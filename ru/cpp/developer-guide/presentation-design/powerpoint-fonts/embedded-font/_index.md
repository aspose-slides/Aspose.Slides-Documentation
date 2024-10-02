---
title: Встроенные Шрифты
type: docs
weight: 40
url: /ru/cpp/embedded-font/
keywords: "Шрифты, встроенные шрифты, добавить шрифты, презентация PowerPoint C++, CPP, Aspose.Slides для C++"
description: "Используйте встроенные шрифты в презентации PowerPoint на C++"
---

**Встроенные шрифты в PowerPoint** полезны, когда вы хотите, чтобы ваша презентация отображалась правильно при открытии на любой системе или устройстве. Если вы использовали сторонний или нестандартный шрифт, потому что проявили креативность в своей работе, у вас есть еще больше причин встроить свой шрифт. В противном случае (без встроенных шрифтов) тексты или числа на ваших слайдах, разметка, стиль и т. д. могут измениться или превратиться в запутанные прямоугольники.

Классы [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/), [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) и их интерфейсы содержат большинство свойств и методов, которые вам нужны для работы с встроенными шрифтами в презентациях PowerPoint.

## **Получение или Удаление Встроенных Шрифтов из Презентации**

Aspose.Slides предоставляет метод [GetEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) (предоставленный классом [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/)), который позволяет вам получить (или выяснить) шрифты, встроенные в презентацию. Для удаления шрифтов используется метод [RemoveEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/removeembeddedfont/) (также предоставленный этим же классом).

Этот код C++ показывает, как получить и удалить встроенные шрифты из презентации:

```c++
// Создает объект Presentation, представляющий файл презентации
auto presentation = System::MakeObject<Presentation>(u"EmbeddedFonts.pptx");
// Отображает слайд, содержащий текстовый фрейм, использующий встроенный "FunSized"
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture1_out.png", ImageFormat::Png);

auto fontsManager = presentation->get_FontsManager();

// Получает все встроенные шрифты
auto embeddedFonts = fontsManager->GetEmbeddedFonts();

std::function<bool(SharedPtr<IFontData>)> comparer = [](SharedPtr<IFontData> data) -> bool
{
    return data->get_FontName() == u"Calibri";
};

// Находит шрифт "Calibri"
auto funSizedEmbeddedFont = Array<SharedPtr<IFontData>>::Find(embeddedFonts, comparer);

// Удаляет шрифт "Calibri"
fontsManager->RemoveEmbeddedFont(funSizedEmbeddedFont);

// Отображает презентацию; шрифт "Calibri" заменен на существующий
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture2_out.png", ImageFormat::Png);

// Сохраняет презентацию без встроенного шрифта "Calibri" на диск
presentation->Save(u"WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
```

## **Добавление Встроенных Шрифтов в Презентацию**

Используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) и два перегруженных метода [AddEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/), вы можете выбрать предпочитаемое правило (встраивания) для добавления шрифтов в презентацию. Этот код C++ показывает, как встроить и добавить шрифты в презентацию:

```c++
// Загружает презентацию
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Загружает исходный шрифт для замены
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

// Сохраняет презентацию на диск
presentation->Save(u"AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
```

## **Сжатие Встроенных Шрифтов**

Чтобы вы могли сжать шрифты, встроенные в презентацию, и уменьшить ее размер файла, Aspose.Slides предоставляет метод [CompressEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) (предоставленный классом [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)).

Этот код C++ показывает, как сжать встроенные шрифты PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

Aspose::Slides::LowCode::Compress::CompressEmbeddedFonts(pres);
pres->Save(u"pres-out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```