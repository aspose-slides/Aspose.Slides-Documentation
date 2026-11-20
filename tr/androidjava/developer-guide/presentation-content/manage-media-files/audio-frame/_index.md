---
title: Android'de Sunumlarda Ses Çerçevelerini Yönetme
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/androidjava/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- ses çıkarma
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile slaytlara ses gömün, ses simgesini değiştirin, oynatmayı yapılandırın, WebVTT altyazılarını yönetin ve slayt geçişi seslerini çıkarın."
---
## **Genel Bakış**

Bir ses çerçevesi, bir slaytta ses çalmanıza olanak tanır. Aspose.Slides for Android via Java ile bir ses klibi ekleyebilir, onu temsil eden resmi seçebilir, oynatmayı ayarlayabilir ve altyazılar ekleyebilirsiniz. Ayrıca bir slayt geçişine atanmış bir sesi de alabilirsiniz.

## **Ses Çerçeveleri Oluşturma**

İlk slayta yerel bir ses klibi eklemek için [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) kullanın. İlk iki koordinat çerçeveyi slaytta konumlandırır, sonraki iki değer ise genişlik ve yüksekliğini, tümü puan cinsinden ayarlar. Bu örnek, klibi otomatik olarak başlatmak için [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) ve yüksek ses ön ayarını seçmek için [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) metodlarını çağırır.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Varsayılan olarak, bir ses çerçevesi bir hoparlör simgesi gösterir. Özel bir küçük resim göstermek için sunuma [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) ile bir görüntü ekleyin ve çerçevenin resmine [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-) ile ayarlayın. Örnek, gömülü bir ses klibi için küçük resim olarak bir JPEG kullanır.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ses Çalma Seçeneklerini Değiştirme**

PowerPoint'in **Audio Options** denetimleri, bir klibin ne zaman başlayacağını, ses seviyesini ve slayt gösterisi sırasında nasıl davranacağını belirler.

![Bir ses çerçevesi için PowerPoint Audio Options denetimleri](audio_frame_0.png)

| PowerPoint denetimi | Aspose.Slides for Android via Java yöntemi |
| --- | --- |
| Başlat | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Ses ön ayarı | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Slaytlar arasında çal | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Durdurulana kadar döngü | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Gösterim sırasında gizle | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Oynatmadan sonra geri sar | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Yumuşak Giriş | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Yumuşak Çıkış | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Ses başlangıç süresini kırp | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Ses bitiş süresini kırp | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Ses kaydırıcısı | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Örnek, ilk slayttaki ilk ses çerçevesini bulur, bir tıklamayla oynatmayı başlatmak için [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) metodunu çağırır ve düşük ses ön ayarını seçer. Klib, döngü kapalıyken slaytlar arasında çalmaya devam eder. Simge gösterim sırasında gizlenir ve klip oynatmadan sonra geri sarar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

3,5 saniyeden uzun bir klip için bu örnek, ilk 1,5 saniyeyi ve son 2 saniyeyi atlar. [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) klibin sonundan çıkarılacak süreyi alır. PowerPoint'te gösterilen bitiş zamanını elde etmek için bu değeri tam klip süresinden çıkarın. Kırpılmış klip 200 milisaniye içinde yumuşak giriş ve 500 milisaniye içinde yumuşak çıkış yapar. Tüm dört yöntem milisaniye cinsinden değer alır.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Oynatma sesini belirli bir yüzdeye ayarlamak için [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) kullanın. Bu örnek, ilk slayttaki ilk ses çerçevesini %85 olarak ayarlar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Ses Altyazılarını Yönetme**

Her ses çerçevesi, [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) aracılığıyla altyazı izlerine erişim sağlar. Koleksiyonu kullanarak klibe WebVTT altyazıları ekleyebilir, mevcut izleri dışa aktarabilir veya kaldırabilirsiniz.

### **Ses Altyazıları Ekleme**

Örnek, ilk slayta bir ses klibi gömer ve yerel bir WebVTT izini eklemek için [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) metodunu kullanır. İlk argüman iz etiketini, ikincisi zamanlanmış altyazıları içeren dosyayı belirtir.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ses Altyazılarını Çıkarma**

Bu örnek, ilk slayttaki bir ses çerçevesine eklenmiş her altyazı izini dışa aktarır. [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) tarafından döndürülen baytları bir WebVTT dosyasına yazar ve [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) tarafından döndürülen tanımlayıcıyı dosya adı olarak kullanır, böylece her iz ayrı bir çıktıya sahip olur.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            try (FileOutputStream output = new FileOutputStream(track.getCaptionId() + ".vtt")) {
                output.write(track.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Ses Altyazılarını Kaldırma**

Bireysel bir izi silmek için [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) veya [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) kullanın. Örnek, ilk slayttaki ilk ses çerçevesinden tüm altyazıları kaldırmak için [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) metodunu kullanır, ancak klibi korur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Ses Altyazılarında Bir Satırı Bulma**

İlk slayttaki ses altyazılarında bir satırı bulmak için bellekteki [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) çıktısını arayın. Düz metin bir WebVTT cue'sunda zaman satırı `-->` içerir, ardından altyazı satırları gelir ve boş bir satır cue'u sonlandırır. Bu örnek, iz etiketini ve “café” içeren her altyazı satırını yazdırır.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\r\\n|\\r|\\n")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ses Çıkarma**

Bir slayt geçişinin kendine özgü bir sesi olabilir. Bunu almak için slayt geçişinde [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) metodunu çağırın. Örnek, [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) tarafından döndürülen baytları alır ve bayt sayısını yazdırır. İlk slaytta geçiş sesi yoksa bunun yerine bir mesaj yazar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

**Aynı ses klibini birden fazla slaytta kopyalamadan yeniden kullanabilir miyim?**

Evet. Klipi sunumun [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--)ına bir kez ekleyin ve aynı ses nesnesini her slayt için [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) metoduna iletin.

**Mevcut bir ses çerçevesindeki sesi değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, değiştirilecek dosyayı göstermek üzere [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) kullanın. Gömülü bir ses için, sunumun ses koleksiyonundan başka bir klibi seçmek üzere [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) metodunu kullanın. Her iki yaklaşım da mevcut çerçeveyi korur.

**Kırpma, sunumda depolanan ses verisini değiştirir mi?**

Hayır. [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) ve [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) oynatma sınırlarını ayarlar. Tam klibi hâlâ [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) ile alabilirsiniz.