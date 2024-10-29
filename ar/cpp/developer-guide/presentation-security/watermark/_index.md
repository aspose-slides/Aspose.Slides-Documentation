---
title: علامة مائية
type: docs
weight: 40
url: /ar/cpp/watermark/
keywords:
- علامة مائية
- إضافة علامة مائية
- علامة مائية نصية
- علامة مائية صورية
- PowerPoint
- تقديم
- C++
- Aspose.Slides لـ C++
description: "إضافة علامات مائية نصية وصورية إلى عروض PowerPoint في C++"
---

## **حول العلامات المائية**

**العلامة المائية** في عرض تقديمي هي ختم نصي أو صوري يُستخدم على شريحة أو على جميع شرائح العرض التقديمي. عادةً ما تُستخدم العلامة المائية لتشير إلى أن العرض التقديمي مسودة (مثل، علامة مائية "مسودة")، أنه يحتوي على معلومات سرية (مثل، علامة مائية "سري")، لتحديد إلى أي شركة ينتمي (مثل، علامة مائية "اسم الشركة")، لتحديد مؤلف العرض التقديمي، إلخ. تساعد العلامة المائية في منع انتهاكات حقوق الطبع والنشر من خلال الإشارة إلى أنه لا يجب نسخ العرض التقديمي. تُستخدم العلامات المائية في كل من PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى تنسيقات ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/cpp/)، هناك طرق مختلفة يمكنك من خلالها إنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب عليك استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)، ولإضافة علامات مائية صورية، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) أو املأ شكل علامة مائية بصورة. `PictureFrame` ينفذ واجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)، مما يسمح لك باستخدام كافة الإعدادات المرنة لكائن الشكل. نظرًا لأن `ITextFrame` ليس شكلاً وإعداداته محدودة، فإنه يُلف في كائن [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/).

هناك طريقتان يمكن تطبيق علامة مائية: على شريحة واحدة أو على جميع الشرائح في العرض التقديمي. يتم استخدام شريحة المُعلم لتطبيق علامة مائية على جميع الشرائح في العرض التقديمي - يتم إضافة العلامة المائية إلى شريحة المُعلم، وتصميمها بالكامل هناك، وتطبيقها على جميع الشرائح دون التأثير على الإذن بتعديل العلامة المائية على الشرائح الفردية.

تعتبر علامة مائية عادةً غير متاحة للتعديل من قبل المستخدمين الآخرين. لمنع العلامة المائية (أو بالأحرى شكل العلامة المائية) من التعديل، توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على شريحة مُعلم. عندما يتم قفل شكل العلامة المائية على شريحة المُعلم، سيتم قفله على جميع شرائح العرض التقديمي.

يمكنك تعيين اسم للعلامة المائية بحيث، في المستقبل، إذا كنت ترغب في حذفها، يمكنك العثور عليها في أشكال الشريحة بالاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، هناك عادة ميزات شائعة في العلامات المائية، مثل المحاذاة في مركز، والتدوير، والموقع الأمامي، إلخ. سننظر في كيفية استخدام هذه الميزات في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نصي إلى هذا الشكل. يُمثل إطار النص بواسطة واجهة [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/). هذا النوع لا يُورث من [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)، والتي تحتوي على مجموعة واسعة من الخصائص لوضع العلامة المائية بطريقة مرنة. لذلك، يتم لف كائن [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) في كائن [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) كما هو موضح أدناه.

```cpp
auto watermarkText = u"سري";

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

إذا كنت ترغب في إضافة علامة مائية نصية إلى العرض التقديمي بالكامل (أي، جميع الشرائح دفعة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/). تظل بقية المنطق كما هو عند إضافة علامة مائية إلى شريحة واحدة - قم بإنشاء كائن [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ثم أضف العلامة المائية إليه باستخدام طريقة [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"سري";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام شريحة المُعلم](/slides/ar/cpp/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يتم تنسيق الشكل المستطيل بألوان تعبئة وخط. تجعل الأسطر التالية من الكود الشكل شفافًا.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **تعيين الخط لعلامة مائية نصية**

يمكنك تغيير خط النص للعلامة المائية كما هو موضح أدناه.

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

### **مركز علامة مائية نصية**

من الممكن تنسيق العلامة المائية في مركز الشريحة، ومن أجل ذلك، يمكنك القيام بما يلي:

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

تظهر الصورة أدناه النتيجة النهائية.

![علامة مائية نصية](text_watermark.png)

## **علامة مائية صورية**

### **إضافة علامة مائية صورية إلى عرض تقديمي**

لإضافة علامة مائية صورية إلى شريحة عرض تقديمي، يمكنك القيام بما يلي:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **قفل علامة مائية من التعديل**

إذا كان من الضروري منع تعديل علامة مائية، استخدم طريقة [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) على الشكل. باستخدام هذه الخاصية، يمكنك حماية الشكل من التحديد، وتغيير حجمه، وإعادة وضعه، وتجميعه مع عناصر أخرى، وقفل نصه من التعديل، وأكثر من ذلك بكثير:

```cpp
// قفل شكل العلامة المائية من التعديل
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **إحضار علامة مائية إلى المقدمة**

في Aspose.Slides، يمكن تعيين ترتيب Z للأشكال عبر طريقة [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/). للقيام بذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة شرائح العرض التقديمي وتمرير مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة، من الممكن إحضار شكل إلى المقدمة أو إرساله إلى الخلف من الشريحة. هذه الميزة مفيدة بشكل خاص إذا كنت بحاجة إلى وضع علامة مائية في مقدمة العرض التقديمي:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **تعيين دوران العلامة المائية**

إليك مثال على الكود حول كيفية ضبط دوران العلامة المائية بحيث يكون موضعها قطريًا عبر الشريحة:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **تعيين اسم لعلامة مائية**

تسمح لك Aspose.Slides بتعيين اسم لشكل. من خلال استخدام اسم الشكل، يمكنك الوصول إليه في المستقبل من أجل تعديله أو حذفه. لتعيين اسم شكل العلامة المائية، قم بتعيينها إلى طريقة [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"علامة مائية");
```

## **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم طريقة [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) للعثور عليها في أشكال الشريحة. ثم، تمرير شكل العلامة المائية إلى طريقة [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/):

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"علامة مائية", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **مثال مباشر**

قد ترغب في التحقق من **Aspose.Slides المجاني** [إضافة علامة مائية](https://products.aspose.app/slides/watermark) و[إزالة علامة مائية](https://products.aspose.app/slides/watermark/remove-watermark) أدوات الإنترنت.

![أدوات عبر الإنترنت لإضافة وإزالة العلامات المائية](online_tools.png)