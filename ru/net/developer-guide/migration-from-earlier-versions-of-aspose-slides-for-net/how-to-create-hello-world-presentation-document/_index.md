---
title: Как создавать презентации Hello World в .NET
linktitle: Презентация Hello World
type: docs
weight: 10
url: /ru/net/how-to-create-hello-world-presentation-document/
keywords:
- миграция
- hello world
- наследуемый код
- современный код
- наследуемый подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создайте презентацию PowerPoint PPT, PPTX и ODP Hello World в .NET с помощью Aspose.Slides, используя как наследуемые, так и современные API, в простом руководстве."
---

{{% alert color="primary" %}} 

Выпущен новый [Aspose.Slides for .NET API](/slides/ru/net/), и теперь этот единый продукт поддерживает возможность создавать документы PowerPoint с нуля и редактировать существующие.

{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный с использованием Aspose.Slides for .NET версии до 13.x, необходимо внести несколько небольших изменений в ваш код, и он будет работать как прежде. Все классы, которые находились в старых пространствах имен Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в едином пространстве имен Aspose.Slides. Пожалуйста, ознакомьтесь со следующим простым фрагментом кода для создания презентации Hello World в устаревшем API Aspose.Slides и следуйте инструкциям, описывающим процесс миграции к новому объединённому API.
## **Устаревший подход Aspose.Slides for .NET**
```c#
//Создать объект Presentation, представляющий файл PPT
Presentation pres = new Presentation();

//Создать объект License
License license = new License();

//Установить лицензию Aspose.Slides for .NET, чтобы избежать ограничений оценки
license.SetLicense("Aspose.Slides.lic");

//Добавление пустого слайда в презентацию и получение ссылки на
//этот пустой слайд
Slide slide = pres.AddEmptySlide();

//Добавление прямоугольника (X=2400, Y=1800, Ширина=1000 и Высота=500) на слайд
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Скрытие линий прямоугольника
rect.LineFormat.ShowLines = false;

//Добавление текстового кадра в прямоугольник с текстом по умолчанию "Hello World"
rect.AddTextFrame("Hello World");

//Удаление первого слайда презентации, который всегда добавляется
//Aspose.Slides for .NET по умолчанию при создании презентации
pres.Slides.RemoveAt(0);

//Запись презентации в файл PPT
pres.Write("C:\\hello.ppt");
```




## **Новый подход Aspose.Slides for .NET 13.x**
```c#
// Создать объект Presentation
Presentation pres = new Presentation();

// Получить первый слайд
ISlide sld = (ISlide)pres.Slides[0];

// Добавить AutoShape типа Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Добавить ITextFrame к прямоугольнику
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
