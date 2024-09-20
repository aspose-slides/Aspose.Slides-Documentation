---
title: Как создать документ представления Hello World
type: docs
weight: 10
url: /net/how-to-create-hello-world-presentation-document/
---

{{% alert color="primary" %}} 

Выпущен новый [Aspose.Slides для .NET API](/slides/net/), который теперь поддерживает возможность создания документов PowerPoint с нуля и редактирования существующих.

{{% /alert %}} 
## **Поддержка устаревшего кода**
Для использования устаревшего кода, разработанного с помощью версий Aspose.Slides для .NET, ранних чем 13.x, вам нужно внести некоторые незначительные изменения в ваш код, и он будет работать как раньше. Все классы, которые были в старом Aspose.Slides для .NET в пространствах имен Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в одно пространство имен Aspose.Slides. Пожалуйста, посмотрите на следующий простой фрагмент кода для создания документа представления Hello World в устаревшем API Aspose.Slides и следуйте шагам, описывающим, как мигрировать на новый объединенный API.
## **Подход устаревшего Aspose.Slides для .NET**
```c#
//Создать объект Presentation, представляющий файл PPT
Presentation pres = new Presentation();

//Создать объект License
License license = new License();

//Установить лицензию Aspose.Slides для .NET, чтобы избежать ограничений на оценку
license.SetLicense("Aspose.Slides.lic");

//Добавление пустого слайда в презентацию и получение ссылки на
//этот пустой слайд
Slide slide = pres.AddEmptySlide();

//Добавление прямоугольника (X=2400, Y=1800, Ширина=1000 и Высота=500) на слайд
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Скрытие линий прямоугольника
rect.LineFormat.ShowLines = false;

//Добавление текстового фрейма в прямоугольник с "Hello World" в качестве текста по умолчанию
rect.AddTextFrame("Hello World");

//Удаление первого слайда презентации, который всегда добавляется
//Aspose.Slides для .NET по умолчанию при создании презентации
pres.Slides.RemoveAt(0);

//Запись презентации в файл PPT
pres.Write("C:\\hello.ppt");
```



## **Подход нового Aspose.Slides для .NET 13.x**
```c#
// Создать Presentation
Presentation pres = new Presentation();

// Получить первый слайд
ISlide sld = (ISlide)pres.Slides[0];

// Добавить автофигуру типа Прямоугольник
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Добавить ITextFrame в Прямоугольник
ashp.AddTextFrame("Hello World");

// Изменить цвет текста на черный (который по умолчанию белый)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Изменить цвет линий прямоугольника на белый
ashp.ShapeStyle.LineColor.Color = Color.White;

// Удалить любое заливочное форматирование в фигуре
ashp.FillFormat.FillType = FillType.NoFill;

// Сохранить презентацию на диск
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```