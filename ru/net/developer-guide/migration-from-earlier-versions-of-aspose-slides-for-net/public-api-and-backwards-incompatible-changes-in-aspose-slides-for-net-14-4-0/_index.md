---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.4.0
linktitle: Aspose.Slides для .NET 14.4.0
type: docs
weight: 60
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- миграция
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
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать решения для презентаций PowerPoint PPT, PPTX и ODP."
---

## **Публичный API и несовместимые изменения**
### **Добавленные интерфейсы, классы, методы и свойства**
#### **Свойство Aspose.Slides.ILayoutSlide.HasDependingSlides было добавлено**
Свойство Aspose.Slides.ILayoutSlide.HasDependingSlides возвращает true, если существует хотя бы один слайд, зависящий от этого слайда‑макета. Например:

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

или

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Метод Aspose.Slides.ILayoutSlideCollection.RemoveUnused() позволяет удалить неиспользуемые макетные слайды (макетные слайды, у которых HasDependingSlides равно false). Примеры кода:

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
Метод Aspose.Slides.ISlide.Remove() позволяет удалить слайд из презентации с минимальным объёмом кода. Например:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat возвращает IFillFormat для маркера узла SmartArt, если макет предоставляет маркеры. Его можно использовать для задания изображения маркера.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Свойство Aspose.Slides.SmartArt.ISmartArtNode.Level**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.Level возвращает уровень вложенности для узлов SmartArt.

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
#### **Метод Aspose.Slides.SmartArt.ISmartArtNode.Remove() был добавлен**
Метод Aspose.Slides.SmartArt.ISmartArtNode.Remove() позволяет удалить узел из диаграммы.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Интерфейс IGlobalLayoutSlideCollection и класс GlobalLayoutSlideCollection**
Интерфейс IGlobalLayoutSlideCollection и класс GlobalLayoutSlideCollection были добавлены в пространство имён Aspose.Slides.

Класс GlobalLayoutSlideCollection реализует интерфейс IGlobalLayoutSlideCollection.

Интерфейс IGlobalLayoutSlideCollection представляет коллекцию всех макетных слайдов в презентации. Свойство IPresentation.LayoutSlides имеет тип IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection расширяет интерфейс ILayoutSlideCollection методами добавления и клонирования макетных слайдов в контексте объединения отдельных коллекций макетных слайдов мастера:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Можно использовать для добавления копии указанного макетного слайда в презентацию. Этот метод сохраняет исходное форматирование (при клонировании макета между разными презентациями также может быть склонирован мастер макета. Внутренний реестр используется для автоматического отслеживания склонированных мастеров, чтобы предотвратить создание нескольких копий одного и того же мастер‑слайда.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Используется для добавления копии указанного макетного слайда в презентацию. Новый макет будет привязан к определённому мастеру в целевой презентации. Этот вариант аналогичен копированию или вставке с опцией **Use Destination Theme** в Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Используется для добавления нового макетного слайда в презентацию. Поддерживаемые типы макетов: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Имя макета может быть сгенерировано автоматически. Добавленный макет типа SlideLayoutType.Custom не содержит заполнителей и фигур. Аналогом этого метода является метод IMasterLayoutSlideCollection.Add(SlideLayoutType, string), доступный через свойство IMasterSlide.LayoutSlides.
#### **Интерфейс IMasterLayoutSlideCollection и класс MasterLayoutSlideCollection**
Интерфейс IMasterLayoutSlideCollection и класс MasterLayoutSlideCollection были добавлены в пространство имён Aspose.Slides. Класс MasterLayoutSlideCollection реализует интерфейс IMasterLayoutSlideCollection.

Интерфейс IMasterLayoutSlideCollection представляет коллекцию всех макетных слайдов определённого мастер‑слайда. Он расширяет интерфейс ILayoutSlideCollection методами добавления, вставки, удаления или клонирования макетных слайдов в контексте отдельных коллекций макетных слайдов мастера:

``` csharp

 // Сигнатура метода:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Пример кода, который присоединяет копию sourceLayout к destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Метод можно использовать для добавления копии указанного макетного слайда в конец коллекции. Новый макет будет привязан к родительскому мастер‑слайду этой коллекции макетных слайдов. Это аналог копирования или вставки с опцией **Use Destination Theme** в PowerPoint. Аналогом этого метода является метод IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide), доступный через свойство IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Используется для вставки копии указанного макетного слайда в указанную позицию коллекции. Новый макет будет привязан к родительскому мастер‑слайду этой коллекции. Это аналог копирования и вставки с опцией **Use Destination Theme** в PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Используется для добавления или вставки нового макетного слайда. Поддерживаемые типы макетов: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Имя макета может быть сгенерировано автоматически. Добавленный макет типа SlideLayoutType.Custom не содержит заполнителей и фигур. Аналогом этого метода является метод IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string), доступный через свойство IPresentation.LayoutSlides.
- void RemoveAt(int index); – Используется для удаления макета по указанному индексу в коллекции.
- void Reorder(int index, ILayoutSlide layoutSlide); – Используется для перемещения макетного слайда в коллекции в указанную позицию.
### **Изменённые методы и свойства**
#### **Подпись метода Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
Подпись метода ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

устарела и заменена подписью

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Параметр allowCloneMissingLayout указывает, что делать, если в destMaster отсутствует подходящий макет для нового (клонированного) слайда. Подходящий макет — это макет того же типа или с тем же именем, что и у исходного слайда. Если в указанном мастере нет подходящего макета, то макет исходного слайда будет клонирован (если allowCloneMissingLayout true) или будет выброшено исключение PptxEditException (если false).

Вызов устаревшего метода, например

AddClone(sourceSlide, destMaster);

предполагает, что allowCloneMissingLayout равен false (т.е. будет выброшено PptxEditException, если нет подходящего макета). Функционально идентичный вызов с новой подписью выглядит так:
AddClone(sourceSlide, destMaster, false);

Если вы хотите, чтобы отсутствующие макеты автоматически клонировались вместо выброса PptxEditException, передайте параметр allowCloneMissingLayout со значением true.

То же относится к методу ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

который также устарел и заменён подписью

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Тип свойства Aspose.Slides.IMasterSlide.LayoutSlides**
Тип свойства Aspose.Slides.IMasterSlide.LayoutSlides изменён с ILayoutSlideCollection на новый интерфейс IMasterLayoutSlideCollection. Интерфейс IMasterLayoutSlideCollection наследуется от ILayoutSlideCollection, поэтому существующий код адаптации не требует.
#### **Тип свойства Aspose.Slides.IPresentation.LayoutSlides изменён**
Тип свойства Aspose.Slides.IPresentation.LayoutSlides изменён с ILayoutSlideCollection на новый интерфейс IGlobalLayoutSlideCollection. Интерфейс IGlobalLayoutSlideCollection наследуется от ILayoutSlideCollection, поэтому существующий код адаптации не требует.