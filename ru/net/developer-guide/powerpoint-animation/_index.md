---
title: Анимация PowerPoint
type: docs
weight: 150
url: /net/powerpoint-animation/
keywords: "Анимация, анимационные эффекты, анимация PowerPoint, временная шкала анимации, интерактивная анимация, анимация форм, анимированные графики, анимированный текст, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Анимация и эффекты презентации PowerPoint на C# или .NET"
---

Так как презентации предназначены для демонстрации чего-либо, их визуальное оформление и интерактивное поведение всегда учитываются при создании.

**Анимация PowerPoint** играет важную роль в том, чтобы сделать презентацию привлекательной и запоминающейся для зрителей. Aspose.Slides для .NET предлагает широкий выбор возможностей для добавления анимации в презентацию PowerPoint:

- применение различных типов анимационных эффектов PowerPoint к формам, графикам, таблицам, OLE-объектам и другим элементам презентации.
- использование нескольких анимационных эффектов PowerPoint на одной форме.
- использование временной шкалы анимации для управления анимационными эффектами.
- создание пользовательской анимации.

В Aspose.Slides для .NET различные анимационные эффекты могут применяться к формам. Так как каждый элемент на слайде, включая текст, изображения, OLE-объекты, таблицы и т.д. считается формой, это означает, что мы можем применять анимационные эффекты к каждому элементу слайда.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/net/aspose.slides.animation/) **пространство имен** предоставляет классы для работы с анимациями PowerPoint.
## **Анимационные эффекты**
Aspose.Slides поддерживает **150+ анимационных эффектов**, включая основные анимационные эффекты, такие как Bounce, PathFootball, Zoom effect и специфические анимационные эффекты, такие как OLEObjectShow, OLEObjectOpen. Полный список анимационных эффектов можно найти в [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) перечислении.

Кроме того, эти анимационные эффекты можно использовать в комбинации с ними:

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)
## **Пользовательская анимация**
В Aspose.Slides возможно создать свою собственную **пользовательскую анимацию**. 
Это можно достичь, если вы объедините несколько поведений в одну новую пользовательскую анимацию.

[**Поведение**](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) является строительным элементом любого анимационного эффекта PowerPoint. Все анимационные эффекты фактически представляют собой набор поведений, объединенных в одну стратегию. Вы можете объединять поведения в пользовательскую анимацию один раз и повторно использовать ее в других презентациях. Если вы добавите новое поведение к стандартному анимационному эффекту PowerPoint, это будет другая пользовательская анимация. Например, вы можете добавить поведение повтора к анимации, чтобы она повторялась несколько раз.

[**Точка анимации**](https://reference.aspose.com/slides/net/aspose.slides.animation/point) - это точка, в которой должно быть применено поведение.
## **Временная шкала анимации**
[**Последовательность**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) является коллекцией анимационных эффектов, применяемых к конкретной форме.

[**Временная шкала**](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) - это набор последовательностей, используемых в конкретном слайде. Это анимационный движок, представленный с PowerPoint 2002. В предыдущих версиях PowerPoint было сложно добавлять анимационные эффекты в презентацию, что можно было достичь только различными обходными путями. Временная шкала приходит на замену старому классу AnimationSettings и предоставляет более четкую объектную модель для анимации PowerPoint. Один слайд может иметь только одну временную шкалу анимации.
## **Интерактивная анимация**
[**Триггер**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) позволяет определить действия пользователя (например, нажатие кнопки), которые запустят определенную анимацию. Триггеры были добавлены только в последней версии PowerPoint.
## **Анимация форм**
Aspose.Slides позволяет применять анимацию к формам, которые могут быть текстом, прямоугольником, линией, рамкой, OLE-объектом и т.д.

{{% alert color="primary" %}} 
Читать далее [**Об анимации форм**](/slides/net/shape-animation/).
{{% /alert %}}

## **Анимированные графики**
Для создания анимированных графиков вы должны использовать те же классы, что и для форм. Однако возможно использовать анимацию PowerPoint только на категориях графиков или сериях графиков. Вы также можете применять анимационный эффект к элементу категории или элементу серии.

{{% alert color="primary" %}} 
Читать далее [**Об анимированных графиках**](/slides/net/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Кроме анимированного текста, также возможно применить анимацию к абзацу.

{{% alert color="primary" %}} 
Читать далее [**Об анимированном тексте**](/slides/net/animated-text/).
{{% /alert %}}