---
title: مدیریت جداول ارائه در C++
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/cpp/manage-table/
keywords:
- اضافه کردن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت عرض به ارتفاع
- تراز متن
- قالب‌بندی متن
- استایل جدول
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای C++. مثال‌های کد ساده‌ای را کشف کنید تا روند کاری جداول خود را بهینه کنید."
---
## **معرفی**

یک جدول در PowerPoint روشی کارآمد برای نمایش و تصویر کردن اطلاعات است. اطلاعات در یک شبکه سلول‌ها (که به صورت ردیف‌ها و ستون‌ها ترتیب یافته‌اند) ساده و به راحتی قابل درک هستند.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/cpp/aspose.slides/table/) ، رابط [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) ، کلاس [Cell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/cell/) ، رابط [ICell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/) و انواع دیگر را ارائه می‌دهد تا بتوانید جدول‌ها را در انواع ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از صفر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک آرایه از `columnWidth` تعریف کنید.  
4. یک آرایه از `rowHeight` تعریف کنید.  
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) را به اسلاید اضافه کنید با استفاده از متد [AddTable()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addtable/).  
6. برای هر [ICell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/) به منظور اعمال قالب‌بندی به حاشیه‌های بالا، پایین، راست و چپ، تکرار کنید.  
7. دو سلول اول ردیف اول جدول را ادغام کنید.  
8. به [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframe/) مربوط به یک [ICell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/) دسترسی پیدا کنید.  
9. متنی به [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframe/) اضافه کنید.  
10. ارائهٔ اصلاح‌شده را ذخیره کنید.

```c++
// یک شیء از کلاس Presentation می‌سازد که نمایانگر یک فایل PPTX است
auto pres = System::MakeObject<Presentation>();

// به اسلاید اول دسترسی می‌یابد
auto sld = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// یک شکل جدول را به اسلاید اضافه می‌کند
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// قالب حاشیه را برای هر سلول تنظیم می‌کند
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}
// سلول‌های ۱ و ۲ ردیف ۱ را ادغام می‌کند
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// متنی به سلول ادغام‌شده اضافه می‌کند
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// ارائه را روی دیسک ذخیره می‌کند
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و مبتنی بر صفر است. اولین سلول در یک جدول با اندیس 0,0 (ستون 0، ردیف 0) شناخته می‌شود.

به عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این کد C++ نشان می‌دهد چگونه شماره‌گذاری سلول‌ها را در یک جدول مشخص کنید:

```c++
// یک شیء از کلاس Presentation می‌سازد که نمایانگر یک فایل PPTX است
auto pres = System::MakeObject<Presentation>();

// به اسلاید اول دسترسی می‌یابد
auto sld = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// یک شکل جدول را به اسلاید اضافه می‌کند
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// قالب حاشیه را برای هر سلول تنظیم می‌کند
for (const auto& row : tbl->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

// ارائه را روی دیسک ذخیره می‌کند
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **دسترسی به جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلایدی که حاوی جدول است را از طریق شاخص آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) ایجاد کنید و آن را به null تنظیم کنید.  
4. تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) را تا پیدا شدن جدول تکرار کنید.  

اگر گمان می‌کنید اسلاید موردنظر تنها یک جدول دارد، می‌توانید به سادگی تمام اشکالی که در آن وجود دارد را بررسی کنید. هنگامی که یک شکل به عنوان جدول شناسایی شد، می‌توانید آن را به یک شیء [Table](https://reference.aspose.com/slides/fa/cpp/aspose.slides/table/) تبدیل کنید. اما اگر اسلاید شامل چندین جدول باشد، بهتر است جدول موردنیاز را از طریق متد [set_AlternativeText()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_alternativetext/) جستجو کنید.  

5. از شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) برای کار با جدول استفاده کنید. در مثال زیر یک ردیف جدید به جدول اضافه کرده‌ایم.  
6. ارائهٔ اصلاح‌شده را ذخیره کنید.

```c++
// یک شیء از کلاس Presentation می‌سازد که نمایانگر یک فایل PPTX است
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// به اسلاید اول دسترسی می‌یابد
auto sld = pres->get_Slides()->idx_get(0);

// جدول را به مقدار null مقداردهی می‌کند
System::SharedPtr<ITable> tbl;

// از طریق اشکال تکرار می‌کند و مرجعی به جدول یافت‌شده تنظیم می‌کند
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// متن را برای ستون اول ردیف دوم تنظیم می‌کند
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// ارائهٔ اصلاح‌شده را روی دیسک ذخیره می‌کند
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **هم‌راست کردن متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) را به اسلاید اضافه کنید.  
4. یک شیء [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) را از جدول دسترسی پیدا کنید.  
5. به [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) مربوط به [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) دسترسی پیدا کنید.  
6. متن را به صورت عمودی هم‌راست کنید.  
7. ارائهٔ اصلاح‌شده را ذخیره کنید.

```c++
// یک نمونه از کلاس Presentation ایجاد می‌کند
auto presentation = System::MakeObject<Presentation>();

// اسلاید اول را دریافت می‌کند 
auto slide = presentation->get_Slides()->idx_get(0);

// ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// شکل جدول را به اسلاید اضافه می‌کند
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// به فریم متن دسترسی می‌یابد
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// شیء Paragraph را برای فریم متن ایجاد می‌کند
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// شیء Portion را برای پاراگراف ایجاد می‌کند
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// متن را به صورت عمودی هم‌راست می‌کند
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// ارائه را بر روی دیسک ذخیره می‌کند
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **تنظیم قالب‌بندی متن در سطح جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) را از اسلاید دسترسی پیدا کنید.  
4. برای متن، [set_FontHeight()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_fontheight/) را تنظیم کنید.  
5. [set_Alignment()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_alignment/) و [set_MarginRight()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_marginright/) را تنظیم کنید.  
6. [set_TextVerticalType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframeformat/set_textverticaltype/) را تنظیم کنید.  
7. ارائهٔ اصلاح‌شده را ذخیره کنید.

```c++
// یک نمونه از کلاس Presentation ایجاد می‌کند
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// فرض می‌کنیم که اولین شکل در اولین اسلاید یک جدول است
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// ارتفاع قلم سلول‌های جدول را تنظیم می‌کند
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// ترازبندی متن سلول‌های جدول و حاشیهٔ راست را در یک فراخوانی تنظیم می‌کند
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// نوع عمودی متن سلول‌های جدول را تنظیم می‌کند
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما اجازه می‌دهد ویژگی‌های سبک یک جدول را بازیابی کنید تا بتوانید این جزئیات را برای جدول دیگر یا مکان دیگری استفاده کنید. این کد C++ نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌فرض جدول دریافت کنید:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **قفل کردن نسبت عرض به ارتفاع جدول**

نسبت عرض به ارتفاع یک شکل هندسی، نسبت ابعاد آن در جهت‌های مختلف است. Aspose.Slides ویژگی `AspectRatioLocked()` را ارائه کرده است تا بتوانید تنظیم نسبت عرض به ارتفاع را برای جدول‌ها و سایر اشکال قفل کنید.

این کد C++ نشان می‌دهد چگونه نسبت عرض به ارتفاع را برای یک جدول قفل کنید:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **سؤالات متداول**

**آیا می‌توانم جهت خواندن راست به چپ (RTL) را برای یک جدول کامل و متن داخل سلول‌های آن فعال کنم؟**  

بله. جدول متد [set_RightToLeft](https://reference.aspose.com/slides/fa/cpp/aspose.slides/table/set_righttoleft/) را در اختیار می‌گذارد و پاراگراف‌ها متد [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraphformat/set_righttoleft/) دارند. استفاده از هر دو اطمینان می‌دهد که ترتیب و رندر صحیح RTL داخل سلول‌ها اعمال شود.

**چگونه می‌توانم از جابجا یا تغییر اندازه جدول توسط کاربران در فایل نهایی جلوگیری کنم؟**  

از [shape locks](/slides/fa/cpp/applying-protection-to-presentation/) استفاده کنید تا جابجایی، تغییر اندازه، انتخاب و غیره غیرفعال شوند. این قفل‌ها برای جدول‌ها نیز اعمال می‌شوند.

**آیا درج تصویر داخل یک سلول به عنوان پس‌زمینه پشتیبانی می‌شود؟**  

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/fa/cpp/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر بسته به حالت انتخابی (کشاندن یا کاشی) کل ناحیه سلول را پوشش می‌دهد.