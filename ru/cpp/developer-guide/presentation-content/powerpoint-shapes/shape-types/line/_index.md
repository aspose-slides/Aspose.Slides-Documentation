---
title: Линия
type: docs
weight: 50
url: /cpp/Line/
---

## **Создание простой линии**
Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр [класса Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автофигуру типа Линия, используя метод [AddAutoShape](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addautoshape/index), предоставленный объектом Shapes.
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **Создание линии в форме стрелки**
Aspose.Slides для C++ также позволяет разработчикам настраивать некоторые свойства линии, чтобы сделать её более привлекательной. Давайте попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр [класса Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автофигуру типа Линия, используя метод AddAutoShape, предоставленный объектом Shapes.
- Установите стиль линии на один из стилей, предлагаемых Aspose.Slides для C++.
- Установите ширину линии.
- Установите [стиль линии](http://www.aspose.com/api/net/slides/aspose.slides/linedashstyle) на один из стилей, предлагаемых Aspose.Slides для C++.
- Установите [стиль наконечника стрелки](http://www.aspose.com/api/net/slides/aspose.slides/lineformat) и длину начальной точки линии.
- Установите стиль наконечника стрелки и длину конечной точки линии.
- Запишите изменённую презентацию в файл PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}