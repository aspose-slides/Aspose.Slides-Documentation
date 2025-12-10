---
title: إدارة SmartArt في عروض PowerPoint باستخدام C++
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/cpp/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- خاصية الإخفاء
- مخطط المنظمة
- مخطط تنظيم الصورة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إنشاء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides لـ C++ مع أمثلة شفرة واضحة تسرّع تصميم الشرائح والأتمتة."
---

## **الحصول على نص من كائن SmartArt**
تم الآن إضافة خاصية TextFrame إلى واجهة ISmartArtShape وفئة SmartArtShape على التوالي. تتيح لك هذه الخاصية الحصول على كل النص من SmartArt إذا لم يكن يحتوي فقط على نص العقد. سيساعدك شفرة العينة التالية في الحصول على النص من عقدة SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **تغيير نوع التخطيط لكائن SmartArt**
لتغيير نوع التخطيط لـ SmartArt. يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة SmartArt BasicBlockList.
- تغيير LayoutType إلى BasicProcess.
- حفظ العرض التقديمي كملف PPTX.
في المثال أدناه، أضفنا موصلاً بين شكلين.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **التحقق من خاصية الإخفاء لكائن SmartArt**
يرجى ملاحظة أن الطريقة com.aspose.slides.ISmartArtNode.isHidden() تُعيد true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. للتحقق من خاصية الإخفاء لأي عقدة في SmartArt. يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- إضافة SmartArt RadialCycle.
- إضافة عقدة إلى SmartArt.
- التحقق من خاصية isHidden.
- حفظ العرض التقديمي كملف PPTX.
في المثال أدناه، أضفنا موصلاً بين شكلين.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **الحصول على أو تعيين نوع مخطط المنظمة**
تسمح الطرق com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() و setOrganizationChartLayout(int) بالحصول على أو تعيين نوع مخطط المنظمة المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع مخطط المنظمة. يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- إضافة SmartArt إلى الشريحة.
- الحصول على أو تعيين نوع مخطط المنظمة.
- حفظ العرض التقديمي كملف PPTX.
في المثال أدناه، أضفنا موصلاً بين شكلين.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **الحصول على أو تعيين حالة SmartArt**
بعض مخططات SmartArt لا تدعم العكس، على سبيل المثال: قائمة نقطية عمودية، عملية عمودية، عملية هابطة، قمع، تروس، توازن، علاقة دائرة، مجموعة سداسية، قائمة عكسية، فين مكدس. لتغيير اتجاه SmartArt. يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- إضافة SmartArt إلى الشريحة.
- الحصول على أو تعيين حالة مخطط SmartArt.
- حفظ العرض التقديمي كملف PPTX.
في المثال أدناه، أضفنا موصلاً بين شكلين.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **إنشاء مخطط منظمة صورة**
توفر Aspose.Slides لـ C++ واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بطريقة سهلة. لإنشاء مخطط على شريحة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. الحصول على مرجع الشريحة بواسطة الفهرس الخاص بها.
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
1. حفظ العرض التقديمي المعدل إلى ملف PPTX

يتم استخدام الشفرة التالية لإنشاء المخطط.
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```


## **الأسئلة المتكررة**

**هل يدعم SmartArt المرآة/العكس للغات RTL؟**

نعم. طريقة [set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) تغير اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المحدد يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/cpp/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/)) أو [استنساخ الشريحة بأكملها](/slides/ar/cpp/clone-slides/) التي تحتوي على هذا الشكل. كلا النهجين يحافظان على الحجم والموضع والنمط.

**كيف أقوم بتحويل SmartArt إلى صورة نقطية للمعاينة أو للتصدير إلى الويب؟**

[قم بتحويل الشريحة](/slides/ar/cpp/convert-powerpoint-to-png/) (أو العرض التقديمي بأكمله) إلى PNG/JPEG عبر واجهة برمجة التطبيقات التي تحول الشرائح/العروض إلى صور — سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجيًا تحديد SmartArt محدد على شريحة إذا كان هناك عدة؟**

ممارسة شائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) والبحث عن الشكل باستخدام هذه السمة داخل [أشكال الشريحة](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/)، ثم التحقق من النوع للتأكد من أنه [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/). توضح الوثائق تقنيات شائعة للعثور على الأشكال والعمل معها.