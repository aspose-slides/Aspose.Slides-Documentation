---
title: Pourquoi ne pas utiliser Open XML SDK
type: docs
weight: 120
url: /php-java/pourquoi-ne-pas-utiliser-open-xml-sdk/
---

{{% alert color="primary" %}} 

Nous entendons parfois cette question :

**Pourquoi devrions-nous utiliser les produits Aspose plutôt que le SDK Open XML gratuit ?**

Cette question est facile à répondre : **fonctionnalités et fonctionnalités**.

{{% /alert %}} 
## **Qu'est-ce que Open XML SDK ?**
Selon la [Bibliothèque MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK est défini comme : 

Le Open XML SDK 2.0 simplifie la tâche de manipulation des paquets Open XML et des éléments de schéma Open XML sous-jacents dans un paquet. Le Open XML SDK 2.0 encapsule de nombreuses tâches courantes que les développeurs effectuent sur les paquets Open XML, afin que vous puissiez effectuer des opérations complexes avec juste quelques lignes de code.

Les documents OOXML sont essentiellement des fichiers XML compressés et Open XML SDK est une collection de classes qui vous permet de travailler avec le contenu des documents OOXML de manière fortement typée. Au lieu de décompresser un fichier pour extraire du XML, de charger ce XML dans un arbre DOM et de travailler directement avec les éléments et attributs XML, Open XML SDK fournit des classes pour le faire.
## **Qu'est-ce que Aspose.Slides ?**
Aspose.Slides est une bibliothèque de classes qui permet à votre application d'effectuer les tâches de traitement de présentation suivantes :

- Programmation avec un modèle d'objet **Presentation**.
- Conversions de haute qualité entre tous les formats de présentation PowerPoint populaires pris en charge, y compris la conversion en PDF, XPS et TIFF.
- Possibilité de générer des vignettes de diapositives dans des formats bien connus tels que PNG, JPEG et BMP, ainsi que l'exportation de diapositives en SVG.
- Capacité à créer des présentations à partir de zéro ou en combinant plusieurs documents.
- Support pour l'ajout d'animations, de cadres Ole, de tableaux, ainsi que la création et la gestion de graphiques.
- Disponibilité d'un contrôle étendu pour gérer le formatage du texte au niveau des TextFrames, Paragraphes et Portions.

Pour plus de détails sur les fonctionnalités prises en charge, veuillez visiter [Fonctionnalités Aspose.Slides](/slides/php-java/product-overview/).
## **Comparer Open XML SDK et Aspose.Slides**
{{% alert color="primary" %}} 

Le tableau suivant compare les fonctionnalités d'Open XML SDK et d'Aspose.Slides.

{{% /alert %}} 

|**Fonctionnalité ou catégorie de fonctionnalités**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formats de présentations pris en charge|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion de PPT à PPTX |Non|Oui|
|<p>Programmation de haut niveau avec un modèle d'objet Document Presentation (DOM) :</p><p>- Trouver et remplacer du texte.</p><p>- Assembler des diapositives dans des présentations.</p>|Non|Oui|
|Programmation détaillée avec un modèle d'objet document, accès à des éléments et formats individuels tels que TextHolders, TextFrames, Paragraphs et Portions.|Oui|Oui|
|Accès direct et complet de bas niveau aux éléments et attributs XML sous-jacents tels que les identifiants de relation, les identifiants de liste d'un document OOXML.|Oui|Non|
|<p>Rendu :</p><p>- Rendre des présentations en PDF, PDF Notes, XPS, images TIFF.</p><p>- Rendre des vignettes de diapositives en PNG, JPEG, BMP, SVG et TIFF.</p><p>- Spécifier la résolution d'image, la qualité, la compression et d'autres options.</p>|Non|Oui |
|Plateformes prises en charge|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|
## **Conclusion**
{{% alert color="primary" %}} 

Open XML SDK et Aspose.Slides ne s'affrontent pas directement car ils répondent à des besoins et des publics très différents. Open XML SDK est une bibliothèque de classes permettant de travailler de manière fortement typée avec des documents OOXML. Aspose.Slides est une bibliothèque de traitement de présentations très utile qui offre un excellent support pour presque tous les formats de fichiers Microsoft PowerPoint.

Si tout ce que vous devez faire est une opération de programmation assez basique sur un document PPTX, alors Open XML SDK pourrait être un choix approprié. Avec Open XML SDK, vous serez assez à l'aise pour effectuer des tâches simples comme générer un document PPTX simple ou supprimer des commentaires, des en-têtes/pieds de page, extraire des images ou d'autres. Certaines tâches peuvent être réalisées avec Open XML SDK, mais ne peuvent pas être réalisées avec Aspose.Slides. Par exemple, si vous avez besoin d'accéder directement aux éléments XML et aux attributs d'un document OOXML, alors vous devriez utiliser Open XML SDK. Cependant, si vous devez effectuer des opérations complexes sur des documents, telles que certaines des tâches suivantes, alors l'utilisation d'Aspose.Slides est votre meilleure option :

- Prendre en charge les anciens formats PowerPoint en plus de PPTX.
- Copier ou cloner des formes dans des diapositives de manière à combiner des objets, des styles et d'autres formats de manière appropriée.
- Remplacer du texte formaté ou non formaté.
- Appliquer des animations et utiliser des connecteurs avec les formes utilisées.
- Convertir un document en PDF, TIFF ou XPS de sorte qu'il apparaisse exactement comme Microsoft PowerPoint l'aurait converti.
- Développer une application .NET ou Java dans des environnements de bureau et basés sur le web.

{{% /alert %}}