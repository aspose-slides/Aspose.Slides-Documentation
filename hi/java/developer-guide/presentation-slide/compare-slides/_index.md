---
title: जावा में प्रस्तुति स्लाइड्स की तुलना
linktitle: स्लाइड्स की तुलना
type: docs
weight: 50
url: /hi/java/compare-slides/
keywords:
- स्लाइड्स की तुलना
- स्लाइड तुलना
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रोग्रामेटिक रूप से PowerPoint और OpenDocument प्रस्तुतियों की तुलना करें। कोड में स्लाइड अंतर को शीघ्र पहचानें।"
---
## **अवलोकन**

Aspose.Slides आपको `IBaseSlide` इंटरफ़ेस और `BaseSlide` क्लास द्वारा प्रदान किए गए `equals` मेथड का उपयोग करके स्लाइड्स, लेआउट स्लाइड्स और मास्टर स्लाइड्स की तुलना करने की अनुमति देता है। यह मेथड तब `true` लौटाता है जब तुलना की गई स्लाइड्स अपने संरचना और स्थिर सामग्री में समान होती हैं।

## **दो स्लाइड्स की तुलना**
Equals मेथड को [IBaseSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IBaseSlide) इंटरफ़ेस और [BaseSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/BaseSlide) क्लास में जोड़ा गया है। यह स्लाइड/लेआउट और स्लाइड/मास्टर स्लाइड्स के लिए `true` लौटाता है जो अपनी संरचना और स्थिर सामग्री में समान हैं।

दो स्लाइड समान मानी जाती हैं यदि सभी शैप्स, स्टाइल्स, टेक्स्ट, एनीमेशन और अन्य सेटिंग्स आदि समान हों। तुलना में यूनिक आइडेंटिफ़ायर मान, जैसे कि SlideId, और डायनेमिक सामग्री, जैसे कि डेट प्लेसहोल्डर में वर्तमान तिथि मूल्य, को ध्यान में नहीं रखा जाता।

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

**क्या स्लाइड के छिपे होने की स्थिति स्लाइड्स की तुलना को प्रभावित करती है?**

[Hidden status](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/#getHidden--) प्रस्तुति/प्लेबैक-स्तर की प्रॉपर्टी है, न कि दृश्य सामग्री। दो विशिष्ट स्लाइड्स की समानता उनके संरचना और स्थिर सामग्री द्वारा निर्धारित होती है; केवल यह तथ्य कि कोई स्लाइड छिपी हुई है, स्लाइड्स को अलग नहीं बनाता।

**क्या हाइपरलिंक और उनके पैरामीटर को ध्यान में रखा जाता है?**

हाँ। लिंक स्लाइड की स्थिर सामग्री का हिस्सा होते हैं। यदि URL या हाइपरलिंक क्रिया अलग है, तो इसे सामान्यतः स्थिर सामग्री में अंतर माना जाता है।

**यदि किसी चार्ट का संदर्भ किसी बाहरी Excel फ़ाइल से है, तो क्या उस फ़ाइल की सामग्री को ध्यान में रखा जाएगा?**

नहीं। तुलना स्लाइड्स स्वयं के आधार पर की जाती है। बाहरी डेटा स्रोत सामान्यतः तुलना के समय पढ़े नहीं जाते; केवल वही जो स्लाइड की संरचना और स्थिर स्थिति में मौजूद है, उसे माना जाता है।