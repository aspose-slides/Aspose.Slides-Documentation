---
title: Convertir des présentations vers plusieurs formats sur Android
linktitle: Convertir la présentation
type: docs
weight: 70
url: /fr/androidjava/convert-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Convertir les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF, et plus avec Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Android via Java peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir des fichiers PPT anciens au format PPTX moderne, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier les diapositives en HTML, ou rendre les diapositives sous forme de fichiers image pour les aperçus, les vignettes et les archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options spécifiques au format si nécessaire. Pour les formats d'image, chaque diapositive est rendue séparément puis enregistrée en tant qu'image raster ou vectorielle. Les articles dédiés ci‑dessous fournissent les détails d'implémentation pour chaque cas.

## **Choisir un scénario de conversion**

Utilisez les articles ci‑dessous pour des exemples Java complets et des options spécifiques au format.

| Scénario | Utilisez‑le lorsque vous avez besoin de | Article |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Moderniser les fichiers PPT anciens, normaliser les fichiers PPTX existants, ou convertir les présentations OpenDocument en PPTX PowerPoint. | [Convertir PPT en PPTX](/slides/fr/androidjava/convert-ppt-to-pptx/), [Convertir ODP en PPTX](/slides/fr/androidjava/convert-odp-to-pptx/), [Enregistrer les présentations](/slides/fr/androidjava/save-presentation/) |
| PPTX to PPT | Enregistrer une présentation PowerPoint moderne au format binaire PPT plus ancien pour la compatibilité avec les anciens flux de travail. | [Convertir PPTX en PPT](/slides/fr/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Créer des documents portables, recherchables, à mise en page fixe pour le partage, l'impression ou l'archivage. | [Convertir PowerPoint en PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convertir PowerPoint en PDF avec notes](/slides/fr/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publier les présentations en pages HTML et contrôler les images, polices, notes et les options de mise en page responsive. | [Convertir PowerPoint en HTML](/slides/fr/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exporter les diapositives vers HTML5 pour une visualisation dans le navigateur avec mise en forme et interactivité conservées. | [Convertir les présentations en HTML5](/slides/fr/androidjava/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendre chaque diapositive en image PNG pour les aperçus, vignettes ou sortie web. | [Convertir PowerPoint en PNG](/slides/fr/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité de l'image. | [Convertir PowerPoint en JPG](/slides/fr/androidjava/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exporter les diapositives individuelles au format graphiques vectoriels évolutifs. | [Rendre la diapositive en SVG](/slides/fr/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Générer des documents XPS à mise en page fixe. | [Convertir PowerPoint en XPS](/slides/fr/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Enregistrer une présentation sous forme de fichier TIFF multipage pour l'impression, la numérisation, le fax ou les flux d'archivage. | [Convertir PowerPoint en TIFF](/slides/fr/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Enregistrer les diapositives avec les notes du présentateur en TIFF. | [Convertir PowerPoint en TIFF avec notes](/slides/fr/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Convertir les diapositives en document Word lorsque vous avez besoin d'une sortie de type document. | [Convertir PowerPoint en Word](/slides/fr/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail basés sur du texte. | [Convertir PowerPoint en Markdown](/slides/fr/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Créer un GIF animé à partir des diapositives. | [Convertir PowerPoint en GIF animé](/slides/fr/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Construire un flux d'exportation vidéo à partir des diapositives de présentation. | [Convertir PowerPoint en vidéo](/slides/fr/androidjava/convert-powerpoint-to-video/) |
| Presentation to XAML | Exporter les diapositives en XAML pour les scénarios d'interface Android ou Java. | [Exporter les présentations en XAML](/slides/fr/androidjava/export-to-xaml/) |

Pour une liste plus large de formats d'entrée et de sortie, voir [Formats de fichiers pris en charge](/slides/fr/androidjava/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for Android via Java prend en charge la conversion à partir des formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, de sorte qu'un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en ne modifiant que le fichier d'entrée.

Lors de la conversion de fichiers ODP, rappelez‑vous que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque fonctionnalité de mise en page et de formatage de la même manière exacte. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convertir les présentations OpenDocument](/slides/fr/androidjava/convert-openoffice-odp/) lorsque vous avez besoin d'orientations spécifiques au format.

## **Conversion de PPT vers PPTX**

PPT est le format binaire PowerPoint plus ancien, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for Android via Java prend en charge la conversion haute fidélité de PPT vers PPTX tout en préservant les structures complexes de présentation telles que les maîtres, les mises en page, les diapositives, les graphiques, les formes groupées, les espaces réservés, les cadres de texte, les textures et les remplissages d'images.

Pour plus de détails, voir [Convertir PPT en PPTX](/slides/fr/androidjava/convert-ppt-to-pptx/) et [PPT vs PPTX](/slides/fr/androidjava/ppt-vs-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque la sortie doit être identique sur tous les appareils et ne doit pas être modifiée comme une présentation. Les articles dédiés PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives masquées, les notes, la qualité d'image, la compression, le format pixel et la taille de sortie.

## **Exportation HTML et image**

L'exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication Web et le partage léger. L'exportation d'images est utile lorsque chaque diapositive doit devenir un aperçu, une vignette ou un actif raster distinct. Utilisez les articles PNG, JPG et SVG pour des conseils de rendu spécifiques au format.

## **FAQ**

**Ai‑je besoin de Microsoft PowerPoint pour convertir les présentations ?**

Non. Aspose.Slides for Android via Java est une bibliothèque autonome et ne nécessite pas Microsoft PowerPoint ni d'automatisation Office.

**Puis‑je convertir en lot de nombreuses présentations ?**

Oui. Chargez chaque présentation, enregistrez‑la dans le format requis, puis libérez l'objet présentation après le traitement. Pour le traitement parallèle, utilisez des instances de présentation distinctes et suivez les recommandations de [multithreading](/slides/fr/androidjava/multithreading/).

**Puis‑je exporter uniquement des diapositives sélectionnées ?**

Oui. Plusieurs méthodes d'exportation vous permettent de fournir des indices de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l'article dédié au format cible.

**Puis‑je inclure les diapositives masquées lors de l'exportation en PDF ou XPS ?**

Oui. Utilisez les paramètres d'exportation des diapositives masquées décrits dans les articles de conversion [PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/androidjava/convert-powerpoint-to-xps/).

**Puis‑je créer une sortie PDF/A ?**

Oui. Les paramètres de conformité PDF sont disponibles pour l'exportation PDF. Consultez [Convertir PowerPoint en PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/) pour plus de détails.

**Comment les polices sont‑elles gérées lors de la conversion ?**

Aspose.Slides peut utiliser des polices incorporées, un repli de police et des paramètres de substitution de police. Voir [Police incorporée](/slides/fr/androidjava/embedded-font/), [Police de repli](/slides/fr/androidjava/fallback-font/), et [Substitution de police](/slides/fr/androidjava/font-substitution/).