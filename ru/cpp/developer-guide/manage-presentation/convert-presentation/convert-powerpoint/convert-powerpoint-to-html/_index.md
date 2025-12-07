---
title: Конвертация презентаций PowerPoint в HTML на C++
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/cpp/convert-powerpoint-to-html/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в HTML
- презентация в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- сохранить PowerPoint как HTML
- сохранить презентацию как HTML
- сохранить слайд как HTML
- сохранить PPT как HTML
- сохранить PPTX как HTML
- экспортировать PPT в HTML
- экспортировать PPTX в HTML
- C++
- Aspose.Slides
description: "Конвертируйте презентации PowerPoint в адаптивный HTML на C++. Сохраняйте макет, ссылки и изображения с помощью руководства по конвертации Aspose.Slides для быстрых и безошибочных результатов."
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формат HTML с использованием C++. Она охватывает следующие темы.

- [Конвертировать PowerPoint в HTML на C++](#convert-powerpoint-to-html)
- [Конвертировать PPT в HTML на C++](#convert-powerpoint-to-html)
- [Конвертировать PPTX в HTML на C++](#convert-powerpoint-to-html)
- [Конвертировать ODP в HTML на C++](#convert-powerpoint-to-html)
- [Конвертировать слайд PowerPoint в HTML на C++](#convert-slide-to-html)

## **PowerPoint в HTML на C++**

Для примеров кода на C++ по конвертации PowerPoint в HTML, см. раздел ниже, а именно [Конвертировать PowerPoint в HTML](#convert-powerpoint-to-html). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation и сохранять их в формат HTML.

## **О конвертации PowerPoint в HTML**

С помощью [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/), приложения и разработчики могут конвертировать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.  

**Aspose.Slides** предоставляет множество параметров (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)), определяющих процесс конвертации PowerPoint в HTML:

* Конвертировать всю презентацию PowerPoint в HTML.  
* Конвертировать отдельный слайд в презентации PowerPoint в HTML.  
* Конвертировать медиа презентации (изображения, видео и т.д.) в HTML.  
* Конвертировать презентацию PowerPoint в адаптивный HTML.  
* Конвертировать презентацию PowerPoint в HTML с включением или исключением заметок выступающего.  
* Конвертировать презентацию PowerPoint в HTML с включением или исключением комментариев.  
* Конвертировать презентацию PowerPoint в HTML с оригинальными или внедрёнными шрифтами.  
* Конвертировать презентацию PowerPoint в HTML с использованием нового стиля CSS.  

{{% alert color="primary" %}} 

С помощью собственного API Aspose разработала бесплатные конвертеры [презентация в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html), и т.д.  

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Возможно, вы захотите ознакомиться с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Помимо описанных здесь процессов конвертации, Aspose.Slides также поддерживает следующие операции конвертации, связанные с форматом HTML: 

* [HTML в изображение](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **Конвертировать PowerPoint в HTML**

С помощью Aspose.Slides вы можете конвертировать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
   * Загрузите **.ppt** в класс _Presentation_ для **Конвертировать PPT в HTML на C++**
   * Загрузите **.pptx** в класс _Presentation_ для **Конвертировать PPTX в HTML на C++**
   * Загрузите **.odp** в класс _Presentation_ для **Конвертировать ODP в HTML на C++**
3. Используйте метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) чтобы сохранить объект в виде HTML‑файла.

Этот код демонстрирует, как конвертировать PowerPoint в HTML на C++:
```cpp
// Создайте объект Presentation, представляющий файл презентации
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Сохранение презентации в HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **Конвертировать PowerPoint в адаптивный HTML**

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller), позволяющий генерировать адаптивные HTML‑файлы. Этот код показывает, как конвертировать презентацию PowerPoint в адаптивный HTML на C++:
```cpp
// Создайте объект Presentation, представляющий файл презентации
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// Сохранение презентации в HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **Конвертировать PowerPoint в HTML с заметками**

Этот код демонстрирует, как конвертировать PowerPoint в HTML с заметками в C++:
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Сохранение страниц заметок
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **Конвертировать PowerPoint в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller), который позволяет внедрять все шрифты презентации при её конвертации в HTML.  

Чтобы предотвратить встраивание некоторых шрифтов, вы можете передать массив названий шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller). Популярные шрифты, такие как Calibri или Arial, при использовании в презентации встраивать не требуется, так как большинство систем уже содержат их. Когда такие шрифты встраиваются, получаемый HTML‑документ становится излишне большим.  

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) поддерживает наследование и предоставляет метод [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77), который предназначен для переопределения. 
```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// исключить шрифты презентации по умолчанию
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```


## **Конвертировать PowerPoint в HTML с изображениями высокого качества**

По умолчанию при конвертации PowerPoint в HTML Aspose.Slides выводит небольшие HTML‑файлы с изображениями 72 DPI и удалёнными обрезанными областями. Чтобы получить HTML‑файлы с изображениями более высокого качества, необходимо установить свойство `PicturesCompression` (из класса `HtmlOptions`) в значение 96 (т.е. `PicturesCompression::Dpi96`) или выше [значения](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8).  

Этот C++‑код показывает, как конвертировать презентацию PowerPoint в HTML, получая изображения высокого качества с разрешением 150 DPI (т.е. `PicturesCompression::Dpi150`):
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


Этот код на C++ демонстрирует, как вывести HTML с изображениями полного качества:
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **Конвертировать слайд в HTML**

Чтобы конвертировать отдельный слайд в PowerPoint в HTML, необходимо создать экземпляр того же класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), который используется для конвертации целых презентаций, а затем применить метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) для сохранения файла в формате HTML. Класс [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) может использоваться для указания дополнительных параметров конвертации:

Этот C++‑код показывает, как конвертировать слайд в презентации PowerPoint в HTML:
``` cpp
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

``` cpp
void Run()
{
    String dataDir = GetDataPath();
    
    auto presentation = System::MakeObject<Presentation>(dataDir + u"Individual-Slide.pptx");

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>();
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


## **Сохранить CSS и изображения при экспорте в HTML**

Используя новые файлы стилей CSS, вы можете легко изменить оформление HTML‑файла, полученного в результате конвертации PowerPoint в HTML.  

C++‑код в этом примере показывает, как использовать переопределяемые методы для создания пользовательского HTML‑документа со ссылкой на файл CSS:
``` cpp
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
        generator->AddHtml(u"<!-- Embedded fonts -->");
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


## **Связать все шрифты при конвертации презентации в HTML**

Если вы не хотите встраивать шрифты (чтобы не увеличивать размер получаемого HTML), вы можете связать все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`.  

Этот C++‑код показывает, как конвертировать PowerPoint в HTML, связывая все шрифты и исключая «Calibri» и «Arial» (поскольку они уже присутствуют в системе):
```cpp
class LinkAllFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkAllFontsHtmlController(ArrayPtr<String> fontNameExcludeList, String basePath)
        :   EmbedAllFontsHtmlController(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    void WriteFont(SharedPtr<IHtmlGenerator> generator, SharedPtr<IFontData> originalFont, SharedPtr<IFontData> substitutedFont,
        String fontStyle, String fontWeight, ArrayPtr<uint8_t> fontData)
    {
        String fontName = substitutedFont == nullptr ? originalFont->get_FontName() : substitutedFont->get_FontName();
        String path = String::Format(u"{0}.woff", fontName); // может потребоваться очистка пути
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

``` cpp
void Run()
{
    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    // исключить шрифты презентации по умолчанию
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    
    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    
    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```


## **Конвертировать PowerPoint в адаптивный HTML**

Этот C++‑код показывает, как конвертировать презентацию PowerPoint в адаптивный HTML:
```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **Экспортировать медиа‑файлы в HTML**

С помощью Aspose.Slides for C++ вы можете экспортировать медиа‑файлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
1. Получите ссылку на слайд.  
1. Добавьте видео на слайд.  
1. Сохраните презентацию в виде HTML‑файла.  

Этот C++‑код показывает, как добавить видео в презентацию и затем сохранить её в HTML:
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


## **FAQ**

**Какова производительность Aspose.Slides при конвертации нескольких презентаций в HTML?**  
Производительность зависит от размера и сложности презентаций. Aspose.Slides обладает высокой эффективностью и масштабируемостью для пакетных операций. Чтобы достичь оптимальной производительности при конвертации большого количества презентаций, рекомендуется по возможности использовать многопоточность или параллельную обработку.  

**Поддерживает ли Aspose.Slides экспорт гиперссылок в HTML?**  
Да, Aspose.Slides полностью поддерживает экспорт внедрённых гиперссылок в HTML. При конвертации презентаций в формат HTML гиперссылки сохраняются автоматически и остаются кликабельными.  

**Существует ли ограничение на количество слайдов при конвертации презентаций в HTML?**  
Ограничения на количество слайдов при использовании Aspose.Slides нет. Вы можете конвертировать презентации любой длины. Однако для презентаций, содержащих очень большое количество слайдов, производительность может зависеть от доступных ресурсов вашего сервера или системы.