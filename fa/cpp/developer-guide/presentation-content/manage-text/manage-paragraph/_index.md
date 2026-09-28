---
title: مدیریت پاراگراف‌های متن پاورپوینت در C++
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- اضافه کردن متن
- اضافه کردن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت گلوله
- تورفتگی پاراگراف
- تورفتگی معلق
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست گلوله‌ای
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صادر کردن پاراگراف
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها, محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای C++ ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides برای C++ متن را به صورت یک سلسله‌مراتب از فریم‌های متنی، پاراگراف‌ها و بخش‌ها نمایش می‌دهد:

* [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) فریم متنی را در یک شکل نشان می‌دهد و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) یک پاراگراف در فریم متنی را نشان می‌دهد و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [IPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/) یک بخش متن درون یک پاراگراف را نشان می‌دهد. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متن با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف را با استفاده از چندین بخش شامل شود.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با بخش‌های متعدد**

مراحل زیر یک فریم متنی با سه پاراگراف، هر کدام شامل سه بخش، ایجاد می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء دیگر [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) را به فریم متنی اضافه کنید.
6. برای هر پاراگراف به اندازه کافی شیء [IPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/) اضافه کنید تا سه بخش داشته باشند. پاراگراف پیش‌فرض در حال حاضر یک بخش خالی دارد.
7. متن هر بخش را تنظیم کنید.
8. قالب‌بندی سطح کاراکتر را از طریق [IPortion::get_PortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/get_portionformat/) اعمال کنید.
9. ارائه تغییر یافته را ذخیره کنید.

این مثال C++ مراحل فوق را اجرا می‌کند:

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
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
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

## **ایجاد فهرست‌های بولت‌دار و عددی**

### **ایجاد یک فهرست بولت‌دار یا عددی**

بولت‌ها و شماره‌گذاری موارد مرتبط را برای اسکن سریع‌تر می‌کند. در Aspose.Slides تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید انتخابی اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از فریم متنی حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraph/) برای بولت نماد ایجاد کنید.
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Symbol](https://reference.aspose.com/slides/fa/cpp/aspose.slides/bullettype/) تنظیم کنید و کاراکتر بولت را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ بولت و ارتفاع بولت را تنظیم کنید.
9. پاراگراف را به فریم متنی اضافه کنید.
10. یک پاراگراف دوم ایجاد کرده و [IBulletFormat::set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Numbered](https://reference.aspose.com/slides/fa/cpp/aspose.slides/bullettype/) تنظیم کنید.
11. سبک بولت عددی را پیکربندی کرده و پاراگراف را به فریم متنی اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال C++ یک بولت نماد و یک بولت عددی ایجاد می‌کند:

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

### **استفاده از بولت‌های تصویری**

بولت‌های تصویری امکان استفاده از تصویر سفارشی به‌جای نماد یا عدد را می‌دهند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) اضافه کنید و به [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از فریم متنی حذف کنید.
5. تصویر بولت را بارگذاری کرده و به مجموعه تصویرهای ارائه به عنوان یک [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraph/) ایجاد کرده و متن آن را تنظیم کنید.
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Picture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [ISlidesPicture::set_Image](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidespicture/set_image/) اختصاص داده و ارتفاع بولت را تنظیم کنید.
9. پاراگراف را به فریم متنی اضافه کنید.
10. ارائه تغییر یافته را ذخیره کنید.

این مثال C++ یک بولت تصویری ایجاد می‌کند:

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

[ IParagraphFormat::set_Depth](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_depth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالا عمق `0` دارد.

1. یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کرده و به یک اسلاید دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض را از فریم متنی آن حذف کنید.
3. چهار پاراگراف ایجاد کرده و نمادهای بولت آن‌ها را پیکربندی کنید.
4. مقدارهای [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_depth/) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به فریم متنی اضافه کرده و ارائه را ذخیره کنید.

این مثال C++ یک فهرست بولت‌دار چهارسطحی ایجاد می‌کند:

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

### **شروع موارد فهرست عددی با مقادیر سفارشی**

از [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) برای تنظیم عدد اولیه نمایش داده شده برای یک پاراگراف عددی استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید و یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از فریم متنی شکل حذف کنید.
3. سه پاراگراف عددی ایجاد کنید.
4. برای پاراگراف‌های مربوطه، [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) را به ترتیب به `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به فریم متنی اضافه کرده و ارائه را ذخیره کنید.

این مثال C++ عدد شروع سفارشی را برای هر پاراگراف اختصاص می‌دهد:

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

## **کنترل چیدمان پاراگراف و ویژگی‌های انتهای پاراگراف**

### **تنظیم تورفتگی خط اول**

از [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که بقیه خطوط در بدنه پاراگراف ثابت می‌مانند.

زمانی که نیاز به جابه‌جایی کل پاراگراف دارید از [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_marginleft/) استفاده کنید. زمانی که فقط خط اول را می‌خواهید جابه‌جا کنید از [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) استفاده کنید.

مثال زیر چند پاراگراف ایجاد کرده و مقادیر مختلف [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) را برای نشان دادن تأثیر تورفتگی خط اول بر چیدمان پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کنید و برای هر کدام مقادیر متفاوتی از [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) تنظیم کنید.
6. پاراگراف‌ها را به فریم متنی اضافه کنید.
7. ارائه تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی پاراگراف تنظیم می‌شود:

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

تورفتگی معلق یک چیدمان پاراگراف است که در آن خط اول به سمت چپ خطوط بعدی شروع می‌شود. در Aspose.Slides این اثر را با [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) ایجاد می‌کنید. مقدار منفی به‌عنوان تورفتگی تنظیم کنید تا خط اول نسبت به بدنه پاراگراف به سمت چپ حرکت کند.

در عمل، [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_marginleft/) موقعیت چپ بدنه پاراگراف را تعیین می‌کند و [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) موقعیت خط اول را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت MarginLeft و مقدار منفی Indent را تنظیم کنید.

این قالب‌بندی برای کتاب‌نامه‌ها، مراجع، واژگان و سایر پاراگراف‌هایی که خطوط بسته‌بندی شده باید زیر بدنه پاراگراف و نه زیر اولین کاراکتر خط اول قرار گیرند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها را ایجاد کنید و برای هر پاراگراف مقدار مثبت [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_marginleft/) تنظیم کنید.
6. برای ایجاد اثر تورفتگی معلق مقدار منفی [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) را تنظیم کنید.
7. پاراگراف‌ها را به فریم متنی اضافه کنید.
8. ارائه تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی معلق برای یک پاراگراف تنظیم می‌شود:

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

### **تنظیم ویژگی‌های انتهای پاراگراف**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر اندازه فونت و فونت لاتین را برای علامت انتهای پاراگراف دوم اختصاص می‌دهد:

1. یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به آن‌ها بخش‌های متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/portionformat/) برای علامت انتهای پاراگراف دوم بسازید.
5. [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_fontheight/) و [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_latinfont/) را تنظیم کنید.
6. قالب را با [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) اختصاص داده و ارائه را ذخیره کنید.

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

## **شمارش خطوط رندر‌شده**

برای قوانین پاراگراف که بر بسته‌بندی خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به [کنترل شکست خط](/slides/fa/cpp/text-formatting/#control-line-breaking) و [کنترل نقطه‌گذاری معلق](/slides/fa/cpp/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [IParagraph::GetLinesCount](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/getlinescount/) برای شمارش خطوطی که یک پاراگراف پس از چیدمان متن اشغال می‌کند، استفاده کنید؛ این شامل بسته‌بندی خودکار نیز می‌شود. این متد وقتی که می‌خواهید طول متن و چیدمان را در قالب‌های ارائه بررسی کنید مفید است.

یک پاراگراف یک مورد در [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_paragraphs/) است و می‌تواند چندین خط رندر‌شده را اشغال کند. یک شکست خط صریح داخل پاراگراف، خط جدیدی ایجاد می‌کند بدون اینکه پاراگراف دیگری ایجاد شود. بسته‌بندی خودکار خطوط را بر اساس عرض موجود ایجاد می‌کند بدون این که کاراکترهای شکست خط صریح به متن افزوده شوند. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، تعداد خطوط رندر‌شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته‌ای کوتاه‌تر جایگزین می‌کند. بسته‌بندی فعال است و AutoFit غیرفعال شده تا عرض شکل کنترل‌کننده‌ی بسته‌بندی باشد بدون اینکه متن یا شکل به‌صورت خودکار کوچک شود. ابعاد شکل بر حسب پونت است. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و تعداد خطوط را در کل فریم متنی جمع می‌زند.

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

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه‌تر آن را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به دسترس‌پذیری و جایگزینی فونت‌ها، اندازه فونت، حاشیه‌ها، تورفتگی، بسته‌بندی و تنظیمات AutoFit متفاوت باشد. هنگام بررسی قالب، از فونت‌ها و تنظیمات چیدمان هدفمند برای محیط هدف استفاده کنید.

تنها شمارش خطوط تعیین‌کننده‌ی overflow متن در محفظه نیست. ارتفاع موجود، ارتفاع خطوط، فاصله بین پاراگراف‌ها و خطوط، و رفتار AutoFit نیز مهم‌اند؛ حتی یک خط می‌تواند عرض موجود را تجاوز کند وقتی بسته‌بندی غیرفعال باشد.

## **واردات و صادرات محتویات پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphcollection/addfromhtml/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متنی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. به یک اسلاید دسترسی پیدا کنید و یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) اضافه کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشته HTML را به [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphcollection/addfromhtml/) پاس دهید.
6. ارائه تغییر یافته را ذخیره کنید.

این مثال C++ HTML را به یک فریم متنی وارد می‌کند:

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

### **صادرات متن پاراگراف به HTML**

از [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphcollection/exporttohtml/) برای صادرات یک بازه انتخابی از پاراگراف‌ها به صورت HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید و ارائه مورد نظر را بارگذاری کنید.
2. اسلاید را دسترسی پیدا کنید و [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) حاوی متن را پیدا کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
4. با مشخص کردن ایندکس پاراگراف شروع و تعداد پاراگراف‌های مورد نظر، [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphcollection/exporttohtml/) را صدا بزنید.
5. رشته HTML بازگشتی را در یک فایل بنویسید.

این مثال C++ تمام پاراگراف‌های اولین شکل متنی را صادر می‌کند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **رندر کردن پاراگراف به عنوان تصویر**

[IParagraph::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/getimage/) یک پاراگراف منفرد را مستقیماً رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) برمی‌گرداند. نتیجه را با استفاده از [IImage::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/save/) به فایل یا جریان ذخیره کنید. نیازی به رندر کل شکل یا برش بیت‌مپ به‌طور دستی ندارید.

[IParagraph::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/getimage/) ممکن است `nullptr` برگرداند اگر پاراگراف در مجموعه والد خود پیدا نشود، مرزهای رندری معتبری نداشته باشد یا نتواند رندر شود. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر بازگشتی را آزاد کنید.

#### **رندر پاراگراف با مقیاس پیش‌فرض**

فرض کنید فایلی به نام sample.pptx داریم که یک اسلاید دارد و اولین شکل آن یک جعبه متن با سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی عادی با مقیاس پیش‌فرض رندر می‌کند و تصویر برگشتی را با فرمت PNG ذخیره می‌کند.

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

#### **رندر پاراگراف در یک سلول جدول با مقیاس**

از Overload متد [IParagraph::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/getimage/) که پارامترهای `float scaleX` و `float scaleY` را می‌پذیرد، برای تنظیم مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول می‌سازد، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌کند.

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

یک مقدار مقیاس `1` آن محور را در اندازه پیکسل پیش‌فرض نگه می‌دارد. برای مثال، `2` برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض باشد و در نتیجه چهار برابر پیکسل داشته باشد. مقادیر بزرگ‌تر معمولاً متن واضح‌تری برای زوم یا خروجی با وضوح بالا فراهم می‌آورند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. مقادیر زیر `1` تصاویر کوچک‌تری با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت عرض/ارتفاع پاراگراف از مقادیر برابر استفاده کنید؛ مقادیر متفاوت افقی و عمودی تصویر را به طور مستقل کشیده می‌کند.

رندر کل شکل با استفاده از [IShape::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/getimage/) زمانی مفید است که خروجی نیاز به شامل پرشدن، حاشیه یا دیگر زمینه‌های بصری شکل داشته باشد. برای تصویر فقط پاراگراف، از [IParagraph::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/getimage/) استفاده کنید.

## **پرسش‌های متداول**

**آیا می‌توانم بسته‌بندی خطوط داخل یک فریم متنی را به‌طور کامل غیرفعال کنم؟**

بله. از [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/set_wraptext/) برای غیرفعال کردن بسته‌بندی استفاده کنید تا خطوط در لبه‌های فریم متنی شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق روی اسلاید یک پاراگراف خاص را به‌دست آورم؟**

از [IParagraph::GetRect](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/getrect/) برای دریافت مستطیل مرزی پاراگراف استفاده کنید. [IPortion::GetRect](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/getrect/) مرزهای یک بخش منفرد را فراهم می‌کند.

**کنترل ترازبندی پاراگراف (چپ، راست، مرکز یا هم‌تراز) در کجا انجام می‌شود؟**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_alignment/) یک تنظیم سطح پاراگراف است و بر کل پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی هر بخش به‌صورت مجزا.

**آیا می‌توانم زبانproofing را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. از [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_languageid/) برای بخش‌های منفرد استفاده کنید؛ به این ترتیب یک پاراگراف می‌تواند متنی با زبان‌های مختلف داشته باشد.