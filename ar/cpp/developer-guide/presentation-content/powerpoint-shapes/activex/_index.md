---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية باستخدام C++
linktitle: ActiveX
type: docs
weight: 80
url: /ar/cpp/activex/
keywords:
- ActiveX
- تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيف يستخدم Aspose.Slides لـ C++ تقنية ActiveX لأتمتة وتحسين عروض PowerPoint التقديمية، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

يتم استخدام عناصر التحكم ActiveX في العروض التقديمية. يتيح لك Aspose.Slides for C++ إدارة عناصر التحكم ActiveX، لكن إدارتها أصعب قليلاً ومختلفة عن الأشكال العادية في العرض التقديمي. من الإصدار 18.1 من Aspose.Slides for C++، يدعم المكون إدارة عناصر التحكم ActiveX. في الوقت الحالي، يمكنك الوصول إلى عنصر التحكم ActiveX المضاف مسبقًا في العرض التقديمي وتعديلّه أو حذفّه باستخدام خصائصه المتعددة. تذكر أن عناصر التحكم ActiveX ليست أشكالًا ولا هي جزء من IShapeCollection في العرض، بل هي ضمن IControlCollection المنفصل. توضح هذه المقالة كيفية التعامل معها.

## **تعديل عنصر تحكم ActiveX**
لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة:

1. إنشاء مثال من فئة Presentation وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX.
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة عبر IControlCollection.
1. الوصول إلى عنصر التحكم ActiveX TextBox1 باستخدام كائن ControlEx.
1. تغيير الخصائص المختلفة لعنصر التحكم ActiveX TextBox1 بما في ذلك النص، الخط، ارتفاع الخط وموقع الإطار.
1. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
1. تغيير تسمية الزر، الخط والموقع.
1. تحريك موقع إطارات عناصر التحكم ActiveX.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يقوم المقتطف البرمجي أدناه بتحديث عناصر التحكم ActiveX على شرائح العرض التقديمي كما هو موضح أدناه.
``` cpp
// الوصول إلى العرض التقديمي مع عناصر التحكم ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Accessing the first slide in presentation
auto slide = presentation->get_Slides()->idx_get(0);

// تغيير نص مربع النص
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // تغيير الصورة البديلة. سيستبدل PowerPoint هذه الصورة أثناء تنشيط ActiveX، لذا قد يكون من المقبول ترك الصورة دون تعديل.
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

// تغيير تسمية الزر
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // تغيير البديل
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

// تحريك إطارات ActiveX أسفل 100 نقطة
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// حفظ العرض التقديمي مع عناصر التحكم ActiveX التي تم تعديلها
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// الآن يتم إزالة العناصر
slide->get_Controls()->Clear();

// حفظ العرض التقديمي مع عناصر التحكم ActiveX المُزالة
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```


## **إضافة عنصر تحكم Media Player ActiveX**
يتم استخدام عناصر التحكم ActiveX في العروض التقديمية. يتيح لك Aspose.Slides for C++ إضافة وإدارة عناصر التحكم ActiveX، لكن إدارتها أصعب قليلاً ومختلفة عن الأشكال العادية في العرض. من الإصدار 18.1 من Aspose.Slides for C++، تم إضافة دعم إضافة عنصر تحكم Media Player ActiveX في Aspose.Slides. تذكر أن عناصر التحكم ActiveX ليست أشكالًا ولا هي جزء من IShapeCollection في العرض، بل هي ضمن IControlExCollection المنفصل. توضح هذه المقالة كيفية التعامل معها. لإدارة عنصر تحكم Media Player ActiveX، يرجى تنفيذ الخطوات التالية:

1. إنشاء مثال من فئة Presentation وتحميل العرض التقديمي النموذجي الذي يحتوي على عناصر تحكم Media Player ActiveX.
1. إنشاء مثال من فئة Presentation المستهدف وتوليد مثال عرض تقديمي فارغ.
1. استنساخ الشريحة التي تحتوي على عنصر تحكم Media Player ActiveX من عرض القالب إلى عرض Presentation المستهدف.
1. الوصول إلى الشريحة المستنسخة في عرض Presentation المستهدف.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة عبر IControlCollection.
1. الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
1. حفظ العرض التقديمي إلى ملف PPTX.
``` cpp
// إنشاء فئة Presentation التي تمثل ملف PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// إنشاء مثال عرض تقديمي فارغ
auto newPresentation = System::MakeObject<Presentation>();

// إزالة الشريحة الافتراضية
newPresentation->get_Slides()->RemoveAt(0);

// استنساخ شريحة تحتوي على عنصر تحكم Media Player ActiveX
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// الوصول إلى عنصر تحكم Media Player ActiveX وتحديد مسار الفيديو
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// حفظ العرض التقديمي
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**هل يحافظ Aspose.Slides على عناصر التحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة تشغيل C++؟**

نعم. يعتبر Aspose.Slides أنها جزء من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ العناصر نفسها للحفاظ عليها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE في العرض التقديمي؟**

عناصر التحكم ActiveX هي عناصر تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، بينما [OLE](/slides/ar/cpp/manage-ole/) يشير إلى كائنات تطبيق مضمّنة (مثلاً ورقة عمل Excel). يتم تخزينها ومعالجتها بطريقة مختلفة ولها نماذج خصائص مختلفة.

**هل تعمل أحداث ActiveX وماكرو VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات والبيانات الوصفية الموجودة؛ ومع ذلك، تُنفّذ الأحداث والماكروهات فقط داخل PowerPoint على نظام Windows عندما تسمح الأمان بذلك. المكتبة لا تقوم بتنفيذ VBA.