---
title: Verwalten von Aufzählungs- und nummerierten Listen in Präsentationen mit Python
linktitle: Listen verwalten
type: docs
weight: 70
url: /de/python-net/manage-bullet-and-numbered-lists/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- nummerierte Liste
- Symbol-Aufzählungszeichen
- Bild-Aufzählungszeichen
- benutzerdefiniertes Aufzählungszeichen
- mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs- und nummerierte Listen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET verwalten können. Schritt‑für‑Schritt‑Anleitung mit Codebeispielen, die Ihnen den schnellen Einstieg erleichtern."
---

## **Übersicht**

Das effektive Verwalten von Aufzählungs- und Nummerierungslisten ist wichtig, wenn eindrucksvolle Präsentationen erstellt werden. Mit Aspose.Slides für Python können Sie die Listformatierung in Ihren Folien programmgesteuert leicht automatisieren. Dieser Artikel führt Sie anhand klarer Beispiele, wie Sie Aufzählungs- und Nummerierungslisten mit Python erstellen, ändern und anpassen. Entdecken Sie einfache, aber leistungsstarke Methoden, um Einrückungen, Stile, Nummerierungsschemata und Aufzählungszeichen zu steuern, damit Ihre Präsentationen jedes Mal professionell und konsistent aussehen.

**Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen zu strukturieren und klar zu präsentieren, wodurch die Lesbarkeit und das Engagement verbessert werden. In der Regel erfüllt eine Aufzählungs‑Liste drei Hauptzwecke:

- Hebt wichtige Informationen hervor und erfasst sofort die Aufmerksamkeit.
- Ermöglicht es den Lesern, schnell zu überfliegen und die Hauptpunkte zu erkennen.
- Kommuniziert wesentliche Details effizient in einem knappen Format.

**Warum nummerierte Listen verwenden?**

Nummerierte Listen sind ein weiteres wertvolles Werkzeug, um Inhalte klar zu strukturieren und zu präsentieren. Sie sind besonders nützlich, wenn die Reihenfolge oder Hierarchie der Elemente wichtig ist. Verwenden Sie nummerierte Listen anstelle von Aufzählungszeichen, wenn die Schritte oder Elemente einer bestimmten Reihenfolge folgen müssen (z. B. *Schritt 1, Schritt 2, Schritt 3,* usw.) oder wenn Sie später im Text auf bestimmte Schritte verweisen müssen (z. B. *verweisen Sie auf Schritt 3*). Dadurch werden Ihre Anweisungen oder Erklärungen klarer, leichter zu folgen und stellen sicher, dass die Leser Ihren Inhalt einfach navigieren und referenzieren können.

## **Symbol‑Aufzählungszeichen erstellen**

Um eine Aufzählungsliste zu erstellen, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)‑Objekt auf die Folie (in die Sie die Aufzählungsliste einfügen möchten) aus der Folien‑Sammlung zu.
1. Fügen Sie dem ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im Textfeld.
1. Erstellen Sie den ersten Absatz mit der Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Setzen Sie den Aufzählungs‑Typ auf `SYMBOL` und definieren Sie das Aufzählungszeichen.
1. Setzen Sie den Absatztext.
1. Stellen Sie den Absatz‑Einzug ein, um die Platzierung des Aufzählungszeichens zu steuern.
1. Setzen Sie die Farbe des Aufzählungszeichens.
1. Setzen Sie die Höhe des Aufzählungszeichens.
1. Fügen Sie den erstellten Absatz der Absatz‑Sammlung des Textfeldes hinzu.
1. Fügen Sie einen zweiten Absatz hinzu und wiederholen Sie die Schritte 7–12.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie Sie eine Aufzählungsliste in einer Folie erstellen:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Die Symbol‑Aufzählungszeichen](symbol_bullets.png)

## **Bild‑Aufzählungszeichen erstellen**

Aspose.Slides für Python via .NET ermöglicht es Ihnen, Aufzählungszeichen in Aufzählungslisten anzupassen. Sie können Standard‑Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder bestimmte Einträge stärker hervorheben möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden.

 {{% alert color="primary" %}}
Idealerweise, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, sollten Sie eine einfache Grafik mit transparentem Hintergrund wählen. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungszeichen.

Beachten Sie, dass das Bild auf eine sehr kleine Größe verkleinert wird. Aus diesem Grund empfehlen wir dringend, ein Bild auszuwählen, das auch in kleiner Form klar und visuell wirkungsvoll als Aufzählungszeichen bleibt.
{{% /alert %}}

Um ein Bild‑Aufzählungszeichen zu erstellen, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)‑Objekt auf die gewünschte Folie aus der Folien‑Sammlung zu.
1. Fügen Sie dem ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit der Methode `add_auto_shape` hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz aus dem Textfeld.
1. Laden Sie ein Bild von der Festplatte, fügen Sie es zu [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) hinzu und erhalten Sie die vom [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/#methods)‑Methode zurückgegebene Instanz von [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/).
1. Erstellen Sie die erste Absatz‑Instanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Setzen Sie den Aufzählungs‑Typ auf `PICTURE` und weisen Sie anschließend das Bild zu.
1. Setzen Sie den Absatztext.
1. Stellen Sie den Absatz‑Einzug ein, um die Position des Aufzählungszeichens festzulegen.
1. Setzen Sie die Farbe des Aufzählungszeichens.
1. Setzen Sie die Höhe des Aufzählungszeichens.
1. Fügen Sie den Absatz der Absatz‑Sammlung des Textfeldes hinzu.
1. Fügen Sie einen zweiten Absatz hinzu und wiederholen Sie die Schritte 8–13.
1. Speichern Sie die Präsentation.

Angenommen, wir haben eine „image.png“:

![Ein Bild für die Aufzählungszeichen](picture_for_bullets.png)

Der folgende Python‑Code zeigt, wie Sie Bild‑Aufzählungszeichen in einer Folie erstellen:
```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Die Bild‑Aufzählungszeichen](picture_bullets.png)

## **Mehrstufige Listen erstellen**

Um eine Aufzählungsliste zu erstellen, die Elemente auf mehreren Ebenen enthält (Unterlisten unter Hauptaufzählungszeichen), gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)‑Objekt auf die gewünschte Folie aus der Folien‑Sammlung zu.
1. Fügen Sie dem ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit der Methode `add_auto_shape` hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz aus dem Textfeld.
1. Erstellen Sie die erste [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)-Instanz und setzen Sie ihre Tiefe auf 0 (Hauptebene).
1. Erstellen Sie den zweiten Absatz und setzen Sie seine Tiefe auf 1 (erste Unterebene).
1. Erstellen Sie den dritten Absatz und setzen Sie seine Tiefe auf 2 (zweite Unterebene).
1. Erstellen Sie den vierten Absatz und setzen Sie seine Tiefe auf 3 (dritte Unterebene).
1. Fügen Sie alle erstellten Absätze der Absatz‑Sammlung des Textfeldes hinzu.
1. Speichern Sie die Präsentation.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Die mehrstufige Liste](multilevel_list.png)

## **Nummerierte Aufzählungszeichen erstellen**

Klare und strukturierte nummerierte Listen zu erstellen ist mit Aspose.Slides für Python einfach. Nummerierte Listen erhöhen die Lesbarkeit erheblich und helfen, Ihr Publikum klar durch Schritte oder geordnete Informationen zu führen. Egal, ob Sie Schulungsfolien vorbereiten, Prozesse dokumentieren oder Präsentationen gliedern, nummerierte Listen sorgen dafür, dass Ihre Botschaft strukturiert und leicht nachvollziehbar bleibt.

Aspose.Slides ermöglicht es Ihnen, nummerierte Listen programmgesteuert einfach hinzuzufügen, anzupassen und zu formatieren. Sie können verschiedene Nummerierungsstile festlegen – wie numerisch (1, 2, 3), alphabetisch (A, B, C) oder römisch (I, II, III) – um den Kontext oder gewünschten Stil Ihrer Präsentationen zu treffen.

Der folgende Python‑Code zeigt, wie Sie eine nummerierte Liste in einer Folie erstellen:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Die nummerierten Aufzählungszeichen](numbered_bullets.png)

## **FAQ**

**Können mit Aspose.Slides erstellte Aufzählungs‑ und Nummerierungslisten in andere Formate wie PDF oder Bilder exportiert werden?**

Ja, Aspose.Slides bewahrt die Formatierung und Struktur von Aufzählungs‑ und Nummerierungslisten vollständig bei, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, wodurch konsistente Ergebnisse sichergestellt werden.

**Ist es möglich, Aufzählungs‑ oder Nummerierungslisten aus bestehenden Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht es Ihnen, Aufzählungs‑ oder Nummerierungslisten aus bestehenden Präsentationen zu importieren und zu bearbeiten, wobei deren ursprüngliche Formatierung und Darstellung erhalten bleibt.

**Unterstützt Aspose.Slides Aufzählungs‑ und Nummerierungslisten in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und ermöglicht das Erstellen von Aufzählungs‑ und Nummerierungslisten in jeder Sprache, einschließlich der Verwendung von Sonder‑ oder Nicht‑Latein‑Zeichen.