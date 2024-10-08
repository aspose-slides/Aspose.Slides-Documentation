---
title: Анимация PowerPoint
type: docs
weight: 150
url: /ru/java/powerpoint-animation/
keywords: "анимация PowerPoint"
description: "Анимация PowerPoint, анимация слайдов PowerPoint с Aspose.Slides."
---

Поскольку презентации предназначены для демонстрации чего-либо, их визуальное оформление и интерактивное поведение всегда учитываются при создании.

**Анимация PowerPoint** играет важную роль в том, чтобы сделать презентацию привлекательной и запоминающейся для зрителей. Aspose.Slides для Java предлагает широкий спектр опций для добавления анимации в презентацию PowerPoint:

- применение различных типов эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.
- использование нескольких эффектов анимации PowerPoint на одной фигуре.
- использование временной шкалы анимации для управления эффектами анимации.
- создание пользовательской анимации.

В Aspose.Slides для Java различные эффекты анимации могут применяться к фигурам. Так как каждый элемент на слайде, включая текст, картинки, объекты OLE, таблицы и т.д., считается фигурой, это означает, что мы можем применить эффект анимации ко всем элементам слайда.

## **Эффекты анимации**
Aspose.Slides поддерживает **150+ эффектов анимации**, включая основные эффекты анимации, такие как Упругость, ПутьФутбольногоМяча, Эффект Увеличения и специфические эффекты анимации, такие как OLEObjectShow, OLEObjectOpen. Полный список эффектов анимации можно найти в [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) перечислении.

Кроме того, эти эффекты анимации могут использоваться в сочетании с ними:

- [ColorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/java/com.aspose.slides/SetEffect)

## **Пользовательская анимация**
В Aspose.Slides можно создавать свои собственные **пользовательские анимации**. 
Это можно сделать, если объединить несколько поведений в новую пользовательскую анимацию.

[**Поведение**](https://reference.aspose.com/slides/java/com.aspose.slides/Behavior) является строительным блоком любого эффекта анимации PowerPoint. Все эффекты анимации на самом деле представляют собой набор поведений, составленных в одну стратегию. Вы можете объединить поведения в пользовательскую анимацию один раз и использовать ее в других презентациях. Если вы добавите новое поведение в стандартный эффект анимации PowerPoint - это будет другая пользовательская анимация. Например, вы можете добавить поведение повтора к анимации, чтобы она повторялась несколько раз.

[**Точка анимации**](https://reference.aspose.com/slides/java/com.aspose.slides/Point) - это точка, в которой должно быть применено поведение.

## **Временная шкала анимации**
[**Последовательность**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) - это коллекция эффектов анимации, применяемых к конкретной фигуре.

[**Временная шкала**](https://reference.aspose.com/slides/java/com.aspose.slides/AnimationTimeLine) - это набор последовательностей, используемых на конкретном слайде. Это анимационный движок, представленный с PowerPoint 2002. В предыдущих версиях PowerPoint было сложно добавлять эффекты анимации в презентацию, которые можно было добиться только с помощью различных обходных путей. Временная шкала приходит на смену старому классу AnimationSettings и предоставляет более четкую объектную модель для анимации PowerPoint. Один слайд может иметь только одну временную шкалу анимации.

## **Интерактивная анимация**
[**Триггер**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectTriggerType) позволяет определить действия пользователя (например, нажатие кнопки), которые запускают определенную анимацию. Триггеры были добавлены только в последней версии PowerPoint.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут на самом деле быть текстом, прямоугольником, линией, рамкой, объектом OLE и т.д.

{{% alert color="primary" %}} 
Читать далее [**О анимации фигур**](/slides/ru/java/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм вы должны использовать все те же классы, что и для фигур. Однако возможно использовать анимацию PowerPoint только для категорий диаграмм или серий диаграмм. Вы также можете применить эффект анимации к элементу категории или серии.

{{% alert color="primary" %}} 
Читать далее [**О анимированных диаграммах**](/slides/ru/java/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Кроме анимированного текста, также возможно применять анимацию к абзацу.

{{% alert color="primary" %}} 
Читать далее [**О анимированном тексте**](/slides/ru/java/animated-text/).
{{% /alert %}}