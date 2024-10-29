Questo progetto si riferisce a uno dei progetti dell'anno 2023/2024, e sarebbe il progetto N01, di seguito la traccia:
------------------------------------------------------------------------------
Realizzare una web api che permetta la gestione di un catalogo di una libreria.
L'applicazione deve avere un elenco di utenti con le seguenti proprietà :
- Email
- Nome 
- Cognome
- Password

Un libro ha le seguenti proprietà :
- Nome
- Autore
- Data di Pubblicazione
- Editore
- Un insieme di categorie
Una categoria ha le seguenti proprietà :
- Nome

Le api che dovranno essere realizzate sono le seguenti :
 - Creazione di un utente (anonima senza autenticazione)
 - Autenticazione
 - Creazione di una Categoria (non possono esistere due categorie con lo stesso nome)
 - Eliminazione di una Categoria (solamente se la categoria non contiene libri)
 - Caricamento di un libro
 - Modifica di un libro
 - Eliminazione di un libro
 - Ricerca di un libro in base alle seguenti proprietà (obbligatoria almeno un filtro) :
      - Categoria
	  - Nome del libro
	  - Data di Pubblicazione
	  - Autore
   La ricerca dovrà paginare i risultati, in base ad un parametro passato nella chiamata
-------------------------------------------------------------------------------------------
ISTRUZIONI PER L'USO:
Dopo che avrà scaricato il codice e il file del database (Libreria.bacpac), dovrà importare quest'ultimo in SQL Management Studio. (qui una guida su come farlo https://www.geeksforgeeks.org/how-to-import-and-export-sql-server-database/).

Su SQL Management Studio il nome del server su cui collegagarsi sarà "localhost", il nome del database sarà "Libreria", quindi quando lo importerà non dovrà cambiare nulla, mentre per l'Account di accesso, dovrà creare un account chiamato "progettolibreria" con la password "libreria".

Fatto ciò ora puo eseguire il codice, e nell'autenticazione per il JWT token puo utilizzare i seguenti account:
-Email:Mariorossi123@gmail.com, Password:String8*
-Email:luigiverdi45@libero.it, Password:Value88#
-Email:CarloGiallo67@gmail.com, Password:Value1*
Oppure ne crea uno nuovo, cosi potrà utilizzare tutte le api disponibili.

Per la paginazione dei libri può mettere direttamente l'autore: Bram Stoker, dato che è l'unico che ha 6 libri all'interno del database



