---
title: إدارة الجدول
type: docs
weight: 10
url: /ar/cpp/manage-table/
keywords: "جدول، إنشاء جدول، الوصول إلى جدول، نسبة عرض إلى ارتفاع الجدول، تقديم PowerPoint، C++، Aspose.Slides لـ C++"
description: "إنشاء وإدارة جدول في تقديمات PowerPoint باستخدام C++"
---

الجدول في PowerPoint هو وسيلة فعالة لعرض وتقديم المعلومات. المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) واضحة وسهلة الفهم.

توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) ، واجهة [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ، فئة [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) ، واجهة [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) ، وأنواع أخرى للسماح لك بإنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. تعريف مصفوفة من `columnWidth`.
4. تعريف مصفوفة من `rowHeight`.
5. إضافة كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) إلى الشريحة من خلال طريقة [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. التكرار عبر كل [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) لتطبيق التنسيق على الحدود العلوية والسفلية واليسرى واليمنى.
7. دمج الخلايا الأوليين من الصف الأول للجدول.
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) الخاصة بـ [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/).
9. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدل.

يوضح هذا الكود C++ كيفية إنشاء جدول في عرض تقديمي:

```c++
// يقوم بإنشاء نسخة من فئة Presentation التي تمثل ملف PPTX
auto pres = System::MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرض وارتفاعات الصفوف
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// يضيف شكل جدول إلى الشريحة
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// يضبط تنسيق الحدود لكل خلية
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
// يدمج الخلايا 1 و 2 من الصف 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// يضيف بعض النص إلى الخلية المدمجة
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"الخلايا المدمجة");

// يحفظ العرض التقديمي على القرص
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **ترقيم في جدول قياسي**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا وقائمًا على الصفر. تُرقم الخلية الأولى في الجدول على أنها 0،0 (عمود 0، صف 0).

على سبيل المثال، تُرقم الخلايا في جدول به 4 أعمدة و4 صفوف على النحو التالي:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

يوضح هذا الكود C++ كيفية تحديد الترقيم للخلايا في جدول:

```c++
// يقوم بإنشاء نسخة من فئة Presentation التي تمثل ملف PPTX
auto pres = System::MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرض وارتفاعات الصفوف
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// يضيف شكل جدول إلى الشريحة
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// يضبط تنسيق الحدود لكل خلية
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

// يحفظ العرض التقديمي على القرص
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **الوصول إلى جدول موجود**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول من خلال فهرسها.
3. إنشاء كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) وتعيينه إلى null.
4. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تشك في أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة التحقق من جميع الأشكال التي تحتوي عليها. عندما يتم تحديد شكل كجدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/). ولكن إذا كانت الشريحة التي تتعامل معها تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول الذي تحتاجه من خلال [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/).

5. استخدم كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.
6. احفظ العرض التقديمي المعدل.

يوضح هذا الكود C++ كيفية الوصول إلى جدول موجود والعمل معه:

```c++
// يقوم بإنشاء نسخة من فئة Presentation التي تمثل ملف PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// يصل إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يبدأ بجدول null
System::SharedPtr<ITable> tbl;

// يتكرر عبر الأشكال ويحدد مرجعًا للجدول الموجود
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// يحدد النص للعمود الأول من الصف الثاني
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"جديد");

// يحفظ العرض التقديمي المعدل على القرص
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **محاذاة النص في الجدول**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) من الجدول.
5. الوصول إلى [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) لـ [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
6. محاذاة النص عموديًا.
7. حفظ العرض التقديمي المعدل.

يوضح هذا الكود C++ كيفية محاذاة النص في جدول:

```c++
// يقوم بإنشاء نسخة من فئة Presentation
auto presentation = System::MakeObject<Presentation>();

// يحصل على الشريحة الأولى
auto slide = presentation->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرض وارتفاعات الصفوف
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// يضيف شكل الجدول إلى الشريحة
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// يصل إلى إطار النص
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// ينشئ كائن الفقرة لإطار النص
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// ينشئ كائن الجزء للفقرة
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"نص هنا");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// يحاذي النص عموديًا
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// يحفظ العرض التقديمي على القرص
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) من الشريحة.
4. تعيين [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) للنص.
5. تعيين [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) و [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. تعيين [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. حفظ العرض التقديمي المعدل.

يوضح هذا الكود C++ كيفية تطبيق خيارات التنسيق المفضلة لديك على النص في جدول:

```c++
// يقوم بإنشاء نسخة من فئة Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// لنفترض أن أول شكل على الشريحة الأولى هو جدول
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// يحدد ارتفاع خط خلية الجدول
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// يحدد محاذاة نص خلية الجدول وهامش اليمين في استدعاء واحد
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// يحدد نوع نص الخلايا العمودي للجدول
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرجاع خصائص النمط لجدول حتى تتمكن من استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. يوضح هذا الكود C++ كيفية الحصول على خصائص النمط من نمط الجدول المعين:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **قفل نسبة عرض الجدول**

نسبة العرض إلى الارتفاع لشكل هندسي هي نسبة أحجامه في أبعاد مختلفة. قدمت Aspose.Slides خاصية `AspectRatioLocked()` للسماح لك بقفل إعداد نسبة العرض إلى الارتفاع للجداول والأشكال الأخرى.

يوضح هذا الكود C++ كيفية قفل نسبة العرض للجدول:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"تم تعيين قفل نسبة العرض: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"تم تعيين قفل نسبة العرض: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```