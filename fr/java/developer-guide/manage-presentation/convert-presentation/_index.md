---
title: Convertir des présentations en plusieurs formats en Java
linktitle: Convertir une présentation
type: docs
weight: 70
url: /fr/java/convert-presentation/
keywords:
- conversion de présentation
- exportation de présentation
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
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF et plus encore avec Aspose.Slides pour Java."
---
## **Aperçu**

Aspose.Slides for Java peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir des fichiers PPT anciens en PPTX modernes, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier des diapositives en HTML, ou rendre des diapositives sous forme de fichiers image pour les aperçus, vignettes et archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options spécifiques au format si nécessaire. Pour les formats d’image, chaque diapositive est rendue séparément puis enregistrée sous forme d’image raster ou vectorielle. Les articles dédiés liés ci‑dessous fournissent les détails d’implémentation pour chaque cas.

## **Choisissez un scénario de conversion**

Utilisez les articles ci‑dessous pour des exemples Java complets et des options spécifiques au format.

| Scénario | Utilisez‑le lorsque vous avez besoin de | Article |
| --- | --- | --- |
| PPT/PPTX/ODP vers PPTX | Moderniser les fichiers PPT anciens, normaliser les fichiers PPTX existants ou convertir des présentations OpenDocument en PowerPoint PPTX. | [Convertir PPT en PPTX](/slides/fr/java/convert-ppt-to-pptx/), [Convertir ODP en PPTX](/slides/fr/java/convert-odp-to-pptx/), [Enregistrer des présentations](/slides/fr/java/save-presentation/) |
| PPTX vers PPT | Enregistrer une présentation PowerPoint moderne au format binaire PPT ancien pour la compatibilité avec des flux de travail plus anciens. | [Convertir PPTX en PPT](/slides/fr/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP vers PDF | Créer des documents portables, consultables et à mise en page fixe pour le partage, l’impression ou l’archivage. | [Convertir PowerPoint en PDF](/slides/fr/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP vers PDF avec notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convertir PowerPoint en PDF avec notes](/slides/fr/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP vers HTML | Publier des présentations sous forme de pages HTML et contrôler les images, polices, notes et options de mise en page responsive. | [Convertir PowerPoint en HTML](/slides/fr/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP vers HTML5 | Exporter les diapositives en HTML5 pour une visualisation dans le navigateur avec mise en forme et interactivité préservées. | [Convertir des présentations en HTML5](/slides/fr/java/export-to-html5/) |
| PPT/PPTX/ODP vers PNG | Rendre chaque diapositive en image PNG pour les aperçus, vignettes ou sorties web. | [Convertir PowerPoint en PNG](/slides/fr/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP vers JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité de l’image. | [Convertir PowerPoint en JPG](/slides/fr/java/convert-powerpoint-to-jpg/) |
| Diapositive vers SVG | Exporter des diapositives individuelles au format graphique vectoriel évolutif. | [Rendre une diapositive en SVG](/slides/fr/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP vers XPS | Générer des documents XPS à mise en page fixe. | [Convertir PowerPoint en XPS](/slides/fr/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP vers TIFF | Enregistrer une présentation sous forme de fichier TIFF multi‑pages pour l’impression, le scan, le fax ou les flux d’archivage. | [Convertir PowerPoint en TIFF](/slides/fr/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP vers TIFF avec notes | Enregistrer les diapositives avec les notes du présentateur en TIFF. | [Convertir PowerPoint en TIFF avec notes](/slides/fr/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX vers Word | Convertir les diapositives en document Word lorsque vous avez besoin d’une sortie au format texte. | [Convertir PowerPoint en Word](/slides/fr/java/convert-powerpoint-to-word/) |
| PPT/PPTX vers Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail texte. | [Convertir PowerPoint en Markdown](/slides/fr/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX vers GIF animé | Créer un GIF animé à partir des diapositives. | [Convertir PowerPoint en GIF animé](/slides/fr/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX vers vidéo | Mettre en place un flux d’exportation vidéo à partir des diapositives de la présentation. | [Convertir PowerPoint en vidéo](/slides/fr/java/convert-powerpoint-to-video/) |
| Présentation vers XAML | Exporter les diapositives vers XAML pour des scénarios d’interface Java. | [Exporter des présentations en XAML](/slides/fr/java/export-to-xaml/) |

Pour une liste plus large de formats d’entrée et de sortie, voir [Formats de fichiers pris en charge](/slides/fr/java/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for Java prend en charge la conversion à partir des formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, de sorte qu’un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en ne changeant que le fichier d’entrée.

Lors de la conversion de fichiers ODP, gardez à l’esprit que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque fonctionnalité de mise en page et de formatage de la même manière exacte. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, passez en revue le résultat et utilisez les options décrites dans [Convertir des présentations OpenDocument](/slides/fr/java/convert-openoffice-odp/) lorsque vous avez besoin de conseils spécifiques au format.

## **Conversion PPT vers PPTX**

PPT est le format binaire PowerPoint ancien, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for Java prend en charge une conversion PPT vers PPTX haute fidélité tout en conservant les structures de présentation complexes telles que les maîtres, les dispositions, les diapositives, les graphiques, les formes groupées, les espaces réservés, les cadres de texte, les textures et les remplissages d’image.

Pour les détails, voir [Convertir PPT en PPTX](/slides/fr/java/convert-ppt-to-pptx/) et [PPT vs PPTX](/slides/fr/java/ppt-vs-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque la sortie doit apparaître de la même façon sur tous les appareils et ne doit pas être modifiable comme une présentation. Les articles dédiés PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives masquées, les notes, la qualité d’image, la compression, le format de pixel et la taille de sortie.

## **Exportation HTML et image**

L’exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication web et le partage léger. L’exportation d’image est utile lorsqu‑each diapositive doit devenir un aperçu, une vignette ou un actif raster distinct. Utilisez les articles PNG, JPG et SVG pour les conseils de rendu spécifiques au format.

## **FAQ**

**Dois‑je disposer de Microsoft PowerPoint pour convertir des présentations ?**

Non. Aspose.Slides for Java est une bibliothèque autonome qui ne nécessite ni Microsoft PowerPoint ni l’automatisation Office.

**Puis‑je convertir en lot de nombreuses présentations ?**

Oui. Chargez chaque présentation, enregistrez‑la dans le format requis et libérez l’objet présentation après traitement. Pour le traitement parallèle, utilisez des instances de présentation distinctes et suivez les recommandations du [multithreading](/slides/fr/java/multithreading/).

**Puis‑je n’exporter que des diapositives sélectionnées ?**

Oui. Plusieurs méthodes d’exportation vous permettent de passer des index de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l’article dédié au format cible.

**Puis‑je inclure les diapositives masquées lors de l’exportation vers PDF ou XPS ?**

Oui. Utilisez les paramètres d’exportation des diapositives masquées décrits dans les articles de conversion [PDF](/slides/fr/java/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/java/convert-powerpoint-to-xps/).

**Puis‑je créer une sortie PDF/A ?**

Oui. Les paramètres de conformité PDF sont disponibles pour l’exportation PDF. Voir [Convertir PowerPoint en PDF](/slides/fr/java/convert-powerpoint-to-pdf/) pour les détails.

**Comment les polices sont‑elles gérées pendant la conversion ?**

Aspose.Slides peut utiliser des polices incorporées, le repli de police et les paramètres de substitution de police. Voir [Police incorporée](/slides/fr/java/embedded-font/), [Police de repli](/slides/fr/java/fallback-font/) et [Substitution de police](/slides/fr/java/font-substitution/).