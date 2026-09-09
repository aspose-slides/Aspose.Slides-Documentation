---
title: PowerPoint-Präsentationen mit Animationen in Python über Java verbessern
linktitle: PowerPoint-Animation
type: docs
weight: 150
url: /de/python-java/powerpoint-animation/
keywords:
- Animation hinzufügen
- Animation aktualisieren
- Animation ändern
- Animation entfernen
- Animation verwalten
- Animation steuern
- Animationseffekt
- PowerPoint-Animation
- Animationszeitachse
- Interaktive Animation
- Benutzerdefinierte Animation
- Formanimation
- Animiertes Diagramm
- Animierter Text
- Animierte Form
- Animiertes OLE-Objekt
- Animiertes Bild
- Animierte Tabelle
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Python über Java bei der Handhabung von PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor und bietet Einblicke, um Ihre Präsentationen zu verbessern."
---
## **Einleitung**

Sowohl das visuelle Erscheinungsbild als auch das interaktive Verhalten werden bei der Erstellung von Präsentationen berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle dabei, eine Präsentation für die Zuschauer ansprechend und fesselnd zu gestalten. Aspose.Slides bietet eine breite Palette von Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- Wenden Sie verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente an.
- Verwenden Sie mehrere PowerPoint-Animationseffekte auf einer einzelnen Form.
- Nutzen Sie die Animationszeitleiste, um Animationseffekte zu steuern.
- Erstellen Sie benutzerdefinierte Animationen.

In Aspose.Slides können verschiedene Animationseffekte auf Formen angewendet werden. Da jedes Element auf einer Folie, einschließlich Text, Bilder, OLE-Objekte und Tabellen, als Form betrachtet wird, können Animationseffekte auf jedes Element der Folie angewendet werden.

## **Animations-Effekte**
Aspose.Slides unterstützt **150+ Animations-Effekte**, darunter grundlegende Animations-Effekte wie Bounce, PathFootball und Zoom sowie spezialisierte Effekte wie OLEObjectShow und OLEObjectOpen. Eine vollständige Auflistung der Animations-Effekte finden Sie in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effecttype/).

Zusätzlich können die folgenden Animations-Effekte in Kombination mit den oben aufgeführten verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/seteffect/)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen.
Dazu können Sie mehrere Behaviors zu einer neuen benutzerdefinierten Animation kombinieren.

[Behavior](https://reference.aspose.com/slides/de/python-java/aspose.slides/behavior/) ist ein Baustein jedes PowerPoint-Animationseffekts. Jeder Animationseffekt besteht aus einer Menge von Behaviors, die zu einer einzigen Strategie kombiniert werden. Sie können Behaviors zu einer benutzerdefinierten Animation kombinieren und sie anschließend in anderen Präsentationen wiederverwenden. Das Hinzufügen eines neuen Behaviors zu einem Standard-PowerPoint-Animationseffekt erzeugt eine weitere benutzerdefinierte Animation. Beispielweise können Sie ein Wiederholungs-Behavior hinzufügen, um eine Animation mehrmals wiederholen zu lassen.

[Point](https://reference.aspose.com/slides/de/python-java/aspose.slides/point/) ist ein Punkt, an dem ein Behavior angewendet werden soll.

## **Animations-Zeitachse**
[Sequence](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/) ist eine Sammlung von Animations-Effekten, die auf eine bestimmte Form angewendet werden.

[AnimationTimeLine](https://reference.aspose.com/slides/de/python-java/aspose.slides/animationtimeline/) ist eine Menge von Sequenzen, die auf einer bestimmten Folie verwendet werden. Sie stellt die Animations-Engine dar, die in PowerPoint 2002 eingeführt wurde. In früheren PowerPoint-Versionen war das Hinzufügen von Animations-Effekten zu einer Präsentation schwierig und erforderte Umwege. Die Zeitachse ersetzt die alte AnimationSettings-Klasse und bietet ein klareres Objektmodell für PowerPoint-Animationen. Eine Folie kann nur eine Animations-Zeitachse besitzen.

## **Interaktive Animation**
[EffectTriggerType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effecttriggertype/) ermöglicht es, Benutzeraktionen (z.B. einen Klick auf einen Button) zu definieren, die eine bestimmte Animation starten. Trigger wurden erst in der neuesten PowerPoint-Version hinzugefügt.

## **Formanimation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die Text, Rechtecke, Linien, Rahmen, OLE-Objekte und andere Elemente darstellen können.

{{% alert color="info" title="Note" %}}
Mehr lesen [Über Formanimation](/slides/de/python-java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, verwenden Sie dieselben Klassen wie für Formen. Allerdings ist es nur möglich, PowerPoint-Animationen auf Diagrammkategorien oder Diagrammreihen anzuwenden. Sie können auch einen Animations-Effekt auf ein Kategorie-Element oder ein Reihen-Element anwenden.

{{% alert color="info" title="Note" %}}
Mehr lesen [Über animierte Diagramme](/slides/de/python-java/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Zusätzlich zur Animation von Text können Sie auch eine Animation auf einen Absatz anwenden.

{{% alert color="info" title="Note" %}}
Mehr lesen [Über animierten Text](/slides/de/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF erhalten?**

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/python-java/slide-transition/) nicht abgespielt. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/python-java/export-to-html5/), [animiertes GIF](/slides/de/python-java/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/python-java/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und dabei Bildrate und Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [die Präsentation als Einzelbilder rendern](/slides/de/python-java/convert-powerpoint-to-video/) und diese zu einem Video (z.B. mit ffmpeg) kodieren, wobei Sie FPS und Auflösung auswählen können. Animationen und Folienübergänge werden beim Rendering abgespielt.

**Bleiben Animationen erhalten, wenn mit ODP (nicht nur PPTX) gearbeitet wird?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/python-java/open-presentation/) und [Schreiben](/slides/de/python-java/save-presentation/) unterstützt, jedoch können Formatunterschiede dazu führen, dass bestimmte Effekte leicht anders aussehen oder sich anders verhalten. Validieren Sie kritische Fälle mit echten Beispielen.