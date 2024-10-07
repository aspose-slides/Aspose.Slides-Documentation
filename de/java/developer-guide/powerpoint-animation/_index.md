---
title: PowerPoint-Animation
type: docs
weight: 150
url: /java/powerpoint-animation/
keywords: "PowerPoint-Animation"
description: "PowerPoint-Animation, PowerPoint-Folienanimation mit Aspose.Slides."
---

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, wird deren visuelle Erscheinung und interaktives Verhalten immer beim Erstellen berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um Präsentationen auffällig und ansprechend für die Zuschauer zu gestalten. Aspose.Slides für Java bietet eine Vielzahl von Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- verschiedene Arten von PowerPoint-Animationseffekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente anwenden.
- mehrere PowerPoint-Animationseffekte auf eine Form anwenden.
- Zeitleiste für Animationen nutzen, um Animationseffekte zu steuern.
- benutzerdefinierte Animationen erstellen.

In Aspose.Slides für Java können verschiedene Animationseffekte auf den Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE-Objekte, Tabellen usw. als eine Form betrachtet wird, bedeutet dies, dass wir Animationseffekte auf jedes Element einer Folie anwenden können.

## **Animationseffekte**
Aspose.Slides unterstützt **über 150 Animationseffekte**, darunter grundlegende Animationseffekte wie Bounce, PathFootball, Zoom-Effekt und spezifische Animationseffekte wie OLEObjectShow, OLEObjectOpen. Sie finden eine vollständige Liste der Animationseffekte in der [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype)-Enumeration.

Zusätzlich können diese Animationseffekte in Kombination mit folgenden verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/java/com.aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. 
Dies kann erreicht werden, wenn Sie mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombinieren.

[**Verhalten**](https://reference.aspose.com/slides/java/com.aspose.slides/Behavior) ist eine Baueinheit eines jeden PowerPoint-Animationseffekts. Alle Animationseffekte bestehen tatsächlich aus einer Reihe von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen einmal zu einer benutzerdefinierten Animation kombinieren und in anderen Präsentationen wiederverwenden. Wenn Sie ein neues Verhalten zu einem standardmäßigen PowerPoint-Animationseffekt hinzufügen - wird es eine weitere benutzerdefinierte Animation sein. Zum Beispiel können Sie ein Wiederholverhalten zu einer Animation hinzufügen, um sie mehrmals wiederholen zu lassen.

[**Animationspunkt**](https://reference.aspose.com/slides/java/com.aspose.slides/Point) ist der Punkt, an dem das Verhalten angewendet werden soll.

## **Animation-Zeitleiste**
[**Sequenz**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) ist eine Sammlung von Animationseffekten, die auf eine bestimmte Form angewendet werden.

[**Zeitleiste**](https://reference.aspose.com/slides/java/com.aspose.slides/AnimationTimeLine) ist eine Reihe von Sequenzen, die in einer bestimmten Folie verwendet werden. Es handelt sich um eine Animationsengine, die seit PowerPoint 2002 vertreten ist. In früheren Versionen von PowerPoint war es schwierig, Animationseffekte zur Präsentation hinzuzufügen, was nur mit unterschiedlichen Workarounds erreicht werden konnte. Die Zeitleiste ersetzt die alte Klasse AnimationSettings und bietet ein klareres Objektmodell für PowerPoint-Animationen. Eine Folie kann nur eine Animationszeitleiste haben.

## **Interaktive Animation**
[**Auslöser**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectTriggerType) ermöglicht es, Benutzeraktionen (z.B. Mausklick) zu definieren, die eine bestimmte Animation starten. Auslöser wurden nur in der neuesten Version von PowerPoint hinzugefügt.

## **Formanimation**
Aspose.Slides ermöglicht es, Animationen auf Formen anzuwenden, die tatsächlich Text, Rechtecke, Linien, Rahmen, OLE-Objekte usw. sein können.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über Formanimation**](/slides/java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie dieselben Klassen wie für die Formen verwenden. Es ist jedoch möglich, PowerPoint-Animationen nur auf Diagrammkategorien oder Diagrammserien anzuwenden. Sie können auch einen Animationseffekt auf ein Kategorienelement oder ein Serieelement anwenden.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über animierte Diagramme**](/slides/java/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, Animationen auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Erfahren Sie mehr [**Über animierten Text**](/slides/java/animated-text/).
{{% /alert %}}