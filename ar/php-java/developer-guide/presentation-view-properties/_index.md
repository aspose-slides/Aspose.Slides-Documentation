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
- تثبيت الفاصل العمودي
- العرض الفردي
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- العرض التقديمي
- PHP
- Aspose.Slides
description: "اكتشف خصائص عرض Aspose.Slides لـ PHP عبر Java لتخصيص صيغ شرائح PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---

{{% alert color="primary" %}} 

تتكون طريقة العرض العادية من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة للمحتوى. تتيح هذه المعلومات للتطبيق حفظ حالة العرض في الملف، بحيث عند إعادة الفتح تكون طريقة العرض في نفس الحالة التي تم حفظ العرض التقديمي فيها آخر مرة.

تم إضافة الطريقة [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص طريقة العرض العادية للعرض التقديمي.  

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties) وفروعها، وعدد [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) enum.  

{{% /alert %}} 

## **About INormalViewProperties**

تمثل خصائص طريقة العرض العادية.

تشير الطرق [getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) إلى ما إذا كان ينبغي على التطبيق إظهار الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تشير الطرق [getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) إلى ما إذا كان ينبغي أن ينتقل الفاصل العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تشير الخاصية [getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) إلى ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة في النافذة بالكامل بدلاً من طريقة العرض العادية القياسية التي تحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في كامل النافذة.

تحدد الطرق [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) الحالة التي يجب عرض شريط الفاصل الأفقي أو العمودي بها. شريط الفاصل الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، وشريط الفاصل العمودي يفصل الشريحة عن المنطقة الجانبية. القيم الممكنة هي: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored).

تحدد الطرق [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) حجم المنطقة العليا أو الجانبية للشريحة في طريقة العرض العادية، عندما تُطبق القيمة [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) وفقًا لذلك.

## **About Restoring INormalViewProperties**

يحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--)، الارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--)) في طريقة العرض العادية، عندما تكون المنطقة بحجم متغير مستعاد (ليس مصغرة ولا مكبرة).  

تشير الطريقة [getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getDimensionSize--) إلى حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ restoredTop، الارتفاع عندما تكون طفلاً لـ restoredLeft).  

تشير الطريقة [getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) إلى ما إذا كان يجب على المنطقة الجانبية تعديل حجمها لتعويض الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.  

مثال أدناه يوضح كيفية الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.  
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

يدعم Aspose.Slides for PHP via Java الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير بالفعل عند فتح العرض. يمكن تحقيق ذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) للعرض التقديمي. يمكن تعيين كل من [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNotesViewProperties--) برمجياً. في هذا الموضوع، سنرى من خلال مثال كيفية تعيين [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) في [Aspose.Slides](/slides/ar/).  

{{% /alert %}} 

لتعيين خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. تعيين [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .  
   في المثال المرفق أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.  
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


## **FAQ**

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) على مستوى العرض التقديمي ([العرض العادي](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[عرض الشريحة](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/))، وليس لكل قسم، لذلك تنطبق مجموعة واحدة من المعلمات على المستند بأكمله عند الفتح.

**هل يمكنني تحديد حالات عرض مختلفة مسبقًا لمستخدمين مختلفين؟**

لا. تُحفظ الإعدادات في الملف وتُشارك. قد تحترم تطبيقات العرض تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض محددة مسبقًا بحيث يفتح العروض الجديدة بنفس الطريقة؟**

نعم. لأن [خصائص العرض](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) تُحفظ على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الابتدائي.