---
title: Convertir des présentations en plusieurs formats en PHP
linktitle: Convertir la présentation
type: docs
weight: 70
url: /fr/php-java/convert-presentation/
keywords:
- convertir présentation
- exporter présentation
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
- PHP
- Aspose.Slides
description: "Convertissez les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF et plus encore avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir les fichiers PPT anciens en PPTX modernes, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier des diapositives en HTML, ou rendre les diapositives sous forme de fichiers image pour des aperçus, des vignettes et des archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options spécifiques au format si nécessaire. Pour les formats d’image, chaque diapositive est rendue séparément puis enregistrée comme image raster ou vecteur. Les articles dédiés liés ci‑dessous fournissent les détails d’implémentation pour chaque cas.

## **Choisissez un scénario de conversion**

Utilisez les articles ci‑dessous pour des exemples PHP complets et des options spécifiques au format.

| Scénario | Utilisez‑le lorsque vous devez | Article |
| --- | --- | --- |
| PPT/PPTX/ODP vers PPTX | Moderniser les fichiers PPT anciens, normaliser les fichiers PPTX existants, ou convertir les présentations OpenDocument en PowerPoint PPTX. | [Convertir PPT en PPTX](/slides/fr/php-java/convert-ppt-to-pptx/), [Convertir ODP en PPTX](/slides/fr/php-java/convert-odp-to-pptx/), [Enregistrer les présentations](/slides/fr/php-java/save-presentation/) |
| PPTX vers PPT | Enregistrer une présentation PowerPoint moderne au format binaire PPT plus ancien pour la compatibilité avec les flux de travail plus anciens. | [Convertir PPTX en PPT](/slides/fr/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP vers PDF | Créer des documents portables, interrogeables, à mise en page fixe pour le partage, l’impression ou l’archivage. | [Convertir PowerPoint en PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP vers PDF avec notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convertir PowerPoint en PDF avec notes](/slides/fr/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP vers HTML | Publier des présentations en pages HTML et contrôler les images, polices, notes et les options de mise en page réactive. | [Convertir PowerPoint en HTML](/slides/fr/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP vers HTML5 | Exporter les diapositives vers HTML5 pour une visualisation dans le navigateur avec le formatage et l’interactivité conservés. | [Convertir les présentations en HTML5](/slides/fr/php-java/export-to-html5/) |
| PPT/PPTX/ODP vers PNG | Rendre chaque diapositive en image PNG pour des aperçus, vignettes ou sortie web. | [Convertir PowerPoint en PNG](/slides/fr/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP vers JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité de l’image. | [Convertir PowerPoint en JPG](/slides/fr/php-java/convert-powerpoint-to-jpg/) |
| Diapositive vers SVG | Exporter des diapositives individuelles en graphiques vectoriels évolutifs. | [Rendre la diapositive en SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP vers XPS | Générer des documents XPS à mise en page fixe. | [Convertir PowerPoint en XPS](/slides/fr/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP vers TIFF | Enregistrer une présentation sous forme de fichier TIFF multipage pour l’impression, la numérisation, le fax ou les flux de travail d’archivage. | [Convertir PowerPoint en TIFF](/slides/fr/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP vers TIFF avec notes | Enregistrer les diapositives avec les notes du présentateur en TIFF. | [Convertir PowerPoint en TIFF avec notes](/slides/fr/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX vers Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail textuels. | [Convertir PowerPoint en Markdown](/slides/fr/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP vers XML | Créer une présentation PowerPoint XML basée sur du texte pour l’inspection, la comparaison, le dépannage ou les flux de travail basés sur XML. | [Convertir PowerPoint en XML](/slides/fr/php-java/convert-powerpoint-to-xml/) |
| PPT/PPTX vers GIF animé | Créer un GIF animé à partir des diapositives. | [Convertir PowerPoint en GIF animé](/slides/fr/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX vers vidéo | Construire un flux d’exportation vidéo à partir des diapositives de présentation. | [Convertir PowerPoint en Vidéo](/slides/fr/php-java/convert-powerpoint-to-video/) |
| Présentation vers XAML | Exporter les diapositives vers XAML pour les scénarios d’interface PHP ou Java. | [Exporter les présentations vers XAML](/slides/fr/php-java/export-to-xaml/) |

Pour une liste plus large de formats d’entrée et de sortie, voir [Formats de fichiers pris en charge](/slides/fr/php-java/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for PHP via Java prend en charge la conversion à partir de formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, de sorte qu’un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en ne changeant que le fichier d’entrée.

Lors de la conversion de fichiers ODP, souvenez‑vous que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque mise en page et fonctionnalité de formatage de la même manière exacte. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convert OpenDocument Presentations](/slides/fr/php-java/convert-openoffice-odp/) lorsque vous avez besoin d’une orientation spécifique au format.

## **Conversion PPT vers PPTX**

PPT est le format binaire PowerPoint plus ancien, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for PHP via Java prend en charge la conversion haute fidélité de PPT vers PPTX tout en conservant les structures complexes de la présentation telles que les maîtres, mises en page, diapositives, graphiques, formes groupées, espaces réservés, cadres de texte, textures et remplissages d’image.

Pour plus de détails, voir [Convertir PPT en PPTX](/slides/fr/php-java/convert-ppt-to-pptx/) et [PPT vs PPTX](/slides/fr/php-java/ppt-vs-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque la sortie doit être identique sur tous les appareils et ne doit pas être modifiée comme une présentation. Les articles dédiés PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives masquées, les notes, la qualité d’image, la compression, le format de pixel et la taille de sortie.

## **Exportation HTML et Image**

L’exportation HTML et HTML5 est utile pour la visualisation dans un navigateur, la publication web et le partage léger. L’exportation d’images est utile lorsque chaque diapositive doit devenir un aperçu, une vignette ou un actif raster distinct. Utilisez les articles PNG, JPG et SVG pour obtenir des instructions de rendu spécifiques au format.

## **FAQ**

**Ai‑je besoin de Microsoft PowerPoint pour convertir des présentations ?**

Non. Aspose.Slides for PHP via Java est une bibliothèque autonome et ne nécessite pas Microsoft PowerPoint ni l’automatisation Office.

**Puis‑je convertir en lot de nombreuses présentations ?**

Oui. Chargez chaque présentation, enregistrez‑la au format requis, et libérez l’objet présentation après le traitement. Pour le traitement parallèle, utilisez des instances de présentation distinctes et suivez les recommandations de [multithreading](/slides/fr/php-java/multithreading/).

**Puis‑je n’exporter que des diapositives sélectionnées ?**

Oui. Plusieurs méthodes d’exportation permettent de spécifier des index de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Voir l’article dédié au format cible.

**Puis‑je inclure les diapositives masquées lors de l’exportation en PDF ou XPS ?**

Oui. Utilisez les paramètres d’exportation des diapositives masquées décrits dans les articles de conversion [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/php-java/convert-powerpoint-to-xps/).

**Puis‑je créer une sortie PDF/A ?**

Oui. Les paramètres de conformité PDF sont disponibles pour l’exportation PDF. Voir [Convert PowerPoint to PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/) pour plus de détails.

**Comment les polices sont‑elles gérées lors de la conversion ?**

Aspose.Slides peut utiliser des polices intégrées, le repli de police et les paramètres de substitution de police. Voir [Embedded Font](/slides/fr/php-java/embedded-font/), [Fallback Font](/slides/fr/php-java/fallback-font/), et [Font Substitution](/slides/fr/php-java/font-substitution/).