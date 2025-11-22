---
title: PowerPoint-Präsentationen mit Animationen in Python verbessern
linktitle: PowerPoint-Animation
type: docs
weight: 150
url: /de/python-net/powerpoint-animation/
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
- PowerPoint-Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Python via .NET zur Handhabung von PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor und bietet Einblicke zur Verbesserung Ihrer Präsentationen."
---

## **Überblick**

Präsentationen werden erstellt, um Informationen zu vermitteln, daher sind ihr visuelles Erscheinungsbild und ihr interaktives Verhalten bei der Erstellung wichtige Überlegungen.

**PowerPoint-Animation** spielt eine wichtige Rolle, um eine Präsentation für Betrachter ansprechend und fesselnd zu machen. Aspose.Slides for Python via .NET bietet eine breite Palette von Optionen, um einer PowerPoint-Präsentation Animationen hinzuzufügen. Sie können:

- Verschiedene Animationseffekte auf Formen, Diagramme, Tabellen, OLE‑Objekte und andere Elemente anwenden.
- Mehrere Animationseffekte auf einer einzelnen Form verwenden.
- Effekte über die Animationszeitleiste steuern.
- Benutzerdefinierte Animationen erstellen.

In Aspose.Slides for Python via .NET können Animationseffekte auf Formen angewendet werden. Da jedes Element auf einer Folie – einschließlich Text, Bilder, OLE‑Objekte und Tabellen – als Form behandelt wird, können Sie Animationseffekte auf jedes Element der Folie anwenden.

Der [aspose.slides.animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/)‑Namespace stellt die Klassen für die Arbeit mit PowerPoint‑Animationen bereit.

## **Animationseffekte**

Aspose.Slides unterstützt **mehr als 150 Animationseffekte**, darunter Grundeffekte wie Bounce, PathFootball und Zoom sowie spezialisierte Effekte wie OLEObjectShow und OLEObjectOpen. Die vollständige Liste finden Sie in der Aufzählung [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/).

Zusätzlich können diese Animationseffekte mit den folgenden Effekten kombiniert werden:

- [ColorEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/)

## **Benutzerdefinierte Animation**

Sie können eigene **benutzerdefinierte Animationen** in Aspose.Slides erstellen, indem Sie mehrere Verhaltensweisen zu einem einzigen Effekt kombinieren.

[Behavior](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/) ist das grundlegende Bauelement jedes PowerPoint‑Animationseffekts. Jeder Animationseffekt besteht im Wesentlichen aus einer Menge von Verhaltensweisen, die zu einer Strategie oder Zeitleiste angeordnet sind. Sie können Verhaltensweisen zu einer benutzerdefinierten Animation zusammenstellen und diese dann in anderen Präsentationen wiederverwenden. Wenn Sie einer Standard‑PowerPoint‑Animation ein neues Verhalten hinzufügen, entsteht eine benutzerdefinierte Animation – z. B. das Hinzufügen eines Wiederholungs‑Verhaltens, damit die Animation mehrfach abgespielt wird.

[Animation Point](https://reference.aspose.com/slides/python-net/aspose.slides.animation/point/) markiert den Moment oder die Position, an der ein Verhalten angewendet wird (ein Schlüsselbild).

## **Animationszeitleiste**

[Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) ist eine Sammlung von Animationseffekten, die auf eine bestimmte Form angewendet werden.

[Timeline](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animationtimeline/) ist die Menge von Sequenzen, die auf einer bestimmten Folie verwendet wird. Sie wurde in PowerPoint 2002 eingeführt. In älteren PowerPoint‑Versionen war das Hinzufügen von Animationseffekten schwierig und erforderte häufig Work‑arounds. Die Zeitleiste ersetzt die alte `AnimationSettings`‑Klasse und bietet ein klareres Objektmodell für PowerPoint‑Animationen. Jede Folie kann nur eine Animationszeitleiste besitzen.

## **Interaktive Animation**

[Trigger](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) ermöglicht es, Benutzeraktionen (z. B. einen Klick auf einen Button) zu definieren, die eine bestimmte Animation starten. Trigger wurden erst in den neuesten PowerPoint‑Versionen eingeführt.

## **Formanimation**

Aspose.Slides lässt Sie Animationen auf Formen anwenden – wie Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und mehr.

{{% alert color="primary" %}}

Mehr lesen [**Über Shape Animation**](/slides/de/python-net/shape-animation/).

{{% /alert %}}

## **Animierte Diagramme**

Um animierte Diagramme zu erstellen, verwenden Sie dieselben Klassen wie für Formen. PowerPoint‑Animationen können jedoch nur auf Diagrammkategorien oder Diagrammreihen angewendet werden. Sie können auch einen Animationseffekt auf ein einzelnes Kategorie‑Element oder ein Reihen‑Element anwenden.

{{% alert color="primary" %}}

Mehr lesen [**Über Animated Charts**](/slides/de/python-net/animated-charts/).

{{% /alert %}}

## **Animierter Text**

Zusätzlich zur Animation von Text können Sie auch einen Absatz animieren.

{{% alert color="primary" %}}

Mehr lesen [**Über Animated Text**](/slides/de/python-net/animated-text/).

{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren nach PDF erhalten?**

Nein. PDF ist ein statisches Format, sodass Animationen und [Folienübergänge](/slides/de/python-net/slide-transition/) nicht abgespielt werden. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen nach [HTML5](/slides/de/python-net/export-to-html5/), [animiertem GIF](/slides/de/python-net/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/python-net/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und Bildrate sowie Bildgröße steuern?**

Ja. Sie können die Präsentation als Einzelbilder [rendern](/slides/de/python-net/convert-powerpoint-to-video/) und diese mit einem Encoder (z. B. ffmpeg) zu einem Video zusammenfügen, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

**Bleiben Animationen erhalten, wenn mit ODP (nicht nur PPTX) gearbeitet wird?**

PPT, PPTX und ODP werden zum [Lesen](/slides/de/python-net/open-presentation/) und [Schreiben](/slides/de/python-net/save-presentation/) unterstützt, jedoch können sich aufgrund von Formatunterschieden einige Effekte leicht anders darstellen oder verhalten. Prüfen Sie kritische Fälle mit echten Beispielen.