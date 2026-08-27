---
title: مدیریت جعبه‌های متنی در ارائه‌ها با C++
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/cpp/manage-textbox/
keywords:
- جعبه متن
- فریم متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ ایجاد، ویرایش و کلون کردن جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را آسان می‌کند و خودکارسازی ارائه‌های شما را بهبود می‌بخشد."
---
## **معرفی**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا اشکال قرار دارند. بنابراین، برای افزودن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی داخل جعبه متن قرار دهید. Aspose.Slides برای C++ رابط [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) را فراهم می‌کند که به شما اجازه می‌دهد شکلی حاوی متن اضافه کنید.

{{% alert title="Info" color="info" %}}
Aspose.Slides همچنین رابط [IShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape) را فراهم می‌کند که به شما اجازه می‌دهد اشکال را به اسلایدها اضافه کنید. با این حال، تمام اشکالی که از طریق رابط `IShape` اضافه می‌شوند نمی‌توانند متن داشته باشند. اما اشکالی که از طریق رابط [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) اضافه می‌شوند می‌توانند متن داشته باشند. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
بنابراین، هنگام کار با شکلی که می‌خواهید متن به آن اضافه کنید، ممکن است بخواهید بررسی کنید و تأیید کنید که آن شکل از طریق رابط `IAutoShape` تبدیل شده است. فقط در این صورت می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.text_frame) کار کنید، که یک ویژگی تحت `IAutoShape` است. بخش [Update Text](https://docs.aspose.com/slides/fa/cpp/manage-textbox/#update-text) را در این صفحه ببینید. 
{{% /alert %}}

## **ایجاد جعبه متن در اسلاید**

برای ایجاد یک جعبه متن در اسلاید، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید. 
2. یک ارجاع به اولین اسلاید در ارائه تازه ایجاد شده به دست آورید. 
3. یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) با مقدار [ShapeType](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) برابر `Rectangle` در موقعیتی مشخص روی اسلاید اضافه کنید و ارجاع به شیء `IAutoShape` تازه اضافه شده را دریافت کنید. 
4. یک ویژگی `TextFrame` به شیء `IAutoShape` اضافه کنید که متنی را در خود دارد. در مثال زیر، این متن را اضافه کردیم: *Aspose TextBox*
5. در نهایت، فایل PPTX را با استفاده از شیء `Presentation` بنویسید. 

این کد C++—پیاده‌سازی مراحل فوق—نحوه افزودن متن به یک اسلاید را نشان می‌دهد:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// یک نمونه از Presentation ایجاد می‌کند
auto pres = System::MakeObject<Presentation>();

// اولین اسلاید را در ارائه دریافت می‌کند
auto sld = pres->get_Slides()->idx_get(0);

// یک AutoShape با تنظیم نوع به Rectangle اضافه می‌کند
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// یک TextFrame به Rectangle اضافه می‌کند
ashp->AddTextFrame(u" ");

// به فریم متن دسترسی می‌یابد
auto txtFrame = ashp->get_TextFrame();

// شیء Paragraph را برای فریم متن ایجاد می‌کند
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// شیء Portion را برای پاراگراف ایجاد می‌کند
auto portion = para->get_Portions()->idx_get(0);

// متن را تنظیم می‌کند
portion->set_Text(u"Aspose TextBox");

// ارائه را روی دیسک ذخیره می‌کند
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **بررسی یک شکل جعبه متن**

Aspose.Slides متد [get_IsTextBox](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/get_istextbox/) را از رابط [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) فراهم می‌کند که به شما امکان بررسی اشکال و شناسایی جعبه‌های متن را می‌دهد.

![Text box and shape](istextbox.png)

این کد C++ نشان می‌دهد چطور بررسی کنید آیا یک شکل به عنوان جعبه متن ایجاد شده است یا نه:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
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

توجه داشته باشید که اگر به سادگی یک شکل خودکار را با استفاده از متد `AddAutoShape` از رابط [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/) اضافه کنید، متد `get_IsTextBox` برای آن شکل مقدار `false` را برمی‌گرداند. اما پس از افزودن متن به شکل خودکار با استفاده از متد `AddTextFrame` یا متد `set_Text`، متد `get_IsTextBox` مقدار `true` برمی‌گرداند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() مقدار false برمی‌گرداند
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() مقدار true برمی‌گرداند

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() مقدار false برمی‌گرداند
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() مقدار true برمی‌گرداند

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() مقدار false برمی‌گرداند
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() مقدار false برمی‌گرداند

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() مقدار false برمی‌گرداند
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() مقدار false برمی‌گرداند
```

## **یافتن شکلی که یک فریم متن را مالک است**

در کدهای عمومی پردازش متن، ممکن است یک [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) دریافت کنید بدون اینکه بدانید کدام شیء ارائه آن را شامل می‌شود. از [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentshape/) استفاده کنید تا به [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) مالک بازگردید.

برای فریم متنی که به یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) یا شکل دیگری حاوی متن تعلق دارد، [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentshape/) مالک را برمی‌گرداند و [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentcell/) مقدار `nullptr` را برمی‌گرداند. هر دو متد پیمایش فقط‑خواندنی هستند، بنابراین فراخوانی آن‌ها مالکیت را تغییر نمی‌دهد. همیشه قبل از دسترسی به شکل، مقدار برگشتی را برای `nullptr` بررسی کنید.

برای یک مثال کامل که مالکین شکل و سلول جدول را شناسایی می‌کند، از جمله اشکال مرتبط با گره‌های SmartArt، به [Search and Replace Text](/slides/fa/cpp/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون‌ها به جعبه متن**

Aspose.Slides متدهای [set_ColumnCount](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) و [set_ColumnSpacing](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format) و کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها به جعبه‌های متن را می‌دهد. می‌توانید تعداد ستون‌ها در یک جعبه متن را مشخص کنید و فاصله بین ستون‌ها را برحسب نقطه تنظیم کنید. 

این کد C++ عملیات توضیح‌داده شده را نشان می‌دهد:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// اولین اسلاید را در ارائه دریافت می‌کند
auto slide = presentation->get_Slides()->idx_get(0);

// یک AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// یک TextFrame به Rectangle اضافه می‌کند
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// قالب متن TextFrame را دریافت می‌کند
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// تعداد ستون‌ها در TextFrame را مشخص می‌کند
format->set_ColumnCount(3);

// فاصله بین ستون‌ها را تعیین می‌کند
format->set_ColumnSpacing(10);

// ارائه را ذخیره می‌کند
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **افزودن ستون‌ها به فریم متن**

Aspose.Slides برای C++ متد [set_ColumnCount](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها در فریم‌های متن را می‌دهد. با استفاده از این متد می‌توانید تعداد ستون‌های دلخواه خود را در یک فریم متن مشخص کنید. 

این کد C++ نشان می‌دهد چگونه یک ستون داخل فریم متن اضافه کنید:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **به‌روزرسانی متن**

Aspose.Slides به شما اجازه می‌دهد متن موجود در یک جعبه متن یا تمام متون موجود در یک ارائه را تغییر یا به‌روزرسانی کنید. 

این کد C++ عملی را نشان می‌دهد که در آن تمام متون یک ارائه به‌روزرسانی یا تغییر می‌یابند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //متن را تغییر می‌دهد
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //قالب‌بندی را تغییر می‌دهد
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//ارائهٔ تغییر یافته را ذخیره می‌کند
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **افزودن جعبه متن با پیوند**

می‌توانید یک پیوند را داخل جعبه متن وارد کنید. هنگامی که جعبه متن کلیک می‌شود، کاربران به باز کردن پیوند هدایت می‌شوند. 

برای افزودن جعبه متن حاوی پیوند، این مراحل را طی کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید. 
2. یک ارجاع به اولین اسلاید در ارائه تازه ایجاد شده به دست آورید. 
3. یک شیء `AutoShape` با مقدار `ShapeType` برابر `Rectangle` در موقعیتی مشخص روی اسلاید اضافه کنید و ارجاع به شیء AutoShape تازه اضافه شده را دریافت کنید.
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید که متن پیش‌فرض *Aspose TextBox* را داشته باشد. 
5. یک نمونه از کلاس `IHyperlinkManager` ایجاد کنید. 
6. شیء `IHyperlinkManager` را به متد [set_HyperlinkClick](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) مرتبط با بخش مورد نظر از `TextFrame` اختصاص دهید. 
7. در نهایت، فایل PPTX را با استفاده از شیء `Presentation` بنویسید. 

این کد C++—پیاده‌سازی مراحل فوق—نحوه افزودن یک جعبه متن با پیوند به یک اسلاید را نشان می‌دهد:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
auto presentation = System::MakeObject<Presentation>();

// اولین اسلاید را در ارائه دریافت می‌کند
auto slide = presentation->get_Slides()->idx_get(0);

// یک شیء AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// شکل را به AutoShape تبدیل می‌کند
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// به ویژگی ITextFrame مرتبط با AutoShape دسترسی پیدا می‌کند
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// متنی به فریم اضافه می‌کند
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// پیوند برای متن Portion تنظیم می‌شود
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// ارائه PPTX را ذخیره می‌کند
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**تفاوت جعبه متن و محل نگه‌دارنده متن هنگام کار با اسلایدهای اصلی چیست؟**

یک [placeholder](/slides/fa/cpp/manage-placeholder/) سبک/موقعیت را از [master](https://reference.aspose.com/slides/fa/cpp/aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن عادی یک شیء مستقل در یک اسلاید خاص است و هنگام تغییر لایه‌ها تغییر نمی‌کند.

**چگونه می‌توانم جایگزینی متن به صورت دسته‌جمعی در کل ارائه انجام دهم بدون اینکه به متن داخل نمودارها، جداول و SmartArt دست بزنم؟**

تکرار خود را به auto‑shapes که فریم متن دارند محدود کنید و اشیای توکار ([charts](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/fa/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartart/)) را جداگانه پیمایش کنید یا از انواع آن اشیاء صرفنظر کنید.