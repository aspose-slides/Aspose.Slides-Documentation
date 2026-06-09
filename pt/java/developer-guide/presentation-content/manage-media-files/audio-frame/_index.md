---
title: Gerenciar áudio em apresentações usando Java
linktitle: Quadro de áudio
type: docs
weight: 10
url: /pt/java/audio-frame/
keywords:
- áudio
- quadro de áudio
- miniatura
- adicionar áudio
- propriedades de áudio
- opções de áudio
- extrair áudio
- Java
- Aspose.Slides
description: "Crie e controle quadros de áudio no Aspose.Slides for Java—exemplos de código para incorporar, cortar, repetir e configurar a reprodução em apresentações PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica como trabalhar com quadros de áudio no Aspose.Slides. Ele mostra como adicionar áudio incorporado aos slides, personalizar a miniatura do quadro de áudio, configurar opções de reprodução como volume, repetição, ocultação, corte e durações de fade, e extrair áudio usado nas transições de apresentação de slides.

## **Criar quadros de áudio**

Aspose.Slides for Java permite adicionar arquivos de áudio aos slides. Os arquivos de áudio são incorporados nos slides como quadros de áudio. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Obtenha a referência de um slide através do seu índice.
3. Carregue o fluxo do arquivo de áudio que deseja incorporar no slide.
4. Adicione o quadro de áudio incorporado (contendo o arquivo de áudio) ao slide.
5. Defina [PlayMode](https://reference.aspose.com/slides/pt/java/com.aspose.slides/AudioPlayModePreset) e `Volume` expostos pelo objeto [IAudioFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IAudioFrame).
6. Salve a apresentação modificada.

Este código Java mostra como adicionar um quadro de áudio incorporado a um slide:

```java
// Instancia a classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation();
try {
    // Obtém o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Carrega o arquivo de áudio wav para o fluxo
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

Quando você adiciona um arquivo de áudio a uma apresentação, o áudio aparece como um quadro com uma imagem padrão (veja a imagem na seção abaixo). Você pode alterar a imagem de visualização do quadro de áudio (defina a imagem de sua preferência).

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

Aspose.Slides for Java permite alterar opções que controlam a reprodução ou propriedades de um áudio. Por exemplo, é possível ajustar o volume do áudio, definir a reprodução em loop ou até ocultar o ícone de áudio.

O painel **Audio Options** no Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opções de áudio do PowerPoint que correspondem às propriedades do Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/AudioFrame) :

- **Início** da lista suspensa corresponde ao método [AudioFrame.setPlayMode](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** corresponde ao método [AudioFrame.setVolume](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Reproduzir em todos os slides** corresponde ao método [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Loop até parar** corresponde ao método [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Ocultar durante a exibição** corresponde ao método [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Retroceder após reproduzir** corresponde ao método [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

Opções de **Edição** do PowerPoint que correspondem às propriedades do Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/AudioFrame) :

- **Fade In** corresponde ao método [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)
- **Fade Out** corresponde ao método [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)
- **Cortar início do áudio** corresponde ao método [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)
- **Cortar fim do áudio** tem valor igual à duração do áudio menos o valor do método [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

O **controle de volume** do PowerPoint no painel de controle de áudio corresponde ao método [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/pt/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Ele permite alterar o volume do áudio como porcentagem.

Veja como alterar as opções de reprodução de áudio:

1. [Criar](#create-audio-frame) ou obtenha o quadro de áudio.
2. Defina novos valores para as propriedades do quadro de áudio que deseja ajustar.
3. Salve o arquivo PowerPoint modificado.

Este código Java demonstra uma operação na qual as opções de um áudio são ajustadas:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtém a forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Define o modo de reprodução para reproduzir ao clicar
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Define o volume para Baixo
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Define o áudio para reproduzir em todos os slides
    audioFrame.setPlayAcrossSlides(true);

    // Desativa o loop para o áudio
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

Este exemplo Java mostra como adicionar um novo quadro de áudio com áudio incorporado, cortá-lo e definir as durações de fade:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Define o deslocamento inicial do corte para 1,5 segundos
    audioFrame.setTrimFromStart(1500f);
    // Define o deslocamento final do corte para 2 segundos
    audioFrame.setTrimFromEnd(2000f);

    // Define a duração do fade-in para 200 ms
    audioFrame.setFadeInDuration(200f);
    // Define a duração do fade-out para 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

O exemplo de código a seguir mostra como recuperar um quadro de áudio com áudio incorporado e definir seu volume para 85%:

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

Aspose.Slides permite adicionar legendas ocultas a um quadro de áudio através do método [getCaptionTracks](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Esse método retorna uma [ICaptionsCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/), que permite adicionar faixas de legenda WebVTT, iterar pelas faixas existentes e removê‑las quando necessário.

**Adicionar legendas de áudio**

Use o método [getCaptionTracks](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) para anexar uma ou mais faixas de legenda a um quadro de áudio. No exemplo a seguir, um arquivo de áudio é adicionado a um slide e, em seguida, uma nova faixa de legenda é carregada a partir de um arquivo `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Adiciona uma nova faixa de legenda de um arquivo WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extrair legendas de áudio**

É possível iterar pelas faixas de legenda associadas a um quadro de áudio e salvá‑las como arquivos `.vtt`. Cada faixa de legenda expõe seus dados binários e identificador exclusivo, que podem ser usados ao exportar as legendas.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Salve a faixa de legenda como um arquivo .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Remover legendas de áudio**

Para remover legendas de um quadro de áudio, use os métodos fornecidos pela [ICaptionsCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/), como [clear](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), ou [removeAt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/#removeAt-int-). O exemplo a seguir remove todas as faixas de legenda de um quadro de áudio.

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

Aspose.Slides for Java permite extrair o som usado nas transições de apresentação de slides. Por exemplo, você pode extrair o som usado em um slide específico.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) e carregue a apresentação que contém o áudio.
2. Obtenha a referência do slide relevante através do seu índice.
3. Acesse as [slideshow transitions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) do slide.
4. Extraia o som em dados binários.

Este código Java mostra como extrair o áudio usado em um slide:

```java
// Instancia uma classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Acessa o slide desejado
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Obtém os efeitos de transição de apresentação de slides para o slide
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extrai o som em array de bytes
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas frequentes**

**Posso reutilizar o mesmo recurso de áudio em vários slides sem inflar o tamanho do arquivo?**

Sim. Adicione o áudio uma vez à coleção de áudio compartilhada da apresentação e crie quadros de áudio adicionais que referenciam esse recurso existente. Isso evita a duplicação dos dados de mídia e mantém o tamanho da apresentação sob controle.

**Posso substituir o som em um quadro de áudio existente sem recriar a forma?**

Sim. Para um som vinculado, atualize o caminho de link ([link path](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-)) para apontar para o novo arquivo. Para um som incorporado, troque o áudio incorporado ([embedded audio](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-)) por outro da coleção de áudio da apresentação. A formatação do quadro e a maioria das configurações de reprodução permanecem intactas.

**O corte altera os dados de áudio subjacentes armazenados na apresentação?**

Não. O corte ajusta apenas os limites de reprodução. Os bytes originais do áudio permanecem inalterados e acessíveis através do áudio incorporado ou da coleção de áudio da apresentação.