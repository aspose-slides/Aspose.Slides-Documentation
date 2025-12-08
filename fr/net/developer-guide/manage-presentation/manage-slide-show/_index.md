---
title: Gérer le diaporama
type: docs
weight: 90
url: /fr/net/manage-slide-show/
keywords:
- type de diaporama
- présenté par un intervenant
- consulté par un individu
- consulté sur un kiosque
- options du diaporama
- boucle continue
- sans narration
- sans animation
- couleur du stylo
- afficher les diapositives
- diaporama personnalisé
- avancer les diapositives
- manuellement
- utilisation des minutages
- PowerPoint
- présentation
- C#
- .NET
- Aspose.Slides for .NET
description: "Gérer les paramètres du diaporama dans les présentations PowerPoint à l'aide de C#"
---

Dans Microsoft PowerPoint, les paramètres du **Diaporama** sont un outil clé pour préparer et présenter des présentations professionnelles. L'une des fonctionnalités les plus importantes de cette section est **Configurer le diaporama**, qui vous permet d'adapter votre présentation à des conditions et à un public spécifiques, garantissant flexibilité et commodité. Avec cette fonctionnalité, vous pouvez sélectionner le type de diaporama (par exemple, présenté par un intervenant, consulté par un individu ou consulté sur un kiosque), activer ou désactiver la boucle, choisir des diapositives spécifiques à afficher et utiliser les minutages. Cette étape de préparation est cruciale pour rendre votre présentation plus efficace et professionnelle.

`SlideShowSettings` est une propriété de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) de type [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), qui vous permet de gérer les paramètres du diaporama dans une présentation PowerPoint. Dans cet article, nous explorerons comment utiliser cette propriété pour configurer et contrôler divers aspects des paramètres du diaporama. 

## **Sélectionner le type de diaporama**

`SlideShowSettings.SlideShowType` définit le type de diaporama, qui peut être une instance des classes suivantes : [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). L'utilisation de cette propriété vous permet d'adapter la présentation à différents scénarios d'utilisation, tels que les kiosques automatisés ou les présentations manuelles.

Le code d'exemple ci-dessous crée une nouvelle présentation et définit le type de diaporama sur "Consulté par un individu" sans afficher la barre de défilement.
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Activer les options du diaporama**

`SlideShowSettings.Loop` détermine si le diaporama doit se répéter en boucle jusqu'à être arrêté manuellement. Cela est utile pour les présentations automatisées qui doivent fonctionner en continu. `SlideShowSettings.ShowNarration` indique si les narrations vocales doivent être lues pendant le diaporama. Cela est utile pour les présentations automatisées contenant des consignes vocales pour le public. `SlideShowSettings.ShowAnimation` indique si les animations ajoutées aux objets de la diapositive doivent être lues. Cela permet de fournir l'effet visuel complet de la présentation.

Le code d'exemple suivant crée une nouvelle présentation et boucle le diaporama.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Sélectionner les diapositives à afficher**

La propriété `SlideShowSettings.Slides` vous permet de sélectionner une plage de diapositives à afficher pendant la présentation. Cela est utile lorsque vous devez ne montrer qu'une partie de la présentation plutôt que toutes les diapositives. Le code d'exemple suivant crée une nouvelle présentation et définit la plage de diapositives à afficher de la diapositive `2` à la diapositive `9`.
```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Utiliser le minutage des diapositives**

La propriété `SlideShowSettings.UseTimings` vous permet d'activer ou de désactiver l'utilisation des minutages prédéfinis pour chaque diapositive. Cela est utile pour afficher automatiquement les diapositives avec des durées d'affichage prédéfinies. Le code d'exemple ci-dessous crée une nouvelle présentation et désactive l'utilisation des minutages.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Afficher les contrôles multimédia**

La propriété `SlideShowSettings.ShowMediaControls` détermine si les contrôles multimédia (comme lecture, pause et arrêt) doivent être affichés pendant le diaporama lorsqu'un contenu multimédia (par exemple, vidéo ou audio) est lu. Cela est utile lorsque vous souhaitez donner au présentateur le contrôle de la lecture des médias pendant la présentation.

Le code d'exemple suivant crée une nouvelle présentation et active l'affichage des contrôles multimédia.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Puis-je enregistrer une présentation afin qu'elle s'ouvre directement en mode diaporama ?**

Oui. Enregistrez le fichier au format PPSX ou PPSM; ces formats s'ouvrent directement en diaporama lorsqu'ils sont ouverts dans PowerPoint. Dans Aspose.Slides, choisissez le format d'enregistrement correspondant [during export](/slides/fr/net/save-presentation/).

**Puis-je exclure des diapositives individuelles du diaporama sans les supprimer du fichier ?**

Oui. Marquez une diapositive comme [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Les diapositives masquées restent dans la présentation mais ne sont pas affichées pendant le diaporama.

**Aspose.Slides peut-il lire un diaporama ou contrôler une présentation en direct à l'écran ?**

Non. Aspose.Slides modifie, analyse et convertit les fichiers de présentation; la lecture réelle est gérée par une application de visualisation telle que PowerPoint.