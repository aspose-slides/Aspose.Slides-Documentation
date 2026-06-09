---
title: Resim
type: docs
weight: 50
url: /tr/nodejs-java/examples/elements/picture/
keywords:
- kod örneği
- resim
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde resimlerle çalışın: ekleme, kırpma, sıkıştırma, renk değiştirme ve PPT, PPTX ve ODP sunumları için örneklerle görüntüleri dışa aktarma."
---
Bu makale, **Aspose.Slides for Node.js via Java** kullanarak resim ekleme ve erişme işlemlerini gösterir. Aşağıdaki örnekler bir dosyadan görüntü okur, bir slayta yerleştirir ve ardından onu geri alır.

## **Resim Ekle**

Bu kod bir dosyadan görüntü okur ve ilk slayta bir resim çerçevesi olarak ekler.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // İlk slaytta görüntüyü gösteren bir resim çerçevesi ekleyin.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Resme Erişim**

Bu örnek, bir slaydın resim çerçevesi içerdiğini doğrular ve ardından bulunan ilkine erişir.

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