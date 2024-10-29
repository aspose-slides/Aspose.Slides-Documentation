---
title: Textformatierung
type: docs
weight: 50
url: /de/python-net/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Textabsätze ausrichten
- Texttransparenz
- Absatzeigenschaften für Schriftarten
- Schriftfamilie
- Textrrotation
- benutzerdefinierte Winkelrotation
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeldanker
- Texttabulation
- Standardtextstil
- Python
- Aspose.Slides für Python
description: "Verwalten und Manipulieren von Text- und Textfeld-Eigenschaften in Python"
---

## **Text Hervorheben**
Die neue Methode HighlightText wurde zur ITextFrame-Schnittstelle und zur TextFrame-Klasse hinzugefügt.

Sie ermöglicht es, einen Textteil mit einer Hintergrundfarbe zu markieren, ähnlich wie das Text Highlight Color-Tool in PowerPoint 2019.

Der folgende Codeausschnitt zeigt, wie man diese Funktion verwendet:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Aspose bietet einen einfachen, [kostenlosen Online-PowerPoint-Bearbeitungsdienst](https://products.aspose.app/slides/editor).

{{% /alert %}} 


## **Text Hervorheben mit regulärem Ausdruck**
Die neue Methode HighlightRegex wurde zur ITextFrame-Schnittstelle und zur TextFrame-Klasse hinzugefügt.

Sie ermöglicht es, einen Textteil mit einer Hintergrundfarbe zu markieren, indem ein regulärer Ausdruck verwendet wird, ähnlich wie das Text Highlight Color-Tool in PowerPoint 2019.

Der folgende Codeausschnitt zeigt, wie man diese Funktion verwendet:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **Text Hintergrundfarbe Festlegen**

Aspose.Slides ermöglicht es Ihnen, eine bevorzugte Farbe für den Hintergrund eines Textes anzugeben.

Dieser Python-Code zeigt Ihnen, wie Sie die Hintergrundfarbe für einen gesamten Text festlegen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Schwarz")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Rot ")
    
    portion3 = slides.Portion("Schwarz")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        portion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```

Dieser Python-Code zeigt Ihnen, wie Sie die Hintergrundfarbe nur für einen Teil eines Textes festlegen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Schwarz")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Rot ")
    
    portion3 = slides.Portion("Schwarz")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        print (portion.text)

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Rot' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **Textabsätze Ausrichten**
Die Textformatierung ist eines der Schlüsselelemente bei der Erstellung jeglicher Art von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für Python über .NET die Möglichkeit unterstützt, Texte in Folien hinzuzufügen. In diesem Thema werden wir sehen, wie wir die Ausrichtung der Textabsätze in einer Folie steuern können. Bitte folgen Sie den folgenden Schritten, um Textabsätze mit Aspose.Slides für Python über .NET auszurichten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erhalten Sie die Referenz zu einer Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die Platzhalterformen in der Folie zu und nutzen Sie sie als AutoShape.
4. Holen Sie sich den Absatz (der ausgerichtet werden soll) aus dem TextFrame, das von AutoShape bereitgestellt wird.
5. Richten Sie den Absatz aus. Ein Absatz kann rechts, links, zentriert oder gerechtfertigt werden.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```py
import aspose.slides as slides

# Erstellen Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
with slides.Presentation(path + "ParagraphsAlignment.pptx") as presentation:
    # Zugriff auf die erste Folie
    slide = presentation.slides[0]

    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und Casting als AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Ändern Sie den Text in beiden Platzhaltern
    tf1.text = "Zentrieren mit Aspose"
    tf2.text = "Zentrieren mit Aspose"

    # Erhalten Sie den ersten Absatz der Platzhalter
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Richten Sie den Textabsatz zentriert aus
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # Schreiben Sie die Präsentation als PPTX-Datei
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Transparenz für Text Festlegen**
Dieser Artikel zeigt, wie man die Transparenzeigenschaft für jede Textform mit Aspose.Slides für Python über .NET festlegt. Um die Transparenz für Text festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Referenz zu einer Folie.
3. Setzen Sie die Schattenfarbe.
4. Schreiben Sie die Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - Transparenz beträgt: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # Setzen Sie die Transparenz auf null Prozent
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Zeichenabstand für Text Festlegen**

Aspose.Slides ermöglicht es Ihnen, den Abstand zwischen Buchstaben in einem Textfeld festzulegen. Auf diese Weise können Sie die visuelle Dichte einer Zeile oder eines Blocks von Text anpassen, indem Sie den Abstand zwischen den Zeichen erweitern oder verringern.

Dieser Python-Code zeigt Ihnen, wie Sie den Abstand für eine Zeile Text erweitern und den Abstand für eine andere Zeile verringern: 

```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # erweitern
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # verringern

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **Schriftart-Eigenschaften von Absätzen Verwalten**
Präsentationen enthalten normalerweise sowohl Texte als auch Bilder. Der Text kann auf verschiedene Arten formatiert werden, entweder um bestimmte Abschnitte und Wörter zu markieren oder um den Unternehmensstilen zu entsprechen. Die Textformatierung hilft den Benutzern, das Erscheinungsbild der Präsentationsinhalte zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides für Python über .NET verwendet, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren. Um die Schriftarteigenschaften eines Absatzes mit Aspose.Slides für Python über .NET zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz zu einer Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die Platzhalterformen in der Folie zu und nutzen Sie sie als AutoShape.
1. Holen Sie sich den Absatz aus dem TextFrame, das von AutoShape bereitgestellt wird.
1. Rechtfertigen Sie den Absatz.
1. Greifen Sie auf den Textanteil eines Absatzes zu.
1. Definieren Sie die Schriftart mit FontData und setzen Sie die Schriftart des Textanteils entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   1. Setzen Sie die Schriftart auf kursiv.
1. Setzen Sie die Schriftfarbe mithilfe des FillFormat, das vom Portion-Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben. Sie nimmt eine unformatierte Präsentation und formatiert die Schriftarten auf einer der Folien.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
with slides.Presentation(path + "FontProperties.pptx") as pres:
    # Zugriff auf eine Folie mithilfe ihrer Folienposition
    slide = pres.slides[0]

    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und zu AutoShape konvertieren
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Zugriff auf den ersten Absatz
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Zugriff auf den ersten Anteil
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # Definieren Sie neue Schriftarten
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # Weisen Sie den Anteile neue Schriftarten zu
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # Setzen der Schriftart auf fett
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # Setzen der Schriftart auf kursiv
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # Setzen der Schriftfarbe
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    # Schreiben Sie die PPTX auf die Festplatte
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Schriftfamilie von Text Verwalten**
Ein Portion wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie man Aspose.Slides für Python verwendet, um ein Textfeld mit einem bestimmten Text zu erstellen und dann eine bestimmte Schriftart sowie andere Eigenschaften der Schriftfamilienkategorie zu definieren. Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erhalten Sie die Referenz zu einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
4. Entfernen Sie den mit der AutoShape verbundenen Füllstil.
5. Greifen Sie auf das TextFrame der AutoShape zu.
6. Fügen Sie dem TextFrame einen Text hinzu.
7. Greifen Sie auf das Portion-Objekt zu, das mit dem TextFrame verknüpft ist.
8. Definieren Sie die zu verwendende Schriftart für das Portion.
9. Setzen Sie andere Schriftarteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe unter Verwendung der relevanten Eigenschaften, die vom Portion-Objekt bereitgestellt werden.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen Sie eine Präsentation
with slides.Presentation() as presentation:
    # Holen Sie sich die erste Folie
    sld = presentation.slides[0]

    # Fügen Sie eine AutoShape des Typs Rechteck hinzu
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # Entfernen Sie den mit der AutoShape verbundenen Füllstil
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Greifen Sie auf das mit der AutoShape verbundene TextFrame zu
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # Greifen Sie auf den mit dem TextFrame verbundenen Anteil zu
    port = tf.paragraphs[0].portions[0]

    # Setzen Sie die Schriftart für den Anteil
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # Setzen Sie die Fett-Eigenschaft der Schriftart
    port.portion_format.font_bold = 1

    # Setzen Sie die Kursiv-Eigenschaft der Schriftart
    port.portion_format.font_italic = 1

    # Setzen Sie die Unterstrich-Eigenschaft der Schriftart
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # Setzen Sie die Höhe der Schriftart
    port.portion_format.font_height = 25

    # Setzen Sie die Farbe der Schriftart
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Schreiben Sie die PPTX auf die Festplatte 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Schriftgröße für Text Festlegen**

Aspose.Slides ermöglicht es Ihnen, Ihre bevorzugte Schriftgröße für vorhandenen Text in einem Absatz auszuwählen und andere Texte, die später zu dem Absatz hinzugefügt werden können.

Dieser Python-Code zeigt Ihnen, wie Sie die Schriftgröße für Texte in einem Absatz festlegen: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # Erhalten Sie die erste Form, zum Beispiel.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # Erhalten Sie den ersten Absatz, zum Beispiel.
        paragraph = shape.text_frame.paragraphs[0]

        # Setzen Sie die Standard-Schriftgröße auf 20 pt für alle Textanteile im Absatz. 
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # Setzen Sie die Schriftgröße auf 20 pt für die aktuellen Textanteile im Absatz. 
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **Textrotation Festlegen**
Aspose.Slides für Python über .NET ermöglicht Entwicklern, den Text zu drehen. Der Text kann horizontal, vertikal, vertikal 270, WordArt vertikal, ostasiatisch vertikal, mongolisch vertikal oder WordArt vertikal von rechts nach links angezeigt werden. Um den Text eines TextFrames zu drehen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Form hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Drehen Sie den Text.
6. Speichern Sie die Datei auf der Festplatte.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen Sie eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    # Holen Sie sich die erste Folie 
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape des Typs Rechteck hinzu
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Fügen Sie TextFrame zur Rechteck hinzu
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Zugriff auf das Textfeld
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Erstellen Sie das Absatzobjekt für das Textfeld
    para = txtFrame.paragraphs[0]

    # Erstellen Sie das Portion-Objekt für den Absatz
    portion = para.portions[0]
    portion.text = "Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Speichern der Präsentation
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Benutzerdefinierte Rotationswinkel für TextFrame Festlegen**
Aspose.Slides für Python über .NET unterstützt jetzt das Festlegen eines benutzerdefinierten Rotationswinkels für das Textfeld. In diesem Thema werden wir anhand eines Beispiels sehen, wie wir die Eigenschaft RotationAngle in Aspose.Slides festlegen. Die neue Eigenschaft RotationAngle wurde zu den IChartTextBlockFormat- und ITextFrameFormat-Schnittstellen hinzugefügt und ermöglicht es, den benutzerdefinierten Rotationswinkel für das Textfeld festzulegen. Um die Eigenschaft RotationAngle festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Fügen Sie ein Diagramm zu einer Folie hinzu.
3. Setzen Sie die RotationAngle-Eigenschaft.
4. Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel setzen wir die RotationAngle-Eigenschaft.

```py
import aspose.slides as slides

# Erstellen Sie eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Benutzerdefinierter Titel").text_frame_format.rotation_angle = -30

    # Speichern der Präsentation
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Zeilenabstand des Absatzes**
Aspose.Slides bietet Eigenschaften unter `paragraph_format`—`space_after`, `space_before` und `space_within`—die es ermöglichen, den Zeilenabstand für einen Absatz zu verwalten. Diese drei Eigenschaften werden folgendermaßen verwendet:

* Um den Zeilenabstand für einen Absatz in Prozent anzugeben, verwenden Sie einen positiven Wert. 
* Um den Zeilenabstand für einen Absatz in Punkten anzugeben, verwenden Sie einen negativen Wert.

Zum Beispiel können Sie einen Zeilenabstand von 16pt für einen Absatz festlegen, indem Sie die Eigenschaft `space_before` auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Absatz an:

1. Laden Sie eine Präsentation, die eine AutoShape mit etwas Text enthält.
2. Erhalten Sie die Referenz zu einer Folie durch ihren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Absatz zu.
5. Setzen Sie die Absatz-Eigenschaften.
6. Speichern Sie die Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie den Zeilenabstand für einen Absatz festlegen:

```py
import aspose.slides as slides

# Erstellen Sie eine Instanz der Presentation-Klasse
with slides.Presentation(path + "Fonts.pptx") as presentation:

    # Holen Sie sich die Referenz zu einer Folie anhand ihres Index
    sld = presentation.slides[0]

    # Greifen Sie auf das TextFrame zu
    tf1 = sld.shapes[0].text_frame

    # Greifen Sie auf den Absatz zu
    para1 = tf1.paragraphs[0]

    # Setzen Sie die Eigenschaften des Absatzes
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # Präsentation speichern
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Die AutofitType-Eigenschaft für das TextFrame Festlegen**
In diesem Thema werden wir die verschiedenen Formatierungseigenschaften des Textfelds untersuchen. Dieser Artikel behandelt, wie man die AutofitType-Eigenschaft des Textfelds, den Anker des Textes und das Drehen des Textes in der Präsentation festlegt. Aspose.Slides für Python über .NET ermöglicht Entwicklern, die AutofitType-Eigenschaft eines beliebigen Textfelds festzulegen. AutofitType könnte auf Normal oder Shape gesetzt werden. Wenn es auf Normal gesetzt ist, bleibt die Form gleich, während der Text angepasst wird, ohne dass die Form selbst geändert wird. Wenn jedoch die AutofitType auf Shape gesetzt wird, wird die Form so geändert, dass nur der erforderliche Text darin enthalten ist. Um die AutofitType-Eigenschaft eines Textfelds festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Form hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Setzen Sie den AutofitType des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen Sie eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:

    # Zugriff auf die erste Folie 
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape des Typs Rechteck hinzu
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Fügen Sie TextFrame zur Rechteck hinzu
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Zugriff auf das Textfeld
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Erstellen Sie das Absatzobjekt für das Textfeld
    para = txtFrame.paragraphs[0]

    # Erstellen Sie das Portion-Objekt für den Absatz
    portion = para.portions[0]
    portion.text = "Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Präsentation speichern
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **Den Anker des TextFrames Festlegen**
Aspose.Slides für Python über .NET ermöglicht Entwicklern, den Anker eines beliebigen TextFrames festzulegen. TextAnchorType gibt an, wo der Text in der Form platziert ist. TextAnchorType kann auf Top, Center, Bottom, Justified oder Distributed gesetzt werden. Um den Anker eines beliebigen TextFrames festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Form hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Setzen Sie den TextAnchorType des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen Sie eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    # Holen Sie sich die erste Folie 
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape des Typs Rechteck hinzu
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Fügen Sie TextFrame zur Rechteck hinzu
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Zugriff auf das Textfeld
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # Erstellen Sie das Absatzobjekt für das Textfeld
    para = txtFrame.paragraphs[0]

    # Erstellen Sie das Portion-Objekt für den Absatz
    portion = para.portions[0]
    portion.text = "Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Präsentation speichern
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Texttabulation Festlegen**
- EffectiveTabs.ExplicitTabCount (2 in unserem Fall) ist gleich Tabs.Count.
- Die EffectiveTabs-Sammlung umfasst alle Tabs (aus der Tabs-Sammlung und Standard-Tabs).
- EffectiveTabs.ExplicitTabCount (2 in unserem Fall) ist gleich Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) gibt den Abstand zwischen Standard-Tabs an (in unserem Beispiel 3 und 4).
- EffectiveTabs.GetTabByIndex(index) mit index = 0 gibt den ersten expliziten Tab zurück (Position = 731), index = 1 - den zweiten Tab (Position = 1241). Wenn Sie versuchen, den nächsten Tab mit index = 2 abzurufen, wird der erste Standard-Tab (Position = 1470) zurückgegeben und so weiter.
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um die nächste Tabulation nach einem bestimmten Text zu erhalten. Zum Beispiel haben Sie den Text: "Helloworld!". Um einen solchen Text darzustellen, sollten Sie wissen, wo Sie mit dem Zeichnen von "world!" beginnen müssen. Zuerst sollten Sie die Länge von "Hello" in Pixeln berechnen und GetTabAfterPosition mit diesem Wert aufrufen. Sie erhalten die nächste Tabulatorposition, um "world!" zu zeichnen.


## **Standardtextstil Festlegen**

Wenn Sie dieselbe Standardtextformatierung auf alle Textelemente einer Präsentation gleichzeitig anwenden möchten, können Sie die `default_text_style`-Eigenschaft der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse verwenden und die bevorzugte Formatierung festlegen. Das folgende Codebeispiel zeigt, wie man die standardmäßige fette Schriftart (14 pt) für den Text auf allen Folien einer neuen Präsentation festlegt.

```py
with slides.Presentation() as presentation:
    # Erhalten Sie das oberste Absatzformat.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```