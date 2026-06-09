---
title: Gerenciar áudio em apresentações usando PHP
linktitle: Quadro de áudio
type: docs
weight: 10
url: /pt/php-java/audio-frame/
keywords:
- áudio
- quadro de áudio
- miniatura
- adicionar áudio
- propriedades de áudio
- opções de áudio
- extrair áudio
- PHP
- Aspose.Slides
description: "Criar e controlar quadros de áudio no Aspose.Slides for PHP—exemplos de código para incorporar, cortar, reproduzir em loop e configurar a reprodução em apresentações PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica como trabalhar com quadros de áudio no Aspose.Slides. Ele mostra como adicionar áudio incorporado aos slides, personalizar a miniatura do quadro de áudio, configurar opções de reprodução como volume, repetição, ocultação, corte e durações de fade, e extrair áudio usado em transições de apresentação de slides.

## **Criar quadros de áudio**

Aspose.Slides for PHP via Java permite que você adicione arquivos de áudio aos slides. Os arquivos de áudio são incorporados nos slides como quadros de áudio.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice.
3. Carregue o fluxo do arquivo de áudio que deseja incorporar no slide.
4. Adicione o quadro de áudio incorporado (contendo o arquivo de áudio) ao slide.
5. Defina [PlayMode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/AudioPlayModePreset) e `Volume` expostos pelo objeto [AudioFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/).
6. Salve a apresentação modificada.

Este código PHP mostra como adicionar um quadro de áudio incorporado a um slide:

```php
// Instancia uma classe Presentation que representa um arquivo de apresentação
$pres = new Presentation();
try {
    # Obtém o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Carrega o arquivo de som wav para o fluxo
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Adiciona o Quadro de Áudio
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Define o modo de reprodução e o volume do áudio
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Grava o arquivo PowerPoint no disco
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Alterar a miniatura do quadro de áudio**

Ao adicionar um arquivo de áudio a uma apresentação, o áudio aparece como um quadro com uma imagem padrão (veja a imagem na seção abaixo). Você pode alterar a imagem de visualização do quadro de áudio (definir sua imagem preferida).

Este código PHP mostra como alterar a miniatura ou imagem de visualização de um quadro de áudio:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Adiciona um quadro de áudio ao slide com posição e tamanho especificados.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Adiciona uma imagem aos recursos da apresentação.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Define a imagem para o quadro de áudio.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Salva a apresentação modificada no disco
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Alterar opções de reprodução de áudio**

Aspose.Slides for PHP via Java permite que você altere opções que controlam a reprodução ou propriedades de um áudio. Por exemplo, é possível ajustar o volume, reproduzir o áudio em loop ou até ocultar o ícone do áudio.

O painel **Opções de áudio** no Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Opções de áudio** do PowerPoint que correspondem às propriedades do Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/):

- **Iniciar** corresponde ao método [AudioFrame::setPlayMode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** corresponde ao método [AudioFrame::setVolume](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setVolume)
- **Reproduzir em todos os slides** corresponde ao método [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Repetir até interromper** corresponde ao método [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Ocultar durante a apresentação** corresponde ao método [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Retroceder após a reprodução** corresponde ao método [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setRewindAudio)

Opções de **Edição** do PowerPoint que correspondem às propriedades do Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/):

- **Fade de entrada** corresponde ao método [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade de saída** corresponde ao método [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Cortar início do áudio** corresponde ao método [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Cortar fim do áudio** tem valor igual à duração total menos o valor definido no método [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setTrimFromEnd)

O controle de **volume** no painel de áudio do PowerPoint corresponde ao método [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#setVolumeValue). Ele permite alterar o volume do áudio em porcentagem.

Assim você altera as opções de reprodução de áudio:

1. **Criar** ([Create](#create-audio-frame)) ou obter o quadro de áudio.
2. Defina novos valores para as propriedades do quadro de áudio que deseja ajustar.
3. Salve o arquivo PowerPoint modificado.

Este código PHP demonstra uma operação em que as opções de um áudio são ajustadas:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Obtém a forma AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Define o modo de reprodução para reproduzir ao clicar
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Define o volume como Baixo
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Define o áudio para reproduzir em todos os slides
    $audioFrame->setPlayAcrossSlides(true);
    # Desativa o loop para o áudio
    $audioFrame->setPlayLoopMode(false);
    # Oculta o AudioFrame durante a apresentação de slides
    $audioFrame->setHideAtShowing(true);
    # Rebobina o áudio para o início após a reprodução
    $audioFrame->setRewindAudio(true);
    # Salva o arquivo PowerPoint no disco
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Este exemplo PHP mostra como adicionar um novo quadro de áudio incorporado, recortá‑lo e definir as durações de fade:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Define o deslocamento inicial do corte para 1,5 segundos
    $audioFrame->setTrimFromStart(1500);
    // Define o deslocamento final do corte para 2 segundos
    $audioFrame->setTrimFromEnd(2000);

    // Define a duração do fade-in para 200 ms
    $audioFrame->setFadeInDuration(200);
    // Define a duração do fade-out para 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

O trecho de código a seguir mostra como recuperar um quadro de áudio incorporado e definir seu volume para 85%:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Obtém a forma do quadro de áudio
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Define o volume do áudio para 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Gerenciar legendas de áudio**

Aspose.Slides permite que você adicione legendas fechadas a um quadro de áudio através do método [getCaptionTracks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#getCaptionTracks). Esse método devolve uma [CaptionsCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captionscollection/), que permite adicionar faixas de legenda WebVTT, iterar pelas faixas existentes e removê‑las quando necessário.

**Adicionar legendas de áudio**

Use o método [getCaptionTracks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/#getCaptionTracks) para associar uma ou mais faixas de legenda a um quadro de áudio. No exemplo a seguir, um arquivo de áudio é adicionado a um slide e, em seguida, uma nova faixa de legenda é carregada de um arquivo `.vtt`.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Adiciona uma nova faixa de legenda a partir de um arquivo WebVTT.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Extrair legendas de áudio**

É possível iterar pelas faixas de legenda associadas a um quadro de áudio e salvá‑las como arquivos `.vtt`. Cada faixa de legenda expõe seus dados binários e identificador único, que podem ser usados ao exportar legendas.

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // Salve cada faixa de legenda como um arquivo .vtt.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Remover legendas de áudio**

Para remover legendas de um quadro de áudio, use os métodos fornecidos por [CaptionsCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captionscollection/), como [clear](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captionscollection/#removeAt). O exemplo a seguir remove todas as faixas de legenda de um quadro de áudio.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // tipo: AudioFrame

    // Remova todas as faixas de legenda do quadro de áudio.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Extrair áudio**

Aspose.Slides for PHP via Java permite que você extraia o som usado em transições de apresentação de slides. Por exemplo, é possível extrair o som usado em um slide específico.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) e carregue a apresentação que contém o áudio.
2. Obtenha a referência do slide relevante através de seu índice.
3. Acesse as [transições de slide show](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/#getSlideShowTransition) do slide.
4. Extraia o som em dados de bytes.

Este código mostra como extrair o áudio usado em um slide:

```php
# Instancia uma classe Presentation que representa um arquivo de apresentação
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Acessa o slide desejado
	$slide = $pres->getSlides()->get_Item(0);
	# Obtém os efeitos de transição de apresentação de slides para o slide
	$transition = $slide->getSlideShowTransition();
	# Extrai o som em um array de bytes
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Posso reutilizar o mesmo recurso de áudio em vários slides sem aumentar o tamanho do arquivo?**

Sim. Adicione o áudio uma vez à [coleção de áudio compartilhada](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getaudios/) da apresentação e crie quadros de áudio adicionais que façam referência a esse recurso existente. Isso evita a duplicação de dados de mídia e mantém o tamanho da apresentação sob controle.

**Posso substituir o som em um quadro de áudio existente sem recriar a forma?**

Sim. Para um som vinculado, atualize o [caminho do link](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/setlinkpathlong/) para apontar para o novo arquivo. Para um som incorporado, troque o objeto [embedded audio](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/setembeddedaudio/) por outro da [coleção de áudio](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getaudios/) da apresentação. A formatação do quadro e a maioria das configurações de reprodução permanecem intactas.

**O recorte altera os dados de áudio subjacentes armazenados na apresentação?**

Não. O recorte ajusta apenas os limites de reprodução. Os bytes originais do áudio permanecem inalterados e acessíveis através do áudio incorporado ou da coleção de áudio da apresentação.