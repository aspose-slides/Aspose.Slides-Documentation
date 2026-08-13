---
title: PowerPoint-Präsentationen mit Animationen in Java verbessern
linktitle: PowerPoint-Animation
type: docs
weight: 150
url: /de/java/powerpoint-animation/
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
- Formanimation
- Animiertes Diagramm
- Animierter Text
- Animierte Form
- Animiertes OLE-Objekt
- Animiertes Bild
- Animierte Tabelle
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Java bei der Behandlung von PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor und bietet Einblicke, um Ihre Präsentationen zu verbessern."
---
## **Einführung**

Da Präsentationen dazu gedacht sind, etwas darzustellen, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bereits bei der Erstellung berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle dabei, eine Präsentation auffällig und ansprechend für die Zuschauer zu gestalten. Aspose.Slides bietet eine breite Palette von Optionen, um PowerPoint-Präsentationen Animationen hinzuzufügen:

- Wenden Sie verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente an.
- Verwenden Sie mehrere PowerPoint-Animationseffekte auf einer einzelnen Form.
- Nutzen Sie die Animationszeitleiste, um Animationseffekte zu steuern.
- Erstellen Sie benutzerdefinierte Animationen.

## **Animationseffekte**
Aspose.Slides unterstützt **mehr als 150 Animationseffekte**, einschließlich grundlegender Effekte wie Bounce, PathFootball, Zoom‑Effekt und spezifischer Effekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Auflistung der Animationseffekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/de/java/com.aspose.slides/effecttype/) Aufzählung.

Zusätzlich können diese Animationseffekte in Kombination miteinander verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. 
Dies kann erreicht werden, indem Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[**Behavior**](https://reference.aspose.com/slides/de/java/com.aspose.slides/Behavior) ist eine Baueinheit jedes PowerPoint-Animationseffekts. Alle Animationseffekte bestehen tatsächlich aus einer Menge von Verhaltensweisen, die zu einer Strategie kombiniert werden. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation kombinieren und diese in anderen Präsentationen wiederverwenden. Wenn Sie einer Standard‑PowerPoint-Animation ein neues Verhalten hinzufügen, entsteht eine weitere benutzerdefinierte Animation. Beispielweise können Sie ein Wiederholungsverhalten zu einer Animation hinzufügen, damit sie mehrmals abspielt.

[**Animation Point**](https://reference.aspose.com/slides/de/java/com.aspose.slides/Point) ist ein Punkt, an dem das Verhalten angewendet werden soll.

## **Animationszeitlinie**
[**Sequence**](https://reference.aspose.com/slides/de/java/com.aspose.slides/Sequence) ist eine Sammlung von Animationseffekten, die auf eine konkrete Form angewendet werden.

[**Timeline**](https://reference.aspose.com/slides/de/java/com.aspose.slides/AnimationTimeLine) ist eine Menge von Sequenzen, die in einer konkreten Folie verwendet werden. Es ist eine Animations‑Engine, die seit PowerPoint 2002 verfügbar ist. In früheren PowerPoint‑Versionen war es schwierig, Animationseffekte zur Präsentation hinzuzufügen; dies war nur mit verschiedenen Workarounds möglich. Die Zeitleiste ersetzt die alte AnimationSettings‑Klasse und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animationszeitleiste haben.

## **Interaktive Animation**
[**Trigger**](https://reference.aspose.com/slides/de/java/com.aspose.slides/EffectTriggerType) ermöglicht die Definition von Benutzeraktionen (z. B. Klick auf einen Button), die eine bestimmte Animation starten. Trigger wurden nur in der neuesten PowerPoint‑Version hinzugefügt.

## **Formanimation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die tatsächlich Text, Rechteck, Linie, Rahmen, OLE‑Objekt usw. sein können.

{{% alert color="info" %}} 
Mehr dazu [**Über Formanimation**](/slides/de/java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Es ist jedoch möglich, PowerPoint‑Animationen nur auf Diagrammkategorien oder Diagrammreihen anzuwenden. Sie können den Animationseffekt auch auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="info" %}} 
Mehr dazu [**Über animierte Diagramme**](/slides/de/java/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, eine Animation auf einen Absatz anzuwenden.

{{% alert color="info" %}} 
Mehr dazu [**Über animierten Text**](/slides/de/java/animated-text/).
{{% /alert %}}

## **FAQ**

### Bleiben Animationen beim Exportieren nach PDF erhalten?
Nein. PDF ist ein statisches Format, sodass Animationen und [Folienübergänge](/slides/de/java/slide-transition/) nicht abgespielt werden. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/java/export-to-html5/), [animated GIF](/slides/de/java/convert-powerpoint-to-animated-gif/) oder [video](/slides/de/java/convert-powerpoint-to-video/).

### Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie die Bildgröße steuern?
Ja. Sie können die Präsentation als Einzelbilder [rendern](/slides/de/java/convert-powerpoint-to-video/) und diese zu einem Video (z. B. mit ffmpeg) kodieren, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

### Bleiben Animationen bei der Arbeit mit ODP (nicht nur PPTX) erhalten?
PPT, PPTX und ODP werden für das [Lesen](/slides/de/java/open-presentation/) und [Schreiben](/slides/de/java/save-presentation/) unterstützt, aber Formatunterschiede können dazu führen, dass bestimmte Effekte leicht abweichend aussehen oder sich verhalten. Überprüfen Sie kritische Fälle mit echten Beispielen.