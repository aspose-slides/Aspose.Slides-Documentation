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
- resim köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java için Aspose.Slides kullanarak PowerPoint ve OpenDocument sunumlarındaki köprüleri ekleyin, biçimlendirin, güncelleyin ve kaldırın, Java örnekleriyle."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içinde bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaca hizmet eder:

* Metin, şekil veya medya çerçevesinden bir web sitesini açmak.
* Örneğin bir içerik tablosundan başka bir slayta gitmek.

Aspose.Slides for Java, bu bağlantıları eklemenizi, görünüm ve seslerini kontrol etmenizi, özelliklerini güncellemenizi ve kaldırmanızı sağlar. Aşağıdaki örnekler, köprülerle bireysel öğeler üzerinde nasıl çalışılacağını ve sunum, slayt veya metin çerçevesi seviyesinde köprülerin nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [Ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/tr/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekle**

Bir web sitesi URL'sini metne, bir şekle veya bir medya çerçevesine atayabilirsiniz. Köprünün atandığı öğe, tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

### **Metne URL Köprüleri Ekle**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi, metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metoduna bir [Hyperlink](https://reference.aspose.com/slides/tr/java/com.aspose.slides/hyperlink/) nesnesi geçirin. Sadece o metin bölümü tıklanabilir hâle gelir.

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

### **Şekillere ve Medya Çerçevelerine URL Köprüleri Ekle**

Bir şekil veya çerçeveyi tıklanabilir hâle getirmek için, onun [setHyperlinkClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metodunu çağırın. Köprü, içinde bir metin bölümü bulunmasından ziyade nesnenin kendisine aittir.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: köprüyü çerçeveye atayın ve gerekirse [setTooltip](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) metodunu çağırın.

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

## **Köprüleri Kullanarak İçindekiler Tablosu Oluşturma**

Dahili köprüler, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, birinci slayttaki “Page 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) metodunu kullanır.

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

[IHyperlink](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/) arayüzünün [setColorSource](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#setColorSource-int-) yöntemi, bir köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanılacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/hyperlinkcolorsource/) seçin ve bölümün doldurma rengini ayarlayın. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlkinde kırmızı metin doldurma kullanılır, ikincisi ise varsayılan köprü rengini korur.

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

Bir köprü, etkinleştirildiğinde bir ses çalabilir veya zaten çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [IHyperlink.setSound](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) köprüye bağlı ses dosyasını belirler.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) köprünün etkinleştirilmesinin önceki sesi durdurup durdurmayacağını kontrol eder.

#### **Köprüye Ses Ekle**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve birinci slayttaki bir düğmeye bağlar. Düğmeye tıklamak sesi çalar ve bir sonraki slayta geçiş yapar. Aynı slayttaki ikinci bir şekil tıklandığında önceki sesi durdurur, ancak bir geçiş işlemi gerçekleştirmez.

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

#### **Köprü Sesini Çıkar**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve birinci şeklin köprü sesini [getSound](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#getSound--) ve [getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudio/#getBinaryData--) aracılığıyla belleğe okur.

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

Metne veya şekle bir köprü atadıktan sonra aşağıdaki [IHyperlink](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/) yöntemlerini çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) izleyicinin bağlantı için ipucu olarak gösterebileceği metni ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) geçerli olduğunda, üst HTML çerçeve seti içinde hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) bağlantının etkinleştirilmesinin hedefini görüntülenen köprüler listesine ekleyip eklemeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) köprünün tıklandığında vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Köprüleri Kaldırma**

Değişiklik yapmadan önce metin bölümü köprüleri dahil olmak üzere köprü kapsayıcılarını toplamak için [getAnyHyperlinks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) yöntemini kullanın. Aşağıdaki örnek, birinci slayttan her iki aktivasyon tipini de kaldırır. Yalnızca bir tipi kaldırmak için sadece [removeHyperlinkClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) veya [removeHyperlinkMouseOver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) çağırın; bir tıklama eylemini kaldırmak, fare üzerine eylemini kaldırmaz.

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

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) seçili kapsamda her iki aktivasyon tipini tek bir çağrıyla kaldırır. Seçimli temizlik ve ana, yerleşim ve notların kapsanması için [Köprüleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluşturma**

Sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envanterleyin. [getAnyHyperlinks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkcontainer/) nesneleri döndürür, düz bir URL dizesi listesi değil. Her kapsayıcıda hem [getHyperlinkClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) inceleyin. Bunlar bağımsızdır: aynı kapsayıcı her iki eylemi de gösterebilir, bu yüzden tam bir rapor her kapsayıcı için iki satır gerektirebilir.

Yalnızca şekil düzeyindeki köprüleri taramak, metin bölümlerine eklenmiş bağlantıları kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve dönen kapsayıcıları saklayın, böylece daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin-Çerçeve Kapsamlarını Sorgula**

[IHyperlinkQueries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkqueries/) arabirimi, [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) ve [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) üzerinden kullanılabilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) tıklama eylemi olan kapsayıcıları döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) fare üzerine eylemi olan kapsayıcıları döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) bir veya iki eylemi olan kapsayıcıları döndürür.

Aşağıdaki örnek, harici bir tıklama bağlantısı, bir dosya fare üzerine bağlantısı, iç slayt navigasyonu, bir metin fare üzerine bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` oluşturur. Bu eylemlerden hiçbiri çalıştırılmaz. Aynı üç sorgu her kapsamda çalışır; sayılar kapsayıcıları tanımlar, eylem toplamlarını değil. Metin-çerçeve kapsamı, içeren şeklin kendi bağlantılarını dışlar.

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

Bu örnek için, sunum ve slayt sorguları her biri üç tıklama kapsayıcısı, iki fare üzerine kapsayıcısı ve bir eylemi olan üç kapsayıcı rapor eder. Metin-çerçeve sorgusu her kategoride bir kapsayıcı rapor eder.

### **Eylemleri ve Hedefleri Sınıflandırma**

[IHyperlink.getActionType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#getActionType--) kullanarak bir eylemi yorumlamadan önce hedefini yorumlayın. [HyperlinkActionType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/hyperlinkactiontype/) değerleri web navigasyonundan daha fazlasını kapsar:

| Değerler | Denetim İçin Anlamı |
| --- | --- |
| `Hyperlink` | Dış köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta iç yönlendirme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Yerleşik slayt gösterisi navigasyonu, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandır veya özel bir gösteri başlat. |
| `StartMacro` | Bir makroyu çalıştır. |
| `StartProgram` | Bir program başlat. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunum aç; web URL'lerinden ayrı incele. |
| `StartStopMedia` | Ortam çalmayı başlat veya durdur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yok veya gözden geçirme gerektiren tanımlanamayan bir eylem. |

Harici hedefleri [getExternalUrl](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#getExternalUrl--) ile, belirli iç hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#getTargetSlide--) ile okuyun. İç eylemler ve yerleşik komutlar harici bir URL içermeyebilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [getExternalUrlOriginal](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) tarafından döndürülen değeri koruyun ve mevcutsa [getTooltip](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#getTooltip--) tarafından döndürülen ipucunu ekleyin.

### **Köprüleri Raporla, Temizle ve Doğrula**

Aşağıdaki Java örneği mevcut bir sunumu okur (yukarıda oluşturulan dosyayı kullanın), `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` kaydeder ve tekrar açarak her iki aktivasyon tipini yeniden kontrol eder. Değişiklik yapmadan önce kapsayıcıları toplar ve aynı kapsayıcının iki kez işlenmesini önlemek için referans eşitliğini kullanır. Sunum sorguları sıradan slaytları kapsar; paket çapında bir envanter için aynı zamanda ana, yerleşim, not ve mevcut olduğunda not ve el ilanı analarını da açıkça sorgular.

Rapor, mevcut olduğunda bir‑bazlı slayt indeksini ve [getSlideId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/#getSlideId--) değerini kaydeder. [ISlideComponent.getSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecomponent/#getSlide--) desteklenen kapsayıcılar için sahibi slaytı sağlar. Ana, yerleşim ve notların sıradan bir slayt indeksi yoktur ve kapsamlarıyla tanımlanırlar. Şekil kapsayıcıları ve metin‑bölüm biçimleme kapsayıcıları ayrı ayrı etiketlenir; diğer kapsayıcı tipleri çalışma zamanındaki tip adlarını korur. Her kapsayıcı, iki eylemin ilişkilendirilebilmesi için rapor‑yerel bir kimlik alır. Rapor, eylem tiplerini Java enum'unda tanımlı tam sayı sabitleri olarak saklar.

Bu kasıtlı olarak kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL'lerini ve geçerli iç slayt hedeflerini izin verir. Makroları, programları, dosya eylemlerini, diğer slayt gösterisi eylemlerini, bilinmeyen eylemleri ve diğer URL şemalarını reddeder. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güven oluşturmaz: uygulamanız için host izin listeleri ve diğer kontroller ekleyin. Hem orijinal hem de normalleştirilmiş harici URL'ler kontrol edilir. Örnek, linkleri takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, kapsayıcının [getHyperlinkManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) şu yöntemleri destekler: [setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Burada, yasak dış tıklama bağlantıları sabit bir HTTPS açılış sayfası ile değiştirilir; diğer yasak tıklamalar ve yasak fare‑üzeri eylemler bağımsız olarak kaldırılır. `replaceExternalClicks` değerini `false` yaparak tüm politika ihlallerini kaldırabilirsiniz. Dağıtımdan önce uygulama sahipli bir değişim sayfası seçin.

Raporun dışa aktarma bayrağı, temkinli bir PDF inceleme politikası kullanır: fare‑üzeri eylemler ve dış bağlantı veya belirli bir slayt atlaması dışındaki her şey potansiyel olarak desteklenmez olarak işaretlenir. Bu bir inceleme ipucu, yetenek testi veya işaretsiz bağlantıların dışa aktarma sırasında hayatta kalacağının garantisi değildir. Desteklenen [PDF](/slides/tr/java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/java/convert-powerpoint-to-html/) dışa aktarmaları, eyleme, dışa aktarım seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir. Raster [görüntüler](/slides/tr/java/convert-powerpoint-to-png/) ve [video](/slides/tr/java/convert-powerpoint-to-video/) etkileşimli köprüleri koruyamaz; bu çıktıların denetimi için her eylemi işaretleyin.

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

Yukarıda oluşturulan girdi ile rapor beş eylem satırı içerir. Dosya fare‑üzeri bağlantısı ve makro tıklaması kaldırılırken, HTTPS bağlantıları ve iç slayt navigasyonu kalır. Doğrulama sıfır yasak eylem yazdırır. Yasak bir dış tıklama URL'si içeren bir girdi, değişim dalını da çalıştırır. İzinli bir tıklama ve yasak bir fare‑üzeri içeren bir kapsayıcı, tıklama eylemini korur.

Bu seçmeli temizlik, politika göz ardı edilse de kapsam içinde her iki aktivasyon tipini kaldıran [removeAllHyperlinks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) yönteminden farklıdır. Buradaki doğrulama yalnızca köprü eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içeriği kaldırmaz ve dışa aktarılmış bir PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme veya onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint'te bölümler slaytları gruplar, ancak dahili bir köprü bireysel bir slaytı hedef alır. Bir bölüme navigasyon oluşturmak için o bölümün ilk slaytına bağlayın.

**Ana slayt öğelerine bir köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Ana slayt ve yerleşim öğeleri köprüleri destekler. Bu öğelerdeki bağlantılar, ilgili ana veya yerleşimi kullanan slayt gösterisi sırasında kullanılabilir.

**Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarıldığında korunur mu?**

Desteklenen PDF ve HTML dışa aktarmaları köprüleri koruyabilir; raster görüntüler ve video koruyamaz. Ayrıntılar için [Köprüleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.