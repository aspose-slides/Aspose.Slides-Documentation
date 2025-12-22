---
title: Управление мастер‑слайдами презентаций на Android
linktitle: Мастер слайда
type: docs
weight: 70
url: /ru/androidjava/slide-master/
keywords:
- мастер слайдов
- мастер слайд
- мастер слайд PPT
- несколько мастеров слайдов
- сравнение мастеров слайдов
- фон
- заполнитель
- клонирование мастера слайда
- копирование мастера слайда
- дублирование мастера слайда
- неиспользуемый мастер слайд
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управление мастерами слайдов в Aspose.Slides для Android: создание, редактирование и применение макетов, тем и заполнителей к PPT, PPTX и ODP с лаконичными примерами на Java."
---

## **Что такое мастер‑слайдов в PowerPoint**

**Мастер‑слайдов** — это шаблон слайда, определяющий макет, стили, тему, шрифты, фон и другие свойства слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) в едином стиле и шаблоне для вашей компании, вы можете использовать мастер‑слайдов.

Мастер‑слайдов полезен, поскольку позволяет единовременно задать и изменить внешний вид всех слайдов презентации. Aspose.Slides поддерживает механизм мастера‑слайдов из PowerPoint.

VBA также позволяет управлять мастером‑слайдов и выполнять те же операции, что поддерживаются в PowerPoint: менять фон, добавлять фигуры, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы для работы с мастерами‑слайдов и выполнения базовых задач.

Это базовые операции с мастером‑слайдов:

- Создать или удалить мастер‑слайдов.
- Применить мастер‑слайдов к слайдам презентации.
- Изменить фон мастера‑слайдов. 
- Добавить изображение, заполнитель, Smart Art и т.п. к мастеру‑слайдов.

Это более продвинутые операции с мастером‑слайдов: 

- Сравнить мастеры‑слайдов.
- Объединить мастеры‑слайдов.
- Применить несколько мастеров‑слайдов.
- Скопировать слайд с мастером‑слайдов в другую презентацию.
- Найти дублирующие мастеры‑слайдов в презентациях.
- Установить мастер‑слайдов как представление презентации по умолчанию.

{{% alert color="primary" %}} 

Возможно, вам будет интересен Aspose [**Онлайн‑просмотрщик PowerPoint**](https://products.aspose.app/slides/viewer), поскольку это живой пример некоторых основных процессов, описанных здесь.

{{% /alert %}} 


## **Как применяется мастер‑слайдов**

Прежде чем работать с мастером‑слайдов, стоит понять, как они используются в презентациях и применяются к слайдам. 

* Каждая презентация по умолчанию имеет хотя бы один мастер‑слайдов. 
* Презентация может содержать несколько мастеров‑слайдов. Вы можете добавить несколько мастеров‑слайдов и использовать их для оформления разных частей презентации разными способами. 

В **Aspose.Slides** мастер‑слайдов представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

Объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Aspose.Slides содержит список [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), который хранит все мастера‑слайдов, определённые в презентации.

Помимо CRUD‑операций, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) предоставляет полезные методы: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) и [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Эти методы унаследованы от базовой функции клонирования слайдов, но при работе с мастерами‑слайдов позволяют реализовать сложные сценарии.

Когда в презентацию добавляется новый слайд, к нему автоматически применяется мастер‑слайдов. По умолчанию выбирается мастер‑слайдов предыдущего слайда. 

**Примечание**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--), и каждый новый слайд добавляется в конец коллекции. Если презентация содержит один мастер‑слайдов, он будет выбран для всех новых слайдов. Поэтому вам не требуется задавать мастер‑слайдов для каждого нового слайда.

Принцип тот же в PowerPoint и Aspose.Slides. Например, в PowerPoint, добавив новый слайд, вы просто щёлкаете под последним слайдом, и появляется новый слайд (с мастером‑слайдов предыдущей презентации):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides аналогичную задачу можно выполнить с помощью метода [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).


## **Мастер‑слайдов в иерархии Slides**

Комбинация макетов слайдов с мастером‑слайдов обеспечивает максимальную гибкость. Макет слайда позволяет задать те же стили, что и мастер‑слайдов (фон, шрифты, фигуры и т.п.). Однако при сочетании нескольких макетов слайдов на одном мастере‑слайдов формируется новый стиль. Применив макет к отдельному слайду, вы можете изменить его стиль, отличающийся от стиля, заданного мастером‑слайдов.

Мастер‑слайдов превалирует над всеми элементами настройки: Мастер‑слайдов → Макет слайда → Слайд:

![todo:image_alt_text](slide-master_2)



Каждый объект [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) — список макетов слайдов. Тип [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) — ссылку на применённый к слайду макет. Взаимодействие между слайдом и мастером‑слайтов происходит через макет слайда.

{{% alert color="info" title="Примечание" %}}

* В Aspose.Slides все настройки слайда (мастер‑слайдов, макет слайда и сам слайд) являются объектами, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide).
* Поэтому мастер‑слайдов и макет слайда могут иметь одинаковые свойства, и важно понимать, как их значения применяются к объекту [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide). Сначала к слайду применяется мастер‑слайдов, затем — макет слайда. Например, если у мастера‑слайдов и макета указано значение фона, окончательный фон будет взят из макета слайда.

{{% /alert %}}


## **Что содержит мастер‑слайдов**

Чтобы понять, как можно изменить мастер‑слайдов, нужно знать его составные части. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) — получить/установить фон слайда.
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) — получить/установить стили текста тела слайда.
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) — получить/установить все фигуры мастера‑слайдов (заполнители, рамки изображений и т.п.).
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) — получить/установить элементы управления ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) — получить менеджер тем.
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) — получить менеджер заголовков и нижних колонтитулов.

Методы мастера‑слайдов:

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) — получить все слайды, зависящие от данного мастера‑слайдов.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) — позволяет создать новый мастер‑слайдов на основе текущего и новой темы; новый мастер будет применён ко всем зависимым слайдам.


## **Получение мастер‑слайдов**

В PowerPoint мастер‑слайдов доступен через меню Вид → Мастер‑слайдов:

![todo:image_alt_text](slide-master_3.jpg)



В Aspose.Slides вы можете получить доступ к мастеру‑слайдов так:
```java
Presentation pres = new Presentation();
try {
    // Предоставляет доступ к мастер‑слайду презентации
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Интерфейс [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) представляет мастер‑слайдов. Свойство [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (связано с типом [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)) содержит список всех мастеров‑слайдов, определённых в презентации.


## **Добавление изображения в мастер‑слайдов**

Когда вы добавляете изображение в мастер‑слайдов, оно появляется на всех слайдах, зависящих от этого мастера.

Например, разместив логотип компании и несколько изображений на мастере‑слайдов, затем вернувшись к режиму редактирования слайда, вы увидите эти изображения на каждом слайде.

![todo:image_alt_text](slide-master_4.png)

Добавить изображения в мастер‑слайдов с помощью Aspose.Slides можно так:
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

Подробности о добавлении изображений в слайд смотрите в статье [Picture Frame](/slides/ru/androidjava/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Добавление заполнителя в мастер‑слайдов**

Это стандартные текстовые заполнители на мастере‑слайдов: 

* Щелкните, чтобы отредактировать стиль заголовка мастера
* Отредактировать стили текста мастера
* Второй уровень
* Третий уровень 

Они также появляются на слайдах, основанных на мастере‑слайдов. Вы можете редактировать эти заполнители в мастере‑слайдов, и изменения автоматически применятся к слайдам.

В PowerPoint добавить заполнитель можно через путь Мастер‑слайдов → Вставить заполнитель:

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Предположим, есть слайд с заполнителями, полученными из мастера‑слайдов:

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование заголовка и подзаголовка в мастере‑слайдов следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала получаем содержимое заполнителя заголовка из объекта мастер‑слайдов и используем поле `PlaceHolder.FillFormat`:
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


Стиль и форматирование заголовка изменятся на всех слайдах, основанных на данном мастере‑слайдов:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="См. также" %}} 

* [Установка текста подсказки в заполнителе](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [Форматирование текста](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}


## **Изменение фона в мастере‑слайдов**

Если изменить цвет фона мастер‑слайда, все обычные слайды презентации получат новый цвет. Ниже пример кода на Java, демонстрирующий эту операцию:
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

- [Фон презентации](https://docs.aspose.com/slides/androidjava/presentation-background/)
- [Тема презентации](https://docs.aspose.com/slides/androidjava/presentation-theme/)

{{% /alert %}}

## **Клонирование мастера‑слайдов в другую презентацию**

Чтобы клонировать мастер‑слайдов в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) у целевой презентации, передав в него мастер‑слайдов. Пример Java‑кода:

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```



## **Добавление нескольких мастеров‑слайдов в презентацию**

Aspose.Slides позволяет добавить несколько мастеров‑слайдов и макетов слайдов в любую презентацию. Это дает возможность задавать стили, макеты и параметры форматирования слайдов многими способами.

В PowerPoint новые мастеры‑слайдов и макеты можно добавить так (из меню «Мастер‑слайдов»):

![todo:image_alt_text](slide-master_9.jpg)

В Aspose.Slides новый мастер‑слайдов добавляется вызовом метода [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):
```java
// Добавляет новый мастер‑слайд
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Сравнение мастеров‑слайдов**

Мастер‑слайдов реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide), содержащий метод [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), который можно использовать для сравнения слайдов. Он возвращает `true`, если мастера‑слайдов идентичны по структуре и статическому содержимому.

Два мастера‑слайдов считаются равными, если их фигуры, стили, тексты, анимация и другие настройки совпадают. При сравнении не учитываются уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущая дата в заполнителе даты).


## **Установка мастера‑слайдов как представления презентации по умолчанию**

Aspose.Slides позволяет установить мастер‑слайдов в качестве представления по умолчанию для презентации. Это то, что будет отображаться первым при открытии файла.

Пример кода на Java, показывающий, как установить мастер‑слайдов как представление по умолчанию:

```java
// Создаёт экземпляр класса Presentation, который представляет файл презентации
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



## **Удаление неиспользуемых мастеров‑слайдов**

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (из класса [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)), позволяющий удалять ненужные и неиспользуемые мастера‑слайдов. Пример Java‑кода:

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

**Что такое мастер‑слайдов в PowerPoint?**

Мастер‑слайдов — это шаблон слайда, определяющий макет, стили, темы, шрифты, фон и другие свойства слайдов в презентации. Он позволяет единовременно задать и изменить внешний вид всех слайдов.

**Как применяется мастер‑слайдов в презентации?**

Каждая презентация имеет как минимум один мастер‑слайдов. При добавлении нового слайда к нему автоматически применяется мастер‑слайдов, обычно наследующий мастер предыдущего слайда. Презентация может содержать несколько мастеров‑слайдов для индивидуального оформления разных частей.

**Какие элементы можно настраивать в мастере‑слайдов?**

Мастер‑слайдов состоит из нескольких основных свойств, которые можно настраивать:

- **Background**: задаёт фон слайда.
- **BodyStyle**: определяет стили текста тела слайда.
- **Shapes**: управляет всеми фигурами мастера, включая заполнители и рамки изображений.
- **Controls**: работа с элементами управления ActiveX.
- **ThemeManager**: доступ к менеджеру тем.
- **HeaderFooterManager**: управление заголовками и нижними колонтитулами.  

**Как добавить изображение в мастер‑слайдов?**

Добавление изображения в мастер‑слайдов гарантирует его появление на всех слайдах, зависящих от этого мастера. Например, разместив логотип компании на мастере, он будет отображаться на каждом слайде презентации.

**Как мастера‑слайдов соотносятся с макетами слайдов?**

Макеты слайдов работают совместно с мастерами‑слайдов, обеспечивая гибкость дизайна. Мастер‑слайдов задаёт глобальные стили и темы, а макет позволяет варьировать расположение содержимого. Иерархия выглядит так:

- **Мастер‑слайдов** → задаёт глобальные стили.
- **Макет слайда** → предоставляет разные варианты расположения контента.
- **Слайд** → наследует дизайн от своего макета.

**Можно ли иметь несколько мастеров‑слайдов в одной презентации?**

Да, презентация может содержать несколько мастеров‑слайдов. Это позволяет оформлять различные разделы презентации по‑разному, обеспечивая большую гибкость дизайна.

**Как получить доступ к мастеру‑слайдов и изменить его с помощью Aspose.Slides?**

В Aspose.Slides мастер‑слайдов представлен интерфейсом [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/). Доступ к нему можно получить через метод [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) объекта [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).