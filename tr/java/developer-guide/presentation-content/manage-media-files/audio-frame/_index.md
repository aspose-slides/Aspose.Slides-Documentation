---
title: Java Kullanarak Sunumlarda Ses Çerçevelerini Yönetin
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/java/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- ses çıkar
- Java
- Aspose.Slides
description: "Sesleri slaytlara gömün, ses simgesini değiştirin, oynatmayı yapılandırın, WebVTT altyazılarını yönetin ve Java için Aspose.Slides ile slayt geçiş seslerini çıkarın."
---
## **Genel Bakış**

Bir ses çerçevesi, bir slaytta ses çalmanıza olanak tanır. Aspose.Slides for Java ile bir ses klibi gömebilir, onu temsil eden resmi seçebilir, oynatmayı ayarlayabilir ve altyazılar ekleyebilirsiniz. Ayrıca bir slayt geçişine atanmış sesi de alabilirsiniz.

## **Ses Çerçeveleri Oluştur**

Yerel bir ses klibini ilk slayta gömmek için [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) kullanın. İlk iki koordinat çerçeveyi slaytta konumlandırır ve sonraki iki değer genişliğini ve yüksekliğini ayarlar; tüm değerler puan cinsindendir. Bu örnek, klibi otomatik olarak başlatmak için [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) çağırır ve yüksek ses ön ayarını seçmek için [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) metodunu kullanır.

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

## **Ses Çerçevesi Küçük Resmini Değiştir**

Varsayılan olarak, bir ses çerçevesi bir hoparlör simgesi gösterir. Özel bir küçük resim göstermek için sunuma [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) ile bir resim ekleyin ve çerçevenin resmine [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-) ile ayarlayın. Örnek, gömülü bir ses klibi için küçük resim olarak bir JPEG kullanır.

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

## **Ses Çalma Seçeneklerini Değiştir**

PowerPoint'in **Audio Options** denetimleri, bir klibin ne zaman başlayacağını, ses seviyesini ve slayt gösterisi sırasında nasıl davranacağını belirler.

![Ses çerçevesi için PowerPoint Ses Seçenekleri denetimleri](audio_frame_0.png)

| PowerPoint denetimi | Aspose.Slides for Java yöntemi |
| --- | --- |
| Başlat | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Ses ön ayarı | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Slaytlar arasında çal | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Durdurulana kadar döngü | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Gösterim sırasında gizle | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Oynatmadan sonra geri sar | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Örnek, ilk slayttaki ilk ses çerçevesini bulur, tıklamayla oynatmayı başlatmak için [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) çağırır ve düşük ses ön ayarını seçer. Klip, döngü devre dışı bırakılarak slaytlar arasında devam eder. Simge gösterim sırasında gizli kalır ve klip oynatmadan sonra geri sarar.

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

3,5 saniyeden uzun bir klip için bu örnek, ilk 1,5 saniyeyi ve son 2 saniyeyi atlar. [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) klibin sonundan çıkarılacak süreci alır. PowerPoint'te gösterilen bitiş zamanını elde etmek için bu offset'i tüm klip süresinden çıkarın. Kırpılmış klip 200 milisaniye içinde fade in, 500 milisaniye içinde fade out olur. Dört yöntem de milisaniye cinsinden değer alır.

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

Oynatma hacmini belirli bir yüzdeye ayarlamak için [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) kullanın. Bu örnek, ilk slaydın ilk ses çerçevesini %85 olarak ayarlar.

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

## **Ses Altyazılarını Yönet**

Her ses çerçevesi, [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) aracılığıyla altyazı izlerine erişim sağlar. Koleksiyonu, klibe WebVTT altyazıları eklemek, mevcut izleri dışa aktarmak veya silmek için kullanın.

### **Ses Altyazısı Ekle**

Örnek, ilk slayta bir ses klibi gömer ve yerel bir WebVTT izini eklemek için [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) kullanır. İlk argüman iz etiketi sağlar, ikinci ise zamanlı altyazıları içeren dosyayı belirtir.

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

### **Ses Altyazılarını Çıkar**

Bu örnek, ilk slaydın ses çerçevesine eklenmiş her altyazı izini dışa aktarır. [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) tarafından döndürülen baytları bir WebVTT dosyasına yazar ve [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) tarafından döndürülen tanımlayıcıyı dosya adı olarak kullanır; böylece her iz ayrı bir çıktı alır.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            Path output = Paths.get(track.getCaptionId() + ".vtt");
            Files.write(output, track.getBinaryData());
        }
    }
} finally {
    presentation.dispose();
}
```

### **Ses Altyazılarını Kaldır**

Tek bir iz silmek için [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) veya [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) kullanın. Örnek, klibi korurken ilk slaydın ilk ses çerçevesindeki tüm altyazıları kaldırmak için [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) metodunu kullanır.

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

### **Ses Altyazılarında Bir Satır Bul**

İlk slayttaki ses altyazılarında bir satır bulmak için [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) tarafından döndürülen metni bellek içinde arayın. Düz metin bir WebVTT işaretinde, zaman satırı `-->` içerir, ardından altyazı satırları gelir ve boş bir satır işareti sonlandırır. Bu örnek, iz etiketini ve “café” içeren her altyazı satırını yazdırır.

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
            for (String line : captions.split("\\R")) {
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

## **Ses Çıkar**

Bir slayt geçişinin kendi sesi olabilir. Onu almak için slayt geçişinde [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) çağırın. Örnek, [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) tarafından döndürülen baytlara erişir ve bayt sayısını yazdırır. Eğer ilk slaytta geçiş sesi yoksa, bunun yerine bir mesaj yazdırır.

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

## **FAQ**

**Aynı ses klibini birden çok slaytta, kopyalamadan yeniden kullanabilir miyim?**

Evet. Klipi bir kez sunumun [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) koleksiyonuna ekleyin ve her slayt için aynı ses nesnesini [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) metoduna geçirin.

**Mevcut bir ses çerçevesindeki sesi değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, değiştirme dosyasına işaret etmek amacıyla [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) kullanın. Gömülü bir ses için, sunumun ses koleksiyonundan başka bir klibi [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) ile seçin. Her iki yaklaşım da mevcut çerçeveyi korur.

**Kırpma, sunumda depolanan ses verisini değiştirir mi?**

Hayır. [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) ve [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) oynatma sınırlarını ayarlar. Yine de tam klibi [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) ile alabilirsiniz.