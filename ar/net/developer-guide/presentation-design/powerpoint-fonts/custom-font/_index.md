---
title: خطوط PowerPoint مخصصة في C#
linktitle: خط مخصص
type: docs
weight: 20
url: /net/custom-font/
keywords: "خطوط, خطوط مخصصة, عرض PowerPoint, C#, Csharp, Aspose.Slides لـ .NET"
description: "خطوط PowerPoint مخصصة في C#"
---

{{% alert color="primary" %}} 

تتيح لك Aspose Slides تحميل هذه الخطوط باستخدام [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) الطريقة:

* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل خطوط مخصصة**

تتيح لك Aspose.Slides تحميل الخطوط التي تظهر في العروض دون الحاجة إلى تثبيت تلك الخطوط. يتم تحميل الخطوط من دليل مخصص. 

1. أنشئ مثيلاً لفئة [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) واستدعِ الطريقة [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. قم بتحميل العرض الذي سيتم تقديمه.
3. قم بتفريغ الذاكرة المؤقتة في فئة [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

توضح هذه الشفرة بلغة C# عملية تحميل الخط:

``` csharp
// المسار إلى دليل الوثائق
string dataDir = "C:\\";

// المجلدات للبحث عن الخطوط
String[] folders = new String[] { dataDir };

// تحميل خطوط الدليل المخصص
FontsLoader.LoadExternalFonts(folders);

// القيام ببعض الأعمال وأداء العرض / تقديم الشرائح
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// تفريغ ذاكرة التخزين المؤقت للخطوط
FontsLoader.ClearCache();
```

## **الحصول على مجلد الخطوط المخصصة**
تقدم Aspose.Slides الطريقة [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) لتمكينك من العثور على مجلدات الخطوط. تعيد هذه الطريقة المجلدات التي أُضيفت من خلال الطريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

توضح هذه الشفرة بلغة C# كيفية استخدام [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):

```c#
// تقوم هذه السطر بإخراج المجلدات التي يتم فحصها لملفات الخطوط.
// هذه هي المجلدات التي أُضيفت من خلال الطريقة LoadExternalFonts ومجلدات الخطوط النظامية.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع العرض**
تقدم Aspose.Slides الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) لتمكينك من تحديد الخطوط الخارجية التي ستستخدم مع العرض.

توضح هذه الشفرة بلغة C# كيفية استخدام خاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // العمل مع العرض
    // CustomFont1 و CustomFont2 ، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض
}
```

## **إدارة الخطوط من الخارج**

تقدم Aspose.Slides الطريقة [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) لتمكينك من تحميل الخطوط الخارجية من بيانات ثنائية.

توضح هذه الشفرة بلغة C# عملية تحميل الخط من مصفوفة بايت: 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // تم تحميل الخط الخارجي أثناء دورة حياة العرض
    }
}
finally
{
    FontsLoader.ClearCache();
}
```