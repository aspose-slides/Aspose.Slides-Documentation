---
title: Gestionar fotogramas de vídeo en presentaciones usando Node.js
linktitle: Fotograma de vídeo
type: docs
weight: 10
url: /es/nodejs-java/video-frame/
keywords:
- añadir vídeo
- crear vídeo
- incrustar vídeo
- extraer vídeo
- recuperar vídeo
- fotograma de vídeo
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a añadir y extraer programáticamente fotogramas de vídeo en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Node.js via Java. Guía rápida paso a paso."
---
## **Introducción**

Los vídeos pueden ayudar a explicar ideas y a captar la atención del público. Aspose.Slides for Node.js via Java le permite añadir fotogramas de vídeo a las diapositivas, ajustar la configuración de reproducción, gestionar subtítulos y extraer los datos de vídeo incrustados.

PowerPoint admite vídeos locales y enlaces a vídeos en línea, como los vídeos de YouTube.

Para representar datos de vídeo y fotogramas de vídeo, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) y la clase [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear un fotograma de vídeo incrustado**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un fotograma de vídeo para incrustar el vídeo en su presentación.

Este ejemplo incrusta un vídeo local en la primera diapositiva de una presentación existente y guarda el resultado. Las coordenadas y dimensiones del fotograma están en puntos. El flujo permanece abierto hasta que se completa el guardado porque [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) lo mantiene bloqueado mientras la presentación lo utiliza.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

También puede pasar una ruta de vídeo local directamente a [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Este ejemplo incrusta el vídeo en la primera diapositiva de una nueva presentación. El vídeo debe permanecer accesible hasta que la presentación se guarde.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Crear un fotograma de vídeo con vídeo de una fuente web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) admite vídeos en línea en las presentaciones. Puede crear un fotograma de vídeo que enlace a un vídeo en línea, como un vídeo de YouTube.

Este ejemplo añade un enlace a un vídeo de YouTube y su miniatura a la primera diapositiva. Reemplace el identificador del vídeo para usar otro vídeo. El método [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) solicita la reproducción automática. Descargar la miniatura y reproducir el vídeo requieren acceso a Internet. El visor de presentaciones también debe ser compatible con la reproducción de vídeos en línea.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Reproducir un vídeo en modo pantalla completa**

En una presentación de formación, puede reproducir una demostración de software en modo pantalla completa para que el público vea los detalles. Llame a [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) con `true` para habilitar este comportamiento durante la reproducción.

Este ejemplo abre una presentación, encuentra el primer [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) en la primera diapositiva y habilita la reproducción a pantalla completa. La presentación de entrada debe contener al menos una diapositiva con un fotograma de vídeo existente en la primera diapositiva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La reproducción a pantalla completa controla cómo se muestra el vídeo. De forma independiente, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) controla si se inicia automáticamente o con un clic, y [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) controla si se repite. Para elegir el comportamiento de inicio, establezca el modo de reproducción a [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). El ejemplo conserva la configuración de inicio y bucle existentes.

## **Retroceder un vídeo después de la reproducción**

En una presentación de formación, devolver un vídeo de demostración a su principio lo deja listo para que el presentador lo reproduzca nuevamente. Llame a [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) con `true` para devolver el vídeo al principio tras la finalización de la reproducción.

Este ejemplo abre una presentación, encuentra el primer [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) en la primera diapositiva y habilita el rebobinado. Desactiva el bucle para que la reproducción pueda terminar y establece la reproducción para que comience con un clic. La presentación de entrada debe contener al menos una diapositiva con un fotograma de vídeo existente en la primera diapositiva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El rebobinado devuelve el vídeo a su principio sin iniciarlo de nuevo. En contraste, llamar a [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) con `true` repite la reproducción automáticamente. Mantenga el bucle desactivado cuando desee que el vídeo finalice y quede listo para reproducirlo nuevamente. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) controla de forma independiente el inicio automático o con clic; este ejemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) para que el presentador controle cuándo comienza la reproducción. Establezca el modo de reproducción después de la configuración del bucle, como se muestra en el ejemplo. El rebobinado funciona de forma independiente de [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Recortar un fotograma de vídeo**

Utilice [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) y [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) para omitir parte del principio o del final de un vídeo durante la reproducción. Ambos valores están en milisegundos. El recorte cambia la configuración de reproducción sin modificar los datos del vídeo incrustado.

**Establecer ajustes de recorte**

Este ejemplo incrusta un vídeo local y omite los primeros 2,5 segundos y el último segundo durante la reproducción. Utilice un vídeo de más de 3,5 segundos para que quede un segmento reproducible.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Leer ajustes de recorte**

Este ejemplo muestra los valores de recorte del primer fotograma de vídeo en la primera diapositiva en milisegundos. La presentación debe contener al menos una diapositiva. Si esa diapositiva no tiene fotograma de vídeo, no se muestra nada. El ejemplo anterior produce valores de 2500 y 1000.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gestionar subtítulos de vídeo**

Aspose.Slides le permite gestionar subtítulos cerrados para los fotogramas de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Añadir subtítulos a un fotograma de vídeo**

Este ejemplo incrusta un vídeo local y añade una pista de subtítulos WebVTT etiquetada como English. Las marcas de tiempo de los subtítulos deben coincidir con el vídeo. La presentación guardada incluye tanto el vídeo como sus subtítulos.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La clase [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) también proporciona el método [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) para añadir subtítulos desde un flujo.

**Extraer subtítulos de un fotograma de vídeo**

Este ejemplo guarda todas las pistas de subtítulos de los fotogramas de vídeo en la primera diapositiva como archivos WebVTT separados. Los números secuenciales mantienen los archivos de salida diferenciados. La consola informa del número de pistas extraídas. La presentación debe contener al menos una diapositiva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Cada objeto [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF‑8.

**Eliminar subtítulos de un fotograma de vídeo**

Este ejemplo elimina todos los subtítulos del fotograma de vídeo en la primera posición de forma en la primera diapositiva y guarda el resultado. Se asume que la diapositiva y la forma existen y que la forma es un fotograma de vídeo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si necesita eliminar solo una pista de subtítulos, utilice los métodos [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) en lugar de [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **Extraer vídeo de una diapositiva**

Además de añadir vídeos a las diapositivas, Aspose.Slides le permite extraer los vídeos incrustados en presentaciones.

Este ejemplo extrae los vídeos incrustados de cada diapositiva en archivos binarios numerados por separado. Los vídeos enlazados se omiten porque no tienen datos incrustados. La consola muestra el tipo MIME de cada vídeo y el recuento total. La salida usa la extensión genérica `.bin`; cámbiela para que coincida con el tipo de medio informado cuando sea necesario.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Qué parámetros de reproducción de vídeo se pueden cambiar en un fotograma de vídeo?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (automático o con clic) y el [bucle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Estas opciones están disponibles mediante los métodos del objeto [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**¿Afecta la incorporación de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrusta un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación aumenta proporcionalmente al tamaño del archivo. Cuando enlaza a un vídeo en línea y añade una miniatura, la presentación almacena el enlace y la imagen de vista previa en lugar de los datos del vídeo, por lo que el aumento de tamaño suele ser menor.

**¿Puedo sustituir el vídeo en un fotograma de vídeo existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) dentro del fotograma manteniendo la geometría de la forma; es un escenario común para actualizar los medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) que puede leer y usar, por ejemplo, al guardarlo en disco.