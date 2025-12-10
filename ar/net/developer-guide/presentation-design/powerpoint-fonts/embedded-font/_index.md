---
title: "تضمين الخطوط في العروض التقديمية في .NET"
linktitle: "تضمين الخط"
type: docs
weight: 40
url: /ar/net/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخط
- الحصول على خط مضمّن
- إضافة خط مضمّن
- إزالة خط مضمّن
- ضغط خط مضمّن
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تضمين خطوط TrueType في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET، لضمان عرض دقيق عبر جميع المنصات."
---

**تضمين الخطوط في PowerPoint** يضمن أن عرضك التقديمي يحتفظ بمظهره المقصود عبر الأنظمة المختلفة. سواء كنت تستخدم خطوطًا فريدة للإبداع أو خطوطًا قياسية، فإن تضمين الخطوط يمنع تشويه النص والتخطيط.

إذا استخدمت خطًا من طرف ثالث أو غير قياسي لأنك كنت مبدعًا في عملك، فستكون لديك أسباب إضافية لتضمين خطك. وإلا (بدون خطوط مضمَّنة)، قد تتغيّر النصوص أو الأرقام على الشرائح، وكذلك التخطيط، والتنسيق، وما إلى ذلك، إلى مستطيلات مربكة.

استخدم الفئات [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)، [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/)، و[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) لإدارة الخطوط المضمَّنة.

## **الحصول على الخطوط المضمَّنة وإزالتها**

استعد أو أزل الخطوط المضمَّنة من عرض تقديمي بسهولة باستخدام الطريقتين [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) و[RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont).

يعرض هذا الكود C# طريقة الحصول على الخطوط المضمَّنة وإزالتها من عرض تقديمي:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // يعرض شريحة تحتوي على إطار نص يستخدم الخط المضمّن "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // يبحث عن الخط "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // يزيل الخط "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // يعرض العرض التقديمي؛ يتم استبدال الخط "Calibri" بخط موجود
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // يحفظ العرض التقديمي بدون الخط المضمّن "Calibri" على القرص
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **إضافة خطوط مضمَّنة**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) وعمليتي التحميل الزائد للطريقة [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/)، يمكنك اختيار القاعدة (التضمين) المفضلة لتضمين الخطوط في عرض تقديمي. يعرض هذا الكود C# طريقة تضمين وإضافة الخطوط إلى عرض تقديمي:
```c#
// يحمل العرض التقديمي
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// يحفظ العرض التقديمي على القرص
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```


## **ضغط الخطوط المضمَّنة**

حسّن حجم الملف عن طريق ضغط الخطوط المضمَّنة باستخدام [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

مثال على الكود للضغط:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض التقديمي سيظل يُستبدل أثناء العرض بالرغم من التضمين؟**

تحقق من [معلومات الاستبدال](/slides/ar/net/font-substitution/) في مدير الخطوط و[قواعد الاحتياطي/الاستبدال](/slides/ar/net/fallback-font/): إذا كان الخط غير متاح أو مقيد، سيتم استخدام خط احتياطي.

**هل يستحق تضمين الخطوط "النظامية" مثل Arial/Calibri؟**

عادة لا—فهذه الخطوط متاحة تقريبًا دائمًا. لكن لضمان قابلية النقل الكاملة في بيئات "خفيفة" (Docker، خادم لينكس بدون خطوط مثبتة مسبقًا)، قد يزيل تضمين خطوط النظام خطر الاستبدالات غير المتوقعة.