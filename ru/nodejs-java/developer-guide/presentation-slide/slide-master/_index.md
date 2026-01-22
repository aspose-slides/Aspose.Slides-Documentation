---
title: Управление мастер‑слайдами презентации в JavaScript
linktitle: Мастер слайда
type: docs
weight: 70
url: /ru/nodejs-java/slide-master/
keywords:
- мастер слайда
- мастер слайда
- мастер-слайд PPT
- несколько мастер‑слайдов
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонировать мастер‑слайд
- копировать мастер‑слайд
- дублировать мастер‑слайд
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте мастер‑слайдами в Aspose.Slides для Node.js через Java: создавайте, редактируйте и применяйте макеты, темы и заполнители к PPT, PPTX и ODP с лаконичными примерами."
---

## **Что такое мастер слайдов в PowerPoint**

**Мастер слайдов** — это шаблон слайда, который определяет макет, стили, тему, шрифты, фон и другие свойства слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать мастер слайдов. 

Мастер слайдов полезен, потому что позволяет задать и изменить внешний вид всех слайдов презентации сразу. Aspose.Slides поддерживает механизм мастера слайдов из PowerPoint. 

VBA также позволяет манипулировать мастером слайдов и выполнять те же операции, что поддерживаются в PowerPoint: менять фон, добавлять фигуры, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы, позволяющие использовать мастера слайдов и выполнять основные задачи с ними. 

Это базовые операции с мастером слайдов:

- Создать или редактировать мастер слайдов.
- Применить мастер слайдов к слайдам презентации.
- Изменить фон мастера слайдов. 
- Добавить изображение, заполнитель, Smart Art и т.п. в мастер слайдов.

Более продвинутые операции с мастером слайдов:

- Сравнение мастеров слайдов.
- Объединение мастеров слайдов.
- Применение нескольких мастеров слайдов.
- Копирование слайда с мастером в другую презентацию.
- Поиск дублирующихся мастеров слайдов в презентациях.
- Установка мастера слайдов как представления по умолчанию презентации.

{{% alert color="primary" %}} 

Возможно, вам будет интересно посмотреть Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer), так как это живой пример некоторых основных процессов, описанных здесь.

{{% /alert %}} 


## **Как применяется мастер слайдов**

Прежде чем работать с мастером слайдов, стоит понять, как они используются в презентациях и применяются к слайдам. 

* Каждая презентация имеет как минимум один мастер слайдов по умолчанию. 
* Презентация может содержать несколько мастеров слайдов. Вы можете добавить несколько мастеров и использовать их для стилизации разных частей презентации по‑разному. 

В **Aspose.Slides** мастер слайдов представлен типом [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). 

Объект Aspose.Slides [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) содержит список [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), в котором находятся все мастера слайдов, определённые в презентации.

Помимо CRUD‑операций, класс [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) содержит полезные методы: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) и [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-). Эти методы унаследованы от базовой функции клонирования слайдов, но при работе с мастерами слайдов позволяют реализовать сложные сценарии.

Когда в презентацию добавляется новый слайд, к нему автоматически применяется мастер слайдов. По умолчанию выбирается мастер предыдущего слайда. 

**Примечание**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--), и каждый новый слайд добавляется в конец коллекции. Если презентация содержит один мастер слайдов, этот мастер выбирается для всех новых слайдов. Поэтому вам не нужно задавать мастер слайдов для каждого нового слайда вручную.

Принцип тот же в PowerPoint и Aspose.Slides. Например, в PowerPoint, когда вы добавляете новый слайд, достаточно кликнуть на нижнюю линию под последним слайдом — и будет создан новый слайд (с мастером последнего слайда):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides то же действие можно выполнить методом [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).


## **Мастер слайдов в иерархии Slides**

Использование макетов слайдов вместе с мастером слайдов обеспечивает максимальную гибкость. Макет слайда позволяет задать те же стили, что и мастер (фон, шрифты, фигуры и т.п.). Однако когда несколько макетов объединяются на мастере, образуется новый стиль. Применяя макет к отдельному слайду, вы можете изменить его стиль относительно того, который задаёт мастер.

Мастер слайдов превосходит все остальные настройки: Мастер слайдов → Макет слайда → Слайд:

![todo:image_alt_text](slide-master_2)



Каждый объект [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) со списком макетов слайдов. Тип [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) со ссылкой на применённый макет. Взаимодействие между слайдом и мастером происходит через макет.

{{% alert color="info" title="Note" %}}

* В Aspose.Slides все настройки слайда (мастер, макет и сам слайд) являются объектами, реализующими класс [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide). 
* Поэтому мастер и макет могут иметь одинаковые свойства, и важно понимать, как их значения применяются к объекту [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide). Сначала к слайду применяется мастер, затем — макет. Например, если и мастер, и макет задают фон, конечный фон будет взят из макета.

{{% /alert %}}


## **Из чего состоит мастер слайдов**

Чтобы понять, как менять мастер слайдов, нужно знать его составные части. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) — получить/установить фон слайда. 
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) — получить/установить стили текста тела слайда. 
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) — получить/установить все фигуры мастера (заполнители, рамки изображений и т.п.). 
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) — получить/установить элементы управления ActiveX. 
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getThemeManager) — получить менеджер темы. 
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) — получить менеджер колонтитулов.

Методы мастера слайдов:

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) — получить все слайды, зависящие от данного мастера. 
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) — позволяет создать новый мастер на основе текущего и новой темы, после чего новый мастер будет применён ко всем зависимым слайдам.


## **Получить мастер слайдов**

В PowerPoint к мастеру слайдов можно обратиться через меню Вид → Мастер слайдов:

![todo:image_alt_text](slide-master_3.jpg)



В Aspose.Slides это делается так: 
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Позволяет получить доступ к мастер‑слайду презентации
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Класс [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) представляет мастер слайдов. Свойство [Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) (связано с типом [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)) содержит список всех мастеров, определённых в презентации. 


## **Добавить изображение в мастер слайдов**

Если добавить изображение в мастер, оно появится на всех слайдах, зависящих от этого мастера. 

Например, разместите логотип компании и несколько изображений на мастере, затем вернитесь в режим редактирования слайдов — изображение будет видно на каждом из них. 

![todo:image_alt_text](slide-master_4.png)

Добавить изображения в мастер можно так:
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


{{% alert color="primary" title="See also" %}} 

Подробнее о добавлении изображений на слайд см. статью [Picture Frame](/slides/ru/nodejs-java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Добавить заполнитель в мастер слайдов**

Эти текстовые поля — стандартные заполнители на мастере слайдов: 

* Нажмите, чтобы редактировать стиль заголовка мастера
* Редактировать стиль текста мастера
* Второй уровень
* Третий уровень 

Они также отображаются на слайдах, построенных на основе мастера. Вы можете редактировать эти заполнители в мастере, и изменения автоматически применятся к слайдам. 

В PowerPoint добавить заполнитель можно через путь Мастер слайдов → Вставить заполнитель:

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Предположим, есть слайд с заполнителями, шаблон из мастера:

![todo:image_alt_text](slide-master_6.png)

Изменим форматирование заголовка и подзаголовка мастера так:

![todo:image_alt_text](slide-master_7.png)

Сначала получаем содержимое заполнителя заголовка из объекта мастера, затем используем поле `PlaceHolder.FillFormat`:
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


Стиль и форматирование заголовка изменятся на всех слайдах, построенных на этом мастере:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/nodejs-java/text-formatting/)

{{% /alert %}}


## **Изменить фон мастера слайдов**

Если изменить цвет фона мастера, все обычные слайды в презентации получат новый цвет. Этот JavaScript‑код демонстрирует операцию:
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


{{% alert color="primary" title="See also" %}} 

- [Presentation Background](https://docs.aspose.com/slides/nodejs-java/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)

{{% /alert %}}

## **Клонировать мастер слайдов в другую презентацию**

Чтобы клонировать мастер в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) целевой презентации, передав в него нужный мастер. Этот JavaScript‑пример показывает, как клонировать мастер в другую презентацию:
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

Aspose.Slides позволяет добавить несколько мастеров и макетов в любую презентацию. Это даёт возможность задавать стили, макеты и параметры форматирования слайдов разнообразными способами. 

В PowerPoint новые мастеры и макеты добавляются так (из меню «Мастер слайдов»):

![todo:image_alt_text](slide-master_9.jpg)

В Aspose.Slides новый мастер добавляется вызовом метода [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-):
```javascript
// Добавляет новый мастер‑слайд
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Сравнить мастера слайдов**

Мастерный слайд реализует класс [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) с методом [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-), который можно использовать для сравнения мастеров. Метод возвращает `true`, если мастера идентичны по структуре и статическому содержимому.

Два мастера считаются равными, если их фигуры, стили, тексты, анимация и другие настройки совпадают. При сравнении не учитываются уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущая дата в заполняющем плацехолдере).


## **Установить мастер слайдов как представление по умолчанию презентации**

Aspose.Slides позволяет задать мастер слайдов как представление по умолчанию. Это то, что пользователь видит первым при открытии презентации. 

Ниже показан код, который устанавливает мастер слайдов как представление по умолчанию в JavaScript:
```javascript
// Создаёт экземпляр класса Presentation, представляющего файл презентации
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

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (из класса [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) для удаления ненужных мастеров. Этот JavaScript‑пример показывает, как удалить мастер из презентации PowerPoint:
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

Мастер слайдов — это шаблон, который определяет макет, стили, темы, шрифты, фон и другие свойства слайдов презентации. Он позволяет задать и изменить внешний вид всех слайдов одновременно.  

**Как применяется мастер слайдов в презентации?**

Каждая презентация имеет как минимум один мастер по умолчанию. При добавлении нового слайда к нему автоматически применяется мастер, обычно наследуемый от мастера предыдущего слайда. Презентация может содержать несколько мастеров для стилизации разных частей по‑разному.  

**Какие элементы можно настраивать в мастере слайдов?**

Мастер состоит из нескольких основных свойств, которые можно менять:

- **Background**: задаёт фон слайда. 
- **BodyStyle**: определяет стили текста тела. 
- **Shapes**: управляет всеми фигурами мастера, включая заполнители и рамки изображений. 
- **Controls**: работает с элементами ActiveX. 
- **ThemeManager**: предоставляет доступ к менеджеру темы. 
- **HeaderFooterManager**: управляет колонтитулами.  

**Как добавить изображение в мастер слайдов?**

Добавление изображения в мастер гарантирует его появление на всех слайдах, зависящих от этого мастера. Например, разместив логотип компании на мастере, вы увидите его на каждом слайде презентации.  

**Как мастера слайдов соотносятся с макетами слайдов?**

Макеты работают совместно с мастерами, обеспечивая гибкость дизайна. Мастер задаёт глобальные стили и темы, а макет позволяет варьировать расположение контента. Иерархия выглядит так:

- **Мастер слайдов** → задаёт глобальные стили. 
- **Макет слайда** → предоставляет различные варианты расположения контента. 
- **Слайд** → наследует дизайн от своего макета. 

**Можно ли иметь несколько мастеров в одной презентации?**

Да, презентация может содержать несколько мастеров. Это позволяет стилизовать разные разделы по‑разному, повышая гибкость дизайна.  

**Как получить и изменить мастер слайдов с помощью Aspose.Slides?**

В Aspose.Slides мастер представлен классом [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). К мастеру можно обратиться через метод [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) объекта [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).