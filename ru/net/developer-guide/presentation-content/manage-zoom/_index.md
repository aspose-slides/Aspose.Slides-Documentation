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
description: "Создавайте и настраивайте Zoom с помощью Aspose.Slides для .NET — переходите между разделами, добавляйте миниатюры и переходы в презентациях PPT, PPTX и ODP."
---

## **Обзор**
Zoom в PowerPoint позволяет переходить к определённым слайдам, разделам и частям презентации и возвращаться от них. При докладе эта возможность быстрой навигации по содержимому может оказаться очень полезной. 

![overview_image](overview.png)

* Чтобы обобщить всю презентацию на одном слайде, используйте [Summary Zoom](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Slide Zoom](#Slide-Zoom).
* Чтобы показать только один раздел, используйте [Section Zoom](#Section-Zoom).

## **Масштаб слайда**
Масштаб слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любом порядке без прерывания её хода. Масштабы слайда отлично подходят для коротких презентаций без большого количества разделов, но их можно использовать и в разных сценариях.

Масштабы слайда помогают детально рассмотреть несколько фрагментов информации, создавая ощущение работы на едином холсте. 

![overview_image](slidezoomsel.png)

Для объектов масштабов слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), интерфейс [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) и несколько методов в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание кадров масштабирования**

Вы можете добавить кадр масштабирования на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Создайте новые слайды, к которым планируете привязать кадры масштабирования. 
3.	Добавьте идентификационный текст и фон к созданным слайдам.
4.	Добавьте кадры масштабирования (ссылающиеся на созданные слайды) на первый слайд.
5.	Запишите изменённую презентацию в файл PPTX.

Этот C# код показывает, как создать кадр масштабирования на слайде:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новые слайды в презентацию
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //Создаёт фон для второго слайда
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //Создаёт текстовое поле для второго слайда
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //Создаёт фон для третьего слайда
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    //Создаёт текстовое поле для третьего слайда
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Добавляет объекты ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    //Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Создание кадров масштабирования с пользовательскими изображениями**
С помощью Aspose.Slides для .NET вы можете создать кадр масштабирования с другим изображением превью слайда следующим образом: 
1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Создайте новый слайд, к которому планируете привязать кадр масштабирования. 
3.	Добавьте идентификационный текст и фон к слайду.
4.	Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использовано для заполнения кадра.
5.	Добавьте кадры масштабирования (ссылающиеся на созданный слайд) на первый слайд.
6.	Запишите изменённую презентацию в файл PPTX.

Этот C# код показывает, как создать кадр масштабирования с другим изображением:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //Создаёт фон для второго слайда
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //Создаёт текстовое поле для третьего слайда
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //Создаёт новое изображение для объекта масштабирования
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Добавляет объект ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    //Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Форматирование кадров масштабирования**
В предыдущих разделах мы показали, как создавать простые кадры масштабирования. Чтобы создавать более сложные кадры, необходимо изменить их форматирование. Существует несколько параметров форматирования, которые можно применить к кадру масштабирования. 

Вы можете управлять форматированием кадра масштабирования на слайде следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Создайте новые слайды, к которым планируете привязать кадр масштабирования. 
3.	Добавьте идентификационный текст и фон к созданным слайдам.
4.	Добавьте кадры масштабирования (ссылающиеся на созданные слайды) на первый слайд.
5.	Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использовано для заполнения кадра.
6.	Установите пользовательское изображение для первого кадра масштабирования.
7.	Измените формат линии для второго кадра масштабирования.
8.	Удалите фон изображения второго кадра масштабирования.
5.	Запишите изменённую презентацию в файл PPTX.

Этот C# код показывает, как изменить форматирование кадра масштабирования на слайде: 
``` csharp
using (Presentation pres = new Presentation())
{
    //Добавляет новые слайды в презентацию
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //Создаёт фон для второго слайда
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //Создаёт текстовое поле для второго слайда
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //Создаёт фон для третьего слайда
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    //Создаёт текстовое поле для третьего слайда
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Добавляет объекты ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    //Создаёт новое изображение для объекта масштабирования
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Устанавливает пользовательское изображение для объекта zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    //Устанавливает формат рамки масштабирования для объекта zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    //Настройка: не показывать фон для объекта zoomFrame2
    zoomFrame2.ShowBackground = false;

    //Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Раздел масштабирования**

Раздел масштабирования — это ссылка на раздел вашей презентации. Вы можете использовать разделы масштабирования, чтобы возвращаться к разделам, которые хотите особенно подчеркнуть. Или использовать их, чтобы показать, как отдельные части вашей презентации связаны между собой. 

![overview_image](seczoomsel.png)

Для объектов разделов масштабирования Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) и несколько методов в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание кадров раздела масштабирования**

Вы можете добавить кадр раздела масштабирования на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Создайте новый слайд. 
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому планируете привязать кадр масштабирования. 
5.	Добавьте кадр раздела масштабирования (ссылающийся на созданный раздел) на первый слайд.
6.	Запишите изменённую презентацию в файл PPTX.

Этот C# код показывает, как создать кадр масштабирования на слайде:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    //Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 1", slide);

    //Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    //Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Создание кадров раздела масштабирования с пользовательскими изображениями**

С помощью Aspose.Slides для .NET вы можете создать кадр раздела масштабирования с другим изображением превью слайда следующим образом: 

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Создайте новый слайд.
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому планируете привязать кадр масштабирования. 
5.	Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использовано для заполнения кадра.
5.	Добавьте кадр раздела масштабирования (ссылающийся на созданный раздел) на первый слайд.
6.	Запишите изменённую презентацию в файл PPTX.

Этот C# код показывает, как создать кадр масштабирования с другим изображением:
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

    // Создаёт новое изображение для объекта масштабирования
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Форматирование кадров раздела масштабирования**

Чтобы создавать более сложные кадры раздела масштабирования, необходимо изменить их форматирование. Существует несколько параметров форматирования, которые можно применить к кадру раздела масштабирования. 

Вы можете управлять форматированием кадра раздела масштабирования на слайде следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Создайте новый слайд.
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому планируете привязать кадр масштабирования. 
5.	Добавьте кадр раздела масштабирования (ссылающийся на созданный раздел) на первый слайд.
6.	Измените размер и положение созданного объекта раздела масштабирования.
7.	Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использовано для заполнения кадра.
8.	Установите пользовательское изображение для созданного кадра раздела масштабирования.
9.	Установите возможность *возврата к оригинальному слайду из связанного раздела*. 
10.	Удалите фон изображения объекта раздела масштабирования.
11.	Измените формат линии для второго кадра масштабирования.
12.	Измените длительность перехода.
13.	Запишите изменённую презентацию в файл PPTX.

Этот C# код показывает, как изменить форматирование кадра раздела масштабирования:
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

    // Форматирование SectionZoomFrame
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

Обзорный масштаб — это своего рода целевая страница, на которой одновременно отображаются все части вашей презентации. При докладе вы можете использовать масштаб, чтобы переходить от одного места презентации к другому в произвольном порядке. Можно проявлять креативность, переключаться вперёд или возвращаться к отдельным элементам слайд‑шоу без нарушения его хода.

![overview_image](sumzoomsel.png)

Для объектов обзорного масштаба Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection), а также несколько методов в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание обзорного масштаба**

Вы можете добавить кадр обзорного масштаба на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте кадр обзорного масштаба на первый слайд.
4.	Запишите изменённую презентацию в файл PPTX.

Этот C# код показывает, как создать кадр обзорного масштаба на слайде:
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


### **Добавление и удаление раздела обзорного масштаба**

Все разделы в кадре обзорного масштаба представлены объектами [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). Вы можете добавить или удалить объект раздела обзорного масштаба через интерфейс [ISummaryZoomSectionCollection] следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте кадр обзорного масштаба в первый слайд.
4.	Добавьте новый слайд и раздел в презентацию.
5.	Добавьте созданный раздел в кадр обзорного масштаба.
6.	Удалите первый раздел из кадра обзорного масштаба.
7.	Запишите изменённую презентацию в файл PPTX.

Этот C# код показывает, как добавить и удалить разделы в кадре обзорного масштаба:
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

Чтобы создавать более сложные объекты разделов обзорного масштаба, необходимо изменить их форматирование. Существует несколько параметров форматирования, которые можно применить к объекту раздела обзорного масштаба. 

Вы можете управлять форматированием объекта раздела обзорного масштаба в кадре обзорного масштаба следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте кадр обзорного масштаба в первый слайд.
4.	Получите объект раздела обзорного масштаба для первого объекта из `ISummaryZoomSectionCollection`.
7.	Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использовано для заполнения кадра.
8.	Установите пользовательское изображение для созданного объекта раздела масштабирования.
9.	Установите возможность *возврата к оригинальному слайду из связанного раздела*. 
11.	Измените формат линии для второго кадра масштабирования.
12.	Измените длительность перехода.
13.	Запишите изменённую презентацию в файл PPTX.

Этот C# код показывает, как изменить форматирование объекта раздела обзорного масштаба:
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

Да. У [Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) или [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) есть свойство `ReturnToParent`, которое при включении отправляет зрителя обратно на исходный слайд после просмотра целевого содержимого.

**Могу ли я изменить «скорость» или длительность перехода Zoom?**

Да. Zoom поддерживает установку `TransitionDuration`, позволяя контролировать продолжительность анимации перехода.

**Есть ли ограничения на количество объектов Zoom, которые может содержать презентация?**

Жёстких ограничений в API нет. Практические ограничения зависят от общей сложности презентации и производительности устройства просмотра. Можно добавить много кадров Zoom, однако следует учитывать размер файла и время рендеринга.