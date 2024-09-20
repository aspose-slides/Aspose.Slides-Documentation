---
title: Преобразование PowerPoint в Markdown на C++
type: docs
weight: 140
url: /cpp/convert-powerpoint-to-markdown/
keywords: "Преобразование PowerPoint в Markdown, Преобразовать ppt в md, PowerPoint, PPT, PPTX, Презентация, Markdown, C++, CPP, Aspose.Slides для C++"
description: "Преобразование PowerPoint в Markdown на C++"
---

{{% alert color="info" %}} 

Поддержка преобразования PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown по умолчанию **без изображений**. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, вам нужно установить `SaveOptions::MarkdownExportType::Visual)` и также указать `BasePath`, где будут сохранены изображения, на которые ссылается markdown документ.

{{% /alert %}} 

## **Преобразование PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) для представления объекта презентации.
2. Используйте метод [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) для сохранения объекта как markdown файла.

Этот код на C++ демонстрирует, как преобразовать PowerPoint в markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## Преобразование PowerPoint в разные варианты Markdown

Aspose.Slides позволяет преобразовывать PowerPoint в markdown (с содержащейся базовой синтаксической разметкой), CommonMark, GitHub-совместимый markdown, Trello, XWiki, GitLab и 17 других вариантов markdown.

Этот код на C++ демонстрирует, как преобразовать PowerPoint в CommonMark:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

23 поддерживаемых варианта markdown [перечислены в перечислении Flavor](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) в классе [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Преобразование презентации с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) предоставляет свойства и перечисления, которые позволяют использовать определенные варианты или настройки для результирующего markdown файла. Например, перечисление [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) может быть установлено на значения, определяющие, как обрабатываются или отображаются изображения: `Последовательно`, `Только текст`, `Визуально`.

### **Последовательное преобразование изображений**

Если вы хотите, чтобы изображения отображались по одному в результирующем markdown, вам нужно выбрать последовательный вариант. Этот код на C++ демонстрирует, как преобразовать презентацию с изображениями в markdown:

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

### **Визуальное преобразование изображений**

Если вы хотите, чтобы изображения отображались вместе в результирующем markdown, вам нужно выбрать визуальный вариант. В этом случае изображения будут сохранены в текущем каталоге приложения (и для них будет построен относительный путь в markdown документе), или вы можете указать предпочитаемый путь и имя папки.

Этот код на C++ демонстрирует операцию:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```