---
title: خط مضمن
type: docs
weight: 40
url: /ar/cpp/embedded-font/
keywords: "خطوط, خطوط مضمنة, إضافة خطوط, عرض تقديمي PowerPoint C++, CPP, Aspose.Slides for C++"
description: "استخدام الخطوط المضمنة في عرض PowerPoint التقديمي في C++"
---

**الخطوط المضمنة في PowerPoint** مفيدة عندما تريد أن يظهر عرضك التقديمي بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا كنت قد استخدمت خطًا من طرف ثالث أو غير قياسي لأنك كنت مبتكرًا في عملك، فستكون لديك أسباب أكثر لتضمين خطك. خلاف ذلك (بدون خطوط مضمنة)، قد تتغير النصوص أو الأرقام على الشرائح الخاصة بك، أو تتغير التنسيقات، أو تصبح مربعات مربكة.

تحتوي فئة [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) وفئة [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/) وفئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) وواجهاتها على معظم الخصائص والأساليب التي تحتاجها للعمل مع الخطوط المضمنة في عروض PowerPoint التقديمية.

## **إضافة أو إزالة الخطوط المضمنة من العرض التقديمي**

يوفر Aspose.Slides طريقة [GetEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) (المكشوفة بواسطة فئة [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/)) لتمكينك من الحصول على (أو معرفة) الخطوط المضمنة في عرض تقديمي. لإزالة الخطوط، يتم استخدام طريقة [RemoveEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/removeembeddedfont/) (المكشوفة بواسطة نفس الفئة).

يوضح هذا الكود C++ كيفية الحصول على الخطوط المضمنة وإزالتها من عرض تقديمي:

```c++
// يقوم بإنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
auto presentation = System::MakeObject<Presentation>(u"EmbeddedFonts.pptx");
// يقوم بعرض شريحة تحتوي على إطار نص يستخدم الخط المضمن "FunSized"
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture1_out.png", ImageFormat::Png);

auto fontsManager = presentation->get_FontsManager();

// يحصل على جميع الخطوط المضمنة
auto embeddedFonts = fontsManager->GetEmbeddedFonts();

std::function<bool(SharedPtr<IFontData>)> comparer = [](SharedPtr<IFontData> data) -> bool
{
    return data->get_FontName() == u"Calibri";
};

// يجد خط "Calibri"
auto funSizedEmbeddedFont = Array<SharedPtr<IFontData>>::Find(embeddedFonts, comparer);

// يزيل خط "Calibri"
fontsManager->RemoveEmbeddedFont(funSizedEmbeddedFont);

// يقوم بعرض العرض التقديمي؛ يتم استبدال خط "Calibri" بخط موجود
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture2_out.png", ImageFormat::Png);

// يحفظ العرض التقديمي بدون خط "Calibri" المضمن على القرص
presentation->Save(u"WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
```

## **إضافة خطوط مضمنة إلى العرض التقديمي**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) واثنين من التحميلات الإضافية لطريقة [AddEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/)، يمكنك اختيار القاعدة المفضلة لديك (للتضمين) لتضمين الخطوط في عرض تقديمي. يوضح هذا الكود C++ كيفية تضمين وإضافة الخطوط إلى عرض تقديمي:

```c++
// يقوم بتحميل العرض التقديمي
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// يقوم بتحميل الخط المصدر المراد استبداله
auto sourceFont = System::MakeObject<FontData>(u"Arial");

auto allFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (SharedPtr<IFontData> font : allFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&font](SharedPtr<IFontData> data) -> bool
    {
        return data == font;
    };

    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        presentation->get_FontsManager()->AddEmbeddedFont(font, EmbedFontCharacters::All);
    }
}

// يحفظ العرض التقديمي على القرص
presentation->Save(u"AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
```

## **ضغط الخطوط المضمنة**

لتتمكن من ضغط الخطوط المضمنة في عرض تقديمي وتقليل حجم ملفه، يوفر Aspose.Slides الطريقة [CompressEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) (المكشوفة بواسطة فئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)).

يوضح هذا الكود C++ كيفية ضغط الخطوط المضمنة في PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

Aspose::Slides::LowCode::Compress::CompressEmbeddedFonts(pres);
pres->Save(u"pres-out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```