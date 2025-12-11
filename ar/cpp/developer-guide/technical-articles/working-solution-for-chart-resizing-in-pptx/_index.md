---
title: حل عملي لتغيير حجم المخطط في PPTX
type: docs
weight: 60
url: /ar/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغيير حجم المخطط
- مخطط إكسل
- كائن OLE
- تضمين المخطط
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إصلاح تغيير حجم المخطط غير المتوقع في PPTX عند استخدام كائنات OLE مضمّنة من إكسل مع Aspose.Slides للـ C++. تعرف على طريقتين مع الشيفرة للحفاظ على تناسق الأحجام."
---

## ** الخلفية**

تمت ملاحظة أن مخططات إكسل المضمنة ككائنات OLE في عرض PowerPoint عبر مكونات Aspose يتم تغيير حجمها إلى مقياس غير محدد بعد تنشيطها لأول مرة. يتسبب هذا السلوك في اختلاف بصري ملحوظ في العرض بين حالة المخطط قبل وبعد التنشيط. قامت فريق Aspose بالتحقيق في المشكلة بالتفصيل ووجد حلاً. تصف هذه المقالة أسباب المشكلة والإصلاح المقابل.

في [المقال السابق](/slides/ar/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا كيفية إنشاء مخطط إكسل باستخدام Aspose.Cells for C++ وتضمينه في عرض PowerPoint باستخدام Aspose.Slides for C++. لمعالجة [مشكلة معاينة الكائن](/slides/ar/cpp/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة المخطط إلى إطار كائن OLE الخاص بالمخطط. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة المخطط، يتم تنشيط مخطط إكسل. يمكن للمستخدمين إجراء أي تغييرات مرغوبة في دفتر إكسل الأساسي ثم الرجوع إلى الشريحة المقابلة بالنقر خارج دفتر العمل النشط. يتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، وتختلف نسبة إعادة الحجم وفقًا للأحجام الأصلية لكل من إطار كائن OLE ودفتر إكسل المضمن.

## ** سبب تغيير الحجم**

نظرًا لأن دفتر إكسل له حجمه الخاص للنافذة، فإنه يحاول الاحتفاظ بحجمه الأصلي عند التنشيط الأول. ومع ذلك، فإن إطار كائن OLE له حجمه الخاص. وفقًا لمايكروسوفت، عند تنشيط دفتر إكسل، يتفاوض إكسل وPowerPoint على الحجم ويحافظان على النسب الصحيحة كجزء من عملية التضمين. بناءً على الاختلافات بين حجم نافذة إكسل وحجم أو موضع إطار كائن OLE، يحدث تغيير الحجم.

## ** حل عملي**

هناك سيناريوهين محتملين لإنشاء عروض PowerPoint باستخدام Aspose.Slides for C++.

**السيناريو 1:** إنشاء عرض بناءً على قالب موجود.

**السيناريو 2:** إنشاء عرض من الصفر.

الحل الذي نقدمه هنا ينطبق على كلا السيناريوهين. أساس جميع نهج الحل هو نفسه: **يجب أن يتطابق حجم نافذة كائن OLE المضمن مع إطار كائن OLE في شريحة PowerPoint**. سنناقش الآن النهجين لهذا الحل.

## ** النهج الأول**

في هذا النهج، سنتعلم كيفية ضبط حجم نافذة دفتر إكسل المضمن بحيث يتطابق مع حجم إطار كائن OLE في شريحة PowerPoint.

**السيناريو 1**

نفترض أننا حددنا قالبًا ونريد إنشاء عروض بناءً عليه. افترض وجود شكل في الفهرس 2 داخل القالب حيث نريد وضع إطار OLE يحتوي على دفتر إكسل مضمّن. في هذا السيناريو، يكون حجم إطار كائن OLE محددًا مسبقًا—يتطابق مع حجم الشكل في الفهرس 2 في القالب. كل ما علينا فعله هو ضبط حجم نافذة دفتر العمل ليتساوى مع حجم ذلك الشكل. المقتطف البرمجي التالي يحقق ذلك:
```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// حدد حجم المخطط باستخدام نافذة. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// حدد عرض نافذة دفتر العمل بالبوصة (قسم على 72 لأن PowerPoint يستخدم 72 بكسل لكل بوصة).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// حدد ارتفاع نافذة دفتر العمل بالبوصة.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// احفظ دفتر العمل إلى تدفق ذاكرة.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// أنشئ إطار كائن OLE مع بيانات Excel المضمنة.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```


**السيناريو 2**

لنفترض أننا نريد إنشاء عرض من الصفر وإدراج إطار OLE بأي حجم مع دفتر إكسل مضمّن. في المقتطف البرمجي التالي، ننشئ إطار OLE بارتفاع 4 بوصات وعرض 9.5 بوصة عند x = 0.5 بوصة و y = 1 بوصة على الشريحة. ثم نضبط نافذة دفتر إكسل لتكون بنفس الحجم—4 بوصات ارتفاع و9.5 بوصة عرض.
```cpp
// الارتفاع المطلوب.
int32_t desiredHeight = 288; // 4 بوصة (4 * 72)

// العرض المطلوب.
int32_t desiredWidth = 684; // 9.5 بوصة (9.5 * 72)

// حدد حجم المخطط باستخدام نافذة. 
chart->SetSizeWithWindow(true);

// حدد عرض نافذة دفتر العمل بالبوصة.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// حدد ارتفاع نافذة دفتر العمل بالبوصة.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// احفظ دفتر العمل إلى تدفق ذاكرة.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// أنشئ إطار كائن OLE مع بيانات Excel المضمنة.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## ** النهج الثاني**

في هذا النهج، سنتعلم كيفية ضبط حجم المخطط في دفتر إكسل المضمن ليتطابق مع حجم إطار كائن OLE في شريحة PowerPoint. هذا النهج مفيد عندما يكون حجم المخطط معروفًا مسبقًا ولن يتغير.

**السيناريو 1**

نفترض أننا حددنا قالبًا ونريد إنشاء عروض بناءً عليه. افترض وجود شكل في الفهرس 2 داخل القالب حيث نعتزم وضع إطار OLE يحتوي على دفتر إكسل مضمّن. في هذا السيناريو، يكون حجم إطار OLE محددًا مسبقًا—متطابقًا مع حجم الشكل في الفهرس 2. كل ما نحتاجه هو ضبط حجم المخطط في دفتر العمل ليكون مساويًا لحجم الشكل. المقتطف البرمجي التالي يحقق ذلك:
```cpp
// حدد حجم المخطط دون نافذة. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// حدد عرض المخطط بالبكسل (اضرب في 96 لأن Excel يستخدم 96 بكسل لكل بوصة).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// حدد ارتفاع المخطط بالبكسل.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// حدد حجم طباعة المخطط.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// احفظ دفتر العمل إلى تدفق ذاكرة.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Create an OLE object frame with the embedded Excel data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```


**السيناريو 2**

نفترض أننا نريد إنشاء عرض من الصفر وإدراج إطار OLE بأي حجم مع دفتر إكسل مضمّن. في المقتطف البرمجي التالي، ننشئ إطار OLE بارتفاع 4 بوصات وعرض 9.5 بوصة على الشريحة عند x = 0.5 بوصة و y = 1 بوصة. كما نضبط حجم المخطط المقابل إلى نفس الأبعاد: ارتفاع 4 بوصات وعرض 9.5 بوصة.
```cpp
// الارتفاع المطلوب.
int32_t desiredHeight = 288; // 4 بوصة (4 * 576)

// العرض المطلوب.
int32_t desiredWidth = 684; // 9.5 بوصة (9.5 * 576)

// حدد حجم المخطط دون نافذة. 
chart->SetSizeWithWindow(false);

// حدد عرض المخطط بالبكسل.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// حدد ارتفاع المخطط بالبكسل.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// احفظ دفتر العمل إلى تدفق ذاكرة.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// أنشئ إطار كائن OLE مع بيانات Excel المضمنة.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## ** الاستنتاج**

هناك نهجين لإصلاح مشكلة تغيير حجم المخطط. يعتمد اختيار النهج على المتطلبات وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة سواء تم إنشاء العروض من قالب أو من الصفر. أيضًا، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

## ** الأسئلة المتداولة**

**لماذا يتغير حجم مخطط إكسل المضمّن بعد تنشيطه في PowerPoint؟**

يحدث هذا لأن إكسل يحاول استعادة حجم النافذة الأصلي عند التنشيط الأول، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وإكسل على الحجم للحفاظ على نسبة الأبعاد، مما قد يؤدي إلى تغيير الحجم.

**هل يمكن منع هذه المشكلة بالكامل؟**

نعم. من خلال مطابقة حجم نافذة دفتر إكسل أو حجم المخطط مع حجم إطار كائن OLE قبل التضمين، يمكنك الحفاظ على أحجام المخططات ثابتة.

**أي نهج ينبغي أن أختار، ضبط حجم نافذة دفتر العمل أم ضبط حجم المخطط؟**

استخدم **النهج 1 (حجم النافذة)** إذا أردت الحفاظ على نسبة أبعاد دفتر العمل وربما السماح بإعادة الحجم لاحقًا.  
استخدم **النهج 2 (حجم المخطط)** إذا كانت أبعاد المخطط ثابتة ولن تتغير بعد التضمين.

**هل ستعمل هذه الطرق مع العروض القائمة على القوالب والجديدة على حد سواء؟**

نعم. كلا النهجين يعملان بنفس الطريقة للعروض التي تم إنشاؤها من القوالب أو من الصفر.

**هل هناك حد لحجم إطار كائن OLE؟**

لا. يمكنك ضبط إطار OLE لأي حجم طالما أنه يتم تحجيمه بشكل مناسب مع حجم دفتر العمل أو المخطط.

**هل يمكنني استخدام هذه الطرق مع المخططات التي تم إنشاؤها في برامج جدول بيانات أخرى؟**

الأمثلة مصممة لمخططات إكسل التي تم إنشاؤها باستخدام Aspose.Cells، لكن المبادئ تنطبق على برامج جدول بيانات أخرى متوافقة مع OLE طالما تدعم خيارات حجم مماثلة.

## ** أقسام ذات صلة**

- [إنشاء مخططات إكسل وتضمينها ككائنات OLE في العروض](/slides/ar/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)