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
- Java
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Java im Umgang mit PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor und bietet Einblicke, um Ihre Präsentationen zu verbessern."
---

## **Übersicht**

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, wird ihr visuelles Erscheinungsbild und ihr interaktives Verhalten stets bei der Erstellung berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um die Präsentation ansprechend und attraktiv für die Betrachter zu machen. Aspose.Slides for Java bietet eine breite Palette von Optionen, um einer PowerPoint-Präsentation Animationen hinzuzufügen:

- verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagrammen, Tabellen, OLE‑Objekten und anderen Präsentationselementen anwenden.
- mehrere PowerPoint-Animationseffekte auf einer Form verwenden.
- die Animationszeitachse verwenden, um Animations‑Effekte zu steuern.
- benutzerdefinierte Animationen erstellen.

In Aspose.Slides for Java können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE‑Objekt, Tabelle usw., als Form betrachtet wird, bedeutet dies, dass wir Animations‑Effekte auf jedes Element einer Folie anwenden können.

## **Animations‑Effekte**

Aspose.Slides unterstützt **150+ Animationseffekte**, darunter grundlegende Animationseffekte wie Bounce, PathFootball, Zoom‑Effekt und spezifische Animationseffekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Auflistung der Animationseffekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype/)-Aufzählung.

Zusätzlich können diese Animationseffekte in Kombination miteinander verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/java/com.aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**

Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[**Behavior**](https://reference.aspose.com/slides/java/com.aspose.slides/Behavior) ist eine Baueinheit jedes PowerPoint‑Animationseffekts. Alle Animationseffekte bestehen tatsächlich aus einer Menge von Verhaltensweisen, die zu einer Strategie zusammengesetzt werden. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation kombinieren und diese einmal erstellen und in anderen Präsentationen wiederverwenden. Wenn Sie eine neue Verhaltensweise zu einem standardmäßigen PowerPoint‑Animationseffekt hinzufügen, entsteht eine weitere benutzerdefinierte Animation. Beispielsweise können Sie einer Animation eine Wiederholungs‑Verhaltensweise hinzufügen, damit sie mehrmals wiederholt wird.

[**Animation Point**](https://reference.aspose.com/slides/java/com.aspose.slides/Point) ist ein Punkt, an dem die Verhaltensweise angewendet werden soll.

## **Animations‑Zeitachse**

[**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) ist eine Sammlung von Animationseffekten, die auf eine konkrete Form angewendet werden.

[**Timeline**](https://reference.aspose.com/slides/java/com.aspose.slides/AnimationTimeLine) ist ein Satz von Sequenzen, die in einer konkreten Folie verwendet werden. Es ist eine Animations‑Engine, die seit PowerPoint 2002 verfügbar ist. In früheren PowerPoint‑Versionen war es schwierig, Animationseffekte zur Präsentation hinzuzufügen, was nur mit verschiedenen Umgehungen möglich war. Die Timeline ersetzt die alte AnimationSettings‑Klasse und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animations‑Zeitachse besitzen.

## **Interaktive Animation**

[**Trigger**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectTriggerType) ermöglicht das Definieren von Benutzeraktionen (z.B. Klick auf einen Button), die eine bestimmte Animation starten. Trigger wurden erst in der neuesten PowerPoint‑Version hinzugefügt.

## **Form‑Animation**

Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die tatsächlich Text, Rechteck, Linie, Rahmen, OLE‑Objekt usw. sein können.

{{% alert color="primary" %}} 
Mehr lesen [**Über Shape Animation**](/slides/de/java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**

Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Allerdings ist es möglich, PowerPoint‑Animationen nur auf Diagrammkategorien oder Diagrammserien anzuwenden. Sie können den Animationseffekt auch auf ein Kategorie‑Element oder ein Serien‑Element anwenden.

{{% alert color="primary" %}} 
Mehr lesen [**Über animierte Diagramme**](/slides/de/java/animated-charts/).
{{% /alert %}}

## **Animierter Text**

Neben animiertem Text ist es auch möglich, eine Animation auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Mehr lesen [**Über animierten Text**](/slides/de/java/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF erhalten?**

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/java/slide-transition/) nicht abgespielt. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/java/export-to-html5/), [animiertem GIF](/slides/de/java/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/java/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie die Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [die Präsentation als Einzelbilder rendern](/slides/de/java/convert-powerpoint-to-video/) und diese mit einem Video kodieren (z.B. via ffmpeg), wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

**Bleiben Animationen beim Arbeiten mit ODP (nicht nur PPTX) erhalten?**

PPT, PPTX und ODP werden zum [Lesen](/slides/de/java/open-presentation/) und [Schreiben](/slides/de/java/save-presentation/) unterstützt, jedoch können Formatunterschiede dazu führen, dass bestimmte Effekte leicht anders aussehen oder sich anders verhalten. Validieren Sie kritische Fälle mit echten Beispielen.