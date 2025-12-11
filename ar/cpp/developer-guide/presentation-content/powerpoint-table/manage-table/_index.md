---
title: إدارة جداول العروض التقديمية في C++
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/cpp/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى جدول
- نسبة الأبعاد
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides لـ C++. اكتشف أمثلة شفرات بسيطة لتبسيط سير عمل الجداول."
---

يُعد الجدول في PowerPoint طريقة فعّالة لعرض وتصوير المعلومات. المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) تكون مباشرة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) والفئة [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) والواجهة [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) وأنواع أخرى تسمح لك بإنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية. 

## **إنشاء جدول من الصفر**

1. أنشئ مثيلاً للفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. احصل على مرجع للشرائح من خلال فهرسها.  
3. عرّف مصفوفة `columnWidth`.  
4. عرّف مصفوفة `rowHeight`.  
5. أضف كائنًا من النوع [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) إلى الشريحة عبر الطريقة [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).  
6. كرّر على كل [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) لتطبيق التنسيق على الحدود العليا والسفلى واليمنى واليسرى.  
7. دمج الخليتين الأوليتين في الصف الأول للجدول.  
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) الخاص بـ [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/).  
9. أضف بعض النص إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/).  
10. احفظ العرض التقديمي المعدل.

يظهر هذا الكود C++ كيفية إنشاء جدول في عرض تقديمي:
```c++
// يقوم بإنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
auto pres = System::MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يعرف الأعمدة بعرضها والصفوف بارتفاعها
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
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// يحفظ العرض التقديمي إلى القرص
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **الترقيم في جدول قياسي**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا ويبدأ من الصفر. تُرقم الخلية الأولى في الجدول كـ 0,0 (العمود 0، الصف 0). 

على سبيل المثال، تُرقم الخلايا في جدول يضم 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

يظهر هذا الكود C++ كيفية تحديد الترقيم للخلايا في جدول:
```c++
// يقوم بإنشاء كائن من فئة Presentation يمثل ملف PPTX
auto pres = System::MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرضها والصفوف بارتفاعها
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

// يحفظ العرض التقديمي إلى القرص
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```


## **الوصول إلى جدول موجود**

1. أنشئ مثيلاً للفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  

2. احصل على مرجع للشفرة التي تحتوي على الجدول عبر فهرسها.  

3. أنشئ كائنًا من النوع [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) وضعه كقيمة null.  

4. كرّر عبر جميع كائنات [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) حتى يتم العثور على الجدول.  

   إذا كنت تشك أن الشريحة تحتوي على جدول واحد فقط، يمكنك فحص جميع الأشكال الموجودة فيها. عندما يتم التعرف على شكل كجدول، يمكنك تحويله إلى كائن من النوع [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/). أما إذا كانت الشريحة تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول المطلوب عبر الخاصية [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/).  

5. استخدم كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.  

6. احفظ العرض التقديمي المعدل.

يظهر هذا الكود C++ كيفية الوصول إلى جدول موجود والعمل معه:
```c++
// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// يصل إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يهيئ جدولًا بقيمة null
System::SharedPtr<ITable> tbl;

// يتجول عبر الأشكال ويعين مرجعًا للجدول المُعثر عليه
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// يضبط النص للعمود الأول من الصف الثاني
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// يحفظ العرض التقديمي المعدل إلى القرص
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```


## **محاذاة النص في جدول**

1. أنشئ مثيلاً للفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. احصل على مرجع للشرائح من خلال فهرسها.  
3. أضف كائنًا من النوع [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) إلى الشريحة.  
4. احصل على كائن [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) من الجدول.  
5. احصل على [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) الخاص بـ [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).  
6. محاذاة النص عموديًا.  
7. احفظ العرض التقديمي المعدل.

يظهر هذا الكود C++ كيفية محاذاة النص في جدول:
```c++
// ينشئ كائنًا من فئة Presentation
auto presentation = System::MakeObject<Presentation>();

// يحصل على الشريحة الأولى
auto slide = presentation->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرضها والصفوف بارتفاعها
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// يضيف شكل جدول إلى الشريحة
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// يصل إلى إطار النص
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// ينشئ كائن Paragraph لإطار النص
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// ينشئ كائن Portion للفقرة
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// يضبط محاذاة النص عموديًا
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// يحفظ العرض التقديمي إلى القرص
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```


## **تعيين تنسيق النص على مستوى الجدول**

1. أنشئ مثيلاً للفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. احصل على مرجع للشرائح من خلال فهرسها.  
3. احصل على كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) من الشريحة.  
4. اضبط [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) للنص.  
5. اضبط [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) و [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).  
6. اضبط [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).  
7. احفظ العرض التقديمي المعدل.  

يظهر هذا الكود C++ كيفية تطبيق خيارات التنسيق المفضلة على نص الجدول:
```c++
// ينشئ مثيلاً لفئة Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// يضبط ارتفاع خط خلايا الجدول
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// يضبط محاذاة نص خلايا الجدول والهامش الأيمن في استدعاء واحد
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// yضبط نوع النص العمودي لخلايا الجدول
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```


## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح هذا الكود C++ كيفية الحصول على خصائص النمط من نمط جدول مبدئي:
```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **قفل نسبة الأبعاد للجدول**

نسبة الأبعاد لشكل هندسي هي نسبة أحجامه في الأبعاد المختلفة. توفر Aspose.Slides الخاصية `AspectRatioLocked()` لتسمح لك بقفل إعداد نسبة الأبعاد للجداول والأشكال الأخرى. 

يظهر هذا الكود C++ كيفية قفل نسبة الأبعاد لجدول:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **الأسئلة المتكررة**

**هل يمكنني تفعيل اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يتيح الجدول طريقة [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/)، وتتوفر الفقرة عبر `ParagraphFormat::set_RightToLeft`. يضمن استخدام الطريقتين الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم الجدول في الملف النهائي؟**

استخدم [قفل الأشكال](/slides/ar/cpp/applying-protection-to-presentation/) لتعطيل التحريك، تغيير الحجم، الاختيار، إلخ. تنطبق هذه الأقفال على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [ملء صورة](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمدد أو تكرار).