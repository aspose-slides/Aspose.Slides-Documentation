---
title: Sunumlarda Video Çerçevelerini JavaScript ile Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/nodejs-java/video-frame/
keywords:
- video ekle
- video oluştur
- video göm
- video çıkar
- videoyu al
- video çerçevesi
- web kaynağı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'i Java üzerinden kullanarak PowerPoint ve OpenDocument slaytlarına video çerçevelerini programlı olarak eklemeyi ve çıkarmayı öğrenin. Hızlı bir uygulama rehberi."
---
## **Giriş**

Sunumda doğru konumlandırılmış bir video, mesajınızı daha etkili hâle getirebilir ve izleyicilerinizle etkileşim düzeyini artırabilir. 

PowerPoint, bir sunumdaki slayta video eklemenizi iki şekilde sağlar:

* Yerel bir video ekleyin veya gömün (bilgisayarınızda depolanmış)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından).

Bir sunuma video (video nesneleri) eklemenizi sağlamak için Aspose.Slides, [Video](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/video/) sınıfını, [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) sınıfını ve ilgili diğer tipleri sunar.

## **Gömülü Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerelde depolanmışsa, videoyu sunuma gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfından bir örnek oluşturun.  
2. Slayt referansını indeksine göre alın.  
3. Bir [Video](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/video/) nesnesi ekleyin ve videoyu sunuma gömmek için video dosya yolunu iletin.  
4. Video için bir çerçeve oluşturmak üzere bir [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesi ekleyin.  
5. Değiştirilmiş sunumu kaydedin.  

```javascript
// Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Videoyu yükler
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // İlk slaytı alır ve bir video çerçevesi ekler
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Sunumu diske kaydeder
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alternatif olarak, videoyu doğrudan dosya yolunu [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) metoduna geçirerek ekleyebilirsiniz:

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

## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**

Microsoft [PowerPoint 2013 ve üzeri](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) sunumlarda YouTube videolarını destekler. Kullanmak istediğiniz video çevrimiçi olarak mevcutsa (ör. YouTube’da), web bağlantısı aracılığıyla sunuma ekleyebilirsiniz. 

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfından bir örnek oluşturun.  
2. Slayt referansını indeksine göre alın.  
3. Bir [Video](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/video/) nesnesi ekleyin ve videonun bağlantısını iletin.  
4. Video çerçevesi için bir küçük resim ayarlayın.  
5. Sunumu kaydedin.  

```javascript
// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
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

## **Video Çerçevesini Kırpma**

Aspose.Slides, bir videonun hangi bölümünün oynatılacağını, [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/settrimfromstart/) ve [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/settrimfromend/) metodlarıyla trim‑from‑start ve trim‑from‑end değerlerini ayarlayarak kontrol etmenizi sağlar. Her iki değer de milisaniye cinsindendir ve videonun başlangıç ve sonundan ne kadar sürenin atlanacağını tanımlar. Bu ayarlar sunumdaki video oynatma ayarlarını değiştirir; gömülü video ikili verisini kesmez veya farklı bir şekilde değiştirmez.

**Kırpma Ayarlarını Belirleme**

Bir video çerçevesi oluşturup kırpma ayarlarını belirlemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfından bir örnek oluşturun.  
2. Sunuma bir [Video](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/video/) nesnesi ekleyin.  
3. Bir slayta bir [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesi ekleyin.  
4. Trim‑from‑start ve trim‑from‑end değerlerini [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/settrimfromstart/) ve [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/settrimfromend/) aracılığıyla ayarlayın.  
5. Değiştirilmiş sunumu kaydedin.  

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Kırpma Ayarlarını Okuma**

Mevcut kırpma ayarlarını incelemek için bir sunum yükleyin, ilk slayttaki şekiller arasında bir [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesi bulun ve değerleri [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) ve [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/gettrimfromend/) aracılığıyla okuyun.

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) yöntemiyle erişilebilir.

**Bir Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfından bir örnek oluşturun.  
2. Sunuma bir video ekleyin.  
3. Bir slayta bir [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesi ekleyin.  
4. [CaptionsCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/) koleksiyonunu kullanarak bir WebVTT altyazı izi ekleyin.  
5. Değiştirilmiş sunumu kaydedin.  

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // WebVTT dosyasından yeni bir altyazı izi ekler.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/) sınıfı ayrıca altyazıları bir akıştan eklemenizi sağlayan [addFromStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#addFromStream) yöntemini sunar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.  
2. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesini bulun.  
3. [CaptionsCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/) koleksiyonunda gezin.  
4. Her altyazı izini bir `.vtt` dosyasına kaydedin.  

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
                // Altyazı izini bir WebVTT dosyasına kaydeder.
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

Her [Captions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve altyazı metnini UTF‑8 dizesi olarak sunar.

**Bir Video Çerçevesinden Altyazı Kaldırma**

Bir video çerçevesinden altyazı kaldırmak için:

1. Videoyu içeren sunumu yükleyin.  
2. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesini alın.  
3. [CaptionsCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/) koleksiyonundan altyazı izlerini kaldırın.  
4. Değiştirilmiş sunumu kaydedin.  

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // tip: com.aspose.slides.VideoFrame

    // Video çerçevesinden tüm altyazıları kaldırır.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sadece tek bir altyazı izini kaldırmak istiyorsanız, [clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#clear) yerine [remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#removeAt) yöntemlerini kullanın.

## **Slayttan Video Çıkarma**

Gömülü videoları slaytlardan çıkarmak da mümkündür.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) örneği oluşturun.  
2. Tüm [Slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/) nesnelerinde gezin.  
3. [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) nesnelerinde gezinerek bir [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) bulun.  
4. Videoyu diske kaydedin.  

```javascript
// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
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
                // Dosya uzantısını alır
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

## **SSS**

**VideoFrame için hangi video oynatma parametreleri değiştirilebilir?**

[playback mode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/setplaymode/) (otomatik veya tıklama) ve [looping](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ayarlarını kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla sunulur.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde ikili veri belgeye dahil edilir ve sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde bir bağlantı ve küçük resim gömülür, bu yüzden boyut artışı daha küçüktür.

**Mevcut bir VideoFrame içindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçeve içinde [video content](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) değiştirilebilir, şeklin geometrisi korunur; bu, mevcut bir yerleşimde medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun bir [content type](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/video/getcontenttype/) vardır ve bunu okuyup, örneğin diske kaydederken kullanabilirsiniz.