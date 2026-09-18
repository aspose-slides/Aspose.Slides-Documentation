---
title: Улучшение презентаций PowerPoint с анимациями в .NET
linktitle: Анимация PowerPoint
type: docs
weight: 150
url: /ru/net/powerpoint-animation/
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
- анимированный OLE‑объект
- анимированное изображение
- анимированная таблица
- презентация PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Изучите возможности Aspose.Slides для .NET по работе с анимациями PowerPoint. Этот общий обзор подчёркивает ключевые функции и предлагает идеи для улучшения ваших презентаций."
---
## **Введение**

Поскольку презентации предназначены для представления чего‑то, их визуальный вид и интерактивное поведение всегда учитываются при создании.

**PowerPoint animation** играет важную роль в том, чтобы презентация привлекала внимание и удерживала интерес зрителей. Aspose.Slides for .NET предоставляет широкий набор возможностей для добавления анимаций в презентации PowerPoint:

- Применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, OLE‑объектам и другим элементам презентации.
- Использовать несколько эффектов анимации PowerPoint на одной фигуре.
- Использовать временную шкалу анимации для управления эффектами.
- Создавать пользовательские анимации.

В Aspose.Slides for .NET к фигурам можно применять различные эффекты анимации. Поскольку каждый элемент на слайде, включая текст, изображения, OLE‑объекты и таблицы, считается фигурой, эффекты анимации могут быть применены к любому элементу на слайде.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/) namespace предоставляет классы для работы с анимациями PowerPoint.

## **Эффекты анимации**

Aspose.Slides поддерживает **более 150 эффектов анимации**, включая базовые эффекты, такие как Bounce, PathFootball и Zoom, а также специфические эффекты, такие как OLEObjectShow и OLEObjectOpen. Полный список эффектов анимации доступен в перечислении [EffectType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/effecttype).

Кроме того, эти эффекты анимации могут использоваться в комбинации со следующими:

- [ColorEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/seteffect)

## **Пользовательская анимация**

Для полных примеров на C#, которые создают, исследуют и изменяют поведения и редактируемые траектории движения, см. [Custom Animation](/slides/ru/net/custom-animation/).

В Aspose.Slides можно создавать собственные **пользовательские анимации**. Это достигается комбинацией нескольких поведений в новую пользовательскую анимацию.

[Behavior](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/behavior) является строительным блоком эффекта анимации PowerPoint. Комбинируйте поведения, чтобы настроить эффект, или добавляйте поведение, чтобы расширить предопределённый эффект. Повторения настраиваются через параметры тайминга, а не отдельным поведением повторения.

[Animation Point](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/point) — точка, в которой должно применяться поведение.

## **Временная шкала анимации**

[Sequence](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/sequence) — коллекция эффектов анимации, которые могут целиться в разные фигуры.

[Timeline](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/animationtimeline) — набор последовательностей, используемых в конкретном слайде. Это анимационный движок, введённый в PowerPoint 2002. В ранних версиях PowerPoint добавление анимаций в презентации было проблематичным и требовало различных обходных решений. Временная шкала заменяет старый класс AnimationSettings и предоставляет более понятную объектную модель анимаций PowerPoint. Слайд может иметь только одну временную шкалу анимации.

## **Интерактивная анимация**

[Trigger](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/effecttriggertype) позволяет задавать действия пользователя (например, щелчок кнопки), которые инициируют определённую анимацию. Триггеры были введены в последней версии PowerPoint.

## **Анимация фигур**

Aspose.Slides позволяет применять анимации к фигурам, которые могут включать текст, прямоугольники, линии, рамки, OLE‑объекты и многое другое.

{{% alert color="info" title="Note" %}}
Read more [**About Shape Animation**](/slides/ru/net/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**

Чтобы создавать анимированные диаграммы, следует использовать те же классы, что и для фигур. Однако анимации PowerPoint могут применяться только к категориям диаграммы или к сериям диаграммы. Также можно применять эффекты анимации к элементу категории или к элементу серии.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Charts**](/slides/ru/net/animated-charts/).
{{% /alert %}}

## **Анимированный текст**

Помимо анимации текста, можно анимировать абзац.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Text**](/slides/ru/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Будут ли анимации сохранены при экспорте в PDF?**

Нет. PDF — статический формат, поэтому анимации и [slide transitions](/slides/ru/net/slide-transition/) не воспроизводятся. Если требуется движение, экспортируйте в [HTML5](/slides/ru/net/export-to-html5/), [animated GIF](/slides/ru/net/convert-powerpoint-to-animated-gif/) или [video](/slides/ru/net/convert-powerpoint-to-video/) вместо этого.

**Могу ли я преобразовать анимированную презентацию в видео и задать частоту кадров и размер кадра?**

Да. Вы можете [render the presentation as frames](/slides/ru/net/convert-powerpoint-to-video/) и закодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Сохранятся ли анимации при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [reading](/slides/ru/net/open-presentation/) и [writing](/slides/ru/net/save-presentation/), но это не гарантирует сохранение анимаций. При конвертации в ODP пользовательские данные анимации могут быть потеряны. См. [Custom Animation](/slides/ru/net/custom-animation/) для проверенного примера и ограничения форматов.