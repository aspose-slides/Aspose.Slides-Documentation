---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 15.1.0
linktitle: Aspose.Slides لـ .NET 15.1.0
type: docs
weight: 130
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- الترحيل
- الكود القديم
- الكود الحديث
- النهج القديم
- النهج الحديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for .NET لتتمكن من ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع الفئات، والطرق، والخصائص، وما إلى ذلك، التي تم [added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) أو [removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 15.1.0 API.

{{% /alert %}} 
## **Public API Chages**
#### **Fonts substitutions functinality has been added**
تمت إضافة إمكانية استبدال الخط بشكل عام عبر العرض التقديمي ومؤقتًا للتصيير.

تم تقديم خاصية جديدة "FontsManager" في فئة Presentation. تحتوي فئة FontsManager على الأعضاء التالية:

**IFontSubstRuleCollection FontSubstRuleList** Property  
هذه المجموعة من مثيلات IFontSubstRule تُستخدم لاستبدال الخطوط أثناء التصيير. IFontSubstRule يحتوي على خصائص SourceFont و DestFont التي تنفّذ واجهة IFontData وخصائص ReplaceFontCondition التي تسمح باختيار شرط الاستبدال ("WhenInaccessible" أو "Always").

**IFontData[] GetFonts()** Method  
تُستخدم لاسترجاع جميع الخطوط المستخدمة في العرض التقديمي الحالي.

**ReplaceFont** Methods  
تُستخدم لاستبدال الخط بشكل دائم في العرض التقديمي.

المثال التالي يوضح كيفية استبدال الخط في العرض التقديمي:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

مثال آخر يوضح استبدال الخط للتصيير عندما يكون غير متاح:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial font will be used instead of SomeRareFont when inaccessible

            pres.Slides[0].GetThumbnail();

```