---
title: Convertir des présentations en plusieurs formats en JavaScript
linktitle: Convertir la présentation
type: docs
weight: 70
url: /fr/nodejs-java/convert-presentation/
keywords:
- convertir la présentation
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF et plus avec Aspose.Slides for Node.js via Java."
---
## **Aperçu**

Aspose.Slides for Node.js via Java peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir des fichiers PPT anciens en PPTX modernes, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier des diapositives en HTML ou rendre les diapositives en fichiers image pour des aperçus, miniatures et archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options spécifiques au format si nécessaire. Pour les formats d'image, chaque diapositive est rendue séparément puis enregistrée en tant qu'image matricielle ou vectorielle. Les articles dédiés ci‑dessous fournissent les détails d'implémentation pour chaque cas.

## **Choisissez un scénario de conversion**

Utilisez les articles ci‑dessus pour des exemples JavaScript complets et des options spécifiques aux formats.

| Scénario | Utilisez‑le lorsque vous devez | Article |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Moderniser les fichiers PPT anciens, normaliser les fichiers PPTX existants ou convertir les présentations OpenDocument en PPTX PowerPoint. | [Convert PPT to PPTX](/slides/fr/nodejs-java/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/fr/nodejs-java/convert-odp-to-pptx/), [Save Presentations](/slides/fr/nodejs-java/save-presentation/) |
| PPTX to PPT | Enregistrer une présentation PowerPoint moderne au format binaire PPT plus ancien pour une compatibilité avec des flux de travail plus anciens. | [Convert PPTX to PPT](/slides/fr/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Créer des documents portables, recherchables et à mise en page fixe pour le partage, l’impression ou l’archivage. | [Convert PowerPoint to PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convert PowerPoint to PDF with Notes](/slides/fr/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publier les présentations sous forme de pages HTML et contrôler les images, les polices, les notes et les options de mise en page réactives. | [Convert PowerPoint to HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exporter les diapositives vers HTML5 pour une visualisation dans le navigateur avec le formatage et l’interactivité préservés. | [Convert Presentations to HTML5](/slides/fr/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendre chaque diapositive en image PNG pour des aperçus, miniatures ou sorties web. | [Convert PowerPoint to PNG](/slides/fr/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité de l’image. | [Convert PowerPoint to JPG](/slides/fr/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exporter des diapositives individuelles au format graphique vectoriel évolutif. | [Render Slide as SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Générer des documents XPS à mise en page fixe. | [Convert PowerPoint to XPS](/slides/fr/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Enregistrer une présentation sous forme de fichier TIFF multipage pour l’impression, la numérisation, le fax ou les flux d’archivage. | [Convert PowerPoint to TIFF](/slides/fr/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Enregistrer les diapositives avec les notes du présentateur au format TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/fr/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail basés sur du texte. | [Convert PowerPoint to Markdown](/slides/fr/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Créer une présentation PowerPoint au format XML texte pour l’inspection, la comparaison, le dépannage ou les flux de travail basés sur XML. | [Convert PowerPoint to XML](/slides/fr/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Créer un GIF animé à partir des diapositives. | [Convert PowerPoint to Animated GIF](/slides/fr/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Construire un flux d’exportation vidéo à partir des diapositives de la présentation. | [Convert PowerPoint to Video](/slides/fr/nodejs-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exporter les diapositives au format XAML pour des scénarios UI JavaScript ou Java. | [Export Presentations to XAML](/slides/fr/nodejs-java/export-to-xaml/) |

Pour une liste plus complète des formats d’entrée et de sortie, consultez [Supported File Formats](/slides/fr/nodejs-java/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for Node.js via Java prend en charge la conversion à partir des formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, de sorte qu’un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en ne modifiant que le fichier d’entrée.

Lors de la conversion de fichiers ODP, gardez à l’esprit que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque fonctionnalité de mise en page et de formatage de la même manière. Si un fichier ODP a été créé avec LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convert OpenDocument Presentations](/slides/fr/nodejs-java/convert-openoffice-odp/) lorsque vous avez besoin de conseils spécifiques au format.

## **Conversion PPT vers PPTX**

PPT est le format binaire PowerPoint plus ancien, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for Node.js via Java prend en charge la conversion PPT vers PPTX haute fidélité tout en conservant les structures de présentation complexes telles que les maîtres, les dispositions, les diapositives, les graphiques, les formes groupées, les espaces réservés, les cadres de texte, les textures et les remplissages d’image.

Pour plus de détails, consultez [Convert PPT to PPTX](/slides/fr/nodejs-java/convert-ppt-to-pptx/) et [PPT vs PPTX](/slides/fr/nodejs-java/ppt-vs-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque la sortie doit apparaître de la même façon sur tous les appareils et ne doit pas être modifiée comme une présentation. Les articles dédiés aux formats PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives masquées, les notes, la qualité de l’image, la compression, le format de pixel et la taille de sortie.

## **Exportation HTML et image**

L’exportation HTML et HTML5 est utile pour la visualisation dans un navigateur, la publication Web et le partage léger. L’exportation d’images est utile lorsque chaque diapositive doit devenir un aperçu, une miniature ou un actif matriciel distinct. Utilisez les articles PNG, JPG et SVG pour des conseils de rendu spécifiques au format.

## **FAQ**

**Ai-je besoin de Microsoft PowerPoint pour convertir des présentations ?**

Non. Aspose.Slides for Node.js via Java est une bibliothèque autonome et ne nécessite pas Microsoft PowerPoint ni l’automatisation d’Office.

**Puis‑je convertir en lot de nombreuses présentations ?**

Oui. Chargez chaque présentation, enregistrez‑la dans le format requis et libérez l’objet présentation après le traitement. Pour un traitement parallèle, utilisez des instances de présentation distinctes et suivez les directives de [multithreading](/slides/fr/nodejs-java/multithreading/).

**Puis‑je exporter uniquement les diapositives sélectionnées ?**

Oui. Plusieurs méthodes d’exportation permettent de fournir les index des diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l’article dédié au format cible.

**Puis‑je inclure les diapositives masquées lors de l’exportation vers PDF ou XPS ?**

Oui. Utilisez les paramètres d’exportation des diapositives masquées décrits dans les articles de conversion [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/nodejs-java/convert-powerpoint-to-xps/).

**Puis‑je créer une sortie PDF/A ?**

Oui. Les paramètres de conformité PDF sont disponibles pour l’exportation PDF. Consultez [Convert PowerPoint to PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/) pour plus de détails.

**Comment les polices sont‑elles gérées pendant la conversion ?**

Aspose.Slides peut utiliser des polices incorporées, le repli de police et les paramètres de substitution de police. Voir [Embedded Font](/slides/fr/nodejs-java/embedded-font/), [Fallback Font](/slides/fr/nodejs-java/fallback-font/) et [Font Substitution](/slides/fr/nodejs-java/font-substitution/).