---
title: Converti PPT e PPTX in PDF in Python tramite Java [Funzionalità Avanzate Incluse]
linktitle: PowerPoint in PDF
type: docs
weight: 40
url: /it/python-java/convert-powerpoint-to-pdf/
keywords:
- converti PowerPoint
- converti presentazione
- PowerPoint in PDF
- presentazione in PDF
- PPT in PDF
- converti PPT in PDF
- PPTX in PDF
- converti PPTX in PDF
- salva PowerPoint come PDF
- salva PPT come PDF
- salva PPTX come PDF
- esporta PPT in PDF
- esporta PPTX in PDF
- allegato
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in Python tramite Java usando Aspose.Slides, con esempi di codice rapidi e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in Python tramite Java offre diversi vantaggi, tra cui la compatibilità su dispositivi diversi e la conservazione del layout e della formattazione della presentazione. Questa guida mostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i file PDF, rilevare sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passare il nome del file come argomento alla classe [Presentazione](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e quindi salvare la presentazione come PDF usando il metodo [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). La classe [Presentazione](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) espone il metodo [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) che è tipicamente usato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides per Python tramite Java inserisce le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Applicazione con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruire Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche di una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Elementi e attributi sono resi accuratamente nella conversione, includendo:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Convertire PowerPoint in PDF**

La conversione standard utilizza le impostazioni predefinite di esportazione PDF. Utilizzare opzioni personalizzate quando è necessario controllare la qualità delle immagini, il contenuto della pagina o la conformità del PDF.

Installa [Aspose.Slides per Python tramite Java](/slides/it/python-java/installation/) e un runtime Java compatibile prima di eseguire gli esempi. Ogni esempio legge `presentation.pptx` dalla directory di lavoro corrente; sostituiscilo con il tuo file PPT, PPTX o ODP. Avvia la JVM una volta per processo Python.

L'esempio seguente carica una presentazione e salva tutte le diapositive visibili in PDF usando le impostazioni di esportazione predefinite.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Aspose offre un [**convertitore online gratuito da PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. Puoi eseguire un test con questo convertitore per una implementazione reale della procedura descritta qui.

{{% /alert %}}

## **Convertire PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—che consentono di personalizzare il PDF risultato, bloccarlo con una password o specificare come deve avvenire il processo di conversione.

### **Convertire PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro ancora.

L'esempio seguente esporta una presentazione in PDF 1.5 con qualità JPEG impostata a 90, risoluzione dell'immagine a 300 DPI, metafile salvati come PNG e compressione testo Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Preservare i File OLE Incorporati come Allegati PDF**

Se una presentazione contiene una cartella di lavoro Excel incorporata, potresti voler consentire ai destinatari del PDF di accedere ai dati della cartella e visualizzare le diapositive. Chiama [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) con `True` per preservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `False`: l'immagine di anteprima o l'icona dell'oggetto OLE viene renderizzata nella pagina PDF, ma il file incorporato non è incluso come allegato. Impostando l'opzione a `True` si includono inoltre i dati del file. L'anteprima rimane una rappresentazione visiva; l'allegato consente ai destinatari di aprire o salvare separatamente il file incorporato. L'oggetto OLE non diventa un foglio di calcolo Excel interattivo nella pagina PDF.

L'esempio seguente carica una presentazione che già contiene una cartella di lavoro Excel incorporata e la esporta in PDF con la cartella allegata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Per verificare il risultato:

1. Apri il PDF esportato in un visualizzatore che supporti gli allegati, ad esempio Adobe Acrobat Reader.
2. Apri il pannello **Attachments** del visualizzatore e individua la cartella di lavoro incorporata.
3. Salva l'allegato e aprilo in Excel per ispezionarne i dati, oppure aprilo direttamente se il visualizzatore lo consente. L'anteprima nella pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}

Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A-1 vieta i file incorporati, PDF/A-2 consente solo allegati PDF/A, e PDF/A-3 consente altri tipi di file, incluse le cartelle di lavoro Excel. Queste sono esigenze degli standard, non restrizioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione predefinita di conformità PDF e non dimostra l'esportazione PDF/A.

{{% /alert %}}

### **Convertire PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) della classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

L'esempio seguente esporta una presentazione in PDF, includendo eventuali diapositive nascoste.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convertire PowerPoint in un PDF Protetto da Password**

L'esempio seguente esporta una presentazione in PDF che richiede la password `password` per l'apertura. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa ad alta qualità.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Rilevare Sostituzioni di Caratteri**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) nella classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), consentendo di rilevare le sostituzioni di caratteri durante il processo di conversione da presentazione a PDF.

L'esempio seguente esporta una presentazione in PDF e stampa gli avvisi di sostituzione dei caratteri sulla console. Un avviso viene stampato solo quando un carattere non disponibile viene sostituito durante l'esportazione. Usa un proxy JPype per ricevere le callback di avviso dall'API Java. Converti la stringa di descrizione Java in una stringa Python prima di verificare il prefisso:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Per ulteriori informazioni sulla sostituzione dei caratteri, consulta l'articolo [Sostituzione di Caratteri](/slides/it/python-java/font-substitution/).

{{% /alert %}}

### **Gestire Caratteri senza Variante Grassetto Dedicata**

Una presentazione può applicare il formato grassetto a del testo anche quando il suo carattere non dispone di una variante grassetto dedicata. Il testo può comunque apparire in grassetto tramite grassetto sintetico, che ispessisce artificialmente i glifi normali. Quando quel testo appare troppo pesante o differente dall'aspetto previsto in PDF, prova a chiamare [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) con `True`. Questa opzione rende il testo interessato come bitmap durante l'esportazione PDF e può migliorarne l'aspetto per alcuni caratteri. Il suo valore predefinito è `False`.

La presentazione di esempio contiene due caselle di testo: una con testo normale e una con formattazione grassetto applicata allo stesso carattere, che non ha una variante grassetto dedicata. L'esempio seguente carica la presentazione, abilita la rasterizzazione degli stili di carattere non supportati e la esporta in PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Le anteprime seguenti mostrano l'output disabilitato e quello abilitato. In questo esempio, il testo in grassetto ha tratti più spessi con l'opzione disabilitata. Con l'opzione abilitata, i tratti sono più leggeri; il testo normale rimane invariato. Confronta i risultati prima di scegliere l'impostazione per la tua presentazione.

| Opzione disabilitata (`False`, l'impostazione predefinita) | Opzione abilitata (`True`) |
|---|---|
| ![PDF con rasterizzazione dello stile di carattere non supportato disabilitata](unsupported-bold-disabled.png) | ![PDF con rasterizzazione dello stile di carattere non supportato abilitata](unsupported-bold-enabled.png) |

In questo esempio, abilitare l'opzione trasforma solo il testo in grassetto in una bitmap: non può essere selezionato, copiato o ricercato come testo senza OCR, e i suoi bordi appaiono più morbidi allo zoom 800 %. Il testo normale rimane ricercabile. Con l'opzione disabilitata, entrambe le stringhe rimangono testo.

Questa opzione rasterizza il testo formattato in grassetto quando il suo carattere non ha una variante grassetto dedicata. La [sostituzione di caratteri](/slides/it/python-java/font-substitution/) invece seleziona un altro carattere quando quello originale non è disponibile.

## **Convertire Diapositive Selezionate da PowerPoint in PDF**

I numeri delle diapositive passati a [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) sono basati su 1. Questo esempio esporta le diapositive 1 e 3 quando entrambe esistono:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Convertire PowerPoint in PDF con Dimensione Diapositiva Personalizzata**

Questo esempio esporta la prima diapositiva su una pagina di dimensioni 612 × 792 punti (US Letter). Clona la diapositiva in una nuova presentazione con le dimensioni specificate e scala il contenuto della diapositiva per adattarlo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Rimuovi la diapositiva vuota con cui è stata creata la nuova presentazione.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Convertire PowerPoint in PDF in Visualizzazione Note Diapositiva**

L'esempio seguente esporta una presentazione in PDF, posizionando le note del relatore di ciascuna diapositiva sotto la diapositiva stessa. Usa una presentazione contenente note del relatore per vedere il risultato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Accessibilità e Standard di Conformità per PDF**

Quando si preparano PDF accessibili, consultare le [Linee Guida per l'Accessibilità dei Contenuti Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Usa [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) per selezionare uno standard di output: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice dimostra un processo di conversione da PowerPoint a PDF che produce più PDF basati su diversi standard di conformità:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafica complessa come SmartArt, grafici e formule come una singola figura. Gli elementi di percorso individuali non sono preservati come contenuti separati e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in blocco?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Sì. Usa la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Chiama [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) con `True` nella classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta la qualità delle immagini nel PDF?**

Sì, è possibile controllare la qualità delle immagini utilizzando metodi come [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) e [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) nella classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) per garantire immagini ad alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF che rispettano [vari standard](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), inclusi PDF/A1a, PDF/A1b e PDF/UA, per accessibilità o archiviazione. Scegli lo standard appropriato e verifica l'output rispetto alle tue esigenze.

## **Risorse Aggiuntive**

- [Documentazione di Aspose.Slides per Python tramite Java](/slides/it/python-java/)
- [Riferimento API di Aspose.Slides per Python tramite Java](https://reference.aspose.com/slides/python-java/)
- [Convertitori Online Gratuiti di Aspose](https://products.aspose.app/slides/conversion)