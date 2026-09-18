---
title: Улучшить презентации PowerPoint с помощью анимаций в PHP
linktitle: Анимация PowerPoint
type: docs
weight: 150
url: /ru/php-java/powerpoint-animation/
keywords:
- добавить анимацию
- обновить анимацию
- изменить анимацию
- удалить анимацию
- управлять анимацией
- контролировать анимацию
- эффект анимации
- анимация PowerPoint
- шкала времени анимации
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
- PHP
- Aspose.Slides
description: "Изучите возможности Aspose.Slides for PHP via Java по работе с анимациями PowerPoint. Основные функции и рекомендации для улучшения ваших презентаций."
---
## **Введение**

Так как презентации предназначены для демонстрации чего‑либо, их визуальный вид и интерактивное поведение всегда учитываются при создании.

**Анимация PowerPoint** играет важную роль в том, чтобы сделать презентацию броской и увлекательной для зрителей. Aspose.Slides for PHP via Java предоставляет широкий набор возможностей для добавления анимаций в презентации PowerPoint:

- Применять различные типы анимационных эффектов PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.
- Использовать несколько анимационных эффектов PowerPoint для одной фигуры.
- Использовать шкалу времени анимации для управления эффектами.
- Создавать пользовательские анимации.

В Aspose.Slides for PHP via Java анимационные эффекты могут применяться к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, объекты OLE и таблицы, считается фигурой, анимационные эффекты могут применяться к любому элементу на слайде.

## **Эффекты анимации**
Aspose.Slides поддерживает **более 150 анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball и Zoom, а также специфические эффекты, такие как OLEObjectShow и OLEObjectOpen. Полный список доступен в классе [EffectType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effecttype/).

Кроме того, эти анимационные эффекты можно комбинировать со следующими поведениями:

- [ColorEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SetEffect)

## **Пользовательская анимация**

Для полного набора примеров PHP, показывающих создание, просмотр и изменение поведений и редактируемых траекторий движения, см. [Пользовательская анимация](/slides/ru/php-java/custom-animation/).

В Aspose.Slides можно создать свои **пользовательские анимации**. Это достигается комбинированием нескольких поведений в новую пользовательскую анимацию.

[Behavior](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behavior/) – строительный блок анимационного эффекта PowerPoint. Комбинируйте поведения, чтобы настроить эффект, или добавляйте поведение для расширения предопределённого эффекта. Повторяемость настраивается через параметры тайминга, а не отдельным поведением повторения.

[Animation Point](https://reference.aspose.com/slides/ru/php-java/aspose.slides/point/) – точка, в которой должно применяться поведение.

## **Шкала времени анимации**
[Sequence](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/) – набор анимационных эффектов, которые могут быть направлены на разные фигуры.

[Timeline](https://reference.aspose.com/slides/ru/php-java/aspose.slides/animationtimeline/) – набор последовательностей, используемых в конкретном слайде. Это анимационный движок, введённый в PowerPoint 2002. В более ранних версиях PowerPoint добавление анимационных эффектов в презентацию было сложным и требовало различных обходных решений. Шкала времени предоставляет более ясную модель объектов для анимаций PowerPoint. У слайда может быть только одна шкала времени анимации.

## **Интерактивная анимация**
[Trigger](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effecttriggertype/) позволяет определить пользовательские действия, такие как щелчок кнопки, которые запускают определённую анимацию.

## **Анимация фигур**
Aspose.Slides позволяет применять анимации к фигурам, которыми могут быть текст, прямоугольники, линии, рамки, объекты OLE и многое другое.

{{% alert color="info" title="Note" %}}
Читайте дальше [**О анимации фигур**](/slides/ru/php-java/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимации PowerPoint могут применяться только к категориям диаграммы или к сериям диаграммы. Также можно применять анимационные эффекты к элементу категории или к элементу серии.

{{% alert color="info" title="Note" %}}
Читайте дальше [**О анимированных диаграммах**](/slides/ru/php-java/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Помимо анимации текста, можно применить анимацию к абзацу.

{{% alert color="info" title="Note" %}}
Читайте дальше [**О анимированном тексте**](/slides/ru/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Сохраняются ли анимации при экспорте в PDF?**

Нет. PDF — статический формат, поэтому анимации и [переходы слайдов](/slides/ru/php-java/slide-transition/) не воспроизводятся. Если необходимы движения, экспортируйте в [HTML5](/slides/ru/php-java/export-to-html5/), [анимированный GIF](/slides/ru/php-java/convert-powerpoint-to-animated-gif/) или [видео](/slides/ru/php-java/convert-powerpoint-to-video/).

**Можно ли превратить анимированную презентацию в видео и задать частоту кадров и размер кадра?**

Да. Вы можете [рендерить презентацию в кадры](/slides/ru/php-java/convert-powerpoint-to-video/) и кодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Сохраняются ли анимации при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/php-java/open-presentation/) и [записи](/slides/ru/php-java/save-presentation/), но это не гарантирует сохранность анимаций. При конвертации в ODP пользовательские данные анимации могут быть потеряны. См. [Пользовательская анимация](/slides/ru/php-java/custom-animation/) для примеров и рекомендаций по проверке совместимости форматов.