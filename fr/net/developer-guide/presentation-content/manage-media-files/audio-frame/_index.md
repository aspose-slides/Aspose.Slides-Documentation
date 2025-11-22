---
title: Gérer l'audio dans les présentations avec C#
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
description: "Créer et contrôler les cadres audio dans Aspose.Slides pour .NET — exemples C# pour incorporer, couper, boucler et configurer la lecture dans les présentations PPT, PPTX et ODP."
---

## **Créer des cadres audio**

Aspose.Slides for .NET vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés aux diapositives sous forme de cadres audio. 

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive via son indice.
3. Chargez le flux du fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) et `Volume` exposés par l’objet [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. Enregistrez la présentation modifiée.

Ce code C# montre comment ajouter un cadre audio intégré à une diapositive :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation())
{
    // Obtient la première diapositive
    ISlide sld = pres.Slides[0];
    
    // Charge le fichier wav en flux
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Ajoute le cadre audio
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Définit le mode de lecture et le volume de l'audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Écrit le fichier PowerPoint sur le disque
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```


## **Modifier la miniature du cadre audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous forme de cadre avec une image par défaut standard (voir l'image dans la section ci‑dessous). Vous pouvez modifier la miniature du cadre audio (définir votre image préférée).

Ce code C# montre comment changer la miniature ou l’image d’aperçu d’un cadre audio :
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
    
	//Enregistre la présentation modifiée sur le disque
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **Modifier les options de lecture audio**

Aspose.Slides for .NET vous permet de modifier les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, définir la lecture en boucle, ou même masquer l'icône audio.

Le volet **Audio Options** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Les **Audio Options** de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) d’Aspose.Slides :

- **Start** du menu déroulant correspond à la propriété [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode).
- **Volume** correspond à la propriété [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume).
- **Play Across Slides** correspond à la propriété [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides).
- **Loop until Stopped** correspond à la propriété [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode).
- **Hide During Show** correspond à la propriété [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing).
- **Rewind after Playing** correspond à la propriété [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio).

Les options **Editing** de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) d’Aspose.Slides :

- **Fade In** correspond à la propriété [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/).
- **Fade Out** correspond à la propriété [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/).
- **Trim Audio Start Time** correspond à la propriété [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/).
- **Trim Audio End Time** a une valeur égale à la durée de l'audio moins la valeur de la propriété [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/).

Le **Volume controll** de PowerPoint dans le panneau de contrôle audio correspond à la propriété [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Сreate](#create-audio-frame) ou obtenez le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code C# montre une opération où les options d'un audio sont ajustées :
```csharp
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Obtient la forme AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Définit le mode de lecture sur lecture au clic
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Définit le volume sur Faible
    audioFrame.Volume = AudioVolumeMode.Low;

    // Définit l'audio pour lire sur toutes les diapositives
    audioFrame.PlayAcrossSlides = true;

    // Désactive la lecture en boucle de l'audio
    audioFrame.PlayLoopMode = false;

    // Masque le AudioFrame pendant le diaporama
    audioFrame.HideAtShowing = true;

    // Rembobine l'audio au début après la lecture
    audioFrame.RewindAudio = true;

    // Enregistre le fichier PowerPoint sur le disque
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


Cet exemple C# montre comment ajouter un nouveau cadre audio avec audio intégré, le couper, et définir les durées de fondu :
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Définit le décalage de début de rognage à 1,5 seconde
    audioFrame.TrimFromStart = 1500f;
    // Définit le décalage de fin de rognage à 2 secondes
    audioFrame.TrimFromEnd = 2000f;

    // Définit la durée du fondu d'entrée à 200 ms
    audioFrame.FadeInDuration = 200f;
    // Définit la durée du fondu de sortie à 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```


L’exemple de code suivant montre comment récupérer un cadre audio avec audio intégré et régler son volume à 85 % :
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


## **Extraire l’audio**

Aspose.Slides for .NET vous permet d'extraire le son utilisé dans les transitions du diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation contenant l’audio.
2. Obtenez la référence de la diapositive concernée via son indice.
3. Accédez aux transitions du diaporama pour la diapositive.
4. Extrayez le son sous forme de données binaires.

Ce code C# montre comment extraire l’audio utilisé dans une diapositive :
```c#
string presName = "AudioSlide.pptx";

// Instancie une classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation(presName);

// Accède à la diapositive
ISlide slide = pres.Slides[0];

// Obtient les effets de transition du diaporama pour la diapositive
ISlideShowTransition transition = slide.SlideShowTransition;

//Extrait le son en tableau d'octets
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **FAQ**

**Puis-je réutiliser le même fichier audio sur plusieurs diapositives sans augmenter la taille du fichier ?**

Oui. Ajoutez l’audio une fois à la [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) partagée de la présentation et créez des cadres audio supplémentaires qui font référence à cet actif existant. Cela évite la duplication des données multimédias et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d’un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) pour pointer vers le nouveau fichier. Pour un son intégré, remplacez l’objet [embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) par un autre provenant de la [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) de la présentation. Le format du cadre et la plupart des paramètres de lecture restent intacts.

**Le rognage modifie-t-il les données audio sous-jacentes stockées dans la présentation ?**

Non. Le rognage ne modifie que les limites de lecture. Les octets audio originaux restent intacts et accessibles via l’audio intégré ou la collection audio de la présentation.