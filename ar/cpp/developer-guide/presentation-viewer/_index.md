---
title: عارض العرض التقديمي
type: docs
weight: 50
url: /cpp/presentation-viewer/
keywords: 
- عرض عرض PowerPoint
- عرض ppt
- عرض PPTX
- C++
- Aspose.Slides لـ C++
description: "عرض عرض PowerPoint في C++"
---

## **إنشاء صورة SVG من الشريحة**
تُستخدم Aspose.Slides لـ C++ لإنشاء ملفات العروض التقديمية، كاملةً مع الشرائح. يمكن عرض هذه الشرائح عن طريق فتح العروض التقديمية باستخدام Microsoft PowerPoint. ولكن أحيانًا، قد يحتاج المطورون أيضًا إلى عرض الشرائح كصور SVG في عارض الصور المفضل لديهم. في هذه الحالة، تتيح لك Aspose.Slides لـ C++ تصدير شريحة فردية إلى صورة SVG. تصف هذه المقالة كيفية استخدام هذه الميزة. لإنشاء صورة SVG من أي شريحة مرغوبة باستخدام Aspose.Slides.Pptx لـ C++، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- الحصول على مرجع الشريحة المرغوبة باستخدام ID أو الفهرس الخاص بها.
- الحصول على صورة SVG في دفق الذاكرة.
- حفظ دفق الذاكرة كملف.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSlidesSVGImage-CreateSlidesSVGImage.cpp" >}}
## **إنشاء SVG مع معرفات أشكال مخصصة**
الآن يمكن استخدام Aspose.Slides لـ C++ لإنشاء SVG من الشريحة مع معرف شكل مخصص. يمكن عرض هذه الشرائح عن طريق فتح العروض التقديمية باستخدام Microsoft PowerPoint. ولكن أحيانًا، قد يحتاج المطورون أيضًا إلى عرض الشرائح كصور SVG في عارض الصور المفضل لديهم. في هذه الحالة، تتيح لك Aspose.Slides لـ C++ تصدير شريحة فردية إلى صورة SVG. لهذه الغاية تم إضافة خاصية ID إلى ISvgShape لدعم التعريفات المخصصة للأشكال في SVG المولدة. لتنفيذ هذه الميزة، تم تقديم CustomSvgShapeFormattingController الذي يمكنك استخدامه لتحديد معرف الشكل.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GeneratingSVGWithCustomShapeIDS-GeneratingSVGWithCustomShapeIDS.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomSvgShapeFormattingController-CustomSvgShapeFormattingController.cpp" >}}


## **إنشاء صورة مصغرة من الشريحة**
تُستخدم Aspose.Slides لـ C++ لإنشاء ملفات العروض التقديمية التي تحتوي على الشرائح. يمكن عرض هذه الشرائح عن طريق فتح ملفات العروض التقديمية باستخدام Microsoft PowerPoint. ولكن أحيانًا، قد يحتاج المطورون إلى عرض الشرائح كصور باستخدام عارض الصور المفضل لديهم. في هذه الحالة، تساعدك Aspose.Slides لـ C++ على إنشاء صور مصغرة للشرائح. لإنشاء الصورة المصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides لـ C++:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الحصول على مرجع أي شريحة مرغوبة باستخدام ID أو الفهرس الخاص بها.
3. الحصول على الصورة المصغرة للشريحة المرجعية على مقياس محدد.
4. حفظ الصورة المصغرة في أي تنسيق صورة مرغوب.

```cpp
// إنشاء مثيل من فئة Presentation
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlide.pptx");

// الوصول إلى الشريحة الأولى
auto slide = presentation->get_Slide(0);

// إنشاء صورة ذات مقياس كامل
auto image = slide->GetImage(1, 1);
image->Save(u"Thumbnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **إنشاء صورة مصغرة بأبعاد محددة من قبل المستخدم**
1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الحصول على مرجع أي شريحة مرغوبة باستخدام ID أو الفهرس الخاص بها.
3. الحصول على الصورة المصغرة للشريحة المرجعية على مقياس محدد.
4. حفظ الصورة المصغرة في أي تنسيق صورة مرغوب.

```cpp
// إنشاء مثيل من فئة Presentation
auto presentation = MakeObject<Presentation>(u"ThumbnailWithUserDefinedDimensions.pptx");

// الوصول إلى الشريحة الأولى
auto slide = presentation->get_Slide(0);

// الأبعاد المحددة من قبل المستخدم
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// الحصول على قيم X و Y المقاسه
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// إنشاء صورة بمقياس مخصص
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Thumbnail2_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **إنشاء صورة مصغرة من الشريحة في عرض ملاحظات الشرائح**
لإنشاء صورة مصغرة من أي شريحة مرغوبة في عرض ملاحظات الشرائح باستخدام Aspose.Slides لـ C++:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الحصول على مرجع أي شريحة مرغوبة باستخدام ID أو الفهرس الخاص بها.
3. الحصول على الصورة المصغرة للشريحة المرجعية على مقياس محدد في عرض ملاحظات الشرائح.
4. حفظ الصورة المصغرة في أي تنسيق صورة مرغوب.

يُنتج مقتطف الكود أدناه صورة مصغرة من الشريحة الأولى من عرض تقديمي في عرض ملاحظات الشرائح.

```cpp
// إنشاء مثيل من فئة Presentation
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlideInNotes.pptx");

// الوصول إلى الشريحة الأولى
auto slide = presentation->get_Slide(0);

// الأبعاد المحددة من قبل المستخدم
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// الحصول على قيم X و Y المقاسه
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// إنشاء صورة ذات مقياس كامل
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Notes_tnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```