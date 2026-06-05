---
title: "Преобразовать презентации PowerPoint в HTML на C++"
linktitle: "PowerPoint в HTML"
type: docs
weight: 30
url: /ru/cpp/convert-powerpoint-to-html/
keywords:
- "конвертировать PowerPoint"
- "преобразовать презентацию"
- "преобразовать слайд"
- "преобразовать PPT"
- "преобразовать PPTX"
- "PowerPoint в HTML"
- "презентацию в HTML"
- "слайд в HTML"
- "PPT в HTML"
- "PPTX в HTML"
- "сохранить PowerPoint как HTML"
- "сохранить презентацию как HTML"
- "сохранить слайд как HTML"
- "сохранить PPT как HTML"
- "сохранить PPTX как HTML"
- "экспортировать PPT в HTML"
- "экспортировать PPTX в HTML"
- C++
- Aspose.Slides
description: "Преобразовать презентации PowerPoint в HTML на C++. Используйте Aspose.Slides для экспорта файлов PPT и PPTX, выбранных слайдов, заметок, шрифтов, изображений, SVG и медиа."
---
## **Обзор**

Aspose.Slides for C++ может сохранять презентации PowerPoint в формате HTML без Microsoft PowerPoint. Основное преобразование состоит из единственной загрузки [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и вызова `Save` с [SaveFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmloptions/), когда необходимо управлять экспортируемым макетом, шрифтами, изображениями, заметками, комментариями, выводом SVG или связанными ресурсами.

Это руководство сосредоточено на практических сценариях экспорта HTML:

- Экспорт всей презентации или выбранных слайдов.
- Создание HTML с фиксированным макетом, отзывчивым или основанным на SVG.
- Включение заметок выступающего и комментариев.
- Контроль качества изображений и обрезанных данных изображений.
- Встраивание шрифтов или отдельное сохранение файлов шрифтов.
- Выбор способа записи и ссылки на внешние ресурсы и медиафайлы.

По умолчанию экспорт HTML создает автономный HTML‑документ, в котором большинство ресурсов встроено. Это удобно для обмена одним файлом, но может увеличить размер вывода. Для публикации в вебе рассмотрите внешние ресурсы, снижение DPI изображений и встраивание только тех шрифтов, которые недоступны в целевой среде.

## **Преобразование презентации в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и сохраните с `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

В этом примере записывается один HTML‑файл. Вызов `Dispose` освобождает файловые дескрипторы и ресурсы рендеринга после экспорта.

## **Использование HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmloptions/) — основной класс конфигурации экспорта HTML. Распространённые настройки включают:

- `SlidesLayoutOptions`: добавляет заметки, комментарии, раздаточные материалы или другую информацию о макете.
- `HtmlFormatter`: изменяет структуру HTML‑документа или делегирует форматирование контроллеру.
- `SlideImageFormat`: изменяет способ представления слайдов, например как SVG.
- `PicturesCompression`: управляет DPI изображения и размером вывода.
- `DeletePicturesCroppedAreas`: сохраняет или удаляет данные обрезанных областей изображений.
- `SvgResponsiveLayout`: делает экспортируемый SVG‑контент адаптивным к своему контейнеру.
- `ShowHiddenSlides`: включает скрытые слайды при необходимости.

В следующих разделах показаны наиболее часто используемые параметры отдельно, чтобы вы могли комбинировать только те, которые нужны вашему рабочему процессу.

## **Экспорт выбранных слайдов в HTML**

Перегрузка `Presentation::Save`, принимающая номера слайдов, использует 1‑based позиции слайдов. Цикл ниже сохраняет каждый слайд в отдельный HTML‑файл.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Используйте эту схему, когда веб‑сайт или приложение требуют одну HTML‑страницу на каждый слайд. Если каждый слайд должен иметь одинаковый макет, создайте один экземпляр [HtmlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmloptions/) и передайте его каждому вызову `Save`.

## **Создание отзывчивого HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/responsivehtmlcontroller/) обеспечивает отзывчивый HTML‑вывод через [HtmlFormatter](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmlformatter/). Используйте его, когда экспортируемая страница должна лучше адаптироваться к ширине браузера.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Для отзывчивого макета на основе SVG установите `SvgResponsiveLayout` в [HtmlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmloptions/). Это полезно, когда содержимое слайда экспортируется как масштабируемая SVG‑разметка.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Включение заметок выступающего и комментариев**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notescommentslayoutingoptions/) через `HtmlOptions.SlidesLayoutOptions`, чтобы включить заметки выступающего или комментарии. Заметки и комментарии скрыты по умолчанию, если только не задать их позиции.

Предположим, что исходная презентация содержит заметки выступающего:

![Слайд с заметками выступающего в PowerPoint](slide_with_notes.png)

Следующий код экспортирует содержимое слайда вместе с заметками под слайдом.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Экспортированный HTML включает область заметок:

![HTML‑вывод со слайдом и заметками выступающего](HTML_with_notes.png)

Чтобы экспортировать комментарии, задайте `CommentsPosition`, например `CommentsPositions::Right` или `CommentsPositions::Bottom`. Если нужны только комментарии, опустите `NotesPosition`. Если нужны и заметки, и комментарии, задайте оба свойства.

## **Контроль качества изображений и обрезанных областей**

Экспорт HTML может сжимать изображения слайдов для уменьшения размера вывода. Установите `PicturesCompression` в значение из [PicturesCompression](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/picturescompression/), когда требуется более высокое качество изображений.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

По умолчанию обрезанные области изображений могут быть удалены из экспортируемого вывода. Сохраняйте обрезанные данные только тогда, когда пользователям необходимо восстановить или проанализировать эти скрытые части изображений. Сохранение их может увеличить размер HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Добавление CSS**

Для простого стилизования передайте строку CSS в `HtmlFormatter::CreateDocumentFormatter`. Это изменит окружающий HTML‑документ, в то время как Aspose.Slides продолжит рендерить содержимое слайда.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Для пользовательского заголовка документа, подключённого CSS‑файла или пользовательской разметки вокруг слайдов и фигур реализуйте [IHtmlFormattingController](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ihtmlformattingcontroller/) и передайте его в [HtmlFormatter](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmlformatter/) с помощью `CreateCustomFormatter`.

## **Встраивание шрифтов**

Если в целевой среде шрифты презентации могут быть не установлены, встроите шрифты в HTML с помощью [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/embedallfontshtmlcontroller/). Встраивание повышает визуальную точность, но увеличивает размер вывода.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Исключайте шрифты только тогда, когда уверены, что целевые браузеры или системы уже их предоставляют. Для фирменных или редких шрифтов встраивание обычно безопаснее.

## **Ссылка на файлы шрифтов вместо их встраивания**

Чтобы уменьшить размер HTML‑файла, можно записать данные шрифтов в отдельные WOFF‑файлы и добавить правила `@font-face` в HTML. Ниже приведён помощник, расширяющий [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/embedallfontshtmlcontroller/) и переопределяющий `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

В этом примере файлы шрифтов сохраняются в `html-output/fonts`, а HTML ссылается на них URL‑ами вида `fonts/BrandFont-normal-400.woff`. Если HTML‑файл и шрифты развернуты в другом месте, выберите `fontUrlPrefix`, соответствующий пути URL после развертывания.

## **Сохранение ресурсов внешне**

Автономный HTML легко перемещать, но встроенные ресурсы Base64 делают файл большим. Если вашему приложению нужны внешние файлы изображений, реализуйте [ILinkEmbedController](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ilinkembedcontroller/) и передайте его в конструктор [HtmlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmloptions/).

При внешнем хранении ресурсов выбирайте два пути осознанно:

- Путь файловой системы, куда приложение записывает сгенерированные изображения, шрифты, аудио или видео.
- URL‑путь, который браузер использует из HTML‑документа для загрузки этих файлов.

## **Экспорт медиа‑файлов**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/videoplayerhtmlcontroller/) экспортирует видеo‑ и аудиофайлы и генерирует HTML, способный воспроизводить их в браузере. Его конструктор принимает:

- `path`: каталог, в который будут записаны сгенерированные медиа‑файлы.
- `fileName`: имя генерируемого HTML‑файла.
- `baseUri`: абсолютный префикс URI, используемый в HTML‑ссылках на медиа‑файлы.

Если HTML‑файл находится по пути `html-output/presentation.html`, а медиа‑файлы сохраняются в `html-output/media`, `path` должен указывать на каталог медиа на диске, а `baseUri` — на тот же каталог с точки зрения браузера. Для локального предварительного просмотра можно построить URI `file:///` из каталога медиа. Для развернутого приложения используйте абсолютный URL опубликованного каталога медиа.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Используйте каталоги вывода, уникальные для каждой задачи экспорта, особенно в серверных приложениях. Совместные пути вывода могут привести к перезаписи файлов разных конвертаций.

## **Производительность и управление ресурсами**

Конвертация HTML — это операция рендеринга, поэтому время обработки и использование памяти зависят от количества слайдов, разрешения изображений, шрифтов, эффектов, диаграмм и встроенных медиа. Более высокие DPI в `PicturesCompression`, встраивание шрифтов, вывод SVG и сохранённые обрезанные области изображений могут улучшить точность, но обычно увеличивают размер вывода.

Для пакетного конвертирования:

- Своевременно вызывайте `Dispose` для каждого экземпляра [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
- Используйте отдельные каталоги вывода для отдельных задач.
- Избегайте встраивания общих шрифтов, если в этом нет необходимости.
- Уменьшайте DPI изображений, когда HTML нужен только для предварительного просмотра или эскизов.
- Храните исходную презентацию, сгенерированный HTML и внешние ресурсы вместе, пока не будут окончательно определены пути развертывания.

## **FAQ**

**Сохраняются ли гиперссылки в HTML‑выводе?**

Да. Гиперссылки презентации экспортируются в HTML и остаются кликабельными, если целевой URL действителен.

**Можно ли конвертировать презентации в HTML параллельно?**

Да, но не следует использовать один экземпляр [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) в нескольких потоках. Обрабатывайте разные файлы отдельными экземплярами презентаций, отдельными потоками и отдельными каталогами вывода. См. руководство по [многопоточности](/slides/ru/cpp/multithreading/).

**Является ли объект Presentation потокобезопасным?**

Нет. Один экземпляр [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) должен быть загружен, изменён, сохранён и освобождён в одном потоке. Для параллельной работы создавайте независимый экземпляр для каждого потока или процесса.

**Почему сгенерированный HTML‑файл большой?**

По умолчанию экспорт может встраивать ресурсы непосредственно в HTML. Встроенные шрифты, изображения с высоким DPI, медиа, SVG‑контент и сохранённые обрезанные области изображений также увеличивают размер. Используйте внешние ресурсы, исключайте из встраивания общие шрифты и уменьшайте `PicturesCompression`, когда важнее меньший размер вывода, чем максимальная точность.

**Как выбрать baseUri для экспорта медиа?**

Выберите `baseUri` с точки зрения браузера и передайте его как абсолютный URI. Для локального предварительного просмотра можно получить его из каталога вывода через `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Для развертывания используйте абсолютный URL опубликованного медиа‑каталога. Путь файловой системы (`path`) и URL‑путь браузера (`baseUri`) не обязаны совпадать буквально, но должны указывать на одно и то же место ресурса.

**Можно ли включить скрытые слайды?**

Да. Установите `ShowHiddenSlides` в `true` у [HtmlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmloptions/), когда необходимо экспортировать скрытые слайды.