---
title: Cadre Audio
type: docs
weight: 10
url: /fr/cpp/audio-frame/
keywords: "Ajouter de l'audio, Cadre audio, Propriétés audio, Extraire l'audio, C++, CPP, Aspose.Slides pour C++"
description: "Ajouter de l'audio à une présentation PowerPoint en C++"
---

## **Création d'un Cadre Audio**
Aspose.Slides pour C++ vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés aux diapositives sous forme de cadres audio. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez une référence à la diapositive par son index.
3. Chargez le flux de fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) et `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame).
6. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment ajouter un cadre audio intégré à une diapositive :

``` cpp
// Instancie une classe Presentation qui représente un fichier de présentation
auto pres = System::MakeObject<Presentation>();

// Obtient la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Charge le fichier audio wav dans le flux
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Ajoute le cadre audio
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Définit le mode de lecture et le volume de l'audio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Écrit le fichier PowerPoint sur le disque
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Changer la Miniature du Cadre Audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous forme de cadre avec une image par défaut standard (voir l'image dans la section ci-dessous). Vous pouvez changer la miniature du cadre audio (définir votre image préférée).

Ce code C++ vous montre comment changer la miniature ou l'image de prévisualisation d'un cadre audio :

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Ajoute un cadre audio à la diapositive avec une position et une taille spécifiées.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Ajoute une image aux ressources de présentation.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Définit l'image pour le cadre audio.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// Sauvegarde la présentation modifiée sur le disque
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Changer les Options de Lecture Audio**

Aspose.Slides pour C++ vous permet de changer les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, définir l'audio pour jouer en boucle, ou même cacher l'icône audio.

Le panneau **Options Audio** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Les options audio PowerPoint qui correspondent aux méthodes [AudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame) d'Aspose.Slides :
- La liste déroulante **Démarrer** des options audio correspond à la méthode [AudioFrame::get_PlayMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a5379c1a9c1166234d674b32413215a2b) 
- Le **Volume** des options audio correspond à la méthode [AudioFrame::get_Volume()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#af06a3176684b6a13326bc8526747d9f3) 
- **Jouer à travers les diapositives** correspond à la méthode [AudioFrame::get_PlayAcrossSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a3c6ffc45b319ce127384fc37e188f7b0)
- **Boucle jusqu'à arrêt** correspond à la méthode [AudioFrame::get_PlayLoopMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a99b5b9cc650e93eba813bd8b2371315b)
- **Masquer pendant le diaporama** correspond à la méthode [AudioFrame::get_HideAtShowing() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#abd008322e6a3d7d06bed527e329a9082) 
- **Rewind après lecture** correspond à la méthode [AudioFrame::get_RewindAudio() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a4900e1df6477db16e8cdd859ad54e637)

Voici comment changer les options de lecture audio :

1. [Créer](#creating-audio-frame) ou obtenir le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code C++ démontre une opération dans laquelle les options d'un audio sont ajustées :

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Obtient une forme
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Cast la forme en forme AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Définit le mode de lecture pour jouer au clic
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Définit le volume à Bas
audioFrame->set_Volume(AudioVolumeMode::Low);

// Définit l'audio pour jouer à travers les diapositives
audioFrame->set_PlayAcrossSlides(true);

// Désactive la boucle pour l'audio
audioFrame->set_PlayLoopMode(false);

// Masque le Cadre Audio pendant le diaporama
audioFrame->set_HideAtShowing(true);

// Rembobine l'audio pour recommencer après lecture
audioFrame->set_RewindAudio(true);

// Sauvegarde le fichier PowerPoint sur le disque
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

## **Extraire l'Audio**
Aspose.Slides pour .NET vous permet d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation contenant l'audio.
2. Obtenez une référence à la diapositive pertinente par son index.
3. Accédez aux transitions de diaporama pour la diapositive.
4. Extrayez le son dans des données d'octets.

Ce code C++ vous montre comment extraire l'audio utilisé dans une diapositive :

``` cpp
String presName = u"AudioSlide.pptx";

// Instancie une classe Presentation qui représente un fichier de présentation
auto pres = System::MakeObject<Presentation>(presName);

// Accède à la diapositive souhaitée
auto slide = pres->get_Slides()->idx_get(0);

// Obtient les effets de transition de diaporama pour la diapositive
auto transition = slide->get_SlideShowTransition();

// Extrait le son dans un tableau d'octets
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Longueur : ") + audio->get_Length());
```