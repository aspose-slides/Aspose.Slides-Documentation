---
title: مشكلة تغيير الكائن عند إضافة OleObjectFrame
type: docs
weight: 10
url: /ar/php-java/object-changed-issue-when-adding-oleobjectframe/
---

## **بيان المشكلة**
عندما يقوم المطورون بإضافة **OleObjectFrame** إلى شريحة باستخدام Aspose.Slides لـ PHP عبر Java، يتم عرض رسالة **تغيير الكائن** على الشريحة الناتجة بدلاً من **الكائن OLE**. يعتقد معظم عملاء Aspose.Slides لـ PHP عبر Java أنها خطأ أو عطل في Aspose.Slides لـ PHP عبر Java.
## **تحليل ونقد الشرح**
أولاً، من المهم معرفة أن رسالة **تغيير الكائن** التي تظهرها Aspose.Slides لـ PHP عبر Java بعد إضافة **OleObjectFrame** في الشريحة، هي **ليست** خطأ أو عطل في Aspose.Slides لـ PHP عبر Java. إنها مجرد معلومة أو رسالة لإخطار المستخدمين بأن الكائن قد تم تغييره ويجب تحديث الصورة.

على سبيل المثال، إذا قمت بإضافة **رسم بياني من Microsoft Excel** كـ **OleObjectFrame** إلى شريحتك (للمزيد من التفاصيل وشفرة المقتطف حول إضافة **OleObjectFrame** إلى شريحتك، [انقر هنا](/slides/ar/php-java/adding-frame-to-the-slide/)) ثم قمت بفتح ملف العرض التقديمي باستخدام MS PowerPoint، ستبدو الشريحة (حيث تم إضافة **الكائن OLE**) كما يلي:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**الشكل**: الشريحة التي تظهر رسالة **تغيير الكائن** بعد إضافة **الكائن OLE**

هذه ليست خطأ ولا يزال كائن الـ OLE الخاص بك مضافًا إلى الشريحة. إذا كنت ترغب في اختبار ذلك، فقم بـ **نقر مزدوج** على رسالة **تغيير الكائن** أو **انقر بزر الماوس الأيمن** عليها واختر خيار **كائن ورقة العمل -> تعديل** كما هو موضح أدناه في الشكل:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**الشكل**: اختيار خيار **تعديل** لتحرير **الكائن OLE**

بعد اختيارك خيار **تعديل** من القائمة المنبثقة، سترى أن **الكائن OLE المضمن** سيصبح مرئيًا في شكل قابل للتعديل كما هو موضح أدناه:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**الشكل**: **الكائن OLE** في شكل قابل للتعديل

لا يزال بإمكانك رؤية رسالة **تغيير الكائن** على الشريحة في **الجزء الأيسر** من MS PowerPoint الذي يعرض معاينات الشرائح. بمجرد أن تنقر على **الكائن OLE**، ستلاحظ أن معاينة الشريحة ستتغير أيضًا وستحل رسالة **تغيير الكائن** محلها صورة **الكائن OLE** كما هو موضح أدناه:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**الشكل**: تحديث صورة **الكائن OLE**

الآن، يجب عليك **حفظ** ملف العرض التقديمي الخاص بك باستخدام MS PowerPoint حتى يتم تحديث صورة **الكائن OLE**. بمجرد حفظ العرض التقديمي وإعادة فتحه باستخدام MS PowerPoint، لن ترى أي رسالة **تغيير الكائن**.
## **المزيد من الحلول**
في تحليل النقد أعلاه، أظهرنا أن صورة **الكائن OLE** يمكن تحديثها عن طريق فتح ملف العرض التقديمي في MS PowerPoint ثم حفظه. لكن، هناك حلان آخران للتعامل مع رسالة **تغيير الكائن**.
## **الحل الأول: استبدال رسالة تغيير الكائن بصورة**
إذا لم تعجبك رسالة **تغيير الكائن**، يمكنك أيضًا استبدال تلك الرسالة بصورة خاصة بك. يمكنك إضافة أي صورة مرغوبة إلى عرضك التقديمي ثم استخدام معرف الصورة المضافة لاستبدال رسالة **تغيير الكائن**.

لتحقيق ذلك، يمكنك إضافة هذه الأسطر القليلة من الشيفرة في تطبيقك بعد إضافة **OleObjectFrame** إلى شريحتك.
## **مثال**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

بعد إضافة الأسطر أعلاه في تطبيقك، ستبدو الشريحة الناتجة التي تحتوي على **OleObjectFrame** كما يلي:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**الشكل**: استبدال رسالة **تغيير الكائن** بصورة
## **الحل الثاني: إنشاء إضافة لـ MS PowerPoint**
يمكنك أيضًا محاولة إنشاء إضافة لـ MS PowerPoint، تقوم بتحديث جميع **الكائنات OLE** عند فتح العرض التقديمي في MS PowerPoint.