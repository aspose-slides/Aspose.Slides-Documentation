---
title: إدارة الصفوف والأعمدة
type: docs
weight: 20
url: /cpp/manage-rows-and-columns/
keywords: "جدول، صفوف وأعمدة الجدول، عرض PowerPoint، C++، CPP، Aspose.Slides لـ C++"
description: "إدارة صفوف وأعمدة الجدول في عروض PowerPoint باستخدام C++"

---

للسماح لك بإدارة صفوف وأعمدة جدول في عرض PowerPoint، توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) وواجهة [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) والعديد من الأنواع الأخرى.

## **تعيين الصف الأول كعنوان**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وحمّل العرض التقديمي.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أنشئ كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) واضبطه على null.
4. قم بالاستعراض خلال جميع كائنات [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) للعثور على الجدول المعني.
5. عيّن الصف الأول من الجدول كعنوان له.

هذا الكود C++ يوضح لك كيفية تعيين الصف الأول من الجدول كعنوان له:

```c++
// ينشئ مثيلًا من فئة Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// يصل إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يهيئ TableEx null
SharedPtr<ITable> tbl;

// يتجول بين الأشكال ويضع مرجعًا للجدول
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// يعين الصف الأول من الجدول كعنوان له 
tbl->set_FirstRow(true);
```

## **استنساخ صف أو عمود الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وحمّل العرض التقديمي.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. عرّف مصفوفة من `columnWidth`.
4. عرّف مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) إلى الشريحة من خلال طريقة [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. استنسخ صف الجدول.
7. استنسخ عمود الجدول.
8. احفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح لك كيفية استنساخ صف أو عمود جدول PowerPoint:

```c++
// مسار دليل المستندات.
const String outPath = u"../out/CloningInTable_out.pptx";

// ينشئ مثيلًا من فئة Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرض وارتفاع الصفوف
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

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone يضيف صفًا في نهاية الجدول
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone يضيف صفًا في موضع محدد في الجدول
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone يضيف عمودًا في نهاية الجدول
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone يضيف عمودًا في موضع محدد في الجدول
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);

// يحفظ العرض التقديمي إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **إزالة صف أو عمود من الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وحمّل العرض التقديمي.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. عرّف مصفوفة من `columnWidth`.
4. عرّف مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) إلى الشريحة من خلال طريقة [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. أزل صف الجدول.
7. أزل عمود الجدول.
8. احفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح لك كيفية إزالة صف أو عمود من الجدول:

```c++
// مسار دليل المستندات.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// ينشئ مثيلًا من فئة Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرض وارتفاع الصفوف
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// يضيف شكل جدول إلى الشريحة
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

// يدمج الخلايا (1، 1) × (2، 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// يدمج الخلايا (1، 2) × (2، 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// يحفظ العرض التقديمي إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تعيين تنسيق النص على مستوى صف الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وحمّل العرض التقديمي.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) المعني من الشريحة.
4. عيّن [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) لخلايا الصف الأول.
5. عيّن [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) و [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) لخلايا الصف الأول.
6. عيّن [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) لخلايا الصف الثاني.
7. احفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح العملية:

```c++
// ينشئ مثيلًا من فئة Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
// يعين ارتفاع خط خلايا الصف الأول
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// يعين محاذاة النص و الهامش الأيمن لخلايا الصف الأول
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// يعين نوع النص العمودي لخلايا الصف الثاني
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// يحفظ العرض التقديمي إلى القرص
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **تعيين تنسيق النص على مستوى عمود الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وحمّل العرض التقديمي.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) المعني من الشريحة.
4. عيّن [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) لخلايا العمود الأول.
5. عيّن [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) و [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) لخلايا العمود الأول.
6. عيّن [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) لخلايا العمود الثاني.
7. احفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح العملية:

```c++
// ينشئ مثيلًا من فئة Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// لنفترض أن الشكل الأول في الشريحة الأولى هو جدول

// يعين ارتفاع خط خلايا العمود الأول
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// يعين محاذاة النص والهامش الأيمن لخلايا العمود الأول في استدعاء واحد
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// يعين نوع النص العمودي لخلايا العمود الثاني
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص نمط الجدول حتى تتمكن من استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. هذا الكود C++ يوضح لك كيفية الحصول على خصائص النمط من نمط جدول مسبق:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```