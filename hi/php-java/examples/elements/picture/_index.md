---
title: चित्र
type: docs
weight: 50
url: /hi/php-java/examples/elements/picture/
keywords:
- चित्र
- चित्र फ्रेम
- चित्र जोड़ें
- चित्र तक पहुँचें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके PHP में चित्रों के साथ कार्य करें: सम्मिलित करें, बदलें, क्रॉप करें, संपीड़ित करें, पारदर्शिता और प्रभावों को समायोजित करें, आकार भरें, और PPT, PPTX तथा ODP के लिए निर्यात करें।"
---
यह दिखाता है कि **Aspose.Slides for PHP via Java** का उपयोग करके चित्र कैसे सम्मिलित और अभिगम किया जाए। नीचे दिए गए उदाहरण एक स्लाइड पर छवि डालते हैं और फिर उसे प्राप्त करते हैं।

## **चित्र जोड़ें**

यह कोड पहली स्लाइड पर छवि को चित्र फ्रेम के रूप में सम्मिलित करता है।

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // प्रेजेंटेशन संसाधनों में छवि जोड़ें।
        $ppImage = $presentation->getImages()->addImage($image);

        // पहली स्लाइड पर छवि दिखाने वाला चित्र फ्रेम सम्मिलित करें।
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **चित्र तक पहुँचें**

यह उदाहरण सुनिश्चित करता है कि स्लाइड में एक चित्र फ्रेम हो और फिर वह पहला मिला हुआ फ्रेम एक्सेस करता है।

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहला PictureFrame एक्सेस करें।
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```