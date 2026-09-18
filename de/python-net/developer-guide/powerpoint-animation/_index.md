---
title: PowerPoint-Präsentationen mit Animationen in Python verbessern
linktitle: PowerPoint-Animation
type: docs
weight: 150
url: /de/python-net/powerpoint-animation/
keywords:
- Animation hinzufügen
- Animation aktualisieren
- Animation ändern
- Animation entfernen
- Animation verwalten
- Animation steuern
- Animationseffekt
- PowerPoint-Animation
- Animationszeitleiste
- Interaktive Animation
- Benutzerdefinierte Animation
- Form-Animation
- Animiertes Diagramm
- Animierter Text
- Animierte Form
- Animiertes OLE-Objekt
- Animiertes Bild
- Animierte Tabelle
- PowerPoint-Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Python via .NET bei der Handhabung von PowerPoint-Animationen. Dieser allgemeine Überblick hebt zentrale Funktionen hervor und bietet Einblicke, um Ihre Präsentationen zu verbessern."
---
## **Einführung**

Präsentationen sollen Informationen vermitteln, daher sind ihr visuelles Erscheinungsbild und ihr interaktives Verhalten zentrale Aspekte bei der Erstellung.

**PowerPoint-Animation** spielt eine wichtige Rolle, um eine Präsentation ansprechend und fesselnd für das Publikum zu gestalten. Aspose.Slides for Python via .NET bietet ein breites Spektrum an Möglichkeiten, Animationen zu einer PowerPoint‑Präsentation hinzuzufügen. Sie können:

- Verschiedene Animationseffekte auf Formen, Diagramme, Tabellen, OLE‑Objekte und andere Elemente anwenden.
- Mehrere Animationseffekte auf einer einzelnen Form verwenden.
- Effekte über die Animations‑Zeitleiste steuern.
- Benutzerdefinierte Animationen erstellen.

In Aspose.Slides for Python via .NET können Animationseffekte auf Formen angewendet werden. Da jedes Element auf einer Folie — einschließlich Text, Bilder, OLE‑Objekte und Tabellen — als Form behandelt wird, können Sie Animationseffekte auf jedes Element der Folie anwenden.

Der [aspose.slides.animation](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/) Namespace stellt die Klassen für die Arbeit mit PowerPoint‑Animationen bereit.

## **Installation**

```bash
pip install aspose.slides
```

## **Eine Animationswirkung einer Form in Python hinzufügen**

Animationswirkungen leben in der Hauptsequenz einer Folie. Fügen Sie eine Form hinzu und rufen Sie `add_effect` auf `slide.timeline.main_sequence` auf, wobei Sie den Effekt‑Typ, dessen Subtyp und den Auslöser übergeben, der ihn startet.

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

Die gespeicherte Datei enthält einen Effekt auf der ersten Folie: Das Rechteck fliegt von links nach rechts innerhalb von zwei Sekunden, wenn der Präsentierende klickt. Wird die Datei erneut geöffnet und `slide.timeline.main_sequence` ausgelesen, wird dieser Effekt zurückgegeben, sodass die Animation den gesamten Durchlauf überlebt und nicht nur im Speicher existiert.

## **Animations‑Effekte**

Aspose.Slides unterstützt **mehr als 150 Animations‑Effekte**, darunter Grundeffekte wie Bounce, PathFootball und Zoom sowie Spezial‑Effekte wie OLEObjectShow und OLEObjectOpen. Die vollständige Liste finden Sie in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttype/).

Zusätzlich können diese Animations‑Effekte mit den folgenden Effekten kombiniert werden:

- [ColorEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/seteffect/)

## **Benutzerdefinierte Animation**

Vollständige Python‑Beispiele, die Verhalten und editierbare Bewegungsbahnen erstellen, prüfen und verändern, finden Sie unter [Custom Animation](/slides/de/python-net/custom-animation/).

Sie können eigene **benutzerdefinierte Animationen** in Aspose.Slides erstellen, indem Sie mehrere Verhaltensweisen zu einem einzelnen Effekt kombinieren.

[Behavior](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behavior/) ist ein Baustein eines PowerPoint‑Animations‑Effekts. Kombinieren Sie Verhaltensweisen, um einen Effekt anzupassen, oder fügen Sie ein Verhalten hinzu, um einen vordefinierten Effekt zu erweitern. Wiederholungen werden über Timing‑Einstellungen konfiguriert, nicht über ein separates Wiederhol‑Verhalten.

[Animation Point](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/point/) markiert den Moment oder die Position, an der ein Verhalten angewendet wird (ein Keyframe).

## **Animations-Zeitleiste**

[Sequence](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/) ist eine Sammlung von Animations‑Effekten, die unterschiedliche Formen ansprechen können.

[Timeline](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/animationtimeline/) ist das Set von Sequenzen, das auf einer bestimmten Folie verwendet wird. Es wurde in PowerPoint 2002 eingeführt. In früheren PowerPoint‑Versionen war das Hinzufügen von Animations‑Effekten schwierig und häufig mit Work‑arounds verbunden. Die Zeitleiste ersetzt die alte Klasse `AnimationSettings` und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Jede Folie kann nur eine Animations‑Zeitleiste besitzen.

## **Interaktive Animation**

[Trigger](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttriggertype/) ermöglicht das Definieren von Benutzeraktionen (z. B. ein Klick auf einen Button), die eine bestimmte Animation starten. Trigger wurden erst in den neuesten PowerPoint‑Versionen eingeführt.

## **Form-Animation**

Aspose.Slides lässt Sie Animationen auf Formen anwenden — wie Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und mehr.

{{% alert color="info" title="Note" %}}
Weitere Informationen [**Über Shape-Animation**](/slides/de/python-net/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**

Um animierte Diagramme zu erstellen, verwenden Sie dieselben Klassen wie für Formen. Allerdings können PowerPoint‑Animationen nur auf Diagrammkategorien oder Diagrammserien angewendet werden. Sie können außerdem einen Animations‑Effekt auf ein einzelnes Kategorie‑Element oder Serien‑Element anwenden.

{{% alert color="info" title="Note" %}}
Weitere Informationen [**Über animierte Diagramme**](/slides/de/python-net/animated-charts/).
{{% /alert %}}

## **Animierter Text**

Neben der Animation von Text können Sie auch eine Passage animieren.

{{% alert color="info" title="Note" %}}
Weitere Informationen [**Über animierten Text**](/slides/de/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF erhalten?**

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/python-net/slide-transition/) nicht wiedergegeben. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen nach [HTML5](/slides/de/python-net/export-to-html5/), [animiertem GIF](/slides/de/python-net/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/python-net/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und Bildrate sowie Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [rendern](/slides/de/python-net/convert-powerpoint-to-video/) und diese mit einem Tool wie ffmpeg zu einem Video zusammenfügen, wobei Sie FPS und Auflösung wählen können. Während des Renderns werden Animationen und Folienübergänge wiedergegeben.

**Bleiben Animationen erhalten, wenn ich mit ODP (nicht nur PPTX) arbeite?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/python-net/open-presentation/) und [Schreiben](/slides/de/python-net/save-presentation/) unterstützt, aber das garantiert keinen Erhalt von Animationen. Bei der Konvertierung nach ODP können benutzerdefinierte Animationsdaten verloren gehen. Siehe [Custom Animation](/slides/de/python-net/custom-animation/) für Beispiele und Hinweise zur Prüfung der Formatkompatibilität.