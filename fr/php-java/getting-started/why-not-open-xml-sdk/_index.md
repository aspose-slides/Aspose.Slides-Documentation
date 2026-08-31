---
title: Pourquoi pas Open XML SDK
type: docs
weight: 120
url: /fr/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- comparaison
- modèle d'objet de présentation
- conversion de haute qualité
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Découvrez pourquoi Aspose.Slides est un meilleur choix que le gratuit Open XML SDK : comparez les fonctionnalités, la conversion sans automatisation et la large prise en charge de PPT, PPTX et ODP."
---
## **Vue d'ensemble**

Cet article explique quand les développeurs peuvent choisir Open XML SDK ou Aspose.Slides pour travailler avec des documents de présentation. Il décrit Open XML SDK comme une bibliothèque permettant de manipuler des packages OOXML et leurs éléments XML sous-jacents, tandis qu'Aspose.Slides est présenté comme une bibliothèque de traitement de présentations avec un modèle d'objet de haut niveau et une prise en charge de nombreuses tâches liées à PowerPoint.

L'article compare les deux options selon les formats pris en charge, le modèle de programmation, le rendu, la prise en charge des plateformes et les cas d'utilisation courants. Il précise également qu'Open XML SDK peut convenir pour des opérations PPTX de base ou un accès direct aux éléments OOXML, tandis qu'Aspose.Slides est plus approprié pour des tâches de présentation complexes telles que le travail avec plusieurs formats PowerPoint, la copie ou le clonage de formes, le remplacement de texte, l'application d'animations et la conversion de présentations en PDF, TIFF ou XPS.

## **Qu'est‑ce qu'Open XML SDK ?**
Selon la [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK est défini comme :

Le Open XML SDK 2.0 simplifie la tâche de manipulation des packages Open XML et des éléments du schéma Open XML sous‑jacent dans un package. Le Open XML SDK 2.0 encapsule de nombreuses tâches courantes que les développeurs effectuent sur les packages Open XML, de sorte que vous pouvez réaliser des opérations complexes avec seulement quelques lignes de code.

Les documents OOXML sont essentiellement des fichiers ZIP contenant du XML et Open XML SDK est un ensemble de classes qui vous permet de travailler avec le contenu des documents OOXML de manière fortement typée. Au lieu de décompresser un fichier pour extraire le XML, de charger ce XML dans un arbre DOM et de travailler directement avec les éléments et attributs XML, Open XML SDK fournit des classes pour le faire.

## **Qu'est‑ce qu'Aspose.Slides ?**
Aspose.Slides est une bibliothèque de classes qui permet à votre application d'effectuer les tâches de traitement de présentation suivantes :

- Programmation avec un modèle d'objet **Presentation**.
- Conversions de haute qualité parmi tous les formats de présentation PowerPoint pris en charge, y compris la conversion en PDF, XPS et TIFF.
- Possibilité de générer des miniatures de diapositives dans des formats courants tels que PNG, JPEG et BMP ainsi que l'exportation de diapositives en SVG.
- Possibilité de créer des présentations à partir de zéro ou en les combinant à partir d’un ou plusieurs documents.
- Prise en charge de l'ajout d'animations, d'objets Ole, de tableaux, de la création et de la gestion de graphiques.
- Disponibilité d’un contrôle étendu pour la gestion du formatage du texte au niveau des TextFrames, Paragraphs et Portions.

Pour plus de détails sur les fonctionnalités prises en charge, veuillez consulter [Aspose.Slides Features](/slides/fr/php-java/product-overview/).

## **Comparer Open XML SDK et Aspose.Slides**
{{% alert color="info" %}} 

Le tableau suivant compare les fonctionnalités d'Open XML SDK et d'Aspose.Slides.

{{% /alert %}} 

|**Fonction ou catégorie de fonction**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formats de présentation pris en charge|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion de PPT vers PPTX|Non|Oui|
|<p>Programmation de haut niveau avec un modèle d'objet Document de présentation (DOM) :</p><p>- Rechercher et remplacer du texte.</p><p>- Assembler des diapositives dans des présentations.</p>|Non|Oui|
|Programmation détaillée avec un modèle d'objet de document, accès aux éléments individuels et au formatage tels que TextHolders, TextFrames, Paragraphs et Portions.|Oui|Oui|
|Accès direct et complet de bas niveau aux éléments XML sous‑jacent et aux attributs tels que les identifiants de relation, les identifiants de liste d'un document OOXML.|Oui|Non|
|<p>Rendu :</p><p>- Rendre des présentations en PDF, PDF Notes, XPS, images TIFF.</p><p>- Rendre des miniatures de diapositives en PNG, JPEG, BMP, SVG et TIFF.</p><p>- Spécifier la résolution de l'image, la qualité, la compression et d'autres options.</p>|Non|Oui |
|Plateformes prises en charge|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Conclusion**
{{% alert color="info" %}} 

Open XML SDK et Aspose.Slides ne sont pas en concurrence directe car ils répondent à des besoins et à des publics très différents. Open XML SDK est une bibliothèque de classes offrant une façon fortement typée de travailler avec les documents OOXML. Aspose.Slides est une bibliothèque de traitement de présentations très utile qui prend en charge presque tous les formats de fichiers Microsoft PowerPoint.

Si tout ce dont vous avez besoin est une opération de programmation assez basique sur un document PPTX, alors Open XML SDK peut être un choix approprié. Avec Open XML SDK, vous serez à l'aise pour réaliser des tâches simples comme générer un document PPTX simple ou supprimer des commentaires, en‑têtes/pieds de page, extraire des images ou d’autres opérations similaires. Certaines tâches peuvent être accomplies avec Open XML SDK, mais pas avec Aspose.Slides. Par exemple, si vous devez accéder directement aux éléments XML et aux attributs d’un document OOXML, vous devez utiliser Open XML SDK. En revanche, si vous devez effectuer des opérations complexes sur les documents, telles que les tâches suivantes, l’utilisation d’Aspose.Slides est votre meilleure option :

- Prise en charge des formats PowerPoint anciens en plus de PPTX.
- Copie ou clonage de formes dans les diapositives d’une manière qui combine objets, styles et autres formats de façon appropriée.
- Remplacement de texte formaté ou non formaté.
- Application d'animations et utilisation de connecteurs avec les formes.
- Conversion d’un document en PDF, TIFF ou XPS pour qu’il apparaisse exactement comme le ferait Microsoft PowerPoint.
- Développement d’une application .NET ou Java aussi bien en environnement de bureau que web.

{{% /alert %}}