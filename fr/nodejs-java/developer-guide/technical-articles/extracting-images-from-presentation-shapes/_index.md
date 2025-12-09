---
title: Extraction d'images à partir des formes de présentation
type: docs
weight: 100
url: /fr/nodejs-java/extracting-images-from-presentation-shapes/
keywords: "Extraction d'image, PowerPoint, PPT, PPTX, présentation PowerPoint, Java, Aspose.Slides for Node.js via Java"
description: "Extraire des images d'une présentation PowerPoint en JavaScript"
---

{{% alert color="primary" %}} 

Les images sont souvent ajoutées aux formes et sont également fréquemment utilisées comme arrière‑plans des diapositives. Les objets image sont ajoutés via [ImageCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection/), qui est une collection d’objets [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).

Cet article explique comment extraire les images ajoutées aux présentations. 

{{% /alert %}} 

Pour extraire une image d’une présentation, vous devez d’abord localiser l’image en parcourant chaque diapositive puis chaque forme. Une fois l’image trouvée ou identifiée, vous pouvez l’extraire et l’enregistrer en tant que nouveau fichier. 
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

**Puis‑je extraire l’image originale sans aucun recadrage, effet ou transformation de forme ?**

Oui. Lorsque vous accédez à l’image d’une forme, vous obtenez l’objet image provenant de la [image collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/) de la présentation, ce qui signifie les pixels originaux sans recadrage ni effets de style. Le processus parcourt la [image collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/) de la présentation et les objets [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/), qui stockent les données brutes.

**Existe‑t‑il un risque de dupliquer des fichiers identiques lors de l’enregistrement de nombreuses images en même temps ?**

Oui, si vous enregistrez tout de manière indiscriminée. La [image collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/) d’une présentation peut contenir des données binaires identiques référencées par différentes formes ou diapositives. Pour éviter les doublons, comparez les hachages, tailles ou contenus des données extraites avant l’écriture.

**Comment déterminer quelles formes sont liées à une image spécifique de la collection de la présentation ?**

Aspose.Slides ne stocke pas de liens inverses de [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) vers les formes. Construisez un mappage manuellement pendant le parcours : chaque fois que vous trouvez une référence à un [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/), notez quelles formes l’utilisent.

**Puis‑je extraire des images intégrées dans des objets OLE, comme des documents joints ?**

Pas directement, car un objet OLE est un conteneur. Vous devez d’abord extraire le paquet OLE lui‑même, puis analyser son contenu avec des outils séparés. Les formes d’image de présentation fonctionnent via [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) ; OLE est un type d’objet différent.