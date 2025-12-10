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
- تحميل الخط
- إدارة الخطوط
- مجلد الخطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides لـ .NET للحفاظ على عروضك التقديمية واضحة ومتسقة عبر أي جهاز."
---

{{% alert color="primary" %}}

يتيح Aspose Slides تحميل هذه الخطوط باستخدام الطريقة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* خطوط TrueType (.ttf) و TrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

يتيح Aspose.Slides تحميل الخطوط التي يتم عرضها في العروض التقديمية دون الحاجة إلى تثبيتها. يتم تحميل الخطوط من دليل مخصص.

1. أنشئ مثالًا من الفئة [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) واستدعِ الطريقة [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. حمّل العرض التقديمي الذي سيتم عرضه.
3. امسح الذاكرة المؤقتة في فئة [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

يعرض هذا الكود C# عملية تحميل الخطوط:
``` csharp
// مسار مجلد المستندات
string dataDir = "C:\\";
// مجلدات للبحث عن الخطوط
String[] folders = new String[] { dataDir };
// تحميل خطوط مجلد الخطوط المخصص
FontsLoader.LoadExternalFonts(folders);
// القيام ببعض العمل وتنفيذ عرض تقديمي/شريحة
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);
// مسح ذاكرة التخزين المؤقت للخطوط
FontsLoader.ClearCache();
```


## **الحصول على مجلدات الخطوط المخصصة**

توفر Aspose.Slides الطريقة [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) لتسمح لك بالعثور على مجلدات الخطوط. تُرجع هذه الطريقة المجلدات التي أضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يعرض هذا الكود C# كيفية استخدام [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):
```c#
 // يطبع هذا السطر المجلدات التي يتم فحصها لملفات الخطوط.
 // هذه هي المجلدات التي أضيفت عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**

توفر Aspose.Slides الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) لتسمح لك بتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

يعرض هذا الكود C# كيفية استخدام الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // العمل مع العرض التقديمي
    // خطوط CustomFont1 و CustomFont2 والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
}
```


## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides الطريقة [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) لتسمح لك بتحميل الخطوط الخارجية من بيانات ثنائية.

يعرض هذا الكود C# عملية تحميل الخط من مصفوفة بايت:
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // خط خارجي تم تحميله خلال مدة عرض العرض التقديمي
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. تُستخدم الخطوط المتصلة بواسطة المحرك عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للعرض لا يعني تضمينه في ملف PPTX. إذا كنت بحاجة إلى تضمين الخط داخل ملف العرض، يجب عليك استخدام ميزات [embedding features](/slides/ar/net/embedded-font/).

**هل يمكنني التحكم في سلوك العودة عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. قم بتكوين [font substitution](/slides/ar/net/font-substitution/)، [replacement rules](/slides/ar/net/font-replacement/)، و[fallback sets](/slides/ar/net/fallback-font/) لتحديد الخط الذي سيُستخدم عندما تكون الرموز المطلوبة غير موجودة.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. يمكنك الإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات بايت. هذا يزيل أي اعتماد على مجلدات الخطوط النظامية داخل صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الالتزام بتراخيص الخطوط. تختلف الشروط؛ بعض الترخيصات تحظر التضمين أو الاستخدام التجاري. تأكد دائمًا من مراجعة اتفاقية ترخيص المستخدم النهائي (EULA) للخط قبل توزيع المخرجات.