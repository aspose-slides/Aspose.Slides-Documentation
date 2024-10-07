---
title: خصائص عرض الشريحة
type: docs
url: /php-java/presentation-view-properties/
---

{{% alert color="primary" %}} 

يتكون العرض الطبيعي من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموقع مناطق المحتوى المختلفة. تتيح هذه المعلومات للتطبيق حفظ حالة العرض في الملف، بحيث عند إعادة فتحه يكون العرض في نفس الحالة التي كانت عليها عندما تم حفظ العرض آخر مرة.

تم إضافة دالة [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/php-java/aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.

تمت إضافة الواجهات [**INormalViewProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties)، [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties) وسلالتها، والتعداد [**SplitterBarStateType**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType).

{{% /alert %}} 


## **حول INormalViewProperties** #
تمثل خصائص العرض العادي.

تحدد الدوال [**getShowOutlineIcons**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [**setShowOutlineIcons**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ما إذا كان يجب على التطبيق عرض الرموز إذا تم عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الدوال [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ما إذا كان يجب على الفاصل العمودي الانجذاب إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدد الخاصية [**getPreferSingleView**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getPreferSingleView--) و [**setPreferSingleView**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ما إذا كان يفضل المستخدم رؤية منطقة محتوى فردية في نافذة كاملة على العرض العادي القياسي مع ثلاث مناطق محتوى. إذا تم تفعيلها، قد يختار التطبيق عرض واحدة من مناطق المحتوى في النافذة بالكامل.

تحدد الدوال [**getVerticalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) و [**getHorizontalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) الحالة التي يجب عرض الفاصل الأفقي أو العمودي فيها. يفصل الفاصل الأفقي الشريحة عن منطقة المحتوى أسفل الشريحة، ويفصل الفاصل العمودي الشريحة عن المنطقة الجانبية. القيم الممكنة هي: [**SplitterBarStateType::Minimized**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Minimized)، [**SplitterBarStateType::Maximized**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Maximized) و [**SplitterBarStateType::Restored**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored).

تحدد الدوال [**getRestoredLeft**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) و [**getRestoredTop**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما يتم تطبيق القيمة [**SplitterBarStateType::Restored**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored) على [**getVerticalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) و [**getHorizontalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) وفقًا لذلك.


## **حول استعادة INormalViewProperties** 
تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--)، الارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (لا مصغرة ولا م Maximized). 

تحدد الدالة [**getDimensionSize**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getDimensionSize--) حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ restoredTop، الارتفاع عندما تكون طفلاً لـ restoredLeft).

تحدد الدالة [**getAutoAdjust**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ما إذا كان يجب أن تتعوض منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

مثال موضح أدناه يوضح كيفية الوصول إلى خصائص [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);
    # استعادة خصائص العرض التقديمي
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **تعيين قيمة الزوم الافتراضية**
{{% alert color="primary" %}} 

Aspose.Slides لـ PHP عبر Java الآن يدعم تعيين قيمة الزوم الافتراضية للعرض التقديمي بحيث عند فتح العرض التقديمي، يتم ضبط الزوم مسبقًا. يمكن القيام بذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) لعرض تقديمي. يمكن تعيين [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getSlideViewProperties--) وكذلك [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNotesViewProperties--) برمجيًا. في هذا الموضوع، سنرى مع مثال كيفية تعيين [خصائص العرض](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) في [Aspose.Slides](/slides/).

{{% /alert %}} 

لتعيين خصائص العرض. يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. تعيين [خصائص العرض](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. كتابة العرض التقديمي كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/).
   في المثال المعطى أدناه، قمنا بتعيين قيمة الزوم لعرض الشريحة وكذلك عرض الملاحظات.

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $presentation = new Presentation();
  try {
    # تعيين خصائص العرض للعرض التقديمي
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100);// قيمة الزوم كنسبة مئوية لعرض الشريحة

    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100);// قيمة الزوم كنسبة مئوية لعرض الملاحظات

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```