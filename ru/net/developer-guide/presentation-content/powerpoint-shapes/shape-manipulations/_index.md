---
title: Манипуляции с Формами
type: docs
weight: 40
url: /net/shape-manipulations/
keywords: "Форма PowerPoint, форма на слайде, найти форму, клонировать форму, удалить форму, скрыть форму, изменить порядок формы, получить идентификатор межоперационной формы, альтернативный текст формы, форматы макета формы, форма как SVG, выровнять форму, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Манипуляции с формами PowerPoint на C# или .NET"
---

## **Найти Форму на Слайде**
Эта тема опишет простую технику, которая упростит разработчикам поиск конкретной формы на слайде без использования её внутреннего идентификатора. Важно знать, что файлы презентаций PowerPoint не имеют способа идентификации форм на слайде, кроме как внутреннего уникального идентификатора. Кажется, что разработчикам сложно найти форму, используя её внутренний уникальный идентификатор. Все формы, добавленные на слайды, имеют некоторый альтернативный текст. Мы рекомендуем разработчикам использовать альтернативный текст для поиска конкретной формы. Вы можете использовать MS PowerPoint для определения альтернативного текста объектов, которые вы планируете изменить в будущем.

После установки альтернативного текста для любой желаемой формы вы можете открыть эту презентацию с помощью Aspose.Slides для .NET и перебрать все формы, добавленные на слайд. Во время каждой итерации вы можете проверить альтернативный текст формы, и форма с совпадающим альтернативным текстом будет необходимой для вас. Чтобы продемонстрировать эту технику более наглядно, мы создали метод [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1), который делает трюк по поиску конкретной формы на слайде и просто возвращает эту форму.

```c#
public static void Run()
{
    // Создание экземпляра класса Presentation, который представляет файл презентации
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Альтернативный текст формы, которую нужно найти
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Имя формы: " + shape.Name);
        }
    }
}
        
// Реализация метода для поиска формы на слайде с использованием альтернативного текста
public static IShape FindShape(ISlide slide, string alttext)
{
    // Перебор всех форм на слайде
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Если альтернативный текст слайда совпадает с требуемым
        // Вернуть форму
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **Клонировать Форму**
Чтобы клонировать форму на слайд с помощью Aspose.Slides для .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите коллекцию форм исходного слайда.
1. Добавьте новый слайд в презентацию.
1. Клонируйте формы из коллекции форм исходного слайда на новый слайд.
1. Сохраните изменённую презентацию в качестве файла PPTX.

Ниже приведённый пример добавляет группированную форму на слайд.

```c#
// Создание экземпляра класса Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Запись файла PPTX на диск
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **Удалить Форму**
Aspose.Slides для .NET позволяет разработчикам удалять любую форму. Чтобы удалить форму с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
1. Получите первый слайд.
1. Найдите форму с конкретным альтернативным текстом.
1. Удалите форму.
1. Сохраните файл на диск.

```c#
// Создание объекта Presentation
Presentation pres = new Presentation();

// Получение первого слайда
ISlide sld = pres.Slides[0];

// Добавление автоформы прямоугольной формы
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "Пользовательский текст";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Сохранение презентации на диск
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```



## **Скрыть Форму**
Aspose.Slides для .NET позволяет разработчикам скрывать любую форму. Чтобы скрыть форму с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
1. Получите первый слайд.
1. Найдите форму с конкретным альтернативным текстом.
1. Скрыть форму.
1. Сохраните файл на диск.

```c#
// Создание экземпляра класса Presentation, представляющего PPTX
Presentation pres = new Presentation();

// Получение первого слайда
ISlide sld = pres.Slides[0];

// Добавление автоформы прямоугольной формы
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "Пользовательский текст";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Сохранение презентации на диск
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```



## **Изменить Порядок Форм**
Aspose.Slides для .NET позволяет разработчикам изменять порядок форм. Изменение порядка формы указывает, какая форма находится спереди, а какая - сзади. Чтобы изменить порядок формы на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
1. Получите первый слайд.
1. Добавьте форму.
1. Добавьте текст в текстовое поле формы.
1. Добавьте другую форму с теми же координатами.
1. Измените порядок форм.
1. Сохраните файл на диск.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Текст Водяного Знака Текст Водяного Знака Текст Водяного Знака";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **Получить Идентификатор Interop Формы**
Aspose.Slides для .NET позволяет разработчикам получать уникальный идентификатор формы в пределах слайда в отличие от свойства UniqueId, которое позволяет получить уникальный идентификатор в пределах презентации. Свойство OfficeInteropShapeId было добавлено к интерфейсам IShape и классу Shape соответственно. Значение, возвращаемое свойством OfficeInteropShapeId, соответствует значению Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведён образец кода.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Получение уникального идентификатора формы в пределах слайда
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **Установить Альтернативный Текст для Формы**
Aspose.Slides для .NET позволяет разработчикам устанавливать альтернативный текст для любой формы. 
Формы в презентации могут быть различимы по альтернативному тексту или свойству имени формы. 
Свойство AlternativeText может читаться или устанавливаться с помощью Aspose.Slides, а также Microsoft PowerPoint. 
Используя это свойство, вы можете пометить форму и выполнять различные операции, такие как удаление формы, 
скрытие формы или изменение порядка форм на слайде.
Чтобы установить альтернативный текст для формы, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
1. Получите первый слайд.
1. Добавьте любую форму на слайд.
1. Выполните некоторые операции с вновь добавленной формой.
1. Переберите формы, чтобы найти форму.
1. Установите альтернативный текст.
1. Сохраните файл на диск.

```c#
// Создание экземпляра класса Presentation, представляющего PPTX
Presentation pres = new Presentation();

// Получение первого слайда
ISlide sld = pres.Slides[0];

// Добавление автоформы прямоугольной формы
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "Пользовательский текст";
    }
}

// Сохранение презентации на диск
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **Доступ к Форматам Макета для Формы**
 Aspose.Slides для .NET предоставляет простой API для доступа к форматам макета для формы. Эта статья демонстрирует, как вы можете получить доступ к форматам макета.

Ниже приведён образец кода.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **Отрисовать Форму как SVG**
Теперь Aspose.Slides для .NET поддерживает отрисовку формы как SVG. Методы WriteAsSvg (и его перегрузки) были добавлены в класс Shape и интерфейс IShape. Этот метод позволяет сохранять содержимое формы как SVG файл. Ниже показан фрагмент кода, показывающий, как экспортировать форму слайда в SVG файл.

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## Выровнять Форму

С помощью перегруженного метода [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) вы можете 

* выровнять формы относительно полей слайда. См. Пример 1. 
* выровнять формы относительно друг друга. См. Пример 2. 

Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) определяет доступные параметры выравнивания.

### Пример 1

Этот код C# показывает, как выровнять формы с индексами 1, 2 и 4 вдоль верхней границы слайда:
Исходный код ниже выравнивает формы с индексами 1, 2 и 4 вдоль верхней границы слайда. 

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

### Пример 2

Этот код C# показывает, как выровнять всю коллекцию форм относительно нижней формы в коллекции:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```