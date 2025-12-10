---
title: Управление мастер‑слайдами презентации в Java
linktitle: Мастер‑слайд
type: docs
weight: 70
url: /ru/java/slide-master/
keywords:
- мастер‑слайд
- основной слайд
- PPT мастер‑слайд
- несколько мастер‑слайдов
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонирование мастер‑слайда
- копирование мастер‑слайда
- дублирование мастер‑слайда
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте мастер‑слайдами в Aspose.Slides для Java: создавайте, редактируйте и применяйте макеты, темы и заполнители к PPT, PPTX и ODP с помощью кратких примеров на Java."
---

## **Что такое Slide Master в PowerPoint**

**Slide Master** — это шаблон слайда, определяющий расположение, стили, тему, шрифты, фон и другие свойства слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) в едином стиле и шаблоне для вашей компании, вы можете использовать Slide Master.  

Slide Master полезен, потому что позволяет задать и изменить внешний вид всех слайдов презентации сразу. Aspose.Slides поддерживает механизм Slide Master из PowerPoint.  

VBA также позволяет манипулировать Slide Master и выполнять те же операции, поддерживаемые в PowerPoint: менять фон, добавлять фигуры, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы, позволяющие использовать Slide Masters и выполнять базовые задачи с ними.  

Это базовые операции с Slide Master:

- Создать Slide Master.  
- Применить Slide Master к слайдам презентации.  
- Изменить фон Slide Master.  
- Добавить изображение, заполнитель, Smart Art и т.д. в Slide Master.  

Это более продвинутые операции, связанные со Slide Master:

- Сравнить Slide Masters.  
- Объединить Slide Masters.  
- Применить несколько Slide Masters.  
- Скопировать слайд с Slide Master в другую презентацию.  
- Найти дублирующие Slide Masters в презентациях.  
- Установить Slide Master как представление по умолчанию для презентации.  

{{% alert color="primary" %}} 
Возможно, вам стоит ознакомиться с Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer), поскольку это живой пример некоторых из основных процессов, описанных здесь.  
{{% /alert %}} 

## **Как применяется Slide Master**

Прежде чем работать со Slide Master, вам может потребоваться понять, как они используются в презентациях и применяются к слайдам.  

- Каждая презентация содержит как минимум один Slide Master по умолчанию.  
- Презентация может содержать несколько Slide Masters. Вы можете добавить несколько Slide Masters и использовать их для оформления разных частей презентации различными способами.  

В **Aspose.Slides** Slide Master представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).  

Объект [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) библиотеки Aspose.Slides содержит список [**getMasters** ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), который включает список всех мастер‑слайдов, определённых в презентации.  

Помимо операций CRUD, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) содержит полезные методы: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) и [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . Эти методы унаследованы из базовой функции клонирования слайдов. Однако при работе с Slide Masters они позволяют реализовывать сложные настройки.  

При добавлении нового слайда в презентацию к нему автоматически применяется Slide Master. По умолчанию выбирается Slide Master предыдущего слайда.  

**Note**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) , и каждый новый слайд по умолчанию добавляется в конец коллекции. Если в презентации содержится один Slide Master, этот мастер‑слайд выбирается для всех новых слайдов. По этой причине вам не нужно задавать Slide Master для каждого нового создаваемого слайда.  

Принцип такой же в PowerPoint и Aspose.Slides. Например, в PowerPoint, когда вы добавляете новую презентацию, можно просто щёлкнуть по нижней линии под последним слайдом, и тогда будет создан новый слайд (с Slide Master последней презентации):  

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить аналогичную задачу с помощью метода [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) класса [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).  

## **Slide Master в иерархии слайдов**

Использование Slide Layout вместе со Slide Master обеспечивает максимальную гибкость. Slide Layout позволяет задать те же стили, что и Slide Master (фон, шрифты, фигуры и т.д.). Однако когда несколько Slide Layout объединяются в Slide Master, создаётся новый стиль. При применении Slide Layout к отдельному слайду вы можете изменить его стиль относительно того, который задаёт Slide Master.  

Slide Master имеет высший приоритет среди всех настроек: Slide Master → Slide Layout → Slide:  

![todo:image_alt_text](slide-master_2)

Каждый объект [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) с перечнем Slide Layout. Тип [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) со ссылкой на Slide Layout, примененный к слайду. Взаимодействие между слайдом и Slide Master происходит через Slide Layout.  

{{% alert color="info" title="Note" %}} 
* В Aspose.Slides все настройки слайдов (Slide Master, Slide Layout и сам слайд) на самом деле являются объектами слайдов, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).  
* Поэтому Slide Master и Slide Layout могут реализовывать одинаковые свойства, и вам необходимо знать, как их значения будут применяться к объекту [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). Сначала к слайду применяется Slide Master, затем – Slide Layout. Например, если у Slide Master и Slide Layout указано значение фона, в итоге слайд получит фон из Slide Layout.  
{{% /alert %}}  

## **Что содержит Slide Master**

Чтобы понять, как можно изменить Slide Master, необходимо знать его составные части. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/).  

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) — получить/установить фон слайда.  
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) — получить/установить стили текста тела слайда.  
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) — получить/установить все фигуры Slide Master (заполнители, рамки изображений и т.д.).  
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) — получить/установить элементы управления ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) — получить менеджер темы.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) — получить менеджер верхнего и нижнего колонтитула.  

### Методы Slide Master  

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) — получить все слайды, зависящие от Slide Master.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) — позволяет создать новый Slide Master на основе текущего Slide Master и новой темы. Новый Slide Master затем будет применён ко всем зависимым слайдам.  

## **Получить Slide Master**

В PowerPoint Slide Master доступен через меню Вид → Slide Master:  

![todo:image_alt_text](slide-master_3.jpg)

С помощью Aspose.Slides вы можете получить Slide Master таким образом:  
```java
Presentation pres = new Presentation();
try {
    // Получает доступ к мастер‑слайду презентации
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Интерфейс [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) представляет Slide Master. Свойство [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (связанное с типом [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) содержит список всех Slide Master, определённых в презентации.  

## **Добавить изображение в Slide Master**

Когда вы добавляете изображение в Slide Master, оно будет отображаться на всех слайдах, зависящих от этого мастер‑слайда.  

Например, вы можете разместить логотип вашей компании и несколько изображений на Slide Master, а затем вернуться в режим редактирования слайдов. Вы должны увидеть изображение на каждом слайде.  

![todo:image_alt_text](slide-master_4.png)

Вы можете добавить изображения в Slide Master с помощью Aspose.Slides:  
```java
Presentation pres = new Presentation();
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="See also" %}} 
Для получения дополнительной информации о добавлении изображений в слайд см. статью [Picture Frame](/slides/ru/java/picture-frame/#create-picture-frame).  
{{% /alert %}}  

## **Добавить заполнитель в Slide Master**

Эти текстовые поля являются стандартными заполнителями на Slide Master:  

- Кликните, чтобы редактировать стиль заголовка мастера  
- Редактировать стили текста мастера  
- Второй уровень  
- Третий уровень  

Они также отображаются на слайдах, основанных на Slide Master. Вы можете редактировать эти заполнители на Slide Master, и изменения автоматически применяются к слайдам.  

В PowerPoint вы можете добавить заполнитель через путь Slide Master → Insert Placeholder:  

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Представьте слайд с заполнителями, созданными из Slide Master:  

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование Title и Subtitle в Slide Master следующим образом:  

![todo:image_alt_text](slide-master_7.png)

Сначала мы получаем содержимое заполнителя заголовка из объекта Slide Master, а затем используем поле `PlaceHolder.FillFormat`:  
```java
public static void main(String[] args) {
    Presentation pres = new Presentation();
    try {
        IMasterSlide master = pres.getMasters().get_Item(0);
        IAutoShape placeHolder = findPlaceholder(master, PlaceholderType.Title);
        placeHolder.getFillFormat().setFillType(FillType.Gradient);
        placeHolder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, new Color(255, 0, 0));
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, new Color(128, 0, 128));

        pres.save("pres.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
}

static IAutoShape findPlaceholder(IMasterSlide master, int type)
{
    for (IShape shape : master.getShapes())
    {
        IAutoShape autoShape = (IAutoShape) shape;
        if (autoShape != null)
        {
            if (autoShape.getPlaceholder().getType() == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```


Стиль и форматирование заголовка изменятся для всех слайдов, основанных на мастер‑слайде:  

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [Установить текст подсказки в заполнителе](https://docs.aspose.com/slides/java/manage-placeholder/)  
* [Форматирование текста](https://docs.aspose.com/slides/java/text-formatting/)  
{{% /alert %}}  

## **Изменить фон Slide Master**

При изменении цвета фона мастер‑слайда все обычные слайды презентации получат новый цвет. Этот код на Java демонстрирует операцию:  
```java
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);
    master.getBackground().setType(BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(FillType.Solid);
    master.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="See also" %}} 
* [Фон презентации](https://docs.aspose.com/slides/java/presentation-background/)  
* [Тема презентации](https://docs.aspose.com/slides/java/presentation-theme/)  
{{% /alert %}}  

## **Клонировать Slide Master в другую презентацию**

Чтобы клонировать Slide Master в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) из целевой презентации, передав в него Slide Master. Этот код на Java показывает, как клонировать Slide Master в другую презентацию:  
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **Добавить несколько Slide Master в презентацию**

Aspose.Slides позволяет добавить несколько Slide Master и Slide Layout в любую презентацию. Это дает возможность настраивать стили, макеты и параметры форматирования слайдов презентации различными способами.  

В PowerPoint вы можете добавить новые Slide Master и Layout (из меню "Slide Master") следующим образом:  

![todo:image_alt_text](slide-master_9.jpg)

С помощью Aspose.Slides вы можете добавить новый Slide Master, вызвав метод [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):  
```java
// Добавляет новый мастер‑слайд
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **Сравнить Slide Masters**

Master Slide реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide), содержащий метод [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), который можно использовать для сравнения слайдов. Он возвращает `true` для Master Slides, идентичных по структуре и статическому содержимому.  

Два Master Slides считаются равными, если их фигуры, стили, тексты, анимация и другие параметры совпадают. При сравнении не учитываются уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущая дата в заполнителе Date).  

## **Установить Slide Master как представление по умолчанию для презентации**

Aspose.Slides позволяет установить Slide Master в качестве представления по умолчанию для презентации. Представление по умолчанию — то, что вы видите при открытии презентации.  

Этот код показывает, как установить Slide Master в качестве представления по умолчанию презентации на Java:  
```java
// Создает экземпляр класса Presentation, который представляет файл презентации
Presentation presentation = new Presentation();
try {
    // Устанавливает представление по умолчанию как SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // Сохраняет презентацию
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Удалить неиспользуемые Master Slides**

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (из класса [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)), позволяющий удалять нежелательные и неиспользуемые мастер‑слайды. Этот код на Java показывает, как удалить мастер‑слайд из презентации PowerPoint:  
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **FAQ**

**Что такое Slide Master в PowerPoint?**  

Slide Master — это шаблон слайда, определяющий расположение, стили, темы, шрифты, фон и другие свойства слайдов в презентации. Он позволяет задать и изменить внешний вид всех слайдов презентации одновременно.  

**Как Slide Master применяется в презентации?**  

Каждая презентация по умолчанию имеет как минимум один Slide Master. При добавлении нового слайда к нему автоматически применяется Slide Master, обычно наследуемый от предыдущего слайда. Презентация может содержать несколько Slide Master для уникального оформления разных частей.  

**Какие элементы можно настроить в Slide Master?**  

- **Background**: задать фон слайда.  
- **BodyStyle**: определить стили текста тела слайда.  
- **Shapes**: управлять всеми фигурами на Slide Master, включая заполнители и рамки изображений.  
- **Controls**: работать с элементами управления ActiveX.  
- **ThemeManager**: получить доступ к менеджеру темы.  
- **HeaderFooterManager**: управлять верхними и нижними колонтитулами.  

**Как добавить изображение в Slide Master?**  

Добавление изображения в Slide Master гарантирует его отображение на всех слайдах, зависящих от этого мастера. Например, размещение логотипа компании на Slide Master отобразится на каждом слайде презентации.  

**Как Slide Master относятся к Slide Layout?**  

Slide Layout работают вместе со Slide Master, обеспечивая гибкость в дизайне слайдов. Пока Slide Master определяет общие стили и темы, Slide Layout позволяют варьировать расположение содержимого. Иерархия выглядит так:  

- **Slide Master** → определяет глобальные стили.  
- **Slide Layout** → предоставляет различные варианты расположения содержимого.  
- **Slide** → наследует дизайн от своего Slide Layout.  

**Могу ли я иметь несколько Slide Master в одной презентации?**  

Да, презентация может содержать несколько Slide Master. Это позволяет оформлять разные разделы презентации различными способами, обеспечивая гибкость дизайна.  

**Как получить доступ и изменить Slide Master с помощью Aspose.Slides?**  

В Aspose.Slides Slide Master представлен интерфейсом [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/). Вы можете получить доступ к Slide Master, используя метод [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) объекта [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).