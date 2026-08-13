---
title: Pourquoi ne pas utiliser Open XML SDK
type: docs
weight: 50
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
description: "Découvrez pourquoi Aspose.Slides est un meilleur choix que le Open XML SDK gratuit : comparez les fonctionnalités, la conversion sans automatisation et la prise en charge étendue des formats PPT, PPTX et ODP."
---
## **Vue d'ensemble**

Cet article explique quand les développeurs peuvent choisir Open XML SDK ou Aspose.Slides pour travailler avec des documents de présentation. Il décrit Open XML SDK comme une bibliothèque permettant de manipuler des packages OOXML et leurs éléments XML sous‑jacent, tandis qu'Aspose.Slides est présenté comme une bibliothèque de traitement de présentations avec un modèle d'objets de haut niveau et la prise en charge de nombreuses tâches liées à PowerPoint.

L'article compare les deux options selon les formats pris en charge, le modèle de programmation, les capacités de rendu et d'impression, le support multiplateforme et les cas d'utilisation courants. Il précise également que Open XML SDK peut convenir pour des opérations PPTX basiques ou un accès direct aux éléments OOXML, tandis qu'Aspose.Slides est plus approprié pour des tâches de présentation complexes telles que le travail avec plusieurs formats PowerPoint, la copie ou le clonage de formes, le remplacement de texte, l'application d'animations et la conversion de présentations en PDF, TIFF ou XPS.

## **Qu'est‑ce que Open XML SDK ?**
Parfois, on reçoit cette question : *Pourquoi devrions‑nous utiliser les produits Aspose plutôt que le Open XML SDK gratuit ?*

Nous trouvons facile de répondre à cette question en termes de fonctionnalités et de capacités.

Selon la [Bibliothèque MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), le Open XML SDK est défini ainsi :

> "Le Open XML SDK 2.0 simplifie la tâche de manipulation des packages Open XML et des éléments du schéma Open XML sous‑jacent à l'intérieur d'un package. Le Open XML SDK 2.0 encapsule de nombreuses tâches courantes que les développeurs effectuent sur les packages Open XML, de sorte que vous pouvez réaliser des opérations complexes en quelques lignes de code seulement. Les documents OOXML sont essentiellement des fichiers XML compressés et le Open XML SDK est une collection de classes qui vous permet de travailler avec le contenu des documents OOXML de manière fortement typée. Au lieu de décompresser un fichier pour extraire le XML, charger ce XML dans un arbre DOM et travailler directement avec les éléments et attributs XML, le Open XML SDK fournit des classes pour le faire."

## **Qu'est‑ce que Aspose.Slides ?**
Aspose.Slides est une bibliothèque de classes qui permet aux applications d'effectuer les tâches de traitement de présentations suivantes :

- Programmation avec un modèle d'objets de présentation.  
- Conversions de haute qualité impliquant tous les formats de présentation PowerPoint populaires, y compris la conversion en PDF, XPS, TIFF et l'impression.  
- Génération de vignettes de diapositives dans des formats bien connus tels que PNG, JPEG et BMP, ainsi que l'exportation de diapositives vers SVG.  
- Construction de présentations à partir de zéro ou en combinant des éléments provenant d'un ou plusieurs documents.  
- Ajout d'animations, de frames OLE, de tableaux, de création et de gestion de graphiques.  
- Contrôle (contrôle étendu) et gestion du formatage du texte au niveau des TextFrames, Paragraphs et Portions.  

Pour plus de détails sur les fonctionnalités disponibles, veuillez consulter la page [Fonctionnalités Aspose.Slides](/slides/fr/net/product-overview/).

## **Comparer Open XML SDK avec Aspose.Slides**
Ce tableau compare les capacités et les fonctionnalités du Open XML SDK avec celles d'Aspose.Slides.

|**Fonctionnalité ou catégorie de fonctionnalité**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formats de présentation pris en charge|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion de PPT vers PPTX|Non|Oui|
|<p>Programmation de haut niveau avec un modèle d'objet de document de présentation (DOM) :</p><p>- Rechercher et remplacer du texte.</p><p>- Assembler des diapositives dans des présentations.</p>|Non|Oui|
|Programmation détaillée avec un modèle d'objet de document ; accès aux éléments individuels et au formatage tels que TextHolders, TextFrames, Paragraphs et Portions.|Oui|Oui|
|Accès direct et complet de bas niveau aux éléments XML sous‑jacent et aux attributs tels que les identifiants de relation, les identifiants de liste d'un document OOXML.|Oui|Non|
|<p>Rendu et impression :</p><p>- Rendre les présentations en PDF, PDF Notes, XPS, images TIFF.</p><p>- Rendre des vignettes de diapositives en PNG, JPEG, BMP, SVG et TIFF.</p><p>- Spécifier la résolution, la qualité, la compression et d'autres options d'image.</p><p>- Imprimer les présentations en utilisant l'infrastructure d'impression .NET. Le composant dispose d'une méthode d'impression intégrée pour imprimer les présentations comme affiché dans l'aperçu avant impression de MS PowerPoint.</p>|Non|Oui|
|Plateformes prises en charge|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusion**
Open XML SDK et Aspose.Slides ne sont pas en concurrence directe car ils répondent à des besoins considérablement différents et ciblent des publics différents.

{{% alert color="info" %}} 

Open XML SDK est une bibliothèque de classes qui offre une manière fortement typée de travailler avec les documents OOXML tandis qu'Aspose.Slides est une bibliothèque de traitement de présentations incroyablement utile qui offre un excellent support pour presque tous les formats de fichiers Microsoft PowerPoint. 

{{% /alert %}} 

Si votre flux de travail consiste en une opération de programmation basique sur un document PPTX, alors Open XML SDK peut être un bon choix. Avec Open XML SDK, vous devriez être à l'aise pour réaliser des tâches simples comme générer un document PPTX simple ou supprimer des commentaires, des en‑têtes/pieds de page, extraire des images ou d'autres opérations. Certaines tâches peuvent être effectuées avec Open XML SDK mais ne le peuvent pas avec Aspose.Slides. Par exemple, si vous devez accéder directement aux éléments XML et aux attributs d'un document OOXML, vous devez utiliser Open XML SDK.

Si vous devez réaliser des tâches complexes sur des documents—telles que les tâches de la liste ci‑dessous—alors Aspose.Slides est votre meilleure option.

- Opérations impliquant d'anciens formats PowerPoint (et PPTX également).  
- Copie ou clonage de formes au sein des diapositives de manière à combiner objets, styles et autres éléments de formatage de façon appropriée.  
- Remplacement de texte formaté ou non formaté.  
- Application d'animations et utilisation de connecteurs avec les formes.  
- Conversion d'un document en PDF, TIFF ou XPS afin qu'il ressemble à une conversion effectuée par Microsoft PowerPoint.  
- Développement d'une application .NET ou Java à la fois sur des environnements de bureau et basés sur le web.