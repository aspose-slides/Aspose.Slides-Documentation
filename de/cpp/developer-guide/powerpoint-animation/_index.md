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
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie erweiterte Animationseffekte in Aspose.Slides für C++ hinzufügen und steuern, um dynamische PowerPoint‑ und OpenDocument‑Präsentationen zu erstellen."
---
## **Einleitung**

Da Präsentationen dazu dienen, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bereits bei der Erstellung stets berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle dabei, eine Präsentation ansprechend und fesselnd für die Betrachter zu machen. Aspose.Slides bietet eine Vielzahl von Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- Wenden Sie verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente an.
- Verwenden Sie mehrere PowerPoint-Animationseffekte gleichzeitig auf einer einzelnen Form.
- Nutzen Sie die Animations‑Zeitleiste, um Animationseffekte zu steuern.
- Erstellen Sie benutzerdefinierte Animationen.

In Aspose.Slides können verschiedene Animationseffekte auf Formen angewendet werden. Da jedes Element auf einer Folie, einschließlich Text, Bildern, OLE-Objekten und Tabellen, als Form betrachtet wird, können Animationseffekte auf jedes Element der Folie angewendet werden.

Der [Aspose::Slides::Animation](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/) Namespace bietet Klassen zur Arbeit mit PowerPoint-Animationen.

## **Animations‑Effekte**

Aspose.Slides unterstützt **150+ Animationseffekte**, darunter Grundeffekte wie Bounce, PathFootball und Zoom sowie spezifische Effekte wie OLEObjectShow und OLEObjectOpen. Eine vollständige Auflistung finden Sie in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/effecttype/).

Zusätzlich können diese Animationseffekte in Kombination mit den folgenden Verhaltensweisen verwendet werden:
- [Farbeffekt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/coloreffect/)
- [Befehlseffekt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/commandeffect/)
- [Filtereffekt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/filtereffect/)
- [Bewegungseffekt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/motioneffect/)
- [Eigenschaftseffekt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/propertyeffect/)
- [Drehungseffekt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/rotationeffect/)
- [Skalierungseffekt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/scaleeffect/)
- [Setzeffekt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/seteffect/)

## **Benutzerdefinierte Animation**

Für vollständige C++‑Beispiele, die Verhaltensweisen und editierbare Bewegungsbahnen erstellen, untersuchen und ändern, siehe [Benutzerdefinierte Animation](/slides/de/cpp/custom-animation/).

In Aspose.Slides ist es möglich, eigene **benutzerdefinierte Animationen** zu erstellen. Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[Verhalten](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/behavior/) ist ein Baustein eines PowerPoint‑Animationseffekts. Kombinieren Sie Verhaltensweisen, um einen Effekt anzupassen, oder fügen Sie ein Verhalten hinzu, um einen vordefinierten Effekt zu erweitern. Wiederholungen werden über Zeiteinstellungen konfiguriert und nicht über ein separates Wiederholungs‑Verhalten.

[Animationspunkt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/point/) ist ein Punkt, an dem ein Verhalten angewendet werden soll.

## **Animationszeitlinie**

[Sequenz](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/sequence/) ist eine Sammlung von Animationseffekten, die verschiedene Formen anvisieren können.

[IAnimationTimeLine](https://reference.aspose.com/slides/de/cpp/aspose.slides/ianimationtimeline/) ist eine Menge von Sequenzen, die in einer bestimmten Folie verwendet werden. Es ist eine Animations‑Engine, die in PowerPoint 2002 eingeführt wurde. In früheren Versionen von PowerPoint war das Hinzufügen von Animationseffekten zu Präsentationen schwierig und nur mit verschiedenen Work‑arounds möglich. Die Zeitleiste bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animations‑Zeitleiste haben.

## **Interaktive Animation**

[Trigger](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/effecttriggertype/) ermöglicht es Ihnen, Benutzeraktionen wie einen Button‑Klick zu definieren, die eine bestimmte Animation starten.

## **Form‑Animation**

Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, zu denen Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und mehr gehören können.

{{% alert color="info" title="Note" %}}
Mehr lesen [**Über Form‑Animation**](/slides/de/cpp/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**

Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. PowerPoint‑Animationen können jedoch nur auf Diagrammkategorien oder Diagrammserien angewendet werden. Sie können Animationseffekte auch auf ein Kategorienelement oder ein Serien‑Element anwenden.

{{% alert color="info" title="Note" %}}
Mehr lesen [**Über animierte Diagramme**](/slides/de/cpp/animated-charts/).
{{% /alert %}}

## **Animierter Text**

Zusätzlich zur Animation von Text können Sie einer Absatzanimation anwenden.

{{% alert color="info" title="Note" %}}
Mehr lesen [**Über animierten Text**](/slides/de/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF erhalten?**

Nein. PDF ist ein statisches Format, sodass Animationen und [Folienübergänge](/slides/de/cpp/slide-transition/) nicht abgespielt werden. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/cpp/export-to-html5/), [animiertem GIF](/slides/de/cpp/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/cpp/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und Bildrate sowie Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [rendern](/slides/de/cpp/convert-powerpoint-to-video/) und diese zu einem Video (z. B. mit ffmpeg) kodieren, wobei Sie FPS und Auflösung wählen können. Animationen und Folienübergänge werden beim Rendern abgespielt.

**Bleiben Animationen beim Arbeiten mit ODP (nicht nur PPTX) erhalten?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/cpp/open-presentation/) und [Schreiben](/slides/de/cpp/save-presentation/) unterstützt, aber das garantiert keinen Erhalt der Animationen. Beim Konvertieren nach ODP können benutzerdefinierte Animationsdaten verloren gehen. Siehe [Benutzerdefinierte Animation](/slides/de/cpp/custom-animation/) für Beispiele und Hinweise zur Überprüfung der Formatkompatibilität.