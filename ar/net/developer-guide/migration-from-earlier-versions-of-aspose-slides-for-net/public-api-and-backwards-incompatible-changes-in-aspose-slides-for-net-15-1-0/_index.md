---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 15.1.0"
linktitle: "Aspose.Slides لـ .NET 15.1.0"
type: docs
weight: 130
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج تقليدي
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسّرة في Aspose.Slides لـ .NET لتقوم بترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

هذه الصفحة تُدرج جميع الفئات والطرق والخصائص وما إلى ذلك [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)، وغيرها من التغييرات التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides for .NET 15.1.0.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم إضافة وظيفة استبدال الخطوط**
تمت إضافة إمكانية استبدال الخط بشكل عام عبر العرض التقديمي وبشكل مؤقت أثناء العرض.

تم تقديم خاصية جديدة "FontsManager" في فئة Presentation. تحتوي فئة FontsManager على الأعضاء التالية:

**IFontSubstRuleCollection FontSubstRuleList** خاصية

تستخدم هذه المجموعة من مثيلات IFontSubstRule لاستبدال الخطوط أثناء العرض. تحتوي IFontSubstRule على خصائص SourceFont و DestFont التي تنفذ واجهة IFontData، وخاصية ReplaceFontCondition التي تسمح باختيار شرط الاستبدال ("WhenInaccessible" أو "Always").

**IFontData[] GetFonts()** طريقة

تُستخدم لاسترجاع جميع الخطوط المستخدمة في العرض التقديمي الحالي.

**ReplaceFont** طرق

تُستخدم لاستبدال الخط بشكل دائم في العرض التقديمي.  

المثال التالي يوضح كيفية استبدال الخط في العرض التقديمي:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

مثال آخر يوضح استبدال الخط أثناء العرض عندما يكون غير متاح:

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