---
title: دمج الخطوط في العروض التقديمية على Android
linktitle: دمج الخط
type: docs
weight: 40
url: /ar/androidjava/embedded-font/
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
- Android
- Java
- Aspose.Slides
description: "دمج خطوط TrueType في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لنظام Android عبر Java، مع ضمان عرض دقيق على جميع المنصات."
---

**الخطوط المدمجة في PowerPoint** مفيدة عندما تريد أن يظهر العرض التقديمي بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا استخدمت خطًا من طرف ثالث أو غير قياسي لأنك أبدعت في عملك، فستكون لديك أسباب إضافية لدمج الخط. وإلا (بدون خطوط مدمجة)، قد يتغير النص أو الأرقام على الشرائح، أو التخطيط، أو الأنماط، إلخ، أو قد تتحول إلى مستطيلات مربكة.

تحتوي فئة [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) وفئة [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) وفئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) وواجهاتهم على معظم الخصائص والطرق التي تحتاجها للعمل مع الخطوط المدمجة في عروض PowerPoint.

## **الحصول على الخطوط المدمجة وإزالتها**

توفر Aspose.Slides طريقة [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (المعروضة بواسطة فئة [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)) لتسمح لك بالحصول (أو معرفة) الخطوط المدمجة في عرض تقديمي. لإزالة الخطوط، تُستخدم طريقة [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (المعروضة بواسطة نفس الفئة).

هذا الكود بلغة Java يوضح لك كيفية الحصول على الخطوط المدمجة وإزالتها من عرض تقديمي:
```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // يعرض شريحة تحتوي على إطار نصي يستخدم الخط المدمج "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //احفظ الصورة إلى القرص بتنسيق JPEG
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

    // يعرض العرض التقديمي؛ خط "Calibri" يتم استبداله بخط موجود
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //احفظ الصورة إلى القرص بتنسيق JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // يحفظ العرض التقديمي دون الخط المدمج "Calibri" إلى القرص
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```



## **إضافة الخطوط المدمجة**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) وطريقتين مفرطتين من طريقة [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) يمكنك اختيار القاعدة المفضلة (للدمج) لدمج الخطوط في عرض تقديمي. هذا الكود بلغة Java يوضح لك كيفية دمج وإضافة الخطوط إلى عرض تقديمي:
```java
// يحمّل العرض التقديمي
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

لتتمكن من ضغط الخطوط المدمجة في عرض تقديمي وتقليل حجم الملف، توفر Aspose.Slides طريقة [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (المعروضة بواسطة فئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)).

هذا الكود بلغة Java يوضح لك كيفية ضغط الخطوط المدمجة في PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**كيف يمكنني معرفة أن خطًا محددًا في العرض التقديمي سيستبدل أثناء العرض رغم دمجه؟**

تحقق من [معلومات الاستبدال](/slides/ar/androidjava/font-substitution/) في مدير الخطوط و[قواعد الفallback/الاستبدال](/slides/ar/androidjava/fallback-font/): إذا كان الخط غير متوفر أو مقيد، سيتم استخدام بديل.

**هل من المفيد دمج خطوط "النظام" مثل Arial/Calibri؟**

عادةً لا—فهذه الخطوط متوفرة تقريبًا دائمًا. ولكن لتحقيق قابلية نقل كاملة في بيئات "رفيعة" (Docker، خادم Linux بدون خطوط مثبتة مسبقًا)، يمكن أن يزيل دمج خطوط النظام خطر الاستبدالات غير المتوقعة.