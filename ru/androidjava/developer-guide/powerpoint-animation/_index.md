---
title: Улучшение презентаций PowerPoint с помощью анимаций на Android
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
description: "Изучите возможности Aspose.Slides для Android через Java в работе с анимациями PowerPoint. Этот общий обзор выделяет ключевые функции."
---

Поскольку презентации предназначены для представления чего-то, их визуальный вид и интерактивное поведение всегда учитываются при их создании.

**PowerPoint animation** играет важную роль, чтобы сделать презентацию притягательной и привлекательной для зрителей. Aspose.Slides for Android via Java предлагает широкий набор вариантов для добавления анимации в презентацию PowerPoint:

- применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.
- использовать несколько эффектов анимации PowerPoint для одной фигуры.
- использовать временную шкалу анимации для управления эффектами анимации.
- создавать пользовательскую анимацию.

В Aspose.Slides for Android via Java различные эффекты анимации могут применяться к фигурам. Поскольку каждый элемент слайда, включая текст, изображения, объект OLE, таблицу и т.д., считается фигурой, это значит, что мы можем применять эффект анимации к каждому элементу слайда.

## **Эффекты анимации**
Aspose.Slides поддерживает **150+ анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball, Zoom effect и специфические эффекты, такие как OLEObjectShow, OLEObjectOpen. Полный список анимационных эффектов можно найти в перечислении [**EffectType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype/).

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
Можно создавать собственные **пользовательские анимации** в Aspose.Slides. Это достигается, если объединить несколько поведений в новую пользовательскую анимацию.

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) – это строительный блок любого эффекта анимации PowerPoint. Все эффекты анимации фактически представляют собой набор поведений, собранных в одну стратегию. Вы можете один раз объединить поведения в пользовательскую анимацию и повторно использовать её в других презентациях. Если вы добавите новое поведение в стандартный эффект анимации PowerPoint, это станет еще одной пользовательской анимацией. Например, вы можете добавить повторяющееся поведение к анимации, чтобы она повторялась несколько раз.

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) — точка, к которой должно применяться поведение.

## **Временная линия анимации**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) — это набор анимационных эффектов, применяемых к конкретной фигуре.

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) — это набор последовательностей (Sequences), используемых в конкретном слайде. Это анимационный движок, представленный начиная с PowerPoint 2002. В предыдущих версиях PowerPoint добавление анимационных эффектов в презентацию было сложной задачей, которую можно было решить только с помощью различных обходных решений. Timeline заменил старый класс AnimationSettings и предоставляет более понятную объектную модель для анимации PowerPoint. Один слайд может иметь только одну анимационную временную шкалу.

## **Интерактивная анимация**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) позволяет определить действия пользователя (например, щелчок кнопки), которые запускают определённую анимацию. Триггеры были добавлены только в последнюю версию PowerPoint.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут быть текстом, прямоугольником, линией, рамкой, объектом OLE и т.д.

{{% alert color="primary" %}} 
Подробнее [**Об анимации фигур**](/slides/ru/androidjava/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграмм или сериям диаграмм. Вы также можете применить эффект анимации к элементу категории или элементу серии.

{{% alert color="primary" %}} 
Подробнее [**Об анимированных диаграммах**](/slides/ru/androidjava/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Помимо анимированного текста, также можно применять анимацию к абзацу.

{{% alert color="primary" %}} 
Подробнее [**Об анимированном тексте**](/slides/ru/androidjava/animated-text/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Сохранятся ли анимации при экспорте в PDF?**

Нет. PDF — статический формат, поэтому анимации и [переходы слайдов](/slides/ru/androidjava/slide-transition/) не воспроизводятся. Если требуется движение, экспортируйте в [HTML5](/slides/ru/androidjava/export-to-html5/), [animated GIF](/slides/ru/androidjava/convert-powerpoint-to-animated-gif/), или [video](/slides/ru/androidjava/convert-powerpoint-to-video/) вместо этого.

**Могу ли я превратить анимированную презентацию в видео и управлять частотой кадров и размером кадра?**

Да. Вы можете [рендерить презентацию в виде кадров](/slides/ru/androidjava/convert-powerpoint-to-video/) и закодировать их в видео (например, с помощью ffmpeg), выбрав FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Сохранится ли анимация при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/androidjava/open-presentation/) и [записи](/slides/ru/androidjava/save-presentation/), но различия форматов могут привести к небольшим отличиям в отображении или поведении некоторых эффектов. Проверяйте критические случаи на реальных образцах.