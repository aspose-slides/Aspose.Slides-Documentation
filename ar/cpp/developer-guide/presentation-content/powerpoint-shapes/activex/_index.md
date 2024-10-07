---
title: ActiveX
type: docs
weight: 80
url: /cpp/activex/
---


تستخدم عناصر التحكم ActiveX في العروض التقديمية. يتيح لك Aspose.Slides لـ C++ إدارة عناصر التحكم ActiveX، لكن إدارتها أكثر تعقيدًا وتختلف عن أشكال العرض التقديمي العادية. اعتبارًا من Aspose.Slides لـ C++ 18.1، يدعم المكون إدارة عناصر التحكم ActiveX. في الوقت الحالي، يمكنك الوصول إلى عنصر التحكم ActiveX الذي تم إضافته مسبقًا في عرضك التقديمي وتعديله أو حذفه باستخدام الخصائص المختلفة الخاصة به. تذكر أن عناصر التحكم ActiveX ليست أشكالًا وليست جزءًا من IShapeCollection للعرض التقديمي، ولكنها جزء من IControlCollection منفصلة. يوضح هذا المقال كيفية العمل معها.

## **تعديل عنصر التحكم ActiveX**
لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة:

1. إنشاء مثيل لفئة Presentation وتحميل العرض التقديمي بعناصر التحكم ActiveX فيه.
1. الحصول على مرجع الشريحة بواسطة مؤشرها.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة من خلال الوصول إلى IControlCollection.
1. الوصول إلى عنصر التحكم ActiveX المسمى TextBox1 باستخدام كائن ControlEx.
1. تغيير الخصائص المختلفة لعنصر التحكم ActiveX TextBox1 بما في ذلك النص، الخط، ارتفاع الخط، وموقع الإطار.
1. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
1. تغيير عنوان الزر، الخط، والمكان.
1. نقل موقع إطارات عناصر التحكم ActiveX.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يحدث الكود أدناه تحديثات على عناصر التحكم ActiveX في شرائح العرض التقديمي كما هو موضح أدناه.

``` cpp
// الوصول إلى العرض التقديمي مع عناصر التحكم ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// الوصول إلى الشريحة الأولى في العرض التقديمي
auto slide = presentation->get_Slides()->idx_get(0);

// تغيير نص TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"تم تغيير النص";
    control->get_Properties()->idx_set(u"Value", newText);

    // تغيير الصورة البديلة. سيستبدل Powerpoint هذه الصورة أثناء تنشيط ActiveX، لذا في بعض الأحيان يكون من الجيد ترك الصورة دون تغيير.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// تغيير عنوان الزر
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // تغيير الصورة البديلة
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// تحريك إطارات ActiveX لأسفل بمقدار 100 نقطة
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// حفظ العرض التقديمي مع عناصر التحكم ActiveX المعدلة
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// الآن إزالة عناصر التحكم
slide->get_Controls()->Clear();

// حفظ العرض التقديمي مع عناصر التحكم ActiveX المصححة
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **إضافة عنصر تحكم Media Player ActiveX**
تستخدم عناصر التحكم ActiveX في العروض التقديمية. يتيح لك Aspose.Slides لـ C++ إضافة وإدارة عناصر التحكم ActiveX، لكن إدارتها أكثر تعقيدًا وتختلف عن أشكال العرض التقديمي العادية. اعتبارًا من Aspose.Slides لـ C++ 18.1، تم إضافة دعم لإضافة عنصر Control ActiveX لمشغل الوسائط. تذكر أن عناصر التحكم ActiveX ليست أشكالًا وليست جزءًا من IShapeCollection للعرض التقديمي، ولكنها جزء من IControlExCollection منفصلة. يوضح هذا المقال كيفية العمل معها. لإدارة عنصر تحكم Media Player ActiveX، يرجى تنفيذ الخطوات التالية:

1. إنشاء مثيل لفئة Presentation وتحميل العرض التقديمي النموذجي مع عناصر التحكم Media Player ActiveX فيه.
1. إنشاء مثيل لفئة Presentation المستهدفة وتوليد مثيل عرض تقديمي فارغ.
1. استنساخ الشريحة التي تحتوي على عنصر التحكم Media Player ActiveX في العرض التقديمي النموذجي إلى العرض التقديمي المستهدف.
1. الوصول إلى الشريحة المستنسخة في العرض التقديمي المستهدف.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة من خلال الوصول إلى IControlCollection.
1. الوصول إلى عنصر التحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
1. حفظ العرض التقديمي إلى ملف PPTX.

``` cpp
// إنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// إنشاء مثيل عرض تقديمي فارغ
auto newPresentation = System::MakeObject<Presentation>();

// إزالة الشريحة الافتراضية
newPresentation->get_Slides()->RemoveAt(0);

// استنساخ شريحة تحتوي على عنصر التحكم Media Player ActiveX
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// الوصول إلى عنصر التحكم Media Player ActiveX وتعيين مسار الفيديو
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// حفظ العرض التقديمي
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```