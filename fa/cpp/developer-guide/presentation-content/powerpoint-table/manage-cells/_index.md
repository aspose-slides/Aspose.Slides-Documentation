---
title: مدیریت سلول‌های جدول در ارائه‌ها با استفاده از C++
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/cpp/manage-cells/
keywords:
- سلول جدول
- ترکیب سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "به سادگی سلول‌های جدول را در PowerPoint با Aspose.Slides برای C++ مدیریت کنید. دسترسی، تغییر و استایل‌دهی به سلول‌ها را به‌سرعت برای خودکارسازی بی‌نقص اسلایدها فراگیرید."
---
## **مروری کلی**

Aspose.Slides به شما امکان دسترسی و تغییر سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ترکیب‌شده را شناسایی کنید، حاشیه‌های سلول را حذف کنید، پس از ترکیب یا تقسیم سلول‌ها با شماره‌گذاری سلول‌ها کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید، و یک تصویر را داخل سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید، و ارائه‌ی اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

## **شناسایی سلول ترکیب‌شده**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. جدول را از اولین اسلاید دریافت کنید.  
3. در سطرها و ستون‌های جدول پیمایش کنید تا سلول‌های ترکیب‌شده را پیدا کنید.  
4. زمانیکه سلول‌های ترکیب‌شده پیدا شد، پیام چاپ کنید.

این کد C++ نشان می‌دهد چگونه سلول‌های جدول ترکیب‌شده را در یک ارائه شناسایی کنید:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// فرض می‌کنیم که اسلاید#0.شکل#0 یک جدول است
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **حذف حاشیه‌های سلول جدول**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. آرایه‌ای از ستون‌ها با عرض تعریف کنید.  
4. آرایه‌ای از سطرها با ارتفاع تعریف کنید.  
5. از متد `AddTable` برای افزودن جدول به اسلاید استفاده کنید.  
6. در تمام سلول‌ها پیمایش کنید تا حاشیه‌های بالا، پایین، راست و چپ را پاک کنید.  
7. نمایش اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد چگونه حاشیه‌های سلول‌های جدول را حذف کنید:

``` cpp
// یک شی از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد می‌کند
auto pres = MakeObject<Presentation>();
// به اولین اسلاید دسترسی می‌یابد
auto sld = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض و سطرها را با ارتفاع تعریف می‌کند
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// یک شکل جدول را به اسلاید اضافه می‌کند
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// قالب حاشیه را برای هر سلول تنظیم می‌کند
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// فایل PPTX را بر روی دیسک ذخیره می‌کند
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **شماره‌گذاری در سلول‌های ترکیب‌شده**
اگر دو جفت سلول (1, 1) × (2, 1) و (1, 2) × (2, 2) را ترکیب کنیم، جدول حاصل شماره‌گذاری می‌شود. این کد C# فرایند را نشان می‌دهد:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// ارائه مورد نظر را بارگذاری می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اولین اسلاید دسترسی می‌یابد
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض و سطرها را با ارتفاع تعریف می‌کند
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// یک شکل جدول به اسلاید اضافه می‌کند
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// قالب حاشیه را برای هر سلول تنظیم می‌کند
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}
// سلول‌ها (1,1) تا (2,1) را ترکیب می‌کند
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// سلول‌ها (1,2) تا (2,2) را ترکیب می‌کند
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// فایل PPTX را بر روی دیسک ذخیره می‌کند
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

سپس سلول‌ها را بیشتر ترکیب می‌کنیم با ترکیب (1, 1) و (1, 2). نتیجه جدولی است که یک سلول ترکیب‌شده بزرگ در مرکز دارد:

```c++
// مسیر پوشه اسناد.
const String outPath = u"../out/MergeCells_out.pptx";

// ارائه مورد نظر را بارگذاری می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اولین اسلاید دسترسی می‌یابد
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض و سطرها را با ارتفاع تعریف می‌کند
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// یک شکل جدول را به اسلاید اضافه می‌کند
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// قالب حاشیه را برای هر سلول تنظیم می‌کند
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}

// سلول‌ها (1, 1) تا (2, 1) را ترکیب می‌کند
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// سلول‌ها (1, 2) تا (2, 2) را ترکیب می‌کند
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// فایل PPTX را بر روی دیسک ذخیره می‌کند
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **شماره‌گذاری در سلول تقسیم‌شده**
در مثال‌های قبلی، زمانی که سلول‌های جدول ترکیب می‌شدند، شماره‌گذاری یا سیستم عددی در سلول‌های دیگر تغییر نمی‌کرد.

این بار، یک جدول معمولی (جدولی بدون سلول ترکیب‌شده) می‌گیریم و سپس سعی می‌کنیم سلول (1,1) را تقسیم کنیم تا جدول ویژه‌ای بدست آوریم. ممکن است به شماره‌گذاری این جدول دقت کنید که ممکن است عجیب به نظر برسد. با این حال، این همان روشی است که Microsoft PowerPoint سلول‌های جدول را شماره‌گذاری می‌کند و Aspose.Slides نیز همین کار را انجام می‌دهد.

این کد C++ فرایندی را که توضیح دادیم نشان می‌دهد:

```c++
// مسیر پوشه اسناد.
const String outPath = u"../out/CellSplit_out.pptx";

// ارائه مورد نظر را بارگذاری می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اولین اسلاید دسترسی می‌یابد
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض و سطرها را با ارتفاع تعریف می‌کند
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// یک شکل جدول را به اسلاید اضافه می‌کند
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// قالب حاشیه را برای هر سلول تنظیم می‌کند
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}

// سلول‌ها (1, 1) تا (2, 1) را ترکیب می‌کند
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// سلول‌ها (1, 2) تا (2, 2) را ترکیب می‌کند
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// سلول (1, 1) را تقسیم می‌کند. 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// فایل PPTX را بر روی دیسک ذخیره می‌کند
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تغییر رنگ پس‌زمینه سلول جدول**

این کد C++ نشان می‌دهد چگونه رنگ پس‌زمینه یک سلول جدول را تغییر دهید:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// یک جدول جدید ایجاد کنید
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// رنگ پس‌زمینه یک سلول را تنظیم کنید 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **افزودن تصویر داخل سلول جدول**
1. یک نمونه از کلاس `Presentation` ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. آرایه‌ای از ستون‌ها با عرض تعریف کنید.  
4. آرایه‌ای از سطرها با ارتفاع تعریف کنید.  
5. از متد `AddTable` برای افزودن جدول به اسلاید استفاده کنید.  
6. یک شیء `Bitmap` ایجاد کنید تا فایل تصویر را نگه دارد.  
7. تصویر bitmap را به شیء `IPPImage` اضافه کنید.  
8. `FillFormat` سلول جدول را به `Picture` تنظیم کنید.  
9. تصویر را به اولین سلول جدول اضافه کنید.  
10. نمایش اصلاح‌شده را به صورت فایل PPTX ذخیره کنید

این کد C# نشان می‌دهد چگونه هنگام ایجاد جدول، یک تصویر را داخل سلول جدول قرار دهید:

```c++
// مسیر پوشه اسناد.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// ارائه مورد نظر را بارگذاری می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اولین اسلاید دسترسی می‌یابد
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض و سطرها را با ارتفاع تعریف می‌کند
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// یک شکل جدول را به اسلاید اضافه می‌کند
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// تصویر را دریافت می‌کند
auto img = Images::FromFile(ImagePath);

// یک تصویر را به مجموعه تصاویر ارائه اضافه می‌کند
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// تصویر را به اولین سلول جدول اضافه می‌کند
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// فایل PPTX را بر روی دیسک ذخیره می‌کند
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **پرسش‌های متداول**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای طرف‌های مختلف یک سلول تنظیم کنم؟**

بله. حاشیه‌های [بالا](https://reference.aspose.com/slides/fa/cpp/aspose.slides/cellformat/get_bordertop/)/[پایین](https://reference.aspose.com/slides/fa/cpp/aspose.slides/cellformat/get_borderbottom/)/[چپ](https://reference.aspose.com/slides/fa/cpp/aspose.slides/cellformat/get_borderleft/)/[راست](https://reference.aspose.com/slides/fa/cpp/aspose.slides/cellformat/get_borderright/) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد. این به‌طور منطقی از کنترل حاشیه برای هر طرف سلول که در مقاله نشان داده شده، پیروی می‌کند.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/سطر را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بستگی به [حالت پر کردن](https://reference.aspose.com/slides/fa/cpp/aspose.slides/picturefillmode/) دارد. در حالت کشیدگی، تصویر با سلول جدید سازگار می‌شود؛ در حالت کاشی، کاشی‌ها مجدداً محاسبه می‌شوند. مقاله به حالت‌های نمایش تصویر در یک سلول اشاره می‌کند.

**آیا می‌توانم یک پیوند به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/cpp/manage-hyperlinks/) در سطح متن (بخش) داخل چارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول تنظیم کنم؟**

بله. چارچوب متن یک سلول از [بخش‌ها](https://reference.aspose.com/slides/fa/cpp/aspose.slides/portion/) (روندها) با قالب‌بندی مستقل—خانواده فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.