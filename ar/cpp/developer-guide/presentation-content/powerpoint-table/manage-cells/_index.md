---
title: إدارة الخلايا
type: docs
weight: 30
url: /ar/cpp/manage-cells/
keywords: "جدول، خلايا مدمجة، خلايا مقسمة، صورة في خلية جدول، C++، CPP، Aspose.Slides لـ C++"
description: "خلايا الجدول في عروض PowerPoint التقديمية بلغة C++"
---

## **تحديد الخلية المدمجة**
1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على الجدول من الشريحة الأولى.
3. مرر عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. اطبع رسالة عند العثور على الخلايا المدمجة.

هذا الكود بلغة C++ يوضح لك كيفية تحديد خلايا الجدول المدمجة في عرض تقديمي:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// بافتراض أن Slide#0.Shape#0 هو جدول
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} هو جزء من خلية مدمجة مع RowSpan={2} و ColSpan={3} تبدأ من Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **إزالة حدود خلايا الجدول**
1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع شريحة من خلال فهرسها.
3. حدد مصفوفة من الأعمدة بعرض محدد.
4. حدد مصفوفة من الصفوف بارتفاع محدد.
5. أضف جدولا إلى الشريحة من خلال طريقة `AddTable`.
6. مرر عبر كل خلية لمسح الحدود العلوية والسفلية واليمنى واليسرى.
7. احفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة C++ يوضح لك كيفية إزالة الحدود من خلايا الجدول:

``` cpp
// ينشئ مثيل من فئة Presentation التي تمثل ملف PPTX
auto pres = MakeObject<Presentation>();
// يصل إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرض و الصفوف بارتفاع
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// يضيف شكل جدول إلى الشريحة
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// يحدد تنسيق الحدود لكل خلية
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

// يكتب ملف PPTX إلى القرص
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **ترقيم في الخلايا المدمجة**
إذا قمنا بدمج زوجين من الخلايا (1، 1) × (2، 1) و (1، 2) × (2، 2)، فسيتم ترقيم الجدول الناتج. هذا الكود بلغة C# يوضح العملية:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرض و الصفوف بارتفاع
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// يضيف شكل جدول إلى الشريحة
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// يحدد تنسيق الحدود لكل خلية
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
// يدمج الخلايا (1، 1) × (2، 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// يدمج الخلايا (1، 2) × (2، 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// يحفظ ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

ثم نقوم بدمج الخلايا أكثر من خلال دمج (1، 1) و (1، 2). والنتيجة هي جدول يحتوي على خلية مدمجة كبيرة في منتصفه: 

```c++
// المسار إلى دليل الوثائق.
const String outPath = u"../out/MergeCells_out.pptx";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرض و الصفوف بارتفاع
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// يضيف شكل جدول إلى الشريحة
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// يحدد تنسيق الحدود لكل خلية
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

// يدمج الخلايا (1، 1) × (2، 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// يدمج الخلايا (1، 2) × (2، 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// يحفظ ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ترقيم في الخلية المقسمة**
في الأمثلة السابقة، عند دمج خلايا الجدول، لم يتغير الترقيم أو نظام الأرقام في الخلايا الأخرى.

هذه المرة، نأخذ جدولًا عاديًا (جدولًا بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1،1) للحصول على جدول خاص. قد ترغب في الانتباه إلى ترقيم هذا الجدول، والذي قد يعتبر غريبًا. ومع ذلك، هذه هي الطريقة التي ترقم بها Microsoft PowerPoint خلايا الجدول و Aspose.Slides تقوم بنفس الشيء.

هذا الكود بلغة C++ يوضح العملية التي وصفناها:

```c++
// المسار إلى دليل الوثائق.
const String outPath = u"../out/CellSplit_out.pptx";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرض و الصفوف بارتفاع
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// يضيف شكل جدول إلى الشريحة
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// يحدد تنسيق الحدود لكل خلية
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

// يدمج الخلايا (1، 1) × (2، 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// يدمج الخلايا (1، 2) × (2، 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// تقسيم الخلية (1، 1).
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// يحفظ ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تغيير لون خلفية خلية الجدول**

هذا الكود بلغة C++ يوضح لك كيفية تغيير لون خلفية خلية الجدول:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// إنشاء جدول جديد
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// تعيين لون الخلفية لخلية
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **إضافة صورة داخل خلية جدول**
1. قم بإنشاء مثيل من فئة `Presentation`.
2. احصل على مرجع شريحة من خلال فهرسها.
3. حدد مصفوفة من الأعمدة بعرض محدد.
4. حدد مصفوفة من الصفوف بارتفاع محدد.
5. أضف جدولًا إلى الشريحة من خلال طريقة `AddTable`. 
6. قم بإنشاء كائن `Bitmap` لتخزين ملف الصورة.
7. أضف الصورة النقطية إلى كائن `IPPImage`.
8. قم بتعيين `FillFormat` لخلية الجدول إلى `Picture`.
9. أضف الصورة إلى الخلية الأولى في الجدول.
10. احفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة C# يوضح لك كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:

```c++
// المسار إلى دليل الوثائق.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرض و الصفوف بارتفاع
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// يضيف شكل جدول إلى الشريحة
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// يحصل على الصورة
auto img = Images::FromFile(ImagePath);

// يضيف صورة إلى مجموعة صور العرض التقديمي
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// يضيف الصورة إلى الخلية الأولى في الجدول
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// احفظ ملف PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```