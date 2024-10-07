---
title: مشكلة تغيير الكائن عند إضافة OleObjectFrame
type: docs
weight: 10
url: /androidjava/object-changed-issue-when-adding-oleobjectframe/
---

## **بيان المشكلة**
عندما يضيف المطورون **OleObjectFrame** إلى شرائحهم باستخدام Aspose.Slides for Android عبر Java، تظهر رسالة **Object Changed** على الشريحة الناتجة بدلاً من **OLE Object**. يعتقد معظم عملاء Aspose.Slides for Android عبر Java أن هذه مشكلة أو خطأ في Aspose.Slides for Android عبر Java.
## **تحليل نقدي وشرح**
أولاً وقبل كل شيء، من المهم معرفة أن رسالة **Object Changed** التي تظهر من قبل Aspose.Slides for Android عبر Java بعد إضافة **OleObjectFrame** في الشريحة، ليست **خطأ** أو **خللاً** في Aspose.Slides for Android عبر Java. إنها مجرد معلومة أو رسالة لإبلاغ المستخدمين بتغيير الكائن وأن الصورة يجب أن يتم تحديثها.

على سبيل المثال، إذا قمت بإضافة **مخطط Microsoft Excel** كـ **OleObjectFrame** إلى شريحتك (لمزيد من التفاصيل وقطع الكود حول إضافة **OleObjectFrame** إلى شريحتك، [اضغط هنا](/slides/androidjava/adding-frame-to-the-slide/)) ثم فتحت ملف العرض باستخدام MS PowerPoint، فإن الشريحة (حيث تم إضافة **OLE Object**) ستبدو هكذا:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**الشكل**: شريحة تظهر رسالة **Object Changed** بعد إضافة **OLE Object**

هذه ليست مشكلة وما زال كائن **OLE Object** قد تم إضافته إلى الشريحة. إذا كنت ترغب في اختبار ذلك، فما عليك سوى **النقر المزدوج** على رسالة **Object Changed** أو **النقر الأيمن** عليها واختيار خيار **Worksheet Object -> Edit** كما هو موضح أدناه في الشكل:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**الشكل**: اختيار خيار **Edit** لتحرير **OLE Object**

بعد اختيارك خيار **Edit** من القائمة المنبثقة، سترى أن **Embedded OLE Object** سيصبح مرئيًا في شكل قابل للتحرير كما هو موضح أدناه:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**الشكل**: **OLE Object** في شكل قابل للتحرير

لا يزال بإمكانك رؤية رسالة **Object Changed** على الشريحة في **الجزء الأيسر** من MS PowerPoint الذي يعرض معاينات الشرائح. بمجرد النقر على **OLE Object**، سترى أن معاينة الشريحة ستتغير أيضًا وستحل رسالة **Changed Object** محل صورة **OLE Object** كما هو موضح أدناه:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**الشكل**: تحديث صورة **OLE Object**

الآن، يجب عليك **حفظ** ملف العرض الخاص بك باستخدام MS PowerPoint بحيث يتم تحديث صورة **OLE Object**. بمجرد حفظ عرضك وفتحه مرة أخرى باستخدام MS PowerPoint، سترى أنه لن تكون هناك رسالة **Object Changed**.
## **حلول إضافية**
في التحليل النقدي أعلاه، أوضحنا أن صورة **OLE Object** يمكن تحديثها عن طريق فتح ملف العرض في MS PowerPoint ثم حفظه. ولكن، هناك حلان آخران للتعامل مع رسالة **Object Changed**.
## **الحل الأول: استبدال رسالة Object Changed بصورة**
إذا كنت لا تحب رسالة **Object Changed**، يمكنك أيضًا استبدال تلك الرسالة بصورة خاصة بك. يمكنك إضافة أي صورة ترغب بها إلى عرضك ثم استخدام معرّف تلك الصورة المضافة لاستبدال رسالة **Object Changed**.

لتحقيق ذلك، يمكنك إضافة هذه الأسطر القليلة من الكود في تطبيقك بعد إضافة **OleObjectFrame** إلى الشريحة الخاصة بك.
## **مثال**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

بعد إضافة الأسطر أعلاه في تطبيقك، ستبدو الشريحة الناتجة التي تحتوي على **OleObjectFrame** هكذا:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**الشكل**: رسالة **Object Changed** مستبدلة بصورة
## **الحل الثاني: إنشاء ملحق لـ MS PowerPoint**
يمكنك أيضًا محاولة إنشاء ملحق لـ MS PowerPoint، الذي يقوم بتحديث جميع **OLE objects** عند فتح العرض في MS PowerPoint.