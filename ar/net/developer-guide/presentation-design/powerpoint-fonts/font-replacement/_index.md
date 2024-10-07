---
title: استبدال الخط - واجهة برمجة التطبيقات PowerPoint C# 
linktitle: استبدال الخط 
type: docs 
weight: 60 
url: /net/font-replacement/ 
keywords: "خط، استبدال الخط، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET" 
description: مع واجهة برمجة التطبيقات PowerPoint C#، يمكنك استبدال الخط بوضوح مع خط آخر باستخدام العرض التقديمي. 
---

إذا قمت بتغيير رأيك بشأن استخدام خط معين، يمكنك استبدال هذا الخط بخط آخر. سيتم استبدال جميع حالات الخط القديم بالخط الجديد.

تسمح لك Aspose.Slides باستبدال خط بهذه الطريقة:

1. تحميل العرض التقديمي المعني.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. استبدال الخط.
5. كتابة العرض التقديمي المعدل كملف PPTX.

توضح هذه الشفرة C# استبدال الخط:

```c#
// يحمل عرض تقديمي 
Presentation presentation = new Presentation("Fonts.pptx");

// يحمل خط المصدر الذي سيتم استبداله 
IFontData sourceFont = new FontData("Arial");

// يحمل الخط الجديد 
IFontData destFont = new FontData("Times New Roman");

// يستبدل الخطوط 
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// يحفظ العرض التقديمي 
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="ملاحظة" color="warning" %}}

لتحديد القواعد التي تحدد ما يحدث في ظروف معينة (إذا لم يكن بالإمكان الوصول إلى خط، على سبيل المثال)، راجع [**استبدال الخط**](/slides/net/font-substitution/).

{{% /alert %}}