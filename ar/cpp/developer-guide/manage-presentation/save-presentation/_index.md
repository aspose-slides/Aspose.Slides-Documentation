---
title: حفظ العرض التقديمي - مكتبة PowerPoint لـ C++
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /cpp/save-presentation/
description: تتيح لك واجهة برمجة تطبيقات C++ PowerPoint أو المكتبة حفظ العرض التقديمي إلى ملف أو دفق. يمكنك إنشاء عرض تقديمي من الصفر أو تعديل عرض تقديمي موجود.
---

{{% alert title="معلومات" color="info" %}}

لتعلم كيفية فتح أو تحميل العروض التقديمية، راجع مقال [*فتح العرض التقديمي*](https://docs.aspose.com/slides/cpp/open-presentation/).

{{% /alert %}}

يشرح المقال هنا كيفية حفظ العروض التقديمية.

يمسك [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) بمحتوى العرض التقديمي. سواء كنت تنشئ عرضًا تقديميًا من الصفر أو تعدل عرضًا موجودًا، عند الانتهاء، تريد حفظ العرض التقديمي. مع Aspose.Slides لـ C++، يمكن حفظه كـ **ملف** أو **دفق**. يشرح هذا المقال كيفية حفظ عرض تقديمي بطرق مختلفة:

## **حفظ العرض التقديمي إلى ملف**
احفظ عرضًا تقديميًا إلى الملفات عن طريق استدعاء **Presentation** [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) الطريقة. ببساطة مرر اسم الملف وتنسيق الحفظ إلى [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) الطريقة. تُظهر الأمثلة التي تلي كيفية حفظ عرض تقديمي باستخدام Aspose.Slides لـ C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveToFile-SaveToFile.cpp" >}}
## **حفظ العرض التقديمي إلى دفق**
يمكن حفظ عرض تقديمي إلى دفق عن طريق تمرير دفق إخراج إلى طريقة Save في فئة [Presentation]() . هناك العديد من أنواع التدفقات التي يمكن حفظ العرض التقديمي فيها. في المثال أدناه، قمنا بإنشاء ملف عرض تقديمي جديد، وأضفنا نصًا في الشكل وحفظنا العرض التقديمي إلى الدفق.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStream-SaveToStream.cpp" >}}

## **حفظ العرض التقديمي مع نوع العرض المحدد مسبقًا**
تقدم Aspose.Slides لـ C++ مرفقًا لتعيين نوع العرض للعرض التقديمي الذي تم إنشاؤه عند فتحه في PowerPoint من خلال الفئة [ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties) . تُستخدم خاصية [LastView](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) لتعيين نوع العرض باستخدام تعداد [ViewType](http://www.aspose.com/api/net/slides/aspose.slides/viewtype) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsPredefinedViewType-SaveAsPredefinedViewType.cpp" >}}

## **حفظ العرض التقديمي بتنسيق Strict Office Open XML**
تتيح لك Aspose.Slides حفظ العرض التقديمي بتنسيق Strict Office Open XML. لهذا الغرض، توفر الفئة **PptxOptions** حيث يمكنك تعيين خاصية التوافق عند حفظ ملف العرض التقديمي. إذا قمت بتعيين قيمتها على **Conformance.Iso29500_2008_Strict**، فسيتم حفظ ملف العرض التقديمي الناتج بتنسيق Strict Office Open XML.

يُنشئ كود المثال التالي عرضًا تقديميًا ويحفظه بتنسيق Strict Office Open XML. عند استدعاء طريقة الحفظ للعرض التقديمي، يتم تمرير كائن **PptxOptions** إليه مع تعيين خاصية التوافق كـ **Conformance.Iso29500_2008_Strict**.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStrictOpenXML-SaveToStrictOpenXML.cpp" >}}

## **حفظ تحديثات التقدم بالنسبة المئوية**
تمت إضافة واجهة **IProgressCallback** إلى واجهة **ISaveOptions** وفئة **SaveOptions** المجردة. تمثل واجهة **IProgressCallback** كائن استدعاء لتحديثات تقدم الحفظ بالنسبة المئوية.

تظهر مقتطفات الكود أدناه كيفية استخدام واجهة IProgressCallback:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.cpp" >}}

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-ExportProgressHandler.cpp" >}}

{{% alert title="معلومات" color="info" %}}

باستخدام واجهته الخاصة، طورت Aspose تطبيق [Splitter PowerPoint مجاني](https://products.aspose.app/slides/splitter) يتيح للمستخدمين تقسيم عروضهم التقديمية إلى ملفات متعددة. في الأساس، يقوم التطبيق بحفظ الشرائح المحددة من عرض تقديمي معين كملفات PowerPoint جديدة (PPTX أو PPT).

{{% /alert %}}