---
title: Pourquoi pas Open XML SDK
type: docs
weight: 180
url: /fr/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
  - Open XML SDK
  - comparaison
  - modèle d'objet de présentation
  - conversion de haute qualité
  - PowerPoint
  - OpenDocument
  - présentation
  - .NET
  - C#
  - Aspose.Slides
description: "Découvrez pourquoi Aspose.Slides est un meilleur choix que le Open XML SDK gratuit : comparez les fonctionnalités, la conversion sans automatisation et la large prise en charge des formats PPT, PPTX et ODP."
---
## **Aperçu**

Cet article explique quand les développeurs pourraient choisir Open XML SDK ou Aspose.Slides pour travailler avec des documents de présentation. Il décrit Open XML SDK comme une bibliothèque permettant de manipuler les packages OOXML et leurs éléments XML sous-jacents, tandis qu’Aspose.Slides est présenté comme une bibliothèque de traitement de présentations avec un modèle d’objet de haut niveau et la prise en charge de nombreuses tâches liées à PowerPoint.

L’article compare les deux options selon les formats supportés, le modèle de programmation, le rendu, la prise en charge des plateformes et les cas d’utilisation courants. Il précise également que Open XML SDK peut convenir pour des opérations PPTX de base ou un accès direct aux éléments OOXML, alors qu’Aspose.Slides est plus approprié pour des tâches de présentation complexes telles que le travail avec plusieurs formats PowerPoint, la copie ou le clonage de formes, le remplacement de texte, l’application d’animations et la conversion de présentations en PDF, TIFF ou XPS.

## **Qu’est‑ce que Open XML SDK ?**
Parfois, on nous pose cette question : *Pourquoi devrions‑nous utiliser les produits Aspose plutôt que le Open XML SDK gratuit ?*

Nous trouvons qu’il est facile de répondre à cette question en termes de fonctionnalités et de capacités.

Selon la [Bibliothèque MSDN](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK est défini ainsi :

> "Le Open XML SDK 2.0 simplifie la tâche de manipulation des packages Open XML et des éléments du schéma Open XML sous‑jacent à l’intérieur d’un package. Le Open XML SDK 2.0 encapsule de nombreuses tâches courantes que les développeurs effectuent sur les packages Open XML, de sorte que vous pouvez réaliser des opérations complexes en quelques lignes de code seulement. Les documents OOXML sont essentiellement des fichiers XML compressés et le Open XML SDK est un ensemble de classes qui vous permet de travailler avec le contenu des documents OOXML de manière fortement typée. Au lieu de décompresser un fichier pour extraire le XML, de charger ce XML dans un arbre DOM et de travailler directement avec les éléments et attributs XML, le Open XML SDK fournit des classes pour le faire."

## **Qu’est‑ce que Aspose.Slides ?**
Aspose.Slides est une bibliothèque de classes qui permet aux applications d’effectuer les tâches de traitement de présentations suivantes :

- Programmation avec un modèle d’objet de présentation.  
- Conversions de haute qualité impliquant tous les formats de présentation PowerPoint pris en charge, y compris la conversion en PDF, XPS et TIFF.  
- Génération de miniatures de diapositives dans des formats courants tels que PNG, JPEG et BMP ainsi qu’exportation de diapositives au format SVG.  
- Construction de présentations à partir de zéro ou en combinant des éléments provenant d’un ou de plusieurs documents.  
- Ajout d’animations, de cadres OLE, de tableaux, création et gestion de graphiques.  
- Contrôle (contrôle étendu) et gestion du formatage du texte au niveau des TextFrames, Paragraphs et Portions.  

Pour plus de détails sur les fonctionnalités disponibles, veuillez consulter la page [Fonctionnalités Aspose.Slides](/slides/fr/net/product-overview/).

## **Comparer Open XML SDK avec Aspose.Slides**
Ce tableau compare les capacités et les fonctionnalités d’Open XML SDK avec celles d’Aspose.Slides.

|**Fonctionnalité ou catégorie de fonctionnalité**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formats de présentation pris en charge|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion de PPT vers PPTX|Non|Oui|
|<p>Programmation de haut niveau avec un modèle d’objet de document de présentation (DOM) :</p><p>- Rechercher et remplacer du texte.</p><p>- Assembler des diapositives dans des présentations.</p>|Non|Oui|
|Programmation détaillée avec un modèle d’objet de document ; accès aux éléments individuels et au formatage tels que TextHolders, TextFrames, Paragraphs et Portions.|Oui|Oui|
|Accès direct et complet de bas niveau aux éléments XML sous‑jacent et aux attributs tels que les identifiants de relation, les identifiants de liste d’un document OOXML.|Oui|Non|
|<p>Rendu de présentation :</p><p>- Rendre des présentations en PDF, PDF Notes, XPS, images TIFF.</p><p>- Rendre des miniatures de diapositives en PNG, JPEG, BMP, SVG et TIFF.</p><p>- Spécifier la résolution d’image, la qualité, la compression et d’autres options.</p>|Non|Oui|
|Plateformes prises en charge|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusion**
Open XML SDK et Aspose.Slides ne sont pas en concurrence directe car ils répondent à des besoins très différents et ciblent des publics différents.

{{% alert color="info" title="Note" %}}
Open XML SDK est une bibliothèque de classes qui fournit une façon fortement typée de travailler avec les documents OOXML tandis qu’Aspose.Slides est une bibliothèque de traitement de présentations incroyablement utile qui offre un excellent support pour presque tous les formats de fichiers Microsoft PowerPoint.
{{% /alert %}}

Si votre flux de travail consiste en une opération de programmation de base sur un document PPTX, alors Open XML SDK peut être un bon choix. Avec Open XML SDK, vous devriez être à l’aise pour effectuer des tâches simples comme générer un document PPTX basique ou supprimer des commentaires, des en‑têtes/pieds de page, extraire des images ou d’autres opérations similaires. Certaines tâches peuvent être réalisées avec Open XML SDK mais ne le peuvent pas avec Aspose.Slides. Par exemple, si vous devez accéder directement aux éléments XML et aux attributs d’un document OOXML, vous devez utiliser Open XML SDK.

Si vous devez réaliser des tâches complexes sur des documents—telles que les tâches de la liste ci‑dessous—alors Aspose.Slides est votre meilleure option.

- Opérations impliquant les anciens formats PowerPoint (et PPTX également).  
- Copie ou clonage de formes au sein des diapositives de manière à combiner objets, styles et autres éléments de formatage de façon appropriée.  
- Remplacement de texte formaté ou non formaté.  
- Application d’animations et utilisation de connecteurs avec des formes.  
- Conversion d’un document en PDF, TIFF ou XPS afin qu’il ressemble à une conversion effectuée par Microsoft PowerPoint.  
- Développement d’une application .NET ou Java dans des environnements de bureau et web.