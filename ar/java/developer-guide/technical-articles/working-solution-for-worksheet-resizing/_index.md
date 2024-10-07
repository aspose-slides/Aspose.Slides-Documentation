---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 20
url: /java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

لقد لوحظ أن أوراق عمل Excel المدمجة كـ OLE في عرض PowerPoint التقديمي من خلال مكونات Aspose يتم تغيير حجمها إلى مقياس غير معروف بعد التفعيل الأول. هذا السلوك يخلق اختلافًا بصريًا كبيرًا في العرض التقديمي بين حالات تفعيل الرسم البياني قبل وبعد. لقد بحثنا في هذه المشكلة بالتفصيل ووجدنا الحل لهذه المشكلة التي تم تناولها في هذه المقالة.

{{% /alert %}} 
## **الخلفية**
في [مقال إضافة إطارات Ole](), شرحنا كيفية إضافة إطار Ole في العرض التقديمي باستخدام Aspose.Slides لـ Java. من أجل استيعاب [مشكلة تغيير الكائن](/slides/java/object-changed-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة ورقة العمل لمنطقة مختارة إلى إطار OLE Object Frame الخاص بالرسم البياني. في العرض التقديمي الناتج، عندما ننقر مرتين على إطار OLE Object Frame الذي يعرض صورة ورقة العمل، يتم تفعيل رسم Excel البياني. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة في دفتر عمل Excel الفعلي ثم العودة إلى الشريحة المعنية بالنقر خارج دفتر عمل Excel الذي تم تفعيله. سيتغير حجم إطار OLE Object Frame عندما يعود المستخدم إلى الشريحة. سيكون عامل التغيير مختلفًا لأحجام مختلفة من إطار OLE Object Frame ودفتري Excel المدمجين.
## **سبب تغيير الحجم**
نظرًا لأن دفتر عمل Excel له حجمه الخاص، فإنه يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. من ناحية أخرى، سيكون لإطار OLE Object Frame حجمه الخاص. وفقًا لمايكروسوفت، عند تنشيط دفتر عمل Excel، تتفاوض Excel و PowerPoint على الحجم وتضمن أنه في النسب الصحيحة كجزء من عملية الالتفاف. بناءً على الاختلافات في حجم نوافذ Excel وحجم / موضع إطار OLE Object Frame، يحدث تغيير الحجم.
## **الحل العملي**
هناك حلان ممكنان لتجنب تأثير إعادة الحجم. * ضبط حجم إطار Ole في PPT ليتناسب مع الحجم من حيث الارتفاع / العرض لعدد الصفوف / الأعمدة المطلوبة في إطار Ole* إبقاء حجم إطار Ole ثابتًا وضبط حجم الصفوف / الأعمدة المشاركة لتناسب حجم إطار Ole المختار
## **ضبط حجم إطار Ole ليتناسب مع حجم الصفوف / الأعمدة المختارة في ورقة العمل**
في هذا النهج، سنتعلم كيفية ضبط حجم إطار Ole لدفتر عمل Excel المدمج ليعادل الحجم التراكمي لعدد الصفوف والأعمدة المشاركة في ورقة العمل الخاصة بـ Excel.
## **مثال**
افترض أننا قمنا بتعريف قالب ورقة Excel ونرغب في إضافتها إلى العرض التقديمي كإطار Ole. في هذه الحالة، سيتم حساب حجم إطار OLE Object Frame أولاً بناءً على ارتفاعات الصفوف التراكمية وأعرض الأعمدة للصفوف والأعمدة في دفتر العمل المشاركين. ثم سنقوم بضبط حجم إطار Ole إلى القيمة المحسوبة. من أجل تجنب رسالة **الكائن المدمج** باللون الأحمر لإطار Ole في PowerPoint، سنقوم أيضًا بالحصول على صورة للأجزاء المطلوبة من الصفوف والأعمدة في دفتر العمل وضبطها كصورة لإطار Ole.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}

## **تعديل ارتفاع صفوف ورقة العمل وعرض الأعمدة وفقًا لحجم إطار Ole**
في هذا النهج، سنتعلم كيفية ضبط ارتفاعات الصفوف المشاركة وعرض الأعمدة المشاركة وفقًا لحجم إطار Ole المضبوط بشكل مخصص.
## **مثال**
افترض أننا قمنا بتعريف قالب ورقة Excel ونرغب في إضافتها إلى العرض التقديمي كإطار Ole. في هذه الحالة، سنقوم بضبط حجم إطار Ole وضبط حجم الصفوف والأعمدة المشاركة في منطقة إطار Ole. ثم سنقوم بحفظ دفتر العمل في دفق لحفظ التغييرات وتحويله إلى مصفوفة بايت لإضافته في إطار Ole. من أجل تجنب رسالة **الكائن المدمج** باللون الأحمر لإطار Ole في PowerPoint، سنقوم أيضًا بالحصول على صورة للأجزاء المطلوبة من الصفوف والأعمدة في دفتر العمل وضبطها كصورة لإطار Ole.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **الخاتمة**
{{% alert color="primary" %}} 

هناك نهجان لإصلاح مشكلة تغيير حجم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات واستخدام الحالة. يعمل كلا النهجين بنفس الطريقة سواء كانت العروض التقديمية تم إنشاؤها من قالب أو تم إنشاؤها من الصفر. أيضًا، لا يوجد حد لحجم إطار OLE Object Frame في الحل.

{{% /alert %}}