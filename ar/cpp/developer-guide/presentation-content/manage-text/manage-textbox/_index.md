---
title: إدارة صناديق النص في العروض التقديمية باستخدام C++
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/cpp/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث النص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "يُسهل Aspose.Slides لـ C++ إنشاء وتحرير واستنساخ صناديق النص في ملفات PowerPoint وOpenDocument، مما يعزز أتمتة عروضك التقديمية."
---

النصوص على الشرائح عادةً ما تكون موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. يقدم Aspose.Slides لـ C++ واجهة [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) التي تسمح لك بإضافة شكل يحتوي على نص.

{{% alert title="Info" color="info" %}}

كما يقدم Aspose.Slides واجهة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) التي تسمح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليس كل الأشكال التي تُضاف عبر واجهة `IShape` يمكنها احتواء نص. لكن الأشكال التي تُضاف عبر واجهة [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) قد تحتوي على نص. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد تحتاج إلى التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. فقط عندئذٍ ستكون قادرًا على العمل مع [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame)، وهو خاصية ضمن `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) في هذه الصفحة. 

{{% /alert %}}

## **إنشاء مربع نص على شريحة**

لإنشاء مربع نص على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
2. الحصول على مرجع لأول شريحة في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. إضافة كائن [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) مع خاصية [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) محددة كـ `Rectangle` في موقع محدد على الشريحة والحصول على مرجع لكائن `IAutoShape` الذي تم إضافته حديثًا. 
4. إضافة خاصية `TextFrame` إلى كائن `IAutoShape` الذي سيحمل نصًا. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox* 
5. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

يعرض لك هذا الكود C++ — تنفيذ للخطوات أعلاه — كيفية إضافة نص إلى شريحة:
```cpp
// ينشئ كائن Presentation
auto pres = System::MakeObject<Presentation>();

// يحصل على الشريحة الأولى في العرض التقديمي
auto sld = pres->get_Slides()->idx_get(0);

// يضيف AutoShape بنوع Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// يضيف TextFrame إلى المستطيل
ashp->AddTextFrame(u" ");

// الوصول إلى إطار النص
auto txtFrame = ashp->get_TextFrame();

// ينشئ كائن Paragraph لإطار النص
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// ينشئ كائن Portion للفقرة
auto portion = para->get_Portions()->idx_get(0);

// يضبط النص
portion->set_Text(u"Aspose TextBox");

// يحفظ العرض التقديمي إلى القرص
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```


## **التحقق من وجود شكل مربع نص**

يوفر Aspose.Slides طريقة [get_IsTextBox](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_istextbox/) من واجهة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ، مما يتيح لك فحص الأشكال وتحديد مربعات النص.

![Text box and shape](istextbox.png)

هذا الكود C++ يوضح لك كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كمربع نص: 
```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```


لاحظ أنه إذا قمت ببساطة بإضافة شكل تلقائي باستخدام طريقة `AddAutoShape` من واجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/)، ستعيد طريقة `get_IsTextBox` الخاصة بالشكل التلقائي القيمة `false`. ومع ذلك، بعد إضافة نص إلى الشكل التلقائي باستخدام طريقة `AddTextFrame` أو طريقة `set_Text`، تُعيد طريقة `get_IsTextBox` القيمة `true`.
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() ترجع false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() ترجع true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() ترجع false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() ترجع true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() ترجع false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() ترجع false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() ترجع false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() ترجع false
```


## **إضافة أعمدة إلى مربع نص**

يوفر Aspose.Slides الطريقتين [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) و [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) وفئة [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) التي تسمح لك بإضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص وتعيين المسافة بين الأعمدة بالنقاط. 

هذا الكود C++ ي demonstrates العملية الموصوفة: 
```cpp
auto presentation = System::MakeObject<Presentation>();
// يحصل على الشريحة الأولى في العرض التقديمي
auto slide = presentation->get_Slides()->idx_get(0);

// إضافة AutoShape مع تعيين النوع كـ مستطيل
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// إضافة TextFrame إلى المستطيل
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// يحصل على تنسيق النص في TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// تحديد عدد الأعمدة في TextFrame
format->set_ColumnCount(3);

// تحديد المسافة بين الأعمدة
format->set_ColumnSpacing(10);

// حفظ العرض التقديمي
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **إضافة أعمدة إلى إطار النص**

يوفر Aspose.Slides لـ C++ طريقة [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الطريقة، يمكنك تحديد عدد الأعمدة المفضلة في إطار النص. 

هذا الكود C++ يوضح لك كيفية إضافة عمود داخل إطار النص:
```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
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

يسمح Aspose.Slides لك بتغيير أو تحديث النص الموجود في مربع نص أو جميع النصوص الموجودة في عرض تقديمي. 

هذا الكود C++ ي демонстрирует عملية تحدث فيها جميع النصوص في عرض تقديمي:
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
                    //يغيّر النص
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //يغيّر التنسيق
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//يحفظ العرض التقديمي المعدل
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```


## **إضافة مربع نص مع ارتباط تشعبي** 

يمكنك إدراج رابط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الرابط. 

لإضافة مربع نص يحتوي على رابط، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة `Presentation`. 
2. الحصول على مرجع لأول شريحة في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. إضافة كائن `AutoShape` مع خاصية `ShapeType` محددة كـ `Rectangle` في موقع محدد على الشريحة والحصول على مرجع لكائن AutoShape الذي تم إضافته حديثًا. 
4. إضافة `TextFrame` إلى كائن `AutoShape` الذي يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء كائن من الفئة `IHyperlinkManager`. 
6. ربط كائن `IHyperlinkManager` بطريقة [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) المرتبطة بالجزء المفضل من `TextFrame`. 
7. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

هذا الكود C++ — تنفيذ للخطوات أعلاه — يوضح لك كيفية إضافة مربع نص مع ارتباط تشعبي إلى شريحة:
```cpp
// ينشئ كائنًا من الفئة Presentation التي تمثل ملف PPTX
auto presentation = System::MakeObject<Presentation>();

// يحصل على الشريحة الأولى في العرض التقديمي
auto slide = presentation->get_Slides()->idx_get(0);

// يضيف كائن AutoShape مع تعيين النوع كـ Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// يقوم بتحويل الشكل إلى AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// الوصول إلى الخاصية ITextFrame المرتبطة بـ AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// يضيف بعض النص إلى الإطار
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// يضبط الارتباط التشعبي لنص الجزء
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// يحفظ عرض PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**ما الفرق بين مربع النص وعلامة العنصر النائب للنص عند العمل مع الشرائح الرئيسية؟**

[placeholder](/slides/ar/cpp/manage-placeholder/) يرث النمط/الموضع من الـ [master](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) ويمكن تجاوزها في [layouts](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/)، في حين أن مربع النص العادي هو كائن مستقل على شريحة معينة ولا يتغير عند تبديل التخطيطات.

**كيف يمكنني إجراء استبدال نصي شامل عبر العرض التقديمي دون تعديل النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نصية واستثناء الكائنات المدمجة ([charts](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)) من خلال استعراض مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.