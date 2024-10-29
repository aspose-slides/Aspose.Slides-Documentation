---
title: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/cpp/manage-placeholder/
keywords: "عنصر نائب, نص العنصر النائب, نص المطالبة, عرض PowerPoint, C++, CPP, Aspose.Slides لـ C++"
description: "تغيير نص العنصر النائب ونص المطالبة في عروض PowerPoint باستخدام C++"
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides لـ C++](/slides/ar/cpp/)، يمكنك العثور على العناصر النائبة وتعديلها في الشرائح داخل العروض التقديمية. تتيح لك Aspose.Slides إجراء تغييرات على النص في العنصر النائب.

**المتطلبات الأساسية**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض التقديمي في تطبيق Microsoft PowerPoint القياسي.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. قم بإنشاء مثيل من الفئة [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) ومرر العرض التقديمي كوسيط.
2. احصل على مرجع إلى الشريحة باستخدام مؤشرها.
3. قم بتكرار الأشكال للعثور على العنصر النائب.
4. قم بتحويل شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) وقم بتغيير النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/) المرتبط بـ [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/).
5. احفظ العرض التقديمي المعدل.

يظهر هذا الكود C++ كيفية تغيير النص في العنصر النائب:

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
	
// حفظ العرض التقديمي على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تعيين نص المطالبة في العنصر النائب**
تحتوي التخطيطات القياسية والمعدة مسبقًا على نصوص المطالبة للعناصر النائبة مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص المطالبة المفضلة لديك في تخطيطات العناصر النائبة.

يظهر هذا الكود C++ كيفية تعيين نص المطالبة في عنصر نائب:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // عندما لا يوجد نص فيه، تعرض PowerPoint "انقر لإضافة عنوان". 
        {
            text = u"انقر لإضافة عنوان";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // يقوم بنفس الشيء للعنوان الفرعي.
        {
            text = u"انقر لإضافة عنوان فرعي";
        }
        System::Console::WriteLine(u"عنصر نائب: {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تعيين شفافية صورة العنصر النائب**

تسمح لك Aspose.Slides بتعيين شفافية صورة الخلفية في عنصر نائب نصي. من خلال ضبط شفافية الصورة في مثل هذا الإطار، يمكنك جعل النص أو الصورة بارزة (اعتمادًا على ألوان النص والصورة).

يظهر هذا الكود C++ كيفية تعيين الشفافية لخلفية الصورة (داخل شكل):

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