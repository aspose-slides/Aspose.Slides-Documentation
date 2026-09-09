---
title: Gérer les diaporamas en Python via Java
linktitle: Diaporama
type: docs
weight: 90
url: /fr/python-java/manage-slide-show/
keywords:
- type de diaporama
- présenté par l’orateur
- parcouru par un individu
- parcouru en kiosque
- options de diaporama
- boucle continue
- diaporama sans narration
- diaporama sans animation
- couleur du stylo
- afficher les diapositives
- diaporama personnalisé
- avancer les diapositives
- manuellement
- avec temporisations
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à gérer les diaporamas dans Aspose.Slides pour Python via Java. Contrôlez les transitions de diapositives, les temporisations et plus encore pour les formats PPT, PPTX et ODP avec facilité."
---
## **Introduction**

Les options **Set Up Show** de Microsoft PowerPoint vous permettent de choisir le type de diaporama, d’activer la boucle, de sélectionner les diapositives et de contrôler la façon dont les diapositives avancent. Avec Aspose.Slides for Python via Java, vous pouvez configurer ces options de manière programmatique et les enregistrer dans un fichier de présentation.

La méthode [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlideShowSettings) renvoie un objet [SlideShowSettings](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowsettings/) qui contrôle ces options. Les exemples ci‑dessous nécessitent Aspose.Slides for Python via Java et un environnement d’exécution Java compatible. Chaque exemple démarre la JVM si nécessaire et libère la présentation à la fin.

## **Select Show Type**

La méthode [SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowsettings/#setSlideShowType) définit le type de diaporama, qui peut être une instance des classes suivantes : [PresentedBySpeaker](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/fr/python-java/aspose.slides/browsedbyindividual/) ou [BrowsedAtKiosk](https://reference.aspose.com/slides/fr/python-java/aspose.slides/browsedatkiosk/). L’utilisation de cette méthode vous permet d’adapter la présentation à différents scénarios d’utilisation, tels que les kiosques automatisés ou les présentations manuelles.

L’exemple de code ci‑dessous crée une nouvelle présentation et définit le type d’affichage sur « Browsed by an individual » sans afficher la barre de défilement.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Enable Show Options**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowsettings/#setLoop) détermine si le diaporama doit se répéter en boucle jusqu’à ce qu’il soit arrêté manuellement. Cela est utile pour les présentations automatisées qui doivent fonctionner en continu. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowsettings/#setShowNarration) détermine si les narrations vocales doivent être lues pendant le diaporama. C’est pratique pour les présentations automatisées contenant des consignes audio pour le public. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowsettings/#setShowAnimation) détermine si les animations ajoutées aux objets des diapositives doivent être jouées. Cela permet de rendre l’effet visuel complet de la présentation.

L’exemple de code suivant crée une nouvelle présentation et boucle le diaporama.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Select Slides to Show**

La méthode [SlideShowSettings.setSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowsettings/#setSlides) vous permet de sélectionner un intervalle de diapositives à afficher pendant la présentation. Ceci est utile lorsque vous devez ne montrer qu’une partie de la présentation plutôt que toutes les diapositives. L’exemple de code suivant crée une présentation contenant neuf diapositives et sélectionne les diapositives 2 à 9. L’intervalle utilise des numéros de diapositives à base 1.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Créer neuf diapositives afin que la plage sélectionnée existe.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Control Slide Advancement**

La méthode [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowsettings/#setUseTimings) permet d’activer ou de désactiver l’utilisation des temporisations prédéfinies pour chaque diapositive. Cela est utile pour afficher automatiquement les diapositives avec des durées d’affichage prédéfinies. L’exemple de code ci‑dessous crée une nouvelle présentation et désactive l’utilisation des temporisations.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Show Media Controls**

La méthode [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) détermine si les contrôles multimédias (lecture, pause, arrêt, etc.) doivent être affichés pendant le diaporama lorsqu’un contenu multimédia (vidéo ou audio) est lu. Cela est utile lorsque vous souhaitez donner au présentateur le contrôle de la lecture des médias pendant la présentation.

L’exemple de code suivant crée une nouvelle présentation et active l’affichage des contrôles multimédias.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I save a presentation so it opens directly in slide show mode?**

Oui. Enregistrez le fichier au format PPSX ou PPSM ; ces formats s’ouvrent directement en mode diaporama lorsqu’ils sont ouverts dans PowerPoint. Dans Aspose.Slides, choisissez le format d’enregistrement correspondant [during export](/slides/fr/python-java/save-presentation/).

**Can I exclude individual slides from the show without deleting them from the file?**

Oui. Marquez une diapositive comme [hidden](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#setHidden). Les diapositives masquées restent dans la présentation mais ne sont pas affichées pendant le diaporama.

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

Non. Aspose.Slides édite, analyse et convertit les fichiers de présentation ; la lecture réelle est assurée par une application de visualisation telle que PowerPoint.