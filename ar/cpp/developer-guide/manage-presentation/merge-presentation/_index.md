---
title: دمج العرض التقديمي - واجهة برمجة تطبيقات PowerPoint لـ C++
linktitle: دمج العرض التقديمي
type: docs
weight: 40
url: /cpp/merge-presentation/
keywords: "دمج PowerPoint، PPTX، PPT، دمج PowerPoint، دمج العرض التقديمي، دمج العرض التقديمي، C++"
description: يشرح المقال كيفية دمج أو دمج عروض PowerPoint التقديمية باستخدام واجهة برمجة تطبيقات PowerPoint لـ C++ أو المكتبة.
---

{{% alert  title="نصيحة" color="primary" %}} 

قد ترغب في الاطلاع على تطبيق **Aspose المجاني عبر الإنترنت** [Merger app](https://products.aspose.app/slides/merger). يتيح للناس دمج عروض PowerPoint التقديمية بنفس التنسيق (PPT إلى PPT، PPTX إلى PPTX، إلخ) ودمج العروض التقديمية بأشكال مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **دمج العروض التقديمية**

عندما تقوم بدمج عرض تقديمي واحد مع آخر، فإنك في الأساس تجمع بينها في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="معلومات" color="info" %}}

يفتقر معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) إلى الوظائف التي تسمح للمستخدمين بدمج العروض التقديمية بهذه الطريقة. 

ومع ذلك، يتيح لك [**Aspose.Slides لـ C++**](https://products.aspose.com/slides/cpp/) دمج العروض التقديمية بطرق مختلفة. يمكنك دمج العروض التقديمية مع جميع الأشكال، الأنماط، النصوص، التنسيقات، التعليقات، الرسوم المتحركة، إلخ دون الحاجة للقلق بشأن فقدان الجودة أو البيانات. 

**انظر أيضًا**

[نسخ الشرائح](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **ما الذي يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 

* العروض التقديمية الكاملة. جميع الشرائح من العروض التقديمية تنتهي في عرض تقديمي واحد
* شرائح معينة. الشرائح المحددة تنتهي في عرض تقديمي واحد
* العروض التقديمية بتنسيق واحد (PPT إلى PPT، PPTX إلى PPTX، إلخ) وبتنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) مع بعضها البعض. 

{{% alert title="ملحوظة" color="warning" %}} 

بالإضافة إلى العروض التقديمية، يتيح لك Aspose.Slides دمج ملفات أخرى:

* [صور](https://products.aspose.com/slides/cpp/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* مستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* وملفات مختلفة مثل [صورة إلى PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان

* كل شريحة في العرض التقديمي الناتج تحتفظ بنمط فريد
* يتم استخدام نمط محدد لجميع الشرائح في العرض التقديمي الناتج. 

لدمج العروض التقديمية، توفر Aspose.Slides طرق [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)). هناك عدة تنفيذات لطرق `AddClone` التي تحدد معلمات عملية دمج العروض التقديمية. يحتوي كل كائن عرض تقديمي على مجموعة [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)، لذا يمكنك استدعاء طريقة `AddClone` من العرض التقديمي الذي تريد دمج الشرائح فيه. 

ترجع طريقة `AddClone` كائن `ISlide`، الذي هو نسخة من الشريحة المصدر. الشرائح في العرض التقديمي الناتج هي ببساطة نسخة من الشرائح من المصدر. لذلك، يمكنك إجراء تغييرات على الشرائح الناتجة (على سبيل المثال، تطبيق أنماط أو خيارات تنسيق أو تخطيطات) دون القلق بشأن تأثر العروض التقديمية المصدر. 

## **دمج العروض التقديمية** 

توفر Aspose.Slides طريقة [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) التي تتيح لك دمج الشرائح مع الاحتفاظ بتخطيطاتهم وأنماطهم (المعلمات الافتراضية). 

يظهر لك هذا الرمز C++ كيفية دمج العروض التقديمية:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **دمج العروض التقديمية مع شريحة الماستر**

توفر Aspose.Slides طريقة [**AddClone (ISlide، IMasterSlide، bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) التي تتيح لك دمج الشرائح مع تطبيق قالب عرض تقديمي لشريحة الماستر. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير النمط للشرائح في العرض التقديمي الناتج. 

يوضح هذا الرمز في C++ العملية الموصوفة:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="ملحوظة" color="warning" %}} 

يتم تحديد تخطيط الشريحة لشريحة الماستر تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا كانت المعلمة المنطقية `allowCloneMissingLayout` لطريقة `AddClone` مضبوطة على true، يتم استخدام التخطيط للشريحة المصدر. بخلاف ذلك، سيتم رمي [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

إذا كنت ترغب في أن تحتوي الشرائح في العرض التقديمي الناتج على تخطيط شريحة مختلف، استخدم طريقة [AddClone (ISlide، ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) بدلاً من ذلك عند الدمج. 

## **دمج شرائح معينة من العروض التقديمية**

يظهر لك هذا الرمز C++ كيفية اختيار ودمج شرائح معينة من عروض تقديمية مختلفة للحصول على عرض تقديمي واحد:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **دمج العروض التقديمية مع تخطيط الشريحة**

يظهر لك هذا الرمز C++ كيفية دمج الشرائح من العروض التقديمية مع تطبيق تخطيط الشريحة المفضل لديك عليها للحصول على عرض تقديمي واحد:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **دمج العروض التقديمية مع أحجام شرائح مختلفة**

{{% alert title="ملحوظة" color="warning" %}} 

لا يمكنك دمج العروض التقديمية بأحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عروض تقديمية اثنتين بأحجام شرائح مختلفة، يجب عليك تغيير حجم إحدى العروض التقديمية لتتناسب مع حجم الأخرى. 

يوضح الرمز المصدري هذا العملية الموصوفة:

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

## **دمج الشرائح إلى قسم العرض التقديمي**

يظهر لك هذا الرمز C++ كيفية دمج شريحة معينة إلى قسم في عرض تقديمي:

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

تتم إضافة الشريحة في نهاية القسم. 

{{% alert title="نصيحة" color="primary" %}}

تقدم Aspose تطبيق ويب [مجاني لتصميم الكولاج](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

{{% /alert %}}