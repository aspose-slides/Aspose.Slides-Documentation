---
title: نسخ فقرة و جزء في PPTX
type: docs
weight: 70
url: /ar/java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

لكي نقوم بتنسيق نص العرض التقديمي، نحتاج إلى تنسيقه على مستوى **فقرة** و **جزء**. هناك بعض خصائص النص التي يمكن تعيينها على مستوى الفقرة والبعض الآخر يُحدد على مستوى الجزء. إذا كانت هناك فقرة أو جزء في النص نحتاج إلى نسخه إلى الفقرات أو الأجزاء المضافة حديثًا، نحتاج إلى نسخ جميع خصائص الفقرة أو الجزء المعني إلى الفقرة أو الجزء المضاف حديثًا.

{{% /alert %}} 
## **نسخ فقرة**
يمكن الوصول إلى خصائص **الفقرة** في مثيل **ParagraphFormat** من فئة **Paragraph**. نحتاج إلى نسخ جميع خصائص الفقرة المصدر إلى الفقرة المستهدفة. في المثال التالي، يتم مشاركة طريقة **CopyParagraph** التي تأخذ الفقرة المراد نسخها كوسائط. تقوم بنسخ جميع خصائص الفقرة المصدر إلى فقرة مؤقتة وتعيد نفس الشيء. تحصل الفقرة المستهدفة على القيم المنسوخة.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}


## **نسخ جزء**
يمكن الوصول إلى خصائص **الجزء** في مثيل **PortionFormat** من فئة **Portion**. نحتاج إلى نسخ جميع خصائص الجزء المصدر إلى الجزء المستهدف. في المثال التالي، يتم مشاركة طريقة **CopyPortion** التي تأخذ الجزء المراد نسخه كوسائط. تقوم بنسخ جميع خصائص الجزء المصدر إلى جزء مؤقت وتعيد نفس الشيء. يحصل الجزء المستهدف على القيم المنسوخة.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}