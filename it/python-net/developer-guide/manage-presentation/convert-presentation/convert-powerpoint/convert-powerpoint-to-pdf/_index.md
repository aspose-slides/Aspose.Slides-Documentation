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
- allegato
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Guida passo-passo per la conversione di PPT, PPTX e ODP in PDF di alta qualità e conformi a WCAG con Python e Aspose.Slides—include protezione con password, selezione delle diapositive e controllo della qualità delle immagini."
showReadingTime: true
---
## **Panoramica**

Convertire presentazioni PowerPoint (PPT, PPTX, ODP) in formato PDF con Python offre diversi vantaggi, tra cui la garanzia di compatibilità su dispositivi diversi e la conservazione del layout e della formattazione della presentazione. Questa guida mostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i documenti PDF, rilevare sostituzioni di font, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Usando Aspose.Slides, è possibile convertire le presentazioni in questi formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF con Python, basta passare il nome del file come argomento alla classe [Presentazione](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e poi salvare la presentazione come PDF usando il metodo [salva](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). La classe [Presentazione](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) espone il metodo [salva](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) che è tipicamente usato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python inserisce le informazioni sulla sua API e il numero di versione nei documenti di output. Per esempio, quando converte una presentazione in PDF, Aspose.Slides for Python popola il campo Application con il valore '*Aspose.Slides*' e il campo PDF Producer con un valore nella forma '*Aspose.Slides v XX.XX*'. **Nota** che non è possibile istruire Aspose.Slides for Python a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche di una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i contenuti dei PDF risultanti corrispondano fedelmente alle presentazioni originali. Elementi e attributi vengono renderizzati accuratamente nella conversione, includendo:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali ai massimi livelli di qualità.

L'esempio seguente carica una presentazione e salva tutte le diapositive visibili in PDF usando le impostazioni di esportazione predefinite.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}

Aspose fornisce un gratuito **convertitore da PowerPoint a PDF** online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. Per una implementazione reale della procedura descritta qui, è possibile eseguire un test con il convertitore.

{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—che consentono di personalizzare il PDF (risultato del processo di conversione), bloccare il PDF con una password o persino specificare come deve avvenire la conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Usando opzioni di conversione personalizzate, è possibile impostare il livello di qualità preferito per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, impostare DPI per le immagini, ecc.

L'esempio seguente esporta una presentazione in PDF 1.5 con qualità JPEG impostata a 90, risoluzione dell'immagine impostata a 300 DPI, metafile salvati come PNG e compressione testo Flate.

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

### **Conserva i File OLE Incorporati come Allegati PDF**

Se una presentazione contiene un workbook Excel incorporato, potrebbe essere necessario che i destinatari del PDF accedano ai dati del workbook oltre a visualizzare le diapositive. Impostare [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) su `True` per conservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `False`: l'immagine di anteprima o l'icona dell'oggetto OLE viene renderizzata nella pagina PDF, ma il file incorporato non è incluso come allegato. Impostare l'opzione su `True` include inoltre i dati del file. L'anteprima rimane una rappresentazione visiva; l'allegato consente ai destinatari di aprire o salvare il file incorporato separatamente. L'oggetto OLE non diventa un foglio di lavoro Excel interattivo nella pagina PDF.

L'esempio seguente carica una presentazione che già contiene un workbook Excel incorporato ed esporta in PDF con il workbook allegato.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Per verificare il risultato:

1. Aprire il PDF esportato in un visualizzatore che supporta gli allegati, come Adobe Acrobat Reader.
2. Aprire il pannello **Allegati** del visualizzatore e individuare il workbook incorporato.
3. Salvare l'allegato e aprirlo in Excel per ispezionarne i dati, o aprirlo direttamente se il visualizzatore lo consente. L'anteprima nella pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}

Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A-1 vieta i file incorporati, PDF/A-2 consente solo allegati PDF/A e PDF/A-3 consente altri tipi di file, inclusi i workbook Excel. Questi sono requisiti degli standard, non restrizioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione di conformità PDF predefinita e non dimostra l'esportazione PDF/A.

{{% /alert %}}

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile usare un'opzione personalizzata—la proprietà [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) della classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—per istruire Aspose.Slides a includere le diapositive nascoste come pagine nel PDF risultante.

L'esempio seguente esporta una presentazione in PDF, includendo eventuali diapositive nascoste.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Converti PowerPoint in un PDF Protetto da Password**

L'esempio seguente esporta una presentazione in un PDF che richiede la password `password` per essere aperto. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa ad alta qualità.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Gestisci i Font senza un Grassetto Dedicato**

Una presentazione può applicare la formattazione grassetto al testo anche quando il suo font non dispone di un tipo di carattere grassetto dedicato. Il testo può comunque apparire in grassetto mediante grassetto sintetico, che ispessisce artificialmente i glifi regolari. Quando quel testo appare troppo pesante o differisce dall'aspetto previsto in PDF, provare a impostare [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) su `True`. Questa opzione renderizza il testo interessato come bitmap durante l'esportazione PDF e può migliorarne l'aspetto per alcuni font. Il valore predefinito è `False`.

La presentazione di esempio contiene due caselle di testo: una con testo normale e una con formattazione grassetto applicata allo stesso font, che non ha un grassetto dedicato. L'esempio seguente carica la presentazione, abilita la rasterizzazione degli stili di font non supportati ed esporta in PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Le anteprime seguenti mostrano l'output disabilitato e quello abilitato. In questo esempio, il testo in grassetto ha tratti più spessi con l'opzione disabilitata. Con l'opzione abilitata, i tratti sono più leggeri; il testo normale rimane invariato. Confronta i risultati prima di scegliere l'impostazione per la tua presentazione.

| Opzione disabilitata (`False`, il valore predefinito) | Opzione abilitata (`True`) |
|---|---|
| ![PDF con rasterizzazione dello stile di font non supportato disabilitata](unsupported-bold-disabled.png) | ![PDF con rasterizzazione dello stile di font non supportato abilitata](unsupported-bold-enabled.png) |

In questo esempio, abilitare l'opzione trasforma solo il testo in grassetto in bitmap: non può essere selezionato, copiato o ricercato come testo senza OCR, e i suoi bordi appaiono più morbidi a zoom 800 %. Il testo normale rimane ricercabile. Con l'opzione disabilitata, entrambe le stringhe rimangono testo.

Questa opzione rasterizza il testo formattato in grassetto quando il suo font non ha un grassetto dedicato. [Sostituzione dei font](/slides/it/python-net/font-substitution/) seleziona invece un altro font quando l'originale non è disponibile.

## **Converti Diapositive Selezionate in PowerPoint in PDF**

L'esempio seguente esporta le diapositive 1 e 3 da una presentazione in PDF. I numeri delle diapositive in questo array partono da 1 e la presentazione di input deve contenere almeno tre diapositive.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Converti PowerPoint in PDF con Dimensione Diapositiva Personalizzata**

L'esempio seguente copia la prima diapositiva da una presentazione in una nuova presentazione con una dimensione diapositiva di 612 × 792 punti (8,5 × 11 pollici). Scala il contenuto della diapositiva per adattarlo ed esporta la singola diapositiva in PDF.

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

## **Converti PowerPoint in PDF nella Vista Note Diapositiva**

L'esempio seguente esporta una presentazione in PDF, posizionando le note del relatore di ogni diapositiva sotto la diapositiva stessa. Usa una presentazione che contiene note del relatore per vedere il risultato.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Standard di Accessibilità e Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione conforme alle [Linee Guida per l'Accessibilità dei Contenuti Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF usando uno qualsiasi di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice Python dimostra un'operazione di conversione da PowerPoint a PDF in cui vengono ottenuti più PDF basati su diversi standard di conformità:

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

Il supporto di Aspose.Slides per le operazioni di conversione PDF consente di convertire PDF nei formati di file più popolari. È possibile eseguire conversioni [PDF a HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF a immagine](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) e [PDF a PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati—[PDF a SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) e [PDF a XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—sono anch'esse supportate.

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafica complessa come SmartArt, diagrammi e formule come un'unica figura. Gli elementi di percorso individuali non vengono conservati come contenuto separato e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Aspose.Slides for Python può rimuovere le informazioni sull'applicazione dal PDF?**

No, Aspose.Slides for Python inserisce automaticamente le informazioni sull'API e il numero di versione nel PDF di output. Queste informazioni non possono essere modificate o rimosse.

**Come includere solo diapositive specifiche nella conversione PDF?**

È possibile specificare gli indici delle diapositive da convertire passando un array di posizioni diapositive al metodo [salva](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**È possibile proteggere con password il PDF durante la conversione?**

Sì, è possibile impostare una password e definire le autorizzazioni di accesso usando la classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) prima di salvare la presentazione come PDF.

**Aspose.Slides supporta la conversione da PDF ad altri formati?**

Sì, Aspose.Slides supporta la conversione di PDF in formati come HTML, formati immagine (JPG, PNG), SVG, TIFF e XML.

**Come garantire che il mio PDF rispetti gli standard di accessibilità?**

Impostare la proprietà [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) su standard come `PDF_A1A`, `PDF_A1B` o `PDF_UA` per garantire la conformità alle linee guida di accessibilità.

**Posso includere diapositive nascoste nell'output PDF?**

Sì, impostando la proprietà [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) su `True`, le diapositive nascoste verranno incluse nel PDF.

**Come regolare la qualità e la risoluzione delle immagini durante la conversione?**

Utilizzare le proprietà [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) e [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) per controllare la qualità e la risoluzione delle immagini nel PDF risultante.

**Aspose.Slides gestisce automaticamente le sostituzioni di font?**

Aspose.Slides rileva le sostituzioni di font durante la conversione e si possono gestire usando la proprietà `warning_callback` in `SaveOptions` (attualmente limitata).

## **Risorse Aggiuntive**

- [Aspose.Slides for Python via .NET Documentation](/slides/it/python-net/)
- [Riferimento API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Converteri Online Gratuiti Aspose](https://products.aspose.app/slides/conversion)