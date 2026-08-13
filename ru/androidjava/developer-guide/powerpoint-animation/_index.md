---
title: Улучшите презентации PowerPoint с помощью анимаций на Android
linktitle: Анимация PowerPoint
type: docs
weight: 150
url: /ru/androidjava/powerpoint-animation/
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
- Android
- Java
- Aspose.Slides
description: "Изучите возможности Aspose.Slides для Android через Java при работе с анимациями PowerPoint. Этот общий обзор подчёркивает ключевые функции."
---
## **Введение**

Поскольку презентации предназначены для представления чего‑либо, их визуальный вид и интерактивное поведение всегда учитываются при их создании.

**PowerPoint animation** играет важную роль, позволяя сделать презентацию заметной и привлекательной для зрителей. Aspose.Slides for Android via Java предлагает широкий набор возможностей для добавления анимации в презентацию PowerPoint:

- применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.
- использовать несколько эффектов анимации PowerPoint для одной фигуры.
- использовать временную шкалу анимации для управления эффектами анимации.
- создавать пользовательскую анимацию.

В Aspose.Slides for Android via Java можно применять различные эффекты анимации к фигурам. Поскольку каждый элемент слайда, включая текст, изображения, объект OLE, таблицу и т. д., считается фигурой, это означает, что мы можем применить эффект анимации к каждому элементу слайда.

## **Эффекты анимации**
Aspose.Slides поддерживает **150+ анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball, эффект Zoom, а также специфические эффекты, такие как OLEObjectShow, OLEObjectOpen. Полный список эффектов анимации можно найти в перечислении [**EffectType**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttype/).

Кроме того, эти эффекты анимации можно использовать в сочетании с ними:

- [ColorEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SetEffect)

## **Пользовательская анимация**
В Aspose.Slides можно создавать собственные **пользовательские анимации**. Это достигается путем объединения нескольких поведений в новую пользовательскую анимацию.

[**Behavior**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Behavior) — строительный блок любого эффекта анимации PowerPoint. Все эффекты анимации на самом деле представляют собой набор поведений, объединённых в одну стратегию. Вы можете объединить поведения в пользовательскую анимацию один раз и повторно использовать её в других презентациях. Если вы добавите новое поведение в стандартный эффект анимации PowerPoint — это будет ещё одна пользовательская анимация. Например, можно добавить повторяющееся поведение к анимации, чтобы она повторялась несколько раз.

[**Animation Point**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Point) — точка, в которой должно применяться поведение.

## **Временная шкала анимации**
[**Sequence**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Sequence) — набор эффектов анимации, применяемых к конкретной фигуре.

[**Timeline**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/AnimationTimeLine) — набор последовательностей, используемых в конкретном слайде. Это движок анимации, представленный с PowerPoint 2002. В предыдущих версиях PowerPoint добавление эффектов анимации в презентацию было сложным и возможно только с различными обходными решениями. Timeline заменяет старый класс AnimationSettings и предоставляет более понятную объектную модель для анимации PowerPoint. Один слайд может иметь только одну временную шкалу анимации.

## **Интерактивная анимация**
[**Trigger**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/EffectTriggerType) позволяет определить действия пользователя (например, щелчок кнопки), которые запустят определённую анимацию. Триггеры были добавлены только в последнюю версию PowerPoint.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут быть текстом, прямоугольником, линией, рамкой, объектом OLE и т. д.

{{% alert color="info" %}} 
Подробнее [**Об анимации фигур**](/slides/ru/androidjava/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграмм или их рядам. Также можно применить эффект анимации к элементу категории или элементу ряда.

{{% alert color="info" %}} 
Подробнее [**Об анимированных диаграммах**](/slides/ru/androidjava/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Кроме анимированного текста, также можно применять анимацию к абзацу.

{{% alert color="info" %}} 
Подробнее [**Об анимированном тексте**](/slides/ru/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

### Сохранятся ли анимации при экспорте в PDF?

Нет. PDF — статический формат, поэтому анимации и [переходы между слайдами](/slides/ru/androidjava/slide-transition/) не воспроизводятся. Если требуется движение, экспортируйте в [HTML5](/slides/ru/androidjava/export-to-html5/), [анимированный GIF](/slides/ru/androidjava/convert-powerpoint-to-animated-gif/) или [видео](/slides/ru/androidjava/convert-powerpoint-to-video/) вместо этого.

### Могу ли я превратить анимированную презентацию в видео и контролировать частоту кадров и размер кадра?

Да. Вы можете [рендерить презентацию кадрами](/slides/ru/androidjava/convert-powerpoint-to-video/) и кодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы между слайдами воспроизводятся во время рендеринга.

### Сохранятся ли анимации при работе с ODP (а не только PPTX)?

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/androidjava/open-presentation/) и [записи](/slides/ru/androidjava/save-presentation/), но различия форматов означают, что некоторые эффекты могут выглядеть или вести себя слегка иначе. Проверяйте критические сценарии на реальных образцах.