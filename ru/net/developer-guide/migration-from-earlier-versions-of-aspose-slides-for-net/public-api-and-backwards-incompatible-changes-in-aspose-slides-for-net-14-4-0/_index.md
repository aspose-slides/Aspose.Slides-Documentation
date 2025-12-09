---
title: Общедоступный API и обратно несовместимые изменения в Aspose.Slides для .NET 14.4.0
linktitle: Aspose.Slides для .NET 14.4.0
type: docs
weight: 60
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- миграция
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
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

## **Публичный API и обратные несовместимые изменения**
### **Добавленные интерфейсы, классы, методы и свойства**
#### **Свойство Aspose.Slides.ILayoutSlide.HasDependingSlides было добавлено**
Свойство Aspose.Slides.ILayoutSlide.HasDependingSlides возвращает true, если существует хотя бы один слайд, зависящий от этого шаблонного слайда. Например:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Метод Aspose.Slides.ILayoutSlide.Remove()**
Метод Aspose.Slides.ILayoutSlide.Remove() позволяет удалить шаблон из презентации с минимальным количеством кода. Например:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Метод Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Метод Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) позволяет удалить шаблон из коллекции. Примеры кода:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

или

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Метод Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Метод Aspose.Slides.ILayoutSlideCollection.RemoveUnused() позволяет удалить неиспользуемые шаблоны слайдов (шаблоны слайдов, у которых HasDependingSlides равно false). Примеры кода:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

или

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Свойство Aspose.Slides.IMasterSlide.HasDependingSlides**
Свойство Aspose.Slides.IMasterSlide.HasDependingSlides возвращает true, если существует хотя бы один слайд, зависящий от этого мастер‑слайда. Например:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Метод Aspose.Slides.ISlide.Remove()**
Метод Aspose.Slides.ISlide.Remove() позволяет удалить слайд из презентации с минимальным количеством кода. Например:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat возвращает IFillFormat для маркера узла SmartArt, если в шаблоне предусмотрены маркеры. Его можно использовать для задания изображения маркера.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Свойство Aspose.Slides.SmartArt.ISmartArtNode.Level**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.Level возвращает вложенный уровень для узлов SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Свойство Aspose.Slides.SmartArt.ISmartArtNode.Position**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.Position возвращает позицию узла среди его соседних элементов.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Метод Aspose.Slides.SmartArt.ISmartArtNode.Remove() был добавлен**
Метод Aspose.Slides.SmartArt.ISmartArtNode.Remove() позволяет удалить узел из диаграммы.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Интерфейс IGlobalLayoutSlideCollection и класс GlobalLayoutSlideCollection**
Интерфейс IGlobalLayoutSlideCollection и класс GlobalLayoutSlideCollection были добавлены в пространство имен Aspose.Slides.

Класс GlobalLayoutSlideCollection реализует интерфейс IGlobalLayoutSlideCollection.

Интерфейс IGlobalLayoutSlideCollection представляет коллекцию всех шаблонных слайдов в презентации. Свойство IPresentation.LayoutSlides имеет тип IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection расширяет интерфейс ILayoutSlideCollection методами для добавления и клонирования шаблонных слайдов в контексте объединения отдельных коллекций шаблонов мастера:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Может использоваться для добавления копии указанного шаблонного слайда в презентацию. Этот метод сохраняет исходное форматирование (при клонировании шаблона между разными презентациями может быть клонирован и мастер шаблона. Внутренний реестр используется для отслеживания автоматически клонированных мастеров, чтобы предотвратить создание нескольких клонов одного и того же мастер‑слайда).
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Используется для добавления копии указанного шаблонного слайда в презентацию. Новый шаблон будет привязан к определённому мастеру в целевой презентации. Эта опция аналогична копированию или вставке с параметром **Use Destination Theme** в Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Используется для добавления нового шаблонного слайда в презентацию. Поддерживаемые типы шаблонов: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Имя шаблона может генерироваться автоматически. Добавленный шаблон типа SlideLayoutType.Custom не содержит заполнителей и фигур. Аналогом этого метода является метод IMasterLayoutSlideCollection.Add(SlideLayoutType, string), доступный через свойство IMasterSlide.LayoutSlides.
#### **Интерфейс IMasterLayoutSlideCollection и класс MasterLayoutSlideCollection**
Интерфейс IMasterLayoutSlideCollection и класс MasterLayoutSlideCollection были добавлены в пространство имен Aspose.Slides. Класс MasterLayoutSlideCollection реализует интерфейс IMasterLayoutSlideCollection.

Интерфейс IMasterLayoutSlideCollection представляет коллекцию всех шаблонных слайдов определённого мастер‑слайда. Он расширяет интерфейс ILayoutSlideCollection методами для добавления, вставки, удаления или клонирования шаблонных слайдов в контексте отдельных коллекций шаблонов мастера:

``` csharp

 // Method signature:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Code example that attaches copy of the sourceLayout to the destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Метод может использоваться для добавления копии указанного шаблонного слайда в конец коллекции. Новый шаблон будет привязан к родительскому мастер‑слайду этой коллекции шаблонных слайдов. Таким образом, это аналог копирования или вставки с параметром **Use Destination Theme** в PowerPoint. Аналогом этого метода является метод IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide), доступный через свойство IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Используется для вставки копии указанного шаблонного слайда в указанную позицию коллекции. Новый шаблон будет привязан к родительскому мастер‑слайду этой коллекции шаблонных слайдов. Это аналог копирования и вставки с параметром **Use Destination Theme** в PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Используется для добавления или вставки нового шаблонного слайда. Поддерживаемые типы шаблонов: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Имя шаблона может генерироваться автоматически. Добавленный шаблон типа SlideLayoutType.Custom не содержит заполнителей и фигур. Аналогом этого метода является метод IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string), доступный через свойство IPresentation.LayoutSlides.
- void RemoveAt(int index); – Используется для удаления шаблона по указанному индексу в коллекции.
- void Reorder(int index, ILayoutSlide layoutSlide); – Используется для перемещения шаблонного слайда в коллекции на указанную позицию.
### **Изменённые методы и свойства**
#### **Сигнатура метода Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
Сигнатура метода ISlideCollection:
``` csharp
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
```
устарела и заменена сигнатурой

``` csharp
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)
```

Параметр allowCloneMissingLayout определяет, что делать, если в destMaster нет подходящего шаблона для нового (клонированного) слайда. Подходящий шаблон — это шаблон того же типа или с тем же именем, что и у исходного слайда. Если в указанном мастере нет подходящего шаблона, то шаблон исходного слайда будет клонирован (если allowCloneMissingLayout равно true) или будет выброшено исключение PptxEditException (если allowCloneMissingLayout равно false).

Вызов устаревшего метода вида

``` csharp
AddClone(sourceSlide, destMaster);
```

эквивалентен вызову с параметром allowCloneMissingLayout, равным false (т.е. будет выброшено PptxEditException, если подходящего шаблона нет). Эквивалентный вызов с новой сигнатурой выглядит так:

``` csharp
AddClone(sourceSlide, destMaster, false);
```

Если вы хотите, чтобы отсутствующие шаблоны автоматически клонировались вместо выбрасывания PptxEditException, передайте параметр allowCloneMissingLayout со значением true.

То же относится к методу ISlideCollection:

``` csharp
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);
```

который также устарел и заменён сигнатурой

``` csharp
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
```
#### **Тип свойства Aspose.Slides.IMasterSlide.LayoutSlides**
Тип свойства Aspose.Slides.IMasterSlide.LayoutSlides изменён с ILayoutSlideCollection на новый интерфейс IMasterLayoutSlideCollection. Интерфейс IMasterLayoutSlideCollection является потомком ILayoutSlideCollection, поэтому существующий код адаптаций не требует.
#### **Тип свойства Aspose.Slides.IPresentation.LayoutSlides изменён**
Тип свойства Aspose.Slides.IPresentation.LayoutSlides изменён с ILayoutSlideCollection на новый интерфейс IGlobalLayoutSlideCollection. Интерфейс IGlobalLayoutSlideCollection является потомком ILayoutSlideCollection, поэтому существующий код адаптаций не требует.