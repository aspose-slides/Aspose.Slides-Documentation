---
title: Convertir des présentations vers plusieurs formats en JavaScript
linktitle: Convertir la présentation
type: docs
weight: 70
url: /fr/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertissez les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF, et plus avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir les fichiers PPT hérités en PPTX modernes, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier des diapositives en HTML ou rendre des diapositives sous forme de fichiers image pour les aperçus, les miniatures et les archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options spécifiques au format si nécessaire. Pour les formats d'image, chaque diapositive est rendue séparément puis enregistrée en tant qu'image raster ou vectorielle. Les articles dédiés ci-bas fournissent les détails d'implémentation pour chaque cas.

## **Choisir un scénario de conversion**

Utilisez les articles ci-dessous pour des exemples JavaScript complets et des options spécifiques au format.

| Scénario | Utilisez-le quand vous avez besoin de | Article |
| --- | --- | --- |
| PPT/PPTX/ODP vers PPTX | Moderniser les fichiers PPT hérités, normaliser les fichiers PPTX existants, ou convertir les présentations OpenDocument en PPTX PowerPoint. | [Convertir PPT en PPTX](/slides/fr/nodejs-java/convert-ppt-to-pptx/), [Convertir ODP en PPTX](/slides/fr/nodejs-java/convert-odp-to-pptx/), [Enregistrer les présentations](/slides/fr/nodejs-java/save-presentation/) |
| PPTX vers PPT | Enregistrez une présentation PowerPoint moderne au format binaire PPT plus ancien pour la compatibilité avec les anciens flux de travail. | [Convertir PPTX en PPT](/slides/fr/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP vers PDF | Créer des documents portables, interrogeables et à mise en page fixe pour le partage, l'impression ou l'archivage. | [Convertir PowerPoint en PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP vers PDF avec notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convertir PowerPoint en PDF avec notes](/slides/fr/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP vers HTML | Publier les présentations comme pages HTML et contrôler les images, polices, notes et options de mise en page réactive. | [Convertir PowerPoint en HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP vers HTML5 | Exporter les diapositives vers HTML5 pour une visualisation dans le navigateur avec le formatage et l'interactivité préservés. | [Convertir les présentations en HTML5](/slides/fr/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP vers PNG | Rendre chaque diapositive en image PNG pour les aperçus, miniatures ou sortie web. | [Convertir PowerPoint en PNG](/slides/fr/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP vers JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité de l'image. | [Convertir PowerPoint en JPG](/slides/fr/nodejs-java/convert-powerpoint-to-jpg/) |
| Diapositive vers SVG | Exporter des diapositives individuelles en graphiques vectoriels évolutifs. | [Rendre la diapositive en SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP vers XPS | Générer des documents XPS à mise en page fixe. | [Convertir PowerPoint en XPS](/slides/fr/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP vers TIFF | Enregistrer une présentation comme fichier TIFF multipage pour l'impression, la numérisation, le fax ou les flux de travail d'archivage. | [Convertir PowerPoint en TIFF](/slides/fr/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP vers TIFF avec notes | Enregistrer les diapositives avec les notes du présentateur au format TIFF. | [Convertir PowerPoint en TIFF avec notes](/slides/fr/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX vers Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail textuels. | [Convertir PowerPoint en Markdown](/slides/fr/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX vers GIF animé | Créer un GIF animé à partir des diapositives. | [Convertir PowerPoint en GIF animé](/slides/fr/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX vers vidéo | Construire un flux d'exportation vidéo à partir des diapositives de la présentation. | [Convertir PowerPoint en vidéo](/slides/fr/nodejs-java/convert-powerpoint-to-video/) |
| Présentation vers XAML | Exporter les diapositives vers XAML pour les scénarios d'interface JavaScript ou Java. | [Exporter les présentations en XAML](/slides/fr/nodejs-java/export-to-xaml/) |

Pour une liste plus complète des formats d'entrée et de sortie, consultez [Formats de fichiers pris en charge](/slides/fr/nodejs-java/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for Node.js via Java prend en charge la conversion à partir des formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, de sorte qu'un flux de travail qui enregistre un fichier PPTX au format PDF peut généralement être appliqué à un fichier ODP en ne modifiant que le fichier d'entrée.

Lorsque vous convertissez des fichiers ODP, rappelez-vous que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque mise en page et fonctionnalité de formatage de la même manière exacte. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez la sortie et utilisez les options décrites dans [Convertir les présentations OpenDocument](/slides/fr/nodejs-java/convert-openoffice-odp/) lorsque vous avez besoin d'orientations spécifiques au format.

## **Conversion PPT vers PPTX**

PPT est l'ancien format binaire PowerPoint, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for Node.js via Java prend en charge la conversion PPT vers PPTX haute fidélité tout en préservant les structures complexes de la présentation telles que les maîtres, mises en page, diapositives, graphiques, formes groupées, zones réservées, cadres de texte, textures et remplissages d'image.

Pour plus de détails, consultez [Convertir PPT en PPTX](/slides/fr/nodejs-java/convert-ppt-to-pptx/) et [PPT vs PPTX](/slides/fr/nodejs-java/ppt-vs-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque la sortie doit apparaître de la même façon sur tous les appareils et ne doit pas être modifiée comme une présentation. Les articles dédiés à PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives masquées, les notes, la qualité de l'image, la compression, le format des pixels et la taille de sortie.

## **Exportation HTML et image**

L'exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication web et le partage léger. L'exportation d'images est utile lorsque chaque diapositive doit devenir un aperçu, une miniature ou un actif raster distinct. Utilisez les articles PNG, JPG et SVG pour des conseils de rendu spécifiques au format.

## **FAQ**

**Ai-je besoin de Microsoft PowerPoint pour convertir les présentations ?**

Non. Aspose.Slides for Node.js via Java est une bibliothèque autonome et ne nécessite pas Microsoft PowerPoint ni l'automatisation d'Office.

**Puis-je convertir en lot de nombreuses présentations ?**

Oui. Chargez chaque présentation, enregistrez-la dans le format requis et libérez l'objet de présentation après le traitement. Pour le traitement parallèle, utilisez des instances de présentation séparées et suivez les recommandations de [multithreading](/slides/fr/nodejs-java/multithreading/).

**Puis-je exporter uniquement des diapositives sélectionnées ?**

Oui. Plusieurs méthodes d'exportation permettent de transmettre des indices de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l'article dédié pour le format cible.

**Puis-je inclure les diapositives masquées lors de l'exportation vers PDF ou XPS ?**

Oui. Utilisez les paramètres d'exportation des diapositives masquées décrits dans les articles de conversion [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/nodejs-java/convert-powerpoint-to-xps/).

**Puis-je créer une sortie PDF/A ?**

Oui. Des paramètres de conformité PDF sont disponibles pour l'exportation PDF. Voir [Convertir PowerPoint en PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/) pour plus de détails.

**Comment les polices sont‑elles gérées lors de la conversion ?**

Aspose.Slides peut utiliser des polices incorporées, le repli de police et les paramètres de substitution de police. Voir [Police incorporée](/slides/fr/nodejs-java/embedded-font/), [Police de secours](/slides/fr/nodejs-java/fallback-font/), et [Substitution de police](/slides/fr/nodejs-java/font-substitution/).