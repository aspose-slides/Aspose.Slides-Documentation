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
- анимированный OLE объект
- анимированное изображение
- анимированная таблица
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Изучите возможности Aspose.Slides для Android через Java при работе с анимацией PowerPoint. Этот общий обзор выделяет ключевые функции."
---
## **Введение**

Поскольку презентации предназначены для представления информации, их визуальный вид и интерактивное поведение всегда учитываются при создании.

**PowerPoint animation** играет важную роль в том, чтобы презентация была привлекательной и увлекательной для зрителей. Aspose.Slides предоставляет широкий набор возможностей для добавления анимации в презентации PowerPoint:

- Применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, OLE‑объектам и другим элементам презентации.
- Использовать несколько эффектов анимации PowerPoint на одной фигуре.
- Использовать временную шкалу анимации для управления эффектами.
- Создавать пользовательские анимации.

## **Эффекты анимации**

Aspose.Slides поддерживает **более 150 эффектов анимации**, включая базовые эффекты, такие как Bounce, PathFootball и Zoom, а также специфические эффекты, такие как OLEObjectShow и OLEObjectOpen. Полный список можно найти в классе [EffectType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttype/) .

Кроме того, эти анимационные эффекты могут использоваться в комбинации со следующими поведениями:

- [ColorEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SetEffect)

## **Пользовательская анимация**

Для полных примеров на Java, которые создают, исследуют и модифицируют поведения и редактируемые траектории движения, см. [Пользовательская анимация](/slides/ru/java/custom-animation/).

В Aspose.Slides можно создавать собственные **пользовательские анимации**. Это достигается комбинированием нескольких поведений в новую пользовательскую анимацию.

[Behavior](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/behavior/) является строительным блоком эффекта анимации PowerPoint. Комбинируйте поведения, чтобы настроить эффект, или добавьте поведение, чтобы расширить предопределённый эффект. Повторение настраивается через параметры тайминга, а не отдельным поведением повторения.

[Animation Point](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/point/) — это точка, к которой должно быть применено поведение.

## **Временная шкала анимации**

[Sequence](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/sequence/) — это коллекция анимационных эффектов, которые могут быть направлены на разные фигуры.

[Timeline](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/animationtimeline/) — набор последовательностей, используемых на конкретном слайде. Это анимационный движок, представленный в PowerPoint 2002. В более ранних версиях PowerPoint добавление анимационных эффектов в презентации было сложным и возможно только с различными обходными путями. Временная шкала предоставляет более понятную объектную модель для анимаций PowerPoint. У слайда может быть только одна временная шкала анимации.

## **Интерактивная анимация**

[Trigger](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttriggertype/) позволяет определить действия пользователя, например щелчок кнопки, которые запускают определённую анимацию.

## **Анимация фигур**

Aspose.Slides позволяет применять анимации к фигурам, которые могут включать текст, прямоугольники, линии, рамки, OLE‑объекты и многое другое.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимации фигур**](/slides/ru/androidjava/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**

Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или к сериям диаграммы. Также можно применить анимационные эффекты к элементу категории или к элементу серии.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимированных диаграммах**](/slides/ru/androidjava/animated-charts/).
{{% /alert %}}

## **Анимированный текст**

Помимо анимации текста, можно также применить анимацию к абзацу.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимированном тексте**](/slides/ru/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Сохранится ли анимация при экспорте в PDF?**

Нет. PDF — статический формат, поэтому анимации и [slide transitions](/slides/ru/androidjava/slide-transition/) не воспроизводятся. Если требуется движение, экспортируйте в [HTML5](/slides/ru/androidjava/export-to-html5/), [animated GIF](/slides/ru/androidjava/convert-powerpoint-to-animated-gif/) или [video](/slides/ru/androidjava/convert-powerpoint-to-video/) вместо этого.

**Могу ли я превратить анимированную презентацию в видео и контролировать частоту кадров и размер кадра?**

Да. Вы можете [render the presentation as frames](/slides/ru/androidjava/convert-powerpoint-to-video/) и закодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Сохранится ли анимация при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [reading](/slides/ru/androidjava/open-presentation/) и [writing](/slides/ru/androidjava/save-presentation/), но это не гарантирует сохранение анимаций. При конвертации в ODP пользовательские данные анимации могут быть потеряны. См. [Custom Animation for Java](/slides/ru/java/custom-animation/) для примеров и рекомендаций по проверке совместимости форматов.