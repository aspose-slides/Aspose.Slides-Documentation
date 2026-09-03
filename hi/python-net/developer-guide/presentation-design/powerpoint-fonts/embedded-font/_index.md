---
title: Python के साथ प्रस्तुतियों में फ़ॉन्ट एंबेड करें
linktitle: एंबेडेड फ़ॉन्ट्स
type: docs
weight: 40
url: /hi/python-net/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एंबेड करें
- फ़ॉन्ट एंबेडिंग
- एंबेडेड फ़ॉन्ट प्राप्त करें
- एंबेडेड फ़ॉन्ट जोड़ें
- एंबेडेड फ़ॉन्ट हटाएँ
- एंबेडेड फ़ॉन्ट संकुचित करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint में एंबेडेड फ़ॉन्ट्स प्रबंधित करें। फ़ॉन्ट्स को जोड़ने, पुनः प्राप्त करने, हटाने और संकुचित करने के लिए Python का उपयोग करें ताकि पाठ की उपस्थिति बनी रहे और फ़ाइल आकार कम हो।"
---
## **परिचय**

फ़ॉन्ट एंबेड करने से फ़ॉन्ट डेटा PowerPoint प्रस्तुति के अंदर संग्रहीत हो जाता है। जब दर्शक एंबेडेड फ़ॉन्ट्स का समर्थन करता है, तो वह लक्ष्य सिस्टम पर फ़ॉन्ट स्थापित न होने पर भी उन फ़ॉन्ट्स का उपयोग करके पाठ प्रदर्शित कर सकता है। इससे लाइन ब्रेक, पाठ अंतराल और स्लाइड लेआउट संरक्षित रहता है।

Aspose.Slides for Python via .NET आपको एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट की [fonts_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/fonts_manager/) प्रॉपर्टी के माध्यम से एंबेडेड फ़ॉन्ट्स को प्राप्त करने, जोड़ने और हटाने की सुविधा देता है। आप प्रस्तुति द्वारा उपयोग न किए गए अक्षरों को हटाकर एंबेडेड फ़ॉन्ट डेटा का आकार भी घटा सकते हैं।

नीचे दिए गए उदाहरण PPTX फ़ाइलों पर कार्य करते हैं। फ़ॉन्ट एंबेड करने से पहले सुनिश्चित करें कि उसका फ़ॉन्ट डेटा Aspose.Slides के पास उपलब्ध है और उसके लाइसेंस में एंबेडिंग की अनुमति है।

## **एंबेडेड फ़ॉन्ट्स को प्राप्त करना और हटाना**

[get_embedded_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) का उपयोग करके प्रस्तुति में संग्रहीत फ़ॉन्ट्स की सूची प्राप्त करें। किसी फ़ॉन्ट को हटाने के लिए उस सूची से फ़ॉन्ट चुनें और उसे [remove_embedded_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/remove_embedded_font/) में पास करें, फिर प्रस्तुति को सहेजें।

निम्न उदाहरण `EmbeddedFonts.pptx` में एंबेडेड फ़ॉन्ट्स को सूचीबद्ध करता है और यदि Calibri मौजूद है तो उसे हटाता है:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

एक एंबेडेड फ़ॉन्ट को हटाने से उसका संग्रहीत फ़ॉन्ट डेटा हट जाता है; यह पाठ को असाइन किए गए फ़ॉन्ट को नहीं बदलता। यदि फ़ॉन्ट लक्ष्य सिस्टम पर स्थापित है, तो पाठ अभी भी उसका उपयोग कर सकता है। अन्यथा, रेंडरिंग के दौरान [font substitution](/slides/hi/python-net/font-substitution/) की आवश्यकता पड़ सकती है, जिससे लेआउट प्रभावित हो सकता है।

## **फ़ॉन्ट डेटा और एंबेडिंग अनुमतियों का निरीक्षण**

फ़ॉन्ट को एंबेड करने से पहले निरीक्षण करने के लिए [FontsManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/) क्लास का उपयोग करें। प्रस्तुति में उपयोग किए गए फ़ॉन्ट्स को प्राप्त करने के लिए [get_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_fonts/) को कॉल करें। प्रत्येक फ़ॉन्ट के लिए एक [FontData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontdata/) ऑब्जेक्ट और आवश्यक [FontStyleType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontstyletype/) मान को [get_font_bytes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_font_bytes/) में पास करें। यह मेथड उस फ़ॉन्ट शैली के बाइनरी डेटा को लौटाता है, या जब अनुरोधित फ़ॉन्ट या शैली उपलब्ध नहीं होती तो `None` लौटाता है। `None` परिणाम को [get_font_embedding_level](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_font_embedding_level/) में पास न करें, क्योंकि इस मेथड को बाइट एरे की आवश्यकता होती है।

[EmbeddingLevel](https://reference.aspose.com/slides/hi/python-net/aspose.slides/embeddinglevel/) एक फ़्लैग्स एन्‍युमरेशन है जो फ़ॉन्ट में संग्रहीत एंबेडिंग प्रतिबंधों को दर्शाता है:

- `INSTALLABLE` एंबेडिंग और दूसरे सिस्टम पर स्थायी इंस्टॉलेशन की अनुमति देता है, बशर्ते फ़ॉन्ट लाइसेंस अनुमति दे।
- `RESTRICTED` केवल तभी एंबेडिंग की अनुमति देता है जब फ़ॉन्ट के कानूनी मालिक से अनुमति प्राप्त की गई हो, जब यह एकमात्र उपयोग‑अनुमति फ़्लैग हो।
- `PREVIEW_PRINT` अस्थायी रूप से देखने और प्रिंट करने की अनुमति देता है; फ़ॉन्ट वाला दस्तावेज़ केवल‑पढ़ने योग्य होना चाहिए।
- `EDITABLE` अस्थायी उपयोग की अनुमति देता है और दस्तावेज़ को संपादित व सहेजने की भी अनुमति देता है।
- `NO_SUBSETTING` अतिरिक्त प्रतिबंध है जो केवल उपसमुच्चय (subset) एंबेडिंग को रोकता है। इस फ़्लैग के उपस्थित होने पर सभी अक्षर एंबेड करें।
- `BITMAP_ONLY` अतिरिक्त प्रतिबंध है जो केवल बिटमैप स्ट्राइक्स को एंबेड करने की अनुमति देता है, आउटलाइन डेटा नहीं। यदि फ़ॉन्ट में बिटमैप स्ट्राइक्स नहीं हैं, तो इसे एंबेड नहीं किया जा सकता।

पहले चार मान उपयोग अनुमति का वर्णन करते हैं, जबकि `NO_SUBSETTING` और `BITMAP_ONLY` उनके साथ संयोजित किए जा सकते हैं। बिटवाइज़ ऑपरेशन्स से मॉडिफ़ायर्स की जाँच करें। चूँकि `INSTALLABLE` शून्य है, उपयोग‑अनुमति बिट्स को मास्क करके परिणाम को `INSTALLABLE` से तुलना करें। वर्तमान फ़ॉन्ट्स में अधिकतम एक उपयोग‑अनुमति बिट सेट होना चाहिए। पुराने फ़ॉन्ट्स के साथ संगतता हेतु जो एक से अधिक बिट सेट कर सकते हैं, नीचे दिया गया हेल्पर सबसे कम प्रतिबंधित अनुमति का चयन करता है: `EDITABLE`, फिर `PREVIEW_PRINT`, फिर `RESTRICTED`.

निम्न उदाहरण `get_fonts` द्वारा लौटाए गए प्रत्येक फ़ॉन्ट के नियमित, बोल्ड, इटैलिक और बोल्ड‑इटैलिक डेटा का ऑडिट करता है। यह अनुपलब्ध शैलियों, प्रतिबंधित फ़ॉन्ट्स, केवल‑बिटमैप फ़ॉन्ट्स, केवल पूर्वावलोकन‑और‑प्रिंट के लिए सीमित फ़ॉन्ट्स (क्योंकि आउटपुट संपादन योग्य रहता है), और पहले से एंबेडेड फ़ॉन्ट्स को छोड़ देता है। यदि किसी उपलब्ध शैली में `NO_SUBSETTING` है, तो वह फ़ॉन्ट परिवार के सभी अक्षर एंबेड करता है।

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

यह निरीक्षण प्रत्येक फ़ॉन्ट फ़ाइल में एन्कोड किए गए प्रतिबंधों को दर्शाता है। यह लाइसेंस प्रदान नहीं करता, न ही यह प्रमाणित करता है कि आपने फ़ॉन्ट कानूनी रूप से प्राप्त किया है, और एंबेडेड कॉपी वितरित करने से पहले फ़ॉन्ट के लाइसेंस समझौते की जाँच का विकल्प नहीं है।

## **एंबेडेड फ़ॉन्ट्स जोड़ना**

[add_embedded_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/add_embedded_font/) का उपयोग करके फ़ॉन्ट एंबेड करें। इसके ओवरलोड या तो एक [FontData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontdata/) ऑब्जेक्ट या फ़ॉन्ट डेटा युक्त बाइट एरे स्वीकार करते हैं। [EmbedFontCharacters](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/embedfontcharacters/) एन्‍युमरेशन निर्धारित करता है कि कौन से अक्षर शामिल किए जाएँ:

- [ALL](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/embedfontcharacters/) फ़ॉन्ट के सभी अक्षर एंबेड करता है। जब प्राप्तकर्ता को प्रस्तुति संपादित करने और नया पाठ दर्ज करने की आवश्यकता हो तो इस विकल्प का उपयोग करें।
- [ONLY_USED](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/embedfontcharacters/) केवल प्रस्तुति में उपयोग किए गए अक्षरों को एंबेड करता है ताकि फ़ाइल आकार घटे। इसे समाप्त प्रस्तुति के लिए चुनें जो मुख्य रूप से देखे जाने के उद्देश्य से है।

निम्न उदाहरण `Fonts.pptx` में उपयोग किए गए फ़ॉन्ट्स को प्राप्त करने के लिए [get_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_fonts/) का उपयोग करता है और उन फ़ॉन्ट्स को एंबेड करता है जो पहले से एंबेड नहीं हुए हैं। जोड़ने के लिए आवश्यक फ़ॉन्ट कोड चलाने वाले मशीन पर उपलब्ध होना चाहिए। मौजूदा एंबेडेड फ़ॉन्ट्स अपने वर्तमान अक्षर सेट को बनाए रखते हैं।

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **एंबेडेड फ़ॉन्ट्स को संपीड़ित करना**

[compress_embedded_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) एंबेडेड फ़ॉन्ट डेटा को अप्रयुक्त अक्षरों को हटाकर घटाता है। यह पहले से एंबेडेड फ़ॉन्ट्स पर कार्य करता है, इसलिए आकार घटाव इस बात पर निर्भर करता है कि प्रस्तुति में कितनी अनावश्यक फ़ॉन्ट डेटा मौजूद है।

निम्न उदाहरण `EmbeddedFonts.pptx` में फ़ॉन्ट्स को संपीड़ित करता है और परिणाम को एक अलग फ़ाइल के रूप में सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

यदि प्राप्तकर्ता बाद में पाठ जोड़ने की संभावना रखते हैं तो मूल फ़ाइल रखें। संपीड़न के दौरान हटाए गए अक्षरों को एंबेडेड फ़ॉन्ट से अधिक नहीं प्राप्त किया जा सकता, चाहे आप मूल रूप में सभी अक्षर एंबेड किए हों।

## **FAQ**

**मैं कैसे जांचूँ कि एंबेडेड फ़ॉन्ट रेंडरिंग के दौरान अभी भी प्रतिस्थापित होगा या नहीं?**

जिस वातावरण में आप प्रस्तुति रेंडर करते हैं, वहाँ [get_substitutions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_substitutions/) को कॉल करें ताकि पता चल सके कि Aspose.Slides किन फ़ॉन्ट्स को बदल देगा। साथ ही [font substitution](/slides/hi/python-net/font-substitution/) सेटिंग्स और [font fallback](/slides/hi/python-net/fallback-font/) नियमों की जाँच करें। फॉलबैक अनुपलब्ध अक्षरों को संभालता है, इसलिए फ़ॉन्ट एंबेड करने से उन अक्षरों का समाधान नहीं होता जो स्वयं फ़ॉन्ट में मौजूद नहीं हैं।

**क्या मुझे Arial और Calibri जैसे सामान्य फ़ॉन्ट्स को एंबेड करना चाहिए?**

निर्णय लक्ष्य पर्यावरण पर आधारित होना चाहिए। यदि आवश्यक फ़ॉन्ट्स प्रत्येक मशीन पर उपलब्ध हैं जहाँ प्रस्तुति खोली या रेंडर की जाएगी, तो उन्हें एंबेड करने से अनावश्यक फ़ाइल आकार बढ़ सकता है। यदि प्राप्तकर्ता या सर्वर में इन फ़ॉन्ट्स की कमी हो सकती है, तो एंबेडिंग मदद कर सकती है, बशर्ते उनके लाइसेंस एंबेडिंग की अनुमति दें।