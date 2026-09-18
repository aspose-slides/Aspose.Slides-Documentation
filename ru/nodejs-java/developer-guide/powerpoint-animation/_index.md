---
title: Улучшите презентации PowerPoint с помощью анимаций на JavaScript
linktitle: Анимация PowerPoint
type: docs
weight: 150
url: /ru/nodejs-java/powerpoint-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Используйте Aspose.Slides для Node.js через Java, чтобы работать с анимациями PowerPoint. Этот обзор подчеркивает ключевые возможности и предоставляет идеи для улучшения ваших презентаций."
---
## **Введение**

Поскольку презентации предназначены для представления чего‑либо, их визуальный вид и интерактивное поведение всегда учитываются при создании.

**PowerPoint animation** играет важную роль в том, чтобы сделать презентацию привлекательной и увлекательной для зрителей. Aspose.Slides for Node.js via Java предоставляет широкий набор возможностей для добавления анимаций в PowerPoint презентации:

- Применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.
- Использовать несколько эффектов анимации PowerPoint для одной фигуры.
- Использовать временную шкалу анимации для управления эффектами анимации.
- Создавать пользовательские анимации.

В Aspose.Slides for Node.js via Java можно применять различные эффекты анимации к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, объекты OLE и таблицы, считается фигурой, эффекты анимации могут быть применены к любому элементу на слайде.

## **Эффекты анимации**
Aspose.Slides поддерживает **более 150 анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball и Zoom, а также специфические эффекты, такие как OLEObjectShow и OLEObjectOpen. Полный список можно найти в перечислении [EffectType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effecttype/).

Кроме того, эти анимационные эффекты могут использоваться в сочетании со следующими поведениями:

- [ColorEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SetEffect)

## **Пользовательская анимация**
Для полных примеров JavaScript, которые создают, исследуют и изменяют поведения и редактируемые траектории движения, смотрите [Custom Animation](/slides/ru/nodejs-java/custom-animation/).

В Aspose.Slides можно создавать собственные **пользовательские анимации**. Это можно достичь, объединив несколько поведений в новую пользовательскую анимацию.

[Behavior](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/behavior/) — это строительный блок анимационного эффекта PowerPoint. Объединяйте поведения, чтобы настроить эффект, или добавляйте поведение, чтобы расширить предопределённый эффект. Повторение настраивается через параметры времени, а не через отдельное повторяющееся поведение.

[Animation Point](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/point/) — это точка, в которой должно применяться поведение.

## **Временная шкала анимации**
[Sequence](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/) — это коллекция анимационных эффектов, которые могут применяться к разным фигурам.

[Timeline](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/animationtimeline/) — это набор последовательностей, используемых в конкретном слайде. Это движок анимации, представленный в PowerPoint 2002. В более ранних версиях PowerPoint добавление анимационных эффектов в презентации было сложным и могло быть достигнуто только с помощью различных обходных решений. Временная шкала предоставляет более ясную объектную модель для анимаций PowerPoint. Слайд может иметь только одну временную шкалу анимации.

## **Интерактивная анимация**
[Trigger](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effecttriggertype/) позволяет определить действия пользователя, такие как щелчок кнопки, которые запускают определённую анимацию.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут включать текст, прямоугольники, линии, рамки, объекты OLE и многое другое.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимации фигур**](/slides/ru/nodejs-java/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимации PowerPoint могут применяться только к категориям диаграмм или к сериям диаграмм. Вы также можете применять анимационные эффекты к элементу категории или к элементу серии.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимированных диаграммах**](/slides/ru/nodejs-java/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Помимо анимации текста, вы можете применять анимацию к абзацу.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимированном тексте**](/slides/ru/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Will animations be preserved when exporting to PDF?**

Нет. PDF — статический формат, поэтому анимации и [slide transitions](/slides/ru/nodejs-java/slide-transition/) не воспроизводятся. Если требуется движение, экспортируйте в [HTML5](/slides/ru/nodejs-java/export-to-html5/), [animated GIF](/slides/ru/nodejs-java/convert-powerpoint-to-animated-gif/) или [video](/slides/ru/nodejs-java/convert-powerpoint-to-video/) вместо этого.

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

Да. Вы можете [render the presentation as frames](/slides/ru/nodejs-java/convert-powerpoint-to-video/) и кодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы между слайдами воспроизводятся во время рендеринга.

**Will animations remain intact when working with ODP (not just PPTX)?**

PPT, PPTX и ODP поддерживаются для [reading](/slides/ru/nodejs-java/open-presentation/) и [writing](/slides/ru/nodejs-java/save-presentation/), но это не гарантирует сохранение анимаций. Пользовательские данные анимации могут быть потеряны при конвертации в ODP. См. [Custom Animation](/slides/ru/nodejs-java/custom-animation/) для примеров и рекомендаций по проверке совместимости форматов.