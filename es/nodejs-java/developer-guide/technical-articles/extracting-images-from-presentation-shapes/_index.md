---
title: Extrayendo imágenes de formas de presentación
type: docs
weight: 100
url: /es/nodejs-java/extracting-images-from-presentation-shapes/
keywords: "Extraer imagen, PowerPoint, PPT, PPTX, presentación de PowerPoint, Java, Aspose.Slides para Node.js a través de Java"
description: "Extraer imágenes de una presentación PowerPoint en JavaScript"
---

{{% alert color="primary" %}} 

Las imágenes se añaden a menudo a las formas y también se usan frecuentemente como fondos de diapositivas. Los objetos de imagen se añaden a través de [ImageCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection/), que es una colección de objetos [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).

Este artículo explica cómo puede extraer las imágenes añadidas a las presentaciones. 

{{% /alert %}} 

Para extraer una imagen de una presentación, debe localizar la imagen primero recorriendo cada diapositiva y luego recorriendo cada forma. Una vez que la imagen se encuentre o identifique, puede extraerla y guardarla como un nuevo archivo. 
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


## **Preguntas frecuentes**

**¿Puedo extraer la imagen original sin recorte, efectos o transformaciones de forma?**

Sí. Cuando accede a la imagen de una forma, obtiene el objeto de imagen de la [image collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/), lo que significa los píxeles originales sin recorte ni efectos de estilo. El proceso recorre la colección de imágenes de la presentación y los objetos [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/), que almacenan los datos sin procesar.

**¿Existe el riesgo de duplicar archivos idénticos al guardar muchas imágenes a la vez?**

Sí, si guarda todo indiscriminadamente. La [image collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/) de una presentación puede contener datos binarios idénticos referenciados por diferentes formas o diapositivas. Para evitar duplicados, compare los hash, tamaños o contenidos de los datos extraídos antes de escribir.

**¿Cómo puedo determinar qué formas están vinculadas a una imagen específica de la colección de la presentación?**

Aspose.Slides no almacena enlaces inversos de [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) a las formas. Construya un mapeo manualmente durante el recorrido: cada vez que encuentre una referencia a un [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/), registre qué formas lo utilizan.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

No directamente, porque un objeto OLE es un contenedor. Necesita extraer el paquete OLE en sí y luego analizar su contenido con herramientas separadas. Las formas de imagen de la presentación funcionan a través de [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/); OLE es un tipo de objeto diferente.