---
title: Schriftarten in Präsentationen mit Python via Java verwalten
linktitle: Schriftarten verwalten
type: docs
weight: 10
url: /de/python-java/manage-fonts/
keywords:
- Schriftarten verwalten
- Schriftart-Eigenschaften
- Absatz
- Textformatierung
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Steuern Sie Schriftarten in Python via Java mit Aspose.Slides: betten Sie benutzerdefinierte Schriftarten ein, ersetzen Sie sie und laden Sie sie, um PPT-, PPTX- und ODP-Präsentationen klar, markenkonform und konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Schriftarteigenschaften im Präsentationstext direkt aus Ihrem Code zu verwalten. Sie können über Formen, Textfelder, Absätze und Portionen auf den Text in Folien zugreifen und anschließend die Formatierung auf den ausgewählten Text anwenden.

Dieser Artikel erklärt, wie Sie schriftbezogene Eigenschaften für vorhandenen Text in einer Präsentation konfigurieren, einschließlich Schriftfamilie, Fett‑ und Kursivstil, Absatzausrichtung und Schriftfarbe. Außerdem wird gezeigt, wie Sie ein Textfeld erstellen, Text hinzufügen und Schriftarteneigenschaften wie Schriftfamilie, Fett, Kursiv, Unterstreichen, Schriftgröße und Farbe festlegen, bevor Sie das Ergebnis als PPTX-Datei speichern.

## **Schriftbezogene Eigenschaften verwalten**
{{% alert color="info" title="Note" %}} 

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, entweder um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensrichtlinien zu entsprechen. Die Textformatierung hilft Benutzern, das Aussehen und die Wirkung des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie Sie Aspose.Slides für Python via Java verwenden, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren.

{{% /alert %}} 

Um Schriftarteigenschaften eines Absatzes mit Aspose.Slides für Python via Java zu verwalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie, indem Sie deren Index verwenden.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholder/)-Formen in der Folie als [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) zu.
1. Rufen Sie das [Paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/) aus dem von [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) bereitgestellten [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) ab.
1. Richten Sie den Absatz aus.
1. Greifen Sie auf den Text‑[Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/) eines [Paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/) zu.
1. Definieren Sie die Schriftart mit [FontData](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontdata/) und setzen Sie die **Font** des Text‑[Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/) entsprechend.
   1. Setzen Sie die Schriftart auf Fett.
   1. Setzen Sie die Schriftart auf Kursiv.
1. Setzen Sie die Schriftfarbe mit dem von dem [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/)‑Objekt bereitgestellten [FillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/).
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten dargestellt. Sie nimmt eine unveränderte Präsentation und formatiert die Schriften auf einer der Folien. Die folgenden Screenshots zeigen die Eingabedatei und wie die Code‑Snippets sie verändern. Der Code ändert die Schrift, die Farbe und den Schriftstil.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Abbildung: Der Text in der Eingabedatei**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Abbildung: Derselbe Text mit aktualisierter Formatierung**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Präsentation laden.
presentation = Presentation("FontProperties.pptx")
try:
    # Greifen Sie auf die erste Folie und die Textfelder ihrer ersten beiden Platzhalter zu.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Greifen Sie auf den ersten Absatz in jedem Textfeld zu.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Greifen Sie auf den ersten Abschnitt in jedem Absatz zu.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Definieren und zuweisen neuer Schriftarten.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Schriftarten fett und kursiv setzen.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Schriftfarben setzen.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Präsentation speichern.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Text‑Schriftart‑Eigenschaften festlegen**
{{% alert color="info" title="Note" %}} 

Wie im Abschnitt **Schriftbezogene Eigenschaften verwalten** erklärt, wird ein [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/) verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie Sie Aspose.Slides für Python via Java verwenden, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene weitere Schriftarteigenschaften zu definieren.

{{% /alert %}} 

Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) vom Typ **Rectangle** hinzu.
1. Entfernen Sie den Füllstil, der mit dem [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) verknüpft ist.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) zu.
1. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) etwas Text hinzu.
1. Greifen Sie auf das mit dem [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) verbundene [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/)-Objekt zu.
1. Definieren Sie die für das [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/) zu verwendende Schriftart.
1. Setzen Sie weitere Schriftarteigenschaften wie Fett, Kursiv, Unterstreichen, Farbe und Größe mithilfe der entsprechenden Eigenschaften, die vom [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/)-Objekt bereitgestellt werden.
1. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten dargestellt.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen von Aspose.Slides für Python via Java eingestellten Schriftarteigenschaften**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Die erste Folie holen und ein Rechteck hinzufügen.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Die Füllung der Form entfernen.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Text zum Textfeld der Form hinzufügen.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Schriftfamilie festlegen.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Fett, kursiv, unterstreichen und Schriftgröße festlegen.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Schriftfarbe festlegen.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Präsentation speichern.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```