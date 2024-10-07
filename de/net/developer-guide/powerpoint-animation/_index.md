---
title: PowerPoint-Animation
type: docs
weight: 150
url: /net/powerpoint-animation/
keywords: "Animation, Animationseffekte, PowerPoint-Animation, Animationszeitleiste, interaktive Animation, Formanimation, animiertes Diagramm, animierter Text, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Animation und Effekte von PowerPoint-Präsentationen in C# oder .NET"
---

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, wird beim Erstellen immer das visuelle Erscheinungsbild und das interaktive Verhalten berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um die Präsentation auffällig und attraktiv für die Zuschauer zu gestalten. Aspose.Slides für .NET bietet eine Vielzahl von Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- verschiedene Arten von PowerPoint-Animations effekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente anwenden.
- mehrere PowerPoint-Animations effekte auf eine Form anwenden.
- Animationszeitleiste verwenden, um Animationseffekte zu steuern.
- benutzerdefinierte Animation erstellen.

In Aspose.Slides für .NET können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE-Objekte, Tabellen usw., als Form betrachtet wird, bedeutet dies, dass wir Animations effekte auf jedes Element einer Folie anwenden können.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/net/aspose.slides.animation/) **Namespace** bietet Klassen zur Arbeit mit PowerPoint-Animationen.
## **Animations Effekte**
Aspose.Slides unterstützt **über 150 Animations effekte**, einschließlich grundlegender Animations effekte wie Bounce, PathFootball, Zoom-Effekt und spezifische Animations effekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Liste der Animations effekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) Aufzählung.

Zusätzlich können diese Animations effekte in Kombination mit den folgenden verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)
## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. 
Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[**Verhalten**](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) ist eine Baueinheit jedes PowerPoint-Animations effekts. Alle Animations effekte sind tatsächlich eine Sammlung von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen einmal zu einer benutzerdefinierten Animation kombinieren und in anderen Präsentationen wiederverwenden. Wenn Sie ein neues Verhalten zu einem Standard-PowerPoint-Animations effekt hinzufügen - wird es eine andere benutzerdefinierte Animation sein. Zum Beispiel können Sie ein Wiederholungsverhalten zu einer Animation hinzufügen, um sie mehrere Male wiederholen zu lassen.

[**Animationspunkt**](https://reference.aspose.com/slides/net/aspose.slides.animation/point) ist ein Punkt, an dem das Verhalten angewendet werden soll.
## **Animationszeitleiste**
[**Sequenz**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) ist eine Sammlung von Animations effekten, die auf eine bestimmte Form angewendet werden.

[**Zeitleiste**](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) ist eine Sammlung von Sequenzen, die in einer bestimmten Folie verwendet werden. Es ist eine Animationsmaschine, die seit PowerPoint 2002 repräsentiert wird. In früheren PowerPoint-Versionen war es schwierig, Animations effekte zu Präsentationen hinzuzufügen, was nur mit verschiedenen Workarounds erreicht werden konnte. Die Zeitleiste ersetzt die alte AnimationSettings-Klasse und bietet ein klareres Objektmodell für PowerPoint-Animationen. Eine Folie kann nur eine Animationszeitleiste haben.
## **Interaktive Animation**
[**Trigger**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) ermöglicht es, Benutzeraktionen (z. B. Mausklicks) zu definieren, die eine bestimmte Animation starten. Trigger wurden nur in der neuesten PowerPoint-Version hinzugefügt.
## **Formanimation**
Aspose.Slides ermöglicht es, Animationen auf Formen anzuwenden, die tatsächlich Text, Rechtecke, Linien, Rahmen, OLE-Objekte usw. sein können.

{{% alert color="primary" %}} 
Lesen Sie mehr [**Über Formanimation**](/slides/net/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie alle gleichen Klassen wie für die Formen verwenden. Es ist jedoch möglich, PowerPoint-Animationen nur auf Diagrammkategorien oder Diagrammserien anzuwenden. Sie können auch einen Animations effekt auf ein Kategorieelement oder ein Serienelement anwenden.

{{% alert color="primary" %}} 
Lesen Sie mehr [**Über animierte Diagramme**](/slides/net/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, Animationen auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Lesen Sie mehr [**Über animierten Text**](/slides/net/animated-text/).
{{% /alert %}}