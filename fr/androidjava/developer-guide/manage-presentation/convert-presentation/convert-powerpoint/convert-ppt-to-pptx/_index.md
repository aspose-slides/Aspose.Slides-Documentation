---
title: Convertir PPT en PPTX sur Android
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/androidjava/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- PPT en PPTX
- enregistrer PPT en PPTX
- exporter PPT en PPTX
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Convertissez rapidement les présentations PPT héritées en PPTX moderne en Java avec Aspose.Slides pour Android — tutoriel clair, exemples de code gratuits, aucune dépendance à Microsoft Office."
---
## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PPT en format PPTX à l'aide de Java et d'une application de conversion en ligne de PPT vers PPTX. Le sujet suivant est couvert.

- Convertir PPT en PPTX avec Java

## **Convertir PPT en PPTX sur Android**

Pour le code d'exemple Java permettant de convertir PPT en PPTX, veuillez consulter la section ci‑dessous, à savoir [Convert PPT to PPTX](#convert-ppt-to-pptx). Il charge simplement le fichier PPT et l'enregistre au format PPTX. En spécifiant différents formats d’enregistrement, vous pouvez également enregistrer le fichier PPT dans de nombreux autres formats tels que PDF, XPS, ODP, HTML, etc., comme expliqué dans ces articles.

- [Convertir PPT en PDF sur Android](/slides/fr/androidjava/convert-powerpoint-to-pdf/)
- [Convertir PPT en XPS sur Android](/slides/fr/androidjava/convert-powerpoint-to-xps/)
- [Convertir PPT en HTML sur Android](/slides/fr/androidjava/convert-powerpoint-to-html/)
- [Convertir PPT en ODP sur Android](/slides/fr/androidjava/save-presentation/)
- [Convertir PPT en PNG sur Android](/slides/fr/androidjava/convert-powerpoint-to-png/)

## **À propos de la conversion PPT en PPTX**
Convertissez l’ancien format PPT en PPTX avec l'API Aspose.Slides. Si vous devez convertir des milliers de présentations PPT en format PPTX, la meilleure solution consiste à le faire de façon programmatique. Avec l'API Aspose.Slides, il est possible de le réaliser en quelques lignes de code seulement. L'API assure une compatibilité complète pour convertir une présentation PPT en PPTX et permet de :

- Convertir les structures complexes de maîtres, de mises en page et de diapositives.
- Convertir une présentation avec des graphiques.
- Convertir une présentation contenant des formes groupées, des formes automatiques (comme des rectangles et des ellipses), des formes avec une géométrie personnalisée.
- Convertir une présentation avec des textures et des styles de remplissage d'images pour les formes automatiques.
- Convertir une présentation avec des espaces réservés, des cadres de texte et des contenants de texte.

{{% alert color="info" %}} 

Jetez un œil à l'application [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx)

Cette application est construite sur la [**Aspose.Slides API**](https://products.aspose.com/slides/fr/androidjava/), vous permettant ainsi de voir un exemple fonctionnel des capacités de conversion de base de PPT en PPTX. Aspose.Slides Conversion est une application web qui permet de déposer un fichier de présentation au format PPT et de le télécharger converti en PPTX.

Découvrez d’autres exemples en ligne de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/fr/conversion/) .

{{% /alert %}} 

## **Convertir PPT en PPTX**
Aspose.Slides pour Android via Java facilite désormais les développeurs pour accéder au PPT à l'aide de l’instance de classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation) et le convertir dans le format [PPTX](https://docs.fileformat.com/presentation/pptx/) correspondant. Actuellement, il prend en charge la conversion partielle de [PPT](https://docs.fileformat.com/presentation/ppt/) vers PPTX.

Aspose.Slides pour Android via Java propose la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation) qui représente un fichier de présentation **PPTX**. La classe Presentation peut désormais également accéder au **PPT** via Presentation lorsqu’elle est instanciée. L’exemple suivant montre comment convertir une présentation PPT en présentation PPTX.

```java
import com.aspose.slides.*;

// Instancier un objet Presentation qui représente un fichier PPT
Presentation pres = new Presentation("Aspose.ppt");
try {
// Enregistrement de la présentation PPT au format PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figure : Présentation PPT source**|

Le fragment de code ci‑dessus génère la présentation PPTX suivante après conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure : Présentation PPTX générée après conversion**|

## **FAQ**

### Quelle est la différence entre les formats PPT et PPTX ?

PPT est l’ancien format binaire utilisé par Microsoft PowerPoint, tandis que PPTX est le nouveau format basé sur XML introduit avec Microsoft Office 2007. Les fichiers PPTX offrent de meilleures performances, une taille réduite et une récupération de données améliorée.

### Aspose.Slides prend‑il en charge la conversion par lots de plusieurs fichiers PPT en PPTX ?

Oui, vous pouvez utiliser Aspose.Slides dans une boucle pour convertir plusieurs fichiers PPT en PPTX de manière programmatique, ce qui le rend adapté aux scénarios de conversion par lots.

### Le contenu et le formatage seront‑ils conservés après la conversion ?

Aspose.Slides maintient une haute fidélité lors de la conversion des présentations. Les mises en page des diapositives, les animations, les formes, les graphiques et les autres éléments de conception sont préservés pendant la conversion de PPT en PPTX.

### Puis‑je convertir d’autres formats comme PDF ou HTML à partir de fichiers PPT ?

Oui, Aspose.Slides prend en charge la conversion de fichiers PPT vers [de multiples formats](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/), y compris PDF, XPS, HTML, ODP et des formats d’image tels que PNG et JPEG.

### Est‑il possible de convertir PPT en PPTX sans Microsoft PowerPoint installé ?

Oui, Aspose.Slides est une API autonome qui ne nécessite ni Microsoft PowerPoint ni aucun logiciel tiers pour effectuer la conversion.

### Existe‑t‑il un outil en ligne disponible pour la conversion PPT en PPTX ?

Oui, vous pouvez utiliser l’application web gratuite [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx) pour effectuer la conversion directement dans votre navigateur sans écrire de code.