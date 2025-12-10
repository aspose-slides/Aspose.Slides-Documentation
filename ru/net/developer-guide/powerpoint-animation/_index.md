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
- анимированный объект OLE
- анимированное изображение
- анимированная таблица
- презентация PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Изучите возможности Aspose.Slides для .NET по работе с анимациями PowerPoint. Этот общий обзор подчеркивает ключевые функции и предлагает идеи для улучшения ваших презентаций."
---

## **Обзор**

Поскольку презентации созданы для демонстрации чего‑либо, их визуальный вид и интерактивное поведение всегда учитываются при создании.

**Анимация PowerPoint** играет важную роль в том, чтобы презентация привлекала внимание и удерживала интерес зрителей. Aspose.Slides for .NET предоставляет широкий набор возможностей для добавления анимаций в презентации PowerPoint:

- Применять различные типы анимационных эффектов PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.  
- Использовать несколько анимационных эффектов PowerPoint на одной фигуре.  
- Управлять анимационными эффектами с помощью временной шкалы анимации.  
- Создавать пользовательские анимации.

В Aspose.Slides for .NET к фигурам можно применять различные анимационные эффекты. Поскольку каждый элемент на слайде, включая текст, изображения, объекты OLE и таблицы, считается фигурой, анимационные эффекты могут быть применены к любому элементу слайда.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) namespace предоставляет классы для работы с анимациями PowerPoint.

## **Эффекты анимации**

Aspose.Slides поддерживает **более 150 анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball и Zoom, а также специфические эффекты, такие как OLEObjectShow и OLEObjectOpen. Полный список анимационных эффектов можно найти в перечислении [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

Кроме того, эти анимационные эффекты могут комбинироваться со следующими:

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)  
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)  
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)  
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)  
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)  
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)  
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)  
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)

## **Пользовательская анимация**

В Aspose.Slides можно создавать **пользовательские анимации**. Это достигается объединением нескольких поведения в новую пользовательскую анимацию.

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) — строительный блок любого анимационного эффекта PowerPoint. Все анимационные эффекты по сути представляют собой набор поведения, собранного в одну стратегию. Вы можете объединить поведения в пользовательскую анимацию один раз и повторно использовать её в других презентациях. Если добавить новое поведение к стандартному анимационному эффекту PowerPoint, оно станет ещё одной пользовательской анимацией. Например, можно добавить повторяющееся поведение к анимации, чтобы она выполнялась несколько раз.

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) — точка, в которой должно применяться поведение.

## **Временная шкала анимации**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) — коллекция анимационных эффектов, применяемых к конкретной фигуре.

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) — набор последовательностей, используемых на конкретном слайде. Это анимационный движок, введённый в PowerPoint 2002. В более ранних версиях PowerPoint добавление анимационных эффектов в презентацию было сложным и требовало различных обходных решений. Временная шкала заменяет старый класс AnimationSettings и предоставляет более понятную объектную модель для анимаций PowerPoint. На слайде может быть только одна временная шкала анимации.

## **Интерактивная анимация**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) позволяет определить действия пользователя (например, щелчок кнопки), которые запустят определённую анимацию. Триггеры были введены в последней версии PowerPoint.

## **Анимация фигур**

Aspose.Slides позволяет применять анимацию к фигуркам, которые могут включать текст, прямоугольники, линии, рамки, объекты OLE и многое другое.

{{% alert color="primary" %}} 
Read more [**About Shape Animation**](/slides/ru/net/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**

Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или к её сериям. Вы также можете применять анимационные эффекты к элементу категории или к элементу серии.

{{% alert color="primary" %}} 
Read more [**About Animated Charts**](/slides/ru/net/animated-charts/).
{{% /alert %}}

## **Анимированный текст**

Помимо анимированного текста, можно также применять анимацию к абзацу.

{{% alert color="primary" %}} 
Read more [**About Animated Text**](/slides/ru/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Будут ли анимации сохранены при экспорте в PDF?**

Нет. PDF — статический формат, поэтому анимации и [переходы слайдов](/slides/ru/net/slide-transition/) не воспроизводятся. Если нужен эффект движения, экспортируйте в [HTML5](/slides/ru/net/export-to-html5/), [анимированный GIF](/slides/ru/net/convert-powerpoint-to-animated-gif/) или [видео](/slides/ru/net/convert-powerpoint-to-video/).

**Можно ли превратить анимированную презентацию в видео и управлять частотой кадров и их размером?**

Да. Вы можете [рендерить презентацию в кадры](/slides/ru/net/convert-powerpoint-to-video/) и кодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Сохранятся ли анимации при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/net/open-presentation/) и [записи](/slides/ru/net/save-presentation/), но различия форматов могут привести к небольшим визуальным или функциональным отклонениям эффектов. Проверяйте критические случаи на реальных образцах.