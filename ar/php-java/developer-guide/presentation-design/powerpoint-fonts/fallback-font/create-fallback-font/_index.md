---
title: إنشاء خط احتياطي
type: docs
weight: 10
url: /php-java/create-fallback-font/
---

تدعم Aspose.Slides واجهة [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) وفئة [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) لتحديد القواعد لتطبيق خط احتياطي. تمثل فئة [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) ارتباطًا بين النطاق المحدد لرموز اليونيكود، المستخدم للبحث عن الرموز المفقودة، وقائمة بالخطوط التي قد تحتوي على الرموز الصحيحة:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);

```

من الممكن أيضًا [إزالة](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) الخط الاحتياطي أو [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) الموجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) عندما تكون هناك حاجة لتحديد قواعد استبدال الخط الاحتياطي لعدة نطاقات من رموز اليونيكود.

{{% alert color="primary" title="أنظر أيضاً" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/php-java/create-fallback-fonts-collection/)
{{% /alert %}}