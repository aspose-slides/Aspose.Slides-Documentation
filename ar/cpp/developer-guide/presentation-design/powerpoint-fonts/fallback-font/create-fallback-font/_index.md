---
title: تحديد خطوط التعويض للعرض التقديمي في C++
linktitle: خط التعويض
type: docs
weight: 10
url: /ar/cpp/create-fallback-font/
keywords:
- خط التعويض
- قاعدة التعويض
- تطبيق الخط
- استبدال الخط
- نطاق Unicode
- الرمز المفقود
- الرمز الصحيح
- PowerPoint
- OpenDocument
- العرض التقديمي
- C++
- Aspose.Slides
description: "تعرّف على Aspose.Slides للغة C++ لتعيين خطوط التعويض في ملفات PPT و PPTX و ODP، مما يضمن عرض النص بشكل متسق على أي جهاز أو نظام تشغيل."
---

## **قواعد التعويض**

يدعم Aspose.Slides واجهة [IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) وفئة [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) لتحديد القواعد لتطبيق خط تعويض. فئة [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) تمثّل ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الرموز المفقودة، وقائمة من الخطوط التي قد تحتوي على الرموز الصحيحة:
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


يمكن أيضًا [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) خط التعويض أو [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) في كائن [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) الموجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)، عندما يكون هناك حاجة إلى تحديد قواعد استبدال خطوط التعويض لمجموعة متعددة من نطاقات Unicode.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط التعويض](/slides/ar/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين خط التعويض، واستبدال الخط، وتضمين الخط؟**

يُستخدم خط التعويض فقط للأحرف المفقودة في الخط الأساسي. [Font substitution](/slides/ar/cpp/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [Font embedding](/slides/ar/cpp/embedded-font/) يضمّن الخطوط داخل ملف الإخراج حتى يتمكن المستلمون من عرض النص كما هو مقصود.

**هل يتم تطبيق خطوط التعويض أثناء التصدير مثل PDF أو PNG أو SVG، أم فقط عند العرض على الشاشة؟**

نعم. يؤثر التعويض على جميع [rendering and export operations](/slides/ar/cpp/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط المصدر.

**هل يغير تكوين التعويض ملف العرض نفسه، وهل سيستمر الإعداد عند الفتحات المستقبلية؟**

لا. قواعد التعويض هي إعدادات عرض وقت التشغيل في التعليمات البرمجية الخاصة بك؛ فهي لا تُخزن داخل ملف .pptx ولا تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة أدلة الخطوط على اختيار التعويض؟**

نعم. يقوم المحرك باستخراج الخطوط من المجلدات النظامية المتاحة وأي [additional paths](/slides/ar/cpp/custom-font/) تقدمها. إذا لم يكن الخط متاحًا فعليًا، لا يمكن لقاعدة تشير إليه أن تُطبّق.

**هل يعمل التعويض مع WordArt وSmartArt والرسوم البيانية؟**

نعم. عندما تحتوي هذه الكائنات على نص، يُطبّق نفس آلية استبدال الرموز لعرض الأحرف المفقودة.