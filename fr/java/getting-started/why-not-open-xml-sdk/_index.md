---
title: Pourquoi ne pas utiliser Open XML SDK
type: docs
weight: 120
url: /fr/java/why-not-open-xml-sdk/
---

{{% alert color="primary" %}} 

Nous entendons parfois cette question :

**Pourquoi devrions-nous utiliser les produits Aspose plutôt que le gratuit Open XML SDK ?**

Cette question est facile à répondre : **fonctionnalités et fonctionnalités**.

{{% /alert %}} 
## **Qu'est-ce qu'Open XML SDK ?**
Selon la [bibliothèque MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK est défini comme : 

Le SDK Open XML 2.0 simplifie la tâche de manipulation des packages Open XML et des éléments de schéma Open XML sous-jacents au sein d'un package. Le SDK Open XML 2.0 encapsule de nombreuses tâches courantes que les développeurs effectuent sur les packages Open XML, afin que vous puissiez effectuer des opérations complexes en quelques lignes de code seulement.

Les documents OOXML sont essentiellement des fichiers XML compressés et Open XML SDK est une collection de classes qui vous permet de travailler avec le contenu des documents OOXML de manière fortement typée. C'est-à-dire qu'au lieu de décompresser un fichier pour extraire le XML, de charger ce XML dans un arbre DOM et de travailler directement avec les éléments et attributs XML, le SDK Open XML fournit des classes pour ce faire.
## **Qu'est-ce qu'Aspose.Slides ?**
Aspose.Slides est une bibliothèque de classes qui permet à votre application d'effectuer les tâches de traitement de présentation suivantes :

- Programmation avec un modèle d'objet **Presentation**.
- Conversions de haute qualité entre tous les formats de présentation PowerPoint pris en charge, y compris la conversion en PDF, XPS et TIFF.
- Capacité à générer des miniatures de diapositives dans des formats bien connus comme PNG, JPEG et BMP ainsi que l'exportation de diapositives vers SVG.
- Capacité à créer des présentations à partir de zéro ou en combinant plusieurs documents.
- Support pour l'ajout d'animations, de cadres Ole, de tableaux, de création et de gestion de graphiques.
- Disponibilité d'un contrôle étendu pour gérer le formatage du texte au niveau des TextFrames, Paragraphes et Portions.

Pour plus de détails sur les fonctionnalités prises en charge, veuillez visiter [Fonctionnalités d'Aspose.Slides](/slides/fr/java/product-overview/).
## **Comparer Open XML SDK et Aspose.Slides**
{{% alert color="primary" %}} 

Le tableau suivant compare les fonctionnalités d'Open XML SDK et d'Aspose.Slides.

{{% /alert %}} 

|**Fonctionnalité ou Catégorie de Fonctionnalité**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formats de présentations pris en charge|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion de PPT à PPTX |Non|Oui|
|<p>Programmation de haut niveau avec un modèle d'objet Document Presentation (DOM) :</p><p>- Rechercher et remplacer du texte.</p><p>- Assembler des diapositives dans des présentations.</p>|Non|Oui|
|Programmation détaillée avec un modèle d'objet document, accès aux éléments individuels et formatage tel que TextHolders, TextFrames, Paragraphes et Portions.|Oui|Oui|
|Accès direct et complet aux éléments et attributs XML sous-jacents tels que les identifiants de relation, les identifiants de liste d'un document OOXML.|Oui|Non|
|<p>Rendu :</p><p>- Rendre des présentations en PDF, PDF Notes, images XPS, TIFF.</p><p>- Rendre des miniatures de diapositives en PNG, JPEG, BMP, SVG et TIFF.</p><p>- Spécifier la résolution de l'image, la qualité, la compression et d'autres options.</p>|Non|Oui |
|Plateformes prises en charge|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|
## **Conclusion**
{{% alert color="primary" %}} 

Open XML SDK et Aspose.Slides ne concurrencent pas de manière directe car ils répondent à des besoins et à des publics assez différents. Open XML SDK est une bibliothèque de classes pour fournir un moyen fortement typé de travailler avec les documents OOXML. Aspose.Slides est une bibliothèque de traitement de présentations très utile qui offre un excellent support pour presque tous les formats de fichiers Microsoft PowerPoint.

Si tout ce que vous devez faire est une opération de programmation assez basique sur un document PPTX, alors Open XML SDK pourrait être un choix approprié. Avec Open XML SDK, vous serez assez à l'aise pour effectuer des tâches simples comme générer un simple document PPTX ou supprimer des commentaires, en-têtes/pieds de page, extraire des images ou d'autres. Certaines tâches peuvent être réalisées avec Open XML SDK, mais ne peuvent pas être réalisées avec Aspose.Slides. Par exemple, si vous devez accéder directement aux éléments et attributs XML d'un document OOXML, alors vous devriez utiliser Open XML SDK. Cependant, si vous devez effectuer des opérations complexes sur des documents, telles que certaines des tâches suivantes, alors utiliser Aspose.Slides est votre meilleure option :

- Support des anciens formats PowerPoint en plus de PPTX.
- Copier ou cloner des formes dans des diapositives de manière à combiner objets, styles et autres formats de manière appropriée.
- Remplacer du texte formaté ou non formaté.
- Appliquer des animations et utiliser des connecteurs avec les formes utilisées.
- Convertir un document en PDF, TIFF ou XPS afin qu'il apparaisse exactement comme Microsoft PowerPoint l'aurait converti.
- Développer une application .NET ou Java dans des environnements de bureau et basés sur le web.

{{% /alert %}}