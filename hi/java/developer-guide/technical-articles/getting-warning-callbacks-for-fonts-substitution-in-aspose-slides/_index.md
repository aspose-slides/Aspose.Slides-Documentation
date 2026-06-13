---
title: फ़ॉन्ट प्रतिस्थापन के लिए चेतावनी कॉलबैक प्राप्त करें
type: docs
weight: 90
url: /hi/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- चेतावनी कॉलबैक
- फ़ॉन्ट प्रतिस्थापन
- रेंडरिंग प्रक्रिया
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में फ़ॉन्ट प्रतिस्थापन के लिए चेतावनी कॉलबैक प्राप्त करना सीखें और PowerPoint तथा OpenDocument प्रस्तुतियों को सटीक रूप से प्रदर्शित करें।"
---
## **परिचय**

Aspose.Slides for Java आपको फ़ॉन्ट प्रतिस्थापन के लिए चेतावनी कॉलबैक प्राप्त करने की अनुमति देता है जब आवश्यक फ़ॉन्ट रेंडरिंग के दौरान मशीन पर उपलब्ध नहीं होता है। ये कॉलबैक गायब या अनुपलब्ध फ़ॉन्ट्स के संबंध में समस्याओं का निदान करने में मदद करते हैं।

## **चेतावनी कॉलबैक सक्षम करें**

Aspose.Slides for Java प्रस्तुति स्लाइड्स को रेंडर करते समय चेतावनी कॉलबैक प्राप्त करने के लिए सरल APIs प्रदान करता है। चेतावनी कॉलबैक को कॉन्फ़िगर करने के लिए इन चरणों का पालन करें:

1. चेतावनियों को संभालने के लिए एक कस्टम कॉलबैक क्लास बनाएं जो [IWarningCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarningcallback/) इंटरफ़ेस को लागू करता हो।
1. विकल्प क्लासों जैसे कि [RenderingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/), आदि का उपयोग करके चेतावनी कॉलबैक सेट करें।
1. ऐसी प्रस्तुति लोड करें जो लक्ष्य मशीन पर उपलब्ध नहीं होने वाले फ़ॉन्ट का उपयोग करती है।
1. प्रभाव को देखने के लिए स्लाइड थंबनेल जनरेट करें या प्रस्तुति को एक्सपोर्ट करें।

**कस्टम चेतावनी कॉलबैक क्लास:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// उदाहरण आउटपुट:
//
// फ़ॉन्ट XYZ से {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}} में बदल दिया जाएगा
```

**स्लाइड थंबनेल बनाएं:**

```java
// स्लाइड रेंडरिंग के दौरान फ़ॉन्ट-संबंधी चेतावनियों को संभालने के लिए चेतावनी कॉलबैक सेट करें।
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// निर्दिष्ट फ़ाइल पथ से प्रस्तुति लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
    // प्रस्तुति में प्रत्येक स्लाइड के लिए थंबनेल चित्र बनाएँ।
    for (ISlide slide : presentation.getSlides()) {
        // निर्दिष्ट रेंडरिंग विकल्पों का उपयोग करके स्लाइड थंबनेल चित्र प्राप्त करें।
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**PDF फ़ॉर्मेट में एक्सपोर्ट करें:**

```java
// PDF निर्यात के दौरान फ़ॉन्ट-संबंधी चेतावनियों को संभालने के लिए चेतावनी कॉलबैक सेट करें।
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// निर्दिष्ट फ़ाइल पथ से प्रस्तुति लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
    // प्रस्तुति को PDF के रूप में निर्यात करें।
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**HTML फ़ॉर्मेट में एक्सपोर्ट करें:**

```java
// HTML निर्यात के दौरान फ़ॉन्ट-संबंधी चेतावनियों को संभालने के लिए चेतावनी कॉलबैक सेट करें।
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// निर्दिष्ट फ़ाइल पथ से प्रस्तुति लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
    // प्रस्तुति को HTML स्वरूप में निर्यात करें।
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```