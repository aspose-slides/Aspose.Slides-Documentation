---
title: JavaScript'te Sunum Hiperlinklerini Yönet
linktitle: Hiperlinkleri Yönet
type: docs
weight: 20
url: /tr/nodejs-java/manage-hyperlinks/
keywords:
  - URL ekle
  - hiperlink ekle
  - hiperlink oluştur
  - hiperlink biçimlendir
  - hiperlink kaldır
  - hiperlink güncelle
  - metin hiperlinki
  - slayt hiperlinki
  - şekil hiperlinki
  - resim hiperlinki
  - video hiperlinki
  - değiştirilebilir hiperlink
  - PowerPoint
  - OpenDocument
  - sunum
  - Node.js
  - JavaScript
  - Aspose.Slides
description: Aspose.Slides for Node.js via Java kullanarak, JavaScript örnekleriyle PowerPoint ve OpenDocument sunumlarında hiperlinkleri ekleyin, biçimlendirin, güncelleyin ve kaldırın.
---
## **Giriş**

Bir köprü (hiperlink), sunum içeriğini bir web sitesine ya da sunum içinde bir konuma bağlar. PowerPoint’te hiperlinkler genellikle iki amaçla kullanılır:

* Metinden, şekilden veya medya çerçevesinden bir web sitesini açmak.
* Örneğin içindekiler tablosundan başka bir slayta gitmek.

Aspose.Slides for Node.js via Java, bu bağlantıları eklemenizi, görünümlerini ve seslerini kontrol etmenizi, özelliklerini güncellemenizi ve kaldırmanızı sağlar. Aşağıdaki örnekler, hiperlinklerle bireysel öğeler üzerinde nasıl çalışılacağını ve hiperlinklere sunum, slayt ya da metin çerçevesi seviyesinde nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [Ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}}

## **URL Hiperlinkleri Ekle**

Bir web sitesi URL'sini metne, şekle veya medya çerçevesine atayabilirsiniz. Hiperlinki atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

Göreceli hiperlinkler içeren sunumlar için, belge düzeyindeki temeli okuyup değiştirmek veya temizlemek için [Hiperlink Temelini Yönet](/slides/tr/nodejs-java/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Hiperlinkleri Ekle**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi bir [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) nesnesini metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) metoduna gönderin. Yalnızca o metin bölümü tıklanabilir olur.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Şekillere ve Medya Çerçevelerine URL Hiperlinkleri Ekle**

Rektangül üzerine [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) metodunu çağırarak tüm alanının tıklanabilir olmasını sağlayın. Kullanıcılar dikdörtgenin üzerine geldiğinde hedef hakkında bir ipucu göstermek için [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) metodunu kullanın. Her iki metod da resim, ses ve video çerçevelerine de uygulanır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **İçindekiler Tablosu Oluşturmak İçin Hiperlinkleri Kullan**

Dahili hiperlinkler, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slayttaki “Page 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) metodunu kullanır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hiperlinkleri Biçimlendir**

Hiperlinkli metnin rengini değiştirebilir, okuyucu bir linki etkinleştirdiğinde ses çalabilir veya durdurabilir ve üzerine gelindiğinde görünen araç ipucunu (tooltip) ayarlayabilirsiniz.

### **Renk**

[Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) sınıfının [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) metodu, bir hiperlinkin sunumun hiperlink rengini mi yoksa metin bölümünün biçimini mi kullandığını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019'da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Bu örnekte, [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) ilk linkin metin bölümünün kırmızı dolgu rengini kullanmasını sağlar. İkinci link ise sunumun hiperlink rengini korur.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ses**

Bir hiperlink etkinleştirildiğinde ses çalabilir veya zaten çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki metodları kullanın:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) hiperlink ile ilişkili ses dosyasını belirler.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) hiperlinki etkinleştirmenin önceki sesi durdurup durdurmayacağını kontrol eder.

#### **Hiperlink Ses Ekle**

İlk slayttaki düğme, okuyucu ilerlemek için tıkladığında `sampleaudio.wav` dosyasını çalmak için [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) metodunu kullanır. İkinci slaytta ayrı bir düğme, oynatmayı durdurmak ve okuyucuyu o slaytta tutmak için [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) metodunu kullanır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Hiperlink Sesini Çıkar**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin hiperlink sesini [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) ve [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData) metodlarıyla belleğe okur.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Araç İpucu ve Etkileşim Ayarları**

Metne veya şekle bir hiperlink atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) metodlarını çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) bağlantı için izleyicinin ipucu olarak gösterebileceği metni ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) uygulanabilir olduğunda, bir üst HTML çerçeve kümesi içinde hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) bağlantıyı etkinleştirmenin hedefini görüntülenen hiperlinkler listesine ekleyip eklemeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) hiperlinkin tıklandığında vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Hiperlinkleri Kaldır**

Değiştirmeden önce, metin bölümü linklerini dahil olmak üzere hiperlink konteynerlerini toplamak için [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) metodunu kullanın. Aşağıdaki örnek, ilk slayttan her iki etkinleştirme türünü kaldırır. Yalnızca bir türü kaldırmak için sadece [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) veya [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) metodunu çağırın; bir tıklama eylemini kaldırmak, mouse-over eşdeğerini kaldırmaz.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) seçilen kapsamda tek bir çağrıyla her iki etkinleştirme türünü de kaldırır. Seçmeli temizlik ve master, düzen ve notların kapsanması için [Raporla, Temizle ve Hiperlinkleri Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

### **Akıllı Sanat Metnini Değiştirmeden Önce Hiperlinkleri Temizle**

Mevcut bir SmartArt düğümündeki paragrafı değiştirdiğinizde, metin bölümlerini temizlemek eski bir hiperlinkin etkili kalmasına neden olabilir. Paragrafı [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getTextFrame) yöntemiyle alın. Bölümlerini temizlemeden önce, paragrafı gösteren düğüm şeklinin metin çerçevesinde [getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) metodunu çağırın, ardından dönen nesnede [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) metodunu çalıştırın. Bu, çerçevedeki tüm hiperlinkleri, diğer paragraflardaki linkler dahil, kaldırır.

Örnek, `SmartArtHyperlink.pptx` dosyasının ilk slaydındaki üçüncü şeklin bir SmartArt grafiği olduğunu varsayar. Dördüncü düğümün ilk paragrafını değiştirir. Bu sunumda, düğümün ilk şekli o paragrafı gösterir.

Her iki bölümü ekledikten sonra, örnek [getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#getEffective) ile etkili biçimlendirmelerini okur. Bu biçimlendirmede, `getHyperlinkClick` ilk bölüm için yeni hiperlinki ve ikinci bölüm için `null` değerini döndürür.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("SmartArtHyperlink.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const smartArt = slide.getShapes().get_Item(2);
    const node = smartArt.getAllNodes().get_Item(3);
    const paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    const link = new aspose.slides.Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    const text = new aspose.slides.Portion(" (updated)");
    paragraph.getPortions().add(text);

    console.log(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    console.log(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **Tam Bir Hiperlink Envanteri Oluştur**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web linklerini envanterleyin. [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) hiperlink konteynerlerini döndürür, URL dizelerinin düz bir listesini değil. Her konteynerde hem [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) metodlarını inceleyin. Bunlar bağımsızdır: aynı konteyner her iki eylemi de sunabilir, bu yüzden tam bir rapor konteyner başına iki satır gerektirebilir.

Sadece şekil düzeyindeki hiperlinkleri taramak, metin bölümlerine eklenmiş linkleri kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve dönen konteynerleri saklayın, böylece daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin Çerçevesi Kapsamlarını Sorgula**

[HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) sınıfı, [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries), ve [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) üzerinden kullanılabilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) tıklama eylemi içeren konteynerleri döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) mouse-over eylemi içeren konteynerleri döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) bir ya da her iki eylemi de içeren konteynerleri döndürür.

Bu örnek, bir şekle ve metnine tıklama ve mouse-over eylemleri, ayrı bir düğmeye ise makro eylemi atar. [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) tarafından döndürülen konteyner sayısını, her aktivasyon tipi için sayılarla karşılaştırır. Metin çerçevesi sorgusu yalnızca metindeki linkleri sayar. İçeren şeklin kendi eylemleri slayt ve sunum sorgularında görünür.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu örnek için, sunum ve slayt sorguları her biri üç tıklama konteyneri, iki mouse-over konteyneri ve bir eylemi olan üç konteyner raporlar. Metin çerçevesi sorgusu her kategoride bir konteyner rapor eder.

### **Eylemleri ve Hedefleri Sınıflandır**

[Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) metodunu, bir eylemin hedefini yorumlamadan önce eylemi yorumlamak için kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) değerleri, yalnızca web gezinmesinden daha fazlasını kapsar:

| Değerler | Denetim için Anlamı |
| --- | --- |
| `Hyperlink` | Harici hiperlink; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta içsel gezinme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Yerleşik slayt gösterisi gezinmesi, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırır veya özel bir gösteri başlatır. |
| `StartMacro` | Makro çalıştırır. |
| `StartProgram` | Bir program başlatır. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunum açar; web URL'lerinden ayrı inceleyin. |
| `StartStopMedia` | Medya oynatmayı başlatır veya durdurur. |
| `NoAction`, `Unknown` | Gezinme eylemi yok ya da gözden geçirilmesi gereken tanınmayan bir eylem. |

[getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) ile harici hedefleri, [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) ile belirli iç hedefleri okuyun. İç eylemler ve yerleşik komutlar harici bir URL içermeyebilir; boş bir URL konteynerin eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklı olduğunda [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) tarafından döndürülen değeri koruyun ve mevcut olduğunda [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) tarafından döndürülen araç ipucunu ekleyin.

### **Raporla, Temizle ve Hiperlinkleri Doğrula**

Bu örnek, önceki örnekten sunumu açar ve her eylem için bir JSON kaydı yazar. Normal slaytlarda, master, düzen ve notlarda (varsa not ve dağıtım masterları da dahil) konteynerleri toplamak için [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) metodunu kullanır. Her konteyneri yalnızca bir kez saymak için referans eşitliğini kullanır, aşağıda açıklanan politikayı uygular ve kaydedilen sunuyu yeniden açarak hem tıklama hem de mouse-over eylemlerini kontrol eder.

Rapor, birden başlayan slayt indeksini ve mevcut olduğunda [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) değerini kaydeder. [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) desteklenen konteynerler için sahip slaytı sağlar. Master, düzen ve notlar normal bir slayt indeksine sahip değildir ve kapsamlarıyla tanımlanır. Şekil konteynerleri ve metin bölümü biçimlendirme konteynerleri ayrı ayrı etiketlenir; diğer konteyner tipleri çalışma zamanı tip adını korur. Her konteyner, iki eylemin ilişkilendirilebilmesi için rapor içinde yerel bir kimlik alır. Rapor, eylem tiplerini HyperlinkActionType sayım tipinde tanımlanan tamsayı sabitleri olarak saklar.

Bu kasıtlı olarak kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL'lerini ve geçerli iç slayt hedeflerini izin verir. Makroları, programları, dosya eylemlerini, diğer slayt gösterisi eylemlerini, bilinmeyen eylemleri ve diğer URL şemalarını reddeder. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güven oluşturmaz: uygulamanız için host izin listeleri ve diğer kontroller ekleyin. Hem orijinal hem de normalleştirilmiş harici URL'ler kontrol edilir. Örnek, linkleri takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, konteynerin [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) metodu [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) metodlarını destekler. Burada, yasaklanmış dış tıklama linkleri sabit bir HTTPS giriş sayfası ile değiştirilir; diğer yasak tıklamalar ve yasak mouse-over eylemleri bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `replaceExternalClicks` değerini `false` olarak ayarlayın. Dağıtımdan önce uygulamaya ait bir değiştirme sayfası seçin.

Raporun dışa aktarma bayrağı, temkinli bir PDF inceleme politikası kullanır: mouse-over eylemleri ve dış link ya da belirli slayt atlaması dışındaki her şey potansiyel olarak desteklenmeyebilir olarak işaretlenir. Bu bir inceleme ipucu olup, yetenek testi ya da işaretlenmemiş linklerin dışa aktarmada hayatta kalacağının garantisi değildir. Desteklenen [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/) dışa aktarmaları, eyleme, dışa aktarma seçeneklerine ve izleyiciye bağlı olarak hiperlinkleri koruyabilir. Raster [görseller](/slides/tr/nodejs-java/convert-powerpoint-to-png/) ve [video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) interaktif hiperlinkleri koruyamaz; bu çıktılar için denetleme yaparken her eylemi işaretleyin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Yukarıda oluşturulan girdi ile rapor beş eylem satırı içerir. Dosya mouse-over linki ve makro tıklaması kaldırılırken, HTTPS linkleri ve iç slayt gezinmesi kalır. Doğrulama, sıfır yasak eylem yazdırır. Yasak bir dış tıklama URL'i içeren bir girdi, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir mouse-over içeren bir konteyner, tıklama eylemini korur.

Bu seçmeli temizlik, politikadan bağımsız olarak seçilen kapsamda her iki etkinleştirme türünü de kaldıran [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) metodundan farklıdır. Buradaki doğrulama yalnızca hiperlink eylemlerini kontrol eder; gömülü VBA projeleri, OLE nesneleri veya diğer aktif içeriği kaldırmaz ve dışa aktarılan bir PDF ya da HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme veya onun ilk slaytına nasıl link ekleyebilirim?**

"Bölümler, PowerPoint’te slaytları gruplar, ancak bir iç hiperlink bireysel bir slaytı hedef alır. Bir bölüme gezinme oluşturmak için, o bölümün ilk slaytına link verin."

**Tüm slaytlarda çalışması için master slayt öğelerine bir hiperlink ekleyebilir miyim?**

"Evet. Master slayt ve düzen öğeleri hiperlinkleri destekler. Bu öğelerdeki linkler, ilgili master veya düzeni kullanan slayt gösterisi sırasında kullanılabilir."

**PDF, HTML, görüntüler veya video olarak dışa aktarırken hiperlinkler korunur mu?**

"Desteklenen PDF ve HTML dışa aktarmaları hiperlinkleri koruyabilir; raster görüntüler ve videolar koruyamaz. Ayrıntılar için [Raporla, Temizle ve Hiperlinkleri Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın."