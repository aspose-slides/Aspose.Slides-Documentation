---
title: Gestisci apice e pedice nelle presentazioni usando Python via Java
linktitle: Apice e pedice
type: docs
weight: 80
url: /it/python-java/superscript-and-subscript/
keywords:
- apice
- pedice
- aggiungi apice
- aggiungi pedice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Padroneggia apice e pedice in Aspose.Slides per Python via Java e migliora le tue presentazioni con una formattazione del testo professionale per massimizzare l'impatto."
---
## **Panoramica**

Aspose.Slides offre funzionalità per integrare testo in apice e pedice nelle tue presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP). Che tu debba evidenziare formule chimiche, equazioni matematiche o annotare contenuti con note a piè di pagina, queste opzioni di formattazione specializzate aiutano a mantenere chiarezza e precisione. In questo articolo imparerai come applicare in modo fluido gli stili apice e pedice e garantire risultati professionali in ogni diapositiva.

## **Gestire testo in apice e pedice**

Puoi aggiungere testo in apice e pedice a qualsiasi porzione di un paragrafo. Per applicare questa formattazione in un frame di testo di Aspose.Slides, usa il metodo [setEscapement](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#setEscapement) della classe [PortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/).

Il valore di escapement varia da -100% (pedice) a 100% (apice). Per esempio:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Recupera una diapositiva per indice.
- Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) di tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#Rectangle) alla diapositiva.
- Accedi al [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) associato all'[AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/).
- Cancella i paragrafi esistenti.
- Crea un paragrafo per contenere testo in apice e aggiungilo alla [paragraph collection](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getParagraphs) del frame di testo.
- Crea una porzione.
- Usa [setEscapement](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#setEscapement) per impostare un valore da 0 a 100 per l'apice (0 significa nessun apice).
- Imposta il testo della [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/) e aggiungila alla collezione di porzioni del paragrafo.
- Crea un paragrafo per contenere testo in pedice e aggiungilo alla [paragraph collection](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getParagraphs) del frame di testo.
- Crea una porzione.
- Usa [setEscapement](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#setEscapement) per impostare un valore da -100 a 0 per il pedice (0 significa nessun pedice).
- Imposta il testo della [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/) e aggiungila alla collezione di porzioni del paragrafo.
- Salva la presentazione come file PPTX.

Il seguente esempio implementa questi passaggi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Crea una presentazione.
presentation = Presentation()
try:
    # Recupera la diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Crea una casella di testo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Crea un paragrafo per il testo in apice.
    superscript_paragraph = Paragraph()

    # Crea una porzione con testo normale.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Crea una porzione con testo in apice.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Crea un paragrafo per il testo in pedice.
    subscript_paragraph = Paragraph()

    # Crea una porzione con testo normale.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Crea una porzione con testo in pedice.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Aggiungi i paragrafi alla casella di testo.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**L'apice e il pedice verranno conservati durante l'esportazione in PDF o altri formati?**

Sì, Aspose.Slides preserva correttamente la formattazione in apice e pedice durante l'esportazione delle presentazioni in PDF, PPT/PPTX, immagini e altri formati supportati. La formattazione specializzata rimane intatta in tutti i file di output.

**L'apice e il pedice possono essere combinati con altri stili di formattazione come grassetto o corsivo?**

Sì, Aspose.Slides consente di mescolare vari stili di testo all'interno di una singola porzione di testo. È possibile abilitare grassetto, corsivo, sottolineatura e applicare simultaneamente apice o pedice configurando le proprietà corrispondenti in [PortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/).

**La formattazione in apice e pedice funziona per il testo all'interno di tabelle, grafici o SmartArt?**

Sì, Aspose.Slides supporta la formattazione nella maggior parte degli oggetti, incluse tabelle e elementi di grafico. Quando si lavora con SmartArt, è necessario accedere agli elementi appropriati (come [SmartArtNode](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnode/)) e ai loro contenitori di testo, quindi configurare le proprietà di [PortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/) in modo simile.