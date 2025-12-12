---
title: PowerPoint-Präsentationen mit Animationen unter Android verbessern
linktitle: PowerPoint-Animation
type: docs
weight: 150
url: /de/androidjava/powerpoint-animation/
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
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Android via Java beim Umgang mit PowerPoint‑Animationen. Dieser allgemeine Überblick hebt die wichtigsten Funktionen hervor."
---

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten beim Erstellen immer berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um die Präsentation für die Zuschauer ansprechend und attraktiv zu gestalten. Aspose.Slides for Android via Java bietet eine Vielzahl von Optionen, um Animationen zu PowerPoint‑Präsentationen hinzuzufügen:

- verschiedene Arten von PowerPoint‑Animationseffekten auf Formen, Diagramme, Tabellen, OLE‑Objekte und andere Präsentationselemente anwenden.
- mehrere PowerPoint‑Animationseffekte auf einer Form verwenden.
- die Animationszeitlinie verwenden, um Animationseffekte zu steuern.
- benutzerdefinierte Animationen erstellen.

In Aspose.Slides for Android via Java können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bildern, OLE‑Objekten, Tabellen usw., als Form betrachtet wird, bedeutet das, dass wir Animationseffekte auf jedes Element einer Folie anwenden können.

## **Animationseffekte**
Aspose.Slides unterstützt **150+ Animationseffekte**, darunter grundlegende Animationseffekte wie Bounce, PathFootball, Zoom‑Effekt und spezifische Animationseffekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Auflistung der Animationseffekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype/)‑Aufzählung.

Zusätzlich können diese Animationseffekte in Kombination miteinander verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, wenn Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) ist eine Baueinheit jedes PowerPoint‑Animationseffekts. Alle Animationseffekte sind im Grunde eine Sammlung von Verhaltensweisen, die zu einer Strategie kombiniert werden. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation kombinieren und diese in anderen Präsentationen wiederverwenden. Wenn Sie eine neue Verhaltensweise zu einem Standard‑PowerPoint‑Animationseffekt hinzufügen, entsteht eine weitere benutzerdefinierte Animation. Zum Beispiel können Sie einer Animation eine Wiederholungs‑Verhaltensweise hinzufügen, damit sie einige Male wiederholt wird.

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) ist ein Punkt, an dem die Verhaltensweise angewendet werden soll.

## **Animationszeitlinie**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) ist eine Sammlung von Animationseffekten, die auf einer konkreten Form angewendet werden.

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) ist eine Menge von Sequenzen, die in einer konkreten Folie verwendet werden. Es ist eine Animations‑Engine, die seit PowerPoint 2002 vorhanden ist. In früheren PowerPoint‑Versionen war es schwierig, Animationseffekte zur Präsentation hinzuzufügen; dies war nur mit verschiedenen Umwegen möglich. Die Timeline ersetzt die alte AnimationSettings‑Klasse und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animationszeitlinie haben.

## **Interaktive Animation**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) ermöglicht das Definieren von Benutzeraktionen (z. B. Mausklick), die eine bestimmte Animation starten. Trigger wurden erst in der neuesten PowerPoint‑Version hinzugefügt.

## **Formanimation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die tatsächlich Text, Rechtecke, Linien, Rahmen, OLE‑Objekte usw. sein können.

{{% alert color="primary" %}} 
Mehr lesen [**About Shape Animation**](/slides/de/androidjava/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Allerdings ist es möglich, PowerPoint‑Animationen nur auf Diagrammkategorien oder Diagrammreihen anzuwenden. Sie können den Animationseffekt auch auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="primary" %}} 
Mehr lesen [**About Animated Charts**](/slides/de/androidjava/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, eine Animation auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Mehr lesen [**About Animated Text**](/slides/de/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren nach PDF beibehalten?**

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/androidjava/slide-transition/) nicht abgespielt. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/androidjava/export-to-html5/), [animiertes GIF](/slides/de/androidjava/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/androidjava/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und Bildrate sowie Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [rendern](/slides/de/androidjava/convert-powerpoint-to-video/) und sie in ein Video kodieren (z. B. über ffmpeg), wobei Sie FPS und Auflösung auswählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

**Bleiben Animationen beim Arbeiten mit ODP (nicht nur PPTX) unverändert?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/androidjava/open-presentation/) und [Schreiben](/slides/de/androidjava/save-presentation/) unterstützt, jedoch können Formatunterschiede dazu führen, dass bestimmte Effekte leicht anders aussehen oder sich anders verhalten. Validieren Sie kritische Fälle mit echten Beispielen.