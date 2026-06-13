---
title: .NET में प्रस्तुति स्लाइड्स की तुलना करें
linktitle: स्लाइड्स की तुलना
type: docs
weight: 50
url: /hi/net/compare-slides/
keywords:
- स्लाइड्स की तुलना
- स्लाइड तुलना
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुतीकरण
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ प्रोग्रामेटिक रूप से PowerPoint और OpenDocument प्रस्तुतियों की तुलना करें। कोड में स्लाइड अंतर को जल्दी पहचानें।"
---
## **अवलोकन**

Aspose.Slides आपको स्लाइड्स, लेआउट स्लाइड्स और मास्टर स्लाइड्स की तुलना करने की अनुमति देता है, `IBaseSlide` इंटरफ़ेस और `BaseSlide` क्लास द्वारा प्रदान किए गए `Equals` मेथड का उपयोग करके। यह मेथड तब `true` लौटाता है जब तुलना की गई स्लाइड्स अपनी संरचना और स्थिर सामग्री में समान होती हैं।

## **दो स्लाइड्स की तुलना**

`Equals` मेथड को [IBaseSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide) इंटरफ़ेस और [BaseSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslide) क्लास में जोड़ा गया है। यह स्लाइड्स/लेआउट और स्लाइड्स/मास्टर स्लाइड्स के लिए `true` लौटाता है जो अपनी संरचना और स्थिर सामग्री में समान होते हैं।

दो स्लाइड्स समान होती हैं यदि सभी शैप्स, स्टाइल्स, टेक्स्ट, एनीमेशन और अन्य सेटिंग्स आदि समान हों। तुलना में अद्वितीय पहचानकर्ता मान, जैसे कि SlideId, तथा गतिशील सामग्री, जैसे कि डेट प्लेसहोल्डर में वर्तमान तिथि मान, को ध्यान में नहीं रखा जाता।

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्लाइड को छिपाया जाना स्लाइड्स की तुलना को प्रभावित करता है?**

[Hidden status](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/hidden/) एक प्रेज़ेंटेशन/प्लेबैक-स्तर की प्रॉपर्टी है, दृश्य सामग्री नहीं। दो विशिष्ट स्लाइड्स की समानता उनकी संरचना और स्थिर सामग्री से निर्धारित होती है; केवल इस बात से कि स्लाइड छिपी हुई है, स्लाइड्स अलग नहीं होतीं।

**क्या हाइपरलिंक और उनके पैरामीटरों को ध्यान में रखा जाता है?**

हाँ। लिंक स्लाइड की स्थिर सामग्री का हिस्सा होते हैं। यदि URL या हाइपरलिंक कार्रवाई में अंतर होता है, तो इसे आमतौर पर स्थिर सामग्री में अंतर माना जाता है।

**यदि कोई चार्ट बाहरी Excel फ़ाइल को संदर्भित करता है, तो क्या उस फ़ाइल की सामग्री को ध्यान में रखा जाएगा?**

नहीं। तुलना स्वयं स्लाइड्स के आधार पर की जाती है। बाहरी डेटा स्रोतों को सामान्यतः तुलना के समय पढ़ा नहीं जाता; केवल वही जो स्लाइड की संरचना और स्थिक स्थिति में मौजूद है, उसे माना जाता है।