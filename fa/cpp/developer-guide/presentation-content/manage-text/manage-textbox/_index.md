---
title: مدیریت جعبه‌های متن در ارائه‌ها با C++
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/cpp/manage-textbox/
keywords:
- جعبه متن
- قاب متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ ایجاد، ویرایش و تکثیر جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را آسان می‌کند و خودکارسازی ارائه‌های شما را بهبود می‌بخشد."
---
## **مقدمه**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا شکل‌ها وجود دارند. بنابراین، برای افزودن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی داخل جعبه متن قرار دهید. Aspose.Slides برای C++ رابط [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) را فراهم می‌کند که به شما امکان افزودن شکلی حاوی متن را می‌دهد.

{{% alert title="Info" color="info" %}}

Aspose.Slides همچنین رابط [IShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape) را فراهم می‌کند که به شما امکان افزودن شکل‌ها به اسلایدها را می‌دهد. با این حال، همهٔ شکل‌هایی که از طریق رابط `IShape` اضافه می‌شوند، نمی‌توانند متن داشته باشند. اما شکل‌هایی که از طریق رابط [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) اضافه می‌شوند، ممکن است متن داشته باشند.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

بنابراین، هنگام کار با شکلی که می‌خواهید به آن متن اضافه کنید، ممکن است بخواهید بررسی و تأیید کنید که از طریق رابط `IAutoShape` تبدیل شده است. فقط در این صورت می‌توانید از [TextFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.text_frame) که یک ویژگی زیر `IAutoShape` است، استفاده کنید. بخش [Update Text](https://docs.aspose.com/slides/fa/cpp/manage-textbox/#update-text) را در این صفحه ببینید.

{{% /alert %}}

## **ایجاد یک جعبه متن در اسلاید**

برای ایجاد یک جعبه متن روی یک اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید. 
2. یک مرجع برای اولین اسلاید در ارائه‌ی تازه ایجاد شده به دست آورید. 
3. یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) با [ShapeType](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) تنظیم شده به عنوان `Rectangle` در موقعیت مشخصی روی اسلاید اضافه کنید و مرجع شیء `IAutoShape` تازه افزوده‌شده را به دست آورید. 
4. ویژگی `TextFrame` را به شیء `IAutoShape` اضافه کنید که حاوی متنی خواهد بود. در مثال زیر، این متن را اضافه کردیم: *Aspose TextBox*
5. در نهایت، فایل PPTX را با استفاده از شیء `Presentation` ذخیره کنید. 

این کد C++—یک پیاده‌سازی از مراحل بالا—نشان می‌دهد چگونه به یک اسلاید متن اضافه کنید:

```cpp
// نمونه‌سازی Presentation
auto pres = System::MakeObject<Presentation>();

// اولین اسلاید در ارائه را دریافت می‌کند
auto sld = pres->get_Slides()->idx_get(0);

// یک AutoShape با نوع Rectangle اضافه می‌کند
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// یک TextFrame به Rectangle اضافه می‌کند
ashp->AddTextFrame(u" ");

// به TextFrame دسترسی می‌یابد
auto txtFrame = ashp->get_TextFrame();

// شی Paragraph برای TextFrame ایجاد می‌کند
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// شی Portion برای پاراگراف ایجاد می‌کند
auto portion = para->get_Portions()->idx_get(0);

// متن را تنظیم می‌کند
portion->set_Text(u"Aspose TextBox");

// ارائه را روی دیسک ذخیره می‌کند
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **بررسی وجود شکل جعبه متن**

Aspose.Slides متد [get_IsTextBox](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/get_istextbox/) را از رابط [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) فراهم می‌کند که به شما امکان بررسی شکل‌ها و شناسایی جعبه‌های متن را می‌دهد.

![Text box and shape](istextbox.png)

این کد C++ نشان می‌دهد چگونه بررسی کنید آیا یک شکل به‌عنوان جعبه متن ایجاد شده است یا خیر: 

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

توجه داشته باشید که اگر فقط یک autoshape را با استفاده از متد `AddAutoShape` از رابط [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/) اضافه کنید، متد `get_IsTextBox` برای آن autoshape مقدار `false` برمی‌گرداند. با این حال، پس از افزودن متن به autoshape با استفاده از متد `AddTextFrame` یا متد `set_Text`، متد `get_IsTextBox` مقدار `true` برمی‌گرداند.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() مقدار false را برمی‌گرداند
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() مقدار true را برمی‌گرداند

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() مقدار false را برمی‌گرداند
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() مقدار true را برمی‌گرداند

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() مقدار false را برمی‌گرداند
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() مقدار false را برمی‌گرداند

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() مقدار false را برمی‌گرداند
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() مقدار false را برمی‌گرداند
```

## **افزودن ستون‌ها به جعبه متن**

Aspose.Slides متدهای [set_ColumnCount](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) و [set_ColumnSpacing](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format) و کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها به جعبه‌های متن را می‌دهد. می‌توانید تعداد ستون‌ها در یک جعبه متن را مشخص کنید و فاصله بین ستون‌ها را برحسب نقطه تنظیم کنید. 

این کد C++ عملیات توضیح داده‌شده را نشان می‌دهد: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// اولین اسلاید در ارائه را دریافت می‌کند
auto slide = presentation->get_Slides()->idx_get(0);

// یک AutoShape با نوع Rectangle را اضافه می‌کند
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// یک TextFrame به Rectangle اضافه می‌کند
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// فرمت متن TextFrame را دریافت می‌کند
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// تعداد ستون‌ها در TextFrame را مشخص می‌کند
format->set_ColumnCount(3);

// فاصله بین ستون‌ها را مشخص می‌کند
format->set_ColumnSpacing(10);

// ارائه را ذخیره می‌کند
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **افزودن ستون‌ها به فریم متن**

Aspose.Slides برای C++ متد [set_ColumnCount](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame_format)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها در فریم‌های متن را می‌دهد. با استفاده از این متد می‌توانید تعداد ستون‌های دلخواه خود را در یک فریم متن مشخص کنید. 

این کد C++ نشان می‌دهد چگونه یک ستون در داخل فریم متن اضافه کنید:

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

## **به‌روزرسانی متن**

Aspose.Slides به شما امکان تغییر یا به‌روزرسانی متنی که در یک جعبه متن یا تمام متون موجود در یک ارائه وجود دارد را می‌دهد. 

این کد C++ عملی را نشان می‌دهد که در آن تمام متون یک ارائه به‌روزرسانی یا تغییر می‌یابند:

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

## **افزودن یک جعبه متن با پیوند** 

می‌توانید یک پیوند را داخل یک جعبه متن درج کنید. وقتی جعبه متن کلیک شود، کاربران به باز کردن پیوند هدایت می‌شوند. 

برای افزودن یک جعبه متن حاوی پیوند، این مراحل را دنبال کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید. 
2. یک مرجع برای اولین اسلاید در ارائه‌ی تازه ایجاد شده به دست آورید. 
3. یک شیء `AutoShape` با `ShapeType` تنظیم شده به عنوان `Rectangle` در موقعیت مشخصی روی اسلاید اضافه کنید و مرجع شیء AutoShape تازه افزوده‌شده را به دست آورید.
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید که به‌عنوان متن پیش‌فرض *Aspose TextBox* را داشته باشد. 
5. یک نمونه از کلاس `IHyperlinkManager` ایجاد کنید. 
6. شیء `IHyperlinkManager` را به متد [set_HyperlinkClick](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) مرتبط با بخش دلخواه شما از `TextFrame` اختصاص دهید. 
7. در نهایت، فایل PPTX را با استفاده از شیء `Presentation` ذخیره کنید. 

این کد C++—یک پیاده‌سازی از مراحل فوق—نشان می‌دهد چگونه یک جعبه متن با پیوند به یک اسلاید اضافه کنید:

```cpp
// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
auto presentation = System::MakeObject<Presentation>();

// اولین اسلاید در ارائه را دریافت می‌کند
auto slide = presentation->get_Slides()->idx_get(0);

// یک شیء AutoShape با نوع Rectangle اضافه می‌کند
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// شکل را به AutoShape تبدیل می‌کند
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// ویژگی ITextFrame مرتبط با AutoShape را دسترسی می‌یابد
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// متنی به فریم اضافه می‌کند
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// پیوند (Hyperlink) را برای متن بخش تنظیم می‌کند
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// ارائه PPTX را ذخیره می‌کند
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**تفاوت جعبه متن و نگهدارنده متن (placeholder) هنگام کار با اسلایدهای اصلی چیست؟**

یک [placeholder](/slides/fa/cpp/manage-placeholder/) سبک/موقعیت را از [master](https://reference.aspose.com/slides/fa/cpp/aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/layoutslide/) تغییر یابد، در حالی که یک جعبه متن معمولی یک شیء مستقل روی اسلاید خاص است و هنگام تعویض لایه‌ها تغییر نمی‌کند.

**چگونه می‌توانم جایگزینی متنی به صورت دسته‌ای در سراسر ارائه انجام دهم بدون اینکه متون داخل نمودارها، جدول‌ها و SmartArt را تحت تأثیر قرار دهم؟**

تکرار خود را تنها به auto‑shapesهایی که فریم متن دارند محدود کنید و اشیاء جاسازی‌شده ([charts](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/)، [tables](https://reference.aspose.com/slides/fa/cpp/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartart/)) را با عبور از مجموعه‌های آن‌ها به‌صورت جداگانه یا صرف‌نظر از این نوع اشیاء حذف کنید.