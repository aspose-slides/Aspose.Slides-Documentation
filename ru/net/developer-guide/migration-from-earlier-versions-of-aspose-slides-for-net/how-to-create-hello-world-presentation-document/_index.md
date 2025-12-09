---
title: Как создать презентацию Hello World в .NET
linktitle: Презентация Hello World
type: docs
weight: 10
url: /ru/net/how-to-create-hello-world-presentation-document/
keywords:
- миграция
- hello world
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
- description: "Создайте презентацию Hello World в PowerPoint PPT, PPTX и ODP в .NET с помощью Aspose.Slides, используя как устаревший, так и современный API, в простом руководстве."
---

{{% alert color="primary" %}} 
Выпущен новый [Aspose.Slides for .NET API](/slides/ru/net/), и теперь этот единственный продукт поддерживает возможность создавать документы PowerPoint с нуля и редактировать существующие.
{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный с Aspose.Slides for .NET версиями ранее 13.x, необходимо внести небольшие изменения в ваш код, и он будет работать как раньше. Все классы, которые были в старой Aspose.Slides for .NET в пространствах имен Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в едином пространстве имен Aspose.Slides. Пожалуйста, ознакомьтесь со следующим простым примером кода для создания презентации Hello World в устаревшем API Aspose.Slides и следуйте шагам, описывающим, как перейти к новому объединённому API.
## **Подход устаревшего Aspose.Slides for .NET**
```c#
//Создать объект Presentation, представляющий PPT‑файл
Presentation pres = new Presentation();

//Создать объект License
License license = new License();

//Установить лицензию Aspose.Slides for .NET, чтобы избежать ограничений оценки
license.SetLicense("Aspose.Slides.lic");

//Добавление пустого слайда в презентацию и получение ссылки на
//этот пустой слайд
Slide slide = pres.AddEmptySlide();

//Добавление прямоугольника (X=2400, Y=1800, Ширина=1000 & Высота=500) к слайду
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Скрытие линий прямоугольника
rect.LineFormat.ShowLines = false;

//Добавление текстового кадра в прямоугольник с текстом "Hello World" по умолчанию
rect.AddTextFrame("Hello World");

//Удаление первого слайда презентации, который всегда добавляется
//Aspose.Slides for .NET по умолчанию при создании презентации
pres.Slides.RemoveAt(0);

//Запись презентации в виде PPT‑файла
pres.Write("C:\\hello.ppt");
```


## **Подход новой Aspose.Slides for .NET 13.x**
```c#
// Создать объект Presentation
Presentation pres = new Presentation();

// Получить первый слайд
ISlide sld = (ISlide)pres.Slides[0];

// Добавить AutoShape типа Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Добавить ITextFrame к прямоугольнику
ashp.AddTextFrame("Hello World");

// Изменить цвет текста на Black (по умолчанию White)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Изменить цвет линии прямоугольника на White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Удалить любые параметры заливки в фигуре
ashp.FillFormat.FillType = FillType.NoFill;

// Сохранить презентацию на диск
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
