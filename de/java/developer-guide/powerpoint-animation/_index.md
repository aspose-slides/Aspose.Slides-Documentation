---
title: PowerPoint-Präsentationen in Java mit Animationen verbessern
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
- Java
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Java zur Verarbeitung von PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor und bietet Einblicke, um Ihre Präsentationen zu verbessern."
---
## **Einleitung**

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bei der Erstellung stets berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um eine Präsentation ansprechend und fesselnd für die Betrachter zu gestalten. Aspose.Slides bietet eine Vielzahl von Möglichkeiten, Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- Wenden Sie verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente an.
- Verwenden Sie mehrere PowerPoint-Animationseffekte auf einer einzigen Form.
- Nutzen Sie die Animationszeitleiste, um Animationseffekte zu steuern.
- Erstellen Sie benutzerdefinierte Animationen.

## **Animationseffekte**
Aspose.Slides unterstützt **mehr als 150 Animationseffekte**, darunter Basis‑Effekte wie Bounce, PathFootball und Zoom sowie spezifische Effekte wie OLEObjectShow und OLEObjectOpen. Eine vollständige Auflistung finden Sie in der Klasse [EffectType](https://reference.aspose.com/slides/de/java/com.aspose.slides/effecttype/).

Zusätzlich können diese Animationseffekte in Kombination mit den folgenden Verhaltensweisen verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**
Für vollständige Java‑Beispiele, die Verhaltensweisen und bearbeitbare Bewegungspfade erstellen, untersuchen und ändern, siehe [Benutzerdefinierte Animation](/slides/de/java/custom-animation/).

Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[Behavior](https://reference.aspose.com/slides/de/java/com.aspose.slides/behavior/) ist ein Baustein eines PowerPoint‑Animationseffekts. Kombinieren Sie Verhaltensweisen, um einen Effekt anzupassen, oder fügen Sie eine Verhaltensweise hinzu, um einen vordefinierten Effekt zu erweitern. Wiederholungen werden über Zeiteinstellungen konfiguriert und nicht über eine separate Wiederholungs‑Verhaltensweise.

[Animation Point](https://reference.aspose.com/slides/de/java/com.aspose.slides/point/) ist ein Punkt, an dem eine Verhaltensweise angewendet werden soll.

## **Animationszeitleiste**
[Sequence](https://reference.aspose.com/slides/de/java/com.aspose.slides/sequence/) ist eine Sammlung von Animationseffekten, die auf verschiedene Formen abzielen können.

[Timeline](https://reference.aspose.com/slides/de/java/com.aspose.slides/animationtimeline/) ist ein Satz von Sequenzen, der in einer bestimmten Folie verwendet wird. Es ist eine Animations‑Engine, die in PowerPoint 2002 eingeführt wurde. In früheren Versionen von PowerPoint war das Hinzufügen von Animationseffekten zu Präsentationen schwierig und nur mit verschiedenen Umgehungen möglich. Die Zeitleiste bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animationszeitleiste besitzen.

## **Interaktive Animation**
[Trigger](https://reference.aspose.com/slides/de/java/com.aspose.slides/effecttriggertype/) ermöglicht es, Benutzeraktionen wie einen Button‑Klick zu definieren, die eine bestimmte Animation starten.

## **Formanimation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und mehr umfassen können.

{{% alert color="info" title="Hinweis" %}}
Mehr erfahren [**Über Formanimation**](/slides/de/java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Allerdings können PowerPoint‑Animationen nur auf Diagrammkategorien oder Diagrammreihen angewendet werden. Sie können Animationseffekte auch auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="info" title="Hinweis" %}}
Mehr erfahren [**Über animierte Diagramme**](/slides/de/java/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Zusätzlich zum Animieren von Text können Sie eine Animation auf einen Absatz anwenden.

{{% alert color="info" title="Hinweis" %}}
Mehr erfahren [**Über animierten Text**](/slides/de/java/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF erhalten?**

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/java/slide-transition/) nicht abgespielt. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/java/export-to-html5/), [animiertem GIF](/slides/de/java/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/java/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie die Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [die Präsentation als Einzelbilder rendern](/slides/de/java/convert-powerpoint-to-video/) und diese zu einem Video (z. B. mit ffmpeg) kodieren, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

**Bleiben Animationen erhalten, wenn man mit ODP arbeitet (nicht nur PPTX)?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/java/open-presentation/) und [Schreiben](/slides/de/java/save-presentation/) unterstützt, dies garantiert jedoch nicht die Erhaltung von Animationen. Benutzerdefinierte Animationsdaten können beim Konvertieren zu ODP verloren gehen. Siehe [Benutzerdefinierte Animation](/slides/de/java/custom-animation/) für Beispiele und Hinweise zur Überprüfung der Formatkompatibilität.