---
title: حل عملي لتغيير حجم المخططات في PPTX
type: docs
weight: 60
url: /cpp/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

لقد لوحظ أن المخططات المدمجة في Excel كعناصر OLE في عرض PowerPoint من خلال مكونات Aspose تتغير أحجامها إلى مقياس غير محدد بعد التنشيط الأول. يؤدي هذا السلوك إلى اختلاف بصري كبير في العرض بين حالات التنشيط المسبق وبعد المخطط. قامت فريق Aspose بمساعدة فريق Microsoft بالتحقيق في هذه المشكلة بشكل مفصل ووجدوا حلاً لهذه المشكلة. تغطي هذه المقالة الأسباب والحل لهذه المشكلة. 

{{% /alert %}} 
## **الخلفية**
في [المقال السابق](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) ، شرحنا كيفية إنشاء مخطط Excel باستخدام Aspose.Cells لـ C++ ثم دمج هذا المخطط في عرض PowerPoint باستخدام Aspose.Slides لـ C++. لاستيعاب مشكلة تغيير الأبعاد، قمنا بتعيين صورة المخطط إلى إطار عنصر OLE للمخطط. في العرض الناتج، عندما نضغط مرتين على إطار عنصر OLE الذي يظهر صورة المخطط، يتم تنشيط مخطط Excel. يمكن للمستخدمين النهائيين إجراء التغيرات المرغوبة في دفتر العمل الفعلي لـ Excel ثم العودة إلى الشريحة المعنية بالنقر خارج دفتر العمل المفعل. سيتغير حجم إطار عنصر OLE عندما يعود المستخدم إلى الشريحة. سيختلف عامل تغيير الحجم لأحجام مختلفة من إطار عنصر OLE ودفتر العمل المدمج لـ Excel.

## **سبب تغيير الحجم**
بما أن دفتر العمل في Excel له حجمه الخاص، فإنه يحاول الاحتفاظ بحجمه الأصلي عند التنشيط الأول. من ناحية أخرى، سيكون لإطار عنصر OLE حجمه الخاص. وفقًا لـ Microsoft، عند تنشيط دفتر العمل في Excel، تتفاوض Excel وPowerPoint على الحجم وتضمن أن تكون الأبعاد صحيحة كجزء من عملية الدمج. بناءً على الفروق في حجم نافذة Excel وحجم/موضع إطار عنصر OLE، يحدث تغيير الحجم. 

## **الحل العملي**
هناك سيناريوهان ممكنان لإنشاء عروض PowerPoint باستخدام Aspose.Slides لـ C++. 

**السيناريو 1:** إنشاء العرض بناءً على قالب موجود.

**السيناريو 2:** إنشاء العرض من الصفر. 

الحل الذي سنقدمه هنا سيكون صالحًا لكلا السيناريوهين. قاعدة جميع نهج الحل ستكون هي نفسها. وهي: **يجب أن يكون حجم نافذة عنصر OLE المدمج هو نفسه حجم إطار عنصر OLE** **في شريحة PowerPoint** . الآن، سنناقش نهجي الحل. 

## **النهج الأول**
في هذا النهج، سنتعلم كيفية تعيين حجم نافذة دفتر العمل المدمج في Excel ليكون مكافئًا لحجم إطار عنصر OLE في شريحة PowerPoint. 

**السيناريو 1** 

لنفرض أننا قمنا بتعريف قالب ونرغب في إنشاء العروض بناءً على هذا القالب. لنفترض أن هناك شكلًا عند الفهرس 2 في القالب حيث نريد وضع إطار OLE يحمل دفتر العمل المدمج في Excel. في هذا السيناريو، سيتم اعتبار حجم إطار عنصر OLE كحجم مسبق الإعداد (وهو حجم الشكل عند الفهرس 2 في القالب). كل ما علينا فعله هو: تعيين حجم نافذة دفتر العمل ليكون مساوياً لحجم الشكل. سيفي المقتطف البرمجي التالي بهذا الغرض: 

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
// تعريف حجم المخطط مع النافذة 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shapes()->idx_get(2);

// تعيين عرض نافذة دفتر العمل بالبوصات (تقسيمه على 72 لأن PowerPoint تستخدم 
// 72 بكسل / بوصة)
wb->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// تعيين ارتفاع نافذة دفتر العمل بالبوصات
wb->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// إنشاء MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream3(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// إنشاء إطار عنصر OLE مع Excel مدمج
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(), 
	shape->get_Height(),
	dataInfo);
```

**السيناريو 2** 

لنقل أننا نريد إنشاء عرض من الصفر ونرغب في إطار عنصر OLE بحجم معين مع دفتر العمل المدمج في Excel. في المقتطف البرمجي التالي، قمنا بإنشاء إطار عنصر OLE بارتفاع 4 بوصة وعرض 9.5 بوصة في الشريحة عند المحور السيني=0.5 بوصة والمحور الصادي=1 بوصة. علاوة على ذلك، قمنا بتعيين حجم نافذة دفتر العمل المكافئ، أي: ارتفاع 4 بوصة وعرض 9.5 بوصة. 

``` cpp
// ارتفاعنا المرغوب
int32_t desiredHeight = 288; //4 بوصة (4 * 72)

// عرضنا المرغوب
int32_t desiredWidth = 684; //9.5 بوصة (9.5 * 72)

// تعريف حجم المخطط مع النافذة 
chart->SetSizeWithWindow(true);

// تعيين عرض نافذة دفتر العمل بالبوصات
wb->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// تعيين ارتفاع نافذة دفتر العمل بالبوصات
wb->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// إنشاء MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// إنشاء إطار عنصر OLE مع Excel مدمج
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f,
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```


## **النهج الثاني**
في هذا النهج، سنتعلم كيفية تعيين حجم المخطط الموجود في دفتر العمل المدمج في Excel ليكون مكافئًا لحجم إطار عنصر OLE في شريحة PowerPoint. هذا النهج مفيد عند معرفة حجم المخطط مسبقًا وأنه لن يتغير أبداً. 

**السيناريو 1** 

لنفرض أننا قمنا بتعريف قالب ونرغب في إنشاء العروض بناءً على هذا القالب. لنفترض أن هناك شكلًا عند الفهرس 2 في القالب حيث نريد وضع إطار OLE يحمل دفتر العمل المدمج في Excel. في هذا السيناريو، سيتم اعتبار حجم إطار OLE كحجم مسبق الإعداد (وهو حجم الشكل عند الفهرس 2 في القالب). كل ما علينا فعله هو: تعيين حجم المخطط في دفتر العمل ليكون مساوياً لحجم الشكل. سيفي المقتطف البرمجي التالي بهذا الغرض: 

``` cpp
// تعريف حجم المخطط بدون نافذة 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shapes()->idx_get(2);

// تعيين عرض المخطط بالبكسل (ضربه في 96 حيث يستخدم Excel 96 بكسل لكل بوصة)    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// تعيين ارتفاع المخطط بالبكسل
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// تعريف حجم طباعة المخطط
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// إنشاء MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// إنشاء إطار عنصر OLE مع Excel مدمج
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(),
	shape->get_Height(),
	dataInfo);
```

**السيناريو 2** 

لنقل أننا نريد إنشاء عرض من الصفر ونرغب في إطار عنصر OLE بأي حجم مع دفتر العمل المدمج في Excel. في المقتطف البرمجي التالي، قمنا بإنشاء إطار عنصر OLE بارتفاع 4 بوصة وعرض 9.5 بوصة في الشريحة عند المحور السيني=0.5 بوصة والمحور الصادي=1 بوصة. علاوة على ذلك، قمنا بتعيين حجم المخطط المكافئ، أي: ارتفاع 4 بوصة وعرض 9.5 بوصة. 

``` cpp
// ارتفاعنا المرغوب
int32_t desiredHeight = 288; // 4 بوصة (4 * 576)

// عرضنا المرغوب
int32_t desiredWidth = 684; // 9.5 بوصة(9.5 * 576)

// تعريف حجم المخطط بدون نافذة 
chart->SetSizeWithWindow(false);

// تعيين عرض المخطط بالبكسل    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// تعيين ارتفاع المخطط بالبكسل    
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// إنشاء MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// إنشاء إطار عنصر OLE مع Excel مدمج
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f, 
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```

## **الخاتمة**
{{% alert color="primary" %}} 

هناك نهجان لحل مشكلة تغيير حجم المخططات. تعتمد اختيار النهج المناسب على المتطلبات وحالة الاستخدام. كلا النمطين يعملان بنفس الطريقة سواء تم إنشاء العروض من قالب أو من الصفر. أيضًا، لا يوجد حد لحجم إطار عنصر OLE في الحل. 

{{% /alert %}} 
## **أقسام ذات صلة**
[إنشاء وإدماج مخطط Excel كعنصر OLE في العرض](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)