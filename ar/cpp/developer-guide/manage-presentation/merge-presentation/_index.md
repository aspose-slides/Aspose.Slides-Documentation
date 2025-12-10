---
title: دمج العروض التقديمية بكفاءة في C++
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/cpp/merge-presentation/
keywords:
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- C++
- Aspose.Slides
description: "دمج شرائح PowerPoint (PPT, PPTX) وعروض OpenDocument (ODP) بسهولة باستخدام Aspose.Slides للـ C++، مما يبسط سير العمل الخاص بك."
---

{{% alert  title="Tip" color="primary" %}} 

قد ترغب في تجربة **Aspose المجانية عبر الإنترنت**[تطبيق دمج](https://products.aspose.app/slides/merger). يتيح للمستخدمين دمج عروض PowerPoint بنفس الصيغة (PPT إلى PPT، PPTX إلى PPTX، إلخ) ودمج العروض بصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **دمج العروض التقديمية**

عند دمج عرض تقديمي مع آخر، تقوم فعليًا بدمج شرائحه في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="Info" color="info" %}}

معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) تفتقر إلى وظائف تسمح للمستخدمين بدمج العروض بهذه الطريقة. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) ، مع ذلك، يتيح لك دمج العروض بطرق مختلفة. يمكنك دمج العروض مع جميع الأشكال والأنماط والنصوص والتنسيقات والتعليقات والرسوم المتحركة، وما إلى ذلك دون القلق بشأن فقدان الجودة أو البيانات. 

**انظر أيضًا**

[استنساخ الشرائح](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **ما الذي يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 
* العروض الكاملة. جميع الشرائح من العروض تنتهي في عرض تقديمي واحد
* شرائح محددة. الشرائح المختارة تنتهي في عرض تقديمي واحد
* العروض بصيغة واحدة (PPT إلى PPT، PPTX إلى PPTX، إلخ) وبصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) إلى بعضها البعض. 

{{% alert title="Note" color="warning" %}} 

إلى جانب العروض، يتيح لك Aspose.Slides دمج ملفات أخرى:

* [الصور](https://products.aspose.com/slides/cpp/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* المستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* وملفين مختلفين مثل [صورة إلى PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذاً

* كل شريحة في العرض الناتج تحتفظ بنمط فريد
* يتم استخدام نمط محدد لجميع الشرائح في العرض الناتج. 

لدمج العروض، يوفر Aspose.Slides طرقًا [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)). هناك عدة تنفيذات لطرق `AddClone` تُعرّف معلمات عملية دمج العروض. كل كائن Presentation يحتوي على مجموعة [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)، لذا يمكنك استدعاء طريقة `AddClone` من العرض الذي تريد دمج الشرائح إليه. 

تعيد طريقة `AddClone` كائن `ISlide`، وهو نسخة مستنسخة من الشريحة المصدر. الشرائح في العرض الناتج هي ببساطة نسخة من الشرائح في المصدر. لذلك يمكنك إجراء تغييرات على الشرائح الناتجة (مثل تطبيق الأنماط أو خيارات التنسيق أو التخطيطات) دون القلق من تأثير ذلك على العروض المصدر. 

## **دمج العروض التقديمية** 

يوفر Aspose.Slides طريقة [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) التي تسمح لك بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها (المعلمات الافتراضية). 

هذا الكود C++ يوضح لك كيفية دمج العروض:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **دمج العروض التقديمية مع شريحة رئيسية** 

يوفر Aspose.Slides طريقة [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) التي تسمح لك بدمج الشرائح مع تطبيق نموذج شريحة رئيسية للعرض. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير النمط للشرائح في العرض الناتج. 

هذا الكود C++ يوضح العملية الموصوفة:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

يتم تحديد تخطيط شريحة الماستر تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم ضبط معامل `allowCloneMissingLayout` المنطقي لطريقة `AddClone` على true، يُستخدم تخطيط الشريحة المصدر. وإلا، سيتم رفع استثناء [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

إذا كنت تريد أن تكون للشرائح في العرض الناتج تخطيط شريحة مختلف، استخدم طريقة [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) بدلاً من ذلك عند الدمج. 

## **دمج شرائح محددة من العروض التقديمية** 

دمج شرائح محددة من عروض متعددة مفيد لإنشاء مجموعات شرائح مخصصة. يتيح لك Aspose.Slides C++ اختيار واستيراد الشرائح التي تحتاجها فقط. تحافظ الواجهة البرمجية على تنسيق وتخطيط وتصميم الشرائح الأصلية. 

الكود C++ التالي ينشئ عرضًا تقديميًا جديدًا، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة في ملف:
```cpp
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


## **دمج العروض التقديمية مع تخطيط شريحة** 

هذا الكود C++ يوضح لك كيفية دمج الشرائح من العروض مع تطبيق تخطيط شريحة مفضل لديك للحصول على عرض تقديمي واحد ناتج:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **دمج العروض التقديمية بأحجام شرائح مختلفة** 

{{% alert title="Note" color="warning" %}} 

لا يمكنك دمج عروض تقديمية بأحجام شرائح مختلفة. 

{{% /alert %}} 

لدمج عرضين بحجم شرائح مختلف، عليك تغيير حجم أحد العروض لجعل حجمه يطابق حجم العرض الآخر. 

هذا الكود النموذجي يوضح العملية الموصوفة:
```cpp
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


## **دمج شرائح إلى قسم في العرض التقديمي** 

هذا الكود C++ يوضح لك كيفية دمج شريحة محددة إلى قسم في عرض تقديمي:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


يتم إضافة الشريحة في نهاية القسم. 

{{% alert title="Tip" color="primary" %}}

توفر Aspose تطبيق ويب مجاني لتجميع الصور [FREE Collage web app](https://products.aspose.app/slides/collage). يمكنك من خلال هذه الخدمة عبر الإنترنت دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

{{% /alert %}}

## **الأسئلة الشائعة** 

**هل يتم الحفاظ على ملاحظات المتحدث أثناء الدمج؟**  

نعم. عند استنساخ الشرائح، تنقل Aspose.Slides جميع عناصر الشريحة بما في ذلك الملاحظات والتنسيقات والرسوم المتحركة. 

**هل يتم نقل التعليقات ومؤلفيها؟**  

التعليقات، كجزء من محتوى الشريحة، تُنسخ مع الشريحة. تُحافظ تسميات مؤلفي التعليقات ككائنات تعليقات في العرض الناتج. 

**ماذا لو كان العرض المصدر محميًا بكلمة مرور؟**  

يجب أن يتم [تم فتحه باستخدام كلمة المرور](/slides/ar/cpp/password-protected-presentation/) عبر [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/)؛ بعد التحميل، يمكن استنساخ تلك الشرائح بأمان إلى ملف هدف غير محمي (أو محمي أيضًا). 

**ما مدى أمان الخيط للدمج؟**  

لا تقم Using نفس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) من [multiple threads](/slides/ar/cpp/multithreading/). القاعدة الموصى بها هي "وثيقة واحدة — خيط واحد"؛ يمكن معالجة ملفات مختلفة بالتوازي في خيوط منفصلة.