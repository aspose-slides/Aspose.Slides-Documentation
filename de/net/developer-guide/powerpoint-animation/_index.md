---
title: PowerPoint-Präsentationen mit Animationen in .NET verbessern
linktitle: PowerPoint-Animation
type: docs
weight: 150
url: /de/net/powerpoint-animation/
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
- PowerPoint-Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für .NET bei der Handhabung von PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor und bietet Einblicke, um Ihre Präsentationen zu verbessern."
---
## **Einführung**

Da Präsentationen dazu dienen, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bei der Erstellung stets berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um eine Präsentation für die Betrachter auffällig und ansprechend zu machen. Aspose.Slides für .NET bietet eine breite Palette von Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- Verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente anwenden.
- Mehrere PowerPoint-Animationseffekte auf einer einzelnen Form verwenden.
- Die Animations‑zeitleiste nutzen, um Animations‑Effekte zu steuern.
- Benutzerdefinierte Animationen erstellen.

In Aspose.Slides für .NET können verschiedene Animations‑Effekte auf Formen angewendet werden. Da jedes Element auf einer Folie, einschließlich Text, Bildern, OLE‑Objekten und Tabellen, als Form betrachtet wird, können Animations‑Effekte auf jedes Element der Folie angewendet werden.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/de/net/aspose.slides.animation/) Namespace stellt Klassen zur Arbeit mit PowerPoint-Animationen bereit.

## **Animations‑Effekte**

Aspose.Slides unterstützt **mehr als 150 Animations‑Effekte**, darunter Basis‑Effekte wie Bounce, PathFootball und Zoom sowie spezifische Effekte wie OLEObjectShow und OLEObjectOpen. Eine vollständige Liste der Animations‑Effekte finden Sie in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effecttype).

Zusätzlich können diese Animations‑Effekte in Kombination mit den folgenden verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/seteffect)

## **Benutzerdefinierte Animation**

Für vollständige C#‑Beispiele, die Verhaltensweisen und bearbeitbare Bewegungs­pfade erstellen, untersuchen und ändern, siehe [Benutzerdefinierte Animation](/slides/de/net/custom-animation/).

Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[Behavior](https://reference.aspose.com/slides/de/net/aspose.slides.animation/behavior) ist ein Baustein eines PowerPoint‑Animations‑Effekts. Kombinieren Sie Verhaltensweisen, um einen Effekt anzupassen, oder fügen Sie eine Verhaltensweise hinzu, um einen vordefinierten Effekt zu erweitern. Wiederholungen werden über Zeiteinstellungen konfiguriert und nicht über ein separates Wiederholungs‑Verhalten.

[Animation Point](https://reference.aspose.com/slides/de/net/aspose.slides.animation/point) ist ein Punkt, an dem eine Verhaltensweise angewendet werden soll.

## **Animations‑Zeitlinie**

[Sequence](https://reference.aspose.com/slides/de/net/aspose.slides.animation/sequence) ist eine Sammlung von Animations‑Effekten, die verschiedene Formen ansprechen können.

[Timeline](https://reference.aspose.com/slides/de/net/aspose.slides.animation/animationtimeline) ist eine Menge von Sequenzen, die in einer bestimmten Folie verwendet werden. Es ist eine Animations‑Engine, die in PowerPoint 2002 eingeführt wurde. In früheren Versionen von PowerPoint war das Hinzufügen von Animations‑Effekten zu Präsentationen schwierig und nur mit verschiedenen Umgehungslösungen möglich. Die Zeitleiste ersetzt die alte AnimationSettings‑Klasse und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animations‑Zeitleiste haben.

## **Interaktive Animation**

[Trigger](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effecttriggertype) ermöglicht es, Benutzeraktionen (z. B. einen Button‑Klick) zu definieren, die eine bestimmte Animation auslösen. Trigger wurden in der neuesten Version von PowerPoint eingeführt.

## **Formanimation**

Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, zu denen Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und mehr gehören.

{{% alert color="info" title="Note" %}}
Mehr lesen [**Über Formanimation**](/slides/de/net/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**

Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für Formen verwenden. PowerPoint‑Animationen können jedoch nur auf Diagrammkategorien oder Diagrammreihen angewendet werden. Sie können Animations‑Effekte auch auf ein Kategorienelement oder ein Reihen‑Element anwenden.

{{% alert color="info" title="Note" %}}
Mehr lesen [**Über animierte Diagramme**](/slides/de/net/animated-charts/).
{{% /alert %}}

## **Animierter Text**

Zusätzlich zum Animieren von Text können Sie einer Absatzanimation anwenden.

{{% alert color="info" title="Note" %}}
Mehr lesen [**Über animierten Text**](/slides/de/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF erhalten?**

Nein. PDF ist ein statisches Format, sodass Animationen und [Folienübergänge](/slides/de/net/slide-transition/) nicht abgespielt werden. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen nach [HTML5](/slides/de/net/export-to-html5/), [animiertem GIF](/slides/de/net/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/net/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [rendern](/slides/de/net/convert-powerpoint-to-video/) und diese in ein Video codieren (z. B. über ffmpeg), wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden während des Renderns abgespielt.

**Bleiben Animationen erhalten, wenn mit ODP (nicht nur PPTX) gearbeitet wird?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/net/open-presentation/) und [Schreiben](/slides/de/net/save-presentation/) unterstützt, jedoch garantiert dies nicht die Erhaltung von Animationen. Beim Konvertieren zu ODP können benutzerdefinierte Animationsdaten verloren gehen. Siehe [Benutzerdefinierte Animation](/slides/de/net/custom-animation/) für ein geprüftes Beispiel und Format‑Einschränkungen.