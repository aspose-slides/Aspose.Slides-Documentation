---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for .NET 15.1.0"
linktitle: "Aspose.Slides لـ .NET 15.1.0"
type: docs
weight: 130
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- "الهجرة"
- "كود قديم"
- "كود حديث"
- "نهج قديم"
- "نهج حديث"
- PowerPoint
- OpenDocument
- "عرض تقديمي"
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for .NET لتسهيل ترحيل حلول عروض PowerPoint PPT، PPTX و ODP الخاصة بك."
---

{{% alert color="primary" %}} 

تُدرج هذه الصفحة جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [مضاف](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) أو [مُزال](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) بها، بالإضافة إلى التغييرات الأخرى التي تم إدخالها مع Aspose.Slides for .NET 15.1.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
#### **تم إضافة وظيفة استبدال الخطوط**
تمت إضافة إمكانية استبدال الخط بشكل عالمي عبر العرض التقديمي ومؤقتًا لأغراض التصيير.

تم تقديم الخاصية الجديدة "FontsManager" في فئة Presentation. تحتوي فئة FontsManager على الأعضاء التالية:

**IFontSubstRuleCollection FontSubstRuleList** خاصية

تستخدم هذه المجموعة من كائنات IFontSubstRule لاستبدال الخطوط أثناء التصيير. يحتوي IFontSubstRule على خاصيتي SourceFont و DestFont اللتين تنفذان واجهة IFontData، وكذلك خاصية ReplaceFontCondition التي تتيح اختيار شرط الاستبدال ("WhenInaccessible" أو "Always").

**IFontData[] GetFonts()** طريقة

تُستخدم لاسترجاع جميع الخطوط المستخدمة في العرض التقديمي الحالي.

**ReplaceFont** طرق

تُستخدم لاستبدال الخط في العرض التقديمي بشكل دائم.

المثال التالي يوضح كيفية استبدال الخط في العرض التقديمي:

```csharp
Presentation pres = new Presentation("PresContainsArialFont.pptx");
IFontData sourceFont = new FontData("Arial");
IFontData destFont = new FontData("Times New Roman");
pres.FontsManager.ReplaceFont(sourceFont, destFont);
pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);
``` 

مثال آخر يوضح استبدال الخط لأغراض التصيير عندما يكون غير متاح:

```csharp
Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
IFontData sourceFont = new FontData("SomeRareFont");
IFontData destFont = new FontData("Arial");
IFontSubstRule fontSubstRule = new FontSubstRule(
    sourceFont, destFont, FontSubstCondition.WhenInaccessible);
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);
pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;
// سيتم استخدام خط Arial بدلاً من SomeRareFont عندما يكون غير متاح
pres.Slides[0].GetThumbnail();
```