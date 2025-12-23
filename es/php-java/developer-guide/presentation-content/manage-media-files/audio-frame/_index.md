---
title: Gestionar audio en presentaciones usando PHP
linktitle: Fotograma de audio
type: docs
weight: 10
url: /es/php-java/audio-frame/
keywords:
- audio
- fotograma de audio
- miniatura
- agregar audio
- propiedades de audio
- opciones de audio
- extraer audio
- PHP
- Aspose.Slides
description: "Crear y controlar fotogramas de audio en Aspose.Slides para PHP: ejemplos de código para incrustar, recortar, reproducir en bucle y configurar la reproducción en presentaciones PPT, PPTX y ODP."
---

## **Crear fotogramas de audio**

Aspose.Slides for PHP via Java le permite agregar archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como fotogramas de audio.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Cargue la secuencia del archivo de audio que desea incrustar en la diapositiva.
4. Agregue el fotograma de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establezca [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame).
6. Guarde la presentación modificada.

Este código PHP le muestra cómo agregar un fotograma de audio incrustado a una diapositiva:
```php
// Instancia una clase Presentation que representa un archivo de presentación
$pres = new Presentation();
try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Carga el archivo de sonido wav al flujo
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Agrega el fotograma de audio
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Establece el modo de reproducción y el volumen del audio
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Escribe el archivo PowerPoint en disco
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


## **Cambiar la miniatura del fotograma de audio**

Cuando agrega un archivo de audio a una presentación, el audio aparece como un fotograma con una imagen predeterminada estándar (vea la imagen en la sección siguiente). Cambie la imagen de vista previa del fotograma de audio (establezca la imagen que prefiera).

Este código PHP le muestra cómo cambiar la miniatura o la imagen de vista previa de un fotograma de audio:
```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Agrega un fotograma de audio a la diapositiva con una posición y tamaño especificados.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Agrega una imagen a los recursos de la presentación.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Establece la imagen para el fotograma de audio.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Guarda la presentación modificada en disco
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```


## **Cambiar opciones de reproducción de audio**

Aspose.Slides for PHP via Java le permite cambiar opciones que controlan la reproducción o propiedades de un audio. Por ejemplo, puede ajustar el volumen de un audio, establecer que el audio se reproduzca en bucle o incluso ocultar el ícono de audio.

El panel **Audio Options** en Microsoft PowerPoint:
![example1_image](audio_frame_0.png)

Las **Audio Options** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) :

- **Start** la lista desplegable coincide con el método [AudioFrame.setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** coincide con el método [AudioFrame.setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** coincide con el método [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** coincide con el método [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** coincide con el método [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** coincide con el método [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio)

Opciones de **Editing** de PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) :

- **Fade In** coincide con el método [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** coincide con el método [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** coincide con el método [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart)
- **Trim Audio End Time** el valor equivale a la duración del audio menos el valor del método [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd)

El **Volume controll** de PowerPoint en el panel de control de audio corresponde al método [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Le permite cambiar el volumen del audio como un porcentaje.

Así es como cambia las opciones de reproducción de audio:

1. [Crear](#create-audio-frame) o obtenga el fotograma de audio.
2. Establezca nuevos valores para las propiedades del fotograma de audio que desea ajustar.
3. Guarde el archivo de PowerPoint modificado.

Este código PHP muestra una operación en la que se ajustan las opciones de un audio:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Obtiene la forma AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Establece el modo de reproducción a reproducir al hacer clic
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Establece el volumen a bajo
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Establece que el audio se reproduzca a través de diapositivas
    $audioFrame->setPlayAcrossSlides(true);
    # Desactiva el bucle del audio
    $audioFrame->setPlayLoopMode(false);
    # Oculta el AudioFrame durante la presentación de diapositivas
    $audioFrame->setHideAtShowing(true);
    # Retrocede el audio al inicio después de reproducir
    $audioFrame->setRewindAudio(true);
    # Guarda el archivo PowerPoint en disco
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


Este ejemplo PHP muestra cómo agregar un nuevo fotograma de audio con audio incrustado, recortarlo y establecer las duraciones de fundido:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Establece el desplazamiento de inicio del recorte a 1,5 segundos
    $audioFrame->setTrimFromStart(1500);
    // Establece el desplazamiento de fin del recorte a 2 segundos
    $audioFrame->setTrimFromEnd(2000);

    // Establece la duración del fundido de entrada a 200 ms
    $audioFrame->setFadeInDuration(200);
    // Establece la duración del fundido de salida a 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


El siguiente ejemplo de código muestra cómo obtener un fotograma de audio con audio incrustado y establecer su volumen al 85%:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Obtiene la forma de fotograma de audio
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Establece el volumen del audio al 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```


## **Extraer audio**

Aspose.Slides for PHP via Java le permite extraer el sonido utilizado en las transiciones de la presentación de diapositivas. Por ejemplo, puede extraer el sonido usado en una diapositiva específica.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y cargue la presentación que contiene el audio.
2. Obtenga la referencia de la diapositiva correspondiente mediante su índice.
3. Acceda a las [slideshow transitions](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) de la diapositiva.
4. Extraiga el sonido en datos de bytes.

Este código le muestra cómo extraer el audio utilizado en una diapositiva:
```php
# Instancia una clase Presentation que representa un archivo de presentación
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Accede a la diapositiva deseada
	$slide = $pres->getSlides()->get_Item(0);
	# Obtiene los efectos de transición de la presentación para la diapositiva
	$transition = $slide->getSlideShowTransition();
	# Extrae el sonido en un arreglo de bytes
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


## **FAQ**

**¿Puedo reutilizar el mismo recurso de audio en varias diapositivas sin aumentar el tamaño del archivo?**

Sí. Añada el audio una vez a la [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) compartida de la presentación y cree fotogramas de audio adicionales que hagan referencia a ese recurso existente. Esto evita duplicar los datos multimedia y mantiene el tamaño de la presentación bajo control.

**¿Puedo reemplazar el sonido en un fotograma de audio existente sin recrear la forma?**

Sí. Para un sonido vinculado, actualice la [link path](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) para que apunte al nuevo archivo. Para un sonido incrustado, reemplace el objeto [embedded audio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) por otro de la [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) de la presentación. El formato del fotograma y la mayoría de los ajustes de reproducción permanecen intactos.

**¿El recorte cambia los datos de audio subyacentes almacenados en la presentación?**

No. El recorte solo ajusta los límites de reproducción. Los bytes originales del audio permanecen sin modificar y son accesibles a través del audio incrustado o de la colección de audio de la presentación.