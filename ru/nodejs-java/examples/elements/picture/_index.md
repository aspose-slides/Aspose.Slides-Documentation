---
title: Изображение
type: docs
weight: 50
url: /ru/nodejs-java/examples/elements/picture/
keywords:
- пример кода
- изображение
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Работа с изображениями в Aspose.Slides для Node.js: вставка, обрезка, сжатие, изменение цвета и экспорт изображений с примерами для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется, как вставлять и получать доступ к изображениям с помощью **Aspose.Slides for Node.js via Java**. Приведённые ниже примеры читают изображение из файла, помещают его на слайд и затем извлекают его.

## **Добавить изображение**

Этот код считывает изображение из файла и вставляет его в виде рамки изображения на первый слайд.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Вставить рамку изображения, отображающую картинку на первом слайде.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Доступ к изображению**

Этот пример проверяет, что слайд содержит рамку изображения, а затем получает доступ к первой найденной.

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```