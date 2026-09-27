---
title: مرجع API
type: docs
weight: 50
url: /ar/nodejs-net/api-reference/
description: "تم توثيق Aspose.Slides for Node.js عبر .NET بواسطة مرجع API الخاص بـ Aspose.Slides لـ .NET. راجع كيف يتم ربط أسماء الفئات والأعضاء في .NET إلى JavaScript."
---
## **نظرة عامة**

Aspose.Slides for Node.js via .NET لا يمتلك مرجع API خاص به. الحزمة تعرض فئات Aspose.Slides for .NET إلى JavaScript تحت نفس الأسماء، مع أسماء أعضاء بصيغة camelCase، لذا فإن [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) يوثق فئاته، أعضائه وتعداداته.

## **تخطيط أسماء .NET إلى JavaScript**

لاستخدام عضو تجده في مرجع API الخاص بـ .NET، اتبع هذه القواعد:

- **الفئات والتعدادات تحتفظ بأسمائها في .NET**، وكذلك قيم التعداد: `Presentation`، `ShapeType.Rectangle`، `SaveFormat.Pdf`. استوردها من الحزمة: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **الخصائص والطرق تبدأ بحرف صغير**. `Presentation.Slides` تصبح `presentation.slides`، و`ShapeCollection.AddAutoShape` تصبح `shapes.addAutoShape`. تظل الخصائص خصائص: تقرأها وتAssignها بدون أقواس.
- **عناصر المجموعات تُقرأ باستخدام `get(index)`**، وعدد العناصر باستخدام `count`: `presentation.slides.get(0)` بدلًا من `presentation.Slides[0]`.
- **بعض التحميل الزائد يحصل على أسماء منفصلة**. على سبيل المثال، التحميل الزائد `Slide.GetImage(Size)` هو `slide.getImageWithImageSize({ width, height })`. البعض الآخر يشارك طريقة واحدة مع معاملات اختيارية متتالية: `presentation.save(path, format, options, slides)` يغطي عدة تحميلات زائدة لـ `Presentation.Save`، و`new Presentation(null, buffer)` يفتح عرضًا تقديميًا من `Buffer`. كل فئة توجد في ملف واحد داخل مجلد `lib` الخاص بالحزمة (مثلاً، `node_modules/aspose.slides.via.net/lib/Slide.js`)، حيث يمكنك البحث عن الأسماء الدقيقة.
- **أطلق العروض التقديمية باستخدام `dispose`** عندما تنتهي منها؛ JavaScript لا يملك بيان `using`.

الحزمة لا تغلف كل عضو في .NET. إذا كان عضو من مرجع API .NET غير موجود في ملف الفئة، فهو غير متاح في JavaScript.

## **مثال**

النص البرمجي التالي يستخدم القواعد أعلاه. كل تعليق يُظهر استدعاء .NET الذي يتطابق مع السطر التالي. يضيف مستطيلًا بنص إلى الشريحة الأولى، يرسم الشريحة كصورة PNG بحجم 960 × 540 بكسل، ويحفظ العرض التقديمي كملف PDF. شغّله من مجلد مشروع حيث تم تثبيت الحزمة كما هو موضح في [Installation](/slides/ar/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

النص البرمجي يكتب `slide.png` و`slide.pdf` إلى المجلد الحالي. كلاهما يعرض المستطيل مع نصه. بدون ترخيص، سيظهران أيضًا علامة مائية توضيحية؛ راجع [Licensing](/slides/ar/nodejs-net/licensing/).

لمزيد من التفاصيل حول الأعضاء المستخدمة هنا، راجع [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/)، [TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) و[Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) في مرجع API الخاص بـ Aspose.Slides for .NET.