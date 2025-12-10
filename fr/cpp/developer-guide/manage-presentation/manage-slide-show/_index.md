---
title: Gérer le diaporama en C++
linktitle: Diaporama
type: docs
weight: 90
url: /fr/cpp/manage-slide-show/
keywords:
- type de diaporama
- présenté par un orateur
- consulté par un individu
- consulté sur kiosque
- options de diaporama
- boucle continue
- diaporama sans narration
- diaporama sans animation
- couleur du stylo
- diapositives du diaporama
- diaporama personnalisé
- avancer les diapositives
- manuellement
- utiliser les minutages
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à gérer les diaporamas dans Aspose.Slides pour C++. Contrôlez les transitions de diapositives, les minutages et bien plus encore pour les formats PPT, PPTX et ODP avec facilité."
---

Dans Microsoft PowerPoint, les paramètres du **Diaporama** sont un outil essentiel pour préparer et présenter des présentations professionnelles. L’une des fonctionnalités les plus importantes de cette section est **Configurer le diaporama**, qui vous permet d’adapter votre présentation à des conditions et à des publics spécifiques, assurant flexibilité et commodité. Avec cette fonctionnalité, vous pouvez sélectionner le type de diaporama (par exemple, présenté par un orateur, consulté par un individu ou consulté sur un kiosque), activer ou désactiver la boucle, choisir des diapositives spécifiques à afficher et utiliser les minutages. Cette étape de préparation est cruciale pour rendre votre présentation plus efficace et professionnelle.

`get_SlideShowSettings` est une méthode de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) qui renvoie un objet de type [SlideShowSettings](https://reference.aspose.com/slides/cpp/aspose.slides/slideshowsettings/), permettant de gérer les paramètres du diaporama dans une présentation PowerPoint. Dans cet article, nous explorerons comment utiliser cette méthode pour configurer et contrôler divers aspects des paramètres du diaporama. 

## **Sélectionner le type de diaporama**

`SlideShowSettings.set_SlideShowType` définit le type de diaporama, qui peut être une instance des classes suivantes : [PresentedBySpeaker](https://reference.aspose.com/slides/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cpp/aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/cpp/aspose.slides/browsedatkiosk/). L’utilisation de cette méthode vous permet d’adapter la présentation à différents scénarios d’utilisation, tels que les kiosques automatisés ou les présentations manuelles.

L’exemple de code ci‑dessous crée une nouvelle présentation et définit le type de diaporama sur « Consulté par un individu » sans afficher la barre de défilement.
```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Activer les options du diaporama**

`SlideShowSettings.set_Loop` détermine si le diaporama doit se répéter en boucle jusqu’à être arrêté manuellement. Cela est utile pour les présentations automatisées qui doivent fonctionner en continu. `SlideShowSettings.set_ShowNarration` indique si les narrations vocales doivent être lues pendant le diaporama. C’est utile pour les présentations automatisées contenant des instructions vocales pour le public. `SlideShowSettings.set_ShowAnimation` indique si les animations ajoutées aux objets de diapositive doivent être jouées. Cela permet de fournir l’effet visuel complet de la présentation.

L’exemple de code suivant crée une nouvelle présentation et boucle le diaporama.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Sélectionner les diapositives à afficher**

La méthode `SlideShowSettings.set_Slides` vous permet de sélectionner une plage de diapositives à afficher pendant la présentation. Ceci est utile lorsque vous devez ne montrer qu’une partie de la présentation plutôt que toutes les diapositives. L’exemple de code suivant crée une nouvelle présentation et définit la plage de diapositives à afficher de la diapositive `2` à la diapositive `9`.
```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Utiliser le minutage des diapositives**

La méthode `SlideShowSettings.set_UseTimings` vous permet d’activer ou de désactiver l’utilisation de minutages prédéfinis pour chaque diapositive. Cela est utile pour afficher automatiquement les diapositives avec des durées d’affichage pré‑définies. L’exemple de code ci‑dessous crée une nouvelle présentation et désactive l’utilisation des minutages.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Afficher les contrôles multimédia**

`SlideShowSettings.set_ShowMediaControls` détermine si les contrôles multimédia (lecture, pause, arrêt, etc.) doivent être affichés pendant le diaporama lorsqu’un contenu multimédia (vidéo ou audio) est lu. Cela est utile lorsque vous souhaitez donner à l’orateur le contrôle de la lecture des médias pendant la présentation.

L’exemple de code suivant crée une nouvelle présentation et active l’affichage des contrôles multimédia.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**Puis‑je enregistrer une présentation de façon à ce qu’elle s’ouvre directement en mode diaporama ?**

Oui. Enregistrez le fichier au format PPSX ou PPSM ; ces formats s’ouvrent directement en mode diaporama dans PowerPoint. Dans Aspose.Slides, choisissez le format d’enregistrement correspondant **[lors de l’exportation](/slides/fr/cpp/save-presentation/)**.

**Puis‑je exclure des diapositives individuelles du diaporama sans les supprimer du fichier ?**

Oui. Marquez une diapositive comme [hidden](https://reference.aspose.com/slides/cpp/aspose.slides/slide/set_hidden/). Les diapositives masquées restent dans la présentation mais ne sont pas affichées pendant le diaporama.

**Aspose.Slides peut‑il jouer un diaporama ou contrôler une présentation en direct à l’écran ?**

Non. Aspose.Slides édite, analyse et convertit les fichiers de présentation ; la lecture réelle est assurée par une application de visualisation telle que PowerPoint.