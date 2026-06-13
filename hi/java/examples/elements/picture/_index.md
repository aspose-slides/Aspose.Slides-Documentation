---
title: चित्र
type: docs
weight: 50
url: /hi/java/examples/elements/picture/
keywords:
- कोड उदाहरण
- चित्र
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में चित्रों के साथ कार्य करें: सम्मिलित करें, क्रॉप करें, संपीड़ित करें, पुनरंगित करें, और PPT, PPTX, और ODP प्रस्तुतियों के लिए Java उदाहरणों के साथ छवियों को निर्यात करें।"
---
यह लेख दिखाता है कि **Aspose.Slides for Java** का उपयोग करके इन‑मेमोरी इमेज़ से चित्रों को कैसे डालें और पहुँचें। नीचे दिए गए उदाहरण एक इमेज़ को मेमोरी में बनाते हैं, उसे एक स्लाइड पर रखते हैं, और फिर उसे प्राप्त करते हैं।

## **चित्र जोड़ें**

यह कोड एक छोटा बिटमैप उत्पन्न करता है, उसे स्ट्रीम में बदलता है, और पहले स्लाइड पर उसे चित्र फ्रेम के रूप में डालता है।

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // एक सरल इन‑मेमोरी छवि बनाएं।
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // बिटमैप को बाइट एरे में बदलें।
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // छवि को प्रस्तुति में जोड़ें।
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // पहली स्लाइड पर छवि दिखाने वाला चित्र फ्रेम डालें।
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **चित्र तक पहुँचें**

यह उदाहरण सुनिश्चित करता है कि स्लाइड में एक चित्र फ्रेम मौजूद है और फिर पहली मिली हुई फ्रेम तक पहुँचता है।

```java
public static void accessPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        BufferedImage bitmap = new BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB);
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

        IPictureFrame pictureFrame = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IPictureFrame) {
                pictureFrame = (IPictureFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```