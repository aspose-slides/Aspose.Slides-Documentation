---
title: प्रेज़ेंटेशन संकुचन
description: छवि संपीड़न और सहेजने की सेटिंग्स के साथ प्रस्तुतियों का आकार घटाएँ।
type: docs
url: /hi/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **अवलोकन**

चित्रों को संकुचित करें, जब आवश्यकता न हो तो क्रॉप किए गए छवि क्षेत्रों को हटाएँ, और सहेजने से पहले प्रस्तुति संपीड़न सेटिंग्स चुनें। यह बड़े फ़ोटो या दोहराए गए मीडिया वाले डेक्स के लिए उपयोगी है। बचत की मात्रा आपके चुने हुए सामग्री और सेटिंग्स पर निर्भर करती है।

## **उपयोग उदाहरण**

यह C# उदाहरण Aspose.Slides for .NET का उपयोग करता है। यह स्पष्ट रूप से 1600 × 900 पिक्सेल ग्रेडिएंट PNG बनाता है, इसे एक छोटे चित्र फ्रेम में सम्मिलित करता है, और *before.pptx* के रूप में सहेजता है। फिर यह चित्र को 96 DPI लक्ष्य रिजॉल्यूशन में संकुचित करता है और *compressed.pptx* के रूप में सहेजता है। दोनों फ़ाइल आकारों और प्रीव्यू की तुलना करें: बचत इनपुट चित्र और प्रदर्शित आकार पर निर्भर करती है।

सेटअप के लिए, देखें [Aspose.Slides for .NET स्थापित करें](/slides/hi/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **अक्सर पूछे जाने वाले प्रश्न**

### **क्या यह एकल संपूर्ण‑फ़ाइल अनुकूलन स्विच है?**

Aspose.Slides for .NET 26.11 में [Compress.CompressPresentation](/slides/hi/net/low-code-presentation-operations/#compress-the-whole-presentation) जोड़ता है, जो अप्रयुक्त लेआउट/मास्टर हटाने, एम्बेडेड‑फ़ॉन्ट सबसेटिंग और 150‑DPI चित्र संपीड़न को संयोजित करता है। यह स्थायी रूप से क्रॉप किए गए चित्र क्षेत्रों को हटाता है। केवल‑चित्र प्रोसेसिंग के लिए, Compress.CompressImages का उपयोग करें; अधिक सूक्ष्म नियंत्रण के लिए, ऊपर दिए गए प्रति‑चित्र वर्कफ़्लो को रखें। ये नए सहायक निर्दिष्ट .NET संस्करण के लिए विशिष्ट हैं; अन्य SDKs के लिए संबंधित मार्गदर्शिका देखें।

### **क्या छवि संपीड़न संपादन योग्य टेक्स्ट या चार्ट को बदलता है?**

चित्र संपीड़न चित्र डेटा को लक्षित करता है, न कि संपादन योग्य टेक्स्ट या चार्ट डेटा को। छवियों की समीक्षा करें क्योंकि आकार बदलना या पुनः‑संकुचन उनके विवरण को कम कर सकता है।

### **प्रेज़ेंटेशन छवियों के लिए मुझे रिज़ॉल्यूशन कैसे चुनना चाहिए?**

दर्शाए गए चित्र के आकार और इच्छित स्क्रीन या प्रिंट उपयोग के आधार पर लक्ष्य चुनें। बड़े डिस्प्ले, प्रिंटिंग और विस्तृत आरेखों के लिए अधिक रिज़ॉल्यूशन रखें, और मूल को हटाने से पहले रेंडर किया गया आउटपुट तुलना करें।

## **मार्गदर्शिकाएँ**

- [.NET में प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें](/slides/hi/net/image/)

संबंधित फीचर: [अप्रयुक्त मास्टर, लेआउट और मीडिया हटाएँ](/slides/hi/features/remove-unused-content/).

## चलाने योग्य .NET उदाहरण

- [प्रेज़ेंटेशन आकार घटाएँ](/slides/hi/net/examples/optimization-batch/compression/)