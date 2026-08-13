---
title: إضافة علامات مائية إلى العروض التقديمية بلغة C++
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
description: "إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument التقديمية باستخدام C++ للإشارة إلى مسودة، معلومات سرية، حقوق طبع ونشر، والمزيد."
---
## **المقدمة**

**العلامة المائية** في العرض التقديمي هي طابع نصي أو صورة تُستخدم على شريحة واحدة أو على جميع شرائح العرض. عادةً ما تُستخدم العلامة المائية للإشارة إلى أن العرض مسودة (مثلاً، علامة مائية "مسودة")، أو أنه يحتوي على معلومات سرية (مثلاً، علامة مائية "سري")، لتحديد أي شركة يخصها (مثلاً، علامة مائية "اسم الشركة")، لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية على منع انتهاكات حقوق النشر من خلال الإشارة إلى أن العرض لا يجب نسخه. تُستخدم العلامات المائية في صيغتي PowerPoint وOpenOffice للعرض التقديمي. في Aspose.Slides، يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/ar/cpp/)، هناك طرق متعددة لإنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/)، ولإضافة علامات مائية صورة، استخدم الفئة [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/) أو املأ شكل العلامة المائية بصورة. `PictureFrame` يطبق واجهة [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) مما يتيح لك استخدام جميع الإعدادات المرنة لكائن الشكل. وبما أن `ITextFrame` ليس شكلاً وإعداداته محدودة، يتم تضمينه داخل كائن [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم Slide Master لتطبيق العلامة المائية على جميع شرائح العرض — تُضاف العلامة المائية إلى Slide Master، تُصمم بالكامل هناك، وتُطبق على جميع الشرائح دون التأثير على إمكانية تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تحرير العلامة المائية (أو بالأحرى الشكل الأب للعلامة المائية)، توفر Aspose.Slides وظيفة قفل الأشكال. يمكن قفل شكل معين على شريحة عادية أو على Slide Master. عندما يكون شكل العلامة المائية مقفلاً على Slide Master، سيكون مقفلاً على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية بحيث يمكنك في المستقبل، إذا رغبت في حذفها، العثور عليها بين أشكال الشريحة بالاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، توجد عادةً ميزات شائعة في العلامات المائية مثل المحاذاة في الوسط، الدوران، الموضع الأمامي، إلخ. سنستعرض كيفية استخدام هذه الخصائص في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولًا إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثل إطار النص واجهة [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/). هذا النوع ليس مشتقًا من [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/)، الذي يحتوي على مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بطريقة مرنة. لذلك، يتم تضمين كائن [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) داخل كائن [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [AddTextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/addtextframe/) كما هو موضح أدناه.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="انظر أيضاً" %}} 
- [كيفية استخدام فئة TextFrame](/slides/ar/cpp/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا رغبت في إضافة علامة مائية نصية إلى العرض بأكمله (أي جميع الشرائح دفعة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/masterslide/). يبقى باقي المنطق كما هو عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائنًا من [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) ثم أضف العلامة المائية إليه باستخدام طريقة [AddTextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="انظر أيضاً" %}} 
- [كيفية استخدام Slide Master](/slides/ar/cpp/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يتم تنسيق الشكل المستطيل بألوان تعبئة وخط. السطور التالية من الشيفرة تجعل الشكل شفافًا.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **تعيين الخط لعلامة مائية نصية**

يمكنك تغيير خط العلامة المائية النصية كما هو موضح أدناه.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **تعيين لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم الشيفرة التالية:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **محاذاة العلامة المائية نصيًا في الوسط**

يمكنك محاذاة العلامة المائية في وسط الشريحة، ولتحقيق ذلك يمكنك القيام بما يلي:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

الصورة أدناه توضح النتيجة النهائية.

![العلامة المائية النصية](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى عرض تقديمي**

لإضافة علامة مائية صورة إلى شريحة عرض تقديمي، يمكنك تنفيذ ما يلي:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **قفل علامة مائية من التحرير**

إذا كان من الضروري منع تحرير العلامة المائية، استخدم طريقة [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/get_autoshapelock/) على الشكل. باستخدام هذه الخاصية، يمكنك حماية الشكل من الاختيار، وتغيير الحجم، وإعادة التحديد، وتجميعه مع عناصر أخرى، وقفل نصه من التحرير، وأكثر من ذلك:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// قفل شكل العلامة المائية من التعديل
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **نقل علامة مائية إلى المقدمة**

في Aspose.Slides، يمكن تعيين ترتيب Z للأشكال عبر طريقة [IShapeCollection::Reorder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/reorder/). للقيام بذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة شرائح العرض وتمرير مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة، يمكن نقل الشكل إلى المقدمة أو إرساله إلى الخلفية. هذه الميزة مفيدة بشكل خاص إذا احتجت إلى وضع العلامة المائية أمام محتوى العرض:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **تعيين دوران العلامة المائية**

فيما يلي مثال شفري يوضح كيفية ضبط دوران العلامة المائية بحيث تُوضع قطريًا عبر الشريحة:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **تعيين اسم للعلامة المائية**

تتيح لك Aspose.Slides تعيين اسم لشكل ما. باستخدام اسم الشكل، يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم لشكل العلامة المائية، احرص على تمريره إلى طريقة [IAutoShape::set_Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_name/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم طريقة [IAutoShape::get_Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_name/) للعثور عليه بين أشكال الشريحة. ثم مرر شكل العلامة المائية إلى طريقة [IShapeCollection::Remove](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/remove/):

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **مثال حي**

قد ترغب في تجربة الأدوات المجانية لـ **Aspose.Slides** عبر الإنترنت: [إضافة علامة مائية](https://products.aspose.app/slides/ar/watermark) و[إزالة علامة مائية](https://products.aspose.app/slides/ar/watermark/remove-watermark).

![أدوات عبر الإنترنت لإضافة وإزالة العلامات المائية](online_tools.png)

## **الأسئلة الشائعة**

### ما هي العلامة المائية ولماذا يجب استخدامها؟

العلامة المائية هي طبقة نصية أو صورة تُطبق على الشرائح وتساعد على حماية الملكية الفكرية، وتعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعروض.

### هل يمكنني إضافة علامة مائية إلى جميع الشرائح في العرض؟

نعم، تتيح لك Aspose.Slides إضافة علامة مائية برمجيًا إلى كل شريحة في العرض. يمكنك التجول عبر جميع الشرائح وتطبيق إعدادات العلامة المائية على كل منها بشكل منفصل.

### كيف يمكنني تعديل شفافية العلامة المائية؟

يمكنك تعديل شفافية العلامة المائية عن طريق تعديل إعدادات التعبئة ([FillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/get_fillformat/)) للشكل. يضمن ذلك أن تكون العلامة المائية خفيفة ولا تشوش محتوى الشريحة.

### ما صيغ الصور التي تدعمها العلامات المائية؟

يدعم Aspose.Slides صيغ صور متعددة مثل PNG وJPEG وGIF وBMP وSVG وغيرها.

### هل يمكنني تخصيص خط ونمط العلامة المائية النصية؟

نعم، يمكنك اختيار أي خط، حجم، ونمط لتتناسب مع تصميم عرضك وتحافظ على اتساق العلامة التجارية.

### كيف أغير موضع أو اتجاه العلامة المائية؟

يمكنك تعديل الموضع والاتجاه للعلامة المائية برمجيًا عن طريق تغيير إحداثيات الشكل، حجمه، وخصائص الدوران.