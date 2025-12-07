---
title: Конвертировать презентации PowerPoint в Markdown на C++
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/cpp/convert-powerpoint-to-markdown/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в MD
- презентация в MD
- слайд в MD
- PPT в MD
- PPTX в MD
- сохранить PowerPoint как Markdown
- сохранить презентацию как Markdown
- сохранить слайд как Markdown
- сохранить PPT как MD
- сохранить PPTX как MD
- экспортировать PPT в MD
- экспортировать PPTX в MD
- PowerPoint
- презентация
- Markdown
- C++
- Aspose.Slides
description: "Конвертируйте слайды PowerPoint—PPT, PPTX—в чистый Markdown с помощью Aspose.Slides для C++, автоматизируйте документацию и сохраняйте форматирование."
---

{{% alert color="info" %}} 
Поддержка конвертации PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).
{{% /alert %}} 

{{% alert color="warning" %}} 
Экспорт PowerPoint в markdown по умолчанию **без изображений**. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, необходимо установить `SaveOptions::MarkdownExportType::Visual)` и также задать `BasePath`, куда будут сохраняться изображения, упомянутые в markdown‑документе.
{{% /alert %}} 

## **Convert PowerPoint to Markdown**
## **Конвертация PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) для представления объекта презентации.  
2. Используйте метод [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) для сохранения объекта в файл markdown.

Этот код C++ показывает, как конвертировать PowerPoint в markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **Convert PowerPoint to Markdown Flavor**
## **Конвертация PowerPoint в варианты Markdown**

Aspose.Slides позволяет конвертировать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab и ещё 17 вариантов markdown.

Этот код C++ показывает, как конвертировать PowerPoint в CommonMark: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


23 поддерживаемых варианта markdown перечислены в перечислении Flavor класса [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).
[listed under the Flavor enumeration](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) from the [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) class.

## **Convert a Presentation Containing Images to Markdown**
## **Конвертация презентации с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие задавать определённые параметры для получаемого markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) может принимать значения, определяющие способ обработки изображений: `Sequential`, `TextOnly`, `Visual`.

### **Convert Images Sequentially**
### **Конвертация изображений последовательно**

Если вы хотите, чтобы изображения отображались по одному последовательно в полученном markdown, выберите параметр последовательной обработки. Этот код C++ показывает, как конвертировать презентацию с изображениями в markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```


### **Convert Images Visually**
### **Конвертация изображений визуально**

Если вы хотите, чтобы изображения отображались вместе в полученном markdown, выберите визуальный параметр. В этом случае изображения будут сохранены в текущий каталог приложения (и в markdown‑документе будет сформирован относительный путь к ним), либо вы можете указать предпочитаемый путь и имя папки.

Этот код C++ демонстрирует операцию: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```


## **FAQ**
## **FAQ**

**Do hyperlinks survive the export to Markdown?**
**Сохраняются ли гиперссылки при экспорте в Markdown?**

Yes. Text [hyperlinks](/slides/ru/cpp/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/ru/cpp/slide-transition/) and [animations](/slides/ru/cpp/powerpoint-animation/) are not converted.
Да. Текстовые [hyperlinks](/slides/ru/cpp/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. Переходы [transitions](/slides/ru/cpp/slide-transition/) и [animations](/slides/ru/cpp/powerpoint-animation/) не конвертируются.

**Can I speed up conversion by running it in multiple threads?**
**Можно ли ускорить конвертацию, запустив её в нескольких потоках?**

You can parallelize across files, but [don’t share](/slides/ru/cpp/multithreading/) the same [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance across threads. Use separate instances/processes per file to avoid contention.
Можно выполнять параллельную обработку разных файлов, но [не делитесь](/slides/ru/cpp/multithreading/) одинаковым объектом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.

**What happens to images—where are they saved, and are the paths relative?**
**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Images](/slides/ru/cpp/image/) are exported to a dedicated folder, and the Markdown file references them with relative paths by default. You can configure the base output path and asset folder name to keep a predictable repository structure.
[Images](/slides/ru/cpp/image/) экспортируются в отдельную папку, а файл Markdown по умолчанию ссылается на них относительными путями. Вы можете настроить базовый путь вывода и имя папки для ресурсов, чтобы поддерживать предсказуемую структуру репозитория.