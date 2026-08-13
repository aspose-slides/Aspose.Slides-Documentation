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
- description: "Создайте презентацию PowerPoint PPT, PPTX и ODP Hello World в .NET с помощью Aspose.Slides, используя как устаревший, так и современный API, в простом руководстве."
---
{{% alert color="info" %}} 
Новый [Aspose.Slides for .NET API](/slides/ru/net/) выпущен, и теперь этот единый продукт поддерживает возможность создавать документы PowerPoint с нуля и редактировать существующие.
{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный с версиями Aspose.Slides for .NET до 13.x, необходимо внести небольшие изменения в ваш код, после чего он будет работать как раньше. Все классы, которые находились в старых версиях Aspose.Slides for .NET в пространствах имён Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в едином пространстве имён Aspose.Slides. Пожалуйста, ознакомьтесь со следующим простым фрагментом кода для создания презентации Hello World в устаревшем API Aspose.Slides и следуйте инструкциям, описывающим, как перейти на новый объединённый API.
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

//Добавление пустого слайда в презентацию и получение ссылки на
//этот пустой слайд
Slide slide = pres.AddEmptySlide();

//Добавление прямоугольника (X=2400, Y=1800, Ширина=1000 & Высота=500) на слайд
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Скрытие линий прямоугольника
rect.LineFormat.ShowLines = false;

//Добавление текстового фрейма к прямоугольнику с "Hello World" в качестве текста по умолчанию
rect.AddTextFrame("Hello World");

//Удаление первого слайда презентации, который всегда добавляется
//Aspose.Slides for .NET по умолчанию при создании презентации
pres.Slides.RemoveAt(0);

//Запись презентации в файл PPT
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

// Удалить любые настройки заливки в фигуре
ashp.FillFormat.FillType = FillType.NoFill;

// Сохранить презентацию на диск
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```