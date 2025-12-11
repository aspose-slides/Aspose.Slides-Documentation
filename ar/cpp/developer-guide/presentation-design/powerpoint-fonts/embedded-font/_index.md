---
title: دمج الخطوط في العروض التقديمية باستخدام C++
linktitle: دمج الخط
type: docs
weight: 40
url: /ar/cpp/embedded-font/
keywords:
- إضافة خط
- دمج خط
- دمج خطوط
- الحصول على خط مدمج
- إضافة خط مدمج
- إزالة خط مدمج
- ضغط خط مدمج
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "دمج خطوط TrueType في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ C++، لضمان عرض دقيق عبر جميع المنصات."
---

## **نظرة عامة**

**Embedded fonts in PowerPoint** تساعد في ضمان أن العرض التقديمي الخاص بك يحتفظ بالمظهر المقصود عند فتحه على أي نظام أو جهاز. هذا مهم بشكل خاص عند استخدام خطوط مخصصة أو خطوط من طرف ثالث أو خطوط غير قياسية لأغراض العلامة التجارية أو الإبداعية. بدون الخطوط المدمجة، قد يتم استبدال النص، ويمكن أن تتعطل التخطيطات، وقد تظهر الأحرف كرموز غير قابلة للقراءة أو مستطيلات، مما يضعف التصميم العام.

Aspose.Slides for C++ يوفر مجموعة قوية من واجهات برمجة التطبيقات لإدارة الخطوط المدمجة برمجيًا. يمكنك استخدام [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) و[FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/) لاستعراض، إضافة أو إزالة الخطوط المدمجة في ملفات العرض التقديمي. بالإضافة إلى ذلك، تسمح لك فئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) بتحسين حجم الملف عن طريق ضغط بيانات الخط دون التأثير على الجودة أو المظهر.

هذه الأدوات تمنحك تحكمًا كاملاً في دمج الخطوط، مما يساعدك على الحفاظ على طباعة متسقة عبر المنصات مع تقليل حجم الملف عند الحاجة.

## **الحصول على الخطوط المدمجة من عرض تقديمي**

Aspose.Slides for C++ يوفر طريقة `GetEmbeddedFonts` عبر فئة [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) التي تتيح لك استرجاع قائمة بالخطوط المدمجة في عرض PowerPoint. يمكن أن يكون ذلك مفيدًا لتدقيق استخدام الخطوط، وضمان الالتزام بإرشادات العلامة التجارية، أو التحقق من أن جميع الخطوط الضرورية مضمنة بشكل صحيح قبل مشاركة الملف.

الكود التالي بلغة C++ يوضح كيفية الحصول على الخطوط المدمجة من ملف عرض تقديمي:
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// الحصول على جميع الخطوط المدمجة.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// طباعة أسماء الخطوط المدمجة.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```


## **إضافة خطوط مدمجة إلى عرض تقديمي**

Aspose.Slides for C++ يسمح لك بدمج الخطوط في عرض PowerPoint باستخدام طريقة [AddEmbeddedFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/) التي تأتي باثنين من التحميلات للاستخدام المرن. يمكنك التحكم في مقدار الخط المدمج باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) — على سبيل المثال، اختيار دمج الأحرف المستخدمة فقط أو مجموعة الخط الكاملة. هذه الميزة مفيدة بشكل خاص عند إعداد عرض لتشاركه أو توزيعه، لضمان ظهور الخطوط المخصصة أو غير القياسية بشكل صحيح على جميع الأنظمة حتى إذا لم تُثبت تلك الخطوط.

الكود التالي بلغة C++ يتحقق من جميع الخطوط المستخدمة في عرض تقديمي، ويدمج أي خطوط غير مدمجة بالفعل:
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

    // التحقق مما إذا كان الخط مدمجًا بالفعل.
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


## **إزالة الخطوط المدمجة من عرض تقديمي**

Aspose.Slides for C++ يوفر طريقة `RemoveEmbeddedFont` عبر فئة [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) التي تتيح لك إزالة خطوط محددة مدمجة في عرض PowerPoint. يمكن أن يساعد ذلك في تقليل حجم الملف الكلي، خاصة إذا لم تعد الخطوط المدمجة مستخدمة أو ضرورية. إزالة الخطوط غير المستخدمة قد تحسن الأداء وتضمن أن العرض يحتوي فقط على الموارد الأساسية.

الكود التالي بلغة C++ يوضح كيفية إزالة خط مدمج من عرض تقديمي:
```cpp
auto fontName = u"Calibri";

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// الحصول على جميع الخطوط المدمجة.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // إزالة الخط المدمج.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```


## **ضغط الخطوط المدمجة**

Aspose.Slides for C++ يوفر طريقة `CompressEmbeddedFonts` عبر فئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) التي تسمح لك بتقليل حجم الملف الكلي للعرض عن طريق تحسين بيانات الخط المدمج. هذا مفيد بشكل خاص عندما يحتوي عرضك على خطوط كبيرة أو متعددة، وتريد الحفاظ على حجم الملف خفيفًا للمشاركة أو التخزين أو الاستخدام عبر الإنترنت — دون المساس بدقة المظهر البصري للمحتوى.

الكود التالي بلغة C++ يوضح كيفية ضغط الخطوط المدمجة في عرض PowerPoint:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض التقديمي سيظل يُستبدل أثناء العرض بالرغم من دمجه؟**  
تحقق من [substitution information](/slides/ar/cpp/font-substitution/) في مدير الخطوط و[fall back/substitution rules](/slides/ar/cpp/fallback-font/): إذا كان الخط غير متاح أو مقيد، سيتم استخدام الخط الاحتياطي.

**هل يستحق دمج الخطوط "النظامية" مثل Arial/Calibri؟**  
عادة لا—فهذه الخطوط متوفرة تقريبًا دائمًا. ولكن من أجل قابلية نقل كاملة في بيئات "خفيفة" (Docker، خادم Linux بدون خطوط مثبتة مسبقًا)، قد يزيل دمج خطوط النظام خطر الاستبدالات غير المتوقعة.