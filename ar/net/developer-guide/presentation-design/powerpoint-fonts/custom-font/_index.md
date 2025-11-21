---
title: خط PowerPoint مخصص في C#
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/net/custom-font/
keywords: "خطوط, خطوط مخصصة, عرض PowerPoint, C#, Csharp, Aspose.Slides لـ .NET"
description: "خطوط PowerPoint مخصصة في C#"
---

{{% alert color="primary" %}} 

يسمح Aspose Slides بتحميل هذه الخطوط باستخدام الطريقة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) :

* خطوط TrueType (.ttf) و TrueType Collection (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

يسمح Aspose.Slides بتحميل الخطوط التي يتم عرضها في العروض التقديمية دون الحاجة إلى تثبيت تلك الخطوط. يتم تحميل الخطوط من دليل مخصص. 

1. إنشاء مثيل من الفئة [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) واستدعاء الطريقة [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. تحميل العرض التقديمي الذي سيتم عرضه.
3. مسح التخزين المؤقت في الفئة [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) .

يظهر هذا الكود C# عملية تحميل الخطوط:
``` csharp
// مسار مجلد المستندات
string dataDir = "C:\\";
// مجلدات للبحث عن الخطوط
String[] folders = new String[] { dataDir };

// Loads the custom font directory fonts
FontsLoader.LoadExternalFonts(folders);

// قم ببعض العمل وتنفيذ عرض الشرائح/العرض التقديمي
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// يمسح ذاكرة التخزين المؤقت للخطوط
FontsLoader.ClearCache();
```


## **الحصول على مجلد الخطوط المخصص**
توفر Aspose.Slides الطريقة [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) لتسمح لك بالعثور على مجلدات الخطوط. تُرجع هذه الطريقة المجلدات التي تمت إضافتها عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يظهر هذا الكود C# كيفية استخدام [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) :
```c#
// هذا السطر يطبع المجلدات التي يتم فحصها لملفات الخطوط.
// هذه هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**
توفر Aspose.Slides الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) لتسمح لك بتحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

يظهر هذا الكود C# كيفية استخدام الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) :
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // العمل على العرض التقديمي
    // CustomFont1، CustomFont2، والخطوط من المجلدات assets\\fonts و global\\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
}
```


## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides الطريقة [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) لتحميل الخطوط الخارجية من بيانات ثنائية.

يظهر هذا الكود C# عملية تحميل الخطوط من مصفوفة البايت:
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // خط خارجي تم تحميله أثناء مدة العرض التقديمي
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **الأسئلة الشائعة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)؟**

نعم. تُستخدم الخطوط المتصلة بواسطة المُعالج عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للعرض ليس هو نفسه تضمينه في ملف PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض التقديمي، يجب عليك استخدام [ميزات التضمين](/slides/ar/net/embedded-font/).

**هل يمكنني التحكم في سلوك السقوط عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. يمكنك تكوين [استبدال الخطوط](/slides/ar/net/font-substitution/)، [قواعد الاستبدال](/slides/ar/net/font-replacement/)، و[مجموعات السقوط](/slides/ar/net/fallback-font/) لتحديد الخط الذي سيُستخدم تمامًا عندما تكون الحرف المطلوب مفقودة.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. يمكنك الإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات البايت. هذا يزيل أي اعتماد على دلائل الخطوط النظامية في صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص بدون قيود؟**

أنت مسؤول عن الالتزام بترخيص الخطوط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. احرص دائمًا على مراجعة اتفاقية ترخيص المستخدم النهائي (EULA) للخط قبل توزيع المخرجات.