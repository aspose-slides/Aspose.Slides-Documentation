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
- formattazione
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri Aspose.Slides for Python via .NET: una potente API per creare, modificare, automatizzare e convertire presentazioni PowerPoint e OpenDocument in modo efficiente."
---
## **Piattaforme supportate**
Le piattaforme su cui Aspose.Slides for Python via .NET può essere utilizzato sono Windows x64 o x86 e un'ampia gamma di distribuzioni Linux con Python 3.5 o successivo installato. Sono presenti requisiti aggiuntivi per la piattaforma Linux di destinazione:
- Librerie di runtime GCC-6 (o successive)
- Dipendenze del .NET Core Runtime. L'installazione del .NET Core Runtime stesso NON è necessaria
- Per Python 3.5-3.7: è necessario il build `pymalloc` di Python. L'opzione di build `--with-pymalloc` di Python è abilitata per default. Tipicamente, il build `pymalloc` di Python è contrassegnato con il suffisso `m` nel nome del file.
- `libpython` libreria condivisa di Python. L'opzione di build `--enable-shared` di Python è disabilitata per default, alcune distribuzioni Python non contengono la libreria condivisa `libpython`. Per alcune piattaforme Linux, la libreria condivisa `libpython` può essere installata tramite il gestore di pacchetti, ad esempio: `sudo apt-get install libpython3.7`. Il problema comune è che la libreria `libpython` è installata in una posizione diversa da quella standard del sistema per le librerie condivise. Il problema può essere risolto usando le opzioni di build di Python per impostare percorsi di libreria alternativi durante la compilazione di Python, o risolto creando un collegamento simbolico al file della libreria `libpython` nella posizione standard del sistema per le librerie condivise. Tipicamente, il nome del file della libreria condivisa `libpython` è `libpythonX.Ym.so.1.0` per Python 3.5-3.7, o libpythonX.Y.so.1.0 per Python 3.8 o successivo (ad esempio: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Se hai bisogno di supporto per ulteriori piattaforme, consulta i prodotti "fratelli gemelli" Aspose.Slides for .NET o Aspose.Slides for Java.

## **Formati file e conversioni**
Aspose.Slides for Python via .NET supporta la maggior parte dei formati di documento PowerPoint. Consente inoltre di esportarli nei formati più diffusi che le organizzazioni utilizzano e scambiano tra loro. Consulta questi dettagli:

|**Funzione**|**Descrizione**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/it/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET offre la più rapida elaborazione per questo formato di documento di presentazione.|
|[PPT to PPTX conversion](/slides/it/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET supporta la conversione da PPT a PPTX.|
|[Portable Document Format (PDF)](/slides/it/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Puoi esportare tutti i formati file supportati in documenti Adobe Portable Document Format (PDF) con un unico metodo.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/it/python-net/convert-powerpoint-to-xps/)|Puoi esportare tutti i formati file supportati in documenti XML Parser Specification (XPS) con un unico metodo.|
|[Tagged Image File Format (TIFF)](/slides/it/python-net/convert-powerpoint-to-tiff/)|Puoi esportare tutti i formati di file di presentazione supportati in Tagged Image File Format (TIFF).|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/it/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET supporta la conversione di PresentationEx in formato HTML.|

## **Rendering delle presentazioni**
Aspose.Slides for Python via .NET supporta il rendering ad alta fedeltà delle diapositive nei documenti di presentazione in vari formati grafici. Consulta questi dettagli:

|**Funzione**|**Descrizione**|
| :- | :- |
|.NET Supported Image Formats|Con Aspose.Slides for Python via .NET, è possibile renderizzare le diapositive di presentazione e le immagini sulle diapositive in tutti i formati grafici supportati da .NET, come TIFF, PNG, BMP, JPEG, GIF e metafile.|
|SVG Format|Aspose.Slides for Python via .NET fornisce anche metodi integrati che consentono di esportare le diapositive di presentazione in formati Scalable Vector Graphics (SVG).|

## **Funzionalità del contenuto**
Aspose.Slides for Python via .NET consente di accedere, modificare o creare quasi tutti gli elementi o i contenuti dei documenti di presentazione. Consulta questi dettagli:

|**Funzione**|**Descrizione**|
| :- | :- |
|Diapositive master|Le diapositive master definiscono il layout delle diapositive normali. Aspose.Slides for Python via .NET consente di accedere e modificare le diapositive master dei documenti di presentazione|
|Diapositive normali|Con Aspose.Slides for Python via .NET, è possibile creare nuove diapositive di diversi tipi; è inoltre possibile accedere e modificare le diapositive esistenti nelle presentazioni|
|Clonazione / Copia di diapositive|Sono disponibili metodi integrati forniti da Aspose.Slides for Python via .NET che consentono di clonare o copiare diapositive esistenti all'interno di una presentazione. È inoltre possibile utilizzare diapositive copiate e clonate da una presentazione all'altra. Poiché una diapositiva eredita il layout dalla diapositiva master, i metodi di clonazione integrati copiano automaticamente il master durante la clonazione|
|Gestione delle sezioni di diapositive|Metodi per organizzare le diapositive in diverse sezioni all'interno di una presentazione|
|Segnaposti e segnaposto testo|È possibile accedere ai segnaposti e ai segnaposto di testo in una diapositiva. Inoltre, è possibile creare una diapositiva con segnaposto di testo da zero utilizzando il metodo appropriato|
|Intestazioni e piè di pagina|Aspose.Slides for Python via .NET facilita la gestione di intestazioni/​piè di pagina nelle diapositive|
|Note nelle diapositive|Con Aspose.Slides for Python via .NET, è possibile accedere e modificare le note associate a una diapositiva e anche aggiungere nuove note|
|Ricerca di una forma|È anche possibile trovare una forma particolare in una diapositiva usando il testo alternativo associato alla forma|
|Sfondi|Aspose.Slides for Python via .NET consente di lavorare con gli sfondi associati a una diapositiva master o normale in una presentazione|
|Caselle di testo|Le caselle di testo possono essere create da zero. È possibile accedere alle caselle di testo esistenti. È anche possibile modificare i loro testi senza perdere il formato originale|
|Forme rettangolari|È possibile creare o modificare forme rettangolari con Aspose.Slides for Python via .NET|
|Forme polilinea|È possibile creare o modificare forme polilinea con Aspose.Slides for Python via .NET|
|Forme ellittiche|È possibile creare o modificare forme ellittiche con Aspose.Slides for Python via .NET|
|Forme di gruppo|Aspose.Slides for Python via .NET supporta le forme di gruppo|
|Forme automatiche|Aspose.Slides for Python via .NET supporta le forme automatiche|
|SmartArt|Aspose.Slides for Python via .NET fornisce supporto per le forme SmartArt in MS PowerPoint|
|Charts|Aspose.Slides for Python via .NET fornisce supporto per i grafici MSO in PowerPoint|
|Serializzazione delle forme|Aspose.Slides for Python via .NET supporta un gran numero di forme. Quando Aspose.Slides for Python via .NET non supporta una forma, è possibile usare un metodo di serializzazione per serializzare quella forma da una diapositiva esistente. In questo modo, è possibile utilizzare la forma ulteriormente secondo le proprie esigenze|
|Cornici immagine|È possibile gestire le immagini in cornici immagine con Aspose.Slides for Python via .NET|
|Cornici audio|È possibile collegare o incorporare file audio in cornici audio sulle diapositive con Aspose.Slides for Python via .NET|
|Cornici video|È possibile gestire file video in cornici video. Aspose.Slides for Python via .NET fornisce anche supporto per video collegati e incorporati|
|Cornice OLE|È possibile gestire oggetti OLE in cornici OLE con Aspose.Slides for Python via .NET|
|Tabelle|Aspose.Slides for Python via .NET supporta le tabelle nelle diapositive|
|Controlli ActiveX|Supporto per i controlli ActiveX|
|Macro VBA|Supporto per la gestione delle macro VBA all'interno delle presentazioni.|
|Cornice di testo|È possibile accedere al testo di qualsiasi forma tramite la cornice di testo associata a quella forma|
|Scansione del testo|È possibile scansire il testo in una presentazione a livello di presentazione o di diapositiva tramite metodi di scansione integrati.|
|Animazioni|È possibile applicare animazioni alle forme|
|Presentazioni diapositive|Aspose.Slides for Python via .NET supporta presentazioni diapositive e transizioni di diapositive|

## **Funzionalità di formattazione**
Consente di formattare testi e forme sulle diapositive nelle presentazioni. Consulta questi dettagli:

|**Funzione**|**Descrizione**|
| :- | :- |
|Text Formatting|<p>In Aspose.Slides for Python via .NET, è possibile gestire i testi tramite i riquadri di testo associati alle forme. Pertanto, è possibile formattare i testi usando i paragrafi e le porzioni associate ai riquadri di testo. Questi elementi di testo possono essere formattati tramite Aspose.Slides for Python via .NET.</p><p>- Tipo di carattere</p><p>- Dimensione del carattere</p><p>- Colore del carattere</p><p>- Tinte del carattere</p><p>- Allineamento del paragrafo</p><p>- Elenco puntato del paragrafo</p><p>- Orientamento del paragrafo</p>|
|Shape Formatting|<p>In Aspose.Slides for Python via .NET, l'elemento base di una diapositiva è una forma. È possibile formattare questi elementi di forma con Aspose.Slides for Python via .NET:</p><p>- Posizione</p><p>- Dimensione</p><p>- Linea</p><p>- Riempimento (inclusi Pattern, Gradiente, Solido)</p><p>- Testo</p><p>- Immagine</p>|

## **FAQ**

### Devo installare Microsoft PowerPoint sul server/PC affinché la libreria funzioni?

No. PowerPoint non è necessario; Aspose.Slides è un motore autonomo per creare, modificare, convertire e renderizzare presentazioni.

### Come funziona il multithreading? È possibile parallelizzare l'elaborazione?

It is safe to process different documents in different threads; the same [presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) object must not be used by [multiple threads](/slides/it/python-net/multithreading/) at the same time.

### Sono supportate le password dei file e la crittografia?

Sì. [Puoi](/slides/it/python-net/password-protected-presentation/) aprire presentazioni criptate, impostare o rimuovere una password di apertura e scrittura, e verificare lo stato di protezione.

### Devo preoccuparmi dei pacchetti di font nei contenitori Linux?

Sì. Si consiglia di installare i pacchetti di font comuni e/o specificare esplicitamente [specificare le directory dei font](/slides/it/python-net/custom-font/) nella tua applicazione per evitare sostituzioni inattese.

### Ci sono limitazioni nella versione di valutazione?

In [modalità di valutazione](/slides/it/python-net/licensing/), viene aggiunta una filigrana all'output e si applicano determinate limitazioni; è disponibile una [licenza temporanea di 30 giorni](https://purchase.aspose.com/temporary-license/) per testare tutte le funzionalità.

### È supportata l'importazione di formati esterni in una presentazione (PDF/HTML → PPTX)?

Sì. Puoi aggiungere [pagine PDF e contenuto HTML](/slides/it/python-net/import-presentation/) a una presentazione, trasformandoli in diapositive.