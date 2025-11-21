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
- interaktive Animation
- benutzerdefinierte Animation
- Formanimation
- animiertes Diagramm
- animierter Text
- animierte Form
- animiertes OLE-Objekt
- animiertes Bild
- animierte Tabelle
- PowerPoint-Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für .NET beim Umgang mit PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor und bietet Einblicke, um Ihre Präsentationen zu verbessern."
---

## **Übersicht**

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bereits bei der Erstellung berücksichtigt.

**PowerPoint-Animationen** spielen eine wichtige Rolle, um eine Präsentation für Zuschauer auffällig und ansprechend zu gestalten. Aspose.Slides für .NET bietet eine breite Palette von Optionen, um PowerPoint‑Präsentationen zu animieren:

- Wenden Sie verschiedene Arten von PowerPoint‑Animationseffekten auf Formen, Diagramme, Tabellen, OLE‑Objekte und andere Präsentationselemente an.
- Verwenden Sie mehrere PowerPoint‑Animationseffekte auf einer einzigen Form.
- Nutzen Sie die Animationszeitlinie, um Animationseffekte zu steuern.
- Erstellen Sie benutzerdefinierte Animationen.

In Aspose.Slides für .NET können verschiedene Animationseffekte auf Formen angewendet werden. Da jedes Element auf einer Folie, einschließlich Text, Bilder, OLE‑Objekte und Tabellen, als Form betrachtet wird, können Animationseffekte auf jedes Element auf der Folie angewendet werden.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) namespace bietet Klassen zur Arbeit mit PowerPoint‑Animationen.

## **Animationseffekte**

Aspose.Slides unterstützt **mehr als 150 Animationseffekte**, darunter Basis‑Effekte wie Bounce, PathFootball und Zoom sowie spezifische Effekte wie OLEObjectShow und OLEObjectOpen. Eine vollständige Liste der Animationseffekte finden Sie in der Aufzählung [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

Zusätzlich können diese Animationseffekte in Kombination mit den folgenden verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)

## **Benutzerdefinierte Animation**

Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) ist ein Baustein jedes PowerPoint‑Animationseffekts. Alle Animationseffekte bestehen im Wesentlichen aus einer Menge von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation kombinieren und diese dann in anderen Präsentationen wiederverwenden. Wenn Sie einer Standard‑PowerPoint‑Animation ein neues Verhalten hinzufügen, entsteht eine weitere benutzerdefinierte Animation. Beispielsweise können Sie einer Animation ein Wiederholungs‑Verhalten hinzufügen, damit sie mehrere Male wiederholt wird.

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) ist ein Punkt, an dem ein Verhalten angewendet werden soll.

## **Animationszeitlinie**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) ist eine Sammlung von Animationseffekten, die auf eine bestimmte Form angewendet werden.

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) ist ein Satz von Sequenzen, die in einer bestimmten Folie verwendet werden. Es ist eine Animations‑Engine, die in PowerPoint 2002 eingeführt wurde. In früheren Versionen von PowerPoint war das Hinzufügen von Animationseffekten zu Präsentationen schwierig und nur mit verschiedenen Work‑arounds möglich. Die Zeitlinie ersetzt die alte AnimationSettings‑Klasse und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animationszeitlinie besitzen.

## **Interaktive Animation**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) ermöglicht es, Benutzeraktionen (z. B. einen Klick auf einen Button) zu definieren, die eine bestimmte Animation starten. Trigger wurden in der neuesten PowerPoint‑Version eingeführt.

## **Form‑Animation**

Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, zu denen Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und mehr gehören können.

{{% alert color="primary" %}} 
Mehr lesen [**Über Shape‑Animation**](/slides/de/net/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**

Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. PowerPoint‑Animationen können jedoch nur auf Diagrammkategorien oder Diagrammreihen angewendet werden. Sie können Animationseffekte auch auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="primary" %}} 
Mehr lesen [**Über animierte Diagramme**](/slides/de/net/animated-charts/).
{{% /alert %}}

## **Animierter Text**

Neben animiertem Text ist es auch möglich, Animationen auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Mehr lesen [**Über animierten Text**](/slides/de/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren nach PDF beibehalten?**

Nein. PDF ist ein statisches Format, sodass Animationen und [Folienübergänge](/slides/de/net/slide-transition/) nicht abgespielt werden. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen nach [HTML5](/slides/de/net/export-to-html5/), [animiertem GIF](/slides/de/net/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/net/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie die Bildgröße steuern?**

Ja. Sie können die Präsentation als einzelne Bilder [rendern](/slides/de/net/convert-powerpoint-to-video/) und diese mit einem Tool wie ffmpeg zu einem Video zusammenfügen, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

**Bleiben Animationen intakt, wenn mit ODP (nicht nur PPTX) gearbeitet wird?**

PPT, PPTX und ODP werden zum [Lesen](/slides/de/net/open-presentation/) und [Schreiben](/slides/de/net/save-presentation/) unterstützt, aber Unterschiede im Format können dazu führen, dass bestimmte Effekte leicht unterschiedlich aussehen oder sich anders verhalten. Validieren Sie kritische Fälle mit echten Beispielen.