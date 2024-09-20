---
title: Анимация PowerPoint
type: docs
weight: 150
url: /python-net/powerpoint-animation/
keywords: "Анимация, анимационные эффекты, анимация PowerPoint, временная шкала анимации, интерактивная анимация, анимация форм, анимированные диаграммы, анимированный текст, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Анимация и эффекты презентации PowerPoint на Python"
---

Так как презентации предназначены для демонстрации чего-либо, их визуальный вид и интерактивное поведение всегда учитываются при создании.

**Анимация PowerPoint** играет важную роль в том, чтобы сделать презентацию привлекательной и запоминающейся для зрителей. Aspose.Slides для Python через .NET предлагает широкий спектр возможностей для добавления анимации в презентацию PowerPoint:

- применять различные типы анимационных эффектов PowerPoint к формам, диаграммам, таблицам, OLE-объектам и другим элементам презентации.
- использовать несколько анимационных эффектов PowerPoint на одной форме.
- использовать временную шкалу анимации для управления анимационными эффектами.
- создавать пользовательскую анимацию.

В Aspose.Slides для Python через .NET различные анимационные эффекты могут быть применены к формам. Поскольку каждый элемент на слайде, включая текст, изображения, OLE-объекты, таблицы и т. д. считается формой, это означает, что мы можем применить анимационный эффект к каждому элементу слайда.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) **пространство имен** предоставляет классы для работы с анимациями PowerPoint.
## **Анимационные Эффекты**
Aspose.Slides поддерживает **более 150 анимационных эффектов**, включая базовые анимационные эффекты, такие как Пружина, ПутьФутбольногоМяча, Эффект Увеличения и специфические анимационные эффекты, такие как OLEObjectShow, OLEObjectOpen. Полный список анимационных эффектов можно найти в [**EffectType**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) перечислении.

Кроме того, эти анимационные эффекты могут быть использованы в комбинации с такими:

- [ColorEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/)
## **Пользовательская Анимация**
В Aspose.Slides возможно создание собственных **пользовательских анимаций**. 
Это можно достичь, если вы объедините несколько действий в новую пользовательскую анимацию.

[**Поведение**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/) является строительным элементом любого анимационного эффекта PowerPoint. Все анимационные эффекты на самом деле представляют собой набор поведений, объединённых в одну стратегию. Вы можете комбинировать поведения в пользовательскую анимацию один раз и повторно использовать её в других презентациях. Если вы добавите новое поведение в стандартный анимационный эффект PowerPoint, это будет другая пользовательская анимация. Например, вы можете добавить поведение повторения к анимации, чтобы сделать её повторяемой несколько раз.

[**Анимационная Точка**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/point/) это точка, где поведение должно быть применено.
## **Временная Шкала Анимации**
[**Последовательность**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) является коллекцией анимационных эффектов, применённых к конкретной форме.

[**Временная шкала**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animationtimeline/) это набор последовательностей, используемых на конкретном слайде. Это анимационный движок, представленный с PowerPoint 2002 года. В предыдущих версиях PowerPoint было сложно добавлять анимационные эффекты в презентацию, что можно было сделать только различными обходными путями. Временная шкала пришла на замену старому классу AnimationSettings и предоставляет более понятную объектную модель для анимации PowerPoint. Один слайд может иметь только одну временную шкалу анимации.
## **Интерактивная Анимация**
[**Триггер**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) позволяет определить действия пользователя (например, клик по кнопке), которые запустят определённую анимацию. Триггеры были добавлены только в последней версии PowerPoint.
## **Анимация Форм**
Aspose.Slides позволяет применять анимацию к формам, которые могут быть на самом деле текстом, прямоугольником, линией, рамкой, OLE-объектом и т.д.

{{% alert color="primary" %}} 
Читать подробнее [**Об Анимации Форм**](/slides/python-net/shape-animation/).
{{% /alert %}}

## **Анимированные Диаграммы**
Для создания анимированных диаграмм вы должны использовать те же классы, что и для форм. Тем не менее, анимацию PowerPoint можно использовать только для категорий диаграммы или серий диаграммы. Вы также можете применить анимационный эффект к элементу категории или элементу серии.

{{% alert color="primary" %}} 
Читать подробнее [**Об Анимированных Диаграммах**](/slides/python-net/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Кроме анимированного текста, также возможно применять анимацию к абзацам.

{{% alert color="primary" %}} 
Читать подробнее [**Об Анимированном Тексте**](/slides/python-net/animated-text/).
{{% /alert %}}