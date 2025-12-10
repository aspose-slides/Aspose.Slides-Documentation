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
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения презентаций PowerPoint PPT, PPTX и ODP."
---

## **Публичный API и несовместимые изменения**
### **Добавленные интерфейсы, классы, методы и свойства**
#### **Свойство Aspose.Slides.ILayoutSlide.HasDependingSlides добавлено**
Свойство Aspose.Slides.ILayoutSlide.HasDependingSlides возвращает true, если существует хотя бы один слайд, зависящий от этого шаблона слайда. Например:

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
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Метод Aspose.Slides.ILayoutSlideCollection.RemoveUnused() позволяет удалить неиспользуемые шаблоны слайдов (шаблоны, у которых HasDependingSlides равно false). Примеры кода:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

или

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Свойство Aspose.Slides.IMasterSlide.HasDependingSlides**
Свойство Aspose.Slides.IMasterSlide.HasDependingSlides возвращает true, если существует хотя бы один слайд, зависящий от этого главного слайда. Например:

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
Свойство Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat возвращает IFillFormat для маркера узла SmartArt, если в макете предусмотрены маркеры. Его можно использовать для установки изображения маркера.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Свойство Aspose.Slides.SmartArt.ISmartArtNode.Level**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.Level возвращает уровень вложенности узлов SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Свойство Aspose.Slides.SmartArt.ISmartArtNode.Position**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.Position возвращает позицию узла среди его соседних узлов.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Метод Aspose.Slides.SmartArt.ISmartArtNode.Remove() добавлен**
Метод Aspose.Slides.SmartArt.ISmartArtNode.Remove() позволяет удалить узел из диаграммы.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Интерфейс IGlobalLayoutSlideCollection и класс GlobalLayoutSlideCollection**
Интерфейс IGlobalLayoutSlideCollection и класс GlobalLayoutSlideCollection были добавлены в пространство имён Aspose.Slides.

Класс GlobalLayoutSlideCollection реализует интерфейс IGlobalLayoutSlideCollection.

Интерфейс IGlobalLayoutSlideCollection представляет коллекцию всех шаблонов слайдов в презентации. Свойство IPresentation.LayoutSlides имеет тип IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection расширяет интерфейс ILayoutSlideCollection методами для добавления и клонирования шаблонов слайдов в контексте объединения отдельных коллекций шаблонов мастера:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Может использоваться для добавления копии указанного шаблона слайда в презентацию. Этот метод сохраняет форматирование исходного шаблона (при клонировании шаблона между разными презентациями может быть клонирован также мастер шаблона. Внутренний реестр используется для отслеживания автоматически клонированных мастеров, чтобы предотвратить создание нескольких копий одного и того же мастер‑слайда).
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Используется для добавления копии указанного шаблона слайда в презентацию. Новый шаблон будет связан с указанным мастером в целевой презентации. Этот вариант аналогичен копированию/вставке с опцией **Use Destination Theme** в Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Используется для добавления нового шаблона слайда в презентацию. Поддерживаемые типы макетов: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Имя макета может генерироваться автоматически. Добавленный макет типа SlideLayoutType.Custom не содержит заполнителей и фигур. Аналогом этого метода является метод IMasterLayoutSlideCollection.Add(SlideLayoutType, string), доступный через свойство IMasterSlide.LayoutSlides.

#### **Интерфейс IMasterLayoutSlideCollection и класс MasterLayoutSlideCollection**
Интерфейс IMasterLayoutSlideCollection и класс MasterLayoutSlideCollection были добавлены в пространство имён Aspose.Slides. Класс MasterLayoutSlideCollection реализует интерфейс IMasterLayoutSlideCollection.

Интерфейс IMasterLayoutSlideCollection представляет коллекцию всех шаблонов слайдов определённого мастер‑слайда. Он расширяет интерфейс ILayoutSlideCollection методами для добавления, вставки, удаления или клонирования шаблонов слайдов в контексте отдельных коллекций шаблонов мастера:

``` csharp

 // Method signature:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Code example that attaches copy of the sourceLayout to the destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Метод может использоваться для добавления копии указанного шаблона слайда в конец коллекции. Новый шаблон будет связан с родительским мастер‑слайдом этой коллекции шаблонов. Таким образом, это аналог копирования/вставки с опцией **Use Destination Theme** в PowerPoint. Аналогом данного метода является метод IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide), доступный через свойство IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Используется для вставки копии указанного шаблона слайда в указанную позицию коллекции. Новый шаблон будет связан с родительским мастер‑слайдом этой коллекции шаблонов. Это аналог копирования и вставки с опцией **Use Destination Theme** в PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Используется для добавления или вставки нового шаблона слайда. Поддерживаемые типы макетов: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Имя макета может генерироваться автоматически. Добавленный макет типа SlideLayoutType.Custom не содержит заполнителей и фигур. Аналогом этого метода является метод IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string), доступный через свойство IPresentation.LayoutSlides.
- void RemoveAt(int index); – Используется для удаления шаблона по указанному индексу в коллекции.
- void Reorder(int index, ILayoutSlide layoutSlide); – Используется для перемещения шаблона слайда в коллекции на указанную позицию.

### **Изменённые методы и свойства**
#### **Сигнатура метода Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
Сигнатура метода ISlideCollection:
```csharp
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
```
устарела и заменена сигнатурой
```csharp
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)
```
Параметр `allowCloneMissingLayout` указывает, что делать, если в `destMaster` нет подходящего шаблона для нового (клонированного) слайда. Подходящий шаблон – это шаблон того же типа или с тем же именем, что и у исходного слайда. Если в указанном мастере нет подходящего шаблона, то шаблон исходного слайда будет клонирован (если `allowCloneMissingLayout` true) или будет выброшено исключение `PptxEditException` (если `allowCloneMissingLayout` false).

Вызов устаревшего метода:
```csharp
AddClone(sourceSlide, destMaster);
```
эквивалентен вызову с `allowCloneMissingLayout` = false (т.е. будет выброшено `PptxEditException`, если подходящего шаблона нет). Эквивалентный вызов с новой сигнатурой:
```csharp
AddClone(sourceSlide, destMaster, false);
```
Если хотите, чтобы отсутствующие шаблоны автоматически клонировались вместо выбрасывания `PptxEditException`, передайте `true`.

То же относится к методу ISlideCollection:
```csharp
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);
```
который также устарел и заменён сигнатурой
```csharp
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
```

#### **Тип свойства Aspose.Slides.IMasterSlide.LayoutSlides**
Тип свойства Aspose.Slides.IMasterSlide.LayoutSlides изменён с ILayoutSlideCollection на новый интерфейс IMasterLayoutSlideCollection. Интерфейс IMasterLayoutSlideCollection является наследником ILayoutSlideCollection, поэтому существующий код не требует адаптации.

#### **Тип свойства Aspose.Slides.IPresentation.LayoutSlides изменён**
Тип свойства Aspose.Slides.IPresentation.LayoutSlides изменён с ILayoutSlideCollection на новый интерфейс IGlobalLayoutSlideCollection. Интерфейс IGlobalLayoutSlideCollection является наследником ILayoutSlideCollection, поэтому существующий код не требует адаптации.