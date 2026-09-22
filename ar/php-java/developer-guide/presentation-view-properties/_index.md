---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في PHP
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/php-java/presentation-view-properties/
keywords:
- خصائص العرض
- عرض عادي
- محتوى المخطط
- أيقونات المخطط
- قفل القاطع العمودي
- عرض فردي
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides for PHP عبر Java لتخصيص صيغ شرائح PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **مقدمة**

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع مناطق المحتوى المختلفة. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض في الملف، بحيث عند إعادة الفتح تكون الحالة كما كانت عندما تم حفظ العرض التقديمي آخر مرة.

تم إضافة الطريقة [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تمت إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewRestoredProperties) وفروعها، وعدد ‎[SplitterBarStateType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SplitterBarStateType)‎.

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

تحدّد الطريقة [getShowOutlineIcons](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) والطريقة [setShowOutlineIcons](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) ما إذا كان ينبغي على التطبيق إظهار الأيقونات عند عرض محتوى المخطط في أيٍ من مناطق المحتوى في وضع العرض العادي.

تحدّد الطريقة [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) والطريقة [setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) ما إذا كان ينبغي للقطيع العمودي أن يلتقط إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

تحدّد الخاصية [getPreferSingleView](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) والطريقة [setPreferSingleView](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) ما إذا كان المستخدم يفضّل رؤية منطقة محتوى واحدة ممتدة على النافذة كاملة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكين ذلك، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

تحدّد الطريقة [getVerticalBarState](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) والطريقة [getHorizontalBarState](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) الحالة التي يجب أن يُظهر فيها شريط القاطع الأفقي أو العمودي. الشريط القاطع الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، بينما الشريط القاطع العمودي يفصل الشريحة عن المنطقة الجانبية. القيم المحتملة هي: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SplitterBarStateType/#Minimized)، [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SplitterBarStateType/#Maximized) و[SplitterBarStateType::Restored](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SplitterBarStateType/#Restored).

تحدّد الطريقة [getRestoredLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) والطريقة [getRestoredTop](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties#getRestoredTop) حجم المنطقة العلوية أو الجانبية من الشريحة في العرض العادي، عندما تُطبق قيمة [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SplitterBarStateType/#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) وفقًا لذلك.

## **حول استعادة INormalViewProperties**

يحدد حجم منطقة الشريحة (العرض عندما تكون تابعًا لـ[getRestoredTop](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getRestoredTop)، الارتفاع عندما تكون تابعًا لـ[getRestoredLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغرًا ولا مكبرًا).  

تحدد الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) حجم منطقة الشريحة (العرض عندما تكون تابعًا لـrestoredTop، الارتفاع عندما تكون تابعًا لـrestoredLeft).  

تحدد الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) ما إذا كان ينبغي لمنطقة المحتوى الجانبية أن تعوّض الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.  

مثال موضح أدناه يوضح كيفية الوصول إلى خصائص [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) لعرض تقديمي.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # استعادة خصائص عرض العرض التقديمي
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **تعيين قيمة التكبير الافتراضية**
{{% alert color="info" %}} 

يدعم Aspose.Slides for PHP via Java الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير بالفعل عند فتح العرض. يمكن القيام بذلك من خلال تعيين [ViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties) للعرض التقديمي. يمكن تعيين [getSlideViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) وكذلك [getNotesViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) برمجيًا. في هذا الموضوع، سنوضح بمثال كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties) للـ[Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation) في Aspose.Slides.

{{% /alert %}} 

لتعيين خصائص العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation).  
1. تعيين [View Properties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties) للـ[Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation).  
1. كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .  
   في المثال الموضح أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.

```php
  $presentation = new Presentation();
  try {
    # ضبط خصائص العرض للعرض التقديمي
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // قيمة التكبير بالنسبة المئوية لعرض الشريحة
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // قيمة التكبير بالنسبة المئوية لعرض الملاحظات

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **تعيين تباعد الشبكة**

استخدم [Presentation::getViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getViewProperties) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. تقرأ وتغيّر الطريقتان [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/#getGridSpacing) و[ViewProperties::setGridSpacing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/#setGridSpacing) الفاصل الزمني للشبكة التحريرية الأساسية. ينطبق هذا الإعداد على العرض التقديمي بأكمله، وليس على شريحة فردية. يُحدَّد تباعد الشبكة بالنقاط، حيث يساوي 72 نقطة واحد بوصة. استخدم قيمة موجبة وفقًا لتوثيق API.

المثال التالي يفتح ملف `demo.pptx` الموجود، يطبع تباعد الشبكة الحالي، يضبط فاصلًا ربع بوصة، ثم يحفظ النتيجة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الشبكة تختلف عن [drawing guides](/slides/ar/php-java/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما الأدلة المرسومة هي خطوط محاذاة أفقية أو عمودية موضوعة يدويًا. إضافة أو نقل أو مسح الأدلة المرسمية لا يغيّر تباعد الشبكة.

كل من الشبكة والأدلة المرسمية هي أدوات تحرير. لا يتم عرضها كمحتوى شريحة في PDF أو الصور أو SVG أو عرض الشرائح. تخزين تباعد الشبكة لا يضمن أن المحرر سيظهر الشبكة: تعتمد رؤيتها أيضًا على تفضيلات المشاهد أو المحرر.

## **الأسئلة الشائعة**

**Why is the grid not visible after I reopen the presentation?**  
الملف يخزن تباعد الشبكة، لكن المحرر يتحكم في ما إذا كانت الشبكة ستُعرض. تحقق من إعدادات رؤية الشبكة في المحرر.

**Does clearing drawing guides change the grid spacing?**  
لا. الأدلة المرسمية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل المخزن للشبكة دون تغيير.

**Can I set different view settings for different sections of a presentation?**  
[View settings](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getviewproperties/) تُعرف على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/getslideviewproperties/))، وليس لكل قسم، لذا يُطبق مجموعة واحدة من المعلمات على المستند كله عند الفتح.

**Can I predefine different view states for different users?**  
لا. تُخزن الإعدادات في الملف وتُشارك. قد تت honor تطبيقات المشاهدة تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**Can I prepare a template with predefined View Properties so new presentations open the same way?**  
نعم. نظرًا لأن [view properties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getviewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.