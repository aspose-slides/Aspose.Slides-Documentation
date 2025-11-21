---
title: Gérer le diaporama dans .NET
linktitle: Diaporama
type: docs
weight: 90
url: /fr/net/manage-slide-show/
keywords:
- type de diaporama
- présenté par un intervenant
- parcouru par un individu
- parcouru sur un kiosque
- options du diaporama
- boucle continue
- diaporama sans narration
- diaporama sans animation
- couleur du stylo
- afficher les diapositives
- diaporama personnalisé
- avancer les diapositives
- manuellement
- utilisation des minutages
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à gérer les diaporamas dans Aspose.Slides pour .NET. Contrôlez les transitions des diapositives, les minutages et plus encore pour les formats PPT, PPTX et ODP avec facilité."
---

Dans Microsoft PowerPoint, les paramètres **Slide Show** sont un outil essentiel pour préparer et diffuser des présentations professionnelles. L’une des fonctionnalités les plus importantes de cette section est **Set Up Show**, qui vous permet d’adapter votre présentation à des conditions et à des publics spécifiques, garantissant flexibilité et commodité. Avec cette fonctionnalité, vous pouvez sélectionner le type de présentation (par exemple, présenté par un intervenant, parcouru par un individu ou parcouru sur un kiosque), activer ou désactiver la boucle, choisir des diapositives spécifiques à afficher et utiliser les minutages. Cette étape de préparation est cruciale pour rendre votre présentation plus efficace et professionnelle.

`SlideShowSettings` est une propriété de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) de type [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), qui vous permet de gérer les paramètres du diaporama dans une présentation PowerPoint. Dans cet article, nous explorerons comment utiliser cette propriété pour configurer et contrôler divers aspects des paramètres du diaporama. 

## **Select Show Type**

`SlideShowSettings.SlideShowType` définit le type de diaporama, qui peut être une instance des classes suivantes : [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). L’utilisation de cette propriété vous permet d’adapter la présentation à différents scénarios d’utilisation, tels que les kiosques automatisés ou les présentations manuelles.

L’exemple de code ci‑dessous crée une nouvelle présentation et définit le type de présentation sur « Browsed by an individual » sans afficher la barre de défilement.
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Enable Show Options**

`SlideShowSettings.Loop` détermine si le diaporama doit se répéter en boucle jusqu’à être arrêté manuellement. Cela est utile pour les présentations automatisées qui doivent fonctionner en continu. `SlideShowSettings.ShowNarration` indique si les narrations vocales doivent être lues pendant le diaporama. Cela est utile pour les présentations automatisées qui contiennent des instructions vocales pour le public. `SlideShowSettings.ShowAnimation` indique si les animations ajoutées aux objets des diapositives doivent être lues. Cela permet de fournir l’effet visuel complet de la présentation.

L’exemple de code suivant crée une nouvelle présentation et boucle le diaporama.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Select Slides to Show**

La propriété `SlideShowSettings.Slides` vous permet de sélectionner une plage de diapositives à afficher pendant la présentation. Cela est utile lorsque vous devez ne montrer qu’une partie de la présentation plutôt que toutes les diapositives. L’exemple de code suivant crée une nouvelle présentation et définit la plage de diapositives à afficher de la diapositive `2` à la diapositive `9`.
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


## **Use Advance Slides**

La propriété `SlideShowSettings.UseTimings` vous permet d’activer ou de désactiver l’utilisation des minutages prédéfinis pour chaque diapositive. Cela est utile pour faire défiler automatiquement les diapositives avec des durées d’affichage pré‑définies. L’exemple de code ci‑dessous crée une nouvelle présentation et désactive l’utilisation des minutages.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Show Media Controls**

La propriété `SlideShowSettings.ShowMediaControls` détermine si les contrôles multimédia (tels que lecture, pause et arrêt) doivent être affichés pendant le diaporama lorsqu’un contenu multimédia (par ex. vidéo ou audio) est lu. Cela est utile lorsque vous souhaitez donner au présentateur le contrôle de la lecture multimédia pendant la présentation.

L’exemple de code suivant crée une nouvelle présentation et active l’affichage des contrôles multimédia.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Puis‑je enregistrer une présentation afin qu’elle s’ouvre directement en mode diaporama ?**

Oui. Enregistrez le fichier au format PPSX ou PPSM ; ces formats se lancent directement en mode diaporama lorsqu’ils sont ouverts dans PowerPoint. Dans Aspose.Slides, choisissez le format d’enregistrement correspondant [pendant l’export](/slides/fr/net/save-presentation/).

**Puis‑je exclure des diapositives individuelles du diaporama sans les supprimer du fichier ?**

Oui. Marquez une diapositive comme [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Les diapositives masquées restent dans la présentation mais ne sont pas affichées pendant le diaporama.

**Aspose.Slides peut‑il lire un diaporama ou contrôler une présentation en direct à l’écran ?**

Non. Aspose.Slides modifie, analyse et convertit les fichiers de présentation ; la lecture réelle est gérée par une application de visualisation telle que PowerPoint.