---
title: "إدارة سلائد الشرائح الرئيسية في العروض التقديمية بلغة C++"
linktitle: "سلادة الشريحة"
type: docs
weight: 80
url: /ar/cpp/slide-master/
keywords:
- "سلادة شريحة"
- "شريحة رئيسية"
- "شريحة رئيسية PPT"
- "شرائح رئيسية متعددة"
- "مقارنة الشرائح الرئيسية"
- "خلفية"
- "عنصر نائب"
- "استنساخ شريحة رئيسية"
- "نسخ شريحة رئيسية"
- "تكرار شريحة رئيسية"
- "شريحة رئيسية غير مستخدمة"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "إدارة سلائد الشرائح الرئيسية في Aspose.Slides للـ C++: إنشاء، تحرير وتطبيق القوالب، السمات والعناصر النائبة على ملفات PPT و PPTX و ODP باستخدام أمثلة مختصرة بلغة C++."
---

## **ما هو Slide Master في PowerPoint**

**Slide Master** هو قالب شريحة يحدد التنسيق، الأنماط، السمة، الخطوط، الخلفية، والخصائص الأخرى للشرائح في عرض تقديمي. إذا كنت تريد إنشاء عرض تقديمي (أو سلسلة من العروض) بنفس النمط والقالب لشركتك، يمكنك استخدام Slide Master.

يعد Slide Master مفيدًا لأنه يتيح لك تعيين وتغيير مظهر جميع شرائح العرض مرة واحدة. يدعم Aspose.Slides آلية Slide Master من PowerPoint.

كما يتيح VBA التحكم في Slide Master وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة الأشكال، تخصيص التخطيط، إلخ. يوفر Aspose.Slides آليات مرنة لاستخدام Slide Masters وأداء المهام الأساسية معها.

هذه هي عمليات Slide Master الأساسية:

- إنشاء أو Slide Master.
- تطبيق Slide Master على شرائح العرض.
- تغيير خلفية Slide Master. 
- إضافة صورة أو عنصر نائب أو Smart Art، إلخ إلى Slide Master.

هذه عمليات أكثر تقدماً تتعلق بـ Slide Master:

- مقارنة Slide Masters.
- دمج Slide Masters.
- تطبيق عدة Slide Masters.
- نسخ شريحة مع Slide Master إلى عرض تقديمي آخر.
- العثور على Slide Masters مكررة في العروض.
- تعيين Slide Master كعرض افتراضي للعرض التقديمي.

{{% alert color="primary" %}} 
قد ترغب في تجربة Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) لأنه تنفيذ حي لبعض العمليات الأساسية الموصوفة هنا.
{{% /alert %}} 

## **كيف يتم تطبيق Slide Master**

قبل العمل مع Slide Master، قد ترغب في فهم كيفية استخدامها في العروض وتطبيقها على الشرائح.

* يحتوي كل عرض تقديمي على Slide Master واحد على الأقل بشكل افتراضي. 
* يمكن للعرض التقديمي أن يحتوي على عدة Slide Masters. يمكنك إضافة عدة Slide Masters واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة. 

في **Aspose.Slides**، يُمثل Slide Master النوع [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide).

يحتوي كائن Aspose.Slides [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) على قائمة [**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) من النوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) التي تضم جميع الشرائح الرئيسية المعرفة في العرض.

بالإضافة إلى عمليات CRUD، يحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) على الطريقتين المفيدتين: [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) و[**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311). هذه الطرق موروثة من وظيفة استنساخ الشريحة الأساسية. لكن عند التعامل مع Slide Masters، تسمح لك بتنفيذ إعدادات معقدة.

عند إضافة شريحة جديدة إلى عرض تقديمي، يتم تطبيق Slide Master عليها تلقائيًا. يتم اختيار Slide Master الخاص بالشريحة السابقة بشكل افتراضي.

**ملاحظة**: تُخزن شرائح العرض في قائمة [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) ، وتُضاف كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض يحتوي على Slide Master واحد، يتم اختيار ذلك الـ Slide Master لجميع الشرائح الجديدة. هذا هو السبب في أنك لا تحتاج إلى تحديد Slide Master لكل شريحة جديدة تُنشئها.

المبدأ نفسه في PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف شريحة جديدة، يمكنك فقط الضغط على الخط السفلي تحت الشريحة الأخيرة ثم تُنشأ شريحة جديدة (مع Slide Master الخاص بالعرض الأخير):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المكافئة باستخدام طريقة [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) ضمن فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

## **Slide Master في هيكل Slides**

استخدام Slide Layouts مع Slide Master يتيح أقصى قدر من المرونة. يتيح Slide Layout لك تعيين جميع الأنماط نفسها كما في Slide Master (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عندما يتم دمج عدة Slide Layouts على Slide Master، يُنشأ نمط جديد. عند تطبيق Slide Layout على شريحة واحدة، يمكنك تغيير نمطها عن النمط المُطبق من قبل Slide Master.

Slide Master يسبق جميع عناصر الإعداد: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)

كل كائن [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) يحتوي على الخاصية [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) التي تُرجع قائمة Slide Layouts. نوع [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) يمتلك الخاصية [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) التي تُشير إلى Slide Layout المُطبق على الشريحة. التفاعل بين الشريحة وSlide Master يتم عبر Slide Layout.

{{% alert color="info" title="Note" %}}
* في Aspose.Slides، جميع إعدادات الشريحة (Slide Master، Slide Layout، والشريحة نفسها) هي في الواقع كائنات شريحة تُطبق واجهة [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide).
* وبالتالي، قد ينفذ كل من Slide Master وSlide Layout نفس الخصائص ويجب أن تعرف كيف سيتم تطبيق قيمهما على كائن [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide). يُطبق Slide Master أولًا على الشريحة ثم يُطبق Slide Layout. على سبيل المثال، إذا كان لكلٍ منهما قيمة خلفية، ستحصل الشريحة في النهاية على الخلفية من Slide Layout.
{{% /alert %}}

## **ما يُكوّن Slide Master**

لفهم كيفية تعديل Slide Master، عليك معرفة مكوناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/):

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - الحصول/تعيين خلفية الشريحة.
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - الحصول/تعيين أنماط النص لجسم الشريحة.
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - الحصول/تعيين جميع الأشكال في Slide Master (عناصر نائب، إطارات صور، إلخ).
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - الحصول/تعيين عناصر تحكم ActiveX.
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - الحصول على مدير السمة.
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - الحصول على مدير الرأس والتذييل.

طرق Slide Master:

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - الحصول على جميع الشرائح التي تعتمد على Slide Master.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - يتيح لك إنشاء Slide Master جديد بناءً على Slide Master الحالي وسمة جديدة. سيتم تطبيق الـ Slide Master الجديد على جميع الشرائح التابعة.

## **الحصول على Slide Master**

في PowerPoint، يمكن الوصول إلى Slide Master عبر القائمة View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى Slide Master بهذه الطريقة:
```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```


تمثل واجهة [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) Slide Master. الخاصية [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) (المرتبطة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)) تحتوي على قائمة بجميع Slide Masters المعرفة في العرض.

## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى Slide Master، ستظهر تلك الصورة على جميع الشرائح التي تعتمد على هذا الـ Slide Master.

على سبيل المثال، يمكنك وضع شعار شركتك وبعض الصور على Slide Master ثم الرجوع إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى Slide Master باستخدام Aspose.Slides:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" title="See also" %}} 
لمزيد من المعلومات حول إضافة الصور إلى شريحة، راجع مقالة [Picture Frame](/slides/ar/cpp/picture-frame/#create-picture-frame).
{{% /alert %}}

## **إضافة عنصر نائب إلى Slide Master**

هذه الحقول النصية هي عناصر نائب قياسية على Slide Master:

* انقر لتحرير نمط عنوان الـ Master
* تحرير أنماط نص الـ Master
* المستوى الثاني
* المستوى الثالث

تظهر أيضًا على الشرائح المستندة إلى Slide Master. يمكنك تحرير تلك العناصر النائبة على Slide Master وسيتم تطبيق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب عبر مسار Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

لنستعرض مثالًا أكثر تعقيدًا للعناصر النائبة مع Aspose.Slides. اعتبار شريحة تحتوي على عناصر نائب مُقَصَّدة من Slide Master:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على Slide Master بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر العنوان النائب من كائن Slide Master ثم نستخدم الحقل `PlaceHolder.FillFormat`:
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


سيتغير نمط العنوان والتنسيق لجميع الشرائح المستندة إلى Slide Master:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/cpp/text-formatting/)
{{% /alert %}}

## **تغيير الخلفية على Slide Master**

عند تغيير لون خلفية الشريحة الرئيسية، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. توضح هذه الشيفرة C++ العملية:
```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/cpp/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/cpp/presentation-theme/)
{{% /alert %}}

## **استنساخ Slide Master إلى عرض تقديمي آخر**

لنسخ Slide Master إلى عرض تقديمي آخر، استدعِ طريقة [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) من العرض الوجهة مع تمرير Slide Master إليه. تُظهر هذه الشيفرة C++ كيفية استنساخ Slide Master إلى عرض تقديمي آخر:
```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```


## **إضافة عدة Slide Masters إلى عرض تقديمي**

يسمح Aspose.Slides لك بإضافة عدة Slide Masters وSlide Layouts إلى أي عرض تقديمي. يتيح لك ذلك إعداد الأنماط والتخطيطات وخيارات التنسيق لشرائح العرض بطرق متعددة.

في PowerPoint، يمكنك إضافة Slide Masters وLayouts جديدة (من قائمة "Slide Master") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة Slide Master جديد باستدعاء طريقة [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48):
```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```


## **مقارنة Slide Masters**

تنفّذ شريحة Master واجهة [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) التي تحتوي على طريقة [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f) يمكن استخدامها لمقارنة الشرائح. تُرجع `true` عندما تكون Slide Masters متماثلة في الهيكل والمحتوى الثابت.

تُعد الشرائح متساوية إذا كانت الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى متطابقة. لا تأخذ المقارنة بعين الاعتبار القيم الفريدة للمعرف (مثل SlideId) أو المحتوى الديناميكي (مثل قيمة التاريخ الحالية في عنصر نائب التاريخ).

## **تعيين Slide Master كعرض افتراضي للعرض التقديمي**

يسمح Aspose.Slides لك بتعيين Slide Master كعرض افتراضي للعرض التقديمي. العرض الافتراضي هو ما تراه أولاً عند فتح العرض.

تُظهر هذه الشيفرة كيفية تعيين Slide Master كعرض افتراضي للعرض التقديمي في C++:
```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```


## **إزالة Slide Masters غير المستخدمة**

يوفر Aspose.Slides طريقة [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (من فئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) لتسمح لك بحذف Slide Masters غير المرغوب فيها وغير المستخدمة. تُظهر هذه الشيفرة C++ كيفية إزالة Slide Master من عرض PowerPoint:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**ما هو Slide Master في PowerPoint؟**

Slide Master هو قالب شريحة يحدد التخطيط، الأنماط، السمات، الخطوط، الخلفية، والخصائص الأخرى للشرائح في عرض تقديمي. يتيح لك تعيين وتغيير مظهر جميع شرائح العرض مرة واحدة.

**كيف يُطبق Slide Master في عرض تقديمي؟**

كل عرض تقديمي يحتوي على Slide Master واحد على الأقل بشكل افتراضي. عند إضافة شريحة جديدة، يُطبق Slide Master عليها تلقائيًا، عادةً ما يكون Master الشريحة السابقة هو المختار. يمكن للعرض أن يحتوي على عدة Slide Masters لتنسيق أجزاء مختلفة بطريقة فريدة.

**ما العناصر التي يمكن تخصيصها في Slide Master؟**

يتكوّن Slide Master من عدة خصائص أساسية يمكن تخصيصها:

- **Background**: تعيين خلفية الشريحة.
- **BodyStyle**: تعريف أنماط النص لجسم الشريحة.
- **Shapes**: إدارة جميع الأشكال على Slide Master، بما في ذلك العناصر النائبة وإطارات الصور.
- **Controls**: التعامل مع عناصر تحكم ActiveX.
- **ThemeManager**: الوصول إلى مدير السمة.
- **HeaderFooterManager**: إدارة الرؤوس والتذييلات.

**كيف يمكنني إضافة صورة إلى Slide Master؟**

إضافة صورة إلى Slide Master يضمن ظهورها على جميع الشرائح التي تعتمد على ذلك الـ Master. على سبيل المثال، وضع شعار الشركة على Slide Master سيظهر على كل شريحة في العرض.

**كيف يرتبط Slide Master بـ Slide Layouts؟**

تعمل Slide Layouts بالتعاون مع Slide Master لتوفير مرونة في تصميم الشرائح. بينما يحدد Slide Master الأنماط والسمات العامة، تسمح Slide Layouts بتغييرات في ترتيب المحتوى. الت hierarchy كالتالي:

- **Slide Master** → يحدد الأنماط العامة.
- **Slide Layout** → يوفر ترتيبات محتوى مختلفة.
- **Slide** → يرث التصميم من Slide Layout الخاص به.

**هل يمكن أن يكون لدي عدة Slide Masters في عرض تقديمي واحد؟**

نعم، يمكن للعرض أن يحتوي على عدة Slide Masters. يتيح لك ذلك تنسيق أقسام مختلفة من العرض بطرق متنوعة، مما يوفر مرونة في التصميم.

**كيف يمكنني الوصول إلى Slide Master وتعديله باستخدام Aspose.Slides؟**

في Aspose.Slides، يُمثّل Slide Master الواجهة [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/). يمكنك الوصول إلى Slide Master باستخدام طريقة [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) لكائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).