---
title: Convertir des présentations en plusieurs formats avec Python
linktitle: Convertir des présentations
type: docs
weight: 70
url: /fr/python-net/convert-presentation/
keywords:
- convertir une présentation
- exporter une présentation
- PPT vers PPTX
- PPTX vers PPT
- ODP vers PPTX
- PPT vers PDF
- PPTX vers PDF
- ODP vers PDF
- PPT vers HTML
- PPTX vers HTML
- ODP vers HTML
- PPT vers PNG
- PPTX vers PNG
- ODP vers PNG
- PPTX vers JPG
- ODP vers JPG
- PPT vers XPS
- PPTX vers XPS
- ODP vers XPS
- PPT vers TIFF
- PPTX vers TIFF
- ODP vers TIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Convertissez les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF et bien plus avec Aspose.Slides for Python via .NET."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir les fichiers PPT anciens en PPTX modernes, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier les diapositives en HTML, ou rendre les diapositives sous forme de fichiers image pour des aperçus, des vignettes et des archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options spécifiques au format si nécessaire. Pour les formats image, chaque diapositive est rendue séparément puis enregistrée sous forme d'image raster ou vectorielle. Les articles dédiés liés ci‑dessous fournissent les détails d’implémentation pour chaque cas.

## **Choisissez un scénario de conversion**

Utilisez les articles ci‑bas pour des exemples Python complets et les options spécifiques à chaque format.

| Scénario | Utilisez‑le lorsque vous devez | Article |
| --- | --- | --- |
| PPT/PPTX/ODP vers PPTX | Modernisez les fichiers PPT anciens, normalisez les fichiers PPTX existants, ou convertissez les présentations OpenDocument en PPTX PowerPoint. | [Convert PPT to PPTX](/slides/fr/python-net/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/fr/python-net/convert-odp-to-pptx/), [Save Presentations](/slides/fr/python-net/save-presentation/) |
| PPTX vers PPT | Enregistrez une présentation PowerPoint moderne au format binaire PPT plus ancien pour assurer la compatibilité avec les flux de travail plus anciens. | [Convert PPTX to PPT](/slides/fr/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP vers PDF | Créez des documents portables, interrogeables et à mise en page fixe pour le partage, l’impression ou l’archivage. | [Convert PowerPoint to PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP vers PDF avec notes | Exportez les notes du présentateur avec le contenu des diapositives. | [Convert PowerPoint to PDF with Notes](/slides/fr/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP vers HTML | Publiez les présentations sous forme de pages HTML et contrôlez les images, les polices, les notes et les options de mise en page responsive. | [Convert PowerPoint to HTML](/slides/fr/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP vers HTML5 | Exportez les diapositives vers HTML5 pour la visualisation dans le navigateur avec le formatage et l’interactivité préservés. | [Convert Presentations to HTML5](/slides/fr/python-net/export-to-html5/) |
| PPT/PPTX/ODP vers PNG | Rendez chaque diapositive sous forme d’image PNG pour les aperçus, les vignettes ou la sortie Web. | [Convert PowerPoint to PNG](/slides/fr/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP vers JPG | Rendez les diapositives sous forme d’images JPG et contrôlez les dimensions et la qualité de l’image. | [Convert PowerPoint to JPG](/slides/fr/python-net/convert-powerpoint-to-jpg/) |
| Diapositive vers SVG | Exportez les diapositives individuelles en tant que graphiques vectoriels évolutifs. | [Render Slide as SVG](/slides/fr/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP vers XPS | Générez des documents XPS à mise en page fixe. | [Convert PowerPoint to XPS](/slides/fr/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP vers TIFF | Enregistrez une présentation sous forme de fichier TIFF multipage pour l’impression, la numérisation, le fax ou les flux de travail d’archivage. | [Convert PowerPoint to TIFF](/slides/fr/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP vers TIFF avec notes | Enregistrez les diapositives avec les notes du présentateur en TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/fr/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP vers Word | Convertissez les diapositives en document Word lorsque vous avez besoin d’une sortie de type document. | [Convert PowerPoint to Word](/slides/fr/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP vers Markdown | Extrayez le contenu de la présentation en Markdown pour la documentation et les flux de travail textuels. | [Convert PowerPoint to Markdown](/slides/fr/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP vers GIF animé | Créez un GIF animé à partir des diapositives. | [Convert PowerPoint to Animated GIF](/slides/fr/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP vers vidéo | Construisez un flux d’exportation vidéo à partir des diapositives de la présentation. | [Convert PowerPoint to Video](/slides/fr/python-net/convert-powerpoint-to-video/) |
| Présentation vers XAML | Exportez les diapositives vers XAML pour les scénarios d’interface Python ou .NET. | [Export Presentations to XAML](/slides/fr/python-net/export-to-xaml/) |

Pour une liste plus complète des formats d’entrée et de sortie, consultez [Supported File Formats](/slides/fr/python-net/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for Python via .NET prend en charge la conversion à partir des formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, de sorte qu’un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en modifiant uniquement le fichier d’entrée.

Lors de la conversion de fichiers ODP, souvenez‑vous que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque disposition et fonction de formatage de la même manière exacte. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convert OpenDocument Presentations](/slides/fr/python-net/convert-openoffice-odp/) lorsque vous avez besoin d’orientation spécifique au format.

## **Conversion PPT vers PPTX**

PPT est le format binaire PowerPoint plus ancien, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for Python via .NET prend en charge la conversion PPT vers PPTX avec une haute fidélité tout en préservant des structures de présentation complexes telles que les maîtres, dispositions, diapositives, graphiques, formes groupées, espaces réservés, cadres de texte, textures et remplissages d’image.

Pour plus de détails, consultez [Convert PPT to PPTX](/slides/fr/python-net/convert-ppt-to-pptx/) et [PPT vs PPTX](/slides/fr/python-net/ppt-vs-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque le résultat doit apparaître de la même façon sur tous les appareils et ne doit pas être modifié comme une présentation. Les articles dédiés PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives masquées, les notes, la qualité de l’image, la compression, le format de pixel et la taille de sortie.

## **Exportation HTML et Image**

L’exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication Web et le partage léger. L’exportation d’image est utile quand chaque diapositive doit devenir un aperçu, une vignette ou un actif raster distinct. Utilisez les articles PNG, JPG et SVG pour des directives de rendu spécifiques au format.

## **FAQ**

**Ai‑je besoin de Microsoft PowerPoint pour convertir des présentations ?**

Non. Aspose.Slides for Python via .NET est une bibliothèque autonome et ne nécessite ni Microsoft PowerPoint ni l’automatisation d’Office.

**Puis‑je convertir en lot de nombreuses présentations ?**

Oui. Chargez chaque présentation, enregistrez‑la dans le format requis, puis libérez l’objet présentation après le traitement. Pour le traitement parallèle, utilisez des instances de présentation distinctes et suivez les directives de [multithreading](/slides/fr/python-net/multithreading/).

**Puis‑je exporter uniquement des diapositives sélectionnées ?**

Oui. Plusieurs méthodes d’exportation permettent de transmettre les index de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l’article dédié pour le format cible.

**Puis‑je inclure les diapositives masquées lors de l’exportation en PDF ou XPS ?**

Oui. Utilisez les paramètres d’exportation des diapositives masquées décrits dans les articles de conversion [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/python-net/convert-powerpoint-to-xps/).

**Puis‑je créer une sortie PDF/A ?**

Oui. Les paramètres de conformité PDF sont disponibles pour l’exportation PDF. Voir [Convert PowerPoint to PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/) pour plus de détails.

**Comment les polices sont‑elles gérées lors de la conversion ?**

Aspose.Slides peut utiliser des polices incorporées, une police de secours et des paramètres de substitution de police. Voir [Embedded Font](/slides/fr/python-net/embedded-font/), [Fallback Font](/slides/fr/python-net/fallback-font/) et [Font Substitution](/slides/fr/python-net/font-substitution/).