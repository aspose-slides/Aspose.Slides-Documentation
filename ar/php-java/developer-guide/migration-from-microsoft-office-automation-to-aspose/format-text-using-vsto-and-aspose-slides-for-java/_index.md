---
title: تنسيق النص باستخدام VSTO و Aspose.Slides ل PHP عبر Java
type: docs
weight: 30
url: /ar/php-java/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

في بعض الأحيان، تحتاج إلى تنسيق النص على الشرائح برمجيًا. تُظهر هذه المقالة كيفية قراءة عرض تقديمي عينة يحتوي على بعض النصوص على الشريحة الأولى باستخدام إما [VSTO](/slides/ar/php-java/format-text-using-vsto-and-aspose-slides-for-java/) و [Aspose.Slides ل PHP عبر Java](/slides/ar/php-java/format-text-using-vsto-and-aspose-slides-for-java/). يقوم الكود بتنسيق النص في مربع النص الثالث على الشريحة ليبدو كالنص في مربع النص الأخير.

{{% /alert %}} 
## **تنسيق النص**
تتخذ كل من طرق VSTO و Aspose.Slides الخطوات التالية:

1. فتح العرض التقديمي المصدر.
1. الوصول إلى الشريحة الأولى.
1. الوصول إلى مربع النص الثالث.
1. تغيير تنسيق النص في مربع النص الثالث.
1. حفظ العرض التقديمي على القرص.

تظهر لقطات الشاشة أدناه الشريحة العينة قبل وبعد تنفيذ كود VSTO و Aspose.Slides ل PHP عبر كود PHP.

**العرض التقديمي المدخل** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **مثال كود VSTO**
يوضح الكود أدناه كيفية إعادة تنسيق النص على الشريحة باستخدام VSTO.

**النص المعاد تنسيقه باستخدام VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **مثال Aspose.Slides ل PHP عبر Java**
لتنسيق النص باستخدام Aspose.Slides، أضف الخط قبل تنسيق النص.

**العرض التقديمي الناتج الذي تم إنشاؤه باستخدام Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}