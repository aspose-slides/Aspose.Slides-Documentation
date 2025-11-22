---
title: تضمين الخطوط في PowerPoint باستخدام C#
linktitle: تضمين الخطوط
type: docs
weight: 40
url: /ar/net/embedded-font/
keywords:
- تضمين الخطوط
- PowerPoint C#
- إضافة الخطوط
- عرض تقديمي
- Aspose.Slides لـ .NET
description: "تعلم كيفية تضمين وإضافة وإدارة الخطوط في عروض PowerPoint باستخدام C# و .NET"
---

**تضمين الخطوط في PowerPoint** يضمن أن عرضك التقديمي يحتفظ بالمظهر المقصود عبر الأنظمة المختلفة. سواءً استخدمت خطوطًا فريدة للإبداع أو خطوطًا قياسية، فإن تضمين الخطوط يمنع اضطراب النص والتخطيط.

إذا استخدمت خطًا من طرف ثالث أو خطًا غير قياسي لأنك أبدعت في عملك، فستكون لديك أسباب إضافية لتضمين الخط. وإلا (بدون خطوط مضمّنة)، قد تتغيّر النصوص أو الأرقام على الشرائح، أو يتغيّر التخطيط، أو تُصبح الأنماط مربّعات مربّقة مربّعة مربّقة مربّعة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة مربّقة

استخدم الفئات [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)، [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/)، و[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) لإدارة الخطوط المضمّنة.

## **الحصول على الخطوط المضمّنة وإزالتها**

استرجع أو احذف الخطوط المضمّنة من العرض التقديمي بسهولة باستخدام طريقتي [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) و[RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont).

هذا الكود بلغة C# يوضح كيفية الحصول على الخطوط المضمّنة وإزالتها من عرض تقديمي:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // يرسم شريحة تحتوي على إطار نص يستخدم الخط المضمن "FunSized"
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

    // يرسم العرض التقديمي؛ يتم استبدال الخط "Calibri" بخط موجود
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // يحفظ العرض التقديمي بدون الخط المضمن "Calibri" إلى القرص
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **إضافة خطوط مضمّنة**

باستخدام عدد التعداد [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) والوظيفتين المتجاوزتين للطريقة [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/)، يمكنك اختيار القاعدة المفضلة (التضمين) لتضمين الخطوط في عرض تقديمي. هذا الكود بلغة C# يوضح كيفية تضمين وإضافة الخطوط إلى عرض تقديمي:
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

// يحفظ العرض التقديمي إلى القرص
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```


## **ضغط الخطوط المضمّنة**

حسّن حجم الملف بضغط الخطوط المضمّنة باستخدام [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

مثال على الكود للضغط:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض التقديمي سيستبدل أثناء العرض على الرغم من التضمين؟**

تحقق من [معلومات الاستبدال](/slides/ar/net/font-substitution/) في مدير الخطوط و[قواعد التعويض/البدائل](/slides/ar/net/fallback-font/): إذا كان الخط غير متوفر أو مقيد، سيتم استخدام بديل.

**هل يستحق تضمين الخطوط "النظامية" مثل Arial/Calibri؟**

عادة لا—فهي متوفرة في معظم الأحيان. لكن لضمان القابلية الكاملة للنقل في بيئات "خفيفة" (Docker، خادم لينكس بدون خطوط مثبتة مسبقًا)، قد يزيل تضمين الخطوط النظامية خطر الاستبدالات غير المتوقعة.