---
title: Convertir des présentations en plusieurs formats avec .NET
linktitle: Convertir la présentation
type: docs
weight: 70
url: /fr/net/convert-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Convertir les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF et plus encore avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Aspose.Slides for .NET peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir les fichiers PPT hérités en PPTX moderne, exporter des présentations vers des documents à mise en page fixe tels que PDF et XPS, publier des diapositives en HTML, ou rendre les diapositives sous forme de fichiers image pour des aperçus, vignettes et archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis, et appliquer les options spécifiques au format au besoin. Pour les formats d’image, chaque diapositive est rendue séparément puis enregistrée sous forme d’image raster ou vectorielle. Les articles dédiés ci‑dessous fournissent les détails d’implémentation pour chaque cas.

## **Choisir un scénario de conversion**

Utilisez les articles ci‑dessous pour des exemples C# complets et les options spécifiques aux formats.

| Scénario | Quand l'utiliser | Article |
| --- | --- | --- |
| PPT/PPTX/ODP vers PPTX | Moderniser les fichiers PPT hérités, normaliser les fichiers PPTX existants ou convertir les présentations OpenDocument en PPTX PowerPoint. | [Convertir PPT en PPTX](/slides/fr/net/convert-ppt-to-pptx/), [Convertir ODP en PPTX](/slides/fr/net/convert-odp-to-pptx/), [Enregistrer les présentations](/slides/fr/net/save-presentation/) |
| PPTX vers PPT | Enregistrer une présentation PowerPoint moderne au format binaire PPT plus ancien pour la compatibilité avec les flux de travail plus anciens. | [Convertir PPTX en PPT](/slides/fr/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP vers PDF | Créer des documents portables, recherchables, à mise en page fixe pour le partage, l'impression ou l'archivage. | [Convertir PowerPoint en PDF](/slides/fr/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP vers PDF avec notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convertir PowerPoint en PDF avec notes](/slides/fr/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP vers HTML | Publier des présentations sous forme de pages HTML et contrôler les images, les polices, les notes et les options de mise en page réactive. | [Convertir PowerPoint en HTML](/slides/fr/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP vers HTML5 | Exporter les diapositives vers HTML5 pour une visualisation dans le navigateur avec mise en forme et interactivité préservées. | [Convertir les présentations en HTML5](/slides/fr/net/export-to-html5/) |
| PPT/PPTX/ODP vers PNG | Rendu de chaque diapositive en image PNG pour les aperçus, les miniatures ou la sortie web. | [Convertir PowerPoint en PNG](/slides/fr/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP vers JPG | Rendu des diapositives en images JPG et contrôle des dimensions et de la qualité de l'image. | [Convertir PowerPoint en JPG](/slides/fr/net/convert-powerpoint-to-jpg/) |
| Diapositive vers SVG | Exporter des diapositives individuelles en graphiques vectoriels évolutifs. | [Rendre la diapositive en SVG](/slides/fr/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP vers XPS | Générer des documents XPS à mise en page fixe. | [Convertir PowerPoint en XPS](/slides/fr/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP vers TIFF | Enregistrer une présentation sous forme de fichier TIFF multipage pour l'impression, la numérisation, le fax ou les flux d'archivage. | [Convertir PowerPoint en TIFF](/slides/fr/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP vers TIFF avec notes | Enregistrer les diapositives avec les notes du présentateur en TIFF. | [Convertir PowerPoint en TIFF avec notes](/slides/fr/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX vers Word | Convertir les diapositives en document Word lorsque vous avez besoin d'une sortie au format document. | [Convertir PowerPoint en Word](/slides/fr/net/convert-powerpoint-to-word/) |
| PPT/PPTX vers Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail basés sur du texte. | [Convertir PowerPoint en Markdown](/slides/fr/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX vers GIF animé | Créer un GIF animé à partir des diapositives. | [Convertir PowerPoint en GIF animé](/slides/fr/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX vers vidéo | Créer un flux d'exportation vidéo à partir des diapositives de présentation. | [Convertir PowerPoint en Vidéo](/slides/fr/net/convert-powerpoint-to-video/) |
| Présentation vers XAML | Exporter les diapositives en XAML pour les scénarios d'interface .NET. | [Exporter les présentations en XAML](/slides/fr/net/export-to-xaml/) |

Pour une liste plus complète des formats d'entrée et de sortie, voir [Formats de fichiers pris en charge](/slides/fr/net/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for .NET prend en charge la conversion à partir de formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, de sorte qu'un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en ne changeant que le fichier d'entrée.

Lors de la conversion de fichiers ODP, gardez à l'esprit que les applications PowerPoint et OpenDocument ne supportent pas chaque disposition et chaque fonction de mise en forme de la même façon. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convertir les présentations OpenDocument](/slides/fr/net/convert-openoffice-odp/) lorsque vous avez besoin d'orientations spécifiques au format.

## **Conversion PPT en PPTX**

PPT est le format binaire PowerPoint plus ancien, tandis que PPTX est le format moderne Office Open XML. Aspose.Slides for .NET prend en charge une conversion PPT vers PPTX à haute fidélité tout en préservant les structures complexes de présentation telles que les maîtres, les dispositions, les diapositives, les graphiques, les formes groupées, les espaces réservés, les cadres de texte, les textures et les remplissages d’image.

Pour plus de détails, voir [Convertir PPT en PPTX](/slides/fr/net/convert-ppt-to-pptx/) et [PPT vs PPTX](/slides/fr/net/ppt-vs-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque le résultat doit apparaître de la même façon sur tous les appareils et ne doit pas être modifié comme une présentation. Utilisez [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/xpsoptions/) et [TiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/) pour contrôler la conformité, les diapositives cachées, les notes, la qualité d’image, la compression, le format de pixel et la taille de sortie.

## **Exportation HTML et image**

L’exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication web et le partage léger. L’exportation d’images est utile lorsque chaque diapositive doit devenir un aperçu, une vignette ou un élément raster distinct. Utilisez les articles PNG, JPG et SVG pour obtenir des conseils de rendu spécifiques à chaque format.

## **FAQ**

**Ai-je besoin de Microsoft PowerPoint pour convertir les présentations ?**

Non. Aspose.Slides for .NET est une bibliothèque autonome et ne nécessite ni Microsoft PowerPoint ni l’automatisation d’Office.

**Puis-je convertir en lot de nombreuses présentations ?**

Oui. Chargez chaque présentation, enregistrez‑la dans le format requis, puis libérez l’objet `Presentation` après le traitement. Pour le traitement parallèle, utilisez des instances de présentation distinctes et suivez les recommandations de [multithreading](/slides/fr/net/multithreading/).

**Puis-je n'exporter que les diapositives sélectionnées ?**

Oui. Plusieurs méthodes d’exportation permettent de fournir des index de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l’article dédié au format ciblé.

**Puis-je inclure les diapositives cachées lors de l'exportation en PDF ou XPS ?**

Oui. Utilisez la propriété `ShowHiddenSlides` dans [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/) ou [XpsOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/xpsoptions/).

**Puis-je créer une sortie PDF/A ?**

Oui. Les paramètres de conformité PDF sont disponibles via [PdfOptions.Compliance](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/compliance/) et [PdfCompliance](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfcompliance/).

**Comment les polices sont‑elles gérées pendant la conversion ?**

Aspose.Slides peut utiliser des polices incorporées, le repli de polices et les paramètres de substitution de polices. Consultez [Embedded Font](/slides/fr/net/embedded-font/), [Fallback Font](/slides/fr/net/fallback-font/) et [Font Substitution](/slides/fr/net/font-substitution/).