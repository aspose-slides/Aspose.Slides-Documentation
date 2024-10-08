---
title: Cadre Audio
type: docs
weight: 10
url: /fr/python-net/audio-frame/
keywords: "Ajouter de l'audio, Cadre audio, Propriétés audio, Extraire de l'audio, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter de l'audio à une présentation PowerPoint en Python"
---

## **Création d'un Cadre Audio**
Aspose.Slides pour Python via .NET vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés dans les diapositives sous forme de cadres audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive par son index.
3. Chargez le flux du fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) et `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/).
6. Enregistrez la présentation modifiée.

Ce code Python vous montre comment ajouter un cadre audio intégré à une diapositive :

```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier de présentation
with slides.Presentation() as pres:
    # Obtient la première diapositive
    sld = pres.slides[0]

    # Charge le fichier son wav dans le flux
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Ajoute le cadre audio
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Définit le mode de lecture et le volume de l'audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Écrit le fichier PowerPoint sur le disque
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Changer la Vignette du Cadre Audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît comme un cadre avec une image par défaut standard (voir l'image dans la section ci-dessous). Vous pouvez changer la vignette du cadre audio (définissez votre image préférée).

Ce code Python vous montre comment changer la vignette ou l'image d'aperçu d'un cadre audio :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajoute un cadre audio à la diapositive avec une position et une taille spécifiées.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Ajoute une image aux ressources de présentation.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Définit l'image pour le cadre audio.
        audioFrame.picture_format.picture.image = audioImage
        
        # Enregistre la présentation modifiée sur le disque
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Changer les Options de Lecture Audio**

Aspose.Slides pour Python via .NET vous permet de changer les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, définir l'audio pour qu'il se joue en boucle, ou même cacher l'icône audio.

Le **Panneau d'Options Audio** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Les options audio de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) d'Aspose.Slides :
- La liste déroulante **Démarrer** des options audio correspond à la propriété [AudioFrame.PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)
- Les options audio **Volume** correspondent à la propriété [AudioFrame.Volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Les options audio **Jouer à travers les diapositives** correspondent à la propriété [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Les options audio **Boucler jusqu'à l'arrêt** correspondent à la propriété [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Les options audio **Masquer pendant le Diaporama** correspondent à la propriété [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)
- Les options audio **Rembobiner après la lecture** correspondent à la propriété [AudioFrame.RewindAudio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 

Voici comment vous changez les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenir le Cadre Audio.
2. Définissez de nouvelles valeurs pour les propriétés du Cadre Audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code Python illustre une opération dans laquelle les options d'un audio sont ajustées :

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Obtient la forme AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Définit le mode de lecture sur lecture au clic
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Définit le volume sur Bas
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Définit l'audio pour jouer à travers les diapositives
    audioFrame.play_across_slides = True

    # Désactive la boucle pour l'audio
    audioFrame.play_loop_mode = False

    # Masque le Cadre Audio pendant le diaporama
    audioFrame.hide_at_showing = True

    # Rembobine l'audio au début après la lecture
    audioFrame.rewind_audio = True

    # Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraire de l'Audio**
Aspose.Slides pour Python via .NET vous permet d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation contenant l'audio.
2. Obtenez la référence de la diapositive pertinente par son index.
3. Accédez aux transitions de diaporama pour la diapositive.
4. Extraire le son en données binaires.

Ce code Python vous montre comment extraire l'audio utilisé dans une diapositive :

```python
import aspose.slides as slides

# with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Accède à la diapositive souhaitée
    slide = pres.slides[0]  

    # Obtient les effets de transition de diaporama pour la diapositive
    transition = slide.slide_show_transition

    # Extrait le son dans un tableau d'octets
    audio = transition.sound.binary_data

    print("Longueur : " + str(len(audio)))
```