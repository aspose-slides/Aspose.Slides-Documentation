---
title: Анимация PowerPoint
type: docs
weight: 150
url: /php-java/powerpoint-animation/
keywords: "Анимация PowerPoint"
description: "Анимация PowerPoint, анимация слайдов PowerPoint с Aspose.Slides."
---

Поскольку презентации предназначены для представления чего-либо, их визуальная привлекательность и интерактивное поведение всегда учитываются при создании.

**Анимация PowerPoint** играет важную роль в том, чтобы сделать презентацию привлекательной и запоминающейся для зрителей. Aspose.Slides для PHP через Java предлагает широкий спектр вариантов для добавления анимации в презентацию PowerPoint:

- применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, OLE-объектам и другим элементам презентации.
- использовать несколько эффектов анимации PowerPoint на одной фигуре.
- использовать временную шкалу анимации для управления эффектами анимации.
- создавать пользовательскую анимацию.

В Aspose.Slides для PHP через Java различные эффекты анимации могут применяться к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, OLE-объекты, таблицы и т.д., считается фигурой, это означает, что мы можем применять эффекты анимации к каждому элементу слайда.

## **Эффекты анимации**
Aspose.Slides поддерживает **более 150 эффектов анимации**, включая базовые эффекты анимации, такие как Bounce, PathFootball, Zoom effect и специфические эффекты анимации, такие как OLEObjectShow, OLEObjectOpen. Вы можете найти полный список эффектов анимации в [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) перечислении.

Кроме того, эти эффекты анимации можно комбинировать с:

- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **Пользовательская анимация**
В Aspose.Slides можно создавать свои собственные **пользовательские анимации**. Это можно сделать, объединив несколько поведений в одну новую пользовательскую анимацию.

[**Поведение**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) является строительным элементом любого эффекта анимации PowerPoint. Все эффекты анимации на самом деле представляют собой набор поведений, составленных в одну стратегию. Вы можете объединить поведения в пользовательскую анимацию один раз и использовать ее в других презентациях. Если вы добавите новое поведение в стандартный эффект анимации PowerPoint - это будет другая пользовательская анимация. Например, вы можете добавить поведение повторения к анимации, чтобы она повторялась несколько раз.

[**Точка анимации**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) - это точка, в которой должно применяться поведение.

## **Временная шкала анимации**
[**Последовательность**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) - это коллекция эффектов анимации, применяемых к конкретной фигуре.

[**Временная шкала**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) - это набор последовательностей, используемых на конкретном слайде. Это движок анимации, представленный с PowerPoint 2002 года. В предыдущих версиях PowerPoint было сложно добавлять эффекты анимации в презентации, что можно было достичь только с помощью различных обходных путей. Временная шкала заменяет старый класс AnimationSettings и предоставляет более четкую объектную модель для анимации PowerPoint. На одном слайде может быть только одна временная шкала анимации.

## **Интерактивная анимация**
[**Триггер**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) позволяет определить действия пользователей (например, нажатие кнопки), которые запустят определенную анимацию. Триггеры были добавлены только в последней версии PowerPoint.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут быть текстом, прямоугольником, линией, рамкой, OLE-объектом и т.д.

{{% alert color="primary" %}} 
Читать далее [**О анимации фигур**](/slides/php-java/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм вам следует использовать все те же классы, что и для фигур. Однако анимация PowerPoint может использоваться только на категориях диаграмм или сериях диаграмм. Вы также можете применить эффект анимации к элементу категории или элементу серии.

{{% alert color="primary" %}} 
Читать далее [**О анимированных диаграммах**](/slides/php-java/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Кроме анимированного текста, также можно применить анимацию к абзацу.

{{% alert color="primary" %}} 
Читать далее [**О анимированном тексте**](/slides/php-java/animated-text/).
{{% /alert %}}