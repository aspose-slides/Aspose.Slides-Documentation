---
title: FAQ
type: docs
weight: 340
url: /it/python-java/faqs/
keywords:
- FAQ
- formato di presentazione
- errore di memoria insufficiente
- dimensione diapositiva
- estrarre testo
- dimensione paragrafo
- bordi tabella
- font
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Trova le risposte alle domande più comuni su Aspose.Slides per Python tramite Java, inclusi formati di file, utilizzo della memoria, dimensioni delle diapositive, testo, tabelle, immagini e font."
---
## **Panoramica**

Questa FAQ copre i formati di file supportati, l'uso della memoria con presentazioni di grandi dimensioni, le dimensioni delle diapositive e le anteprime, l'estrazione del testo, i bordi delle tabelle, il posizionamento delle immagini e le differenze dei font quando si convertono presentazioni in PDF o immagini.

## **FAQ**

### **Formati di File Supportati**

**Quali formati di file supporta Aspose.Slides per Python tramite Java?**

Consulta [Formati di File Supportati](/slides/it/python-java/supported-file-formats/) per i formati di presentazione, documento e immagine supportati e le loro capacità di importazione ed esportazione.

### **Eccezioni**

**Perché ricevo un errore di out-of-memory durante il caricamento di una presentazione di grandi dimensioni con immagini? Esiste un limite di dimensione del file?**

Non esiste una soglia unica di dimensione del file che preveda se una presentazione entrerà in memoria. I requisiti di memoria dipendono dalla struttura della presentazione, dalle immagini decomprse, dagli effetti e dalle operazioni eseguite. Le immagini possono occupare molta più memoria rispetto alle loro dimensioni compresse su disco.

Aspose.Slides per Python tramite Java utilizza il motore Java tramite JPype, quindi l'heap della JVM deve avere spazio sufficiente per l'elaborazione. La sola RAM di sistema disponibile non indica quanta memoria può utilizzare la JVM. Rilascia le presentazioni con [Presentation.dispose](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#dispose) quando hai finito di usarle. Per la configurazione dell'ambiente, consulta [Requisiti di Sistema](/slides/it/python-java/system-requirements/) e [Installazione](/slides/it/python-java/installation/).

### **Lavorare con le Diapositive**

**Posso modificare le dimensioni delle diapositive in una presentazione?**

Sì. Usa [Presentation.getSlideSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getslidesize) per accedere alle impostazioni delle dimensioni delle diapositive della presentazione, quindi usa [SlideSize.setSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesize/#setsize) per impostare le dimensioni e scegliere come scalare il contenuto esistente.

**Le diapositive nella stessa presentazione possono avere dimensioni diverse?**

No. I documenti Microsoft PowerPoint definiscono la dimensione della diapositiva a livello di presentazione, quindi tutte le diapositive condividono le stesse dimensioni.

**Posso visualizzare un'anteprima di una diapositiva prima di salvare la presentazione?**

Sì. Renderizza la diapositiva in un'immagine e visualizza quell'immagine nella tua applicazione. Non è necessario salvare prima la presentazione.

### **Lavorare con il Testo**

**Posso recuperare tutto il testo da una presentazione?**

Sì. La classe [SlideUtil](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideutil/) fornisce metodi per recuperare il testo da presentazioni e diapositive individuali.

**Perché le dimensioni dei paragrafi sono diverse su Windows e Linux?**

Le dimensioni dei paragrafi dipendono dalle metriche dei font utilizzati per renderizzare il testo. Se un font è assente, un sostituto può avere larghezze dei caratteri e altezze di riga diverse, il che modifica l'andatura del testo e le dimensioni del paragrafo. Installa gli stessi font su entrambi i sistemi o carica gli stessi file di font con [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#loadexternalfonts) prima di creare o caricare le presentazioni.

### **Formattazione e Immagini**

**Come posso impostare il colore del bordo di una tabella?**

Usa [Cell.getCellFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/cell/#getcellformat) per accedere alla formattazione del bordo di ogni cella e impostare il colore di riempimento per i bordi pertinenti. Per modificare tutti i bordi, elabora tutte le celle. Per modificare solo il contorno della tabella, aggiorna solo i bordi esterni delle celle lungo i suoi lati.

**Quali unità vengono utilizzate per posizionare e dimensionare le immagini?**

Le coordinate e le dimensioni delle forme sono misurate in punti. Un pollice corrisponde a 72 punti; questi valori non sono coordinate in pixel.

### **Lavorare con i Font**

**Perché i font cambiano quando converto una presentazione in PDF o immagini?**

I font richiesti potrebbero mancare sulla macchina che esegue la conversione. Installa i font originali o utilizza [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#loadexternalfonts) per aggiungere le cartelle che li contengono. Carica i font esterni prima di creare o aprire le presentazioni.

Il seguente esempio registra una cartella di font. Sostituisci il percorso con una cartella esistente contenente i tuoi file di font. Presume l'ambiente descritto in [Installazione](/slides/it/python-java/installation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

L'esempio mantiene la JVM in esecuzione per le operazioni successive sulla presentazione. Per l'uso nei notebook e le restrizioni sul ciclo di vita della JVM, consulta [Limitazioni e Differenze API](/slides/it/python-java/limitations-and-api-differences/).