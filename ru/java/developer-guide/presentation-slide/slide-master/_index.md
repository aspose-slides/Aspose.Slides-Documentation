---
title: Управление мастерами слайдов презентации в Java
linktitle: Мастер слайда
type: docs
weight: 70
url: /ru/java/slide-master/
keywords:
- мастер слайда
- основной слайд
- PPT мастер слайда
- несколько мастер слайдов
- сравнение мастер слайдов
- фон
- заполнитель
- клонирование мастер слайда
- копирование мастер слайда
- дублирование мастер слайда
- неиспользуемый мастер слайда
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте мастерами слайдов в Aspose.Slides для Java: создавайте, редактируйте и применяйте макеты, темы и заполнитель к PPT, PPTX и ODP с лаконичными примерами Java."
---

## **Что такое мастер слайдов в PowerPoint**

**Мастер слайдов** — это шаблон слайда, определяющий макет, стили, тему, шрифты, фон и другие свойства слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) в едином стиле и шаблоне для вашей компании, используйте мастер слайдов.  

Мастер слайдов полезен, потому что позволяет установить и изменить внешний вид всех слайдов презентации сразу. Aspose.Slides поддерживает механизм мастера слайдов из PowerPoint.  

VBA также позволяет управлять мастером слайдов и выполнять те же операции, поддерживаемые в PowerPoint: изменять фон, добавлять формы, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы, позволяющие использовать мастера слайдов и выполнять базовые задачи с ними.  

Это базовые операции с мастером слайдов:

- Создать мастер слайдов.  
- Применить мастер слайдов к слайдам презентации.  
- Изменить фон мастера слайдов.  
- Добавить изображение, заполнитель, Smart Art и т.п. в мастер слайдов.  

Это более продвинутые операции с мастером слайдов:  

- Сравнить мастера слайдов.  
- Объединить мастера слайдов.  
- Применить несколько мастеров слайдов.  
- Скопировать слайд с мастером слайдов в другую презентацию.  
- Найти дублирующиеся мастера слайдов в презентациях.  
- Установить мастер слайдов как представление по умолчанию в презентации.  

{{% alert color="primary" %}} 
Возможно, вам будет интересно ознакомиться с Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer), так как это живой пример некоторых основных процессов, описанных здесь.
{{% /alert %}} 

## **Как применяется мастер слайдов**

Прежде чем работать с мастером слайдов, вам следует понять, как они используются в презентациях и применяются к слайдам.  

* Каждая презентация содержит как минимум один мастер слайдов по умолчанию.  
* Презентация может содержать несколько мастеров слайдов. Вы можете добавить несколько мастеров слайдов и использовать их для оформления разных частей презентации различными способами.  

В **Aspose.Slides** мастер слайдов представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).  

Объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) содержит список [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), в котором находятся все мастера слайдов, определённые в презентации.  

Помимо CRUD‑операций, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) содержит полезные методы: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) и [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . Эти методы унаследованы от базовой функции клонирования слайдов. При работе с мастерами слайдов они позволяют реализовывать сложные настройки.  

Когда в презентацию добавляется новый слайд, к нему автоматически применяется мастер слайдов. По умолчанию выбирается мастер слайдов предыдущего слайда.  

**Примечание**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) , и каждый новый слайд по умолчанию добавляется в конец коллекции. Если презентация содержит единственный мастер слайдов, этот мастер используется для всех новых слайдов. Поэтому вам не нужно задавать мастер слайдов для каждого нового слайда.  

Принцип тот же в PowerPoint и Aspose.Slides. Например, в PowerPoint, когда вы добавляете новый слайд, достаточно щёлкнуть по нижней линии под последним слайдом, и будет создан новый слайд (с мастером слайдов последней презентации):  

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить аналогичную задачу с помощью метода [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).  

## **Мастер слайдов в иерархии слайдов**

Использование макетов слайдов вместе с мастером слайдов обеспечивает максимальную гибкость. Макет слайда позволяет задавать те же стили, что и мастер слайдов (фон, шрифты, фигуры и т.д.). Однако когда несколько макетов слайдов объединяются в мастере слайдов, создаётся новый стиль. При применении макета слайда к отдельному слайду вы можете изменить его стиль по сравнению с тем, что задан мастером слайдов.  

Мастер слайдов имеет более высокий приоритет, чем остальные элементы: Мастер слайдов → Макет слайда → Слайд:  

![todo:image_alt_text](slide-master_2)

Каждый объект [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) со списком макетов слайдов. Тип [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) со ссылкой на макет слайда, применённый к слайду. Взаимодействие между слайдом и мастером слайдов происходит через макет слайда.  

{{% alert color="info" title="Note" %}}
* В Aspose.Slides все настройки слайдов (мастер слайдов, макет слайда и сам слайд) фактически являются объектами слайдов, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).  

* Поэтому мастер слайдов и макет слайда могут иметь одинаковые свойства, и вам необходимо знать, как их значения будут применяться к объекту [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). Сначала к слайду применяется мастер слайдов, затем — макет слайда. Например, если и у мастера слайдов, и у макета слайда задан фон, в итоге слайд получит фон из макета слайда.  
{{% /alert %}}

## **Что содержит мастер слайдов**

Чтобы понять, как можно изменить мастер слайдов, необходимо знать его составные части. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/).  

- [getBackground] — получить/установить фон слайда.  
- [getBodyStyle] — получить/установить стили текста основной части слайда.  
- [getShapes] — получить/установить все фигуры мастера слайдов (заполнители, рамки изображений и т.д.).  
- [getControls] — получить/установить элементы управления ActiveX.  
- [getThemeManager] — получить менеджер тем.  
- [getHeaderFooterManager] — получить менеджер колонтитулов.  

Методы мастера слайдов:  

- [getDependingSlides] — получить все слайды, зависящие от мастера слайдов.  
- [applyExternalThemeToDependingSlides] — позволяет создать новый мастер слайдов на основе текущего мастера и новой темы. Новый мастер будет применён ко всем зависимым слайдам.  

## **Получить мастер слайдов**

В PowerPoint мастер слайдов можно открыть через меню Вид → Мастер слайдов:  

![todo:image_alt_text](slide-master_3.jpg)

С помощью Aspose.Slides вы можете получить мастер слайдов следующим образом:  
```java
Presentation pres = new Presentation();
try {
    // Предоставляет доступ к мастер-слайду презентации
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Интерфейс [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) представляет мастер слайдов. Свойство [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (относящееся к типу [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) содержит список всех мастеров слайдов, определённых в презентации.  

## **Добавить изображение в мастер слайдов**

Когда вы добавляете изображение в мастер слайдов, оно появляется на всех слайдах, зависящих от этого мастера.  

Вы можете добавить изображения в мастер слайдов с помощью Aspose.Slides:  
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
Для получения дополнительной информации о добавлении изображений на слайд см. статью [Picture Frame](/slides/ru/java/picture-frame/#create-picture-frame).  
{{% /alert %}}  

## **Добавить заполнитель в мастер слайдов**

Эти текстовые поля являются стандартными заполнителями на мастере слайдов:  

* Щёлкните, чтобы отредактировать стиль заголовка мастера  
* Отредактировать стили текста мастера  
* Второй уровень  
* Третий уровень  

Они также отображаются на слайдах, основанных на мастере слайдов. Вы можете редактировать эти заполняющие элементы в мастере слайдов, и изменения автоматически применятся к слайдам.  

В PowerPoint вы можете добавить заполнитель через путь Мастер слайдов → Вставить заполнитель:  

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Предположим слайд с заполнителями, шаблонными из мастера слайдов:  

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование Заголовка и Подзаголовка в мастере слайдов следующим образом:  

![todo:image_alt_text](slide-master_7.png)

Сначала мы получаем содержимое заполнительного поля заголовка из объекта мастера слайдов, а затем используем поле `PlaceHolder.FillFormat`:  
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


Стиль и форматирование заголовка изменятся для всех слайдов, основанных на мастере слайдов:  

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* Установить подсказку в заполнитель  
* Форматирование текста  
{{% /alert %}}  

## **Изменить фон в мастере слайдов**

Когда вы меняете цвет фона мастера слайда, все обычные слайды в презентации получают новый цвет. Этот пример кода на Java демонстрирует операцию:  
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
- Фон презентации  
- Тема презентации  
{{% /alert %}}  

## **Клонировать мастер слайдов в другую презентацию**

Чтобы клонировать мастер слайдов в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) из целевой презентации, передав в него мастер слайдов. Этот пример кода на Java показывает, как клонировать мастер слайдов в другую презентацию:  
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```
  

## **Добавить несколько мастеров слайдов в презентацию**

Aspose.Slides позволяет добавлять несколько мастеров слайдов и макетов слайдов в любую презентацию. Это дает возможность настраивать стили, макеты и параметры форматирования слайдов различными способами.  

В PowerPoint новые мастера слайдов и макеты (из меню «Мастер слайдов») можно добавить так:  

![todo:image_alt_text](slide-master_9.jpg)

С помощью Aspose.Slides можно добавить новый мастер слайдов, вызвав метод [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):  
```java
// Добавляет новый мастер слайд
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```
  

## **Сравнить мастеры слайдов**

Мастер‑слайд реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) , содержащий метод [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) , который можно использовать для сравнения слайдов. Он возвращает `true` для мастеров‑слайдов, идентичных по структуре и статическому содержимому.  

Два мастера‑слайда считаются равными, если их фигуры, стили, тексты, анимация и другие параметры одинаковы. При сравнении не учитываются уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущая дата в заполняющем элементе даты).  

## **Установить мастер слайдов как представление презентации по умолчанию**

Aspose.Slides позволяет установить мастер слайдов как представление по умолчанию для презентации. Это представление отображается первым при открытии презентации.  

Этот пример кода показывает, как в Java установить мастер слайдов как представление по умолчанию презентации:  
```java
// Создаёт экземпляр класса Presentation, представляющего файл презентации
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
  

## **Удалить неиспользуемые мастера слайдов**

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (из класса [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)), позволяющий удалять ненужные и неиспользуемые мастера слайдов. Этот пример кода на Java показывает, как удалить мастер‑слайд из презентации PowerPoint:  
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

**Что такое мастер слайдов в PowerPoint?**  
Мастер слайдов — это шаблон слайда, определяющий макет, стили, темы, шрифты, фон и другие свойства слайдов в презентации. Он позволяет установить и изменить внешний вид всех слайдов презентации одновременно.  

**Как применяется мастер слайдов в презентации?**  
Каждая презентация имеет как минимум один мастер слайдов по умолчанию. При добавлении нового слайда к нему автоматически применяется мастер слайдов, обычно наследующийся от мастера предыдущего слайда. Презентация может содержать несколько мастеров слайдов для уникального оформления разных частей.  

**Какие элементы можно настроить в мастере слайдов?**  
Мастер слайдов состоит из нескольких основных свойств, которые можно настраивать:  

- **Background**: задаёт фон слайда.  
- **BodyStyle**: определяет стили текста основной части слайда.  
- **Shapes**: управляет всеми фигурами мастера, включая заполняющие элементы и рамки изображений.  
- **Controls**: работа с элементами управления ActiveX.  
- **ThemeManager**: доступ к менеджеру тем.  
- **HeaderFooterManager**: управление колонтитулами.  

**Как добавить изображение в мастер слайдов?**  
Добавление изображения в мастер слайдов гарантирует его появление на всех слайдах, зависящих от этого мастера. Например, разместив логотип компании в мастере, вы увидите его на каждом слайде презентации.  

**Как мастеры слайдов соотносятся с макетами слайдов?**  
Макеты слайдов работают совместно с мастерами слайдов, обеспечивая гибкость в дизайне. Мастер определяет глобальные стили и темы, а макет позволяет варьировать расположение контента. Иерархия следующая:  

- **Мастер слайдов** → определяет глобальные стили.  
- **Макет слайда** → предоставляет различные варианты расположения контента.  
- **Слайд** → наследует дизайн от своего макета.  

**Можно ли иметь несколько мастеров слайдов в одной презентации?**  
Да, презентация может содержать несколько мастеров слайдов. Это позволяет оформлять разные разделы презентации по‑разному, предоставляя гибкость в дизайне.  

**Как получить доступ к мастеру слайдов и изменить его с помощью Aspose.Slides?**  
В Aspose.Slides мастер слайдов представлен интерфейсом [IMasterSlide]. Вы можете получить доступ к мастеру слайдов с помощью метода [getMasters] объекта [Presentation].