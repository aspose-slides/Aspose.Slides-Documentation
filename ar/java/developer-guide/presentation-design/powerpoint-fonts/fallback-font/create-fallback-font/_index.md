---
title: إنشاء خط احتياطي
type: docs
weight: 10
url: /ar/java/create-fallback-font/
---

يدعم Aspose.Slides واجهة [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) وفئة [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) لتحديد القواعد التي تطبق خط احتياطي. تمثل فئة [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) ارتباطًا بين النطاق المحدد من Unicode، المستخدم للبحث عن الرموز المفقودة، وقائمة من الخطوط التي قد تحتوي على الرموز الصحيحة:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "فيديوجيا");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//يمكنك إضافة قائمة الخطوط بعدة طرق:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

من الممكن أيضًا [إزالة](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) خط احتياطي أو [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) الموجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule)، عندما يكون هناك حاجة لتحديد قواعد استبدال الخطوط الاحتياطية لعدة نطاقات من Unicode.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/java/create-fallback-fonts-collection/)
{{% /alert %}}