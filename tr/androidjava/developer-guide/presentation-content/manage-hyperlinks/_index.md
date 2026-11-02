---
title: Android'de Sunum Köprülerini Yönet
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/androidjava/manage-hyperlinks/
keywords:
- URL ekle
- Köprü ekle
- Köprü oluştur
- Köprü biçimlendir
- Köprü kaldır
- Köprüyü güncelle
- Metin köprüsü
- Slayt köprüsü
- Şekil köprüsü
- Görsel köprüsü
- Video köprüsü
- Değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak, Java örnekleriyle PowerPoint ve OpenDocument sunumlarında köprüleri ekleyin, biçimlendirin, güncelleyin ve kaldırın."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içinde bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaca hizmet eder:

* Metinden, bir şekilden veya bir medya çerçevesinden bir web sitesini açma.
* Örneğin içindekiler tablosundan başka bir slayta gitme.

Aspose.Slides for Android via Java, bu köprüleri eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, tek tek öğelerde köprülerle nasıl çalışılacağını ve köprülere sunum, slayt veya metin‑çerçevesi seviyesinde nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Köprülerini Ekle**

Metne, bir şekle veya bir medya çerçevesine bir web sitesi URL'si atayabilirsiniz. Köprüyü atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

Göreceli köprüler içeren sunumlar için, belge‑seviye temel adresi okumak, değiştirmek veya temizlemek amacıyla [Manage the Hyperlink Base](/slides/tr/androidjava/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Köprüsü Ekle**

Metni bir web sitesine bağlamak için, aşağıdaki gibi bir [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) nesnesini metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metoduna aktarın. Yalnızca o metin bölümü tıklanabilir hâle gelir.

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

### **Şekillere ve Medya Çerçevelerine URL Köprüsü Ekle**

Bir şekli veya çerçeveyi tıklanabilir hâle getirmek için, onun [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metodunu çağırın. Köprü, içinde metin bölümü bulunmasından bağımsız olarak nesneye aittir.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: köprüyü çerçeveye atayın ve gerekirse [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) metodunu çağırın.

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

## **İçindekiler Tablosu Oluşturmak İçin Köprüleri Kullan**

Dahili köprüler, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, birinci slaydın “Page 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) metodunu kullanır.

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

## **Köprüleri Biçimlendir**

### **Renk**

[IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) arayüzünün [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) metodu, köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanılacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlkinde kırmızı metin dolgusu, ikincisinde ise varsayılan köprü rengi kullanılır.

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

Bir köprü etkinleştirildiğinde ses çalabilir ya da hâlihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) köprüye atanacak ses dosyasını belirtir.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) köprünün etkinleştirilmesiyle önceki sesin durdurulup durdurulmayacağını kontrol eder.

#### **Köprüye Ses Ekle**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve birinci slayttaki bir düğmeye ilişkilendirir. Düğmeye tıklandığında ses çalar ve bir sonraki slayta geçilir. Aynı slayttaki ikinci bir şekil tıklandığında ses durur, ancak bir gezinme işlemi gerçekleşmez.

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

#### **Köprü Sesini Çıkar**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) ve [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) yöntemleriyle belleğe okur.

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

### **Araç İpucu ve Etkileşim Ayarları**

Bir köprüyü metne veya şekle atadıktan sonra aşağıdaki [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) yöntemlerini çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) izleyicinin bağlantı için bir ipucu (tooltip) göstermesini sağlar.
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) uygulanabilir olduğunda, üst HTML çerçeve grubundaki hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) bağlantının etkinleştirilmesinin hedefini izlenen köprüler listesine ekleyip eklemeyeceğini denetler.
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) köprünün tıklandığında vurgulanıp vurgulanmayacağını belirler.

## **Sunumlardan Köprüleri Kaldır**

[ getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) yöntemini kullanarak, değiştirmeden önce metin‑parça bağlantıları da dahil olmak üzere köprü kapsayıcılarını toplayın. Aşağıdaki örnek, birinci slayttaki her iki etkinleştirme türünü de kaldırır. Yalnızca bir türü kaldırmak istiyorsanız, sadece [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) veya [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) yöntemlerini çağırın; bir tıklama eylemini kaldırmak, fare‑üzerinde eylemi kaldırmaz.

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

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) yöntemi seçili kapsamda iki etkinleştirme türünü tek bir çağrıyla kaldırır. Master, yerleşim ve notların yanı sıra bu kapsamlarda seçici temizlik ve kapsama için [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluştur**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) yöntemi, URL dizesi düz listesi yerine [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) nesnelerini döndürür. Her kapsayıcıda hem [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) incelenmelidir. Bunlar bağımsızdır: aynı kapsayıcı iki eylemi de barındırabilir; bu nedenle eksiksiz bir rapor, her kapsayıcı için iki satır gerektirebilir.

Yalnızca şekil‑seviyesi köprüleri taramak, metin parçalarına eklenmiş bağlantıları kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve döndürülen kapsayıcıları saklayarak ileride eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin‑Çerçeve Kapsamlarını Sorgula**

[IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) arayüzü, [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) ve [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) üzerinden kullanılabilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) tıklama eylemi olan kapsayıcıları döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) fare‑üzerinde eylemi olan kapsayıcıları döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) her iki eylemden birini veya ikisini de barındıran kapsayıcıları döndürür.

Aşağıdaki örnek, dış tıklama bağlantısı, dosya fare‑üzerinde bağlantısı, dahili slayt gezintisi, metin fare‑üzerinde bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemlerden hiçbiri yürütülmez. Aynı üç sorgu her kapsamda çalışır; sayımlar kapsayıcı sayısını, eylem toplamını değil, gösterir. Metin‑çerçeve kapsamı, içinde bulunduğu şeklin kendi bağlantılarını dışarıda tutar.

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

Bu örnek için, sunum ve slayt sorguları her birinde üç tıklama kapsayıcısı, iki fare‑üzerinde kapsayıcısı ve üç toplam kapsayıcı raporlar. Metin‑çerçeve sorgusu her kategoride bir kapsayıcı raporlar.

### **Eylemleri ve Hedefleri Sınıflandır**

Bir eylemin hedefine bakmadan önce, [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) yöntemiyle eylemi yorumlayın. [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) değerleri, yalnızca web gezintisini değil, şu amaçları da kapsar:

| Değerler | Denetim İçin Anlam |
| --- | --- |
| `Hyperlink` | Dış köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta dahili geçiş. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi içinde yerleşik gezinme, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandır veya özel bir gösteri başlat. |
| `StartMacro` | Bir makroyu çalıştır. |
| `StartProgram` | Bir program başlat. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunum aç; web URL'lerinden ayrı olarak incelenir. |
| `StartStopMedia` | Medya oynatmasını başlat veya durdur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yok ya da tanınmayan bir eylem; inceleme gerekir. |

Dış hedefleri [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) ile, belirli dahili hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) ile okuyun. Dahili eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) değerini koruyun ve mevcutsa [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) tarafından döndürülen araç ipucunu ekleyin.

### **Köprüleri Raporla, Temizle ve Doğrula**

Aşağıdaki Java örneği, mevcut bir sunumu (yukarıda oluşturulan dosyayı) okur, `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` kaydeder ve iki etkinleştirme türünü tekrar kontrol etmek için yeniden açar. Değiştirmeden önce kapsayıcıları toplar ve aynı kapsayıcıyı iki kez işlememek için referans eşitliğini kullanır. Sunum sorguları sıradan slaytları kapsar; paket‑geneli envanter için ayrıca master, yerleşim, not ve not‑ve‑el ilanı masterlarını da sorgular.

Rapor, mevcut olduğunda bir‑bazlı slayt indeksini ve [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) değerini kaydeder. [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) desteklenen kapsayıcılar için sahibi slaytı sağlar. Master, yerleşim ve notların sıradan slayt indeksi yoktur; kapsamlarıyla tanımlanırlar. Şekil kapsayıcıları ve metin‑parça biçimlendirme kapsayıcıları ayrı ayrı etiketlenir; diğer kapsayıcı tipleri çalışma zamanı tip adını korur. Her kapsayıcı, iki eylemi ilişkilendirebilmek için rapor‑içinde bir kimlik alır. Rapor, eylem türlerini Java enum'unda tanımlı tamsayı sabitleri olarak saklar.

Bu kasıtlı kısıtlayıcı uygulama politikası, yalnızca mutlak HTTPS URL'lerini ve geçerli dahili slayt hedeflerini izin verir. Makrolar, programlar, dosya eylemleri, diğer slayt gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS yalnız başına güven oluşturmaz: uygulamanız için host izin listeleri ve ekstra kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler kontrol edilir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, kapsayıcının [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) yöntemi [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metodlarını destekler. Burada, yasak dış tıklama bağlantıları sabit bir HTTPS açılış sayfasıyla değiştirilir; diğer yasak tıklamalar ve yasak fare‑üzerinde eylemleri bağımsız olarak kaldırılır. `replaceExternalClicks` değerini `false` yaparak tüm politika ihlallerini kaldırabilirsiniz. Dağıtımdan önce uygulamaya ait bir yedek sayfa seçin.

Raporun dışa aktarım bayrağı, tutucu bir PDF inceleme politikası kullanır: fare‑üzerinde eylemler ve dış bağlantı ya da belirli slayt atlaması dışındaki her şey potansiyel olarak desteklenmeyebilir olarak işaretlenir. Bu bir inceleme ipucu olup, işaretlenmemiş bağlantıların dışa aktarımda sorunsuz çalışacağını garanti etmez. Desteklenen [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarım seçeneklerine ve izleyiciye bağlı olarak köprüleri koruyabilir; raster [images](/slides/tr/androidjava/convert-powerpoint-to-png/) ve [video](/slides/tr/androidjava/convert-powerpoint-to-video/) köprüleri koruyamaz; bu çıktılar için denetim sırasında her eylemi işaretleyin.

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

Yukarıdaki girdiyi oluşturduktan sonra rapor beş eylem satırı içerir. Dosya fare‑üzerinde bağlantısı ve makro tıklaması kaldırılır, HTTPS bağlantıları ve dahili slayt geçişi kalır. Doğrulama, sıfır yasaklı eylem çıktılar. Yasak bir dış tıklama URL'si içeren bir giriş, değişim dalını çalıştırır. İzinli bir tıklama ve yasak fare‑üzerinde eylemi olan bir kapsayıcı, tıklama eylemini tutar.

Bu seçici temizlik, [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) yönteminden farklıdır; bu yöntem, politika dikkate alınmadan seçili kapsamda her iki etkinleştirme türünü de kaldırır. Buradaki doğrulama yalnızca köprü eylemlerini kontrol eder; gömülü VBA projeleri, OLE nesneleri veya diğer aktif içerikleri kaldırmaz ve dışa aktarılmış PDF ya da HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme veya onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint’te bölümler slaytları gruplayarak düzenler, ancak dahili bir köprü bireysel bir slaytı hedef alır. Bir bölüme gezinme oluşturmak için, o bölümün ilk slaytına bağlanın.

**Master slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Master slayt ve yerleşim öğeleri köprüleri destekler. Bu öğelere eklenen köprüler, ilgili master veya yerleşimi kullanan slayt gösterisi sırasında erişilebilir olur.

**Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarılırken korunur mu?**

Desteklenen PDF ve HTML dışa aktarımları köprüleri koruyabilir; raster görüntüler ve video köprüleri koruyamaz. Bununla ilgili detayları [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümünde bulabilirsiniz.