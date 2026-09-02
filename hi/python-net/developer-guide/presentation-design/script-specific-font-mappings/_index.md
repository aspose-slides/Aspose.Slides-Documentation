---
title: Python में स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट प्रबंधित करें
linktitle: स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट
type: docs
weight: 15
url: /hi/python-net/script-specific-font-mappings/
keywords:
- स्क्रिप्ट-विशिष्ट फ़ॉन्ट
- थीम फ़ॉन्ट मैपिंग
- बहु‑भाषी प्रेज़ेंटेशन
- लेखन प्रणाली
- साइरिलिक फ़ॉन्ट
- अरबी फ़ॉन्ट
- जापानी फ़ॉन्ट
- जॉर्जियन फ़ॉन्ट
- थाना फ़ॉन्ट
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "PowerPoint थीम में स्क्रिप्ट-विशिष्ट फ़ॉन्ट मैपिंग्स को निरीक्षण, जोड़ना, बदलना और हटाना, Aspose.Slides for Python के माध्यम से .NET के द्वारा।"
---
## **सारांश**

एक प्रेजेंटेशन थीम विभिन्न लेखन प्रणालियों के लिए अलग‑अलग फ़ॉन्ट परिवार चयन कर सकती है। इससे बहु‑भाषी पाठ, जो अभी भी थीम फ़ॉन्ट का उपयोग करता है, एक समन्वित फ़ॉन्ट स्कीम का पालन करता है जबकि साइरिलिक, अरबी, जापानी, जॉर्जियन, थाना और अन्य लिपियों के लिए उपयुक्त फ़ॉन्ट उपयोग में लाता है।

थीम का [FontScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/) एक प्रमुख फ़ॉन्ट संग्रह रखता है, जो आम तौर पर हेडिंग के लिए उपयोग होता है, और एक गौण फ़ॉन्ट संग्रह, जो बॉडी टेक्स्ट के लिए उपयोग होता है। उनके लैटिन और ईस्ट एशियन फ़ॉन्ट गुणों के अलावा, दोनों संग्रह लिखावट‑प्रणाली टैग को फ़ॉन्ट परिवार नामों से संबंधित करने वाले मैपिंग्स को [Fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fonts/) क्लास के माध्यम से उजागर करते हैं।

यह लेख दिखाता है कि प्रेजेंटेशन के मास्टर थीम में इन मैपिंग्स को कैसे निरीक्षण और संशोधित किया जाए और यह सत्यापित किया जाए कि परिवर्तन सहेज‑और‑पुनः‑लोड चक्र में बना रहता है।

## **स्क्रिप्ट टैग समझें**

स्क्रिप्ट फ़ॉन्ट विधियाँ चार‑अक्षर BCP 47 स्क्रिप्ट उप‑टैग का उपयोग करके लेखन प्रणालियों की पहचान करती हैं। सामान्य मानों में शामिल हैं:

| स्क्रिप्ट टैग | लेखन प्रणाली |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

ये मैपिंग्स थीम फ़ॉन्ट स्कीम से संबंधित हैं, न कि व्यक्तिगत पाठ भागों से। एक प्रेजेंटेशन प्रमुख और गौण संग्रहों के लिए अलग‑अलग मैपिंग्स परिभाषित कर सकता है, और कुछ स्क्रिप्ट्स के लिए मैपिंग को छोड़ भी सकता है।

## **स्क्रिप्ट फ़ॉन्ट मैपिंग्स तक पहुँचें और निरीक्षण करें**

प्रेजेंटेशन‑लेवल थीम तक पहुँचने के लिए [Presentation.master_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/master_theme/) का उपयोग करें। [FontScheme.major](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/major/) और [FontScheme.minor](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/minor/) प्रॉपर्टी दो [Fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fonts/) संग्रह लौटाते हैं।

[Fonts.get_script_font_map](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fonts/get_script_font_map/) को कॉल करके आप संग्रह से सभी मैपिंग्स प्राप्त कर सकते हैं। किसी एक लेखन प्रणाली को खोजने के लिए, उसके स्क्रिप्ट टैग के साथ [Fonts.get_script_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fonts/get_script_font/) को कॉल करें। `get_script_font` तब `None` लौटाता है जब उस संग्रह में अनुरोधित मैपिंग परिभाषित नहीं है।

## **मैपिंग्स बदलें और स्थायित्व सत्यापित करें**

एक मैपिंग बनाने या उसके वर्तमान फ़ॉन्ट परिवार को बदलने के लिए [Fonts.set_script_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fonts/set_script_font/) का उपयोग करें। एक मैपिंग हटाने के लिए [Fonts.remove_script_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fonts/remove_script_font/) का उपयोग करें।

निम्नलिखित एंड‑टू‑एंड उदाहरण सभी मौजूदा प्रमुख और गौण मैपिंग्स को पढ़ता है, जापानी प्रमुख फ़ॉन्ट को देखता है, साइरिलिक प्रमुख फ़ॉन्ट को बदलता है, थाना गौण मैपिंग को हटाता है, प्रेजेंटेशन को सहेजता है, और दोनों बदलावों को सत्यापित करने के लिए इसे पुनः खोलता है। हटाने के चरण को शुरुआती थीम से स्वतंत्र बनाने के लिये, उदाहरण पहले केवल तब थाना मैपिंग बनाता है जब वह पहले से परिभाषित नहीं है।

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

सत्यापन वही `None` व्यवहार उपयोग करता है जैसा कि सामान्य लुक‑अप में होता है: हटाने को सहेजने के बाद, `get_script_font("Thaa")` गौण संग्रह के लिये `None` लौटाता है।

## **थीम मैपिंग्स को अन्य फ़ॉन्ट सेटिंग्स से अलग करें**

स्क्रिप्ट‑विशिष्ट थीम मैपिंग्स फ़ॉन्ट चयन में भाग लेती हैं, लेकिन वे सीधे टेक्स्ट फ़ॉर्मेटिंग, प्रतिस्थापन और फ़ॉलबैक से अलग समस्या को हल करती हैं:

| तंत्र | उद्देश्य | थीम मैपिंग बदलने का प्रभाव |
|---|---|---|
| स्क्रिप्ट‑विशिष्ट थीम फ़ॉन्ट मैपिंग | किसी लेखन प्रणाली के लिए प्रमुख या गौण थीम फ़ॉन्ट का चयन करती है। | वह पाठ जो अभी भी संबंधित थीम फ़ॉन्ट उपयोग करता है, नया मैप किया गया परिवार प्राप्त कर सकता है। |
| टेक्स्ट भाग को स्पष्ट रूप से असाइन किया गया फ़ॉन्ट | उस भाग पर सीधे अनुरोधित फ़ॉन्ट परिवार को निर्धारित करता है, थीम पर निर्भर रहने के बजाय। | भाग वही रह सकता है क्योंकि उसका प्रत्यक्ष फ़ॉर्मेटिंग थीम चयन को ओवरराइड करता है। |
| फ़ॉन्ट प्रतिस्थापन | जब अनुरोधित फ़ॉन्ट उपलब्ध नहीं होता या कोई प्रतिस्थापन नियम लागू होता है, तब फ़ॉन्ट बदलता है। | यह फ़ॉन्ट के अनुरोध के बाद कार्य करता है; यह थीम की स्क्रिप्ट मैपिंग को पुनर्परिभाषित नहीं करता। |
| फ़ॉलबैक फ़ॉन्ट | चयनित फ़ॉन्ट में न मौजूद ग्लीफ़्स को उपलब्ध कराता है, अक्सर विशिष्ट यूनिकोड रेंज के लिये। | यह लापता ग्लीफ़ कवरेज को भरता है; यह संग्रहीत थीम मैपिंग को नहीं बदलता। |

अंतिम दो तंत्रों के बारे में अधिक जानकारी के लिये देखें [फ़ॉन्ट प्रतिस्थापन](/slides/hi/python-net/font-substitution/) और [फ़ॉलबैक फ़ॉन्ट](/slides/hi/python-net/fallback-font/)।

[Presentation.master_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/master_theme/) में एक मैपिंग बदलने से केवल उन कंटेंट पर प्रभाव पड़ता है जिनके प्रभावी फ़ॉर्मेटिंग अभी भी उस थीम पर निर्भर है। टेक्स्ट इसके बजाय मास्टर, लेआउट या स्लाइड से थीम ओवरराइड विरासत में ले सकता है, या स्पष्ट रूप से असाइन किए गए फ़ॉन्ट का उपयोग कर सकता है। जब दिखाई देने वाला परिणाम प्रेजेंटेशन‑लेवल मैपिंग का अनुसरण नहीं करता, तो उन स्तरों की जांच करें।

## **मैप्ड फ़ॉन्ट उपलब्ध कराएँ और परिणाम को मान्य करें**

एक स्क्रिप्ट मैपिंग केवल फ़ॉन्ट परिवार नाम संग्रहीत करती है; यह संबंधित फ़ॉन्ट फ़ाइल को स्थापित या लोड नहीं करती। सुसंगत रेंडरिंग और निर्यात के लिये, हर मैप्ड फ़ॉन्ट को पर्यावरण में स्थापित होना चाहिए या Aspose.Slides को किसी कस्टम स्रोत जैसे [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/load_external_fonts/) या [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/document_level_font_sources/) के माध्यम से प्रदान किया जाना चाहिए। उपलब्ध लोडिंग विकल्पों के लिये देखें [Custom Fonts](/slides/hi/python-net/custom-font/)।

सहेजी गई मैपिंग का सत्यापन केवल इस बात की पुष्टि करता है कि थीम परिभाषा संरक्षित रही। यह नहीं साबित करता कि फ़ॉन्ट उपलब्ध है, सभी आवश्यक ग्लीफ़्स शामिल हैं, या इच्छित लेआउट उत्पन्न करता है। प्रत्येक आवश्यक लेखन प्रणाली के लिये प्रतिनिधि टेक्स्ट को छवि या PDF में रेंडर करें और आउटपुट का निरीक्षण करें। इससे लापता फ़ॉन्ट, अधूरी ग्लीफ़ कवरेज, फ़ॉलबैक व्यवहार, और लेआउट परिवर्तन प्रेजेंटेशन वितरित करने से पहले पकड़े जा सकते हैं। रेंडरिंग और निर्यात उदाहरणों के लिये देखें [Convert PowerPoint Presentations](/slides/hi/python-net/convert-powerpoint/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब स्क्रिप्ट मैप्ड नहीं हो तो `get_script_font` क्या लौटाता है?**

[Fonts.get_script_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fonts/get_script_font/) तब `None` लौटाता है जब अनुरोधित स्क्रिप्ट मैपिंग उस प्रमुख या गौण फ़ॉन्ट संग्रह में परिभाषित नहीं है।

**क्या `set_script_font` स्क्रिप्ट पहले से मौजूद होने पर दूसरा मैपिंग जोड़ता है?**

नहीं। [Fonts.set_script_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fonts/set_script_font/) तब मैपिंग बनाता है जब वह गायब हो और उसी स्क्रिप्ट टैग के लिये पहले से मौजूद होने पर मैप्ड फ़ॉन्ट परिवार को बदलता है।

**क्यों थीम मैपिंग बदलने से कुछ टेक्स्ट नहीं बदला?**

टेक्स्ट के पास स्पष्ट रूप से असाइन किया गया फ़ॉन्ट हो सकता है, वह एक ओवरराइड के माध्यम से अलग थीम विरासत में ले सकता है, या रेंडरिंग के समय प्रतिस्थापन या फ़ॉलबैक से प्रभावित हो सकता है। प्रेजेंटेशन‑लेवल स्क्रिप्ट मैपिंग केवल उन पाठों को नियंत्रित करता है जिनकी प्रभावी फ़ॉर्मेटिंग अभी भी उस थीम फ़ॉन्ट संग्रह का संदर्भ देती है।

**क्या सहेजना और पुनः खोलना बहुभाषी आउटपुट को मान्य करने के लिये पर्याप्त है?**

नहीं। पुनः खोलना केवल थीम डेटा की स्थायित्व की पुष्टि करता है। इसके अतिरिक्त प्रत्येक आवश्यक लेखन प्रणाली से प्रतिनिधि टेक्स्ट को रेंडर करें ताकि यह सुनिश्चित हो सके कि मैप्ड फ़ॉन्ट उपलब्ध हैं और आवश्यक ग्लीफ़्स सम्मिलित हैं।