---
title: Анимация PowerPoint
type: docs
weight: 150
url: /ru/nodejs-java/powerpoint-animation/
keywords: "Анимация PowerPoint"
description: "Анимация PowerPoint, анимация слайдов PowerPoint с Aspose.Slides."
---

Поскольку презентации предназначены для представления чего‑либо, их внешний вид и интерактивное поведение всегда учитываются при их создании.

**PowerPoint animation** играет важную роль, позволяя сделать презентацию более заметной и привлекательной для зрителей. Aspose.Slides for Node.js via Java предлагает широкий набор возможностей для добавления анимации в презентацию PowerPoint:

- применять различные типы анимационных эффектов PowerPoint к фигурам, диаграммам, таблицам, OLE‑объектам и другим элементам презентации.
- использовать несколько анимационных эффектов PowerPoint для одной фигуры.
- использовать временную шкалу анимации для управления эффектами.
- создавать пользовательскую анимацию.

В Aspose.Slides for Node.js via Java анимационные эффекты могут применяться к фигурам. Поскольку каждый элемент слайда, включая текст, изображения, OLE‑объекты, таблицы и т.д., считается фигурой, это означает, что анимацию можно задать для любого элемента слайда.

## **Animation Effects**
Aspose.Slides поддерживает **150+ animation effects**, включая базовые эффекты, такие как Bounce, PathFootball, Zoom, а также специфические эффекты, такие как OLEObjectShow, OLEObjectOpen. Полный список анимационных эффектов можно посмотреть в перечислении [**EffectType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype/).

Кроме того, эти анимационные эффекты можно комбинировать со следующими:

- [ColorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SetEffect)

## **Custom Animation**
В Aspose.Slides можно создавать собственные **custom animations**.  
Это достигается комбинированием нескольких поведений в новую пользовательскую анимацию.

[**Behavior**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Behavior) — строительный блок любого анимационного эффекта PowerPoint. Все анимационные эффекты фактически представляют собой набор поведений, объединённых в одну стратегию. Вы можете один раз комбинировать поведения в пользовательскую анимацию и затем повторно использовать её в других презентациях. Добавление нового поведения в стандартный анимационный эффект PowerPoint создаёт другую пользовательскую анимацию. Например, можно добавить поведение повторения, чтобы анимация запускалась несколько раз.

[**Animation Point**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Point) — точка, в которой должно применяться поведение.

## **Animation Time Line**
[**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) — коллекция анимационных эффектов, применяемая к конкретной фигуре.

[**Timeline**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AnimationTimeLine) — набор последовательностей, используемый на конкретном слайде. Это анимационный движок, представленный начиная с PowerPoint 2002. В предыдущих версиях PowerPoint добавлять анимационные эффекты было сложно и требовало различных обходных решений. Timeline заменил старый класс AnimationSettings и предоставляет более понятную модель объектов для анимации PowerPoint. На одном слайде может быть только одна временная шкала анимации.

## **Interactive Animation**
[**Trigger**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectTriggerType) позволяет задать действия пользователя (например, щелчок кнопки), которые запускают определённую анимацию. Триггеры появились только в последних версиях PowerPoint.

## **Shape Animation**
Aspose.Slides позволяет добавлять анимацию к фигурам, которые могут быть текстом, прямоугольником, линией, рамкой, OLE‑объектом и т.д.

{{% alert color="primary" %}} 
Подробнее [**О анимации фигур**](/slides/ru/nodejs-java/shape-animation/).
{{% /alert %}}

## **Animated Charts**
Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применить только к категориям диаграммы или к сериям. Можно также задать анимационный эффект для отдельного элемента категории или серии.

{{% alert color="primary" %}} 
Подробнее [**Об анимированных диаграммах**](/slides/ru/nodejs-java/animated-charts/).
{{% /alert %}}

## **Animated text**
Помимо анимированного текста, можно применять анимацию к абзацу.

{{% alert color="primary" %}} 
Подробнее [**Об анимированном тексте**](/slides/ru/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Will animations be preserved when exporting to PDF?**

No. PDF is a static format, so animations and [slide transitions](/slides/ru/nodejs-java/slide-transition/) don’t play. If you need motion, export to [HTML5](/slides/ru/nodejs-java/export-to-html5/), [animated GIF](/slides/ru/nodejs-java/convert-powerpoint-to-animated-gif/), or [video](/slides/ru/nodejs-java/convert-powerpoint-to-video/) instead.

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

Yes. You can [render the presentation as frames](/slides/ru/nodejs-java/convert-powerpoint-to-video/) and encode them into a video (e.g., via ffmpeg), choosing the FPS and resolution. Animations and slide transitions are played during rendering.

**Will animations remain intact when working with ODP (not just PPTX)?**

PPT, PPTX, and ODP are supported for [reading](/slides/ru/nodejs-java/open-presentation/) and [writing](/slides/ru/nodejs-java/save-presentation/), but format differences mean certain effects may look or behave slightly differently. Validate critical cases with real samples.