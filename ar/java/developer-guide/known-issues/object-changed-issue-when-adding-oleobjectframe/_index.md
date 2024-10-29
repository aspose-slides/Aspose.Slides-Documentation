---
title: مشكلة تغيير الكائن عند إضافة OleObjectFrame
type: docs
weight: 10
url: /ar/java/object-changed-issue-when-adding-oleobjectframe/
---

## **بيان المشكلة**
عندما يضيف المطورون **OleObjectFrame** إلى شرائحهم باستخدام Aspose.Slides for Java، يتم عرض رسالة **Object Changed** على الشريحة الناتجة بدلاً من **OLE Object**. يعتقد معظم عملاء Aspose.Slides for Java أنها خطأ أو عطل في Aspose.Slides for Java.
## **التحليل النقدي والتفسير**
أولاً، من المهم معرفة أن رسالة **Object Changed** التي تظهرها Aspose.Slides for Java بعد إضافة **OleObjectFrame** إلى الشريحة، هي **ليست** خطأ أو عطل في Aspose.Slides for Java. إنها مجرد معلومات أو رسالة لإخطار المستخدمين بأن الكائن قد تغير وأن الصورة يجب أن تُحدث.

على سبيل المثال، إذا أضفت **رسم بياني من Microsoft Excel** كـ **OleObjectFrame** إلى شريحتك (للمزيد من التفاصيل وقطع الكود حول إضافة **OleObjectFrame** إلى شريحتك، [انقر هنا](/slides/ar/java/adding-frame-to-the-slide/)) ثم فتحت ملف العرض التقديمي باستخدام MS PowerPoint، فإن الشريحة (حيث تم إضافة **OLE Object**) ستبدو هكذا:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**الشكل**: شريحة تعرض رسالة **Object Changed** بعد إضافة **OLE Object**

هذا ليس خطأ، وكائن OLE الخاص بك لا يزال مضافًا إلى الشريحة. إذا كنت ترغب في اختباره، فقم بـ **نقر مزدوج** على رسالة **Object Changed** أو **انقر بزر الماوس الأيمن** عليها واختر خيار **Worksheet Object -> Edit** كما هو موضح أدناه في الشكل:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**الشكل**: اختيار خيار **Edit** لتحرير **OLE Object**

بعد اختيار خيار **Edit** من القائمة المنبثقة، سترى أن **OLE Object المضمن** سيصبح مرئيًا بصيغة قابلة للتحرير كما هو موضح أدناه:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**الشكل**: **OLE Object** في صيغة قابلة للتحرير

لا يزال بإمكانك رؤية رسالة **Object Changed** على الشريحة في **اللوحة اليسرى** من MS PowerPoint التي تعرض معاينات الشرائح. بمجرد أن تنقر على **OLE Object**، سترى أن معاينة الشريحة ستتغير أيضًا وستحل رسالة **Changed Object** محلها صورة **OLE Object** كما هو موضح أدناه:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**الشكل**: تحديث صورة **OLE Object**

الآن، يجب عليك **حفظ** ملف العرض التقديمي الخاص بك باستخدام MS PowerPoint حتى يتم تحديث الصورة الخاصة بـ **OLE Object**. بمجرد حفظ تقديمك وإعادة فتحه باستخدام MS PowerPoint، سترى أنه لن تكون هناك رسالة **Object Changed**.
## **حلول إضافية**
في التحليل النقدي أعلاه، أظهرنا أن صورة **OLE Object** يمكن تحديثها عن طريق فتح ملف العرض التقديمي في MS PowerPoint ثم حفظه. ولكن، هناك حلين إضافيين للتعامل مع رسالة **Object Changed**.
## **الحل الأول: استبدال رسالة Object Changed بصورة**
إذا لم تعجبك رسالة **Object Changed**، يمكنك أيضًا استبدال تلك الرسالة بصورة خاصة بك. يمكنك إضافة أي صورة ترغب بها إلى تقديمك ثم استخدام مُعرِّف تلك الصورة المضافة لاستبدال رسالة **Object Changed**.

لتحقيق ذلك، يمكنك إضافة هذه الأسطر القليلة من الكود في تطبيقك بعد إضافة **OleObjectFrame** إلى شريحتك.
## **مثال**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

بعد إضافة السطور أعلاه في تطبيقك، ستبدو الشريحة الناتجة التي تحتوي على **OleObjectFrame** هكذا:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**الشكل**: استبدال رسالة **Object Changed** بصورة
## **الحل الثاني: إنشاء ملحق لـ MS PowerPoint**
يمكنك أيضًا محاولة إنشاء ملحق لـ MS PowerPoint، الذي يقوم بتحديث جميع **OLE objects** عند فتح العرض التقديمي في MS PowerPoint.