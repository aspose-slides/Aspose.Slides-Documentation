---
title: Gérer les cadres audio dans les présentations avec Python
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/python-net/audio-frame/
keywords:
- audio
- cadre audio
- vignette
- ajouter audio
- propriétés audio
- options audio
- extraire audio
- WebVTT
- Python
- Aspose.Slides
description: "Intégrer de l’audio dans les diapositives, changer l’icône audio, configurer la lecture, gérer les légendes WebVTT et extraire les sons de transition de diapositives avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Un cadre audio vous permet de lire un son sur une diapositive. Avec Aspose.Slides for Python via .NET, vous pouvez intégrer un clip audio, choisir l'image qui le représente, ajuster la lecture et ajouter des légendes. Vous pouvez également récupérer un son attribué à une transition de diapositive.

## **Créer des cadres audio**

Utilisez [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) pour intégrer un clip audio local sur la première diapositive. Les deux premières coordonnées positionnent le cadre sur la diapositive, et les deux suivantes définissent sa largeur et sa hauteur, le tout en points. Cet exemple définit [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) pour démarrer le clip automatiquement et [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) sur le préréglage fort.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifier la vignette du cadre audio**

Par défaut, un cadre audio affiche une icône de haut-parleur. Pour afficher une vignette personnalisée, ajoutez une image à la présentation avec [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) et affectez‑la à la propriété [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) du cadre. L’exemple utilise un JPEG comme vignette pour un clip audio intégré.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifier les options de lecture audio**

Les contrôles des **Options audio** de PowerPoint déterminent quand un clip démarre, à quel volume il est joué et comment il se comporte pendant le diaporama.

![Contrôles des options audio de PowerPoint pour un cadre audio](audio_frame_0.png)

| Contrôle PowerPoint | Propriété Aspose.Slides |
| --- | --- |
| Démarrer | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Préréglage de volume | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Lire sur plusieurs diapositives | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Boucle jusqu’à l’arrêt | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Masquer pendant le diaporama | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Rembobiner après lecture | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Fondu en entrée | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Fondu en sortie | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Découper le temps de début audio | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Découper le temps de fin audio | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Curseur de volume | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

L’exemple trouve le premier cadre audio sur la première diapositive, définit [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) pour démarrer la lecture au clic, et sélectionne le préréglage de volume bas. Le clip continue sur plusieurs diapositives avec la boucle désactivée. L’icône reste masquée pendant le diaporama, et le clip est rembobiné après la lecture.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Pour un clip de plus de 3,5 s, cet exemple saute les 1,5 s premières et les 2 s dernières. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) mesure la durée à omettre à la fin du clip. Pour obtenir le temps de fin affiché dans PowerPoint, soustrayez ce décalage de la durée totale du clip. Le clip découpé fondu en entrée pendant 200 ms et fondu en sortie pendant 500 ms. Les quatre propriétés prennent des valeurs en millisecondes.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Pour définir le volume de lecture à un pourcentage spécifique, utilisez [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Cet exemple définit le premier cadre audio sur la première diapositive à 85 %.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer les légendes audio**

Chaque cadre audio possède une collection [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/). Utilisez‑la pour joindre des légendes WebVTT au clip, exporter les pistes existantes ou les supprimer.

### **Ajouter des légendes audio**

L’exemple intègre un clip audio sur la première diapositive et utilise [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) pour joindre une piste WebVTT locale. Le premier argument fournit le libellé de la piste, et le second identifie le fichier contenant les légendes synchronisées.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Extraire les légendes audio**

Cet exemple exporte chaque piste de légende attachée à un cadre audio sur la première diapositive. Il écrit les [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) de la piste dans un fichier WebVTT et utilise son [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) comme nom de fichier afin que chaque piste ait une sortie distincte.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **Supprimer les légendes audio**

Utilisez [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) ou [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) pour supprimer une piste individuelle. L’exemple utilise [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) pour enlever toutes les légendes du premier cadre audio sur la première diapositive tout en conservant le clip.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Trouver une ligne dans les légendes audio**

Pour trouver une ligne dans les légendes audio de la première diapositive, lisez en mémoire le [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) de chaque piste. Dans un cue WebVTT en texte brut, la ligne de chronométrage contient `-->`, les lignes de légende la suivent, et une ligne vide termine le cue. Cet exemple affiche le libellé de la piste et chaque ligne de légende contenant « café ».

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **Extraire l’audio**

Une transition de diapositive peut avoir son propre son. Pour le récupérer, lisez la propriété [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) de la transition. L’exemple accède aux [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) du son et affiche sa taille en octets. Si la première diapositive n’a pas de son de transition, il affiche un message à la place.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **FAQ**

**Puis‑je réutiliser le même clip audio sur plusieurs diapositives sans le dupliquer ?**

Oui. Ajoutez le clip une fois à la [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) de la présentation et transmettez le même objet audio à [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) pour chaque diapositive.

**Puis‑je remplacer le son d’un cadre audio existant ?**

Oui. Pour un son lié, mettez à jour [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) pour pointer vers le fichier de remplacement. Pour un son intégré, affectez un autre clip de la collection audio de la présentation à [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/). Les deux approches conservent le cadre existant.

**Le découpage modifie‑t‑il les données audio stockées dans la présentation ?**

Non. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) et [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) définissent les limites de lecture. Vous pouvez toujours récupérer le clip complet via [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/).