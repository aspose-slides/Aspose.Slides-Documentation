---
title: Convertir des présentations vers plusieurs formats en .NET
linktitle: Convertir la présentation
type: docs
weight: 70
url: /fr/net/convert-presentation/
keywords:
- convertir présentation
- exporter présentation
- PPT to PPTX
- PPTX to PPT
- ODP to PPTX
- PPT to PDF
- PPTX to PDF
- ODP to PDF
- PPT to HTML
- PPTX to HTML
- ODP to HTML
- PPT to PNG
- PPTX to PNG
- ODP to PNG
- PPTX to JPG
- ODP to JPG
- PPT to XPS
- PPTX to XPS
- ODP to XPS
- PPT to TIFF
- PPTX to TIFF
- ODP to TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Convertissez les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF et plus avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Aspose.Slides for .NET peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir des fichiers PPT anciens en PPTX modernes, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier des diapositives au format HTML ou rendre les diapositives sous forme de fichiers image pour les aperçus, les vignettes et les archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis et appliquer les options spécifiques au format si nécessaire. Pour les formats d'image, chaque diapositive est rendue séparément puis enregistrée sous forme d'image raster ou vectorielle. Les articles dédiés ci‑dessous fournissent les détails d'implémentation pour chaque cas.

## **Choisir un scénario de conversion**

Utilisez les articles ci‑dessous pour des exemples C# complets et les options spécifiques à chaque format.

| Scénario | Utilisez‑le quand vous avez besoin de | Article |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Moderniser les fichiers PPT anciens, normaliser les fichiers PPTX existants ou convertir des présentations OpenDocument en PPTX de PowerPoint. | [Convertir PPT en PPTX](/slides/fr/net/convert-ppt-to-pptx/), [Convertir ODP en PPTX](/slides/fr/net/convert-odp-to-pptx/), [Enregistrer les présentations](/slides/fr/net/save-presentation/) |
| PPTX to PPT | Enregistrer une présentation PowerPoint moderne au format binaire PPT plus ancien pour la compatibilité avec les flux de travail plus anciens. | [Convertir PPTX en PPT](/slides/fr/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Créer des documents portables, consultables et à mise en page fixe pour le partage, l'impression ou l'archivage. | [Convertir PowerPoint en PDF](/slides/fr/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convertir PowerPoint en PDF avec notes](/slides/fr/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publier des présentations en pages HTML et contrôler les images, les polices, les notes et les options de mise en page responsive. | [Convertir PowerPoint en HTML](/slides/fr/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exporter les diapositives vers HTML5 pour la visualisation dans le navigateur avec formatage et interactivité préservés. | [Convertir les présentations en HTML5](/slides/fr/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendre chaque diapositive en image PNG pour les aperçus, les vignettes ou la diffusion Web. | [Convertir PowerPoint en PNG](/slides/fr/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité de l'image. | [Convertir PowerPoint en JPG](/slides/fr/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exporter les diapositives individuelles en graphiques vectoriels évolutifs. | [Rendre la diapositive en SVG](/slides/fr/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Générer des documents XPS à mise en page fixe. | [Convertir PowerPoint en XPS](/slides/fr/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Enregistrer une présentation sous forme de fichier TIFF multipage pour l'impression, la numérisation, le fax ou les flux de travail d'archivage. | [Convertir PowerPoint en TIFF](/slides/fr/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Enregistrer les diapositives avec les notes du présentateur au format TIFF. | [Convertir PowerPoint en TIFF avec notes](/slides/fr/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Convertir les diapositives en document Word lorsque vous avez besoin d'une sortie de type document. | [Convertir PowerPoint en Word](/slides/fr/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail basés sur le texte. | [Convertir PowerPoint en Markdown](/slides/fr/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Créer une présentation PowerPoint XML basée sur du texte pour l'inspection, la comparaison, le dépannage ou les flux de travail basés sur XML. | [Convertir PowerPoint en XML](/slides/fr/net/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Créer un GIF animé à partir des diapositives. | [Convertir PowerPoint en GIF animé](/slides/fr/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Construire un flux d'exportation vidéo à partir des diapositives de la présentation. | [Convertir PowerPoint en vidéo](/slides/fr/net/convert-powerpoint-to-video/) |
| Presentation to XAML | Exporter les diapositives en XAML pour les scénarios UI .NET. | [Exporter les présentations en XAML](/slides/fr/net/export-to-xaml/) |

Pour une liste plus large de formats d’entrée et de sortie, voir [Formats de fichiers pris en charge](/slides/fr/net/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for .NET prend en charge la conversion à partir des formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, ainsi un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en ne changeant que le fichier d’entrée.

Lors de la conversion de fichiers ODP, gardez à l’esprit que les applications PowerPoint et OpenDocument ne supportent pas chaque fonctionnalité de mise en page et de formatage de la même manière. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convertir les présentations OpenDocument](/slides/fr/net/convert-openoffice-odp/) lorsque vous avez besoin d’orientations spécifiques au format.

## **Conversion PPT en PPTX**

PPT est le format binaire PowerPoint plus ancien, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for .NET prend en charge la conversion PPT vers PPTX avec une haute fidélité tout en préservant les structures de présentation complexes telles que les maîtres, les mises en page, les diapositives, les graphiques, les formes groupées, les espaces réservés, les zones de texte, les textures et les remplissages d’image.

Pour plus de détails, voir [Convertir PPT en PPTX](/slides/fr/net/convert-ppt-to-pptx/) et [PPT vs PPTX](/slides/fr/net/ppt-vs-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque le résultat doit être identique sur tous les appareils et ne doit pas être modifié comme une présentation. Utilisez [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/xpsoptions/), et [TiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/) pour contrôler la conformité, les diapositives masquées, les notes, la qualité de l’image, la compression, le format de pixel et la taille de sortie.

## **Exportation HTML et image**

L’exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication Web et le partage léger. L’exportation d’images est utile lorsque chaque diapositive doit devenir un aperçu, une vignette ou un actif raster distinct. Consultez les articles PNG, JPG et SVG pour des conseils de rendu spécifiques au format.

## **FAQ**

**Ai-je besoin de Microsoft PowerPoint pour convertir les présentations ?**  
Non. Aspose.Slides for .NET est une bibliothèque autonome et ne nécessite pas Microsoft PowerPoint ni d’automatisation d’Office.

**Puis-je convertir en lot de nombreuses présentations ?**  
Oui. Chargez chaque présentation, enregistrez‑la dans le format requis, puis libérez l’objet `Presentation` après le traitement. Pour le traitement parallèle, utilisez des instances de présentation séparées et suivez les directives de [multithreading](/slides/fr/net/multithreading/).

**Puis‑je n’exporter que des diapositives sélectionnées ?**  
Oui. Plusieurs méthodes d’exportation permettent de passer des index de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l’article dédié au format cible.

**Puis‑je inclure les diapositives masquées lors de l’exportation en PDF ou XPS ?**  
Oui. Utilisez la propriété `ShowHiddenSlides` dans [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/) ou [XpsOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/xpsoptions/).

**Puis‑je créer une sortie PDF/A ?**  
Oui. Les paramètres de conformité PDF sont disponibles via [PdfOptions.Compliance](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/compliance/) et [PdfCompliance](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfcompliance/).

**Comment les polices sont‑elles gérées lors de la conversion ?**  
Aspose.Slides peut utiliser des polices incorporées, le repli de police et les paramètres de substitution de police. Voir [Police incorporée](/slides/fr/net/embedded-font/), [Police de repli](/slides/fr/net/fallback-font/), et [Substitution de police](/slides/fr/net/font-substitution/).