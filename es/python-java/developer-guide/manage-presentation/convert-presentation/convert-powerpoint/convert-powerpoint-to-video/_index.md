---
title: Convertir presentaciones de PowerPoint a video en Python
linktitle: PowerPoint a video
type: docs
weight: 130
url: /es/python-java/convert-powerpoint-to-video/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir PPT
- convertir PPTX
- PowerPoint a video
- presentación a video
- PPT a video
- PPTX a video
- PowerPoint a MP4
- presentación a MP4
- PPT a MP4
- PPTX a MP4
- guardar PPT como MP4
- guardar PPTX como MP4
- exportar PPT a MP4
- exportar PPTX a MP4
- conversión de video
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a video MP4 en Python mediante Java. Generar fotogramas con Aspose.Slides y codificarlos con FFmpeg, incluidas animaciones y transiciones."
---
## **Descripción general**

Convertir una presentación de PowerPoint o OpenDocument a video permite a los espectadores ver su contenido en un reproductor de video sin abrir una aplicación de presentaciones. Aspose.Slides for Python via Java representa las animaciones y transiciones de la presentación en fotogramas de imagen. Un codificador separado, como FFmpeg, combina esos fotogramas en un archivo de video.

{{% alert color="info" title="Note" %}}
Prueba el [convertidor en línea de PowerPoint a Video](https://products.aspose.app/slides/es/video) para ver la conversión de presentación a video en acción.
{{% /alert %}}

## **Convertir PowerPoint a video**

La conversión consta de dos etapas: generar fotogramas PNG a una velocidad de fotogramas elegida y, a continuación, codificar la secuencia de imágenes como MP4. Utiliza la misma velocidad de fotogramas en ambas etapas para preservar la sincronización de la animación.

Antes de ejecutar el ejemplo:

1. Configura [Aspose.Slides for Python via Java](/slides/es/python-java/installation/).
2. Descarga [FFmpeg](https://ffmpeg.org/download.html) y haz que su ejecutable esté disponible en `PATH`. El ejemplo utiliza una compilación con el codificador `libx264`.
3. Ejecuta el siguiente código Python en un directorio con permisos de escritura.

El ejemplo crea una forma sonriente con animaciones de entrada y salida, genera fotogramas a 30 FPS y llama a FFmpeg para crear `output.mp4`. Un directorio de fotogramas nuevo evita que los fotogramas de ejecuciones anteriores se incluyan en el video.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

Para convertir un archivo existente, inicializa [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) con su ruta y omite las sentencias de creación de forma y de animación.

El comando FFmpeg lee una [secuencia de imágenes numerada](https://ffmpeg.org/ffmpeg-formats.html#image2), rellena las dimensiones impares a valores pares y escribe video H.264 con el formato de píxeles `yuv420p`. La opción `-n` evita sobrescribir un archivo de salida existente. Los archivos PNG generados permanecen en el directorio de fotogramas; elimínalos cuando ya no sean necesarios.

{{% alert color="info" title="Note" %}}
Este ejemplo codifica solo fotogramas de imagen. No añade narración ni audio incrustado de la presentación al video de salida.
{{% /alert %}}

## **Efectos de video**

Las animaciones controlan cómo aparecen, se mueven o desaparecen los objetos de la diapositiva. Las transiciones controlan el paso entre diapositivas. Añade estos efectos antes de generar los fotogramas de video.

Consulta [Animación de PowerPoint](/slides/es/python-java/powerpoint-animation/), [Animación de formas](/slides/es/python-java/shape-animation/), [Efectos de formas](/slides/es/python-java/shape-effect/), y [Transiciones de diapositivas](/slides/es/python-java/slide-transition/).

### **Añadir una transición de diapositiva**

El siguiente ejemplo independiente crea una presentación con dos diapositivas. La segunda diapositiva tiene un fondo magenta y una transición de empuje. Guarda la presentación y luego utilízala como entrada para el ejemplo de generación de fotogramas anterior.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Animar párrafos**

El texto puede aparecer párrafo a párrafo. Este ejemplo crea tres párrafos con efectos de entrada de fundido secuencial, cada uno retrasado un segundo después del efecto anterior. Utiliza el archivo guardado `paragraphs.pptx` como entrada para el ejemplo de conversión de video.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clases de conversión de video**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationanimationsgenerator/) genera eventos de animación para las diapositivas. Construirlo a partir de una presentación utiliza el tamaño de diapositiva de la presentación para los fotogramas. Utiliza [setDefaultDelay](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) para configurar el retardo predeterminado en milisegundos.

[PresentationPlayer](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationplayer/) muestrea las animaciones generadas a la velocidad de fotogramas suministrada a su constructor. Registra una devolución de llamada de Python a través de JPype con [setFrameTick](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationplayer/#setFrameTick), luego llama a [run](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationanimationsgenerator/#run) para generar los fotogramas. El primer ejemplo utiliza su propio contador basado en cero para que los nombres de archivo coincidan con la secuencia de entrada de FFmpeg.

Para estados de animación individuales, registra una devolución de llamada con [setNewAnimation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). La devolución de llamada recibe un reproductor de animación que puede posicionarse en un tiempo seleccionado. El siguiente ejemplo guarda los primeros y últimos fotogramas de cada animación generada con nombres de archivo únicos:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Animaciones y efectos compatibles**

Las siguientes tablas resumen la compatibilidad de renderizado descrita en el artículo de conversión de Java. Visualiza una vista previa de los fotogramas generados cuando una presentación utiliza efectos que no son compatibles.

**Entrada**:

| **Tipo de animación** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | No | Sí |
| **Desvanecer** | Sí | Sí |
| **Entrar volando** | Sí | Sí |
| **Entrar flotando** | Sí | Sí |
| **Dividir** | Sí | Sí |
| **Barrer** | Sí | Sí |
| **Forma** | Sí | Sí |
| **Rueda** | Sí | Sí |
| **Barras aleatorias** | Sí | Sí |
| **Crecer y girar** | No | Sí |
| **Zoom** | Sí | Sí |
| **Giro** | Sí | Sí |
| **Rebotar** | Sí | Sí |

**Énfasis**:

| **Tipo de animación** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulso** | No | Sí |
| **Pulso de color** | No | Sí |
| **Balanceo** | Sí | Sí |
| **Giro** | Sí | Sí |
| **Crecer/Encoger** | No | Sí |
| **Desaturar** | No | Sí |
| **Oscurecer** | No | Sí |
| **Aclarar** | No | Sí |
| **Transparencia** | No | Sí |
| **Color del objeto** | No | Sí |
| **Color complementario** | No | Sí |
| **Color de línea** | No | Sí |
| **Color de relleno** | No | Sí |

**Salida**:

| **Tipo de animación** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Desaparecer** | No | Sí |
| **Desvanecer** | Sí | Sí |
| **Salir volando** | Sí | Sí |
| **Salir flotando** | Sí | Sí |
| **Dividir** | Sí | Sí |
| **Barrer** | Sí | Sí |
| **Forma** | Sí | Sí |
| **Barras aleatorias** | Sí | Sí |
| **Encoger y girar** | No | Sí |
| **Zoom** | Sí | Sí |
| **Giro** | Sí | Sí |
| **Rebotar** | Sí | Sí |

**Rutas de movimiento**:

| **Tipo de animación** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Líneas** | Sí | Sí |
| **Arcos** | Sí | Sí |
| **Giros** | Sí | Sí |
| **Formas** | Sí | Sí |
| **Bucles** | Sí | Sí |
| **Ruta personalizada** | Sí | Sí |

## **Preguntas frecuentes**

**¿Aspose.Slides crea un archivo MP4 directamente?**  
No. Aspose.Slides genera fotogramas de la presentación. Utiliza un codificador de video como FFmpeg para combinarlos en un archivo MP4.

**¿Por qué el video se reproduce más rápido o más lento de lo esperado?**  
Utiliza la misma velocidad de fotogramas (FPS) para la generación de fotogramas y la velocidad de fotogramas de entrada del codificador. Una discrepancia altera la duración de reproducción de la secuencia de imágenes.

**¿Puedo convertir una presentación protegida con contraseña?**  
Sí. Proporciona la contraseña correcta al [cargar la presentación protegida](/slides/es/python-java/password-protected-presentation/), y luego genera los fotogramas del contenido cargado.

**¿Este flujo de trabajo preserva el audio de la presentación?**  
Los ejemplos exportan fotogramas de imagen, por lo que el video resultante es silencioso. Para incluir audio, proporciona una pista de audio por separado durante la codificación del video.

**¿Cómo puedo reducir el uso temporal del disco?**  
Utiliza un tamaño de fotograma más pequeño o una FPS más baja, y elimina los archivos PNG temporales tras una codificación exitosa. Verifica la calidad del video resultante al reducir cualquiera de los ajustes.