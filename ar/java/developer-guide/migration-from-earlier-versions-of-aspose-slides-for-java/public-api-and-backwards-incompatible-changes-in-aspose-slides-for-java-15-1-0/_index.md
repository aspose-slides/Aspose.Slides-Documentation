---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.1.0
type: docs
weight: 100
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

تدرج هذه الصفحة جميع [الإضافات](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) من الفئات والطرق والخصائص وما إلى ذلك، وأي قيود جديدة وغيرها من [التغييرات](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

توجد مشكلات معروفة تتعلق ببعض النقاط البالية والصور الجمالية التي سيتم إصلاحها في Aspose.Slides لـ Java 15.2.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة وظيفة استبدال الخطوط**
تمت إضافة إمكانية استبدال الخطوط بشكل عالمي عبر العرض التقديمي ومؤقتًا للتقديم.

تم تقديم الطريقة الجديدة getFontsManager() من فئة Presentation. تحتوي فئة FontsManager على الأعضاء التالية:

**IFontSubstRuleCollection getFontSubstRuleList**() method

هذه هي مجموعة من مثيلات IFontSubstRule المستخدمة لاستبدال الخطوط أثناء التقديم. تحتوي IFontSubstRule على طرق getSourceFont() و getDestFont() التي تنفذ واجهة IFontData وطريقة getReplaceFontCondition() التي تتيح اختيار شرط الاستبدال ("عندما يكون غير متاح" أو "دائمًا").

يمكن استخدام **IFontData[] getFonts()** لاسترداد جميع الخطوط المستخدمة في العرض التقديمي الحالي.

يمكن استخدام طرق **replaceFont(...)}** لاستبدال الخط بشكل دائم في العرض التقديمي.

يوضح المثال التالي كيفية استبدال خط في عرض تقديمي:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

يوضح مثال آخر استبدال الخط للتقديم عندما يكون غير متاح:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// سيتم استخدام خط Arial بدلاً من SomeRareFont عندما يكون غير متاح

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```