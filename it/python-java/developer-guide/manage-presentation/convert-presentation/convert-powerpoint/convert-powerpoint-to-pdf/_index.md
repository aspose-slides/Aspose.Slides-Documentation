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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in Python tramite Java usando Aspose.Slides, con esempi di codice veloci e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire le presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in Python tramite Java offre diversi vantaggi, tra cui la compatibilità su dispositivi diversi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere le diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni dei font, selezionare diapositive specifiche per la conversione e applicare gli standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e poi salva la presentazione come PDF utilizzando il metodo [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save). La classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) espone il metodo [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) che è tipicamente utilizzato per convertire una presentazione in PDF.

{{% alert color="info" title="Nota" %}}
Aspose.Slides per Python tramite Java inserisce le informazioni sulla sua API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruire Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.
{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche da una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Gli elementi e gli attributi vengono renderizzati accuratamente durante la conversione, includendo:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione del paragrafo
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Punti elenco
* TabelLe

## **Convertire PowerPoint in PDF**

La conversione standard utilizza le impostazioni predefinite di esportazione PDF. Utilizza opzioni personalizzate quando è necessario controllare la qualità delle immagini, il contenuto delle pagine o la conformità PDF.

Installa [Aspose.Slides for Python via Java](/slides/it/python-java/installation/) e un runtime Java compatibile prima di eseguire gli esempi. Ogni esempio legge `presentation.pptx` dalla directory di lavoro corrente; sostituiscila con il tuo file PPT, PPTX o ODP. Avvia la JVM una sola volta per processo Python.

Questo codice converte una presentazione in PDF:

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

{{% alert color="info" title="Nota" %}}
Aspose offre un gratuito [**convertitore da PowerPoint a PDF**](https://products.aspose.app/slides/it/conversion/ppt-to-pdf) online che dimostra il processo di conversione da presentazione a PDF. Puoi eseguire un test con questo convertitore per una implementazione pratica della procedura descritta qui.
{{% /alert %}}

## **Convertire PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/)—che consentono di personalizzare il PDF risultante, bloccare il PDF con una password o specificare come deve procedere il processo di conversione.

### **Convertire PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro ancora.

Il esempio di codice seguente dimostra come convertire una presentazione PowerPoint in PDF con diverse opzioni personalizzate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convertire PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) della classe [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

Questo codice mostra come convertire una presentazione PowerPoint in PDF includendo le diapositive nascoste:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convertire PowerPoint in un PDF Protetto da Password**

Questo codice dimostra come convertire una presentazione PowerPoint in un PDF protetto da password utilizzando i parametri di protezione della classe [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Rilevare le Sostituzioni dei Font**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveoptions/#setWarningCallback) nella classe [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/), consentendo di rilevare le sostituzioni dei font durante il processo di conversione da presentazione a PDF.

Utilizza un proxy JPype per ricevere i callback di avviso dall'API Java. Converti la stringa di descrizione Java in una stringa Python prima di verificarne il prefisso:

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


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Per ulteriori informazioni su come ricevere i callback per le sostituzioni dei font durante il processo di rendering, consulta [Getting Warning Callbacks for Font Substitution](/slides/it/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Per ulteriori informazioni sulla sostituzione dei font, vedi l'articolo [Font Substitution](/slides/it/python-java/font-substitution/).
{{% /alert %}}

## **Convertire Diapositive Selezionate da PowerPoint in PDF**

I numeri delle diapositive passati a [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) sono basati su 1. Questo esempio esporta le diapositive 1 e 3 quando entrambe esistono:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **Convertire PowerPoint in PDF con Dimensioni Personalizzate della Diapositiva**

Questo esempio esporta la prima diapositiva su una pagina di dimensioni 612 per 792 punti (US Letter). Clona la diapositiva in una nuova presentazione con le dimensioni specificate:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **Convertire PowerPoint in PDF nella Visualizzazione Note della Diapositiva**

Questo codice dimostra come convertire una presentazione PowerPoint in un PDF che includa le note:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Standard di Accessibilità e Conformità per PDF**

Quando si preparano PDF accessibili, consultare le [Linee guida per l'accessibilità dei contenuti web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Utilizzare [PdfOptions.setCompliance](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setCompliance) per selezionare uno standard di output: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

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

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta le grafiche complesse come SmartArt, diagrammi e formule come un'unica figura. Gli elementi di percorso individuali non vengono conservati come contenuti separati e potrebbero essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in blocco?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui propri file e applicare il processo di conversione tramite codice.

**È possibile proteggere con password il PDF convertito?**

Sì. Utilizza la classe [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Utilizza il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) nella classe [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità dell'immagine nel PDF?**

Sì, è possibile controllare la qualità dell'immagine utilizzando metodi come [setJpegQuality](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setJpegQuality) e [setSufficientResolution](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setSufficientResolution) nella classe [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/) per garantire immagini ad alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF conformi a [vari standard](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfcompliance/), tra cui PDF/A1a, PDF/A1b e PDF/UA, per l'accessibilità o l'archiviazione. Scegli lo standard appropriato e verifica l'output rispetto ai tuoi requisiti.

## **Risorse Aggiuntive**

- [Documentazione di Aspose.Slides per Python via Java](/slides/it/python-java/)
- [Riferimento API di Aspose.Slides per Python via Java](https://reference.aspose.com/slides/it/python-java/)
- [Convertitori Online Gratuiti di Aspose](https://products.aspose.app/slides/it/conversion)