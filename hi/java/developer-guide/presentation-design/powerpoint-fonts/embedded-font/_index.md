---
title: Java में प्रस्तुतियों में फ़ॉन्ट एम्बेड करना
linktitle: एंबेडेड फ़ॉन्ट्स
type: docs
weight: 40
url: /hi/java/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एम्बेड करें
- फ़ॉन्ट एम्बेडिंग
- एंबेडेड फ़ॉन्ट प्राप्त करें
- एंबेडेड फ़ॉन्ट जोड़ें
- एंबेडेड फ़ॉन्ट हटाएँ
- एंबेडेड फ़ॉन्ट संकुचित करें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "PowerPoint में Aspose.Slides for Java के साथ एंबेडेड फ़ॉन्ट्स का प्रबंधन करें। फ़ॉन्ट्स जोड़ें, प्राप्त करें, हटाएँ और संकुचित करें ताकि टेक्स्ट की उपस्थिति बनी रहे और फ़ाइल आकार कम हो।"
---
## **परिचय**

एम्बेडेड फ़ॉन्ट्स फ़ॉन्ट डेटा को PowerPoint प्रस्तुति के भीतर संग्रहीत करते हैं। जब एक व्यूअर एम्बेडेड फ़ॉन्ट्स का समर्थन करता है, तो वह लक्ष्य प्रणाली पर फ़ॉन्ट स्थापित न होने पर भी उन फ़ॉन्ट्स का उपयोग करके टेक्स्ट प्रदर्शित कर सकता है। यह लाइन ब्रेक, टेक्स्ट स्पेसिंग और स्लाइड लेआउट को संरक्षित रखने में मदद करता है।

Aspose.Slides for Java आपको एम्बेडेड फ़ॉन्ट्स को प्राप्त करने, जोड़ने और हटाने की सुविधा देता है, यह [IFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/) इंटरफ़ेस के माध्यम से किया जाता है जो [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getFontsManager--) द्वारा लौटाया जाता है। आप प्रस्तुति द्वारा उपयोग नहीं किए जाने वाले अक्षरों को हटाकर एम्बेडेड फ़ॉन्ट डेटा का आकार भी कम कर सकते हैं।

नीचे के उदाहरण PPTX फ़ाइलों के साथ कार्य करते हैं। फ़ॉन्ट को एम्बेड करने से पहले सुनिश्चित करें कि उसका फ़ॉन्ट डेटा Aspose.Slides के लिए उपलब्ध है और उसका लाइसेंस एम्बेडिंग की अनुमति देता है।

## **एम्बेडेड फ़ॉन्ट्स प्राप्त करें और हटाएँ**

एक प्रस्तुति में संग्रहीत फ़ॉन्ट्स को सूचीबद्ध करने के लिए [getEmbeddedFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) का उपयोग करें। किसी फ़ॉन्ट को हटाने के लिए, उस सूची में से फ़ॉन्ट को [removeEmbeddedFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) में पास करें, फिर प्रस्तुति को सहेजें।

निम्न उदाहरण `EmbeddedFonts.pptx` में एम्बेडेड फ़ॉन्ट्स को सूचीबद्ध करता है और यदि उपस्थित हो तो Calibri को हटाता है:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

एक एम्बेडेड फ़ॉन्ट को हटाने से उसका संग्रहीत फ़ॉन्ट डेटा हट जाता है; यह टेक्स्ट को असाइन किए गए फ़ॉन्ट को नहीं बदलता। यदि फ़ॉन्ट लक्ष्य प्रणाली पर स्थापित है, तो टेक्स्ट अभी भी उसका उपयोग कर सकता है। अन्यथा, रेंडरिंग के दौरान [फ़ॉन्ट प्रतिस्थापन](/slides/hi/java/font-substitution/) आवश्यक हो सकता है, जिससे लेआउट प्रभावित हो सकता है।

## **फ़ॉन्ट डेटा और एम्बेडिंग अनुमति की जांच करें**

फ़ॉन्ट को एम्बेड करने से पहले निरीक्षण करने के लिए [IFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/) इंटरफ़ेस का उपयोग करें। प्रस्तुति में उपयोग किए गए फ़ॉन्ट्स को प्राप्त करने के लिए [IFontsManager.getFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getFonts--) को कॉल करें। प्रत्येक फ़ॉन्ट के लिए, एक [IFontData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontdata/) ऑब्जेक्ट और आवश्यक [FontStyleType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontstyletype/) मान को [IFontsManager.getFontBytes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) में पास करें। यह मेथड उस फ़ॉन्ट शैली के बाइनरी डेटा को लौटाता है, या जब अनुरोधित फ़ॉन्ट या शैली उपलब्ध नहीं होती तो `null` लौटाता है। `null` परिणाम को [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) में पास न करें, क्योंकि यह मेथड बाइट एरे की आवश्यकता रखता है।

[EmbeddingLevel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/embeddinglevel/) एक फ़्लैग्स एनेमरेशन है जो फ़ॉन्ट में संग्रहीत एम्बेडिंग प्रतिबंधों की रिपोर्ट करता है:

- `Installable` एम्बेडिंग और अन्य प्रणाली पर स्थायी स्थापना की अनुमति देता है, फ़ॉन्ट लाइसेंस के अधीन।
- `Restricted` केवल तभी एम्बेडिंग की अनुमति देता है जब फ़ॉन्ट के कानूनी मालिक से अनुमति प्राप्त की गई हो, जब यह एकमात्र उपयोग‑अनुमति फ्लैग हो।
- `PreviewPrint` अस्थायी रूप से दर्शाने और प्रिंट करने की अनुमति देता है; फ़ॉन्ट वाला दस्तावेज़ केवल‑पढ़ने योग्य होना चाहिए।
- `Editable` अस्थायी उपयोग की अनुमति देता है और दस्तावेज़ को संपादित और सहेजने की अनुमति देता है।
- `NoSubsetting` एक अतिरिक्त प्रतिबंध है जो केवल कुछ ग्लिफ़्स के एम्बेडिंग को प्रतिबंधित करता है। जब यह फ़्लैग मौजूद हो तो सभी अक्षर एम्बेड किए जाएँ।
- `BitmapOnly` एक अतिरिक्त प्रतिबंध है जो केवल बिटमैप स्ट्राइक्स के एम्बेडिंग की अनुमति देता है, आउटलाइन डेटा नहीं। यदि फ़ॉन्ट में बिटमैप स्ट्राइक्स नहीं हैं, तो इसे एम्बेड नहीं किया जा सकता।

पहले चार मान उपयोग‑अनुमति का वर्णन करते हैं, जबकि `NoSubsetting` और `BitmapOnly` को उनके साथ जोड़ा जा सकता है। बिटवाइज़ ऑपरेशनों के साथ इन संशोधकों की जाँच करें। क्योंकि `Installable` शून्य है, उपयोग‑अनुमति बिट्स को मास्क करके परिणाम की तुलना `Installable` से करें, न कि इसे फ्लैग के रूप में जाँचें। वर्तमान फ़ॉन्ट्स को अधिकतम एक उपयोग‑अनुमति बिट सेट करना चाहिए। पुराने फ़ॉन्ट्स के साथ संगतता के लिए जो एक से अधिक सेट कर सकते हैं, नीचे दिया गया हेल्पर सबसे कम प्रतिबंधित अनुमति चुनता है: `Editable`, फिर `PreviewPrint`, फिर `Restricted`।

निम्न उदाहरण प्रत्येक फ़ॉन्ट द्वारा `getFonts` से लौटाए गए नियमित, बोल्ड, इटैलिक और बोल्ड‑इटैलिक डेटा का ऑडिट करता है। यह उपलब्ध नहीं होने वाली शैलियों, प्रतिबंधित फ़ॉन्ट्स, केवल‑बिटमैप फ़ॉन्ट्स, केवल‑पूर्वावलोकन‑और‑प्रिंट फ़ॉन्ट्स (क्योंकि आउटपुट अभी भी संपादन योग्य रहता है), और पहले से एम्बेडेड फ़ॉन्ट्स को छोड़ देता है। यदि किसी उपलब्ध शैली में `NoSubsetting` है, तो वह फ़ॉन्ट परिवार के सभी अक्षर एम्बेड करता है।

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह निरीक्षण प्रत्येक फ़ॉन्ट फ़ाइल में एन्कोड किए गए प्रतिबंधों की रिपोर्ट करता है। यह लाइसेंस प्रदान नहीं करता, यह प्रमाणित नहीं करता कि आपने फ़ॉन्ट कानूनी रूप से प्राप्त किया है, या एम्बेडेड कॉपी वितरित करने से पहले फ़ॉन्ट के लाइसेंस समझौते की जाँच को बदलता है।

## **एम्बेडेड फ़ॉन्ट्स जोड़ें**

एक फ़ॉन्ट को एम्बेड करने के लिए [addEmbeddedFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) का उपयोग करें। इसके ओवरलोड्स या तो एक [IFontData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontdata/) ऑब्जेक्ट या फ़ॉन्ट डेटा वाले बाइट एरे को स्वीकार करते हैं। कौन से अक्षर शामिल किए जाएँ, इसे नियंत्रित करने वाला एनेमरेशन [EmbedFontCharacters](https://reference.aspose.com/slides/hi/java/com.aspose.slides/embedfontcharacters/) है:

- [All](https://reference.aspose.com/slides/hi/java/com.aspose.slides/embedfontcharacters/) फ़ॉन्ट के सभी अक्षर एम्बेड करता है। इस विकल्प का उपयोग तब करें जब प्राप्तकर्ता को प्रस्तुति को संपादित करने और नया टेक्स्ट दर्ज करने की आवश्यकता हो।
- [OnlyUsed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/embedfontcharacters/) केवल प्रस्तुति में उपयोग किए गए अक्षरों को एम्बेड करता है ताकि फ़ाइल आकार घटाया जा सके। इस विकल्प का चयन तब करें जब प्रस्तुति मुख्यतः देखने के लिए तैयार हो।

निम्न उदाहरण [getFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getFonts--) का उपयोग करके `Fonts.pptx` में उपयोग किए गए फ़ॉन्ट्स को प्राप्त करता है और उन फ़ॉन्ट्स को एम्बेड करता है जो पहले से एम्बेड नहीं हैं। जोड़ने के लिए फ़ॉन्ट्स को कोड चलाने वाली मशीन पर उपलब्ध होना चाहिए। मौजूदा एम्बेडेड फ़ॉन्ट्स अपने वर्तमान कैरेक्टर सेट को बनाए रखते हैं।

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एम्बेडेड फ़ॉन्ट्स को संकुचित करें**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) एम्बेडेड फ़ॉन्ट डेटा को अनावश्यक अक्षरों को हटाकर कम करता है। यह उन फ़ॉन्ट्स पर कार्य करता है जो पहले से एम्बेडेड हैं, इसलिए आकार में कमी इस पर निर्भर करती है कि प्रस्तुति में कितना अनउपयोगित फ़ॉन्ट डेटा है।

निम्न उदाहरण `EmbeddedFonts.pptx` में फ़ॉन्ट्स को संकुचित करता है और परिणाम को एक अलग फ़ाइल के रूप में सहेजता है:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि प्राप्तकर्ताओं को बाद में टेक्स्ट जोड़ने की आवश्यकता हो सकती है तो मूल फ़ाइल को रखें। संकुचन के दौरान हटाए गए अक्षर एम्बेडेड फ़ॉन्ट से अब उपलब्ध नहीं रहेंगे, भले ही आपने मूल रूप से सभी अक्षर एम्बेड किए हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जांच सकता हूँ कि एम्बेडेड फ़ॉन्ट रेंडरिंग के दौरान अभी भी प्रतिस्थापित होगा या नहीं?**

[getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) को उसी पर्यावरण में कॉल करें जहाँ आप प्रस्तुति रेंडर कर रहे हैं, ताकि देखा जा सके कि Aspose.Slides कौन से फ़ॉन्ट्स को बदल देगा। साथ ही [फ़ॉन्ट प्रतिस्थापन](/slides/hi/java/font-substitution/) सेटिंग्स और [फ़ॉन्ट फ़ॉलबैक](/slides/hi/java/fallback-font/) नियमों की जाँच करें। फ़ॉलबैक गुम अक्षरों को संभालता है, इसलिए फ़ॉन्ट को एम्बेड करने से उन अक्षरों का समाधान नहीं होता जो फ़ॉन्ट स्वयं में नहीं होते।

**क्या मुझे Arial और Calibri जैसे सामान्य फ़ॉन्ट्स को एम्बेड करना चाहिए?**

निर्णय लक्ष्य पर्यावरण पर आधारित होना चाहिए। यदि आवश्यक फ़ॉन्ट्स प्रत्येक मशीन पर उपलब्ध हैं जो प्रस्तुति खोलती या रेंडर करती है, तो उन्हें एम्बेड करने से अनावश्यक फ़ाइल आकार बढ़ सकता है। यदि प्राप्तकर्ताओं या सर्वरों के पास ये फ़ॉन्ट्स नहीं हो सकते, तो उन्हें एम्बेड करना इच्छित रूप को संरक्षित रखने में मदद कर सकता है, बशर्ते उनके लाइसेंस एम्बेडिंग की अनुमति दें।