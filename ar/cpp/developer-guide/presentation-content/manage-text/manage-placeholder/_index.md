---
title: إدارة عناصر النائب في العرض التقديمي باستخدام C++
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/cpp/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- نص المطالبة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة العناصر النائبة بسهولة في Aspose.Slides لـ C++: استبدال النص، تخصيص المطالبات وتعيين شفافية الصورة في PowerPoint و OpenDocument."
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides لـ C++](/slides/ar/cpp/)، يمكنك العثور على العناصر النائبة وتعديلها على الشرائح في العروض التقديمية. يسمح لك Aspose.Slides بإجراء تغييرات على النص في العنصر النائب.

**المتطلبات المسبقّة**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض التقديمي في تطبيق Microsoft PowerPoint القياسي.

إليك الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. إنشاء كائن من الفئة `Presentation` وتمرير العرض التقديمي كمعامل.
2. الحصول على مرجع الشريحة عبر رقمها.
3. التنقل عبر الأشكال للعثور على العنصر النائب.
4. تحويل نوع شكل العنصر النائب إلى `AutoShape` وتغيير النص باستخدام `TextFrame` المرتبط بـ `AutoShape`.
5. حفظ العرض التقديمي المعدل.

This C++ code shows how to change the text in a placeholder:
```c++
// مسار دليل المستندات.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويله إلى AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// حفظ العرض التقديمي إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **تعيين نص المطالبة في العنصر النائب**
تحتوي القوالب القياسية والمبنية مسبقًا على نصوص مطالبة للعنصر النائب مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة نص فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص المطالبة المفضلة لديك في قوالب العناصر النائبة.

This C++ code shows you how to set the prompt text in a placeholder:
```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // عند عدم وجود نص فيه، يعرض PowerPoint "Click to add title".
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // يفعل الشيء نفسه للعنوان الفرعي.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **تعيين شفافية صورة العنصر النائب**

يسمح لك Aspose.Slides بتعيين شفافية صورة الخلفية في عنصر نائب نصي. من خلال تعديل شفافية الصورة داخل هذا الإطار، يمكنك إبراز النص أو الصورة (اعتمادًا على ألوان النص والصورة).

This C++ code shows you how to set the transparency for a picture background (inside a shape):
```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```


## **الأسئلة المتكررة**

**ما هو العنصر النائب الأساسي، وكيف ي berbeda عن الشكل المحلي على الشريحة؟**
العنصر النائب الأساسي هو الشكل الأصلي في القالب أو القالب الرئيسي الذي يرث منه شكل الشريحة — النوع، الموضع، وبعض التنسيقات تأتي منه. الشكل المحلي مستقل؛ إذا لم يكن هناك عنصر نائب أساسي، لا يتم تطبيق الوراثة.

**كيف يمكنني تحديث جميع العناوين أو التسميات التوضيحية عبر عرض تقديمي دون التنقل عبر كل شريحة؟**
قم بتحرير العنصر النائب المقابل على القالب أو القالب الرئيسي. ستورّث الشرائح التي تعتمد على تلك القوالب/القالب الرئيسي التغيير تلقائيًا.

**كيف يمكنني التحكم في العناصر النائبة القياسية للترويسة/التذييل — التاريخ والوقت، رقم الشريحة، ونص التذييل؟**
استخدم مديري HeaderFooter في النطاق المناسب (الشرائح العادية، القوالب، القالب الرئيسي، الملاحظات/المستندات) لتفعيل أو إلغاء تفعيل هذه العناصر النائبة وتحديد محتواها.