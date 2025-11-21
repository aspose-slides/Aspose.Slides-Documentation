---
title: خط مضمّن - PowerPoint JavaScript API
linktitle: خط مضمّن
type: docs
weight: 40
url: /ar/nodejs-java/embedded-font/
keywords: "الخطوط, الخطوط المضمنة, إضافة خطوط, عرض تقديمي PowerPoint, Java, Aspose.Slides لـ Node.js عبر Java"
description: "استخدام الخطوط المضمنة في عرض تقديمي PowerPoint باستخدام JavaScript"
---

**الخطوط المضمنة في PowerPoint** مفيدة عندما تريد أن تظهر عرضك التقديمي بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا استخدمت خطًا من طرف ثالث أو غير قياسي لأنك أبدعت في عملك، فستكون لديك أسباب إضافية لتضمين الخط. وإلا (بدون خطوط مضمنة)، قد تتغير النصوص أو الأرقام على الشرائح، والتخطيط، والتنسيق، وما إلى ذلك، أو تتحول إلى مستطيلات مربكة. 

فئة [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager)، فئة [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) وفئة [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)، وتحتوي فئاتهما على معظم الخصائص والطرق التي تحتاجها للعمل مع الخطوط المضمنة في عروض PowerPoint.

## **الحصول على خطوط مضمنة أو إزالتها من العرض التقديمي**

توفر Aspose.Slides طريقة [getEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (المعروضة من فئة [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager)) لتتيح لك الحصول على (أو معرفة) الخطوط المضمنة في عرض تقديمي. لإزالة الخطوط، تُستخدم طريقة [removeEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (المعروضة من نفس الفئة).

يعرض لك هذا الكود JavaScript كيفية الحصول على الخطوط المضمنة وإزالتها من عرض تقديمي:
```javascript
// يَنشئ كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // يُرْسِم شريحة تحتوي على إطار نص يستخدم الخط المضمَّن "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // يحفظ الصورة على القرص بصيغة JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // يحصل على جميع الخطوط المضمَّنة
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // يبحث عن الخط "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // يزيل الخط "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // يُرْسِم العرض التقديمي؛ يتم استبدال الخط "Calibri" بآخر موجود
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // يحفظ الصورة على القرص بصيغة JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // يحفظ العرض التقديمي بدون الخط المضمَّن "Calibri" على القرص
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة خطوط مدمجة إلى العرض التقديمي**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedfontcharacters/) واثنين من الإصدارات الفائقة لطريقة [addEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-)، يمكنك اختيار قاعدة التضمين المفضلة لتضمين الخطوط في عرض تقديمي. يوضح لك هذا الكود JavaScript كيفية تضمين وإضافة الخطوط إلى عرض تقديمي:
```javascript
// يحمل العرض التقديمي
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // يحفظ العرض التقديمي إلى القرص
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ضغط الخطوط المضمنة**

لتتيح لك ضغط الخطوط المضمنة في عرض تقديمي وتقليل حجمه، توفر Aspose.Slides طريقة [compressEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (المعروضة من فئة [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)).

يعرض لك هذا الكود JavaScript كيفية ضغط خطوط PowerPoint المضمنة:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض التقديمي سيظل يتم استبداله أثناء العرض رغم التضمين؟**

تحقق من [معلومات الاستبدال](/slides/ar/nodejs-java/font-substitution/) في مدير الخطوط و[قواعد الاحتياطي/الاستبدال](/slides/ar/nodejs-java/fallback-font/): إذا كان الخط غير متاح أو مقيد، سيتم استخدام احتياطي.

**هل يستحق تضمين الخطوط "النظامية" مثل Arial/Calibri؟**

عادة لا—فهي متوفرة تقريبًا دائمًا. ولكن لضمان القابلية للتنقل الكامل في بيئات "خفيفة" (Docker، خادم Linux دون خطوط مثبتة مسبقًا)، قد يزيل تضمين خطوط النظام خطر الاستبدالات غير المتوقعة.