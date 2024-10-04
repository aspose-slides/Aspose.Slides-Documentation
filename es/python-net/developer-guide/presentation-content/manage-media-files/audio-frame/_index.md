---
title: Marco de Audio
type: docs
weight: 10
url: /es/python-net/audio-frame/
keywords: "Agregar audio, Marco de audio, Propiedades de audio, Extraer audio, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar audio a la presentación de PowerPoint en Python"
---

## **Creando un Marco de Audio**
Aspose.Slides para Python a través de .NET te permite agregar archivos de audio a las diapositivas. Los archivos de audio se incrustan en las diapositivas como marcos de audio.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Carga la secuencia del archivo de audio que deseas incrustar en la diapositiva.
4. Agrega el marco de audio incrustado (que contiene el archivo de audio) a la diapositiva.
5. Establece [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) y `Volume` expuestos por el objeto [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/).
6. Guarda la presentación modificada.

Este código Python te muestra cómo agregar un marco de audio incrustado a una diapositiva:

```python
import aspose.slides as slides

# Instancia una clase de presentación que representa un archivo de presentación
with slides.Presentation() as pres:
    # Obtiene la primera diapositiva
    sld = pres.slides[0]

    # Carga el archivo de sonido wav en la secuencia
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Agrega el Marco de Audio
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Establece el Modo de Reproducción y el Volumen del Audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Escribe el archivo de PowerPoint en el disco
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar la Miniatura del Marco de Audio**

Cuando agregas un archivo de audio a una presentación, el audio aparece como un marco con una imagen estándar predeterminada (ver la imagen en la sección siguiente). Puedes cambiar la miniatura del marco de audio (establecer tu imagen preferida).

Este código Python te muestra cómo cambiar la miniatura o imagen de vista previa de un marco de audio:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agrega un marco de audio a la diapositiva con una posición y tamaño especificados.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Agrega una imagen a los recursos de la presentación.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Establece la imagen para el marco de audio.
        audioFrame.picture_format.picture.image = audioImage
        
        # Guarda la presentación modificada en el disco
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar las Opciones de Reproducción de Audio**

Aspose.Slides para Python a través de .NET te permite cambiar opciones que controlan la reproducción o las propiedades de un audio. Por ejemplo, puedes ajustar el volumen de un audio, configurar el audio para que se reproduzca en bucle, o incluso ocultar el ícono de audio.

El panel de **Opciones de Audio** en Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Las opciones de audio en PowerPoint que corresponden a las propiedades de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/):
- La lista desplegable **Inicio** de Opciones de Audio coincide con la propiedad [AudioFrame.PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Las **Opciones de Volumen** de Audio coinciden con la propiedad [AudioFrame.Volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Las **Opciones de Reproducción en Diapositivas** coinciden con la propiedad [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Las **Opciones de Bucle hasta detenerse** coinciden con la propiedad [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Las **Opciones de Ocultar durante la Presentación** coinciden con la propiedad [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Las **Opciones de Rebobinar después de Reproducir** coinciden con la propiedad [AudioFrame.RewindAudio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 

Así es como cambias las opciones de reproducción de audio:

1. [Crear](#create-audio-frame) o obtener el Marco de Audio.
2. Establecer nuevos valores para las propiedades del Marco de Audio que deseas ajustar.
3. Guarda el archivo de PowerPoint modificado.

Este código Python demuestra una operación en la que se ajustan las opciones de un audio:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Obtiene la forma de AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Establece el modo de reproducción para reproducir al hacer clic
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Establece el Volumen a Bajo
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Establece el audio para reproducirse en las diapositivas
    audioFrame.play_across_slides = True

    # Desactiva el bucle para el audio
    audioFrame.play_loop_mode = False

    # Oculta el AudioFrame durante la presentación
    audioFrame.hide_at_showing = True

    # Rebobina el audio al inicio después de reproducir
    audioFrame.rewind_audio = True

    # Guarda el archivo de PowerPoint en el disco
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraer Audio**
Aspose.Slides para Python a través de .NET te permite extraer el sonido utilizado en las transiciones de la presentación. Por ejemplo, puedes extraer el sonido utilizado en una diapositiva específica.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y carga la presentación que contiene el audio.
2. Obtén la referencia de la diapositiva relevante a través de su índice.
3. Accede a las transiciones de la presentación para la diapositiva.
4. Extrae el sonido en datos de bytes.

Este código Python te muestra cómo extraer el audio utilizado en una diapositiva:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Accede a la diapositiva deseada
    slide = pres.slides[0]  

    # Obtiene los efectos de transición de presentación para la diapositiva
    transition = slide.slide_show_transition

    # Extrae el sonido en un array de bytes
    audio = transition.sound.binary_data

    print("Longitud: " + str(len(audio)))
```