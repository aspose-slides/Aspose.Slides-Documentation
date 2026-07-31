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
description: "Встраивание TrueType шрифтов в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для C++, обеспечивая точный рендеринг на всех платформах."
---
## **Введение**

**Встроенные шрифты в PowerPoint** позволяют гарантировать, что ваша презентация сохраняет задуманное оформление при открытии на любой системе или устройстве. Это особенно важно при использовании пользовательских, сторонних или нестандартных шрифтов для брендинга или креативных целей. Без встроенных шрифтов текст может быть заменён, макет может нарушиться, а символы могут отображаться как нечитаемые знаки или прямоугольники, что ухудшает общий дизайн.

Aspose.Slides for C++ предоставляет набор мощных API для программного управления встроенными шрифтами. Вы можете использовать классы [FontsManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/) и [FontData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontdata/) для просмотра, добавления или удаления встроенных шрифтов в файлах презентаций. Кроме того, класс [Compress](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/) позволяет оптимизировать размер файла, сжимая данные шрифтов без потери качества или внешнего вида.

Эти инструменты дают вам полный контроль над встраиванием шрифтов, помогая поддерживать согласованную типографику на разных платформах и при необходимости уменьшать размер файла.

## **Получение встроенных шрифтов из презентации**

Aspose.Slides for C++ предоставляет метод `GetEmbeddedFonts` через класс [FontsManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/), который позволяет получить список шрифтов, встроенных в презентацию PowerPoint. Это может быть полезно для аудита использования шрифтов, обеспечения соответствия требованиям бренда или проверки того, что все необходимые шрифты правильно включены перед обменом файлом.

Ниже приведён пример кода на C++, демонстрирующий, как получить встроенные шрифты из файла презентации:

```cpp
// Создайте экземпляр класса Presentation, который представляет файл презентации.
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

## **Добавление встроенных шрифтов в презентацию**

Aspose.Slides for C++ позволяет встраивать шрифты в презентацию PowerPoint с помощью метода [AddEmbeddedFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/addembeddedfont/), который имеет две перегрузки для гибкого использования. Вы можете контролировать, насколько полностью шрифт будет встроен, используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/embedfontcharacters/) — например, выбрать встраивание только использованных символов или всего набора шрифта. Эта функция особенно полезна при подготовке презентации к распространению, гарантируя, что пользовательские или нестандартные шрифты будут отображаться корректно на всех системах, даже если эти шрифты не установлены.

Ниже показан пример кода на C++, который проверяет все шрифты, используемые в презентации, и встраивает те, которые ещё не встроены:

```cpp
// Загрузите файл презентации.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Проверьте, встроен ли шрифт уже.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Встроить шрифт в презентацию.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Сохраните презентацию на диск.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Удаление встроенных шрифтов из презентации**

Aspose.Slides for C++ предоставляет метод `RemoveEmbeddedFont` через класс [FontsManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/), который позволяет удалять конкретные встроенные шрифты из презентации PowerPoint. Это может помочь уменьшить общий размер файла, особенно если встроенные шрифты больше не используются или не нужны. Удаление неиспользуемых шрифтов также может улучшить производительность и обеспечить, что ваша презентация содержит только необходимые ресурсы.

Ниже приведён пример кода на C++, демонстрирующий, как удалить встроенный шрифт из презентации:

```cpp
auto fontName = u"Calibri";

// Создайте экземпляр класса Presentation, который представляет файл презентации.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Получите все встроенные шрифты.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Удалите встроенный шрифт.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Сжатие встроенных шрифтов**

Aspose.Slides for C++ предоставляет метод `CompressEmbeddedFonts` через класс [Compress](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/), позволяющий уменьшить общий размер файла презентации за счёт оптимизации данных встроенных шрифтов. Это особенно полезно, когда презентация содержит крупные или многочисленные шрифты, и вам нужно сохранить файл лёгким для обмена, хранения или онлайн‑использования — без ущерба визуальному качеству содержимого.

Ниже показан пример кода на C++, демонстрирующий, как сжать встроенные шрифты в презентации PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Как определить, что конкретный шрифт в презентации всё равно будет заменён при рендеринге, несмотря на встраивание?**

Проверьте [информацию о подстановке](/slides/ru/cpp/font-substitution/) в менеджере шрифтов и [правила fallback/substitution](/slides/ru/cpp/fallback-font/): если шрифт недоступен или ограничен, будет использован запасной вариант.

**Стоит ли встраивать «системные» шрифты, такие как Arial/Calibri?**

Обычно нет — они почти всегда доступны. Но для полной портативности в «тонких» средах (Docker, Linux‑сервер без предустановленных шрифтов) встраивание системных шрифтов может исключить риск неожиданных замен.