---
title: Gérer l'audio dans les présentations avec C++
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/cpp/audio-frame/
keywords:
- audio
- cadre audio
- miniature
- ajouter audio
- propriétés audio
- options audio
- extraire audio
- C++
- Aspose.Slides
description: "Créer et contrôler les cadres audio dans Aspose.Slides pour C++ — exemples de code pour incorporer, rogner, boucler et configurer la lecture dans les présentations PPT, PPTX et ODP."
---

## **Créer des cadres audio**

Aspose.Slides for C++ vous permet d’ajouter des fichiers audio aux diapositives. Les fichiers audio sont incorporés dans les diapositives sous forme de cadres audio. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d’une diapositive via son indice.
3. Chargez le flux du fichier audio que vous souhaitez incorporer dans la diapositive.
4. Ajoutez le cadre audio incorporé (contenant le fichier audio) à la diapositive.
5. Définissez le [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) et `Volume` exposés par l’objet [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame).
6. Enregistrez la présentation modifiée.

Ce code C++ montre comment ajouter un cadre audio incorporé à une diapositive :
``` cpp
// Instancie une classe Presentation qui représente un fichier de présentation
auto pres = System::MakeObject<Presentation>();

// Obtient la première diapositive
auto sld = pres->get_Slides()->idx_get(0);

// Charge le fichier son wav dans un flux
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Ajoute le cadre audio
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Définit le mode de lecture et le volume de l'audio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Écrit le fichier PowerPoint sur le disque
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```


## **Modifier la miniature du cadre audio**

Lorsque vous ajoutez un fichier audio à une présentation, l’audio apparaît sous forme de cadre avec une image par défaut standard (voir l’image dans la section ci‑dessous). Vous pouvez changer la miniature du cadre audio (définir votre image préférée).

Ce code C++ montre comment modifier la miniature ou l’image d’aperçu d’un cadre audio :
```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Ajoute un cadre audio à la diapositive avec une position et une taille spécifiées.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Ajoute une image aux ressources de la présentation.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Définit l'image pour le cadre audio.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Enregistre la présentation modifiée sur le disque
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Modifier les options de lecture audio**

Aspose.Slides for C++ vous permet de modifier les options qui contrôlent la lecture ou les propriétés d’un audio. Par exemple, vous pouvez régler le volume, définir la lecture en boucle ou même masquer l’icône audio.

Le volet **Audio Options** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Options **Audio** de PowerPoint correspondant aux méthodes Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) :

- **Start** liste déroulante correspond à la méthode [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playmode/)
- **Volume** correspond à la méthode [AudioFrame::set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volume/)
- **Play Across Slides** correspond à la méthode [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playacrossslides/)
- **Loop until Stopped** correspond à la méthode [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playloopmode/)
- **Hide During Show** correspond à la méthode [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_hideatshowing/)
- **Rewind after Playing** correspond à la méthode [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_rewindaudio/)

Options d’**édition** de PowerPoint correspondant aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) :

- **Fade In** correspond à la méthode [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeinduration/)
- **Fade Out** correspond à la méthode [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeoutduration/)
- **Trim Audio Start Time** correspond à la méthode [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromstart/)
- **Trim Audio End Time** la valeur correspond à la durée de l’audio moins la valeur de la méthode [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromend/)

Le **contrôle du volume** de PowerPoint sur le panneau de contrôle audio correspond à la méthode [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volumevalue/). Il vous permet de modifier le volume de l’audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Créer](#creating-audio-frame) ou récupérez le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code C++ montre une opération où les options d’un audio sont ajustées :
``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Récupère une forme
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Convertit la forme en forme AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Définit le mode de lecture sur lecture au clic
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Définit le volume sur Bas
audioFrame->set_Volume(AudioVolumeMode::Low);

// Définit l'audio pour lire sur toutes les diapositives
audioFrame->set_PlayAcrossSlides(true);

// Désactive la boucle pour l'audio
audioFrame->set_PlayLoopMode(false);

// Masque le AudioFrame pendant le diaporama
audioFrame->set_HideAtShowing(true);

// Rembobine l'audio au début après la lecture
audioFrame->set_RewindAudio(true);

// Enregistre le fichier PowerPoint sur le disque
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```


Cet exemple C++ montre comment ajouter un nouveau cadre audio avec audio incorporé, le rogner et définir les durées de fondu :
```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


L’exemple de code suivant montre comment récupérer un cadre audio incorporé et régler son volume à 85 % :
```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Récupère une forme de cadre audio
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Définit le volume audio à 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


## **Extraire l'audio**
Aspose.Slides vous permet d’extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation contenant l’audio.
2. Obtenez la référence de la diapositive concernée via son indice.
3. Accédez aux transitions de diaporama de la diapositive.
4. Extrayez le son sous forme de données octetées.

Ce code C++ montre comment extraire l’audio utilisé dans une diapositive :
``` cpp
String presName = u"AudioSlide.pptx";

// Crée une instance de la classe Presentation qui représente un fichier de présentation
auto pres = System::MakeObject<Presentation>(presName);

// Accède à la diapositive souhaitée
auto slide = pres->get_Slides()->idx_get(0);

// Obtient les effets de transition du diaporama pour la diapositive
auto transition = slide->get_SlideShowTransition();

// Extrait le son sous forme de tableau d'octets
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```


## **FAQ**

**Puis‑je réutiliser le même fichier audio sur plusieurs diapositives sans augmenter la taille du fichier ?**

Oui. Ajoutez l’audio une fois à la [collection audio partagée](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) de la présentation et créez des cadres audio supplémentaires qui référencent cet actif existant. Cela évite la duplication des données multimédia et maintient la taille de la présentation sous contrôle.

**Puis‑je remplacer le son d’un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [chemin du lien](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_linkpathlong/) pour qu’il pointe vers le nouveau fichier. Pour un son incorporé, échangez l’objet [embedded audio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_embeddedaudio/) avec un autre provenant de la [collection audio](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) de la présentation. Le format du cadre et la plupart des paramètres de lecture restent intacts.

**Le rognage modifie‑t‑il les données audio sous‑jacentes stockées dans la présentation ?**

Non. Le rognage ne fait qu’ajuster les limites de lecture. Les octets audio originaux restent intacts et accessibles via l’audio incorporé ou la collection audio de la présentation.