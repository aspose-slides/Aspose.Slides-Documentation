---
title: Java'da Sunum Köprülerini Yönetme
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/java/manage-hyperlinks/
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
- görüntü köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarında köprüleri ekleyin, biçimlendirin, güncelleyin ve kaldırın, Java örnekleri kullanarak."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içinde bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaca hizmet eder:

* Metin, şekil veya medya çerçevesinden bir web sitesini açmak.
* Örneğin bir içindekiler tablosundan başka bir slayta gitmek.

Aspose.Slides for Java, bu bağlantıları eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, bireysel öğeler üzerindeki köprülerle nasıl çalışılacağını ve sunum, slayt veya metin‑çerçevesi seviyesinde köprülere nasıl erişileceğini gösterir.

{{% alert color="info" title="Not" %}}

Sunumları ayrıca [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.

{{% /alert %}} 

## **URL Köprüleri Ekleme**

Bir web sitesi URL'sini metne, şekle veya medya çerçevesine atayabilirsiniz. Köprüyü atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

Göreceli köprüler içeren sunumlar için, belge‑seviyesi temel URL'sini okumak, değiştirmek veya temizlemek amacıyla [Hyperlink Base Yönetimi](/slides/tr/java/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Köprüsü Ekleme**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) yöntemine bir [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlink/) nesnesi iletmelisiniz. Yalnızca o metin bölümü tıklanabilir olur.

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

### **Şekillere ve Medya Çerçevelerine URL Köprüsü Ekleme**

Bir şekil veya çerçeveyi tıklanabilir hâle getirmek için, nesnenin [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) yöntemini çağırın. Köprü, içinde bir metin bölümü bulunmasından bağımsız olarak nesneye aittir.

Aynı yaklaşım resim, ses ve video çerçeveleri için de geçerlidir: köprüyü çerçeveye atayın ve gerektiğinde [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) yöntemini çağırın.

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

## **İçindekiler Tablosu Oluşturmak İçin Köprü Kullanma**

İç köprüler, okuyucuların bir içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slayttaki “Sayfa 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) yöntemini kullanır.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

[IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) arayüzünün [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) yöntemi, köprünün sunumun köprü rengine mi yoksa metin bölümünün biçimlendirmesine mi göre renklendirileceğini belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkcolorsource/) seçip bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlki kırmızı dolgu renkli, ikincisi varsayılan köprü rengini korur.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Bir köprü, etkinleştirildiğinde bir ses çalabilir veya zaten çalmakta olan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) köprüye ilişkilendirilecek sesi belirtir.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) köprünün etkinleştirilmesiyle önceki sesin durdurulup durdurulmayacağını kontrol eder.

#### **Köprü Sesi Ekleme**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slayd üzerindeki bir düğmeye ilişkilendirir. Düğmeye tıklandığında ses çalar ve bir sonraki slayta geçilir. Aynı slaydın ikinci şekli tıklandığında önceki sesi durdurur, ancak gezinme işlemi yapmaz.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

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

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getSound--) ve [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) yöntemleriyle belleğe okur.

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

Bir köprüyü metne veya şekle atadıktan sonra aşağıdaki [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) yöntemlerini çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) izleyicinin bağlantı için bir ipucu olarak görüntüleyebileceği metni ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) uygulanabilir olduğunda, bir üst HTML çerçeve seti içinde hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) bağlantının etkinleştirilmesinin hedefini görüntülenen köprüler listesine ekleyip eklemeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) tıklandığında köprünün vurgulanıp vurgulanmayacağını belirler.

## **Sunumlardan Köprüleri Kaldırma**

Köprü konteynerlerini (metin‑bölümü köprüleri dahil) değiştirmeden önce toplamak için [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) yöntemini kullanın. Aşağıdaki örnek, ilk slayttaki hem tıklama hem de fare‑üzerinde iki etkinleştirme tipini kaldırır. Yalnızca bir tip kaldırmak isterseniz, sadece [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) veya [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) yöntemini çağırın; tıklama eylemini kaldırmak fare‑üzerindeki eylemi kaldırmaz.

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

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) seçili kapsamda her iki etkinleştirme tipini tek bir çağrıyla kaldırır. Ustalar, düzenler ve notlar dahil olmak üzere seçici temizlik ve kapsamlı kapsama için [Köprüleri Raporlama, Temizleme ve Doğrulama](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluşturma**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) yöntemi, URL dizesi listesi yerine [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) nesneleri döndürür. Her konteynerdeki [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) ve [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) yöntemlerini inceleyin. Bunlar bağımsızdır: aynı konteyner iki eylemi de içerebilir; bu yüzden tam rapor bir konteyner için iki satır gerektirebilir.

Sadece şekil‑seviyesi köprüleri sorgulamak, metin bölümlerine eklenmiş köprüleri kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve daha sonra eylemlerini güncellemek veya kaldırmak için döndürülen konteynerleri saklayın.

### **Sunum, Slayt ve Metin‑Çerçeve Kapsamlarını Sorgulama**

[IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/) arayüzüne sırasıyla [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), ve [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) üzerinden erişilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) tıklama eylemi içeren konteynerleri döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) fare‑üzerinde eylemi içeren konteynerleri döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) bir ya da her iki eylemi içeren konteynerleri döndürür.

Aşağıdaki örnek, dış tıklama köprüsü, dosya fare‑üzerinde köprüsü, iç slayt navigasyonu, metin fare‑üzerinde köprüsü ve makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemler çalıştırılmaz. Aynı üç sorgu her kapsamda çalışır; sayıların anlamı konteyner sayısıdır, eylem toplamı değildir. Metin‑çerçeve kapsamı, kapsayan şeklin kendi köprülerini içermez.

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

Bu örnek için, sunum ve slayt sorguları üç tıklama konteyneri, iki fare‑üzerinde konteyner ve üç ortak konteyner raporlar. Metin‑çerçeve sorgusu her kategoride bir konteyner raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

Bir eylemi yorumlamadan önce hedefini yorumlamak için [IHyperlink.getActionType](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getActionType--) yöntemini kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkactiontype/) değerleri web navigasyonunun ötesine geçer:

| Değer | Denetim İçin Anlamı |
| --- | --- |
| `Hyperlink` | Dış köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta iç navigasyon. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi içinde yerleşik gezinme. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandır veya özel gösteriyi başlat. |
| `StartMacro` | Bir makroyu çalıştır. |
| `StartProgram` | Bir programı başlat. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunumu aç; web URL'lerinden ayrı değerlendirin. |
| `StartStopMedia` | Medya oynatmayı başlat veya durdur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yok veya tanınmayan eylem; inceleme gerektirir. |

Dış hedefleri [getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) ile, belirli iç hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTargetSlide--) ile okuyun. İç eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, konteynerin eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) değerini koruyun ve mümkünse [getTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTooltip--) ile dönen ipucunu ekleyin.

### **Köprüleri Raporlama, Temizleme ve Doğrulama**

Aşağıdaki Java örneği mevcut bir sunumu (yukarıdaki dosyayı) okur, `hyperlink-audit.json` oluşturur, bir politika uygular, `hyperlink-sanitized.pptx` kaydeder ve tekrar açarak iki etkinleştirme tipini yeniden kontrol eder. Değişiklik öncesi konteynerleri toplar ve aynı konteyneri iki kez işlememek için referans eşitliğini kullanır. Sunum sorguları sıradan slaytları kapsar; paket‑geneli envanter için ayrıca ustalar, düzenler, notlar ve varsa not‑ve el ilanı ustaları da sorgulanır.

Rapor, mevcut olduğunda bir‑tabanlı slayt indeksini ve [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) değerini kaydeder. [ISlideComponent.getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) desteklenen konteynerler için sahip slaytı sağlar. Ustalar, düzenler ve notlar normal slayt indeksi taşımadığından kapsamlarıyla tanımlanır. Şekil konteynerleri ve metin‑bölümü biçim konteynerleri ayrı ayrı etiketlenir; diğer konteyner tipleri çalışma zamanı sınıf adını korur. Her konteyner, iki eylemin ilişkili olabilmesi için rapor‑yerel bir kimlik alır. Rapor, eylem tiplerini Java enum’unda tanımlı tam sayı sabitleri olarak saklar.

Bu kasıtlı olarak kısıtlayıcı uygulama politikası, yalnızca mutlak HTTPS URL’lerini ve geçerli iç slayt hedeflerini kabul eder. Makrolar, programlar, dosya eylemleri, diğer slayt gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenliği kararı değildir. HTTPS tek başına güven oluşturmaz: uygulamanız için host beyaz listeleri ve diğer kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL’ler kontrol edilir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, konteynerin [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) yöntemi [setExternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) işlevlerini destekler. Burada, yasak dış tıklama köprüleri sabit bir HTTPS açılış sayfası ile değiştirilir; diğer yasak tıklama ve fare‑üzerinde eylemler bağımsız olarak kaldırılır. `replaceExternalClicks` değerini `false` yaparsanız tüm politika ihlallerini kaldırırsınız. Dağıtımdan önce uygulama sahipli bir değiştirme sayfası seçin.

Raporun dışa aktarım bayrağı, temkinli bir PDF inceleme politikası uygular: fare‑üzerindeki eylemleri ve dış bağlantı olmayan ya da belirli slayt atlaması dışındaki her şeyi potansiyel olarak desteklenmeyen olarak işaretler. Bu bir inceleme ipucu olup, bir yetenek testi ya da işaretlenmemiş bağlantıların dışa aktarımda korunacağı garantisi değildir. Desteklenen [PDF](/slides/tr/java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/java/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarma seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir. Raster [görseller](/slides/tr/java/convert-powerpoint-to-png/) ve [videolar](/slides/tr/java/convert-powerpoint-to-video/) etkileşimli köprüleri koruyamaz; bu çıktılar için denetim yaparken tüm eylemleri işaretleyin.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
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

    // Bu raporun düz satırlarını ek bir JSON bağımlılığı olmadan serileştir.
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
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
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
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

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

Yukarıda oluşturulan giriş ile rapor beş eylem satırı içerir. Dosya fare‑üzerinde köprüsü ve makro tıklaması kaldırılır, HTTPS köprüleri ve iç slayt navigasyonu kalır. Doğrulama sıfır yasaklı eylem çıktılar. Yasak bir dış tıklama URL’si içeren bir giriş, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare‑üzerinde eylemi olan bir konteyner, tıklama eylemini tutar.

Bu seçici temizlik, politika göz önünde bulundurularak [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) yönteminin tüm aktifleştirme tiplerini kapsamdan bağımsız olarak kaldırmasından farklıdır. Buradaki doğrulama yalnızca köprü eylemlerini denetler; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içeriği kaldırmaz ve dışa aktarılmış PDF ya da HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölümün ya da bölümün ilk slaytına nasıl bağlanabilirim?**

PowerPoint’te bölümler slaytları gruplar, ancak iç köprü tek bir slaytı hedef alır. Bir bölüme gezinme oluşturmak için, o bölümün ilk slaytına bağlayın.

**Usta slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Usta slayt ve düzen öğeleri köprüleri destekler. Bu öğelere eklenen köprüler, ilgili usta ya da düzeni kullanan slayt gösterisi sırasında kullanılabilir.

**Köprüler PDF, HTML, görseller veya video olarak dışa aktarıldığında korunur mu?**

Desteklenen PDF ve HTML dışa aktarımları köprüleri koruyabilir; raster görseller ve videolar koruyamaz. Ayrıntılar için [Köprüleri Raporlama, Temizleme ve Doğrulama](#report-sanitize-and-verify-hyperlinks) bölümündeki dışa aktarım hususlarına bakın.