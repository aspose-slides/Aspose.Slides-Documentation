---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET 15.1.0
type: docs
weight: 130
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
---

{{% alert color="primary" %}} 

توضح هذه الصفحة جميع [المضاف](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) أو [المremoved](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) الفئات، والأساليب، والخصائص، وما إلى ذلك، وأي تغييرات أخرى تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 15.1.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة وظيفة استبدال الخطوط**
تمت إضافة إمكانية استبدال الخطوط على مستوى العرض التقديمي بشكل عالمي ومؤقت للتقديم.

تم تقديم خاصية جديدة "FontsManager" في فئة Presentation. تحتوي فئة FontsManager على الأعضاء التالية:

**IFontSubstRuleCollection FontSubstRuleList** خاصية

تحتوي هذه المجموعة من مثيلات IFontSubstRule على استخدام لاستبدال الخطوط أثناء التقديم. تحتوي IFontSubstRule على خاصيتي SourceFont و DestFont التي تنفذ واجهة IFontData، و خاصية ReplaceFontCondition التي تسمح باختيار شرط الاستبدال ("WhenInaccessible" أو "Always").

**IFontData[] GetFonts()** أسلوب

يستخدم لاسترداد جميع الخطوط المستخدمة في العرض التقديمي الحالي.

**ReplaceFont** أساليب

تستخدم لاستبدال الخط بشكل دائم في العرض التقديمي.

يوضح المثال التالي كيفية استبدال الخط في العرض التقديمي:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

مثال آخر، يوضح استبدال الخطوط للتقديم عند عدم الوصول إليها:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // سيتم استخدام خط Arial بدلاً من SomeRareFont عند عدم الوصول إليه

            pres.Slides[0].GetThumbnail();

```