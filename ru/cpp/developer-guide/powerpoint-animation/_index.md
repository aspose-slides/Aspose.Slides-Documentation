---
title: Улучшить презентации PowerPoint с помощью анимаций в C++
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
description: "Узнайте, как добавлять и управлять расширенными эффектами анимации в Aspose.Slides для C++, чтобы создавать динамичные презентации PowerPoint и OpenDocument."
---

Поскольку презентации предназначены для представления чего‑то, их визуальный вид и интерактивное поведение всегда учитываются при их создании.

**PowerPoint animation** играет важную роль, позволяя сделать презентацию привлекательно визуально для зрителей. Aspose.Slides for C++ предлагает широкий набор возможностей для добавления анимации в презентацию PowerPoint:

- применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.  
- использовать несколько эффектов анимации PowerPoint для одной фигуры.  
- использовать временную шкалу анимации для управления эффектами анимации.  
- создавать пользовательскую анимацию.

В Aspose.Slides for C++ различные эффекты анимации могут быть применены к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, объект OLE, таблицу и т.п., считается фигурой, это значит, что мы можем применить эффект анимации к каждому элементу слайда.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **namespace** предоставляет классы для работы с анимациями PowerPoint.
## **Эффекты анимации**
Aspose.Slides поддерживает **150+ эффектов анимации**, включая базовые эффекты, такие как Bounce, PathFootball, Zoom и специфические эффекты, такие как OLEObjectShow, OLEObjectOpen. Полный список эффектов анимации можно найти в [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) перечислении.

Кроме того, эти эффекты анимации могут использоваться в комбинации друг с другом:

- [ColorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **Пользовательская анимация**
В Aspose.Slides можно создавать собственные **пользовательские анимации**. Это можно сделать, объединив несколько behaviours в новую пользовательскую анимацию.

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) является строительным блоком любого эффекта анимации PowerPoint. Все эффекты анимации фактически представляют собой набор behaviours, объединённых в одну стратегию. Вы можете объединить поведения в пользовательскую анимацию один раз и переиспользовать её в других презентациях. Если добавить новое поведение в стандартный эффект анимации PowerPoint — это станет ещё одной пользовательской анимацией. Например, можно добавить повторяющееся поведение к анимации, чтобы она воспроизводилась несколько раз.

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) — это точка, в которой должно применяться поведение.

## **Временная шкала анимации**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) — набор эффектов анимации, применяемый к конкретной фигуре.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) — набор Sequences, используемых на конкретном слайде. Это анимационный движок, представленный с PowerPoint 2002. В предыдущих версиях PowerPoint было сложно добавить эффекты анимации в презентацию, это могло быть реализовано только с различными обходными решениями. Временная шкала пришла на смену старому классу AnimationSettings и обеспечивает более понятную объектную модель анимации PowerPoint. Один слайд может иметь только одну временную шкалу анимации.

## **Интерактивная анимация**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) позволяет определить действия пользователя (например, щелчок кнопки), которые запускают определённую анимацию. Триггеры были добавлены только в последних версиях PowerPoint.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут быть фактически текстом, прямоугольником, линией, рамкой, объектом OLE и т.д.

{{% alert color="primary" %}} 
Читайте дальше [**О анимации фигур**](/slides/ru/cpp/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или к её рядам. Можно также применить эффект анимации к элементу категории или к элементу ряда.

{{% alert color="primary" %}} 
Читайте дальше [**Об анимированных диаграммах**](/slides/ru/cpp/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Кроме анимированного текста, также можно применять анимацию к абзацу.

{{% alert color="primary" %}} 
Читайте дальше [**Об анимированном тексте**](/slides/ru/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Сохранится ли анимация при экспорте в PDF?**

Нет. PDF — статический формат, поэтому анимации и [переходы слайдов](/slides/ru/cpp/slide-transition/) не воспроизводятся. Если требуется движение, экспортируйте в [HTML5](/slides/ru/cpp/export-to-html5/), [анимированный GIF](/slides/ru/cpp/convert-powerpoint-to-animated-gif/) или [видео](/slides/ru/cpp/convert-powerpoint-to-video/) вместо этого.

**Можно ли превратить анимированную презентацию в видео и контролировать частоту кадров и размер кадра?**

Да. Вы можете [вставить презентацию как кадры](/slides/ru/cpp/convert-powerpoint-to-video/) и закодировать их в видео (например, при помощи ffmpeg), задав FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Сохранятся ли анимации при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/cpp/open-presentation/) и [записи](/slides/ru/cpp/save-presentation/), но различия форматов означают, что некоторые эффекты могут выглядеть или вести себя немного иначе. Проверяйте критические случаи на реальных образцах.