---
title: إنشاء مجموعة خطوط احتياطية
type: docs
weight: 20
url: /ar/cpp/create-fallback-fonts-collection/
---

يمكن تنظيم حالات [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection)، التي تنفذ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection) واجهة. من الممكن إضافة القواعد أو إزالتها من المجموعة.

ثم يمكن تمرير هذه المجموعة إلى [set_FontFallBackRulesCollection() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924)طريقة من [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager) . يتحكم FontsManager في الخطوط عبر العرض. اقرأ المزيد [عن FontsManager وFontsLoader](/slides/ar/cpp/about-fontsmanager-and-fontsloader/).

تحتوي كل [Presentation ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)على [get_FontsManager() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a)طريقة مع مثيل خاص بها من فئة FontsManager.

إليك مثال حول كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها في FontsManager لعرض معين:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

بعد تهيئة FontsManager بمجموعات الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض العرض.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض العرض باستخدام خط احتياطي](/slides/ar/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}