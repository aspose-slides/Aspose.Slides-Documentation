---
title: سلايد ماستر
type: docs
weight: 80
url: /cpp/slide-master/
keywords: "إضافة سلايد ماستر، شريحة ماستر PPT، سلايد ماستر باوربوينت، صورة إلى سلايد ماستر، عنصر نائب، عدة سلايد ماستر، مقارنة سلايد ماستر، C++، CPP، Aspose.Slides لـ C++"
description: "إضافة أو تحرير سلايد ماستر في عرض باوربوينت باستخدام C++"
---

## **ما هو سلايد ماستر في باوربوينت**

سلايد ماستر هو نموذج شريحة يحدد تخطيطها وأنماطها وثيمها وخطوطها وخلفيتها وخصائص أخرى للشرائح في العرض. إذا كنت ترغب في إنشاء عرض (أو سلسلة من العروض) بنفس النمط والقالب لشركتك، يمكنك استخدام سلايد ماستر.

يعتبر سلايد ماستر مفيدًا لأنه يتيح لك ضبط وتغيير مظهر جميع الشرائح في العرض مرة واحدة. يدعم Aspose.Slides آلية سلايد ماستر من باوربوينت.

تسمح لك VBA أيضًا بالتلاعب بسلايد ماستر وتنفيذ نفس العمليات المدعومة في باوربوينت: تغيير الخلفيات، إضافة الأشكال، تخصيص التخطيط، وما إلى ذلك. يوفر Aspose.Slides آليات مرنة تسمح لك باستخدام سلايد ماستر وأداء المهام الأساسية معها.

هذه هي العمليات الأساسية لسلايد ماستر:

- إنشاء أو تعديل سلايد ماستر.
- تطبيق سلايد ماستر على شرائح العرض.
- تغيير خلفية سلايد ماستر.
- إضافة صورة، عنصر نائب، فن ذكي، إلخ. إلى سلايد ماستر.

هذه هي العمليات الأكثر تقدمًا المتعلقة بسلايد ماستر:

- مقارنة سلايد ماستر.
- دمج سلايد ماستر.
- تطبيق عدة سلايد ماستر.
- نسخ الشريحة مع سلايد ماستر إلى عرض تقديمي آخر.
- اكتشاف سلايد ماستر المكررة في العروض.
- تعيين سلايد ماستر كعرض افتراضي للعرض.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على مشاهد Aspose [**عبر الإنترنت**](https://products.aspose.app/slides/viewer) لأنه تنفيذ حي لبعض العمليات الأساسية الموضحة هنا.

{{% /alert %}} 

## **كيف يتم تطبيق سلايد ماستر**

قبل أن تعمل مع سلايد ماستر، قد ترغب في فهم كيفية استخدامها في العروض وتطبيقها على الشرائح.

* يحتوي كل عرض افتراضيًا على سلايد ماستر واحد على الأقل.
* يمكن أن يحتوي العرض على عدة سلايد ماستر. يمكنك إضافة عدة سلايد ماستر واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة.

في **Aspose.Slides**، يتم تمثيل سلايد ماستر بواسطة [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) نوع.

تحتوي كائن [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) في Aspose.Slides على قائمة [**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) من نوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) ، والتي تحتوي على قائمة بجميع الشرائح الرئيسية المحددة في العرض.

بالإضافة إلى عمليات CRUD، يحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) على هذه الطرق المفيدة: [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) و [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311) . يتم وراثة تلك الطرق من وظيفة استنساخ الشريحة الأساسية. ولكن عند التعامل مع سلايد ماستر، تتيح لك تلك الطرق تنفيذ إعدادات معقدة.

عندما تتم إضافة شريحة جديدة إلى العرض، يتم تطبيق سلايد ماستر عليها تلقائيًا. يتم اختيار سلايد ماستر للشريحة السابقة بشكل افتراضي.

**ملاحظة**: يتم تخزين شرائح العرض في قائمة [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) ، ويتم إضافة كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض يحتوي على سلايد ماستر واحد فقط، فإن ذلك السلايد ماستر يتم اختياره لجميع الشرائح الجديدة. هذه هي السبب في أنك لا تحتاج إلى تعريف سلايد ماستر لكل شريحة جديدة تقوم بإنشائها.

المبدأ هو نفسه في باوربوينت وAspose.Slides. على سبيل المثال، في باوربوينت، عندما تضيف عرضًا جديدًا، يمكنك فقط الضغط على الخط السفلي تحت آخر شريحة ثم سيتم إنشاء شريحة جديدة (مع سلايد ماستر للعرض الأخير):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك أداء المهمة المكافئة باستخدام [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) الطريقة تحت فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

## **سلايد ماستر في تسلسل الشرائح**

استخدام تخطيطات الشرائح مع سلايد ماستر يسمح بأقصى قدر من المرونة. يسمح لك تخطيط الشريحة بتعيين جميع الأنماط نفسها مثل سلايد ماستر (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عند الجمع بين عدة تخطيطات شرائح على سلايد ماستر، يتم إنشاء نمط جديد. عند تطبيق تخطيط شريحة على شريحة واحدة، يمكنك تغيير نمطها عن النمط المعتمد من قبل سلايد ماستر.

يتفوق سلايد ماستر على جميع العناصر المثبتة: سلايد ماستر -> تخطيط شريحة -> شريحة:

![todo:image_alt_text](slide-master_2)

كل كائن [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) يحتوي على خاصية [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) مع قائمة من تخطيطات الشرائح. تحتوي نوع [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) على خاصية [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) مع ارتباط إلى تخطيط الشريحة المعتمد على الشريحة. يحدث التفاعل بين الشريحة وسلايد ماستر من خلال تخطيط الشريحة.

{{% alert color="info" title="ملاحظة" %}}

* في Aspose.Slides، يتم تنفيذ جميع إعدادات الشرائح (سلايد ماستر، وتخطيط الشريحة، والشريحة نفسها) ككائنات شرائح تنفذ واجهة [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide).
* لذلك، قد تنفذ سلايد ماستر وتخطيط الشريحة نفس الخصائص، وتحتاج إلى معرفة كيف سيتم تطبيق قيمها على كائن [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) . يتم تطبيق سلايد ماستر أولاً على الشريحة ثم يتم تطبيق تخطيط الشريحة. على سبيل المثال، إذا كان لدى سلايد ماستر وتخطيط الشريحة كلاهما قيمة خلفية، ستنتهي الشريحة بالخلفية من تخطيط الشريحة.

{{% /alert %}}

## **ماذا يحتوي سلايد ماستر**

لفهم كيف يمكن تغيير سلايد ماستر، تحتاج إلى معرفة مكوناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) .

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - الحصول على/تعيين خلفية الشريحة.
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - الحصول على/تعيين أنماط النص لجسم الشريحة.
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - الحصول على/تعيين جميع أشكال سلايد ماستر (عناصر نائب، إطارات صور، إلخ).
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - الحصول على/تعيين عناصر التحكم ActiveX.
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - الحصول على مدير الثيمات.
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - الحصول على مدير الرأس والتذييل.

طرق سلايد ماستر:

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - الحصول على جميع الشرائح المعتمدة على سلايد ماستر.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - يتيح لك إنشاء سلايد ماستر جديدة بناءً على سلايد ماستر الحالية وثيم جديدة. سيتم تطبيق سلايد ماستر الجديدة على جميع الشرائح المعتمدة.

## **الحصول على سلايد ماستر**

في باوربوينت، يمكن الوصول إلى سلايد ماستر من قائمة العرض -> سلايد ماستر:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى سلايد ماستر بهذه الطريقة:

```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```

تمثل واجهة [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) سلايد ماستر. تحتوي خاصية [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) (المتعلقة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)) على قائمة بجميع سلايد ماستر التي تم تعريفها في العرض.

## **إضافة صورة إلى سلايد ماستر**

عند إضافة صورة إلى سلايد ماستر، ستظهر تلك الصورة على جميع الشرائح المعتمدة على سلايد ماستر تلك.

على سبيل المثال، يمكنك وضع شعار شركتك وبعض الصور على سلايد ماستر ثم العودة إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى سلايد ماستر باستخدام Aspose.Slides:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" title="انظر أيضًا" %}} 

لمزيد من المعلومات حول إضافة الصور إلى الشريحة، انظر المقالة [إطار الصورة](/slides/cpp/picture-frame/#create-picture-frame).
{{% /alert %}}

## **إضافة عنصر نائب إلى سلايد ماستر**

هذه الحقول النصية هي عناصر نائب قياسية على سلايد ماستر:

* انقر لتحرير نمط عنوان السلايد

* تحرير أنماط نص السلايد

* المستوى الثاني

* المستوى الثالث 

تظهر أيضًا على الشرائح بناءً على سلايد ماستر. يمكنك تحرير تلك العناصر النائبة على سلايد ماستر وسيتم تطبيق التغييرات تلقائيًا على الشرائح.

في باوربوينت، يمكنك إضافة عنصر نائب من خلال مسار سلايد ماستر -> إدراج عنصر نائب:

![todo:image_alt_text](slide-master_5.png)

دعنا نفحص مثالًا أكثر تعقيدًا لعناصر نائب باستخدام Aspose.Slides. اعتبر شريحة تحتوي على عناصر نائب مُعدة من سلايد ماستر:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على سلايد ماستر بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر نائب العنوان من كائن سلايد ماستر ثم نستخدم حقل `PlaceHolder.FillFormat`:

```c++
System::SharedPtr<IAutoShape> FindPlaceholder(System::SharedPtr<IMasterSlide> master, PlaceholderType type)
{
    for (auto& shape : master->get_Shapes())
    {
        System::SharedPtr<IAutoShape> autoShape = System::AsCast<Aspose::Slides::IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            if (autoShape->get_Placeholder()->get_Type() == type)
            {
                return autoShape;
            }
        }
    }
    return nullptr;
}

void Main()
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
    System::SharedPtr<IAutoShape> placeHolder = FindPlaceholder(master, Aspose::Slides::PlaceholderType::Title);
    auto fillFormat = placeHolder->get_FillFormat();
    fillFormat->set_FillType(Aspose::Slides::FillType::Gradient);
    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(Aspose::Slides::GradientShape::Linear);
    gradientFormat->get_GradientStops()->Add(0.0f, System::Drawing::Color::FromArgb(255, 0, 0));
    gradientFormat->get_GradientStops()->Add(255.0f, System::Drawing::Color::FromArgb(128, 0, 128));
    
    pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
}
```

سيتغير نمط العنوان وتنسيقه لجميع الشرائح بناءً على سلايد ماستر:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}} 

* [تعيين نص التذكير في عنصر نائب](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [تنسيق النص](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **تغيير الخلفية على سلايد ماستر**

عند تغيير لون خلفية سلايد ماستر، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يُظهر هذا الرمز C++ العملية:

```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="primary" title="انظر أيضًا" %}} 

- [خلفية العرض](https://docs.aspose.com/slides/cpp/presentation-background/)

- [ثيم العرض](https://docs.aspose.com/slides/cpp/presentation-theme/)

  {{% /alert %}}

## **استنساخ سلايد ماستر إلى عرض تقدمي آخر**

لاستنساخ سلايد ماستر إلى عرض موديل آخر، اتصل بطريقة [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) من العرض المقصود مع تمرير سلايد ماستر إليها. يُظهر هذا الرمز C++ كيف يمكنك استنساخ سلايد ماستر إلى عرض تقديمي آخر:

```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```

## **إضافة عدة سلايد ماستر إلى العرض**

تسمح Aspose.Slides لك بإضافة عدة سلايد ماستر وتخطيطات شرائح إلى أي عرض محدد. يتيح لك ذلك إعداد الأنماط والتخطيطات وخيارات التنسيق لشرائح العرض بطرق عديدة.

في باوربوينت، يمكنك إضافة سلايد ماستر وتخطيط جديدة (من قائمة "سلايد ماستر") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة سلايد ماستر جديدة عن طريق استدعاء طريقة [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48):

```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```

## **مقارنة سلايد ماستر**

ت implement سلايد ماستر واجهة [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) التي تحتوي على طريقة [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f) ، والتي يمكن استخدامها لمقارنة الشرائح. وترجع `true` لسلايد ماستر المتماثلة في الهيكل والمحتوى الثابت.

تكون سلايد ماستر متساوية إذا كانت أشكالها وأنماطها ونصوصها وتأثيراتها والإعدادات الأخرى وما إلى ذلك متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريد (على سبيل المثال: SlideId) والمحتوى الديناميكي (على سبيل المثال: القيمة الحالية في عنصر نائب التاريخ).

## **تعيين سلايد ماستر كعرض افتراضي للعرض**

تسمح Aspose.Slides لك بتعيين سلايد ماستر كعرض افتراضي لعرض تقديمي. العرض الافتراضي هو ما تراه أولاً عند فتح العَرض.

يظهر هذا الرمز لك كيفية تعيين سلايد ماستر كعرض افتراضي لعَرض تقديمي في C++:

```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```

## **إزالة سلايد ماستر غير المستخدمة**

توفر Aspose.Slides طريقة [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (من فئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) للسماح لك بحذف سلايد ماستر غير مرغوب فيه وغير مستخدم. يُظهر هذا الرمز C++ كيف يمكنك إزالة سلايد ماستر من عرض باوربوينت:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```