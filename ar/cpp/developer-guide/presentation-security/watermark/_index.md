---
title: إضافة علامات مائية إلى العروض التقديمية في C++
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/cpp/watermark/
keywords:
- علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- إضافة علامة مائية
- تعديل علامة مائية
- إزالة علامة مائية
- حذف علامة مائية
- إضافة علامة مائية إلى PPT
- إضافة علامة مائية إلى PPTX
- إضافة علامة مائية إلى ODP
- إزالة علامة مائية من PPT
- إزالة علامة مائية من PPTX
- إزالة علامة مائية من ODP
- حذف علامة مائية من PPT
- حذف علامة مائية من PPTX
- حذف علامة مائية من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument باستخدام C++ للإشارة إلى مسودة أو معلومات سرية أو حقوق نشر وغيرها."
---

## **نظرة عامة**

**علامة مائية** في العرض التقديمي هي ختم نصي أو صور يتم استعماله على شريحة أو على جميع شرائح العرض. عادةً تُستخدم العلامة المائية للإشارة إلى أن العرض مسودة (مثال: علامة مائية "مسودة")، أو أنه يحتوي على معلومات سرية (مثال: علامة مائية "سري")، لتحديد الشركة المالكة (مثال: علامة مائية "اسم الشركة")، لتحديد مؤلف العرض، وغيرها. تساعد العلامة المائية على منع انتهاك حقوق النشر عن طريق الإشارة إلى أنه لا ينبغي نسخ العرض. تُستخدم العلامات المائية في صيغ عروض PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/cpp/)، توجد طرق متعددة لإنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)، ولإضافة علامات مائية صور، استخدم الفئة [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) أو املاً شكل العلامة المائية بصورة. تُنفّذ `PictureFrame` واجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) مما يتيح لك استعمال جميع إعدادات الشكل المرنة. نظرًا لأن `ITextFrame` ليس شكلاً وإعداداته محدودة، يتم تغليفه في كائن [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم Slide Master لتطبيق العلامة المائية على جميع الشرائح — تُضاف العلامة المائية إلى Slide Master، تُصمم بالكامل هناك، وتُطبق على جميع الشرائح دون التأثير على صلاحية تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تحرير العلامة المائية (أو شكلها الأب)، يوفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل محدد على شريحة عادية أو على Slide Master. عندما يُقفل شكل العلامة المائية على Slide Master، سيُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية حتى تتمكن في المستقبل، إذا أردت حذفها، من العثور عليها في أشكال الشريحة بالاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، توجد عادةً ميزات شائعة في العلامات المائية مثل المحاذاة الوسطية، الدوران، الموضع الأمامي، إلخ. سنُظهر كيفية استخدام هذه الميزات في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثَّل إطار النص بواجهة [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/). هذا النوع ليس مُوروثًا من [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)، الذي يمتلك مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بطريقة مرنة. لذلك يُغلَّف كائن [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) داخل كائن [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) كما هو موضح أدناه.
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام فئة TextFrame](/slides/ar/cpp/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا أردت إضافة علامة مائية نصية إلى العرض بالكامل (أي جميع الشرائح مرة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/). بقية المنطق هي نفسها كما عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائنًا من [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ثم أضف العلامة المائية باستخدام طريقة [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/).
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام Slide Master](/slides/ar/cpp/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يُصمم الشكل المستطيل بألوان التعبئة والحد. تجعل السطور التالية من الكود الشكل شفافًا.
```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```


### **تعيين الخط للعلامة المائية النصية**

يمكنك تغيير خط العلامة المائية النصية كما هو مبين أدناه.
```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```


### **تعيين لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم هذا الكود:
```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```


### **محاذاة علامة مائية نصية في الوسط**

يمكن مركزية العلامة المائية على الشريحة، وللقيام بذلك يمكنك تنفيذ التالي:
```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```


الصورة أدناه تُظهر النتيجة النهائية.

![علامة مائية نصية](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى عرض تقديمي**

لإضافة علامة مائية صورة إلى شريحة عرض تقديمي، يمكنك القيام بما يلي:
```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```


## **قفل علامة مائية من التحرير**

إذا كان من الضروري منع تحرير العلامة المائية، استخدم طريقة [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) على الشكل. باستخدام هذه الخاصية، يمكنك حماية الشكل من الاختيار، إعادة الحجم، إعادة التوضيع، التجميع مع عناصر أخرى، قفل نصه من التحرير، وأكثر من ذلك:
```cpp
// قفل شكل العلامة المائية من التعديل
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```


## **إحضار علامة مائية إلى المقدمة**

في Aspose.Slides، يمكن ضبط ترتيب Z للأشكال عبر طريقة [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/). للقيام بذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة شرائح العرض وتمرير مرجع الشكل ورقمه الترتيبي إلى الطريقة. بهذه الطريقة، يمكن إحضار شكل إلى المقدمة أو إرساله إلى الخلف. هذه الميزة مفيدة خصوصًا إذا كنت تريد وضع العلامة المائية أمام محتوى العرض:
```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```


## **تعيين دوران العلامة المائية**

فيما يلي مثال على كود لضبط دوران العلامة المائية بحيث تكون مائلة على طول الشريحة:
```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```


## **تعيين اسم للعلامة المائية**

يسمح Aspose.Slides لك بتعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه مستقبلاً لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، اسند القيمة إلى طريقة [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/):
```cpp
watermarkShape->set_Name(u"watermark");
```


## **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم طريقة [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) للعثور عليه ضمن أشكال الشريحة. ثم مرر شكل العلامة المائية إلى طريقة [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/):
```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```


## **مثال حي**

قد ترغب في تجربة أدوات **Aspose.Slides المجانية** عبر الإنترنت: [إضافة علامة مائية](https://products.aspose.app/slides/watermark) و[إزالة علامة مائية](https://products.aspose.app/slides/watermark/remove-watermark).

![أدوات الإنترنت لإضافة وإزالة العلامات المائية](online_tools.png)

## **الأسئلة الشائعة**

**ما هي العلامة المائية ولماذا يجب استخدامها؟**

العلامة المائية هي طبقة نصية أو صورة تُطبق على الشرائح لحماية الملكية الفكرية، تعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعروض.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في عرض تقديمي؟**

نعم، يتيح Aspose.Slides إضافة علامة مائية برمجيًا إلى كل شريحة في العرض. يمكنك التكرار عبر جميع الشرائح وتطبيق إعدادات العلامة المائية على كل واحدة على حدة.

**كيف يمكنني تعديل شفافية العلامة المائية؟**

يمكنك تعديل شفافية العلامة المائية عن طريق تغيير إعدادات التعبئة ([FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_fillformat/)) للشكل. يضمن ذلك أن تكون العلامة المائية خفيفة ولا تشتت انتباه المشاهد عن محتوى الشريحة.

**ما صيغ الصور المدعومة للعلامات المائية؟**

يدعم Aspose.Slides صيغ صور متعددة مثل PNG، JPEG، GIF، BMP، SVG، وغيرها.

**هل يمكنني تخصيص خط ونمط العلامة المائية النصية؟**

نعم، يمكنك اختيار أي خط وحجم ونمط لتتناسب مع تصميم عرضك والحفاظ على تناسق العلامة التجارية.

**كيف أُغيّر موضع أو اتجاه العلامة المائية؟**

يمكنك تعديل موضع واتجاه العلامة المائية برمجيًا عبر تعديل إحداثيات الشكل، حجمه، وخصائص الدوران.