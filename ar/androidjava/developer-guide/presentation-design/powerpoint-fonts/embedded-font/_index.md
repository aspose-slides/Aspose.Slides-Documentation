---
title: الخطوط المدمجة - واجهة برمجة التطبيقات PowerPoint Java
linktitle: الخطوط المدمجة
type: docs
weight: 40
url: /androidjava/embedded-font/
keywords: "الخطوط، الخطوط المدمجة، إضافة خطوط، عرض PowerPoint، Java، Aspose.Slides لـ Android عبر Java"
description: "استخدام الخطوط المدمجة في عرض PowerPoint في Java"

---

**الخطوط المدمجة في PowerPoint** مفيدة عندما تريد أن يظهر عرضك بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا استخدمت خطًا تابعًا لجهة خارجية أو غير قياسي لأنك كنت مبتكرًا في عملك، فأنت لديك مزيد من الأسباب لتضمين خطك. خلاف ذلك (دون خطوط مدمجة)، قد تتغير النصوص أو الأرقام على الشرائح الخاصة بك، أو التخطيط، أو التنسيق، إلخ، أو تتحول إلى مستطيلات مربكة.

تحتوي فئة [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) وفئة [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) وفئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) والواجهات الخاصة بها على معظم الخصائص والأساليب التي تحتاجها للعمل مع الخطوط المدمجة في عروض PowerPoint.

## **الحصول على الخطوط المدمجة أو إزالتها من العرض**

يوفر Aspose.Slides الطريقة [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (المكشوفة بواسطة فئة [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)) للسماح لك بالحصول على (أو معرفة) الخطوط المدمجة في العرض. لإزالة الخطوط، تستخدم الطريقة [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (المكشوفة بواسطة نفس الفئة).

يوضح هذا الكود بلغة Java كيفية الحصول على الخطوط المدمجة وإزالتها من عرض:

```java
// ينشئ كائن Presentation يمثل ملف عرض
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // يقوم بتجسيد شريحة تحتوي على إطار نص يستخدم الخط المدمج "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //يحفظ الصورة على القرص بتنسيق JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // يحصل على جميع الخطوط المدمجة
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // يجد خط "Calibri"
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

    // يقوم بتجسيد العرض؛ يتم استبدال خط "Calibri" بخط موجود
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //يحفظ الصورة على القرص بتنسيق JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // يحفظ العرض بدون خط "Calibri" المدمج على القرص
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة خطوط مدمجة إلى العرض**

باستخدام النوع [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) واثنين من التحميلات الزائدة للطريقة [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) ، يمكنك اختيار قاعدتك المفضلة (للتضمين) لتضمين الخطوط في عرض. يوضح هذا الكود بلغة Java كيفية تضمين وإضافة الخطوط إلى عرض:

```java
// يقوم بتحميل العرض
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

    // يحفظ العرض على القرص
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ضغط الخطوط المدمجة**

لسماح لك بضغط الخطوط المدمجة في عرض وتقليل حجم ملفه، يوفر Aspose.Slides الطريقة [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (المكشوفة بواسطة فئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)).

يوضح هذا الكود بلغة Java كيفية ضغط الخطوط المدمجة في PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```