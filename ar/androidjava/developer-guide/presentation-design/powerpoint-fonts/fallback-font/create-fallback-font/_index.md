---
title: إنشاء خط احتياطي
type: docs
weight: 10
url: /androidjava/create-fallback-font/
---

تدعم Aspose.Slides واجهة [IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule) و فئة [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) لتحديد القواعد لإضافة خط احتياطي. تمثل فئة [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) ارتباطًا بين نطاقات Unicode المحددة، المستخدمة للبحث عن الرموز المفقودة، وقائمة من الخطوط التي قد تحتوي على رموز مناسبة:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//باستخدام طرق متعددة، يمكنك إضافة قائمة الخطوط:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

من الممكن أيضًا [إزالة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) الخط الاحتياطي أو [addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) موجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) لتنظيم قائمة من [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) الكائنات، عندما تكون هناك حاجة لتحديد قواعد استبدال الخط الاحتياطي لعدة نطاقات Unicode.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}