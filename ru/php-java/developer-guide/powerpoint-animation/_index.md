---
title: "Улучшите презентации PowerPoint с помощью анимации в PHP"
linktitle: "Анимация PowerPoint"
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
- PHP
- Aspose.Slides
description: "Изучите возможности Aspose.Slides for PHP via Java по работе с анимацией PowerPoint. Ключевые функции и сведения для улучшения ваших презентаций."
---

Поскольку презентации предназначены для демонстрации чего‑либо, их визуальный вид и интерактивное поведение всегда учитываются при их создании.

**PowerPoint animation** играет важную роль в том, чтобы сделать презентацию привлекательной и интересной для зрителей. Aspose.Slides for PHP via Java предлагает широкий набор возможностей для добавления анимации в презентацию PowerPoint:

- применять различные типы анимационных эффектов PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.  
- использовать несколько анимационных эффектов PowerPoint для одной фигуры.  
- использовать временную шкалу анимации для управления анимационными эффектами.  
- создавать пользовательскую анимацию.

В Aspose.Slides for PHP via Java различные анимационные эффекты могут быть применены к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, объект OLE, таблицу и т.д., считается фигурой, это означает, что мы можем применить анимационный эффект к каждому элементу слайда.

## **Animation Effects**
Aspose.Slides поддерживает **150+ animation effects**, включая базовые эффекты анимации, такие как Bounce, PathFootball, Zoom, а также специфические эффекты, например OLEObjectShow, OLEObjectOpen. Полный список анимационных эффектов можно найти в перечислении [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

Кроме того, эти анимационные эффекты можно использовать в комбинации с ними:

- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **Пользовательская анимация**
В Aspose.Slides возможно создать собственные **custom animations**.  
Это достигается путем объединения нескольких поведений в новую пользовательскую анимацию.

[**Behavior**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) – строительный блок любого анимационного эффекта PowerPoint. Все анимационные эффекты фактически представляют собой набор поведений, объединённых в одну стратегию. Вы можете объединить поведения в пользовательскую анимацию один раз и использовать её в других презентациях. Если вы добавите новое поведение в стандартный анимационный эффект PowerPoint, получится другая пользовательская анимация. Например, можно добавить поведение повторения к анимации, чтобы она воспроизводилась несколько раз.

[**Animation Point**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) – точка, где должно применяться поведение.

## **Временная шкала анимации**
[**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) – коллекция анимационных эффектов, применяемая к конкретной фигуре.

[**Timeline**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) – набор последовательностей, используемых в конкретном слайде. Это анимационный движок, представленный начиная с PowerPoint 2002. В предыдущих версиях PowerPoint добавление анимационных эффектов было сложным и требовало различных обходных решений. Timeline заменил старый класс AnimationSettings и предоставляет более понятную объектную модель для анимации PowerPoint. На одном слайде может быть только одна анимационная временная шкала.

## **Интерактивная анимация**
[**Trigger**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) позволяет определить действия пользователя (например, щелчок кнопки), которые запустят определённую анимацию. Триггеры появились только в последних версиях PowerPoint.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут быть текстом, прямоугольником, линией, рамкой, объектом OLE и т.д.

{{% alert color="primary" %}} 
Подробнее [**About Shape Animation**](/slides/ru/php-java/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или к сериям диаграммы. Также можно применить анимационный эффект к элементу категории или к элементу серии.

{{% alert color="primary" %}} 
Подробнее [**About Animated Charts**](/slides/ru/php-java/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Помимо анимированного текста, также возможно применить анимацию к абзацу.

{{% alert color="primary" %}} 
Подробнее [**About Animated Text**](/slides/ru/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Будут ли анимации сохранены при экспорте в PDF?**

Нет. PDF – статический формат, поэтому анимации и [slide transitions](/slides/ru/php-java/slide-transition/) не воспроизводятся. Если нужен движущийся контент, экспортируйте в [HTML5](/slides/ru/php-java/export-to-html5/), [animated GIF](/slides/ru/php-java/convert-powerpoint-to-animated-gif/) или [video](/slides/ru/php-java/convert-powerpoint-to-video/) вместо этого.

**Могу ли я превратить анимированную презентацию в видео и контролировать частоту кадров и размер кадра?**

Да. Вы можете [render the presentation as frames](/slides/ru/php-java/convert-powerpoint-to-video/) и закодировать их в видео (например, с помощью ffmpeg), выбрав FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Сохранятся ли анимации при работе с ODP (а не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [reading](/slides/ru/php-java/open-presentation/) и [writing](/slides/ru/php-java/save-presentation/), но различия форматов могут приводить к небольшим изменениям внешнего вида или поведения некоторых эффектов. Проверяйте критические сценарии на реальных образцах.