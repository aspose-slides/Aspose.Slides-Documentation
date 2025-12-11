---
title: Встраивание шрифтов в презентации с использованием C++
linktitle: Встраивание шрифта
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
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Встраивание шрифтов TrueType в презентации PowerPoint и OpenDocument с помощью Aspose.Slides for C++, обеспечивая точный рендеринг на всех платформах."
---

## **Обзор**

**Встроенные шрифты в PowerPoint** помогают гарантировать, что ваша презентация сохраняет задуманное оформление при открытии на любой системе или устройстве. Это особенно важно при использовании пользовательских, сторонних или нестандартных шрифтов для брендинга или креативных целей. Без встроенных шрифтов текст может быть заменён, макеты могут испортиться, а символы могут отобразиться как нечитаемые знаки или прямоугольники, что ухудшает общий дизайн.

Aspose.Slides for C++ предоставляет набор мощных API для программного управления встроенными шрифтами. Вы можете использовать [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) и [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/) для инспектирования, добавления или удаления встроенных шрифтов в файлах презентаций. Кроме того, класс [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) позволяет оптимизировать размер файла, сжимая данные шрифтов без потери качества или внешнего вида.

Эти инструменты дают вам полный контроль над встраиванием шрифтов, помогая поддерживать согласованную типографику на всех платформах, одновременно позволяя уменьшать размер файла при необходимости.

## **Получить встроенные шрифты из презентации**

Aspose.Slides for C++ предоставляет метод `GetEmbeddedFonts` через класс [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/), который позволяет получить список шрифтов, встроенных в презентацию PowerPoint. Это может быть полезно для аудита использования шрифтов, обеспечения соответствия брендинговым требованиям или проверки того, что все необходимые шрифты правильно включены перед распространением файла.

Следующий код на C++ демонстрирует, как получить встроенные шрифты из файла презентации:
```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Получите все встроенные шрифты.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Выведите имена встроенных шрифтов.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```


## **Добавить встроенные шрифты в презентацию**

Aspose.Slides for C++ позволяет встраивать шрифты в презентацию PowerPoint с помощью метода [AddEmbeddedFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/), который имеет две перегрузки для гибкого использования. Вы можете контролировать, сколько шрифта будет встроено, используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) — например, выбирая встраивание только используемых символов или полного набора шрифта. Эта функция особенно полезна при подготовке презентации к совместному использованию или распространению, гарантируя, что пользовательские или нестандартные шрифты отображаются корректно на всех системах, даже если эти шрифты не установлены.

Следующий код на C++ проверяет все шрифты, использованные в презентации, и встраивает любые шрифты, которые ещё не встроены:
```cpp
// Загрузить файл презентации.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Проверить, встроен ли шрифт уже.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Встроить шрифт в презентацию.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Сохранить презентацию на диск.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Удалить встроенные шрифты из презентации**

Aspose.Slides for C++ предоставляет метод `RemoveEmbeddedFont` через класс [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/), который позволяет удалить конкретные встроенные шрифты из презентации PowerPoint. Это может помочь уменьшить общий размер файла, особенно если встроенные шрифты больше не используются или не нужны. Удаление неиспользуемых шрифтов также может улучшить производительность и гарантировать, что презентация содержит только необходимые ресурсы.

Следующий код на C++ демонстрирует, как удалить встроенный шрифт из презентации:
```cpp
auto fontName = u"Calibri";

// Создать экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Получить все встроенные шрифты.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Удалить встроенный шрифт.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```


## **Сжать встроенные шрифты**

Aspose.Slides for C++ предоставляет метод `CompressEmbeddedFonts` через класс [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/), позволяющий уменьшить общий размер файла презентации за счёт оптимизации данных встроенных шрифтов. Это особенно полезно, когда ваша презентация содержит крупные или несколько шрифтов, и вы хотите сохранить файл лёгким для совместного использования, хранения или онлайн‑просмотра — без ущерба визуальному качеству содержимого.

Следующий код на C++ демонстрирует, как сжать встроенные шрифты в презентации PowerPoint:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**Как узнать, что конкретный шрифт в презентации всё равно будет заменён при рендеринге, несмотря на встраивание?**

Проверьте [substitution information](/slides/ru/cpp/font-substitution/) в менеджере шрифтов и [fallback/substitution rules](/slides/ru/cpp/fallback-font/): если шрифт недоступен или ограничен, будет использован запасной вариант.

**Стоит ли встраивать «системные» шрифты, такие как Arial/Calibri?**

Обычно нет — они почти всегда доступны. Но для полной переносимости в «тонких» средах (Docker, Linux‑сервер без предустановленных шрифтов) встраивание системных шрифтов может устранить риск неожиданной замены.