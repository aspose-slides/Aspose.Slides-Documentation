---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.1.0
type: docs
weight: 100
url: /ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [المضاف](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) من الفئات والطرق والخصائص وما إلى ذلك، وأي قيود جديدة وأخرى [التغييرات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

هناك مشكلات معروفة تتعلق ببعض النقاط البصرية والصور النصية (WordArt) والتي سيتم إصلاحها في Aspose.Slides لـ Java 15.2.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة وظيفة استبدال الخطوط**
تمت إضافة إمكانية استبدال الخطوط على مستوى العالم عبر العرض التقديمي ومؤقتًا للرسم.

تم تقديم الطريقة الجديدة getFontsManager() من فئة Presentation. تحتوي فئة FontsManager على الأعضاء التاليين:

**IFontSubstRuleCollection getFontSubstRuleList**() 

هذه هي مجموعة من مثيلات IFontSubstRule المستخدمة لاستبدال الخطوط أثناء عملية الرسم. تحتوي IFontSubstRule على طرق getSourceFont() و getDestFont() التي تنفذ واجهة IFontData وطريقة getReplaceFontCondition() التي تسمح باختيار شرط الاستبدال ("WhenInaccessible" أو "Always").

**IFontData[] getFonts()** يمكن استخدامها لاسترجاع جميع الخطوط المستخدمة في العرض التقديمي الحالي.

يمكن استخدام **replaceFont(...)** لاستبدال خط بشكل دائم في العرض التقديمي.

يوضح المثال التالي كيفية استبدال خط في عرض تقديمي:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

يوضح مثال آخر استبدال الخط للرسم عند عدم توفره:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// سيتم استخدام خط Arial بدلاً من SomeRareFont عند عدم توفره

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```