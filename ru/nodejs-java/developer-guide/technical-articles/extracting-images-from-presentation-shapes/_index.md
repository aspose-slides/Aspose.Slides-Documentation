---
title: Извлечение изображений из фигур презентации
type: docs
weight: 100
url: /ru/nodejs-java/extracting-images-from-presentation-shapes/
keywords: "Извлечение изображения, PowerPoint, PPT, PPTX, Презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Извлечение изображений из презентации PowerPoint в JavaScript"
---

{{% alert color="primary" %}} 

Изображения часто добавляются к фигурам и также часто используются в качестве фонов слайдов. Объекты изображений добавляются через [ImageCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection/), которая представляет собой коллекцию объектов [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).

В этой статье объясняется, как можно извлечь изображения, добавленные в презентации. 

{{% /alert %}} 

Чтобы извлечь изображение из презентации, нужно сначала найти изображение, проходя каждый слайд, а затем каждый объект. Как только изображение найдено или идентифицировано, вы можете извлечь его и сохранить как новый файл. 
```javascript
function extractImages() {
    const folderPath = "./";
    const pres = new aspose.slides.Presentation(folderPath + "ExtractImages.pptx");
    let img = null;
    let backImage = null;

    let slideIndex = 0;
    let imageType = 0;
    let ifImageFound = false;

    for (let i = 0; i < pres.getSlides().size(); i++) {
        slideIndex++;
        let sl = pres.getSlides().get_Item(i);

        if (sl.getBackground().getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
            backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
            imageType = getImageTType(backImage);

            const imagePath = folderPath + "backImage_Slide_" + slideIndex + "." + imageType;
            saveImage(backImage, imagePath, imageType);
        } else if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
            backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
            imageType = getImageTType(backImage);

            const imagePath = folderPath + "backImage_LayoutSlide_" + slideIndex + "." + imageType;
            saveImage(backImage, imagePath, imageType);
        }

        for (let j = 0; j < sl.getShapes().size(); j++) {
            let sh = sl.getShapes().get_Item(j);

            if (java.instanceOf(sh, "com.aspose.slides.IAutoShape")) {
                let ashp = sh;
                if (ashp.getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
                    img = ashp.getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(img);
                    ifImageFound = true;
                }
            } else if (java.instanceOf(sh, "com.aspose.slides.IPictureFrame")) {
                let pf = sh;
                img = pf.getPictureFormat().getPicture().getImage();
                imageType = getImageTType(img);
                ifImageFound = true;
            }

            if (ifImageFound) {
                const imagePath = folderPath + "backImage_Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                saveImage(img, imagePath, imageType);
            }
            ifImageFound = false;
        }
    }
}

function getImageTType(image) {
    let imageContentType = image.getContentType();
    imageContentType = imageContentType.substring(imageContentType.indexOf("/") + 1);
    imageContentType = imageContentType.substring(imageContentType.indexOf("-") + 1);
    return imageContentType;
}

function capitalize(str) {
    if (!str || str.length <= 1) return str;
    return str.charAt(0).toUpperCase() + str.slice(1);
}

function saveImage(image, path, imageType) {    
    var ImageFormatClass = java.import('com.aspose.slides.ImageFormat');
    let imageTypeValue = java.callStaticMethodSync("com.aspose.slides.ImageFormat", "getValue", ImageFormatClass.class, capitalize(imageType));
    
    image.getImage().save(path, java.newInstanceSync("java.lang.Integer", imageTypeValue.longValue));
    console.log(`Image saved to ${path}`);
}
```


## **FAQ**

**Могу ли я извлечь оригинальное изображение без обрезки, эффектов или трансформаций фигуры?**

Да. Когда вы получаете изображение фигуры, вы получаете объект изображения из [коллекция изображений](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/), то есть оригинальные пиксели без обрезки или стилистических эффектов. Процесс проходит через коллекцию изображений презентации и объекты [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/), которые хранят необработанные данные.

**Существует ли риск дублирования одинаковых файлов при сохранении большого количества изображений одновременно?**

Да, если сохранять всё без разбора. [коллекция изображений](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/) презентации может содержать одинаковые бинарные данные, на которые ссылаются разные фигуры или слайды. Чтобы избежать дублирования, сравнивайте хэши, размеры или содержимое извлечённых данных перед записью.

**Как определить, какие фигуры связаны с конкретным изображением из коллекции презентации?**

Aspose.Slides не хранит обратные ссылки от [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) к фигурам. Постройте отображение вручную во время обхода: каждый раз, когда вы находите ссылку на [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/), фиксируйте, какие фигуры её используют.

**Могу ли я извлечь изображения, встроенные в OLE‑объекты, такие как вложенные документы?**

Не напрямую, поскольку OLE‑объект является контейнером. Необходимо извлечь сам OLE‑пакет, а затем проанализировать его содержимое с помощью отдельных инструментов. Фигуры‑изображения в презентации работают через [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/); OLE — это другой тип объекта.