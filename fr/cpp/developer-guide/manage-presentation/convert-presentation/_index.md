---
title: Convertir des présentations vers plusieurs formats en C++
linktitle: Convertir la présentation
type: docs
weight: 70
url: /fr/cpp/convert-presentation/
keywords:
- convertir présentation
- exporter présentation
- PPT en PPTX
- PPTX en PPT
- ODP en PPTX
- PPT en PDF
- PPTX en PDF
- ODP en PDF
- PPT en HTML
- PPTX en HTML
- ODP en HTML
- PPT en PNG
- PPTX en PNG
- ODP en PNG
- PPTX en JPG
- ODP en JPG
- PPT en XPS
- PPTX en XPS
- ODP en XPS
- PPT en TIFF
- PPTX en TIFF
- ODP en TIFF
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Convertir les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF, et plus avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides pour C++ peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir les fichiers PPT hérités en PPTX modernes, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier des diapositives en HTML, ou rendre les diapositives sous forme de fichiers image pour les aperçus, les vignettes et les archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options spécifiques au format si nécessaire. Pour les formats image, chaque diapositive est rendue séparément puis enregistrée en tant qu’image raster ou vectorielle. Les articles dédiés ci‑dessous fournissent les détails d’implémentation pour chaque cas.

## **Choisissez un scénario de conversion**

Utilisez les articles ci‑dessous pour des exemples C++ complets et les options spécifiques à chaque format.

| Scénario | À utiliser lorsque vous avez besoin de | Article |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Moderniser les fichiers PPT hérités, normaliser les fichiers PPTX existants, ou convertir les présentations OpenDocument en PPTX PowerPoint. | [Convert PPT to PPTX](/slides/fr/cpp/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/fr/cpp/convert-odp-to-pptx/), [Save Presentations](/slides/fr/cpp/save-presentation/) |
| PPTX to PPT | Enregistrer une présentation PowerPoint moderne au format PPT binaire plus ancien pour assurer la compatibilité avec les flux de travail plus anciens. | [Convert PPTX to PPT](/slides/fr/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Créer des documents portables, recherchables et à mise en page fixe pour le partage, l'impression ou l'archivage. | [Convert PowerPoint to PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convert PowerPoint to PDF with Notes](/slides/fr/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publier des présentations sous forme de pages HTML et contrôler les images, les polices, les notes et les options de mise en page réactive. | [Convert PowerPoint to HTML](/slides/fr/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exporter les diapositives vers HTML5 pour une visualisation dans le navigateur avec le formatage et l'interactivité préservés. | [Convert Presentations to HTML5](/slides/fr/cpp/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendre chaque diapositive en image PNG pour les aperçus, les vignettes ou la diffusion web. | [Convert PowerPoint to PNG](/slides/fr/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité de l'image. | [Convert PowerPoint to JPG](/slides/fr/cpp/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exporter des diapositives individuelles au format graphiques vectorielles évolutives. | [Render Slide as SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Générer des documents XPS à mise en page fixe. | [Convert PowerPoint to XPS](/slides/fr/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Enregistrer une présentation sous forme de fichier TIFF multipage pour l'impression, la numérisation, le fax ou les flux de travail d'archivage. | [Convert PowerPoint to TIFF](/slides/fr/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Enregistrer les diapositives avec les notes du présentateur au format TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/fr/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Convertir les diapositives en document Word lorsque vous avez besoin d'une sortie de type document. | [Convert PowerPoint to Word](/slides/fr/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail textuels. | [Convert PowerPoint to Markdown](/slides/fr/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Créer une présentation PowerPoint au format XML textuel pour l'inspection, la comparaison, le dépannage ou les flux de travail basés sur XML. | [Convert PowerPoint to XML](/slides/fr/cpp/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Créer un GIF animé à partir des diapositives. | [Convert PowerPoint to Animated GIF](/slides/fr/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Construire un flux d'exportation vidéo à partir des diapositives de la présentation. | [Convert PowerPoint to Video](/slides/fr/cpp/convert-powerpoint-to-video/) |
| Presentation to XAML | Exporter les diapositives en XAML pour les scénarios d'interface utilisateur C++. | [Export Presentations to XAML](/slides/fr/cpp/export-to-xaml/) |

Pour une liste plus étendue des formats d'entrée et de sortie, voir [Formats de fichiers pris en charge](/slides/fr/cpp/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides pour C++ prend en charge la conversion à partir des formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, de sorte qu'un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en changeant uniquement le fichier d'entrée.

Lors de la conversion de fichiers ODP, gardez à l'esprit que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque disposition et chaque fonctionnalité de formatage de la même façon. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convert OpenDocument Presentations](/slides/fr/cpp/convert-openoffice-odp/) lorsque vous avez besoin d'une orientation spécifique au format.

## **Conversion PPT vers PPTX**

PPT est le format PowerPoint binaire plus ancien, tandis que PPTX est le format Office Open XML moderne. Aspose.Slides pour C++ prend en charge une conversion PPT vers PPTX à haute fidélité tout en préservant des structures de présentation complexes telles que les maîtres, les dispositions, les diapositives, les graphiques, les formes groupées, les espaces réservés, les cadres de texte, les textures et les remplissages d’image.

Pour plus de détails, voir [Convert PPT to PPTX](/slides/fr/cpp/convert-ppt-to-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque le rendu doit être identique sur tous les appareils et ne doit pas être modifié comme une présentation. Les articles dédiés sur PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives masquées, les notes, la qualité d’image, la compression, le format pixel et la taille de sortie.

## **Exportation HTML et Image**

L'exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication web et le partage léger. L'exportation d'images est utile lorsque chaque diapositive doit devenir un aperçu, une vignette ou un actif raster distinct. Utilisez les articles PNG, JPG et SVG pour les directives de rendu spécifiques aux formats.

## **FAQ**

**Ai-je besoin de Microsoft PowerPoint pour convertir les présentations ?**

Non. Aspose.Slides pour C++ est une bibliothèque autonome qui ne nécessite ni Microsoft PowerPoint ni l'automatisation Office.

**Puis‑je convertir en lot de nombreuses présentations ?**

Oui. Chargez chaque présentation, enregistrez‑la dans le format requis et libérez l’objet présentation après le traitement. Pour le traitement parallèle, utilisez des instances de présentation distinctes et suivez les directives de [multithreading](/slides/fr/cpp/multithreading/).

**Puis‑je exporter uniquement des diapositives sélectionnées ?**

Oui. Plusieurs méthodes d'exportation permettent de fournir des index de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l'article dédié au format cible.

**Puis‑je inclure les diapositives masquées lors de l'exportation vers PDF ou XPS ?**

Oui. Utilisez les paramètres d'exportation des diapositives masquées décrits dans les articles de conversion [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/cpp/convert-powerpoint-to-xps/).

**Puis‑je créer une sortie PDF/A ?**

Oui. Des paramètres de conformité PDF sont disponibles pour l'exportation PDF. Voir [Convert PowerPoint to PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) pour les détails.

**Comment les polices sont‑elles gérées pendant la conversion ?**

Aspose.Slides peut utiliser des polices incorporées, la récupération de polices et les paramètres de substitution de polices. Consultez [Embedded Font](/slides/fr/cpp/embedded-font/), [Fallback Font](/slides/fr/cpp/fallback-font/) et [Font Substitution](/slides/fr/cpp/font-substitution/).