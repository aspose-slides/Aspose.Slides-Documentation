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
- extraire audio
- .NET
- C#
- Aspose.Slides
description: "Créer et contrôler les cadres audio dans Aspose.Slides pour .NET — exemples C# pour incorporer, rogner, mettre en boucle et configurer la lecture dans les présentations PPT, PPTX et ODP."
---
## **Créer des cadres audio**

Aspose.Slides for .NET vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont incorporés dans les diapositives sous forme de cadres audio. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Chargez le flux du fichier audio que vous souhaitez incorporer dans la diapositive.
4. Ajoutez le cadre audio incorporé (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/fr/net/aspose.slides/audioplaymodepreset) et `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe).
6. Enregistrez la présentation modifiée.

```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation())
{
    // Obtient la première diapositive
    ISlide sld = pres.Slides[0];
    
    // Charge le fichier audio wav dans un flux
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Ajoute le cadre audio
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Définit le mode de lecture et le volume de l'audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Enregistre le fichier PowerPoint sur le disque
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Modifier la miniature du cadre audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous forme de cadre avec une image par défaut standard (voir l'image dans la section ci-dessous). Vous pouvez changer la miniature du cadre audio (définir votre image préférée).

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Ajoute un cadre audio à la diapositive avec une position et une taille spécifiées.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Ajoute une image aux ressources de la présentation.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Définit l'image pour le cadre audio.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----

	//Saves la présentation modifiée sur le disque
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Modifier les options de lecture audio**

Aspose.Slides for .NET vous permet de modifier les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, définir la lecture en boucle, ou même masquer l'icône audio.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** correspondant aux propriétés [AudioFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe) d'Aspose.Slides:

- Le menu déroulant **Start** correspond à la propriété [AudioFrame.PlayMode](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/properties/playmode) 
- **Volume** correspond à la propriété [AudioFrame.Volume](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/properties/volume) 
- **Play Across Slides** correspond à la propriété [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/properties/playacrossslides) 
- **Loop until Stopped** correspond à la propriété [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/properties/playloopmode) 
- **Hide During Show** correspond à la propriété [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/properties/hideatshowing) 
- **Rewind after Playing** correspond à la propriété [AudioFrame.RewindAudio](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/properties/rewindaudio) 

Options **Editing** de PowerPoint correspondant aux propriétés [AudioFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe) d'Aspose.Slides:

- **Fade In** correspond à la propriété [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/fadeinduration/) 
- **Fade Out** correspond à la propriété [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/fadeoutduration/) 
- **Trim Audio Start Time** correspond à la propriété [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/trimfromstart/) 
- La valeur **Trim Audio End Time** correspond à la durée de l'audio moins la valeur de la propriété [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/trimfromend/) 

Le contrôle **Volume** de PowerPoint sur le panneau de contrôle audio correspond à la propriété [AudioFrame.VolumeValue](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/volumevalue/) . Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenir le Cadre Audio.
2. Définissez de nouvelles valeurs pour les propriétés du Cadre Audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Obtient la forme AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Définit le mode de lecture pour jouer au clic
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Définit le volume à Bas
    audioFrame.Volume = AudioVolumeMode.Low;

    // Définit l'audio pour lire sur toutes les diapositives
    audioFrame.PlayAcrossSlides = true;

    // Désactive la boucle pour l'audio
    audioFrame.PlayLoopMode = false;

    // Masque le AudioFrame pendant le diaporama
    audioFrame.HideAtShowing = true;

    // Rembobine l'audio au début après la lecture
    audioFrame.RewindAudio = true;

    // Enregistre le fichier PowerPoint sur le disque
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Définit le décalage de début du rognage à 1,5 secondes
    audioFrame.TrimFromStart = 1500f;
    // Définit le décalage de fin du rognage à 2 secondes
    audioFrame.TrimFromEnd = 2000f;

    // Définit la durée de fondu entrant à 200 ms
    audioFrame.FadeInDuration = 200f;
    // Définit la durée de fondu sortant à 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Obtient une forme de cadre audio
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Définit le volume audio à 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Gérer les légendes audio**

Aspose.Slides vous permet d'ajouter des sous-titres fermés à un cadre audio via la propriété [CaptionTracks](https://reference.aspose.com/slides/fr/net/aspose.slides/iaudioframe/captiontracks/) . Cette propriété renvoie une [ICaptionsCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/icaptionscollection/) , qui vous permet d'ajouter des pistes de sous-titres WebVTT, de parcourir les pistes existantes et de les supprimer si nécessaire.

**Ajouter des sous-titres audio**

Utilisez la propriété [CaptionTracks](https://reference.aspose.com/slides/fr/net/aspose.slides/iaudioframe/captiontracks/) pour joindre une ou plusieurs pistes de sous-titres à un cadre audio. Dans l'exemple suivant, un fichier audio est ajouté à une diapositive, puis une nouvelle piste de sous-titres est chargée à partir d'un fichier `.vtt` .

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Ajoute une nouvelle piste de sous-titres à partir d'un fichier WebVTT.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Extraire les sous-titres audio**

Vous pouvez parcourir les pistes de sous-titres associées à un cadre audio et les enregistrer sous forme de fichiers `.vtt`. Chaque piste expose ses données binaires et son identifiant unique, qui peuvent être utilisés lors de l'exportation des sous-titres.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // Enregistre la piste de sous-titres sous forme de fichier .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Supprimer les sous-titres audio**

Pour supprimer les sous-titres d'un cadre audio, utilisez les méthodes fournies par [ICaptionsCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/icaptionscollection/) , telles que [Clear](https://reference.aspose.com/slides/fr/net/aspose.slides/icaptionscollection/clear/) , [Remove](https://reference.aspose.com/slides/fr/net/aspose.slides/icaptionscollection/remove/) , ou [RemoveAt](https://reference.aspose.com/slides/fr/net/aspose.slides/icaptionscollection/removeat/) . L'exemple suivant supprime toutes les pistes de sous-titres d'un cadre audio.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Supprime toutes les pistes de sous-titres du cadre audio.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Extraire l'audio**

Aspose.Slides for .NET vous permet d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) et chargez la présentation contenant l'audio.
2. Obtenez la référence de la diapositive concernée via son index.
3. Accédez aux transitions du diaporama pour la diapositive.
4. Extrayez le son sous forme de données binaires.

```c#
string presName = "AudioSlide.pptx";

// Instancie une classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation(presName);

// Accède à la diapositive
ISlide slide = pres.Slides[0];

// Obtient les effets de transition du diaporama pour la diapositive
ISlideShowTransition transition = slide.SlideShowTransition;

//Extrait le son sous forme de tableau d'octets
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**Puis-je réutiliser le même fichier audio sur plusieurs diapositives sans augmenter la taille du fichier ?**

Oui. Ajoutez l'audio une fois à la [audio collection](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/audios/) partagée de la présentation et créez des cadres audio supplémentaires qui référencent cet actif existant. Cela évite la duplication des données multimédia et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d'un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [link path](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/linkpathlong/) pour pointer vers le nouveau fichier. Pour un son incorporé, remplacez l'objet [embedded audio](https://reference.aspose.com/slides/fr/net/aspose.slides/audioframe/embeddedaudio/) par un autre provenant de la [audio collection](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/audios/) de la présentation. Le formatage du cadre et la plupart des paramètres de lecture restent inchangés.

**Le rognage modifie-t-il les données audio sous-jacentes stockées dans la présentation ?**

Non. Le rognage ajuste uniquement les limites de lecture. Les octets audio originaux restent intacts et accessibles via l'audio incorporé ou la collection audio de la présentation.