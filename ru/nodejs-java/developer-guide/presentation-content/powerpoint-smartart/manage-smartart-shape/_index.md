---
title: Управление фигурой SmartArt
type: docs
weight: 20
url: /ru/nodejs-java/manage-smartart-shape/
---

## **Создать SmartArt форму**
Aspose.Slides for Node.js via Java предоставил API для создания SmartArt фигур. Чтобы создать SmartArt форму на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его Index.
1. [Добавьте SmartArt форму](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) путем установки [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType).
1. Сохраните изменённую презентацию в файл PPTX.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавить Smart Art фигуру
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Сохранение презентации
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: SmartArt фигура, добавленная на слайд**|

## **Доступ к SmartArt фигуре на слайде**
В следующем коде будет произведён доступ к SmartArt фигурам, добавленным в слайд презентации. В примере кода мы пройдем по всем фигурам внутри слайда и проверим, является ли она [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) фигурой. Если фигура типа SmartArt, мы приведём её к экземпляру [**SmartArt**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt).
```javascript
// Загрузить нужную презентацию
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Перебрать все фигуры на первом слайде
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Проверить, является ли фигура типом SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Привести фигуру к типу SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Доступ к SmartArt фигуре с определённым LayoutType**
В следующем примере кода будет показано, как получить доступ к фигуре [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) с определённым LayoutType. Обратите внимание, что изменить LayoutType у SmartArt нельзя, так как он только для чтения и задаётся лишь при добавлении фигуры [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) и загрузите презентацию с SmartArt фигурой.
1. Получите ссылку на первый слайд, используя его Index.
1. Пройдитесь по всем фигурам внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), и приведите выбранную фигуру к SmartArt, если это SmartArt.
1. Проверьте SmartArt фигуру с определённым LayoutType и выполните требуемые действия.
```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Перебрать все фигуры в первом слайде
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Проверить, является ли фигура типом SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Привести фигуру к типу SmartArtEx
            var smart = shape;
            // Проверка макета SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Изменить стиль SmartArt фигуры**
В этом примере мы научимся изменять быстрый стиль любой SmartArt фигуры.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) и загрузите презентацию с SmartArt фигурой.
1. Получите ссылку на первый слайд, используя его Index.
1. Пройдитесь по всем фигурам внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), и приведите выбранную фигуру к SmartArt, если это SmartArt.
1. Найдите SmartArt фигуру с определённым Style.
1. Установите новый Style для SmartArt фигуры.
1. Сохраните презентацию.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Получить первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Перебрать все фигуры в первом слайде
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Проверить, является ли фигура типом SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Привести фигуру к типу SmartArtEx
            var smart = shape;
            // Проверка стиля SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Изменение стиля SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Сохранение презентации
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: SmartArt фигура с изменённым Style**|

## **Изменить цветовой стиль SmartArt фигуры**
В этом примере мы научимся изменять цветовой стиль любой SmartArt фигуры. В следующем примере кода будет выполнен доступ к SmartArt фигуре с определённым цветовым стилем и его изменение.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) и загрузите презентацию с SmartArt фигурой.
1. Получите ссылку на первый слайд, используя его Index.
1. Пройдитесь по всем фигурам внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), и приведите выбранную фигуру к SmartArt, если это SmartArt.
1. Найдите SmartArt фигуру с определённым Color Style.
1. Установите новый Color Style для SmartArt фигуры.
1. Сохраните презентацию.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Получить первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Перебрать все фигуры в первом слайде
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Проверить, является ли фигура типом SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Привести фигуру к типу SmartArtEx
            var smart = shape;
            // Проверка цветового стиля SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Изменение цветового стиля SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Сохранение презентации
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Рисунок: SmartArt фигура с изменённым Color Style**|

## **FAQ**

**Могу ли я анимировать SmartArt как единый объект?**

Да. SmartArt является фигурой, поэтому вы можете применять [standard animations](/slides/ru/nodejs-java/powerpoint-animation/) через API анимаций (вход, выход, акцент, пути движения), так же как и к другим фигурам.

**Как найти конкретный SmartArt на слайде, если я не знаю его внутренний ID?**

Установите и используйте альтернативный текст (AltText) и ищите фигуру по этому значению — это рекомендуемый способ найти нужную фигуру.

**Могу ли я группировать SmartArt с другими фигурами?**

Да. Вы можете группировать SmartArt с другими фигурами (изображения, таблицы и т.д.), а затем [manipulate the group](/slides/ru/nodejs-java/group/).

**Как получить изображение конкретного SmartArt (например, для предварительного просмотра или отчёта)?**

Экспортируйте миниатюру/изображение фигуры; библиотека может [render individual shapes](/slides/ru/nodejs-java/create-shape-thumbnails/) в растровые файлы (PNG/JPG/TIFF).

**Сохранится ли внешний вид SmartArt при конвертации всей презентации в PDF?**

Да. Рендеринговый движок ориентирован на высокую точность при [PDF export](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), предлагая широкий набор параметров качества и совместимости.