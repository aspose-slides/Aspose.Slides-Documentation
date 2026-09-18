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
- PHP
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für PHP via Java bei der Handhabung von PowerPoint-Animationen. Schlüsselmerkmale und Einblicke, um Ihre Präsentationen zu verbessern."
---
## **Einleitung**

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bei der Erstellung stets berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um eine Präsentation für Betrachter ansprechend und fesselnd zu machen. Aspose.Slides für PHP via Java bietet eine Vielzahl von Möglichkeiten, Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- Verschiedene Typen von PowerPoint‑Animationseffekten auf Formen, Diagramme, Tabellen, OLE‑Objekte und andere Präsentationselemente anwenden.
- Mehrere PowerPoint‑Animationseffekte auf einer einzigen Form verwenden.
- Die Animationszeitleiste nutzen, um Animationseffekte zu steuern.
- Benutzerdefinierte Animationen erstellen.

In Aspose.Slides für PHP via Java können verschiedene Animationseffekte auf Formen angewendet werden. Da jedes Element auf einer Folie, einschließlich Text, Bilder, OLE‑Objekte und Tabellen, als Form gilt, können Animationseffekte auf jedes Element der Folie angewendet werden.

## **Animationseffekte**
Aspose.Slides unterstützt **mehr als 150 Animationseffekte**, darunter Grundeffekte wie Bounce, PathFootball und Zoom sowie spezifische Effekte wie OLEObjectShow und OLEObjectOpen. Eine vollständige Auflistung finden Sie in der Klasse [EffectType](https://reference.aspose.com/slides/de/php-java/aspose.slides/effecttype/).

Zusätzlich können diese Animationseffekte in Kombination mit den folgenden Verhaltensweisen verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**

Vollständige PHP‑Beispiele, die Verhaltensweisen und editierbare Bewegungsbahnen erstellen, inspizieren und ändern, finden Sie unter [Custom Animation](/slides/de/php-java/custom-animation/).

Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[Behavior](https://reference.aspose.com/slides/de/php-java/aspose.slides/behavior/) ist ein Baustein eines PowerPoint‑Animationseffekts. Kombinieren Sie Verhaltensweisen, um einen Effekt anzupassen, oder fügen Sie eine Verhaltensweise hinzu, um einen vordefinierten Effekt zu erweitern. Wiederholungen werden über Zeiteinstellungen konfiguriert, nicht über ein separates Wiederholungs‑Verhalten.

[Animation Point](https://reference.aspose.com/slides/de/php-java/aspose.slides/point/) ist ein Punkt, an dem ein Verhalten angewendet werden soll.

## **Animationszeitachse**
[Sequence](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/) ist eine Sammlung von Animationseffekten, die verschiedene Formen ansprechen können.

[Timeline](https://reference.aspose.com/slides/de/php-java/aspose.slides/animationtimeline/) ist ein Satz von Sequenzen, die in einer bestimmten Folie verwendet werden. Sie ist eine Animations‑Engine, die in PowerPoint 2002 eingeführt wurde. In früheren Versionen von PowerPoint war das Hinzufügen von Animationseffekten zu Präsentationen schwierig und nur mit verschiedenen Workarounds möglich. Die Zeitleiste bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animationszeitleiste besitzen.

## **Interaktive Animation**
[Trigger](https://reference.aspose.com/slides/de/php-java/aspose.slides/effecttriggertype/) ermöglicht es, Benutzeraktionen wie einen Button‑Klick zu definieren, die eine bestimmte Animation starten.

## **Formanimation**
Aspose.Slides erlaubt das Anwenden von Animationen auf Formen, zu denen Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und mehr gehören können.

{{% alert color="info" title="Note" %}}
Lesen Sie mehr [**Über Formanimation**](/slides/de/php-java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. Allerdings können PowerPoint‑Animationen nur auf Diagrammkategorien oder Diagrammreihen angewendet werden. Sie können Animationseffekte auch auf ein Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="info" title="Note" %}}
Lesen Sie mehr [**Über animierte Diagramme**](/slides/de/php-java/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben der Animation von Text können Sie auch eine Animation auf einen Absatz anwenden.

{{% alert color="info" title="Note" %}}
Lesen Sie mehr [**Über animierten Text**](/slides/de/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF beibehalten?**

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folienübergänge](/slides/de/php-java/slide-transition/) nicht abgespielt. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/php-java/export-to-html5/), [animiertem GIF](/slides/de/php-java/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/php-java/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und Bildrate sowie Bildgröße steuern?**

Ja. Sie können die Präsentation in einzelne Frames [rendern](/slides/de/php-java/convert-powerpoint-to-video/) und diese mit einem Encoder (z. B. ffmpeg) zu einem Video zusammenfügen, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden während des Renderns abgespielt.

**Bleiben Animationen erhalten, wenn mit ODP (nicht nur PPTX) gearbeitet wird?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/php-java/open-presentation/) und [Schreiben](/slides/de/php-java/save-presentation/) unterstützt, jedoch garantiert das keine Erhaltung der Animationen. Beim Konvertieren nach ODP können benutzerdefinierte Animationsdaten verloren gehen. Siehe [Custom Animation](/slides/de/php-java/custom-animation/) für Beispiele und Hinweise zur Prüfung der Formatkompatibilität.