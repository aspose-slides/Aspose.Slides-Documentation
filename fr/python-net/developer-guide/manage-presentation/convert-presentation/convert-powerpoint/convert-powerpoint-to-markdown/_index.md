---
title: Convertir les présentations PowerPoint en Markdown avec Python
linktitle: PowerPoint en Markdown
type: docs
weight: 140
url: /fr/python-net/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint en Markdown
- convertir OpenDocument en Markdown
- convertir présentation en Markdown
- convertir diapositive en Markdown
- convertir PPT en Markdown
- convertir PPTX en Markdown
- convertir ODP en Markdown
- convertir PowerPoint en MD
- convertir OpenDocument en MD
- convertir présentation en MD
- convertir diapositive en MD
- convertir PPT en MD
- convertir PPTX en MD
- convertir ODP en MD
- PowerPoint
- OpenDocument
- présentation
- Markdown
- Python
- Aspose.Slides
description: "Convertir les diapositives PowerPoint et OpenDocument—PPT, PPTX, ODP—en Markdown propre avec Aspose.Slides pour Python via .NET, automatiser la documentation et conserver le formatage."
---

## **Convertir les présentations en Markdown**

L'exemple ci-dessous montre la façon la plus simple de convertir une présentation PowerPoint en Markdown à l'aide d'Aspose.Slides pour Python via .NET avec les paramètres par défaut.

1. Instancier une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour charger la présentation.
1. Appeler `save` pour l'exporter en tant que fichier Markdown.

Utilisez l'extrait Python ci-dessous pour effectuer la conversion:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```


## **Convertir les présentations en variantes de Markdown**

Aspose.Slides vous permet de convertir des présentations en formats Markdown, y compris le Markdown de base, CommonMark, le Markdown de type GitHub, Trello, XWiki, GitLab et 17 autres variantes Markdown.

L'exemple Python suivant montre comment convertir une présentation PowerPoint en CommonMark :
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```


Les 23 variantes Markdown prises en charge sont répertoriées dans l'énumération [Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la classe [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir les présentations contenant des images en Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fournit des propriétés et des énumérations qui vous permettent de configurer le fichier Markdown résultant. Par exemple, l'énumération [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) contrôle la façon dont les images sont traitées : `SEQUENTIAL`, `TEXT_ONLY` ou `VISUAL`.

### **Convertir les images séquentiellement**

Si vous souhaitez que les images apparaissent individuellement—une après l'autre—dans le Markdown généré, choisissez l'option `SEQUENTIAL`. L'exemple Python ci-dessous montre comment convertir une présentation contenant des images en Markdown.
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```


### **Convertir les images visuellement**

Si vous souhaitez que les images apparaissent groupées dans le Markdown résultant, choisissez l'option `VISUAL`. Dans ce mode, les images sont enregistrées dans le répertoire courant de l'application (et le document Markdown utilise des chemins relatifs), ou vous pouvez spécifier un chemin de sortie personnalisé et le nom du dossier.

L'exemple Python ci-dessous illustre cette opération :
```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```


## **FAQ**

**Les hyperliens survivent-ils à l'exportation vers Markdown ?**

Oui. Les [hyperliens](/slides/fr/python-net/manage-hyperlinks/) du texte sont conservés sous forme de liens Markdown standard. Les [transitions](/slides/fr/python-net/slide-transition/) et les [animations](/slides/fr/python-net/powerpoint-animation/) des diapositives ne sont pas converties.

**Puis-je accélérer la conversion en l'exécutant sur plusieurs threads ?**

Vous pouvez paralléliser par fichier, mais [ne partagez pas](/slides/fr/python-net/multithreading/) la même instance [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) entre les threads. Utilisez des instances/processus distincts par fichier pour éviter les conflits.

**Que se passe‑t‑il avec les images — où sont‑elles sauvegardées et les chemins sont‑ils relatifs ?**

Les [Images](/slides/fr/python-net/image/) sont exportées vers un dossier dédié, et le fichier Markdown les référence avec des chemins relatifs par défaut. Vous pouvez configurer le chemin de sortie de base et le nom du dossier d’actifs pour maintenir une structure de dépôt prévisible.