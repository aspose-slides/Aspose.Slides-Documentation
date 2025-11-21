---
title: Как создать Hello World презентации в .NET
linktitle: Hello World презентация
type: docs
weight: 10
url: /ru/net/how-to-create-hello-world-presentation-document/
keywords:
- миграция
- hello world
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создайте Hello World PowerPoint PPT, PPTX и ODP презентацию в .NET с помощью Aspose.Slides, используя как унаследованные, так и современные API, в простом руководстве."
---

{{% alert color="primary" %}} 

Новый [Aspose.Slides for .NET API](/slides/ru/net/) был выпущен, и теперь этот единый продукт поддерживает возможность генерировать документы PowerPoint с нуля и редактировать существующие.

{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный для Aspose.Slides for .NET версий до 13.x, вам нужно внести небольшие изменения в ваш код, и он будет работать как раньше. Все классы, которые находились в старых версиях Aspose.Slides for .NET в пространствах имен Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в единственное пространство имен Aspose.Slides. Пожалуйста, ознакомьтесь со следующим простым примером кода для создания презентации Hello World в устаревшем API Aspose.Slides и следуйте шагам, описывающим миграцию к новому объединенному API.
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

//Добавление прямоугольника (X=2400, Y=1800, Width=1000 & Height=500) к слайду
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Скрытие линий прямоугольника
rect.LineFormat.ShowLines = false;

//Добавление текстового кадра в прямоугольник с "Hello World" в качестве текста по умолчанию
rect.AddTextFrame("Hello World");

//Удаление первого слайда презентации, который всегда добавляется
//Aspose.Slides for .NET по умолчанию при создании презентации
pres.Slides.RemoveAt(0);

//Сохранение презентации в виде файла PPT
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

// Изменить цвет текста на чёрный (по умолчанию он белый)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Изменить цвет линии прямоугольника на белый
ashp.ShapeStyle.LineColor.Color = Color.White;

// Удалить любое заполнение формы
ashp.FillFormat.FillType = FillType.NoFill;

// Сохранить презентацию на диск
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
