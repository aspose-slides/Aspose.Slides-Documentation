---
title: Gerenciar áudio em apresentações usando C++
linktitle: Quadro de Áudio
type: docs
weight: 10
url: /pt/cpp/audio-frame/
keywords:
- áudio
- quadro de áudio
- miniatura
- adicionar áudio
- propriedades de áudio
- opções de áudio
- extrair áudio
- C++
- Aspose.Slides
description: "Criar e controlar quadros de áudio no Aspose.Slides para C++ — exemplos de código para incorporar, cortar, reproduzir em loop e configurar a reprodução em apresentações PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica como trabalhar com quadros de áudio no Aspose.Slides. Ele mostra como adicionar áudio incorporado aos slides, personalizar a miniatura do quadro de áudio, configurar opções de reprodução como volume, repetição, ocultação, corte e durações de fade, e extrair o áudio usado nas transições de apresentação de slides.

## **Criar quadros de áudio**

Aspose.Slides para C++ permite adicionar arquivos de áudio aos slides. Os arquivos de áudio são incorporados nos slides como quadros de áudio. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
2. Obtenha a referência de um slide por meio do seu índice.
3. Carregue o fluxo do arquivo de áudio que você deseja incorporar no slide.
4. Adicione o quadro de áudio incorporado (contendo o arquivo de áudio) ao slide.
5. Defina [PlayMode](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) e `Volume` expostos pelo objeto [IAudioFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_audio_frame).
6. Salve a apresentação modificada.

Este código C++ mostra como adicionar um quadro de áudio incorporado a um slide:

``` cpp
// Instancia uma classe Presentation que representa um arquivo de apresentação
auto pres = System::MakeObject<Presentation>();

// Obtém o primeiro slide
auto sld = pres->get_Slides()->idx_get(0);

// Carrega o arquivo de áudio wav para o stream
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Adiciona o Quadro de Áudio
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Define o modo de reprodução e o volume do áudio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Grava o arquivo PowerPoint no disco
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Alterar a miniatura do quadro de áudio**

Quando você adiciona um arquivo de áudio a uma apresentação, o áudio aparece como um quadro com uma imagem padrão (veja a imagem na seção abaixo). Você pode alterar a miniatura do quadro de áudio (definir a imagem de sua preferência).

Este código C++ mostra como alterar a miniatura ou a imagem de visualização de um quadro de áudio:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Adiciona um quadro de áudio ao slide com posição e tamanho especificados.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Adiciona uma imagem aos recursos da apresentação.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Define a imagem para o quadro de áudio.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Salva a apresentação modificada no disco
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Alterar opções de reprodução de áudio**

Aspose.Slides para C++ permite alterar opções que controlam a reprodução ou propriedades de um áudio. Por exemplo, você pode ajustar o volume de um áudio, definir que o áudio seja reproduzido em loop ou até ocultar o ícone do áudio.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/) methods:

- **Start** drop-down list matches the [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_playmode/) method 
- **Volume** matches the [AudioFrame::set_Volume](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_volume/) method 
- **Play Across Slides** matches the [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_playacrossslides/) method 
- **Loop until Stopped** matches the [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_playloopmode/) method 
- **Hide During Show** matches the  [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_hideatshowing/) method 
- **Rewind after Playing** matches the [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_rewindaudio/) method 

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/) properties:

- **Fade In** matches the [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_fadeinduration/) method
- **Fade Out** matches the [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_fadeoutduration/) method
- **Trim Audio Start Time** matches the [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_trimfromstart/) method
- **Trim Audio End Time** value equals the audio duration minus the value of [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_trimfromend/) method

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_volumevalue/) method. It lets you change the audio volume as a percentage.

Veja como alterar as opções de reprodução de áudio:

1. [Crie](#creating-audio-frame) ou obtenha o Quadro de Áudio.
2. Defina novos valores para as propriedades do quadro de áudio que você deseja ajustar.
3. Salve o arquivo PowerPoint modificado.

Este código C++ demonstra uma operação na qual as opções de um áudio são ajustadas:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Obtém uma forma
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Converte a forma para um AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Define o modo de reprodução para tocar ao clicar
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Define o volume como Baixo
audioFrame->set_Volume(AudioVolumeMode::Low);

// Define que o áudio será reproduzido em todos os slides
audioFrame->set_PlayAcrossSlides(true);

// Desabilita o loop para o áudio
audioFrame->set_PlayLoopMode(false);

// Oculta o AudioFrame durante a apresentação
audioFrame->set_HideAtShowing(true);

// Rebobina o áudio para o início após a reprodução
audioFrame->set_RewindAudio(true);

// Salva o arquivo PowerPoint no disco
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Este exemplo C++ mostra como adicionar um novo quadro de áudio com áudio incorporado, recortá‑lo e definir as durações de fade:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Define o deslocamento de início do corte para 1,5 segundos
audioFrame->set_TrimFromStart(1500);
// Define o deslocamento de fim do corte para 2 segundos
audioFrame->set_TrimFromEnd(2000);

// Define a duração do fade-in para 200 ms
audioFrame->set_FadeInDuration(200);
// Define a duração do fade-out para 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

O exemplo de código a seguir mostra como recuperar um quadro de áudio com áudio incorporado e definir seu volume para 85%:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Obtém uma forma de quadro de áudio
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Define o volume do áudio para 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Gerenciar legendas de áudio**

Aspose.Slides permite adicionar legendas fechadas a um quadro de áudio através do método [get_CaptionTracks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iaudioframe/get_captiontracks/). Esse método retorna um [ICaptionsCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptionscollection/), que permite adicionar faixas de legenda WebVTT, iterar pelas faixas existentes e removê‑las quando necessário.

### **Adicionar legendas de áudio**

Use o método [get_CaptionTracks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iaudioframe/get_captiontracks/) para anexar uma ou mais faixas de legenda a um quadro de áudio. No exemplo a seguir, um arquivo de áudio é adicionado a um slide e, em seguida, uma nova faixa de legenda é carregada a partir de um arquivo `.vtt`.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Adiciona uma nova faixa de legenda a partir de um arquivo WebVTT.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Extrair legendas de áudio**

Você pode iterar pelas faixas de legenda associadas a um quadro de áudio e salvá‑las como arquivos `.vtt`. Cada faixa de legenda expõe seus dados binários e identificador exclusivo, que podem ser usados ao exportar legendas.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Salvar cada faixa de legenda como um arquivo .vtt.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

### **Remover legendas de áudio**

Para remover legendas de um quadro de áudio, use os métodos fornecidos por [ICaptionsCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptionscollection/), como [Clear](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptionscollection/remove/), ou [RemoveAt](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptionscollection/removeat/). O exemplo a seguir remove todas as faixas de legenda de um quadro de áudio.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Remover todas as faixas de legenda do quadro de áudio.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extrair áudio**
Aspose.Slides permite extrair o som usado nas transições da apresentação de slides. Por exemplo, você pode extrair o som usado em um slide específico.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) e carregue a apresentação que contém o áudio.
2. Obtenha a referência do slide relevante por meio do seu índice.
3. Acesse as transições de apresentação de slides para o slide.
4. Extraia o som em dados binários.

Este código C++ mostra como extrair o áudio usado em um slide:

``` cpp
String presName = u"AudioSlide.pptx";

// Instancia uma classe Presentation que representa um arquivo de apresentação
auto pres = System::MakeObject<Presentation>(presName);

// Acessa o slide desejado
auto slide = pres->get_Slides()->idx_get(0);

// Obtém os efeitos de transição de apresentação de slides para o slide
auto transition = slide->get_SlideShowTransition();

// Extrai o som em um array de bytes
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**Posso reutilizar o mesmo recurso de áudio em vários slides sem aumentar o tamanho do arquivo?**

Sim. Adicione o áudio uma vez à [coleção de áudio compartilhada](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_audios/) da apresentação e crie quadros de áudio adicionais que referenciem esse recurso existente. Isso evita duplicar os dados de mídia e mantém o tamanho da apresentação sob controle.

**Posso substituir o som em um quadro de áudio existente sem recriar a forma?**

Sim. Para um som vinculado, atualize o [link path](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_linkpathlong/) para apontar para o novo arquivo. Para um som incorporado, troque o objeto [embedded audio](https://reference.aspose.com/slides/pt/cpp/aspose.slides/audioframe/set_embeddedaudio/) por outro da [coleção de áudio](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_audios/) da apresentação. A formatação do quadro e a maioria das configurações de reprodução permanecem intactas.

**O recorte altera os dados de áudio subjacentes armazenados na apresentação?**

Não. O recorte ajusta apenas os limites de reprodução. Os bytes originais do áudio permanecem inalterados e acessíveis através do áudio incorporado ou da coleção de áudio da apresentação.