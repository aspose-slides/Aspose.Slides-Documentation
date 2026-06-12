---
title: Formati di file diversi e conversioni
type: docs
weight: 50
url: /it/cpp/different-file-formats-and-conversions/
---
## **Microsoft PowerPoint (PPT)**
### **Informazioni su PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) è il formato di file per documenti di presentazione che può essere creato, letto, manipolato e scritto da diverse versioni di Microsoft PowerPoint. È il formato binario per documenti di presentazione sviluppato da Microsoft.
### **PPT in Aspose.Slides for C++**
Aspose.Slides for C++ può leggere i file PPT creati dal software elencato di seguito.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Allo stesso modo, i file PPT creati da Aspose.Slides for C++ possono essere letti dal suddetto insieme di software.
### **Supporto completo per PPT**
Aspose.Slides for C++ fornisce supporto per quasi tutte le funzionalità relative al formato di file PPT. Non solo copre le funzionalità di base/avanzate offerte dalle diverse versioni di Microsoft PowerPoint per la manipolazione dei documenti PPT, ma anche alcune funzionalità che neppure Microsoft PowerPoint supporta. Il principale vantaggio dell'utilizzo della libreria API Aspose.Slides for C++ è la facilità d'uso nella gestione di tali funzionalità.

Oltre alle attività di base relative alla creazione, lettura e scrittura di file PPT, Aspose.Slides for C++ offre diverse funzionalità, tra cui:

- Importare altri formati di file MS Office come oggetti OLE nei documenti PPT.
- Esportare documenti PPT in formati PDF, TIFF, XPS.
- Esportare le diapositive dei documenti PPT in formati SVG.
- Renderizzare le diapositive in qualsiasi formato immagine supportato dal Framework C++.
- Impostare la dimensione delle diapositive nel documento PPT.
- Gestire le animazioni sulle forme.
- Gestire le presentazioni.
- Formattare il testo sulle diapositive.
- Scansionare il testo dai documenti PPT.
- Gestire le tabelle sulle diapositive.
- Copia automatica dei master utilizzando la funzionalità di clonazione.
Un file PPT generato da Aspose.Slides for C++ e aperto in Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **Informazioni su PresentationML**
PresentationML è il nome di una famiglia di formati basati su XML per documenti di presentazione. Office OpenXML (OOXML) è il formato basato su XML introdotto nelle applicazioni Microsoft Office 2007. Office OpenXML è un formato contenitore per diversi linguaggi di markup basati su XML specializzati. PresentationML è il linguaggio di markup utilizzato da Microsoft Office PowerPoint 2007 per memorizzare i suoi documenti.
### **PresentationML in Aspose.Slides for C++**
I documenti OOXML PresentationML vengono forniti come file PPTX, che sono pacchetti XML compressi che seguono le specifiche [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for C++ supporta ampiamente la creazione, lettura, manipolazione e scrittura di documenti PresentationML. Inoltre, Aspose.Slides for C++ è in grado di esportare i documenti PresentationML in diversi formati di documento ampiamente utilizzati, come PDF, TIFF e XPS. Questo è possibile perché Aspose.Slides for C++ è stato progettato con l'obiettivo di gestire in modo completo i documenti di presentazione e PresentationML mantiene essenzialmente la presentazione interna dei documenti come pacchetto XML compresso.
Un documento PPTX generato da Aspose.Slides for C++ e aperto in Microsoft PowerPoint
Visualizzazione del documento PPTX generato da Aspose.Slides for C++ in un'applicazione Zip
### **PresentationML è open, perché usare Aspose.Slides for C++**
Poiché PresentationML è basato su XML, è assolutamente possibile creare applicazioni per l'elaborazione e la generazione di documenti PresentationML utilizzando classi XML senza fare affidamento su librerie di classi di terze parti come Aspose.Slides for C++. Tuttavia, vi sono diversi vantaggi nell'utilizzare Aspose.Slides for C++ rispetto alle classi XML quando si lavora con documenti PresentationML.

La specifica OOXML è molto lunga, conta diverse migliaia di pagine. Ciò significa che, per gestire correttamente i documenti PresentationML, dovrai dedicare molto tempo e sforzo per comprendere il formato di tali documenti. D'altra parte, usando Aspose.Slides for C++, basta utilizzare le classi pertinenti e i rispettivi metodi / proprietà per eseguire operazioni che apparirebbero molto complesse se effettuate tramite classi XML.

Di seguito sono elencate alcune funzionalità che non sono nemmeno disponibili quando si gestiscono documenti PresentationML tramite classi XML:

- Esportare documenti PPT in formati PDF, TIFF, XPS
- Esportare le diapositive dei documenti PPT in formati SVG
- Renderizzare le diapositive in qualsiasi formato immagine supportato dal Framework C++
- Copia automatica dei master dalle presentazioni di origine utilizzando la funzionalità di clonazione
- Applicare protezione sulle forme

Prendiamo ad esempio un documento PresentationML che contiene una singola diapositiva con una casella di testo contenente il testo “Hello World”. Per leggere il testo tramite classi XML, dovrai scrivere un programma in grado di analizzare questo semplice testo dal seguente frammento:
``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>

```
## **Conversione da PPT a PPTX**
### **Informazioni sulla conversione**
Aspose.Slides ora supporta anche la conversione da PPT a PPTX.
### **Funzionalità supportate nella conversione**
Aspose.Slides for C++ fornisce supporto parziale per la conversione di presentazioni in formato file PPT a presentazioni in formato file PPTX. Poiché il supporto per la funzionalità di conversione di presentazioni è stato appena introdotto in Aspose.Slides for C++, al momento ha capacità limitate e funziona solo per forme semplici di presentazioni. Il principale vantaggio che la libreria API Aspose.Slides for C++ fornisce per la conversione di presentazioni PPT al formato PPTX è la facilità d'uso dell'API per raggiungere l'obiettivo desiderato. Si prega di consultare this[link]() per la sezione degli snippet di codice per ulteriori dettagli. La sezione seguente illustra chiaramente quali funzionalità sono supportate e non supportate durante la conversione di presentazioni in formato PPT a presentazioni in formato PPTX.
### **Funzionalità supportate**
Le seguenti funzionalità sono supportate durante la conversione:

- Conversione della struttura di master, layout e diapositive
- Conversione della struttura di master, layout e diapositive
- Conversione di grafici
- Forme di gruppo
- Conversione di Auto-shape, inclusi rettangoli ed ellissi. Tuttavia, è possibile che le Auto-shape abbiano valori di regolazione errati
- Forme con geometria personalizzata. A volte potrebbero non essere convertite
- Stile di riempimento con texture e immagini per Auto-shape. A volte potrebbero non essere convertiti
- Conversione dei segnaposti
- Conversione del testo in caselle di testo e contenitori di testo. Tuttavia, i punti elenco, l'allineamento e le tabulazioni non sono completamente implementati
### **Funzionalità non supportate**
Le seguenti funzionalità non sono supportate durante la conversione:

- Diapositive con note poiché la lettura delle note non è implementata in PPTX. Nel caso in cui il PPT le contenga, non può ancora essere salvato come PPTX* Conversione di linee e polilinee
- Formati di linea e riempimento
- Stili di riempimento a gradiente
- Cornici OLE, tabelle, video e fotogrammi audio, ecc.
- Animazione e altre proprietà della presentazione vengono ignorate
Nuove funzionalità o funzionalità mancanti saranno aggiunte successivamente nelle prossime versioni di Aspose.Slides for C++.
Presentazione PPT di origine
Presentazione PPTX convertita
## **Portable Document Format (PDF)**
### **Informazioni su PDF**
Il [Portable Document Format](https://en.wikipedia.org/wiki/PDF) è un formato di file creato da Adobe System per lo scambio di documenti tra diverse organizzazioni. Lo scopo di questo formato era rendere possibile che il contenuto dei documenti possa essere rappresentato in modo tale che il loro aspetto visivo non dipenda dalla piattaforma su cui vengono visualizzati.
### **PDF in Aspose.Slides for C++**
Qualsiasi documento di presentazione che può essere caricato in Aspose.Slides for C++ può essere convertito in documento PDF che può conformarsi a [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) o [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) in base alla tua scelta. Aspose.Slides for C++ esporta i documenti di presentazione in PDF in modo tale che, nella maggior parte dei casi, il documento PDF esportato appare quasi identico al documento di presentazione originale. La soluzione Aspose supporta le seguenti funzionalità dei documenti di presentazione durante la conversione in documenti PDF:

- Immagini, caselle di testo e altre forme
- Testo e formattazione
- Paragrafi e formattazione
- Collegamenti ipertestuali
- Intestazioni e piè di pagina
- Elenco puntato
- Tabelle

La esportazione dei documenti di presentazione in PDF può essere effettuata direttamente utilizzando solo il componente Aspose.Slides for C++. Non è necessario alcun altro componente di terze parti o Aspose.Pdf a tale scopo. Inoltre, è possibile personalizzare l'esportazione della presentazione in PDF con diverse opzioni come spiegato in [questo argomento](/slides/it/cpp/convert-powerpoint-to-pdf/).
Un documento di presentazione convertito in documento PDF tramite Aspose.Slides for C++
## **XML Parser Specification (XPS)**
### **Informazioni su XPS**
La [XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) è un linguaggio di descrizione pagina e un formato di documento a layout fisso originariamente sviluppato da Microsoft. Come PDF, XPS è un formato di documento a layout fisso progettato per preservare la fedeltà del documento e fornire un aspetto indipendente dal dispositivo.
### **XPS in Aspose.Slides for C++**
Qualsiasi documento di presentazione che può essere caricato da Aspose.Slides for C++ può essere convertito in formato XPS. Aspose.Slides for C++ utilizza il motore di layout di pagina ad alta fedeltà e di rendering per produrre output nel formato XPS a layout fisso. Vale la pena menzionare che Aspose.Slides for C++ genera direttamente XPS senza dipendere dalle classi Windows Presentation Foundation (WPF) incluse nel Framework C++ 3.5, consentendo così ad Aspose.Slides for C++ di produrre documenti XPS su macchine che eseguono versioni del Framework C++ precedenti alla 3.5. Puoi apprendere come esportare i documenti di presentazione in documenti XPS tramite Aspose.Slides for C++ in [questo argomento](https://docs.aspose.com/slides/it/cpp/convert-powerpoint-to-xps/).
Un documento di presentazione convertito in documento XPS tramite Aspose.Slides for C++