---
title: دمج الخطوط في العروض التقديمية في .NET
linktitle: تضمين الخط
type: docs
weight: 40
url: /ar/net/embedded-font/
keywords:
- إضافة خط
- دمج خط
- دمج الخط
- الحصول على خط مدمج
- إضافة خط مدمج
- إزالة خط مدمج
- ضغط خط مدمج
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "دمج خطوط TrueType في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET، مما يضمن عرضًا دقيقًا عبر جميع المنصات."
---

**Embedding fonts in PowerPoint** يضمن أن تحتفظ عرضك التقديمي بالمظهر المقصود عبر الأنظمة المختلفة. سواء استخدمت خطوطًا فريدة للإبداع أو خطوطًا قياسية، فإن تضمين الخطوط يمنع تشويش النص والتخطيط.

إذا استخدمت خطًا من طرف ثالث أو غير قياسي لأنك أبدعت في عملك، فستكون لديك أسباب إضافية لتضمين الخط. وإلا (بدون خطوط مضمنة)، قد تتغير النصوص أو الأرقام على الشرائح، والتخطيط، والأسلوب، وما إلى ذلك، أو تتحول إلى مستطيلات مربكة. 

استخدم الفئات [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/), و[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) لإدارة الخطوط المضمنة.

## **الحصول على الخطوط المضمنة وإزالتها**

استرجع أو أزل الخطوط المضمنة من عرض تقديمي بسهولة باستخدام الأساليب [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) و[RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont). 

هذا كود C# يوضح كيفية الحصول على الخطوط المضمنة وإزالتها من عرض تقديمي:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // يقوم بإنشاء صورة لشريحة تحتوي على إطار نص يستخدم الخط المضمن "FunSized"
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

    // يقوم بإنشاء صورة للعرض التقديمي؛ يتم استبدال الخط "Calibri" بخط موجود
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // يحفظ العرض التقديمي بدون الخط المضمن "Calibri" على القرص
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **إضافة خطوط مضمنة**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) وطريقتين متجاوزتين من الأسلوب [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/)، يمكنك اختيار القاعدة المفضلة (للتضمين) لتضمين الخطوط في عرض تقديمي. يُظهر لك هذا الكود C# كيفية تضمين وإضافة الخطوط إلى عرض تقديمي:
```c#
 // يقوم بتحميل العرض التقديمي
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

// يحفظ العرض التقديمي إلى القرص
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```


## **ضغط الخطوط المضمنة**

حسّن حجم الملف عن طريق ضغط الخطوط المضمنة باستخدام [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

مثال على الكود للضغط:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض التقديمي سيظل يتم استبداله أثناء العرض بالرغم من التضمين؟**

تحقق من [معلومات الاستبدال](/slides/ar/net/font-substitution/) في مدير الخطوط و[قواعد البديل/الاستبدال](/slides/ar/net/fallback-font/): إذا كان الخط غير متوفر أو مقيد، سيتم استخدام بديل.

**هل من المفيد تضمين خطوط "النظام" مثل Arial/Calibri؟**

عادةً لا—فهذه الخطوط متوفرة تقريبًا دائمًا. ولكن لضمان قابلية النقل الكاملة في بيئات "نحيفة" (Docker، خادم Linux بدون خطوط مثبتة مسبقًا)، يمكن أن يزيل تضمين خطوط النظام خطر الاستبدالات غير المتوقعة.