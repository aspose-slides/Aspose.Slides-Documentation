---
title: تخصيص خطوط PowerPoint في .NET
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/net/custom-font/
keywords:
- خط
- خط مخصص
- خط خارجي
- تحميل خط
- إدارة الخطوط
- مجلد الخطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "خصص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides لـ .NET للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---

{{% alert color="primary" %}} 

يتيح Aspose Slides لك تحميل هذه الخطوط باستخدام الطريقة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

يتيح Aspose.Slides لك تحميل الخطوط التي يتم عرضها في العروض التقديمية دون الحاجة لتثبيتها. يتم تحميل الخطوط من دليل مخصص. 

1. أنشئ مثيلاً لفئة [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) واستدعِ الطريقة [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. حمِّل العرض التقديمي الذي سيُعرض.
3. امسح الذاكرة المؤقتة في فئة [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

هذا الكود C# يوضح عملية تحميل الخط:
``` csharp
// مسار مجلد المستندات
string dataDir = "C:\\";

// المجلدات للبحث عن الخطوط
String[] folders = new String[] { dataDir };

// يقوم بتحميل خطوط دليل الخطوط المخصصة
FontsLoader.LoadExternalFonts(folders);

// قم ببعض العمل وأجرِ عرض تقديمي/شريحة
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// يمسح ذاكرة الخط المؤقتة
FontsLoader.ClearCache();
```


## **الحصول على مجلد الخطوط المخصصة**

يوفر Aspose.Slides الطريقة [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) لتحديد مجلدات الخطوط. ترجع هذه الطريقة المجلدات التي تمت إضافتها عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

هذا الكود C# يوضح كيفية استخدام [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):
```c#
// هذا السطر يعرض المجلدات التي يتم فحصها لملفات الخطوط.
// هذه هي المجلدات التي تم إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**

يوفر Aspose.Slides الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) لتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

هذا الكود C# يوضح كيفية استخدام الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // العمل مع العرض التقديمي
    // CustomFont1، CustomFont2، والخطوط من مجلدي assets\fonts و global\fonts ومجلداتهما الفرعية متاحة للعرض التقديمي
}
```


## **إدارة الخطوط خارجيًا**

يوفر Aspose.Slides الطريقة [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) لتحميل الخطوط الخارجية من بيانات ثنائية.

هذا الكود C# يوضح عملية تحميل الخط من مصفوفة بايت:
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // تم تحميل الخط الخارجي خلال عمر العرض التقديمي
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **الأسئلة الشائعة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. يتم استخدام الخطوط المتصلة من قبل المُعالج عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للعرض لا يعني تضمينه في ملف PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض، يجب عليك استخدام ميزات [embedding features](/slides/ar/net/embedded-font/).

**هل يمكنني التحكم في سلوك الفallback عندما يفتقر الخط المخصص إلى بعض الأحرف؟**

نعم. قم بتكوين [font substitution](/slides/ar/net/font-substitution/)، [replacement rules](/slides/ar/net/font-replacement/)، و[fallback sets](/slides/ar/net/fallback-font/) لتحديد الخط الذي سيُستخدم عندما تكون الأحرف المطلوبة غير موجودة.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. أشِر إلى مجلدات الخطوط الخاصة بك أو حمِّل الخطوط من مصفوفات بايت. هذا يُزيل أي اعتماد على مجلدات الخطوط النظامية في صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص بدون قيود؟**

أنت المسؤول عن توافق ترخيص الخط. الشروط تختلف؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. دائمًا راجع اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.