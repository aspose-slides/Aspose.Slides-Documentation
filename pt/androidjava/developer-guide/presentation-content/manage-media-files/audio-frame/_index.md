---
title: Gerenciar áudio em apresentações no Android
linktitle: Quadro de áudio
type: docs
weight: 10
url: /pt/androidjava/audio-frame/
keywords:
- áudio
- quadro de áudio
- miniatura
- adicionar áudio
- propriedades de áudio
- opções de áudio
- extrair áudio
- Android
- Java
- Aspose.Slides
description: "Crie e controle quadros de áudio no Aspose.Slides para Android—exemplos em Java para incorporar, cortar, reproduzir em loop e configurar a reprodução em apresentações PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica como trabalhar com quadros de áudio no Aspose.Slides. Ele mostra como adicionar áudio incorporado aos slides, personalizar a miniatura do quadro de áudio, configurar opções de reprodução como volume, reprodução em loop, ocultação, corte e durações de fade, e extrair o áudio usado nas transições de apresentação de slides.

## **Criar quadros de áudio**
Aspose.Slides for Android via Java permite que você adicione arquivos de áudio aos slides. Os arquivos de áudio são incorporados nos slides como quadros de áudio.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2. Obtenha a referência de um slide através do seu índice.
3. Carregue o fluxo do arquivo de áudio que deseja incorporar no slide.
4. Adicione o quadro de áudio incorporado (contendo o arquivo de áudio) ao slide.
5. Defina [PlayMode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/AudioPlayModePreset) e `Volume` expostos pelo objeto [IAudioFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAudioFrame).
6. Salve a apresentação modificada.

Este código Java mostra como adicionar um quadro de áudio incorporado a um slide:

```java
// Instancia uma classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation();
try {
    // Obtém o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Carrega o arquivo de som wav para o fluxo
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Adiciona o Quadro de Áudio
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Define o modo de reprodução e o volume do áudio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Grava o arquivo PowerPoint no disco
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alterar a miniatura do quadro de áudio**

Ao adicionar um arquivo de áudio a uma apresentação, o áudio aparece como um quadro com uma imagem padrão (veja a imagem na seção abaixo). Você pode alterar a imagem de visualização do quadro de áudio (defina sua imagem preferida).

Este código Java mostra como alterar a miniatura ou imagem de visualização de um quadro de áudio:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adiciona um quadro de áudio ao slide com posição e tamanho especificados.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Adiciona uma imagem aos recursos da apresentação.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Define a imagem para o quadro de áudio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Salva a apresentação modificada no disco
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Alterar opções de reprodução de áudio**

Aspose.Slides for Android via Java permite que você altere opções que controlam a reprodução ou as propriedades de um áudio. Por exemplo, é possível ajustar o volume do áudio, definir a reprodução em loop ou até ocultar o ícone do áudio.

O painel **Audio Options** no Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opções de áudio do PowerPoint que correspondem às propriedades do Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/AudioFrame):

- **Início** lista suspensa corresponde à propriedade [AudioFrame.PlayMode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/AudioFrame#getPlayMode--)
- **Volume** corresponde à propriedade [AudioFrame.Volume](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/AudioFrame#getVolume--)
- **Reproduzir entre slides** corresponde à propriedade [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--)
- **Loop até ser interrompido** corresponde à propriedade [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--)
- **Ocultar durante a apresentação** corresponde à propriedade [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--)
- **Retroceder após a reprodução** corresponde à propriedade [AudioFrame.RewindAudio](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--)

Opções de **Edição** do PowerPoint que correspondem às propriedades do Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/audioframe/):

- **Fade In** corresponde à propriedade [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--)
- **Fade Out** corresponde à propriedade [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--)
- **Cortar início do áudio** corresponde à propriedade [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--)
- **Cortar fim do áudio** valor é igual à duração do áudio menos o valor da propriedade [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--)

O **controle de volume** do PowerPoint no painel de controle de áudio corresponde à propriedade [AudioFrame.VolumeValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/audioframe/#getVolumeValue--). Ele permite alterar o volume do áudio como porcentagem.

Veja como alterar as opções de reprodução de áudio:

1. [Create](#create-audio-frame) ou obtenha o Quadro de Áudio.
2. Defina novos valores para as propriedades do Quadro de Áudio que deseja ajustar.
3. Salve o arquivo PowerPoint modificado.

Este código Java demonstra uma operação em que as opções de um áudio são ajustadas:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtém a forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Define o modo de reprodução para reproduzir ao clicar
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Define o volume para Baixo
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Define o áudio para reproduzir entre slides
    audioFrame.setPlayAcrossSlides(true);

    // Desabilita o loop para o áudio
    audioFrame.setPlayLoopMode(false);

    // Oculta o AudioFrame durante a apresentação
    audioFrame.setHideAtShowing(true);

    // Rebobina o áudio para o início após a reprodução
    audioFrame.setRewindAudio(true);

    // Salva o arquivo PowerPoint no disco
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este exemplo Java mostra como adicionar um novo quadro de áudio com áudio incorporado, cortá‑lo e definir as durações de fade:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Define o deslocamento inicial de corte para 1,5 segundos
    audioFrame.setTrimFromStart(1500f);
    // Define o deslocamento final de corte para 2 segundos
    audioFrame.setTrimFromEnd(2000f);

    // Define a duração de fade-in para 200 ms
    audioFrame.setFadeInDuration(200f);
    // Define a duração de fade-out para 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

O exemplo de código a seguir mostra como recuperar um quadro de áudio com áudio incorporado e definir seu volume em 85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Obtém uma forma de quadro de áudio
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Define o volume do áudio para 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Gerenciar legendas de áudio**

Aspose.Slides permite que você adicione legendas fechadas a um quadro de áudio por meio do método [getCaptionTracks](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Esse método devolve uma [ICaptionsCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icaptionscollection/), que permite adicionar faixas de legenda WebVTT, percorrer as faixas existentes e removê‑las quando necessário.

### **Adicionar legendas de áudio**

Use o método [getCaptionTracks](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) para anexar uma ou mais faixas de legenda a um quadro de áudio. No exemplo a seguir, um arquivo de áudio é adicionado a um slide e depois uma nova faixa de legenda é carregada a partir de um arquivo `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Adiciona uma nova faixa de legenda a partir de um arquivo WebVTT.
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Extrair legendas de áudio**

Você pode percorrer as faixas de legenda associadas a um quadro de áudio e salvá‑las como arquivos `.vtt`. Cada faixa de legenda expõe seus dados binários e identificador único, que podem ser usados ao exportar as legendas.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Salve a faixa de legenda como um arquivo .vtt.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

### **Remover legendas de áudio**

Para remover legendas de um quadro de áudio, use os métodos fornecidos por [ICaptionsCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icaptionscollection/), como [clear](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), ou [removeAt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). O exemplo a seguir remove todas as faixas de legenda de um quadro de áudio.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Remove todas as faixas de legenda do quadro de áudio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrair áudio**

Aspose.Slides for Android via Java permite que você extraia o som usado nas transições de apresentação de slides. Por exemplo, é possível extrair o som usado em um slide específico.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) e carregue a apresentação que contém o áudio.
2. Obtenha a referência do slide relevante através do seu índice.
3. Acesse as [slideshow transitions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) do slide.
4. Extraia o som em dados de bytes.

Este código Java mostra como extrair o áudio usado em um slide:

```java
// Instancia uma classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Acessa o slide desejado
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Obtém os efeitos de transição de apresentação de slides para o slide
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Extrai o som em um array de bytes
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso reutilizar o mesmo recurso de áudio em vários slides sem inflar o tamanho do arquivo?**

Sim. Adicione o áudio uma única vez à [audio collection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getAudios--) compartilhada da apresentação e crie quadros de áudio adicionais que façam referência a esse recurso existente. Isso evita a duplicação de dados de mídia e mantém o tamanho da apresentação sob controle.

**Posso substituir o som em um quadro de áudio existente sem recriar o formato?**

Sim. Para um som vinculado, atualize o [link path](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) para apontar para o novo arquivo. Para um som incorporado, troque o objeto [embedded audio](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) por outro da [audio collection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getAudios--) da apresentação. A formatação do quadro e a maioria das configurações de reprodução permanecem intactas.

**O corte altera os dados de áudio subjacentes armazenados na apresentação?**

Não. O corte ajusta apenas os limites de reprodução. Os bytes originais do áudio permanecem inalterados e acessíveis através do áudio incorporado ou da coleção de áudios da apresentação.