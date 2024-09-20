---
title: Конвертация PowerPoint в HTML на C++
linktitle: Конвертация PowerPoint в HTML
type: docs
weight: 30
url: /cpp/convert-powerpoint-to-html/
keywords: "C++ PowerPoint в HTML, Конвертировать презентацию PowerPoint, PPTX, PPT, PPT в HTML, PPTX в HTML, PowerPoint в HTML, Сохранить PowerPoint как HTML, Сохранить PPT как HTML, Сохранить PPTX как HTML, C++, CPP, Aspose.Slides, экспорт в HTML"
description: "Конвертация PowerPoint в HTML на C++. Сохранение PPTX или PPT в HTML на C++. Сохранение слайдов в HTML на C++"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формат HTML с использованием C++. Она охватывает следующие темы.

- [Конвертация PowerPoint в HTML на C++](#convert-powerpoint-to-html)
- [Конвертация PPT в HTML на C++](#convert-powerpoint-to-html)
- [Конвертация PPTX в HTML на C++](#convert-powerpoint-to-html)
- [Конвертация ODP в HTML на C++](#convert-powerpoint-to-html)
- [Конвертация слайдов PowerPoint в HTML на C++](#convert-slide-to-html)

## **C++ PowerPoint в HTML**

Для кода C++ примера конвертации PowerPoint в HTML смотрите раздел ниже, т.е. [Конвертация PowerPoint в HTML](#convert-powerpoint-to-html). Код может загружать множество форматов, таких как PPT, PPTX и ODP в объект презентации и сохранять его в формате HTML.

## **О конвертации PowerPoint в HTML**
С помощью [**Aspose.Slides для C++**](https://products.aspose.com/slides/cpp/) приложения и разработчики могут конвертировать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.

**Aspose.Slides** предоставляет множество параметров (большинство из класса [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)), которые определяют процесс конвертации PowerPoint в HTML:

* Конвертировать всю презентацию PowerPoint в HTML.
* Конвертировать конкретный слайд в презентации PowerPoint в HTML.
* Конвертировать медиа-презентации (изображения, видео и т.д.) в HTML.
* Конвертировать презентацию PowerPoint в адаптивный HTML.
* Конвертировать презентацию PowerPoint в HTML с включением или исключением заметок докладчика.
* Конвертировать презентацию PowerPoint в HTML с включением или исключением комментариев.
* Конвертировать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами.
* Конвертировать презентацию PowerPoint в HTML с использованием нового CSS стиля.

{{% alert color="primary" %}} 

С использованием собственного API Aspose разработал бесплатные [конвертеры презентаций в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html) и др. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Вы также можете ознакомиться с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}} 

Кроме описанных здесь процессов конвертации, Aspose.Slides также поддерживает операции конвертации, касающиеся формата HTML:

* [HTML в изображение](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **Конвертация PowerPoint в HTML**
С помощью Aspose.Slides вы можете преобразовать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
   * Загрузите **.ppt** в _Presentation_ класс для **Конвертации PPT в HTML на C++**
   * Загрузите **.pptx** в _Presentation_ класс для **Конвертации PPTX в HTML на C++**
   * Загрузите **.odp** в _Presentation_ класс для **Конвертации ODP в HTML на C++**
3. Используйте метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020), чтобы сохранить объект как HTML файл.

Этот код показывает, как конвертировать PowerPoint в HTML на C++:

```cpp
// Создание объекта Presentation, представляющего файл презентации
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Сохранение презентации в HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```

## **Конвертация PowerPoint в адаптивный HTML**
Aspose.Slides предоставляет класс [ResponsiveHtmlController ](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller), который позволяет генерировать адаптивные HTML файлы. Этот код показывает, как конвертировать презентацию PowerPoint в адаптивный HTML на C++:

```cpp
// Создание объекта Presentation, представляющего файл презентации
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// Сохранение презентации в HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```

## **Конвертация PowerPoint в HTML с примечаниями**
Этот код показывает, как конвертировать PowerPoint в HTML с примечаниями на C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Сохранение страниц заметок
pres->Save(u"Output.html", SaveFormat::Html, opt);
```

## **Конвертация PowerPoint в HTML с оригинальными шрифтами**
Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller), который позволяет встраивать все шрифты в презентацию в процессе конвертации презентации в HTML.

Чтобы предотвратить встраивание определенных шрифтов, вы можете передать массив имен шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller). Популярные шрифты, такие как Calibri или Arial, при использовании в презентации не обязательно встраивать, потому что большинство систем уже содержат такие шрифты. Когда эти шрифты встроены, результирующий HTML документ становится ненужным образом большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) поддерживает наследование и предоставляет метод [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77), который предназначен для переопределения.

```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// исключить стандартные шрифты презентации
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```

## **Конвертация PowerPoint в HTML с изображениями высокого качества**
По умолчанию, когда вы конвертируете PowerPoint в HTML, Aspose.Slides выводит маленький HTML с изображениями в 72 DPI и удаленными обрезанными областями. Чтобы получить HTML файлы с изображениями более высокого качества, вы должны установить свойство `PicturesCompression` (из класса `HtmlOptions`) на 96 (т.е., `PicturesCompression::Dpi96`) или более высокие [значения](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8).

Этот код C++ показывает, как конвертировать презентацию PowerPoint в HTML, получая изображения высокого качества с 150 DPI (т.е., `PicturesCompression::Dpi150`):

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```

Этот код на C++ показывает, как получить HTML с изображениями полного качества:

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```

## **Конвертация слайда в HTML**
Чтобы конвертировать конкретный слайд в PowerPoint в HTML, вы должны создать экземпляр того же класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) (используемого для конвертации целых презентаций в HTML), а затем использовать метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) для сохранения файла в качестве HTML. Класс [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) может быть использован для указания дополнительных параметров конвертации:

Этот код C++ показывает, как конвертировать слайд в презентации PowerPoint в HTML:

```cpp
class CustomFormattingController : public IHtmlFormattingController
{
public:
    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteDocumentEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteSlideStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(String::Format(SlideHeader, generator->get_SlideIndex() + 1));
    }
    void WriteSlideEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(SlideFooter);
    }
    void WriteShapeStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}
    void WriteShapeEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}

private:
    static const String SlideHeader;
    static const String SlideFooter;
};

const String CustomFormattingController::SlideHeader = u"<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
const String CustomFormattingController::SlideFooter = u"</div>";
```

```cpp
void Run()
{
    String dataDir = GetDataPath();
    
    auto presentation = System::MakeObject<Presentation>(dataDir + u"Individual-Slide.pptx");

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>());
    auto htmlOptions = System::MakeObject<HtmlOptions>();
    htmlOptions->set_HtmlFormatter(formatter);

    // Сохранение файла              
    for (int32_t i = 0; i < presentation->get_Slides()->get_Count(); i++)
    {
        presentation->Save(dataDir + u"Individual Slide" + (i + 1) + u"_out.html", 
            MakeArray<int32_t>({ i + 1 }), SaveFormat::Html, htmlOptions);
    }
}
```

## **Сохранение CSS и изображений при экспорте в HTML**
Используя новые CSS файлы стилей, вы можете легко изменить стиль HTML файла, полученного в результате процесса конвертации PowerPoint в HTML.

Код C++ в этом примере показывает, как использовать переопределяемые методы для создания пользовательского HTML документа со ссылкой на CSS файл:

```cpp
class CustomHeaderAndFontsController : public EmbedAllFontsHtmlController
{
public:
    CustomHeaderAndFontsController(String cssFileName)
        : m_cssFileName(cssFileName)
    {
    }

    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(System::String::Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    void WriteAllFonts(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(u"<!-- Встроенные шрифты -->");
        EmbedAllFontsHtmlController::WriteAllFonts(generator, presentation);
    }

private:
    static const String Header;
    String m_cssFileName;
};

const String CustomHeaderAndFontsController::Header = String(u"<!DOCTYPE html>\n") + 
u"<html>\n" + u"<head>\n" + 
u"<meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\">\n" + 
u"<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" + 
u"<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" + u"</head>";
```

```cpp
void Run()
{
    // Путь к директории документов.
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```

## **Ссылка на все шрифты при конвертации презентации в HTML**
Если вы не хотите встраивать шрифты (чтобы избежать увеличения размера результирующего HTML), вы можете ссылаться на все шрифты, реализовав свою собственную версию `LinkAllFontsHtmlController`. 

Этот код C++ показывает, как конвертировать PowerPoint в HTML, ссылаясь на все шрифты и исключая "Calibri" и "Arial" (так как они уже существуют в системе):

```cpp
class LinkAllFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkAllFontsHtmlController(ArrayPtr<String> fontNameExcludeList, String basePath)
        : EmbedAllFontsHtmlController(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    void WriteFont(SharedPtr<IHtmlGenerator> generator, SharedPtr<IFontData> originalFont, SharedPtr<IFontData> substitutedFont,
        String fontStyle, String fontWeight, ArrayPtr<uint8_t> fontData)
    {
        String fontName = substitutedFont == nullptr ? originalFont->get_FontName() : substitutedFont->get_FontName();
        String path = String::Format(u"{0}.woff", fontName); // возможно потребуется некоторая санация пути
        IO::File::WriteAllBytes(IO::Path::Combine(m_basePath, path), fontData);

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face { ");
        generator->AddHtml(String::Format(u"font-family: '{0}'; ", fontName));
        generator->AddHtml(String::Format(u"src: url('{0}')", path));

        generator->AddHtml(u" }");
        generator->AddHtml(u"</style>");
    }

private:
    String m_basePath;
};
```

```cpp
void Run()
{
    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    // исключить стандартные шрифты презентации
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    
    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    
    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```

## **Конвертация PowerPoint в адаптивный HTML**
Этот код C++ показывает, как конвертировать презентацию PowerPoint в адаптивный HTML:

```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```

## **Экспорт медиафайлов в HTML**
С помощью Aspose.Slides для C++ вы можете экспортировать медиафайлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд.
3. Добавьте видео на слайд.
4. Запишите презентацию как HTML файл.

Этот код C++ показывает, как добавить видео к презентации, а затем сохранить его в HTML:

```cpp
// Загружает презентацию
auto pres = System::MakeObject<Presentation>();

const System::String path = u"C:/out/";
const System::String fileName = u"ExportMediaFiles_out.html";
const System::String baseUri = u"http://www.example.com/";

auto fileStream = System::MakeObject<IO::FileStream>(u"my_video.avi", IO::FileMode::Open, IO::FileAccess::Read);

auto video = pres->get_Videos()->AddVideo(fileStream, Aspose::Slides::LoadingStreamBehavior::ReadStreamAndRelease);

auto slide = pres->get_Slides()->idx_get(0);
slide->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(path, fileName, baseUri);

// Устанавливает параметры HTML
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// Сохраняет файл
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```