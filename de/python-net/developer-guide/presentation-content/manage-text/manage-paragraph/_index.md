---
title: Verwalten von Textabsätzen in Präsentationen mit Python
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/python-net/manage-paragraph/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatzeinzug
- hängender Einzug
- Absatz-Aufzählungszeichen
- nummerierte Liste
- Aufzählungsliste
- Absatz-Eigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absatz zu Bild
- Text zu Bild
- Absatz exportieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Beherrschen Sie die Absatzformatierung mit Aspose.Slides für Python über .NET — optimieren Sie Ausrichtung, Abstände und Stil in PowerPoint- und OpenDocument-Präsentationen in Python, um die Zuschauer zu begeistern."
---

Aspose.Slides bietet alle Schnittstellen und Klassen, die Sie benötigen, um in Python mit PowerPoint-Texten, Absätzen und Teilen zu arbeiten.

* Aspose.Slides bietet die [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) Schnittstelle, um Objekte hinzuzufügen, die einen Absatz darstellen. Ein `ITextFame`-Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides bietet die [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) Schnittstelle, um Objekte hinzuzufügen, die Teile darstellen. Ein `IParagraph`-Objekt kann einen oder mehrere Teile (Sammlung von iPortions-Objekten) enthalten.
* Aspose.Slides bietet die [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) Schnittstelle, um Objekte hinzuzufügen, die Texte und deren Formatierungseigenschaften darstellen.

Ein `IParagraph`-Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`-Objekte verwalten.

## **Mehrere Absätze mit mehreren Teilen hinzufügen**

Diese Schritte zeigen Ihnen, wie Sie einen Textbereich mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Teile enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folienreferenz zu.
3. Fügen Sie der Folie eine Rechteck-[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
4. Holen Sie sich das ITextFrame, das mit der [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) verknüpft ist.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) Objekte und fügen Sie diese der `IParagraphs`-Sammlung des [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) hinzu.
6. Erstellen Sie drei [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) Objekte für jeden neuen `IParagraph` (zwei Portionenobjekte für den Standardparagraphen) und fügen Sie jedes `IPortion`-Objekt der IPortion-Sammlung jedes `IParagraph` hinzu.
7. Setzen Sie für jedes Teil einen Text.
8. Wenden Sie Ihre bevorzugten Formatierungsmerkmale auf jedes Teil an, indem Sie die von dem `IPortion`-Objekt bereitgestellten Formatierungseigenschaften verwenden.
9. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code ist eine Implementierung der Schritte zum Hinzufügen von Absätzen mit Teilen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen Sie eine Instanz der Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation() as pres:
    # Zugriff auf die erste Folie
    slide = pres.slides[0]

    # Hinzufügen einer AutoShape vom Typ Rechteck
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Zugriff auf das TextFrame der AutoShape
    tf = ashp.text_frame

    # Erstellen von Absätzen und Teilen mit unterschiedlichen Textformaten
    para0 = tf.paragraphs[0]
    port01 = slides.Portion()
    port02 = slides.Portion()
    para0.portions.add(port01)
    para0.portions.add(port02)

    para1 = slides.Paragraph()
    tf.paragraphs.add(para1)
    port10 = slides.Portion()
    port11 = slides.Portion()
    port12 = slides.Portion()
    para1.portions.add(port10)
    para1.portions.add(port11)
    para1.portions.add(port12)

    para2 = slides.Paragraph()
    tf.paragraphs.add(para2)
    port20 = slides.Portion()
    port21 = slides.Portion()
    port22 = slides.Portion()
    para2.portions.add(port20)
    para2.portions.add(port21)
    para2.portions.add(port22)

    for i in range(3):
        for j in range(3):
            tf.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                tf.paragraphs[i].portions[j].portion_format.font_bold = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                tf.paragraphs[i].portions[j].portion_format.font_italic = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 18

    # Schreiben Sie PPTX auf die Festplatte
    pres.save("multiParaPort_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Absatzaufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folienreferenz zu.
3. Fügen Sie der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) Klasse.
7. Setzen Sie den Aufzählungstyp für den Absatz auf `Symbol` und legen Sie das Aufzählungszeichen fest.
8. Setzen Sie den Absatztext.
9. Setzen Sie die Indentierung des Absatzes für das Aufzählungszeichen.
10. Setzen Sie eine Farbe für das Aufzählungszeichen.
11. Setzen Sie eine Höhe des Aufzählungszeichens.
12. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess gemäß den Schritten 7 bis 13.
14. Speichern Sie die Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie ein Absatzaufzählungszeichen hinzufügen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen einer Präsentationsinstanz
with slides.Presentation() as pres:
    # Zugriff auf die erste Folie
    slide = pres.slides[0]

    # Hinzufügen und Zugriff auf AutoShape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Zugriff auf das TextFrame der erstellten AutoShape
    txtFrm = aShp.text_frame

    # Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.paragraphs.remove_at(0)

    # Erstellen eines Absatzes
    para = slides.Paragraph()

    # Festlegen des Absatzaufzählungsstil und Symbols
    para.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para.paragraph_format.bullet.char = chr(8226)

    # Festlegen des Absatztextes
    para.text = "Willkommen bei Aspose.Slides"

    # Festlegen der Aufzählungsindentierung
    para.paragraph_format.indent = 25

    # Festlegen der Aufzählungsfarbe
    para.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para.paragraph_format.bullet.color.color = draw.Color.black
    para.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Festlegen der Aufzählungshöhe
    para.paragraph_format.bullet.height = 100

    # Hinzufügen des Absatzes zum Textfeld
    txtFrm.paragraphs.add(para)

    # Erstellen des zweiten Absatzes
    para2 = slides.Paragraph()

    # Festlegen des Absatzaufzählungstyps und -stils
    para2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    para2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Hinzufügen des Absatztextes
    para2.text = "Dies ist ein nummeriertes Aufzählungszeichen"

    # Festlegen der Aufzählungsindentierung
    para2.paragraph_format.indent = 25

    para2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para2.paragraph_format.bullet.color.color = draw.Color.black
    para2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Festlegen der Aufzählungshöhe
    para2.paragraph_format.bullet.height = 100

    # Hinzufügen des Absatzes zum Textfeld
    txtFrm.paragraphs.add(para2)


    # Schreiben der Präsentation als PPTX-Datei
    pres.save("bullet_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Bilder als Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bildabsätze sind einfach zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folienreferenz zu.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungstyp auf [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) und setzen Sie das Bild.
9. Setzen Sie den Absatztext.
10. Setzen Sie die Indentierung des Absatzes für das Aufzählungszeichen.
11. Setzen Sie eine Farbe für das Aufzählungszeichen.
12. Setzen Sie eine Höhe für das Aufzählungszeichen.
13. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess basierend auf den vorherigen Schritten.
15. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie Bilder als Aufzählungszeichen hinzufügen und verwalten:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Zugriff auf die erste Folie
    slide = presentation.slides[0]

    # Instanziieren Sie das Bild für Aufzählungszeichen
    image = draw.Bitmap(path + "bullets.png")
    ippxImage = presentation.images.add_image(image)

    # Hinzufügen und Zugriff auf AutoShape
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Zugriff auf das TextFrame der erstellten AutoShape
    textFrame = autoShape.text_frame

    # Entfernen desstandardmäßigen vorhandenen Absatzes
    textFrame.paragraphs.remove_at(0)

    # Erstellen eines neuen Absatzes
    paragraph = slides.Paragraph()
    paragraph.text = "Willkommen bei Aspose.Slides"

    # Festlegen des Absatzaufzählungsstils und des Bildes
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = ippxImage

    # Festlegen der Aufzählungshöhe
    paragraph.paragraph_format.bullet.height = 100

    # Hinzufügen des Absatzes zum Textfeld
    textFrame.paragraphs.add(paragraph)

    # Schreiben der Präsentation als PPTX-Datei
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", slides.export.SaveFormat.PPTX)
    # Schreiben der Präsentation als PPT-Datei
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", slides.export.SaveFormat.PPT)
```


## **Mehrstufige Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Mehrstufige Aufzählungszeichen sind einfach zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folienreferenz zu.
3. Fügen Sie in der neuen Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz über die `Paragraph`-Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz über die `Paragraph`-Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz über die `Paragraph`-Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
11. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie mehrstufige Aufzählungszeichen hinzufügen und verwalten:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen einer Präsentationsinstanz
with slides.Presentation() as pres:
    # Zugriff auf die erste Folie
    slide = pres.slides[0]
    
    # Hinzufügen und Zugriff auf AutoShape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Zugriff auf das TextFrame der erstellten AutoShape
    text = aShp.add_text_frame("")
    
    # Löschen des Standardabsatzes
    text.paragraphs.clear()

    # Hinzufügen des ersten Absatzes
    para1 = slides.Paragraph()
    para1.text = "Inhalt"
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setzen der Aufzählungsebene
    para1.paragraph_format.depth = 0

    # Hinzufügen des zweiten Absatzes
    para2 = slides.Paragraph()
    para2.text = "Zweite Ebene"
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = '-'
    para2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setzen der Aufzählungsebene
    para2.paragraph_format.depth = 1

    # Hinzufügen des dritten Absatzes
    para3 = slides.Paragraph()
    para3.text = "Dritte Ebene"
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setzen der Aufzählungsebene
    para3.paragraph_format.depth = 2

    # Hinzufügen des vierten Absatzes
    para4 = slides.Paragraph()
    para4.text = "Vierte Ebene"
    para4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para4.paragraph_format.bullet.char = '-'
    para4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setzen der Aufzählungsebene
    para4.paragraph_format.depth = 3

    # Hinzufügen der Absätze zur Sammlung
    text.paragraphs.add(para1)
    text.paragraphs.add(para2)
    text.paragraphs.add(para3)
    text.paragraphs.add(para4)

    # Schreiben der Präsentation als PPTX-Datei
    pres.save("MultilevelBullet.pptx", slides.export.SaveFormat.PPTX)
```


## **Absatz mit benutzerdefinierter nummerierter Liste verwalten**

Die [IBulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformat/#ibulletformat/) Schnittstelle bietet die Eigenschaft `NumberedBulletStartWith` und andere, die Ihnen ermöglichen, Absätze mit benutzerdefinierter Nummerierung oder Formatierung zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz durch die [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) Klasse und setzen Sie `NumberedBulletStartWith` auf 2.
7. Erstellen Sie die zweite Absatzinstanz durch die `Paragraph` Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatzinstanz durch die `Paragraph` Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
10. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung hinzufügen und verwalten:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Zugriff auf das TextFrame der erstellten AutoShape
    textFrame = shape.text_frame

    # Entfernen des standardmäßig vorhandenen Absatzes
    textFrame.paragraphs.remove_at(0)

    # Erster Listeneintrag
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Aufzählung 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.text = "Aufzählung 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    textFrame.paragraphs.add(paragraph2)


    paragraph5 = slides.Paragraph()
    paragraph5.text = "Aufzählung 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph5)

    presentation.save("SetCustomBulletsNumber-slides.pptx", slides.export.SaveFormat.PPTX)
```


## **Absatz-Indentation festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Greifen Sie über den Index auf die entsprechende Folienreferenz zu.
1. Fügen Sie der Folie eine Rechteck-[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck-AutoShape ein [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) mit drei Absätzen hinzu.
1. Blenden Sie die Linien des Rechtecks aus.
1. Setzen Sie die Indentierung für jeden [Absatz](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) über deren BulletOffset-Eigenschaft.
1. Schreiben Sie die modifizierte Präsentation als PPT-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie eine Absatz-Indentation festlegen:

```python
import aspose.slides as slides

# Instanziieren Sie die Präsentationsklasse
with slides.Presentation() as pres:

    # Holen Sie sich die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine rechteckige Form hinzu
    rect = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # Fügen Sie dem Rechteck ein TextFrame hinzu
    tf = rect.add_text_frame("Dies ist die erste Zeile \rDies ist die zweite Zeile \rDies ist die dritte Zeile")

    # Setzen Sie den Text so, dass er in die Form passt
    tf.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Blenden Sie die Linien des Rechtecks aus
    rect.line_format.fill_format.fill_type = slides.FillType.SOLID

    # Holen Sie sich den ersten Absatz im TextFrame und legen Sie dessen Indent fest
    para1 = tf.paragraphs[0]
    # Festlegen des Absatzaufzählungsstils und Symbols
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.alignment = slides.TextAlignment.LEFT

    para1.paragraph_format.depth = 2
    para1.paragraph_format.indent = 30

    # Holen Sie sich den zweiten Absatz im TextFrame und legen Sie dessen Indent fest
    para2 = tf.paragraphs[1]
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = chr(8226)
    para2.paragraph_format.alignment = slides.TextAlignment.LEFT
    para2.paragraph_format.depth = 2
    para2.paragraph_format.indent = 40

    # Holen Sie sich den dritten Absatz im TextFrame und legen Sie dessen Indent fest
    para3 = tf.paragraphs[2]
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.alignment = slides.TextAlignment.LEFT
    para3.paragraph_format.depth = 2
    para3.paragraph_format.indent = 50

    # Schreiben Sie die Präsentation auf die Festplatte
    pres.save("InOutDent_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hängende Einzüge für Absätze festlegen**

Dieser Python-Code zeigt Ihnen, wie Sie den hängenden Einzug für einen Absatz festlegen:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    auto_shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    para1 = slides.Paragraph()
    para1.text = "Beispiel"
    para2 = slides.Paragraph()
    para2.text = "Hängenden Einzug für Absatz festlegen"
    para3 = slides.Paragraph()
    para3.text = "Dieser C#-Code zeigt Ihnen, wie Sie den hängenden Einzug für einen Absatz festlegen:"

    para2.paragraph_format.margin_left = 10
    para3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(para1)
    paragraphs.add(para2)
    paragraphs.add(para3)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Endabsatzlaufformateigenschaften für Absätze verwalten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz zur Folie, die den Absatz enthält, über deren Position.
1. Fügen Sie der Folie eine Rechteck-[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) mit zwei Absätzen hinzu.
1. Setzen Sie die `FontHeight` und den Schriftarttyp für die Absätze.
1. Setzen Sie die Endeigenschaften für die Absätze.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie die Endeigenschaften für Absätze in PowerPoint festlegen:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	para1 = slides.Paragraph()
	para1.portions.add(slides.Portion("Beispieltext"))

	para2 = slides.Paragraph()
	para2.portions.add(slides.Portion("Beispieltext 2"))
	endParagraphPortionFormat = slides.PortionFormat()
	endParagraphPortionFormat.font_height = 48
	endParagraphPortionFormat.latin_font = slides.FontData("Times New Roman")
	para2.end_paragraph_portion_format = endParagraphPortionFormat

	shape.text_frame.paragraphs.add(para1)
	shape.text_frame.paragraphs.add(para2)

	pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **HTML-Text in Absätze importieren**

Aspose.Slides bietet verbesserte Unterstützung für den Import von HTML-Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folienreferenz zu.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie die `AutoShape` [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die Quell-HTML-Datei in einen TextReader.
7. Erstellen Sie die erste Absatzinstanz durch die [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) Klasse.
8. Fügen Sie den Inhalt der HTML-Datei, die Sie im TextReader gelesen haben, der [ParagraphCollection](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code ist eine Implementierung der Schritte zum Importieren von HTML-Text in Absätze:

```python
import aspose.slides as slides

# Erstellen Sie eine leere Präsentationsinstanz
with slides.Presentation() as pres:
    # Zugriff auf die standardmäßige erste Folie der Präsentation
    slide = pres.slides[0]

    # Hinzufügen der AutoShape, um den HTML-Inhalt aufzunehmen
    ashape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, pres.slide_size.size.width - 20, pres.slide_size.size.height - 10)

    ashape.fill_format.fill_type = slides.FillType.NO_FILL

    # Hinzufügen eines Textfeldes zur Form
    ashape.add_text_frame("")

    # Löschen aller Absätze im hinzugefügten Textfeld
    ashape.text_frame.paragraphs.clear()

    # Laden der HTML-Datei mit einem Stream-Reader
    with open(path + "file.html", "rt") as tr:
        # Hinzufügen des Textes aus dem HTML-Stream-Reader in das Textfeld
        ashape.text_frame.paragraphs.add_from_html(tr.read())

    # Speichern der Präsentation
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Text von Absätzen in HTML exportieren**

Aspose.Slides bietet verbesserte Unterstützung für den Export von Texten (die in Absätzen enthalten sind) zu HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die entsprechende Folienreferenz zu.
3. Greifen Sie auf die Form zu, die den Text enthält, der in HTML exportiert werden soll.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML-Datei hinzu.
6. Geben Sie einen Startindex für den StreamWriter an und exportieren Sie die gewünschten Absätze.

Dieser Python-Code zeigt Ihnen, wie Sie PowerPoint-Absatztexte in HTML exportieren können:

```python
import aspose.slides as slides

# Laden der Präsentationsdatei
with slides.Presentation(path + "ExportingHTMLText.pptx") as pres:
    # Zugriff auf die standardmäßige erste Folie der Präsentation
    slide = pres.slides[0]

    # Gewünschter Index
    index = 0

    # Zugriff auf die hinzugefügte Form
    ashape = slide.shapes[index]

    with open("output_out.html", "w") as sw:
        # Schreiben von Absatzdaten in HTML, indem der Startindex des Absatzes, die Anzahl der zu kopierenden Absätze angegeben wird
        sw.write(ashape.text_frame.paragraphs.export_to_html(0, ashape.text_frame.paragraphs.count, None))
```