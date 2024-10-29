---
title: إدارة المربع النصي
type: docs
weight: 20
url: /ar/cpp/manage-textbox/
keywords: "المربع النصي، إطار النص، إضافة مربع نص، مربع نص مرتبط، C++، Aspose.Slides لـ C++"
description: "إضافة مربع نص أو إطار نص إلى عروض PowerPoint في C++"
---

توجد النصوص في الشرائح عادةً في مربعات نص أو أشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides لـ C++ واجهة [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) التي تتيح لك إضافة شكل يحتوي على بعض النص.

{{% alert title="معلومات" color="info" %}}

توفر Aspose.Slides أيضًا واجهة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) التي تتيح لك إضافة أشكال إلى الشرائح. ومع ذلك، لا يمكن لجميع الأشكال المضافة عبر واجهة `IShape` أن تحتوي على نص. ولكن يمكن أن تحتوي الأشكال المضافة عبر واجهة [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) على نص.

{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}} 

لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكيد على أنه تم تحويله عبر واجهة `IAutoShape`. فقط حينها ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) ، وهي خاصية تحت `IAutoShape`. راجع قسم [تحديث النص](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) في هذه الصفحة.

{{% /alert %}}

## **إنشاء مربع نص على الشريحة**

لإنشاء مربع نص على شريحة، اتبع هذه الخطوات:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
2. احصل على مرجع للشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائن [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) مع تعيين [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) ليكون `Rectangle` في موقع محدد على الشريحة واحصل على مرجع لكائن `IAutoShape` المضاف حديثًا. 
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، قم بكتابة ملف PPTX عبر كائن `Presentation`. 

يظهر هذا الكود C++—تنفيذ الخطوات المذكورة أعلاه—كيف يمكنك إضافة نص إلى شريحة:

```cpp
// إنشاء عرض تقديمي
auto pres = System::MakeObject<Presentation>();

// الحصول على الشريحة الأولى في العرض التقديمي
auto sld = pres->get_Slides()->idx_get(0);

// إضافة AutoShape بنوع محدد كـ Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// إضافة TextFrame إلى Rectangle
ashp->AddTextFrame(u" ");

// الوصول إلى إطار النص
auto txtFrame = ashp->get_TextFrame();

// إنشاء كائن فقرة لإطار النص
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// إنشاء كائن Portion للفقرة
auto portion = para->get_Portions()->idx_get(0);

// تعيين النص
portion->set_Text(u"Aspose TextBox");

// حفظ العرض التقديمي على القرص
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **تحقق من شكل مربع النص**

توفر Aspose.Slides طريقة [get_IsTextBox()](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) (من فئة [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/)) التي تتيح لك فحص الأشكال والعثور على مربعات النص.

![مربع النص والشكل](istextbox.png)

يوضح هذا الكود C++ كيف تتحقق مما إذا كان الشكل قد تم إنشاؤه كمربع نص:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
for (auto&& slide : pres->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        auto autoShape = System::DynamicCast_noexcept<Aspose::Slides::AutoShape>(shape);
        if (autoShape != nullptr)
        {
            System::Console::WriteLine(autoShape->get_IsTextBox() ? System::String(u"الشكل هو مربع نص") : System::String(u"الشكل ليس مربع نص"));
        }
    }
}
```

## **إضافة عمود في مربع النص**

توفر Aspose.Slides طرق [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) و [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) وفئة [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) التي تتيح لك إضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص وضبط مقدار التباعد بالنقاط بين الأعمدة.

يوضح هذا الكود في C++ العملية الموصوفة:

```cpp
auto presentation = System::MakeObject<Presentation>();
// الحصول على الشريحة الأولى في العرض التقديمي
auto slide = presentation->get_Slides()->idx_get(0);

// إضافة AutoShape بنوع محدد كـ Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// إضافة TextFrame إلى Rectangle
aShape->AddTextFrame(String(u"جميع هذه الأعمدة محدودة لتكون ضمن حاوية نص واحدة -- ") 
    + u"يمكنك إضافة نص أو حذفه والنص الجديد أو المتبقي يتكيف تلقائيًا " 
    + u"للتدفق ضمن الحاوية. لا يمكنك أن يتدفق النص من حاوية إلى أخرى " 
    + u"على الرغم من ذلك -- لقد أخبرناك أن خيارات الأعمدة في PowerPoint للنص محدودة!");

// الحصول على تنسيق النص لإطار النص
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// تحديد عدد الأعمدة في TextFrame
format->set_ColumnCount(3);

// تحديد التباعد بين الأعمدة
format->set_ColumnSpacing(10);

// حفظ العرض التقديمي
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **إضافة عمود في إطار النص**
توفر Aspose.Slides لـ C++ طريقة [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) التي تتيح لك إضافة أعمدة في إطارات النص. من خلال هذه الطريقة، يمكنك تحديد عدد الأعمدة المفضلة لديك في إطار النص.

يوضح هذا الكود C++ كيفية إضافة عمود داخل إطار النص:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"جميع هذه الأعمدة مضطرة للبقاء ضمن حاوية نص واحدة -- ") 
    + u"يمكنك إضافة نص أو حذفه - ويتكيف النص الجديد أو المتبقي تلقائيًا " 
    + u"للبقاء ضمن الحاوية. لا يمكنك أن يتدفق النص من حاوية إلى أخرى " 
    + u"على الرغم من ذلك -- لأن خيارات الأعمدة في PowerPoint للنص محدودة!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **تحديث النص**

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في مربع نص أو جميع النصوص الموجودة في عرض تقديمي.

يوضح هذا الكود C++ عملية حيث يتم تحديث أو تغيير جميع النصوص في عرض تقديمي:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    // تغيير النص
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    // تغيير التنسيق
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

// حفظ العرض التقديمي المعدل
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **إضافة مربع نص مرتبط** 

يمكنك إدراج رابط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الرابط.

لإضافة مربع نص يحتوي على رابط، اتبع هذه الخطوات:

1. قم بإنشاء مثيل من فئة `Presentation`. 
2. احصل على مرجع للشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائن `AutoShape` مع تعيين `ShapeType` ليكون `Rectangle` في موقع محدد على الشريحة واحصل على مرجع لكائن AutoShape المضاف حديثًا.
4. أضف `TextFrame` إلى كائن `AutoShape` الذي يحتوي على *Aspose TextBox* كنص افتراضي. 
5. قم بإنشاء مثيل لفئة `IHyperlinkManager`. 
6. قم بتعيين كائن `IHyperlinkManager` إلى طريقة [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) المرتبطة بالجزء المفضل لديك من `TextFrame`. 
7. أخيرًا، قم بكتابة ملف PPTX عبر كائن `Presentation`. 

يوضح هذا الكود C++—تنفيذ الخطوات المذكورة أعلاه—كيف يمكنك إضافة مربع نص مرتبط إلى شريحة:

```cpp
// إنشاء مثيل لفئة Presentation تمثل PPTX
auto presentation = System::MakeObject<Presentation>();

// الحصول على الشريحة الأولى في العرض التقديمي
auto slide = presentation->get_Slides()->idx_get(0);

// إضافة كائن AutoShape مع تحديد النوع كـ Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// تحويل الشكل إلى AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// الوصول إلى خاصية ITextFrame المرتبطة بـ AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// إضافة نص إلى الإطار
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// تعيين الرابط للنص المخصص
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// حفظ عرض PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```