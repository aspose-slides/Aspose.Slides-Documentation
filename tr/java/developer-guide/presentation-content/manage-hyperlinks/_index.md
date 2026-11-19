---
title: Java'da Sunum Hiperbağlantılarını Yönetme
linktitle: Hiperbağlantıları Yönet
type: docs
weight: 20
url: /tr/java/manage-hyperlinks/
keywords:
- URL ekle
- hiperbağlantı ekle
- hiperbağlantı oluştur
- hiperbağlantıyı biçimlendir
- hiperbağlantıyı kaldır
- hiperbağlantıyı güncelle
- metin hiperbağlantısı
- slayt hiperbağlantısı
- şekil hiperbağlantısı
- görsel hiperbağlantısı
- video hiperbağlantısı
- değiştirilebilir hiperbağlantı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java için Aspose.Slides kullanarak PowerPoint ve OpenDocument sunumlarında hiperbağlantıları ekleyin, biçimlendirin, güncelleyin ve kaldırın, Java örnekleri ile."
---
## **Giriş**

Bir hiperbağlantı, sunum içeriğini bir web sitesine ya da sunum içindeki bir konuma bağlar. PowerPoint’te hiperbağlantılar genellikle iki amaçla kullanılır:

* Metin, şekil ya da medya çerçevesinden bir web sitesini açmak.
* Örneğin bir içerik tablosundan başka bir slayta gitmek.

Aspose.Slides for Java, bu bağlantıları eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, bireysel öğeler üzerinde hiperbağlantılarla nasıl çalışılacağını ve sunum, slayt ya da metin‑çerçevesi düzeyinde hiperbağlantılara nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Ayrıca sunumları [free online Aspose PowerPoint editor](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}}

## **URL Hiperbağlantıları Ekleme**

Bir web sitesi URL’si metne, şekle ya da medya çerçevesine atanabilir. Hiperbağlantıyı atadığınız öğe tıklanabilir alanı belirler: bir metin bölümü seçilen metni bağlarken, bir şekil ya da çerçeve slayt nesnesini bağlar.

Göreceli hiperbağlantı içeren sunumlar için, belge‑düzeyindeki temeli okumak, değiştirmek ya da temizlemek amacıyla [Manage the Hyperlink Base](/slides/tr/java/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Hiperbağlantısı Ekleme**

Metni bir web sitesine bağlamak için, metin bölümü’nin [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metoduna bir [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlink/) gönderin; aşağıda gösterildiği gibi. Yalnızca bu metin bölümü tıklanabilir hâle gelir.

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

### **Şekillere ve Medya Çerçevelerine URL Hiperbağlantısı Ekleme**

Dikdörtgenin tüm alanını tıklanabilir yapmak için [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metodunu çağırın. Kullanıcı dikdörtgenin üzerine geldiğinde hedef hakkında bir ipucu göstermek için [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) metodunu kullanın. Her iki metod da resim, ses ve video çerçevelerine de uygulanabilir.

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

## **İçindekiler Tablosu Oluşturmak İçin Hiperbağlantılar Kullanma**

Dahili hiperbağlantılar, okuyucuların içerik tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slaydın “Page 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) metodunu kullanır.

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

## **Hiperbağlantıların Biçimlendirilmesi**

Bağlantılı metnin rengini değiştirebilir, bir okuyucu bağlantıyı etkinleştirdiğinde ses çalabilir veya durdurabilir ve üzerine gelindiğinde görülen araç ipucunu ayarlayabilirsiniz.

### **Renk**

[IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/)’in [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) yöntemi, bir hiperbağlantının sunumun hiperbağlantı rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanılacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkcolorsource/) seçilir ve bölümün dolgu rengi ayarlanır. Bu özellik PowerPoint 2019’da tanıtıldı; daha eski sürümler bu ayarı uygulamaz.

Bu örnekte, [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) ilk bağlantının metin bölümünün kırmızı dolgusunu kullanmasını sağlar. İkinci bağlantı ise sunumun hiperbağlantı rengini korur.

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

Bir hiperbağlantı etkinleştirildiğinde ses çalabilir veya zaten çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) hiperbağlantıya ilişkilendirilen sesi belirtir.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) hiperbağlantının etkinleştirilmesinin önceki sesi durdurup durdurmayacağını kontrol eder.

#### **Bir Hiperbağlantı Sesi Ekleme**

İlk slayttaki düğme, okuyucu ileriye tıkladığında `sampleaudio.wav` dosyasından ses çalmak için [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) metodunu kullanır. İkinci slayttaki ayrı bir düğme, oynatımı durdurmak ve okuyucuyu aynı slaytta tutmak için [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) metodunu kullanır.

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

#### **Bir Hiperbağlantı Sesini Çıkarma**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin hiperbağlantı sesini [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getSound--) ve [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) aracılığıyla bellek içine okur.

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

Metne ya da şekle bir hiperbağlantı atadıktan sonra aşağıdaki [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) yöntemlerini çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) izleyicinin bağlantı için ipucu olarak gösterebileceği metni ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) gerektiğinde üst HTML çerçeve seti içinde hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) bağlantının etkinleştirilmesinin hedefini görüntülenen hiperbağlantılar listesine ekleyip eklemeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) tıklandığında hiperbağlantının vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Hiperbağlantıları Kaldırma**

Hiperbağlantı kapsayıcılarını, metin‑bölüm bağlantıları da dahil olmak üzere, değiştirmeden önce toplamak için [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) metodunu kullanın. Aşağıdaki örnek, ilk slayttan hem tıklama hem de fare‑üzerine eylemlerini kaldırır. Sadece bir türü kaldırmak isterseniz, yalnızca [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) ya da [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metodunu çağırın; tıklama eylemini kaldırmak fare‑üzerine karşılığını kaldırmaz.

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

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) seçili kapsam içinde her iki aktivasyon türünü tek bir çağrıda kaldırır. Master, düzen ve notlar dahil olmak üzere seçici temizlik ve kapsamlı kapsama için, [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

### **SmartArt Metni Değiştirmeden Önce Hiperbağlantıları Temizleme**

Mevcut bir SmartArt düğümündeki bir paragrafı değiştirdiğinizde, metin bölümlerini temizlemek eski bir hiperbağlantının etkide kalmasına neden olabilir. Paragrafı [ISmartArtNode.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getTextFrame--) ile alın. Bölümleri temizlemeden önce, düğüm şeklinin metin çerçevesi üzerinde [getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) metodunu çağırın, ardından dönen nesne üzerinde [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) metodunu çalıştırın. Bu, çerçevedeki tüm hiperbağlantıları, diğer paragraflardaki bağlantılar dahil, kaldırır.

Örnek, `SmartArtHyperlink.pptx` dosyasının ilk slaydındaki üçüncü şeklin bir SmartArt grafik olduğu varsayımına dayanır. Dördüncü düğümün ilk paragrafını değiştirir. Bu sunumda, düğümün ilk şekli o paragrafı gösterir.

Her iki bölümü ekledikten sonra örnek, etkili biçimlendirmeyi [getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) ile okur. Bu biçimlendirmede, [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) ilk bölüm için yeni hiperbağlantıyı ve ikinci bölüm için `null` döndürür.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(2);
    ISmartArtNode node = smartArt.getAllNodes().get_Item(3);
    IParagraph paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    IPortion link = new Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    IPortion text = new Portion(" (updated)");
    paragraph.getPortions().add(text);

    System.out.println(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    System.out.println(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **Tam Bir Hiperbağlantı Envanteri Oluşturma**

Sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) sadece URL dizgesi listesi değil, [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) nesneleri döndürür. Her kapsayıcıda hem [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) incelenmelidir. Aynı kapsayıcı iki eylemi de içerebilir; bu yüzden tam bir rapor her kapsayıcı için iki satır gerektirebilir.

Yalnızca şekil‑düzeyindeki hiperbağlantılar sorgulanırsa, metin bölümlerine eklenmiş bağlantılar gözden kaçabilir. Bunun yerine uygun kapsamı sorgulayın ve dönen kapsayıcıları saklayarak daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin‑Çerçeve Kapsamlarını Sorgulama**

[IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/) arayüzü, [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) ve [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) aracılığıyla elde edilebilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) tıklama eylemi içeren kapsayıcıları döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) fare‑üzerine eylemi içeren kapsayıcıları döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) bir veya iki eylemi içeren kapsayıcıları döndürür.

Bu örnek, bir şekle ve metnine tıklama ve fare‑üzerine eylemleri, ayrı bir düğmeye ise makro eylemi atar. [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) tarafından döndürülen kapsayıcı sayısını, her aktivasyon türü için dönen sayılarla karşılaştırır. Bir metin‑çerçeve sorgusu yalnızca metindeki bağlantıları sayar. Çerçeveyi kapsayan şeklin kendi eylemleri slayt ve sunum sorgularında görünür.

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

Bu örnek için, sunum ve slayt sorguları her birinde üç tıklama kapsayıcısı, iki fare‑üzerine kapsayıcısı ve toplam üç kapsayıcı raporlar. Metin‑çerçeve sorgusu ise her kategoriye bir kapsayıcı raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

[IHyperlink.getActionType](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getActionType--) eylemi yorumlamadan önce hedefi yorumlamak için kullanılmalıdır. [HyperlinkActionType](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkactiontype/) değerleri web gezintisinin ötesine geçer:

| Değerler | Denetim için anlamı |
| --- | --- |
| `Hyperlink` | Dış hiperbağlantı; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta iç gezinti. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi içinde yerleşik gezinme. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırma veya özel gösteri başlatma. |
| `StartMacro` | Makro çalıştırma. |
| `StartProgram` | Program başlatma. |
| `OpenFile`, `OpenPresentation` | Dosya ya da başka bir sunum açma; web URL’lerinden ayrı değerlendirin. |
| `StartStopMedia` | Medya oynatmayı başlatma/durdurma. |
| `NoAction`, `Unknown` | Navigasyon eylemi yok veya tanımlanamayan eylem; incelenmelidir. |

Dış hedefleri [getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) üzerinden, belirli iç hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTargetSlide--) üzerinden okuyun. İç eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL’den farklıysa [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) değerini koruyun ve mevcutsa [getTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTooltip--) tarafından dönen ipucunu ekleyin.

### **Hiperbağlantıları Raporlama, Temizleme ve Doğrulama**

Bu örnek, önceki örnekten sunumu açar ve her eylem için bir JSON kaydı yazar. Normal slaytlar, master’lar, düzenler ve notlar dahil olmak üzere tüm kapsamlarda kapsayıcıları toplamak için [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) kullanır; not ve el ilanı master’ları da mevcutsa dahil eder. Her kapsayıcıyı yalnızca bir kez saymak için referans eşitliği uygulanır, aşağıda açıklanan politika uygulanır ve kaydedilen sunum tekrar açılarak tıklama ve fare‑üzerine eylemleri kontrol edilir.

Rapor, mümkünse bir‑bazlı slayt indeksini ve mevcutsa [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) değerini saklar. Desteklenen kapsayıcılar için [ISlideComponent.getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) ilgili slaytı sağlar. Master, düzen ve notlar normal bir slayt indeksine sahip değildir; kapsamlarıyla tanımlanırlar. Şekil kapsayıcıları ve metin‑bölüm biçimlendirme kapsayıcıları ayrı etiketlenir; diğer kapsayıcı tipleri çalışma zamanı tip adını korur. Her kapsayıcı, iki eylemin ilişkilendirilebilmesi için rapor‑yerel bir kimlik alır. Rapor, eylem türlerini Java enum’undaki tamsayı sabitleri olarak saklar.

Bu kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL’lerini ve geçerli iç slayt hedeflerini kabul eder. Makrolar, programlar, dosya eylemleri, diğer slayt gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güveni garantilemez; uygulamanız için host beyaz listeleri ve diğer kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL’ler denetlenir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, kapsayıcının [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) aşağıdaki yöntemleri destekler: [setExternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Burada, yasak dış tıklama bağlantıları sabit bir HTTPS açılış sayfasıyla değiştirilir; diğer yasak tıklamalar ve yasak fare‑üzerine eylemler bağımsız olarak kaldırılır. `replaceExternalClicks` değerini `false` yaparsanız tüm politika ihlallerini kaldırır. Dağıtıma geçmeden önce uygulama‑sahibi bir yedek sayfa seçin.

Raporun dışa aktarım bayrağı, temkinli bir PDF inceleme politikası kullanır: fare‑üzerine eylemler ve dış bağlantı olmayan ya da belirli slayt atlaması olmayan her şey potansiyel olarak desteklenmeyen olarak işaretlenir. Bu bir inceleme ipucudur, yetenek testi ya da işaretlenmemiş bağlantıların dışa aktarımda korunacağı garantisi değildir. Desteklenen [PDF](/slides/tr/java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/java/convert-powerpoint-to-html/) dışa aktarmaları, eyleme, dışa aktarım seçeneklerine ve görüntüleyiciye bağlı olarak hiperbağlantıları koruyabilir. Raster [images](/slides/tr/java/convert-powerpoint-to-png/) ve [video](/slides/tr/java/convert-powerpoint-to-video/) etkileşimli hiperbağlantıları koruyamaz; bu çıktılar için denetleme yaparken her eylemi işaretleyin.

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

Yukarıda oluşturulan girdi ile rapor beş eylem satırı içerir. Dosya fare‑üzerine bağlantısı ve makro tıklaması kaldırılır, HTTPS bağlantıları ve iç slayt gezinmesi kalır. Doğrulama sıfır yasaklı eylem yazdırır. Yasak bir dış tıklama URL’si içeren bir girdi de değiştirme dalını çalıştırır. İzin verilen bir tıklama ve yasak bir fare‑üzerine eylemi olan bir kapsayıcı tıklama eylemini korur.

Bu seçici temizlik, [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) metodundan farklıdır; o metod, politika gözetmeksizin seçilen kapsam içinde her iki aktivasyon tipini de kaldırır. Burada doğrulama yalnızca hiperbağlantı eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini ya da diğer aktif içeriği kaldırmaz ve dışa aktarılmış PDF ya da HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme ya da onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint’te bölümler slaytları gruplar, ancak dahili bir hiperbağlantı tek bir slaytı hedef alır. Bir bölüme yönlendirme oluşturmak için o bölümün ilk slaytına bağlayın.

**Master slayt öğelerine hiperbağlantı ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Master slayt ve düzen öğeleri hiperbağlantı desteğine sahiptir. Bu öğelerdeki bağlantılar, ilgili master ya da düzeni kullanan slayt gösterisi sırasında kullanılabilir.

**Hiperbağlantılar PDF, HTML, görüntüler ya da video olarak dışa aktarılırken korunur mu?**

Desteklenen PDF ve HTML dışa aktarmaları hiperbağlantıları koruyabilir; raster görüntüler ve video koruyamaz. Ayrıntılar için [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümündeki dışa aktarım hususlarına bakın.