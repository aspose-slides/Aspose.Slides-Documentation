---
title: Python में प्रस्तुति स्लाइड्स की तुलना करें
linktitle: स्लाइड्स की तुलना करें
type: docs
weight: 50
url: /hi/python-java/compare-slides/
keywords:
- स्लाइड्स की तुलना
- स्लाइड तुलना
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों की प्रोग्रामेटिक तुलना करें। कोड में जल्दी से स्लाइड अंतर पहचानें।"
---
## **अवलोकन**

Aspose.Slides आपको स्लाइड, लेआउट स्लाइड और मास्टर स्लाइड की तुलना करने की अनुमति देता है, जिसके लिए आप [BaseSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/) क्लास द्वारा प्रदान किए गए [equals](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#equals) मेथड का उपयोग कर सकते हैं। यह मेथड तब `True` लौटाता है जब तुलना की गई स्लाइड की संरचना और स्थिर सामग्री समान हो।

## **दो स्लाइड की तुलना**

[BaseSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/) क्लास में [equals](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#equals) मेथड उन स्लाइड, लेआउट स्लाइड और मास्टर स्लाइड के लिए `True` लौटाता है जो संरचना और स्थिर सामग्री में समान होते हैं।

दो स्लाइड समान मानी जाती हैं जब उनके सभी शेप, स्टाइल, टेक्स्ट, एनीमेशन और अन्य सेटिंग समान हों। तुलना में यूनिक आइडेंटिफायर मान, जैसे स्लाइड ID, या गतिशील सामग्री, जैसे डेट प्लेसहोल्डर में वर्तमान तिथि, को ध्यान में नहीं रखा जाता।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्लाइड के छिपे होने का तथ्य स्लाइड की तुलना को प्रभावित करता है?**

[Hidden status](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getHidden) एक प्रस्तुति/प्लेबैक‑स्तर की प्रॉपर्टी है, न कि दृश्य सामग्री। दो विशिष्ट स्लाइड की समानता उनकी संरचना और स्थिर सामग्री द्वारा निर्धारित होती है; केवल यह तथ्य कि कोई स्लाइड छिपी हुई है, स्लाइड को अलग नहीं बनाता।

**क्या हाइपरलिंक और उनके पैरामीटर ध्यान में रखे जाते हैं?**

हाँ। लिंक स्लाइड की स्थिर सामग्री का हिस्सा हैं। यदि URL या हाइपरलिंक एक्शन अलग है, तो इसे सामान्यतः स्थिर सामग्री में अंतर माना जाता है।

**यदि किसी चार्ट में बाहरी Excel फ़ाइल का संदर्भ है, तो वह फ़ाइल की सामग्री ध्यान में रखी जाएगी?**

नहीं। तुलना केवल स्लाइड स्वयं के आधार पर की जाती है। बाहरी डेटा स्रोत आमतौर पर तुलना के समय पढ़े नहीं जाते; केवल वही जो स्लाइड की संरचना और स्थिर स्थिति में मौजूद होता है, उसे माना जाता है।