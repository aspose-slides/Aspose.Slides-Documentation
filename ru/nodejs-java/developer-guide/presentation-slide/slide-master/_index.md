---
title: Мастер слайдов
type: docs
weight: 70
url: /ru/nodejs-java/slide-master/
keywords: "Добавить мастер слайдов, Мастер слайд PPT, мастер слайд PowerPoint, Изображение в мастер слайдов, Заполнитель, Несколько мастеров слайдов, Сравнить мастера слайдов, Java, Aspose.Slides for Node.js via Java"
description: "Добавить или изменить мастер слайдов в презентации PowerPoint с помощью JavaScript"
---

## **Что такое мастер слайдов в PowerPoint**

**Slide Master** — это шаблон слайда, определяющий компоновку, стили, тему, шрифты, фон и другие свойства слайдов в презентации. Если вы хотите создать одну или несколько презентаций в едином стиле и шаблоне для вашей компании, используйте мастер слайдов. 

Мастер слайдов полезен тем, что позволяет задать и изменить внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм мастера слайдов из PowerPoint. 

VBA также позволяет управлять мастером слайдов и выполнять те же операции, что поддерживаются в PowerPoint: менять фон, добавлять фигуры, настраивать компоновку и т.д. Aspose.Slides предоставляет гибкие механизмы для работы с мастерами слайдов и выполнения базовых задач. 

Это базовые операции с мастером слайдов:

- Создать мастер слайдов.
- Применить мастер слайдов к слайдам презентации.
- Изменить фон мастера слайдов. 
- Добавить изображение, заполнитель, Smart Art и т.п. к мастеру слайдов.

Более продвинутые операции с мастером слайдов:

- Сравнить мастера слайдов.
- Объединить мастера слайдов.
- Применить несколько мастеров слайдов.
- Скопировать слайд с мастером слайдов в другую презентацию.
- Найти дублирующиеся мастера слайдов в презентациях.
- Установить мастер слайдов как представление по умолчанию презентации.

{{% alert color="primary" %}} 
Возможно, вам будет интересно попробовать Aspose [**Онлайн‑просмотрщик PowerPoint**](https://products.aspose.app/slides/viewer), так как он демонстрирует живую реализацию некоторых из описанных здесь процессов.
{{% /alert %}} 

## **Как применяется мастер слайдов**

Прежде чем работать с мастером слайдов, стоит понять, как они используются в презентациях и применяются к слайдам. 

* Каждая презентация имеет как минимум один мастер слайдов по умолчанию. 
* Презентация может содержать несколько мастеров слайдов. Вы можете добавить несколько мастеров слайдов и использовать их для стилизации разных частей презентации различными способами. 

В **Aspose.Slides** мастер слайдов представлен типом [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). 

Объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) в Aspose.Slides содержит список [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) из [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), в котором находятся все мастера слайдов, определённые в презентации. 

Помимо CRUD‑операций, класс [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) включает полезные методы: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) и [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-). Эти методы унаследованы от базовой функции клонирования слайдов, но при работе с мастерами слайдов позволяют реализовывать сложные настройки. 

Когда в презентацию добавляется новый слайд, к нему автоматически применяется мастер слайдов. По умолчанию выбирается мастер слайдов предыдущего слайда. 

**Примечание**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--), и каждый новый слайд добавляется в конец коллекции. Если презентация содержит один мастер слайдов, он будет выбран для всех новых слайдов. Поэтому вам не нужно явно задавать мастер слайдов для каждого нового слайда. 

Принцип тот же в PowerPoint и Aspose.Slides. Например, в PowerPoint, добавив новый слайд, вы просто щёлкаете под последним слайдом, и создаётся новый слайд (с мастером слайдов последней презентации):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides аналогичную задачу можно выполнить методом [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). 

## **Мастер слайдов в иерархии Slides**

Использование макетов слайдов вместе с мастером слайдов обеспечивает максимальную гибкость. Макет слайда позволяет задать такие же стили, как и мастер слайдов (фон, шрифты, фигуры и т.д.). Однако при комбинировании нескольких макетов слайдов на мастере слайдов создаётся новый стиль. Применяя макет слайда к отдельному слайду, вы можете изменить его стиль, отличающийся от стиля мастера слайдов. 

Иерархия: Мастер слайдов → Макет слайда → Слайд:

![todo:image_alt_text](slide-master_2)

Каждый объект [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) со списком макетов слайдов. Тип [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) со ссылкой на применённый к слайду макет. Взаимодействие между слайдом и мастером слайдов происходит через макет слайда. 

{{% alert color="info" title="Примечание" %}}
* В Aspose.Slides все настройки слайда (мастер слайдов, макет слайда и сам слайд) реализованы как объекты слайдов, наследующие класс [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide). 
* Поэтому мастер слайдов и макет слайда могут иметь одинаковые свойства, и важно понять, как их значения применяются к объекту [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide). Сначала к слайду применяется мастер слайдов, затем — макет слайда. Например, если у мастера и макета задан фон, итоговый фон будет взят из макета слайда. 
{{% /alert %}} 

## **Из чего состоит мастер слайдов**

Чтобы понять, как менять мастер слайдов, нужно знать его составные части. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) — получить/установить фон слайда. 
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) — получить/установить стили текста тела слайда. 
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) — получить/установить все фигуры мастера слайдов (заполнители, рамки изображений и т.п.). 
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) — получить/установить элементы управления ActiveX. 
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterThemeable#getThemeManager--) — получить менеджер тем. 
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) — получить менеджер колонтитулов. 

Методы мастера слайдов:

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) — получить все слайды, зависящие от мастера слайдов. 
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) — позволяет создать новый мастер слайдов на основе текущего и новой темы. Новый мастер слайдов будет применён ко всем зависимым слайдам. 

## **Получить мастер слайдов**

В PowerPoint мастер слайдов доступен через меню View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

В Aspose.Slides мастер слайдов можно получить так:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Получает доступ к мастер‑слайду презентации
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Класс [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) представляет мастер слайдов. Свойство [Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) (связанное с типом [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)) содержит список всех мастеров слайдов, определённых в презентации. 

## **Добавить изображение в мастер слайдов**

Если добавить изображение в мастер слайдов, оно появится на всех слайдах, зависящих от этого мастера. 

Например, разместив логотип компании и несколько изображений на мастере слайдов, вы увидите их на каждом слайде после возврата в режим редактирования. 

![todo:image_alt_text](slide-master_4.png)

Изображения в мастер слайдов можно добавить с помощью Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="См. также" %}} 
Подробности о добавлении изображений см. в статье [Picture Frame](/slides/ru/nodejs-java/picture-frame/#create-picture-frame). 
{{% /alert %}} 

## **Добавить заполнитель в мастер слайдов**

Это стандартные заполнители на мастере слайдов: 

* Щёлкните, чтобы отредактировать стиль заголовка мастера
* Отредактировать стили текста мастера
* Второй уровень
* Третий уровень 

Они также отображаются на слайдах, основанных на мастере. Вы можете отредактировать эти заполнители в мастере, и изменения автоматически применятся к слайдам. 

В PowerPoint заполнитель добавляется через путь Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Предположим, есть слайд с заполнителями, шаблонными от мастера слайдов:

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование заголовка и подзаголовка на мастере слайдов следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала получаем содержимое заполняющего заголовка из объекта мастера слайдов и затем используем поле `PlaceHolder.FillFormat`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    var placeHolder = findPlaceholder(master, aspose.slides.PlaceholderType.Title);
    placeHolder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    placeHolder.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    var awtColor = java.import('java.awt.Color');
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, java.newInstanceSync('java.awt.Color', 255, 0, 0));
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, java.newInstanceSync('java.awt.Color', 128, 0, 128));

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

function findPlaceholder(master, type)
{    
    for (var i = 0 ; i < master.getShapes().size(); i++)
    {
        var autoShape = master.getShapes().get_Item(i);
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


Стиль и форматирование заголовка изменятся на всех слайдах, основанных на этом мастере:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="См. также" %}} 
* [Установка подсказочного текста в заполнителе](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/) 
* [Форматирование текста](https://docs.aspose.com/slides/nodejs-java/text-formatting/) 
{{% /alert %}} 

## **Изменить фон мастера слайдов**

При изменении цвета фона мастера слайдов все обычные слайды презентации получат новый цвет. Эта JavaScript‑программа демонстрирует операцию:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    master.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    master.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="См. также" %}} 
- [Фон презентации](https://docs.aspose.com/slides/nodejs-java/presentation-background/) 
- [Тема презентации](https://docs.aspose.com/slides/nodejs-java/presentation-theme/) 
{{% /alert %}} 

## **Клонировать мастер слайдов в другую презентацию**

Чтобы клонировать мастер слайдов в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) у целевой презентации, передав в него мастер слайдов. Эта JavaScript‑программа показывает, как это сделать:
```javascript
var presSource = new aspose.slides.Presentation();
var presTarget = new aspose.slides.Presentation();
try {
    var master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) {
        presSource.dispose();
    }
}
```


## **Добавить несколько мастеров слайдов в презентацию**

Aspose.Slides позволяет добавить несколько мастеров слайдов и макетов в любую презентацию. Это даёт возможность задавать стили, компоновки и параметры форматирования слайдов различными способами. 

В PowerPoint новые мастера слайдов и макеты добавляются через меню “Slide Master”:

![todo:image_alt_text](slide-master_9.jpg)

В Aspose.Slides новый мастер слайдов добавляется вызовом метода [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-):
```javascript
// Добавляет новый мастер слайд
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **Сравнить мастера слайдов**

Мастер‑слайд реализует класс [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide), содержащий метод [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-), который можно использовать для сравнения слайдов. Метод возвращает `true`, если мастера слайдов идентичны по структуре и статическому содержимому. 

Два мастера слайдов считаются равными, если их фигуры, стили, тексты, анимация и другие настройки совпадают. При сравнении не учитываются уникальные идентификаторы (например, SlideId) и динамическое содержание (например, текущая дата в заполняющем поле даты). 

## **Установить мастер слайдов как представление по умолчанию презентации**

Aspose.Slides позволяет задать мастер слайдов как представление по умолчанию для презентации. Это то, что вы видите первым при открытии файла. 

Пример кода, показывающий, как установить мастер слайдов как представление по умолчанию в JavaScript:
```javascript
// Создаёт экземпляр класса Presentation, представляющий файл презентации
var presentation = new aspose.slides.Presentation();
try {
    // Устанавливает представление по умолчанию как SlideMasterView
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    // Сохраняет презентацию
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Удалить неиспользуемый мастер слайдов**

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) класса [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/), позволяющий удалять ненужные мастера слайдов. Этот JavaScript‑пример демонстрирует удаление мастера слайдов из PowerPoint‑презентации:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Что такое мастер слайдов в PowerPoint?**  

Мастер слайдов — это шаблон слайда, определяющий компоновку, стили, темы, шрифты, фон и другие свойства слайдов в презентации. Он позволяет задать и изменить внешний вид всех слайдов одновременно.  

**Как применяется мастер слайдов в презентации?**  

Каждая презентация имеет минимум один мастер слайдов. При добавлении нового слайда к нему автоматически применяется мастер слайдов, обычно наследующий мастер предыдущего слайда. В презентации может быть несколько мастеров слайдов для различного стилизования частей.  

**Какие элементы можно настраивать в мастере слайдов?**  

Мастер слайдов состоит из нескольких основных свойств, которые можно настраивать:  

- **Background** — задаёт фон слайда.  
- **BodyStyle** — определяет стили текста тела слайда.  
- **Shapes** — управляет всеми фигурами на мастере, включая заполнители и рамки изображений.  
- **Controls** — управляет элементами управления ActiveX.  
- **ThemeManager** — доступ к менеджеру темы.  
- **HeaderFooterManager** — управление колонтитулами.  

**Как добавить изображение в мастер слайдов?**  

Добавление изображения в мастер слайдов гарантирует его отображение на всех слайдах, зависящих от этого мастера. Например, разместив логотип компании на мастере, вы увидите его на каждом слайде презентации.  

**Как мастера слайдов связаны с макетами слайдов?**  

Макеты слайдов работают совместно с мастерами, обеспечивая гибкость дизайна. Мастер задаёт глобальные стили и темы, а макеты позволяют варьировать расположение контента. Иерархия выглядит так:  

- **Мастер слайдов** → задаёт глобальные стили.  
- **Макет слайда** → предоставляет разные варианты компоновки.  
- **Слайд** → наследует дизайн от своего макета.  

**Можно ли использовать несколько мастеров слайдов в одной презентации?**  

Да, презентация может содержать несколько мастеров слайдов, что позволяет стилизовать различные разделы по‑разному и повышать гибкость дизайна.  

**Как получить и изменить мастер слайдов с помощью Aspose.Slides?**  

В Aspose.Slides мастер слайдов представлен классом [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). Доступ к мастеру можно получить через метод [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) объекта [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).