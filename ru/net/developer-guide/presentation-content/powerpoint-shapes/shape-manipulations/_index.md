---
title: Управление формами презентации в .NET
linktitle: Манипуляция формами
type: docs
weight: 40
url: /ru/net/shape-manipulations/
keywords:
- Форма PowerPoint
- Форма презентации
- Форма на слайде
- Найти форму
- Клонировать форму
- Удалить форму
- Скрыть форму
- Изменить порядок форм
- Получить Interop ID формы
- Альтернативный текст формы
- Форматы расположения формы
- Форма как SVG
- Форма в SVG
- Выровнять форму
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать, редактировать и оптимизировать формы в Aspose.Slides для .NET и предоставлять высокопроизводительные презентации PowerPoint."
---

## **Найти форму на слайде**
Эта тема будет описана простая техника, позволяющая разработчикам легче находить определённую форму на слайде без использования её внутреннего Id. Важно знать, что файлы PowerPoint Presentation не имеют способа идентифицировать формы на слайде, кроме внутреннего уникального Id. Разработчикам кажется сложно находить форму, используя её внутренний уникальный Id. Все формы, добавленные на слайды, имеют некоторый Alt Text. Мы советуем разработчикам использовать альтернативный текст для поиска определённой формы. Вы можете использовать MS PowerPoint для задания альтернативного текста объектам, которые планируете изменять в будущем.

После задания альтернативного текста любой нужной формы вы можете открыть эту презентацию с помощью Aspose.Slides для .NET и перебрать все формы, добавленные на слайд. Во время каждой итерации можно проверять альтернативный текст формы, и форма с совпадающим альтернативным текстом будет требуемой. Чтобы продемонстрировать эту технику более наглядно, мы создали метод [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1), который позволяет найти определённую форму на слайде и просто возвращает её.
```c#
public static void Run()
{
    // Создать экземпляр класса Presentation, представляющего файл презентации
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Альтернативный текст ищемой формы
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Реализация метода для поиска формы на слайде по её альтернативному тексту
public static IShape FindShape(ISlide slide, string alttext)
{
    // Перебор всех форм на слайде
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Если альтернативный текст формы соответствует требуемому, то
        // Возвратить форму
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```




## **Клонировать форму**
Для клонирования формы на слайде с использованием Aspose.Slides для .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к коллекции форм исходного слайда.
4. Добавьте новый слайд в презентацию.
5. Клонируйте формы из коллекции форм исходного слайда в новый слайд.
6. Сохраните изменённую презентацию в файл PPTX.

Пример ниже добавляет групповую форму на слайд.
```c#
// Создать экземпляр класса Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Записать PPTX файл на диск
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```




## **Удалить форму**
Aspose.Slides для .NET позволяет разработчикам удалять любую форму. Чтобы удалить форму с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
2. Получите доступ к первому слайду.
3. Найдите форму с конкретным AlternativeText.
4. Удалите форму.
5. Сохраните файл на диск.
```c#
// Создать объект Presentation
Presentation pres = new Presentation();

// Получить первый слайд
ISlide sld = pres.Slides[0];

// Добавить автофигуру типа прямоугольник
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Сохранить презентацию на диск
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```




## **Скрыть форму**
Aspose.Slides для .NET позволяет разработчикам скрывать любую форму. Чтобы скрыть форму на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
2. Получите доступ к первому слайду.
3. Найдите форму с конкретным AlternativeText.
4. Скройте форму.
5. Сохраните файл на диск.
```c#
// Создать экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();

// Получить первый слайд
ISlide sld = pres.Slides[0];

// Добавить автофигуру типа прямоугольник
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Сохранить презентацию на диск
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```




## **Изменить порядок форм**
Aspose.Slides для .NET позволяет разработчикам переупорядочивать формы. Переупорядочивание определяет, какая форма находится спереди, а какая — сзади. Чтобы переупорядочить формы на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
2. Получите доступ к первому слайду.
3. Добавьте форму.
4. Добавьте немного текста в текстовый фрейм формы.
5. Добавьте другую форму с теми же координатами.
6. Переупорядочьте формы.
7. Сохраните файл на диск.
```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```



## **Получить Interop Shape ID**
Aspose.Slides для .NET позволяет разработчикам получить уникальный идентификатор формы в пределах слайда, в отличие от свойства UniqueId, которое даёт уникальный идентификатор в пределах презентации. Свойство OfficeInteropShapeId было добавлено к интерфейсам IShape и классу Shape соответственно. Значение, возвращаемое свойством OfficeInteropShapeId, соответствует значению Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведён пример кода.
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Получение уникального идентификатора формы в области слайда
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```




## **Установить альтернативный текст для формы**
Aspose.Slides для .NET позволяет разработчикам задавать AlternateText любой формы.  
Формы в презентации могут различаться по свойству AlternativeText или имени формы (Shape Name).  
Свойство AlternativeText можно читать и задавать с помощью Aspose.Slides, а также Microsoft PowerPoint.  
Используя это свойство, вы можете пометить форму и выполнять различные операции, такие как удаление формы, скрытие формы или переупорядочивание форм на слайде.  
Чтобы задать AlternateText формы, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Выполните некоторые действия с только что добавленной формой.
5. Пройдитесь по формам, чтобы найти форму.
6. Задайте AlternativeText.
7. Сохраните файл на диск.
```c#
// Создать экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();

// Получить первый слайд
ISlide sld = pres.Slides[0];

// Добавить автофигуру типа прямоугольник
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
        ashp.AlternativeText = "User Defined";
    }
}

// Сохранить презентацию на диск
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```





## **Получить доступ к форматам расположения формы**
Aspose.Slides для .NET предоставляет простой API для доступа к форматам расположения формы. В этой статье показано, как получить доступ к форматам расположения.  
Ниже приведён пример кода.
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


## **Отобразить форму как SVG**
Теперь Aspose.Slides для .NET поддерживает отрисовку формы как svg. Метод WriteAsSvg (и его перегрузка) был добавлен в класс Shape и интерфейс IShape. Этот метод позволяет сохранять содержимое формы в файл SVG. Ниже показан фрагмент кода, демонстрирующий, как экспортировать форму слайда в файл SVG.
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


## **Выровнять форму**

С помощью перегруженного метода [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) вы можете

* выравнивать формы относительно полей слайда. См. пример 1. 
* выравнивать формы относительно друг друга. См. пример 2. 

Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) определяет доступные варианты выравнивания.

**Пример 1**

Этот код C# показывает, как выровнять формы с индексами 1,2 и 4 по верхнему краю слайда:  
Исходный код ниже выравнивает формы с индексами 1,2 и 4 по верхнему краю слайда. 
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


**Пример 2**

Этот код C# показывает, как выровнять всю коллекцию форм относительно нижней формы в коллекции: 
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **Свойства отражения**

В Aspose.Slides класс [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) предоставляет управление горизонтальным и вертикальным отражением форм через свойства `FlipH` и `FlipV`. Оба свойства имеют тип [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), позволяя значения `True` для включения отражения, `False` для отсутствия отражения или `NotDefined` для использования поведения по умолчанию. Эти значения доступны через [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) формы.

Чтобы изменить параметры отражения, создаётся новый экземпляр [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) с текущими позицией и размером формы, желаемыми значениями `FlipH` и `FlipV` и углом поворота. Присвоив этот экземпляр свойству [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) формы и сохранив презентацию, вы применяете зеркальные трансформации и фиксируете их в выходном файле.

Предположим, у нас есть файл sample.pptx, в котором первый слайд содержит единственную форму с настройками отражения по умолчанию, как показано ниже.

![The shape to be flipped](shape_to_be_flipped.png)

Следующий пример кода получает текущие свойства отражения формы и отражает её горизонтально и вертикально.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Получить горизонтальное свойство отражения формы.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Получить вертикальное свойство отражения формы.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Отразить по горизонтали.
    NullableBool flipV = NullableBool.True; // Отразить по вертикали.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


Результат:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Могу ли я комбинировать формы (объединять/пересекать/вычитать) на слайде, как в настольном редакторе?**

Встроенного API для булевых операций нет. Можно приблизительно выполнить задачу, построив требуемый контур самостоятельно — например, вычислить результирующую геометрию с помощью [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) и создать новую форму с этим контуром, при желании удалив исходные.

**Как я могу контролировать порядок наложения (z-order), чтобы форма всегда оставалась «поверх»?**

Изменяйте порядок вставки/перемещения внутри коллекции [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) слайда. Для предсказуемого результата фиксируйте z-order после всех остальных изменений слайда.

**Могу ли я «запереть» форму, чтобы пользователи не могли её редактировать в PowerPoint?**

Да. Установите [флаги защиты на уровне формы](/slides/ru/net/applying-protection-to-presentation/) (например, блокировку выбора, перемещения, изменения размеров, редактирования текста). При необходимости наложите ограничения на мастер или макет. Учтите, что это защита на уровне UI, а не механизм безопасности; для более сильной защиты сочетайте её с ограничениями уровня файла, такими как рекомендации только для чтения или пароли [/slides/net/password-protected-presentation/].