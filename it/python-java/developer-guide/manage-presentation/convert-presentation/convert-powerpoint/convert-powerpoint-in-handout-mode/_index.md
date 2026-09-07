---
title: Converti presentazioni PowerPoint in modalità Handout usando Python
linktitle: Modalità Handout
type: docs
weight: 150
url: /it/python-java/convert-powerpoint-in-handout-mode/
keywords:
- converti PowerPoint
- converti presentazione
- modalità handout
- handout
- PPT
- PPTX
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Converti presentazioni PowerPoint in handout in Python via Java. Disporre più diapositive per pagina ed esportare in PDF con Aspose.Slides."
---
## **Introduzione**

Aspose.Slides per Python via Java consente di esportare presentazioni in modalità handout, disponendo più diapositive su una singola pagina. Questo è utile per stampare materiale di presentazione per conferenze, seminari e eventi simili.

Configura il layout tramite il metodo [setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). I layout handout sono supportati da [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/), e [TiffOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/). Usa un oggetto [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/handoutlayoutingoptions/) per specificare le impostazioni di layout e visualizzazione.

## **Esportazione in modalità Handout**

Per esportare una presentazione in modalità handout, crea un'istanza di [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/handoutlayoutingoptions/) e assegnala alle opzioni di esportazione di destinazione utilizzando [setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

L'esempio seguente carica `sample.pptx` ed esporta in PDF con quattro diapositive per pagina in ordine orizzontale. Include i numeri di diapositiva e i bordi intorno alle diapositive, ed esclude i commenti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Carica una presentazione.
presentation = Presentation("sample.pptx")
try:
    # Configura il layout handout.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Esporta la presentazione in PDF con il layout scelto.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Le impostazioni del layout handout si applicano ai formati di output supportati, come PDF, HTML, TIFF e immagini renderizzate. Non riorganizzano le diapositive nella presentazione originale.
{{% /alert %}}

## **FAQ**

**Qual è il numero massimo di miniature di diapositive per pagina in modalità handout?**

Aspose.Slides supporta fino a nove miniature per pagina. I preset [HandoutType](https://reference.aspose.com/slides/it/python-java/aspose.slides/handouttype/) forniscono una, due, tre, quattro, sei o nove diapositive per pagina. I preset a quattro, sei e nove diapositive offrono ordinamento orizzontale e verticale.

**Posso definire una griglia personalizzata, come cinque o otto diapositive per pagina?**

No. Il numero e l'ordinamento delle miniature sono controllati dai valori predefiniti di [HandoutType](https://reference.aspose.com/slides/it/python-java/aspose.slides/handouttype/). Griglie arbitrarie non sono supportate da queste impostazioni di layout handout.

**Posso includere diapositive nascoste nell'output handout?**

Sì. Abilita le diapositive nascoste nelle impostazioni di esportazione per il formato di destinazione. Per PDF, chiama [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) con `True` prima di salvare la presentazione.