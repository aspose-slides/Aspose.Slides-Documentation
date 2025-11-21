---
title: Управление масштабированием презентации в .NET
linktitle: Управление масштабом
type: docs
weight: 60
url: /ru/net/manage-zoom/
keywords:
- масштаб
- рамка масштаба
- масштаб слайда
- масштаб раздела
- обзорный масштаб
- добавить масштаб
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и настраивайте масштаб с помощью Aspose.Slides для .NET — переходите между разделами, добавляйте миниатюры и переходы в презентациях PPT, PPTX и ODP."
---

## **Обзор**
Масштабы в PowerPoint позволяют переходить к определённым слайдам, разделам и частям презентации и обратно. Во время презентации эта возможность быстро перемещаться по содержимому может оказаться очень полезной. 

![обзор_изображение](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Summary Zoom](#Summary-Zoom).
* Чтобы показывать только выбранные слайды, используйте [Slide Zoom](#Slide-Zoom).
* Чтобы показывать только один раздел, используйте [Section Zoom](#Section-Zoom).

## **Масштаб слайда**
Масштаб слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любом порядке без прерывания её потока. Масштабы слайда отлично подходят для коротких презентаций без большого количества разделов, но их также можно применять в разных сценариях.

Масштабы слайда помогают подробно рассмотреть несколько частей информации, ощущая при этом, что вы работаете на едином холсте. 

![масштаб_слайда_изображение](slidezoomsel.png)

Для объектов масштаба слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), интерфейс [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) и некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание Zoom‑рамок**
Вы можете добавить Zoom‑рамку на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды, к которым планируете привязать Zoom‑рамки. 
3. Добавьте текст идентификации и фон к созданным слайдам.
4. Добавьте Zoom‑рамки (ссылающиеся на созданные слайды) на первый слайд.
5. Запишите изменённую презентацию в файл PPTX.

Этот C#‑код показывает, как создать Zoom‑рамку на слайде:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новые слайды в презентацию
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Создает фон для второго слайда
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Создает текстовое поле для второго слайда
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Создает фон для третьего слайда
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Создает текстовое поле для третьего слайда
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Adds ZoomFrame objects
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Создание Zoom‑рамок с пользовательскими изображениями**
С помощью Aspose.Slides для .NET вы можете создать Zoom‑рамку с другим изображением‑предпросмотром слайда следующим образом: 
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд, к которому планируете привязать Zoom‑рамку. 
3. Добавьте текст идентификации и фон к слайду.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использовано для заполнения рамки.
5. Добавьте Zoom‑рамки (ссылающиеся на созданный слайд) на первый слайд.
6. Запишите изменённую презентацию в файл PPTX.

Этот C#‑код показывает, как создать Zoom‑рамку с другим изображением:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Создает фон для второго слайда
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Создает текстовое поле для третьего слайда
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Создает новое изображение для объекта Zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Adds the ZoomFrame object
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Форматирование Zoom‑рамок**
В предыдущих разделах мы показывали, как создавать простые Zoom‑рамки. Чтобы создать более сложные Zoom‑рамки, необходимо изменить их форматирование. Существует несколько параметров форматирования, которые можно применить к Zoom‑рамке. 

Вы можете управлять форматированием Zoom‑рамки на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды, к которым планируете привязать Zoom‑рамку. 
3. Добавьте текст идентификации и фон к созданным слайдам.
4. Добавьте Zoom‑рамки (ссылающиеся на созданные слайды) на первый слайд.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использовано для заполнения рамки.
6. Установите пользовательское изображение для первого объекта Zoom‑рамки.
7. Измените формат линии для второго объекта Zoom‑рамки.
8. Удалите фон изображения второго объекта Zoom‑рамки.
9. Запишите изменённую презентацию в файл PPTX.

Этот C#‑код показывает, как изменить форматирование Zoom‑рамки на слайде: 
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новые слайды в презентацию
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Создаёт фон для второго слайда
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Создаёт текстовое поле для второго слайда
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Создаёт фон для третьего слайда
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Создаёт текстовое поле для третьего слайда
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Добавляет объекты ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Создаёт новое изображение для объекта Zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Устанавливает пользовательское изображение для объекта zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Устанавливает формат ZoomFrame для объекта zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Настройка: не показывать фон для объекта zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Масштаб раздела**
Масштаб раздела — это ссылка на раздел вашей презентации. Вы можете использовать масштабы разделов, чтобы возвращаться к разделам, которые хотите особенно подчеркнуть, либо чтобы показать, как отдельные части вашей презентации взаимосвязаны. 

![масштаб_раздела_изображение](seczoomsel.png)

Для объектов масштаба раздела Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) и некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание Zoom‑рамок раздела**
Вы можете добавить Zoom‑рамку раздела на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд. 
3. Добавьте фон идентификации к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать Zoom‑рамку. 
5. Добавьте Zoom‑рамку раздела (ссылающуюся на созданный раздел) на первый слайд.
6. Запишите изменённую презентацию в файл PPTX.

Этот C#‑код показывает, как создать Zoom‑рамку на слайде:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 1", slide);

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Создание Zoom‑рамок раздела с пользовательскими изображениями**
С помощью Aspose.Slides для .NET вы можете создать Zoom‑рамку раздела с другим изображением‑предпросмотром слайда следующим образом: 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд.
3. Добавьте фон идентификации к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать Zoom‑рамку. 
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использовано для заполнения рамки.
6. Добавьте Zoom‑рамку раздела (ссылающуюся на созданный раздел) на первый слайд.
7. Запишите изменённую презентацию в файл PPTX.

Этот C#‑код показывает, как создать Zoom‑рамку с другим изображением:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 1", slide);

    // Создаёт новое изображение для объекта Zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Форматирование Zoom‑рамок раздела**
Чтобы создать более сложные Zoom‑рамки раздела, необходимо изменить их форматирование. Существует несколько параметров форматирования, которые можно применить к Zoom‑рамке раздела. 

Вы можете управлять форматированием Zoom‑рамки раздела на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд.
3. Добавьте фон идентификации к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать Zoom‑рамку. 
5. Добавьте Zoom‑рамку раздела (ссылающуюся на созданный раздел) на первый слайд.
6. Измените размер и положение созданного объекта Zoom‑раздела.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использовано для заполнения рамки.
8. Установите пользовательское изображение для созданного объекта Zoom‑раздела.
9. Включите возможность *возврата к оригинальному слайду из связанного раздела*. 
10. Удалите фон изображения объекта Zoom‑раздела.
11. Измените формат линии для второго объекта Zoom‑рамки.
12. Измените длительность перехода.
13. Запишите изменённую презентацию в файл PPTX.

Этот C#‑код показывает, как изменить форматирование Zoom‑рамки раздела:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 1", slide);

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Форматирование для SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Обзорный масштаб**
Обзорный масштаб похож на целевую страницу, на которой сразу отображаются все части вашей презентации. Во время показа вы можете использовать масштаб, чтобы переходить из одной части презентации в другую в произвольном порядке. Вы можете проявлять креативность, прыгать вперёд или возвращаться к отдельным слайдам без прерывания потока презентации.

![масштаб_обзора_изображение](sumzoomsel.png)

Для объектов обзорного масштаба Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection), а также некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание обзорного масштаба**
Вы можете добавить обзорный масштаб на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды с фоном идентификации и новыми разделами для этих слайдов.
3. Добавьте обзорный масштаб на первый слайд.
4. Запишите изменённую презентацию в файл PPTX.

Этот C#‑код показывает, как создать обзорный масштаб на слайде:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 2", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 3", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 4", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Добавление и удаление разделов обзорного масштаба**
Все разделы в объекте обзорного масштаба представлены объектами [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). Вы можете добавить или удалить раздел через интерфейс [ISummaryZoomSectionCollection] следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды с фоном идентификации и новыми разделами для этих слайдов.
3. Добавьте обзорный масштаб на первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в объект обзорного масштаба.
6. Удалите первый раздел из объекта обзорного масштаба.
7. Запишите изменённую презентацию в файл PPTX.

Этот C#‑код показывает, как добавить и удалить разделы в объекте обзорного масштаба:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 2", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Добавляет раздел в Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Удаляет раздел из Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Форматирование разделов обзорного масштаба**
Чтобы создать более сложные объекты разделов обзорного масштаба, необходимо изменить их форматирование. Существует несколько параметров форматирования, которые можно применить к объекту раздела обзорного масштаба. 

Вы можете управлять форматированием раздела обзорного масштаба в объекте обзорного масштаба следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды с фоном идентификации и новыми разделами для этих слайдов.
3. Добавьте обзорный масштаб на первый слайд.
4. Получите объект раздела обзорного масштаба из `ISummaryZoomSectionCollection` для первого элемента.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использовано для заполнения рамки.
6. Установите пользовательское изображение для созданного объекта Zoom‑раздела.
7. Включите возможность *возврата к оригинальному слайду из связанного раздела*. 
8. Измените формат линии для второго объекта Zoom‑рамки.
9. Измените длительность перехода.
10. Запишите изменённую презентацию в файл PPTX.

Этот C#‑код показывает, как изменить форматирование объекта раздела обзорного масштаба:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 2", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Получает первый объект SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Форматирование объекта SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Могу ли я управлять возвратом к «родительскому» слайду после показа цели?**

Да. У [Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) или [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) есть параметр `ReturnToParent`, который при включении отправляет зрителей обратно к исходному слайду после посещения целевого содержимого.

**Можно ли изменить «скорость» или длительность перехода Zoom?**

Да. Для Zoom можно задать `TransitionDuration`, что позволяет контролировать продолжительность анимации перехода.

**Есть ли ограничения на количество объектов Zoom в презентации?**

Твёрдого ограничения API не документировано. Практические ограничения зависят от общей сложности презентации и производительности устройства просмотра. Вы можете добавлять множество Zoom‑рамок, но следует учитывать размер файла и время рендеринга.