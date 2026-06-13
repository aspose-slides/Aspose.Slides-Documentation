---
title: एंड्रॉइड पर प्रेजेंटेशन स्लाइड्स की तुलना
linktitle: स्लाइड्स की तुलना
type: docs
weight: 50
url: /hi/androidjava/compare-slides/
keywords:
- स्लाइड्स की तुलना
- स्लाइड तुलना
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ प्रोग्रामेटिक रूप से PowerPoint और OpenDocument प्रस्तुतियों की तुलना करें। Java कोड में स्लाइड अंतर को तेज़ी से पहचानें।"
---
## **अवलोकन**

Aspose.Slides आपको स्लाइड्स, लेआउट स्लाइड्स, और मास्टर स्लाइड्स की तुलना `equals` मेथड का उपयोग करके करने की अनुमति देता है, जो `IBaseSlide` इंटरफ़ेस और `BaseSlide` क्लास द्वारा प्रदान किया जाता है। यह मेथड तब `true` लौटाता है जब तुलना की गई स्लाइड्स अपनी संरचना और स्थैतिक सामग्री में एक समान होती हैं।

## **दो स्लाइड्स की तुलना**
Equals मेथड को [IBaseSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBaseSlide) इंटरफ़ेस और [BaseSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/BaseSlide) क्लास में जोड़ा गया है। यह स्लाइड्स/लेआउट और स्लाइड्स/मास्टर स्लाइड्स के लिए `true` लौटाता है जो अपनी संरचना और स्थैतिक सामग्री में समान होते हैं। 

दो स्लाइड्स समान तब होती हैं जब सभी आकार, शैलियां, पाठ, एनीमेशन और अन्य सेटिंग्स आदि समान हों। तुलना में अद्वितीय पहचानकर्ता मान, जैसे SlideId, तथा गतिशील सामग्री, जैसे तिथि प्लेसहोल्डर में वर्तमान तिथि मान, को ध्यान में नहीं रखा जाता है।

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
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

**क्या स्लाइड के छिपे हुए होने का तथ्य स्वयं स्लाइड्स की तुलना को प्रभावित करता है?**

[Hidden status](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slide/#getHidden--) एक प्रेजेंटेशन/प्लेबैक-स्तर की प्रॉपर्टी है, न कि दृश्य सामग्री। दो विशिष्ट स्लाइड्स की समानता उनकी संरचना और स्थैतिक सामग्री द्वारा निर्धारित होती है; केवल यह तथ्य कि एक स्लाइड छिपी हुई है, स्लाइड्स को अलग नहीं बनाता है।

**क्या हाइपरलिंक और उनके पैरामीटर ध्यान में रखे जाते हैं?**

हाँ। लिंक स्लाइड की स्थैतिक सामग्री का हिस्सा होते हैं। यदि URL या हाइपरलिंक का एक्शन अलग है, तो इसे आमतौर पर स्थैतिक सामग्री में अंतर माना जाता है।

**यदि कोई चार्ट बाहरी Excel फ़ाइल को संदर्भित करता है, तो क्या उस फ़ाइल की सामग्री को ध्यान में रखा जाएगा?**

नहीं। तुलना स्वयं स्लाइड्स के आधार पर की जाती है। बाहरी डेटा स्रोत आमतौर पर तुलना के समय पढ़े नहीं जाते; केवल वह ही जो स्लाइड की संरचना और स्थैतिक स्थिति में मौजूद है, उसे माना जाता है।