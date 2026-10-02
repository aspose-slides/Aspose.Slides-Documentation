---
title: Gestire i paragrafi di testo PowerPoint in Python tramite Java
linktitle: Gestisci Paragrafo
type: docs
weight: 40
url: /it/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- aggiungi testo
- aggiungi paragrafo
- gestisci testo
- gestisci paragrafo
- gestisci bullet
- indentazione paragrafo
- indentazione sospesa
- puntatore paragrafo
- elenco numerato
- elenco puntato
- proprietà del paragrafo
- importa HTML
- testo in HTML
- paragrafo in HTML
- paragrafo in immagine
- testo in immagine
- esporta paragrafo
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come creare e formattare paragrafi, porzioni, proiettili, elenchi numerati, rientri, contenuti HTML e immagini di paragrafi con Aspose.Slides per Python tramite Java."
---
## **Panoramica**

Aspose.Slides per Python tramite Java rappresenta il testo come una gerarchia di cornici di testo, paragrafi e porzioni:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua raccolta di paragrafi.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) rappresenta un paragrafo in una cornice di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) rappresenta un blocco di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con caratteri, colori, dimensioni e altre formattazioni diverse usando più porzioni.

## **Crea e formatta i paragrafi**

### **Crea paragrafi con più porzioni**

I seguenti passaggi creano una cornice di testo con tre paragrafi, ciascuno contenente tre porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) della forma.
5. Usa il paragrafo predefinito e aggiungi altri due oggetti [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) alla cornice di testo.
6. Aggiungi sufficienti oggetti [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) affinché ogni paragrafo contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Imposta il testo di ogni porzione.
8. Applica la formattazione a livello di carattere tramite [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat).
9. Salva la presentazione modificata.

Questo esempio Python implementa i passaggi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Crea elenchi puntati e numerati**

### **Crea un elenco puntato o numerato**

I puntini e la numerazione rendono più facile la scansione degli elementi correlati. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/).

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) alla diapositiva selezionata.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) della forma.
5. Rimuovi il paragrafo predefinito dalla cornice di testo.
6. Crea un [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) per un proiettile a simbolo.
7. Imposta [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) a [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) e specifica il carattere del proiettile.
8. Imposta il testo del paragrafo, l'indentazione, il colore del proiettile e l'altezza del proiettile.
9. Aggiungi il paragrafo alla cornice di testo.
10. Crea un secondo paragrafo e imposta [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) a [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered).
11. Configura lo stile del proiettile numerato e aggiungi il paragrafo alla cornice di testo.
12. Salva la presentazione.

Questo esempio Python crea un proiettile a simbolo e un proiettile numerato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utilizza proiettili immagine**

I proiettili immagine consentono di utilizzare un'immagine personalizzata invece di un simbolo o di un numero.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) e accedi al suo [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).
4. Rimuovi il paragrafo predefinito dalla cornice di testo.
5. Carica l'immagine del proiettile e aggiungila alla raccolta di immagini della presentazione come [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/).
6. Crea un [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) e imposta il suo testo.
7. Imposta [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) a [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture).
8. Assegna l'immagine tramite [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) e imposta l'altezza del proiettile.
9. Aggiungi il paragrafo alla cornice di testo.
10. Salva la presentazione modificata.

Questo esempio Python crea un proiettile immagine:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **Crea un elenco multilivello**

Imposta [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) per posizionare i paragrafi a livelli diversi di un elenco. Il livello più alto ha una profondità di `0`.

1. Crea una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi una [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) e cancella il paragrafo predefinito dalla sua cornice di testo.
3. Crea quattro paragrafi e configura i loro simboli di proiettile.
4. Imposta i valori di [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) su `0`, `1`, `2` e `3`.
5. Aggiungi i paragrafi alla cornice di testo e salva la presentazione.

Questo esempio Python crea un elenco puntato a quattro livelli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Avvia gli elementi dell'elenco numerato con valori personalizzati**

Usa [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Crea una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e aggiungi una [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) a una diapositiva.
2. Cancella il paragrafo predefinito dalla cornice di testo della forma.
3. Crea tre paragrafi numerati.
4. Imposta [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) su `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungi i paragrafi alla cornice di testo e salva la presentazione.

Questo esempio Python assegna un numero di partenza personalizzato a ciascun paragrafo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlla il layout del paragrafo e le proprietà finali**

### **Imposta un'indentazione della prima riga**

Usa [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) per controllare l'indentazione della prima riga di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usa [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) quando è necessario spostare l'intero paragrafo. Usa [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) quando è necessario spostare solo la prima riga.

L'esempio sottostante crea diversi paragrafi e applica valori diversi di [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) per dimostrare come l'indentazione della prima riga influisce sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi alla diapositiva target.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) della forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori diversi di [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) per ciascuno.
6. Aggiungi i paragrafi alla cornice di testo.
7. Salva la presentazione modificata.

Questo codice mostra come impostare un'indentazione del paragrafo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L'indentazione della prima riga dei paragrafi](first_line_indent.png)

### **Imposta un'indentazione sospesa**

Un'indentazione sospesa è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe rimanenti. In Aspose.Slides, crei questo effetto con [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent). Fornisci un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) definisce la posizione sinistra del corpo del paragrafo, e [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) definisce la posizione della prima riga rispetto a quel margine. Per creare un'indentazione sospesa, fornisci un valore positivo a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) e un valore negativo a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent).

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi alla diapositiva target.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) della forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e fornisci un valore positivo a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) per ciascun paragrafo.
6. Fornisci un valore negativo a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) per creare l'effetto di indentazione sospesa.
7. Aggiungi i paragrafi alla cornice di testo.
8. Salva la presentazione modificata.

Questo codice mostra come impostare un'indentazione sospesa per un paragrafo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L'indentazione sospesa dei paragrafi](hanging_indent.png)

### **Imposta le proprietà di esecuzione alla fine del paragrafo**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) controlla la formattazione del segno di fine paragrafo. L'esempio seguente assegna una dimensione del carattere e un font latino al segno di fine del secondo paragrafo:

1. Carica una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi una [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) e cancella il suo paragrafo predefinito.
3. Crea due paragrafi e aggiungi porzioni di testo a ciascuno.
4. Crea un [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Imposta [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) e [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont).
6. Assegna il formato con [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) e salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Conta le righe renderizzate**

Per le regole dei paragrafi che influenzano l'avvolgimento automatico e la punteggiatura alle estremità delle righe, vedi [Controlla interruzione di riga](/slides/it/python-java/text-formatting/#control-line-breaking) e [Controlla punteggiatura sospesa](/slides/it/python-java/text-formatting/#control-hanging-punctuation).

Usa [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) per contare le righe occupate da un paragrafo dopo il layout del testo, includendo l'avvolgimento automatico. Questo è utile quando si verifica la lunghezza del testo e il layout nei modelli di presentazione.

Un paragrafo è un elemento in [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs) e può occupare diverse righe renderizzate. Un'interruzione di riga esplicita all'interno di un paragrafo forza una nuova riga senza creare un altro paragrafo. L'avvolgimento automatico crea righe basandosi sulla larghezza disponibile senza inserire interruzioni di riga esplicite nel testo. Pertanto, il conteggio dei paragrafi o dei caratteri di interruzione di riga non fornisce il conteggio delle righe renderizzate.

L'esempio seguente crea una forma di testo, conta le sue righe, restringe la forma e quindi sostituisce il testo con una stringa più breve. L'avvolgimento è abilitato e l'adattamento automatico è disabilitato in modo che la larghezza della forma controlli l'avvolgimento senza ridurre automaticamente il testo o ridimensionare la forma. Le dimensioni della forma sono in punti. Infine, l'esempio aggiunge un altro paragrafo e somma i conteggi delle righe nell'intera cornice di testo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

Con questo testo e queste dimensioni, restringere la forma aumenta il conteggio delle righe, mentre sostituire il testo con la stringa corta lo riduce. I conteggi esatti possono variare a seconda della disponibilità dei font e della loro sostituzione, della dimensione del carattere, dei margini, dell'indentazione, dell'avvolgimento e delle impostazioni di adattamento automatico. Usa i font e le impostazioni di layout destinati all'ambiente di destinazione quando verifichi un modello.

Il solo conteggio delle righe non determina se il testo supera il contenitore. Anche l'altezza disponibile, le altezze delle righe, la spaziatura dei paragrafi e delle righe e il comportamento di adattamento automatico influiscono; anche una singola riga può superare la larghezza disponibile quando l'avvolgimento è disabilitato.

## **Importa ed esporta il contenuto dei paragrafi**

### **Importa testo HTML nei paragrafi**

Usa [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) per convertire il markup HTML in paragrafi e porzioni in una cornice di testo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi a una diapositiva e aggiungi una [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
3. Accedi al [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) della forma e cancella il suo paragrafo predefinito.
4. Leggi il file HTML di origine.
5. Passa la stringa HTML a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Salva la presentazione modificata.

Questo esempio Python importa HTML in una cornice di testo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **Esporta il testo del paragrafo in HTML**

Usa [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) per esportare un intervallo selezionato di paragrafi come HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e carica la presentazione desiderata.
2. Accedi alla diapositiva e trova la [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) che contiene il testo.
3. Accedi al [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) della forma.
4. Chiama [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) specificando l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivi la stringa HTML restituita in un file.

Questo esempio Python esporta tutti i paragrafi dalla prima forma di testo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **Renderizza un paragrafo come immagine**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) renderizza direttamente un singolo paragrafo e restituisce un oggetto immagine. Salva il risultato in un file o stream con il metodo `save`. Non è necessario renderizzare la forma contenente o ritagliare manualmente una bitmap.

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) può restituire `None` se il paragrafo non si trova nella raccolta genitore, non ha limiti di rendering validi o non può essere renderizzato. Controlla il risultato prima di salvarlo e rilascia l'immagine restituita dopo l'uso.

#### **Renderizza un paragrafo alla scala predefinita**

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, in cui la prima forma è una casella di testo contenente tre paragrafi.

![Il riquadro di testo con tre paragrafi](paragraph_to_image_input.png)

L'esempio seguente renderizza il secondo paragrafo in una forma di testo normale alla scala predefinita e salva l'immagine restituita in formato PNG. Il blocco `finally` garantisce che l'immagine venga rilasciata correttamente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

Il risultato:

![L'immagine del paragrafo](paragraph_to_image_output.png)

#### **Renderizza un paragrafo in una cella di tabella con scaling**

Usa la sovraccarico di [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) che accetta i parametri `scale_x` e `scale_y` per impostare i fattori di scala orizzontale e verticale. L'esempio seguente crea una tabella, renderizza il paragrafo nella sua prima cella al doppio della larghezza e dell'altezza predefinite e salva il risultato come immagine PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

Un fattore di scala di `1` mantiene quell'asse alla dimensione pixel predefinita. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono approssimativamente il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per lo zoom o output ad alta risoluzione, ma aumentano anche l'uso di memoria e la dimensione del file. Fattori inferiori a `1` producono immagini più piccole con meno dettaglio. Usa fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori orizzontali e verticali diversi allungano l'output indipendentemente.

Renderizzare un'intera forma con [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) rimane utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine contenente solo il paragrafo, usa [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/).

## **FAQ**

**Posso disabilitare completamente l'andare a capo automatico all'interno di una cornice di testo?**

Sì. Imposta [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) per disabilitare l'avvolgimento in modo che le linee non si interrompano ai bordi della cornice di testo.

**Come posso ottenere i limiti esatti sul diapositiva di un paragrafo specifico?**

Usa [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) per recuperare il rettangolo di delimitazione del paragrafo. [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

Per allineare verticalmente le porzioni di diverse dimensioni di carattere all'interno di ciascuna riga, vedi [Allinea i font all'interno di una riga](/slides/it/python-java/text-formatting/#align-fonts-within-a-line).

**Posso impostare la lingua di verifica per parte di un paragrafo?**

Sì. Imposta [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) per le singole porzioni, in modo che un paragrafo possa contenere testo in più lingue.