---
title: Marco de video
type: docs
weight: 10
url: /es/nodejs-java/video-frame/
keywords: "Agregar video, crear marco de video, extraer video, presentación de PowerPoint, Java, Aspose.Slides para Node.js via Java"
description: "Agregar marco de video a una presentación de PowerPoint en JavaScript"
---

Un video bien colocado en una presentación puede hacer que tu mensaje sea más impactante y aumentar los niveles de compromiso con tu audiencia. 

PowerPoint te permite agregar videos a una diapositiva en una presentación de dos maneras:

* Agregar o incrustar un video local (almacenado en tu equipo)
* Agregar un video en línea (desde una fuente web como YouTube).

Para permitirte agregar videos (objetos de video) a una presentación, Aspose.Slides proporciona la clase [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/), la clase [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) y otros tipos relevantes.

## **Crear Marco de Video Incrustado**

Si el archivo de video que deseas agregar a tu diapositiva está almacenado localmente, puedes crear un marco de video para incrustar el video en tu presentación. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtén una referencia a la diapositiva mediante su índice. 
1. Agrega un objeto [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) y pasa la ruta del archivo de video para incrustar el video en la presentación.
1. Agrega un objeto [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) para crear un marco para el video.
1. Guarda la presentación modificada. 

Este código JavaScript te muestra cómo agregar un video almacenado localmente a una presentación:
```javascript
// Instancia la clase Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Carga el video
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Obtiene la primera diapositiva y agrega un videoframe
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


Alternativamente, puedes agregar un video pasando su ruta de archivo directamente al método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :
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


## **Crear Marco de Video con Video de Fuente Web**

Microsoft [PowerPoint 2013 y versiones posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) admite videos de YouTube en las presentaciones. Si el video que deseas usar está disponible en línea (p. ej., en YouTube), puedes agregarlo a tu presentación a través de su enlace web. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)
1. Obtén una referencia a la diapositiva mediante su índice. 
1. Agrega un objeto [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) y pasa el enlace al video.
1. Establece una miniatura para el marco de video. 
1. Guarda la presentación. 

Este código JavaScript te muestra cómo agregar un video desde la web a una diapositiva en una presentación de PowerPoint:
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


## **Extraer Video de la Diapositiva**

Además de agregar videos a las diapositivas, Aspose.Slides te permite extraer videos incrustados en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) para cargar la presentación que contiene el video.
2. Recorre todos los objetos [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/).
3. Recorre todos los objetos [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) para encontrar un [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).
4. Guarda el video en el disco.

Este código JavaScript te muestra cómo extraer el video de una diapositiva de la presentación:
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

**¿Qué parámetros de reproducción de video se pueden cambiar para un VideoFrame?**

Puedes controlar el [modo de reproducción](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (automático o al hacer clic) y el [bucle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Estas opciones están disponibles a través de las propiedades del objeto [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**¿Agregar un video afecta el tamaño del archivo PPTX?**

Sí. Cuando incrustas un video local, los datos binarios se incluyen en el documento, por lo que el tamaño de la presentación crece en proporción al tamaño del archivo. Cuando agregas un video en línea, se incrustan un enlace y una miniatura, por lo que el aumento de tamaño es menor.

**¿Puedo reemplazar el video en un VideoFrame existente sin cambiar su posición y tamaño?**

Sí. Puedes intercambiar el [contenido de video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) dentro del marco manteniendo la geometría de la forma; este es un escenario común para actualizar medios en un diseño existente.

**¿Se puede determinar el tipo de contenido (MIME) de un video incrustado?**

Sí. Un video incrustado tiene un [tipo de contenido](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) que puedes leer y usar, por ejemplo al guardarlo en el disco.