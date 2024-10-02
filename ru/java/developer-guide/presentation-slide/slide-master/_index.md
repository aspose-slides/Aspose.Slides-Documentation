---
title: Слайд Мастер
type: docs
weight: 70
url: /ru/java/slide-master/
keywords: "Добавить Слайд Мастер, PPT мастер-слайд, слайд мастер PowerPoint, Изображение в Слайд Мастер, Заполнитель, Несколько Слайд Мастеров, Сравнение Слайд Мастеров, Java, Aspose.Slides для Java"
description: "Добавьте или измените слайд мастер в презентации PowerPoint на Java"
---

## **Что такое Слайд Мастер в PowerPoint**

**Слайд Мастер** - это шаблон слайда, который определяет макет, стили, тему, шрифты, фон и другие свойства для слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать слайд мастер.

Слайд Мастер полезен, потому что позволяет устанавливать и изменять внешний вид всех слайдов презентации сразу. Aspose.Slides поддерживает механизм Слайда Мастера от PowerPoint.

VBA также позволяет манипулировать Слайд Мастером и выполнять те же операции, которые поддерживаются в PowerPoint: изменять фоны, добавлять фигуры, настраивать макет и т. д. Aspose.Slides предоставляет гибкие механизмы, которые позволяют использовать Слайды Мастера и выполнять с ними основные задачи.

Это основные операции с Слайдом Мастером:

- Создать или Слайд Мастер.
- Применить Слайд Мастер к слайдам презентации.
- Изменить фон Слайда Мастера.
- Добавить изображение, заполнитель, смарт-арт и т. д. в Слайд Мастер.

Это более сложные операции с Слайд Мастером:

- Сравнить Слайды Мастера.
- Объединить Слайды Мастера.
- Применить несколько Слайдов Мастеров.
- Скопировать слайд с Слайд Мастером в другую презентацию.
- Найти дублирующиеся Слайды Мастера в презентациях.
- Установить Слайд Мастер как представление по умолчанию для презентации.

{{% alert color="primary" %}} 

Вам может быть интересно взглянуть на Aspose [**Онлайн Просмотрщик PowerPoint**](https://products.aspose.app/slides/viewer), так как это живое приложение некоторых основных процессов, описанных здесь.

{{% /alert %}} 


## **Как применяется Слайд Мастер**

Перед тем как работать с Слайд Мастером, вам может быть полезно понять, как они используются в презентациях и применяются к слайдам.

* Каждая презентация по умолчанию имеет хотя бы один Слайд Мастер.
* Презентация может содержать несколько Слайдов Мастеров. Вы можете добавить несколько Слайдов Мастеров и использовать их для стилизации различных частей презентации разными способами.

В **Aspose.Slides** Слайд Мастер представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).

Объект [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) содержит список [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), который содержит список всех мастер-слайдов, определенных в презентации.

Кроме операций CRUD интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) содержит несколько полезных методов: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) и [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Эти методы наследуются от основной функции клонирования слайдов. Но когда дело доходит до Слайдов Мастеров, эти методы позволяют реализовать сложные настройки.

Когда новый слайд добавляется в презентацию, к нему автоматически применяется Слайд Мастер. По умолчанию выбирается Слайд Мастер предыдущего слайда.

**Примечание**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--), и каждый новый слайд по умолчанию добавляется в конец коллекции. Если презентация содержит единственный Слайд Мастер, этот слайд мастер выбирается для всех новых слайдов. Именно поэтому вам не нужно определять Слайд Мастер для каждого нового слайда, который вы создаете.

Принцип такой же как для PowerPoint, так и для Aspose.Slides. Например, в PowerPoint, когда вы добавляете новую презентацию, вы можете просто нажать на нижнюю строку под последним слайдом, и затем будет создан новый слайд (с Слайд Мастером последней презентации):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить эквивалентную задачу с помощью метода [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) класса [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).


## **Слайд Мастер в иерархии Слайдов**

Использование Макетов Слайдов с Слайд Мастером обеспечивает максимальную гибкость. Макет Слайда позволяет установить все те же стили, что и Слайд Мастер (фон, шрифты, фигуры и т. д.). Однако, когда несколько Макетов Слайдов комбинируются на Слайд Мастере, создается новый стиль. Когда вы применяете Макет Слайда к одиночному слайду, вы можете изменить его стиль по сравнению с тем, который применен Слайд Мастером.

Слайд Мастер имеет приоритет над всеми настройками: Слайд Мастер -> Макет Слайда -> Слайд:

![todo:image_alt_text](slide-master_2)



Каждый объект [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) с списком Макетов Слайдов. Объект типа [Слайд](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) с ссылкой на Макет Слайда, примененный к слайду. Взаимодействие между слайдом и Слайд Мастером происходит через Макет Слайда.

{{% alert color="info" title="Примечание" %}}

* В Aspose.Slides все настройки слайдов (Слайд Мастер, Макет Слайда и сам слайд) на самом деле являются объектами слайдов, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).
* Следовательно, Слайд Мастер и Макет Слайда могут реализовывать одни и те же свойства, и вам нужно знать, как их значения будут применены к объекту [Слайд](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). Сначала к слайду применяется Слайд Мастер, а затем применяется Макет Слайда. Например, если и Слайд Мастер, и Макет Слайда имеют значение фона, слайд получит фон от Макета Слайда.

{{% /alert %}}


## **Что включает в себя Слайд Мастер**

Чтобы понять, как можно изменить Слайд Мастер, вы должны знать его составные части. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) получать/устанавливать фон слайда.
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) - получать/устанавливать текстовые стили тела слайда.
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) получать/устанавливать все фигуры Слайда Мастера (заполнители, фоторамки и т. д.).
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) получать/устанавливать элементы управления ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) - получать менеджер тем.
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - получать менеджер заголовков и подвалов.

Методы Слайда Мастера:

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) - получать все Слайды, которые зависят от Слайда Мастера.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - позволяет создать новый Слайд Мастер на основе текущего Слайда Мастера и новой темы. Новый Слайд Мастер будет затем применен ко всем зависимым слайдам.


## **Получить Слайд Мастер**

В PowerPoint к Слайд Мастеру можно получить доступ из меню Вид -> Слайд Мастер:

![todo:image_alt_text](slide-master_3.jpg)



Используя Aspose.Slides, вы можете получить доступ к Слайд Мастеру следующим образом: 

```java
Presentation pres = new Presentation();
try {
    // Даёт доступ к мастер-слайду Презентации
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

Интерфейс [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) представляет собой Слайд Мастер. Свойство [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (связанное с типом [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) содержит список всех Слайдов Мастеров, которые определены в презентации.


## **Добавить Изображение в Слайд Мастер**

Когда вы добавляете изображение в Слайд Мастер, это изображение появится на всех слайдах, зависящих от этого слайда мастера.

Например, вы можете разместить логотип вашей компании и несколько изображений на Слайде Мастере, а затем вернуться к режиму редактирования слайдов. Вы должны увидеть изображение на каждом слайде.

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

Для получения дополнительной информации о добавлении изображений на слайд смотрите статью [Рамка для изображения](/slides/ru/java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Добавить Заполнитель в Слайд Мастер**

Эти текстовые поля являются стандартными заполнителями на Слайд Мастере:

* Нажмите, чтобы изменить стиль заголовка мастера

* Изменить текстовые стили мастера

* Второй уровень

* Третий уровень 

Они также появляются на слайдах, основанных на Слайд Мастере. Вы можете редактировать эти заполнители на Слайд Мастере, и изменения будут автоматически применены к слайдам.

В PowerPoint вы можете добавить заполнитель через путь Слайд Мастер -> Вставить Заполнитель:



![todo:image_alt_text](slide-master_5.png)



Давайте рассмотрим более сложный пример для заполнителей с использованием Aspose.Slides. Рассмотрим слайд с заполнителями, оформленными по шаблону Слайда Мастера:



![todo:image_alt_text](slide-master_6.png)



Мы хотим изменить форматирование Заголовка и Подзаголовка на Слайд Мастере следующим образом:

![todo:image_alt_text](slide-master_7.png)



Сначала мы извлекаем содержимое заголовка заполнителя из объекта Слайда Мастера и затем используем поле `PlaceHolder.FillFormat`:

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

Стиль и форматирование заголовка изменятся для всех слайдов, основанных на слайде мастера:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Смотрите также" %}} 

* [Установить текст подсказки в заполнитель](https://docs.aspose.com/slides/java/manage-placeholder/)
* [Форматирование текста](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}


## **Изменить фон на Слайде Мастере**

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

- [Фон презентации](https://docs.aspose.com/slides/java/presentation-background/)

- [Тема презентации](https://docs.aspose.com/slides/java/presentation-theme/)

  {{% /alert %}}

## **Клонировать Слайд Мастер в другую Презентацию**

Чтобы клонировать Слайд Мастер в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) из целевой презентации вместе с Слайд Мастером, переданным в него. Этот код на Java показывает, как клонировать Слайд Мастер в другую презентацию:

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **Добавить Несколько Слайд Мастеров в Презентацию**

Aspose.Slides позволяет добавлять несколько Слайдов Мастеров и Макетов Слайдов в любую данную презентацию. Это позволяет настраивать стили, макеты и параметры форматирования для слайдов презентации множеством способов.

В PowerPoint вы можете добавлять новые Слайды Мастера и Макеты (из меню "Слайд Мастер") следующим образом:

![todo:image_alt_text](slide-master_9.jpg)

Используя Aspose.Slides, вы можете добавить новый Слайд Мастер, вызвав метод [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) следующим образом:

```java
// Добавляет новый мастер-слайд
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **Сравнить Слайды Мастера**

Слайд Мастер реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide), содержащий метод [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), который можно использовать для сравнения слайдов. Он возвращает `true` для Слайдов Мастеров, идентичных по структуре и статическому содержимому.

Два Слайда Мастера равны, если их фигуры, стили, тексты, анимация и другие настройки и т. д. равны. Сравнение не учитывает значения уникального идентификатора (например, SlideId) и динамическое содержание (например, текущее значение даты в Заполнителе Даты).


## **Установить Слайд Мастер как представление по умолчанию для Презентации**

Aspose.Slides позволяет установить Слайд Мастер как представление по умолчанию для презентации. Представление по умолчанию - это то, что вы видите первым, когда открываете презентацию.

Этот код показывает, как установить Слайд Мастер как представление по умолчанию для презентации в Java:

```java
// Создаёт класс Презентации, представляющий файл презентации
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

## **Удалить неиспользуемый мастер-слайд**

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (из класса [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)), который позволяет удалять ненужные и неиспользуемые мастер-слайды. Этот код на Java показывает, как удалить мастер-слайд из презентации PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```