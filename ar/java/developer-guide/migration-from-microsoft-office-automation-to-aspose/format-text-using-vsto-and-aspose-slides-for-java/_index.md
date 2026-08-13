---
title: تنسيق النص باستخدام VSTO و Aspose.Slides لـ Java
linktitle: تنسيق النص
type: docs
weight: 30
url: /ar/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- تنسيق النص
- الهجرة
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بالهجرة من أتمتة Microsoft Office إلى Aspose.Slides لـ Java وقم بتنسيق النص في عروض PowerPoint (PPT, PPTX) بدقة تحكم عالية."
---
{{% alert color="info" %}} 

في بعض الأحيان، تحتاج إلى تنسيق النص على الشرائح برمجياً. توضح هذه المقالة كيفية قراءة عرض تقديمي نموذجي يحتوي على بعض النص في الشريحة الأولى باستخدام إما [VSTO](/slides/ar/java/format-text-using-vsto-and-aspose-slides-for-java/) و [Aspose.Slides for Java](/slides/ar/java/format-text-using-vsto-and-aspose-slides-for-java/). يقوم الكود بتنسيق النص في صندوق النص الثالث على الشريحة ليظهر كالنص في صندوق النص الأخير.

{{% /alert %}} 
## **تنسيق النص**
تتبع كل من طرق VSTO و Aspose.Slides الخطوات التالية:

1. فتح عرض التقديم المصدر.
1. الوصول إلى الشريحة الأولى.
1. الوصول إلى صندوق النص الثالث.
1. تغيير تنسيق النص في صندوق النص الثالث.
1. حفظ العرض التقديمي على القرص.

تظهر لقطات الشاشة أدناه الشريحة النموذجية قبل وبعد تنفيذ كود VSTO و Aspose.Slides for Java.

**عرض التقديم الإدخالي** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **مثال على كود VSTO**
يوضح الكود أدناه كيفية إعادة تنسيق النص على شريحة باستخدام VSTO.

**النص المعاد تنسيقه باستخدام VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **مثال Aspose.Slides for Java**
لتنسيق النص باستخدام Aspose.Slides، أضف الخط قبل تنسيق النص.

**عرض التقديم الناتج الذي تم إنشاؤه باستخدام Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}