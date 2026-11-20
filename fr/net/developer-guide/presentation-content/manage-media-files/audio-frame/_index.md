---
title: Gérer les cadres audio dans les présentations en .NET
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/net/audio-frame/
keywords:
- audio
- cadre audio
- miniature
- ajouter audio
- propriétés audio
- options audio
- extraire l'audio
- .NET
- C#
- Aspose.Slides
description: "Intégrez de l'audio dans les diapositives, modifiez l'icône audio, configurez la lecture, gérez les légendes WebVTT et extrayez les sons des transitions de diapositives avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Un cadre audio vous permet de lire un son sur une diapositive. Avec Aspose.Slides pour .NET, vous pouvez intégrer un clip audio, choisir l’image qui le représente, ajuster la lecture et ajouter des légendes. Vous pouvez également récupérer un son attribué à une transition de diapositive.

## **Créer des cadres audio**

Utilisez [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) pour intégrer un clip audio local sur la première diapositive. Les deux premières coordonnées placent le cadre sur la diapositive, et les deux suivantes définissent sa largeur et sa hauteur, le tout en points. Cet exemple définit [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) pour démarrer automatiquement le clip et [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) sur le préréglage fort.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Modifier la miniature du cadre audio**

Par défaut, un cadre audio affiche une icône de haut‑parleur. Pour afficher une miniature personnalisée, ajoutez une image à la présentation avec [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) et attribuez‑la à la propriété [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) du cadre. L’exemple utilise un JPEG comme miniature pour un clip audio intégré.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Modifier les options de lecture audio**

Les contrôles **Audio Options** de PowerPoint déterminent quand un clip commence, à quel volume il joue et comment il se comporte pendant le diaporama.

![Contrôles Audio Options de PowerPoint pour un cadre audio](audio_frame_0.png)

| Contrôle PowerPoint | Propriété Aspose.Slides |
| --- | --- |
| Démarrage | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Préréglage du volume | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Lecture sur plusieurs diapositives | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Boucle jusqu’à arrêt | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Masquer pendant le diaporama | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Rembobiner après lecture | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Fondu entrant | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Fondu sortant | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Début de la coupe audio | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Fin de la coupe audio | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Curseur de volume | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

L’exemple trouve le premier cadre audio sur la première diapositive, définit [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) pour démarrer la lecture au clic, et sélectionne le préréglage de faible volume. Le clip se poursuit sur plusieurs diapositives avec la boucle désactivée. L’icône reste masquée pendant le diaporama, et le clip est rembobiné après la lecture.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

Pour un clip de plus de 3,5 secondes, cet exemple saute les 1,5 premières secondes et les 2 dernières secondes. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) mesure la durée à omettre à la fin du clip. Pour obtenir l’heure de fin affichée dans PowerPoint, soustrayez ce décalage de la durée totale du clip. Le clip découpé apparaît progressivement sur 200 millisecondes et disparaît sur 500 millisecondes. Les quatre propriétés prennent des valeurs en millisecondes.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

Pour définir le volume de lecture à un pourcentage spécifique, utilisez [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Cet exemple fixe le premier cadre audio sur la première diapositive à 85 %.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Gérer les légendes audio**

Chaque cadre audio possède une collection [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/). Utilisez‑la pour joindre des légendes WebVTT au clip, exporter les pistes existantes ou les supprimer.

### **Ajouter des légendes audio**

L’exemple intègre un clip audio sur la première diapositive et utilise [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) pour joindre une piste WebVTT locale. Le premier argument fournit le libellé de la piste, et le second identifie le fichier contenant les légendes synchronisées.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Extraire les légendes audio**

Cet exemple exporte chaque piste de légende attachée à un cadre audio sur la première diapositive. Il écrit les [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) de la piste dans un fichier WebVTT et utilise son [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) comme nom de fichier afin que chaque piste dispose d’une sortie distincte.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Supprimer les légendes audio**

Utilisez [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) pour supprimer une piste individuelle. L’exemple utilise [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) pour enlever toutes les légendes du premier cadre audio sur la première diapositive tout en conservant le clip.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Trouver une ligne dans les légendes audio**

Pour trouver une ligne dans les légendes audio de la première diapositive, lisez le [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) de chaque piste en mémoire. Dans un cue WebVTT en texte brut, la ligne de synchronisation contient `-->`, les lignes de légende la suivent, et une ligne vide termine le cue. Cet exemple imprime le libellé de la piste et chaque ligne de légende contenant «café».

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Extraire l’audio**

Une transition de diapositive peut avoir son propre son. Pour le récupérer, lisez la propriété [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) de la transition. L’exemple accède aux [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) du son et affiche sa taille en octets. Si la première diapositive n’a pas de son de transition, il affiche un message à la place.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**Puis-je réutiliser le même clip audio sur plusieurs diapositives sans le dupliquer ?**

Oui. Ajoutez le clip une fois à la [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) de la présentation et transmettez le même objet audio à [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) pour chaque diapositive.

**Puis-je remplacer le son d’un cadre audio existant ?**

Oui. Pour un son lié, mettez à jour [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) pour pointer vers le fichier de remplacement. Pour un son intégré, assignez un autre clip de la collection audio de la présentation à [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Les deux approches conservent le cadre existant.

**Le rognage modifie-t-il les données audio stockées dans la présentation ?**

Non. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) et [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) définissent les limites de lecture. Vous pouvez toujours récupérer le clip complet via [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).