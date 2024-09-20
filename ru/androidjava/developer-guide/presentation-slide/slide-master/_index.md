---
title: Слайд Мастер
type: docs
weight: 70
url: /androidjava/slide-master/
keywords: "Добавить Слайд Мастер, PPT мастер-слайд, слайд мастер PowerPoint, Изображение в Слайд Мастер, Заполнитель, Несколько Слайд Мастеров, Сравнить Слайд Мастера, Java, Aspose.Slides для Android через Java"
description: "Добавить или редактировать слайд мастер в презентации PowerPoint на Java"
---

## **Что такое Слайд Мастер в PowerPoint**

**Слайд Мастер** – это шаблон слайда, который определяет макет, стили, тему, шрифты, фон и другие свойства для слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать слайд мастер. 

Слайд Мастер полезен, потому что позволяет задать и изменить внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм Слайда Мастера из PowerPoint. 

VBA также позволяет манипулировать Слайд Мастером и выполнять те же операции, которые поддерживаются в PowerPoint: менять фоны, добавлять фигуры, настраивать макет и т. д. Aspose.Slides предоставляет гибкие механизмы, позволяя вам использовать Слайд Мастера и выполнять с ними основные задачи. 

Вот основные операции с Слайд Мастером:

- Создать или редактировать Слайд Мастер.
- Применить Слайд Мастер к слайдам презентации.
- Изменить фон Слайда Мастера. 
- Добавить изображение, заполнитель, умное искусство и т. д. к Слайд Мастеру.

Это более сложные операции со Слайд Мастером:

- Сравнить Слайд Мастера.
- Объединить Слайд Мастера.
- Применить несколько Слайд Мастеров.
- Скопировать слайд с Слайд Мастером в другую презентацию.
- Найти дублирующиеся Слайд Мастера в презентациях.
- Установить Слайд Мастер в качестве представления по умолчанию для презентации.

{{% alert color="primary" %}} 

Вам может быть интересно ознакомиться с Aspose [**Онлайн-Просмотрщиком PowerPoint**](https://products.aspose.app/slides/viewer), так как это живое приложение некоторых основных процессов, описанных здесь.

{{% /alert %}} 


## **Как применяется Слайд Мастер**

Прежде чем работать со Слайд Мастером, вам может быть полезно понять, как они используются в презентациях и применяются к слайдам. 

* Каждая презентация по умолчанию имеет как минимум один Слайд Мастер. 
* Презентация может содержать несколько Слайд Мастеров. Вы можете добавить несколько Слайд Мастеров и использовать их для стилизации различных частей презентации разными способами. 

В **Aspose.Slides** Слайд Мастер представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

Объект [Презентации](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Aspose.Slides содержит список [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), который содержит список всех мастер-слайдов, определенных в презентации.

Помимо операций CRUD, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) содержит полезные методы: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) и [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Эти методы унаследованы от базовой функции клонирования слайдов, но при работе с Слайд Мастерами они позволяют реализовать сложные настройки.

Когда новый слайд добавляется в презентацию, Слайд Мастер автоматически применяется к нему. По умолчанию выбирается Слайд Мастер предыдущего слайда. 

**Примечание**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) и каждый новый слайд по умолчанию добавляется в конец коллекции. Если презентация содержит только один Слайд Мастер, он выбирается для всех новых слайдов. Эта причина, почему вам не нужно определять Слайд Мастер для каждого нового слайда, который вы создаете.

Принцип остается тем же для PowerPoint и Aspose.Slides. Например, в PowerPoint, когда вы добавляете новую презентацию, вы можете просто нажать на нижнюю линию под последним слайдом, и затем будет создан новый слайд (с последним Слайд Мастером):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить эквивалентную задачу с помощью метода [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) класса [Презентация](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).


## **Слайд Мастер в иерархии Слайдов**

Использование Макетов Слайдов с Слайд Мастером позволяет обеспечить максимальную гибкость. Макет Слайда позволяет установить все те же стили, что и Слайд Мастер (фон, шрифты, фигуры и т. д.). Однако, когда несколько Макетов Слайдов комбинируются на Слайд Мастере, создается новый стиль. Когда вы применяете Макет Слайда к одному слайду, вы можете изменить его стиль по сравнению с тем, который применен Слайд Мастером.

Слайд Мастер превосходит все элементы настроек: Слайд Мастер -> Макет Слайда -> Слайд:

![todo:image_alt_text](slide-master_2)



Каждый объект [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) с списком Макетов Слайдов. Тип [Слайд](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) с ссылкой на Макет Слайда, примененный к слайду. Взаимодействие между слайдом и Слайд Мастером происходит через Макет Слайда.

{{% alert color="info" title="Примечание" %}}

* В Aspose.Slides все настройки слайдов (Слайд Мастер, Макет Слайда и сам слайд) фактически являются объектами слайдов, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide).
* Таким образом, Слайд Мастер и Макет Слайда могут реализовывать одни и те же свойства, и вам нужно знать, как их значения будут применяться к объекту [Слайд](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide). Сначала к слайду применяется Слайд Мастер, а затем применяется Макет Слайда. Например, если Слайд Мастер и Макет Слайда оба имеют значение фона, Слайд в итоге получит фон из Макета Слайда.

{{% /alert %}}


## **Что включает в себя Слайд Мастер**

Чтобы понять, как можно изменить Слайд Мастер, вам нужно знать его составляющие. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) получить/установить фон слайда.
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) - получить/установить текстовые стили тела слайда.
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) получить/установить все фигуры Слайда Мастера (заполнители, рамки для изображений и т. д.).
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) получить/установить элементы управления ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) - получить менеджера тем.
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - получить менеджера заголовков и подвалов.

Методы Слайда Мастера:

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) - получить все слайды, зависящие от Слайда Мастера.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - позволяет вам создать новый Слайд Мастер на основе текущего Слайда Мастера и новой темы. Новый Слайд Мастер будет затем применен ко всем зависимым слайдам.


## **Получить Слайд Мастер**

В PowerPoint Слайд Мастер можно получить из меню Вид -> Слайд Мастер:

![todo:image_alt_text](slide-master_3.jpg)



Используя Aspose.Slides, вы можете получить Слайд Мастер следующим образом: 

```java
Presentation pres = new Presentation();
try {
    // Получает доступ к мастер-слайду Презентации
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

Интерфейс [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) представляет собой Слайд Мастер. Свойство [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (связанное с типом [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)) содержит список всех Слайд Мастеров, определенных в презентации. 


## **Добавить изображение в Слайд Мастер**

Когда вы добавляете изображение в Слайд Мастер, это изображение появится на всех слайдах, зависящих от этого слайда мастера. 

Например, вы можете разместить логотип вашей компании и несколько изображений на Слайд Мастере, а затем вернуться в режим редактирования слайдов. Вы должны увидеть изображение на каждом слайде. 

![todo:image_alt_text](slide-master_4.png)

Вы можете добавлять изображения в слайд мастер с помощью Aspose.Slides:

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

{{% alert color="primary" title="Смотрите также" %}} 

Для получения дополнительной информации о добавлении изображений на слайд, смотрите статью [Рамка для изображения](/slides/androidjava/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Добавить заполнитель в Слайд Мастер**

Эти текстовые поля являются стандартными заполнителями на Слайд Мастере: 

* Нажмите, чтобы изменить стиль заголовка Мастера

* Изменить текстовые стили Мастера

* Второй уровень

* Третий уровень 

Они также появляются на слайдах, основанных на Слайд Мастере. Вы можете редактировать эти заполнители на Слайд Мастере, и изменения автоматически применяются к слайдам. 

В PowerPoint вы можете добавить заполнитель через путь Слайд Мастер -> Вставить Заполнитель:



![todo:image_alt_text](slide-master_5.png)



Рассмотрим более сложный пример для заполнителей с помощью Aspose.Slides. Рассмотрим слайд с заполнителями, шаблонированными с Слайда Мастера:



![todo:image_alt_text](slide-master_6.png)



Мы хотим изменить форматирование заголовка и подзаголовка на Слайд Мастере таким образом:

![todo:image_alt_text](slide-master_7.png)



Сначала мы получаем содержимое заполнителя заголовка из объекта Слайда Мастера и затем используем поле `PlaceHolder.FillFormat`: 

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

Стиль заголовка и форматирование изменятся для всех слайдов, основанных на слайде мастере:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Смотрите также" %}} 

* [Установить текст подсказки в заполнителе](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [Форматирование текста](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}


## **Изменить фон на Слайд Мастере**

Когда вы изменяете цвет фона мастер-слайда, все обычные слайды в презентации получат новый цвет. Этот код на Java демонстрирует операцию:

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

{{% alert color="primary" title="Смотрите также" %}} 

- [Фон Презентации](https://docs.aspose.com/slides/androidjava/presentation-background/)

- [Тема Презентации](https://docs.aspose.com/slides/androidjava/presentation-theme/)

  {{% /alert %}}

## **Клонировать Слайд Мастер в другую презентацию**

Чтобы клонировать Слайд Мастер в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) из целевой презентации вместе с переданным в него Слайд Мастером. Этот код на Java показывает, как клонировать Слайд Мастер в другую презентацию:

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **Добавить несколько Слайд Мастеров в Презентацию**

Aspose.Slides позволяет добавлять несколько Слайд Мастеров и Макетов Слайдов в любую данную презентацию. Это позволяет настраивать стили, макеты и параметры форматирования для слайдов презентации различными способами. 

В PowerPoint вы можете добавить новые Слайд Мастера и Макеты (из меню "Слайд Мастер) таким образом:

![todo:image_alt_text](slide-master_9.jpg)

Используя Aspose.Slides, вы можете добавить новый Слайд Мастер, вызвав метод [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):

```java
// Добавляет новый мастер-слайд
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **Сравнить Слайд Мастера**

Слайд Мастер реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide), который содержит метод [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), который затем можно использовать для сравнения слайдов. Он возвращает `true` для мастер-слайдов, идентичных по структуре и статическому содержимому.

Два мастер-слайда равны, если их фигуры, стили, тексты, анимация и другие настройки и т. д. равны. Сравнение не учитывает уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущее значение даты в Заполнителе даты). 


## **Установить Слайд Мастер в качестве представления по умолчанию для Презентации**

Aspose.Slides позволяет установить Слайд Мастер в качестве представления по умолчанию для презентации. Представление по умолчанию – это то, что вы видите в первую очередь, когда открываете презентацию. 

Этот код показывает, как установить Слайд Мастер в качестве представления по умолчанию для презентации на Java:

```java
// Инстанцирует класс Презентации, представляющий файл презентации
Presentation presentation = new Presentation();
try {
    // Устанавливает Представление по умолчанию как SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // Сохраняет презентацию
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Удалить неиспользуемый Мастер Слайд**

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (из класса [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)), чтобы позволить вам удалить ненужные и неиспользуемые мастер-слайды. Этот код на Java показывает, как удалить мастер-слайд из презентации PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```