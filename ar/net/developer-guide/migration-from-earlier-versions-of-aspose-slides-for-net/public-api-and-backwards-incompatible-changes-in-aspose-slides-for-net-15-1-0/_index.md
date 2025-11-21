---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 15.1.0
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- ترحيل
- شفرة تقليدية
- شفرة حديثة
- نهج تقليدي
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for .NET للقيام بالترحيل السلس لحلول عرض PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) والطرق والخصائص وما إلى ذلك، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 15.1.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
#### **تم إضافة وظيفة استبدال الخطوط**
تم إضافة إمكانية استبدال الخط عالميًا عبر العرض التقديمي ومؤقتًا عند العرض.

تم تقديم الخاصية "FontsManager" في فئة Presentation. يحتوي فئة FontsManager على الأعضاء التالية:

**IFontSubstRuleCollection FontSubstRuleList** Property

هذه المجموعة من كائنات IFontSubstRule تستخدم لاستبدال الخطوط أثناء العرض. يحتوي IFontSubstRule على خاصيتي SourceFont و DestFont اللتين تنفذان واجهة IFontData وخاصية ReplaceFontCondition التي تسمح باختيار شرط الاستبدال ("WhenInaccessible" أو "Always").

**IFontData[] GetFonts()** Method

تُستخدم لاسترجاع جميع الخطوط المستخدمة في العرض التقديمي الحالي.

**ReplaceFont** Methods

تُستخدم لاستبدال الخط في العرض التقديمي بشكل دائم.

المثال التالي يوضح كيفية استبدال الخط في العرض التقديمي:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

مثال آخر يوضح استبدال الخط عند العرض عندما يكون الخط غير متاح:

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