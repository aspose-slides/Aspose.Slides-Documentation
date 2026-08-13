---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides ل .NET 15.1.0
linktitle: Aspose.Slides ل .NET 15.1.0
type: docs
weight: 130
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسّرة في Aspose.Slides ل .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP."
---
{{% alert color="info" %}} 
هذه الصفحة تسرد جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) أو [removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) وكذلك التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 15.1.0 API.
{{% /alert %}} 
## **Public API Chages**
#### **Fonts Substitutions Functinality Has Been Added**
تمت إضافة إمكانية استبدال الخط بشكل عالمي عبر العرض التقديمي ومؤقتًا لأغراض العرض.

خاصية جديدة "FontsManager" في فئة Presentation تم تقديمها. فئة FontsManager تحتوي على الأعضاء التالية:

**IFontSubstRuleCollection FontSubstRuleList** خاصية
هذه المجموعة من مثيلات IFontSubstRule تُستخدم لاستبدال الخطوط أثناء العرض. تحتوي IFontSubstRule على خصائص SourceFont و DestFont التي تنفذ واجهة IFontData وخاصية ReplaceFontCondition التي تسمح باختيار شرط الاستبدال ("WhenInaccessible" أو "Always").

**IFontData[] GetFonts()** طريقة
تُستخدم لاسترجاع جميع الخطوط المستخدمة في العرض التقديمي الحالي.

**ReplaceFont** طرق
تُستخدم لاستبدال الخط بشكل دائم في العرض التقديمي.

المثال التالي يوضح كيفية استبدال الخط في العرض التقديمي:
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

مثال آخر يوضح استبدال الخط لأغراض العرض عندما يكون غير متاح:
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

            // سيتم استخدام خط Arial بدلاً من SomeRareFont عندما يكون غير متاح

            pres.Slides[0].GetImage();
```