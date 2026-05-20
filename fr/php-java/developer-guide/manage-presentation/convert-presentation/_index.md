---
title: Convertir des présentations en plusieurs formats en PHP
linktitle: Convertir une présentation
type: docs
weight: 70
url: /fr/php-java/convert-presentation/
keywords:
- convertir une présentation
- exporter une présentation
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
- PHP
- Aspose.Slides
description: "Convertissez les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF et plus encore avec Aspose.Slides pour PHP via Java."
---
## **Aperçu**

Aspose.Slides for PHP via Java peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir les fichiers PPT anciens en PPTX modernes, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier des diapositives en HTML ou rendre les diapositives sous forme de fichiers image pour les aperçus, les miniatures et les archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options propres au format si nécessaire. Pour les formats d'image, chaque diapositive est rendue séparément puis enregistrée en tant qu'image raster ou vectorielle. Les articles dédiés ci‑dessous fournissent les détails d'implémentation pour chaque cas.

## **Choisissez un scénario de conversion**

Utilisez les articles ci‑dessous pour des exemples PHP complets et des options spécifiques au format.

| Scénario | Utilisez‑le lorsque vous avez besoin de | Article |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Moderniser les fichiers PPT anciens, normaliser les fichiers PPTX existants ou convertir les présentations OpenDocument en PPTX PowerPoint. | [Convertir PPT en PPTX](/slides/fr/php-java/convert-ppt-to-pptx/), [Convertir ODP en PPTX](/slides/fr/php-java/convert-odp-to-pptx/), [Enregistrer les présentations](/slides/fr/php-java/save-presentation/) |
| PPTX to PPT | Enregistrer une présentation PowerPoint moderne au format binaire PPT plus ancien pour la compatibilité avec les flux de travail plus anciens. | [Convertir PPTX en PPT](/slides/fr/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Créer des documents portables, interrogeables et à mise en page fixe pour le partage, l'impression ou l'archivage. | [Convertir PowerPoint en PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convertir PowerPoint en PDF avec notes](/slides/fr/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publier des présentations sous forme de pages HTML et contrôler les images, les polices, les notes et les options de mise en page réactive. | [Convertir PowerPoint en HTML](/slides/fr/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exporter les diapositives vers HTML5 pour une visualisation dans le navigateur en conservant le formatage et l'interactivité. | [Convertir les présentations en HTML5](/slides/fr/php-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendre chaque diapositive en image PNG pour les aperçus, les miniatures ou la sortie web. | [Convertir PowerPoint en PNG](/slides/fr/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité des images. | [Convertir PowerPoint en JPG](/slides/fr/php-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exporter des diapositives individuelles en graphiques vectoriels évolutifs. | [Rendre la diapositive en SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Générer des documents XPS à mise en page fixe. | [Convertir PowerPoint en XPS](/slides/fr/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Enregistrer une présentation sous forme de fichier TIFF multi‑pages pour l'impression, la numérisation, le fax ou les flux d'archivage. | [Convertir PowerPoint en TIFF](/slides/fr/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Enregistrer les diapositives avec les notes du présentateur en TIFF. | [Convertir PowerPoint en TIFF avec notes](/slides/fr/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail textuels. | [Convertir PowerPoint en Markdown](/slides/fr/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Créer un GIF animé à partir des diapositives. | [Convertir PowerPoint en GIF animé](/slides/fr/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Établir un flux d'exportation vidéo à partir des diapositives de la présentation. | [Convertir PowerPoint en vidéo](/slides/fr/php-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exporter les diapositives vers XAML pour des scénarios d'interface PHP ou Java. | [Exporter les présentations en XAML](/slides/fr/php-java/export-to-xaml/) |

Pour une liste plus complète des formats d'entrée et de sortie, voir [Formats de fichiers pris en charge](/slides/fr/php-java/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for PHP via Java prend en charge la conversion à partir des formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, ainsi un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en ne changeant que le fichier d'entrée.

Lors de la conversion de fichiers ODP, gardez à l'esprit que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque fonction de mise en page et de formatage de la même manière. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convertir les présentations OpenDocument](/slides/fr/php-java/convert-openoffice-odp/) lorsque vous avez besoin de conseils spécifiques au format.

## **Conversion de PPT en PPTX**

PPT est le format binaire PowerPoint ancien, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for PHP via Java prend en charge une conversion PPT vers PPTX de haute fidélité tout en préservant les structures de présentation complexes telles que les maîtres, les mises en page, les diapositives, les graphiques, les formes groupées, les espaces réservés, les cadres de texte, les textures et les remplissages d'images.

Pour plus de détails, voir [Convertir PPT en PPTX](/slides/fr/php-java/convert-ppt-to-pptx/) et [PPT vs PPTX](/slides/fr/php-java/ppt-vs-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque le résultat doit être identique sur tous les appareils et ne doit pas être édité comme une présentation. Les articles dédiés PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives masquées, les notes, la qualité de l'image, la compression, le format des pixels et la taille de sortie.

## **Exportation HTML et Image**

L'exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication web et le partage léger. L'exportation d'images est utile lorsque chaque diapositive doit devenir un aperçu, une miniature ou un actif raster séparé. Utilisez les articles PNG, JPG et SVG pour des instructions de rendu spécifiques au format.

## **FAQ**

**Ai-je besoin de Microsoft PowerPoint pour convertir les présentations ?**

Non. Aspose.Slides for PHP via Java est une bibliothèque autonome et ne nécessite pas Microsoft PowerPoint ni l'automatisation Office.

**Puis-je convertir en lot de nombreuses présentations ?**

Oui. Chargez chaque présentation, enregistrez‑la dans le format requis et libérez l'objet présentation après le traitement. Pour le traitement parallèle, utilisez des instances de présentation distinctes et suivez les directives [multithreading](/slides/fr/php-java/multithreading/).

**Puis‑je exporter uniquement des diapositives sélectionnées ?**

Oui. Plusieurs méthodes d'exportation vous permettent de transmettre des indices de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Voir l'article dédié pour le format cible.

**Puis‑je inclure les diapositives masquées lors de l'exportation en PDF ou XPS ?**

Oui. Utilisez les paramètres d'exportation des diapositives masquées décrits dans les articles de conversion [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/php-java/convert-powerpoint-to-xps/).

**Puis‑je créer une sortie PDF/A ?**

Oui. Les paramètres de conformité PDF sont disponibles pour l'exportation PDF. Voir [Convertir PowerPoint en PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/) pour plus de détails.

**Comment les polices sont‑elles gérées pendant la conversion ?**

Aspose.Slides peut utiliser des polices incorporées, des polices de secours et des paramètres de substitution de polices. Voir [Police incorporée](/slides/fr/php-java/embedded-font/), [Police de secours](/slides/fr/php-java/fallback-font/) et [Substitution de police](/slides/fr/php-java/font-substitution/).