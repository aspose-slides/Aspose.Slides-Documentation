---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides для .NET 14.4.0
type: docs
weight: 60
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
---

## **Публичный API и обратные несовместимые изменения**
### **Добавленные интерфейсы, классы, методы и свойства**
#### **Свойство Aspose.Slides.ILayoutSlide.HasDependingSlides было добавлено**
Свойство Aspose.Slides.ILayoutSlide.HasDependingSlides возвращает true, если существует хотя бы один слайд, который зависит от этого компоновочного слайда. Например:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Метод Aspose.Slides.ILayoutSlide.Remove()**
Метод Aspose.Slides.ILayoutSlide.Remove() позволяет вам удалить компоновку из презентации с минимальным объемом кода. Например:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Метод Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Метод Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) позволяет вам удалить компоновку из коллекции. Примеры кода:

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
Метод Aspose.Slides.ILayoutSlideCollection.RemoveUnused() позволяет вам удалить неиспользуемые компоновочные слайды (компоновочные слайды, у которых HasDependingSlides равно false). Примеры кода:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

или

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Свойство Aspose.Slides.IMasterSlide.HasDependingSlides**
Свойство Aspose.Slides.IMasterSlide.HasDependingSlides возвращает true, если существует хотя бы один слайд, который зависит от этого главного слайда. Например:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Метод Aspose.Slides.ISlide.Remove()**
Метод Aspose.Slides.ISlide.Remove() позволяет вам удалить слайд из презентации с минимальным объемом кода. Например:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat возвращает IFillFormat для пули, если компоновка предоставляет пули. Его можно использовать для установки изображения пули.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Свойство Aspose.Slides.SmartArt.ISmartArtNode.Level**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.Level возвращает вложенный уровень для узлов SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "Первый уровень";

``` 
#### **Свойство Aspose.Slides.SmartArt.ISmartArtNode.Position**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.Position возвращает позицию узла среди его братьев и сестер.

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

Интерфейс IGlobalLayoutSlideCollection представляет собой коллекцию всех компоновочных слайдов в презентации. Свойство IPresentation.LayoutSlides имеет тип IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection расширяет интерфейс ILayoutSlideCollection методами для добавления и клонирования компоновочных слайдов в контексте объединения отдельных коллекций компоновочных слайдов мастера:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Может использоваться для добавления копии указанного компоновочного слайда в презентацию. Этот метод сохраняет исходное форматирование (при клонировании компоновки между разными презентациями может быть также клонирован мастер компоновки. Внутренний реестр используется для автоматического отслеживания клонированных мастеров, чтобы предотвратить создание нескольких клонов одного и того же главного слайда.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Используется для добавления копии указанного компоновочного слайда в презентацию. Новая компоновка будет связана с определенным мастером в целевой презентации. Этот вариант аналогичен копированию или вставке с параметром **Использовать тему назначения** в Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Используется для добавления нового компоновочного слайда в презентацию. Поддерживаемые типы компоновки: Заголовок, ТолькоЗаголовок, Пустой, ЗаголовокИОбъект, ВертикальныйТекст, ВертикальныйЗаголовокИТекст, ДваОбъекта, ЗаголовокРаздела, ДваТекстаИДваОбъекта, ЗаголовокОбъектаИПодпись, КартинкаИПодпись, Пользовательский. Имя компоновки может быть сгенерировано автоматически. Добавленная компоновка типа SlideLayoutType.Custom не содержит ни заполнителей, ни фигур. Аналогом этого метода является метод IMasterLayoutSlideCollection.Add(SlideLayoutType, string), доступный через свойство IMasterSlide.LayoutSlides.
#### **Интерфейс IMasterLayoutSlideCollection и класс MasterLayoutSlideCollection**
Интерфейс IMasterLayoutSlideCollection и класс MasterLayoutSlideCollection были добавлены в пространство имен Aspose.Slides. Класс MasterLayoutSlideCollection реализует интерфейс IMasterLayoutSlideCollection.

Интерфейс IMasterLayoutSlideCollection представляет собой коллекцию всех компоновочных слайдов определенного главного слайда. Он расширяет интерфейс ILayoutSlideCollection методами для добавления, вставки, удаления или клонирования компоновочных слайдов в контексте отдельных коллекций компоновочных слайдов мастера:

``` csharp

 // Подпись метода:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Пример кода, который прикрепляет копию sourceLayout к destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Метод может использоваться для добавления копии указанного компоновочного слайда в конец коллекции. Новая компоновка будет связана с родительским главной компоновкой для этой коллекции компоновочных слайдов. Таким образом, это аналогично копированию или вставке с параметром **Использовать тему назначения** в PowerPoint. Аналогом этого метода является метод IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide), доступный через свойство IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Используется для вставки копии указанного компоновочного слайда в указанную позицию в коллекции. Новая компоновка будет связана с родительским мастером для этой коллекции компоновочных слайдов. Таким образом, это аналогично копированию и вставке с параметром **Использовать тему назначения** в PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Используется для добавления или вставки нового компоновочного слайда. Поддерживаемые типы компоновки: Заголовок, ТолькоЗаголовок, Пустой, ЗаголовокИОбъект, ВертикальныйТекст, ВертикальныйЗаголовокИТекст, ДваОбъекта, ЗаголовокРаздела, ДваТекстаИДваОбъекта, ЗаголовокОбъектаИПодпись, КартинкаИПодпись, Пользовательский. Имя компоновки может быть сгенерировано автоматически. Добавленная компоновка типа SlideLayoutType.Custom не содержит ни заполнителей, ни фигур. Аналогом этого метода является метод IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string), доступный через свойство IPresentation.LayoutSlides.
- void RemoveAt(int index); – Используется для удаления компоновки по указанному индексу в коллекции.
- void Reorder(int index, ILayoutSlide layoutSlide); – Используется для перемещения компоновочного слайда из коллекции на указанную позицию.
### **Измененные методы и свойства**
#### **Подпись метода Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
Подпись метода ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

устарела и заменена на подпись

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Параметр allowCloneMissingLayout указывает, что делать, если в destMaster нет подходящей компоновки для нового (клонированного) слайда. Подходящая компоновка – это компоновка с тем же типом или именем, что и компоновка исходного слайда. Если в указанном мастере нет подходящей компоновки, то компоновка исходного слайда будет клонирована (если allowCloneMissingLayout равно true) или будет выброшено исключение PptxEditException (если allowCloneMissingLayout равно false).

Вызов устаревшего метода как

AddClone(sourceSlide, destMaster);

предполагает, что allowCloneMissingLayout равен false (то есть исключение PptxEditException будет выброшено, если нет подходящей компоновки). Функционально идентичный вызов, использующий новую подпись, выглядит так:
AddClone(sourceSlide, destMaster, false);

Если вы хотите, чтобы отсутствующие компоновки автоматически клонировались вместо генерации исключения PptxEditException, передайте параметр allowCloneMissingLayout как true.

То же относится к методу ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

также устарела и заменена на подпись

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Тип свойства Aspose.Slides.IMasterSlide.LayoutSlides**
Тип свойства Aspose.Slides.IMasterSlide.LayoutSlides был изменен с ILayoutSlideCollection на новый интерфейс IMasterLayoutSlideCollection. Интерфейс IMasterLayoutSlideCollection является потомком ILayoutSlideCollection, поэтому существующий код не требует доработки.
#### **Тип свойства Aspose.Slides.IPresentation.LayoutSlides был изменен**
Тип свойства Aspose.Slides.IPresentation.LayoutSlides был изменен с ILayoutSlideCollection на новый интерфейс IGlobalLayoutSlideCollection. Интерфейс IGlobalLayoutSlideCollection является потомком ILayoutSlideCollection, поэтому существующий код не требует доработки.