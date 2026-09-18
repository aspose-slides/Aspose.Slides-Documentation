---
title: Улучшите презентации PowerPoint с анимацией на C++
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
- анимационный эффект
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
description: "Узнайте, как добавлять и управлять продвинутыми анимационными эффектами в Aspose.Slides для C++, чтобы создавать динамические презентации PowerPoint и OpenDocument."
---
## **Введение**

Поскольку презентации предназначены для представления чего‑либо, их визуальный вид и интерактивное поведение всегда учитываются при создании.

**Анимация PowerPoint** играет важную роль в том, чтобы презентация была заметной и привлекала внимание зрителей. Aspose.Slides предоставляет широкий набор возможностей для добавления анимаций в презентации PowerPoint:

- Применять различные типы анимационных эффектов PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.
- Использовать несколько анимационных эффектов PowerPoint для одной фигуры.
- Использовать временную шкалу анимации для управления анимационными эффектами.
- Создавать пользовательские анимации.

В Aspose.Slides различные анимационные эффекты могут применяться к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, объекты OLE и таблицы, считается фигурой, анимационные эффекты могут быть применены к любому элементу на слайде.

Пространство имён [Aspose::Slides::Animation](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/) предоставляет классы для работы с анимациями PowerPoint.

## **Эффекты анимации**
Aspose.Slides поддерживает **более 150 анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball и Zoom, а также специфические эффекты, такие как OLEObjectShow и OLEObjectOpen. Полный список можно найти в перечислении [EffectType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/effecttype/).

Кроме того, эти анимационные эффекты могут использоваться в сочетании со следующими поведениями:

- [ColorEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/seteffect/)

## **Пользовательская анимация**

Для полного примера на C++, создающего, исследующего и изменяющего поведения и редактируемые траектории движения, см. [Пользовательская анимация](/slides/ru/cpp/custom-animation/).

Можно создавать собственные **пользовательские анимации** в Aspose.Slides. Это достигается комбинированием нескольких поведений в новую пользовательскую анимацию.

[Behavior](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/behavior/) — строительный блок анимационного эффекта PowerPoint. Комбинируйте поведения, чтобы настроить эффект, или добавляйте поведение для расширения предопределённого эффекта. Повторение настраивается через параметры тайминга, а не отдельным поведением повторения.

[Animation Point](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/point/) — точка, в которой должно быть применено поведение.

## **Временная шкала анимации**
[Sequence](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/sequence/) — набор анимационных эффектов, которые могут быть направлены на разные фигуры.

[IAnimationTimeLine](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ianimationtimeline/) — набор последовательностей, используемых в конкретном слайде. Это анимационный движок, введённый в PowerPoint 2002. В более ранних версиях PowerPoint добавление анимационных эффектов в презентации было затруднено и требовало различных обходных путей. Временная шкала предоставляет более понятную объектную модель для анимаций PowerPoint. На слайде может быть только одна временная шкала анимации.

## **Интерактивная анимация**
[Trigger](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/effecttriggertype/) позволяет определить действия пользователя, такие как щелчок кнопки, которые запускают определённую анимацию.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут включать текст, прямоугольники, линии, рамки, объекты OLE и многое другое.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимации фигур**](/slides/ru/cpp/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или её сериям. Также можно применить анимационный эффект к элементу категории или элементу серии.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимированных диаграммах**](/slides/ru/cpp/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Помимо анимации текста, можно применять анимацию к абзацу.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимированном тексте**](/slides/ru/cpp/animated-text/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Будут ли анимации сохранены при экспорте в PDF?**

Нет. PDF — статический формат, поэтому анимации и [slide transitions](/slides/ru/cpp/slide-transition/) не воспроизводятся. Если требуется движение, экспортируйте в [HTML5](/slides/ru/cpp/export-to-html5/), [animated GIF](/slides/ru/cpp/convert-powerpoint-to-animated-gif/) или [video](/slides/ru/cpp/convert-powerpoint-to-video/) вместо этого.

**Можно ли превратить анимированную презентацию в видео и управлять частотой кадров и размером кадра?**

Да. Вы можете [render the presentation as frames](/slides/ru/cpp/convert-powerpoint-to-video/) и закодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Сохранатся ли анимации при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [reading](/slides/ru/cpp/open-presentation/) и [writing](/slides/ru/cpp/save-presentation/), но это не гарантирует сохранение анимаций. Пользовательские данные анимации могут быть потеряны при конвертации в ODP. См. [Custom Animation](/slides/ru/cpp/custom-animation/) для примеров и рекомендаций по проверке совместимости форматов.