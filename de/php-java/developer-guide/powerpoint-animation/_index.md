---
title: PowerPoint-Präsentationen mit Animationen in PHP verbessern
linktitle: PowerPoint-Animation
type: docs
weight: 150
url: /de/php-java/powerpoint-animation/
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
- PHP
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für PHP via Java beim Umgang mit PowerPoint-Animationen. Schlüsselmerkmale und Einblicke zur Verbesserung Ihrer Präsentationen."
---

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten stets bei der Erstellung berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um die Präsentation für die Betrachter ansprechend und attraktiv zu gestalten. Aspose.Slides für PHP über Java bietet eine breite Palette von Optionen, um PowerPoint-Präsentationen Animationen hinzuzufügen:

- verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente anwenden.
- mehrere PowerPoint-Animationseffekte auf einer Form verwenden.
- die Animationszeitachse verwenden, um Animationseffekte zu steuern.
- benutzerdefinierte Animationen erstellen.

In Aspose.Slides für PHP über Java können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE-Objekt, Tabelle usw., als Form betrachtet wird, bedeutet dies, dass wir den Animationseffekt auf jedes Element einer Folie anwenden können.


## **Animations-Effekte**
Aspose.Slides unterstützt **mehr als 150 Animationseffekte**, darunter grundlegende Animationseffekte wie Bounce, PathFootball, Zoom‑Effekt und spezifische Animationseffekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Auflistung der Animationseffekte finden Sie in der Aufzählung **EffectType**.

Zusätzlich können diese Animationseffekte in Kombination miteinander verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen.  
Dies kann erreicht werden, indem Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[**Behavior**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) ist eine Baueinheit jedes PowerPoint-Animationseffekts. Alle Animationseffekte sind tatsächlich ein Satz von Verhaltensweisen, die zu einer Strategie zusammengefasst sind. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation kombinieren und sie anschließend in anderen Präsentationen wiederverwenden. Wenn Sie ein neues Verhalten zu einem standardmäßigen PowerPoint-Animationseffekt hinzufügen, entsteht eine weitere benutzerdefinierte Animation. Zum Beispiel können Sie ein Wiederholungsverhalten zu einer Animation hinzufügen, um sie mehrmals wiederholen zu lassen.

[**Animation Point**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) ist ein Punkt, an dem das Verhalten angewendet werden soll.

## **Animations-Zeitachse**
[**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) ist eine Sammlung von Animationseffekten, die auf eine konkrete Form angewendet werden.

[**Timeline**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) ist ein Satz von Sequenzen, der in einer konkreten Folie verwendet wird. Es ist eine Animationsengine, die seit PowerPoint 2002 bereitgestellt wird. In früheren PowerPoint-Versionen war es schwierig, einer Präsentation Animationseffekte hinzuzufügen; dies war nur mit verschiedenen Workarounds möglich. Die Timeline ersetzt die alte AnimationSettings‑Klasse und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animationszeitachse haben.

## **Interaktive Animation**
[**Trigger**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) ermöglicht die Definition von Benutzeraktionen (z. B. Klick auf einen Button), die eine bestimmte Animation starten. Trigger wurden erst in der neuesten PowerPoint‑Version hinzugefügt.

## **Form‑Animation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die tatsächlich Text, Rechteck, Linie, Rahmen, OLE‑Objekt usw. sein können.

{{% alert color="primary" %}} 
Mehr dazu [**Über Form‑Animation**](/slides/de/php-java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Es ist jedoch möglich, PowerPoint‑Animationen nur auf Diagrammkategorien oder Diagrammreihen anzuwenden. Sie können den Animationseffekt auch auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="primary" %}} 
Mehr dazu [**Über animierte Diagramme**](/slides/de/php-java/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, einen Absatz zu animieren.

{{% alert color="primary" %}} 
Mehr dazu [**Über animierten Text**](/slides/de/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF beibehalten?**

Nein. PDF ist ein statisches Format, sodass Animationen und [Folienübergänge](/slides/de/php-java/slide-transition/) nicht abgespielt werden. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/php-java/export-to-html5/), [animiertem GIF](/slides/de/php-java/convert-powerpoint-to-animated-gif/), oder [Video](/slides/de/php-java/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie die Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [rendern](/slides/de/php-java/convert-powerpoint-to-video/) und in ein Video (z. B. über ffmpeg) codieren, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden während des Renderns abgespielt.

**Bleiben Animationen beim Arbeiten mit ODP (nicht nur PPTX) erhalten?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/php-java/open-presentation/) und [Schreiben](/slides/de/php-java/save-presentation/) unterstützt, jedoch können sich Formatunterschiede auswirken, sodass bestimmte Effekte leicht anders aussehen oder sich anders verhalten. Validieren Sie kritische Fälle mit echten Beispielen.