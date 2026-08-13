---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for Java 15.1.0
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- الترحيل
- كود تقليدي
- كود حديث
- نهج تقليدي
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات الجوهرية في Aspose.Slides for Java للقيام بترحيل سلس لحلول عروض PowerPoint (PPT, PPTX) و ODP."
---
{{% alert color="info" %}} 

هذه الصفحة تسرد جميع الفئات، والأساليب، والخصائص وما إلى ذلك المُضافة، وأي قيود جديدة، وغيرها من [التغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides for Java 15.1.0.

{{% /alert %}} {{% alert color="info" %}} 

هناك مشكلات معروفة تتعلق ببعض نقاط الصور وكائنات WordArt سيتم إصلاحها في Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **تغييرات الواجهة العامة**
### **تم إضافة خاصية استبدال الخطوط**
تمت إضافة إمكانية استبدال الخطوط على مستوى العرض التقديمي بالكامل أو مؤقتًا أثناء العرض.

تم تقديم الطريقة الجديدة getFontsManager() في فئة Presentation. تحتوي فئة FontsManager على الأعضاء التاليين:

**IFontSubstRuleCollection getFontSubstRuleList**() طريقة

هذه مجموعة من كائنات IFontSubstRule المستخدمة لاستبدال الخطوط أثناء العرض. يحتوي IFontSubstRule على طريقتي getSourceFont() و getDestFont() اللتين تنفذان واجهة IFontData، وطريقة getReplaceFontCondition() التي تسمح باختيار شرط الاستبدال ("WhenInaccessible" أو "Always").

**IFontData[] getFonts()** طريقة يمكن استخدامها لاسترجاع جميع الخطوط المستخدمة في العرض التقديمي الحالي.

**replaceFont(...)** طرق يمكن استخدامها لاستبدال خط بشكل دائم في العرض التقديمي.

المثال التالي يوضح كيفية استبدال خط في عرض تقديمي:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

مثال آخر يُظهر استبدال الخط أثناء العرض عندما يكون غير قابل للوصول:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // سيتم استخدام خط Arial بدلاً من SomeRareFont عندما يكون غير قابل للوصول.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```