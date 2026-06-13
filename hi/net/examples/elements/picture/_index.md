---
title: चित्र
type: docs
weight: 50
url: /hi/net/examples/elements/picture/
keywords:
- चित्र
- चित्र फ्रेम
- चित्र जोड़ें
- चित्र तक पहुँचें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में चित्रों के साथ काम करें: सम्मिलित करें, क्रॉप करें, संपीड़ित करें, पुनः रंगित करें, और PPT, PPTX, तथा ODP प्रस्तुतियों के लिए C# उदाहरणों के साथ छवियों को निर्यात करें।"
---
यह लेख प्रदर्शित करता है कि **Aspose.Slides for .NET** का उपयोग करके इन‑मेमोरी चित्रों से चित्र कैसे सम्मिलित और एक्सेस करें। नीचे दिए गए उदाहरण मेमोरी में एक चित्र बनाते हैं, उसे एक स्लाइड पर रखते हैं, और फिर उसे पुनः प्राप्त करते हैं।

## **छवि जोड़ें**

यह कोड एक छोटा बिटमैप बनाता है, इसे स्ट्रीम में बदलता है, और पहले स्लाइड पर इसे एक चित्र फ्रेम के रूप में सम्मिलित करता है।

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // एक सरल इन‑मेमोरी छवि बनाएं।
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // बिटमैप को MemoryStream में बदलें।
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // छवि को प्रस्तुति में जोड़ें।
    var image = presentation.Images.AddImage(imageStream);

    // पहली स्लाइड पर छवि दिखाने वाला चित्र फ्रेम सम्मिलित करें।
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **छवि तक पहुँचें**

यह उदाहरण सुनिश्चित करता है कि स्लाइड में एक चित्र फ्रेम मौजूद है और फिर पहले मिलने वाले चित्र फ्रेम तक पहुँचता है।

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // कम से कम एक चित्र फ्रेम मौजूद हो, यह सुनिश्चित करें।
    using var bitmap = new Bitmap(40, 40);

    // बिटमैप को MemoryStream में बदलें।
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // छवि को प्रस्तुति में जोड़ें।
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // स्लाइड पर पहले चित्र फ्रेम तक पहुँचें।
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```