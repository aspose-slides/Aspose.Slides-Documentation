---
title: "PowerPoint-Präsentationen mit Animationen in C++ verbessern"
linktitle: "PowerPoint-Animation"
type: docs
weight: 150
url: /de/cpp/powerpoint-animation/
keywords:
- "Animation hinzufügen"
- "Animation aktualisieren"
- "Animation ändern"
- "Animation entfernen"
- "Animation verwalten"
- "Animation steuern"
- "Animationseffekt"
- "PowerPoint-Animation"
- "Animationszeitleiste"
- "interaktive Animation"
- "benutzerdefinierte Animation"
- "Formanimation"
- "animiertes Diagramm"
- "animierter Text"
- "animierte Form"
- "animiertes OLE-Objekt"
- "animiertes Bild"
- "animierte Tabelle"
- "PowerPoint"
- "Präsentation"
- "C++"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie erweiterte Animationseffekte in Aspose.Slides für C++ hinzufügen und steuern, um dynamische PowerPoint- und OpenDocument-Präsentationen zu erstellen."
---
## **Einleitung**

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten stets beim Erstellen berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um Präsentationen für die Betrachter auffällig und attraktiv zu gestalten. Aspose.Slides for C++ bietet eine breite Palette von Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente anwenden.
- mehrere PowerPoint-Animationseffekte auf einer Form verwenden.
- die Animationszeitleiste verwenden, um Animations-Effekte zu steuern.
- benutzerdefinierte Animation erstellen.

In Aspose.Slides for C++ können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bildern, OLE-Objekt, Tabelle usw., als Form betrachtet wird, bedeutet dies, dass wir Animations-Effekte auf jedes Element einer Folie anwenden können.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/de/cpp/namespace/aspose.slides.animation) **namespace** stellt Klassen zur Arbeit mit PowerPoint-Animationen bereit.
## **Animations-Effekte**
Aspose.Slides unterstützt **150+ Animationseffekte**, darunter grundlegende Effekte wie Bounce, PathFootball, Zoom-Effekt und spezifische Effekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Auflistung der Animationseffekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/de/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31)‑Aufzählung.

Zusätzlich können diese Animations‑Effekte in Kombination miteinander verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.set_effect)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, wenn Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[**Behavior**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.behavior) ist die Baueinheit jedes PowerPoint-Animationseffekts. Alle Animationseffekte bestehen tatsächlich aus einer Menge von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen einmal zu einer benutzerdefinierten Animation kombinieren und sie in anderen Präsentationen wiederverwenden. Wenn Sie einer Standard-PowerPoint-Animation ein neues Verhalten hinzufügen, entsteht eine weitere benutzerdefinierte Animation. Beispielsweise können Sie ein Wiederholungs-Verhalten zu einer Animation hinzufügen, um sie mehrmals wiederholen zu lassen.

[**Animation Point**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.point) ist ein Punkt, an dem das Verhalten angewendet werden soll.

## **Animationszeitlinie**
[**Sequence**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.sequence) ist eine Sammlung von Animationseffekten, die auf eine konkrete Form angewendet werden.

[**AnimationTimeLine**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.animation_time_line) ist eine Menge von Sequenzen, die in einer konkreten Folie verwendet werden. Es ist eine Animations-Engine, die seit PowerPoint 2002 existiert. In früheren PowerPoint-Versionen war es schwierig, Animations-Effekte zur Präsentation hinzuzufügen, was nur mit verschiedenen Umgehungslösungen möglich war. Die Zeitleiste ersetzt die alte AnimationSettings-Klasse und bietet ein klareres Objektmodell für PowerPoint-Animationen. Eine Folie kann nur eine Animations-Zeitleiste besitzen.

## **Interaktive Animation**
[**EffectTriggerType**](https://reference.aspose.com/slides/de/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) ermöglicht die Definition von Benutzeraktionen (z. B. Klick auf einen Button), die eine bestimmte Animation starten. Trigger wurden nur in der neuesten PowerPoint-Version hinzugefügt.

## **Formanimation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die tatsächlich Text, Rechteck, Linie, Rahmen, OLE-Objekt usw. sein können.

{{% alert color="info" %}} 
Mehr lesen [**Über Formanimation**](/slides/de/cpp/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Es ist jedoch nur möglich, PowerPoint-Animationen auf Diagrammkategorien oder Diagrammreihen anzuwenden. Sie können den Animationseffekt auch auf ein Kategorie-Element oder ein Reihen-Element anwenden.

{{% alert color="info" %}} 
Mehr lesen [**Über animierte Diagramme**](/slides/de/cpp/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, eine Animation auf einen Absatz anzuwenden.

{{% alert color="info" %}} 
Mehr lesen [**Über animierten Text**](/slides/de/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

### Werden Animationen beim Exportieren in PDF erhalten?

Nein. PDF ist ein statisches Format, sodass Animationen und [Folienübergänge](/slides/de/cpp/slide-transition/) nicht abgespielt werden. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/cpp/export-to-html5/), [animierten GIF](/slides/de/cpp/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/cpp/convert-powerpoint-to-video/).

### Kann ich eine animierte Präsentation in ein Video umwandeln und Bildrate sowie Bildgröße steuern?

Ja. Sie können die Präsentation als Einzelbilder [die Präsentation als Einzelbilder rendern](/slides/de/cpp/convert-powerpoint-to-video/) und diese mit einem Video (z. B. über ffmpeg) codieren, wobei Sie Bildrate und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern wiedergegeben.

### Bleiben Animationen beim Arbeiten mit ODP (nicht nur PPTX) erhalten?

PPT, PPTX und ODP werden für das [Lesen](/slides/de/cpp/open-presentation/) und [Schreiben](/slides/de/cpp/save-presentation/) unterstützt, jedoch können Formatunterschiede dazu führen, dass bestimmte Effekte leicht anders aussehen oder sich anders verhalten. Validieren Sie kritische Fälle mit echten Beispielen.