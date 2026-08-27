---
title: Convertir des présentations PowerPoint en Markdown avec Python
linktitle: PowerPoint en Markdown
type: docs
weight: 140
url: /fr/python-net/convert-powerpoint-to-markdown/
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
- enregistrer la présentation en Markdown
- enregistrer la diapositive en Markdown
- enregistrer PPT en MD
- enregistrer PPTX en MD
- exporter PPT en MD
- exporter PPTX en MD
- exportation d'images Markdown
- liens d'images CDN
- PowerPoint
- présentation
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "Convertissez les présentations PPT et PPTX en Markdown avec Python et contrôlez où les images exportées sont enregistrées ainsi que la façon dont le Markdown généré les référence."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET peut convertir des présentations PPT et PPTX en Markdown pour la documentation, les sites statiques, la migration de contenu et les flux de travail de contrôle de version. Vous pouvez choisir une variante de Markdown, contrôler la façon dont le contenu des diapositives est rendu et décider où les images exportées sont stockées ainsi que la manière dont le Markdown généré les référence.

Par défaut, l'exportation Markdown utilise une sortie texte uniquement. Pour exporter du contenu visuel, définissez la propriété [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/markdownsaveoptions/export_type/) sur la valeur `SEQUENTIAL` ou `VISUAL` de l'énumération [MarkdownExportType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` rend les éléments des diapositives séparément et dans l'ordre, tandis que `VISUAL` maintient les éléments groupés ensemble afin de préserver leur relation visuelle. La valeur `TEXT_ONLY` n'émet pas de ressources d'image.

## **Convertir une présentation en Markdown**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/), puis appelez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ipresentation/save/) avec la valeur `MD` de l'énumération [SaveFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Sélectionner une variante de Markdown**

La propriété [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/markdownsaveoptions/flavor/) contrôle la spécification Markdown utilisée pour la sortie. L'énumération [Flavor](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/flavor/) comprend CommonMark, GitHub Flavored Markdown et d'autres variantes prises en charge.

L'exemple suivant exporte une présentation en tant que CommonMark :

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Exporter les images en utilisant le comportement d'enregistrement local par défaut**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/markdownsaveoptions/) fournit deux propriétés pour les images enregistrées localement :

- [base_path](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/markdownsaveoptions/base_path/) spécifie le répertoire de base pour le document Markdown et ses ressources.
- [images_save_folder_name](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) spécifie le sous-répertoire d'images. Sa valeur par défaut est `Images`.

L'exemple suivant rend le contenu visuel, écrit les images dans `output/assets` et crée des références d'image relatives dans le document Markdown :

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides crée le sous-répertoire d'images lorsque l'exportation produit des ressources d'image, mais l'application doit créer `base_path` avant d'enregistrer le fichier Markdown.

## **Préparer le Markdown et les images pour la publication**

Aspose.Slides for Python via .NET n'expose pas les callbacks d'enregistrement d'image .NET permettant de remplacer chaque lien d'image généré lors de l'exportation. À la place, exportez le document Markdown et son dossier d'images vers un répertoire de publication, puis publiez ce répertoire sans modifier sa structure relative.

L'exemple suivant prépare `cdn-origin/presentations/quarterly-report` comme répertoire de publication monté ou synchronisé. L'exemple lui-même n'effectue aucun téléchargement réseau : les liens générés deviennent valides après que le répertoire ait été publié sur le site ou l'emplacement CDN prévu.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Publiez `presentation.md` avec le répertoire `assets`. Le document Markdown utilise des références d'image relatives, de sorte que les deux éléments doivent conserver la même relation à la destination. Si un système de publication nécessite des URL externes absolues, réécrivez les liens générés lors d'une étape de post-traitement séparée après la publication de tous les fichiers image.

## **FAQ**

**Les callbacks Python peuvent-ils personnaliser les fichiers image individuels et les liens lors de l'exportation Markdown ?**

Non. Aspose.Slides for Python via .NET n'expose pas les callbacks .NET `ImageSaving` et `SvgImageSaving`. Configurez la sortie locale avec [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/markdownsaveoptions/base_path/) et [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), puis publiez ou post-traitez les ressources générées.

**Où les images exportées sont‑elles enregistrées ?**

L'emplacement des images est contrôlé par [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/markdownsaveoptions/base_path/) et [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). Le document Markdown référence ces images avec des chemins relatifs.

**Quel séparateur de chemin les liens d'image doivent‑ils utiliser ?**

Utilisez des barres obliques (`/`) dans les liens Markdown et les URL. Utilisez `os.path.join` uniquement pour les chemins du système de fichiers, et normalisez chaque lien créé lors du post‑traitement séparément.

**Les hyperliens sont‑ils conservés lors de l'exportation Markdown ?**

Oui. Les [hyperliens](/slides/fr/python-net/manage-hyperlinks/) du texte sont conservés comme des liens Markdown standard. Les [transitions](/slides/fr/python-net/slide-transition/) et les [animations](/slides/fr/python-net/powerpoint-animation/) des diapositives ne sont pas converties.

**Les présentations peuvent‑elles être converties en Markdown en parallèle ?**

Vous pouvez traiter différents fichiers de présentation en parallèle, mais ne partagez pas la même instance [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) entre les threads. Suivez les [directives multithreading](/slides/fr/python-net/multithreading/) et utilisez une instance distincte pour chaque fichier.