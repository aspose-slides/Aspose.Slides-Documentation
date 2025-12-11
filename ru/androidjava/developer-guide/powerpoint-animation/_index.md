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
description: "Исследуйте возможности Aspose.Slides для Android через Java при работе с анимациями PowerPoint. Этот общий обзор выделяет ключевые особенности."
---

Поскольку презентации предназначены для представления чего‑либо, их визуальный вид и интерактивное поведение всегда учитываются при их создании.

**PowerPoint animation** играет важную роль, позволяя сделать презентацию привлекательной и заметной для зрителей. Aspose.Slides for Android via Java предлагает широкий набор возможностей для добавления анимации в презентацию PowerPoint:

- применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.
- использовать несколько эффектов анимации PowerPoint для одной фигуры.
- использовать временную шкалу анимации для управления эффектами.
- создавать пользовательскую анимацию.

В Aspose.Slides for Android via Java различные эффекты анимации могут применяться к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, объект OLE, таблицу и т. д., считается фигурой, это означает, что мы можем применять анимацию к каждому элементу слайда.

## **Эффекты анимации**
Aspose.Slides поддерживает **150+ анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball, Zoom, а также специфические эффекты, такие как OLEObjectShow, OLEObjectOpen. Полный список анимационных эффектов можно посмотреть в перечислении [**EffectType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype/).

Кроме того, эти анимационные эффекты могут использоваться в комбинации друг с другом:

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **Пользовательская анимация**
Можно создавать собственные **пользовательские анимации** в Aspose.Slides. Это достигается путем комбинирования нескольких поведений в новую пользовательскую анимацию.

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) — строительный блок любого эффекта анимации PowerPoint. Все эффекты анимации на самом деле представляют собой набор поведений, объединённых в одну стратегию. Вы можете один раз объединить поведения в пользовательскую анимацию и затем повторно использовать её в других презентациях. Если добавить новое поведение в стандартный эффект анимации PowerPoint, получится другая пользовательская анимация. Например, можно добавить повторяющееся поведение к анимации, чтобы она воспроизводилась несколько раз.

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) — точка, в которой должно применяться поведение.

## **Временная шкала анимации**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) — набор анимационных эффектов, применяемый к конкретной фигуре.

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) — набор последовательностей, используемых в конкретном слайде. Это анимационный движок, присутствующий с PowerPoint 2002. В предыдущих версиях PowerPoint добавление анимационных эффектов в презентацию было сложным и возможно только с различными обходными решениями. Timeline заменил старый класс AnimationSettings и предоставляет более понятную объектную модель для анимации PowerPoint. Один слайд может иметь только одну временную шкалу анимации.

## **Интерактивная анимация**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) позволяет определить действия пользователя (например, щелчок кнопкой), которые запускают определённую анимацию. Триггеры добавлены только в последних версиях PowerPoint.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которыми могут быть текст, прямоугольник, линия, рамка, объект OLE и т. д.

{{% alert color="primary" %}} 
Подробнее [**Об анимации фигур**](/slides/ru/androidjava/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или её сериям. Также можно применить анимационный эффект к элементу категории или к элементу серии.

{{% alert color="primary" %}} 
Подробнее [**Об анимированных диаграммах**](/slides/ru/androidjava/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Кроме анимированного текста, также возможно применять анимацию к абзацу.

{{% alert color="primary" %}} 
Подробнее [**Об анимированном тексте**](/slides/ru/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Будут ли анимации сохранены при экспорте в PDF?**

Нет. PDF — статический формат, поэтому анимации и [переходы слайдов](/slides/ru/androidjava/slide-transition/) не проигрываются. Если требуется движение, экспортируйте в [HTML5](/slides/ru/androidjava/export-to-html5/), [анимированный GIF](/slides/ru/androidjava/convert-powerpoint-to-animated-gif/) или [видео](/slides/ru/androidjava/convert-powerpoint-to-video/) вместо этого.

**Могу ли я преобразовать анимированную презентацию в видео и задать частоту кадров и размер кадра?**

Да. Вы можете [визуализировать презентацию кадрами](/slides/ru/androidjava/convert-powerpoint-to-video/) и закодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Сохранятся ли анимации при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/androidjava/open-presentation/) и [записи](/slides/ru/androidjava/save-presentation/), однако различия форматов могут привести к небольшим различиям во внешнем виде или поведении некоторых эффектов. Проверяйте критические случаи на реальных образцах.