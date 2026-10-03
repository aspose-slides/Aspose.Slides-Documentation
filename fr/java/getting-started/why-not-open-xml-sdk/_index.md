---
title: Pourquoi pas Open XML SDK
type: docs
weight: 180
url: /fr/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- comparaison
- modèle d'objet de présentation
- conversion de haute qualité
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Découvrez pourquoi Aspose.Slides est un meilleur choix que le gratuit Open XML SDK : comparez les fonctionnalités, la conversion sans automatisation et la large prise en charge des formats PPT, PPTX et ODP."
---
## **Aperçu**

Cet article explique quand les développeurs peuvent choisir Open XML SDK ou Aspose.Slides pour travailler avec des documents de présentation. Il décrit Open XML SDK comme une bibliothèque permettant de manipuler des packages OOXML et leurs éléments XML sous-jacents, tandis qu’Aspose.Slides est présenté comme une bibliothèque de traitement de présentations avec un modèle d’objets de haut niveau et une prise en charge de nombreuses tâches liées à PowerPoint.

L’article compare les deux options selon les formats pris en charge, le modèle de programmation, le rendu, la prise en charge des plateformes et les cas d’utilisation courants. Il précise également qu’Open XML SDK peut convenir pour des opérations PPTX basiques ou un accès direct aux éléments OOXML, alors qu’Aspose.Slides est plus approprié pour des tâches de présentation complexes telles que travailler avec plusieurs formats PowerPoint, copier ou cloner des formes, remplacer du texte, appliquer des animations et convertir des présentations en PDF, TIFF ou XPS.

## **Qu’est‑ce que Open XML SDK ?**
Selon la [Bibliothèque MSDN](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK est défini comme suit :

Le SDK Open XML 2.0 simplifie la tâche de manipulation des packages Open XML et des éléments du schéma Open XML sous-jacents dans un package. Le SDK Open XML 2.0 encapsule de nombreuses tâches courantes que les développeurs effectuent sur les packages Open XML, de sorte que vous pouvez réaliser des opérations complexes en quelques lignes de code seulement.

Les documents OOXML sont essentiellement des fichiers XML compressés et Open XML SDK est une collection de classes qui vous permet de travailler avec le contenu des documents OOXML de façon fortement typée. Au lieu de décompresser un fichier pour extraire le XML, de charger ce XML dans un arbre DOM et de travailler directement avec les éléments et attributs XML, Open XML SDK fournit des classes pour le faire.

## **Qu’est‑ce que Aspose.Slides ?**
Aspose.Slides est une bibliothèque de classes qui permet à votre application d’exécuter les tâches de traitement de présentations suivantes :

- Programmation avec un modèle d’objet **Presentation**.
- Conversions de haute qualité entre tous les formats de présentation PowerPoint pris en charge, y compris la conversion en PDF, XPS et TIFF.
- Possibilité de générer des miniatures de diapositives dans des formats courants tels que PNG, JPEG et BMP ainsi que l’exportation de diapositives au format SVG.
- Possibilité de créer des présentations à partir de zéro ou en les combinant à partir d’un ou plusieurs documents.
- Prise en charge de l’ajout d’animations, de cadres Ole, de tableaux, ainsi que de la création et de la gestion de graphiques.
- Contrôle étendu pour la gestion du formatage du texte au niveau des TextFrames, Paragraphs et Portions.

Pour plus de détails sur les fonctionnalités prises en charge, consultez [Fonctionnalités d'Aspose.Slides](/slides/fr/java/product-overview/).

## **Comparer Open XML SDK et Aspose.Slides**
{{% alert color="info" title="Remarque" %}}

Le tableau suivant compare les fonctionnalités d’Open XML SDK et d’Aspose.Slides.

{{% /alert %}}

|**Fonctionnalité ou catégorie de fonctionnalité**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formats de présentations pris en charge|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion de PPT en PPTX|Non|Oui|
|<p>Programmation de haut niveau avec un modèle d’objet Document de Présentation (DOM) :</p><p>- Rechercher et remplacer du texte.</p><p>- Assembler des diapositives dans des présentations.</p>|Non|Oui|
|Programmation détaillée avec un modèle d’objet document, accès aux éléments individuels et au formatage tels que TextHolders, TextFrames, Paragraphs et Portions.|Oui|Oui|
|Accès direct et complet de bas niveau aux éléments XML sous‑jacents et aux attributs tels que les identifiants de relation, les identifiants de liste d’un document OOXML.|Oui|Non|
|<p>Rendu :</p><p>- Rendre des présentations en PDF, PDF Notes, XPS, images TIFF.</p><p>- Rendre des miniatures de diapositives en PNG, JPEG, BMP, SVG et TIFF.</p><p>- Spécifier la résolution d’image, la qualité, la compression et d’autres options.</p>|Non|Oui |
|Plateformes prises en charge|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|

## **Conclusion**
{{% alert color="info" title="Remarque" %}}

Open XML SDK et Aspose.Slides ne sont pas en concurrence directe car ils répondent à des besoins et à des publics très différents. Open XML SDK est une bibliothèque de classes offrant une manière fortement typée de travailler avec les documents OOXML. Aspose.Slides est une bibliothèque très utile de traitement de présentations qui prend en charge presque tous les formats de fichiers Microsoft PowerPoint.

Si vous avez simplement besoin d’une opération de programmation assez basique sur un document PPTX, Open XML SDK peut être un choix approprié. Avec Open XML SDK vous serez à l’aise pour réaliser des tâches simples comme générer un document PPTX simple ou supprimer des commentaires, en‑têtes/pieds de page, extraire des images, etc. Certaines tâches peuvent être réalisées avec Open XML SDK, mais ne le peuvent pas avec Aspose.Slides. Par exemple, si vous devez accéder directement aux éléments XML et aux attributs d’un document OOXML, vous devez utiliser Open XML SDK. En revanche, si vous devez exécuter des opérations complexes sur les documents, telles que les tâches suivantes, l’utilisation d’Aspose.Slides est votre meilleure option :

- Prise en charge des anciens formats PowerPoint en plus du PPTX.
- Copier ou cloner des formes dans les diapositives de manière à combiner objets, styles et autres formatages de façon appropriée.
- Remplacer du texte formaté ou non formaté.
- Appliquer des animations et utiliser des connecteurs avec les formes.
- Convertir un document en PDF, TIFF ou XPS afin qu’il apparaisse exactement comme le ferait Microsoft PowerPoint.
- Développer une application .NET ou Java tant en environnement de bureau qu’en environnement web.

{{% /alert %}}