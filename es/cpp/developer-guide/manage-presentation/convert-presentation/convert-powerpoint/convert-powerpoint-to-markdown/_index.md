---
title: Convertir presentaciones de PowerPoint a Markdown en C++
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /es/cpp/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a MD
- presentación a MD
- diapositiva a MD
- PPT a MD
- PPTX a MD
- guardar PowerPoint como Markdown
- guardar presentación como Markdown
- guardar diapositiva como Markdown
- guardar PPT como MD
- guardar PPTX como MD
- exportar PPT a MD
- exportar PPTX a MD
- PowerPoint
- presentación
- Markdown
- C++
- Aspose.Slides
description: "Convertir diapositivas de PowerPoint - PPT, PPTX - a Markdown limpio con Aspose.Slides para C++, automatizar la documentación y mantener el formato."
---

{{% alert color="info" %}} 

El soporte para la conversión de PowerPoint a markdown se implementó en [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

La exportación de PowerPoint a markdown es **sin imágenes** por defecto. Si desea exportar un documento PowerPoint que contenga imágenes, debe establecer `SaveOptions::MarkdownExportType::Visual)` y también definir `BasePath` donde se guardarán las imágenes referenciadas en el documento markdown.

{{% /alert %}} 

## **Convertir PowerPoint a Markdown**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) para representar un objeto de presentación.  
2. Use el método [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) para guardar el objeto como un archivo markdown.

Este código C++ le muestra cómo convertir PowerPoint a markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **Convertir PowerPoint a un Sabor de Markdown**

Aspose.Slides le permite convertir PowerPoint a markdown (con sintaxis básica), CommonMark, markdown con estilo GitHub, Trello, XWiki, GitLab y 17 sabores de markdown adicionales.

Este código C++ le muestra cómo convertir PowerPoint a CommonMark: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


Los 23 sabores de markdown admitidos están [listados en la enumeración Flavor](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la clase [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir una Presentación con Imágenes a Markdown**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) proporciona propiedades y enumeraciones que le permiten usar ciertas opciones o configuraciones para el archivo markdown resultante. El enumerado [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/), por ejemplo, puede establecerse en valores que determinan cómo se renderizan o gestionan las imágenes: `Sequential`, `TextOnly`, `Visual`.

### **Convertir Imágenes Secuencialmente**

Si desea que las imágenes aparezcan individualmente una tras otra en el markdown resultante, debe elegir la opción secuencial. Este código C++ le muestra cómo convertir una presentación con imágenes a markdown:
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

Si desea que las imágenes aparezcan juntas en el markdown resultante, debe elegir la opción visual. En este caso, las imágenes se guardarán en el directorio actual de la aplicación (y se generará una ruta relativa para ellas en el documento markdown), o puede especificar la ruta y el nombre de carpeta que prefiera.

Este código C++ demuestra la operación: 
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

**¿Los hipervínculos se conservan al exportar a Markdown?**

Sí. Los [hipervínculos](/slides/es/cpp/manage-hyperlinks/) de texto se conservan como enlaces Markdown estándar. Las [transiciones](/slides/es/cpp/slide-transition/) y [animaciones](/slides/es/cpp/powerpoint-animation/) de las diapositivas no se convierten.

**¿Puedo acelerar la conversión ejecutándola en varios hilos?**

Puede paralelizar por archivos, pero [no comparta](/slides/es/cpp/multithreading/) la misma instancia de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) entre hilos. Utilice instancias/procesos separados por archivo para evitar contenciones.

**¿Qué ocurre con las imágenes—dónde se guardan y son las rutas relativas?**

Las [imágenes](/slides/es/cpp/image/) se exportan a una carpeta dedicada, y el archivo Markdown las referencia con rutas relativas por defecto. Puede configurar la ruta base de salida y el nombre de la carpeta de recursos para mantener una estructura de repositorio predecible.