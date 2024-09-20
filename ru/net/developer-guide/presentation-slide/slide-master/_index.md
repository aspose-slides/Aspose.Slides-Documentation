---
title: Слайд Мастер
type: docs
weight: 80
url: /net/slide-master/
keywords: "Добавить Слайд Мастер, мастер-слайд PPT, слайд мастер PowerPoint, Изображение в Слайд Мастер, Заполнитель, Множество Слайд Мастеров, Сравнить Слайд Мастера, C#, Csharp, .NET, Aspose.Slides"
description: "Добавить или редактировать слайд мастер в представлении PowerPoint на C# или .NET"
---


## **Что такое Слайд Мастер в PowerPoint**
**Слайд Мастер** — это шаблон слайда, который определяет макет, стили, темы, шрифты, фон и другие свойства для слайдов в презентации. Если вы хотите создать презентацию (или ряд презентаций) с одним и тем же стилем и шаблоном для вашей компании, вы можете использовать слайд мастер.

Слайд Мастер полезен, потому что позволяет вам установить и изменить внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм Слайд Мастера из PowerPoint.

VBA также позволяет вам управлять Слайд Мастером и выполнять те же операции, которые поддерживаются в PowerPoint: изменить фоны, добавить формы, настроить макет и т. д. Aspose.Slides предоставляет гибкие механизмы, позволяющие вам использовать Слайды Мастера и выполнять с ними основные задачи.

Это основные операции с Слайд Мастером:

- Создать или Слайд Мастер.
- Применить Слайд Мастер к слайдам презентации.
- Изменить фон Слайда Мастера.
- Добавить изображение, заполнитель, Умное оформление и т. д. в Слайд Мастер.

Это более продвинутые операции с Слайд Мастером:

- Сравнить Слайд Мастера.
- Объединить Слайд Мастера.
- Применить несколько Слайд Мастеров.
- Копировать слайд с Слайд Мастером в другую презентацию.
- Найти дублирующиеся Слайд Мастера в презентациях.
- Установить Слайд Мастер в качестве стандартного представления презентации.

{{% alert color="primary" %}} 

Вам может быть интересно ознакомиться с Aspose [**Онлайн Просмотрщиком PowerPoint**](https://products.aspose.app/slides/viewer), так как это онлайн реализация некоторых из основных процессов, описанных здесь.

{{% /alert %}} 


## **Как применяется Слайд Мастер**
Прежде чем работать с Слайд Мастером, вам может быть интересно понять, как их используют в презентациях и применяют к слайдам.

* Каждая презентация по умолчанию имеет по крайней мере один Слайд Мастер.
* Презентация может содержать несколько Слайд Мастеров. Вы можете добавить несколько Слайд Мастеров и использовать их для оформления различных частей презентации разными способами.

В **Aspose.Slides** Слайд Мастер представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide).

Объект [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation) Aspose.Slides содержит список [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), который содержит список всех мастер-слайдов, определенных в презентации.

Кроме операций CRUD, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) содержит полезные методы: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) и [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Эти методы унаследованы от основной функции клонирования слайдов. Но при работе с Слайд Мастерами эти методы позволяют вам реализовать сложные настройки.

Когда новый слайд добавляется в презентацию, к нему автоматически применяется Слайд Мастер. Слайд Мастер предыдущего слайда выбирается по умолчанию.

**Примечание**: Слайды презентации хранятся в списке [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), и каждый новый слайд по умолчанию добавляется в конец коллекции. Если в презентации есть только один Слайд Мастер, этот слайд мастер выбирается для всех новых слайдов. Это причина, по которой вам не нужно определять Слайд Мастер для каждого нового создаваемого вами слайда.

Принцип тот же, что в PowerPoint, так и в Aspose.Slides. Например, в PowerPoint, когда вы добавляете новую презентацию, вы можете просто нажать на нижнюю линию под последним слайдом, и тогда будет создан новый слайд (с Слайд Мастером последней презентации):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить эквивалентную задачу с помощью метода [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).


## **Слайд Мастер в иерархии Слайдов**
Использование Макетов Слайдов с Слайд Мастером обеспечивает максимальную гибкость. Макет Слайда позволяет вам установить все те же стили, что и Слайд Мастер (фон, шрифты, фигуры и т. д.). Однако, когда несколько Макетов Слайдов объединены на Слайд Мастере, создается новый стиль. Когда вы применяете Макет Слайда к отдельному слайду, вы можете изменить его стиль, отличающийся от примененного Слайд Мастером.

Слайд Мастер превосходит все элементы настройки: Слайд Мастер -> Макет Слайда -> Слайд:

![todo:image_alt_text](slide-master_2)


Каждый [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) объект имеет свойство [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) со списком Макетов Слайдов. Тип [Слайд](https://reference.aspose.com/slides/net/aspose.slides/slide) имеет свойство [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) с ссылкой на Макет Слайда, примененный к слайду. Взаимодействие между слайдом и Слайд Мастером происходит через Макет Слайда.

{{% alert color="info" title="Примечание" %}}

* 
   В Aspose.Slides все настройки слайдов (Слайд Мастер, Макет Слайда и сам слайд) на самом деле являются объектами слайдов, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide).
* Следовательно, Слайд Мастер и Макет Слайда могут реализовать одни и те же свойства, и вам нужно знать, как их значения будут применены к объекту [Слайд](https://reference.aspose.com/slides/net/aspose.slides/slide/). Слайд Мастер применяется первым к слайду, а затем применяется Макет Слайда. Например, если у Слайд Мастера и Макета Слайда есть значение фона, Слайд в конечном итоге получит фон от Макета Слайда.

{{% /alert %}}


## **Что включает в себя Слайд Мастер**
Чтобы понять, как может быть изменен Слайд Мастер, вам нужно знать его составляющие. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/).

- [Фон](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - получить/установить фон слайда.
- [СтильТела](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - получить/установить текстовые стили тела слайда.
- [Формы](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - получить/установить все формы Слайда Мастера (заполнители, рамки для изображений и т. д.).
- [Элементы управления](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - получить/установить элементы управления ActiveX.
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - получить менеджер тем.
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - получить менеджер заголовков и нижних колонтитулов.

Методы Слайда Мастера:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - получить все Слайды, зависимые от Слайда Мастера.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - позволяет создать новый Слайд Мастер на основе текущего Слайда Мастера и новой темы. Новый Слайд Мастер будет применен ко всем зависимым слайдам.


## **Получить Слайд Мастер**
В PowerPoint Слайд Мастер можно получить через меню Вид -> Слайд Мастер:

![todo:image_alt_text](slide-master_3.jpg)


Используя Aspose.Slides, вы можете получить доступ к Слайду Мастеру следующим образом:

```c#
IMasterSlide master = pres.Masters[0];
```

Интерфейс [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) представляет собой Слайд Мастер. Свойство [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (связанное с типом [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) содержит список всех Слайдов Мастеров, определенных в презентации.


## **Добавить изображение в Слайд Мастер**
Когда вы добавляете изображение в Слайд Мастер, это изображение будет отображаться на всех слайдах, зависимых от этого Слайда Мастера.

Например, вы можете разместить логотип вашей компании и несколько изображений на Слайд Мастере, а затем вернуться в режим редактирования слайдов. Вы должны увидеть изображение на каждом слайде.

![todo:image_alt_text](slide-master_4.png)

Вы можете добавлять изображения в Слайд Мастер с помощью Aspose.Slides:

```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="Смотрите также" %}} 

Для получения дополнительной информации о добавлении изображений на слайд смотрите статью [Рамка для изображения](/slides/net/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Добавить Заполнитель в Слайд Мастер**
Эти текстовые поля являются стандартными заполнителями на Слайд Мастере:

* Нажмите, чтобы редактировать стиль заголовка Мастера

* Редактировать текстовые стили Мастера

* Второй уровень

* Третий уровень

Они также появляются на слайдах, основанных на Слайд Мастере. Вы можете редактировать эти заполнители на Слайд Мастере, и изменения автоматически применяются к слайдам.

В PowerPoint вы можете добавить заполнитель через путь Слайд Мастер -> Вставить Заполнитель:

![todo:image_alt_text](slide-master_5.png)


Давайте рассмотрим более сложный пример с заполнителями с использованием Aspose.Slides. Рассмотрим слайд с заполнителями, полученными из Слайда Мастера:

![todo:image_alt_text](slide-master_6.png)


Мы хотим изменить форматирование Заголовка и Подзаголовка на Слайд Мастере следующим образом:

![todo:image_alt_text](slide-master_7.png)


Сначала мы получаем содержимое заполнителя заголовка из объекта Слайда Мастера и затем используем поле `PlaceHolder.FillFormat`:

```c#
public static void Main()
{
    using (var pres = new Presentation())
    {
        IMasterSlide master = pres.Masters[0];
        IAutoShape placeHolder = FindPlaceholder(master, PlaceholderType.Title);
        placeHolder.FillFormat.FillType = FillType.Gradient;
        placeHolder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(0, Color.FromArgb(255, 0, 0));
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(255, Color.FromArgb(128, 0, 128));
        
        pres.Save("pres.pptx", SaveFormat.Pptx);
    }
}

static IAutoShape FindPlaceholder(IMasterSlide master, PlaceholderType type)
{
    foreach (IShape shape in master.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            if (autoShape.Placeholder.Type == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```

Стиль и форматирование заголовка изменятся для всех слайдов, основанных на слайд мастере:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Смотрите также" %}} 

* [Установить текст подсказки в Заполнителе](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Форматирование текста](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Изменить фон на Слайд Мастере**
Когда вы изменяете цвет фона мастер-слайда, все обычные слайды в презентации получат новый цвет. Этот код C# демонстрирует операцию:

```c#
using (var pres = new Presentation())
{
    IMasterSlide master = pres.Masters[0];
    master.Background.Type = BackgroundType.OwnBackground;
    master.Background.FillFormat.FillType = FillType.Solid;
    master.Background.FillFormat.SolidFillColor.Color = Color.Green;
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="Смотрите также" %}} 
- [Фон презентации](https://docs.aspose.com/slides/net/presentation-background/)

- [Тема презентации](https://docs.aspose.com/slides/net/presentation-theme/)

{{% /alert %}}

## **Клонировать Слайд Мастер в другую презентацию**
Чтобы клонировать Слайд Мастер в другую презентацию, вызовите метод [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) из целевой презентации с использованием Слайда Мастера, переданного в него. Этот код C# показывает, как клонировать Слайд Мастер в другую презентацию:

```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **Добавить несколько Слайд Мастеров в Презентацию**
Aspose.Slides позволяет добавлять несколько Слайд Мастеров и Макетов Слайдов в любую данную презентацию. Это позволяет настраивать стили, макеты и параметры форматирования для слайдов презентаций множеством способов.

В PowerPoint вы можете добавить новые Слайд Мастера и Макеты (из меню "Слайд Мастер") следующим образом:

![todo:image_alt_text](slide-master_9.jpg)

Используя Aspose.Slides, вы можете добавить новый Слайд Мастер, вызвав метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/):

```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **Сравнить Слайд Мастера**
Мастер-Слайд реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide), который содержит метод [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals), который можно использовать для сравнения слайдов. Он возвращает `true` для Мастер-Слайдов, идентичных по структуре и статическому содержимому.

Два Мастера Слайда равны, если их фигуры, стили, тексты, анимация и другие настройки и т. д. равны. Сравнение не учитывает уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущее значение даты в Заполнителе Даты).


## **Установить Слайд Мастер в качестве стандартного вида презентации**
Aspose.Slides позволяет установить Слайд Мастер в качестве стандартного вида для презентации. Стандартный вид — это то, что вы видите в первую очередь, когда открываете презентацию.

Этот код показывает, как установить Слайд Мастер в качестве стандартного вида презентации на C#:

```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```

## **Удалить неиспользуемый мастер-слайд**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (из класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)), чтобы позволить вам удалить ненужные и неиспользуемые мастер-слайды. Этот код C# показывает, как удалить мастер-слайд из презентации PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```