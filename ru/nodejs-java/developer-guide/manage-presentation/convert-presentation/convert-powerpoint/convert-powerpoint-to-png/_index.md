---
title: Конвертировать слайды PowerPoint в PNG на JavaScript
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/nodejs-java/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PNG
- презентацию в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в высококачественные PNG-изображения на JavaScript быстро с помощью Aspose.Slides для Node.js, обеспечивая точные, автоматизированные результаты."
---

## **О преобразовании PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё равно очень популярен. 

**Случай использования:** Когда у вас сложное изображение и размер не критичен, PNG — лучший формат изображения по сравнению с JPEG. 

{{% alert title="Tip" color="primary" %}} Возможно, вам будет интересно ознакомиться с бесплатными конвертерами Aspose **PowerPoint в PNG**: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живой пример процесса, описанного на этой странице. {{% /alert %}}

## **Преобразовать PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите объект слайда из коллекции, возвращаемой методом [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) класса [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide).
3. Используйте метод [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) для получения миниатюры каждого слайда.
4. Используйте [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) метод для сохранения миниатюры слайда в формате PNG.

Этот код JavaScript показывает, как преобразовать презентацию PowerPoint в PNG:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразовать PowerPoint в PNG с пользовательскими размерами**

Если вам нужны PNG‑файлы определённого масштаба, вы можете установить значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры. 

Этот код на JavaScript демонстрирует описанную операцию:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразовать PowerPoint в PNG с пользовательским размером**

Если вам нужны PNG‑файлы определённого размера, вы можете передать желаемые аргументы `width` и `height` для `ImageSize`. 

Этот код показывает, как преобразовать PowerPoint в PNG, задав размер изображений: 
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Как экспортировать только определённую форму (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/nodejs-java/create-shape-thumbnails/); вы можете отрисовать форму в PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**

Да, но [не делите](/slides/ru/nodejs-java/multithreading/) один экземпляр презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Каковы ограничения пробной версии при экспорте в PNG?**

В режиме оценки к выходным изображениям добавляется водяной знак и действуют [другие ограничения](/slides/ru/nodejs-java/licensing/), пока не будет применена лицензия.