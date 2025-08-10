---
title: Exporter des présentations en HTML avec des images liées en externe en Python
linktitle: Exporter des présentations en HTML avec des images liées en externe
type: docs
weight: 100
url: /fr/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint vers HTML
- OpenDocument vers HTML
- présentation vers HTML
- diapositive vers HTML
- PPT vers HTML
- PPTX vers HTML
- ODP vers HTML
- exportation HTML
- image liée
- image liée en externe
- ressource HTML
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment exporter des présentations en HTML avec des images liées en externe dans Aspose.Slides for Python via .NET, couvrant les formats PowerPoint et OpenDocument."
---

{{% alert color="primary" %}} 

Cet article décrit une technique avancée qui permet de contrôler les ressources qui sont intégrées dans le fichier HTML résultant et celles qui sont enregistrées externément et référencées depuis le fichier HTML.

{{% /alert %}} 
## **Contexte**
Le comportement par défaut de l'exportation en HTML est d'intégrer toute ressource dans le fichier HTML. Cette approche aboutit à un fichier HTML unique qui est facile à visualiser et à distribuer. Toutes les ressources nécessaires sont encodées en base64 à l'intérieur. Mais cette approche a deux inconvénients :

- La taille de la sortie est significativement plus grande en raison de l'encodage en base64. Il est difficile de remplacer les images contenues dans le fichier.

Dans cet article, nous allons voir comment nous pouvons changer le comportement par défaut en utilisant **Aspose.Slides for Python via .NET** pour lier les images de manière externe plutôt que de les intégrer dans le fichier HTML. Nous allons utiliser l'interface **ILinkEmbedController** qui contient trois méthodes pour contrôler le processus d'intégration et de sauvegarde des ressources. Nous pouvons passer cette interface au constructeur de la classe HtmlOptions lors de la préparation de l'exportation.

Voici le code complet de la classe **LinkController** qui implémente l'interface **ILinkEmbedController**. Comme mentionné précédemment, le LinkController doit implémenter l'interface ILinkEmbedController. Cette interface spécifie trois méthodes :

- **public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)** Elle est appelée lorsque l'exportateur rencontre une ressource et doit décider comment la stocker. Les paramètres les plus importants sont ‘id’ – l'identifiant unique de la ressource pour l'ensemble de l'opération d'exportation et ‘contentType’ – contient le type MIME de la ressource. Si nous décidons de lier la ressource, nous devrions retourner LinkEmbedDecision.Link depuis cette méthode. Sinon, LinkEmbedDecision.Embed devrait être retourné pour intégrer la ressource.
- **public string GetUrl(int id, int referrer)** 
  Elle est appelée pour obtenir l'URL de la ressource sous la forme dans laquelle elle est utilisée dans le fichier résultant, par exemple pour une balise <img src=”%method_result_here%”>. La ressource est identifiée par ‘id’.
- **public void SaveExternal(int id, byte[] entityData)** 
  La dernière méthode de la séquence, elle est appelée lorsqu'il s'agit de stocker la ressource de manière externe. Nous avons l'identifiant de la ressource et le contenu de la ressource sous la forme d'un tableau de bytes. C'est à nous de décider quoi faire avec les données de la ressource fournies.

```py
# [TODO[not_supported_yet]: implémentation python des interfaces .net]
```

Après avoir écrit la classe **LinkController**, nous allons maintenant l'utiliser avec la classe **HTMLOptions** pour exporter la présentation au format HTML en ayant des images liées externément en utilisant le code suivant.

```py
# [TODO[not_supported_yet]: implémentation python des interfaces .net]
```

Nous avons assigné **SlideImageFormat.Svg** à la propriété **SlideImageFormat**, ce qui signifie que le fichier HTML résultant contiendra des données SVG à l'intérieur pour dessiner le contenu de la présentation.

En ce qui concerne les types de contenu, cela dépend des données d'image réelles contenues dans la présentation. S'il y a des bitmaps raster dans la présentation, alors le code de la classe doit être prêt à traiter les types de contenu ‘image/jpeg’ et ‘image/png’. Le type de contenu réel des images bitmap raster exportées peut ne pas correspondre à celui des images stockées dans la présentation. Les algorithmes internes d'Aspose.Slides effectuent une optimisation de taille et utilisent soit le codec JPG, soit le codec PNG, selon celui qui génère une taille de données plus petite. Les images contenant un canal alpha (transparence) sont toujours encodées en PNG.