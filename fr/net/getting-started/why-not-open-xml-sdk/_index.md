---
title: Pourquoi ne pas utiliser Open XML SDK
type: docs
weight: 50
url: /fr/net/why-not-open-xml-sdk/
---

## **Qu'est-ce qu'Open XML SDK ?**
Parfois, nous recevons cette question : *Pourquoi devrions-nous utiliser les produits Aspose plutôt que le gratuit Open XML SDK ?*

Nous trouvons facile de répondre à cette question en termes de caractéristiques et de fonctionnalités.

Selon la [Bibliothèque MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK est défini de la manière suivante :

> "L'Open XML SDK 2.0 simplifie la tâche de manipulation des paquets Open XML et des éléments de schéma Open XML sous-jacents dans un paquet. L'Open XML SDK 2.0 encapsule de nombreuses tâches courantes que les développeurs effectuent sur les paquets Open XML, afin que vous puissiez effectuer des opérations complexes en seulement quelques lignes de code. Les documents OOXML sont essentiellement des fichiers XML compressés et l'Open XML SDK est une collection de classes qui vous permet de travailler avec le contenu des documents OOXML de manière fortement typée. C'est-à-dire qu'au lieu de décompresser un fichier pour extraire XML, de charger ce XML dans un arbre DOM et de travailler directement avec les éléments et attributs XML, l'Open XML SDK fournit des classes pour le faire."

## **Qu'est-ce qu'Aspose.Slides ?**
Aspose.Slides est une bibliothèque de classes qui permet aux applications d'effectuer ces tâches de traitement de présentations :

- Programmation avec un modèle d'objet de présentation.

- Conversions de haute qualité impliquant tous les formats de présentation PowerPoint populaires pris en charge, y compris la conversion en PDF, XPS, TIFF et impression.

- Génération de vignettes de diapositives dans des formats bien connus tels que PNG, JPEG et BMP, ainsi que l'exportation de diapositives vers SVG.

- Création de présentations à partir de zéro ou en combinant des éléments de un ou plusieurs documents.

- Ajout d'animations, de cadres OLE, de tableaux, création et gestion de graphiques.

- Contrôle (contrôle étendu) et gestion de la mise en forme du texte au niveau des TextFrames, Paragraphes et Portions.

  Pour plus de détails sur les fonctionnalités disponibles, veuillez consulter la page [Fonctionnalités d'Aspose.Slides](/slides/fr/net/product-overview/).

## **Comparer Open XML SDK avec Aspose.Slides**
Ce tableau compare les capacités et les caractéristiques d'Open XML SDK avec celles d'Aspose.Slides.

|**Fonctionnalité ou catégorie de fonctionnalité**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formats de présentations pris en charge|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion de PPT en PPTX |Non|Oui|
|<p>Programmation de haut niveau avec un modèle d'objet de document de présentation (DOM) : </p><p>- Trouver et remplacer des textes.</p><p>- Assembler des diapositives dans des présentations.</p>|Non|Oui|
|Programmation détaillée avec un modèle d'objet de document ; accès à des éléments individuels et à des formats tels que TextHolders, TextFrames, Paragraphs et Portions.|Oui|Oui|
|Accès direct et complet de bas niveau aux éléments et attributs XML sous-jacents tels que les identificateurs de relation, les identificateurs de liste d'un document OOXML.|Oui|Non|
|<p>Rendu et impression :</p><p>- Rendre des présentations au format PDF, PDF Notes, XPS, images TIFF.</p><p>- Rendre des vignettes de diapositives au format PNG, JPEG, BMP, SVG et TIFF.</p><p>- Spécifier la résolution d'image, la qualité, la compression et d'autres options.</p><p>- Imprimer des présentations en utilisant l'infrastructure d'impression .NET. Le composant a une méthode d'impression intégrée pour imprimer les présentations comme montré dans l'aperçu avant impression de MS PowerPoint.</p>|Non|Oui|
|Plateformes prises en charge|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusion**
Open XML SDK et Aspose.Slides ne rivalisent pas directement car ils répondent à des besoins considérablement différents et ciblent des publics différents.

{{% alert color="primary" %}} 

Open XML SDK est une bibliothèque de classes qui fournit une manière fortement typée de travailler avec les documents OOXML, tandis qu'Aspose.Slides est une bibliothèque de traitement de présentations incroyablement utile qui offre un excellent support pour presque tous les formats de fichiers Microsoft PowerPoint. 

{{% /alert %}} 

Si votre flux de travail consiste en une opération de programmation de base sur un document PPTX, alors Open XML SDK pourrait être un bon choix. Avec Open XML SDK, vous devriez être à l'aise pour effectuer des tâches simples comme générer un document PPTX simple ou supprimer des commentaires, des en-têtes/pieds de page, extraire des images ou autres. Certaines tâches peuvent être effectuées avec Open XML SDK mais ne peuvent pas être réalisées avec Aspose.Slides. Par exemple, si vous devez accéder directement aux éléments et attributs XML d'un document OOXML, vous devriez utiliser Open XML SDK.

Si vous avez besoin d'effectuer des tâches complexes sur des documents—telles que les tâches énumérées ci-dessous—alors Aspose.Slides est votre meilleure option.

- Opérations impliquant d'anciens formats PowerPoint (et PPTX aussi).
- Copier ou cloner des formes au sein des diapositives d'une manière qui combine des objets, des styles et d'autres éléments de formatage de manière appropriée.
- Remplacer du texte formaté ou non formaté.
- Appliquer des animations et utiliser des connecteurs avec des formes.
- Convertir un document en PDF, TIFF ou XPS afin qu'il apparaisse comme si Microsoft PowerPoint avait effectué la conversion.
- Développer une application .NET ou Java dans des environnements de bureau et basés sur le web.