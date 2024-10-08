---
title: خط PowerPoint مخصص في Java
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/java/custom-font/
keywords: "الخطوط، الخطوط المخصصة، عرض PowerPoint، Java، Aspose.Slides لـ Java"
description: "خطوط PowerPoint المخصصة في Java"
---

{{% alert color="primary" %}} 

تتيح لك Aspose Slides تحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) ومجموعات TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل خطوط مخصصة**

تتيح لك Aspose.Slides تحميل الخطوط التي يتم عرضها في العروض التقديمية دون الحاجة إلى تثبيت تلك الخطوط. يتم تحميل الخطوط من دليل مخصص.

1. قم بإنشاء مثيل من فئة [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) واستدع الطريقة [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. قم بتحميل العرض التقديمي الذي سيتم عرضه.
3. [امسح الذاكرة المؤقتة](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) في فئة [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

يوضح هذا الرمز بلغة Java عملية تحميل الخط:

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

    // Clears ذاكرة الخط
    FontsLoader.clearCache();
}
```

## **احصل على مجلدات الخطوط المخصصة**
توفر Aspose.Slides الطريقة [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) لتسمح لك بالعثور على مجلدات الخطوط. ترجع هذه الطريقة المجلدات التي تمت إضافتها من خلال طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يوضح هذا الرمز بلغة Java كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// هذه السطر يخرج المجلدات حيث يتم البحث عن ملفات الخطوط.
// تلك هي المجلدات المضافة من خلال طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**
توفر Aspose.Slides الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) لتسمح لك بتحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

يوضح هذا الرمز بلغة Java كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي
    // خط CustomFont1 و CustomFont2 والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعروض التقديمية
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides الطريقة [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) لتسمح لك بتحميل الخطوط الخارجية من البيانات الثنائية.

يوضح هذا الرمز بلغة Java عملية تحميل الخط من مصفوفة البايت:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // تم تحميل الخط الخارجي أثناء فترة العرض التقديمي
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```