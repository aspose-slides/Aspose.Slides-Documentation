---
title: जावास्क्रिप्ट में प्रेजेंटेशन स्लाइड्स की तुलना
linktitle: स्लाइड्स तुलना
type: docs
weight: 50
url: /hi/nodejs-java/compare-slides/
keywords:
- स्लाइड्स तुलना
- स्लाइड तुलना
- पॉवरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके प्रोग्रामेटिक रूप से PowerPoint और OpenDocument प्रस्तुतियों की तुलना करें। कोड में जल्दी से स्लाइड अंतर पहचानें।"
---
## **अवलोकन**

Aspose.Slides आपको `BaseSlide` क्लास द्वारा प्रदान किए गए `equals` मेथड का उपयोग करके स्लाइड्स, लेआउट स्लाइड्स और मास्टर स्लाइड्स की तुलना करने की सुविधा देता है। यह मेथड तब `true` लौटाता है जब तुलना की गई स्लाइड्स की संरचना और स्थिर सामग्री में समानता होती है।

## **दो स्लाइड्स की तुलना**

Equals मेथड को [BaseSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BaseSlide) क्लास और [BaseSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BaseSlide) क्लास में जोड़ दिया गया है। यह स्लाइड्स/लेआउट और स्लाइड्स/मास्टर स्लाइड्स के लिए, जो अपनी संरचना और स्थिर सामग्री में समान होते हैं, `true` लौटाता है।

दो स्लाइड्स समान मानी जाती हैं यदि सभी आकार, शैलियाँ, पाठ, एनीमेशन और अन्य सेटिंग्स आदि समान हों। तुलना में अद्वितीय पहचानकर्ता मान, जैसे SlideId, और गतिशील सामग्री, जैसे तिथि प्लेसहोल्डर में वर्तमान तिथि मान, को ध्यान में नहीं रखा जाता।

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या यह तथ्य कि कोई स्लाइड छिपी हुई है, स्लाइड्स की तुलना को प्रभावित करता है?**

[Hidden status](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/gethidden/) एक प्रस्तुति/प्लेबैक-स्तर की गुणधर्म है, दृश्य सामग्री नहीं। दो विशिष्ट स्लाइड्स की समानता उनकी संरचना और स्थिर सामग्री द्वारा निर्धारित होती है; केवल यह तथ्य कि कोई स्लाइड छिपी हुई है, स्लाइड्स को अलग नहीं बनाता।

**क्या हाइपरलिंक और उनके पैरामीटर ध्यान में रखे जाते हैं?**

हां। लिंक स्लाइड की स्थिर सामग्री का भाग होते हैं। यदि URL या हाइपरलिंक कार्रवाई अलग है, तो इसे आमतौर पर स्थिर सामग्री में अंतर माना जाता है।

**यदि कोई चार्ट बाहरी Excel फ़ाइल को संदर्भित करता है, तो क्या उस फ़ाइल की सामग्री को ध्यान में रखा जाएगा?**

नहीं। तुलना केवल स्लाइड्स के आधार पर की जाती है। बाहरी डेटा स्रोत आमतौर पर तुलना के समय पढ़े नहीं जाते; केवल वह सामग्री जो स्लाइड की संरचना और स्थिर स्थिति में मौजूद है, पर विचार किया जाता है।