---
title: إنشاء خط احتياطي
type: docs
weight: 10
url: /ar/net/create-fallback-font/
keywords: "الخطوط، خط احتياطي، عرض باوربوينت C#، Csharp، Aspose.Slides لـ .NET"
description: "خط احتياطي في باوربوينت في C# أو .NET"
---

تدعم Aspose.Slides واجهة [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) و [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) لتحديد القواعد لتطبيق خط احتياطي. تمثل فئة [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) ارتباطًا بين النطاق المحدد من يونيكود، المستخدم للبحث عن الرموز المفقودة، وقائمة من الخطوط التي قد تحتوي على الرموز المناسبة:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```



من الممكن أيضًا [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) إزالة الخط الاحتياطي أو [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) الموجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) ، عندما تكون هناك حاجة لتحديد قواعد استبدال الخط الاحتياطي لعدة نطاقات يونيكود.

{{% alert color="primary" title="انظر أيضاً" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/net/create-fallback-fonts-collection/)
{{% /alert %}}