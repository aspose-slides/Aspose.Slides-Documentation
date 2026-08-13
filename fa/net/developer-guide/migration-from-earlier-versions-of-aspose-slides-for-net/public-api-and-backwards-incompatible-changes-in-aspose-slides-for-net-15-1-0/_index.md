---
title: API عمومی و تغییرات ناسازگار به‌عقب در Aspose.Slides برای .NET 15.1.0
linktitle: Aspose.Slides برای .NET 15.1.0
type: docs
weight: 130
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را بررسی کنید تا بتوانید به‌صورت روان راه‌حل‌های ارائهٔ PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، خصوصیات و غیرهٔ [اضافه](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) یا [حذف](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) شده را فهرست می‌کند و سایر تغییراتی که در API Aspose.Slides for .NET 15.1.0 معرفی شده‌اند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **قابلیت جایگزینی فونت‌ها اضافه شد**
امکان جایگزینی فونت به صورت سراسری در سراسر ارائه و به صورت موقت برای رندر افزوده شده است.

ویژگی جدید "FontsManager" در کلاس Presentation معرفی شد. کلاس FontsManager دارای اعضای زیر است:

**IFontSubstRuleCollection FontSubstRuleList** Property  
این مجموعه از نمونه‌های IFontSubstRule برای جایگزینی فونت‌ها هنگام رندر استفاده می‌شود. IFontSubstRule دارای خصوصیات SourceFont و DestFont که پیاده‌سازی IFontData هستند و خصوصیت ReplaceFontCondition که امکان انتخاب شرط جایگزینی را می‌دهد ("WhenInaccessible" یا "Always").

**IFontData[] GetFonts()** Method  
برای بازیابی تمام فونت‌های استفاده‌شده در ارائهٔ جاری استفاده می‌شود.

**ReplaceFont** Methods  
برای جایگزینی دائمی فونت در ارائه به کار می‌رود.

مثال زیر نشان می‌دهد چگونه می‌توان فونت را در ارائه جایگزین کرد:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

مثال دیگر، جایگزینی فونت برای رندر زمانی که دسترسی به فونت امکان‌پذیر نیست را نشان می‌دهد:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // فونت Arial به جای SomeRareFont در صورتی که قابل دسترسی نباشد استفاده می‌شود

            pres.Slides[0].GetImage();

```