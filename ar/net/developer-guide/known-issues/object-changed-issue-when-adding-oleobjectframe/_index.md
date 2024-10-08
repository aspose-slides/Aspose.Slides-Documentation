---
title: مشكلة تغيير الكائن عند إضافة OleObjectFrame
type: docs
weight: 10
url: /ar/net/object-changed-issue-when-adding-oleobjectframe/
---

{{% alert color="primary" %}} 

باستخدام Aspose.Slides لـ .NET، عندما تضيف **[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)** إلى شريحة، تظهر رسالة **Object Changed** على الشريحة الناتجة (وليس على كائن OLE). العملية الموضحة هي إجراء متعمد وليس خطأ.

لمزيد من المعلومات حول العمل مع كائنات OLE، انظر [إدارة OLE](/slides/ar/net/manage-ole/).

{{% /alert %}} 
## **الشرح** والحل
تظهر Aspose.Slides رسالة **Object Changed** لإعلامك بأنه تم تغيير كائن OLE وأن صورة المعاينة يجب أن يتم تحديثها.

على سبيل المثال، إذا قمت بإضافة رسم بياني من Microsoft Excel كـ **[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)** إلى شريحة (لمزيد من التفاصيل، انظر مقال إدارة OLE) ثم قمت بفتح العرض التقديمي في تطبيق Microsoft PowerPoint، سترى هذه الصورة على الشريحة:

~~استبدال جميع الصور بصور جديدة~~

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

إذا كنت تريد التحقق من تأكيد أنه تم إضافة كائن OLE الخاص بك إلى الشريحة، عليك النقر المزدوج على رسالة **Object Changed**، أو يمكنك النقر بزر الماوس الأيمن عليها والذهاب عبر **كائن ورقة العمل > خيار تحرير.**

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

ثم يقوم PowerPoint بفتح كائن OLE المدمج

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

قد تحتفظ الشريحة برسالة **Object Changed**. بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة ويتم استبدال رسالة **Object Changed** بالصورة الفعلية لكائن OLE.

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

الآن، قد ترغب في حفظ العرض التقديمي الخاص بك لضمان تحديث الصورة لكائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، عند فتح العرض التقديمي مرة أخرى، لن ترى رسالة **Object Changed**.

## **حلول أخرى**
### **الحل 1: استبدال رسالة Object Changed بصورة**

إذا كنت لا تريد إزالة رسالة **Object Changed** بفتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة المفضلة لديك. توضح هذه الأسطر من التعليمات البرمجية العملية:

``` csharp 
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
   ISlide slide = pres.Slides[0];
   IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    
   IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("my_image.png"));
   oleObjectFrame.SubstitutePictureTitle = "My title";
   oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
   oleObjectFrame.IsObjectIcon = false;
    
   pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

الشريحة التي تحتوي على `OleObjectFrame` تتغير بعد ذلك إلى هذا:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

### **الحل 2: إنشاء إضافة لـ PowerPoint**
يمكنك أيضًا إنشاء إضافة لـ Microsoft PowerPoint تقوم بتحديث جميع كائنات OLE عند فتح العروض التقديمية في البرنامج.