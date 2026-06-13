---
title: مدیریت ردیف‌ها و ستون‌ها در جدول‌های PowerPoint با استفاده از C++
linktitle: ردیف‌ها و ستون‌ها
type: docs
weight: 20
url: /fa/cpp/manage-rows-and-columns/
keywords:
- ردیف جدول
- ستون جدول
- ردیف اول
- سرصفحه جدول
- تکثیر ردیف
- تکثیر ستون
- کپی ردیف
- کپی ستون
- حذف ردیف
- حذف ستون
- قالب‌بندی متن ردیف
- قالب‌بندی متن ستون
- استایل جدول
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint با Aspose.Slides برای C++ و تسریع ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **معرفی**

برای اینکه بتوانید ردیف‌ها و ستون‌های یک جدول را در یک ارائه PowerPoint مدیریت کنید، Aspose.Slides کلاس [جدول](https://reference.aspose.com/slides/fa/cpp/aspose.slides/table/) ، رابط [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) و انواع دیگری را فراهم می‌کند. 

## **تنظیم ردیف اول به عنوان سرصفحه**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید و ارائه را بارگذاری کنید. 
2. از طریق شاخص، مرجع یک اسلاید را دریافت کنید. 
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) ایجاد کنید و آن را به null تنظیم کنید. 
4. از میان تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) عبور کنید تا جدول مربوطه را پیدا کنید. 
5. ردیف اول جدول را به عنوان سرصفحه تنظیم کنید. 

این کد C++ نشان می‌دهد چگونه ردیف اول جدول را به عنوان سرصفحه تنظیم کنید:

```c++
// یک نمونه از کلاس Presentation ایجاد می‌کند 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// دسترسی به اسلاید اول
auto sld = pres->get_Slides()->idx_get(0);

// متغیر TableEx تهی را مقداردهی اولیه می‌کند
SharedPtr<ITable> tbl;

// در اشکال مرور می‌کند و مرجع جدول را تنظیم می‌کند
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// ردیف اول جدول را به عنوان سرصفحه تنظیم می‌کند 
tbl->set_FirstRow(true);
```

## **کلون کردن ردیف یا ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید و ارائه را بارگذاری کنید, 
2. از طریق شاخص، مرجع یک اسلاید را دریافت کنید. 
3. یک آرایه از `columnWidth` تعریف کنید. 
4. یک آرایه از `rowHeight` تعریف کنید. 
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) به اسلاید اضافه کنید از طریق متد [AddTable()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addtable/). 
6. ردیف جدول را کلون کنید. 
7. ستون جدول را کلون کنید. 
8. ارائه تغییر یافته را ذخیره کنید. 

این کد C++ نشان می‌دهد چگونه ردیف یا ستون جدول PowerPoint را کلون کنید:

```c++
// مسیر به پوشه اسناد.
const String outPath = u"../out/CloningInTable_out.pptx";

// یک نمونه از کلاس Presentation ایجاد می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اسلاید اول دسترسی پیدا می‌کند
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض و ردیف‌ها را با ارتفاع تعریف می‌کند
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// یک شکل جدول را به اسلاید اضافه می‌کند
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// قالب مرزبندی هر سلول را تنظیم می‌کند
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

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone یک ردیف در انتهای جدول اضافه می‌کند
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone یک ردیف را در موقعیت خاصی از جدول اضافه می‌کند
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone یک ستون در انتهای جدول اضافه می‌کند
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone یک ستون را در موقعیت خاصی از جدول اضافه می‌کند
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// ارائه را بر روی دیسک ذخیره می‌کند
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **حذف ردیف یا ستون از جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید و ارائه را بارگذاری کنید, 
2. از طریق شاخص، مرجع یک اسلاید را دریافت کنید. 
3. یک آرایه از `columnWidth` تعریف کنید. 
4. یک آرایه از `rowHeight` تعریف کنید. 
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) به اسلاید اضافه کنید از طریق متد [AddTable()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addtable/). 
6. ردیف جدول را حذف کنید. 
7. ستون جدول را حذف کنید. 
8. ارائه تغییر یافته را ذخیره کنید. 

این کد C++ نشان می‌دهد چگونه ردیف یا ستون را از جدول حذف کنید:

```c++
// مسیر به پوشه اسناد.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// یک نمونه از کلاس Presentation ایجاد می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اسلاید اول دسترسی می‌یابد
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض و ردیف‌ها را با ارتفاع تعریف می‌کند
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// یک شکل جدول را به اسلاید اضافه می‌کند
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// سلول‌های (1, 1) و (2, 1) را ترکیب می‌کند
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// سلول‌های (1, 2) و (2, 2) را ترکیب می‌کند
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// ارائه را بر روی دیسک ذخیره می‌کند
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تنظیم قالب‌بندی متن در سطح ردیف جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید و ارائه را بارگذاری کنید, 
2. از طریق شاخص، مرجع یک اسلاید را دریافت کنید. 
3. به شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) مربوطه از اسلاید دسترسی پیدا کنید. 
4. متد [set_FontHeight()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_fontheight/) را برای سلول‌های ردیف اول تنظیم کنید. 
5. متدهای [set_Alignment()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_alignment/) و [set_MarginRight()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_marginright/) را برای سلول‌های ردیف اول تنظیم کنید. 
6. متد [set_TextVerticalType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframeformat/set_textverticaltype/) را برای سلول‌های ردیف دوم تنظیم کنید. 
7. ارائه تغییر یافته را ذخیره کنید. 

این کد C++ عملیات را نشان می‌دهد.

```c++
// یک نمونه از کلاس Presentation ایجاد می‌کند
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// فرض می‌کنیم که اولین شکل در اسلاید اول یک جدول است
// ارتفاع قلم سلول‌های ردیف اول را تنظیم می‌کند
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// تراز متن و حاشیه راست سلول‌های ردیف اول را تنظیم می‌کند
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// نوع عمودی متن سلول‌های ردیف دوم را تنظیم می‌کند
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// ارائه را بر روی دیسک ذخیره می‌کند
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید و ارائه را بارگذاری کنید, 
2. از طریق شاخص، مرجع یک اسلاید را دریافت کنید. 
3. به شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) مربوطه از اسلاید دسترسی پیدا کنید. 
4. متد [set_FontHeight()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_fontheight/) را برای سلول‌های ستون اول تنظیم کنید. 
5. متدهای [set_Alignment()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_alignment/) و [set_MarginRight()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_marginright/) را برای سلول‌های ستون اول تنظیم کنید. 
6. متد [set_TextVerticalType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframeformat/set_textverticaltype/) را برای سلول‌های ستون دوم تنظیم کنید. 
7. ارائه تغییر یافته را ذخیره کنید. 

این کد C++ عملیات را نشان می‌دهد: 

```c++
// یک نمونه از کلاس Presentation ایجاد می‌کند
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// فرض می‌کنیم که اولین شکل در اسلاید اول یک جدول است

// ارتفاع قلم سلول‌های ستون اول را تنظیم می‌کند
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// تراز متن و حاشیه راست سلول‌های ستون اول را در یک فراخوانی تنظیم می‌کند
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// نوع عمودی متن سلول‌های ستون دوم را تنظیم می‌کند
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **دریافت ویژگی‌های استایل جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های استایل یک جدول را بازیابی کنید تا بتوانید این جزئیات را برای جدول دیگری یا در جای دیگری استفاده کنید. این کد C++ نشان می‌دهد چگونه ویژگی‌های استایل را از یک استایل پیش‌تنظیم جدولی دریافت کنید:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**آیا می‌توانم تم‌ها/استایل‌های PowerPoint را به جدول از پیش ساخته شده اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/مستر را به ارث می‌برد و همچنان می‌توانید پرکننده‌ها، حاشیه‌ها و رنگ‌های متن را بر روی آن تم بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را مانند Excel مرتب کنم؟**

خیر، جدول‌های Aspose.Slides قابلیت مرتب‌سازی یا فیلترهای داخلی ندارند. ابتدا داده‌ها را در حافظه مرتب کنید، سپس ردیف‌های جدول را به ترتیب آن پر کنید.

**آیا می‌توانم ستون‌های نواردار (خط‌خط) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص حفظ کنم؟**

بله. ستون‌های نواردار را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول بر استایل جدول اولویت دارد.