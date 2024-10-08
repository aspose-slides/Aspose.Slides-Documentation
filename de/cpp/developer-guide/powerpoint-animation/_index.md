---
title: PowerPoint-Animation
type: docs
weight: 150
url: /de/cpp/powerpoint-animation/
keywords: "PowerPoint-Animation"
description: "PowerPoint-Animation, PowerPoint-Folienanimation mit Aspose.Slides."
---

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, wird ihr visuelles Erscheinungsbild und interaktives Verhalten immer bei der Erstellung berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um die Präsentation für die Zuschauer ansprechend und attraktiv zu gestalten. Aspose.Slides für C++ bietet eine Vielzahl von Möglichkeiten, Animationen in PowerPoint-Präsentationen hinzuzufügen:

- verschiedene Arten von PowerPoint-Animations-Effekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente anwenden.
- mehrere PowerPoint-Animations-Effekte auf eine Form anwenden.
- Animationszeitleiste verwenden, um Animationseffekte zu steuern.
- benutzerdefinierte Animation erstellen.

In Aspose.Slides für C++ können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE-Objekt, Tabelle usw., als Form betrachtet wird, bedeutet dies, dass wir Animationseffekte auf jedes Element einer Folie anwenden können.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **Namespace** stellt Klassen zur Verfügung, um mit PowerPoint-Animationen zu arbeiten.
## **Animations-Effekte**
Aspose.Slides unterstützt **über 150 Animations-Effekte**, einschließlich grundlegender Animations-Effekte wie Bounce, PathFootball, Zoom-Effekt und spezifische Animations-Effekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Liste der Animations-Effekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) Aufzählung.

Zusätzlich können diese Animations-Effekte in Kombination mit den folgenden verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. 
Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) ist eine Baueinheit eines jeden PowerPoint-Animations-Effekts. Alle Animations-Effekte sind tatsächlich eine Kombination von Verhaltensweisen, die in einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen einmal zu einer benutzerdefinierten Animation kombinieren und sie in anderen Präsentationen wiederverwenden. Wenn Sie ein neues Verhalten zu einem standardmäßigen PowerPoint-Animations-Effekt hinzufügen, wird es zu einer anderen benutzerdefinierten Animation. Zum Beispiel können Sie das Wiederholungsverhalten zu einer Animation hinzufügen, um sie mehrmals wiederholen zu lassen.

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) ist der Punkt, an dem das Verhalten angewendet werden soll.

## **Animationszeitleiste**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) ist eine Sammlung von Animations-Effekten, die auf eine bestimmte Form angewendet werden.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) ist eine Sammlung von Sequenzen, die in einer bestimmten Folie verwendet werden. Es ist eine Animations-Engine, die seit PowerPoint 2002 vertreten ist. In früheren PowerPoint-Versionen war es eine Herausforderung, Animations-Effekte zur Präsentation hinzuzufügen, was nur durch verschiedene Umgehungslösungen möglich war. Die Zeitleiste ersetzt die alte AnimationsSettings-Klasse und bietet ein klareres Objektmodell für PowerPoint-Animationen. Eine Folie kann nur eine Animationszeitleiste haben.
## **Interaktive Animation**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) erlaubt es, Benutzeraktionen (z. B. Mausklick) zu definieren, die eine bestimmte Animation starten. Trigger wurden nur in der neuesten PowerPoint-Version hinzugefügt.


## **Form-Animation**
Aspose.Slides ermöglicht es, Animationen auf Formen anzuwenden, die tatsächlich Text, Rechtecke, Linien, Rahmen, OLE-Objekte usw. sein können.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über Formanimation**](/slides/de/cpp/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie die gleichen Klassen wie für die Formen verwenden. Es ist jedoch möglich, PowerPoint-Animation nur auf Diagrammkategorien oder Diagrammserien anzuwenden. Sie können auch einen Animationseffekt auf ein Kategorienelement oder ein Serienelement anwenden.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über animierte Diagramme**](/slides/de/cpp/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, Animationen auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über animierten Text**](/slides/de/cpp/animated-text/).
{{% /alert %}}