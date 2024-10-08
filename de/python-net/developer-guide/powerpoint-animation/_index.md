---
title: PowerPoint-Animation
type: docs
weight: 150
url: /de/python-net/powerpoint-animation/
keywords: "Animation, Animationseffekte, PowerPoint-Animation, Animationstimeline, interaktive Animation, Formenanimation, animiertes Diagramm, animierter Text, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Animation und Effekte von PowerPoint-Präsentationen in Python"
---

Da Präsentationen dazu dienen, etwas zu präsentieren, wird ihr visuelles Erscheinungsbild und interaktives Verhalten beim Erstellen immer berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um die Präsentation ansprechend und attraktiv für die Zuschauer zu gestalten. Aspose.Slides für Python über .NET bietet eine Vielzahl von Möglichkeiten, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- verschiedene Arten von PowerPoint-Animations effekten auf Formen, Diagrammen, Tabellen, OLE-Objekten und anderen Präsentationselementen anwenden.
- mehrere PowerPoint-Animations effekte auf eine Form anwenden.
- Animationstimeline verwenden, um Animationseffekte zu steuern.
- benutzerdefinierte Animationen erstellen.

In Aspose.Slides für Python über .NET können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE-Objekte, Tabellen usw. als Form betrachtet wird, bedeutet dies, dass wir einen Animationseffekt auf jedes Element einer Folie anwenden können.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) **Namespace** bietet Klassen zur Arbeit mit PowerPoint-Animationen.
## **Animations effekte**
Aspose.Slides unterstützt **über 150 Animationseffekte**, einschließlich grundlegender Animationseffekte wie Bounce, PathFootball, Zoom-Effekt und spezifischen Animationseffekten wie OLEObjectShow, OLEObjectOpen. Eine vollständige Liste der Animationseffekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) Aufzählung.

Zusätzlich können diese Animationseffekte in Kombination mit ihnen verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/)
## **Benutzerdefinierte Animation**
Es ist möglich, Ihre eigenen **benutzerdefinierten Animationen** in Aspose.Slides zu erstellen. 
Dies kann erreicht werden, wenn Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[**Verhalten**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/) ist eine Baueinheit jedes PowerPoint-Animations effekts. Alle Animationseffekte sind eigentlich eine Kombination von Verhaltensweisen, die in einer Strategie zusammengefügt sind. Sie können Verhaltensweisen einmal zu einer benutzerdefinierten Animation kombinieren und in anderen Präsentationen wiederverwenden. Wenn Sie ein neues Verhalten zu einem standardmäßigen PowerPoint-Animations effekt hinzufügen, wird es zu einer anderen benutzerdefinierten Animation. Zum Beispiel können Sie ein Wiederholungsverhalten zu einer Animation hinzufügen, um sie mehrmals wiederholen zu lassen.

[**Animationspunkt**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/point/) ist ein Punkt, an dem das Verhalten angewendet werden sollte.
## **Animationstimeline**
[**Sequenz**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) ist eine Sammlung von Animationseffekten, die auf eine bestimmte Form angewendet werden.

[**Timeline**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animationtimeline/) ist eine Menge von Sequenzen, die in einer bestimmten Folie verwendet werden. Es ist ein Animationsmotor, der seit PowerPoint 2002 dargestellt wird. In früheren PowerPoint-Versionen war es eine Herausforderung, Animationseffekte auf Präsentationen anzuwenden, was nur mit unterschiedlichen Workarounds erreicht werden konnte. Die Timeline ersetzt die alte AnimationSettings-Klasse und bietet ein klareres Objektmodell für PowerPoint-Animationen. Eine Folie kann nur eine Animationstimeline haben.
## **Interaktive Animation**
[**Trigger**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) ermöglicht es, Benutzeraktionen (z.B. Knopfdruck) zu definieren, die eine bestimmte Animation starten. Trigger wurden nur in der neuesten PowerPoint-Version hinzugefügt.
## **Formanimation**
Aspose.Slides ermöglicht es, Animationen auf Formen anzuwenden, die tatsächlich Text, Rechtecke, Linien, Rahmen, OLE-Objekte usw. sein können.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über Formanimation**](/slides/de/python-net/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie die gleichen Klassen wie für die Formen verwenden. Es ist jedoch möglich, PowerPoint-Animationen nur auf Diagrammkategorien oder Diagrammserien anzuwenden. Sie können auch einen Animationseffekt auf ein Kategorienelement oder ein Serien element anwenden.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über animierte Diagramme**](/slides/de/python-net/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, Animationen auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über animierten Text**](/slides/de/python-net/animated-text/).
{{% /alert %}}