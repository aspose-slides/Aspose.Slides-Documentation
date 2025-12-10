---
title: Добавление линейных фигур в презентации на C++
linktitle: Линия
type: docs
weight: 50
url: /ru/cpp/line/
keywords:
- линия
- создать линию
- добавить линию
- прямая линия
- настроить линию
- кастомизировать линию
- стиль черточек
- стрелка
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides для C++. Откройте свойства, методы и примеры."
---

## **Создать простую линию**
Чтобы добавить простую линию к выбранному слайду презентации, выполните следующие шаги:

- Создайте экземпляр [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line, используя [AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) метод, предоставляемый объектом Shapes.
- Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили линию на первый слайд презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Создать линию со стрелкой**
Aspose.Slides for C++ также позволяет разработчикам настроить некоторые свойства линии, чтобы она выглядела более привлекательно. Давайте попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line, используя метод AddAutoShape, предоставляемый объектом Shapes.
- Установите стиль линии (Line Style) в один из стилей, предлагаемых Aspose.Slides for C++.
- Установите ширину (Width) линии.
- Установите [Dash Style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) линии в один из стилей, предлагаемых Aspose.Slides for C++.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/cpp/aspose.slides/lineformat/) и длину (Length) стрелочного конца в начале линии.
- Установите стиль и длину (Length) стрелочного конца в конце линии.
- Сохраните изменённую презентацию в файл PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Могу ли я преобразовать обычную линию в соединитель, чтобы она «привязалась» к фигурам?**

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/) типа [Line](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/)) автоматически не превращается в соединитель. Чтобы привязать её к фигурам, используйте специальный тип [Connector](https://reference.aspose.com/slides/cpp/aspose.slides/connector/) и [соответствующие API](/slides/ru/cpp/connector/) для соединений.

**Что сделать, если свойства линии унаследованы из темы и трудно определить конечные значения?**

[Прочитайте действительные свойства](/slides/ru/cpp/shape-effective-properties/) через интерфейсы [ILineFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformateffectivedata/) — они уже учитывают наследование и стили темы.

**Могу ли я заблокировать линию от редактирования (перемещения, изменения размеров)?**

Да. Фигуры предоставляют [lock objects](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/get_autoshapelock/), которые позволяют [запретить операции редактирования](/slides/ru/cpp/applying-protection-to-presentation/).