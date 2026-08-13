---
title: PowerPoint-Präsentationen mit Animationen in .NET verbessern
linktitle: PowerPoint-Animation
type: docs
weight: 150
url: /de/net/powerpoint-animation/
keywords:
- Animation hinzufügen
- Animation aktualisieren
- Animation ändern
- Animation entfernen
- Animation verwalten
- Animation steuern
- Animationseffekt
- PowerPoint-Animation
- Animationszeitlinie
- Interaktive Animation
- Benutzerdefinierte Animation
- Formanimation
- Animiertes Diagramm
- Animierter Text
- Animierte Form
- Animiertes OLE-Objekt
- Animiertes Bild
- Animierte Tabelle
- PowerPoint-Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für .NET bei der Handhabung von PowerPoint-Animationen. Dieser allgemeine Überblick hebt zentrale Funktionen hervor und bietet Einblicke, um Ihre Präsentationen zu verbessern."
---
## **Einführung**

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bei der Erstellung stets berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle dabei, eine Präsentation für die Zuschauer auffällig und ansprechend zu gestalten. Aspose.Slides for .NET bietet eine große Auswahl an Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- Wenden Sie verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente an.
- Verwenden Sie mehrere PowerPoint-Animationseffekte auf einer einzelnen Form.
- Nutzen Sie die Animationszeitlinie, um Animationseffekte zu steuern.
- Erstellen Sie benutzerdefinierte Animationen.

In Aspose.Slides for .NET können verschiedene Animationseffekte auf Formen angewendet werden. Da jedes Element auf einer Folie, einschließlich Text, Bilder, OLE-Objekte und Tabellen, als Form betrachtet wird, können Animationseffekte auf jedes Element der Folie angewendet werden.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/de/net/aspose.slides.animation/) Namespace stellt Klassen zur Arbeit mit PowerPoint-Animationen bereit.

## **Animationseffekte**

Aspose.Slides unterstützt **150+ Animationseffekte**, darunter Grundeffekte wie Bounce, PathFootball und Zoom sowie spezifische Effekte wie OLEObjectShow und OLEObjectOpen. Eine vollständige Liste der Animationseffekte finden Sie in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effecttype).

Zusätzlich können diese Animationseffekte in Kombination mit den folgenden verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/seteffect)

## **Benutzerdefinierte Animation**

Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[Behaviour](https://reference.aspose.com/slides/de/net/aspose.slides.animation/behavior) ist ein Baustein jedes PowerPoint-Animationseffekts. Alle Animationseffekte bestehen im Wesentlichen aus einer Menge von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation kombinieren und diese dann in anderen Präsentationen wiederverwenden. Wenn Sie einer Standard-PowerPoint-Animation einen neuen Vorgang hinzufügen, wird daraus eine weitere benutzerdefinierte Animation. Beispielsweise können Sie einer Animation ein Wiederholungsverhalten hinzufügen, um sie mehrmals wiederholen zu lassen.

[Animation Point](https://reference.aspose.com/slides/de/net/aspose.slides.animation/point) ist ein Punkt, an dem ein Verhalten angewendet werden soll.

## **Animationszeitlinie**

[Sequence](https://reference.aspose.com/slides/de/net/aspose.slides.animation/sequence) ist eine Sammlung von Animationseffekten, die auf eine bestimmte Form angewendet werden.

[Timeline](https://reference.aspose.com/slides/de/net/aspose.slides.animation/animationtimeline) ist eine Menge von Sequenzen, die in einer bestimmten Folie verwendet werden. Es ist eine Animationsengine, die in PowerPoint 2002 eingeführt wurde. In früheren Versionen von PowerPoint war das Hinzufügen von Animationseffekten zu Präsentationen schwierig und nur mit verschiedenen Umwegen möglich. Die Zeitlinie ersetzt die alte AnimationSettings-Klasse und bietet ein klareres Objektmodell für PowerPoint-Animationen. Eine Folie kann nur eine Animationszeitlinie haben.

## **Interaktive Animation**

[Trigger](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effecttriggertype) ermöglicht es Ihnen, Benutzeraktionen (z. B. einen Button‑Klick) zu definieren, die eine bestimmte Animation auslösen. Trigger wurden in der neuesten Version von PowerPoint eingeführt.

## **Formanimation**

Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und mehr umfassen können.

{{% alert color="info" %}} 
Mehr dazu [**Über Formanimation**](/slides/de/net/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**

Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. PowerPoint‑Animationen können jedoch nur auf Diagrammkategorien oder Diagrammreihen angewendet werden. Sie können Animations‑effekte auch auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="info" %}} 
Mehr dazu [**Über animierte Diagramme**](/slides/de/net/animated-charts/).
{{% /alert %}}

## **Animierter Text**

Neben animiertem Text kann auch auf einen Absatz eine Animation angewendet werden.

{{% alert color="info" %}} 
Mehr dazu [**Über animierten Text**](/slides/de/net/animated-text/).
{{% /alert %}}

## **FAQ**

### Bleiben Animationen beim Export nach PDF erhalten?

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/net/slide-transition/) nicht abgespielt. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen nach [HTML5](/slides/de/net/export-to-html5/), [animated GIF](/slides/de/net/convert-powerpoint-to-animated-gif/) oder [video](/slides/de/net/convert-powerpoint-to-video/).

### Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie die Bildgröße steuern?

Ja. Sie können [die Präsentation als Einzelbilder rendern](/slides/de/net/convert-powerpoint-to-video/) und diese in ein Video (z. B. mit ffmpeg) kodieren, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

### Bleiben Animationen beim Arbeiten mit ODP (nicht nur PPTX) intakt?

PPT, PPTX und ODP werden für das [Lesen](/slides/de/net/open-presentation/) und [Schreiben](/slides/de/net/save-presentation/) unterstützt, jedoch können Formatunterschiede dazu führen, dass bestimmte Effekte leicht unterschiedlich aussehen oder sich anders verhalten. Validieren Sie kritische Fälle mit realen Beispielen.