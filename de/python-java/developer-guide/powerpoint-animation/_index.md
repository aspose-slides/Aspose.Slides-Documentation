---
title: "PowerPoint-Präsentationen mit Animationen in Python via Java verbessern"
linktitle: "PowerPoint-Animation"
type: docs
weight: 150
url: /de/python-java/powerpoint-animation/
keywords:
  - "Animation hinzufügen"
  - "Animation aktualisieren"
  - "Animation ändern"
  - "Animation entfernen"
  - "Animation verwalten"
  - "Animation steuern"
  - "Animationseffekt"
  - "PowerPoint-Animation"
  - "Animationszeitlinie"
  - "interaktive Animation"
  - "benutzerdefinierte Animation"
  - "Form-Animation"
  - "animiertes Diagramm"
  - "animierter Text"
  - "animierte Form"
  - "animiertes OLE-Objekt"
  - "animiertes Bild"
  - "animierte Tabelle"
  - "PowerPoint"
  - "Präsentation"
  - "Python"
  - "Java"
  - "Aspose.Slides"
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Python via Java beim Umgang mit PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor und bietet Einblicke, um Ihre Präsentationen zu verbessern."
---
## **Einleitung**

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bei der Erstellung stets berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle dabei, eine Präsentation auffällig und ansprechend für die Zuschauer zu gestalten. Aspose.Slides bietet eine breite Palette von Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- Wenden Sie verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente an.
- Verwenden Sie mehrere PowerPoint-Animationseffekte gleichzeitig auf einer einzelnen Form.
- Nutzen Sie die Animationszeitleiste, um Animationseffekte zu steuern.
- Erstellen Sie benutzerdefinierte Animationen.

## **Animationseffekte**

Aspose.Slides unterstützt **150+ Animationseffekte**, darunter grundlegende Animationseffekte wie Bounce, PathFootball, Zoom-Effekt sowie spezifische Animationseffekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Auflistung der Animationseffekte finden Sie in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effecttype/).

Zusätzlich können diese Animationseffekte in Kombination miteinander verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/seteffect/)

## **Benutzerdefinierte Animation**

Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[Behavior](https://reference.aspose.com/slides/de/python-java/aspose.slides/behavior/) ist eine Baueinheit jedes PowerPoint-Animationseffekts. Alle Animationseffekte bestehen eigentlich aus einer Menge von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation kombinieren und sie anschließend in anderen Präsentationen wiederverwenden. Wenn Sie einer Standard‑PowerPoint‑Animation ein neues Verhalten hinzufügen, entsteht eine weitere benutzerdefinierte Animation. Beispielsweise können Sie einer Animation ein Wiederholungsverhalten hinzufügen, damit sie mehrmals wiederholt wird.

[Point](https://reference.aspose.com/slides/de/python-java/aspose.slides/point/) ist ein Punkt, an dem das Verhalten angewendet werden soll.

## **Animationszeitlinie**

[Sequence](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/) ist eine Sammlung von Animationseffekten, die auf einer konkreten Form angewendet werden.

[AnimationTimeLine](https://reference.aspose.com/slides/de/python-java/aspose.slides/animationtimeline/) ist ein Satz von Sequenzen, die in einer konkreten Folie verwendet werden. Es ist eine Animations-Engine, die seit PowerPoint 2002 verfügbar ist. In früheren PowerPoint‑Versionen war das Hinzufügen von Animationseffekten zur Präsentation schwierig und nur mit verschiedenen Workarounds möglich. Die Zeitachse ersetzt die alte Klasse AnimationSettings und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Auf einer Folie kann nur eine Animationszeitachse vorhanden sein.

## **Interaktive Animation**

[EffectTriggerType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effecttriggertype/) ermöglicht das Definieren von Benutzeraktionen (z. B. Klick auf einen Button), die eine bestimmte Animation starten lassen. Trigger wurden erst in der neuesten PowerPoint‑Version eingeführt.

## **Form-Animation**

Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die tatsächlich Text, Rechteck, Linie, Rahmen, OLE‑Objekt usw. sein können.

{{% alert color="info" title="Hinweis" %}} 
Mehr dazu [Über Shape-Animation](/slides/de/python-java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**

Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Es ist jedoch nur möglich, PowerPoint‑Animationen auf Diagrammkategorien oder Diagrammreihen anzuwenden. Sie können den Animationseffekt auch auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="info" title="Hinweis" %}} 
Mehr dazu [Über animierte Diagramme](/slides/de/python-java/animated-charts/).
{{% /alert %}}

## **Animierter Text**

Neben animiertem Text ist es auch möglich, eine Animation auf einen Absatz anzuwenden.

{{% alert color="info" title="Hinweis" %}} 
Mehr dazu [Über animierten Text](/slides/de/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren nach PDF erhalten?**

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/python-java/slide-transition/) nicht abgespielt. Wenn Sie Bewegungen benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/python-java/export-to-html5/), [animiertem GIF](/slides/de/python-java/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/python-java/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie die Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [die Präsentation als Einzelbilder rendern](/slides/de/python-java/convert-powerpoint-to-video/) und sie in ein Video (z. B. mit ffmpeg) enkodieren, wobei Sie FPS und Auflösung wählen können. Animationen und Folienübergänge werden während des Renderns abgespielt.

**Bleiben Animationen intakt, wenn mit ODP (nicht nur PPTX) gearbeitet wird?**

PPT, PPTX und ODP werden zum [Lesen](/slides/de/python-java/open-presentation/) und [Schreiben](/slides/de/python-java/save-presentation/) unterstützt, jedoch können Formatunterschiede dazu führen, dass bestimmte Effekte leicht anders aussehen oder sich anders verhalten. Validieren Sie kritische Fälle mit echten Beispielen.