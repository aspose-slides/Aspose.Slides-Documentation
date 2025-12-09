---
title: Преобразовать PowerPoint в PNG
type: docs
weight: 30
url: /ru/nodejs-java/convert-powerpoint-to-png/
keywords: PowerPoint to PNG, PPT to PNG, PPTX to PNG, java, Aspose.Slides для Node.js через Java
description: Преобразовать презентацию PowerPoint в PNG
---

## **О преобразовании PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё равно очень популярен. 

**Случай использования:** Когда у вас сложное изображение и размер не имеет значения, PNG — лучший формат изображения, чем JPEG. 

{{% alert title="Tip" color="primary" %}} Возможно, вам стоит взглянуть на бесплатные конвертеры Aspose **PowerPoint в PNG**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живой пример реализации процесса, описанного на этой странице. {{% /alert %}}

## **Преобразовать PowerPoint в PNG**

Пройдите следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите объект слайда из коллекции, возвращаемой методом [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) класса [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide).
3. Воспользуйтесь методом [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) для получения миниатюры каждого слайда.
4. Используйте метод [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) для сохранения миниатюры слайда в формате PNG.

Этот код на JavaScript демонстрирует, как конвертировать презентацию PowerPoint в PNG:
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

Если вы хотите получить PNG‑файлы определённого масштаба, вы можете задать значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры. 

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

Если вы хотите получить PNG‑файлы определённого размера, вы можете передать желаемые аргументы `width` и `height` для `ImageSize`. 

Этот код показывает, как конвертировать PowerPoint в PNG, задавая размер изображений: 
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


## **Часто задаваемые вопросы**

**Как экспортировать только конкретную форму (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр отдельных фигур](/slides/ru/nodejs-java/create-shape-thumbnails/); вы можете отобразить форму в PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**

Да, но [не следует совместно использовать](/slides/ru/nodejs-java/multithreading/) один экземпляр презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Каковы ограничения пробной версии при экспорте в PNG?**

В режиме оценки к экспортируемым изображениям добавляется водяной знак, а также применяются [другие ограничения](/slides/ru/nodejs-java/licensing/) до установки лицензии.