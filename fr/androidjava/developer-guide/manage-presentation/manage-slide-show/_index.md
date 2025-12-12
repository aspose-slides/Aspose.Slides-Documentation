---
title: Gérer le diaporama sur Android
linktitle: Diaporama
type: docs
weight: 90
url: /fr/androidjava/manage-slide-show/
keywords:
- type de diaporama
- présenté par l'orateur
- consulté par un individu
- consulté sur un kiosque
- options de diaporama
- boucle continue
- diaporama sans narration
- diaporama sans animation
- couleur du stylet
- afficher les diapositives
- diaporama personnalisé
- avancer les diapositives
- manuellement
- avec minutage
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à gérer les diaporamas avec Aspose.Slides pour Android via Java. Contrôlez les transitions de diapositives, les minutages et bien plus encore pour les formats PPT, PPTX et ODP en toute simplicité."
---

Dans Microsoft PowerPoint, les paramètres du **Diaporama** sont un outil clé pour préparer et présenter des présentations professionnelles. L'une des fonctionnalités les plus importantes de cette section est **Configurer le Diaporama**, qui vous permet d'adapter votre présentation à des conditions et à un public spécifiques, garantissant flexibilité et commodité. Avec cette fonctionnalité, vous pouvez sélectionner le type de diaporama (par ex. présenté par un intervenant, parcouru par un individu ou parcouru sur un kiosque), activer ou désactiver la boucle, choisir des diapositives spécifiques à afficher et utiliser les minutages. Cette étape de préparation est cruciale pour rendre votre présentation plus efficace et professionnelle.

`getSlideShowSettings` est une méthode de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) qui renvoie un objet de type [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/), ce qui vous permet de gérer les paramètres du diaporama dans une présentation PowerPoint. Dans cet article, nous explorerons comment utiliser cette méthode pour configurer et contrôler divers aspects des paramètres du diaporama. 

## **Sélectionner le type de diaporama**

`SlideShowSettings.setSlideShowType` définit le type de diaporama, qui peut être une instance des classes suivantes : [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). L'utilisation de cette méthode vous permet d'adapter la présentation à différents scénarios d'utilisation, tels que des kiosques automatisés ou des présentations manuelles.

L'exemple de code ci‑dessous crée une nouvelle présentation et définit le type de diaporama sur « Parcouru par un individu » sans afficher la barre de défilement.
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Activer les options du diaporama**

`SlideShowSettings.setLoop` détermine si le diaporama doit se répéter en boucle jusqu'à être arrêté manuellement. Cela est utile pour les présentations automatisées qui doivent fonctionner en continu. `SlideShowSettings.setShowNarration` détermine si les narrations vocales doivent être lues pendant le diaporama. C’est utile pour les présentations automatisées qui contiennent des instructions vocales pour le public. `SlideShowSettings.setShowAnimation` détermine si les animations ajoutées aux objets de la diapositive doivent être jouées. Cela est utile pour fournir l'effet visuel complet de la présentation.

L'exemple de code suivant crée une nouvelle présentation et boucle le diaporama.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Sélectionner les diapositives à afficher**

`SlideShowSettings.setSlides` vous permet de sélectionner une plage de diapositives à afficher pendant la présentation. Cela est utile lorsque vous devez n'afficher qu'une partie de la présentation plutôt que toutes les diapositives. L'exemple de code suivant crée une nouvelle présentation et définit la plage de diapositives à afficher de la diapositive `2` à la diapositive `9`.
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Utiliser les minutages**

`SlideShowSettings.setUseTimings` permet d'activer ou de désactiver l'utilisation de minutages prédéfinis pour chaque diapositive. Cela est utile pour afficher automatiquement les diapositives avec des durées d'affichage pré‑définies. L'exemple de code ci‑dessous crée une nouvelle présentation et désactive l'utilisation des minutages.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Afficher les contrôles multimédias**

`SlideShowSettings.setShowMediaControls` détermine si les contrôles multimédias (tels que lecture, pause et arrêt) doivent être affichés pendant le diaporama lorsqu'un contenu multimédia (par ex. vidéo ou audio) est lu. Cela est utile lorsque vous souhaitez donner au présentateur le contrôle de la lecture multimédia pendant la présentation.

L'exemple de code suivant crée une nouvelle présentation et active l'affichage des contrôles multimédias.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**Puis-je enregistrer une présentation de façon qu'elle s'ouvre directement en mode diaporama ?**

Oui. Enregistrez le fichier au format PPSX ou PPSM ; ces formats s'ouvrent directement en mode diaporama lorsqu'ils sont ouverts dans PowerPoint. Dans Aspose.Slides, choisissez le format d’enregistrement correspondant [lors de l'export](/slides/fr/androidjava/save-presentation/).

**Puis-je exclure des diapositives individuelles du diaporama sans les supprimer du fichier ?**

Oui. Marquez une diapositive comme [masquée](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Les diapositives masquées restent dans la présentation mais ne sont pas affichées pendant le diaporama.

**Aspose.Slides peut-il lire un diaporama ou contrôler une présentation en direct à l'écran ?**

Non. Aspose.Slides modifie, analyse et convertit les fichiers de présentation ; la lecture réelle est gérée par une application de visualisation telle que PowerPoint.