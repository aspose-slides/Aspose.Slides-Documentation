---
title: Android'de Sunum Köprülerini Yönetme
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/androidjava/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprü biçimlendir
- köprü kaldır
- köprü güncelle
- metin köprüsü
- slayt köprüsü
- şekil köprüsü
- resim köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument sunumlarında Java örnekleri kullanarak köprü ekleme, biçimlendirme, güncelleme ve kaldırma."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içindeki bir konuma bağlar. PowerPoint’te köprüler genellikle iki amaçla kullanılır:

* Metin, şekil veya medya çerçevesinden bir web sitesini açmak.
* Örneğin, bir içerik tablosundan başka bir slayta geçiş yapmak.

Aspose.Slides for Android via Java, bu köprüleri eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, bireysel öğelerde köprülerle nasıl çalışılacağını ve sunum, slayt veya metin‑çerçevesi seviyesinde köprülere nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/tr/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekleme**

Bir web sitesi URL’sini metne, şekle veya medya çerçevesine atayabilirsiniz. Köprüyü atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçili metni, bir şekil veya çerçeve ise slayt nesnesini bağlar.

### **Metne URL Köprüleri Ekleme**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi [Hyperlink](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/hyperlink/) nesnesini metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metoduna gönderin. Yalnızca o metin bölümü tıklanabilir olur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Şekillere ve Medya Çerçevelerine URL Köprüleri Ekleme**

Bir şekli veya çerçeveyi tıklanabilir yapmak için, onun [setHyperlinkClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metodunu çağırın. Köprü, içinde metin bölümü bulunan nesneye değil, nesnenin kendisine aittir.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: köprüyü çerçeveye atayın ve gerekirse [setTooltip](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) metodunu çağırın.

Aşağıdaki örnek bir dikdörtgeni tıklanabilir hâle getirir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **İçerik Tablosu Oluşturmak İçin Köprüleri Kullanma**

Dahili köprüler, okuyucuların bir içerik tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slayttaki “Sayfa 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) metodunu kullanır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Köprüleri Biçimlendirme**

### **Renk**

[IHyperlink](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/) arayüzünün [setColorSource](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) metodu, bir köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/hyperlinkcolorsource/) seçilir ve bölümün doldurma rengi ayarlanır. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlki kırmızı metin doldurması kullanırken, ikincisi varsayılan köprü rengini korur.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Ses**

Bir köprü etkinleştirildiğinde ses çalabilir veya zaten çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki metodları kullanın:

- [IHyperlink.setSound](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) köprüyü ses dosyasıyla ilişkilendirir.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) köprünün etkinleştirilmesiyle önceki sesin durdurulup durdurulmayacağını belirler.

#### **Köprü Sesi Ekleme**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slaydın üzerindeki bir düğmeye ilişkilendirir. Düğmeye tıklandığında ses çalar ve bir sonraki slayta geçiş yapılır. Aynı slayttaki ikinci bir şekil, tıklandığında önceki sesi durdurur, ancak bir geçiş gerçekleştirmez.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Köprü Sesini Çıkarma**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [getSound](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#getSound--) ve [getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudio/#getBinaryData--) metodlarıyla belleğe okur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **İpucu ve Etkileşim Ayarları**

Bir köprüyü metne veya şekle atadıktan sonra aşağıdaki [IHyperlink](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/) metodlarını çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) izleyicinin bağlantı için gösterdiği ipucu metnini ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) geçerli olduğunda, bir üst HTML çerçeve kümesi içinde hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) köprünün etkinleştirilmesinin hedefini görüntülenen köprüler listesine ekleyip eklemeyeceğini denetler.
- [setHighlightClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) köprünün tıklandığında vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Köprüleri Kaldırma**

Köprü konteynerlerini (metin‑bölümü köprüleri dahil) değiştirmeden önce toplamak için [getAnyHyperlinks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) metodunu kullanın. Aşağıdaki örnek ilk slayttan iki etkinleştirme tipini (tıkla ve fare üzerine gel) kaldırır. Yalnızca bir tip kaldırmak isterseniz, sadece [removeHyperlinkClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) veya [removeHyperlinkMouseOver](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metodunu çağırın; bir tıklama eylemini kaldırmak, fare‑üzerine‑gel eylemini kaldırmaz.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) metodunu kullanarak seçili kapsamda iki etkinleştirme tipini tek bir çağrıyla kaldırabilirsiniz. Üstatlar, yerleşimler ve notlar dahil olmak üzere seçici temizlik ve kapsamlı kapsama hakkında daha fazla bilgi için **[Köprüleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks)** bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluşturma**

Sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [getAnyHyperlinks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) metodu, URL dizesi listesi yerine [IHyperlinkContainer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkcontainer/) nesnelerini döndürür. Her konteynerdeki [getHyperlinkClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) ve [getHyperlinkMouseOver](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) metodlarını inceleyin. Bunlar bağımsızdır: aynı konteyner iki eylemi de barındırabilir, bu yüzden tam bir rapor her konteyner için iki satır gerektirebilir.

Yalnızca şekil‑seviyesi köprüleri taramak, metin bölümlerine eklenmiş köprüleri kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve dönen konteynerleri tutarak daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin‑Çerçeve Kapsamlarını Sorgulama**

[IHyperlinkQueries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkqueries/) arabirimi, [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) ve [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) üzerinden erişilebilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) tıklama eylemi içeren konteynerleri döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) fare‑üzerine‑gel eylemi içeren konteynerleri döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) bir veya iki eylemi içeren konteynerleri döndürür.

Aşağıdaki örnek, dış bağlantı tıklama, dosya fare‑üzerine‑gel, dahili slayt geçişi, metin fare‑üzerine‑gel ve makro eylemleri içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemler yürütülmez. Üç sorgu her kapsamda aynı şekilde çalışır; sayılar konteyner sayısını, eylem toplamını değil gösterir. Metin‑çerçeve sorgusu, içinde bulunduğu şeklin kendi bağlantılarını içermez.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu örnek için, sunum ve slayt sorguları üç tıklama konteyneri, iki fare‑üzerine‑gel konteyneri ve her iki eylemi de içeren üç konteyner raporlar. Metin‑çerçeve sorgusu her kategori için bir konteyner raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

Bir eylemi yorumlamadan önce, onun hedefini yorumlamak için [IHyperlink.getActionType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#getActionType--) metodunu kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/hyperlinkactiontype/) değerleri web gezinmesinden daha fazlasını kapsar:

| Değerler | Denetim İçin Anlamı |
| --- | --- |
| `Hyperlink` | Dış köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta dahili geçiş. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi içinde yerleşik gezinme komutları. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırma veya özel gösteri başlatma. |
| `StartMacro` | Bir makro çalıştırma. |
| `StartProgram` | Bir program başlatma. |
| `OpenFile`, `OpenPresentation` | Dosya veya başka bir sunum açma; web URL’lerinden ayrı değerlendirin. |
| `StartStopMedia` | Medya oynatmayı başlatma veya durdurma. |
| `NoAction`, `Unknown` | Gezinti eylemi yok veya tanınmayan eylem; inceleme gerektirir. |

Dış hedefleri [getExternalUrl](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) metodundan, dahili hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) metodundan okuyun. Dahili eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, konteynerin eylem içermediği anlamına gelmez. Normalleştirilmiş URL’den farklıysa, [getExternalUrlOriginal](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) değerini koruyun ve varsa [getTooltip](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) tarafından döndürülen ipucu metnini ekleyin.

### **Köprüleri Raporla, Temizle ve Doğrula**

Aşağıdaki Java örneği, mevcut bir sunumu (yukarıda oluşturulan dosyayı) okur, `hyperlink-audit.json` dosyasına yazar, bir politika uygular, `hyperlink-sanitized.pptx` dosyasını kaydeder ve ardından iki etkinleştirme tipini tekrar kontrol eder. Değişiklik yapmadan önce konteynerleri toplar ve aynı konteynerin iki kez işlenmesini önlemek için referans eşitliğini kullanır. Sunum sorguları normal slaytları kapsar; paket‑geneli envanter için ayrıca üst‑slaytlar, yerleşimler, notlar ve varsa not‑ve‑el kitabı üst‑slaytları da sorgular.

Rapor, bir‑bazlı slayt indeksini ve mümkünse [getSlideId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) değerini kaydeder. [ISlideComponent.getSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecomponent/#getSlide--) desteklenen konteynerler için sahibi slaytı sağlar. Üstatlar, yerleşimler ve notlar normal slayt indeksine sahip değildir ve kapsamlarıyla tanımlanır. Şekil konteynerleri ve metin‑bölümü biçimleme konteynerleri ayrı ayrı etiketlenir; diğer konteyner tipleri çalışma zamanı tip adlarını korur. Her konteyner rapor içinde bir yerel kimlik alır, böylece iki eylemi ilişkilendirilebilir. Rapor, eylem tiplerini Java enum’unda tanımlı tamsayı sabitleri olarak saklar.

Bu kısıtlayıcı uygulama politikası yalnızca kesin HTTPS URL’lerini ve geçerli dahili slayt hedeflerini kabul eder. Makrolar, programlar, dosya eylemleri, diğer slayt gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güven sağlar demek değildir: uygulamanıza host izin listeleri ve ek denetimler ekleyin. Hem orijinal hem de normalleştirilmiş dış URL’ler kontrol edilir. Örnek, linkleri takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, konteynerin [getHyperlinkManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) yöntemi [setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metodlarını destekler. Burada, yasak dış tıklama köprüleri sabit bir HTTPS açılış sayfası ile değiştirilir; diğer yasak tıklamalar ve yasak fare‑üzerine‑gel eylemleri bağımsız olarak kaldırılır. Politikaya uymayan tüm köprüleri kaldırmak için `replaceExternalClicks` değerini `false` yapın. Dağıtımdan önce uygulamaya ait bir değişim sayfası seçin.

Raporun dışa aktarma bayrağı, temkinli bir PDF inceleme politikasına dayanır: fare‑üzerine‑gel eylemleri ve dış bağlantı ya da belirli slayt atlamı dışındaki her şey potansiyel olarak desteklenmez olarak işaretlenir. Bu bir inceleme ipucudur, yetenek testi ya da işaretlenmemiş linklerin dışa aktarma sırasında korunacağı garantisi değildir. Desteklenen [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarma seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir; raster [görüntüler](/slides/tr/androidjava/convert-powerpoint-to-png/) ve [videolar](/slides/tr/androidjava/convert-powerpoint-to-video/) etkileşimli köprüleri koruyamaz; bu çıktılar için denetleme sırasında her eylem işaretlenmelidir.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Bu raporun düz satırlarını ek bir JSON bağımlılığı olmadan seri hale getir.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Yukarıdaki girişle oluşturulan rapor, beş eylem satırı içerir. Dosya fare‑üzerine‑gel bağlantısı ve makro tıklaması kaldırılır, HTTPS bağlantıları ve dahili slayt geçişi kalır. Doğrulama, yasak eylem bulunmadığını bildirir. Yasak bir dış tıklama URL’si içeren bir giriş, değişim dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare‑üzerine‑gel eylemi içeren bir konteyner, tıklama eylemini korur.

Bu seçici temizlik, [removeAllHyperlinks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) metodunun seçilen kapsamda politikadan bağımsız olarak iki etkinleştirme tipini de kaldırmasıyla farklıdır. Buradaki doğrulama yalnızca köprü eylemlerini denetler; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içerikleri kaldırmaz ve dışa aktarılan PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme veya onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint’te bölümler slaytları gruplar, ancak bir dahili köprü yalnızca tek bir slaytı hedefler. Bir bölüme geçiş oluşturmak için, o bölümün ilk slaytına bağlanın.

**Üstat slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Üstat slayt ve yerleşim öğeleri köprüleri destekler. Bu öğelere eklenen köprüler, ilgili üstat veya yerleşimi kullanan slayt gösterisi sırasında erişilebilir.

**Köprüler PDF, HTML, görüntü veya video olarak dışa aktarılırken korunur mu?**

Desteklenen PDF ve HTML dışa aktarımları köprüleri koruyabilir; raster görüntüler ve video koruyamaz. Köprüleri koruma konusundaki detaylar için **[Köprüleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks)** bölümüne bakın.