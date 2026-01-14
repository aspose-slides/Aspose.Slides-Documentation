---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في PHP
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/php-java/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- تثبيت القاطع العمودي
- عرض واحد
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides للـ PHP عبر Java لتخصيص صيغ عروض PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---

{{% alert color="primary" %}} 

العرض العادي يتكوّن من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع مناطق المحتوى المختلفة. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض في الملف، بحيث عند إعادة الفتح تكون الحالة هي نفسها كما كانت عندما تم حفظ العرض التقديمي آخر مرة.

تمت إضافة الطريقة [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.

تمت إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties) وفروعها، وكذلك تعداد [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) .

{{% /alert %}} 

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

تحدّد الطريقتان [getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) و[setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدّد الطريقتان [getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) و[setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) ما إذا كان يجب أن ينتقل القاطع العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدّد الخاصيتان [getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) و[setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) ما إذا كان المستخدم يفضّل رؤية منطقة محتوى واحدة ممتدة على كامل النافذة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكين ذلك، قد يختار التطبيق عرض إحدى مناطق المحتوى في كامل النافذة.

تحدّد الطريقتان [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) و[getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) الحالة التي يجب أن يُظهر عليها شريط القاطع الأفقي أو العمودي. الشريط القاطع الأفقي يفصل الشريحة عن منطقة المحتوى التي تحت الشريحة، والشريط القاطع العمودي يفصل الشريحة عن المنطقة الجانبية. القيم الممكنة هي: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Minimized)، [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Maximized) و[SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored).

تحدّد الطريقتان [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) و[getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties#getRestoredTop) حجم المنطقة العلوية أو الجانبية في العرض العادي، عندما تُطَبَّق القيمة [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) و[getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) وفقًا لذلك.

## **حول Restoring INormalViewProperties**

تحدّد حجم منطقة الشريحة (العرض عندما تكون ابنًا لـ [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredTop)، الارتفاع عندما تكون ابنًا لـ [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) في العرض العادي، عندما تكون المنطقة ذات حجم متغيّر مستعاد (ليس مصغّرًا ولا مكبّرًا).

تحدّد الطريقة [getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) حجم منطقة الشريحة (العرض عندما تكون ابنًا لـ restoredTop، الارتفاع عندما تكون ابنًا لـ restoredLeft).

تحدّد الطريقة [getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) ما إذا كان حجم منطقة المحتوى الجانبية يجب أن يعوّض الحجم الجديد عند إعادة تحجيم النافذة التي تحتوي على العرض داخل التطبيق.

يوضح المثال أدناه كيف يمكنك الوصول إلى خصائص [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) لعرض تقديمي.
```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # استعادة خصائص العرض للعرض التقديمي
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Set the Default Zoom Value**
{{% alert color="primary" %}} 

أصبح Aspose.Slides for PHP via Java يدعم الآن ضبط قيمة التكبير الافتراضية للعرض التقديمي بحيث تكون قيمة التكبير مُحدَّدة بالفعل عند فتح العرض. يمكن تحقيق ذلك عن طريق ضبط كائن [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) للعرض التقديمي. يمكن ضبط كل من [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) و[getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) برمجيًا. في هذا الموضوع، سنستعرض مثالًا يوضح كيفية ضبط [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) في [Aspose.Slides](/slides/ar/).

{{% /alert %}} 

لضبط خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. ضبط [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. حفظ العرض التقديمي كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.
   في المثال أدناه، قمنا بضبط قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.
```php
  $presentation = new Presentation();
  try {
    # ضبط خصائص العرض للعرض التقديمي
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // قيمة التكبير بالنسب المئوية لعرض الشريحة
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // قيمة التكبير بالنسب المئوية لعرض الملاحظات

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**هل يمكنني ضبط إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) على مستوى العرض التقديمي ([العرض العادي](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[عرض الشريحة](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/))، وليس لكل قسم، لذا يتم تطبيق مجموعة واحدة من المعلمات على المستند بالكامل عند فتحه.

**هل يمكنني تعريف حالات عرض مسبقة لمستخدمين مختلفين؟**

لا. تُحفظ الإعدادات في الملف وتُشارك بين المستخدمين. قد تلتزم تطبيقات المشاهدة بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض معرفة مسبقًا بحيث تفتح العروض الجديدة بنفس الطريقة؟**

نعم. نظرًا لأن [خصائص العرض](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه مع نفس تكوين العرض الابتدائي.