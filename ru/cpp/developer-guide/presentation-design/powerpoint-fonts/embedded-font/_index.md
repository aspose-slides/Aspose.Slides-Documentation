---
title: "Встраивание шрифтов в презентации на C++"
linktitle: "Встроенные шрифты"
type: docs
weight: 40
url: /ru/cpp/embedded-font/
keywords:
- добавить шрифт
- встроить шрифт
- встраивание шрифтов
- получить встроенный шрифт
- добавить встроенный шрифт
- удалить встроенный шрифт
- сжать встроенный шрифт
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Управляйте встроенными шрифтами в PowerPoint с помощью Aspose.Slides для C++. Добавляйте, получайте, удаляйте и сжимайте шрифты, чтобы сохранить внешний вид текста и уменьшить размер файла."
---
## **Введение**

Встраивание шрифтов сохраняет данные шрифта внутри презентации PowerPoint. Когда средство просмотра поддерживает встроенные шрифты, оно может отображать текст с использованием этих шрифтов, даже если они не установлены в целевой системе. Это помогает сохранять разрывы строк, межсимвольные интервалы и макет слайдов.

Aspose.Slides for C++ позволяет получать, добавлять и удалять встроенные шрифты через метод [Presentation::get_FontsManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_fontsmanager/) класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). Вы также можете уменьшить размер данных встроенного шрифта, удалив символы, которые не используются в презентации.

Приведённые ниже примеры работают с файлами PPTX. Перед встраиванием шрифта убедитесь, что его данные доступны Aspose.Slides и что его лицензия позволяет встраивание.

## **Получение и удаление встроенных шрифтов**

Используйте [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) для получения списка шрифтов, хранящихся в презентации. Чтобы удалить один из них, передайте шрифт из этого списка в [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), затем сохраните презентацию.

Следующий пример выводит список встроенных шрифтов в файле `EmbeddedFonts.pptx` и удаляет Calibri, если он присутствует:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Удаление встроенного шрифта удаляет его сохранённые данные шрифта; это не меняет шрифт, присвоенный тексту. Если шрифт установлен в целевой системе, текст всё равно может его использовать. В противном случае при рендеринге может потребоваться [замена шрифтов](/slides/ru/cpp/font-substitution/), что может повлиять на макет.

## **Проверка данных шрифта и разрешений на встраивание**

Используйте интерфейс [IFontsManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/) , чтобы проверить шрифты перед их встраиванием. Вызовите [IFontsManager::GetFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getfonts/), чтобы получить шрифты, используемые в презентации. Для каждого шрифта передайте объект [IFontData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontdata/) и требуемое значение [FontStyleType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontstyletype/), в [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getfontbytes/). Метод возвращает двоичные данные для данного стиля шрифта или `nullptr`, если запрашиваемый шрифт или стиль недоступны. Не передавайте результат `nullptr` в [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), поскольку этот метод требует массив байтов.

[EmbeddingLevel](https://reference.aspose.com/slides/ru/cpp/aspose.slides/embeddinglevel/) — это перечисление флагов, которое сообщает о ограничениях встраивания, хранящихся в шрифте:

- `Installable` разрешает встраивание и постоянную установку на другой системе, при условии соблюдения лицензии шрифта.
- `Restricted` запрещает встраивание, если не получено разрешение от законного владельца шрифта, когда это единственный флаг разрешения использования.
- `PreviewPrint` позволяет временное использование для просмотра и печати; документ, содержащий шрифт, должен быть только для чтения.
- `Editable` позволяет временное использование и позволяет документу быть отредактированным и сохранённым.
- `NoSubsetting` — дополнительное ограничение, запрещающее встраивание только подмножества глифов. При наличии этого флага встраиваются все символы.
- `BitmapOnly` — дополнительное ограничение, позволяющее встраивать только растровые варианты, а не контурные данные. Если у шрифта нет растровых вариантов, его нельзя встроить.

Первые четыре значения описывают разрешения на использование, тогда как `NoSubsetting` и `BitmapOnly` могут быть комбинированы с ними. Проверяйте модификаторы с помощью побитовых операций. Поскольку `Installable` имеет значение ноль, маскируйте биты разрешения использования и сравнивайте результат с `Installable`. Текущие шрифты должны устанавливать не более одного бита разрешения использования. Для совместимости со старыми шрифтами, которые устанавливают более одного, вспомогательная функция ниже выбирает наименее ограничительное разрешение: `Editable`, затем `PreviewPrint`, затем `Restricted`.

Следующий пример проверяет обычные, полужирные, курсивные и полужирные курсивные данные, доступные для каждого шрифта, возвращённого `GetFonts`. Он пропускает недоступные стили, ограниченные шрифты, шрифты только с растровыми вариантами, шрифты, ограниченные просмотром и печатью, поскольку вывод остаётся редактируемым, а также шрифты, уже встроенные. Если какой‑либо доступный стиль имеет `NoSubsetting`, он встраивает все символы для данного семейства шрифтов.

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Эта проверка сообщает об ограничениях, закодированных в каждом файле шрифта. Она не предоставляет лицензии, не доказывает, что вы получили шрифт законно, и не заменяет проверку лицензионного соглашения шрифта перед распространением встроенной копии.

## **Добавление встроенных шрифтов**

Используйте [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/addembeddedfont/) , чтобы встроить шрифт. Его перегрузки принимают либо объект [IFontData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontdata/) , либо массив байтов, содержащий данные шрифта. Перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/embedfontcharacters/) управляет тем, какие символы включаются:

- [All](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/embedfontcharacters/) встраивает все символы шрифта. Используйте эту опцию, когда получатели должны редактировать презентацию и вводить новый текст.
- [OnlyUsed](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/embedfontcharacters/) встраивает только символы, используемые в презентации, чтобы уменьшить размер файла. Выберите эту опцию для готовой презентации, предназначенной преимущественно для просмотра.

Следующий пример использует [IFontsManager::GetFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getfonts/) , чтобы получить шрифты, используемые в `Fonts.pptx`, и встраивает те, которые ещё не встроены. Шрифты для добавления должны быть доступны на машине, где выполняется код. Существующие встроенные шрифты сохраняют свои текущие наборы символов.

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Сжатие встроенных шрифтов**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) уменьшает данные встроенного шрифта, удаляя неиспользуемые символы. Он работает с уже встроенными шрифтами, поэтому уменьшение размера зависит от того, сколько неиспользованных данных шрифта содержится в презентации.

Следующий пример сжимает шрифты в `EmbeddedFonts.pptx` и сохраняет результат в отдельный файл:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Сохраните оригинальный файл, если получатели могут позже добавить текст. Символы, удалённые во время сжатия, более недоступны из встроенного шрифта, даже если изначально вы встроили все символы.

## **FAQ**

**Как проверить, будет ли встроенный шрифт заменён при рендеринге?**

Вызовите [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getsubstitutions/) в среде, где вы рендерите презентацию, чтобы увидеть, какие шрифты Aspose.Slides заменит. Также проверьте настройки [замена шрифтов](/slides/ru/cpp/font-substitution/) и правила [fallback шрифтов](/slides/ru/cpp/fallback-font/). Fallback обрабатывает недостающие символы, поэтому встраивание шрифта не решает проблему символов, которых в самом шрифте нет.

**Стоит ли встраивать распространённые шрифты, такие как Arial и Calibri?**

Решение следует принимать, ориентируясь на целевую среду. Если необходимые шрифты доступны на каждом компьютере, который открывает или рендерит презентацию, их встраивание может увеличить размер файла без необходимости. Если у получателей или серверов могут отсутствовать эти шрифты, их встраивание поможет сохранить задуманное отображение, при условии, что лицензии позволяют это.