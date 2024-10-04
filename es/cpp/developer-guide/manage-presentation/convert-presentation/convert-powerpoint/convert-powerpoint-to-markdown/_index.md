---
title: Convertir PowerPoint a Markdown en C++
type: docs
weight: 140
url: /cpp/convert-powerpoint-to-markdown/
keywords: "Convertir PowerPoint a Markdown, Convertir ppt a md, PowerPoint, PPT, PPTX, Presentación, Markdown, C++, CPP, Aspose.Slides para C++"
description: "Convertir PowerPoint a Markdown en C++"
---

{{% alert color="info" %}} 

El soporte para la conversión de PowerPoint a markdown fue implementado en [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

La exportación de PowerPoint a markdown es **sin imágenes** por defecto. Si deseas exportar un documento de PowerPoint que contenga imágenes, necesitas establecer `SaveOptions::MarkdownExportType::Visual)` y también establecer la `BasePath` donde se guardarán las imágenes referenciadas en el documento markdown.

{{% /alert %}} 

## **Convertir PowerPoint a Markdown**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) para representar un objeto de presentación.
2. Usa el método [Save ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) para guardar el objeto como un archivo markdown.

Este código en C++ te muestra cómo convertir PowerPoint a markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## Convertir PowerPoint a Sabor Markdown

Aspose.Slides te permite convertir PowerPoint a markdown (contiene sintaxis básica), CommonMark, markdown con sabor a GitHub, Trello, XWiki, GitLab y 17 otros sabores de markdown.

Este código en C++ te muestra cómo convertir PowerPoint a CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

Los 23 sabores de markdown soportados están [listados bajo la enumeración Flavor](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la clase [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir Presentación que Contiene Imágenes a Markdown**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) proporciona propiedades y enumeraciones que te permiten usar ciertas opciones o configuraciones para el archivo markdown resultante. La enumeración [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) puede ser configurada a valores que determinan cómo se representan o manejan las imágenes: `Sequential`, `TextOnly`, `Visual`.

### **Convertir Imágenes Secuencialmente**

Si deseas que las imágenes aparezcan individualmente una después de la otra en el markdown resultante, debes elegir la opción secuencial. Este código en C++ te muestra cómo convertir una presentación que contiene imágenes a markdown:

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

### **Convertir Imágenes Visualmente**

Si deseas que las imágenes aparezcan juntas en el markdown resultante, debes elegir la opción visual. En este caso, las imágenes se guardarán en el directorio actual de la aplicación (y se construirá una ruta relativa para ellas en el documento markdown), o puedes especificar tu ruta y nombre de carpeta preferidos.

Este código en C++ demuestra la operación: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```