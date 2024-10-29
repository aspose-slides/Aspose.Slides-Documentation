---
title: الخطوط المدمجة - واجهة برمجة تطبيقات PowerPoint Java
linktitle: الخطوط المدمجة
type: docs
weight: 40
url: /ar/java/embedded-font/
keywords: "الخطوط، الخطوط المدمجة، إضافة الخطوط، تقديم PowerPoint، Java، Aspose.Slides لـ Java"
description: "استخدم الخطوط المدمجة في تقديم PowerPoint باستخدام Java"

---

**الخطوط المدمجة في PowerPoint** مفيدة عندما ترغب في ظهور تقديمك بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا كنت قد استخدمت خطًا خارجيًا أو غير قياسي لأنك كنت مبدعًا في عملك، فإن لديك أسبابًا أكثر لدمج خطك. بخلاف ذلك (بدون خطوط مدمجة)، قد تتغير النصوص أو الأرقام على الشرائح الخاصة بك، أو التخطيط، أو التنسيق، أو غيرها، أو تتحول إلى مستطيلات محيرة.

فئة [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) ، وفئة [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) ، وفئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) ، وواجهاتها تحتوي على معظم الخصائص والأساليب التي تحتاجها للعمل مع الخطوط المدمجة في تقديمات PowerPoint.

## **الحصول على الخطوط المدمجة أو إزالتها من التقديم**

توفر Aspose.Slides أسلوب [getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (المكشوف بواسطة فئة [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)) لتسمح لك بالحصول على (أو معرفة) الخطوط المدمجة في تقديم. لإزالة الخطوط، يتم استخدام الأسلوب [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (المكشوف بواسطة نفس الفئة).

هذا الكود Java يوضح لك كيفية الحصول على الخطوط المدمجة وإزالتها من تقديم:

```java
// ينشئ كائن Presentation يمثل ملف تقديم
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // يقوم برسم شريحة تحتوي على إطار نصي يستخدم "FunSized" المدمج
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // حفظ الصورة على القرص بتنسيق JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // الحصول على جميع الخطوط المدمجة
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // البحث عن خط "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println("" + embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // إزالة خط "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // يقوم برسم التقديم؛ يتم استبدال خط "Calibri" بخط موجود
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // حفظ الصورة على القرص بتنسيق JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // حفظ التقديم بدون خط "Calibri" المدمج على القرص
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة خطوط مدمجة إلى التقديم**

باستخدام التعداد [EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) وعبورتين من أسلوب [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) ، يمكنك اختيار قاعدتك المفضلة (لعملية الدمج) لدمج الخطوط في التقديم. هذا الكود Java يوضح لك كيفية دمج وإضافة الخطوط إلى التقديم:

```java
// تحميل التقديم
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

    // حفظ التقديم على القرص
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ضغط الخطوط المدمجة**

لتسمح لك بضغط الخطوط المدمجة في التقديم وتقليل حجم الملف، توفر Aspose.Slides الأسلوب [compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (المكشوف بواسطة فئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)).

هذا الكود Java يوضح لك كيفية ضغط الخطوط المدمجة في PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```