---
title: PowerPoint-Animation
type: docs
weight: 150
url: /de/nodejs-java/powerpoint-animation/
keywords: "PowerPoint-Animation"
description: "PowerPoint-Animation, PowerPoint-Folienanimation mit Aspose.Slides."
---

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten beim Erstellen stets berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um die Präsentation für die Zuschauer ansprechend und attraktiv zu machen. Aspose.Slides für Node.js über Java bietet eine breite Palette von Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente anwenden.
- mehrere PowerPoint-Animationseffekte auf einer Form verwenden.
- die Animationszeitleiste verwenden, um Animationseffekte zu steuern.
- benutzerdefinierte Animationen erstellen.

In Aspose.Slides für Node.js über Java können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE-Objekt, Tabelle usw., als Form betrachtet wird, bedeutet das, dass wir Animationseffekte auf jedes Element einer Folie anwenden können.

## **Animations‑Effekte**
Aspose.Slides unterstützt **150+ Animationseffekte**, darunter Grundanimationseffekte wie Bounce, PathFootball, Zoom‑Effekt und spezifische Animationseffekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Auflistung der Animationseffekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype/)‑Aufzählung.

Zusätzlich können diese Animationseffekte in Kombination damit verwendet werden:
- [ColorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem man mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert.

[**Behavior**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Behavior) ist eine Baueinheit jedes PowerPoint-Animationseffekts. Alle Animationseffekte sind tatsächlich ein Satz von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen einmal zu einer benutzerdefinierten Animation kombinieren und sie in anderen Präsentationen wiederverwenden. Wenn Sie ein neues Verhalten in einen Standard‑PowerPoint-Animationseffekt einfügen, entsteht eine weitere benutzerdefinierte Animation. Zum Beispiel können Sie ein Wiederholungs‑Verhalten zu einer Animation hinzufügen, damit sie mehrmals wiederholt wird.

[**Animation Point**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Point) ist ein Punkt, an dem das Verhalten angewendet werden soll.

## **Animations‑Zeitlinie**
[**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) ist eine Sammlung von Animationseffekten, die auf eine konkrete Form angewendet werden.

[**Timeline**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AnimationTimeLine) ist ein Satz von Sequenzen, die in einer konkreten Folie verwendet werden. Es ist eine Animations-Engine, die seit PowerPoint 2002 verfügbar ist. In früheren PowerPoint‑Versionen war es schwierig, Animationseffekte zu einer Präsentation hinzuzufügen; dies war nur mit verschiedenen Workarounds möglich. Die Timeline ersetzt die alte AnimationSettings‑Klasse und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animations‑Zeitlinie haben.

## **Interaktive Animation**
[**Trigger**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectTriggerType) ermöglicht das Definieren von Benutzeraktionen (z. B. Klick auf einen Button), die eine bestimmte Animation starten. Trigger wurden erst in der neuesten PowerPoint‑Version hinzugefügt.

## **Form‑Animation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die tatsächlich Text, Rechteck, Linie, Rahmen, OLE‑Objekt usw. sein können.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über Form‑Animation**](/slides/de/nodejs-java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Es ist jedoch möglich, PowerPoint‑Animationen nur auf Diagrammkategorien oder Diagrammreihen anzuwenden. Sie können den Animationseffekt auch auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über animierte Diagramme**](/slides/de/nodejs-java/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, eine Animation auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über animierten Text**](/slides/de/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren nach PDF erhalten?**

Nein. PDF ist ein statisches Format, sodass Animationen und [Folienübergänge](/slides/de/nodejs-java/slide-transition/) nicht abgespielt werden. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/nodejs-java/export-to-html5/), [animiertem GIF](/slides/de/nodejs-java/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/nodejs-java/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und Bildrate sowie Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [rendern](/slides/de/nodejs-java/convert-powerpoint-to-video/) und diese mit einem Video (z. B. über ffmpeg) kodieren, wobei Sie Bildrate und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

**Bleiben Animationen erhalten, wenn mit ODP (nicht nur PPTX) gearbeitet wird?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/nodejs-java/open-presentation/) und [Schreiben](/slides/de/nodejs-java/save-presentation/) unterstützt, jedoch können aufgrund von Formatunterschieden bestimmte Effekte leicht anders aussehen oder sich anders verhalten. Validieren Sie kritische Fälle mit echten Beispielen.