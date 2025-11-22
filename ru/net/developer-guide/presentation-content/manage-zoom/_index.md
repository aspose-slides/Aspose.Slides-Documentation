---
title: Управление Zoom
type: docs
weight: 60
url: /ru/net/manage-zoom/
keywords:
  - zoom
  - кадр zoom
  - добавить zoom
  - форматировать кадр zoom
  - сводный zoom
  - презентация PowerPoint
  - C#
  - Csharp
  - Aspose.Slides for .NET
description: "Добавьте zoom или кадры zoom в презентации PowerPoint на C# или .NET"
---

## **Обзор**
Zoom в PowerPoint позволяет переходить к конкретным слайдам, разделам и частям презентации и возвращаться от них. При проведении презентации такая возможность быстрого перемещения по содержимому может оказаться очень полезной. 

![overview_image](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Сводный Zoom](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Zoom слайда](#Slide-Zoom).
* Чтобы показать только один раздел, используйте [Zoom раздела](#Section-Zoom).

## **Zoom слайда**
Zoom слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любом порядке без прерывания потока презентации. Zoom слайда отлично подходит для коротких презентаций без множества разделов, но их можно использовать и в других сценариях.

Zoom слайда помогает углубляться в несколько блоков информации, создавая ощущение, что вы работаете на едином холсте. 

![overview_image](slidezoomsel.png)

Для объектов Zoom слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), интерфейс [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) и некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание Zoom‑кадров**

Вы можете добавить Zoom‑кадр на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды, к которым вы планируете привязать Zoom‑кадры. 
3. Добавьте идентификационный текст и фон к созданным слайдам.
4. Добавьте Zoom‑кадры (содержащие ссылки на созданные слайды) на первый слайд.
5. Сохраните изменённую презентацию в файл PPTX.

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

    //Adds ZoomFrame objects
    // Добавляет объекты ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Saves the presentation
    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Создание Zoom‑кадров с пользовательскими изображениями**
С помощью Aspose.Slides для .NET вы можете создать Zoom‑кадр с другим изображением предварительного просмотра слайда следующим образом: 
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд, к которому вы планируете привязать Zoom‑кадр. 
3. Добавьте идентификационный текст и фон к слайду.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), которое будет использоваться для заполнения кадра.
5. Добавьте Zoom‑кадры (содержащие ссылку на созданный слайд) на первый слайд.
6. Сохраните изменённую презентацию в файл PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adds a new slide to the presentation
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Creates a background for the second slide
    // Создаёт фон для второго слайда
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Creates a text box for the third slide
    // Создаёт текстовое поле для третьего слайда
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Creates a new image for the zoom object
    // Создаёт новое изображение для объекта Zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Adds the ZoomFrame object
    //Добавляет объект ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Saves the presentation
    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Форматирование Zoom‑кадров**
В предыдущих разделах мы показали, как создать простые Zoom‑кадры. Чтобы создать более сложные Zoom‑кадры, необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые можно применить к Zoom‑кадру. 

Вы можете управлять форматированием Zoom‑кадра на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды, к которым вы планируете привязать Zoom‑кадр. 
3. Добавьте идентификационный текст и фон к созданным слайдам.
4. Добавьте Zoom‑кадры (содержащие ссылки на созданные слайды) на первый слайд.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) для заполнения кадра.
6. Установите собственное изображение для первого Zoom‑кадра.
7. Измените формат линии для второго Zoom‑кадра.
8. Удалите фон из изображения второго Zoom‑кадра.
5. Сохраните изменённую презентацию в файл PPTX.

``` csharp
using (Presentation pres = new Presentation())
{
    // Добавляет новые слайды в презентацию
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

    // Добавляет объекты ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Создаёт новое изображение для объекта Zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Устанавливает пользовательское изображение для объекта zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Устанавливает формат zoom‑кадра для объекта zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Настройка отключения фонового изображения для объекта zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Zoom раздела**

Zoom раздела — это ссылка на раздел в вашей презентации. Вы можете использовать Zoom раздела, чтобы вернуться к разделам, которые хотите особенно подчеркнуть. Или использовать их для демонстрации того, как отдельные части вашей презентации связаны между собой. 

![overview_image](seczoomsel.png)

Для объектов Zoom раздела Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) и некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание Zoom‑кадров раздела**

Вы можете добавить Zoom‑кадр раздела на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд. 
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы планируете привязать Zoom‑кадр. 
5. Добавьте Zoom‑кадр раздела (содержащий ссылки на созданный раздел) на первый слайд.
6. Сохраните изменённую презентацию в файл PPTX.

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

### **Создание Zoom‑кадров раздела с пользовательскими изображениями**

Используя Aspose.Slides для .NET, вы можете создать Zoom‑кадр раздела с другим изображением предварительного просмотра слайда следующим образом: 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы планируете привязать Zoom‑кадр. 
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) для заполнения кадра.
5. Добавьте Zoom‑кадр раздела (содержащий ссылку на созданный раздел) на первый слайд.
6. Сохраните изменённую презентацию в файл PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    // Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 1", slide);

    // Создаёт новое изображение для объекта zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Форматирование Zoom‑кадров раздела**

Чтобы создать более сложные Zoom‑кадры раздела, необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые можно применить к Zoom‑кадру раздела. 

Вы можете управлять форматированием Zoom‑кадра раздела на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы планируете привязать Zoom‑кадр. 
5. Добавьте Zoom‑кадр раздела (содержащий ссылки на созданный раздел) на первый слайд.
6. Измените размер и позицию созданного Zoom‑кадра раздела.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) для заполнения кадра.
8. Установите собственное изображение для созданного Zoom‑кадра раздела.
9. Установите возможность *возвращения к исходному слайду из связанного раздела*.
10. Удалите фон из изображения Zoom‑кадра раздела.
11. Измените формат линии для второго Zoom‑кадра.
12. Измените длительность перехода.
13. Сохраните изменённую презентацию в файл PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    // Добавляет новый слайд в презентацию
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



## **Сводный Zoom**

Сводный Zoom похож на целевую страницу, где все части вашей презентации отображаются одновременно. Когда вы проводите презентацию, можно использовать Zoom, чтобы перейти от одного места к другому в любом порядке. Можно проявлять креативность, пропускать части или возвращаться к любым слайдам без прерывания потока презентации.

![overview_image](sumzoomsel.png)

Для объектов Сводного Zoom Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection), а также некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание Сводного Zoom**

Вы можете добавить Сводный Zoom‑кадр на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте Сводный Zoom‑кадр на первый слайд.
4. Сохраните изменённую презентацию в файл PPTX.

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

    //Добавяет новый слайд в презентацию
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


### **Добавление и удаление секций Сводного Zoom**

Все секции в Сводном Zoom‑кадре представлены объектами [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). Вы можете добавить или удалить объект секции Сводного Zoom через интерфейс [ISummaryZoomSectionCollection] следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте Сводный Zoom‑кадр в первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в Сводный Zoom‑кадр.
6. Удалите первый раздел из Сводного Zoom‑кадра.
7. Сохраните изменённую презентацию в файл PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    // Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 1", slide);

    // Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 2", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Добавляет новый слайд в презентацию
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


### **Форматирование секций Сводного Zoom**

Чтобы создать более сложные объекты секций Сводного Zoom, необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые можно применить к объекту секции Сводного Zoom. 

Вы можете управлять форматированием объекта секции Сводного Zoom в Сводном Zoom‑кадре следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте Сводный Zoom‑кадр на первый слайд.
4. Получите объект секции Сводного Zoom для первого элемента из `ISummaryZoomSectionCollection`.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) для заполнения кадра.
8. Установите собственное изображение для созданного Zoom‑кадра секции.
9. Установите возможность *возвращения к исходному слайду из связанного раздела*.
11. Измените формат линии для второго Zoom‑кадра.
12. Измените длительность перехода.
13. Сохраните изменённую презентацию в файл PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    // Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Section 1", slide);

    // Добавляет новый слайд в презентацию
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

Да. У [Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) или [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) есть свойство `ReturnToParent`, которое при включении отправляет зрителей обратно на исходный слайд после посещения целевого содержимого.

**Могу ли я настроить «скорость» или длительность перехода Zoom?**

Да. Zoom поддерживает установку `TransitionDuration`, позволяя контролировать продолжительность анимации перехода.

**Есть ли ограничения на количество объектов Zoom, которые может содержать презентация?**

Жёстких ограничений API не задокументировано. Практические ограничения зависят от общей сложности презентации и производительности устройства просмотра. Можно добавить многие Zoom‑кадры, но следует учитывать размер файла и время рендеринга.