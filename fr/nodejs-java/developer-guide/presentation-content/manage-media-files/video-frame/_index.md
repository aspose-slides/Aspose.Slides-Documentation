---
title: Cadre vidéo
type: docs
weight: 10
url: /fr/nodejs-java/video-frame/
keywords: "Ajouter une vidéo, créer un cadre vidéo, extraire une vidéo, présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Ajouter un cadre vidéo à une présentation PowerPoint en JavaScript"
---

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre public.  

PowerPoint vous permet d’ajouter des vidéos à une diapositive de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre machine)  
* Ajouter une vidéo en ligne (depuis une source Web telle que YouTube).  

Pour vous permettre d’ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit la classe [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/), la classe [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) et d’autres types pertinents.  

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour incorporer la vidéo dans votre présentation.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son indice.  
3. Ajoutez un objet [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) et transmettez le chemin du fichier vidéo pour l’incorporer à la présentation.  
4. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) pour créer un cadre pour la vidéo.  
5. Enregistrez la présentation modifiée.  

Ce code JavaScript vous montre comment ajouter une vidéo stockée localement à une présentation :
```javascript
// Instancie la classe Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Charge la vidéo
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Obtient la première diapositive et ajoute un videoframe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Enregistre la présentation sur le disque
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Vous pouvez également ajouter une vidéo en transmettant directement son chemin de fichier à la méthode [addVideoFrame(float x,float y,float width,float height,IVideo video)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :
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
  

## **Créer un cadre vidéo avec une vidéo depuis une source Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prennent en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par ex. sur YouTube), vous pouvez l’ajouter à votre présentation via son lien Web.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son indice.  
3. Ajoutez un objet [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) et transmettez le lien vers la vidéo.  
4. Définissez une vignette pour le cadre vidéo.  
5. Enregistrez la présentation.  

Ce code JavaScript vous montre comment ajouter une vidéo depuis le Web à une diapositive dans une présentation PowerPoint :
```javascript
// Crée un objet Presentation qui représente un fichier de présentation
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
  

## **Extraire la vidéo d'une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) pour charger la présentation contenant la vidéo.  
2. Parcourez tous les objets [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/).  
3. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).  
4. Enregistrez la vidéo sur le disque.  

Ce code JavaScript vous montre comment extraire la vidéo d’une diapositive de présentation :
```javascript
// Instancie un objet Presentation qui représente un fichier de présentation
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
                //                Obtient l'extension du fichier
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

**Quels paramètres de lecture peuvent être modifiés pour un VideoFrame ?**  

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatique ou au clic) et la [boucle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).  

**L’ajout d’une vidéo influe‑t‑il sur la taille du fichier PPTX ?**  

Oui. Lorsque vous incorporez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une vignette sont incorporés, ce qui entraîne une hausse de taille moindre.  

**Puis‑je remplacer la vidéo d’un VideoFrame existant sans modifier sa position ni sa taille ?**  

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) à l’intérieur du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.  

**Le type de contenu (MIME) d’une vidéo incorporée peut‑il être déterminé ?**  

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) que vous pouvez lire et utiliser, par exemple lors de l’enregistrement sur le disque.  