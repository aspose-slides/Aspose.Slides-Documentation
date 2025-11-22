---
title: Extrahieren von Bildern aus Präsentationsformen
type: docs
weight: 100
url: /de/nodejs-java/extracting-images-from-presentation-shapes/
keywords: "Bild extrahieren, PowerPoint, PPT, PPTX, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Bilder aus PowerPoint-Präsentation in JavaScript extrahieren"
---

{{% alert color="primary" %}} 

Bilder werden häufig zu Formen hinzugefügt und auch oft als Folienhintergründe verwendet. Die Bildobjekte werden über [ImageCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection/) hinzugefügt, das eine Sammlung von [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)-Objekten ist.

Dieser Artikel erklärt, wie Sie die zu Präsentationen hinzugefügten Bilder extrahieren können. 

{{% /alert %}} 

Um ein Bild aus einer Präsentation zu extrahieren, müssen Sie das Bild zunächst finden, indem Sie jede Folie und anschließend jede Form durchgehen. Sobald das Bild gefunden oder identifiziert ist, können Sie es extrahieren und als neue Datei speichern. 
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

**Kann ich das Originalbild ohne Beschnitt, Effekte oder Formen‑transformationen extrahieren?**

Ja. Wenn Sie auf das Bild einer Form zugreifen, erhalten Sie das Bildobjekt aus der [Bildsammlung](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/) der Präsentation, d. h. die Originalpixel ohne Beschnitt oder Stil‑effekte. Der Ablauf geht durch die Bildsammlung der Präsentation und die [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)-Objekte, die die Rohdaten speichern.

**Besteht das Risiko, bei gleichzeitiger Speicherung vieler Bilder identische Dateien zu duplizieren?**

Ja, wenn Sie alles ungefiltert speichern. Die Bildsammlung einer Präsentation kann identische Binärdaten enthalten, die von verschiedenen Formen oder Folien referenziert werden. Um Duplikate zu vermeiden, vergleichen Sie vor dem Schreiben Hashes, Größen oder Inhalte der extrahierten Daten.

**Wie kann ich feststellen, welche Formen mit einem bestimmten Bild aus der Bildsammlung der Präsentation verknüpft sind?**

Aspose.Slides speichert keine Rückverweise von [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) zu Formen. Erstellen Sie während der Traversierung manuell eine Zuordnung: Wann immer Sie eine Referenz zu einem [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) finden, notieren Sie, welche Formen es verwenden.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?**

Nicht direkt, da ein OLE‑Objekt ein Container ist. Sie müssen das OLE‑Paket selbst extrahieren und anschließend dessen Inhalt mit separaten Werkzeugen analysieren. Präsentations‑Bildformen funktionieren über [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/); OLE ist ein anderer Objekttyp.