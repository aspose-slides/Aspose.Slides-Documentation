---
title: Convertir des présentations en plusieurs formats en C++
linktitle: Convertir la présentation
type: docs
weight: 70
url: /fr/cpp/convert-presentation/
keywords:
- convertir présentation
- exporter la présentation
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

Aspose.Slides for C++ peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir des fichiers PPT anciens en PPTX modernes, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier des diapositives en HTML, ou rendre les diapositives sous forme de fichiers image pour les aperçus, les miniatures et les archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options spécifiques au format si nécessaire. Pour les formats image, chaque diapositive est rendue séparément puis enregistrée sous forme d’image raster ou vectorielle. Les articles dédiés liés ci‑dessous fournissent les détails d’implémentation pour chaque cas.

## **Choisissez un scénario de conversion**

Utilisez les articles ci‑dessous pour des exemples C++ complets et les options spécifiques au format.

| Scénario | Utilisez‑le lorsque vous avez besoin de | Article |
| --- | --- | --- |
| PPT/PPTX/ODP vers PPTX | Moderniser les fichiers PPT anciens, normaliser les fichiers PPTX existants ou convertir des présentations OpenDocument en PowerPoint PPTX. | [Convertir PPT en PPTX](/slides/fr/cpp/convert-ppt-to-pptx/), [Convertir ODP en PPTX](/slides/fr/cpp/convert-odp-to-pptx/), [Enregistrer des présentations](/slides/fr/cpp/save-presentation/) |
| PPTX vers PPT | Enregistrer une présentation PowerPoint moderne au format binaire PPT plus ancien pour la compatibilité avec des flux de travail plus anciens. | [Convertir PPTX en PPT](/slides/fr/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP vers PDF | Créer des documents portables, recherchables, à mise en page fixe pour le partage, l’impression ou l’archivage. | [Convertir PowerPoint en PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP vers PDF avec notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convertir PowerPoint en PDF avec notes](/slides/fr/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP vers HTML | Publier des présentations sous forme de pages HTML et contrôler les images, les polices, les notes et les options de mise en page réactive. | [Convertir PowerPoint en HTML](/slides/fr/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP vers HTML5 | Exporter les diapositives en HTML5 pour la visualisation dans le navigateur avec mise en forme et interactivité conservées. | [Convertir les présentations en HTML5](/slides/fr/cpp/export-to-html5/) |
| PPT/PPTX/ODP vers PNG | Rendre chaque diapositive en image PNG pour les aperçus, les miniatures ou la sortie web. | [Convertir PowerPoint en PNG](/slides/fr/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP vers JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité de l’image. | [Convertir PowerPoint en JPG](/slides/fr/cpp/convert-powerpoint-to-jpg/) |
| Diapositive vers SVG | Exporter des diapositives individuelles en graphiques vectoriels évolutifs. | [Rendre la diapositive en SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP vers XPS | Générer des documents XPS à mise en page fixe. | [Convertir PowerPoint en XPS](/slides/fr/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP vers TIFF | Enregistrer une présentation sous forme de fichier TIFF multi‑pages pour l’impression, la numérisation, le fax ou les workflows d’archivage. | [Convertir PowerPoint en TIFF](/slides/fr/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP vers TIFF avec notes | Enregistrer les diapositives avec les notes du présentateur en TIFF. | [Convertir PowerPoint en TIFF avec notes](/slides/fr/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX vers Word | Convertir les diapositives en document Word lorsque vous avez besoin d’une sortie de type document. | [Convertir PowerPoint en Word](/slides/fr/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX vers Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les workflows basés sur du texte. | [Convertir PowerPoint en Markdown](/slides/fr/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX vers GIF animé | Créer un GIF animé à partir des diapositives. | [Convertir PowerPoint en GIF animé](/slides/fr/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX vers vidéo | Mettre en place un workflow d’exportation vidéo à partir des diapositives de présentation. | [Convertir PowerPoint en vidéo](/slides/fr/cpp/convert-powerpoint-to-video/) |
| Présentation vers XAML | Exporter les diapositives en XAML pour les scénarios d’interface utilisateur C++. | [Exporter les présentations en XAML](/slides/fr/cpp/export-to-xaml/) |

Pour une liste plus large de formats d’entrée et de sortie, voir [Formats de fichiers pris en charge](/slides/fr/cpp/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for C++ prend en charge la conversion à partir de formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, ainsi un workflow qui enregistre un fichier PPTX au format PDF peut généralement être appliqué à un fichier ODP en ne changeant que le fichier d’entrée.

Lors de la conversion de fichiers ODP, gardez à l’esprit que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque fonctionnalité de mise en page et de formatage exactement de la même façon. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convertir les présentations OpenDocument](/slides/fr/cpp/convert-openoffice-odp/) lorsque vous avez besoin d’orientations spécifiques au format.

## **Conversion PPT vers PPTX**

PPT est le format binaire PowerPoint ancien, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for C++ prend en charge la conversion PPT vers PPTX à haute fidélité tout en conservant des structures de présentation complexes telles que les maîtres, les mises en page, les diapositives, les graphiques, les formes groupées, les espaces réservés, les cadres de texte, les textures et les remplissages d’image.

Pour plus de détails, voir [Convertir PPT en PPTX](/slides/fr/cpp/convert-ppt-to-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque la sortie doit être identique sur tous les appareils et ne doit pas être éditée comme une présentation. Les articles dédiés à PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives cachées, les notes, la qualité d’image, la compression, le format de pixel et la taille de sortie.

## **Exportation HTML et image**

L’exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication web et le partage léger. L’exportation d’images est utile lorsqu’il faut que chaque diapositive devienne un aperçu, une vignette ou un actif raster distinct. Utilisez les articles PNG, JPG et SVG pour des recommandations de rendu spécifiques au format.

## **FAQ**

**Dois‑je disposer de Microsoft PowerPoint pour convertir des présentations ?**

Non. Aspose.Slides for C++ est une bibliothèque autonome qui ne nécessite ni Microsoft PowerPoint ni l’automatisation d’Office.

**Puis‑je convertir un grand nombre de présentations en lot ?**

Oui. Chargez chaque présentation, enregistrez‑la dans le format requis, puis libérez l’objet présentation après le traitement. Pour le traitement parallèle, utilisez des instances de présentation distinctes et suivez les consignes de [multithreading](/slides/fr/cpp/multithreading/).

**Puis‑je exporter uniquement des diapositives sélectionnées ?**

Oui. Plusieurs méthodes d’exportation vous permettent de fournir des index de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l’article dédié au format cible.

**Puis‑je inclure les diapositives cachées lors de l’exportation en PDF ou XPS ?**

Oui. Utilisez les paramètres d’exportation des diapositives cachées décrits dans les articles de conversion [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/cpp/convert-powerpoint-to-xps/).

**Puis‑je créer une sortie PDF/A ?**

Oui. Des paramètres de conformité PDF sont disponibles pour l’exportation PDF. Voir [Convertir PowerPoint en PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) pour plus de détails.

**Comment les polices sont‑elles gérées pendant la conversion ?**

Aspose.Slides peut utiliser des polices incorporées, la récupération de polices et les paramètres de substitution de polices. Voir [Police incorporée](/slides/fr/cpp/embedded-font/), [Police de secours](/slides/fr/cpp/fallback-font/) et [Substitution de police](/slides/fr/cpp/font-substitution/).