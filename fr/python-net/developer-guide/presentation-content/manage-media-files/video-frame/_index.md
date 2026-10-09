---
title: Gérer les cadres vidéo dans les présentations en Python
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/python-net/video-frame/
keywords:
- ajouter vidéo
- créer vidéo
- intégrer vidéo
- extraire vidéo
- récupérer vidéo
- cadre vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmaticalement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via .NET. Guide pratique rapide."
---
## **Introduction**

Les vidéos peuvent aider à expliquer des idées et à capter l'attention du public. Aspose.Slides for Python via .NET vous permet d'ajouter des cadres vidéo aux diapositives, d'ajuster les paramètres de lecture, de gérer les sous‑titres et d'extraire les données vidéo intégrées.

PowerPoint prend en charge les vidéos locales et les liens vers des vidéos en ligne, comme les vidéos YouTube.

Pour représenter les données vidéo et les cadres vidéo, Aspose.Slides fournit la classe [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , la classe [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) et d'autres types pertinents.

## **Create an Embedded Video Frame**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.

Cet exemple intègre une vidéo locale sur la première diapositive d'une présentation existante et enregistre le résultat. Les coordonnées et les dimensions du cadre sont exprimées en points. Le flux reste ouvert jusqu'à la fin de l'enregistrement car [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) le verrouille tant que la présentation l'utilise.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Vous pouvez également fournir directement un chemin vers une vidéo locale à [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Cet exemple intègre la vidéo sur la première diapositive d'une nouvelle présentation. La vidéo doit rester accessible jusqu'à ce que la présentation soit enregistrée.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Create a Video Frame with Video from a Web Source**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prend en charge les vidéos en ligne dans les présentations. Vous pouvez créer un cadre vidéo qui lie à une vidéo en ligne, comme une vidéo YouTube.

Cet exemple ajoute un lien vidéo YouTube et une miniature à la première diapositive. Remplacez l'identifiant vidéo pour utiliser une autre vidéo. Le paramètre [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) demande une lecture automatique. Le téléchargement de la miniature et la lecture de la vidéo nécessitent un accès Internet. Le visualiseur de présentation doit également prendre en charge la lecture de vidéos en ligne.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Play a Video in Full-Screen Mode**

Dans une présentation de formation, vous pouvez lire une démonstration logicielle en mode plein écran afin que le public puisse voir les détails. Définissez [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) à `True` pour activer ce comportement pendant la lecture.

Cet exemple ouvre une présentation, trouve le premier [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) sur la première diapositive, et active la lecture en plein écran. La présentation d'entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

La lecture en plein écran contrôle la façon dont la vidéo est affichée. Indépendamment, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) contrôle si elle démarre automatiquement ou au clic, et [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) contrôle si elle se répète. Pour choisir le comportement de démarrage, définissez le mode de lecture sur [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). L'exemple préserve les paramètres de démarrage et de boucle existants.

## **Rewind a Video After Playback**

Dans une présentation de formation, ramener une vidéo de démonstration au début la rend prête pour que le présentateur la lise à nouveau. Définissez [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) à `True` pour ramener la vidéo au début après la fin de la lecture.

Cet exemple ouvre une présentation, trouve le premier [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) sur la première diapositive, et active le rembobinage. Il désactive la boucle afin que la lecture puisse se terminer et définit le démarrage de la lecture au clic. La présentation d'entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

Le rembobinage ramène la vidéo à son début sans la relancer. En revanche, activer [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) répète la lecture automatiquement. Gardez la boucle désactivée lorsque vous voulez que la vidéo se termine et reste prête à être rejouée. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) contrôle indépendamment le démarrage automatique ou au clic ; cet exemple utilise [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) afin que le présentateur contrôle le moment du démarrage. Définissez le mode de lecture après le paramètre de boucle, comme indiqué dans l'exemple. Le rembobinage fonctionne indépendamment de [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Trim a Video Frame**

Utilisez [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) et [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) pour ignorer une partie du début ou de la fin d'une vidéo pendant la lecture. Les deux valeurs sont exprimées en millisecondes. Le rognage modifie les paramètres de lecture sans modifier les données vidéo intégrées.

**Set Trim Settings**

Cette exemple intègre une vidéo locale et saute les 2,5 secondes initiales ainsi que la dernière seconde pendant la lecture. Utilisez une vidéo d'une durée supérieure à 3,5 secondes afin qu'un segment lisible demeure.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Read Trim Settings**

Cette exemple affiche les valeurs de rognage du premier cadre vidéo sur la première diapositive en millisecondes. La présentation doit contenir au moins une diapositive. Si cette diapositive ne possède aucun cadre vidéo, rien n'est affiché. L'exemple précédent produit les valeurs 2500 et 1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Manage Video Captions**

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont exposés via la propriété [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

**Add Captions to a Video Frame**

Cette exemple intègre une vidéo locale et ajoute une piste de sous‑titre WebVTT étiquetée Anglais. Les horodatages des sous‑titres doivent correspondre à la vidéo. La présentation enregistrée comprend à la fois la vidéo et ses sous‑titres.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) propose également une surcharge qui permet d'ajouter des sous‑titres à partir d'un flux.

**Extract Captions from a Video Frame**

Cette exemple enregistre toutes les pistes de sous‑titres des cadres vidéo sur la première diapositive en fichiers WebVTT distincts. Les numéros séquentiels gardent les fichiers de sortie distincts. La console signale le nombre de pistes extraites. La présentation doit contenir au moins une diapositive.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Chaque objet [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) expose l'identifiant du sous‑titre, l'étiquette, les données binaires et le texte du sous‑titre sous forme de chaîne UTF‑8.

**Remove Captions from a Video Frame**

Cette exemple supprime tous les sous‑titres du cadre vidéo à la première position de forme sur la première diapositive et enregistre le résultat. Elle suppose que la diapositive et la forme existent et que la forme est un cadre vidéo.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Si vous devez supprimer uniquement une piste de sous‑titre, utilisez les méthodes [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) ou [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) au lieu de [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

## **Extract Video from a Slide**

Outre l'ajout de vidéos aux diapositives, Aspose.Slides vous permet d'extraire les vidéos intégrées dans les présentations.

Cette exemple extrait les vidéos intégrées de chaque diapositive dans des fichiers binaires distincts et numérotés. Les vidéos liées sont ignorées car elles ne contiennent aucune donnée intégrée. La console affiche le type MIME de chaque vidéo ainsi que le nombre total. La sortie utilise l'extension générique `.bin` ; modifiez‑la pour correspondre au type de média indiqué si nécessaire.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **FAQ**

**Which video playback parameters can be changed for a video frame?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automatique ou au clic) et la [boucle](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Ces options sont disponibles via les propriétés de l'objet [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Does adding a video affect the PPTX file size?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente proportionnellement la taille de la présentation. Lorsque vous liez à une vidéo en ligne et ajoutez une miniature, la présentation ne conserve que le lien et l'image de prévisualisation, ce qui réduit généralement l'augmentation de taille.

**Can I replace the video in an existing video frame without changing its position and size?**

Oui. Vous pouvez remplacer le [contenu vidéo](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) à l'intérieur du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Can the content type (MIME) of an embedded video be determined?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) que vous pouvez lire et utiliser, par exemple lors de l'enregistrement sur le disque.