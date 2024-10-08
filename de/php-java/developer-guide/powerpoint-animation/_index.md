---
title: PowerPoint-Animation
type: docs
weight: 150
url: /de/php-java/powerpoint-animation/
keywords: "PowerPoint-Animation"
description: "PowerPoint-Animation, PowerPoint-Folienanimation mit Aspose.Slides."
---

Da Präsentationen dazu gedacht sind, etwas zu präsentieren, werden ihr visuelles Erscheinungsbild und interaktives Verhalten stets bei der Erstellung berücksichtigt.

**PowerPoint-Animation** spielt eine wichtige Rolle, um die Präsentation für die Zuschauer auffällig und attraktiv zu gestalten. Aspose.Slides für PHP über Java bietet eine Vielzahl von Optionen, um Animationen zu PowerPoint-Präsentationen hinzuzufügen:

- verschiedene Arten von PowerPoint-Animations-Effekten auf Formen, Diagramme, Tabellen, OLE-Objekte und andere Präsentationselemente anwenden.
- mehrere PowerPoint-Animations-Effekte auf einer Form verwenden.
- die Animationszeitachse verwenden, um Animationseffekte zu steuern.
- benutzerdefinierte Animationen erstellen.

In Aspose.Slides für PHP über Java können verschiedene Animationseffekte auf Formen angewendet werden. Da jedes Element auf der Folie, einschließlich Text, Bilder, OLE-Objekte, Tabellen usw., als Form betrachtet wird, bedeutet dies, dass wir Animations-Effekte auf jedes Element einer Folie anwenden können.

## **Animations-Effekte**
Aspose.Slides unterstützt **150+ Animations-Effekte**, einschließlich grundlegender Animations-Effekte wie Bounce, PathFootball, Zoom-Effekt und spezifische Animations-Effekte wie OLEObjectShow, OLEObjectOpen. Eine vollständige Liste der Animations-Effekte finden Sie in der [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype)-Enumeration.

Darüber hinaus können diese Animations-Effekte in Kombination mit den folgenden verwendet werden:

- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **Benutzerdefinierte Animation**
Es ist möglich, eigene **benutzerdefinierte Animationen** in Aspose.Slides zu erstellen. 
Dies kann erreicht werden, indem mehrere Verhaltensweisen zu einer neuen benutzerdefinierten Animation kombiniert werden.

[**Behavior**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) ist eine Grundeinheit jedes PowerPoint-Animations-Effekts. Alle Animations-Effekte sind tatsächlich eine Gruppe von Verhaltensweisen, die zu einer Strategie zusammengesetzt sind. Sie können Verhaltensweisen einmal in eine benutzerdefinierte Animation kombinieren und sie in anderen Präsentationen wiederverwenden. Wenn Sie ein neues Verhalten zu einem Standard-PowerPoint-Animations-Effekt hinzufügen, wird es zu einer anderen benutzerdefinierten Animation. Zum Beispiel können Sie ein Wiederholverhalten zu einer Animation hinzufügen, um sie ein paar Mal wiederholen zu lassen.

[**Animationspunkt**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) ist ein Punkt, an dem das Verhalten angewendet werden soll.

## **Animations-Zeitleiste**
[**Sequenz**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) ist eine Sammlung von Animations-Effekten, die auf eine konkrete Form angewendet werden.

[**Zeitleiste**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) ist eine Menge von Sequenzen, die in einer bestimmten Folie verwendet wird. Es ist eine Animations-Engine, die seit PowerPoint 2002 vertreten ist. In früheren PowerPoint-Versionen war es schwierig, Animations-Effekte zu Präsentationen hinzuzufügen, was nur mit verschiedenen Workarounds erreicht werden konnte. Die Zeitleiste ersetzt die alte Animations-Einstellungen-Klasse und bietet ein klareres Objektmodell für PowerPoint-Animationen. Eine Folie kann nur eine Animations-Zeitleiste haben.

## **Interaktive Animation**
[**Trigger**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) ermöglicht es, Benutzeraktionen (z. B. Tastendruck) zu definieren, die eine bestimmte Animation starten. Trigger wurden nur in der neuesten PowerPoint-Version hinzugefügt.

## **Form-Animation**
Aspose.Slides ermöglicht die Anwendung von Animationen auf Formen, die tatsächlich Text, Rechtecke, Linien, Rahmen, OLE-Objekte usw. sein können.

{{% alert color="primary" %}} 
Mehr lesen [**Über Form-Animation**](/slides/de/php-java/shape-animation/).
{{% /alert %}}

## **Animierte Diagramme**
Um animierte Diagramme zu erstellen, sollten Sie alle gleichen Klassen wie für die Formen verwenden. Es ist jedoch möglich, PowerPoint-Animationen nur auf Diagrammkategorien oder Diagrammserien anzuwenden. Sie können auch Animations-Effekte auf ein Kategorienelement oder ein Serienelement anwenden.

{{% alert color="primary" %}} 
Mehr lesen [**Über animierte Diagramme**](/slides/de/php-java/animated-charts/).
{{% /alert %}}

## **Animierter Text**
Neben animiertem Text ist es auch möglich, Animationen auf einen Absatz anzuwenden.

{{% alert color="primary" %}} 
Mehr lesen [**Über animierten Text**](/slides/de/php-java/animated-text/).
{{% /alert %}}