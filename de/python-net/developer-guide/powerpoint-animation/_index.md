---
title: "PowerPoint-Präsentationen mit Animationen in Python verbessern"
linktitle: "PowerPoint-Animation"
type: docs
weight: 150
url: /de/python-net/powerpoint-animation/
keywords:
- "Animation hinzufügen"
- "Animation aktualisieren"
- "Animation ändern"
- "Animation entfernen"
- "Animation verwalten"
- "Animation steuern"
- "Animationseffekt"
- "PowerPoint-Animation"
- "Animationszeitachse"
- "interaktive Animation"
- "benutzerdefinierte Animation"
- "Formanimation"
- "animiertes Diagramm"
- "animierter Text"
- "animierte Form"
- "animiertes OLE-Objekt"
- "animiertes Bild"
- "animierte Tabelle"
- "PowerPoint-Präsentation"
- "Python"
- "Aspose.Slides"
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Python via .NET bei der Handhabung von PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor und bietet Einblicke, um Ihre Präsentationen zu verbessern."
---
## **Einführung**

Präsentationen werden erstellt, um Informationen zu vermitteln, daher sind ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bei der Erstellung wichtige Aspekte.

**PowerPoint-Animation** spielt eine wichtige Rolle, um eine Präsentation für Betrachter ansprechend und fesselnd zu machen. Aspose.Slides for Python via .NET bietet eine Vielzahl von Optionen, um einer PowerPoint-Präsentation Animationen hinzuzufügen. Sie können:

- Verschiedene Animationseffekte auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Elemente anwenden.
- Mehrere Animationseffekte auf einer einzelnen Form verwenden.
- Effekte über die Animationszeitachse steuern.
- Benutzerdefinierte Animationen erstellen.

In Aspose.Slides for Python via .NET können Animationseffekte auf Formen angewendet werden. Da jedes Element auf einer Folie – einschließlich Text, Bilder, OLE-Objekte und Tabellen – als Form behandelt wird, können Sie Animationseffekte auf jedes Element der Folie anwenden.

Der [aspose.slides.animation](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/) Namespace stellt die Klassen für die Arbeit mit PowerPoint-Animationen bereit.

## **Installation**

```bash
pip install aspose.slides
```

## **Animationseffekt zu einer Form in Python hinzufügen**

Animationseffekte befinden sich in der Hauptsequenz einer Folie. Fügen Sie eine Form hinzu und rufen Sie dann `add_effect` auf `slide.timeline.main_sequence` auf, wobei Sie den Effekttyp, seinen Subtyp und den Auslöser, der ihn startet, übergeben.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

Die gespeicherte Datei enthält einen Effekt auf der ersten Folie: Das Rechteck fliegt von links innerhalb von zwei Sekunden ein, wenn der Präsentierende klickt. Beim erneuten Öffnen und Auslesen von `slide.timeline.main_sequence` wird dieser Effekt zurückgegeben, sodass die Animation den Rundweg übersteht und nicht nur im Speicher existiert.

## **Animationseffekte**

Aspose.Slides unterstützt **mehr als 150 Animationseffekte**, darunter Grundeffekte wie Bounce, PathFootball und Zoom sowie spezialisierte Effekte wie OLEObjectShow und OLEObjectOpen. Die vollständige Liste finden Sie in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttype/).

Zusätzlich können diese Animationseffekte mit den folgenden Effekten kombiniert werden:

- [ColorEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/seteffect/)

## **Benutzerdefinierte Animation**

Sie können in Aspose.Slides eigene **benutzerdefinierte Animationen** erstellen, indem Sie mehrere Verhaltensweisen zu einem einzigen Effekt kombinieren.

[Behavior](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behavior/) ist das Grundbaustein jedes PowerPoint-Animationseffekts. Jeder Animationseffekt besteht im Wesentlichen aus einer Menge von Verhaltensweisen, die zu einer Strategie oder Zeitleiste angeordnet sind. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation zusammenstellen und diese in anderen Präsentationen wiederverwenden. Wenn Sie einer Standard-PowerPoint-Animation ein neues Verhalten hinzufügen, entsteht eine benutzerdefinierte Animation – zum Beispiel durch Hinzufügen eines Wiederholungs‑Verhaltens, das die Animation mehrmals abspielt.

[Animation Point](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/point/) markiert den Moment oder die Position, an der ein Verhalten angewendet wird (ein Schlüsselbild).

## **Animationszeitachse**

[Sequence](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/) ist eine Sammlung von Animationseffekten, die auf eine bestimmte Form angewendet werden.

[Timeline](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/animationtimeline/) ist die Menge von Sequenzen, die auf einer bestimmten Folie verwendet werden. Sie wurde in PowerPoint 2002 eingeführt. In früheren Versionen von PowerPoint war das Hinzufügen von Animationseffekten schwierig und erforderte oft Umgehungen. Die Timeline ersetzt die alte Klasse `AnimationSettings` und bietet ein klareres Objektmodell für PowerPoint-Animationen. Jede Folie kann nur eine Animationszeitachse besitzen.

## **Interaktive Animation**

[Trigger](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttriggertype/) ermöglicht es Ihnen, Benutzeraktionen (z. B. einen Button‑Klick) zu definieren, die eine bestimmte Animation starten. Trigger wurden erst in den neuesten Versionen von PowerPoint hinzugefügt.

## **Formanimation**

Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen – z. B. Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und mehr.

{{% alert color="primary" %}}
Mehr dazu [**Über Formanimation**](/slides/de/python-net/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**

Um animierte Diagramme zu erstellen, verwenden Sie dieselben Klassen wie für Formen. PowerPoint-Animationen können jedoch nur auf Diagrammkategorien oder Diagrammserien angewendet werden. Sie können einen Animationseffekt auch auf ein einzelnes Kategorienelement oder Serienelement anwenden.

{{% alert color="primary" %}}
Mehr dazu [**Über animierte Diagramme**](/slides/de/python-net/animated-charts/).
{{% /alert %}}

## **Animierter Text**

Zusätzlich zum Animieren von Text können Sie einer Absatzanimation anwenden.

{{% alert color="primary" %}}
Mehr dazu [**Über animierten Text**](/slides/de/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

### Werden Animationen beim Exportieren in PDF erhalten?

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/python-net/slide-transition/) nicht abgespielt. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/python-net/export-to-html5/), [animiertem GIF](/slides/de/python-net/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/python-net/convert-powerpoint-to-video/).

### Kann ich eine animierte Präsentation in ein Video umwandeln und Bildrate sowie Bildgröße steuern?

Ja. Sie können die Präsentation als Einzelbilder [die Präsentation als Einzelbilder rendern](/slides/de/python-net/convert-powerpoint-to-video/) und diese zu einem Video (z. B. mit ffmpeg) kodieren, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

### Bleiben Animationen bei der Arbeit mit ODP (nicht nur PPTX) intakt?

PPT, PPTX und ODP werden für das [Lesen](/slides/de/python-net/open-presentation/) und [Schreiben](/slides/de/python-net/save-presentation/) unterstützt, jedoch können Formatunterschiede dazu führen, dass bestimmte Effekte leicht abweichend aussehen oder sich verhalten. Prüfen Sie kritische Fälle mit echten Beispielen.