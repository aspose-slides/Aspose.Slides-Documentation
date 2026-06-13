---
title: Java में PowerPoint प्रस्तुतियों को HTML में बदलें
linktitle: PowerPoint से HTML
type: docs
weight: 30
url: /hi/java/convert-powerpoint-to-html/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से HTML
- प्रस्तुति से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- PowerPoint को HTML के रूप में सहेजें
- प्रस्तुति को HTML के रूप में सहेजें
- स्लाइड को HTML के रूप में सहेजें
- PPT को HTML के रूप में सहेजें
- PPTX को HTML के रूप में सहेजें
- PPT को HTML में निर्यात करें
- PPTX को HTML में निर्यात करें
- Java
- Aspose.Slides
description: "Java में PowerPoint प्रस्तुतियों को HTML में बदलें। PPT और PPTX फ़ाइलें, चयनित स्लाइड्स, नोट्स, फ़ॉन्ट, चित्र, SVG और मीडिया निर्यात करने के लिए Aspose.Slides का उपयोग करें।"
---
## **अवलोकन**

Aspose.Slides for Java Microsoft PowerPoint के बिना PowerPoint प्रस्तुतियों को HTML के रूप में सहेज सकता है। बुनियादी रूपांतरण केवल एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) लोड और [SaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) के साथ एक `save` कॉल है। जब आपको निर्यातित लेआउट, फ़ॉन्ट, चित्र, नोट्स, टिप्पणी, SVG आउटपुट, या लिंक किए गए संसाधनों को नियंत्रित करने की आवश्यकता हो तो [HtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/) का उपयोग करें।

यह गाइड व्यावहारिक HTML निर्यात परिदृश्यों पर केंद्रित है:

- पूरी प्रस्तुति या चयनित स्लाइड्स निर्यात करें।
- स्थिर-लेआउट, उत्तरदायी, या SVG-आधारित HTML उत्पन्न करें।
- स्पीकर नोट्स और टिप्पणियों को शामिल करें।
- छवि गुणवत्ता और क्रॉप किए गए चित्र डेटा को नियंत्रित करें।
- फ़ॉन्ट एम्बेड करें या फ़ॉन्ट फ़ाइलों को अलग से सहेजें।
- बाहरी संसाधनों और मीडिया फ़ाइलों को कैसे लिखा और संदर्भित किया जाए, चुनें।

डिफ़ॉल्ट रूप से, HTML निर्यात एक स्वनिहित HTML दस्तावेज़ बनाता है जहाँ अधिकांश संसाधन एम्बेड होते हैं। यह एक फ़ाइल साझा करने के लिए सुविधाजनक है, लेकिन आउटपुट आकार बढ़ा सकता है। वेब प्रकाशन के लिए, बाहरी संसाधनों पर विचार करें, छवि DPI कम करें, और केवल उन फ़ॉन्ट को एम्बेड करें जो लक्ष्य परिवेश में विश्वसनीय रूप से उपलब्ध नहीं हैं।

## **प्रस्तुति को HTML में बदलें**

PowerPoint प्रस्तुति को HTML में निर्यात करने के लिए, इसे [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) से लोड करें और [SaveFormat.Html](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) के साथ सहेजें।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

यह उदाहरण एक HTML फ़ाइल लिखता है। प्रस्तुति ऑब्जेक्ट को `finally` ब्लॉक में डिस्पोज़ किया जाता है, जो निर्यात के बाद फ़ाइल हैंडल और रेंडरिंग संसाधन रिलीज़ करता है।

## **HtmlOptions का उपयोग करें**

[HtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/) HTML निर्यात के लिए मुख्य कॉन्फ़िगरेशन क्लास है। सामान्य सेटिंग्स में शामिल हैं:

- `SlidesLayoutOptions`: नोट्स, टिप्पणियों, हैंडआउट या अन्य लेआउट जानकारी जोड़ता है।
- `HtmlFormatter`: HTML दस्तावेज़ संरचना को बदलता है या फ़ॉर्मेटिंग को कंट्रोलर को सौंपता है।
- `SlideImageFormat`: स्लाइड्स को प्रदर्शित करने का तरीका बदलता है, उदाहरण के लिए SVG के रूप में।
- `PicturesCompression`: चित्र DPI और आउटपुट आकार को नियंत्रित करता है।
- `DeletePicturesCroppedAreas`: क्रॉप किए गए चित्र डेटा को रखता या हटाता है।
- `SvgResponsiveLayout`: निर्यातित SVG सामग्री को उसके कंटेनर के अनुसार अनुकूल बनाता है।
- `ShowHiddenSlides`: आवश्यकता होने पर छिपी स्लाइड्स को शामिल करता है।

निम्नलिखित अनुभाग सबसे सामान्य विकल्पों को अलग‑अलग दर्शाते हैं ताकि आप केवल वही विकल्प संयोजित कर सकें जो आपके कार्यप्रवाह को चाहिए।

## **चयनित स्लाइड्स को HTML में बदलें**

`Presentation.save` ओवरलोड जो स्लाइड नंबर स्वीकार करता है, 1‑आधारित स्लाइड स्थितियों का उपयोग करता है। नीचे दिया गया लूप प्रत्येक स्लाइड को एक अलग HTML फ़ाइल में सहेजता है।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

जब किसी वेबसाइट या एप्लिकेशन को प्रत्येक स्लाइड के लिए एक HTML पृष्ठ चाहिए, तब इस पैटर्न का उपयोग करें। यदि प्रत्येक स्लाइड का लेआउट समान होना चाहिए, तो एक [HtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/) इंस्टेंस बनाएँ और इसे प्रत्येक `save` कॉल में पास करें।

## **जवाबदेह (Responsive) HTML बनाएं**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmlformatter/) के माध्यम से उत्तरदायी HTML आउटपुट प्रदान करता है। जब निर्यातित पृष्ठ को ब्राउज़र की चौड़ाई के अनुसार बेहतर अनुकूल होना चाहिए, तब इसका उपयोग करें।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

SVG‑आधारित उत्तरदायी लेआउट के लिए, [HtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/) पर `SvgResponsiveLayout` सेट करें। यह उपयोगी है जब स्लाइड सामग्री को स्केलेबल SVG मार्कअप के रूप में निर्यात किया जाता है।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **स्पीकर नोट्स और टिप्पणियां शामिल करें**

स्पीकर नोट्स या टिप्पणियों को शामिल करने के लिए `HtmlOptions.setSlidesLayoutOptions` के माध्यम से [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notescommentslayoutingoptions/) का उपयोग करें। नोट्स और टिप्पणियां डिफ़ॉल्ट रूप से छिपी रहती हैं जब तक आप उनकी स्थिति नहीं चुनते।

मान लीजिए स्रोत प्रस्तुति में स्पीकर नोट्स हैं:

![PowerPoint में स्पीकर नोट्स वाला स्लाइड](slide_with_notes.png)

निम्नलिखित कोड स्लाइड सामग्री को स्लाइड के नीचे स्पीकर नोट्स के साथ निर्यात करता है।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

निर्यातित HTML में नोट्स क्षेत्र शामिल होता है:

![स्लाइड और स्पीकर नोट्स के साथ HTML आउटपुट](HTML_with_notes.png)

टिप्पणियां निर्यात करने के लिए, `CommentsPosition` सेट करें, उदाहरण के लिए `CommentsPositions.Right` या `CommentsPositions.Bottom`। यदि आपको केवल टिप्पणियां चाहिए, तो `NotesPosition` को छोड़ दें। यदि आपको दोनों नोट्स और टिप्पणियां चाहिए, तो दोनों प्रॉपर्टी सेट करें।

## **छवि गुणवत्ता और क्रॉप किए गए क्षेत्रों को नियंत्रित करें**

HTML निर्यात स्लाइड चित्रों को संपीड़ित कर आउटपुट आकार घटा सकता है। जब आपको उच्च छवि गुणवत्ता चाहिए, तो [PicturesCompression](https://reference.aspose.com/slides/hi/java/com.aspose.slides/picturescompression/) से मान लेकर `PicturesCompression` सेट करें।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, चित्रों के क्रॉप किए गए क्षेत्रों को निर्यातित आउटपुट से हटाया जा सकता है। केवल तब क्रॉप डेटा रखें जब उपयोगकर्ता को उन छिपे हुए चित्र भागों को पुनः प्राप्त या निरीक्षण करना आवश्यक हो। इसे रखने से HTML आकार बढ़ सकता है।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSS जोड़ें**

सरल स्टाइलिंग के लिए, `HtmlFormatter.createDocumentFormatter` को एक CSS स्ट्रिंग पास करें। यह आस-पास के HTML दस्तावेज़ को बदलता है जबकि Aspose.Slides स्लाइड सामग्री को रेंडर करना जारी रखता है।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

कस्टम दस्तावेज़ हेडर, लिंक्ड CSS फ़ाइल, या स्लाइड और आकारों के आसपास कस्टम मार्कअप के लिए, [IHtmlFormattingController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihtmlformattingcontroller/) लागू करें और `createCustomFormatter` के साथ इसे [HtmlFormatter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmlformatter/) को पास करें।

## **फ़ॉन्ट एम्बेड करें**

यदि लक्ष्य परिवेश में प्रस्तुति फ़ॉन्ट स्थापित नहीं हो सकते, तो [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/embedallfontshtmlcontroller/) के साथ HTML में फ़ॉन्ट एम्बेड करें। एम्बेडिंग दृश्य निष्ठा में सुधार करती है लेकिन आउटपुट आकार बढ़ा देती है।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

केवल तब फ़ॉन्ट बाहर रखें जब आपको पूरा विश्वास हो कि लक्ष्य ब्राउज़र या सिस्टम पहले से ही उन्हें प्रदान करते हैं। ब्रांड फ़ॉन्ट या कम सामान्य फ़ॉन्ट के लिए एम्बेडिंग आमतौर पर सुरक्षित है।

## **फ़ॉन्ट फ़ाइलों को लिंक करें बजाय एम्बेड करने के**

HTML फ़ाइल आकार घटाने के लिए, आप फ़ॉन्ट डेटा को अलग‑अलग WOFF फ़ाइलों में लिख सकते हैं और HTML में `@font-face` नियम जोड़ सकते हैं। नीचे दिया गया हेल्पर [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/embedallfontshtmlcontroller/) को विस्तारित करता है और `writeFont` को ओवरराइड करता है।

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

इस उदाहरण में, फ़ॉन्ट फ़ाइलें `html-output/fonts` में सहेजी जाती हैं, और HTML उन्हें `fonts/BrandFont-normal-400.woff` जैसे URL से संदर्भित करता है। यदि HTML फ़ाइल और फ़ॉन्ट किसी अन्य स्थान पर तैनात किए जाते हैं, तो `fontUrlPrefix` चुनें ताकि वह तैनात URL पथ से मेल खाए।

## **संसाधनों को बाहरी रूप से सहेजें**

स्वनिहित HTML को ले जाना आसान है, लेकिन एम्बेडेड Base64 संसाधन फ़ाइल को बड़ा बना सकते हैं। यदि आपके एप्लिकेशन को बाहरी छवि फ़ाइलों की आवश्यकता है, तो [ILinkEmbedController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) लागू करें और इसे [HtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/) कन्स्ट्रक्टर को पास करें।

जब आप संसाधनों को बाहरी बनाते हैं, तो दो पथ सावधानीपूर्वक चुनें:

- फ़ाइल सिस्टम आउटपुट पथ, जहाँ आपका एप्लिकेशन उत्पन्न चित्र, फ़ॉन्ट, ऑडियो या वीडियो लिखता है।
- URL पथ, जो ब्राउज़र HTML दस्तावेज़ से उन फ़ाइलों को लोड करने के लिए उपयोग करता है।

## **मीडिया फ़ाइलें निर्यात करें**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/videoplayerhtmlcontroller/) वीडियो और ऑडियो फ़ाइलें निर्यात करता है और ऐसा HTML लिखता है जो ब्राउज़र में उन्हें चलाया जा सके। इसका कन्स्ट्रक्टर स्वीकार करता है:

- `path`: वह डायरेक्टरी जहाँ उत्पन्न मीडिया फ़ाइलें लिखी जाएँगी।
- `fileName`: जनरेट किया जा रहा HTML फ़ाइल नाम।
- `baseUri`: HTML लिंक में मीडिया फ़ाइलों के लिए प्रयुक्त पूर्ण URI उपसर्ग।

यदि HTML फ़ाइल `html-output/presentation.html` है और मीडिया फ़ाइलें `html-output/media` में सहेजी गई हैं, तो `path` डिस्क पर मीडिया डायरेक्टरी की ओर इशारा करे, जबकि `baseUri` ब्राउज़र के दृष्टिकोण से उसी डायरेक्टरी की ओर। स्थानीय प्रीव्यू के लिए आप मीडिया डायरेक्टरी से `file:///` URI बना सकते हैं। तैनात एप्लिकेशन के लिए प्रकाशित मीडिया डायरेक्टरी के पूर्ण URL का उपयोग करें।

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

ऐसे आउटपुट डायरेक्टरी उपयोग करें जो प्रत्येक निर्यात कार्य के लिए विशिष्ट हों, विशेष रूप से सर्वर एप्लिकेशन में। साझा आउटपुट पथ विभिन्न रूपांतरणों की फ़ाइलों को एक‑दूसरे पर लिखने का कारण बन सकते हैं।

## **प्रदर्शन और संसाधन प्रबंधन**

HTML रूपांतरण एक रेंडरिंग ऑपरेशन है, इसलिए प्रोसेसिंग समय और मेमोरी उपयोग स्लाइड संख्या, छवि रिज़ॉल्यूशन, फ़ॉन्ट, इफ़ेक्ट, चार्ट और एम्बेडेड मीडिया पर निर्भर करता है। उच्च `PicturesCompression` DPI मान, एम्बेडेड फ़ॉन्ट, SVG आउटपुट, और रखे गए क्रॉप किए गए चित्र क्षेत्र फ़िडेलिटी को सुधार सकते हैं लेकिन आमतौर पर आउटपुट आकार बढ़ाते हैं।

बैच रूपांतरण के लिए:

- प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को तुरंत डिस्पोज़ करें।
- विभिन्न कार्यों के लिए अलग आउटपुट डायरेक्टरी उपयोग करें।
- फ़िडेलिटी की आवश्यकता न हो तो सामान्य फ़ॉन्ट एम्बेड करने से बचें।
- जब HTML प्रीव्यू या थंबनेल के लिए हो तो इमेज DPI घटाएँ।
- डिप्लॉयमेंट पथ अंतिम होने तक स्रोत प्रस्तुति, उत्पन्न HTML, और बाहरी संसाधनों को साथ रखें।

## **FAQ**

**क्या HTML आउटपुट में हाइपरलिंक संरक्षित रहते हैं?**

हां। प्रस्तुति के हाइपरलिंक HTML में निर्यात होते हैं और लक्ष्य URL वैध होने पर क्लिक करने योग्य रहते हैं।

**क्या मैं प्रस्तुतियों को समानांतर में HTML में बदल सकता हूँ?**

हां, लेकिन एक ही [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स में साझा न करें। विभिन्न फ़ाइलों को अलग‑अलग प्रस्तुति इंस्टेंस, अलग‑अलग स्ट्रीम, और अलग‑अलग आउटपुट डायरेक्टरी के साथ प्रोसेस करें। विवरण के लिए [multithreading guidance](/slides/hi/java/multithreading/) देखें।

**क्या Presentation ऑब्जेक्ट थ्रेड-सुरक्षित है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को एक ही थ्रेड पर लोड, संशोधित, सहेज और डिस्पोज़ किया जाना चाहिए। समानांतर कार्य के लिए प्रत्येक थ्रेड या प्रोसेस के लिए एक स्वतंत्र इंस्टेंस बनाएँ।

**जेनरेट किया गया HTML फ़ाइल बड़ा क्यों है?**

डिफ़ॉल्ट निर्यात संसाधन को सीधे HTML में एम्बेड करता है। एम्बेडेड फ़ॉन्ट, उच्च‑DPI छवियां, मीडिया, SVG सामग्री, और रखे गए क्रॉप किए गए चित्र क्षेत्र भी आकार बढ़ाते हैं। छोटे आउटपुट को अधिक महत्व देने पर बाहरी संसाधनों का उपयोग करें, सामान्य फ़ॉन्ट को एम्बेड करने से बाहर रखें, और फ़िडेलिटी से कम प्राथमिकता होने पर `PicturesCompression` कम करें।

**PowerPoint फ़ॉन्ट आकार जैसे 24 pt HTML में 17.999819 pt क्यों दिखता है?**

यह इसलिए हो सकता है क्योंकि PowerPoint और HTML अलग‑अलग DPI मॉडल उपयोग करते हैं। PowerPoint टेक्स्ट आकार 72 DPI पर आधारित टाइपोग्राफ़िक पॉइंट में रखता है, जबकि HTML लेआउट 96 DPI मॉडल पर आधारित CSS पिक्सेल का उपयोग करता है। जब Aspose.Slides प्रस्तुति को HTML में निर्यात करता है, तो फ़ॉन्ट आकार इन प्रणालियों के बीच अनुवादित होता है, और परिवर्तन के दौरान छोटे गोलाई अंतर हो सकते हैं।

ये मान वास्तविक दृश्य फ़ॉन्ट‑साइज़ परिवर्तन नहीं दर्शाते। वे केवल PowerPoint और HTML के बीच टेक्स्ट मीट्रिक बदलने के गणितीय साइड‑इफ़ेक्ट हैं।

**मीडिया एक्सपोर्ट के लिए baseUri कैसे चुनना चाहिए?**

`baseUri` को ब्राउज़र के दृष्टिकोण से चुनें और इसे पूर्ण URI के रूप में पास करें। स्थानीय प्रीव्यू के लिए आप इसे आउटपुट डायरेक्टरी से `mediaDirectory.toUri().toString()` द्वारा प्राप्त कर सकते हैं। डिप्लॉयमेंट के लिए प्रकाशित मीडिया डायरेक्टरी के पूर्ण URL का उपयोग करें। फ़ाइल सिस्टम `path` और ब्राउज़र `baseUri` को समान स्ट्रिंग होने की आवश्यकता नहीं है, लेकिन उन्हें एक ही संसाधन स्थान को वर्णित करना चाहिए।

**क्या मैं छिपी स्लाइड्स को शामिल कर सकता हूँ?**

हां। जब छिपी स्लाइड्स को निर्यात करना आवश्यक हो, तो [HtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/) पर `ShowHiddenSlides` को `true` सेट करें।