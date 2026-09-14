---
title: Gestire i Font nelle Presentazioni con Python via Java
linktitle: Gestire i Font
type: docs
weight: 10
url: /it/python-java/manage-fonts/
keywords:
- gestire i font
- proprietà del font
- paragrafo
- formattazione del testo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Controlla i font in Python via Java con Aspose.Slides: incorpora, sostituisci e carica font personalizzati per mantenere le presentazioni PPT, PPTX e ODP chiare, coerenti con il brand e uniformi."
---
## **Panoramica**

Aspose.Slides consente di gestire le proprietà dei caratteri nel testo delle presentazioni direttamente dal tuo codice. Puoi accedere al testo nelle diapositive tramite forme, caselle di testo, paragrafi e porzioni, e quindi applicare la formattazione al testo selezionato.

Questo articolo spiega come configurare le proprietà dei caratteri per il testo esistente in una presentazione, inclusi la famiglia di caratteri, gli stili grassetto e corsivo, l'allineamento del paragrafo e il colore del carattere. Mostra inoltre come creare una casella di testo, aggiungere del testo al suo interno e impostare le proprietà del carattere come la famiglia di caratteri, grassetto, corsivo, sottolineato, dimensione del carattere e colore, prima di salvare il risultato come file PPTX.

## **Gestire le Proprietà dei Caratteri**
{{% alert color="info" title="Note" %}} 

Le presentazioni solitamente contengono sia testo che immagini. Il testo può essere formattato in vari modi, sia per evidenziare sezioni e parole specifiche sia per conformarsi agli stili aziendali. La formattazione del testo aiuta gli utenti a variare l'aspetto del contenuto della presentazione. Questo articolo mostra come utilizzare Aspose.Slides for Python via Java per configurare le proprietà dei caratteri dei paragrafi di testo nelle diapositive.

{{% /alert %}} 

Per gestire le proprietà dei caratteri di un paragrafo utilizzando Aspose.Slides for Python via Java:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni il riferimento di una diapositiva utilizzando il suo indice.
1. Accedi alle forme [Placeholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholder/) nella diapositiva come [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/).
1. Recupera il [Paragraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/) dal [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) esposto da [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/).
1. Giustifica il paragrafo.
1. Accedi al testo [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/) di un [Paragraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/).
1. Definisci il carattere utilizzando [FontData](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontdata/) e imposta il **Font** della [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/) del testo di conseguenza.
   1. Imposta il carattere in grassetto.
   1. Imposta il carattere in corsivo.
1. Imposta il colore del carattere utilizzando il [FillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/) esposto dall'oggetto [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/).
1. Salva la presentazione modificata in un file PPTX.

L'implementazione dei passaggi sopra riportati è mostrata di seguito. Prende una presentazione non formattata e formatta i caratteri su una delle diapositive. Gli screenshot seguenti mostrano il file di input e come le parti di codice lo modificano. Il codice cambia il carattere, il colore e lo stile del carattere.

|![Testo nella presentazione di input](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: Il testo nel file di input**|

|![Testo con formattazione dei caratteri aggiornata](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: Lo stesso testo con formattazione aggiornata**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Carica la presentazione.
presentation = Presentation("FontProperties.pptx")
try:
    # Accedi alla prima diapositiva e ai frame di testo dei suoi primi due segnaposto.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Accedi al primo paragrafo in ciascun frame di testo.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Accedi alla prima porzione in ogni paragrafo.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Definisci e assegna nuovi font.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Imposta i font in grassetto e corsivo.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Imposta i colori dei font.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Salva la presentazione.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta le Proprietà del Carattere del Testo**
{{% alert color="info" title="Note" %}} 

Come menzionato in **Gestire le Proprietà dei Caratteri**, un [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/) viene utilizzato per contenere testo con uno stesso stile di formattazione in un paragrafo. Questo articolo mostra come utilizzare Aspose.Slides for Python via Java per creare una casella di testo con del testo e poi definire un carattere specifico e varie altre proprietà del carattere.

{{% /alert %}} 

Per creare una casella di testo e impostare le proprietà del carattere del testo al suo interno:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni il riferimento di una diapositiva utilizzando il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) di tipo **Rectangle** alla diapositiva.
1. Rimuovi lo stile di riempimento associato al [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/).
1. Accedi al [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) dell'[AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/).
1. Aggiungi del testo al [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/).
1. Accedi all'oggetto [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/) associato al [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/).
1. Definisci il carattere da utilizzare per la [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/).
1. Imposta altre proprietà del carattere come grassetto, corsivo, sottolineato, colore e altezza utilizzando le proprietà rilevanti esposte dall'oggetto [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/).
1. Scrivi la presentazione modificata in un file PPTX.

L'implementazione dei passaggi sopra è mostrata di seguito.

|![Testo con proprietà dei caratteri applicate](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Testo con alcune proprietà dei caratteri impostate da Aspose.Slides for Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Ottieni la prima diapositiva e aggiungi un rettangolo.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Rimuovi il riempimento della forma.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Aggiungi testo al frame di testo della forma.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Imposta la famiglia del carattere.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Imposta grassetto, corsivo, sottolineatura e dimensione del carattere.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Imposta il colore del carattere.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Salva la presentazione.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```