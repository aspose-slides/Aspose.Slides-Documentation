---
title: JavaScript'te Sunum Köprülerini Yönetme
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/nodejs-java/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprüyü biçimlendir
- köprüyü kaldır
- köprüyü güncelle
- metin köprüsü
- slayt köprüsü
- şekil köprüsü
- görsel köprüsü
- video köprüsü
- değiştirebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak, JavaScript örnekleriyle PowerPoint ve OpenDocument sunumlarında köprüleri ekleyin, biçimlendirin, güncelleyin ve kaldırın."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine ya da sunum içindeki bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaçla kullanılır:

* Metinden, şekilden ya da bir medya çerçevesinden bir web sitesini açar.
* Örneğin, bir içindekiler tablosundan başka bir slayta yönlendirir.

Aspose.Slides for Node.js via Java, bu bağlantıları eklemenizi, görünüm ve seslerini kontrol etmenizi, özelliklerini güncellemenizi ve kaldırmanızı sağlar. Aşağıdaki örnekler, tek tek öğelerde köprülerle nasıl çalışılacağını ve sunum, slayt veya metin çerçevesi düzeyinde köprülere nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/tr/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekleme**

Bir web sitesi URL'sini metne, şekle ya da bir medya çerçevesine atayabilirsiniz. Köprünün atandığı öğe tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil ya da çerçeve slayt nesnesini bağlar.

### **Metne URL Köprüsü Ekleme**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) yöntemine bir [Hyperlink](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink) gönderin. Sadece o metin bölümü tıklanabilir hâle gelir.

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

### **Şekillere ve Medya Çerçevelerine URL Köprüsü Ekleme**

Bir şekli ya da çerçeveyi tıklanabilir hâle getirmek için, onun [setHyperlinkClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#setHyperlinkClick) yöntemini çağırın. Köprü, içindeki bir metin bölümüne değil, nesnenin kendisine aittir.

Aynı yöntem resim, ses ve video çerçevelerine de uygulanır: köprüyü çerçeveye atayın ve gerekirse [setTooltip](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setTooltip) metodunu çağırın.

Aşağıdaki örnek bir dikdörtgeni tıklanabilir hâle getirir:

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

## **İçindekiler Tablosu Oluşturmak İçin Köprü Kullanma**

İç köprüler, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slayttaki “Page 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) metodunu kullanır.

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

## **Köprüleri Biçimlendirme**

### **Renk**

[Hyperlink](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink) sınıfının [setColorSource](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setColorSource) yöntemi, köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesini mi kullanacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkColorSource) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019'da tanıtıldı; daha eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. Birincisi kırmızı metin dolgusu kullanırken, ikincisi varsayılan köprü rengini korur.

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

Bir köprü aktive edildiğinde ses çalabilir ya da hâlihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [Hyperlink.setSound](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setSound) köprüyle ilişkili sesi belirtir.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) köprünün aktive edilmesinin önceki sesi durdurup durdurmayacağını kontrol eder.

#### **Köprüye Ses Ekleme**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slayttaki bir düğmeye bağlar. Düğmeye tıklamak sesi çalar ve bir sonraki slayta yönlendirir. Aynı slaydaki ikinci bir şekil tıklandığında önceki sesi durdurur, ancak bir yönlendirme eylemi yapmaz.

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

#### **Köprü Sesini Çıkarma**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [getSound](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#getSound) ve [getBinaryData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Audio#getBinaryData) aracılığıyla belleğe okur.

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

### **İpucu ve Etkileşim Ayarları**

Metne ya da şekle bir köprü atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink) yöntemlerini çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setTooltip) bağlantı için bir ipucu metni ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) uygulanabilir olduğunda, bir üst HTML çerçeve kümesindeki hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setHistory) bağlantının etkinleştirilmesinin hedefini görüntülenen köprüler listesine ekleyip eklemeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) bağlantının tıklandığında vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Köprüleri Kaldırma**

[getAnyHyperlinks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) metodunu kullanarak, değiştirmeden önce metin bölümü köprüleri de dahil olmak üzere köprü konteynerlerini toplayın. Aşağıdaki örnek ilk slayttan her iki aktivasyon türünü de kaldırır. Sadece bir türü kaldırmak için yalnızca [removeHyperlinkClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) veya [removeHyperlinkMouseOver](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) metodunu çağırın; bir tıklama eylemini kaldırmak, mouse-over karşılığını kaldırmaz.

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

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) seçilen kapsamda tek bir çağrıyla her iki aktivasyon türünü de kaldırır. Seçimli temizlik ve master, düzen ve notların kapsamını görmek için [Raporla, Temizle ve Köprüleri Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluşturma**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [getAnyHyperlinks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) köprü konteynerlerini döndürür, URL dizesi düz bir listeyi değil. Her konteynerdeki [getHyperlinkClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getHyperlinkClick) ve [getHyperlinkMouseOver](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) metodlarını inceleyin. Bunlar bağımsızdır: aynı konteyner her iki eylemi de gösterebilir, bu yüzden tam bir rapor konteyner başına iki satır içerebilir.

Sadece şekil düzeyindeki köprüleri taramak, metin bölümlerine eklenen köprüleri kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve döndürülen konteynerleri saklayın, böylece daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin-Çerçeve Kapsamlarını Sorgulama**

[HyperlinkQueries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries) sınıfı, [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) ve [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) aracılığıyla kullanılabilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) bir tıklama eylemi olan konteynerleri döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) mouse-over eylemi olan konteynerleri döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) ya birini ya da her ikisini de içeren konteynerleri döndürür.

Aşağıdaki örnek `hyperlink-audit-input.pptx` dosyasını, dış bir tıklama bağlantısı, bir dosya mouse-over bağlantısı, iç slayt navigasyonu, bir metin mouse-over bağlantısı ve bir makro eylemi içerecek şekilde oluşturur. Bu eylemlerden hiçbiri yürütülmez. Aynı üç sorgu her kapsamda çalışır; sayımlar konteynerleri, eylem toplamlarını değil, tanımlar. Metin-çerçeve kapsamı, içindeki şeklin kendi bağlantılarını dışarıda bırakır.

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

Bu örnek için, sunum ve slayt sorguları her biri üç tıklama konteyneri, iki mouse-over konteyneri ve her iki eylemi de içeren üç konteyner raporlar. Metin-çerçeve sorgusu her kategoride bir konteyner raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

Bir eylemi yorumlamadan önce, [Hyperlink.getActionType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#getActionType) kullanarak eylemi yorumlayın. [HyperlinkActionType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkActionType) değerleri sadece web navigasyonundan daha fazlasını kapsar:

| Değerler | Denetim için Anlamı |
| --- | --- |
| `Hyperlink` | Harici köprü; URL'yi ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta iç navigasyon. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Yerleşik slayt gösterisi navigasyonu, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırır veya özel bir gösteriyi başlatır. |
| `StartMacro` | Bir makroyu çalıştır. |
| `StartProgram` | Bir program başlat. |
| `OpenFile`, `OpenPresentation` | Bir dosya ya da başka bir sunum açar; web URL'lerinden ayrı olarak inceleyin. |
| `StartStopMedia` | Medya oynatımını başlatır veya durdurur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yok veya incelenmesi gereken tanımlanamayan bir eylem. |

Dış hedefleri [getExternalUrl](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) ile, belirli iç hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) ile okuyun. İç eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, konteynerin eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [getExternalUrlOriginal](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) tarafından döndürülen değeri koruyun ve mevcutsa [getTooltip](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#getTooltip) tarafından döndürülen ipucunu ekleyin.

### **Köprüleri Raporla, Temizle ve Doğrula**

Aşağıdaki JavaScript örneği mevcut bir sunumu okur (yukarıda oluşturulan dosyayı kullanın), `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` olarak kaydeder ve her iki aktivasyon türünü yeniden kontrol etmek için tekrar açar. Değiştirmeden önce konteynerleri toplar ve aynı konteyneri iki kez işlememek için referans eşitliğini kullanır. Sunum sorguları normal slaytları kapsar; paket çapında bir envanter için, ayrıca master, düzen, not ve not ve el ilanı masterlarını da açıkça sorgular.

Rapor, mevcut olduğunda bir- bazlı slayt indeksini ve [getSlideId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/BaseSlide#getSlideId) kaydeder. [getSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getSlide), desteklenen konteynerler için sahip slaytı sağlar. Masterlar, düzenler ve notlar normal bir slayt indeksine sahip değildir ve kapsamlarıyla tanımlanır. Şekil konteynerleri ve metin bölümü biçimlendirme konteynerleri ayrı ayrı etiketlenir; diğer konteyner tipleri çalışma zamanı tip adlarını korur. Her konteyner rapor içinde bir kimlik alır, böylece iki eylemi ilişkilendirilebilir. Rapor, eylem tiplerini HyperlinkActionType enumunda tanımlı tamsayı sabitleri olarak depolar.

Bu bilinçli kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL'leri ve geçerli iç slayt hedeflerine izin verir. Makroları, programları, dosya eylemlerini, diğer slayt gösterisi eylemlerini, bilinmeyen eylemleri ve diğer URL şemalarını reddeder. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güven oluşturmaz: uygulamanız için host izin listeleri ve diğer kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler kontrol edilir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

İyileştirme için, konteynerin [getHyperlinkManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getHyperlinkManager) [setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) metodlarını destekler. Burada, yasaklanmış dış tıklama bağlantıları sabit bir HTTPS açılış sayfasıyla değiştirilir; diğer yasak tıklamalar ve yasak mouse-over eylemleri bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `replaceExternalClicks` değerini `false` olarak ayarlayın. Dağıtıma geçmeden önce uygulamaya ait bir değiştirme sayfası seçin.

Raporun dışa aktarma işareti, temkinli bir PDF inceleme politikası kullanır: mouse-over eylemlerini ve dış bağlantı ya da belirli slayt atlaması dışındaki her şeyi potansiyel olarak desteklenmemiş olarak işaretler. Bu bir inceleme ipucu olup, bir yetenek testi ya da işaretsiz bağlantıların dışa aktarmada hayatta kalacağı garantisi değildir. Desteklenen [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/) dışa aktarmalar, eyleme, dışa aktarım seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir. Raster [images](/slides/tr/nodejs-java/convert-powerpoint-to-png/) ve [video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) interaktif köprüleri koruyamaz; bu çıktı tipleri için denetleme yaparken tüm eylemleri işaretleyin.

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

Yukarıda oluşturulan girişle, rapor beş eylem satırı içerir. Dosya mouse-over bağlantısı ve makro tıklaması kaldırılır, HTTPS bağlantıları ve iç slayt navigasyonu kalır. Doğrulama, sıfır yasak eylem çıktılar. Yasak dış tıklama URL'si içeren bir giriş, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir mouse-over içeren bir konteyner, tıklama eylemini korur.

Bu seçmeli temizlik, [removeAllHyperlinks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) metodunun seçilen kapsamda politika gözetmeksizin her iki aktivasyon türünü de kaldırmasından farklıdır. Buradaki doğrulama sadece köprü eylemlerini kontrol eder; yerleşik VBA projelerini, OLE nesnelerini veya diğer aktif içerikleri kaldırmaz ve dışa aktarılmış bir PDF ya da HTML dosyasını doğrulamaz.

## **SSS**

**Bölüme ya da ilk slaytına nasıl bağlanabilirim?**

PowerPoint'teki bölümler slaytları gruplaştırır, ancak bir iç köprü bireysel bir slaytı hedef alır. Bir bölüme yönlendirme oluşturmak için o bölümün ilk slaytına bağlayın.

**Ana slayt öğelerine köprü ekleyebilir ve tüm slaytlarda çalışmasını sağlayabilir miyim?**

Evet. Ana slayt ve düzen öğeleri köprüleri destekler. Bu öğeler üzerindeki köprüler, ilgili ana slaytı ya da düzeni kullanan slayt gösterisi sırasında kullanılabilir.

**Köprüler PDF, HTML, görüntüler ya da video olarak dışa aktarıldığında korunur mu?**

Desteklenen [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/) dışa aktarmalar köprüleri koruyabilir; raster [images](/slides/tr/nodejs-java/convert-powerpoint-to-png/) ve [video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) koruyamaz. Dışa aktarma hususları için [Raporla, Temizle ve Köprüleri Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.