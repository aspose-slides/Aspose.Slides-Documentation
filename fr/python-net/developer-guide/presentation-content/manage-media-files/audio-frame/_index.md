---
title: Gérer l'audio dans les présentations avec Python
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/python-net/audio-frame/
keywords:
- ajouter audio
- intégrer audio
- cadre audio
- fichier audio
- propriétés audio
- extraire audio
- récupérer audio
- modifier audio
- options de lecture
- mode de lecture
- lecture sur plusieurs diapositives
- boucler jusqu'à arrêt
- masquer pendant le diaporama
- rembobiner après lecture
- volume audio
- image par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajoutez, extrayez et gérez facilement les cadres audio dans PPT, PPTX et ODP avec Aspose.Slides for Python via .NET. Explorez des exemples de code et améliorez vos présentations dès aujourd'hui."
---

## **Créer des cadres audio**

Aspose.Slides for Python via .NET vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés dans les diapositives sous forme de cadres audio. 

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive à l'aide de son indice.
3. Chargez le flux du fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez le [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) et le `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/).
6. Enregistrez la présentation modifiée.

Ce code Python vous montre comment ajouter un cadre audio intégré à une diapositive :
```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier de présentation
with slides.Presentation() as pres:
    # Obtient la première diapositive
    sld = pres.slides[0]

    # Charge le fichier son wav dans un flux
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Ajoute le cadre audio
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Définit le mode de lecture et le volume de l'audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Enregistre le fichier PowerPoint sur le disque
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Modifier la miniature du cadre audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous forme de cadre avec une image par défaut standard (voir l'image dans la section ci-dessous). Vous pouvez modifier la miniature du cadre audio (définir votre image préférée).

Ce code Python vous montre comment modifier la miniature ou l'image d'aperçu d'un cadre audio :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajoute un cadre audio à la diapositive avec une position et une taille spécifiées.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Ajoute une image aux ressources de la présentation.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Définit l'image pour le cadre audio.
        audioFrame.picture_format.picture.image = audioImage
        
        #Enregistre la présentation modifiée sur le disque
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Modifier les options de lecture audio**

Aspose.Slides for Python via .NET vous permet de modifier les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, régler la lecture en boucle, ou même masquer l'icône audio.

Le volet **Options audio** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Les **Options audio** de PowerPoint qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) :

- **Début** la liste déroulante correspond à la propriété [AudioFrame.play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/)
- **Volume** correspond à la propriété [AudioFrame.volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/)
- **Lire sur plusieurs diapositives** correspond à la propriété [AudioFrame.play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/)
- **Boucler jusqu'à l'arrêt** correspond à la propriété [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/)
- **Masquer pendant le diaporama** correspond à la propriété [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/)
- **Rembobiner après lecture** correspond à la propriété [AudioFrame.rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/)

Les options **Édition** de PowerPoint qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) :

- **Fondu d'entrée** correspond à la propriété [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/)
- **Fondu de sortie** correspond à la propriété [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/)
- **Rogner le temps de début audio** correspond à la propriété [AudioFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/)
- **Rogner le temps de fin audio** la valeur correspond à la durée de l'audio moins la valeur de la propriété [AudioFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/)

Le **contrôle du volume** de PowerPoint dans le panneau de contrôle audio correspond à la propriété [AudioFrame.volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenir le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code Python démontre une opération dans laquelle les options d'un audio sont ajustées :
```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Récupère la forme AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Définit le mode de lecture sur lecture au clic
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Définit le volume à faible
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Définit la lecture de l'audio sur plusieurs diapositives
    audioFrame.play_across_slides = True

    # Désactive la boucle pour l'audio
    audioFrame.play_loop_mode = False

    # Masque le AudioFrame pendant le diaporama
    audioFrame.hide_at_showing = True

    # Rembobine l'audio au début après la lecture
    audioFrame.rewind_audio = True

    # Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```


Cet exemple Python montre comment ajouter un nouveau cadre audio avec audio intégré, le rogner, et définir les durées du fondu :
```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Définit le décalage de début du rognage à 1,5 seconde
    # Définit le décalage de fin du rognage à 2 secondes
    # Définit la durée du fondu d'entrée à 200 ms
    # Définit la durée du fondu de sortie à 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```


L'exemple de code suivant montre comment récupérer un cadre audio avec audio intégré et régler son volume à 85 % :
```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Récupère la forme d'un cadre audio
    audio_frame = pres.slides[0].shapes[0]

    # Définit le volume audio à 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Extraire l'audio**

Aspose.Slides for Python via .NET vous permet d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation contenant l'audio.
2. Obtenez la référence de la diapositive concernée à l'aide de son indice.
3. Accédez aux transitions du diaporama pour la diapositive.
4. Extrayez le son sous forme de données binaires.

Ce code Python vous montre comment extraire l'audio utilisé dans une diapositive :
```python
import aspose.slides as slides

#avec slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Accède à la diapositive souhaitée
    slide = pres.slides[0]  

    # Obtient les effets de transition du diaporama pour la diapositive
    transition = slide.slide_show_transition

    #Extrait le son sous forme de tableau d'octets
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```


## **FAQ**

**Puis-je réutiliser le même fichier audio sur plusieurs diapositives sans augmenter la taille du fichier ?**

Oui. Ajoutez l'audio une seule fois à la [collection audio](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) partagée de la présentation et créez des cadres audio supplémentaires qui font référence à cet élément existant. Cela évite de dupliquer les données multimédias et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d'un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [chemin du lien](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) pour qu'il pointe vers le nouveau fichier. Pour un son intégré, remplacez l'objet [audio intégré](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) par un autre provenant de la [collection audio](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) de la présentation. Le formatage du cadre et la plupart des paramètres de lecture restent intacts.

**Le rognage modifie-t-il les données audio sous-jacentes stockées dans la présentation ?**

Non. Le rognage n'ajuste que les limites de lecture. Les octets audio originaux restent intacts et accessibles via l'audio intégré ou la collection audio de la présentation.