---
title: Verbessern Sie PowerPoint-Präsentationen mit Animationen auf Android
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
- Animationszeitleiste
- interaktive Animation
- benutzerdefinierte Animation
- Formanimation
- animierte Diagramme
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
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Android via Java im Umgang mit PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor."
---

Da Präsentationen dazu bestimmt sind, etwas zu zeigen, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten beim Erstellen stets berücksichtigt.

**PowerPoint animation** spielt eine wichtige Rolle, um Präsentationen für die Zuschauer ansprechend und attraktiv zu gestalten. Aspose.Slides für Android via Java bietet eine Vielzahl von Optionen, um Animationen zu PowerPoint‑Präsentationen hinzuzufügen:

- verschiedene Arten von PowerPoint‑Animationseffekten auf Formen, Diagramme, Tabellen, OLE‑Objekte und andere Präsentationselemente anwenden.
- mehrere PowerPoint‑Animationseffekte auf einer Form verwenden.
- die Animations‑Zeitleiste nutzen, um Animations‑effekte zu steuern.
- benutzerdefinierte Animationen erstellen.

In Aspose.Slides für Android via Java können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE‑Objekt, Tabelle usw., als Form betrachtet wird, bedeutet dies, dass wir den Animationseffekt auf jedes Element einer Folie anwenden können.

## **Animationseffekte**
Aspose.Slides unterstützt **150+ Animationseffekte**, darunter grundlegende Effekte wie Bounce, PathFootball, Zoom‑Effekt sowie spezifische Effekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Auflistung der Animationseffekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype/) Aufzählung.

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
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) ist eine Baueinheit jedes PowerPoint‑Animationseffekts. Alle Animationseffekte bestehen eigentlich aus einer Menge von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation kombinieren und sie anschließend in anderen Präsentationen wiederverwenden. Wenn Sie einer Standard‑PowerPoint‑Animation ein neues Verhalten hinzufügen, entsteht eine weitere benutzerdefinierte Animation. Beispielsweise können Sie einer Animation ein Wiederholungs‑Verhalten hinzufügen, sodass sie mehrmals abgespielt wird.

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) ist ein Punkt, an dem das Verhalten angewendet werden soll.

## **Animationszeitlinie**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) ist eine Sammlung von Animationseffekten, die auf einer konkreten Form angewendet werden.

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) ist ein Satz von Sequenzen, die in einer konkreten Folie verwendet werden. Es ist eine Animations‑Engine, die seit PowerPoint 2002 verfügbar ist. In früheren PowerPoint‑Versionen war das Hinzufügen von Animationseffekten zur Präsentation schwierig und nur mit verschiedenen Workarounds möglich. Die Zeitleiste ersetzt die alte Klasse AnimationSettings und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animations‑Zeitleiste besitzen.

## **Interaktive Animation**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) ermöglicht das Definieren von Benutzeraktionen (z. B. Klick auf einen Button), die eine bestimmte Animation starten. Trigger wurden erst in der neuesten PowerPoint‑Version hinzugefügt.

## **Formanimation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die tatsächlich Text, Rechteck, Linie, Rahmen, OLE‑Objekt usw. sein können.

{{% alert color="primary" %}} 
Mehr dazu [**Über Formanimation**](/slides/de/androidjava/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Es ist jedoch möglich, PowerPoint‑Animationen nur auf Diagrammkategorien oder Diagrammserien anzuwenden. Sie können den Animationseffekt auch auf ein Kategorie‑Element oder ein Serien‑Element anwenden.

{{% alert color="primary" %}} 
Mehr dazu [**Über animierte Diagramme**](/slides/de/androidjava/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, eine Animation auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Mehr dazu [**Über animierten Text**](/slides/de/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF beibehalten?**

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/androidjava/slide-transition/) nicht abgespielt. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/androidjava/export-to-html5/), [animiertes GIF](/slides/de/androidjava/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/androidjava/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie die Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [die Präsentation als Einzelbilder rendern](/slides/de/androidjava/convert-powerpoint-to-video/) und mit einem Video (z. B. über ffmpeg) kodieren, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden während des Renderns abgespielt.

**Bleiben Animationen beim Arbeiten mit ODP (nicht nur PPTX) erhalten?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/androidjava/open-presentation/) und [Schreiben](/slides/de/androidjava/save-presentation/) unterstützt, jedoch können sich aufgrund von Formatunterschieden einige Effekte leicht anders darstellen oder verhalten. Prüfen Sie kritische Fälle mit realen Beispielen.