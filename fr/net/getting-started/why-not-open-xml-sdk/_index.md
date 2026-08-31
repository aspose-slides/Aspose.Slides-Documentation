---
title: Pourquoi pas Open XML SDK
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
description: "Découvrez pourquoi Aspose.Slides est un meilleur choix que le gratuit Open XML SDK : comparez les fonctionnalités, la conversion sans automatisation et la large prise en charge de PPT, PPTX et ODP."
---
## **Aperçu**

Cet article explique quand les développeurs peuvent choisir Open XML SDK ou Aspose.Slides pour travailler avec des documents de présentation. Il décrit Open XML SDK comme une bibliothèque pour manipuler les packages OOXML et leurs éléments XML sous‑jacent, tandis qu’Aspose.Slides est présenté comme une bibliothèque de traitement de présentations avec un modèle d’objet de haut niveau et une prise en charge de nombreuses tâches liées à PowerPoint.

L’article compare les deux options selon les formats pris en charge, le modèle de programmation, le rendu, la prise en charge des plateformes et les cas d’utilisation courants. Il précise également que Open XML SDK peut convenir pour des opérations PPTX de base ou un accès direct aux éléments OOXML, tandis qu’Aspose.Slides est plus approprié pour des tâches de présentation complexes telles que le travail avec plusieurs formats PowerPoint, la copie ou le clonage de formes, le remplacement de texte, l’application d’animations et la conversion de présentations en PDF, TIFF ou XPS.

## **Qu'est‑ce que Open XML SDK ?**
Parfois, nous recevons cette question : *Pourquoi devrions‑nous utiliser les produits Aspose plutôt que le gratuit Open XML SDK ?* 

Nous trouvons facile de répondre à cette question en termes de fonctionnalités et de capacités. 

Selon la [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK est défini ainsi : 

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **Qu'est‑ce que Aspose.Slides ?**
Aspose.Slides est une bibliothèque de classes qui permet aux applications d’effectuer ces tâches de traitement de présentations : 

- Programmation avec un modèle d’objet de présentation.  
- Conversions de haute qualité impliquant tous les formats de présentation PowerPoint populaires, y compris la conversion en PDF, XPS et TIFF.  
- Génération de miniatures de diapositives dans des formats bien connus tels que PNG, JPEG et BMP, ainsi que l’exportation de diapositives vers SVG.  
- Création de présentations à partir de zéro ou en combinant des éléments provenant d’un ou plusieurs documents.  
- Ajout d’animations, de cadres OLE, de tableaux, création et gestion de graphiques.  
- Contrôle (contrôle étendu) et gestion du formatage du texte au niveau des TextFrames, Paragraphs et Portions.  

Pour plus de détails sur les fonctionnalités disponibles, veuillez consulter la page [Aspose.Slides Features](/slides/fr/net/product-overview/).

## **Comparer Open XML SDK avec Aspose.Slides**
Ce tableau compare les capacités et les fonctionnalités d’Open XML SDK avec celles d’Aspose.Slides.

|**Fonctionnalité ou catégorie de fonctionnalité**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formats de présentations pris en charge|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion de PPT en PPTX|Non|Oui|
|<p>Programmation de haut niveau avec un modèle d'objet de document de présentation (DOM) : </p><p>- Rechercher et remplacer du texte.</p><p>- Assembler des diapositives dans des présentations.</p>|Non|Oui|
|Programmation détaillée avec un modèle d'objet de document ; accès aux éléments individuels et au formatage tel que TextHolders, TextFrames, Paragraphs et Portions.|Oui|Oui|
|Accès direct et complet de bas niveau aux éléments et attributs XML sous‑jacent tels que les identifiants de relation, les identifiants de liste d’un document OOXML.|Oui|Non|
|<p>Rendu de présentations :</p><p>- Rendre les présentations en PDF, PDF Notes, XPS, images TIFF.</p><p>- Rendre les miniatures de diapositives en PNG, JPEG, BMP, SVG et TIFF.</p><p>- Spécifier la résolution, la qualité, la compression et d’autres options d’image.</p>|Non|Oui|
|Plateformes prises en charge|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusion**
Open XML SDK et Aspose.Slides ne sont pas en concurrence directe car ils répondent à des besoins considérablement différents et ciblent des publics différents. 

{{% alert color="info" %}} 
Open XML SDK est une bibliothèque de classes qui fournit une manière fortement typée de travailler avec les documents OOXML tandis qu’Aspose.Slides est une bibliothèque de traitement de présentations incroyablement utile qui offre une excellente prise en charge de presque tous les formats de fichiers Microsoft PowerPoint. 
{{% /alert %}} 

Si votre flux de travail consiste en une opération de programmation basique sur un document PPTX, alors Open XML SDK peut être un bon choix. Avec Open XML SDK, vous devriez être à l’aise pour effectuer des tâches simples comme générer un document PPTX simple ou supprimer des commentaires, en‑têtes/pieds de page, extraire des images ou d’autres. Certaines tâches peuvent être effectuées avec Open XML SDK mais ne peuvent pas l’être avec Aspose.Slides. Par exemple, si vous devez accéder directement aux éléments et attributs XML d’un document OOXML, vous devez alors utiliser Open XML SDK. 

Si vous devez effectuer des tâches complexes sur les documents—comme les tâches de la liste ci‑dessous—alors Aspose.Slides est votre meilleure option. 

- Opérations impliquant d’anciens formats PowerPoint (et PPTX également).  
- Copier ou cloner des formes au sein des diapositives d’une manière qui combine objets, styles et autres éléments de formatage de façon appropriée.  
- Remplacer du texte formaté ou non formaté.  
- Appliquer des animations et utiliser des connecteurs avec les formes.  
- Convertir un document en PDF, TIFF ou XPS afin qu’il ressemble à la conversion effectuée par Microsoft PowerPoint.  
- Développer une application .NET ou Java tant sur des environnements de bureau que web.