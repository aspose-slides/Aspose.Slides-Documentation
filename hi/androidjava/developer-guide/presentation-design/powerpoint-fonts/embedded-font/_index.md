---
title: Android पर प्रस्तुतियों में फ़ॉन्ट एम्बेड करें
linktitle: फ़ॉन्ट एम्बेड करना
type: docs
weight: 40
url: /hi/androidjava/embedded-font/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में TrueType फ़ॉन्ट एम्बेड करें, जिससे सभी प्लेटफ़ॉर्म पर सटीक रेंडरिंग सुनिश्चित हो।"
---
## **परिचय**

**PowerPoint में एम्बेडेड फ़ॉन्ट** उपयोगी होते हैं जब आप चाहते हैं कि आपका प्रस्तुतिकरण किसी भी प्रणाली या डिवाइस पर खोलने पर सही दिखे। यदि आपने अपनी रचनात्मकता के कारण थर्ड‑पार्टी या गैर‑मानक फ़ॉन्ट का उपयोग किया है, तो फ़ॉन्ट एम्बेड करने के और भी कारण मिलते हैं। अन्यथा (बिना एम्बेडेड फ़ॉन्ट के), आपकी स्लाइड्स पर टेक्स्ट या नंबर, लेआउट, स्टाइलिंग आदि बदल सकते हैं या भ्रमित करने वाले आयताकार रूप में दिख सकते हैं।  

The [FontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsManager) class, [FontData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontdata/) class, [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) class, और उनके इंटरफ़ेसेस में वह अधिकांश प्रॉपर्टीज़ और मेथड्स शामिल हैं जो आपको PowerPoint प्रस्तुतियों में एम्बेडेड फ़ॉन्ट के साथ काम करने के लिए चाहिए।

## **एम्बेडेड फ़ॉन्ट प्राप्त करें और हटाएँ**

Aspose.Slides [getEmbeddedFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) मेथड (जो [FontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsManager) क्लास द्वारा प्रदर्शित है) आपको प्रस्तुति में एम्बेडेड फ़ॉन्ट प्राप्त (या पता लगाने) की सुविधा देता है। फ़ॉन्ट हटाने के लिए, [removeEmbeddedFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) मेथड (उसी क्लास द्वारा प्रदर्शित) का उपयोग किया जाता है।

यह Java कोड दिखाता है कि प्रस्तुति से एम्बेडेड फ़ॉन्ट कैसे प्राप्त और हटाएँ।

```java
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // एक स्लाइड रेंडर करता है जिसमें एक टेक्स्ट फ्रेम होता है जो एम्बेडेड "FunSized" का उपयोग करता है
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Save the image to disk in JPEG format
    // छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजें
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

    // प्रस्तुति रेंडर करता है; "Calibri" फ़ॉन्ट को मौजूदा फ़ॉन्ट से बदल दिया जाता है
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Save the image to disk in JPEG format
     // छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजें
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // प्रस्तुति को एम्बेडेड "Calibri" फ़ॉन्ट के बिना डिस्क पर सहेजता है
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एम्बेडेड फ़ॉन्ट जोड़ें**

आप [EmbedFontCharacters](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/embedfontcharacters/) एनम और [addEmbeddedFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) मेथड की दो ओवरलोड्स का उपयोग करके, प्रस्तुति में फ़ॉन्ट एम्बेड करने के लिए अपनी पसंदीदा (एम्बेडिंग) नियम चुन सकते हैं। यह Java कोड दिखाता है कि फ़ॉन्ट को कैसे एम्बेड और जोड़ें।

```java
// प्रस्तुति लोड करता है
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

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एम्बेडेड फ़ॉन्ट संपीड़ित करें**

आपको प्रस्तुति में एम्बेडेड फ़ॉन्ट को संपीड़ित करके फ़ाइल आकार घटाने की अनुमति देने के लिए, Aspose.Slides [compressEmbeddedFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) क्लास द्वारा प्रदर्शित है) प्रदान करता है।

यह Java कोड दिखाता है कि एम्बेडेड PowerPoint फ़ॉन्ट कैसे संपीड़ित करें:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि प्रस्तुति में कोई विशिष्ट फ़ॉन्ट एम्बेडिंग के बावजूद रेंडरिंग के समय अभी भी बदला जाएगा?**  
फ़ॉन्ट मैनेजर में [substitution information](/slides/hi/androidjava/font-substitution/) और [fallback/substitution rules](/slides/hi/androidjava/fallback-font/) देखें: यदि फ़ॉन्ट उपलब्ध नहीं है या प्रतिबंधित है, तो फ़ॉल्बैक उपयोग किया जाएगा।

**क्या Arial/Calibri जैसे “सिस्टम” फ़ॉन्ट एम्बेड करना मूल्यवान है?**  
आमतौर पर नहीं—वे लगभग हमेशा उपलब्ध रहते हैं। लेकिन “थिन” वातावरण (Docker, पूर्व‑स्थापित फ़ॉन्टों के बिना Linux सर्वर) में पूरी पोर्टेबिलिटी के लिए, सिस्टम फ़ॉन्ट एम्बेड करने से अप्रत्याशित प्रतिस्थापन का जोखिम समाप्त हो सकता है।