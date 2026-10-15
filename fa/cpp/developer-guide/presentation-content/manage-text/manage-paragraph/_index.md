---
title: مدیریت پاراگراف‌های متن PowerPoint در C++
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت گلوله
- تورفتگی پاراگراف
- تورفتگی معلق
- گلوله پاراگراف
- لیست شماره‌دار
- لیست گلوله‌ای
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- خروجی پاراگراف
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای C++ پاراگراف‌ها، بخش‌ها، گلوله‌ها، لیست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides for C++ متن را به‌صورت سلسله‌مراتبی از فریم‌های متنی، پاراگراف‌ها و بخش‌ها نمایش می‌دهد:

* [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) متن ظرفش در یک شکل را نشان می‌دهد و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) یک پاراگراف در یک فریم متنی را نمایش می‌دهد و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) یک بخش متن داخل یک پاراگراف را نشان می‌دهد. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

در نتیجه یک پاراگراف می‌تواند متنی با قلم‌ها، رنگ‌ها، اندازه‌ها و سایر قالب‌بندی‌های مختلف داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

پاراگراف‌ها را در فریم متنی یک شکل ایجاد کنید و از بخش‌ها برای قالب‌بندی اجراهای متنی منفرد استفاده کنید. این بخش نشان می‌دهد چگونه می‌توان چندین بخش را در هر پاراگراف ترکیب کرد و رنگ‌ها، اندازه‌های قلم و سبک‌های مختلف را اعمال کرد.

### **ایجاد پاراگراف‌ها با چندین بخش**

مثال زیر در C++ سه پاراگراف ایجاد می‌کند که هر یک شامل سه اجرا متن در مجموعه [IParagraph::get_Portions](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_portions/) خود هستند. این مثال از پاراگراف پیش‌فرض و بخش خالی آن استفاده می‌کند، سپس پاراگراف‌ها و بخش‌های باقیمانده را اضافه می‌کند. قالب‌بندی از طریق [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/) اعمال می‌شود: اولین بخش در هر پاراگراف قرمز، ضخیم و 15 پوینت است؛ دومین بخش آبی، ایتالیک و 18 پوینت؛ سومین بخش قالب‌بندی پیش‌فرض خود را حفظ می‌کند:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (auto paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (auto portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ایجاد فهرست‌های گلوله‌ای و عددی**

متن پاراگراف را به فهرست‌های شامل نمادها، اعداد یا تصاویر سفارشی سازماندهی کنید. مثال‌های این بخش قالب‌بندی گلوله، فهرست‌های چندسطحی و اعداد شروع سفارشی را پوشش می‌دهند.

### **ایجاد فهرست گلوله‌ای یا عددی**

گلوله‌ها و شماره‌گذاری موارد مرتبط را برای اسکن آسان‌تر می‌کنند. در Aspose.Slides تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) تعریف می‌شوند.

این مثال C++ یک گلوله نماد و یک آیتم عددی را به همان فریم متنی اضافه می‌کند. [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) نوع گلوله را انتخاب می‌کند، در حالی که [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) نماد را فراهم می‌کند و [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) سبک شماره‌گذاری را انتخاب می‌کند. هر دو آیتم از گلوله‌های سیاه با ارتفاع 100 درصد و تورفتگی پاراگراف 25 پوینت استفاده می‌کنند:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **استفاده از گلوله‌های تصویری**

گلوله‌های تصویری به شما امکان می‌دهند به جای نماد یا عدد، تصویر سفارشی استفاده کنید.

این مثال نیاز به `bullets.png` در پوشه کاری دارد. این مثال C++ یک تصویر را به مجموعه تصویرهای ارائه به عنوان یک [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) اضافه می‌کند و از آن به عنوان گلوله پاراگراف استفاده می‌کند. با استفاده از [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) یک گلوله تصویری تنظیم می‌شود و تصویر از طریق [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/) اختصاص داده می‌شود. [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) روی 100 درصد تنظیم می‌شود تا گلوله نسبت به متن پاراگراف اندازه‌گیری شود:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **ایجاد فهرست چندسطحی**

[ IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

این مثال C++ مقادیر [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) را از 0 تا 3 به چهار پاراگراف اختصاص می‌دهد و یک سلسله‌مراتب در یک فریم متنی ایجاد می‌کند. هر پاراگراف از یک گلوله نماد استفاده می‌کند و [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) به صورت متناوب بین یک گلوله گرد و یک خط تیره برای تمایز سطوح مجاور سوئیچ می‌کند:

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **شروع آیتم‌های فهرست عددی با مقادیر سفارشی**

از [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) برای تعیین عدد اولیه نمایش داده‌شده برای یک پاراگراف عددی استفاده کنید.

این مثال C++ [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) را برای استفاده از شماره‌گذاری برای سه پاراگراف تنظیم می‌کند و مقادیر [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) را به ترتیب 2، 3 و 7 اختصاص می‌دهد. مقدار شروع به طور جداگانه برای هر پاراگراف پیکربندی می‌شود و اجازه می‌دهد اعداد نمایش داده‌شده مقادیر را نادیده بگیرند:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **کنترل چیدمان پاراگراف و ویژگی‌های پایان**

حاشیه‌ها و تورفتگی‌های پاراگراف را تنظیم کنید تا موقعیت خط اول و خطوط بسته‌شده را کنترل کنید. همچنین می‌توانید علامت پایان پاراگراف را جدا از بخش‌های متنی قابل مشاهده قالب‌بندی کنید.

### **تنظیم تورفتگی خط اول**

از متد [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد فقط خط اول را نسبت به حاشیه چپ پاراگراف جابجا می‌کند. مقدار مثبت خط اول را به راست می‌پرد، در حالی که خطوط باقی‌مانده به بدنه پاراگراف تراز می‌شوند.

وقتی نیاز به جابه‌جایی کل پاراگراف دارید از [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) استفاده کنید. وقتی فقط به جابه‌جایی خط اول نیاز دارید از [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) استفاده کنید.

مثال زیر سه پاراگراف را با همان [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) برابر 20 پوینت و مقادیر [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) برابر 0، 20 و 40 پوینت می‌دهد. خطوط اول به ترتیب از آفستهای بزرگتری شروع می‌شوند، در حالی که خطوط بسته‌شده همان حاشیه چپ را حفظ می‌کنند:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تورفتگی معلق**

تورفتگی معلق یک چیدمان پاراگراف است که در آن خط اول در سمت چپ خطوط باقی‌مانده شروع می‌شود. در Aspose.Slides این اثر را با متد [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) ایجاد می‌کنید. مقدار منفی به خط اول اجازه می‌دهد نسبت به بدنه پاراگراف به سمت چپ حرکت کند.

در عمل، [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) موقعیت خط اول را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی معلق مقدار مثبت `MarginLeft` و مقدار منفی `Indent` را تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنه پاراگراف نه زیر اولین کاراکتر خط اول تراز شوند، مفید است.

مثال C++ زیر مقادیر [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) برابر 40 و 60 پوینت را با مقادیر [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) برابر -20 و -30 پوینت ترکیب می‌کند. در هر پاراگراف، خط اول به سمت چپ خطوط بسته‌شده شروع می‌شود؛ پاراگراف دوم تورفتگی معلق عمیق‌تری دارد:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های اجرای پایان پاراگراف**

متد [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال `Test.pptx` را که باید حداقل یک اسلاید داشته باشد، بارگذاری می‌کند. مثال زیر یک [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) با [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontheight/) برابر 48 پوینت و [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_latinfont/) برابر Times New Roman ایجاد می‌کند. این قالب به علامت پایان پاراگراف دوم اختصاص داده می‌شود، در حالی که بخش‌های متنی قابل مشاهده بدون تغییر می‌مانند:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **شمرده شدن خطوط رندر شده**

برای قواعد پاراگراف که بر بسته شدن خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به [Control Line Breaking](/slides/fa/cpp/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/cpp/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) برای شمردن خطوطی که یک پاراگراف پس از چیدمان متن اشغال می‌کند، از جمله بسته شدن خودکار استفاده کنید. این برای بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

یک پاراگراف یک مورد در [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_paragraphs/) است و می‌تواند چندین خط رندر شده را اشغال کند. یک شکست خط صریح داخل پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف دیگری ساخته شود. بسته شدن خودکار خطوط بر اساس عرض موجود خطوط را ایجاد می‌کند بدون اینکه شکست‌های خط صریح در متن درج شود. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، شمارش خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متن ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته کوتاه‌تری جایگزین می‌کند. مثال [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) را فعال و [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) را غیرفعال می‌کند تا عرض شکل بسته شدن را کنترل کند بدون اینکه متن به‌صورت خودکار کوچک یا شکل تغییر اندازه دهد. هر اندازه‌گیری از [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) استفاده می‌کند. ابعاد شکل بر حسب پوینت هستند. در نهایت مثال یک پاراگراف دیگر اضافه می‌کند و مجموع شمارش خطوط را در سراسر فریم متن جمع می‌کند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

با این متن و این ابعاد، باریک کردن شکل شمارش خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه شمارش را کاهش می‌دهد. شمارش‌های دقیق می‌توانند بسته به در دسترس بودن و جایگزینی قلم، اندازه قلم، حاشیه‌ها، تورفتگی، بسته شدن و تنظیمات autofit متفاوت باشند. هنگام بررسی یک قالب، از قلم‌ها و تنظیمات چیدمانی که برای محیط هدف در نظر گرفته‌اید استفاده کنید.

تنها شمارش خطوط تعیین‌کننده این نیست که آیا متن از محفظه‌اش سرریز می‌شود یا نه. ارتفاع موجود، ارتفاع خطوط، فاصله بین پاراگراف‌ها و خطوط، و رفتار autofit نیز مهم هستند؛ حتی یک خط واحد می‌تواند عرض موجود را در زمان غیرفعال بودن بسته شدن از خود بگذرد.

## **واردات و خروجی محتوای پاراگراف**

از HTML برای وارد کردن متن به یک ارائه یا خروجی پاراگراف‌های موجود برای استفاده در خارج از آن استفاده کنید. این بخش همچنین نشان می‌دهد چگونه می‌توان پاراگراف‌های منفرد را به عنوان تصویر رندر کرد، از جمله پاراگراف‌های داخل سلول‌های جدول.

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در فریم متنی استفاده کنید.

این مثال C++ HTML را از یک فایل می‌خواند و نشانه‌گذاری را به [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/) می‌گذارد. پاراگراف پیش‌فرض فریم متنی را پاک می‌کند تا فریم فقط شامل محتوای وارد شده باشد. شکل مستطیلی حاشیه 10 پوینت در هر سمت اسلاید می‌گذارد:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **خروجی متن پاراگراف به HTML**

از [ParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/exporttohtml/) برای خروجی یک بازه انتخابی از پاراگراف‌ها به صورت HTML استفاده کنید. وقتی متن ارائه را در یک وب‌سایت مجدداً استفاده می‌کنید، ممکن است بخواهید تأکید محلی را حفظ کنید بدون اینکه قلم، اندازه یا سبک‌های جعبه متن ارائه را منتقل کنید. [TextToHtmlConversionOptions::set_TextInheritanceLimit](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/set_textinheritancelimit/) را تنظیم کنید تا میزان ارث‌بری قالب‌بندی توسط خروجی‌کننده کنترل شود.

[نمونه ارائه را دانلود کنید](text-inheritance.pptx) و در پوشه کاری برنامه قرار دهید. اسلاید اولین آن شامل یک شکل متن با متن «Inherited text; explicit red 18pt» است. ورودی به‌صراحت از چندین سطح قالب‌بندی استفاده می‌کند:

- سبک متن پیش‌فرض ارائه Calibri با اندازه 28 پوینت را فراهم می‌کند.
- سبک متن سطح اول فریم متنی متن آبی و ایتالیک را فراهم می‌کند.
- پاراگراف به‌صراحت متن ضخیم را تنظیم می‌کند.
- بخش دوم، «explicit red 18pt»، به‌صراحت متن قرمز و اندازه 18 پوینت را تنظیم می‌کند.

مثال زیر همان پاراگراف‌ها را سه بار خروجی می‌دهد. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/) را به متد خروجی پاس می‌دهد و هر نتیجه را به عنوان یک فایل HTML جداگانه UTF-8 می‌نویسد:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <Export/TextInheritanceLimit.h>
#include <Export/TextToHtmlConversionOptions.h>
#include <system/array.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"text-inheritance.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto modes = MakeArray<TextInheritanceLimit>({TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly});
    auto fileNames = MakeArray<String>({u"All.html", u"TextBox.html", u"ParagraphOnly.html"});

    for (auto i = 0; i < modes->get_Length(); i++)
    {
        auto options = MakeObject<TextToHtmlConversionOptions>();
        options->set_TextInheritanceLimit(modes[i]);

        auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), options);
        File::WriteAllText(fileNames[i], html, Encoding::get_UTF8());
    }
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

HTML تولید شده CSS زیر را برای اولین بخش «Inherited text; » شامل می‌شود. جدول اعلان‌های مرتبط را فهرست می‌کند؛ سایر ویژگی‌های تولید شده برای وضوح حذف شده‌اند.

| خروجی | CSS مرتبط برای اولین بخش | ظاهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، ضخیم، ایتالیک با 28 پوینت در Calibri، در صورت موجود بودن این قلم. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، ضخیم، ایتالیک؛ صفحه یا مرورگر محیطی قلم و اندازه را فراهم می‌کند. |
| `ParagraphOnly.html` | `font-weight:bold` | متن ضخیم؛ صفحه یا مرورگر قلم، اندازه، رنگ و سبک ایتالیک را فراهم می‌کند. |

بخش دوم `color:#ff0000`، `font-size:18pt` و `font-weight:bold` را در هر سه خروجی حفظ می‌کند. همچنین ایتالیک را در `All` و `TextBox` نگه می‌دارد، اما در `ParagraphOnly` نه. محدود کردن ارث‌بری بنابراین قالب‌بندی اختصاصی به پاراگراف یا بخش را حذف نمی‌کند.

فایل‌ها را در همان مرورگر باز کنید تا آن‌ها را مقایسه کنید. در دو حالت محدود، ویژگی‌های CSS حذف شده توسط سبک‌های صفحه مقصد یا پیش‌فرض‌های مرورگر برطرف می‌شوند، بنابراین ظاهر نهایی به مکانی که HTML استفاده می‌شود بستگی دارد.

### **رندر یک پاراگراف به عنوان تصویر**

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) یک پاراگراف منفرد را مستقیماً رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) برمی‌گرداند. نتیجه را با [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) در یک فایل یا جریان ذخیره کنید. نیازی به رندر کل شکل حاوی یا برش دستی بیت‌مپ ندارید.

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) می‌تواند `nullptr` برگرداند اگر پاراگراف را نتوان در مجموعه والد پیدا کرد، محدوده رندر معتبری نداشته باشد یا قابل رندر نباشد. قبل از ذخیره نتیجه را بررسی کنید و پس از استفاده تصویر بازگشتی را حذف کنید.

#### **رندر یک پاراگراف در مقیاس پیش‌فرض**

مثال از `sample.pptx` استفاده می‌کند؛ یک ارائه با یک اسلاید که اولین شکل آن یک جعبه متن با سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم با اندیس 1 را انتخاب می‌کند و بدون پارامترهای مقیاس به [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) فراخوانی می‌کند. بررسی می‌کند که شکل پاراگراف مورد نیاز را دارد و رندر یک تصویر برمی‌گرداند قبل از اینکه [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) را برای ذخیره در فرمت PNG فراخوانی کند. پس از ذخیره تصویر را حذف می‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

نتیجه:

![تصویر پاراگراف](paragraph_to_image_output.png)

#### **رندر یک پاراگراف در سلول جدول با مقیاس‌بندی**

از بارگذاری [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) که پارامترهای `float scaleX` و `float scaleY` می‌پذیرد استفاده کنید تا عوامل مقیاس افقی و عمودی را تنظیم کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به صورت تصویر PNG ذخیره می‌کند.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

یک عامل مقیاس `1` آن محور را در اندازه پیش‌فرض پیکسل نگه می‌دارد. به عنوان مثال، `2` برای هر دو عامل تصویری با عرض و ارتفاع تقریباً دو برابر ابعاد پیش‌فرض تولید می‌کند که چهار برابر پیکسل دارد. عوامل بزرگ‌تر معمولاً متن واضح‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا تولید می‌کنند، اما حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتر با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت عرض به ارتفاع پاراگراف از عوامل برابر استفاده کنید؛ عوامل افقی و عمودی متفاوت تصویر خروجی را به‌طور مستقل کشیده می‌کنند.

رندر یک شکل کامل با [IShape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getimage/) زمانی مفید است که خروجی باید شامل پرشکل، حاشیه یا سایر زمینه‌های بصری باشد. برای یک تصویر فقط پاراگراف، از [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) استفاده کنید.

## **سؤالات متداول**

**آیا می‌توانم بسته شدن خطوط داخل فریم متنی را کاملاً غیرفعال کنم؟**

بله. از [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) برای غیرفعال کردن بسته شدن استفاده کنید تا خطوط در لبه‌های فریم متنی شکسته نشوند.

**چگونه می‌توانم حدود دقیق روی اسلاید یک پاراگراف خاص را دریافت کنم؟**

از [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/) برای بازیابی مستطیل مرزی پاراگراف استفاده کنید. [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/) حدود یک بخش منفرد را فراهم می‌کند.

**کنترل هم‌ترازی پاراگراف (چپ، راست، مرکز یا توجیه) در کجای تنظیم می‌شود؟**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) یک تنظیم سطح پاراگراف است و برای کل پاراگراف اعمال می‌شود، صرف نظر از قالب‌بندی بخش‌های منفرد.

برای هم‌ترازی عمودی بخش‌هایی با اندازه قلم متفاوت در هر خط، به [Align Fonts Within a Line](/slides/fa/cpp/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان اصلاح‌کننده را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. از [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) برای بخش‌های منفرد استفاده کنید، به‌طوری‌که یک پاراگراف بتواند متنی در چند زبان مختلف داشته باشد.