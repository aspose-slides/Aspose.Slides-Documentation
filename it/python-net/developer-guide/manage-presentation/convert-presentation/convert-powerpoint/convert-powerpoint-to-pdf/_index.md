---
title: Converti PPT & PPTX in PDF con Python | Opzioni avanzate
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
- allegato
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Guida passo-a-passo per convertire PPT, PPTX e ODP in PDF ad alta qualità e conformi a WCAG in Python con Aspose.Slides — include protezione con password, selezione delle diapositive e controllo della qualità delle immagini."
showReadingTime: true
---
## **Panoramica**

Convertire presentazioni PowerPoint (PPT, PPTX, ODP) in formato PDF in Python offre diversi vantaggi, tra cui garantire la compatibilità su diversi dispositivi e preservare il layout e la formattazione della tua presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere le diapositive nascoste, proteggere con password i documenti PDF, rilevare le sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, puoi convertire le presentazioni in questi formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF in Python, è sufficiente passare il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e quindi salvare la presentazione come PDF usando il metodo [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) espone il metodo [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) che viene tipicamente usato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides per Python inserisce le informazioni sulla sua API e il numero di versione nei documenti di output. Ad esempio, quando converte una presentazione in PDF, Aspose.Slides per Python popola il campo Application con il valore '*Aspose.Slides*' e il campo PDF Producer con un valore nella forma '*Aspose.Slides v XX.XX*'. **Nota** che non è possibile istruirе Aspose.Slides per Python a modificare o rimuovere queste informazioni dai documenti di output.
{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche in una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che il contenuto dei PDF risultanti corrisponda fedelmente alle presentazioni originali. Elementi e attributi vengono renderizzati accuratamente nella conversione, includendo:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF utilizzando impostazioni ottimali al massimo livello di qualità.

La seguente esempio carica una presentazione e salva tutte le diapositive visibili in PDF utilizzando le impostazioni di esportazione predefinite.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose offre un gratuito convertitore online [**Convertitore da PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. Per una implementazione reale della procedura descritta qui, è possibile fare un test con il convertitore.
{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—che consentono di personalizzare il PDF (generato dal processo di conversione), bloccare il PDF con una password o persino specificare come deve avvenire il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile impostare le impostazioni di qualità preferite per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, impostare DPI per le immagini, ecc.

Il seguente esempio esporta una presentazione in PDF 1.5 con qualità JPEG impostata a 90, risoluzione dell'immagine impostata a 300 DPI, metafile salvati come PNG e compressione del testo Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Conserva i file OLE incorporati come allegati PDF**

Se una presentazione contiene una cartella di lavoro Excel incorporata, potresti desiderare che i destinatari del PDF possano accedere ai dati della cartella di lavoro così come visualizzare le diapositive. Imposta [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) a `True` per conservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `False`: l'immagine di anteprima o l'icona dell'oggetto OLE viene renderizzata nella pagina PDF, ma il file incorporato non è incluso come allegato. Impostare l'opzione a `True` include inoltre i dati del file. L'anteprima rimane una rappresentazione visiva; l'allegato consente ai destinatari di aprire o salvare il file incorporato separatamente. L'oggetto OLE non diventa un foglio di lavoro Excel interattivo nella pagina PDF.

Il seguente esempio carica una presentazione che contiene già una cartella di lavoro Excel incorporata ed esporta in PDF con la cartella di lavoro allegata.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Per verificare il risultato:

1. Apri il PDF esportato in un visualizzatore che supporta gli allegati, come Adobe Acrobat Reader.
2. Apri il pannello **Allegati** del visualizzatore e individua la cartella di lavoro incorporata.
3. Salva l'allegato e aprilo in Excel per ispezionarne i dati, oppure aprilo direttamente se il visualizzatore lo consente. L'anteprima nella pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}
Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A-1 vieta i file incorporati, PDF/A-2 consente solo allegati PDF/A, e PDF/A-3 consente altri tipi di file, inclusi i fogli di lavoro Excel. Questi sono requisiti degli standard, non restrizioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione di conformità PDF predefinita e non dimostra l'esportazione PDF/A.
{{% /alert %}}

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare un'opzione personalizzata—la proprietà [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) della classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—per indicare ad Aspose.Slides di includere le diapositive nascoste come pagine nel PDF risultato.

Il seguente esempio esporta una presentazione in PDF, includendo eventuali diapositive nascoste.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Converti PowerPoint in PDF protetto da password**

Il seguente esempio esporta una presentazione in un PDF che richiede la password `password` per l'apertura. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa ad alta qualità.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Converti diapositive selezionate in PowerPoint in PDF**

Il seguente esempio esporta le diapositive 1 e 3 da una presentazione in PDF. I numeri delle diapositive in questo array partono da 1, e la presentazione di input deve contenere almeno tre diapositive.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Converti PowerPoint in PDF con dimensione diapositiva personalizzata**

Il seguente esempio copia la prima diapositiva da una presentazione in una nuova presentazione con dimensione diapositiva di 612 × 792 punti (8,5 × 11 pollici). È scala il contenuto della diapositiva per adattarlo ed esporta la singola diapositiva in PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Rimuovi la diapositiva vuota con cui è stata creata la nuova presentazione.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Converti PowerPoint in PDF in visualizzazione note diapositiva**

Il seguente esempio esporta una presentazione in PDF, posizionando le note del relatore di ciascuna diapositiva sotto la diapositiva stessa. Usa una presentazione che contiene note del relatore per vedere il risultato.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Standard di accessibilità e conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF usando uno qualsiasi di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice Python dimostra un'operazione di conversione da PowerPoint a PDF in cui vengono ottenuti PDF multipli basati su diversi standard di conformità:

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

{{% alert color="info" title="Note" %}}
Il supporto di Aspose.Slides per le operazioni di conversione PDF consente di convertire PDF nei formati di file più popolari. È possibile eseguire conversioni da [PDF in HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), da [PDF in immagine](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), da [PDF in JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), e da [PDF in PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) . Altre operazioni di conversione PDF in formati specializzati—[PDF in SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), e [PDF in XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—sono anch'esse supportate.
{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta elementi grafici complessi come SmartArt, grafici e formule come una singola figura. Gli elementi di percorso individuali non sono conservati come contenuti separati e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Aspose.Slides per Python può rimuovere le informazioni sull'applicazione dal PDF?**

No, Aspose.Slides per Python include automaticamente le informazioni sull'API e il numero di versione nel PDF di output. Queste informazioni non possono essere modificate o rimosse.

**Come includo solo diapositive specifiche nella conversione PDF?**

Puoi specificare gli indici delle diapositive che desideri convertire passando un array di posizioni diapositive al metodo [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**È possibile proteggere con password il PDF durante la conversione?**

Sì, è possibile impostare una password e definire le autorizzazioni di accesso utilizzando la classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) prima di salvare la presentazione come PDF.

**Aspose.Slides supporta la conversione di PDF in altri formati?**

Sì, Aspose.Slides supporta la conversione di PDF in formati come HTML, formati immagine (JPG, PNG), SVG, TIFF e XML.

**Come posso garantire che il mio PDF rispetti gli standard di accessibilità?**

Imposta la proprietà [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sugli standard `PDF_A1A`, `PDF_A1B` o `PDF_UA` per assicurare la conformità alle linee guida di accessibilità.

**Posso includere diapositive nascoste nell'output PDF?**

Sì, impostando la proprietà [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) a `True`, le diapositive nascoste saranno incluse nel PDF.

**Come regolo la qualità e la risoluzione delle immagini durante la conversione?**

Utilizza le proprietà [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) e [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) per controllare la qualità e la risoluzione delle immagini nel PDF risultante.

**Aspose.Slides gestisce automaticamente le sostituzioni di caratteri?**

Aspose.Slides rileva le sostituzioni di caratteri durante la conversione e puoi gestirle tramite la proprietà `warning_callback` in `SaveOptions` (attualmente limitata).

## **Risorse aggiuntive**

- [Aspose.Slides per Python via .NET Documentazione](/slides/it/python-net/)
- [Riferimento API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Convertitori online gratuiti Aspose](https://products.aspose.app/slides/conversion)