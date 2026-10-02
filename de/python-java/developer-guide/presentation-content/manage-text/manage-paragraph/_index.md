---
title: PowerPoint-Textabsätze in Python über Java verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
  - Text hinzufügen
  - Absatz hinzufügen
  - Text verwalten
  - Absatz verwalten
  - Aufzählungszeichen verwalten
  - Absatzeinzug
  - hängender Einzug
  - Absatzaufzählung
  - nummerierte Liste
  - Aufzählungsliste
  - Absatzeigenschaften
  - HTML importieren
  - Text zu HTML
  - Absatz zu HTML
  - Absatz zu Bild
  - Text zu Bild
  - Absatz exportieren
  - PowerPoint
  - Präsentation
  - Python
  - Java
  - Aspose.Slides
description: "Lernen Sie, wie Sie mit Aspose.Slides für Python über Java Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML-Inhalte und Absatzbilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für Python über Java stellt Text als Hierarchie von Textfeldern, Absätzen und Portionen dar:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) stellt den Textbehälter in einer Form dar und bietet Zugriff auf deren Absatzsammlung.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) stellt einen Absatz in einem Textfeld dar und bietet Zugriff auf seine Portionen und Absatz‑bezogene Formatierung.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) stellt einen Textlauf innerhalb eines Absatzes dar. Jede Portion kann ihren eigenen Text und Zeichen‑bezogene Formatierung besitzen.

Ein Absatz kann daher Text mit unterschiedlichen Schriftarten, Farben, Größen und sonstiger Formatierung enthalten, indem mehrere Portionen verwendet werden.

## **Absätze erstellen und formatieren**

### **Absätze mit mehreren Portionen erstellen**

Die folgenden Schritte erzeugen ein Textfeld mit drei Absätzen, die jeweils drei Portionen enthalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) der Form zu.
5. Verwenden Sie den Standardabsatz und fügen Sie dem Textfeld zwei weitere [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/)‑Objekte hinzu.
6. Fügen Sie genügend [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/)‑Objekte hinzu, sodass jeder Absatz drei Portionen enthält. Der Standardabsatz enthält bereits eine leere Portion.
7. Setzen Sie den Text jeder Portion.
8. Wenden Sie Zeichen‑bezogene Formatierung über [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat) an.
9. Speichern Sie die geänderte Präsentation.

Dieses Python‑Beispiel implementiert die Schritte:

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

## **Aufzählungen und nummerierte Listen erstellen**

### **Eine Aufzählungs‑ oder nummerierte Liste erstellen**

Aufzählungszeichen und Nummerierungen erleichtern das Scannen zusammengehöriger Elemente. In Aspose.Slides werden Listeneinstellungen über [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) definiert.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) der Form zu.
5. Entfernen Sie den Standardabsatz aus dem Textfeld.
6. Erstellen Sie einen [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) für ein Symbol‑Aufzählungszeichen.
7. Setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) auf [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) und geben Sie das Aufzählungszeichen‑Symbol an.
8. Legen Sie den Absatztext, Einzug, Aufzählungszeichenfarbe und Aufzählungszeichenhöhe fest.
9. Fügen Sie den Absatz dem Textfeld hinzu.
10. Erstellen Sie einen zweiten Absatz und setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) auf [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered).
11. Konfigurieren Sie den nummerierten Aufzählungsstil und fügen Sie den Absatz dem Textfeld hinzu.
12. Speichern Sie die Präsentation.

Dieses Python‑Beispiel erstellt ein Symbol‑Aufzählungszeichen und ein nummeriertes Aufzählungszeichen:

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

### **Bild‑Aufzählungszeichen verwenden**

Bild‑Aufzählungszeichen ermöglichen die Verwendung eines benutzerdefinierten Bildes anstelle eines Symbols oder einer Zahl.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu und greifen Sie auf dessen [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) zu.
4. Entfernen Sie den Standardabsatz aus dem Textfeld.
5. Laden Sie das Aufzählungs‑Bild und fügen Sie es der Bildsammlung der Präsentation als [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) hinzu.
6. Erstellen Sie einen [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) und setzen Sie dessen Text.
7. Setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) auf [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture).
8. Weisen Sie das Bild über [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) zu und legen Sie die Aufzählungszeichenhöhe fest.
9. Fügen Sie den Absatz dem Textfeld hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieses Python‑Beispiel erstellt ein Bild‑Aufzählungszeichen:

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

### **Eine mehrstufige Liste erstellen**

Setzen Sie [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth), um Absätze auf verschiedenen Ebenen einer Liste zu platzieren. Die oberste Ebene hat eine Tiefe von `0`.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu und entfernen Sie den Standardabsatz aus dessen Textfeld.
3. Erstellen Sie vier Absätze und konfigurieren Sie deren Aufzählungssymbole.
4. Setzen Sie ihre [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth)-Werte auf `0`, `1`, `2` und `3`.
5. Fügen Sie die Absätze dem Textfeld hinzu und speichern Sie die Präsentation.

Dieses Python‑Beispiel erstellt eine vierstufige Aufzählungsliste:

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

### **Nummerierte Listenelemente bei benutzerdefinierten Werten beginnen lassen**

Verwenden Sie [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), um die anfängliche Zahl für einen nummerierten Absatz festzulegen.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) und fügen Sie einer Folie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
2. Entfernen Sie den Standardabsatz aus dem Textfeld der Form.
3. Erstellen Sie drei nummerierte Absätze.
4. Setzen Sie [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) für die jeweiligen Absätze auf `2`, `3` bzw. `7`.
5. Fügen Sie die Absätze dem Textfeld hinzu und speichern Sie die Präsentation.

Dieses Python‑Beispiel weist jedem Absatz eine benutzerdefinierte Startzahl zu:

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

## **Absatzlayout und End‑Eigenschaften steuern**

### **Ein Erstzeileneinzug festlegen**

Verwenden Sie [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent), um den Erstzeileneinzug eines Absatzes zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft), wenn Sie den gesamten Absatz verschieben müssen. Verwenden Sie [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent), wenn Sie nur die erste Zeile verschieben möchten.

Das nachstehende Beispiel erstellt mehrere Absätze und wendet verschiedene [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent)-Werte an, um zu zeigen, wie der Erstzeileneinzug das Absatzlayout beeinflusst.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie mehrere Absätze und setzen Sie unterschiedliche [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent)-Werte für sie.
6. Fügen Sie die Absätze dem Textfeld hinzu.
7. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie man einen Absatz‑Einzug festlegt:

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

Das Ergebnis:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Einen hängenden Einzug festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent). Übergeben Sie einen negativen Wert, um die erste Zeile nach links relativ zum Absatzkörper zu verschieben.

In der Praxis legt [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) die linke Position des Absatzkörpers fest, und [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) definiert die Position der ersten Zeile relativ zu diesem Rand. Um einen hängenden Einzug zu erzeugen, übergeben Sie einen positiven Wert an [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) und einen negativen Wert an [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent).

Diese Formatierung ist nützlich für Bibliografien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie Absätze und übergeben Sie für jeden Absatz einen positiven Wert an [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft).
6. Übergeben Sie einen negativen Wert an [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent), um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Absätze dem Textfeld hinzu.
8. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie man einen hängenden Einzug für einen Absatz festlegt:

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

Das Ergebnis:

![The hanging indent of the paragraphs](hanging_indent.png)

### **End‑Absatz‑Lauf‑Eigenschaften festlegen**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) steuert die Formatierung des Absatzendzeichens. Das folgende Beispiel weist dem Endzeichen des zweiten Absatzes eine Schriftgröße und eine lateinische Schrift zu:

1. Laden Sie eine [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu und entfernen Sie dessen Standardabsatz.
3. Erstellen Sie zwei Absätze und fügen Sie ihnen Textportionen hinzu.
4. Erstellen Sie ein [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) für das Endzeichen des zweiten Absatzes.
5. Setzen Sie [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) und [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont).
6. Weisen Sie das Format mit [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) zu und speichern Sie die Präsentation.

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

## **Gerenderte Zeilen zählen**

Für Absatzregeln, die automatisches Umbrechen und Interpunktion am Zeilenende beeinflussen, siehe [Control Line Breaking](/slides/de/python-java/text-formatting/#control-line-breaking) und [Control Hanging Punctuation](/slides/de/python-java/text-formatting/#control-hanging-punctuation).

Verwenden Sie [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount), um die von einem Absatz nach der Textanordnung belegten Zeilen zu zählen, einschließlich automatischem Umbrechen. Das ist nützlich, um Textlänge und Layout in Präsentationsvorlagen zu prüfen.

Ein Absatz ist ein Element in [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs) und kann mehrere gerenderte Zeilen belegen. Ein expliziter Zeilenumbruch innerhalb eines Absatzes erzwingt eine neue Zeile, ohne einen weiteren Absatz zu erzeugen. Automatisches Umbrechen erzeugt Zeilen basierend auf der verfügbaren Breite, ohne explizite Zeilenumbrüche in den Text einzufügen. Das Zählen von Absätzen oder Zeilenumbruch‑Zeichen liefert daher nicht die Anzahl der gerenderten Zeilen.

Das folgende Beispiel erstellt eine Textform, zählt deren Zeilen, verengt die Form und ersetzt dann den Text durch einen kürzeren String. Umbrechen ist aktiviert und AutoFit deaktiviert, sodass die Formbreite das Umbrechen steuert, ohne den Text automatisch zu verkleinern oder die Form zu skalieren. Die Formabmessungen werden in Punkt angegeben. Abschließend fügt das Beispiel einen weiteren Absatz hinzu und summiert die Zeilenzahlen über das Textfeld.

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

Mit diesem Text und diesen Abmessungen erhöht das Verengen der Form die Zeilenzahl, während das Ersetzen des Textes durch den kurzen String sie reduziert. Exakte Zählungen können je nach Schriftverfügbarkeit und -ersatz, Schriftgröße, Rändern, Einzügen, Umbrechen und AutoFit‑Einstellungen variieren. Verwenden Sie die für die Zielumgebung vorgesehenen Schriften und Layout‑Einstellungen, wenn Sie eine Vorlage prüfen.

Die Zeilenzahl allein bestimmt nicht, ob der Text seinen Container überläuft. Die verfügbare Höhe, Zeilenhöhen, Absatz‑ und Zeilenabstände sowie das AutoFit‑Verhalten spielen ebenfalls eine Rolle; selbst eine einzelne Zeile kann die verfügbare Breite überschreiten, wenn Umbrechen deaktiviert ist.

## **Absatzinhalt importieren und exportieren**

### **HTML‑Text in Absätze importieren**

Verwenden Sie [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml), um HTML‑Markup in Absätze und Portionen eines Textfeldes zu konvertieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Greifen Sie auf eine Folie zu und fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) hinzu.
3. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) der Form zu und entfernen Sie den Standardabsatz.
4. Lesen Sie die Quell‑HTML‑Datei.
5. Übergeben Sie die HTML‑Zeichenkette an [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Speichern Sie die geänderte Präsentation.

Dieses Python‑Beispiel importiert HTML in ein Textfeld:

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

### **Absatztext nach HTML exportieren**

Verwenden Sie [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml), um einen ausgewählten Absatzbereich als HTML zu exportieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie auf die Folie zu und finden Sie das [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), das den Text enthält.
3. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) der Form zu.
4. Rufen Sie [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) mit dem Start‑Absatz‑Index und der Anzahl der zu exportierenden Absätze auf.
5. Schreiben Sie die zurückgegebene HTML‑Zeichenkette in eine Datei.

Dieses Python‑Beispiel exportiert alle Absätze aus dem ersten Textfeld:

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

### **Einen Absatz als Bild rendern**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) rendert einen einzelnen Absatz direkt und gibt ein Bildobjekt zurück. Speichern Sie das Ergebnis mit der `save`‑Methode in einer Datei oder einem Stream. Sie müssen die enthaltende Form nicht rendern oder ein Bitmap manuell zuschneiden.

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) kann `None` zurückgeben, wenn der Absatz nicht in seiner übergeordneten Sammlung gefunden wird, keine gültigen Render‑Grenzen hat oder nicht gerendert werden kann. Prüfen Sie das Ergebnis vor dem Speichern und geben Sie das zurückgegebene Bild nach der Verwendung frei.

#### **Einen Absatz im Default‑Maßstab rendern**

Angenommen, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, wobei die erste Form ein Textfeld mit drei Absätzen ist.

![The text box with three paragraphs](paragraph_to_image_input.png)

Das folgende Beispiel rendert den zweiten Absatz in einer regulären Textform im Default‑Maßstab und speichert das zurückgegebene Bild im PNG‑Format. Der `finally`‑Block stellt sicher, dass das Bild korrekt freigegeben wird.

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

Das Ergebnis:

![The paragraph image](paragraph_to_image_output.png)

#### **Einen Absatz in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) , die die Parameter `scale_x` und `scale_y` akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Absatz in ihrer ersten Zelle mit dem doppelten der Standardbreite und -höhe und speichert das Ergebnis als PNG‑Bild.

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

Ein Skalierungsfaktor von `1` behält diese Achse bei ihrer Standard‑Pixelgröße bei. Beispielsweise erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa doppelt so groß sind wie die Standardabmessungen, was zu viermal so vielen Pixeln führt. Größere Faktoren erzeugen im Allgemeinen schärferen Text für das Zoomen oder hochauflösende Ausgaben, erhöhen jedoch auch den Speicherverbrauch und die Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Absatzes zu erhalten; unterschiedliche horizontale und vertikale Faktoren strecken die Ausgabe unabhängig voneinander.

Das Rendern einer gesamten Form mit [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) bleibt nützlich, wenn die Ausgabe die Füllung, den Rand oder anderen visuellen Kontext der Form enthalten muss. Für ein reines Absatz‑Bild verwenden Sie [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/).

## **FAQ**

**Kann ich das Zeilenumbruch‑Verhalten in einem Textfeld vollständig deaktivieren?**

Ja. Setzen Sie [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), um das Umbrechen zu deaktivieren, sodass Zeilen nicht an den Rändern des Textfelds umgebrochen werden.

**Wie kann ich die genauen Folien‑Grenzen eines bestimmten Absatzes ermitteln?**

Verwenden Sie [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect), um das begrenzende Rechteck des Absatzes abzurufen. [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatz‑Ausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) ist eine Absatz‑Ebene‑Einstellung und gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

Um Portionen unterschiedlicher Schriftgrößen innerhalb jeder Zeile vertikal auszurichten, siehe [Align Fonts Within a Line](/slides/de/python-java/text-formatting/#align-fonts-within-a-line).

**Kann ich die Korrektursprache für einen Teil eines Absatzes festlegen?**

Ja. Setzen Sie [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) für einzelne Portionen, sodass ein Absatz Text in mehreren Sprachen enthalten kann.