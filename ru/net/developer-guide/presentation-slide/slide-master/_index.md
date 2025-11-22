---
title: Что такое Slide Master в PowerPoint? Определение и руководство по использованию
linktitle: Slide Master
type: docs
weight: 80
url: /ru/net/slide-master/
keywords: "Добавить Slide Master, PPT мастер слайд, slide master PowerPoint, Изображение в Slide Master, Заполнитель, Несколько Slide Masters, Сравнить Slide Masters, C#, Csharp, .NET, Aspose.Slides"
description: "Узнайте, что такое Slide Master в PowerPoint и как он помогает контролировать макеты слайдов, шрифты, цвета и фирменный стиль. Простой пошаговый гид с примерами на C# или .NET."
---

## **Что такое Slide Master в PowerPoint**
**Slide Master** в PowerPoint — это функция, управляющая макетом, шрифтами и стилями на нескольких слайдах. Она помогает поддерживать согласованность и фирменный стиль в презентациях. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, используйте Slide Master. 

Slide Master полезен тем, что позволяет задать и изменить внешний вид всех слайдов презентации сразу. Aspose.Slides поддерживает механизм Slide Master из PowerPoint. 

VBA также позволяет работать со Slide Master и выполнять те же операции, поддерживаемые в PowerPoint: менять фон, добавлять фигуры, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы для использования Slide Master и выполнения базовых задач с ними. 

Это основные операции со Slide Master:

- Создать Slide Master.
- Применить Slide Master к слайдам презентации.
- Изменить фон Slide Master. 
- Добавить изображение, заполнитель, Smart Art и т.п. в Slide Master.

Это более продвинутые операции со Slide Master: 

- Сравнить Slide Master.
- Объединить Slide Master.
- Применить несколько Slide Master.
- Скопировать слайд с Slide Master в другую презентацию.
- Найти дублирующие Slide Master в презентациях.
- Установить Slide Master как представление по умолчанию для презентации.

{{% alert color="primary" %}} 
Возможно, вам будет полезен Aspose [**Онлайн‑просмотрщик PowerPoint**](https://products.aspose.app/slides/viewer), так как он демонстрирует живую реализацию некоторых основных процессов, описанных здесь.
{{% /alert %}} 

## **Как применяется Slide Master**
Прежде чем работать со Slide Master, стоит понять, как они используются в презентациях и применяются к слайдам. 

* Каждая презентация имеет как минимум один Slide Master по умолчанию. 
* Презентация может содержать несколько Slide Master. Вы можете добавить несколько Slide Master и использовать их для стилизации разных частей презентации по‑разному. 

В **Aspose.Slides** Slide Master представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide). 

Объект [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) Aspose.Slides содержит список [**Masters** ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), в котором хранится перечень всех мастер‑слайдов, определённых в презентации. 

Помимо CRUD‑операций, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) предоставляет полезные методы: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) и [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Эти методы унаследованы от базовой функции клонирования слайдов. При работе с Slide Master они позволяют реализовывать сложные сценарии. 

Когда в презентацию добавляется новый слайд, к нему автоматически применяется Slide Master. По умолчанию выбирается Slide Master предыдущего слайда. 

**Примечание**: Слайды презентации хранятся в списке [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), и каждый новый слайд добавляется в конец коллекции. Если в презентации есть единственный Slide Master, он будет выбран для всех новых слайдов. Поэтому вам не нужно вручную указывать Slide Master для каждого создаваемого слайда.

Принцип одинаков для PowerPoint и Aspose.Slides. Например, в PowerPoint, добавив новый слайд, вы можете просто кликнуть на пустую строку под последним слайдом — и будет создан новый слайд (с последним используемым Slide Master):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides то же самое достигается вызовом метода [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) у класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

## **Slide Master в иерархии Slides**
Использование Slide Layout вместе со Slide Master обеспечивает максимальную гибкость. Slide Layout позволяет задать такие же стили, как у Slide Master (фон, шрифты, фигуры и т.д.). Однако при комбинировании нескольких Slide Layout на одном Slide Master появляется новый стиль. Применив Slide Layout к отдельному слайду, вы можете изменить его стиль, переопределив стиль Slide Master.

Slide Master превосходит все остальные элементы настройки: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)

Каждый объект [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) имеет свойство [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) — список Slide Layout. Объект типа [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) имеет свойство [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide), указывающее на применённый к нему Slide Layout. Взаимодействие слайда и Slide Master происходит через Slide Layout.

{{% alert color="info" title="Note" %}}
* В Aspose.Slides все настройки слайда (Slide Master, Slide Layout и сам слайд) реализованы как объекты, реализующие интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide).
* Поэтому Slide Master и Slide Layout могут иметь одинаковые свойства, и важно понимать, как их значения применяются к объекту [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/). Сначала к слайду применяется Slide Master, затем — Slide Layout. Например, если и Slide Master, и Slide Layout задают фон, окончательный фон будет взят из Slide Layout.
{{% /alert %}}

## **Из чего состоит Slide Master**
Чтобы понять, как можно изменить Slide Master, необходимо знать его составные части. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/):

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) — получить/установить фон слайда.
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) — получить/установить стили текста тела слайда.
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) — получить/установить все фигуры Slide Master (заполнители, рамки изображений и т.п.).
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) — получить/установить элементы ActiveX.
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) — получить менеджер тем.
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) — получить менеджер колонтитулов.

Методы Slide Master:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) — получить все слайды, зависящие от данного Slide Master.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) — позволяет создать новый Slide Master на основе текущего и новой темы, после чего новый мастер будет применён ко всем зависимым слайдам.

## **Получить Slide Master**
В PowerPoint Slide Master доступен через меню Вид → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

В Aspose.Slides доступ к Slide Master выглядит так:
```c#
IMasterSlide master = pres.Masters[0];
```


Интерфейс [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) представляет Slide Master. Свойство [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (относящееся к типу [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) содержит список всех Slide Master, определённых в презентации. 

## **Добавить изображение в Slide Master**
При добавлении изображения в Slide Master оно появится на всех слайдах, зависящих от этого мастера. 

Например, разместив логотип компании и несколько изображений на Slide Master, вы увидите их на каждом слайде после возврата в режим редактирования.

![todo:image_alt_text](slide-master_4.png)

Добавить изображения в Slide Master можно с помощью Aspose.Slides: 
```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="See also" %}} 
Для получения дополнительной информации о добавлении изображений на слайд см. статью [Picture Frame](/slides/ru/net/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Добавить заполнитель в Slide Master**
Это стандартные заполняющие текстовые поля на Slide Master: 

* Click to edit Master title style
* Edit Master text styles
* Second level
* Third level 

Они также отображаются на слайдах, основанных на Slide Master. Вы можете отредактировать эти заполнители на Slide Master, и изменения автоматически применятся к слайдам. 

В PowerPoint добавить заполнитель можно через путь Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Предположим, что слайд содержит заполнители, полученные из Slide Master:

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование заголовка и подзаголовка на Slide Master следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала получаем содержимое заполнителя заголовка из объекта Slide Master и затем используем поле `PlaceHolder.FillFormat`:
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


Стиль и форматирование заголовка изменятся на всех слайдах, основанных на данном мастере:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)
{{% /alert %}}

## **Изменить фон Slide Master**
При изменении цвета фона мастер‑слайда новый цвет будет применён ко всем обычным слайдам презентации. Ниже пример кода на C#:

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


{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/net/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/net/presentation-theme/)
{{% /alert %}}

## **Клонировать Slide Master в другую презентацию**
Чтобы клонировать Slide Master в другую презентацию, вызовите метод [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) у целевой презентации, передав в него нужный Slide Master. Пример кода на C#:

```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **Добавить несколько Slide Master в презентацию**
Aspose.Slides позволяет добавить несколько Slide Master и Slide Layout в любую презентацию. Это даёт возможность задавать стили, макеты и параметры форматирования слайдов различными способами. 

В PowerPoint новые Slide Master и Layout добавляются через меню «Slide Master» следующим образом:

![todo:image_alt_text](slide-master_9.jpg)

В Aspose.Slides новый Slide Master добавляется вызовом метода [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/):

```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **Сравнить Slide Master**
Slide Master реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide), содержащий метод [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals), которым можно сравнивать мастеры. Метод возвращает `true`, если мастеры идентичны по структуре и статическому содержимому. 

Два Slide Master считаются равными, если их фигуры, стили, тексты, анимации и прочие настройки совпадают. При сравнении игнорируются уникальные идентификаторы (например, SlideId) и динамический контент (например, текущая дата в заполнителе Date).

## **Установить Slide Master как представление по умолчанию для презентации**
Aspose.Slides позволяет задать Slide Master в качестве представления по умолчанию для презентации. Это то, что пользователь видит первым при открытии файла. 

Ниже пример кода на C#, показывающий, как установить Slide Master в качестве представления по умолчанию:

```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```


## **Удалить неиспользуемый Master Slide**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), позволяющий удалить ненужные и неиспользуемые мастер‑слайды. Пример кода на C#:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Что такое Slide Master в PowerPoint?**

Slide Master — шаблон слайда, определяющий макет, стили, темы, шрифты, фон и другие свойства всех слайдов презентации. Он позволяет задать и изменить внешний вид всех слайдов сразу.  

**Как применяется Slide Master в презентации?**

Каждая презентация имеет как минимум один Slide Master по умолчанию. При добавлении нового слайда к нему автоматически применяется Slide Master, обычно наследующийся от мастера предыдущего слайда. Презентация может содержать несколько Slide Master для индивидуального оформления разных частей.  

**Какие элементы можно настроить в Slide Master?**

Slide Master состоит из нескольких основных свойств, которые можно настроить:

- **Background**: задать фон слайда.
- **BodyStyle**: определить стили текста тела.
- **Shapes**: управлять всеми фигурами мастер‑слайда, включая заполнители и рамки изображений.
- **Controls**: работать с элементами ActiveX.
- **ThemeManager**: доступ к менеджеру тем.
- **HeaderFooterManager**: управлять колонтитулами.  

**Как добавить изображение в Slide Master?**

Добавление изображения в Slide Master гарантирует его отображение на всех слайдах, зависящих от данного мастера. Например, разместив логотип компании на Slide Master, вы увидите его на каждом слайде презентации.  

**Как Slide Master взаимодействует с Slide Layout?**

Slide Layout работает совместно со Slide Master, обеспечивая гибкость дизайна. Slide Master задаёт глобальные стили и темы, а Slide Layout позволяет варьировать расположение контента. Иерархия выглядит так:

- **Slide Master** → задаёт глобальные стили.
- **Slide Layout** → предлагает разные варианты расположения контента.
- **Slide** → наследует дизайн от выбранного Slide Layout.

**Можно ли использовать несколько Slide Master в одной презентации?**

Да, презентация может содержать несколько Slide Master. Это даёт возможность оформлять разные секции презентации по‑разному, увеличивая гибкость дизайна.  

**Как получить доступ к Slide Master и изменить его с помощью Aspose.Slides?**

В Aspose.Slides Slide Master представлен интерфейсом `IMasterSlide`. Доступ к нему осуществляется через свойство `Masters` объекта `Presentation`.