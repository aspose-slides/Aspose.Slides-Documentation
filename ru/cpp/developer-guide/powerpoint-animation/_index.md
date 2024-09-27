---
title: Анимация PowerPoint
type: docs
weight: 150
url: /ru/cpp/powerpoint-animation/
keywords: "Анимация PowerPoint"
description: "Анимация PowerPoint, анимация слайдов PowerPoint с помощью Aspose.Slides."
---

Поскольку презентации предназначены для демонстрации чего-либо, их визуальное оформление и интерактивное поведение всегда принимаются во внимание при создании.

**Анимация PowerPoint** играет важную роль в том, чтобы сделать презентацию привлекательной и привлекательной для зрителей. Aspose.Slides для C++ предлагает широкий спектр опций для добавления анимации в презентацию PowerPoint:

- применять различные типы эффектов анимации PowerPoint к формам, диаграммам, таблицам, OLE-объектам и другим элементам презентации.
- использовать несколько эффектов анимации PowerPoint на форме.
- использовать временную шкалу анимации для управления эффектами анимации.
- создавать пользовательскую анимацию.

В Aspose.Slides для C++ различные эффекты анимации могут быть применены к формам. Поскольку каждый элемент на слайде, включая текст, картинки, OLE-объект, таблицу и т. д., рассматривается как форма, это означает, что мы можем применять эффект анимации к каждому элементу слайда.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **пространство имен** предоставляет классы для работы с анимациями PowerPoint.
## **Эффекты анимации**
Aspose.Slides поддерживает **150+ эффектов анимации**, включая базовые эффекты анимации, такие как Bounce, PathFootball, эффект увеличения и специфические эффекты анимации, такие как OLEObjectShow, OLEObjectOpen. Вы можете найти полный список эффектов анимации в [**перечислении EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Дополнительно эти эффекты анимации можно использовать в сочетании с ними:

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **Пользовательская анимация**
В Aspose.Slides возможно создать свои собственные **пользовательские анимации**. Это можно сделать, объединив несколько поведений в новую пользовательскую анимацию.

[**Поведение**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) является строительным элементом любого эффекта анимации PowerPoint. Все эффекты анимации фактически представляют собой набор поведений, объединенных в одну стратегию. Вы можете объединить поведения в пользовательскую анимацию один раз и использовать ее в других презентациях. Если вы добавите новое поведение в стандартный эффект анимации PowerPoint - это будет другая пользовательская анимация. Например, вы можете добавить поведение повтора к анимации, чтобы она повторялась несколько раз.

[**Анимационная точка**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) - это точка, где должно быть применено поведение.

## **Временная шкала анимации**
[**Последовательность**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) - это коллекция эффектов анимации, применяемых к конкретной форме.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) - это набор последовательностей, используемых в конкретном слайде. Это анимационный движок, представленный с PowerPoint 2002. В предыдущих версиях PowerPoint было сложно добавить эффекты анимации в презентацию, что можно было добиться только с помощью различных обходных путей. Временная шкала пришла на смену старому классу AnimationSettings и предоставляет более четкую объектную модель для анимации PowerPoint. Один слайд может иметь только одну временную шкалу анимации.
## **Интерактивная анимация**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) позволяет определить действия пользователя (например, щелчок кнопкой), которые вызовут начало определенной анимации. Триггеры были добавлены только в последней версии PowerPoint.

## **Анимация форм**
Aspose.Slides позволяет применять анимацию к формам, которые могут быть текстом, прямоугольником, линией, рамкой, OLE-объектом и т. д.

{{% alert color="primary" %}} 
Узнайте больше [**Об анимации форм**](/slides/ru/cpp/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм вы должны использовать те же классы, что и для форм. Тем не менее, возможна анимация PowerPoint только на категориях диаграммы или серии диаграммы. Вы также можете применить эффект анимации к элементу категории или элементу серии.

{{% alert color="primary" %}} 
Узнайте больше [**Об анимированных диаграммах**](/slides/ru/cpp/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Кроме анимированного текста, также возможно применять анимацию к абзацу.

{{% alert color="primary" %}} 
Узнайте больше [**Об анимированном тексте**](/slides/ru/cpp/animated-text/).
{{% /alert %}}