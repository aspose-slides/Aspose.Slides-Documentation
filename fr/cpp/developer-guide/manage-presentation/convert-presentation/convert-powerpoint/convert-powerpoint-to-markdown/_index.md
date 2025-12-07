---
title: Convertir des présentations PowerPoint en Markdown en C++
linktitle: PowerPoint en Markdown
type: docs
weight: 140
url: /fr/cpp/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en MD
- présentation en MD
- diapositive en MD
- PPT en MD
- PPTX en MD
- enregistrer PowerPoint en Markdown
- enregistrer présentation en Markdown
- enregistrer diapositive en Markdown
- enregistrer PPT en MD
- enregistrer PPTX en MD
- exporter PPT en MD
- exporter PPTX en MD
- PowerPoint
- présentation
- Markdown
- C++
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint—PPT, PPTX—en Markdown clair avec Aspose.Slides pour C++, automatisez la documentation et conservez le formatage."
---

{{% alert color="info" %}} 

La prise en charge de la conversion de PowerPoint en markdown a été implémentée dans [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

L'exportation de PowerPoint en markdown est **sans images** par défaut. Si vous souhaitez exporter un document PowerPoint contenant des images, vous devez définir `SaveOptions::MarkdownExportType::Visual)` et également définir le `BasePath` où les images référencées dans le document markdown seront enregistrées.

{{% /alert %}} 

## **Convertir PowerPoint en Markdown**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) pour représenter un objet de présentation.  
2. Utilisez la méthode [Save ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)pour enregistrer l'objet sous forme de fichier markdown.

Ce code C++ vous montre comment convertir PowerPoint en markdown :
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **Convertir PowerPoint en variante Markdown**

Aspose.Slides vous permet de convertir PowerPoint en markdown (contenant une syntaxe de base), CommonMark, markdown à la saveur GitHub, Trello, XWiki, GitLab et 17 autres variantes de markdown.

Ce code C++ vous montre comment convertir PowerPoint en CommonMark : 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


Les 23 variantes de markdown prises en charge sont [listées sous l'énumération Flavor](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la classe [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir une présentation contenant des images en Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fournit des propriétés et des énumérations qui vous permettent d'utiliser certaines options ou paramètres pour le fichier markdown résultant. L'énumération [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) peut, par exemple, être définie sur des valeurs qui déterminent comment les images sont rendues ou gérées : `Sequential`, `TextOnly`, `Visual`.

### **Convertir les images séquentiellement**

Si vous voulez que les images apparaissent individuellement, les unes après les autres, dans le markdown résultant, choisissez l'option séquentielle. Ce code C++ vous montre comment convertir une présentation contenant des images en markdown :
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


### **Convertir les images visuellement**

Si vous voulez que les images apparaissent ensemble dans le markdown résultant, choisissez l'option visuelle. Dans ce cas, les images seront enregistrées dans le répertoire actuel de l'application (et un chemin relatif sera créé pour elles dans le document markdown), ou vous pouvez spécifier le chemin et le nom de dossier de votre choix.

Ce code C++ illustre l'opération : 
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

**Les hyperliens sont-ils conservés lors de l'exportation en Markdown ?**

Oui. Les [hyperliens](/slides/fr/cpp/manage-hyperlinks/) de texte sont conservés comme des liens Markdown standard. Les [transitions](/slides/fr/cpp/slide-transition/) et les [animations](/slides/fr/cpp/powerpoint-animation/) des diapositives ne sont pas converties.

**Puis-je accélérer la conversion en l'exécutant sur plusieurs threads ?**

Vous pouvez paralléliser le traitement à travers les fichiers, mais [ne pas partager](/slides/fr/cpp/multithreading/) la même instance de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) entre les threads. Utilisez des instances ou des processus distincts par fichier pour éviter les conflits.

**Que se passe-t-il avec les images — où sont-elles enregistrées et les chemins sont-ils relatifs ?**

Les [images](/slides/fr/cpp/image/) sont exportées vers un dossier dédié, et le fichier Markdown les référence par des chemins relatifs par défaut. Vous pouvez configurer le chemin de sortie de base et le nom du dossier d’actifs pour maintenir une structure de dépôt prévisible.