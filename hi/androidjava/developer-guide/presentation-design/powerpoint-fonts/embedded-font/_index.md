---
title: Android पर प्रस्तुतियों में फ़ॉन्ट एम्बेड करें
linktitle: एम्बेडेड फ़ॉन्ट्स
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
- एम्बेडेड फ़ॉन्ट संकुचित करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint में एम्बेडेड फ़ॉन्ट प्रबंधित करें। फ़ॉन्ट जोड़ें, प्राप्त करें, हटाएँ और संकुचित करें ताकि पाठ की उपस्थिति बनी रहे और फ़ाइल आकार घटे।"
---
## **परिचय**

फ़ॉन्ट एम्बेड करने से फ़ॉन्ट डेटा PowerPoint प्रस्तुति के अंदर संग्रहीत हो जाता है। जब कोई व्यूअर एम्बेडेड फ़ॉन्ट का समर्थन करता है, तो वह लक्षित सिस्टम में फ़ॉन्ट इंस्टॉल न होने पर भी उन फ़ॉन्टों का उपयोग करके पाठ प्रदर्शित कर सकता है। इससे लाइन ब्रेक, पाठ स्पेसिंग और स्लाइड लेआउट बना रहता है।

Aspose.Slides for Android via Java आपको एम्बेडेड फ़ॉन्ट को प्राप्त करने, जोड़ने और हटाने की सुविधा देता है, यह [IFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/) इंटरफ़ेस के माध्यम से होता है, जिसे [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getFontsManager--) द्वारा लौटाया जाता है। आप प्रस्तुति द्वारा उपयोग न किए गए अक्षरों को हटाकर एम्बेडेड फ़ॉन्ट डेटा का आकार भी कम कर सकते हैं।

नीचे दिए गए उदाहरण PPTX फ़ाइलों के साथ काम करते हैं। फ़ॉन्ट एम्बेड करने से पहले सुनिश्चित करें कि उसका फ़ॉन्ट डेटा Aspose.Slides के लिए उपलब्ध है और उसका लाइसेंस एम्बेडिंग की अनुमति देता है।

## **एम्बेडेड फ़ॉन्ट प्राप्त करें और हटाएँ**

[ getEmbeddedFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) का उपयोग करके प्रस्तुति में संग्रहीत फ़ॉन्ट की सूची प्राप्त करें। हटाने के लिए, उस सूची में से एक फ़ॉन्ट को [removeEmbeddedFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) को पास करें, फिर प्रस्तुति को संग्रहीत करें।

निम्न उदाहरण `EmbeddedFonts.pptx` में एम्बेडेड फ़ॉन्ट की सूची दिखाता है और यदि मौजूद हों तो Calibri को हटाता है:

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

एक एम्बेडेड फ़ॉन्ट को हटाने से उसका संग्रहीत फ़ॉन्ट डेटा हट जाता है; यह टेक्स्ट पर असाइन किए गए फ़ॉन्ट को नहीं बदलता। यदि फ़ॉन्ट लक्ष्य सिस्टम में इंस्टॉल है, तो टेक्स्ट अभी भी उसे उपयोग कर सकता है। अन्यथा, रेंडरिंग को [फ़ॉन्ट प्रतिस्थापन](/slides/hi/androidjava/font-substitution/) की आवश्यकता हो सकती है, जिससे लेआउट प्रभावित हो सकता है।

## **फ़ॉन्ट डेटा और एम्बेडिंग अनुमतियों का निरीक्षण करें**

[IFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/) इंटरफ़ेस का उपयोग करके फ़ॉन्ट एम्बेड करने से पहले उनका निरीक्षण करें। प्रस्तुति में उपयोग किए गए फ़ॉन्ट को प्राप्त करने के लिए [IFontsManager.getFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) को कॉल करें। प्रत्येक फ़ॉन्ट के लिए, एक [IFontData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontdata/) ऑब्जेक्ट और आवश्यक [FontStyleType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontstyletype/) मान को [IFontsManager.getFontBytes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) को पास करें। यह मेथड उस फ़ॉन्ट शैली का बाइनरी डेटा लौटाता है, या जब अनुरोधित फ़ॉन्ट या शैली उपलब्ध नहीं हो तो `null` लौटाता है। `null` परिणाम को [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) को पास न करें, क्योंकि वह मेथड बाइट ऐरे की आवश्यकता रखता है।

[EmbeddingLevel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/embeddinglevel/) एक फ़्लैग्स एनेमरेशन है जो फ़ॉन्ट में संग्रहीत एम्बेडिंग प्रतिबंधों की रिपोर्ट करता है:

- `Installable` एम्बेडिंग और अन्य सिस्टम पर स्थायी इंस्टॉलेशन की अनुमति देता है, फ़ॉन्ट लाइसेंस के अनुसार।
- `Restricted` केवल तब एम्बेडिंग की अनुमति देता है जब फ़ॉन्ट के कानूनी मालिक से अनुमति प्राप्त हो और यह केवल उपयोग-अनुमति फ़्लैग हो।
- `PreviewPrint` अस्थायी रूप से देखना और प्रिंट करना अनुमति देता है; फ़ॉन्ट वाला दस्तावेज़ केवल रीड‑ओनली होना चाहिए।
- `Editable` अस्थायी उपयोग की अनुमति देता है और दस्तावेज़ को संपादित और सहेजा जा सकता है।
- `NoSubsetting` अतिरिक्त प्रतिबंध है जो glyphs के केवल उपसमुच्चय को एम्बेड करने से रोकता है। यह फ़्लैग मौजूद हो तो सभी अक्षर एम्बेड करें।
- `BitmapOnly` अतिरिक्त प्रतिबंध है जो केवल bitmap strikes को एम्बेड करने की अनुमति देता है, outline डेटा नहीं। यदि फ़ॉन्ट में bitmap strikes नहीं हैं, तो उसे एम्बेड नहीं किया जा सकता।

पहले चार मान उपयोग अनुमति का वर्णन करते हैं, जबकि `NoSubsetting` और `BitmapOnly` को उनके साथ मिलाया जा सकता है। बिटवाइज़ ऑपरेशन्स के साथ मॉडिफ़ायर की जाँच करें। क्योंकि `Installable` का मान शून्य है, उपयोग‑अनुमति बिट्स को मास्क करके परिणाम की तुलना `Installable` से करें, न कि इसे फ़्लैग के रूप में जाँचें। वर्तमान फ़ॉन्ट्स को अधिकतम एक उपयोग‑अनुमति बिट सेट करना चाहिए। पुरानी फ़ॉन्ट्स जो एक से अधिक बिट सेट करते हैं, उनके साथ संगतता हेतु नीचे दिया गया हेल्पर सबसे कम प्रतिबंधित अनुमति चुनता है: `Editable`, फिर `PreviewPrint`, फिर `Restricted`।

निम्न उदाहरण `getFonts` द्वारा लौटाए गए प्रत्येक फ़ॉन्ट के नियमित, बोल्ड, इटैलिक और बोल्ड‑इटैलिक डेटा का ऑडिट करता है। यह उपलब्ध न होने वाली शैलियों, प्रतिबंधित फ़ॉन्ट्स, केवल‑bitmap फ़ॉन्ट्स, प्रीव्यू‑प्रिंट‑केवल फ़ॉन्ट्स (क्योंकि आउटपुट अभी भी संपादनीय रहता है), और पहले से एम्बेडेड फ़ॉन्ट्स को स्किप करता है। यदि किसी उपलब्ध शैली में `NoSubsetting` हो, तो वह फ़ॉन्ट परिवार के सभी अक्षर एम्बेड करता है।

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

यह निरीक्षण प्रत्येक फ़ॉन्ट फ़ाइल में एन्कोडेड प्रतिबंधों की रिपोर्ट करता है। यह लाइसेंस प्रदान नहीं करता, न ही यह प्रमाणित करता कि आपने फ़ॉन्ट कानूनी रूप से प्राप्त किया है, और न ही एम्बेडेड कॉपी वितरित करने से पहले फ़ॉन्ट के लाइसेंस समझौते की जाँच को प्रतिस्थापित करता है।

## **एम्बेडेड फ़ॉन्ट जोड़ें**

[addEmbeddedFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) का उपयोग करके फ़ॉन्ट एम्बेड करें। इसके ओवरलोड्स या तो एक [IFontData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontdata/) ऑब्जेक्ट या फ़ॉन्ट डेटा वाली बाइट ऐरे स्वीकार करते हैं। [EmbedFontCharacters](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/embedfontcharacters/) एनेमरेशन यह नियंत्रित करता है कि कौन से अक्षर शामिल किए जाएँ:

- [All](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/embedfontcharacters/) फ़ॉन्ट के सभी अक्षर एम्बेड करता है। जब प्राप्तकर्ता को प्रस्तुति को संपादित करने और नया टेक्स्ट दर्ज करने की आवश्यकता हो तो इस विकल्प का उपयोग करें।
- [OnlyUsed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/embedfontcharacters/) केवल प्रस्तुति में उपयोग किए गए अक्षर एम्बेड करता है ताकि फ़ाइल आकार घटे। यह विकल्प मुख्य रूप से व्यूइंग के लिए बनाई गई तैयार प्रस्तुति के लिए उपयुक्त है।

निम्न उदाहरण `Fonts.pptx` में उपयोग किए गए फ़ॉन्ट को प्राप्त करने के लिए [getFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) का उपयोग करता है और उन फ़ॉन्ट्स को एम्बेड करता है जो पहले से एम्बेड नहीं हैं। जोड़ने वाले फ़ॉन्ट्स Android डिवाइस पर उपलब्ध होने चाहिए या Aspose.Slides के साथ रजिस्टर्ड होने चाहिए। मौजूदा एम्बेडेड फ़ॉन्ट्स अपने वर्तमान कैरेक्टर सेट को बनाए रखते हैं।

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

## **एम्बेडेड फ़ॉन्ट संकुचित करें**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) एम्बेडेड फ़ॉन्ट डेटा को उपयोग न किए गए अक्षरों को हटाकर घटाता है। यह पहले से एम्बेडेड फ़ॉन्ट्स पर काम करता है, इसलिए आकार में कमी इस बात पर निर्भर करती है कि प्रस्तुति में कितना अनुपयोगी फ़ॉन्ट डेटा मौजूद है।

निम्न उदाहरण `EmbeddedFonts.pptx` में फ़ॉन्ट को संकुचित करता है और परिणाम को एक अलग फ़ाइल के रूप में सहेजता है:

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

यदि प्राप्तकर्ताओं को बाद में टेक्स्ट जोड़ने की आवश्यकता हो सकती है तो मूल फ़ाइल रखें। संकुचन के दौरान हटाए गए अक्षर एम्बेडेड फ़ॉन्ट से अब उपलब्ध नहीं रहेंगे, भले ही आपने शुरू में सभी अक्षर एम्बेड किए हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं जांच सकता हूँ कि एम्बेडेड फ़ॉन्ट रेंडरिंग के दौरान अभी भी प्रतिस्थापित होगा?**

[ getSubstitutions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) को उस पर्यावरण में कॉल करें जहाँ आप प्रस्तुति रेंडर करते हैं, ताकि देखा जा सके कि Aspose.Slides किन फ़ॉन्ट को बदल देगा। साथ ही [फ़ॉन्ट प्रतिस्थापन](/slides/hi/androidjava/font-substitution/) सेटिंग्स और [फ़ॉन्ट फॉलबैक](/slides/hi/androidjava/fallback-font/) नियमों की जाँच करें। फॉलबैक लापता अक्षरों को संभालता है, इसलिए फ़ॉन्ट एम्बेड करने से वह अक्षर नहीं जुड़ते जो फ़ॉन्ट स्वयं में नहीं होते।

**क्या मुझे Arial और Calibri जैसे सामान्य फ़ॉन्ट एम्बेड करने चाहिए?**

निर्णय लक्ष्य पर्यावरण पर आधारित होना चाहिए। यदि आवश्यक फ़ॉन्ट हर डिवाइस पर उपलब्ध हैं जो प्रस्तुति खोलता या रेंडर करता है, तो एम्बेड करने से अनावश्यक फ़ाइल आकार बढ़ सकता है। यदि प्राप्तकर्ता या सर्वर के पास ये फ़ॉन्ट नहीं हैं, तो एम्बेड करने से इच्छित रूप बनाए रखने में मदद मिलती है, बशर्ते उनके लाइसेंस एम्बेडिंग की अनुमति दें।