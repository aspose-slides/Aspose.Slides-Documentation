---
title: Python के माध्यम से Java में प्रस्तुतियों में फ़ॉन्ट एम्बेड करें
linktitle: एम्बेडेड फ़ॉन्ट्स
type: docs
weight: 40
url: /hi/python-java/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एम्बेड करें
- फ़ॉन्ट एम्बेडिंग
- एंबेडेड फ़ॉन्ट प्राप्त करें
- एंबेडेड फ़ॉन्ट जोड़ें
- एंबेडेड फ़ॉन्ट हटाएँ
- एंबेडेड फ़ॉन्ट संपीड़ित करें
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java के लिए Aspose.Slides के साथ PowerPoint में एंबेडेड फ़ॉन्ट्स का प्रबंधन करें। फ़ॉन्ट को जोड़ें, पुनः प्राप्त करें, हटाएँ और संपीड़ित करें ताकि पाठ की दिखावट बनी रहे और फ़ाइल का आकार कम हो सके।"
---
## **परिचय**

फ़ॉन्ट एम्बेड करने से फ़ॉन्ट डेटा PowerPoint प्रस्तुति के भीतर संग्रहीत हो जाता है। जब कोई व्यूअर एम्बेडेड फ़ॉन्ट का समर्थन करता है, तो वह उन फ़ॉन्टों का उपयोग करके पाठ प्रदर्शित कर सकता है, भले ही लक्ष्य प्रणाली पर फ़ॉन्ट स्थापित न हो। यह पंक्ति ब्रेक, पाठ अंतराल और स्लाइड लेआउट को बरकरार रखने में मदद करता है।

Aspose.Slides for Python via Java आपको एम्बेडेड फ़ॉन्ट को पुनः प्राप्त करने, जोड़ने और हटाने की सुविधा देता है, यह [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) वर्ग के माध्यम से किया जाता है, जो [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getFontsManager) द्वारा लौटाया जाता है। आप प्रस्तुति द्वारा उपयोग न किए गए अक्षरों को हटाकर एम्बेडेड फ़ॉन्ट डेटा का आकार भी कम कर सकते हैं।

नीचे के उदाहरण PPTX फ़ाइलों के साथ काम करते हैं। फ़ॉन्ट एम्बेड करने से पहले सुनिश्चित करें कि उसका फ़ॉन्ट डेटा Aspose.Slides के लिए उपलब्ध है और उसका लाइसेंस एम्बेडिंग की अनुमति देता है।

## **एम्बेडेड फ़ॉन्ट प्राप्त करें और हटाएँ**

एक प्रस्तुति में संग्रहीत फ़ॉन्टों की सूची बनाने के लिए [getEmbeddedFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) का उपयोग करें। किसी फ़ॉन्ट को हटाने के लिए, उस सूची से एक फ़ॉन्ट को [removeEmbeddedFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont) को पास करें, फिर प्रस्तुति को सहेजें।

निम्न उदाहरण `EmbeddedFonts.pptx` में एम्बेडेड फ़ॉन्टों की सूची बनाता है और यदि मौजूद हों तो Calibri को हटाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

एक एम्बेडेड फ़ॉन्ट को हटाने से उसका संग्रहीत फ़ॉन्ट डेटा हट जाता है; यह पाठ को असाइन किए गए फ़ॉन्ट को नहीं बदलता। यदि फ़ॉन्ट लक्ष्य प्रणाली पर स्थापित है, तो पाठ अभी भी उसका उपयोग कर सकता है। अन्यथा, रेंडरिंग को फ़ॉन्ट प्रतिस्थापन की आवश्यकता हो सकती है, जो लेआउट को प्रभावित कर सकता है।

## **फ़ॉन्ट डेटा और एम्बेडिंग अनुमतियों का निरीक्षण**

फ़ॉन्ट को एम्बेड करने से पहले उनका निरीक्षण करने के लिए [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) वर्ग का उपयोग करें। प्रस्तुति में उपयोग किए गए फ़ॉन्टों को प्राप्त करने के लिए [FontsManager.getFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getFonts) को कॉल करें। प्रत्येक फ़ॉन्ट के लिए, एक [FontData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontdata/) ऑब्जेक्ट और आवश्यक [FontStyleType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontstyletype/) मान को [FontsManager.getFontBytes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getFontBytes) को पास करें। यह मेथड उस फ़ॉन्ट शैली के बाइनरी डेटा को लौटाता है, या जब अनुरोधित फ़ॉन्ट या शैली उपलब्ध नहीं होती तो `None` लौटाता है। `None` परिणाम को [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) को पास न करें, क्योंकि वह मेथड बाइट ऐरे की अपेक्षा करता है।

[EmbeddingLevel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/embeddinglevel/) एक फ़्लैग्स एनेमरेशन है जो फ़ॉन्ट में संग्रहीत एम्बेडिंग प्रतिबंधों की रिपोर्ट करता है:

- `Installable` एम्बेड करने और दूसरे सिस्टम पर स्थायी रूप से स्थापित करने की अनुमति देता है, फ़ॉन्ट लाइसेंस के अधीन।
- `Restricted` केवल तब एम्बेड करने की अनुमति देता है जब फ़ॉन्ट के कानूनी मालिक से अनुमति प्राप्त की गई हो, जब यह एकमात्र उपयोग‑अनुमति फ़्लैग हो।
- `PreviewPrint` अस्थायी रूप से देखने और प्रिंट करने की अनुमति देता है; फ़ॉन्ट युक्त दस्तावेज़ केवल पढ़ने‑के‑लिए होना चाहिए।
- `Editable` अस्थायी उपयोग की अनुमति देता है और दस्तावेज़ को संपादित और सहेजा जा सकता है।
- `NoSubsetting` एक अतिरिक्त प्रतिबंध है जो केवल कुछ ग्लिफ़ों के एम्बेडिंग को रोकता है। यदि यह फ़्लैग मौजूद है तो सभी अक्षर एम्बेड करें।
- `BitmapOnly` एक अतिरिक्त प्रतिबंध है जो केवल बिटमैप स्ट्राइक्स को एम्बेड करने की अनुमति देता है, आउटलाइन डेटा नहीं। यदि फ़ॉन्ट में बिटमैप स्ट्राइक्स नहीं हैं, तो इसे एम्बेड नहीं किया जा सकता।

पहले चार मान उपयोग‑अनुमति को वर्णित करते हैं, जबकि `NoSubsetting` और `BitmapOnly` को उनके साथ संयुक्त किया जा सकता है। बिटवाइज़ ऑपरेशनों के साथ मॉडिफ़ायर जाँचें। क्योंकि `Installable` शून्य है, उपयोग‑अनुमति बिट्स को मास्क करें और परिणाम की तुलना `Installable` से करें, न कि इसे फ़्लैग के रूप में जाँचें। वर्तमान फ़ॉन्ट अधिकतम एक उपयोग‑अनुमति बिट सेट करेंगे। पुराने फ़ॉन्ट जो एक से अधिक सेट करते हैं, उनके साथ अनुकूलता के लिए नीचे दिया गया हेल्पर सबसे कम प्रतिबंध वाली अनुमति चुनता है: पहले `Editable`, फिर `PreviewPrint`, फिर `Restricted`।

निम्न उदाहरण `getFonts` द्वारा लौटाए गए प्रत्येक फ़ॉन्ट के सामान्य, बोल्ड, इटैलिक और बोल्ड‑इटैलिक डेटा का ऑडिट करता है। यह अनुपलब्ध शैलियों, प्रतिबंधित फ़ॉन्ट, केवल‑बिटमैप फ़ॉन्ट, केवल‑पूर्वावलोकन‑और‑प्रिंट फ़ॉन्ट (क्योंकि आउटपुट अभी भी संपादित योग्य रहता है) और पहले से एम्बेडेड फ़ॉन्ट को छोड़ देता है। यदि किसी उपलब्ध शैली में `NoSubsetting` है, तो वह फ़ॉन्ट परिवार के सभी अक्षर एम्बेड करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यह निरीक्षण प्रत्येक फ़ॉन्ट फ़ाइल में एन्कोडेड प्रतिबंधों की रिपोर्ट करता है। यह लाइसेंस प्रदान नहीं करता, यह प्रमाणित नहीं करता कि आपने फ़ॉन्ट कानूनी रूप से प्राप्त किया है, या एम्बेडेड कॉपी वितरित करने से पहले फ़ॉन्ट के लाइसेंस समझौते की जाँच को बदलता है।

## **एंबेडेड फ़ॉन्ट जोड़ें**

एक फ़ॉन्ट को एम्बेड करने के लिए [addEmbeddedFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) का उपयोग करें। इसके ओवरलोड या तो एक [FontData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontdata/) ऑब्जेक्ट या फ़ॉन्ट डेटा वाली बाइट ऐरे को स्वीकार करते हैं। कौन से अक्षर शामिल किए जाएँ, यह नियंत्रित करने के लिए [EmbedFontCharacters](https://reference.aspose.com/slides/hi/python-java/aspose.slides/embedfontcharacters/) एनेमरेशन का उपयोग करें:

- [All](https://reference.aspose.com/slides/hi/python-java/aspose.slides/embedfontcharacters/) फ़ॉन्ट में सभी अक्षर एम्बेड करता है। इस विकल्प का उपयोग तब करें जब प्राप्तकर्ता को प्रस्तुति को संपादित करने और नया पाठ दर्ज करने की आवश्यकता हो।
- [OnlyUsed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/embedfontcharacters/) केवल प्रस्तुति में उपयोग किए गए अक्षर एम्बेड करता है ताकि फ़ाइल आकार कम हो। इस विकल्प को समाप्त प्रस्तुति के लिए चुनें, जिसका मुख्य उद्देश्य दर्शन है।

निम्न उदाहरण `Fonts.pptx` में उपयोग किए गए फ़ॉन्टों को पुनः प्राप्त करने के लिए [getFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getFonts) का उपयोग करता है और उन फ़ॉन्टों को एम्बेड करता है जो पहले से एम्बेड नहीं हैं। जोड़ने वाले फ़ॉन्ट कोड चलाने वाली मशीन पर उपलब्ध होने चाहिए। मौजूदा एम्बेडेड फ़ॉन्ट अपने वर्तमान अक्षर सेट को बनाए रखेंगे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एंबेडेड फ़ॉन्ट संपीड़ित करें**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#compressEmbeddedFonts) अनउपयोगी अक्षरों को हटाकर एम्बेडेड फ़ॉन्ट डेटा को घटाता है। यह पहले से एम्बेडेड फ़ॉन्टों पर कार्य करता है, इसलिए आकार कमी इस बात पर निर्भर करती है कि प्रस्तुति में कितना अनउपयोगी फ़ॉन्ट डेटा मौजूद है।

निम्न उदाहरण `EmbeddedFonts.pptx` में फ़ॉन्टों को संपीड़ित करता है और परिणाम को एक अलग फ़ाइल के रूप में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यदि प्राप्तकर्ता बाद में पाठ जोड़ना चाहते हैं, तो मूल फ़ाइल रखें। संपीड़न के दौरान हटाए गए अक्षर एम्बेडेड फ़ॉन्ट से अब उपलब्ध नहीं रहेंगे, भले ही आपने प्रारम्भ में सभी अक्षर एम्बेड किए हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँच सकता हूँ कि क्या एम्बेडेड फ़ॉन्ट रेंडरिंग के दौरान अभी भी प्रतिस्थापित होगा?**

वह पर्यावरण जहाँ आप प्रस्तुति रेंडर करते हैं, उसमें [getSubstitutions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getSubstitutions) को कॉल करें ताकि देखा जा सके कि Aspose.Slides कौन से फ़ॉन्ट को बदल देगा। फ़ॉन्ट प्रतिस्थापन सेटिंग्स और फ़ॉन्ट फ़ॉलबैक नियमों की भी जाँच करें। फ़ॉलबैक गायब अक्षरों को संभालता है, इसलिए फ़ॉन्ट एम्बेड करने से उन अक्षरों का समाधान नहीं होता जो फ़ॉन्ट स्वयं में नहीं हैं।

**क्या मुझे Arial और Calibri जैसे सामान्य फ़ॉन्ट एम्बेड करने चाहिए?**

निर्णय लक्ष्य पर्यावरण पर आधारित होना चाहिए। यदि आवश्यक फ़ॉन्ट हर मशीन पर उपलब्ध हैं जो प्रस्तुति खोलती या रेंडर करती है, तो उन्हें एम्बेड करने से अनावश्यक फ़ाइल आकार बढ़ सकता है। यदि प्राप्तकर्ता या सर्वर उन फ़ॉन्टों की कमी हो सकती है, तो एम्बेड करने से इच्छित दिखावट को बरकरार रखने में मदद मिलती है, बशर्ते उनके लाइसेंस एम्बेडिंग की अनुमति दें।