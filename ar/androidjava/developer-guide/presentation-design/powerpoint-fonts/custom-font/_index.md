---
title: خط PowerPoint مخصص في Java
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/androidjava/custom-font/
keywords: "الخطوط، الخطوط المخصصة، عرض PowerPoint، Java، Aspose.Slides لـ Android عبر Java"
description: "خطوط PowerPoint المخصصة في Java"
---

{{% alert color="primary" %}} 

يسمح Aspose Slides لك بتحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

يسمح Aspose.Slides لك بتحميل الخطوط التي يتم عرضها في العروض التقديمية دون الحاجة إلى تثبيت تلك الخطوط. يتم تحميل الخطوط من دليل مخصص.

1. أنشئ مثيلًا من فئة [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) واستدعاء طريقة [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. قم بتحميل العرض التقديمي الذي سيتم عرضه.
3. [امسح ذاكرة التخزين المؤقت](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) في فئة [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader).

توضح شيفرة Java هذه عملية تحميل الخط:

```java
// المجلدات للبحث عن الخطوط
String[] folders = new String[] { externalFontsDir };

// تحميل خطوط الدليل المخصص
FontsLoader.loadExternalFonts(folders);

// قم ببعض العمل وأداء عرض الشرائح
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // يمسح ذاكرة التخزين المؤقت للخطوط
    FontsLoader.clearCache();
}
```

## **الحصول على مجلد الخطوط المخصصة**
يوفر Aspose.Slides طريقة [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) للسماح لك بالعثور على مجلدات الخطوط. تُرجع هذه الطريقة المجلدات المضافة من خلال طريقة `LoadExternalFonts` و مجلدات الخطوط النظامية.

توضح شيفرة Java هذه كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// يقوم هذا السطر بإخراج المجلدات التي يتم البحث فيها عن ملفات الخطوط.
// هذه هي المجلدات المضافة من خلال طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**
يوفر Aspose.Slides خاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) للسماح لك بتحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

توضح شيفرة Java هذه كيفية استخدام خاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي
    // CustomFont1 و CustomFont2 والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعروض التقديمية
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة الخطوط خارجيًا**

يوفر Aspose.Slides طريقة [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) للسماح لك بتحميل الخطوط الخارجية من بيانات ثنائية.

توضح شيفرة Java هذه عملية تحميل الخطوط من مصفوفة بايت:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // تم تحميل الخط الخارجي أثناء فترة عرض العرض التقديمي
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```