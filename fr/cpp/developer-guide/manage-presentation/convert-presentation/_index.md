---
title: Convertir des présentations en plusieurs formats avec C++
linktitle: Convertir une présentation
type: docs
weight: 70
url: /fr/cpp/convert-presentation/
keywords:
- convertir une présentation
- exporter une présentation
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
- C++
- Aspose.Slides
description: "Convertissez les présentations PowerPoint et OpenDocument en PPTX, PDF, HTML, images, XPS, TIFF et plus avec Aspose.Slides pour C++."
---
## **Aperçu**

Aspose.Slides for C++ peut charger des présentations PowerPoint et OpenDocument et les enregistrer ou les rendre dans de nombreux autres formats sans Microsoft PowerPoint, OpenOffice ou LibreOffice. Vous pouvez convertir les fichiers PPT hérités en PPTX modernes, exporter des présentations vers des documents à mise en page fixe comme PDF et XPS, publier des diapositives en HTML, ou rendre les diapositives sous forme de fichiers image pour les aperçus, les miniatures et les archives.

La plupart des conversions de documents utilisent le même flux de travail général : charger le fichier source, choisir le format de sortie requis, et appliquer les options spécifiques au format si nécessaire. Pour les formats d'image, chaque diapositive est rendue séparément puis enregistrée sous forme d'image raster ou vectorielle. Les articles dédiés ci‑dessous fournissent les détails d'implémentation pour chaque cas.

## **Choisissez un scénario de conversion**

Utilisez les articles ci-dessous pour des exemples C++ complets et les options spécifiques au format.

| Scénario | Lorsque vous avez besoin de | Article |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Moderniser les fichiers PPT hérités, normaliser les fichiers PPTX existants, ou convertir les présentations OpenDocument en PPTX PowerPoint. | [Convertir PPT en PPTX](/slides/fr/cpp/convert-ppt-to-pptx/), [Convertir ODP en PPTX](/slides/fr/cpp/convert-odp-to-pptx/), [Enregistrer les présentations](/slides/fr/cpp/save-presentation/) |
| PPTX to PPT | Enregistrer une présentation PowerPoint moderne au format binaire PPT plus ancien pour la compatibilité avec les flux de travail anciens. | [Convertir PPTX en PPT](/slides/fr/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Créer des documents portables, consultables et à mise en page fixe pour le partage, l'impression ou l'archivage. | [Convertir PowerPoint en PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exporter les notes du présentateur avec le contenu des diapositives. | [Convertir PowerPoint en PDF avec notes](/slides/fr/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publier des présentations en pages HTML et contrôler les images, les polices, les notes et les options de mise en page responsive. | [Convertir PowerPoint en HTML](/slides/fr/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exporter les diapositives vers HTML5 pour une visualisation dans le navigateur avec le formatage et l'interactivité conservés. | [Convertir les présentations en HTML5](/slides/fr/cpp/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendre chaque diapositive en image PNG pour les aperçus, les miniatures ou la sortie web. | [Convertir PowerPoint en PNG](/slides/fr/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendre les diapositives en images JPG et contrôler les dimensions et la qualité de l'image. | [Convertir PowerPoint en JPG](/slides/fr/cpp/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exporter des diapositives individuelles en graphiques vectoriels évolutifs. | [Rendre la diapositive en SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Générer des documents XPS à mise en page fixe. | [Convertir PowerPoint en XPS](/slides/fr/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Enregistrer une présentation sous forme de fichier TIFF multipage pour l'impression, la numérisation, le fax ou les flux d'archivage. | [Convertir PowerPoint en TIFF](/slides/fr/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Enregistrer les diapositives avec les notes du présentateur au format TIFF. | [Convertir PowerPoint en TIFF avec notes](/slides/fr/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Convertir les diapositives en document Word lorsque vous avez besoin d'une sortie de type document. | [Convertir PowerPoint en Word](/slides/fr/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extraire le contenu de la présentation en Markdown pour la documentation et les flux de travail basés sur du texte. | [Convertir PowerPoint en Markdown](/slides/fr/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Créer un GIF animé à partir des diapositives. | [Convertir PowerPoint en GIF animé](/slides/fr/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Construire un flux d'exportation vidéo à partir des diapositives de la présentation. | [Convertir PowerPoint en vidéo](/slides/fr/cpp/convert-powerpoint-to-video/) |
| Presentation to XAML | Exporter les diapositives en XAML pour les scénarios d'interface utilisateur C++. | [Exporter les présentations en XAML](/slides/fr/cpp/export-to-xaml/) |

Pour une liste plus complète des formats d'entrée et de sortie, consultez [Formats de fichiers pris en charge](/slides/fr/cpp/supported-file-formats/).

## **Conversion PowerPoint et OpenDocument**

Aspose.Slides for C++ prend en charge la conversion à partir des formats de présentation couramment utilisés tels que PPT, PPTX, PPS, PPSX, POT, POTX et ODP. La même API de conversion est utilisée pour les fichiers PowerPoint et OpenDocument, de sorte qu'un flux de travail qui enregistre un fichier PPTX en PDF peut généralement être appliqué à un fichier ODP en ne modifiant que le fichier d'entrée.

Lors de la conversion de fichiers ODP, gardez à l'esprit que les applications PowerPoint et OpenDocument ne prennent pas en charge chaque mise en page et chaque fonctionnalité de formatage de la même manière. Si un fichier ODP a été créé dans LibreOffice ou OpenOffice Impress, examinez le résultat et utilisez les options décrites dans [Convertir les présentations OpenDocument](/slides/fr/cpp/convert-openoffice-odp/) lorsque vous avez besoin d'orientation spécifique au format.

## **Conversion PPT en PPTX**

PPT est le format PowerPoint binaire plus ancien, tandis que PPTX est le format Office Open XML moderne. Aspose.Slides for C++ prend en charge la conversion PPT vers PPTX à haute fidélité tout en conservant les structures complexes de présentation telles que les maîtres, les mises en page, les diapositives, les graphiques, les formes groupées, les espaces réservés, les cadres de texte, les textures et les remplissages d'images.

Pour plus de détails, consultez [Convertir PPT en PPTX](/slides/fr/cpp/convert-ppt-to-pptx/).

## **Exportation à mise en page fixe**

PDF, XPS et TIFF sont utiles lorsque la sortie doit apparaître de la même façon sur tous les appareils et ne doit pas être modifiée comme une présentation. Les articles dédiés à PDF, XPS et TIFF expliquent comment contrôler la conformité, les diapositives masquées, les notes, la qualité de l'image, la compression, le format des pixels et la taille de sortie.

## **Exportation HTML et image**

L'exportation HTML et HTML5 est utile pour la visualisation dans le navigateur, la publication Web et le partage léger. L'exportation d'images est utile lorsque chaque diapositive doit devenir un aperçu, une miniature ou un élément raster distinct. Utilisez les articles PNG, JPG et SVG pour obtenir des conseils de rendu spécifiques au format.

## **FAQ**

**Ai-je besoin de Microsoft PowerPoint pour convertir des présentations ?**  
Non. Aspose.Slides for C++ est une bibliothèque autonome et ne nécessite ni Microsoft PowerPoint ni l'automatisation Office.

**Puis-je convertir en lot de nombreuses présentations ?**  
Oui. Chargez chaque présentation, enregistrez‑la au format requis, puis libérez l'objet présentation après le traitement. Pour le traitement parallèle, utilisez des instances de présentation séparées et suivez les consignes de [multithreading](/slides/fr/cpp/multithreading/).

**Puis-je exporter uniquement des diapositives sélectionnées ?**  
Oui. Plusieurs méthodes d'exportation vous permettent de passer les index de diapositives ou de rendre des diapositives individuelles, selon le format de sortie. Consultez l'article dédié au format cible.

**Puis-je inclure les diapositives masquées lors de l'exportation en PDF ou XPS ?**  
Oui. Utilisez les paramètres d'exportation des diapositives masquées décrits dans les articles de conversion [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) et [XPS](/slides/fr/cpp/convert-powerpoint-to-xps/).

**Puis-je créer une sortie PDF/A ?**  
Oui. Les paramètres de conformité PDF sont disponibles pour l'exportation PDF. Consultez [Convertir PowerPoint en PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) pour plus de détails.

**Comment les polices sont‑elles gérées pendant la conversion ?**  
Aspose.Slides peut utiliser des polices intégrées, le repli de police et les paramètres de substitution de police. Consultez [Police intégrée](/slides/fr/cpp/embedded-font/), [Police de repli](/slides/fr/cpp/fallback-font/), et [Substitution de police](/slides/fr/cpp/font-substitution/).