---
title: إضافة مستطيلات إلى العروض التقديمية بلغة C++
linktitle: مستطيل
type: docs
weight: 80
url: /ar/cpp/rectangle/
keywords:
- إضافة مستطيل
- إنشاء مستطيل
- شكل مستطيل
- مستطيل بسيط
- مستطيل منسق
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "عزز عروض PowerPoint التقديمية الخاصة بك بإضافة مستطيلات باستخدام Aspose.Slides للغة C++ — صمم وغير الأشكال برمجيًا بسهولة."
---

## **إنشاء مستطيل بسيط**
مثل المواضيع السابقة، يتناول هذا الموضوع أيضًا إضافة شكل، وهذه المرة الشكل الذي سنناقشه هو المستطيل. في هذا الموضوع، شرحنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو مُنسقة إلى شرائحهم باستخدام Aspose.Slides للغة C++ . لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
3. إضافة IAutoShape من نوع Rectangle باستخدام الطريقة AddAutoShape التي يوفرها كائن IShapes.
4. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، أضفنا مستطيلًا بسيطًا إلى الشريحة الأولى من العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **إنشاء مستطيل مُنسق**
لإضافة مستطيل مُنسق إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
3. إضافة IAutoShape من نوع Rectangle باستخدام الطريقة AddAutoShape التي يوفرها كائن IShapes.
4. ضبط نوع التعبئة للمستطيل إلى Solid.
5. ضبط لون المستطيل باستخدام الخاصية SolidFillColor.Color المتوفرة في كائن FillFormat المرتبط بـ IShape.
6. ضبط لون خطوط المستطيل.
7. ضبط عرض خطوط المستطيل.
8. كتابة العرض التقديمي المعدل كملف PPTX.
   الخطوات السابقة مُطبقة في المثال المعروض أدناه.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **الأسئلة الشائعة**

**كيف يمكنني إضافة مستطيل بزوايا مدورة؟**

استخدم نوع الشكل [rounded-corner](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) وقم بضبط نصف قطر الزاوية في خصائص الشكل؛ ويمكن أيضًا تطبيق التقويس على كل زاوية على حدة عبر تعديل الهندسة.

**كيف يمكنني تعبئة المستطيل بصورة (نقش)؟**

اختر نوع التعبئة [picture](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)، وفر مصدر الصورة، وقم بتكوين أوضاع [stretching/tiling](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/).

**هل يمكن للمستطيل أن يحتوي على ظل وتألق؟**

نعم. الظلال الخارجية/الداخلية، والتألق، والحواف الناعمة متاحة من خلال [shape-effect](/slides/ar/cpp/shape-effect/) مع إمكانية تعديل المعلمات.

**هل يمكن تحويل المستطيل إلى زر يحتوي على ارتباط تشعبي؟**

نعم. يمكنك [assign a hyperlink](/slides/ar/cpp/manage-hyperlinks/) إلى النقر على الشكل (الانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكن حماية المستطيل من النقل والتعديل؟**

استخدم [shape locks](/slides/ar/cpp/applying-protection-to-presentation/): يمكنك منع النقل، إعادة الحجم، التحديد، أو تحرير النص للحفاظ على التخطيط.

**هل يمكن تحويل المستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [render the shape](http://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) إلى صورة بحجم/مقياس محدد أو [export it as SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) للاستخدام المتجهي.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**

[استخدم الخصائص الفعّالة للشكل](/slides/ar/cpp/shape-effective-properties/): تُعيد الواجهة البرمجية القيم المُحسوبة التي تأخذ في الاعتبار أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.