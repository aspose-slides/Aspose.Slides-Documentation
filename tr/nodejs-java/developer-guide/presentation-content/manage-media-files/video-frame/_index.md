---
title: JavaScript Kullanarak Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/nodejs-java/video-frame/
keywords:
- video ekle
- video oluştur
- video göm
- video çıkar
- video al
- video çerçevesi
- web kaynağı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'i Java üzerinden kullanarak PowerPoint ve OpenDocument slaytlarında video çerçevelerini programlı olarak eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır kılavuzu."
---
## **Giriş**

Bir sunumda iyi yerleştirilmiş bir video, mesajınızı daha etkileyici hale getirebilir ve izleyicilerinizle etkileşim seviyesini artırabilir. 

PowerPoint, bir sunumdaki slayta video eklemenize iki şekilde izin verir:

* Yerel bir video ekleyin veya gömün (bilgisayarınızda saklanan)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından).

Sunuma video (video nesneleri) eklemenize olanak tanımak için Aspose.Slides, [Video](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/video/) sınıfını, [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) sınıfını ve diğer ilgili türleri sağlar.

## **Gömülü Video Çerçevesi Oluşturma**

Eklemek istediğiniz video dosyası yerel olarak depolanmışsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İndeksine göre bir slayt referansı alın.  
3. [Video](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/video/) nesnesi ekleyin ve videoyu sunuma gömmek için video dosya yolunu iletin.  
4. [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesi ekleyerek video için bir çerçeve oluşturun.  
5. Değiştirilmiş sunumu kaydedin.  

```javascript
// Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Videoyu yüklüyor
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

Alternatif olarak, videonun dosya yolunu doğrudan [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) metoduna geçerek bir video ekleyebilirsiniz:

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

Microsoft [PowerPoint 2013 ve daha yeni sürümler](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) sunumlarda YouTube videolarını destekler. Kullanmak istediğiniz video çevrimiçi (ör. YouTube’da) mevcutsa, web bağlantısı aracılığıyla sunuma ekleyebilirsiniz. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. İndeksine göre bir slayt referansı alın.  
3. [Video](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/video/) nesnesi ekleyin ve videoya bağlantıyı iletin.  
4. Video çerçevesi için bir küçük resim ayarlayın.  
5. Sunumu kaydedin.  

```javascript
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekler
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

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) metodu aracılığıyla erişilebilir.

**Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
2. Sunuma bir video ekleyin.  
3. Bir slayta [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesi ekleyin.  
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

[CaptionsCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/) sınıfı ayrıca bir akıştan altyazı eklemenizi sağlayan [addFromStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#addFromStream) metodunu sunar.

**Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.  
2. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesini bulun.  
3. [CaptionsCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/) koleksiyonunda döngü oluşturun.  
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

Her [Captions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili veriyi ve altyazı metnini UTF-8 bir dize olarak sunar.

**Video Çerçevesinden Altyazı Silme**

Bir video çerçevesinden altyazı silmek için:

1. Videoyu içeren sunumu yükleyin.  
2. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesini alın.  
3. [CaptionsCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/) koleksiyonundan altyazı izlerini kaldırın.  
4. Değiştirilmiş sunumu kaydedin.  

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // tip: com.aspose.slides.VideoFrame

    // Video çerçevesindeki tüm altyazıları kaldırır.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yalnızca bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#clear) yerine [remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#removeAt) metodlarını kullanın.


## **Slayttan Video Çıkarma**

Slaytlara video eklemenin yanı sıra, Aspose.Slides sunumlarda gömülü videoları çıkarmanıza da olanak tanır.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Tüm [Slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/) nesnelerinde döngü oluşturun.  
3. Bir [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) bulmak için tüm [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) nesnelerinde döngü oluşturun.  
4. Videoyu diske kaydedin.  

```javascript
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekler
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

**VideoFrame için hangi oynatma parametreleri değiştirilebilir?**

[playback mode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/setplaymode/) (otomatik veya tıklama) ve [looping](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ayarlarını kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla bulunmaktadır.

**Video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye dahil edilir, bu nedenle sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde, bir bağlantı ve bir küçük resim gömülür, bu yüzden boyut artışı daha küçüktür.

**Mevcut bir VideoFrame içindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Şeklin geometrisini koruyarak çerçeve içindeki [video content](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) değiştirilebilir; bu, mevcut bir düzenlemedeki medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun okuyup kullanabileceğiniz bir [content type](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/video/getcontenttype/) vardır; örneğin diske kaydederken kullanılabilir.