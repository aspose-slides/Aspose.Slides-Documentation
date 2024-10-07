---
title: إنشاء خط احتياطي
type: docs
weight: 10
url: /python-net/create-fallback-font/
keywords: "خطوط, خط احتياطي, عرض PowerPoint بايثون, Aspose.Slides لبايثون عبر .NET"
description: "خط احتياطي في PowerPoint بايثون"
---

تدعم Aspose.Slides واجهة [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) و فئة [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) لتحديد القواعد التي تنطبق على خط احتياطي. تمثل فئة [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) ارتباطًا بين نطاق يونيكود المحدد، المستخدم للبحث عن الحروف الناقصة، وقائمة من الخطوط التي قد تحتوي على حروف مناسبة:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#باستخدام طرق متعددة، يمكنك إضافة قائمة الخطوط:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```



من الممكن أيضًا [إزالة()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) الخط الاحتياطي أو [إضافة خطوط احتياطية()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) الموجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) لتنظيم قائمة من [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) الكائنات، عندما تكون هناك حاجة لتحديد قواعد استبدال الخط الاحتياطي لعدة نطاقات يونيكود.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/python-net/create-fallback-fonts-collection/)
{{% /alert %}}