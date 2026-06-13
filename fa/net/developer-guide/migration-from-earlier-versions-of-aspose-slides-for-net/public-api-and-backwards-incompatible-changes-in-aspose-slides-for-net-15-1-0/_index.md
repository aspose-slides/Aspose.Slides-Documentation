---
title: API عمومی و تغییرات ناسازگار به‌عقب در Aspose.Slides برای .NET 15.1.0
linktitle: Aspose.Slides برای .NET 15.1.0
type: docs
weight: 130
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- مهاجرت
- کدهای ارثی
- کدهای مدرن
- رویکرد ارثی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را بررسی کنید تا بتوانید به‌صورت روان راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره که [اضافه](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) یا [حذف](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) شده‌اند و سایر تغییراتی که در API Aspose.Slides for .NET نسخه 15.1.0 معرفی شده‌اند را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات عمومی API**
#### **قابلیت جایگزینی فونت‌ها اضافه شده است**
امکان جایگزینی فونت به صورت سراسری در کل ارائه و به‌صورت موقت برای رندرینگ اضافه شده است.

ویژگی جدید "FontsManager" در کلاس Presentation معرفی شده است. کلاس FontsManager دارای اعضای زیر است:

**IFontSubstRuleCollection FontSubstRuleList** ویژگی

این مجموعه‌ای از نمونه‌های IFontSubstRule برای جایگزینی فونت‌ها در حین رندرینگ استفاده می‌شود. IFontSubstRule دارای ویژگی‌های SourceFont و DestFont که رابط IFontData را پیاده‌سازی می‌کنند و ویژگی ReplaceFontCondition است که امکان انتخاب شرایط جایگزینی ("WhenInaccessible" یا "Always") را فراهم می‌کند.

**IFontData[] GetFonts()** متد

برای دریافت تمام فونت‌های استفاده‌شده در ارائه جاری استفاده می‌شود.

**ReplaceFont** متدها

برای جایگزینی پایدار فونت در ارائه استفاده می‌شود.

مثال زیر نشان می‌دهد چگونه فونت را در ارائه جایگزین کنیم:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

مثال دیگر، جایگزینی فونت را برای رندرینگ در زمانی که دسترسی‌پذیر نیست نشان می‌دهد:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // فونت Arial به جای SomeRareFont زمانی که در دسترس نیست استفاده خواهد شد

            pres.Slides[0].GetThumbnail();

```