---
title: قالب‌بندی متن با استفاده از VSTO و Aspose.Slides برای Java
linktitle: قالب‌بندی متن
type: docs
weight: 30
url: /fa/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- قالب‌بندی متن
- مهاجرت
- VSTO
- اتوماسیون Office
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "از اتوماسیون Microsoft Office به Aspose.Slides برای Java مهاجرت کنید و متن را در ارائه‌های PowerPoint (PPT، PPTX) با کنترل دقیق قالب‌بندی کنید."
---
{{% alert color="primary" %}} 

گاهی اوقات، نیاز است که متن اسلایدها را به‌صورت برنامه‌نویسی شده قالب‌بندی کنید. این مقاله نشان می‌دهد که چگونه می‌توان یک ارائه نمونه را که متنی در اسلاید اول دارد، با استفاده از [VSTO](/slides/fa/java/format-text-using-vsto-and-aspose-slides-for-java/) و [Aspose.Slides for Java](/slides/fa/java/format-text-using-vsto-and-aspose-slides-for-java/) بخوانید. کد متن در جعبه متن سوم را طوری قالب‌بندی می‌کند که شبیه متن در جعبه متن آخر باشد.

{{% /alert %}} 
## **قالب‌بندی متن**
هر دو روش VSTO و Aspose.Slides مراحل زیر را انجام می‌دهند:

1. ارائهٔ منبع را باز کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. به جعبه متن سوم دسترسی پیدا کنید.
1. قالب‌بندی متن در جعبه متن سوم را تغییر دهید.
1. ارائه را روی دیسک ذخیره کنید.

تصاویر زیر اسلاید نمونه را قبل و بعد از اجرای کد VSTO و Aspose.Slides برای Java نشان می‌دهند.

**ارائه ورودی** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **مثال کد VSTO**
کد زیر نشان می‌دهد چگونه می‌توان متن در یک اسلاید را با استفاده از VSTO بازفرمت کرد.

**متن بازفرمت‌شده با VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **مثال Aspose.Slides برای Java**
برای قالب‌بندی متن با Aspose.Slides، قبل از قالب‌بندی متن، قلم را اضافه کنید.

**ارائه خروجی ایجاد‌شده با Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}