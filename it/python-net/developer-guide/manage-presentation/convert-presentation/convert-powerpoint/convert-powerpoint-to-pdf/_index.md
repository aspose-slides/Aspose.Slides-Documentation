---
title: Converti PPT e PPTX in PDF con Python | Opzioni Avanzate
linktitle: PowerPoint in PDF
type: docs
weight: 40
url: /it/python-net/convert-powerpoint-to-pdf/
keywords:
- convertire PowerPoint
- presentazione
- PowerPoint in PDF
- PPT in PDF
- PPTX in PDF
- salvare PowerPoint come PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Guida passo‑passo per convertire PPT, PPTX e ODP in PDF ad alta qualità e conformi a WCAG in Python con Aspose.Slides—include protezione con password, selezione delle diapositive e controllo della qualità delle immagini."
showReadingTime: true
---
## **Panoramica**

Convertire presentazioni PowerPoint (PPT, PPTX, ODP) in formato PDF con Python offre diversi vantaggi, tra cui garantire la compatibilità su diversi dispositivi e preservare il layout e la formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere le diapositive nascoste, proteggere i PDF con password, rilevare le sostituzioni dei caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF con Python, è sufficiente passare il nome del file come argomento nella classe [Presentation](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/) e quindi salvare la presentazione come PDF utilizzando il metodo [Save](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/#methods). La classe [Presentation](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/) espone il metodo [Save](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/#methods) che è tipicamente usato per convertire una presentazione in PDF.

{{%  alert title="NOTE"  color="warning" %}} 

Aspose.Slides per Python scrive direttamente le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, quando converte una presentazione in PDF, Aspose.Slides per Python popola il campo Application con il valore '*Aspose.Slides*' e il campo PDF Producer con un valore nella forma '*Aspose.Slides v XX.XX*'. **Nota** che non è possibile istruire Aspose.Slides per Python a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Tutte le presentazioni in PDF
* Diapositive specifiche in una presentazione in PDF

Aspose.Slides esporta presentazioni in PDF, garantendo che il contenuto dei PDF risultanti corrisponda fedelmente alle presentazioni originali. Gli elementi e gli attributi vengono renderizzati accuratamente nella conversione, includendo:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

La conversione standard da PowerPoint a PDF viene eseguita usando le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF utilizzando impostazioni ottimali al livello di massima qualità. Questo codice Python mostra come convertire un PowerPoint in PDF:

_Passaggi: Conversioni da PowerPoint a PDF in Python_

Il codice di esempio seguente spiega queste conversioni usando Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Passaggi: Converti PowerPoint in PDF usando Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Passaggi: Converti PPT in PDF usando Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Passaggi: Converti PPTX in PDF usando Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Passaggi: Converti ODP in PDF usando Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Passaggi: Converti PPS in PDF usando Python via .NET</a></strong>

_Passaggi del codice:_

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e forniscile il file PowerPoint.
  * estensione _.ppt_ per caricare il file **PPT** nella classe _Presentation_.
  * estensione _.pptx_ per caricare il file **PPTX** nella classe _Presentation_.
  * estensione _.odp_ per caricare il file **ODP** nella classe _Presentation_.
  * estensione _.pps_ per caricare il file **PPS** nella classe _Presentation_.
- Salva la _Presentation_ in formato **PDF** chiamando il metodo **Save** e usando l'enumerazione **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Istanzia una classe Presentation che rappresenta un file PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Salva la presentazione come PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary" %}} 

Aspose offre un convertitore online gratuito [**Convertitore PowerPoint in PDF**](https://products.aspose.app/slides/it/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. Per una implementazione live della procedura descritta qui, puoi provare il convertitore.

{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate — proprietà nella classe [PdfOptions](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides.export/pdfoptions/) — che consentono di personalizzare il PDF (risultante dal processo di conversione), bloccare il PDF con una password, o persino specificare come dovrebbe procedere il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile impostare la qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per i testi, definire DPI per le immagini, ecc.  
L'esempio di codice qui sotto dimostra un'operazione in cui una presentazione PowerPoint viene convertita in PDF con diverse opzioni personalizzate:

```python
import aspose.slides as slides

# Istanzia la classe PdfOptions
pdf_options = slides.export.PdfOptions()

# Imposta la qualità per le immagini JPG
pdf_options.jpeg_quality = 90

# Imposta i DPI per le immagini
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

Se una presentazione contiene diapositive nascoste, puoi utilizzare un'opzione personalizzata — la proprietà `show_hidden_slides` della classe [PdfOptions](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides.export/pdfoptions/) — per istruire Aspose.Slides a includere le diapositive nascoste come pagine nel PDF risultante.  
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

Questo codice Python mostra come convertire un PowerPoint in un PDF protetto da password (usando i parametri di protezione della classe [PdfOptions](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Istanzia un oggetto Presentation che rappresenta un file PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Istanzia la classe PdfOptions
pdfOptions = slides.export.PdfOptions()

# Imposta la password PDF e i permessi di accesso
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

# Imposta un array di posizioni diapositive
slides_array = [ 1, 3 ]

# Salva la presentazione come PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Converti PowerPoint in PDF con Dimensione Diapositiva Personalizzata**

Questo codice Python mostra come convertire un PowerPoint la cui dimensione della diapositiva è specificata in PDF:

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

        # Clona la prima diapositiva dalla presentazione originale.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Salva la presentazione ridimensionata in un PDF con note.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Converti PowerPoint in PDF nella Vista Note**

Questo codice Python mostra come convertire un PowerPoint in note PDF:

```python
import aspose.slides as slides

# Istanzia una classe Presentation che rappresenta un file PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Salva la presentazione in note PDF
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Accessibilità e Standard di Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno di questi standard di conformità: **PDF/A1a**, **PDF/A1b**, e **PDF/UA**.  
Questo codice Python dimostra un'operazione di conversione da PowerPoint a PDF in cui si ottengono più PDF basati su diversi standard di conformità:

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

{{% alert title="Nota" color="warning" %}} 

Il supporto di Aspose.Slides per le operazioni di conversione PDF si estende consentendo di convertire PDF nei formati di file più popolari. È possibile eseguire conversioni [PDF in HTML](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-html/), [PDF in immagine](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-image/), [PDF in JPG](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-jpg/), e [PDF in PNG](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-png/) . Altre operazioni di conversione PDF in formati specializzati — [PDF in SVG](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-tiff/), e [PDF in XML](https://products.aspose.com/slides/it/python-net/conversion/pdf-to-xml/) — sono anch'esse supportate.

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafiche complesse come SmartArt, diagrammi e formule come una singola figura. Gli elementi di percorso individuali non sono preservati come contenuti separati e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **Domande frequenti**

**Aspose.Slides per Python può rimuovere le informazioni sull'applicazione dal PDF?**  
No, Aspose.Slides per Python include automaticamente le informazioni sull'API e il numero di versione nel PDF di output. Queste informazioni non possono essere modificate o rimosse.

**Come includere solo le diapositive specifiche nella conversione PDF?**  
È possibile specificare gli indici delle diapositive da convertire passando un array di posizioni diapositive al metodo `save`.

**È possibile proteggere con password il PDF durante la conversione?**  
Sì, è possibile impostare una password e definire i permessi di accesso usando la classe `PdfOptions` prima di salvare la presentazione come PDF.

**Aspose.Slides supporta la conversione di PDF in altri formati?**  
Sì, Aspose.Slides supporta la conversione di PDF in formati come HTML, formati immagine (JPG, PNG), SVG, TIFF e XML.

**Come posso garantire che il mio PDF rispetti gli standard di accessibilità?**  
Imposta la proprietà `compliance` in `PdfOptions` su standard come `PDF_A1A`, `PDF_A1B` o `PDF_UA` per garantire la conformità alle linee guida di accessibilità.

**Posso includere diapositive nascoste nel PDF generato?**  
Sì, impostando la proprietà `show_hidden_slides` in `PdfOptions` a `True`, le diapositive nascoste saranno incluse nel PDF.

**Come regolare la qualità e la risoluzione delle immagini durante la conversione?**  
Utilizza le proprietà `jpeg_quality` e `sufficient_resolution` in `PdfOptions` per controllare la qualità e la risoluzione delle immagini nel PDF risultante.

**Aspose.Slides gestisce automaticamente le sostituzioni dei caratteri?**  
Aspose.Slides rileva le sostituzioni dei caratteri durante la conversione, e puoi gestirle usando la proprietà `warning_callback` in `SaveOptions` (attualmente limitata).

## **Risorse aggiuntive**

- [Documentazione Aspose.Slides per .NET](https://docs.aspose.com/slides/it/python-net/)
- [Riferimento API Aspose.Slides](https://reference.aspose.com/slides/it/python-net/)
- [Convertitori Online Gratuiti di Aspose](https://products.aspose.app/slides/it/conversion)