---
title: JavaScript Kullanarak Sunumlarda Ses Çerçevelerini Yönetme
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/nodejs-java/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- ses çıkarma
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile slaytlara ses gömün, ses simgesini değiştirin, oynatmayı yapılandırın, WebVTT altyazılarını yönetin ve slayt geçiş seslerini çıkarın."
---
## **Genel Bakış**

Bir ses çerçevesi, bir slaytta ses çalmanızı sağlar. Aspose.Slides for Node.js via Java ile bir ses klibi gömebilir, onu temsil eden görseli seçebilir, oynatmayı ayarlayabilir ve altyazılar ekleyebilirsiniz. Ayrıca bir slayt geçişine atanmış sesi de alabilirsiniz.

## **Ses Çerçeveleri Oluşturma**

[addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) kullanarak ilk slayta yerel bir ses klibi gömebilirsiniz. İlk iki koordinat çerçevenin slayttaki konumunu, sonraki iki değer ise genişlik ve yüksekliğini, tümü puan cinsinden ayarlar. Bu örnek, klibi otomatik olarak başlatmak için [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) ve yüksek ses ön ayarını seçmek için [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) çağırır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ses Çerçevesi Küçük Resmini Değiştir**

Varsayılan olarak, bir ses çerçevesi hoparlör simgesi gösterir. Özel bir küçük resim göstermek için sunuma [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) ile bir görsel ekleyin ve çerçevenin resmine [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) ile ayarlayın. Örnek, gömülü ses klibi için `eagle.jpeg` dosyasını küçük resim olarak kullanır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ses Çalma Seçeneklerini Değiştir**

PowerPoint'in **Ses Seçenekleri** denetimleri, bir klibin ne zaman başlayacağını, ses seviyesini ve slayt gösterisi sırasında nasıl davranacağını belirler.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint denetimi | Aspose.Slides for Node.js via Java yöntemi |
| --- | --- |
| Başlat | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Ses seviyesi ön ayarı | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Slaytlar Arasında Oynat | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Durdurulana Kadar Döngü | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Gösteri Sırasında Gizle | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Oynatmadan Sonra Geri Sar | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| İçeri Solma | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Dışarı Solma | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Ses Kesme başlangıç zamanı | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Ses Kesme bitiş zamanı | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Ses kaydırıcısı | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

Örnek, ilk slayttaki ilk ses çerçevesini bulur, tıklamayla oynatmayı başlatmak için [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) çağırır ve düşük ses ön ayarını seçer. Klib, döngü devre dışı bırakılarak slaytlar arasında devam eder. Simge gösteri sırasında gizli kalır ve oynatmadan sonra klip geri sarılır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

3,5 saniyeden uzun bir klip için bu örnek, ilk 1,5 saniyeyi ve son 2 saniyeyi atlar. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) klibin sonundan çıkarılacak süreyi alır. PowerPoint'te gösterilen bitiş zamanını elde etmek için bu offset’i tam klip süresinden çıkarın. Kesilen klip 200 milisaniye içinde içeri solma, 500 milisaniye içinde dışarı solma efektine sahiptir. Dört yöntem de değerleri milisaniye cinsinden alır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Oynatma ses seviyesini belirli bir yüzdeye ayarlamak için [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) kullanın. Bu örnek, ilk slayttaki ilk ses çerçevesini %85 olarak ayarlar.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Ses Altyazılarını Yönet**

Her ses çerçevesi, [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) aracılığıyla altyazı izlerine erişim sağlar. Koleksiyonu, WebVTT altyazılarını klibe eklemek, mevcut izleri dışa aktarmak veya silmek için kullanın.

### **Ses Altyazıları Ekle**

Örnek, ilk slayta bir ses klibi gömer ve [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) ile yerel bir WebVTT izini ekler. İlk argüman iz etiketini, ikinci argüman zamanlı altyazıları içeren dosyayı belirtir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ses Altyazılarını Çıkar**

Bu örnek, ilk slayttaki bir ses çerçevesine eklenmiş her altyazı izini dışa aktarır. [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) tarafından döndürülen baytları bir WebVTT dosyasına yazar ve [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) tarafından döndürülen tanımlayıcıyı dosya adı olarak kullanır; böylece her iz ayrı bir çıktı alır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **Ses Altyazılarını Kaldır**

Bireysel bir izi silmek için [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) kullanın. Örnek, ilk slayttaki ilk ses çerçevesinden tüm altyazıları kaldırmak için [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) yöntemini çağırır; klip korunur.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Ses Altyazılarında Satır Bul**

İlk slayttaki ses altyazılarında bir satır bulmak için [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) tarafından döndürülen metni bellekte arayın. Düz metin bir WebVTT kodunda zaman satırı `-->` içerir, ardından altyazı satırları gelir ve boş bir satır kodu sonlandırır. Bu örnek, “café” içeren iz etiketi ve ilgili altyazı satırlarını yazdırır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ses Çıkarma**

Bir slayt geçişinin kendi sesi olabilir. Bunu almak için geçiş üzerinde [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) çağırın. Örnek, [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) tarafından döndürülen baytları alır ve bayt sayısını yazdırır. İlk slaytta geçiş sesi yoksa, bunun yerine bir mesaj yazdırır.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

**Aynı ses klibini birden fazla slaytta tekrarlamadan kullanabilir miyim?**

Evet. Ses klibini sunumun [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) kısmına bir kez ekleyin ve her slayt için aynı ses nesnesini [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) metoduna geçirin.

**Mevcut bir ses çerçevesindeki sesi değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, değiştirilecek dosyayı işaret etmek üzere [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) kullanın. Gömülü bir ses için, [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio) ile sunumun ses koleksiyonundan başka bir klip seçin. Her iki yaklaşım da mevcut çerçeveyi korur.

**Kesme işlemi, sunumda saklanan ses verisini değiştirir mi?**

Hayır. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) ve [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) yalnızca oynatma sınırlarını ayarlar. Tam klibi hâlâ [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio) ile alabilirsiniz.