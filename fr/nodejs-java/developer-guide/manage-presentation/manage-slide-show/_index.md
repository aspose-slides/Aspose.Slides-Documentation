---
title: Gérer le diaporama
type: docs
weight: 90
url: /fr/nodejs-java/manage-slide-show/
keywords:
- type de diaporama
- présenté par un intervenant
- parcouru par un individu
- parcouru en kiosque
- options du diaporama
- boucle continue
- diaporama sans narration
- diaporama sans animation
- couleur du stylo
- diapositives du diaporama
- diaporama personnalisé
- avancer les diapositives
- manuellement
- avec minutages
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides pour Node.js via Java
description: "Gérer les paramètres du diaporama dans les présentations PowerPoint à l'aide de JavaScript"
---

Dans Microsoft PowerPoint, les paramètres du **Diaporama** sont un outil essentiel pour préparer et présenter des présentations professionnelles. L’une des fonctionnalités les plus importantes de cette section est **Set Up Show**, qui vous permet d’adapter votre présentation à des conditions et à des publics spécifiques, assurant ainsi flexibilité et commodité. Avec cette fonctionnalité, vous pouvez sélectionner le type de diaporama (par exemple, présenté par un intervenant, parcouru par un individu ou parcouru en kiosque), activer ou désactiver la boucle, choisir des diapositives spécifiques à afficher et utiliser les minutages. Cette étape de préparation est cruciale pour rendre votre présentation plus efficace et professionnelle.

`getSlideShowSettings` est une méthode de la classe [Présentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) qui renvoie un objet de type [SlideShowSettings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowsettings/), vous permettant de gérer les paramètres du diaporama dans une présentation PowerPoint. Dans cet article, nous explorerons comment utiliser cette méthode pour configurer et contrôler divers aspects des paramètres du diaporama. 

## **Sélectionner le type de diaporama**

`SlideShowSettings.setSlideShowType` définit le type de diaporama, qui peut être une instance des classes suivantes : [PresentedBySpeaker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedatkiosk/). L’utilisation de cette méthode vous permet d’adapter la présentation à différents scénarios d’utilisation, tels que les kiosques automatisés ou les présentations manuelles.

L’exemple de code ci‑dessous crée une nouvelle présentation et définit le type de diaporama sur « Parcouru par un individu » sans afficher la barre de défilement.
```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Activer les options du diaporama**

`SlideShowSettings.setLoop` détermine si le diaporama doit se répéter en boucle jusqu’à être arrêté manuellement. Cela est utile pour les présentations automatisées qui doivent fonctionner en continu. `SlideShowSettings.setShowNarration` indique si les narrations vocales doivent être lues pendant le diaporama. C’est utile pour les présentations automatisées contenant des consignes audio pour le public. `SlideShowSettings.setShowAnimation` indique si les animations ajoutées aux objets de diapositives doivent être lues. Cela permet de fournir l’effet visuel complet de la présentation.

L’exemple de code suivant crée une nouvelle présentation et boucle le diaporama.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Sélectionner les diapositives à afficher**

La méthode `SlideShowSettings.setSlides` vous permet de choisir une plage de diapositives à afficher pendant la présentation. Cela est utile lorsque vous ne devez afficher qu’une partie de la présentation plutôt que toutes les diapositives. L’exemple de code suivant crée une nouvelle présentation et définit la plage de diapositives à afficher de la diapositive `2` à la diapositive `9`.
```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Utiliser les minutages des diapositives**

La méthode `SlideShowSettings.setUseTimings` permet d’activer ou de désactiver l’utilisation des minutages prédéfinis pour chaque diapositive. Cela est utile pour afficher automatiquement les diapositives avec des durées d’affichage pré‑définies. L’exemple de code ci‑dessous crée une nouvelle présentation et désactive l’utilisation des minutages.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Afficher les contrôles multimédia**

La méthode `SlideShowSettings.setShowMediaControls` détermine si les contrôles multimédia (tels que lecture, pause et arrêt) doivent être affichés pendant le diaporama lorsqu’un contenu multimédia (par exemple, vidéo ou audio) est lu. Cela est utile lorsque vous souhaitez donner à l’intervenant le contrôle de la lecture multimédia pendant la présentation.

L’exemple de code suivant crée une nouvelle présentation et active l’affichage des contrôles multimédia.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**Puis‑je enregistrer une présentation afin qu’elle s’ouvre directement en mode diaporama ?**

Oui. Enregistrez le fichier au format PPSX ou PPSM ; ces formats se lancent directement en diaporama lorsqu’ils sont ouverts dans PowerPoint. Dans Aspose.Slides, choisissez le format d’enregistrement correspondant [lors de l’exportation](/slides/fr/nodejs-java/save-presentation/).

**Puis‑je exclure des diapositives individuelles du diaporama sans les supprimer du fichier ?**

Oui. Marquez une diapositive comme [masquée](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/sethidden/). Les diapositives masquées restent dans la présentation mais ne sont pas affichées pendant le diaporama.

**Aspose.Slides peut‑il lire un diaporama ou contrôler une présentation en direct à l’écran ?**

Non. Aspose.Slides édite, analyse et convertit les fichiers de présentation ; la lecture réelle est assurée par une application de visualisation telle que PowerPoint.