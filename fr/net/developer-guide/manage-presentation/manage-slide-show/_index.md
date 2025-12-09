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
- options de diaporama
- boucle continue
- diaporama sans narration
- diaporama sans animation
- couleur du stylo
- afficher les diapositives
- diaporama personnalisé
- avancer les diapositives
- manuellement
- avec minuteries
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à gérer les diaporamas dans Aspose.Slides pour .NET. Contrôlez les transitions de diapositives, les minuteries et plus encore pour les formats PPT, PPTX et ODP en toute simplicité."
---

Dans Microsoft PowerPoint, les paramètres du **Diaporama** sont un outil clé pour préparer et présenter des présentations professionnelles. L’une des fonctionnalités les plus importantes de cette section est **Configurer le diaporama**, qui vous permet d’adapter votre présentation à des conditions et à des publics spécifiques, assurant flexibilité et commodité. Avec cette fonctionnalité, vous pouvez sélectionner le type de diaporama (par exemple, présenté par un intervenant, parcouru par un individu ou parcouru sur un kiosque), activer ou désactiver la boucle, choisir des diapositives spécifiques à afficher et utiliser les minuteries. Cette étape de préparation est cruciale pour rendre votre présentation plus efficace et professionnelle.

`SlideShowSettings` est une propriété de la classe [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) , de type [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/) , qui vous permet de gérer les paramètres du diaporama dans une présentation PowerPoint. Dans cet article, nous explorerons comment utiliser cette propriété pour configurer et contrôler divers aspects des paramètres du diaporama. 

## **Sélectionner le type de diaporama**

`SlideShowSettings.SlideShowType` définit le type de diaporama, qui peut être une instance des classes suivantes : [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/) , [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/) , ou [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/) . Utiliser cette propriété vous permet d’adapter la présentation à différents scénarios d’utilisation, tels que les kiosques automatisés ou les présentations manuelles.

Le code d’exemple ci‑dessous crée une nouvelle présentation et définit le type de diaporama sur « Parcouru par un individu » sans afficher la barre de défilement.
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

`SlideShowSettings.Loop` détermine si le diaporama doit se répéter en boucle jusqu’à ce qu’il soit arrêté manuellement. Cela est utile pour les présentations automatisées qui doivent fonctionner en continu. `SlideShowSettings.ShowNarration` détermine si les narrations vocales doivent être jouées pendant le diaporama. Cela est utile pour les présentations automatisées contenant des instructions vocales pour le public. `SlideShowSettings.ShowAnimation` détermine si les animations ajoutées aux objets de la diapositive doivent être lues. Cela est utile pour fournir l’effet visuel complet de la présentation.

L’exemple de code suivant crée une nouvelle présentation et boucle le diaporama.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Sélectionner les diapositives à afficher**

`SlideShowSettings.Slides` permet de sélectionner une plage de diapositives à afficher pendant la présentation. Cela est utile lorsque vous devez ne montrer qu’une partie de la présentation plutôt que toutes les diapositives. L’exemple de code suivant crée une nouvelle présentation et définit la plage de diapositives à afficher des diapositives `2` à `9`.
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


## **Utiliser les minuteries**

`SlideShowSettings.UseTimings` permet d’activer ou de désactiver l’utilisation des minuteries prédéfinies pour chaque diapositive. Cela est utile pour afficher automatiquement les diapositives avec des durées d’affichage pré‑définies. L’exemple de code ci‑dessous crée une nouvelle présentation et désactive l’utilisation des minuteries.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Afficher les contrôles multimédias**

`SlideShowSettings.ShowMediaControls` détermine si les contrôles multimédias (tels que lecture, pause et arrêt) doivent être affichés pendant le diaporama lorsqu’un contenu multimédia (par ex., vidéo ou audio) est lu. Cela est utile lorsque vous souhaitez donner au présentateur le contrôle de la lecture des médias pendant la présentation.

L’exemple de code suivant crée une nouvelle présentation et active l’affichage des contrôles multimédias.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Puis-je enregistrer une présentation afin qu’elle s’ouvre directement en mode diaporama ?**

Oui. Enregistrez le fichier au format PPSX ou PPSM ; ces formats se lancent directement en diaporama lorsqu’ils sont ouverts dans PowerPoint. Dans Aspose.Slides, choisissez le format d’enregistrement correspondant [lors de l’export](/slides/fr/net/save-presentation/).

**Puis-je exclure des diapositives individuelles du diaporama sans les supprimer du fichier ?**

Oui. Marquez une diapositive comme [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) . Les diapositives masquées restent dans la présentation mais ne sont pas affichées pendant le diaporama.

**Aspose.Slides peut‑il lire un diaporama ou contrôler une présentation en direct à l’écran ?**

Non. Aspose.Slides édite, analyse et convertit les fichiers de présentation ; la lecture réelle est assurée par une application de visualisation telle que PowerPoint.