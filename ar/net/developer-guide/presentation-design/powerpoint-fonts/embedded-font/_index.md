---
title: الخطوط المدمجة - واجهة برمجة تطبيقات PowerPoint C#
linktitle: الخطوط المدمجة
type: docs
weight: 40
url: /ar/net/embedded-font/
keywords:
- الخطوط
- الخطوط المدمجة
- إضافة خطوط
- PowerPoint
- تقديم
- C#
- Csharp
- Aspose.Slides for .NET
description: "استخدم الخطوط المدمجة في عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

**الخطوط المدمجة في PowerPoint** مفيدة عندما تريد أن تظهر عرضك التقديمي بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا كنت قد استخدمت خطًا طرفًا أو غير قياسي لأنك كنت مبدعًا في عملك، فلد لديك أسباب أكثر لإدراج خطك. بخلاف ذلك (بدون خطوط مدمجة)، قد تتغير النصوص أو الأرقام على الشرائح الخاصة بك، والتنسيق، والتصميم، وما إلى ذلك، أو تتحول إلى مستطيلات مربكة.

تحتوي فئة [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) وفئة [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) وفئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) وواجهاتهم على معظم الخصائص والأساليب التي تحتاجها للعمل مع الخطوط المدمجة في عروض PowerPoint التقديمية.

## **الحصول على الخطوط المدمجة أو إزالتها من العرض التقديمي**

يوفر Aspose.Slides طريقة [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) (المكشوفة بواسطة فئة [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)) للسماح لك بالحصول على (أو معرفة) الخطوط المدمجة في عرض تقديمي. لإزالة الخطوط، يتم استخدام طريقة [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) (المكشوفة بواسطة نفس الفئة).

تظهر لك الشفرة C# التالية كيفية الحصول على الخطوط المدمجة وإزالتها من عرض تقديمي:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // يقوم بعرض شريحة تحتوي على إطار نص يستخدم الخط المدمج "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // يبحث عن خط "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // يزيل خط "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // يقوم بعرض العرض التقديمي؛ يتم استبدال خط "Calibri" بخط موجود
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // يحفظ العرض التقديمي بدون خط "Calibri" المدمج على القرص
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **إضافة خطوط مدمجة إلى العرض التقديمي**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) واثنين من التحميلات الزائدة لطريقة [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) ، يمكنك اختيار القاعدة المفضلة لديك (للدمج) لإدراج الخطوط في عرض تقديمي. تظهر لك الشفرة C# التالية كيفية إدراج وإضافة الخطوط إلى عرض تقديمي:

```c#
// تحميل العرض التقديمي
Presentation presentation = new Presentation("Fonts.pptx");

// تحميل الخط المصدر ليتم استبداله
IFontData sourceFont = new FontData("Arial");


IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// حفظ العرض التقديمي على القرص
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **ضغط الخطوط المدمجة**

للسماح لك بضغط الخطوط المدمجة في عرض تقديمي وتقليل حجم ملفه، يقدم Aspose.Slides طريقة [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) (المكشوفة بواسطة فئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)).

تظهر لك الشفرة C# التالية كيفية ضغط الخطوط المدمجة في PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```