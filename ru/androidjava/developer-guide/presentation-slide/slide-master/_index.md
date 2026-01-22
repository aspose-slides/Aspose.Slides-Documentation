---
title: Управление мастер-слайдами презентации на Android
linktitle: Мастер-слайд
type: docs
weight: 70
url: /ru/androidjava/slide-master/
keywords:
- мастер-слайд
- мастер-слайд
- мастер-слайд PPT
- несколько мастер-слайдов
- сравнение мастер-слайдов
- фон
- заполнитель
- клонировать мастер-слайд
- копировать мастер-слайд
- дублировать мастер-слайд
- неиспользуемый мастер-слайд
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте мастер-слайдами в Aspose.Slides для Android: создавайте, редактируйте и применяйте макеты, темы и заполнители к PPT, PPTX и ODP с помощью лаконичных примеров на Java."
---

## **Что такое Slide Master в PowerPoint**

**Slide Master** — это шаблон слайда, который определяет расположение, стили, тему, шрифты, фон и другие свойства слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать Slide Master.  

Slide Master полезен, потому что позволяет задать и изменить внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм Slide Master из PowerPoint.  

VBA также позволяет манипулировать Slide Master и выполнять те же операции, что поддерживаются в PowerPoint: изменять фон, добавлять фигуры, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы, позволяющие использовать Slide Master и выполнять базовые задачи с ними.  

Это базовые операции с Slide Master:

- Создать Slide Master.
- Применить Slide Master к слайдам презентации.
- Изменить фон Slide Master. 
- Добавить изображение, заполнитель, Smart Art и т.п. к Slide Master.

Это более продвинутые операции с Slide Master: 

- Сравнить Slide Master.
- Объединить Slide Master.
- Применить несколько Slide Master.
- Скопировать слайд с Slide Master в другую презентацию.
- Найти дублирующиеся Slide Master в презентациях.
- Установить Slide Master как представление по умолчанию для презентации.

{{% alert color="primary" %}} 
Возможно, вам будет интересно попробовать Aspose [**Онлайн‑просмотрщик PowerPoint**](https://products.aspose.app/slides/viewer), так как это живой пример некоторых основных процессов, описанных здесь.
{{% /alert %}} 


## **Как применяется Slide Master**

Прежде чем работать со Slide Master, может быть полезно понять, как они используются в презентациях и применяются к слайдам. 

* Каждая презентация имеет по крайней мере один Slide Master по умолчанию. 
* Презентация может содержать несколько Slide Master. Вы можете добавить несколько Slide Master и использовать их для стилизации разных частей презентации по‑разному. 

В **Aspose.Slides** Slide Master представляется типом [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).  

Объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) в Aspose.Slides содержит список [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), в котором находится перечень всех мастер‑слайдов, определённых в презентации.  

Помимо CRUD‑операций, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) содержит полезные методы: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) и [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Эти методы наследованы от базовой функции клонирования слайдов, но при работе с Slide Master позволяют реализовывать сложные сценарии.  

Когда в презентацию добавляется новый слайд, к нему автоматически применяется Slide Master. По умолчанию выбирается Slide Master предыдущего слайда.  

**Примечание**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) и каждый новый слайд добавляется в конец коллекции. Если в презентации один Slide Master, он используется для всех новых слайдов. Поэтому не нужно явно указывать Slide Master для каждого создаваемого слайда.  

Принцип тот же в PowerPoint и Aspose.Slides. Например, в PowerPoint, когда вы добавляете новый слайд, просто нажимаете строку под последним слайдом, и создаётся новый слайд (с последним Slide Master):  

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides эквивалентную задачу можно выполнить методом [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).  


## **Slide Master в иерархии Slides**

Использование Slide Layout вместе со Slide Master обеспечивает максимальную гибкость. Slide Layout позволяет задать те же стили, что и Slide Master (фон, шрифты, фигуры и т.п.). Однако при комбинировании нескольких Slide Layout на Slide Master создаётся новый стиль. Применяя Slide Layout к отдельному слайду, вы можете изменить его стиль относительно того, что задаёт Slide Master.  

Slide Master превалирует над всеми элементами настройки: Slide Master → Slide Layout → Slide:  

![todo:image_alt_text](slide-master_2)



Каждый объект [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) со списком Slide Layout. Тип [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) со ссылкой на применённый к слайду Slide Layout. Взаимодействие между слайдом и Slide Master происходит через Slide Layout.  

{{% alert color="info" title="Примечание" %}}

* В Aspose.Slides все настройки слайда (Slide Master, Slide Layout и сам слайд) являются объектами слайдов, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide).  
* Поэтому Slide Master и Slide Layout могут реализовывать одинаковые свойства, и важно понимать, как их значения применяются к объекту [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide). Сначала к слайду применяется Slide Master, затем — Slide Layout. Например, если у Slide Master и Slide Layout заданы одинаковые значения фона, окончательный фон будет взят из Slide Layout.

{{% /alert %}}


## **Что входит в состав Slide Master**

Чтобы понять, как можно менять Slide Master, необходимо знать его составные части. Ниже перечислены основные свойства [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/).  

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) — получение/установка фона слайда.  
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) — получение/установка стилей текста тела слайда.  
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) — получение/установка всех фигур Slide Master (заполнители, рамки изображений и т.п.).  
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) — получение/установка элементов ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) — получение менеджера тем.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) — получение менеджера колонтитулов.  

Методы Slide Master:

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) — получение всех слайдов, зависящих от данного Slide Master.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) — позволяет создать новый Slide Master на основе текущего и новой темы; новый Slide Master затем применяется ко всем зависимым слайдам.  


## **Получить Slide Master**

В PowerPoint Slide Master доступен через меню Вид → Slide Master:  

![todo:image_alt_text](slide-master_3.jpg)



В Aspose.Slides доступ к Slide Master выглядит так:  
```java
Presentation pres = new Presentation();
try {
    // Получает доступ к мастер-слайду презентации
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Интерфейс [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) представляет Slide Master. Свойство [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (относящееся к типу [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)) содержит список всех Slide Master, определённых в презентации.  


## **Добавить изображение в Slide Master**

Когда вы добавляете изображение в Slide Master, оно появляется на всех слайдах, зависящих от этого мастера.  

Например, можно разместить логотип компании и несколько изображений на Slide Master, а затем вернуться к режиму редактирования слайдов — изображение будет видно на каждом слайде.  

![todo:image_alt_text](slide-master_4.png)

Добавить изображения в Slide Master с помощью Aspose.Slides можно так:  
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


{{% alert color="primary" title="См. также" %}} 
Подробнее о добавлении изображений в слайд читайте в статье [Picture Frame](/slides/ru/androidjava/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Добавить заполнитель в Slide Master**

Эти текстовые поля являются стандартными заполнителями на Slide Master: 

* Кликните, чтобы отредактировать стиль заголовка мастера
* Отредактировать стили текста мастера
* Второй уровень
* Третий уровень  

Они также отображаются на слайдах, основанных на Slide Master. Вы можете редактировать эти заполнители на Slide Master, и изменения автоматически применятся к слайдам.  

В PowerPoint заполнитель можно добавить через путь Slide Master → Insert Placeholder:  

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Представим слайд с заполнителями, полученными из Slide Master:  

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование заголовка и подзаголовка на Slide Master следующим образом:  

![todo:image_alt_text](slide-master_7.png)

Сначала получаем содержимое заполнителя заголовка из объекта Slide Master, затем используем поле `PlaceHolder.FillFormat`:  
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


Стиль и форматирование заголовка изменятся для всех слайдов, основанных на этом мастере:  

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="См. также" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/androidjava/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}


## **Изменить фон Slide Master**

При изменении цвета фона мастер‑слайда все обычные слайды презентации получают новый цвет. Ниже пример на Java:  
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


{{% alert color="primary" title="См. также" %}} 
- [Presentation Background](https://docs.aspose.com/slides/androidjava/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/androidjava/presentation-theme/)  
{{% /alert %}}

## **Клонировать Slide Master в другую презентацию**

Чтобы клонировать Slide Master в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) у целевой презентации, передав в него Slide Master. Ниже пример на Java:  
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

Aspose.Slides позволяет добавить несколько Slide Master и Slide Layout в любую презентацию. Это даёт возможность задавать стили, макеты и параметры форматирования слайдов различными способами.  

В PowerPoint новые Slide Master и Layout добавляются через меню «Slide Master»:  

![todo:image_alt_text](slide-master_9.jpg)

В Aspose.Slides новый Slide Master можно добавить, вызвав метод [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):  
```java
// Добавляет новый мастер‑слайд
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Сравнить Slide Master**

Master Slide реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) с методом [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), который можно использовать для сравнения слайдов. Он возвращает `true`, если Master Slides идентичны по структуре и статическому содержимому.  

Два Master Slide считаются равными, если их фигуры, стили, тексты, анимация и прочие настройки совпадают. При сравнении не учитываются уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущая дата в заполнителе даты).  


## **Установить Slide Master как представление по умолчанию для презентации**

Aspose.Slides позволяет задать Slide Master как представление по умолчанию для презентации. Представление по умолчанию — это то, что пользователь видит первой при открытии файла.  

Пример кода на Java, показывающий, как установить Slide Master как представление по умолчанию:  
```java
// Создает экземпляр класса Presentation, представляющего файл презентации
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

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) класса [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/), позволяющий удалять ненужные и неиспользуемые мастер‑слайды. Ниже пример на Java, демонстрирующий, как удалить мастер‑слайд из презентации PowerPoint:  
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

Slide Master — это шаблон слайда, который определяет расположение, стили, темы, шрифты, фон и другие свойства слайдов в презентации. Он позволяет задать и изменить внешний вид всех слайдов одновременно.  

**Как применяется Slide Master в презентации?**  

Каждая презентация имеет по крайней мере один Slide Master по умолчанию. При добавлении нового слайда к нему автоматически применяется Slide Master, обычно наследующий мастер предыдущего слайда. Презентация может содержать несколько Slide Master для стилизации разных частей по‑разному.  

**Какие элементы можно настраивать в Slide Master?**  

Slide Master состоит из нескольких основных свойств, которые можно настраивать:  

- **Background**: задать фон слайда.  
- **BodyStyle**: определить стили текста тела слайда.  
- **Shapes**: управлять всеми фигурами на Slide Master, включая заполнители и рамки изображений.  
- **Controls**: работать с элементами ActiveX.  
- **ThemeManager**: доступ к менеджеру тем.  
- **HeaderFooterManager**: управлять колонтитулами.  

**Как добавить изображение в Slide Master?**  

Добавление изображения в Slide Master гарантирует его отображение на всех слайдах, зависящих от этого мастера. Например, разместив логотип компании на Slide Master, вы увидите его на каждом слайде презентации.  

**Как Slide Master соотносится с Slide Layout?**  

Slide Layout работают совместно со Slide Master, обеспечивая гибкость дизайна. Slide Master задаёт глобальные стили и темы, а Slide Layout позволяют варьировать расположение контента. Иерархия выглядит так:  

- **Slide Master** → определяет глобальные стили.  
- **Slide Layout** → предоставляет разные варианты размещения контента.  
- **Slide** → наследует дизайн от своего Slide Layout.  

**Можно ли иметь несколько Slide Master в одной презентации?**  

Да, презентация может содержать несколько Slide Master. Это позволяет стилизовать разные разделы презентации различными способами, предоставляя большую гибкость в дизайне.  

**Как получить доступ к Slide Master и изменить его с помощью Aspose.Slides?**  

В Aspose.Slides Slide Master представляется интерфейсом [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/). Доступ к Slide Master можно получить через метод [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) объекта [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).