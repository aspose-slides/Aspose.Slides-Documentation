---
title: استبدال الخط
type: docs
weight: 60
url: /ar/cpp/font-replacement/
keywords: "خط, استبدال الخط, عرض PowerPoint, C++, CPP, Aspose.Slides for C++"
description: "استبدال الخطوط بشكل صريح في PowerPoint باستخدام C++"
---

إذا غيرت رأيك حول استخدام خط ما، يمكنك استبدال ذلك الخط بخط آخر. سيتم استبدال جميع حالات الخط القديم بالخط الجديد.

تسمح لك Aspose.Slides باستبدال خط بهذه الطريقة:

1. تحميل العرض التقديمي المعني.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. استبدال الخط.
5. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود في C++ يوضح استبدال الخط:

``` cpp
// يقوم بتحميل عرض تقديمي
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// يقوم بتحميل الخط المصدر الذي سيتم استبداله
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// يقوم بتحميل الخط الجديد
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// يستبدل الخطوط
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// يقوم بحفظ العرض التقديمي
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="ملاحظة" color="warning" %}} 

لتحديد القواعد التي تحدد ما يحدث في ظروف معينة (على سبيل المثال، إذا لم يمكن الوصول إلى خط ما)، انظر [**استبدال الخط**](/slides/ar/cpp/font-substitution/). 

{{% /alert %}}