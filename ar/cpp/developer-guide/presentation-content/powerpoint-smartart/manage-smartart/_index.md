---
title: إدارة SmartArt
type: docs
weight: 10
url: /ar/cpp/manage-smartart/
---

## **الحصول على نص من SmartArt**
تمت إضافة خاصية TextFrame إلى واجهة ISmartArtShape وفئة SmartArtShape على التوالي. هذه الخاصية تتيح لك الحصول على جميع النصوص من SmartArt إذا لم يكن لديها نصوص العقد فقط. الكود المثال التالي سيساعدك على الحصول على النص من عقدة SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **تغيير نوع التخطيط لأي SmartArt**
لتغيير نوع التخطيط لـ SmartArt. يرجى اتباع الخطوات أدناه:

- أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- احصل على مرجع لشريحة باستخدام مؤشرها.
- أضف SmartArt BasicBlockList.
- غيّر LayoutType إلى BasicProcess.
- احفظ العرض التقديمي كملف PPTX.
  في المثال المعطى أدناه، أضفنا موصلًا بين شكلين.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **تحقق من خاصية الإخفاء لـ SmartArt**
يرجى ملاحظة أن الطريقة com.aspose.slides.ISmartArtNode.isHidden() ترجع true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. للتحقق من خاصية الإخفاء لأي عقدة من SmartArt. يرجى اتباع الخطوات أدناه:

- أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- أضف SmartArt RadialCycle.
- أضف عقدة على SmartArt.
- تحقق من خاصية isHidden.
- احفظ العرض التقديمي كملف PPTX.

في المثال المعطى أدناه، أضفنا موصلًا بين شكلين.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **الحصول على نوع مخطط التنظيم أو تعيينه**
تسمح الطرق com.aspose.slides.ISmartArtNode.getOrganizationChartLayout()، setOrganizationChartLayout(int) بالحصول على نوع مخطط التنظيم أو تعيينه المرتبط بالعقدة الحالية. للحصول على نوع مخطط التنظيم أو تعيينه. يرجى اتباع الخطوات أدناه:

- أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- أضف SmartArt على الشريحة.
- احصل على نوع مخطط التنظيم أو عيّنه.
- احفظ العرض التقديمي كملف PPTX.
  في المثال المعطى أدناه، أضفنا موصلًا بين شكلين.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **الحصول على حالة SmartArt أو تعيينها**
بعض مخططات SmartArt لا تدعم الانعكاس، على سبيل المثال؛ قائمة رموز نقطية عمودية، عملية عمودية، عملية تنازلية، قمع، تروس، توازن، علاقة دائرية، مجموعة سداسية، قائمة عكسية، فين مكدس. لتغيير اتجاه SmartArt. يرجى اتباع الخطوات أدناه:

- أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- أضف SmartArt على الشريحة.
- احصل على حالة مخطط SmartArt أو عيّنها.
- احفظ العرض التقديمي كملف PPTX.
  في المثال المعطى أدناه، أضفنا موصلًا بين شكلين.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **إنشاء مخطط تنظيم الصورة**
توفر Aspose.Slides لـ C++ واجهة برمجة تطبيقات بسيطة لإنشاء مخططات وصور تنظيمية بطريقة سهلة. لإنشاء مخطط على شريحة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. احصل على مرجع الشريحة باستخدام مؤشرها.
1. أضف مخططًا مع بيانات افتراضية إلى جانب النوع المطلوب (ChartType.PictureOrganizationChart).
1. احفظ العرض التقديمي المعدل إلى ملف PPTX.

الكود التالي يستخدم لإنشاء مخطط.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```