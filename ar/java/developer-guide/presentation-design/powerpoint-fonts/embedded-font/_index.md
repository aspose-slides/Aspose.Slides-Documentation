---
title: دمج الخطوط في العروض باستخدام Java
linktitle: دمج الخط
type: docs
weight: 40
url: /ar/java/embedded-font/
keywords:
- إضافة خط
- دمج خط
- دمج الخطوط
- الحصول على الخط المدمج
- إضافة خط مدمج
- إزالة الخط المدمج
- ضغط الخط المدمج
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "دمج خطوط TrueType في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Java، لضمان عرض دقيق عبر جميع المنصات."
---

**Embedded fonts in PowerPoint** مفيدة عندما تريد أن يظهر عرضك التقديمي بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا استخدمت خطًا من طرف ثالث أو غير قياسي لأنك كنت مبدعًا في عملك، فستحصل على مزيد من الأسباب لدمج الخط الخاص بك. أما إذا لم تكن الخطوط مدمجة، فقد يتغير النص أو الأرقام على الشرائح، والتخطيط، والتنسيق، إلخ، أو يتحول إلى مستطيلات مربكة.

تحتوي الفئة [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) والفئة [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) والفئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) وواجهاتها على معظم الخصائص والطرق التي تحتاجها للعمل مع الخطوط المدمجة في عروض PowerPoint التقديمية.

## **الحصول على الخطوط المدمجة وإزالتها**

توفر Aspose.Slides طريقة [getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (المعروضة بواسطة الفئة [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)) للسماح لك بالحصول على (أو معرفة) الخطوط المدمجة في عرض تقديمي. لإزالة الخطوط، تُستخدم طريقة [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (المعروضة بواسطة نفس الفئة).

يُظهر لك هذا الرمز Java كيفية الحصول على الخطوط المدمجة وإزالتها من عرض تقديمي:
```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // يعرض شريحة تحتوي على إطار نص يستخدم الخط المدمج "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // احفظ الصورة إلى القرص بتنسيق JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // يحصل على جميع الخطوط المدمجة
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // يبحث عن خط "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // يزيل خط "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // يعرض العرض التقديمي؛ يتم استبدال خط "Calibri" بآخر موجود
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // احفظ الصورة إلى القرص بتنسيق JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // يحفظ العرض التقديمي بدون خط "Calibri" المدمج إلى القرص
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة الخطوط المدمجة**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) واثنين من التحميل الزائد للطريقة [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-)، يمكنك اختيار القاعدة المفضلة (للدمج) لدمج الخطوط في عرض تقديمي. يُظهر لك هذا الرمز Java كيفية دمج وإضافة الخطوط إلى عرض تقديمي:
```java
// يحمل العرض التقديمي
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // يحفظ العرض التقديمي إلى القرص
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ضغط الخطوط المدمجة**

لتتمكن من ضغط الخطوط المدمجة في عرض تقديمي وتقليل حجمه، توفر Aspose.Slides الطريقة [compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (المعروضة بواسطة الفئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)).

يُظهر لك هذا الرمز Java كيفية ضغط خطوط PowerPoint المدمجة:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض التقديمي سيستبدل أثناء التصيّر بالرغم من دمجه؟**

تحقق من [معلومات الاستبدال](/slides/ar/java/font-substitution/) في مدير الخطوط و[قواعد الاحتياط/الاستبدال](/slides/ar/java/fallback-font/): إذا كان الخط غير متوفر أو مقيد، سيتم استخدام خط احتياطي.

**هل من المجدي دمج الخطوط "النظامية" مثل Arial/Calibri؟**

عادةً لا—فهي متوفرة تقريبًا دائمًا. لكن لتحقيق قابلية نقل كاملة في بيئات "رقيقة" (Docker، خادم Linux دون خطوط مثبتة مسبقًا)، يمكن أن يزيل دمج خطوط النظام خطر الاستبدالات غير المتوقعة.