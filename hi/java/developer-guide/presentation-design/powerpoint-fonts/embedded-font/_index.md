---
title: Java का उपयोग करके प्रस्तुतियों में फ़ॉन्ट एम्बेड करें
linktitle: फ़ॉन्ट एम्बेड करना
type: docs
weight: 40
url: /hi/java/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एम्बेड करें
- फ़ॉन्ट एम्बेडिंग
- एम्बेडेड फ़ॉन्ट प्राप्त करें
- एम्बेडेड फ़ॉन्ट जोड़ें
- एम्बेडेड फ़ॉन्ट हटाएँ
- एम्बेडेड फ़ॉन्ट संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में TrueType फ़ॉन्ट एम्बेड करें, जिससे सभी प्लेटफ़ॉर्म पर सटीक रेंडरिंग सुनिश्चित हो।"
---
## **परिचय**

**PowerPoint में एम्बेडेड फ़ॉन्ट** उपयोगी होते हैं जब आप चाहते हैं कि आपका प्रस्तुतीकरण किसी भी सिस्टम या डिवाइस पर खुलने पर सही दिखे। यदि आपने अपने काम में रचनात्मकता दिखाने के कारण कोई तृतीय‑पक्षीय या गैर‑मानक फ़ॉन्ट उपयोग किया है, तो आपको फ़ॉन्ट एम्बेड करने के और भी कारण मिलते हैं। अन्यथा (बिना एम्बेडेड फ़ॉन्ट के), स्लाइड्स पर पाठ या संख्याएँ, लेआउट, स्टाइलिंग आदि बदल सकते हैं या भ्रमित करने वाले आयत में बदल सकते हैं।

The [FontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsManager) class, [FontData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontdata/) class, [Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/) class, and their interfaces contain most of the properties and methods you need to work with embedded fonts in PowerPoint presentations.

## **एम्बेडेड फ़ॉन्ट प्राप्त करें और हटाएँ**

Aspose.Slides [getEmbeddedFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) method (exposed by the [FontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsManager) class) आपको प्रस्तुति में एम्बेडेड फ़ॉन्ट प्राप्त (या पता लगाने) की अनुमति देता है। फ़ॉन्ट हटाने के लिए, वही क्लास द्वारा प्रदान किया गया [removeEmbeddedFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) method उपयोग किया जाता है।

यह Java कोड आपको दिखाता है कि प्रस्तुति से एम्बेडेड फ़ॉन्ट कैसे प्राप्त और हटाए जाएँ:
```java
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // एक स्लाइड रेंडर करता है जिसमें एक टेक्स्ट फ्रेम है जो एम्बेडेड "FunSized" का उपयोग करता है
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // इमेज को डिस्क पर JPEG फ़ॉर्मेट में सेव करें
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // सभी एम्बेडेड फ़ॉन्ट प्राप्त करता है
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // "Calibri" फ़ॉन्ट खोजता है
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // "Calibri" फ़ॉन्ट हटाता है
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // प्रस्तुति को रेंडर करता है; "Calibri" फ़ॉन्ट को मौजूदा फ़ॉन्ट से बदल दिया जाता है
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // इमेज को डिस्क पर JPEG फ़ॉर्मेट में सेव करें
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // एम्बेडेड "Calibri" फ़ॉन्ट के बिना प्रस्तुति को डिस्क पर सेव करता है
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एम्बेडेड फ़ॉन्ट जोड़ें**

Using the [EmbedFontCharacters](https://reference.aspose.com/slides/hi/java/com.aspose.slides/embedfontcharacters/) enum और [addEmbeddedFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) method के दो ओवरलोड का उपयोग करके, आप प्रस्तुति में फ़ॉन्ट एम्बेड करने के लिए अपनी पसंदीदा (एम्बेडिंग) नियम चुन सकते हैं। यह Java कोड आपको दिखाता है कि प्रस्तुति में फ़ॉन्ट कैसे एम्बेड और जोड़ें:
```java
// प्रस्तुति को लोड करता है
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // प्रस्तुति को डिस्क पर सेव करता है
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एम्बेडेड फ़ॉन्ट संपीड़ित करें**

आपको प्रस्तुति में एम्बेडेड फ़ॉन्ट संपीड़ित करने और फ़ाइल आकार घटाने के लिए, Aspose.Slides [compressEmbeddedFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) method (जो [Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/) class द्वारा प्रदान किया गया है) प्रदान करता है।

यह Java कोड आपको दिखाता है कि एम्बेडेड PowerPoint फ़ॉन्ट कैसे संपीड़ित करें:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि प्रस्तुति में कोई विशिष्ट फ़ॉन्ट एम्बेड होने के बावजूद रेंडरिंग के समय अभी भी प्रतिस्थापित होगा?**  
फ़ॉन्ट मैनेजर में [substitution information](/slides/hi/java/font-substitution/) और [fallback/substitution rules](/slides/hi/java/fallback-font/) जांचें: यदि फ़ॉन्ट उपलब्ध नहीं है या प्रतिबंधित है, तो फ़ॉलबैक उपयोग किया जाएगा।

**क्या Arial/Calibri जैसे "सिस्टम" फ़ॉन्ट एम्बेड करना मूल्यवान है?**  
आमतौर पर नहीं—ये लगभग हमेशा उपलब्ध होते हैं। लेकिन "thin" वातावरण (Docker, प्री‑इंस्टॉल्ड फ़ॉन्ट के बिना Linux सर्वर) में पूर्ण पोर्टेबिलिटी के लिए, सिस्टम फ़ॉन्ट एम्बेड करने से अनपेक्षित प्रतिस्थापन का जोखिम समाप्त हो सकता है।