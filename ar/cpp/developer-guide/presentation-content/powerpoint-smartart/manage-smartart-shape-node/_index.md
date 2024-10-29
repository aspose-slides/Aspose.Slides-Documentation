---
title: إدارة عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/cpp/manage-smartart-shape-node/
keywords:
- SmartArt
- عقدة SmartArt
- عقدة الطفل SmartArt
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides for C++
description: "إدارة عقد SmartArt وعقد الأطفال في عروض PowerPoint باستخدام C++"
---



## **إضافة عقدة SmartArt**
توفر Aspose.Slides for C++ أبسط واجهة برمجة التطبيقات لإدارة أشكال SmartArt بطريقة سهلة. سيساعدك الكود المثال التالي على إضافة عقدة وعقدة طفل داخل شكل SmartArt.

- أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وفتح العرض التقديمي مع شكل SmartArt.
- احصل على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- تنقل خلال كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وقم بتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- أضف عقدة جديدة في مجموعة عقد شكل SmartArt وقم بتعيين النص في TextFrame.
- الآن، أضف عقدة طفل في عقدة SmartArt الجديدة وقم بتعيين النص في TextFrame.
- احفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **إضافة عقدة SmartArt في موضع معين**
في الكود المثال التالي، شرحنا كيفية إضافة عقد الأطفال الخاصة بالعقد الخاصة بشكل SmartArt في موضع معين.

- أنشئ مثيل من `Presentation` .
- احصل على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- أضف شكل SmartArt من نوع StackedList في الشريحة التي تمت تجربتها.
- الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
- الآن، أضف عقدة الطفل للعقدة المحددة في الموضع 2 وقم بتعيين نصها.
- احفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}


## **الوصول إلى عقدة SmartArt**
سيساعدك الكود المثال التالي على الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

- أنشئ مثيل من `Presentation` وافتح العرض التقديمي مع شكل SmartArt.
- احصل على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- تنقل خلال كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وقم بتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- تنقل خلال جميع العقد داخل شكل SmartArt.
- الوصول إلى المعلومات وعرضها مثل موضع عقدة SmartArt، المستوى والنص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **الوصول إلى عقدة الطفل SmartArt**
سيساعدك الكود المثال التالي على الوصول إلى عقد الأطفال الخاصة بالعقد الخاصة بشكل SmartArt.

- أنشئ مثيل من PresentationEx وافتح العرض التقديمي مع شكل SmartArt.
- احصل على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- تنقل خلال كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وقم بتحويل الشكل المحدد إلى SmartArtEx إذا كان SmartArt.
- تنقل خلال جميع العقد داخل شكل SmartArt.
- لكل عقدة شكل SmartArt مختارة، تنقل خلال جميع عقد الأطفال داخل العقدة المحددة.
- الوصول إلى المعلومات وعرضها مثل موضع عقدة الطفل، المستوى والنص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **الوصول إلى عقدة الطفل SmartArt في موضع معين**
في هذا المثال، سنتعلم كيفية الوصول إلى عقد الأطفال في موضع معين الخاصة بالعقد الخاصة بشكل SmartArt.

- أنشئ مثيل من `Presentation` .
- احصل على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- أضف شكل SmartArt من نوع StackedList.
- الوصول إلى شكل SmartArt المضاف.
- الوصول إلى العقدة في الفهرس 0 لشكل SmartArt الذي تم الوصول إليه.
- الآن، الوصول إلى عقدة الطفل في الموضع 1 لعقدة SmartArt التي تم الوصول إليها باستخدام طريقة GetNodeByPosition().
- الوصول إلى المعلومات وعرضها مثل موضع عقدة الطفل، المستوى والنص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **إزالة عقدة SmartArt**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

- أنشئ مثيل من `Presentation` وافتح العرض التقديمي مع شكل SmartArt.
- احصل على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- تنقل خلال كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وقم بتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- تحقق مما إذا كان SmartArt لديه أكثر من 0 عقد.
- اختر العقدة SmartArt التي سيتم حذفها.
- الآن، قم بإزالة العقدة المحددة باستخدام طريقة RemoveNode() * احفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **إزالة عقدة SmartArt في موضع معين**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موضع معين.

- أنشئ مثيل من `Presentation` وافتح العرض التقديمي مع شكل SmartArt.
- احصل على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- تنقل خلال كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وقم بتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- اختر العقدة شكل SmartArt في الفهرس 0.
- الآن، تحقق مما إذا كانت العقدة SmartArt المحددة لديها أكثر من 2 عقد طفل.
- الآن، قم بإزالة العقدة في الموضع 1 باستخدام طريقة RemoveNodeByPosition().
- احفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}


## **تعيين موضع مخصص لعقدة الطفل SmartArt**
الآن توفر Aspose.Slides for .NET دعمًا لتعيين خصائص X و Y لشكل SmartArt. توضح كود الشفرة أدناه كيفية تعيين موضع وشكل وحجم SmartArtShape مخصص، ويرجى ملاحظة أن إضافة عقد جديدة يتسبب في إعادة حساب المواضع والأحجام لجميع العقد.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}


## **تحقق من عقدة المساعد**
في الكود المثال التالي، سنحقق كيفية تحديد عقد مساعد في مجموعة العقد الخاصة بـ SmartArt وتغييرها.

- أنشئ مثيل من PresentationEx وافتح العرض التقديمي مع شكل SmartArt.
- احصل على مرجع الشريحة الثانية باستخدام الفهرس الخاص بها.
- تنقل خلال كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وقم بتحويل الشكل المحدد إلى SmartArtEx إذا كان SmartArt.
- تنقل خلال جميع العقد داخل شكل SmartArt وتحقق مما إذا كانت عقد مساعد.
- غير حالة عقدة المساعد إلى عقدة عادية.
- احفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **تعيين تنسيق ملىء العقدة**
تتيح Aspose.Slides for C++ إمكانية إضافة أشكال SmartArt مخصصة وتعيين تنسيق ملئهم. يوضح هذا المقال كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق الملء الخاص بهم باستخدام Aspose.Slides for C++.

يرجى اتباع الخطوات أدناه:

- أنشئ مثيل من `Presentation` .
- احصل على مرجع شريحة باستخدام فهرسها.
- أضف شكل SmartArt عن طريق تعيين LayoutType الخاص به.
- قم بتعيين FillFormat للعقد الخاصة بشكل SmartArt.
- اكتب العرض التقديمي المعدل كملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}


## **إنشاء صورة مصغرة لعقدة الطفل SmartArt**
يمكن للمطورين إنشاء صورة مصغرة لعقدة الطفل من SmartArt من خلال اتباع الخطوات أدناه:

1. أنشئ مثيل `Presentation` يمثل ملف PPTX.
1. أضف SmartArt.
1. احصل على مرجع لعقدة باستخدام فهرسها.
1. احصل على صورة مصغرة.
1. احفظ الصورة المصغرة بأي تنسيق صورة مرغوب.

المثال التالي ينشئ صورة مصغرة لعقدة الطفل في SmartArt:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```