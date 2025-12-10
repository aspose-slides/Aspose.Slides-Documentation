---
title: "Управление мастер‑слайдами презентации в .NET"
linktitle: "Мастер‑слайд"
type: docs
weight: 80
url: /ru/net/slide-master/
keywords:
- "мастер‑слайд"
- "мастер‑слайд"
- "мастер‑слайд PPT"
- "несколько мастер‑слайдов"
- "сравнение мастер‑слайдов"
- "фон"
- "заполнитель"
- "клонирование мастер‑слайда"
- "копирование мастер‑слайда"
- "дубликат мастер‑слайда"
- "неиспользуемый мастер‑слайд"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Управляйте мастер‑слайдами в Aspose.Slides для .NET: создавайте, редактируйте и применяйте макеты, темы и заполнители к PPT, PPTX и ODP с помощью кратких примеров на C#."
---

## **Что такое мастер‑слайд в PowerPoint**
**Мастер‑слайд** в PowerPoint — это функция, управляющая макетом, шрифтами и стилями на нескольких слайдах. Он помогает поддерживать единообразие и фирменный стиль в презентациях. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать мастер‑слайд. 

Мастер‑слайд полезен тем, что позволяет задать и изменить внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм мастер‑слайдов из PowerPoint. 

VBA также позволяет манипулировать мастер‑слайдом и выполнять те же операции, что поддерживаются в PowerPoint: изменять фон, добавлять фигуры, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы для использования мастер‑слайдов и выполнения базовых задач с ними. 

Это базовые операции с мастер‑слайдом:

- Создание или редактирование мастер‑слайда.  
- Применение мастер‑слайда к слайдам презентации.  
- Изменение фона мастер‑слайда.  
- Добавление изображения, заполнителя, Smart Art и т.п. к мастер‑слайду.  

Это более продвинутые операции с мастер‑слайдом:  

- Сравнение мастер‑слайдов.  
- Объединение мастер‑слайдов.  
- Применение нескольких мастер‑слайдов.  
- Копирование слайда с мастер‑слайдом в другую презентацию.  
- Поиск дублирующихся мастер‑слайдов в презентациях.  
- Установка мастер‑слайда как представления по умолчанию для презентации.  

{{% alert color="primary" %}} 

Возможно, вам будет интересно посмотреть Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer), поскольку это живой пример некоторых основных процессов, описанных здесь.

{{% /alert %}} 


## **Как применяется мастер‑слайд**
Прежде чем работать с мастер‑слайдом, стоит понять, как они используются в презентациях и применяются к слайдам. 

* Каждая презентация имеет как минимум один мастер‑слайд по умолчанию.  
* Презентация может содержать несколько мастер‑слайдов. Вы можете добавить несколько мастер‑слайдов и использовать их для стилизации разных частей презентации по‑разному.  

В **Aspose.Slides** мастер‑слайд представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide). 

Объект [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) в Aspose.Slides содержит список [**Masters** ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), который хранит все мастер‑слайды, определённые в презентации. 

Помимо CRUD‑операций, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) содержит полезные методы: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) и [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Эти методы унаследованы от базовой функции клонирования слайдов. Но при работе с мастер‑слайдами они позволяют реализовывать сложные настройки. 

Когда в презентацию добавляется новый слайд, к нему автоматически применяется мастер‑слайд. По умолчанию выбирается мастер‑слайд предыдущего слайда. 

**Note**: Слайды презентации хранятся в списке [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), и каждый новый слайд добавляется в конец коллекции по умолчанию. Если презентация содержит один единственный мастер‑слайд, этот мастер‑слайд будет выбран для всех новых слайдов. Поэтому вам не нужно задавать мастер‑слайд для каждого нового слайда.  

Принцип тот же, что и в PowerPoint. Например, в PowerPoint, когда вы добавляете новый слайд, достаточно щёлкнуть по нижней линии под последним слайдом — будет создан новый слайд (с мастер‑слайдом последней презентации):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить эквивалентную задачу с помощью метода [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) класса [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).


## **Мастер‑слайд в иерархии слайдов**
Использование макетов слайдов вместе с мастер‑слайдом обеспечивает максимальную гибкость. Макет слайда позволяет задать те же стили, что и мастер‑слайд (фон, шрифты, фигуры и т.п.). Однако, когда несколько макетов слайдов объединяются на одном мастер‑слайде, появляется новый стиль. При применении макета к отдельному слайду вы можете изменить его стиль относительно того, который задаёт мастер‑слайд.

Мастер‑слайд имеет приоритет над всеми настройками: Мастер‑слайд → Макет слайда → Слайд:

![todo:image_alt_text](slide-master_2)



Каждый объект [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) имеет свойство [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) со списком макетов слайдов. Тип [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) имеет свойство [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide), указывающее на макет, применённый к этому слайду. Взаимодействие между слайдом и мастер‑слайдом происходит через макет слайда.

{{% alert color="info" title="Note" %}}

* В Aspose.Slides все настройки слайда (Мастер‑слайд, Макет слайда и сам слайд) являются объектами слайдов, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide).  
* Поэтому Мастер‑слайд и Макет слайда могут реализовывать одинаковые свойства, и вам нужно знать, как их значения будут применяться к объекту [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/). Сначала к слайду применяется Мастер‑слайд, затем — Макет слайда. Например, если у Мастер‑слайда и у Макета слайда задан фон, в итоге у слайда будет фон из Макета слайда.

{{% /alert %}}


## **Содержание мастер‑слайда**
Чтобы понять, как можно изменять мастер‑слайд, следует знать его составные части. Ниже перечислены основные свойства [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/).

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) — получение/установка фона слайда.  
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) — получение/установка стилей текста тела слайда.  
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) — получение/установка всех фигур мастер‑слайда (заполнители, рамки изображений и т.п.).  
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) — получение/установка элементов ActiveX.  
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) — получение менеджера тем.  
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) — получение менеджера верхних и нижних колонтитулов.  

Методы мастер‑слайда:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) — получение всех слайдов, зависящих от данного мастер‑слайда.  
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) — позволяет создать новый мастер‑слайд на основе текущего и новой темы. Новый мастер‑слайд затем будет применён ко всем зависимым слайдам.


## **Получить мастер‑слайд**
В PowerPoint мастер‑слайд доступен через меню Вид → Мастер‑слайд:

![todo:image_alt_text](slide-master_3.jpg)



В Aspose.Slides вы можете получить мастер‑слайд так:
```c#
IMasterSlide master = pres.Masters[0];
```


Интерфейс [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) представляет мастер‑слайд. Свойство [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (связано с типом [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) содержит список всех мастер‑слайдов, определённых в презентации. 


## **Добавить изображение в мастер‑слайд**
При добавлении изображения в мастер‑слайд это изображение будет отображаться на всех слайдах, зависящих от данного мастер‑слайда. 

Например, вы можете разместить логотип вашей компании и несколько изображений на мастер‑слайде, затем вернуться в режим редактирования слайдов. Вы увидите изображение на каждом слайде. 

![todo:image_alt_text](slide-master_4.png)

Вы можете добавить изображения в мастер‑слайд с помощью Aspose.Slides: 
```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="See also" %}} 

Для получения дополнительной информации о добавлении изображений см. статью [Picture Frame](/slides/ru/net/picture-frame/#create-picture-frame).

{{% /alert %}}


## **Добавить заполнитель в мастер‑слайд**
Эти текстовые поля являются стандартными заполнителями на мастер‑слайде: 

* Щёлкните, чтобы отредактировать стиль заголовка мастера  
* Отредактировать стили текста мастера  
* Уровень 2  
* Уровень 3  

Они также отображаются на слайдах, основанных на мастер‑слайде. Вы можете редактировать эти заполнители на мастер‑слайде, и изменения автоматически применятся к слайдам. 

В PowerPoint вы можете добавить заполнитель через путь Мастер‑слайд → Вставить заполнитель:

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Предположим, есть слайд с заполнителями, полученными из мастер‑слайда:

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование заголовка и подзаголовка на мастер‑слайде следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала получаем содержимое заполнителя заголовка из объекта мастер‑слайда, затем используем поле `PlaceHolder.FillFormat`: 
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


Стиль заголовка и форматирование изменятся на всех слайдах, основанных на данном мастер‑слайде:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Изменить фон мастер‑слайда**
При изменении цвета фона мастер‑слайда все обычные слайды презентации получат новый цвет. Этот C#‑код демонстрирует операцию:
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

## **Клонировать мастер‑слайд в другую презентацию**
Чтобы клонировать мастер‑слайд в другую презентацию, вызовите метод [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) из целевой презентации, передав в него мастер‑слайд. Этот C#‑код показывает, как клонировать мастер‑слайд в другую презентацию:
```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```



## **Добавить несколько мастер‑слайдов в презентацию**
Aspose.Slides позволяет добавить несколько мастер‑слайдов и макетов слайдов в любую презентацию. Это даёт возможность настраивать стили, макеты и параметры форматирования слайдов множеством способов. 

В PowerPoint новые мастер‑слайды и макеты (из меню «Мастер‑слайд») добавляются так:

![todo:image_alt_text](slide-master_9.jpg)

В Aspose.Slides вы можете добавить новый мастер‑слайд, вызвав метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/):
```c#
pres.Masters.AddClone(pres.Masters[0]);
```



## **Сравнение мастер‑слайдов**
Мастер‑слайд реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) с методом [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals), который можно использовать для сравнения слайдов. Он возвращает `true`, если мастер‑слайды идентичны по структуре и статическому содержимому. 

Два мастер‑слайда считаются равными, если их фигуры, стили, тексты, анимация и другие настройки совпадают. При сравнении не учитываются уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущая дата в заполняющем поле даты). 


## **Установить мастер‑слайд как представление по умолчанию для презентации**
Aspose.Slides позволяет установить мастер‑слайд как представление по умолчанию для презентации. Представление по умолчанию — это то, что вы видите первым при открытии презентации. 

Этот код показывает, как установить мастер‑слайд как представление по умолчанию в C#:
```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```


## **Удалить неиспользуемые мастер‑слайды**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)), позволяющий удалять нежелательные и неиспользуемые мастер‑слайды. Этот C#‑код показывает, как удалить мастер‑слайд из презентации PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Что такое мастер‑слайд в PowerPoint?**

Мастер‑слайд — это шаблон слайда, определяющий макет, стили, темы, шрифты, фон и другие свойства слайдов презентации. Он позволяет задать и изменить внешний вид всех слайдов презентации одновременно.  

**Как применяется мастер‑слайд в презентации?**

Каждая презентация имеет как минимум один мастер‑слайд по умолчанию. Когда добавляется новый слайд, к нему автоматически применяется мастер‑слайд, обычно наследующийся от мастера предыдущего слайда. Презентация может содержать несколько мастер‑слайдов для стилизации разных частей по‑отдельности.  

**Какие элементы можно настраивать в мастер‑слайде?**

Мастер‑слайд состоит из нескольких основных свойств, которые можно изменять:

- **Background**: задаёт фон слайда.  
- **BodyStyle**: определяет стили текста тела слайда.  
- **Shapes**: управляет всеми фигурами на мастер‑слайде, включая заполнители и рамки изображений.  
- **Controls**: работает с элементами ActiveX.  
- **ThemeManager**: предоставляет доступ к менеджеру тем.  
- **HeaderFooterManager**: управляет верхними и нижними колонтитулами.  

**Как добавить изображение в мастер‑слайд?**

Добавление изображения в мастер‑слайд гарантирует его отображение на всех слайдах, зависящих от данного мастера. Например, размещение логотипа компании на мастер‑слайде сделает его видимым на каждом слайде презентации.  

**Как мастер‑слайды связаны с макетами слайдов?**

Макеты слайдов работают совместно с мастер‑слайдами, обеспечивая гибкость дизайна. Пока мастер‑слайд задаёт общие стили и темы, макет слайда позволяет варьировать расположение контента. Иерархия выглядит так:

- **Мастер‑слайд** → определяет глобальные стили.  
- **Макет слайда** → предоставляет разные варианты расположения контента.  
- **Слайд** → наследует дизайн от своего макета слайда.  

**Можно ли иметь несколько мастер‑слайдов в одной презентации?**

Да, презентация может содержать несколько мастер‑слайдов. Это позволяет стилизовать разные разделы презентации различными способами, обеспечивая гибкость дизайна.  

**Как получить и изменить мастер‑слайд с помощью Aspose.Slides?**

В Aspose.Slides мастер‑слайд представлен интерфейсом `IMasterSlide`. Вы можете получить мастер‑слайд, используя свойство `Masters` объекта `Presentation`.