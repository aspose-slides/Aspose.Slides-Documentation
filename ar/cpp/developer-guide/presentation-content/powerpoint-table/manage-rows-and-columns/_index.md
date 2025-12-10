---
title: إدارة الصفوف والأعمدة في جداول PowerPoint باستخدام C++
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/cpp/manage-rows-and-columns/
keywords:
- صف جدول
- عمود جدول
- الصف الأول
- رأس جدول
- استنساخ صف
- استنساخ عمود
- نسخ صف
- نسخ عمود
- إزالة صف
- إزالة عمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجداول في PowerPoint باستخدام Aspose.Slides لـ C++ وتسريع تحرير العروض التقديمية وتحديث البيانات."
---

للسماح لك بإدارة صفوف وأعمدة جدول في عرض تقديمي لبرنامج PowerPoint، توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) والعديد من الأنواع الأخرى. 

## **تعيين الصف الأول كعنوان**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وتحميل العرض التقديمي. 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) وتعيينه إلى null. 
4. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) للعثور على الجدول المعني. 
5. تعيين الصف الأول للجدول كعنوان. 

يظهر لك هذا الكود بلغة C++ كيفية تعيين الصف الأول للجدول كعنوان:
```c++
// ينشئ كائنًا من فئة Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// الوصول إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يهيئ TableEx كقيمة فارغة
SharedPtr<ITable> tbl;

// يتنقل عبر الأشكال ويضبط مرجعًا إلى الجدول
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// يضبط الصف الأول من الجدول كعنوانه
tbl->set_FirstRow(true);
```



## **استنساخ صف أو عمود من جدول**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. تعريف مصفوفة من `columnWidth`. 
4. تعريف مصفوفة من `rowHeight`. 
5. إضافة كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) إلى الشريحة عبر طريقة [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) . 
6. استنساخ صف الجدول. 
7. استنساخ عمود الجدول. 
8. حفظ العرض التقديمي المعدل. 

يظهر لك هذا الكود بلغة C++ كيفية استنساخ صف أو عمود من جدول PowerPoint:
```c++
 // مسار مجلد المستندات.
const String outPath = u"../out/CloningInTable_out.pptx";

// ينشئ كائنًا من فئة Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// يعرّف الأعمدة بأعرضها والصفوف بارتفاعها
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// يضيف شكل جدول إلى الشريحة
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// يضبط تنسيق الحدود لكل خلية
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

//InsertClone يضيف صفًا في موضع محدد داخل الجدول
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone يضيف عمودًا في نهاية الجدول
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone يضيف عمودًا في موضع محدد داخل الجدول
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// يحفظ العرض التقديمي على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **إزالة صف أو عمود من جدول**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. تعريف مصفوفة من `columnWidth`. 
4. تعريف مصفوفة من `rowHeight`. 
5. إضافة كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) إلى الشريحة عبر طريقة [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) . 
6. إزالة صف الجدول. 
7. إزالة عمود الجدول. 
8. حفظ العرض التقديمي المعدل. 

يظهر لك هذا الكود بلغة C++ كيفية إزالة صف أو عمود من جدول:
```c++
// مسار دليل المستندات.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// ينشئ كائنًا من فئة Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرضها والصفوف بارتفاعها
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// يضيف شكل جدول إلى الشريحة
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// يددمج الخلايا (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// يددمج الخلايا (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// يحفظ العرض التقديمي على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **تعيين تنسيق النص على مستوى صف الجدول**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) المعني من الشريحة. 
4. تعيين ارتفاع الخط للخلية في الصف الأول عبر [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. تعيين محاذاة الخلايا في الصف الأول عبر [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) و[set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. تعيين نوع النص العمودي للخلية في الصف الثاني عبر [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. حفظ العرض التقديمي المعدل. 

هذا الكود بلغة C++ يوضح العملية.
```c++
// ينشئ مثالا من فئة Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// نفترض أن الشكل الأول في الشريحة الأولى هو جدول
// يضبط ارتفاع خط خلايا الصف الأول
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// يضبط محاذاة النص وخط الهوامش اليمنى لخلايا الصف الأول
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// يضبط نوع النص العمودي لخلايا الصف الثاني
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// يحفظ العرض التقديمي على القرص
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```


## **تعيين تنسيق النص على مستوى عمود الجدول**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) المعني من الشريحة. 
4. تعيين ارتفاع الخط للخلية في العمود الأول عبر [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. تعيين محاذاة الخلايا في العمود الأول عبر [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) و[set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. تعيين نوع النص العمودي للخلية في العمود الثاني عبر [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. حفظ العرض التقديمي المعدل. 

هذا الكود بلغة C++ يوضح العملية: 
```c++
// ينشئ مثالا من فئة Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// لنفرض أن الشكل الأول في الشريحة الأولى هو جدول

// يضبط ارتفاع خط خلايا العمود الأول
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// يضبط محاذاة النص والهوامش اليمنى لخلايا العمود الأول في استدعاء واحد
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// يضبط نوع النص العمودي لخلايا العمود الثاني
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```


## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح هذا الكود بلغة C++ كيفية الحصول على خصائص النمط من نمط جدول مسبق الإعداد:
```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه بالفعل؟**

نعم. يتورث الجدول سمة الشريحة/التخطيط/الماستر، ويمكنك مع ذلك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، جداول Aspose.Slides لا تحتوي على فرز أو فلاتر مدمجة. قم بفرز البيانات في الذاكرة أولاً، ثم أعد تعبئة صفوف الجدول وفق ذلك الترتيب.

**هل يمكنني الحصول على أعمدة مخططة (متناوبة) مع الحفاظ على ألوان مخصصة للخلايا المحددة؟**

نعم. قم بتفعيل الأعمدة المخططة، ثم تجاوز خلايا محددة بالتنسيق المحلي؛ التنسيق على مستوى الخلية له أولوية على نمط الجدول.