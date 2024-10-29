---
title: Cadre Audio - Insérer et Extraire de l'Audio dans PowerPoint avec C#
linktitle: Cadre Audio
type: docs
weight: 10
url: /fr/net/audio-frame/
keywords: "image miniature audio, Ajouter de l'audio, Cadre audio, Propriétés audio, Extraire de l'audio, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter de l'audio à une présentation PowerPoint en C# ou .NET"
---

## **Créer un Cadre Audio**
Aspose.Slides pour .NET vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés dans les diapositives sous forme de cadres audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive par son index.
3. Chargez le flux de fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) et `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. Enregistrez la présentation modifiée.

Ce code C# vous montre comment ajouter un cadre audio intégré à une diapositive :

```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation())
{
    // Obtient la première diapositive
    ISlide sld = pres.Slides[0];
    
    // Charge le fichier audio wav dans un flux
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Ajoute le Cadre Audio
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Définit le Mode de Lecture et le Volume de l'Audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Écrit le fichier PowerPoint sur le disque
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Changer la Miniature du Cadre Audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous la forme d'un cadre avec une image par défaut standard (voir l'image dans la section ci-dessous). Vous pouvez changer la miniature du cadre audio (définissez votre image préférée).

Ce code C# vous montre comment changer la miniature ou l'image de prévisualisation d'un cadre audio :

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Ajoute un cadre audio à la diapositive avec une position et une taille spécifiées.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Ajoute une image aux ressources de présentation.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Définit l'image pour le cadre audio.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//Sauvegarde la présentation modifiée sur le disque
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Changer les Options de Lecture Audio**

Aspose.Slides pour .NET vous permet de changer les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, définir l'audio pour qu'il soit joué en boucle, ou même cacher l'icône audio.

Le **Panneau des Options Audio** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Les options audio de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) d'Aspose.Slides :

- Le menu déroulant **Démarrer** des Options Audio correspond à la propriété [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) 
- Les options Audio **Volume** correspondent à la propriété [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) 
- Les options Audio **Jouer à travers les diapositives** correspondent à la propriété [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) 
- Les options Audio **Boucler jusqu'à l'arrêt** correspondent à la propriété [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) 
- Les options Audio **Cacher pendant la présentation** correspondent à la propriété [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) 
- Les options Audio **Rembobiner après lecture** correspondent à la propriété [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) 

Voici comment vous changez les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenir le Cadre Audio.
2. Définissez de nouvelles valeurs pour les propriétés du Cadre Audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code C# démontre une opération dans laquelle les options d'un audio sont ajustées :

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Obtient la forme AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Définit le mode de lecture pour jouer au clic
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Définit le volume sur Bas
    audioFrame.Volume = AudioVolumeMode.Low;

    // Définit l'audio pour jouer à travers les diapositives
    audioFrame.PlayAcrossSlides = true;

    // Désactive la boucle pour l'audio
    audioFrame.PlayLoopMode = false;

    // Cache le Cadre Audio pendant le diaporama
    audioFrame.HideAtShowing = true;

    // Rembobine l'audio pour commencer après la lecture
    audioFrame.RewindAudio = true;

    // Enregistre le fichier PowerPoint sur le disque
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

## **Extraire de l'Audio**
Aspose.Slides pour .NET vous permet d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation contenant l'audio.
2. Obtenez une référence à la diapositive pertinente par son index.
3. Accédez aux transitions de diaporama pour la diapositive.
4. Extraire le son sous forme de données binaires.

Ce code C# vous montre comment extraire l'audio utilisé dans une diapositive :

```c#
string presName = "AudioSlide.pptx";

// Instancie une classe de Présentation qui représente un fichier de présentation
Presentation pres = new Presentation(presName);

// Accède à la diapositive
ISlide slide = pres.Slides[0];

// Obtient les effets de transition de diaporama pour la diapositive
ISlideShowTransition transition = slide.SlideShowTransition;

//Extrait le son sous forme de tableau d'octets
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Longueur : " + audio.Length);
```