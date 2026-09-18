---
title: PowerPoint-Präsentationen mit Animationen auf Android verbessern
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
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Android über Java bei der Handhabung von PowerPoint-Animationen. Dieser allgemeine Überblick hebt die wichtigsten Funktionen hervor."
---
## **Einleitung**

Da Präsentationen dazu dienen, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bei der Erstellung stets berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle dabei, eine Präsentation für die Zuschauer ansprechend und fesselnd zu machen. Aspose.Slides bietet eine breite Palette von Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- Wenden Sie verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente an.
- Verwenden Sie mehrere PowerPoint-Animationseffekte auf einer einzigen Form.
- Nutzen Sie die Animationszeitlinie, um Animationseffekte zu steuern.
- Erstellen Sie benutzerdefinierte Animationen.

## **Animationseffekte**
Aspose.Slides unterstützt **mehr als 150 Animationseffekte**, darunter Basis‑Effekte wie Bounce, PathFootball und Zoom sowie spezifische Effekte wie OLEObjectShow und OLEObjectOpen. Eine vollständige Auflistung finden Sie in der Klasse [EffectType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effecttype/).

Zusätzlich können diese Animationseffekte in Kombination mit den folgenden Verhaltensweisen verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**
Vollständige Java‑Beispiele, die Verhaltensweisen und bearbeitbare Bewegungsbahnen erstellen, inspizieren und ändern, finden Sie unter [Benutzerdefinierte Animation](/slides/de/java/custom-animation/).

Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[Behavior](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/behavior/) ist ein Baustein eines PowerPoint‑Animationseffekts. Kombinieren Sie Verhaltensweisen, um einen Effekt anzupassen, oder fügen Sie eine Verhaltensweise hinzu, um einen vordefinierten Effekt zu erweitern. Wiederholungen werden über Zeiteinstellungen konfiguriert und nicht über ein separates Wiederholungs‑Verhalten.

[Animation Point](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/point/) ist ein Punkt, an dem eine Verhaltensweise angewendet werden soll.

## **Animationszeitlinie**
[Sequence](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sequence/) ist eine Sammlung von Animationseffekten, die verschiedene Formen ansprechen können.

[Timeline](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/animationtimeline/) ist ein Satz von Sequenzen, die in einer bestimmten Folie verwendet werden. Sie ist eine Animationsengine, die in PowerPoint 2002 eingeführt wurde. In früheren Versionen von PowerPoint war das Hinzufügen von Animationseffekten zu Präsentationen schwierig und nur mit verschiedenen Umwegen möglich. Die Zeitlinie bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animationszeitlinie besitzen.

## **Interaktive Animation**
[Trigger](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effecttriggertype/) ermöglicht es, Benutzeraktionen wie einen Button‑Klick zu definieren, die eine bestimmte Animation starten.

## **Formanimation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, zu denen Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und mehr gehören können.

{{% alert color="info" title="Note" %}}
Mehr dazu [**Über Shape Animation**](/slides/de/androidjava/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. PowerPoint‑Animationen können jedoch nur auf Diagrammkategorien oder Diagrammserien angewendet werden. Sie können Animations‑effekte auch auf ein Kategorie‑Element oder ein Serien‑Element anwenden.

{{% alert color="info" title="Note" %}}
Mehr dazu [**Über animierte Diagramme**](/slides/de/androidjava/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Zusätzlich zur Animation von Text können Sie auch einem Absatz eine Animation zuweisen.

{{% alert color="info" title="Note" %}}
Mehr dazu [**Über animierten Text**](/slides/de/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF erhalten?**

Nein. PDF ist ein statisches Format, daher werden Animationen und [Folientransitionen](/slides/de/androidjava/slide-transition/) nicht abgespielt. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/androidjava/export-to-html5/), [animiertem GIF](/slides/de/androidjava/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/androidjava/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und dabei Bildrate und Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [die Präsentation als Einzelbilder rendern](/slides/de/androidjava/convert-powerpoint-to-video/) und diese in ein Video (z. B. über ffmpeg) kodieren, wobei Sie FPS und Auflösung wählen. Animationen und Folientransitionen werden während des Renderns abgespielt.

**Bleiben Animationen beim Arbeiten mit ODP (nicht nur PPTX) erhalten?**

PPT, PPTX und ODP werden zum [Lesen](/slides/de/androidjava/open-presentation/) und [Schreiben](/slides/de/androidjava/save-presentation/) unterstützt, jedoch garantiert dies nicht die Erhaltung von Animationen. Beim Konvertieren zu ODP können benutzerdefinierte Animationsdaten verloren gehen. Siehe [Benutzerdefinierte Animation für Java](/slides/de/java/custom-animation/) für Beispiele und Hinweise zur Prüfung der Formatkompatibilität.