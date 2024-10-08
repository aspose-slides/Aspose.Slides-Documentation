---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 20
url: /ar/php-java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

تمت ملاحظة أن أوراق Excel المدمجة كـ OLE في عرض PowerPoint من خلال مكونات Aspose يتم تغيير حجمها إلى مقياس غير محدد بعد التفعيل الأول. هذا السلوك يُحدث فرقًا بصريًا كبيرًا في العرض بين حالات التفعيل السابقة واللاحقة للرسم البياني. لقد قمنا بالتحقيق في هذه المشكلة بتفصيل ووجدنا الحل لهذه المشكلة التي تم تناولها في هذه المقالة.

{{% /alert %}} 
## **السياق**
في [مقال إضافة إطارات Ole](), شرحنا كيفية إضافة إطار Ole في العرض في عرض PowerPoint باستخدام Aspose.Slides لـ PHP عبر Java. من أجل معالجة [مشكلة تغيير الكائن](/slides/ar/php-java/object-changed-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة ورقة العمل لمنطقة محددة إلى إطار كائن OLE الخاص بالرسم البياني. في العرض الناتج، عندما نقوم بالنقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تنشيط رسم Excel البياني. يمكن لمستخدمي النهاية إجراء أي تغييرات مطلوبة في دفتر العمل Excel الفعلي ثم العودة إلى الشريحة المعنية من خلال النقر خارج دفتر العمل Excel المفعّل. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. ستكون عوامل تغيير الحجم مختلفة لأحجام مختلفة من إطار كائن OLE ودفتر العمل Excel المدمج.
## **سبب تغيير الحجم**
نظرًا لأن دفتر العمل Excel له حجم نافذته الخاصة، فإنه يحاول الاحتفاظ بحجمه الأصلي عند التفعيل الأول. من ناحية أخرى، سيكون لإطار كائن OLE حجمه الخاص. وفقًا لـ Microsoft، عند تنشيط دفتر العمل Excel، تتفاوض Excel وPowerPoint على الحجم وتضمن أنه يتناسب بشكل صحيح كجزء من عملية التضمين. استنادًا إلى الاختلافات في حجم نافذة Excel وحجم / موضع إطار كائن OLE، يحدث تغيير الحجم.
## **حل عملي**
هناك حلّان ممكنان لتجنب تأثير إعادة الحجم.* قم بتغيير حجم إطار Ole في PPT ليتناسب مع الحجم من حيث ارتفاع/عرض عدد الصفوف/الأعمدة المطلوب في إطار Ole* احتفظ بحجم إطار Ole ثابتًا وقم بتغيير حجم الصفوف/الأعمدة المشاركة لتناسب حجم إطار Ole المحدد
## **تغيير حجم إطار Ole ليتناسب مع حجم الصفوف/الأعمدة المختارة في ورقة العمل**
في هذا النهج، سنتعلم كيفية تعيين حجم إطار Ole لدفتر العمل Excel المدمج بما يتناسب مع الحجم التراكمي لعدد الصفوف والأعمدة المشاركة في ورقة العمل Excel.
## **مثال**
افترض أننا قمنا بتعريف ورقة Excel نموذجية ونرغب في إضافتها إلى العرض كإطار Ole. في هذا السيناريو، سيتم حساب حجم إطار كائن OLE أولاً بناءً على ارتفاع الصفوف التراكمي وعرض الأعمدة لصفوف وأعمدة دفتر العمل المشاركة. ثم سنقوم بتعيين حجم إطار Ole إلى تلك القيمة المحسوبة. لتجنب الرسالة الحمراء **الكائن المضمن** لإطار Ole في PowerPoint، سنقوم أيضًا بالحصول على صورة للأجزاء المرغوبة من الصفوف والأعمدة في دفتر العمل وتعيينها كصورة إطار Ole.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}

## **تغيير ارتفاع الصفوف وعرض الأعمدة في ورقة العمل وفقًا لحجم إطار Ole**
في هذا النهج، سنتعلم كيفية تغيير ارتفاعات الصفوف المشاركة وعرض العمود المشاركة وفقًا لحجم إطار Ole المحدد
## **مثال**
افترض أننا قمنا بتعريف ورقة Excel نموذجية ونرغب في إضافتها إلى العرض كإطار Ole. في هذا السيناريو، سنقوم بتعيين حجم إطار Ole وتغيير حجم الصفوف والأعمدة المشاركة في منطقة إطار Ole. ثم سنقوم بحفظ دفتر العمل في دفق لحفظ التغييرات وتحويله إلى مصفوفة بايت لإضافته في إطار Ole. لتجنب الرسالة الحمراء **الكائن المضمن** لإطار Ole في PowerPoint، سنقوم أيضًا بالحصول على صورة للأجزاء المرغوبة من الصفوف والأعمدة في دفتر العمل وتعيينها كصورة إطار Ole.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **الخاتمة**
{{% alert color="primary" %}} 

هناك نهجان لحل مشكلة تغيير حجم ورقة العمل. تعتمد اختيار الطريقة المناسبة على المتطلبات وحالة الاستخدام. كلا النهجين يعمل بنفس الطريقة سواء كانت العروض تم إنشاؤها من قالب أو تم إنشاؤها من الصفر. أيضًا، لا يوجد حد لحجم إطار كائن OLE في الحل.

{{% /alert %}}