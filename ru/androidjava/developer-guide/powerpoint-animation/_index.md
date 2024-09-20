---
title: Анимация PowerPoint
type: docs
weight: 150
url: /androidjava/powerpoint-animation/
keywords: "Анимация PowerPoint"
description: "Анимация PowerPoint, анимация слайдов PowerPoint с использованием Aspose.Slides."
---

Поскольку презентации предназначены для представления чего-либо, их визуальное оформление и интерактивное поведение всегда учитываются при их создании.

**Анимация PowerPoint** играет важную роль в том, чтобы сделать презентацию привлекательной и интересной для зрителей. Aspose.Slides для Android на Java предлагает широкий спектр опций для добавления анимации в презентацию PowerPoint:

- применять различные типы эффектов анимации PowerPoint на фигурах, графиках, таблицах, OLE-объектах и других элементах презентации.
- использовать несколько эффектов анимации PowerPoint на одной фигуре.
- использовать временную шкалу анимации для контроля анимационных эффектов.
- создавать пользовательскую анимацию.

В Aspose.Slides для Android на Java различные анимационные эффекты могут применяться к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, OLE-объекты, таблицы и т. д., рассматривается как фигура, это означает, что мы можем применять анимационные эффекты к каждому элементу слайда.

## **Эффекты анимации**
Aspose.Slides поддерживает **более 150 эффектов анимации**, включая основные эффекты анимации, такие как Отскок, ПутьФутбола, Зум и специфические эффекты анимации, такие как OLEObjectShow, OLEObjectOpen. Полный список эффектов анимации можно найти в [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) перечислении.

Кроме того, эти эффекты анимации могут использоваться в комбинации с ними:

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **Пользовательская анимация**
Возможно создать собственные **пользовательские анимации** в Aspose.Slides. 
Это можно достичь, если объединить несколько поведений в одну новую пользовательскую анимацию.

[**Поведение**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) является строительным элементом любого эффекта анимации PowerPoint. Все эффекты анимации на самом деле представляют собой набор поведений, объединенных в одну стратегию. Вы можете объединять поведения в пользовательскую анимацию один раз и использовать ее в других презентациях. Если вы добавите новое поведение в стандартный эффект анимации PowerPoint, это будет другая пользовательская анимация. Например, вы можете добавить поведение повторения к анимации, чтобы она повторялась несколько раз.

[**Точка анимации**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) — это точка, где должно применяться поведение.

## **Временная шкала анимации**
[**Последовательность**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) является коллекцией эффектов анимации, применяемых к конкретной фигуре.

[**Временная шкала**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) — это набор последовательностей, используемых в конкретном слайде. Это анимационный движок, представленный с PowerPoint 2002. В предыдущих версиях PowerPoint было сложно добавлять эффекты анимации в презентацию, что можно было сделать только с различными обходами. Временная шкала приходит на замену старому классу AnimationSettings и предоставляет более четкую объектную модель для анимации PowerPoint. В одном слайде может быть только одна временная шкала анимации.

## **Интерактивная анимация**
[**Триггер**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) позволяет определить действия пользователя (например, щелчок кнопки), которые запустят определенную анимацию. Триггеры были добавлены только в последней версии PowerPoint.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут быть на самом деле текстом, прямоугольником, линией, рамкой, OLE-объектом и т. д.

{{% alert color="primary" %}} 
Читать подробнее [**О анимации фигур**](/slides/androidjava/shape-animation/).
{{% /alert %}}

## **Анимированные графики**
Для создания анимированных графиков следует использовать все те же классы, что и для фигур. Однако возможно использовать анимацию PowerPoint только на категориях графика или сериях графика. Вы также можете применить эффект анимации к элементу категории или элементу серии.

{{% alert color="primary" %}} 
Читать подробнее [**О анимированных графиках**](/slides/androidjava/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Кроме анимированного текста, также возможно применять анимацию к абзцу.

{{% alert color="primary" %}} 
Читать подробнее [**О анимированном тексте**](/slides/androidjava/animated-text/).
{{% /alert %}}