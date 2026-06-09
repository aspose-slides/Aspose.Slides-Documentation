---
title: Gerenciar quadros de áudio em apresentações no .NET
linktitle: Quadro de Áudio
type: docs
weight: 10
url: /pt/net/audio-frame/
keywords:
- áudio
- quadro de áudio
- miniatura
- adicionar áudio
- propriedades de áudio
- opções de áudio
- extrair áudio
- .NET
- C#
- Aspose.Slides
description: "Crie e controle quadros de áudio no Aspose.Slides para .NET—exemplos C# para incorporar, cortar, reproduzir em loop e configurar a reprodução em apresentações PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica como trabalhar com quadros de áudio no Aspose.Slides. Ele mostra como adicionar áudio incorporado aos slides, personalizar a miniatura do quadro de áudio, configurar opções de reprodução como volume, reprodução em loop, ocultação, corte e durações de fade, e extrair o áudio usado nas transições de apresentação de slides.

## **Criar quadros de áudio**

Aspose.Slides for .NET permite que você adicione arquivos de áudio aos slides. Os arquivos de áudio são incorporados nos slides como quadros de áudio. 

1. Crie uma instância da classe [Presentation ](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation)class.
2. Obtenha a referência de um slide através do seu índice.
3. Carregue o fluxo do arquivo de áudio que você deseja incorporar no slide.
4. Adicione o quadro de áudio incorporado (contendo o arquivo de áudio) ao slide.
5. Defina o [PlayMode](https://reference.aspose.com/slides/pt/net/aspose.slides/audioplaymodepreset) e `Volume` expostos pelo objeto [IAudioFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe).
6. Salve a apresentação modificada.

Este código C# mostra como adicionar um quadro de áudio incorporado a um slide:

```c#
 // Instancia uma classe de apresentação que representa um arquivo de apresentação
using (Presentation pres = new Presentation())
{
    // Obtém o primeiro slide
    ISlide sld = pres.Slides[0];
    
    // Carrega o arquivo de som wav para o fluxo
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Adiciona o Quadro de Áudio
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Define o Modo de Reprodução e o Volume do Áudio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Grava o arquivo PowerPoint no disco
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Alterar a miniatura do quadro de áudio**

Quando você adiciona um arquivo de áudio a uma apresentação, o áudio aparece como um quadro com uma imagem padrão padrão (veja a imagem na seção abaixo). Você pode mudar a miniatura do quadro de áudio (definir sua imagem preferida).

Este código C# mostra como alterar a miniatura ou a imagem de visualização de um quadro de áudio:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Adiciona um quadro de áudio ao slide com posição e tamanho especificados.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Adiciona uma imagem aos recursos da apresentação.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Define a imagem para o quadro de áudio.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----

	//Salva a apresentação modificada no disco
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Alterar opções de reprodução de áudio**

Aspose.Slides for .NET permite que você altere opções que controlam a reprodução ou propriedades de um áudio. Por exemplo, você pode ajustar o volume de um áudio, definir a reprodução em loop ou até ocultar o ícone de áudio.

O painel **Opções de áudio** no Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opções de **Áudio** do PowerPoint que correspondem às propriedades Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe):

- **Iniciar** menu suspenso corresponde à propriedade [AudioFrame.PlayMode](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/properties/playmode)
- **Volume** corresponde à propriedade [AudioFrame.Volume](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/properties/volume)
- **Reproduzir em todos os slides** corresponde à propriedade [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/properties/playacrossslides)
- **Loop até parar** corresponde à propriedade [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/properties/playloopmode)
- **Ocultar durante a exibição** corresponde à  [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/properties/hideatshowing)
- **Retroceder após reproduzir** corresponde à [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/properties/rewindaudio)

Opções de **Edição** do PowerPoint que correspondem às propriedades Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe):

- **Desvanecer entrada** corresponde à propriedade [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/fadeinduration/) 
- **Desvanecer saída** corresponde à propriedade [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/fadeoutduration/) 
- **Ajustar início do áudio** corresponde à propriedade [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/trimfromstart/) 
- **Ajustar tempo final do áudio** valor equivale à duração do áudio menos o valor da propriedade [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/trimfromend/) property

O **controle de volume** do PowerPoint no painel de controle de áudio corresponde à propriedade [AudioFrame.VolumeValue](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/volumevalue/) . Ele permite alterar o volume do áudio como porcentagem.

É assim que você altera as opções de reprodução de áudio:

1. [Сreate](#create-audio-frame) ou obtenha o Quadro de Áudio.
2. Defina novos valores para as propriedades do Quadro de Áudio que você deseja ajustar.
3. Salve o arquivo PowerPoint modificado.

Este código C# demonstra uma operação na qual as opções de um áudio são ajustadas:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Obtém a forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Define o modo de reprodução para tocar ao clicar
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Define o volume para Baixo
    audioFrame.Volume = AudioVolumeMode.Low;

    // Define o áudio para reproduzir nos slides
    audioFrame.PlayAcrossSlides = true;

    // Desabilita o loop para o áudio
    audioFrame.PlayLoopMode = false;

    // Oculta o AudioFrame durante a apresentação de slides
    audioFrame.HideAtShowing = true;

    // Retrocede o áudio ao início após a reprodução
    audioFrame.RewindAudio = true;

    // Salva o arquivo PowerPoint no disco
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Este exemplo C# mostra como adicionar um novo quadro de áudio com áudio incorporado, cortá‑lo e definir as durações de fade:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Define o deslocamento inicial de corte para 1,5 segundos
    audioFrame.TrimFromStart = 1500f;
    // Define o deslocamento final de corte para 2 segundos
    audioFrame.TrimFromEnd = 2000f;

    // Define a duração do fade-in para 200 ms
    audioFrame.FadeInDuration = 200f;
    // Define a duração do fade-out para 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

O código a seguir mostra como recuperar um quadro de áudio incorporado e definir seu volume para 85 %:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Obtém uma forma de quadro de áudio
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Define o volume do áudio para 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Gerenciar legendas de áudio**

Aspose.Slides permite que você adicione legendas fechadas a um quadro de áudio por meio da propriedade [CaptionTracks](https://reference.aspose.com/slides/pt/net/aspose.slides/iaudioframe/captiontracks/) . Essa propriedade devolve um [ICaptionsCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/icaptionscollection/) , que permite adicionar faixas de legenda WebVTT, percorrer faixas existentes e removê‑las quando necessário.

**Adicionar legendas de áudio**

Use a propriedade [CaptionTracks](https://reference.aspose.com/slides/pt/net/aspose.slides/iaudioframe/captiontracks/) para anexar uma ou mais faixas de legenda a um quadro de áudio. No exemplo a seguir, um arquivo de áudio é adicionado a um slide e, em seguida, uma nova faixa de legenda é carregada a partir de um arquivo `.vtt`.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Adiciona uma nova faixa de legenda a partir de um arquivo WebVTT.
    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Extrair legendas de áudio**

Você pode percorrer as faixas de legenda associadas a um quadro de áudio e salvá‑las como arquivos `.vtt`. Cada faixa de legenda expõe seus dados binários e identificador exclusivo, que podem ser usados ao exportar legendas.

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
                // Salve a faixa de legenda como um arquivo .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Remover legendas de áudio**

Para remover legendas de um quadro de áudio, use os métodos fornecidos por [ICaptionsCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/icaptionscollection/) , como [Clear](https://reference.aspose.com/slides/pt/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/pt/net/aspose.slides/icaptionscollection/remove/), ou [RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides/icaptionscollection/removeat/). O exemplo a seguir remove todas as faixas de legenda de um quadro de áudio.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Remove todas as faixas de legenda do quadro de áudio.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Extrair áudio**
Aspose.Slides for .NET permite que você extraia o som usado nas transições de apresentações de slides. Por exemplo, você pode extrair o som usado em um slide específico.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) e carregue a apresentação que contém o áudio.
2. Obtenha a referência do slide relevante através do seu índice.
3. Acesse as transições da apresentação de slides para o slide.
4. Extraia o som em dados de bytes.

Este código C# mostra como extrair o áudio usado em um slide:

```c#
string presName = "AudioSlide.pptx";

// Instancia uma classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation(presName);

// Acessa o slide
ISlide slide = pres.Slides[0];

// Obtém os efeitos de transição de apresentação de slides para o slide
ISlideShowTransition transition = slide.SlideShowTransition;

//Extrai o som em um array de bytes
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**Posso reutilizar o mesmo recurso de áudio em vários slides sem inflar o tamanho do arquivo?**

Sim. Adicione o áudio uma vez à [audio collection](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/audios/) compartilhada da apresentação e crie quadros de áudio adicionais que referenciem esse recurso existente. Isso evita duplicar os dados de mídia e mantém o tamanho da apresentação sob controle.

**Posso substituir o som em um quadro de áudio existente sem recriar a forma?**

Sim. Para um som vinculado, atualize o [link path](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/linkpathlong/) para apontar para o novo arquivo. Para um som incorporado, troque o objeto [embedded audio](https://reference.aspose.com/slides/pt/net/aspose.slides/audioframe/embeddedaudio/) por outro da [audio collection](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/audios/) da apresentação. A formatação do quadro e a maioria das configurações de reprodução permanecem intactas.

**A edição altera os dados de áudio subjacentes armazenados na apresentação?**

Não. O trim ajusta apenas os limites de reprodução. Os bytes originais do áudio permanecem intactos e acessíveis através do áudio incorporado ou da coleção de áudio da apresentação.