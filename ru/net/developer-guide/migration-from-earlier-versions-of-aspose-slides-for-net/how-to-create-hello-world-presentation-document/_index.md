---
title: Как создать Hello World презентацию в .NET
linktitle: Hello World презентация
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

{{% alert color="primary" %}}

Выпущен новый [Aspose.Slides for .NET API](/slides/ru/net/), и теперь этот единственный продукт поддерживает возможность создавать документы PowerPoint с нуля и редактировать существующие.

{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный для Aspose.Slides for .NET версии до 13.x, необходимо внести некоторые небольшие изменения в ваш код, после чего он будет работать как и прежде. Все классы, которые ранее находились в пространствах имен Aspose.Slide и Aspose.Slides.Pptx старой версии Aspose.Slides for .NET, теперь объединены в одно пространство имен Aspose.Slides. Пожалуйста, ознакомьтесь со следующим простым примером кода для создания презентации Hello World в устаревшем API Aspose.Slides и следуйте шагам, описывающим миграцию к новому объединённому API.
## **Устаревший подход Aspose.Slides for .NET**
```c#
//Создать объект Presentation, представляющий PPT-файл
Presentation pres = new Presentation();

//Создать объект License
License license = new License();

//Установить лицензию Aspose.Slides for .NET, чтобы избежать ограничений оценки
license.SetLicense("Aspose.Slides.lic");

//Добавление пустого слайда в презентацию и получение ссылки на
//этот пустой слайд
Slide slide = pres.AddEmptySlide();

//Добавление прямоугольника (X=2400, Y=1800, Ширина=1000 & Height=500) на слайд
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Скрытие линий прямоугольника
rect.LineFormat.ShowLines = false;

//Добавление текстового фрейма в прямоугольник с "Hello World" в качестве текста по умолчанию
rect.AddTextFrame("Hello World");

//Удаление первого слайда презентации, который всегда добавляется
//Aspose.Slides for .NET по умолчанию при создании презентации
pres.Slides.RemoveAt(0);

//Запись презентации в виде PPT-файла
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

// Добавить ITextFrame к Rectangle
ashp.AddTextFrame("Hello World");

// Изменить цвет текста на черный (по умолчанию он белый)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Изменить цвет линии прямоугольника на белый
ashp.ShapeStyle.LineColor.Color = Color.White;

// Удалить любые настройки заливки в фигуре
ashp.FillFormat.FillType = FillType.NoFill;

// Сохранить презентацию на диск
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
