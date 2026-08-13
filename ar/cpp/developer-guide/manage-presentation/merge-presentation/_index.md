---
title: "دمج العروض التقديمية بفعالية في C++"
linktitle: "دمج العروض التقديمية"
type: docs
weight: 40
url: /ar/cpp/merge-presentation/
keywords:
- "دمج PowerPoint"
- "دمج العروض التقديمية"
- "دمج الشرائح"
- "دمج PPT"
- "دمج PPTX"
- "دمج ODP"
- "دمج PowerPoint"
- "دمج العروض التقديمية"
- "دمج الشرائح"
- "دمج PPT"
- "دمج PPTX"
- "دمج ODP"
- "C++"
- "Aspose.Slides"
description: "دمج عروض PowerPoint (PPT، PPTX) وOpenDocument (ODP) بسهولة باستخدام Aspose.Slides للغة C++، مما يُسهل سير عملك."
---
## **نظرة عامة**

تتيح لك Aspose.Slides دمج العروض التقديمية عن طريق استنساخ الشرائح من عرض تقديمي إلى آخر. يوضح هذا المقال كيفية دمج العروض بالكامل أو شرائح مختارة، واستخدام قالب شريحة رئيسية أو تخطيط معين أثناء الدمج، ومعالجة العروض ذات أحجام الشرائح المختلفة، وإضافة الشرائح المدمجة إلى قسم من العرض التقديمي. كما يغطي ملاحظات عملية متعلقة بالمحتوى المدمج، بما في ذلك ملاحظات المتحدث، التعليقات، الملفات المصدرية المحمية بكلمة مرور، واستخدام الخيوط.

## **دمج العروض التقديمية**

عند دمج عرض تقديمي مع آخر، فأنت فعليًا تجمع شرائحهما في عرض تقديمي واحد للحصول على ملف واحد.

{{% alert title="Info" color="info" %}}
معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) تفتقر إلى وظائف تسمح للمستخدمين بدمج العروض بهذه الطريقة.
[**Aspose.Slides for C++**](https://products.aspose.com/slides/ar/cpp/), ومع ذلك، يتيح لك دمج العروض بطرق مختلفة. يمكنك دمج العروض مع جميع الأشكال والأنماط والنصوص والتنسيقات والتعليقات والرسوم المتحركة، إلخ، دون القلق بشأن فقدان الجودة أو البيانات.
**انظر أيضًا**
[Clone Slides](https://docs.aspose.com/slides/ar/cpp/clone-slides/)*.*
{{% /alert %}}

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج

* العروض الكاملة. جميع الشرائح من العروض تنتهي في عرض واحد
* شرائح محددة. الشرائح المختارة تنتهي في عرض واحد
* العروض بصيغة واحدة (PPT إلى PPT، PPTX إلى PPTX، إلخ) وبصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) بعضها البعض.

{{% alert title="Note" color="warning" %}} 
إلى جانب العروض التقديمية، تسمح لك Aspose.Slides بدمج ملفات أخرى:

* [Images](https://products.aspose.com/slides/ar/cpp/merger/image-to-image/)، مثل [JPG to JPG](https://products.aspose.com/slides/ar/cpp/merger/jpg-to-jpg/) أو [PNG to PNG](https://products.aspose.com/slides/ar/cpp/merger/png-to-png/)
* مستندات، مثل [PDF to PDF](https://products.aspose.com/slides/ar/cpp/merger/pdf-to-pdf/) أو [HTML to HTML](https://products.aspose.com/slides/ar/cpp/merger/html-to-html/)
* وملفّين مختلفين مثل [image to PDF](https://products.aspose.com/slides/ar/cpp/merger/image-to-pdf/) أو [JPG to PDF](https://products.aspose.com/slides/ar/cpp/merger/jpg-to-pdf/) أو [TIFF to PDF](https://products.aspose.com/slides/ar/cpp/merger/tiff-to-pdf/).
{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان

* كل شريحة في العرض الناتج تحتفظ بنمط فريد
* يُستخدم نمط محدد لجميع الشرائح في العرض الناتج.

لدمج العروض، توفر Aspose.Slides طرق [AddClone](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_slide_collection)). هناك عدة تنفيذات لطرق `AddClone` تحدد معلمات عملية دمج العرض. كل كائن Presentation يحتوي على مجموعة [Slides](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)، لذا يمكنك استدعاء طريقة `AddClone` من العرض الذي تريد دمج الشرائح إليه.

طريقة `AddClone` تُعيد كائن `ISlide`، وهو نسخة مستنسخة من الشريحة المصدر. الشرائح في العرض الناتج هي ببساطة نسخة من الشرائح في المصدر. لذلك يمكنك تعديل الشرائح الناتجة (مثلاً تطبيق أنماط أو خيارات تنسيق أو تخطيطات) دون القلق من تأثير ذلك على العروض المصدرية.

## **دمج العروض**

توفر Aspose.Slides طريقة [**AddClone (ISlide)**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) التي تسمح لك بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها (المعلمات الافتراضية).

هذا الكود C++ يوضح لك كيفية دمج العروض:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **دمج العروض باستخدام قالب شريحة رئيسية**

توفر Aspose.Slides طريقة [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) التي تسمح لك بدمج الشرائح مع تطبيق قالب شريحة رئيسية. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير النمط للشرائح في العرض الناتج.

هذا الكود C++ يوضح العملية الموضحة:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
يتم تحديد تخطيط الشريحة للماستر تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم ضبط معامل `allowCloneMissingLayout` البولياني لطريقة `AddClone` على true، يُستخدم تخطيط الشريحة المصدر. وإلا سيُطرح استثناء [PptxEditException](https://reference.aspose.com/slides/ar/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).
{{% /alert %}}

إذا أردت أن يكون للشرائح في العرض الناتج تخطيط مختلف، استخدم طريقة [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) بدلاً من ذلك عند الدمج.

## **دمج شرائح محددة من العروض**

دمج شرائح محددة من عدة عروض مفيد لإنشاء مجموعة شرائح مخصصة. يتيح لك Aspose.Slides C++ اختيار استيراد الشرائح التي تحتاجها فقط. يحافظ API على التنسيق والتخطيط وتصميم الشرائح الأصلية.

الكود C++ التالي ينشئ عرضًا جديدًا، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة إلى ملف:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// مُعلن في الكود أعلاه.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **دمج العروض باستخدام تخطيط شريحة**

هذا الكود C++ يوضح لك كيفية دمج الشرائح من العروض مع تطبيق تخطيط شريحة مفضل للحصول على عرض إخراج واحد:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **دمج العروض بأحجام شرائح مختلفة**

{{% alert title="Note" color="warning" %}} 
لا يمكنك دمج العروض بأحجام شرائح مختلفة.
{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، عليك تعديل حجم أحد العروض ليتطابق مع حجم العرض الآخر.

هذا مثال الكود يوضح العملية الموضحة:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **دمج شرائح إلى قسم من العرض**

هذا الكود C++ يوضح لك كيفية دمج شريحة محددة إلى قسم في عرض تقديمي:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

يُضاف الشريحة في نهاية القسم.

{{% alert title="Tip" color="info" %}}
توفر Aspose تطبيق ويب مجاني لتجميع الصور [FREE Collage web app](https://products.aspose.app/slides/ar/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG to JPG](https://products.aspose.app/slides/ar/collage/jpg) أو PNG إلى PNG، إنشاء [شبكات صور](https://products.aspose.app/slides/ar/collage/photo-grid)، وما إلى ذلك.
{{% /alert %}}

## **الأسئلة المتداولة**

### هل يتم حفظ ملاحظات المتحدث أثناء الدمج؟

نعم. عند استنساخ الشرائح، تنقل Aspose.Slides جميع عناصر الشريحة بما في ذلك الملاحظات والتنسيق والرسوم المتحركة.

### هل يتم نقل التعليقات ومؤلفيها؟

التعليقات، كجزء من محتوى الشريحة، تُنسخ مع الشريحة. تُحافظ تسميات مؤلف التعليق ككائنات تعليق في العرض الناتج.

### ماذا يحدث إذا كان العرض المصدر محميًا بكلمة مرور؟

يجب [فتح العرض باستخدام كلمة المرور](/slides/ar/cpp/password-protected-presentation/) عبر [LoadOptions::set_Password](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_password/)؛ بعد التحميل، يمكن استنساخ تلك الشرائح بأمان إلى ملف هدف غير محمي (أو محمي أيضًا).

### ما مدى أمان الخيط للعملية الدمج؟

لا تستخدم نفس كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/cpp/multithreading/). القاعدة الموصى بها هي "مستند واحد — خيط واحد"؛ يمكن معالجة ملفات مختلفة بالتوازي في خيوط منفصلة.