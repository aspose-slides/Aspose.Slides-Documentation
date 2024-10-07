---
title: إنشاء خط احتياطي
type: docs
weight: 10
url: /cpp/create-fallback-font/
---

تدعم Aspose.Slides واجهة [IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) وفئة [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) لتحديد القواعد لتطبيق خط احتياطي. تمثل فئة [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) ارتباطًا بين نطاق يونيكود المحدد، المستخدم للبحث عن الرموز المفقودة، وقائمة من الخطوط التي قد تحتوي على الرموز المناسبة:

```cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

من الممكن أيضًا [إزالة](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) الخط الاحتياطي أو [إضافة خطوط احتياطية](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) موجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) عندما تكون هناك حاجة لتحديد قواعد استبدال الخطوط الاحتياطية لمجموعة من نطاقات يونيكود.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/cpp/create-fallback-fonts-collection/)
{{% /alert %}}