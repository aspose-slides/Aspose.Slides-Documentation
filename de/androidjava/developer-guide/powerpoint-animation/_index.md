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
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Android via Java beim Umgang mit PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor."
---
## **Einführung**

Da Präsentationen dazu dienen, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bei der Erstellung stets berücksichtigt.

**PowerPoint‑Animation** spielt eine wichtige Rolle, um die Präsentation für die Zuschauer ansprechend und attraktiv zu machen. Aspose.Slides für Android via Java bietet eine Vielzahl von Möglichkeiten, um Animationen zu PowerPoint‑Präsentationen hinzuzufügen:

- verschiedene Arten von PowerPoint‑Animationseffekten auf Formen, Diagrammen, Tabellen, OLE‑Objekten und anderen Präsentationselementen anwenden.
- mehrere PowerPoint‑Animationseffekte auf einer Form verwenden.
- die Animations‑Timeline nutzen, um Animationseffekte zu steuern.
- benutzerdefinierte Animationen erstellen.

In Aspose.Slides für Android via Java können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE‑Objekt, Tabelle usw., als Form betrachtet wird, bedeutet das, dass wir Animationseffekte auf jedes Element einer Folie anwenden können.

## **Animationseffekte**
Aspose.Slides unterstützt **mehr als 150 Animationseffekte**, darunter grundlegende Effekte wie Bounce, PathFootball, Zoom und spezifische Effekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Auflistung der Animationseffekte finden Sie in der Enumeration [**EffectType**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effecttype/).

Zusätzlich können diese Animationseffekte in Kombination mit folgenden verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen.  
Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[**Behavior**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Behavior) ist die Baueinheit jedes PowerPoint‑Animationseffekts. Alle Animationseffekte bestehen tatsächlich aus einer Menge von Verhaltensweisen, die zu einer Strategie zusammengefasst sind. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation kombinieren und diese dann in anderen Präsentationen wiederverwenden. Wenn Sie ein neues Verhalten zu einem Standard‑PowerPoint‑Animationseffekt hinzufügen, entsteht eine weitere benutzerdefinierte Animation. Beispielsweise können Sie ein Wiederholungs‑Verhalten zu einer Animation hinzufügen, damit sie mehrmals wiederholt wird.

[**Animation Point**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Point) ist der Punkt, an dem ein Verhalten angewendet werden soll.

## **Animations‑Zeitlinie**
[**Sequence**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Sequence) ist eine Sammlung von Animationseffekten, die auf eine konkrete Form angewendet werden.

[**Timeline**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/AnimationTimeLine) ist ein Satz von Sequenzen, die in einer konkreten Folie verwendet werden. Sie ist eine Animations‑Engine, die seit PowerPoint 2002 existiert. In früheren PowerPoint‑Versionen war das Hinzufügen von Animationseffekten zur Präsentation schwierig und nur mit verschiedenen Workarounds möglich. Die Timeline ersetzt die alte Klasse AnimationSettings und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Pro Folie kann nur **eine** Animations‑Zeitlinie verwendet werden.

## **Interaktive Animation**
[**Trigger**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/EffectTriggerType) ermöglicht die Definition von Benutzeraktionen (z. B. Klick auf einen Button), die eine bestimmte Animation starten. Trigger wurden erst in der neuesten PowerPoint‑Version eingeführt.

## **Form‑Animation**
Aspose.Slides erlaubt das Anwenden von Animationen auf Formen, die tatsächlich Text, Rechtecke, Linien, Rahmen, OLE‑Objekte usw. sein können.

{{% alert color="info" %}} 
Mehr erfahren [**Über Shape Animation**](/slides/de/androidjava/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Es ist jedoch nur möglich, PowerPoint‑Animationen auf Diagrammkategorien oder Diagrammreihen anzuwenden. Sie können den Animationseffekt auch auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="info" %}} 
Mehr erfahren [**Über Animated Charts**](/slides/de/androidjava/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, Animationen auf einen Absatz anzuwenden.

{{% alert color="info" %}} 
Mehr erfahren [**Über Animated Text**](/slides/de/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

### Werden Animationen beim Exportieren nach PDF beibehalten?

Nein. PDF ist ein statisches Format, sodass Animationen und [Folienübergänge](/slides/de/androidjava/slide-transition/) nicht abgespielt werden. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen nach [HTML5](/slides/de/androidjava/export-to-html5/), [animiertem GIF](/slides/de/androidjava/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/androidjava/convert-powerpoint-to-video/).

### Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie Bildgröße steuern?

Ja. Sie können die Präsentation als Einzelbilder [rendern](/slides/de/androidjava/convert-powerpoint-to-video/) und diese dann mit einem Encoder (z. B. ffmpeg) zu einem Video zusammenfügen, wobei Sie FPS und Auflösung auswählen. Animationen und Folienübergänge werden während des Renderns abgespielt.

### Bleiben Animationen bei der Arbeit mit ODP (nicht nur PPTX) erhalten?

PPT, PPTX und ODP werden für das [Lesen](/slides/de/androidjava/open-presentation/) und [Schreiben](/slides/de/androidjava/save-presentation/) unterstützt, aber aufgrund von Formatunterschieden können bestimmte Effekte leicht unterschiedlich aussehen oder sich verhalten. Validieren Sie kritische Fälle mit echten Beispielen.