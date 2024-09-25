---
title: Управление Зумом
type: docs
weight: 60
url: /net/manage-zoom/
keywords: "Zoom, рамка зума, добавить зум, формат рамки зума, Зум резюме, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте зум или рамки зума в презентации PowerPoint на C# или .NET"
---

## **Обзор**
Зумы в PowerPoint позволяют вам переходить к конкретным слайдам, разделам и частям презентации и обратно. Когда вы представляете, эта возможность быстро перемещаться по контенту может оказаться очень полезной.

![overview_image](overview.png)

* Чтобы обобщить всю презентацию на одном слайде, используйте [Зум резюме](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Зум слайда](#Slide-Zoom).
* Чтобы показать только один раздел, используйте [Зум раздела](#Section-Zoom).

## **Зум слайда**
Зум слайда может сделать вашу презентацию более динамичной, позволяя вам свободно перемещаться между слайдами в любом порядке без прерывания потока вашей презентации. Зумы слайдов отличны для коротких презентаций без множества разделов, но вы все равно можете использовать их в различных сценариях презентации.

Зумы слайдов помогают вам углубиться в несколько частей информации, ощущая себя на одном канвасе.

![overview_image](slidezoomsel.png)

Для объектов зума слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), интерфейс [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание рамок зума**

Вы можете добавить рамку зума на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды, к которым вы собираетесь связать рамки зума.
3. Добавьте идентификационный текст и фон к созданным слайдам.
4. Добавьте рамки зума (с содержащими ссылками на созданные слайды) к первому слайду.
5. Запишите измененную презентацию в виде файла PPTX.

Этот код C# показывает, как создать рамку зума на слайде:

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
    autoshape.TextFrame.Text = "Второй слайд";

    // Создает фон для третьего слайда
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Создает текстовое поле для третьего слайда
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Третий слайд";

    //Добавляет объекты ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Создание рамок зума с индивидуальными изображениями**
С помощью Aspose.Slides для .NET вы можете создать рамку зума с другим изображением предпросмотра слайда следующим образом: 
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд, к которому вы собираетесь связать рамку зума. 
3. Добавьте идентификационный текст и фон к слайду.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который будет использоваться для заполнения рамки.
5. Добавьте рамки зума (с содержащими ссылками на созданный слайд) к первому слайду.
6. Запишите измененную презентацию в виде файла PPTX.

Этот код C# показывает, как создать рамку зума с другим изображением:

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
    autoshape.TextFrame.Text = "Второй слайд";

    // Создает новое изображение для объекта зума
    IPPImage image = pres.Images.AddImage(Image.FromFile("image.png"));

    //Добавляет объект ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, image);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Форматирование рамок зума**
В предыдущих разделах мы показали, как создать простые рамки зума. Чтобы создать более сложные рамки зума, вам необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые вы можете применить к рамке зума. 

Вы можете контролировать форматирование рамки зума на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды, к которым вы собираетесь связать рамку зума. 
3. Добавьте некоторый идентификационный текст и фон к созданным слайдам.
4. Добавьте рамки зума (с содержащими ссылками на созданные слайды) к первому слайду.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который будет использоваться для заполнения рамки.
6. Установите индивидуальное изображение для первого объекта рамки зума.
7. Измените формат линии для второго объекта рамки зума.
8. Удалите фон из изображения второго объекта рамки зума.
9. Запишите измененную презентацию в виде файла PPTX.

Этот код C# показывает, как изменить форматирование рамки зума на слайде:

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
    autoshape.TextFrame.Text = "Второй слайд";

    // Создает фон для третьего слайда
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Создает текстовое поле для третьего слайда
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Третий слайд";

    //Добавляет объекты ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Создает новое изображение для объекта зума
    IPPImage image = pres.Images.AddImage(Image.FromFile("image.png"));
    // Устанавливает индивидуальное изображение для объекта zoomFrame1
    zoomFrame1.Image = image;

    // Устанавливает формат рамки зума для объекта zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Установка для Не показывать фон для объекта zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Зум раздела**

Зум раздела — это ссылка на раздел в вашей презентации. Вы можете использовать зумы разделов, чтобы вернуться к разделам, которые действительно хотите подчеркнуть. Или вы можете использовать их, чтобы показать, как определенные части вашей презентации связаны.

![overview_image](seczoomsel.png)

Для объектов зума раздела Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание рамок зума раздела**

Вы можете добавить рамку зума раздела на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд. 
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы собираетесь связать рамку зума. 
5. Добавьте рамку зума раздела (с содержащими ссылками на созданный раздел) к первому слайду.
6. Запишите измененную презентацию в виде файла PPTX.

Этот код C# показывает, как создать рамку зума на слайде:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 1", slide);

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Создание рамок зума раздела с индивидуальными изображениями**

Используя Aspose.Slides для .NET, вы можете создать рамку зума раздела с другим изображением предпросмотра слайда следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы собираетесь связать рамку зума. 
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который будет использоваться для заполнения рамки.
6. Добавьте рамку зума раздела (с содержащими ссылками на созданный раздел) к первому слайду.
7. Запишите измененную презентацию в виде файла PPTX.

Этот код C# показывает, как создать рамку зума с другим изображением:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 1", slide);

    // Создает новое изображение для объекта зума
    IPPImage image = pres.Images.AddImage(Image.FromFile("image.png"));

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], image);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Форматирование рамок зума раздела**

Чтобы создать более сложные рамки зума раздела, вам необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые вы можете применить к рамке зума раздела. 

Вы можете контролировать форматирование рамки зума раздела на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы собираетесь связать рамку зума. 
5. Добавьте рамку зума раздела (с содержащими ссылками на созданный раздел) к первому слайду.
6. Измените размер и позицию созданного объекта зума раздела.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который будет использоваться для заполнения рамки.
8. Установите индивидуальное изображение для созданного объекта рамки зума раздела.
9. Установите возможность *возвращаться к оригинальному слайду из связанного раздела*. 
10. Удалите фон из изображения объекта рамки зума раздела.
11. Измените формат линии для второго объекта рамки зума.
12. Измените продолжительность перехода.
13. Запишите измененную презентацию в виде файла PPTX.

Этот код C# показывает, как изменить форматирование рамки зума раздела:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 1", slide);

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Форматирование для SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IPPImage image = pres.Images.AddImage(Image.FromFile("image.png"));
    sectionZoomFrame.Image = image;

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

## **Зум резюме**

Зум резюме — это как целевая страница, где все элементы вашей презентации отображаются одновременно. Когда вы представляете, вы можете использовать зум, чтобы перейти из одного места вашей презентации в другое в любом порядке, который вам нравится. Вы можете проявить креативность, пропустить вперед или снова посетить части вашего слайд-шоу, не прерывая поток вашей презентации.

![overview_image](sumzoomsel.png)

Для объектов зума резюме Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Создание зума резюме**

Вы можете добавить рамку зума резюме на слайд таким образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте рамку зума резюме к первому слайду.
4. Запишите измененную презентацию в виде файла PPTX.

Этот код C# показывает, как создать рамку зума резюме на слайде:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 2", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 3", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 4", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Добавление и удаление секции зума резюме**

Все секции в рамке зума резюме представлены объектами [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). Вы можете добавлять или удалять объект секции зума резюме через интерфейс [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте рамку зума резюме в первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в рамку зума резюме.
6. Удалите первый раздел из рамки зума резюме.
7. Запишите измененную презентацию в виде файла PPTX.

Этот код C# показывает, как добавлять и удалять секции в рамке зума резюме:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 2", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    ISection section3 = pres.Sections.AddSection("Раздел 3", slide);

    // Добавляет раздел в зум резюме
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Удаляет раздел из зума резюме
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Сохраняет презентацию
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Форматирование секций зума резюме**

Чтобы создать более сложные объекты секции зума резюме, вам необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые вы можете применять к объекту секции зума резюме. 

Вы можете контролировать форматирование объекта секции зума резюме в рамке зума резюме следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте рамку зума резюме к первому слайду.
4. Получите объект секции зума резюме для первого объекта из `ISummaryZoomSectionCollection`.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который будет использоваться для заполнения рамки.
6. Установите индивидуальное изображение для созданного объекта секции зума резюме.
7. Установите возможность *возвращаться к оригинальному слайду из связанного раздела*. 
8. Измените формат линий для второго объекта зума.
9. Измените продолжительность перехода.
10. Запишите измененную презентацию в виде файла PPTX.

Этот код C# показывает, как изменить форматирование для объекта секции зума резюме:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Добавляет новый раздел в презентацию
    pres.Sections.AddSection("Раздел 2", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Получает первый объект SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    // Форматирование для объекта SummaryZoomSection
    IPPImage image = pres.Images.AddImage(Image.FromFile("image.png"));
    summarySection.Image = image;

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