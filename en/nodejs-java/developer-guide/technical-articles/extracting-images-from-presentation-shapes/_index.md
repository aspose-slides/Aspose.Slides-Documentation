---
title: Extracting Images from Presentation shapes
type: docs
weight: 100
url: /nodejs-java/extracting-images-from-presentation-shapes/
keywords: "Extract image, PowerPoint, PPT, PPTX, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Extract images from PowerPoint presentation in JavaScript"

---

{{% alert color="primary" %}} 

Images are often added to shapes and also frequently used as slides' backgrounds. The image objects are added through [ImageCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection/), which is a collection of [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) objects.

This article explains how you can extract the images added to presentations. 

{{% /alert %}} 

To extract an image from a presentation, you have to locate the image first by going through every slide and then going through every shape. Once the image is found or identified, you can extract it and save it as a new file. 

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

