---
title: دمج الخطوط في العروض التقديمية باستخدام C++
linktitle: دمج الخط
type: docs
weight: 40
url: /ar/cpp/embedded-font/
keywords:
- إضافة خط
- دمج خط
- دمج الخطوط
- الحصول على الخط المضمن
- إضافة خط مضمّن
- إزالة خط مضمّن
- ضغط خط مضمّن
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "دمج خطوط TrueType في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for C++، لضمان عرض دقيق عبر جميع المنصات."
---
## **مقدمة**

**الخطوط المضمنة في PowerPoint** تساعد على ضمان بقاء مظهر العرض التقديمي كما هو عندما يُفتح على أي نظام أو جهاز. هذا مهم خصوصًا عند استخدام خطوط مخصصة أو من طرف ثالث أو غير قياسية لأغراض العلامة التجارية أو الإبداعية. بدون الخطوط المضمنة، قد يتم استبدال النص، قد تتعطل التخطيطات، وقد تظهر الحروف كرموز غير قابلة للقراءة أو مربعات، مما يضعف التصميم العام.

توفر Aspose.Slides for C++ مجموعة من واجهات برمجة التطبيقات القوية لإدارة الخطوط المضمنة برمجيًا. يمكنك استخدام [FontsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/) و[FontData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontdata/) لفحص، إضافة أو إزالة الخطوط المضمنة في ملفات العرض التقديمي. بالإضافة إلى ذلك، تتيح لك فئة [Compress](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/) تحسين حجم الملف عن طريق ضغط بيانات الخط دون التأثير على الجودة أو المظهر.

توفر هذه الأدوات سيطرة كاملة على تضمين الخطوط، مما يساعدك على الحفاظ على طباعة ثابتة عبر المنصات مع تقليل حجم الملف عند الحاجة.

## **الحصول على الخطوط المضمنة من عرض تقديمي**

توفر Aspose.Slides for C++ الطريقة `GetEmbeddedFonts` من خلال فئة [FontsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/)، والتي تسمح لك باسترداد قائمة الخطوط المضمنة في عرض PowerPoint. يمكن أن يكون هذا مفيدًا لتدقيق استخدام الخطوط، وضمان الالتزام بإرشادات العلامة التجارية، أو التحقق من تضمين جميع الخطوط الضرورية قبل مشاركة الملف.

الكود التالي بلغة C++ يوضح كيفية الحصول على الخطوط المضمنة من ملف عرض تقديمي:

```cpp
// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// الحصول على جميع الخطوط المضمنة.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// طباعة أسماء الخطوط المضمنة.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **إضافة خطوط مضمَّنة إلى عرض تقديمي**

تتيح لك Aspose.Slides for C++ تضمين الخطوط في عرض PowerPoint باستخدام الطريقة [AddEmbeddedFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/addembeddedfont/)، التي تحتوي على overloadين لاستخدام مرن. يمكنك التحكم في مقدار الخط المضمن باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/embedfontcharacters/)، على سبيل المثال اختيار تضمين الأحرف المستخدمة فقط أو مجموعة الخط بالكامل. هذه الميزة مفيدة خاصةً عند إعداد عرض للتشارك أو التوزيع، لضمان ظهور الخطوط المخصصة أو غير القياسية بشكل صحيح على جميع الأنظمة حتى لو لم تكن مثبتة.

الكود التالي بلغة C++ يتحقق من جميع الخطوط المستخدمة في عرض تقديمي، ويضمن أي خطوط غير مضمَّنة بالفعل:

```cpp
// تحميل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // التحقق مما إذا كان الخط مضمّنًا بالفعل.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // دمج الخط في العرض التقديمي.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// حفظ العرض التقديمي إلى القرص.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **إزالة الخطوط المضمنة من عرض تقديمي**

توفر Aspose.Slides for C++ الطريقة `RemoveEmbeddedFont` من خلال فئة [FontsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/)، والتي تمكنك من إزالة خطوط معينة مضمَّنة في عرض PowerPoint. يمكن أن يساعد هذا في تقليل حجم الملف الإجمالي، خاصةً إذا لم تعد الخطوط المضمنة مستخدمة أو لازمة. إزالة الخطوط غير المستخدمة يمكن أيضًا أن يحسن الأداء ويضمن أن العرض يحتوي فقط على الموارد الأساسية.

الكود التالي بلغة C++ يوضح كيفية إزالة خط مضمَّن من عرض تقديمي:

```cpp
auto fontName = u"Calibri";

// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// الحصول على جميع الخطوط المضمنة.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // إزالة الخط المضمن.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **ضغط الخطوط المضمنة**

توفر Aspose.Slides for C++ الطريقة `CompressEmbeddedFonts` من خلال فئة [Compress](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/)، مما يسمح لك بتقليل حجم الملف الكلي للعرض عن طريق تحسين بيانات الخط المضمَّن. هذا مفيد خصوصًا عندما يحتوي العرض على خطوط كبيرة أو متعددة، وتريد الحفاظ على وزن خفيف للملف للمشاركة أو التخزين أو الاستخدام عبر الإنترنت — دون المساس بدقة المحتوى البصري.

الكود التالي بلغة C++ يوضح كيفية ضغط الخطوط المضمَّنة في عرض PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الأسئلة المتداولة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض سيظل مستبدلاً أثناء العرض بالرغم من التضمين؟**

تحقق من [معلومات الاستبدال](/slides/ar/cpp/font-substitution/) في مدير الخطوط و[قواعد التراجع/الاستبدال](/slides/ar/cpp/fallback-font/): إذا كان الخط غير متاح أو مقيد، سيتم استخدام بديل.

**هل يستحق تضمين الخطوط "النظامية" مثل Arial/Calibri؟**

عادة لا — فهي متوفرة تقريبًا دائمًا. لكن لضمان النقل الكامل في بيئات "رقيقة" (Docker، خادم Linux بدون خطوط مثبتة مسبقًا)، قد يساعد تضمين خطوط النظام على القضاء على خطر الاستبدالات غير المتوقعة.