---
title: واجهة برمجة التطبيقات العامة والتغييرات غير التCompatible في Aspose.Slides لـ PHP عبر Java 15.1.0
type: docs
weight: 100
url: /ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

تحتوي هذه الصفحة على قائمة بجميع [الإضافات](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) من الأصناف، والطرق، والخصائص وما إلى ذلك، وأي قيود جديدة وغيرها من [التغييرات](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) التي تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

هناك مشاكل معروفة تتعلق ببعض النقاط الصوتية للصور وأشياء WordArt التي سيتم إصلاحها في Aspose.Slides لـ PHP عبر Java 15.2.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تم إضافة إمكانية استبدال الخطوط**
تمت إضافة إمكانية استبدال الخطوط على مستوى عالمي عبر العرض التقديمي ولفترة مؤقتة للتصيير.

تم تقديم طريقة getFontsManager() من فئة Presentation. تحتوي فئة FontsManager على الأعضاء التالية:

**IFontSubstRuleCollection getFontSubstRuleList**() method

هذه هي مجموعة من مثيلات IFontSubstRule المستخدمة لاستبدال الخطوط أثناء التصيير. تحتوي IFontSubstRule على طرق getSourceFont() وgetDestFont() التي تنفذ واجهة IFontData، وطريقة getReplaceFontCondition() التي تسمح باختيار شرط الاستبدال ("عند عدم الوصول" أو "دائماً").

يمكن استخدام **IFontData[] getFonts()** الطريقة لاسترجاع جميع الخطوط المستخدمة في العرض التقديمي الحالي.

يمكن استخدام طرق **replaceFont(...)** لاستبدال خط بشكل دائم في عرض تقديمي.

يوضح المثال التالي كيفية استبدال خط في عرض تقديمي:

```php
  $pres = new Presentation("PresContainsArialFont.pptx");
  $sourceFont = new FontData("Arial");
  $destFont = new FontData("Times New Roman");
  $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
  $pres->save("PresContainsTimesNoewRomanFont.pptx", SaveFormat::Pptx);

```

يوضح مثال آخر استبدال الخط عند التصيير عندما يكون غير متاح:

```php
  $pres = new Presentation("PresContainsSomeRareFontFont.pptx");
  $sourceFont = new FontData("SomeRareFont");
  $destFont = new FontData("Arial");
  $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
  $fontSubstRuleCollection = new FontSubstRuleCollection();
  $fontSubstRuleCollection->add($fontSubstRule);
  $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
  # سيتم استخدام خط Arial بدلاً من SomeRareFont عند عدم الوصول
  $pres->getSlides()->get_Item(0)->getThumbnail(1, 1);

```