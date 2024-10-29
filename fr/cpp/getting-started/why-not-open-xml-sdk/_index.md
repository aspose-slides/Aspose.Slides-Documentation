---
title: Pourquoi ne pas utiliser Open XML SDK
type: docs
weight: 100
url: /fr/cpp/pourquoi-ne-pas-utiliser-open-xml-sdk/
---

## **Qu'est-ce qu'Open XML SDK ?**
Nous entendons parfois cette question : Pourquoi devrions-nous utiliser les produits Aspose plutôt que le gratuit Open XML SDK ? Cette question est facile à répondre : fonctionnalités et possibilités. Selon la [Bibliothèque MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK est défini comme suit : L'Open XML SDK 2.0 simplifie la tâche de manipulation des packages Open XML et des éléments de schéma Open XML sous-jacents au sein d'un package. L'Open XML SDK 2.0 encapsule de nombreuses tâches courantes que les développeurs effectuent sur les packages Open XML, de sorte que vous puissiez effectuer des opérations complexes avec seulement quelques lignes de code. Les documents OOXML sont essentiellement des fichiers XML compressés, et l'Open XML SDK est une collection de classes qui vous permet de travailler avec le contenu des documents OOXML de manière fortement typée. C'est-à-dire qu'au lieu de décompresser un fichier pour extraire du XML, de charger ce XML dans un arbre DOM et de travailler directement avec des éléments et des attributs XML, l'Open XML SDK fournit des classes pour cela.
## **Qu'est-ce qu'Aspose.Slides ?**
Aspose.Slides est une bibliothèque de classes qui permet à votre application d'effectuer les tâches suivantes de traitement de présentations :

- Programmation avec un modèle d'objet **Presentation**.
- Conversions de haute qualité parmi tous les formats de présentation PowerPoint populaires pris en charge, y compris la conversion en PDF et XPS.
- Capacité à générer des vignettes de diapositives dans des formats bien connus comme PNG, JPEG et BMP avec exportation de diapositives vers SVG.
- Capacité à créer des présentations à partir de zéro ou en combinant plusieurs documents.
- Support pour l'ajout d'animations, de cadres Ole, de tableaux, la création et la gestion de graphiques.
- Disponibilité d'un contrôle étendu pour la gestion de la mise en forme du texte au niveau des TextFrames, Paragraphes et Portions.
  Pour plus de détails sur les fonctionnalités prises en charge, veuillez visiter [Fonctionnalités d'Aspose.Slides](/slides/fr/net/product-overview/).
## **Comparer Open XML SDK et Aspose.Slides**
Le tableau suivant compare les caractéristiques d'Open XML SDK et d'Aspose.Slides.

|**Fonction ou catégorie de fonction**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formats de présentations pris en charge|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion de PPT à PPTX|Non|Oui|
|<p>Programmation de haut niveau avec un modèle d'objet document de présentation (DOM) :</p><p>- Trouver et remplacer du texte.</p><p>- Assembler des diapositives dans des présentations.</p>|Non|Oui|
|Programmation détaillée avec un modèle d'objet document, accès aux éléments individuels et à la mise en forme tel que TextHolders, TextFrames, Paragraphes et Portions.|Oui|Oui|
|Accès direct et complet de bas niveau aux éléments et attributs XML sous-jacents tels que les identifiants de relation, les identifiants de liste d'un document OOXML.|Oui|Non|
|<p>Rendu :</p><p>- Rendre des présentations en PDF, Notes PDF, XPS, images TIFF.</p><p>- Rendre des vignettes de diapositives en PNG, JPEG, BMP, SVG et TIFF.</p><p>- Spécifier la résolution d'image, la qualité, la compression et d'autres options.</p>|Non|Oui|

## **Conclusion**
Open XML SDK et Aspose.Slides ne sont pas en concurrence directe car ils répondent à des besoins et à des publics assez différents. Open XML SDK est une bibliothèque de classes qui fournit une manière fortement typée de travailler avec des documents OOXML. Aspose.Slides est une bibliothèque de traitement de présentations très utile qui offre un excellent support pour presque tous les formats de fichiers Microsoft PowerPoint. Si tout ce que vous devez faire est une opération de programmation assez basique sur un document PPTX, alors l'Open XML SDK pourrait être un choix approprié. Avec l'Open XML SDK, vous serez assez à l'aise pour effectuer des tâches simples comme générer un simple document PPTX ou supprimer des commentaires, des en-têtes/pieds de page, extraire des images ou d'autres. Certaines tâches peuvent être réalisées avec l'Open XML SDK, mais ne peuvent pas être réalisées avec Aspose.Slides. Par exemple, si vous devez accéder directement aux éléments et attributs XML d'un document OOXML, alors vous devriez utiliser l'Open XML SDK. Cependant, si vous devez effectuer des opérations complexes sur des documents, comme certaines des tâches suivantes, alors utiliser Aspose.Slides est votre meilleure option :

- Supporter les anciens formats PowerPoint en plus de PPTX.
- Copier ou cloner des formes dans des diapositives de manière à combiner des objets, styles et autres mises en forme de manière appropriée.
- Remplacer du texte formaté ou non formaté.
- Appliquer des animations et utiliser des connecteurs avec les formes utilisées.
- Convertir un document en PDF ou XPS pour qu'il apparaisse exactement comme Microsoft PowerPoint l'aurait converti.
- Développer une application C++ tant dans des environnements de bureau que dans des environnements basés sur des consoles.