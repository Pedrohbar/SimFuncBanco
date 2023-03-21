PGDMP         .                {            postgres    15.2    15.2     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    5    postgres    DATABASE        CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Portuguese_Brazil.1252';
    DROP DATABASE postgres;
                postgres    false            �           0    0    DATABASE postgres    COMMENT     N   COMMENT ON DATABASE postgres IS 'default administrative connection database';
                   postgres    false    3326                        3079    16384 	   adminpack 	   EXTENSION     A   CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;
    DROP EXTENSION adminpack;
                   false                        0    0    EXTENSION adminpack    COMMENT     M   COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';
                        false    2            �            1259    24591    conta    TABLE     �   CREATE TABLE public.conta (
    numero integer NOT NULL,
    nomeusuario character varying(50) NOT NULL,
    saldo double precision NOT NULL
);
    DROP TABLE public.conta;
       public         heap    postgres    false            �            1259    24590    conta_numeroConta_seq    SEQUENCE     �   CREATE SEQUENCE public."conta_numeroConta_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."conta_numeroConta_seq";
       public          postgres    false    216                       0    0    conta_numeroConta_seq    SEQUENCE OWNED BY     L   ALTER SEQUENCE public."conta_numeroConta_seq" OWNED BY public.conta.numero;
          public          postgres    false    215            f           2604    24594    conta numero    DEFAULT     s   ALTER TABLE ONLY public.conta ALTER COLUMN numero SET DEFAULT nextval('public."conta_numeroConta_seq"'::regclass);
 ;   ALTER TABLE public.conta ALTER COLUMN numero DROP DEFAULT;
       public          postgres    false    216    215    216            �          0    24591    conta 
   TABLE DATA           ;   COPY public.conta (numero, nomeusuario, saldo) FROM stdin;
    public          postgres    false    216   4                  0    0    conta_numeroConta_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."conta_numeroConta_seq"', 1, false);
          public          postgres    false    215            h           2606    24596    conta conta_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.conta
    ADD CONSTRAINT conta_pkey PRIMARY KEY (numero);
 :   ALTER TABLE ONLY public.conta DROP CONSTRAINT conta_pkey;
       public            postgres    false    216            �   &   x�34261�HM)�W�H�+�,,M�41����� �g�     