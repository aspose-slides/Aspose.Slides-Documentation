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
description: "Конвертировать слайды PowerPoint - PPT, PPTX - в чистый Markdown с помощью Aspose.Slides для C++, автоматизировать документацию и сохранять форматирование."
---

{{% alert color="info" %}} 

Поддержка конвертации PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown по умолчанию **без изображений**. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, необходимо установить `SaveOptions::MarkdownExportType::Visual)` и также задать `BasePath`, куда будут сохраняться изображения, на которые ссылается markdown‑документ.

{{% /alert %}} 

## **Конвертация PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) для представления объекта презентации.
2. Используйте метод [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) для сохранения объекта в файл markdown.

Этот код C++ демонстрирует, как конвертировать PowerPoint в markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **Конвертация PowerPoint в варианты Markdown**

Aspose.Slides позволяет конвертировать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab и ещё 17 вариантов markdown.

Этот код C++ демонстрирует, как конвертировать PowerPoint в CommonMark: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


23 поддерживаемых варианта markdown перечислены в [Flavor enumeration](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Конвертация презентации с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие задавать различные параметры для получаемого markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) может принимать значения, определяющие способ отображения или обработки изображений: `Sequential`, `TextOnly`, `Visual`.

### **Последовательная конвертация изображений**

Если вы хотите, чтобы изображения появлялись по отдельности друг за другом в результирующем markdown, нужно выбрать последовательный вариант. Этот код C++ демонстрирует, как конвертировать презентацию с изображениями в markdown:
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


### **Визуальная конвертация изображений**

Если вы хотите, чтобы изображения отображались вместе в результирующем markdown, необходимо выбрать визуальный вариант. В этом случае изображения будут сохранены в текущий каталог приложения (и в markdown‑документе будет сформирован относительный путь к ним), либо вы можете задать собственный путь и имя папки.

Этот код C++ демонстрирует эту операцию: 
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

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [гиперссылки](/slides/ru/cpp/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. Слайды [переходы](/slides/ru/cpp/slide-transition/) и [анимации](/slides/ru/cpp/powerpoint-animation/) не конвертируются.

**Могу ли я ускорить конвертацию, запустив её в нескольких потоках?**

Вы можете выполнять параллельную обработку файлов, но [не делитесь](/slides/ru/cpp/multithreading/) одним и тем же объектом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Images](/slides/ru/cpp/image/) экспортируются в отдельную папку, а Markdown‑файл по умолчанию ссылается на них относительными путями. Вы можете задать базовый путь вывода и имя папки ресурсов, чтобы поддерживать предсказуемую структуру репозитория.