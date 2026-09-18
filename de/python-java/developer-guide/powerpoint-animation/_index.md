---
title: PowerPoint-Präsentationen mit Animationen in Python via Java verbessern
linktitle: PowerPoint-Animation
type: docs
weight: 150
url: /de/python-java/powerpoint-animation/
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
- Python
- Java
- Aspose.Slides
description: "Entdecken Sie die Möglichkeiten von Aspose.Slides für Python via Java bei der Handhabung von PowerPoint-Animationen. Dieser allgemeine Überblick hebt wichtige Funktionen hervor und bietet Erkenntnisse zur Verbesserung Ihrer Präsentationen."
---
## **Einführung**

Sowohl das visuelle Erscheinungsbild als auch das interaktive Verhalten werden berücksichtigt, wenn Präsentationen erstellt werden.

**PowerPoint-Animation** spielt eine wichtige Rolle, um eine Präsentation für Betrachter auffällig und ansprechend zu machen. Aspose.Slides bietet eine Vielzahl von Optionen, um PowerPoint-Präsentationen Animationen hinzuzufügen:

- Verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE‑Objekte und andere Präsentationselemente anwenden.
- Mehrere PowerPoint-Animationseffekte auf einer einzelnen Form verwenden.
- Die Animationszeitlinie nutzen, um Animationseffekte zu steuern.
- Benutzerdefinierte Animationen erstellen.

In Aspose.Slides können verschiedene Animations‑effekte auf Formen angewendet werden. Da jedes Element auf einer Folie, einschließlich Text, Bilder, OLE‑Objekte und Tabellen, als Form betrachtet wird, können Animations‑effekte auf jedes Element der Folie angewendet werden.

## **Animations‑Effekte**

Aspose.Slides unterstützt **mehr als 150 Animations‑Effekte**, darunter Basis‑Effekte wie Bounce, PathFootball und Zoom sowie spezifische Effekte wie OLEObjectShow und OLEObjectOpen. Eine vollständige Auflistung finden Sie in der Klasse [EffectType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effecttype/).

Zusätzlich können diese Animations‑Effekte in Kombination mit den folgenden Verhaltensweisen verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/seteffect/)

## **Benutzerdefinierte Animation**

Für vollständige Python‑via‑Java‑Beispiele, die Verhaltensweisen und editierbare Bewegungs­pfade erstellen, untersuchen und ändern, siehe [Benutzerdefinierte Animation](/slides/de/python-java/custom-animation/).

Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[Behavior](https://reference.aspose.com/slides/de/python-java/aspose.slides/behavior/) ist ein Baustein eines PowerPoint-Animations‑effekts. Kombinieren Sie Verhaltensweisen, um einen Effekt anzupassen, oder fügen Sie eine Verhaltensweise hinzu, um einen vordefinierten Effekt zu erweitern. Wiederholungen werden über Zeiteinstellungen konfiguriert, nicht über ein separates Wiederholungs‑Verhalten.

[Point](https://reference.aspose.com/slides/de/python-java/aspose.slides/point/) ist ein Punkt, an dem eine Verhaltensweise angewendet werden soll.

## **Animations‑Zeitlinie**
[Sequence](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/) ist eine Sammlung von Animations‑Effekten, die unterschiedliche Formen ansprechen können.

[AnimationTimeLine](https://reference.aspose.com/slides/de/python-java/aspose.slides/animationtimeline/) ist ein Satz von Sequenzen, die auf einer bestimmten Folie verwendet werden. Er stellt die Animations‑Engine dar, die in PowerPoint 2002 eingeführt wurde. In früheren PowerPoint‑Versionen war das Hinzufügen von Animations‑Effekten zu einer Präsentation schwierig und erforderte Workarounds. Die Zeitlinie bietet ein klareres Objektmodell für PowerPoint‑Animationen. Eine Folie kann nur eine Animations‑Zeitlinie besitzen.

## **Interaktive Animation**
[EffectTriggerType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effecttriggertype/) ermöglicht es Ihnen, Benutzeraktionen wie einen Button‑Klick zu definieren, die eine bestimmte Animation starten.

## **Form‑Animation**
Aspose.Slides ermöglicht das Anwenden von Animationen auf Formen, die Text, Rechtecke, Linien, Rahmen, OLE‑Objekte und andere Elemente darstellen können.

{{% alert color="info" title="Hinweis" %}}
Mehr lesen [Über Shape Animation](/slides/de/python-java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, verwenden Sie dieselben Klassen wie für Formen. Allerdings ist es nur möglich, PowerPoint‑Animationen auf Diagrammkategorien oder Diagramm‑Serien anzuwenden. Sie können auch einen Animations‑Effekt auf ein Kategorie‑Element oder ein Serien‑Element anwenden.

{{% alert color="info" title="Hinweis" %}}
Mehr lesen [Über animierte Diagramme](/slides/de/python-java/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Zusätzlich zur Animation von Text können Sie auch einem Absatz eine Animation zuweisen.

{{% alert color="info" title="Hinweis" %}}
Mehr lesen [Über animierten Text](/slides/de/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Werden Animationen beim Exportieren in PDF erhalten?**

Nein. PDF ist ein statisches Format, sodass Animationen und [Folienübergänge](/slides/de/python-java/slide-transition/) nicht abgespielt werden. Wenn Sie Bewegung benötigen, exportieren Sie stattdessen zu [HTML5](/slides/de/python-java/export-to-html5/), [animiertem GIF](/slides/de/python-java/convert-powerpoint-to-animated-gif/) oder [Video](/slides/de/python-java/convert-powerpoint-to-video/).

**Kann ich eine animierte Präsentation in ein Video umwandeln und die Bildrate sowie die Bildgröße steuern?**

Ja. Sie können die Präsentation [als Einzelbilder rendern](/slides/de/python-java/convert-powerpoint-to-video/) und diese zu einem Video (z. B. mit ffmpeg) kodieren, wobei Sie FPS und Auflösung wählen. Animationen und Folienübergänge werden beim Rendern abgespielt.

**Bleiben Animationen beim Arbeiten mit ODP (nicht nur PPTX) erhalten?**

PPT, PPTX und ODP werden für das [Lesen](/slides/de/python-java/open-presentation/) und [Schreiben](/slides/de/python-java/save-presentation/) unterstützt, jedoch garantiert dies nicht die Erhaltung von Animationen. Benutzerdefinierte Animationsdaten können beim Konvertieren in ODP verloren gehen. Siehe [Custom Animation](/slides/de/python-java/custom-animation/) für Beispiele und Hinweise zur Überprüfung der Formatkompatibilität.