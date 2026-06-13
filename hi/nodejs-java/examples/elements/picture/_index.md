---
title: चित्र
type: docs
weight: 50
url: /hi/nodejs-java/examples/elements/picture/
keywords:
- कोड उदाहरण
- चित्र
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में चित्रों के साथ काम करें: सम्मिलित करें, क्रॉप करें, संपीड़ित करें, पुन: रंगित करें, और PPT, PPTX, और ODP प्रस्तुतियों के उदाहरणों के साथ छवियों को निर्यात करें।"
---
यह लेख **Aspose.Slides for Node.js via Java** का उपयोग करके चित्रों को सम्मिलित करने और एक्सेस करने का प्रदर्शन करता है। नीचे दिए गए उदाहरण फ़ाइल से एक छवि पढ़ते हैं, उसे स्लाइड पर रखते हैं, और फिर उसे प्राप्त करते हैं।

## **चित्र जोड़ें**

यह कोड फ़ाइल से एक चित्र पढ़ता है और उसे पहले स्लाइड पर एक चित्र फ्रेम के रूप में सम्मिलित करता है।

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // पहले स्लाइड पर छवि दिखाने वाला चित्र फ्रेम जोड़ें।
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **चित्र तक पहुँचें**

यह उदाहरण सुनिश्चित करता है कि स्लाइड में एक चित्र फ्रेम मौजूद हो और फिर वह पहले मिले फ्रेम को एक्सेस करता है।

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