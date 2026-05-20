---
title: Convertir des présentations en plusieurs formats en Java
linktitle: Convertir présentation
type: docs
weight: 70
url: /fr/java/convert-presentation/
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
- Java
- Aspose.Slides
description: "Convertir les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF et plus avec Aspose.Slides pour Java."
---
## **Vue d'ensemble**

Aspose.Slides for Java peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir les fichiers PPT hérités en PPTX modernes, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier des diapositives en HTML, ou rendre les diapositives en fichiers image pour les aperçus, les vignettes et les archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options spécifiques au format si nécessaire. Pour les formats image, chaque diapositive est rendue séparément puis enregistrée comme image raster ou vectorielle. Les articles dédiés liés ci‑dessous fournissent les détails d’implémentation pour chaque cas.

## **Choisissez un scénario de conversion**

Utilisez les articles ci‑dessous pour des exemples Java complets et les options spécifiques à chaque format.

| Scénario | Utilisez‑le lorsque vous devez | Article |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Moderniser les fichiers PPT anciens, normaliser les fichiers PPTX existants ou convertir des présentations OpenDocument en PowerPoint PPTX. | [Convertir PPT en PPTX](/slides/fr/java/convert-ppt-to-pptx/), [Convertir ODP en PPTX](/slides/fr/java/convert-odp-to-pptx/), [Enregistrer des présentations](/slides/fr/java/save-presentation/) |
| PPTX to PPT | Enregistrer une présentation PowerPoint moderne au format binaire PPT plus ancien pour la compatibilité avec des flux de travail plus vieux. | [Convertir PPTX en PPT](/slides/fr/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Créer des documents portables, recherchables et à mise en page fixe pour le partage, l’impression ou l’archivage. | [Convertir PowerPoint en PDF](/slides/fr/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exporter les notes de l’orateur avec le contenu des diapositives. | [Convertir PowerPoint en PDF avec notes](/slides/fr/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publier des présentations en pages HTML et contrôler les images, les polices, les notes et les options de mise en page réactive. | [Convertir PowerPoint en HTML](/slides/fr/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exporter les diapositives en HTML5 pour la visualisation dans le navigateur avec le formatage et l’interactivité préservés. | [Convertir les présentations en HTML5](/slides/fr/java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendre chaque diapositive en image PNG pour les aperçus, les vignettes ou la sortie web. | [Convertir PowerPoint en PNG](/slides/fr/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité de l’image. | [Convertir PowerPoint en JPG](/slides/fr/java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exporter des diapositives individuelles en graphiques vectoriels évolutifs. | [Rendre la diapositive en SVG](/slides/fr/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Générer des documents XPS à mise en page fixe. | [Convertir PowerPoint en XPS](/slides/fr/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Enregistrer une présentation en fichier TIFF multipage pour l’impression, la numérisation, le fax ou les flux d’archivage. | [Convertir PowerPoint en TIFF](/slides/fr/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Enregistrer les diapositives avec les notes de l’orateur en TIFF. | [Convertir PowerPoint en TIFF avec notes](/slides/fr/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Convertir les diapositives en document Word lorsque vous avez besoin d’une sortie de type document. | [Convertir PowerPoint en Word](/slides/fr/java/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail texte. | [Convertir PowerPoint en Markdown](/slides/fr/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Créer un GIF animé à partir des diapositives. | [Convertir PowerPoint en GIF animé](/slides/fr/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Mettre en place un flux d’exportation vidéo à partir des diapositives de la présentation. | [Convertir PowerPoint en vidéo](/slides/fr/java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exporter les diapositives en XAML pour les scénarios d’interface Java. | [Exporter les présentations en XAML](/slides/fr/java/export-to-xaml/) |

Pour une liste plus large des formats d’entrée et de sortie, consultez [Formats de fichier pris en charge](/slides/fr/java/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for Java prend en charge la conversion à partir des formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, de sorte qu’un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en ne changeant que le fichier d’entrée.

Lors de la conversion de fichiers ODP, gardez à l’esprit que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque fonctionnalité de mise en page et de formatage de la même manière exacte. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convertir les présentations OpenDocument](/slides/fr/java/convert-openoffice-odp/) lorsque vous avez besoin d’orientation spécifique au format.

## **Conversion PPT en PPTX**

PPT est le format binaire PowerPoint plus ancien, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for Java prend en charge la conversion PPT vers PPTX haute fidélité tout en préservant les structures de présentation complexes telles que les maîtres, les dispositions, les diapositives, les graphiques, les formes groupées, les espaces réservés, les cadres de texte, les textures et les remplissages d’image.

Pour plus de détails, voir [Convertir PPT en PPTX](/slides/fr/java/convert-ppt-to-pptx/) et [PPT vs PPTX](/slides/fr/java/ppt-vs-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque la sortie doit avoir le même aspect sur tous les appareils et ne doit pas être modifiable comme une présentation. Les articles dédiés à PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives masquées, les notes, la qualité d’image, la compression, le format de pixel et la taille de sortie.

## **Exportation HTML et image**

L’exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication web et le partage léger. L’exportation d’image est utile lorsque chaque diapositive doit devenir un aperçu, une vignette ou un actif raster séparé. Utilisez les articles PNG, JPG et SVG pour des conseils de rendu spécifiques au format.

## **FAQ**

**Do I need Microsoft PowerPoint to convert presentations?**

Non. Aspose.Slides for Java est une bibliothèque autonome et ne nécessite ni Microsoft PowerPoint ni l’automatisation Office.

**Can I batch convert many presentations?**

Oui. Chargez chaque présentation, enregistrez‑la dans le format requis, puis libérez l’objet présentation après le traitement. Pour un traitement parallèle, utilisez des instances séparées de présentation et suivez les recommandations de [multithreading](/slides/fr/java/multithreading/).

**Can I export only selected slides?**

Oui. Plusieurs méthodes d’exportation vous permettent de transmettre des index de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l’article dédié au format cible.

**Can I include hidden slides when exporting to PDF or XPS?**

Oui. Utilisez les paramètres d’exportation des diapositives cachées décrits dans les articles de conversion [PDF](/slides/fr/java/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/java/convert-powerpoint-to-xps/).

**Can I create PDF/A output?**

Oui. Les paramètres de conformité PDF sont disponibles pour l’exportation PDF. Voir [Convertir PowerPoint en PDF](/slides/fr/java/convert-powerpoint-to-pdf/) pour plus de détails.

**How are fonts handled during conversion?**

Aspose.Slides peut utiliser des polices incorporées, le repli de police et les paramètres de substitution de police. Voir [Embedded Font](/slides/fr/java/embedded-font/), [Fallback Font](/slides/fr/java/fallback-font/) et [Font Substitution](/slides/fr/java/font-substitution/).