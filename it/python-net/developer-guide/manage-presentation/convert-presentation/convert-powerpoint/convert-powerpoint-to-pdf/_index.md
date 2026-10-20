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
  - Aspose.Slides per Python
description: "Guida passo-passo per convertire PPT, PPTX e ODP in PDF ad alta qualità e conformi a WCAG con Python e Aspose.Slides — include protezione con password, selezione delle diapositive e controllo della qualità delle immagini."
showReadingTime: true
---
## **Panoramica**

Convertire presentazioni PowerPoint (PPT, PPTX, ODP) in formato PDF con Python offre diversi vantaggi, tra cui garantire la compatibilità su diversi dispositivi e preservare il layout e la formattazione della tua presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i documenti PDF, rilevare le sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare gli standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire le presentazioni in questi formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF con Python, è sufficiente passare il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e quindi salvare la presentazione come PDF utilizzando il metodo [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) espone il metodo [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) che è tipicamente usato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides per Python inserisce le informazioni sulla sua API e il numero di versione nei documenti di output. Ad esempio, quando converte una presentazione in PDF, Aspose.Slides per Python popola il campo Application con il valore '*Aspose.Slides*' e il campo PDF Producer con un valore nella forma '*Aspose.Slides v XX.XX*'. **Nota** che non è possibile istruire Aspose.Slides per Python a modificare o rimuovere queste informazioni dai documenti di output.
{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche di una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che il contenuto dei PDF risultanti corrisponda fedelmente alle presentazioni originali. Elementi e attributi sono resi accuratamente durante la conversione, inclusi:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenco puntato
* Tabelle

## **Converti PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali ai massimi livelli di qualità.

L'esempio seguente carica una presentazione e salva tutte le diapositive visibili in PDF utilizzando le impostazioni di esportazione predefinite.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose offre un gratuito [**Convertitore da PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. Per una implementazione reale della procedura descritta qui, puoi effettuare un test con il convertitore.
{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà nella classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—che consentono di personalizzare il PDF (ottenuto dal processo di conversione), bloccare il PDF con una password o persino specificare come deve avvenire il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile impostare la qualità desiderata per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, impostare DPI per le immagini, ecc.

L'esempio seguente esporta una presentazione in PDF 1.5 con qualità JPEG impostata a 90, risoluzione dell'immagine impostata a 300 DPI, metafile salvati come PNG e compressione del testo Flate.

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

### **Seleziona Automaticamente la Compressione delle Immagini**

Quando una presentazione contiene molte fotografie o screenshot, ridurre le dimensioni del PDF esportato può renderlo più facile da inviare via email o da scaricare. Imposta [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) su `True` per selezionare automaticamente l'algoritmo di compressione più appropriato per ciascuna immagine durante l'esportazione in PDF.

L'esempio seguente carica una presentazione esistente, abilita la selezione automatica della compressione delle immagini e la salva come documento PDF. Tutte le altre impostazioni di esportazione PDF mantengono i loro valori predefiniti.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Questa opzione seleziona un algoritmo di compressione per ciascuna immagine. Ridurre [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) diminuisce la qualità dell'immagine JPEG, mentre ridurre [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) consente di ridurre la risoluzione delle immagini, il che può ridurre i dettagli. L'abilitazione della selezione automatica della compressione non riduce di per sé nessuna di queste impostazioni.

La selezione degli algoritmi di compressione delle immagini richiede tempo di elaborazione e memoria aggiuntivi. La riduzione delle dimensioni dipende dalle immagini della presentazione e dalle impostazioni di esportazione; una riduzione fissa non è garantita per ogni presentazione.

### **Preserva i File OLE Incorporati come Allegati PDF**

Se una presentazione contiene una cartella di lavoro Excel incorporata, potresti desiderare che i destinatari del PDF possano accedere ai dati della cartella di lavoro oltre a visualizzare le diapositive. Imposta [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) su `True` per preservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `False`: l'immagine di anteprima o l'icona dell'oggetto OLE viene renderizzata sulla pagina PDF, ma il file incorporato non viene incluso come allegato. Impostare l'opzione su `True` include inoltre i dati del file. L'anteprima rimane una rappresentazione visiva; l'allegato consente ai destinatari di aprire o salvare separatamente il file incorporato. L'oggetto OLE non diventa un foglio di calcolo Excel interattivo nella pagina PDF.

L'esempio seguente carica una presentazione che contiene già una cartella di lavoro Excel incorporata e la esporta in PDF con la cartella di lavoro allegata.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Per verificare il risultato:

1. Apri il PDF esportato in un visualizzatore che supporta gli allegati di file, come Adobe Acrobat Reader.
2. Apri il pannello **Allegati** del visualizzatore e individua la cartella di lavoro incorporata.
3. Salva l'allegato e aprilo in Excel per esaminarne i dati, o aprilo direttamente se il visualizzatore lo consente. L'anteprima sulla pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}
Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A-1 vieta i file incorporati, PDF/A-2 consente solo allegati PDF/A, e PDF/A-3 permette altri tipi di file, incluse le cartelle di lavoro Excel. Questi sono requisiti degli standard, non restrizioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione di conformità PDF predefinita e non dimostra l'esportazione PDF/A.
{{% /alert %}}

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare un'opzione personalizzata—la proprietà [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) della classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—per istruire Aspose.Slides a includere le diapositive nascoste come pagine nel PDF risultante.

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

### **Gestisci i Font Senza un Carattere Grassetto Dedicato**

Una presentazione può applicare la formattazione grassetto al testo anche quando il suo font non dispone di un carattere grassetto dedicato. Il testo può comunque apparire in grassetto tramite grassetto sintetico, che ispessisce artificialmente i glifi normali. Quando quel testo appare troppo pesante o differisce dall'aspetto previsto nel PDF, prova a impostare [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) su `True`. Questa opzione rende il testo interessato come bitmap durante l'esportazione in PDF e può migliorarne l'aspetto per alcuni font. Il valore predefinito è `False`.

La presentazione di esempio contiene due caselle di testo: una con testo normale e una con formattazione grassetto applicata allo stesso font, che non ha un carattere grassetto dedicato. L'esempio seguente carica la presentazione, abilita la rasterizzazione degli stili di font non supportati e la esporta in PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Le anteprime seguenti mostrano l'output con l'opzione disabilitata e quello abilitata. In questo esempio, il testo in grassetto ha tratti più spessi con l'opzione disabilitata. Con l'opzione abilitata, i suoi tratti sono più leggeri; il testo normale rimane invariato. Confronta i risultati prima di scegliere l'impostazione per la tua presentazione.

| Opzione disabilitata (`False`, predefinita) | Opzione abilitata (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In questo esempio, abilitare l'opzione trasforma solo il testo in grassetto in una bitmap: non può essere selezionato, copiato o ricercato come testo senza OCR, e i suoi bordi appaiono più morbidi a ingrandimento 800%. Il testo normale rimane ricercabile. Con l'opzione disabilitata, entrambe le stringhe rimangono testo.

Questa opzione rasterizza il testo formattato in grassetto quando il suo font non ha un carattere grassetto dedicato. [Sostituzione dei font](/slides/it/python-net/font-substitution/) invece seleziona un altro font quando l'originale non è disponibile.

## **Converti Diapositive Selezionate in PowerPoint in PDF**

L'esempio seguente esporta le diapositive 1 e 3 da una presentazione in PDF. I numeri delle diapositive in questo array partono da 1, e la presentazione di input deve contenere almeno tre diapositive.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Converti PowerPoint in PDF con Dimensione Personalizzata della Diapositiva**

L'esempio seguente copia la prima diapositiva da una presentazione in una nuova presentazione con dimensione diapositiva di 612 × 792 punti (8,5 × 11 pollici). Scala il contenuto della diapositiva per adattarlo ed esporta la singola diapositiva in PDF.

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

## **Converti PowerPoint in PDF nella Vista Note della Diapositiva**

L'esempio seguente esporta una presentazione in PDF, posizionando le note del relatore di ciascuna diapositiva sotto la diapositiva stessa. Usa una presentazione contenente note del relatore per vedere il risultato.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Standard di Accessibilità e Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

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

{{% alert color="info" title="Note" %}}
Il supporto di Aspose.Slides per le operazioni di conversione PDF consente di convertire i PDF nei formati di file più popolari. È possibile eseguire conversioni [PDF in HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF in immagine](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF in JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) e [PDF in PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Altre operazioni di conversione PDF in formati specializzati—[PDF in SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), e [PDF in XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—sono anch'esse supportate.
{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta le grafiche complesse come SmartArt, grafici e formule come un'unica figura. Gli elementi di percorso individuali non vengono conservati come contenuto separato e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Aspose.Slides per Python può rimuovere le informazioni sull'applicazione dal PDF?**

No, Aspose.Slides per Python include automaticamente le informazioni API e il numero di versione nel PDF di output. Queste informazioni non possono essere modificate o rimosse.

**Come includere solo diapositive specifiche nella conversione PDF?**

È possibile specificare gli indici delle diapositive da convertire passando un array di posizioni di diapositiva al metodo [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**È possibile proteggere con password il PDF durante la conversione?**

Sì, è possibile impostare una password e definire le autorizzazioni di accesso utilizzando la classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) prima di salvare la presentazione come PDF.

**Aspose.Slides supporta la conversione di PDF in altri formati?**

Sì, Aspose.Slides supporta la conversione di PDF in formati come HTML, formati immagine (JPG, PNG), SVG, TIFF e XML.

**Come posso garantire che il mio PDF sia conforme agli standard di accessibilità?**

Imposta la proprietà [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) nella classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) su standard come `PDF_A1A`, `PDF_A1B` o `PDF_UA` per garantire la conformità alle linee guida di accessibilità.

**Posso includere le diapositive nascoste nell'output PDF?**

Sì, impostando la proprietà [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) nella classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) su `True`, le diapositive nascoste verranno incluse nel PDF.

**Come regolare la qualità e la risoluzione delle immagini durante la conversione?**

Utilizza le proprietà [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) e [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) nella classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) per controllare la qualità e la risoluzione delle immagini nel PDF risultante.

**Aspose.Slides gestisce automaticamente le sostituzioni di font?**

Aspose.Slides rileva le sostituzioni di font durante la conversione e puoi gestirle utilizzando la proprietà `warning_callback` in `SaveOptions` (attualmente limitata).

## **Risorse Aggiuntive**

* [Documentazione di Aspose.Slides per Python via .NET](/slides/it/python-net/)
* [Riferimento API di Aspose.Slides](https://reference.aspose.com/slides/python-net/)
* [Convertitori Online Gratuiti di Aspose](https://products.aspose.app/slides/conversion)