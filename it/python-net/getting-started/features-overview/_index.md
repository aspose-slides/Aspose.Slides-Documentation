---
title: Panoramica delle funzionalità
type: docs
weight: 20
url: /it/python-net/features-overview/
keywords:
- funzionalità
- piattaforme supportate
- formato file
- conversione
- rendering
- stampa
- formattazione
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri Aspose.Slides for Python via .NET: un'API potente per creare, modificare, automatizzare e convertire presentazioni PowerPoint e OpenDocument in modo efficiente."
---
## **Piattaforme supportate**
Le piattaforme Aspose.Slides for Python via .NET possono essere utilizzate su Windows x64 o x86 e su un'ampia gamma di distribuzioni Linux con Python 3.5 o versioni successive installate. Sono richiesti requisiti aggiuntivi per la piattaforma Linux di destinazione:
- Librerie di runtime GCC-6 (o successive)
- Dipendenze del Runtime .NET Core. L'installazione del Runtime .NET Core non è necessaria
- Per Python 3.5-3.7: è necessaria la build `pymalloc` di Python. L'opzione di compilazione `--with-pymalloc` è abilitata per impostazione predefinita. Tipicamente, la build `pymalloc` di Python è contrassegnata dal suffisso `m` nel nome file.
- `libpython` libreria Python condivisa. L'opzione di compilazione `--enable-shared` è disabilitata per impostazione predefinita; alcune distribuzioni Python non contengono la libreria condivisa `libpython`. Per alcune piattaforme Linux, la libreria condivisa `libpython` può essere installata utilizzando il gestore di pacchetti, ad esempio: `sudo apt-get install libpython3.7`. Il problema più comune è che la libreria `libpython` viene installata in una posizione diversa da quella standard di sistema per le librerie condivise. Il problema può essere risolto impostando percorsi di libreria alternativi mediante le opzioni di compilazione di Python, oppure creando un collegamento simbolico al file della libreria `libpython` nella posizione standard di sistema per le librerie condivise. Tipicamente, il nome file della libreria condivisa `libpython` è `libpythonX.Ym.so.1.0` per Python 3.5-3.7, o `libpythonX.Y.so.1.0` per Python 3.8 o versioni successive (ad esempio: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Se hai bisogno di supporto per ulteriori piattaforme, cerca i prodotti "fratelli gemelli" Aspose.Slides per .NET o Aspose.Slides per Java.

## **Formati file e conversioni**
Aspose.Slides for Python via .NET supporta la maggior parte dei formati di documenti PowerPoint. Consente inoltre di esportarli nei formati più diffusi che le organizzazioni utilizzano e scambiano tra loro. Consulta i dettagli:

|**Funzione**|**Descrizione**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/it/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET fornisce l'elaborazione più veloce per questo formato di documento di presentazione.|
|[Conversione da PPT a PPTX](/slides/it/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET supporta la conversione da PPT a PPTX.|
|[Formato documento portabile (PDF)](/slides/it/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Puoi esportare tutti i formati di file supportati in documenti Adobe Portable Document Format (PDF) con un unico metodo.|
|[Specificazione XML Parser (XPS)](https://docs.aspose.com/slides/it/python-net/convert-powerpoint-to-xps/)|Puoi esportare tutti i formati di file supportati in documenti XML Parser Specification (XPS) con un unico metodo.|
|[Tagged Image File Format (TIFF)](/slides/it/python-net/convert-powerpoint-to-tiff/)|Puoi esportare tutti i formati di file di presentazione supportati in Tagged Image File Format (TIFF).|
|[Conversione PPTX in HTML](https://docs.aspose.com/slides/it/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET supporta la conversione di PresentationEx in formato HTML.|

## **Rendering e stampa**
Aspose.Slides for Python via .NET supporta il rendering ad alta fedeltà delle diapositive nei documenti di presentazione in vari formati grafici. Consulta i dettagli:

|**Funzione**|**Descrizione**|
| :- | :- |
|Formati immagine supportati da .NET|Con Aspose.Slides for Python via .NET, puoi renderizzare le diapositive di presentazione e le immagini nelle diapositive in tutti i formati grafici supportati da .NET come TIFF, PNG, BMP, JPEG, GIF e metafile.|
|Formato SVG|Aspose.Slides for Python via .NET fornisce anche metodi integrati che consentono di esportare le diapositive di presentazione in formati Scalable Vector Graphics (SVG).|
|Stampa della presentazione|Le versioni più recenti di Aspose.Slides per Python via .NET offrono metodi di stampa integrati con diverse opzioni.|

## **Funzionalità dei contenuti**
Aspose.Slides for Python via .NET ti consente di accedere, modificare o creare quasi tutti gli elementi o i contenuti dei documenti di presentazione. Consulta i dettagli:

|**Funzione**|**Descrizione**|
| :- | :- |
|Diapositive master|Le diapositive master definiscono il layout delle diapositive normali. Aspose.Slides for Python via .NET ti consente di accedere e modificare le Diapositive master dei documenti di presentazione|
|Diapositive normali|Con Aspose.Slides for Python via .NET, puoi creare nuove diapositive di diversi tipi; puoi inoltre accedere e modificare le diapositive esistenti nelle presentazioni|
|Clonazione / Copia diapositive|Ci sono metodi integrati forniti da Aspose.Slides for Python via .NET che consentono di clonare o copiare diapositive esistenti all'interno di una presentazione. Puoi anche utilizzare diapositive copiate e clonate da una presentazione all'altra. Poiché una diapositiva eredita il layout dalla diapositiva master, i metodi di clonazione integrati copiano automaticamente il master durante la clonazione|
|Gestione sezioni diapositive|Metodi per organizzare le diapositive in diverse sezioni all'interno di una presentazione|
|Segnaposti e segnaposto testo|Puoi accedere ai segnaposti e ai segnaposto testo in una diapositiva. Inoltre, puoi creare una diapositiva con segnaposto testo da zero usando il metodo appropriato|
|Intestazioni e piè di pagina|Aspose.Slides for Python via .NET facilita la gestione di intestazioni/piè di pagina nelle diapositive|
|Note nelle diapositive|Con Aspose.Slides for Python via .NET, puoi accedere e modificare le note associate a una diapositiva e anche aggiungere nuove note|
|Ricerca di una forma|Puoi anche trovare una forma specifica in una diapositiva usando il testo alternativo associato alla forma|
|Sfondi|Aspose.Slides for Python via .NET ti consente di lavorare con gli sfondi associati a una diapositiva master o normale in una presentazione|
|Caselle di testo|Le caselle di testo possono essere create da zero. Puoi accedere alle caselle di testo esistenti. Puoi anche modificarne il contenuto senza perdere il formato del testo originale|
|Forme rettangolari|Puoi creare o modificare forme rettangolari con Aspose.Slides for Python via .NET|
|Forme polilinea|Puoi creare o modificare forme polilinea con Aspose.Slides for Python via .NET|
|Forme ellisse|Puoi creare o modificare forme ellisse con Aspose.Slides for Python via .NET|
|Forme di gruppo|Aspose.Slides for Python via .NET supporta le forme di gruppo|
|Forme automatiche|Aspose.Slides for Python via .NET supporta le forme automatiche|
|SmartArt|Aspose.Slides for Python via .NET fornisce supporto per le forme SmartArt in MS PowerPoint|
|Grafici|Aspose.Slides for Python via .NET fornisce supporto per i grafici MSO in PowerPoint|
|Serializzazione delle forme|Aspose.Slides for Python via .NET supporta un gran numero di forme. Quando Aspose.Slides for Python via .NET non supporta una forma, puoi utilizzare un metodo di serializzazione per serializzare quella forma da una diapositiva esistente. In questo modo, puoi riutilizzare la forma secondo le tue esigenze|
|Cornici immagine|Puoi gestire le immagini nelle cornici immagine con Aspose.Slides for Python via .NET|
|Cornici audio|Puoi collegare o incorporare file audio nelle cornici audio sulle diapositive con Aspose.Slides for Python via .NET|
|Cornici video|Puoi gestire file video nelle cornici video. Aspose.Slides for Python via .NET fornisce anche supporto per video collegati e incorporati|
|Cornice OLE|Puoi gestire gli oggetti OLE nelle cornici OLE con Aspose.Slides for Python via .NET|
|Tabelle|Aspose.Slides for Python via .NET supporta le tabelle nelle diapositive|
|Controlli ActiveX|Supporto per i controlli ActiveX|
|Macro VBA|Supporto per la gestione delle macro VBA all'interno delle presentazioni|
|Cornice testo|Puoi accedere al testo di qualsiasi forma tramite la cornice testo associata a quella forma|
|Scansione testo|Puoi scansionare il testo in una presentazione a livello di presentazione o diapositiva tramite metodi di scansione integrati|
|Animazioni|Puoi applicare animazioni sulle forme|
|Presentazioni|Aspose.Slides for Python via .NET supporta presentazioni e transizioni diapositive|

## **Funzionalità di formattazione**
Aspose.Slides for Python via .NET ti permette di formattare testi e forme su diapositive nelle presentazioni. Consulta i dettagli:

|**Funzione**|**Descrizione**|
| :- | :- |
|Formattazione testo|<p>In Aspose.Slides for Python via .NET, puoi gestire i testi attraverso le cornici testo associate alle forme. Pertanto, puoi formattare i testi usando i paragrafi e le parti associate alle cornici testo. Questi elementi di testo possono essere formattati tramite Aspose.Slides for Python via .NET.</p><p>- Tipo di carattere</p><p>- Dimensione del carattere</p><p>- Colore del carattere</p><p>- Tinte del carattere</p><p>- Allineamento del paragrafo</p><p>- Elenco puntato del paragrafo</p><p>- Orientamento del paragrafo</p>|
|Formattazione forma|<p>In Aspose.Slides for Python via .NET, l'elemento base di una diapositiva è una forma. Puoi formattare questi elementi forma con Aspose.Slides for Python via .NET:</p><p>- Posizione</p><p>- Dimensione</p><p>- Linea</p><p>- Riempimento (inclusi Pattern, Gradiente, Solido)</p><p>- Testo</p><p>- Immagine</p>|

## **FAQ**

**Devo installare Microsoft PowerPoint sul server/PC affinché la libreria funzioni?**

No. PowerPoint non è necessario; Aspose.Slides è un motore autonomo per creare, modificare, convertire e rendere presentazioni.

**Come funziona il multithreading? È possibile parallelizzare l'elaborazione?**

È sicuro elaborare documenti diversi in thread diversi; lo stesso [presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) oggetto non deve essere usato da [multiple threads](/slides/it/python-net/multithreading/) contemporaneamente.

**Sono supportate le password dei file e la crittografia?**

Sì. [Puoi](/slides/it/python-net/password-protected-presentation/) aprire presentazioni crittografate, impostare o rimuovere una password di apertura e scrittura, e verificare lo stato di protezione.

**Devo preoccuparmi dei pacchetti di font nei container Linux?**

Sì. È consigliato installare i pacchetti di font comuni e/o specificare esplicitamente le [directory dei font](/slides/it/python-net/custom-font/) nella tua applicazione per evitare sostituzioni inattese.

**Ci sono limitazioni nella versione di valutazione?**

In [modalità di valutazione](/slides/it/python-net/licensing/), viene aggiunta una filigrana all'output e si applicano alcune limitazioni; è disponibile una [licenza temporanea di 30 giorni](https://purchase.aspose.com/temporary-license/) per testare tutte le funzionalità.

**È supportata l'importazione di formati esterni in una presentazione (PDF/HTML → PPTX)?**

Sì. Puoi aggiungere [pagine PDF e contenuto HTML](/slides/it/python-net/import-presentation/) a una presentazione, trasformandoli in diapositive.