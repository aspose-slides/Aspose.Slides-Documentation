---
title: Как создать презентацию Hello World в .NET
linktitle: Презентация Hello World
type: docs
weight: 10
url: /ru/net/how-to-create-hello-world-presentation-document/
keywords:
- миграция
- привет мир
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создайте презентацию Hello World PowerPoint PPT, PPTX и ODP в .NET с помощью Aspose.Slides, используя как устаревшие, так и современные API, в одном простом руководстве."
---
{{% alert color="info" %}} 

Выпущен новый [Aspose.Slides for .NET API](/slides/ru/net/), и теперь этот единый продукт поддерживает возможность создания PowerPoint-документов с нуля и редактирования существующих.

{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный с помощью Aspose.Slides for .NET версии ранее 13.x, необходимо внести небольшие изменения в ваш код, и он будет работать как ранее. Все классы, которые ранее находились в старых пространствах имен Aspose.Slides for .NET - Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в единственное пространство имен Aspose.Slides. Пожалуйста, обратите внимание на следующий простой фрагмент кода для создания презентации Hello World в устаревшем API Aspose.Slides и следуйте шагам, описывающим миграцию на новый объединенный API.
## **Подход к устаревшему Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Создайте объект Presentation, представляющий файл PPT
Presentation pres = new Presentation();

//Создайте объект License
License license = new License();

//Установите лицензию Aspose.Slides for .NET, чтобы избежать ограничений оценки
license.SetLicense("Aspose.Slides.lic");

//Добавляем пустой слайд в презентацию и получаем ссылку на
//этот пустой слайд
Slide slide = pres.AddEmptySlide();

//Добавляем прямоугольник (X=2400, Y=1800, Ширина=1000 & Высота=500) на слайд
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Скрываем линии прямоугольника
rect.LineFormat.ShowLines = false;

//Добавляем текстовый фрейм к прямоугольнику с "Hello World" как текстом по умолчанию
rect.AddTextFrame("Hello World");

//Удаляем первый слайд презентации, который всегда добавляется
//Aspose.Slides for .NET по умолчанию при создании презентации
pres.Slides.RemoveAt(0);

//Сохраняем презентацию как файл PPT
pres.Write("C:\\hello.ppt");
```



## **Подход к новому Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создать объект Presentation
Presentation pres = new Presentation();

// Получить первый слайд
ISlide sld = (ISlide)pres.Slides[0];

// Добавить AutoShape типа Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Добавить ITextFrame к прямоугольнику
ashp.AddTextFrame("Hello World");

// Изменить цвет текста на черный (по умолчанию он белый)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Изменить цвет линии прямоугольника на белый
ashp.ShapeStyle.LineColor.Color = Color.White;

// Удалить любой заливочный формат в фигуре
ashp.FillFormat.FillType = FillType.NoFill;

// Сохранить презентацию на диск
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```