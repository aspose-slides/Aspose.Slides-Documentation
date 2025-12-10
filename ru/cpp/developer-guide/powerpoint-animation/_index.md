---
title: Улучшите презентации PowerPoint с помощью анимаций в C++
linktitle: Анимация PowerPoint
type: docs
weight: 150
url: /ru/cpp/powerpoint-animation/
keywords:
- добавить анимацию
- обновить анимацию
- изменить анимацию
- удалить анимацию
- управлять анимацией
- контролировать анимацию
- эффект анимации
- анимация PowerPoint
- временная шкала анимации
- интерактивная анимация
- пользовательская анимация
- анимация фигур
- анимированная диаграмма
- анимированный текст
- анимированная фигура
- анимированный объект OLE
- анимированное изображение
- анимированная таблица
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как добавить и управлять продвинутыми эффектами анимации в Aspose.Slides для C++, чтобы создавать динамические презентации PowerPoint и OpenDocument."
---

Поскольку презентации предназначены для представления чего‑либо, их визуальный вид и интерактивное поведение всегда учитываются при их создании.

**PowerPoint animation** играет важную роль, чтобы сделать презентацию заметной и привлекательной для зрителей. Aspose.Slides for C++ предлагает широкий спектр возможностей добавлять анимацию в презентацию PowerPoint:

- применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.
- использовать несколько эффектов анимации PowerPoint на одной фигуре.
- использовать временную шкалу анимации для управления эффектами анимации.
- создавать пользовательскую анимацию.

В Aspose.Slides for C++ можно применять различные анимационные эффекты к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, объект OLE, таблицу и т.д., считается фигурой, это означает, что мы можем применять эффект анимации к каждому элементу слайда.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **namespace** предоставляет классы для работы с анимациями PowerPoint.

## **Эффекты анимации**
Aspose.Slides поддерживает **более 150 анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball, Zoom, а также специфические эффекты, например OLEObjectShow, OLEObjectOpen. Полный список анимационных эффектов можно найти в перечислении [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Кроме того, эти анимационные эффекты можно использовать в комбинации с ними:

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **Пользовательская анимация**
В Aspose.Slides можно создавать собственные **пользовательские анимации**. 
Это можно достичь, объединив несколько поведений в новую пользовательскую анимацию.

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) является базовым элементом любого эффекта анимации PowerPoint. Все анимационные эффекты на самом деле представляют собой набор поведений, объединённых в одну стратегию. Вы можете объединить поведения в пользовательскую анимацию один раз и повторно использовать её в других презентациях. Если добавить новое поведение в стандартный эффект анимации PowerPoint, получится другая пользовательская анимация. Например, можно добавить поведение повторения к анимации, чтобы она повторялась несколько раз.

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) — это точка, в которой должно применяться поведение.

## **Временная шкала анимации**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) — это набор анимационных эффектов, применяемых к конкретной фигуре.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) представляет собой набор последовательностей (Sequences), используемых в конкретном слайде. Это анимационный движок, представленный, начиная с PowerPoint 2002. В предыдущих версиях PowerPoint добавление анимационных эффектов в презентацию было сложной задачей, решаемой лишь различными обходными путями. Временная шкала заменяет старый класс AnimationSettings и предоставляет более понятную объектную модель для анимации PowerPoint. Один слайд может иметь только одну временную шкалу анимации.

## **Интерактивная анимация**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) позволяет определить действия пользователя (например, щелчок кнопки), которые запустят определённую анимацию. Триггеры были добавлены только в последнюю версию PowerPoint.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут быть текстом, прямоугольником, линией, рамкой, объектом OLE и т.д.

{{% alert color="primary" %}} 
Подробнее [**Об анимации фигур**](/slides/ru/cpp/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или её сериям. Также можно применить анимационный эффект к элементу категории или к элементу серии.

{{% alert color="primary" %}} 
Подробнее [**Об анимированных диаграммах**](/slides/ru/cpp/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Помимо анимированного текста, также можно применять анимацию к абзацу.

{{% alert color="primary" %}} 
Подробнее [**Об анимированном тексте**](/slides/ru/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Сохранятся ли анимации при экспорте в PDF?**

Нет. PDF — статический формат, поэтому анимации и [переходы слайдов](/slides/ru/cpp/slide-transition/) не воспроизводятся. Если требуется движение, экспортируйте в [HTML5](/slides/ru/cpp/export-to-html5/), [анимированный GIF](/slides/ru/cpp/convert-powerpoint-to-animated-gif/), или [видео](/slides/ru/cpp/convert-powerpoint-to-video/) вместо этого.

**Могу ли я превратить анимированную презентацию в видео и контролировать частоту кадров и размер кадра?**

Да. Вы можете [рендерить презентацию в виде кадров](/slides/ru/cpp/convert-powerpoint-to-video/) и кодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Останутся ли анимации неизменными при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/cpp/open-presentation/) и [записи](/slides/ru/cpp/save-presentation/), однако различия форматов могут привести к небольшим различиям в отображении или поведении некоторых эффектов. Проверяйте критические случаи на реальных образцах.