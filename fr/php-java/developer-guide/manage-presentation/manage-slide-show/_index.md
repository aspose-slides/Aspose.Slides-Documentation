---
title: Gérer le diaporama en PHP
linktitle: Diaporama
type: docs
weight: 90
url: /fr/php-java/manage-slide-show/
keywords:
- type de diaporama
- présenté par un intervenant
- consulté par un individu
- consulté sur un kiosque
- options du diaporama
- boucle continue
- diaporama sans narration
- diaporama sans animation
- couleur du stylo
- afficher les diapositives
- diaporama personnalisé
- avancement des diapositives
- manuellement
- en utilisant les minutages
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à gérer les diaporamas dans Aspose.Slides pour PHP via Java. Contrôlez les transitions de diapositives, les minutages et plus encore, pour les formats PPT, PPTX et ODP avec facilité."
---

Dans Microsoft PowerPoint, les paramètres du **Diaporama** sont un outil essentiel pour préparer et diffuser des présentations professionnelles. L’une des fonctions les plus importantes de cette section est **Configurer le diaporama**, qui vous permet d’adapter votre présentation à des conditions et à un public spécifiques, assurant flexibilité et commodité. Avec cette fonction, vous pouvez sélectionner le type de diaporama (par exemple présenté par un intervenant, consulté par un individu ou consulté sur un kiosque), activer ou désactiver la boucle, choisir des diapositives spécifiques à afficher et utiliser les minutages. Cette étape de préparation est cruciale pour rendre votre présentation plus efficace et professionnelle.

`getSlideShowSettings` est une méthode de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) qui renvoie un objet du type [SlideShowSettings](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowsettings/), ce qui vous permet de gérer les paramètres du diaporama dans une présentation PowerPoint. Dans cet article, nous explorerons comment utiliser cette méthode pour configurer et contrôler divers aspects des paramètres du diaporama. 

## **Sélectionner le type de diaporama**

`SlideShowSettings->setSlideShowType` définit le type de diaporama, qui peut être une instance des classes suivantes : [PresentedBySpeaker](https://reference.aspose.com/slides/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/php-java/aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/php-java/aspose.slides/browsedatkiosk/). L’utilisation de cette méthode vous permet d’adapter la présentation à différents scénarios d’utilisation, tels que des kiosques automatisés ou des présentations manuelles.

Le exemple de code ci-dessous crée une nouvelle présentation et définit le type de diaporama sur « Consulté par un individu » sans afficher la barre de défilement.
```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Activer les options du diaporama**

`SlideShowSettings->setLoop` détermine si le diaporama doit se répéter en boucle jusqu’à être arrêté manuellement. Cela est utile pour les présentations automatisées qui doivent fonctionner en continu. `SlideShowSettings->setShowNarration` détermine si les narrations vocales doivent être lues pendant le diaporama. Cela est utile pour les présentations automatisées contenant des consignes vocales pour le public. `SlideShowSettings->setShowAnimation` détermine si les animations ajoutées aux objets de diapositive doivent être lues. Cela est utile pour fournir l’effet visuel complet de la présentation.

L’exemple de code suivant crée une nouvelle présentation et répète le diaporama en boucle.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Sélectionner les diapositives à afficher**

La méthode `SlideShowSettings->setSlides` vous permet de sélectionner une plage de diapositives à afficher pendant la présentation. Cela est utile lorsque vous devez ne montrer qu’une partie de la présentation plutôt que toutes les diapositives. L’exemple de code suivant crée une nouvelle présentation et définit la plage de diapositives à afficher de `2` à `9`.
```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Utiliser l’avancement des diapositives**

La méthode `SlideShowSettings->setUseTimings` vous permet d’activer ou de désactiver l’utilisation de minutages prédéfinis pour chaque diapositive. Cela est utile pour afficher automatiquement les diapositives avec des durées d’affichage pré‑définies. L’exemple de code ci‑dessous crée une nouvelle présentation et désactive l’utilisation des minutages.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Afficher les contrôles multimédia**

La méthode `SlideShowSettings->setShowMediaControls` détermine si les contrôles multimédia (tels que lecture, pause et arrêt) doivent être affichés pendant le diaporama lorsque du contenu multimédia (par exemple une vidéo ou un audio) est lu. Cela est utile lorsque vous souhaitez offrir à l’intervenant le contrôle de la lecture multimédia pendant la présentation.

L’exemple de code suivant crée une nouvelle présentation et active l’affichage des contrôles multimédia.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **FAQ**

**Puis-je enregistrer une présentation pour qu’elle s’ouvre directement en mode diaporama ?**

Oui. Enregistrez le fichier au format PPSX ou PPSM ; ces formats s’ouvrent directement en diaporama lorsqu’ils sont ouverts dans PowerPoint. Dans Aspose.Slides, choisissez le format d’enregistrement correspondant [lors de l'exportation](/slides/fr/php-java/save-presentation/).

**Puis-je exclure des diapositives individuelles du diaporama sans les supprimer du fichier ?**

Oui. Marquez une diapositive comme [masquée](https://reference.aspose.com/slides/php-java/aspose.slides/slide/sethidden/). Les diapositives masquées restent dans la présentation mais ne sont pas affichées pendant le diaporama.

**Aspose.Slides peut‑il lire un diaporama ou contrôler une présentation en direct à l’écran ?**

Non. Aspose.Slides modifie, analyse et convertit les fichiers de présentation ; la lecture réelle est gérée par une application de visualisation comme PowerPoint.