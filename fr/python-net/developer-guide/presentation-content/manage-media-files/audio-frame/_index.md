---
title: Gérer l'audio dans les présentations avec Python
linktitle: Trame audio
type: docs
weight: 10
url: /fr/python-net/audio-frame/
keywords:
- ajouter audio
- intégrer audio
- trame audio
- fichier audio
- propriétés audio
- extraire audio
- récupérer audio
- modifier audio
- options de lecture
- mode de lecture
- lecture sur plusieurs diapositives
- boucle jusqu'à l'arrêt
- masquer pendant la présentation
- rembobiner après lecture
- volume audio
- image par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajoutez, extrayez et gérez facilement les trames audio dans PPT, PPTX et ODP avec Aspose.Slides for Python via .NET. Explorez des exemples de code et améliorez vos présentations dès aujourd'hui."
---
## **Créer des trames audio**

Aspose.Slides for Python via .NET vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont incorporés dans les diapositives sous forme de trames audio. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive via son index.
3. Chargez le flux du fichier audio que vous souhaitez incorporer dans la diapositive.
4. Ajoutez la trame audio incorporée (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioplaymodepreset) et `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/).
6. Enregistrez la présentation modifiée.

Ce code Python vous montre comment ajouter une trame audio incorporée à une diapositive :

```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier de présentation
with slides.Presentation() as pres:
    # Obtient la première diapositive
    sld = pres.slides[0]

    # Charge le fichier son wav en flux
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Ajoute la trame audio
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Définit le mode de lecture et le volume de l'audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Enregistre le fichier PowerPoint sur le disque
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifier la vignette de la trame audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous forme d'une trame avec une image par défaut standard (voir l'image dans la section ci‑dessous). Vous pouvez modifier la miniature de la trame audio (définir votre image préférée).

Ce code Python vous montre comment modifier la miniature ou l'image d'aperçu d'une trame audio :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajoute une trame audio à la diapositive avec une position et une taille spécifiées.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Ajoute une image aux ressources de la présentation.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Définit l'image pour la trame audio.
        audioFrame.picture_format.picture.image = audioImage
        
        #Enregistre la présentation modifiée sur le disque
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifier les options de lecture audio**

Aspose.Slides for Python via .NET vous permet de modifier les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, définir la lecture en boucle, ou même masquer l'icône audio.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/) :

- **Start** (liste déroulante) correspond à la propriété [AudioFrame.play_mode](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/play_mode/) 
- **Volume** correspond à la propriété [AudioFrame.volume](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/volume/) 
- **Play Across Slides** correspond à la propriété [AudioFrame.play_across_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/play_across_slides/) 
- **Loop until Stopped** correspond à la propriété [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/play_loop_mode/) 
- **Hide During Show** correspond à la propriété [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/hide_at_showing/) 
- **Rewind after Playing** correspond à la propriété [AudioFrame.rewind_audio](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/rewind_audio/) 

PowerPoint **Editing** options qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/) :

- **Fade In** correspond à la propriété [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/fade_in_duration/) 
- **Fade Out** correspond à la propriété [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/fade_out_duration/) 
- **Trim Audio Start Time** correspond à la propriété [AudioFrame.trim_from_start](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/trim_from_start/) 
- **Trim Audio End Time** correspond à la durée de l'audio moins la valeur de la propriété [AudioFrame.trim_from_end](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/trim_from_end/) 

Le **contrôle du volume** de PowerPoint sur le panneau de contrôle audio correspond à la propriété [AudioFrame.volume_value](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/volume_value/) . Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenez la Trame audio.
2. Définissez de nouvelles valeurs pour les propriétés de la trame audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code Python démontre une opération où les options d'un audio sont ajustées :

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Obtient la forme AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Définit le mode de lecture sur lecture au clic
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Définit le volume à Bas
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Définit l'audio pour qu'il joue sur plusieurs diapositives
    audioFrame.play_across_slides = True

    # Désactive la boucle pour l'audio
    audioFrame.play_loop_mode = False

    # Masque la trame audio pendant le diaporama
    audioFrame.hide_at_showing = True

    # Rembobine l'audio au début après la lecture
    audioFrame.rewind_audio = True

    # Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Cet exemple Python montre comment ajouter une nouvelle trame audio avec audio incorporé, la rogner et définir les durées de fondu :

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Définit le point de début de rognage à 1,5 secondes
    # Définit le point de fin de rognage à 2 secondes
    # Définit la durée du fondu d'entrée à 200 ms
    # Définit la durée du fondu de sortie à 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

L'exemple de code suivant montre comment récupérer une trame audio avec audio incorporé et définir son volume à 85 % :

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Obtient une forme de trame audio
    audio_frame = pres.slides[0].shapes[0]

    # Définit le volume audio à 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer les sous‑titres audio**

Aspose.Slides vous permet d'ajouter des sous‑titres fermés à une trame audio via la propriété [caption_tracks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/caption_tracks/) . Cette propriété renvoie une [CaptionsCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/), qui vous permet d'ajouter des pistes de sous‑titres WebVTT, de parcourir les pistes existantes et de les supprimer si nécessaire.

**Ajouter des sous‑titres audio**

Utilisez la propriété [caption_tracks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/caption_tracks/) pour attacher une ou plusieurs pistes de sous‑titres à une trame audio. Dans l'exemple suivant, un fichier audio est ajouté à une diapositive, puis une nouvelle piste de sous‑titres est chargée à partir d'un fichier `.vtt` .

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Ajouter une nouvelle piste de sous‑titres à partir d'un fichier WebVTT.
    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Extraire les sous‑titres audio**

Vous pouvez parcourir les pistes de sous‑titres associées à une trame audio et les enregistrer en fichiers `.vtt`. Chaque piste de sous‑titres expose ses données binaires et son identifiant unique, qui peuvent être utilisés lors de l'exportation des sous‑titres.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Enregistre la piste de sous-titres comme fichier .vtt.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Supprimer les sous‑titres audio**

Pour supprimer les sous‑titres d'une trame audio, utilisez les méthodes fournies par [CaptionsCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/), telles que [clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/remove/), ou [remove_at](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/remove_at/). L'exemple suivant supprime toutes les pistes de sous‑titres d'une trame audio.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # type: slides.AudioFrame

    # Supprime toutes les pistes de sous-titres de la trame audio.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraire l'audio**

Aspose.Slides for Python via .NET vous permet d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et chargez la présentation contenant l'audio.
2. Obtenez la référence de la diapositive concernée via son index.
3. Accédez aux transitions du diaporama pour la diapositive.
4. Extrayez le son sous forme de données binaires.

Ce code Python vous montre comment extraire l'audio utilisé dans une diapositive :

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
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

Oui. Ajoutez l'audio une seule fois à la [audio collection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/audios/) partagée de la présentation et créez des trames audio supplémentaires qui font référence à cet actif existant. Cela évite la duplication des données multimédia et maintient la taille du fichier sous contrôle.

**Puis-je remplacer le son d'une trame audio existante sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [link path](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/link_path_long/) pour pointer vers le nouveau fichier. Pour un son incorporé, remplacez l'objet [embedded audio](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/embedded_audio/) par un autre provenant de la [audio collection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/audios/) de la présentation. Le formatage de la trame et la plupart des paramètres de lecture restent intacts.

**Le rognage modifie-t-il les données audio sous‑jacentes stockées dans la présentation ?**

Non. Le rognage ajuste uniquement les limites de lecture. Les octets audio originaux restent inchangés et accessibles via l'audio incorporé ou la collection audio de la présentation.