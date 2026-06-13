---
title: PHP में प्रस्तुति स्लाइड्स की तुलना करें
linktitle: स्लाइड्स की तुलना
type: docs
weight: 50
url: /hi/php-java/compare-slides/
keywords:
- स्लाइड्स की तुलना
- स्लाइड तुलना
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रोग्रामेटिक रूप से PowerPoint और OpenDocument प्रस्तुतियों की तुलना करें। कोड में स्लाइड अंतर को जल्दी पहचानें।"
---
## **परिचय**

Aspose.Slides आपको `BaseSlide` क्लास द्वारा प्रदान किए गए `equals` मेथड का उपयोग करके स्लाइड्स, लेआउट स्लाइड्स और मास्टर स्लाइड्स की तुलना करने की सुविधा देता है। जब तुलना की गई स्लाइड्स की संरचना और स्थैतिक सामग्री समान होती है, तो यह मेथड `true` लौटाता है।

## **दो स्लाइड्स की तुलना करें**

`equals` मेथड को [BaseSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/BaseSlide) क्लास में जोड़ा गया है। यह उन स्लाइड्स/लेआउट और स्लाइड्स/मास्टर स्लाइड्स के लिए `true` लौटाता है जो अपनी संरचना और स्थैतिक सामग्री में समान होते हैं।  

दो स्लाइड्स समान होती हैं यदि सभी शैलियाँ, आकार, टेक्स्ट, एनीमेशन और अन्य सेटिंग्स आदि समान हों। तुलना में अद्वितीय पहचान मान जैसे SlideId और गतिशील सामग्री जैसे तिथि प्लेसहोल्डर में वर्तमान तिथि मान को ध्यान में नहीं रखा जाता।

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या यह तथ्य कि कोई स्लाइड छिपी हुई है, स्लाइड्स की तुलना को प्रभावित करता है?**

[छिपी स्थिति](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/gethidden/) एक प्रस्तुति/प्लेबैक‑स्तर की प्रॉपर्टी है, न कि दृश्य सामग्री। दो विशिष्ट स्लाइड्स की समानता उनकी संरचना और स्थैतिक सामग्री द्वारा निर्धारित होती है; केवल इस बात से कि कोई स्लाइड छिपी हुई है, स्लाइड्स अलग नहीं मानी जातीं।

**क्या हाइपरलिंक और उनके पैरामीटर ध्यान में रखे जाते हैं?**

हाँ। लिंक स्लाइड की स्थैतिक सामग्री का हिस्सा होते हैं। यदि URL या हाइपरलिंक क्रिया अलग है, तो इसे आमतौर पर स्थैतिक सामग्री में अंतर माना जाता है।

**यदि कोई चार्ट बाहरी Excel फ़ाइल को संदर्भित करता है, तो क्या उस फ़ाइल की सामग्री को ध्यान में रखा जाएगा?**

नहीं। तुलना केवल स्लाइड्स स्वयं पर आधारित होती है। बाहरी डेटा स्रोत आमतौर पर तुलना के समय पढ़े नहीं जाते; केवल वही जो स्लाइड की संरचना और स्थैतिक स्थिति में मौजूद है, उसे माना जाता है।