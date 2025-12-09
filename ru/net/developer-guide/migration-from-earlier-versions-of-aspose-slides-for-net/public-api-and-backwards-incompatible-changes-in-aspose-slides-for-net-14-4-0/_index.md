---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.4.0
linktitle: Aspose.Slides для .NET 14.4.0
type: docs
weight: 60
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- миграция
- наследуемый код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и нарушающих совместимость изменений в Aspose.Slides for .NET для плавной миграции ваших решений презентаций PowerPoint PPT, PPTX и ODP."
---

## **Публичный API и несовместимые изменения**
### **Добавленные интерфейсы, классы, методы и свойства**
#### **Свойство Aspose.Slides.ILayoutSlide.HasDependingSlides было добавлено**
Свойство Aspose.Slides.ILayoutSlide.HasDependingSlides возвращает true, если существует хотя бы один слайд, зависящий от этого шаблонного слайда. Например:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Метод Aspose.Slides.ILayoutSlide.Remove()**
Метод Aspose.Slides.ILayoutSlide.Remove() позволяет удалить макет из презентации с минимальным объёмом кода. Например:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Метод Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Метод Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) позволяет удалить макет из коллекции. Примеры кода:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

or

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Метод Aspose.Slides.ILayoutSlideCollection.RemoveUnused() позволяет удалить неиспользуемые макеты слайдов (макеты слайдов, у которых HasDependingSlides равно false). Примеры кода:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

or

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
Метод Aspose.Slides.ISlide.Remove() позволяет удалить слайд из презентации с минимальным объёмом кода. Например:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat возвращает IFillFormat для маркера узла SmartArt, если макет предоставляет маркеры. Его можно использовать для установки изображения маркера.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level property**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.Level возвращает вложенный уровень для узлов SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position property**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.Position возвращает позицию узла среди его соседних узлов.

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

Интерфейс IGlobalLayoutSlideCollection представляет собой коллекцию всех макетных слайдов в презентации. Свойство IPresentation.LayoutSlides имеет тип IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection расширяет интерфейс ILayoutSlideCollection методами для добавления и клонирования макетных слайдов в контексте объединения отдельных коллекций макетных слайдов мастера:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Можно использовать для добавления копии указанного макетного слайда в презентацию. Этот метод сохраняет исходное форматирование (при клонировании макета между разными презентациями также может быть клонирован мастер макета. Внутренний реестр используется для отслеживания автоматически клонированных мастеров, чтобы предотвратить создание нескольких копий одного и того же мастер‑слайда.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Используется для добавления копии указанного макетного слайда в презентацию. Новый макет будет связан с определённым мастером в целевой презентации. Эта опция аналогична копированию или вставке с опцией **Use Destination Theme** в Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Используется для добавления нового макетного слайда в презентацию. Поддерживаемые типы макетов: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Имя макета может генерироваться автоматически. Добавленный макет типа SlideLayoutType.Custom не содержит заполнителей и фигур. Аналогом этого метода является метод IMasterLayoutSlideCollection.Add(SlideLayoutType, string), доступный через свойство IMasterSlide.LayoutSlides.

#### **Интерфейс IMasterLayoutSlideCollection и класс MasterLayoutSlideCollection**
Интерфейс IMasterLayoutSlideCollection и класс MasterLayoutSlideCollection были добавлены в пространство имен Aspose.Slides. Класс MasterLayoutSlideCollection реализует интерфейс IMasterLayoutSlideCollection.

Интерфейс IMasterLayoutSlideCollection представляет собой коллекцию всех макетных слайдов определённого мастер‑слайда. Он расширяет интерфейс ILayoutSlideCollection методами для добавления, вставки, удаления или клонирования макетных слайдов в контексте отдельных коллекций макетных слайдов мастера:

``` csharp

 // Method signature:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Code example that attaches copy of the sourceLayout to the destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Метод можно использовать для добавления копии указанного макетного слайда в конец коллекции. Новый макет будет связан с родительским мастер‑слайдом этой коллекции макетных слайдов. Таким образом, это аналог копирования или вставки с опцией **Use Destination Theme** в PowerPoint. Аналогом этого метода является метод IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide), доступный через свойство IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Используется для вставки копии указанного макетного слайда в указанную позицию коллекции. Новый макет будет связан с родительским мастер‑слайдом этой коллекции макетных слайдов. Таким образом, это аналог копирования и вставки с опцией **Use Destination Theme** в PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Используется для добавления или вставки нового макетного слайда. Поддерживаемые типы макетов: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Имя макета может генерироваться автоматически. Добавленный макет типа SlideLayoutType.Custom не содержит заполнителей и фигур. Аналогом этого метода является метод IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string), доступный через свойство IPresentation.LayoutSlides.
- void RemoveAt(int index); – Используется для удаления макета по указанному индексу в коллекции.
- void Reorder(int index, ILayoutSlide layoutSlide); – Используется для перемещения макетного слайда в коллекции в указанную позицию.
### **Изменённые методы и свойства**
#### **Сигнатура метода Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
Сигнатура метода ISlideCollection:
```csharp
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
```
сейчас считается устаревшей и заменена на сигнатуру
```csharp
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)
```
Параметр `allowCloneMissingLayout` определяет действие, если в `destMaster` отсутствует подходящий макет для нового (клонированного) слайда. Подходящий макет — это макет того же типа или с тем же именем, что и у исходного слайда. Если в указанном мастере нет подходящего макета, то макет исходного слайда будет клонирован (если `allowCloneMissingLayout` равно true) или будет выброшено исключение `PptxEditException` (если `allowCloneMissingLayout` равно false).

Вызов устаревшего метода, например
```csharp
AddClone(sourceSlide, destMaster);
```
эквивалентен вызову с параметром `allowCloneMissingLayout`, равным false (то есть будет выброшено `PptxEditException`, если подходящего макета нет). Функционально эквивалентный вызов с новой сигнатурой выглядит так:
```csharp
AddClone(sourceSlide, destMaster, false);
```
Если вы хотите, чтобы отсутствующие макеты автоматически клонировались вместо выброса `PptxEditException`, передайте параметр `allowCloneMissingLayout` со значением true.

То же относится к методу `ISlideCollection`:
```csharp
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);
```
Он также считается устаревшим и заменён на сигнатуру
```csharp
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
```
#### **Тип свойства Aspose.Slides.IMasterSlide.LayoutSlides**
Тип свойства Aspose.Slides.IMasterSlide.LayoutSlides изменён с ILayoutSlideCollection на новый интерфейс IMasterLayoutSlideCollection. Интерфейс IMasterLayoutSlideCollection является наследником ILayoutSlideCollection, поэтому существующий код не требует адаптации.
#### **Тип свойства Aspose.Slides.IPresentation.LayoutSlides изменён**
Тип свойства Aspose.Slides.IPresentation.LayoutSlides изменён с ILayoutSlideCollection на новый интерфейс IGlobalLayoutSlideCollection. Интерфейс IGlobalLayoutSlideCollection является наследником ILayoutSlideCollection, поэтому существующий код не требует адаптации.