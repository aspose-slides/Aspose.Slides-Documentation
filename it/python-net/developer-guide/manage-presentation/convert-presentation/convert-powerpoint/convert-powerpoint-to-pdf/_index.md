---
title: Converti PPT e PPTX in PDF con Python | Opzioni Avanzate
linktitle: PowerPoint in PDF
type: docs
weight: 40
url: /it/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- converti PowerPoint
- presentazione
- PowerPoint in PDF
- PPT in PDF
- PPTX in PDF
- salva PowerPoint come PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Guida passo a passo per convertire PPT, PPTX e ODP in PDF di alta qualità e conformi a WCAG in Python con Aspose.Slides—include protezione con password, selezione diapositive e controllo della qualità delle immagini."
showReadingTime: true
---
## **Panoramica**

Convertire le presentazioni PowerPoint (PPT, PPTX, ODP) in formato PDF in Python offre diversi vantaggi, tra cui garantire la compatibilità su diversi dispositivi e preservare la disposizione e la formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i documenti PDF, rilevare le sostituzioni dei font, selezionare diapositive specifiche per la conversione e applicare normative di conformità ai documenti di output.

## **Installazione**

```bash
pip install aspose.slides
```

Il pacchetto include il runtime necessario, quindi Microsoft PowerPoint non deve essere installato sulla macchina che esegue la conversione.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire le presentazioni in questi formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF in Python, è sufficiente passare il nome del file come argomento nella classe [Presentation](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/) e quindi salvare la presentazione come PDF utilizzando il metodo [Save](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/#methods). La classe [Presentation](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/) espone il metodo [Save](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/#methods) tipicamente usato per convertire una presentazione in PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides per Python scrive direttamente le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, quando converte una presentazione in PDF, Aspose.Slides per Python popola il campo Application con il valore '*Aspose.Slides*' e il campo PDF Producer con un valore in forma '*Aspose.Slides v XX.XX*'. **Nota** che non è possibile indicare ad Aspose.Slides per Python di modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche in una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che il contenuto dei PDF risultanti corrisponda strettamente alle presentazioni originali. Elementi e attributi vengono renderizzati accuratamente nella conversione, includendo:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

L'operazione standard di conversione da PowerPoint a PDF viene eseguita utilizzando le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali al massimo livello di qualità. Questo codice Python mostra come convertire un PowerPoint in PDF:

_Steps: PowerPoint to PDF Conversions in Python_

Il seguente codice di esempio spiega queste conversioni usando Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Passaggi: Converti PowerPoint in PDF usando Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Passaggi: Converti PPT in PDF usando Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Passaggi: Converti PPTX in PDF usando Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Passaggi: Converti ODP in PDF usando Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Passaggi: Converti PPS in PDF usando Python via .NET</a></strong>

_Code Steps:_

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e forniscile il file PowerPoint.
  * _.ppt_ estensione per caricare il file **PPT** nella classe _Presentation_.
  * _.pptx_ estensione per caricare il file **PPTX** nella classe _Presentation_.
  * _.odp_ estensione per caricare il file **ODP** nella classe _Presentation_.
  * _.pps_ estensione per caricare il file **PPS** nella classe _Presentation_.
- Salva la _Presentation_ in formato **PDF** chiamando il metodo **Save** e usando l'enumerazione **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Istanzia una classe Presentation che rappresenta un file PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Salva la presentazione come PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose offre un [**convertitore online gratuito da PowerPoint a PDF**](https://products.aspose.app/slides/it/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. Per una implementazione reale della procedura descritta qui, è possibile eseguire un test con il convertitore.

{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà nella classe [PdfOptions](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides.export/pdfoptions/)—che consentono di personalizzare il PDF (risultato del processo di conversione), bloccare il PDF con una password o persino specificare come deve svolgersi il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile impostare la qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per i testi, impostare DPI per le immagini, ecc.

Il seguente esempio di codice dimostra un'operazione in cui una presentazione PowerPoint viene convertita in PDF con diverse opzioni personalizzate:

```python
import aspose.slides as slides

# Istanzia la classe PdfOptions
pdf_options = slides.export.PdfOptions()

# Imposta la qualità per le immagini JPG
pdf_options.jpeg_quality = 90

# Imposta DPI per le immagini
pdf_options.sufficient_resolution = 300

# Imposta il comportamento per i metafile
pdf_options.save_metafiles_as_png = True

# Imposta il livello di compressione del testo per il contenuto testuale
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definisce la modalità di conformità PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Istanzia la classe Presentation che rappresenta un documento PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Salva la presentazione come documento PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare un'opzione personalizzata—la proprietà `show_hidden_slides` della classe [PdfOptions](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides.export/pdfoptions/)—per indicare ad Aspose.Slides di includere le diapositive nascoste come pagine nel PDF risultante.

Questo codice Python mostra come convertire una presentazione PowerPoint in PDF includendo le diapositive nascoste:

```python
import aspose.slides as slides

# Istanzia una classe Presentation che rappresenta un file PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Istanzia la classe PdfOptions
pdfOptions = slides.export.PdfOptions()

# Aggiunge diapositive nascoste
pdfOptions.show_hidden_slides = True

# Salva la presentazione come PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Converti PowerPoint in PDF Protetto da Password**

Questo codice Python mostra come convertire un PowerPoint in un PDF protetto da password (usando i parametri di protezione dalla classe [PdfOptions](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Istanzia un oggetto Presentation che rappresenta un file PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Istanzia la classe PdfOptions
pdfOptions = slides.export.PdfOptions()

# Imposta la password PDF e le autorizzazioni di accesso
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Salva la presentazione come PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Converti Diapositive Selezionate in PowerPoint in PDF**

Questo codice Python mostra come convertire diapositive specifiche in una presentazione PowerPoint in PDF:

```python
import aspose.slides as slides

# Istanzia un oggetto Presentation che rappresenta un file PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Imposta un array di posizioni delle diapositive
slides_array = [ 1, 3 ]

# Salva la presentazione come PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Converti PowerPoint in PDF con Dimensione Diapositiva Personalizzata**

Questo codice Python mostra come convertire un PowerPoint quando la sua dimensione delle diapositive è specificata in un PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Crea una nuova presentazione con una dimensione della diapositiva regolata.
    with slides.Presentation() as resized_presentation:

        # Imposta la dimensione personalizzata della diapositiva.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Clona la prima diapositiva dalla presentazione originale e rimuove la diapositiva vuota predefinita.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Salva la presentazione ridimensionata in PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Converti PowerPoint in PDF nella Visualizzazione Note Diapositiva**

Questo codice Python mostra come convertire un PowerPoint in note PDF:

```python
import aspose.slides as slides

# Istanzia una classe Presentation che rappresenta un file PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

# Configura le opzioni PDF con il layout delle note
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Salva la presentazione in un PDF con le note
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Standard di Accessibilità e Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF usando uno di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice Python dimostra un'operazione di conversione da PowerPoint a PDF in cui vengono generati più PDF basati su diversi standard di conformità:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Il supporto di Aspose.Slides per le operazioni di conversione PDF si estende consentendo la conversione di PDF nei formati di file più popolari. È possibile effettuare conversioni [PDF to HTML](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-jpg/) e [PDF to PNG](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati—[PDF to SVG](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-tiff/), e [PDF to XML](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-xml/)—sono anch'esse supportate.

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafica complessa come SmartArt, grafici e formule come una singola figura. Gli elementi di percorso individuali non sono conservati come contenuto separato e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

### Aspose.Slides per Python può rimuovere le informazioni sull'applicazione dal PDF?

No, Aspose.Slides per Python include automaticamente le informazioni sull'API e il numero di versione nel PDF di output. Queste informazioni non possono essere modificate o rimosse.

### Come includere solo diapositive specifiche nella conversione PDF?

È possibile specificare gli indici delle diapositive da convertire passando un array di posizioni diapositive al metodo `save`.

### È possibile proteggere con password il PDF durante la conversione?

Sì, è possibile impostare una password e definire le autorizzazioni di accesso utilizzando la classe `PdfOptions` prima di salvare la presentazione come PDF.

### Aspose.Slides supporta la conversione di PDF in altri formati?

Sì, Aspose.Slides supporta la conversione di PDF in formati come HTML, formati immagine (JPG, PNG), SVG, TIFF e XML.

### Come garantire che il PDF rispetti gli standard di accessibilità?

Impostare la proprietà `compliance` in `PdfOptions` su standard come `PDF_A1A`, `PDF_A1B` o `PDF_UA` per assicurare la conformità alle linee guida di accessibilità.

### Posso includere diapositive nascoste nell'output PDF?

Sì, impostando la proprietà `show_hidden_slides` in `PdfOptions` su `True`, le diapositive nascoste verranno incluse nel PDF.

### Come regolare la qualità e la risoluzione delle immagini durante la conversione?

Utilizzare le proprietà `jpeg_quality` e `sufficient_resolution` in `PdfOptions` per controllare la qualità e la risoluzione delle immagini nel PDF risultante.

### Aspose.Slides gestisce automaticamente le sostituzioni dei font?

Aspose.Slides rileva le sostituzioni dei font durante la conversione e è possibile gestirle tramite la proprietà `warning_callback` in `SaveOptions` (attualmente limitata).

## **Risorse Aggiuntive**

- [Documentazione Aspose.Slides per .NET](https://docs.aspose.com/slides/it/python-net/)
- [Riferimento API Aspose.Slides](https://reference.aspose.com/slides/it/python-net/)
- [Convertitori Online Gratuiti Aspose](https://products.aspose.app/slides/it/conversion)