---
title: إدارة عقد شكل SmartArt في العروض التقديمية باستخدام C++
linktitle: عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/cpp/manage-smartart-shape-node/
keywords:
- عقدة SmartArt
- عقدة فرعية
- إضافة عقدة
- موضع العقدة
- الوصول إلى العقدة
- إزالة العقدة
- موضع مخصص
- عقدة مساعد
- تنسيق تعبئة
- تصيير العقدة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة عقد شكل SmartArt في ملفات PPT و PPTX باستخدام Aspose.Slides للغة C++. احصل على أمثلة شفرة واضحة ونصائح لتبسيط عروضك التقديمية."
---

## **إضافة عقدة SmartArt**
Aspose.Slides for C++ توفر أبسط واجهة برمجة تطبيقات لإدارة أشكال SmartArt بأبسط طريقة. سيساعدك الكود النموذجي التالي على إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.  
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
- استعراض كل شكل داخل الشريحة الأولى.  
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.  
- إضافة عقدة جديدة إلى مجموعة العقد NodeCollection في شكل SmartArt وتعيين النص في TextFrame.  
- الآن، إضافة عقدة فرعية إلى العقدة التي تم إضافتها حديثًا في SmartArt وتعيين النص في TextFrame.  
- حفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **إضافة عقدة SmartArt في موقع محدد**
في الكود النموذجي التالي نشرح كيفية إضافة العقد الفرعية التابعة للعقد المحددة في شكل SmartArt في موقع معين.

- إنشاء مثيل من الفئة `Presentation`.  
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
- إضافة شكل SmartArt من نوع StackedList إلى الشريحة التي تم الوصول إليها.  
- الوصول إلى العقدة الأولى في شكل SmartArt المضاف.  
- الآن، إضافة العقدة الفرعية للعقدة المحددة في الموضع 2 وتعيين نصها.  
- حفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **الوصول إلى عقدة SmartArt**
سيساعدك الكود النموذجي التالي على الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنك لا تستطيع تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.  
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
- استعراض كل شكل داخل الشريحة الأولى.  
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.  
- استعراض جميع العقد داخل شكل SmartArt.  
- الوصول إلى المعلومات وعرضها مثل موضع عقدة SmartArt، المستوى والنص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **الوصول إلى عقدة فرعية في SmartArt**
سيساعدك الكود النموذجي التالي على الوصول إلى العقد الفرعية التابعة للعقد المحددة في شكل SmartArt.

- إنشاء مثيل من الفئة PresentationEx وتحميل العرض التقديمي مع شكل SmartArt.  
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
- استعراض كل شكل داخل الشريحة الأولى.  
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArtEx إذا كان كذلك.  
- استعراض جميع العقد داخل شكل SmartArt.  
- لكل عقدة SmartArt مختارة، استعراض جميع العقد الفرعية داخل تلك العقدة المحددة.  
- الوصول إلى المعلومات وعرضها مثل موضع العقدة الفرعية، المستوى والنص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **الوصول إلى عقدة فرعية في SmartArt في موقع محدد**
في هذا المثال سنتعلم كيفية الوصول إلى العقد الفرعية في موقع معين تتبع للعقد المحددة في شكل SmartArt.

- إنشاء مثيل من الفئة `Presentation`.  
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
- إضافة شكل SmartArt من نوع StackedList.  
- الوصول إلى شكل SmartArt المضاف.  
- الوصول إلى العقدة عند الفهرس 0 لشكل SmartArt الذي تم الوصول إليه.  
- الآن، الوصول إلى العقدة الفرعية في الموضع 1 للعقدة المختارة باستخدام طريقة GetNodeByPosition().  
- الوصول إلى المعلومات وعرضها مثل موضع العقدة الفرعية، المستوى والنص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **إزالة عقدة SmartArt**
في هذا المثال سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.  
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
- استعراض كل شكل داخل الشريحة الأولى.  
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.  
- التحقق مما إذا كان SmartArt يحتوي على أكثر من 0 عقد.  
- اختيار العقدة التي تريد حذفها.  
- الآن، إزالة العقدة المختارة باستخدام طريقة RemoveNode().  
- حفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **إزالة عقدة SmartArt في موقع محدد**
في هذا المثال سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موقع معين.

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.  
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.  
- استعراض كل شكل داخل الشريحة الأولى.  
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.  
- اختيار عقدة شكل SmartArt عند الفهرس 0.  
- الآن، التحقق مما إذا كانت العقدة المختارة تحتوي على أكثر من عقدتين فرعيتين.  
- الآن، إزالة العقدة في الموضع 1 باستخدام طريقة RemoveNodeByPosition().  
- حفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **تعيين موضع مخصص لعقدة فرعية في SmartArt**
الآن يدعم Aspose.Slides تعيين خصائص X و Y لشكل SmartArt. يوضح المقتطف البرمجي أدناه كيفية تعيين موضع وحجم وتدوير مخصصين لشكل SmartArt، ويرجى ملاحظة أن إضافة عقد جديدة تتسبب في إعادة حساب المواضع والأحجام لجميع العقد.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **التحقق من عقدة مساعد**
في الكود النموذجي التالي سنستكشف كيفية تحديد العقد المساعدة في مجموعة عقد SmartArt وتغييرها.

- إنشاء مثيل من الفئة PresentationEx وتحميل العرض التقديمي مع شكل SmartArt.  
- الحصول على مرجع الشريحة الثانية باستخدام الفهرس الخاص بها.  
- استعراض كل شكل داخل الشريحة الأولى.  
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArtEx إذا كان كذلك.  
- استعراض جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت عقدة مساعد.  
- تغيير حالة العقدة المساعدة إلى عقدة عادية.  
- حفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **تعيين تنسيق تعبئة العقدة**
Aspose.Slides for C++ يجعل من الممكن إضافة أشكال SmartArt مخصصة وتعيين تنسيقات التعبئة الخاصة بها. يشرح هذا المقال كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق التعبئة باستخدام Aspose.Slides for C++.

يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة `Presentation`.  
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.  
- إضافة شكل SmartArt عن طريق تعيين LayoutType الخاص به.  
- تعيين FillFormat لعقد شكل SmartArt.  
- حفظ العرض التقديمي المعدل كملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **إنشاء صورة مصغرة لعقدة فرعية في SmartArt**
يمكن للمطورين إنشاء صورة مصغرة لعقدة فرعية في SmartArt باتباع الخطوات التالية:

1. إنشاء مثيل من فئة `Presentation` التي تمثل ملف PPTX.  
2. إضافة SmartArt.  
3. الحصول على مرجع العقدة باستخدام الفهرس الخاص بها.  
4. الحصول على صورة المصغرة.  
5. حفظ صورة المصغرة بأي تنسيق صور مرغوب.

المثال أدناه ينشئ صورة مصغرة لعقدة فرعية في SmartArt  
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


## **الأسئلة المتداولة**

**هل تدعم الرسوم المتحركة في SmartArt؟**

نعم. يُعامل SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوم المتحركة القياسية](/slides/ar/cpp/shape-animation/) (دخول، خروج، تأكيد، مسارات الحركة) وضبط التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الحاجة.

**كيف يمكنني تحديد موقع SmartArt معين على الشريحة إذا كان معرفه الداخلي غير معروف؟**

قم بالتعيين والبحث باستخدام [النص البديل]https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/. تعيين AltText مميز على SmartArt يتيح لك العثور عليه برمجياً دون الاعتماد على المعرفات الداخلية.

**هل سيتم الحفاظ على مظهر SmartArt عند تحويل العرض التقديمي إلى PDF؟**

نعم. يقوم Aspose.Slides بتصيير SmartArt بدقة بصرية عالية أثناء [تصدير PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط والألوان والتأثيرات.

**هل يمكنني استخراج صورة كاملة لـ SmartArt (للمعاينات أو التقارير)؟**

نعم. يمكنك تصيير شكل SmartArt إلى [صيغ نقطية]https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/ أو إلى [SVG]https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/ لإخراج متجه قابل للتوسع، مما يجعله مناسبًا للصور المصغرة أو التقارير أو الاستخدام على الويب.