---
title: Gérer le diaporama en Python
linktitle: Diaporama
type: docs
weight: 90
url: /fr/python-net/manage-slide-show/
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
- afficher les diapositives
- diaporama personnalisé
- avancer les diapositives
- manuellement
- avec minutage
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à gérer les diaporamas avec Aspose.Slides pour Python via .NET. Contrôlez les transitions de diapositives, les minutages et bien plus encore pour les formats PPT, PPTX et ODP en toute simplicité."
---

Dans Microsoft PowerPoint, les paramètres de **diaporama** sont un outil clé pour préparer et présenter des présentations professionnelles. L’une des fonctionnalités les plus importantes de cette section est **Configurer le diaporama**, qui vous permet d’adapter votre présentation à des conditions et à des publics spécifiques, assurant flexibilité et commodité. Avec cette fonctionnalité, vous pouvez sélectionner le type de diaporama (par exemple présenté par un intervenant, parcouru par un individu ou parcouru en kiosque), activer ou désactiver la boucle, choisir des diapositives spécifiques à afficher, et utiliser les minutages. Cette étape de préparation est cruciale pour rendre votre présentation plus efficace et professionnelle.

`slide_show_settings` est une propriété de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), de type [SlideShowSettings](https://reference.aspose.com/slides/python-net/aspose.slides/slideshowsettings/), qui vous permet de gérer les paramètres du diaporama dans une présentation PowerPoint. Dans cet article, nous explorerons comment utiliser cette propriété pour configurer et contrôler divers aspects des paramètres du diaporama. 

## **Sélectionner le type de diaporama**

`SlideShowSettings.slide_show_type` définit le type de diaporama, qui peut être une instance des classes suivantes : [PresentedBySpeaker](https://reference.aspose.com/slides/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/python-net/aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/python-net/aspose.slides/browsedatkiosk/). Utiliser cette propriété vous permet d’adapter la présentation à différents scénarios d’utilisation, tels que les kiosques automatisés ou les présentations manuelles.

L’exemple de code ci‑dessous crée une nouvelle présentation et définit le type de diaporama sur « Parcouru par un individu » sans afficher la barre de défilement.
```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Activer les options du diaporama**

`SlideShowSettings.loop` détermine si le diaporama doit se répéter en boucle jusqu’à être arrêté manuellement. Cela est utile pour les présentations automatisées qui doivent fonctionner en continu. `SlideShowSettings.show_narration` détermine si les narrations vocales doivent être lues pendant le diaporama. Cela est utile pour les présentations automatisées contenant des instructions vocales pour le public. `SlideShowSettings.show_animation` détermine si les animations ajoutées aux objets de diapositive doivent être jouées. Cela est utile pour fournir l’effet visuel complet de la présentation.

Le code suivant crée une nouvelle présentation et boucle le diaporama.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Sélectionner les diapositives à afficher**

`SlideShowSettings.slides` permet de sélectionner une plage de diapositives à afficher pendant la présentation. Cela est utile lorsque vous devez ne montrer qu’une partie de la présentation plutôt que toutes les diapositives. L’exemple de code suivant crée une nouvelle présentation et définit la plage de diapositives à afficher de `2` à `9`.
```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Utiliser l’avance des diapositives**

`SlideShowSettings.use_timings` permet d’activer ou de désactiver l’utilisation de minutages prédéfinis pour chaque diapositive. Cela est utile pour afficher automatiquement les diapositives avec des durées d’affichage pré‑définies. L’exemple de code ci‑dessous crée une nouvelle présentation et désactive l’utilisation des minutages.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Afficher les contrôles multimédia**

`SlideShowSettings.show_media_controls` détermine si les contrôles multimédia (tels que lecture, pause et arrêt) doivent être affichés pendant le diaporama lorsque du contenu multimédia (par exemple vidéo ou audio) est lu. Cela est utile lorsque vous souhaitez donner au présentateur le contrôle de la lecture des médias pendant la présentation.

Le code suivant crée une nouvelle présentation et active l’affichage des contrôles multimédia.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis-je enregistrer une présentation pour qu’elle s’ouvre directement en mode diaporama ?**

Oui. Enregistrez le fichier au format PPSX ou PPSM ; ces formats s’ouvrent directement en diaporama lorsqu’ils sont ouverts dans PowerPoint. Dans Aspose.Slides, choisissez le format d’enregistrement correspondant [lors de l’export](/slides/fr/python-net/save-presentation/).

**Puis-je exclure des diapositives individuelles du diaporama sans les supprimer du fichier ?**

Oui. Marquez une diapositive comme [cachée](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/). Les diapositives cachées restent dans la présentation mais ne sont pas affichées pendant le diaporama.

**Aspose.Slides peut‑il lire un diaporama ou contrôler une présentation en direct à l’écran ?**

Non. Aspose.Slides édite, analyse et convertit les fichiers de présentation ; la lecture réelle est prise en charge par une application de visualisation telle que PowerPoint.