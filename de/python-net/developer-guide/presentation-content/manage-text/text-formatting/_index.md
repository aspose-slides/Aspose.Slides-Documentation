---
title: PowerPoint-Text in Python formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/python-net/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeld-Anker
- Texttabulierung
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET formatieren und gestalten. Passen Sie Schriftarten, Farben, Ausrichtungen und mehr mit leistungsstarken Python-Codebeispielen an."
---

## **Text hervorheben**

Die `highlight_text`‑Methode in der [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-Klasse ermöglicht es Ihnen, einen Teil des Textes mit einer Hintergrundfarbe zu markieren, indem Sie eine Textprobe verwenden, ähnlich dem Tool „Text Highlight Color“ in PowerPoint 2019.

Das folgende Code‑Snippet zeigt, wie diese Funktion verwendet wird:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```


## **Text mithilfe regulärer Ausdrücke hervorheben**

Die `highlight_regex`‑Methode der [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-Klasse lässt Sie einen Textabschnitt mit einer Hintergrundfarbe hervorheben, indem Sie einen regulären Ausdruck verwenden, ähnlich dem Tool „Text Highlight Color“ in PowerPoint 2019.

Das folgende Code‑Snippet zeigt, wie diese Funktion verwendet wird:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **Text‑Hintergrundfarbe festlegen**

Aspose.Slides ermöglicht es Ihnen, Ihre bevorzugte Hintergrundfarbe für Text anzugeben. Der folgende Python‑Code zeigt, wie Sie die Hintergrundfarbe für den gesamten Text festlegen:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
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


Dieser Python‑Code zeigt, wie Sie die Hintergrundfarbe nur für einen Teil des Textes festlegen:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
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

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Red' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **Textabsätze ausrichten**

Textformatierung ist ein Schlüsselelement beim Erstellen von Dokumenten oder Präsentationen. Aspose.Slides for Python via .NET unterstützt das Hinzufügen von Text zu Folien; in diesem Abschnitt sehen wir, wie man die Absatzausrichtung in einer Folie steuert. Folgen Sie diesen Schritten, um Textabsätze mit Aspose.Slides for Python via .NET auszurichten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
3. Greifen Sie auf die Platzhalterformen der Folie zu und casten Sie sie zu [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).  
4. Aus dem von der [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) bereitgestellten [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) holen Sie sich den Absatz, der ausgerichtet werden soll.  
5. Richten Sie den Absatz aus. Ein Absatz kann `LEFT`, `RIGHT`, `CENTER`, `JUSTIFY`, `JUSTIFY_LOW` oder `DISTRIBUTED` ausgerichtet werden.  
6. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung dieser Schritte wird unten gezeigt.
```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
with slides.Presentation("ParagraphsAlignment.pptx") as presentation:
    # Zugriff auf die erste Folie
    slide = presentation.slides[0]

    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und Umwandlung in AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Ändern des Textes in beiden Platzhaltern
    tf1.text = "Center Align by Aspose"
    tf2.text = "Center Align by Aspose"

    # Abrufen des ersten Absatzes der Platzhalter
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Ausrichten des Textabsatzes zur Mitte
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # Schreiben der Präsentation als PPTX-Datei
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Transparenz für Text festlegen**

In diesem Abschnitt wird gezeigt, wie Sie die Transparenzeigenschaft für jede Textform mit Aspose.Slides for Python via .NET festlegen. Gehen Sie dazu wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich einen Verweis auf eine Folie.  
3. Setzen Sie die Schattenfarbe.  
4. Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung dieser Schritte finden Sie unten.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - transparency is: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # Transparenz auf null Prozent setzen
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Zeichenabstand für Text festlegen**

Aspose.Slides ermöglicht es Ihnen, den Abstand zwischen Buchstaben in einem Textfeld anzupassen. Dadurch können Sie die visuelle Dichte einer Zeile oder eines Textblocks steuern, indem Sie den Abstand zwischen den Zeichen vergrößern oder verkleinern.

Das folgende Python‑Beispiel zeigt, wie Sie den Abstand für eine Zeile Text vergrößern und für eine andere verkleinern:
```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # erweitern
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # verdichten

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **Absatz‑Schrifteigenschaften verwalten**

Präsentationen enthalten meist sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden – sei es, um bestimmte Abschnitte und Wörter hervorzuheben oder um Unternehmensrichtlinien zu entsprechen. Textformatierung hilft Benutzern, das Aussehen des Präsentationsinhalts zu ändern.

In diesem Abschnitt wird gezeigt, wie Sie mit Aspose.Slides for Python via .NET die Schliffeigenschaften von Absätzen im Folientext konfigurieren. So verwalten Sie die Schrifteigenschaften eines Absatzes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
3. Greifen Sie auf die Platzhalterformen der Folie zu und casten Sie sie zu [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).  
4. Holen Sie den Absatz aus dem von der [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) bereitgestellten [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).  
5. Richten Sie den Absatz aus.  
6. Greifen Sie auf den Text‑Portion des Absatzes zu.  
7. Definieren Sie die Schrift über [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) und setzen Sie die Schrift der Portion entsprechend.  
   1. Setzen Sie die Schrift auf fett.  
   2. Setzen Sie die Schrift auf kursiv.  
8. Setzen Sie die Schriftfarbe über das [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), das vom [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)-Objekt bereitgestellt wird.  
9. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird unten gezeigt. Sie nimmt eine einfache Präsentation und wendet Schriftformatierung auf eine der Folien an.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
with slides.Presentation("FontProperties.pptx") as pres:
    # Zugriff auf eine Folie anhand ihrer Position
    slide = pres.slides[0]

    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Zugriff auf den ersten Absatz
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Zugriff auf die erste Portion
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # Definieren neuer Schriftarten
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # Zuweisen neuer Schriftarten zur Portion
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # Schrift auf Fett setzen
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # Schrift auf Kursiv setzen
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # Schriftfarbe festlegen
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    #Write die PPTX auf die Festplatte
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Schriftfamilie des Textes verwalten**

[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)-Objekte werden verwendet, um Text mit ähnlichem Formatstil innerhalb eines Absatzes zu halten. Dieser Abschnitt zeigt, wie Sie mit Aspose.Slides for Python ein Textfeld erstellen, Text hinzufügen und dann eine bestimmte Schrift sowie weitere Schriftfamilien‑Eigenschaften festlegen.

So erstellen Sie ein Textfeld und setzen die Schrift‑Eigenschaften des darin enthaltenen Textes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vom Typ `RECTANGLE` hinzu.  
4. Entfernen Sie den Füllstil, der mit der [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) verbunden ist.  
5. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der AutoShape zu.  
6. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) Text hinzu.  
7. Greifen Sie auf das [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)-Objekt zu, das mit dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) verknüpft ist.  
8. Definieren Sie die für das [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)-Objekt zu verwendende Schrift.  
9. Setzen Sie weitere Schrift‑Eigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe über die entsprechenden Eigenschaften des [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)-Objekts.  
10. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung dieser Schritte wird unten gezeigt.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Präsentation instanziieren
with slides.Presentation() as presentation:
    # Erste Folie holen
    sld = presentation.slides[0]

    # AutoShape vom Typ Rechteck hinzufügen
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # Fill‑Stil des AutoShape entfernen
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Auf das mit dem AutoShape verbundene TextFrame zugreifen
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # Auf die mit dem TextFrame verbundene Portion zugreifen
    port = tf.paragraphs[0].portions[0]

    # Schriftart für die Portion festlegen
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # Fett‑Eigenschaft der Schrift festlegen
    port.portion_format.font_bold = 1

    # Kursiv‑Eigenschaft der Schrift festlegen
    port.portion_format.font_italic = 1

    # Unterstreichungs‑Eigenschaft der Schrift festlegen
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # Höhe der Schrift festlegen
    port.portion_format.font_height = 25

    # Farbe der Schrift festlegen
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # PPTX auf die Festplatte schreiben 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Schriftgröße für Text festlegen**

Aspose.Slides erlaubt es Ihnen, die bevorzugte Schriftgröße für vorhandenen Text in einem Absatz sowie für künftig hinzugefügten Text festzulegen.

Das folgende Python‑Beispiel demonstriert, wie Sie die Schriftgröße für Text in einem Absatz setzen:
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # Holt das erste Shape, zum Beispiel.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # Holt den ersten Absatz, zum Beispiel.
        paragraph = shape.text_frame.paragraphs[0]

        # Setzt die Standardschriftgröße auf 20 pt für alle Textanteile im Absatz. 
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # Setzt die Schriftgröße auf 20 pt für die aktuellen Textanteile im Absatz. 
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **Text rotieren**

Aspose.Slides for Python via .NET ermöglicht es Entwicklern, Text zu drehen. Text kann als `HORIZONTAL`, `VERTICAL`, `VERTICAL270`, `WORD_ART_VERTICAL`, `EAST_ASIAN_VERTICAL`, `MONGOLIAN_VERTICAL` oder `WORD_ART_VERTICAL_RIGHT_TO_LEFT` dargestellt werden.

Um den Text in einem beliebigen [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) zu rotieren, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie der Folie eine Form hinzu.  
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) zu.  
5. Wenden Sie die gewünschte Textrotation an.  
6. Speichern Sie die Datei auf dem Datenträger.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstelle eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    # Hole die erste Folie 
    slide = presentation.slides[0]

    # Füge eine AutoShape vom Typ Rechteck hinzu
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Füge dem Rechteck ein TextFrame hinzu
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Zugriff auf das TextFrame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Erstelle das Paragraph-Objekt für das TextFrame
    para = txtFrame.paragraphs[0]

    # Erstelle ein Portion-Objekt für den Absatz
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Präsentation speichern
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Benutzerdefinierten Rotationswinkel für ein TextFrame festlegen**

Aspose.Slides for Python via .NET unterstützt das Festlegen eines benutzerdefinierten Rotationswinkels für ein [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). In diesem Abschnitt zeigen wir, wie Sie die Eigenschaft `rotation_angle` in Aspose.Slides verwenden.

Um die Eigenschaft `rotation_angle` zu setzen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Fügen Sie der Folie ein Diagramm hinzu.  
3. Setzen Sie die Eigenschaft `rotation_angle`.  
4. Speichern Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel setzen wir die Eigenschaft `rotation_angle`.
```py
import aspose.slides as slides

# Instanz der Presentation-Klasse erstellen
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Custom title").text_frame_format.rotation_angle = -30

    # Präsentation speichern
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides stellt die Eigenschaften `space_after`, `space_before` und `space_within` in der [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)-Klasse bereit, um den Zeilenabstand eines Absatzes zu steuern. Diese Eigenschaften funktionieren wie folgt:

* Um den Zeilenabstand als Prozentsatz anzugeben, verwenden Sie einen positiven Wert.  
* Um den Zeilenabstand in Punkten anzugeben, verwenden Sie einen negativen Wert.

Beispiel: Um einen Zeilenabstand von 16 pt vor einem Absatz zu setzen, setzen Sie die Eigenschaft `space_before` auf `-16`.

So legen Sie den Zeilenabstand für einen bestimmten Absatz fest:

1. Laden Sie eine Präsentation, die eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit Text enthält.  
2. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.  
3. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) zu.  
4. Greifen Sie auf den [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) zu.  
5. Setzen Sie die gewünschten Absatz‑Eigenschaften.  
6. Speichern Sie die Präsentation.

Das folgende Python‑Beispiel demonstriert, wie der Zeilenabstand für einen Absatz gesetzt wird:
```py
import aspose.slides as slides

# Instanz der Presentation-Klasse erstellen
with slides.Presentation("Fonts.pptx") as presentation:

    # Referenz einer Folie anhand ihres Index erhalten
    sld = presentation.slides[0]

    # Auf das TextFrame zugreifen
    tf1 = sld.shapes[0].text_frame

    # Auf den Absatz zugreifen
    para1 = tf1.paragraphs[0]

    # Eigenschaften des Absatzes festlegen
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # Präsentation speichern
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **AutofitType‑Eigenschaft für TextFrame festlegen**

In diesem Abschnitt untersuchen wir verschiedene Formatierungseigenschaften eines [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), einschließlich des Setzens von `autofit_type`, Anpassen des Textankers und Drehen von Text in einer Präsentation.

Aspose.Slides for Python via .NET ermöglicht es Entwicklern, die Eigenschaft `autofit_type` eines beliebigen [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) festzulegen. `autofit_type` kann entweder `NORMAL` oder `SHAPE` sein:

* Bei `NORMAL` bleibt die Form unverändert, während der Text angepasst wird, damit er hineinpasst.  
* Bei `SHAPE` wird die Form so skaliert, dass nur der benötigte Text enthalten ist.

So setzen Sie die Eigenschaft `autofit_type` eines [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/):

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie der Folie eine Form hinzu.  
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) zu.  
5. Setzen Sie `autofit_type` für das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).  
6. Speichern Sie die Datei auf dem Datenträger.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanz der Presentation-Klasse erstellen
with slides.Presentation() as presentation:

    # Auf die erste Folie zugreifen 
    slide = presentation.slides[0]

    # AutoShape vom Typ Rechteck hinzufügen
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # TextFrame zum Rechteck hinzufügen
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Zugriff auf das TextFrame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Paragraph-Objekt für das TextFrame erstellen
    para = txtFrame.paragraphs[0]

    # Portion-Objekt für den Absatz erstellen
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Präsentation speichern
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **Anker eines TextFrame festlegen**

Aspose.Slides for Python via .NET ermöglicht es Entwicklern, die Ankerposition eines beliebigen [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) festzulegen. Die Eigenschaft [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) bestimmt, wo der Text innerhalb der Form platziert wird. Sie kann auf `TOP`, `CENTER`, `BOTTOM`, `JUSTIFIED` oder `DISTRIBUTED` gesetzt werden.

So legen Sie den Anker eines [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) fest:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie der Folie eine Form hinzu.  
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) zu.  
5. Setzen Sie das [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) für das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).  
6. Speichern Sie die Datei auf dem Datenträger.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanz der Presentation-Klasse erstellen
with slides.Presentation() as presentation:
    # Erste Folie holen 
    slide = presentation.slides[0]

    # AutoShape vom Typ Rechteck hinzufügen
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # TextFrame zum Rechteck hinzufügen
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Zugriff auf das TextFrame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # Paragraph-Objekt für das TextFrame erstellen
    para = txtFrame.paragraphs[0]

    # Portion-Objekt für den Absatz erstellen
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Präsentation speichern
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Standard‑Textstil festlegen**

Wenn Sie denselben Standard‑Textformatierungsstil auf alle Textelemente einer Präsentation anwenden möchten, können Sie die Eigenschaft `default_text_style` der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse verwenden und das gewünschte Format festlegen.

Das folgende Beispiel demonstriert, wie Sie die Standardschrift auf fett und Größe 14 pt für allen Text in jeder Folie einer neuen Präsentation setzen.
```py
with slides.Presentation() as presentation:
    # Hole das Absatzformat der obersten Ebene.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```


## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint bewirkt der Schrift­effekt **All Caps**, dass Text in Großbuchstaben angezeigt wird, obwohl er ursprünglich in Kleinbuchstaben eingegeben wurde. Beim Abrufen eines solchen Textabschnitts mit Aspose.Slides liefert die Bibliothek den ursprünglich eingegebenen Text. Um dies zu handhaben, prüfen Sie [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) – wenn er `ALL` anzeigt, konvertieren Sie die zurückgegebene Zeichenkette einfach in Großbuchstaben, sodass Ihre Ausgabe mit dem übereinstimmt, was im Folien‑Layout zu sehen ist.

Angenommen, wir haben das folgende Textfeld auf der ersten Folie der Datei sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Der nachfolgende Code‑Abschnitt zeigt, wie Sie den Text mit dem **All Caps**‑Effekt extrahieren:
```py
with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```


Ausgabe:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


{{% alert color="primary" %}}
Aspose bietet einen einfachen, [kostenlosen Online‑PowerPoint‑Bearbeitungsservice](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **FAQ**

**Kann ich unterschiedliche Formatierungen auf bestimmte Teile eines Textes innerhalb eines einzelnen Absatzes anwenden (z. B. nur ein paar Wörter fett) und wie wirkt sich das auf von Layouts und Themes geerbte Stile aus?**

Ja. Die Formatierung wird auf Ebene der „Text‑Portion“ innerhalb eines Absatzes gesetzt und überschreibt den Theme‑/Layout‑Stil nur für die ausgewählten Fragmente. Wenn das Theme geändert wird, aktualisieren sich nur die Bereiche ohne explizite lokale Formatierung.

**Wie funktionieren Schriften unter Linux und in Docker‑Containern, in denen keine Systemschriften installiert sind?**

Die Bibliothek verwendet Schrifterkennung/-substitution. Auf Systemen ohne Schriften sollten Sie explizit auf Schriftordner verweisen [/slides/python-net/custom-font/] und/oder eine Substitutionstabelle konfigurieren [/slides/python-net/font-substitution/], um ein Zurückfallen auf ungeeignete Schriftarten und Layout‑Verschiebungen zu vermeiden.

**Wie unterscheidet sich die Textformatierung in Platzhaltern von der in regulären AutoShapes?**

Platzhalter erben Stildefinitionen stärker vom Folienmaster und Layout als reguläre AutoShapes. Lokale Änderungen in Platzhaltern sind möglich, aber bei Layout‑Änderungen werden sie eher wieder auf Theme‑Stile zurückgesetzt, sofern Sie die Formatierung nicht explizit auf Ebene der Text‑Portion überschrieben haben.