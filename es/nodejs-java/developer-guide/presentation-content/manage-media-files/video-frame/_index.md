---
title: Gestionar marcos de vídeo en presentaciones usando JavaScript
linktitle: Marco de vídeo
type: docs
weight: 10
url: /es/nodejs-java/video-frame/
keywords:
- añadir vídeo
- crear vídeo
- incrustar vídeo
- extraer vídeo
- recuperar vídeo
- marco de vídeo
- fuente web
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a añadir y extraer programáticamente marcos de vídeo en diapositivas PowerPoint y OpenDocument usando Aspose.Slides para Node.js mediante Java. Guía práctica rápida."
---
Un vídeo bien colocado en una presentación puede hacer que su mensaje sea más atractivo y aumentar el nivel de compromiso con su audiencia. 

PowerPoint le permite añadir vídeos a una diapositiva de una presentación de dos maneras:

* Añadir o incrustar un vídeo local (almacenado en su máquina)
* Añadir un vídeo en línea (de una fuente web como YouTube).

Para permitirle añadir vídeos (objetos de vídeo) a una presentación, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/video/) , la clase [VideoFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear Marco de Vídeo Incrustado**

Si el archivo de vídeo que desea añadir a su diapositiva está almacenado localmente, puede crear un marco de vídeo para incrustar el vídeo en su presentación. 

1. Crear una instancia de la clase [Presentation ](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) .
1. Obtener la referencia de una diapositiva mediante su índice. 
1. Añadir un objeto [Video](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/video/) y pasar la ruta del archivo de vídeo para incrustar el vídeo en la presentación. 
1. Añadir un objeto [VideoFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/) para crear un marco para el vídeo. 
1. Guardar la presentación modificada. 

Este código JavaScript le muestra cómo añadir un vídeo almacenado localmente a una presentación:

```javascript
// Instancia la clase Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Carga el vídeo
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Obtiene la primera diapositiva y añade un marco de vídeo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Guarda la presentación en disco
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alternativamente, puede añadir un vídeo pasando directamente su ruta de archivo al método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Crear Marco de Vídeo con Vídeo de Fuente Web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) soportan vídeos de YouTube en presentaciones. Si el vídeo que desea usar está disponible en línea (p. ej. en YouTube), puede añadirlo a su presentación mediante su enlace web. 

1. Crear una instancia de la clase [Presentation ](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) .
1. Obtener la referencia de una diapositiva mediante su índice. 
1. Añadir un objeto [Video](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/video/) y pasar el enlace al vídeo. 
1. Establecer una miniatura para el marco de vídeo. 
1. Guardar la presentación. 

Este código JavaScript le muestra cómo añadir un vídeo de la web a una diapositiva en una presentación de PowerPoint:

```javascript
// Instancia un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Gestionar Subtítulos de Vídeo**

Aspose.Slides permite gestionar los subtítulos cerrados para los marcos de vídeo en presentaciones de PowerPoint. Los subtítulos se almacenan en formato WebVTT y se exponen mediante el método [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Añadir subtítulos a un marco de vídeo**

Para añadir subtítulos a un marco de vídeo:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) .
1. Añadir un vídeo a la presentación. 
1. Añadir un objeto [VideoFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/) a una diapositiva. 
1. Utilizar la colección [CaptionsCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/) para añadir una pista de subtítulos WebVTT. 
1. Guardar la presentación modificada. 

El siguiente código le muestra cómo añadir subtítulos a un marco de vídeo:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Añade una nueva pista de subtítulos desde un archivo WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La clase [CaptionsCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/) también proporciona el método [addFromStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/#addFromStream) que permite añadir subtítulos desde un flujo.

**Extraer subtítulos de un marco de vídeo**

Para extraer subtítulos de un marco de vídeo:

1. Cargar la presentación que contiene el vídeo. 
1. Encontrar el objeto [VideoFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/) objetivo. 
1. Iterar a través de la colección [CaptionsCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/) . 
1. Guardar cada pista de subtítulos en un archivo `.vtt`. 

El siguiente código le muestra cómo extraer subtítulos de un marco de vídeo:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Guarda la pista de subtítulos en un archivo WebVTT.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Cada objeto [Captions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captions/) expone el identificador del subtítulo, la etiqueta, los datos binarios y el texto del subtítulo como una cadena UTF‑8.

**Eliminar subtítulos de un marco de vídeo**

Para eliminar subtítulos de un marco de vídeo:

1. Cargar la presentación que contiene el vídeo. 
1. Obtener el objeto [VideoFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/) objetivo. 
1. Eliminar las pistas de subtítulos de la colección [CaptionsCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/) . 
1. Guardar la presentación modificada. 

El siguiente código le muestra cómo eliminar todos los subtítulos de un marco de vídeo:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // tipo: com.aspose.slides.VideoFrame

    // Elimina todos los subtítulos del marco de vídeo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si necesita eliminar solo una pista de subtítulos, utilice los métodos [remove](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/#removeAt) en lugar de [clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/captionscollection/#clear).


## **Extraer vídeo de la diapositiva**

Además de añadir vídeos a diapositivas, Aspose.Slides le permite extraer los vídeos incrustados en presentaciones.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) para cargar la presentación que contiene el vídeo. 
2. Iterar a través de todos los objetos [Slide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/) . 
3. Iterar a través de todos los objetos [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/) . 
4. Guardar el vídeo en disco. 

Este código JavaScript le muestra cómo extraer el vídeo de una diapositiva de una presentación:

```javascript
// Instancia un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Obtiene la extensión del archivo
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**¿Qué parámetros de reproducción de vídeo se pueden cambiar en un VideoFrame?**

Puede controlar el [modo de reproducción](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/setplaymode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/) .

**¿Afecta la adición de un vídeo al tamaño del archivo PPTX?**

Sí. Cuando incrusta un vídeo local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando añade un vídeo en línea, se incrustan un enlace y una miniatura, de modo que el incremento de tamaño es menor.

**¿Puedo sustituir el vídeo en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puede intercambiar el [contenido del vídeo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) dentro del marco manteniendo la geometría de la forma; es un escenario habitual para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un vídeo incrustado?**

Sí. Un vídeo incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/video/getcontenttype/) que puede leer y utilizar, por ejemplo, al guardarlo en disco.