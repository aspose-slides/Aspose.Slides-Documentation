---
title: API عمومی و تغییرات ناسازگار با نسخه قبلی در Aspose.Slides برای Java 15.1.0
linktitle: Aspose.Slides برای Java 15.1.0
type: docs
weight: 100
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای Java را مرور کنید تا به‌صورت روان اسلایدهای PowerPoint PPT، PPTX و ODP خود را مهاجرت کنید."
---
{{% alert color="primary" %}} 

این صفحه تمام [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) کلاس‌ها، متدها، ویژگی‌ها و غیره، هر محدودیت جدید و سایر [changes](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) معرفی‌شده با Aspose.Slides برای Java 15.1.0 API را فهرست می‌کند.

{{% /alert %}} {{% alert color="primary" %}} 

مشکلات شناخته‌شده‌ای در برخی از گلوله‌های تصویری و اشیای WordArt وجود دارد که در Aspose.Slides برای Java 15.2.0 برطرف خواهند شد.

{{% /alert %}} 
## **تغییرات API عمومی**
### **قابلیت جایگزینی قلم‌ها اضافه شد**
امکان جایگزینی قلم‌ها به صورت سراسری در سراسر ارائه و به صورت موقت برای رندرینگ اضافه شده است.

متد جدید getFontsManager() از کلاس Presentation معرفی شده است. کلاس FontsManager اعضای زیر را دارد:

**IFontSubstRuleCollection getFontSubstRuleList**() متد

این مجموعه ای از نمونه‌های IFontSubstRule است که برای جایگزینی قلم‌ها هنگام رندرینگ استفاده می‌شود. IFontSubstRule دارای متدهای getSourceFont() و getDestFont() است که واسط IFontData را پیاده‌سازی می‌کنند و متد getReplaceFontCondition() که امکان انتخاب شرایط جایگزینی را می‌دهد ("WhenInaccessible" یا "Always").

**IFontData[] getFonts()** متد می‌تواند برای بازیابی تمام قلم‌های استفاده‌شده در ارائه جاری استفاده شود.

**replaceFont(...)** متدها می‌توانند برای جایگزینی دائم یک قلم در ارائه استفاده شوند.

مثال زیر نحوه جایگزینی یک قلم در ارائه را نشان می‌دهد:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

مثال دیگری نشان می‌دهد که چگونه برای رندرینگ هنگام عدم دسترسی به قلم، جایگزینی قلم انجام شود:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// فونت Arial به جای SomeRareFont در صورت عدم دسترسی استفاده می‌شود

pres.getSlides().get_Item(0).getThumbnail(1, 1);
```