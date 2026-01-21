---
title: PowerPoint-Präsentationen mit Animationen in C++ verbessern
linktitle: PowerPoint-Animation
type: docs
weight: 150
url: /de/cpp/powerpoint-animation/
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
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie erweiterte Animationseffekte in Aspose.Slides für C++ hinzufügen und steuern, um dynamische PowerPoint- und OpenDocument-Präsentationen zu erstellen."
---

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten stets bei der Erstellung berücksichtigt.

**PowerPoint animation** spielt eine wichtige Rolle, um Präsentationen ansprechend und attraktiv für die Betrachter zu machen. Aspose.Slides for C++ bietet eine Vielzahl von Optionen, um einer PowerPoint‑Präsentation Animationen hinzuzufügen:

- verschiedene Arten von PowerPoint‑Animationseffekten auf Formen, Diagramme, Tabellen, OLE‑Objekte und andere Präsentationselemente anwenden.
- mehrere PowerPoint‑Animationseffekte auf einer Form verwenden.
- die Animations‑Zeitlinie verwenden, um Animations‑Effekte zu steuern.
- benutzerdefinierte Animationen erstellen.

In Aspose.Slides for C++ können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE‑Objekt, Tabelle usw., als Form betrachtet wird, bedeutet dies, dass wir den Animationseffekt auf jedes Element einer Folie anwenden können.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **Namespace** stellt Klassen zur Arbeit mit PowerPoint‑Animationen bereit.

## **Animations‑Effekte**
Aspose.Slides unterstützt **mehr als 150 Animationseffekte**, darunter Grundanimationseffekte wie Bounce, PathFootball, Zoom‑Effekt und spezifische Animationseffekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Liste der Animationseffekte finden Sie in der Aufzählung [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Zusätzlich können diese Animationseffekte in Kombination miteinander verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) ist Baustein jeder PowerPoint‑Animation. Alle Animationseffekte bestehen eigentlich aus einer Menge von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation kombinieren und diese dann in anderen Präsentationen wiederverwenden. Wenn Sie eine neue Verhaltensweise in einen Standard‑PowerPoint‑Animationseffekt einfügen, entsteht eine weitere benutzerdefinierte Animation. Zum Beispiel können Sie einer Animation ein Wiederholungs‑Verhalten hinzufügen, damit sie mehrmals wiederholt wird.

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) ist ein Punkt, an dem das Verhalten angewendet werden soll.

## **Animations‑Zeitlinie**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) ist eine Sammlung von Animationseffekten, die auf eine konkrete Form angewendet werden.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) ist ein Satz von Sequenzen, die in einer konkreten Folie verwendet werden. Es ist eine Animations‑Engine, die seit PowerPoint 2002 existiert. In früheren PowerPoint‑Versionen war es schwierig, Animationseffekte zur Präsentation hinzuzufügen, was nur mit verschiedenen Workarounds möglich war. Die Zeitlinie ersetzt die alte AnimationSettings‑Klasse und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animations‑Zeitlinie enthalten.

## **Interaktive Animation**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) ermöglicht es, Benutzeraktionen (z. B. Button‑Klick) zu definieren, die eine bestimmte Animation starten. Trigger wurden erst in der neuesten PowerPoint‑Version hinzugefügt.

## **Form‑Animation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die tatsächlich Text, Rechteck, Linie, Rahmen, OLE‑Objekt usw. sein können.

{{% alert color="primary" %}} 
Mehr erfahren [**Über Shape Animation**](/slides/de/cpp/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Es ist jedoch möglich, PowerPoint‑Animationen nur auf Diagrammkategorien oder Diagrammreihen anzuwenden. Sie können auch einen Animationseffekt auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="primary" %}} 
Mehr erfahren [**Über animierte Diagramme**](/slides/de/cpp/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, einem Absatz eine Animation hinzuzufügen.

{{% alert color="primary" %}} 
Mehr erfahren [**Über animierten Text**](/slides/de/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Export in PDF beibehalten?**

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/cpp/slide-transition/) nicht abgespielt. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/cpp/export-to-html5/), [animiertem GIF](/slides/de/cpp/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/cpp/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie die Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [rendern](/slides/de/cpp/convert-powerpoint-to-video/) und diese zu einem Video (z. B. mit ffmpeg) kodieren, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

**Bleiben Animationen beim Arbeiten mit ODP (nicht nur PPTX) erhalten?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/cpp/open-presentation/) und [Schreiben](/slides/de/cpp/save-presentation/) unterstützt, jedoch können Formatunterschiede dazu führen, dass bestimmte Effekte leicht anders aussehen oder sich anders verhalten. Validieren Sie kritische Fälle mit echten Beispielen.