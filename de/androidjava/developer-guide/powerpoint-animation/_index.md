---
title: PowerPoint-Animation
type: docs
weight: 150
url: /androidjava/powerpoint-animation/
keywords: "PowerPoint-Animation"
description: "PowerPoint-Animation, PowerPoint-Folienanimation mit Aspose.Slides."
---

Da Präsentationen dazu gedacht sind, etwas darzustellen, wird bei deren Erstellung stets auf das visuelle Erscheinungsbild und das interaktive Verhalten geachtet.

**PowerPoint-Animation** spielt eine wichtige Rolle, um die Präsentation für die Zuschauer ansprechend und attraktiv zu gestalten. Aspose.Slides für Android über Java bietet eine Vielzahl von Optionen, um Animationen zur PowerPoint-Präsentation hinzuzufügen:

- Verschiedene Arten von PowerPoint-Animations Effekten auf Formen, Diagrammen, Tabellen, OLE-Objekten und anderen Präsentationselementen anwenden.
- Mehrere PowerPoint-Animationseffekte auf eine Form anwenden.
- Animationszeitlinie verwenden, um Animationseffekte zu steuern.
- Benutzerdefinierte Animationen erstellen.

In Aspose.Slides für Android über Java können verschiedene Animationseffekte auf die Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE-Objekten, Tabellen usw. als Form betrachtet wird, bedeutet dies, dass wir Animationseffekte auf jedes Element einer Folie anwenden können.

## **Animations Effekte**
Aspose.Slides unterstützt **150+ Animationseffekte**, einschließlich grundlegender Animationseffekte wie Bounce, PathFootball, Zoom-Effekt und spezifischer Animationseffekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Liste der Animationseffekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) Aufzählung.

Darüber hinaus können diese Animationseffekte in Kombination mit den folgenden verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**
Es ist möglich, Ihre eigenen **benutzerdefinierten Animationen** in Aspose.Slides zu erstellen. 
Dies kann erreicht werden, wenn Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[**Verhalten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) ist eine Grundeinheit jedes PowerPoint-Animations Effekts. Alle Animationseffekte sind tatsächlich eine Sammlung von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen einmal zu einer benutzerdefinierten Animation kombinieren und in anderen Präsentationen wiederverwenden. Wenn Sie ein neues Verhalten zu einem standardmäßigen PowerPoint-Animations Effekt hinzufügen, wird es zu einer anderen benutzerdefinierten Animation. Zum Beispiel können Sie das Wiederholungsverhalten einer Animation hinzufügen, um sie ein paar Mal wiederholen zu lassen.

[**Animationspunkt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) ist ein Punkt, an dem das Verhalten angewendet werden soll.

## **Animations-Zeitlinie**
[**Sequenz**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) ist eine Sammlung von Animationseffekten, die auf eine bestimmte Form angewendet werden.

[**Zeitlinie**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) ist eine Menge von Sequenzen, die in einer bestimmten Folie verwendet werden. Es ist eine Animations-Engine, die seit PowerPoint 2002 vertreten ist. In früheren Versionen von PowerPoint war es eine Herausforderung, Animationseffekte zur Präsentation hinzuzufügen, was nur mit verschiedenen Workarounds erreicht werden konnte. Die Zeitlinie ersetzt die alte Klasse AnimationSettings und bietet ein klareres Objektmodell für die PowerPoint-Animation. Eine Folie kann nur eine Animationszeitlinie haben.

## **Interaktive Animation**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) ermöglicht es, Benutzeraktionen (z. B. einen Klick auf eine Schaltfläche) zu definieren, die eine bestimmte Animation starten. Trigger wurden nur in der neuesten Version von PowerPoint hinzugefügt.

## **Formanimation**
Aspose.Slides ermöglicht es, Animationen auf Formen anzuwenden, die tatsächlich Text, Rechtecke, Linien, Rahmen, OLE-Objekte usw. sein können.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über Formanimation**](/slides/androidjava/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie alle gleichen Klassen wie für die Formen verwenden. Es ist jedoch möglich, die PowerPoint-Animation nur auf Diagrammkategorien oder Diagrammserien anzuwenden. Sie können auch einen Animationseffekt auf ein Kategorieelement oder ein Serienelement anwenden.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über animierte Diagramme**](/slides/androidjava/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, Animationen auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über animierten Text**](/slides/androidjava/animated-text/).
{{% /alert %}}