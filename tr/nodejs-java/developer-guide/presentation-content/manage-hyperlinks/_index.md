---
title: JavaScript'te Sunum Köprülerini Yönet
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/nodejs-java/manage-hyperlinks/
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
- görsel köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PowerPoint ve OpenDocument sunumlarında köprü ekleme, biçimlendirme, güncelleme ve kaldırma işlemlerini JavaScript örnekleri kullanarak yapın."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine ya da sunum içinde bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaçla kullanılır:

* Metinden, şekilden veya medya çerçevesinden bir web sitesini açar.
* Örneğin bir içindekiler tablosundan başka bir slayta gider.

Aspose.Slides for Node.js via Java, bu bağlantıları eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, bireysel öğelerdeki köprülerle nasıl çalışılacağını ve sunum, slayt ya da metin‑çerçevesi seviyesinde köprülere nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}

Sunumları ayrıca [Ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.

{{% /alert %}} 

## **URL Köprüleri Ekle**

Metne, şekle veya medya çerçevesine bir web sitesi URL'si atayabilirsiniz. Köprüyü atadığınız öğe, tıklanabilir alanı belirler: metin bölümü seçilen metni bağlarken, şekil ya da çerçeve slayt nesnesini bağlar.

Göreli köprüler içeren sunumlar için, belge‑seviye temeli okumak, değiştirmek veya temizlemek üzere [Köprü Temelini Yönet](/slides/tr/nodejs-java/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Köprüsü Ekle**

Metni bir web sitesine bağlamak için, metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) yöntemine bir [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) nesnesi gönderin; aşağıda gösterildiği gibi. Yalnızca o metin bölümü tıklanabilir hâle gelir.

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

### **Şekillere ve Medya Çerçevelerine URL Köprüsü Ekle**

Bir şekli ya da çerçeveyi tıklanabilir hâle getirmek için, onun [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) yöntemini çağırın. Köprü, içinde metin bölümü bulunmasından bağımsız olarak nesnenin kendisine aittir.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: köprüyü çerçeveye atayın ve gerekirse [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) metodunu çağırın.

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

## **İçindekiler Tablosu Oluşturmak için Köprüleri Kullan**

Dahili köprüler, okuyucuların bir içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, birinci slayttaki “Page 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) yöntemini kullanır.

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

## **Köprüleri Biçimlendir**

### **Renk**

[Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) sınıfının [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) yöntemi, bir köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019’da tanıtıldı; daha eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlki kırmızı metin dolgu rengine sahiptir, ikincisi ise varsayılan köprü rengini korur.

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

Bir köprü, etkinleştirildiğinde bir ses çalabilir ya da hâlihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound), köprüye ilişkilendirilen sesi belirler.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick), köprünün etkinleştirilmesinin önceki sesi durdurup durdurmayacağını kontrol eder.

#### **Köprünün Sesini Ekle**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve birinci slayttaki bir düğmeye ilişkilendirir. Düğmeye tıklandığında ses çalar ve bir sonraki slayta geçilir. Aynı slayttaki ikinci bir şekil, tıklandığında önceki sesi durdurur; navigasyon eylemi gerçekleştirmez.

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

#### **Köprü Sesini Çıkar**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve birinci şeklin köprü sesini [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) ve [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData) yöntemleriyle belleğe okur.

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

Metne ya da şekle bir köprü atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) yöntemlerini çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip), izleyicinin bağlantı için ipucu olarak gösterebileceği metni ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame), uygulanabilir olduğunda üst HTML çerçeve kümesindeki hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory), bağlantının etkinleştirilmesinin hedefi görüntülenen köprüler listesine ekleyip eklemeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick), köprünün tıklandığında vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Köprüleri Kaldır**

[ getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) yöntemini kullanarak metin‑bölümü köprüleri dahil tüm köprü kapsayıcılarını toplayın; ardından değişiklik yapın. Aşağıdaki örnek birinci slayttan her iki etkinleştirme türünü de kaldırır. Yalnızca bir türü kaldırmak isterseniz, sadece [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) ya da [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) yöntemini çağırın; bir tıklama eylemini kaldırmak, fare‑üzerinde eylemini kaldırmaz.

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

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) seçili kapsam içinde her iki etkinleştirme türünü tek bir çağrıyla kaldırır. Seçici temizlik ve ana‑slayt, yerleşim ve notların kapsamlı ele alınması için [Köprüleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluştur**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) yalnızca URL dizesi listesi yerine köprü kapsayıcılarını döndürür. Her kapsayıcıda hem [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) metodlarını inceleyin. Bunlar birbirinden bağımsızdır: aynı kapsayıcı iki eylemi de sunabilir; bu yüzden kapsamlı bir rapor her kapsayıcı için iki satır gerektirebilir.

Yalnızca şekil‑seviyesi köprüleri taramak, metin bölümlerine eklenmiş bağlantıları kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve döndürülen kapsayıcıları saklayın; böylece daha sonra eylemlerini güncelleyebilir ya da kaldırabilirsiniz.

### **Sunum, Slayt ve Metin Çerçevesi Kapsamlarını Sorgula**

[HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) sınıfı, [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) ve [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) aracılığıyla kullanılabilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) tıklama eylemi olan kapsayıcıları döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) fare‑üzerinde eylemi olan kapsayıcıları döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) bir ya da iki eylemi olan kapsayıcıları döndürür.

Aşağıdaki örnek, dış tıklama bağlantısı, dosya fare‑üzerinde bağlantısı, dahili slayt gezintisi, metin fare‑üzerinde bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Hiçbir eylemi çalıştırmaz. Aynı üç sorgu her kapsamda çalışır; sayılar kapsayıcı adedini, eylem toplamını değil, gösterir. Metin‑çerçevesi kapsamı dışındaki şeklin kendi bağlantılarını dışlar.

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

Bu örnek için, sunum ve slayt sorguları her birinde üç tıklama kapsayıcısı, iki fare‑üzerinde kapsayıcısı ve üç ortak kapsayıcı rapor eder. Metin‑çerçevesi sorgusu her kategoride bir kapsayıcı bildirir.

### **Eylemleri ve Hedefleri Sınıflandır**

[Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) metodunu, bir eylemi yorumlamadan önce kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) değerleri web gezinmesinden daha fazlasını kapsar:

| Değerler | Denetim için Anlamı |
| --- | --- |
| `Hyperlink` | Harici köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta içsel gezinme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Yerleşik slayt gösterisi gezinmesi, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırır veya özel bir gösteri başlatır. |
| `StartMacro` | Makro çalıştırır. |
| `StartProgram` | Program başlatır. |
| `OpenFile`, `OpenPresentation` | Dosya veya başka bir sunumu açar; web URL'lerinden ayrı incelenir. |
| `StartStopMedia` | Medya oynatımını başlatır veya durdurur. |
| `NoAction`, `Unknown` | Gezinti eylemi yoktur veya tanımlanamayan eylem, incelenmesi gerekir. |

Harici hedefleri [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) ile, belirli iç hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) ile okuyun. İç eylemler ve yerleşik komutlar harici URL içermeyebilir; boş bir URL kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) değerini koruyun ve mevcutsa [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) tarafından döndürülen ipucunu ekleyin.

### **Köprüleri Raporla, Temizle ve Doğrula**

Aşağıdaki JavaScript örneği mevcut bir sunumu okur (yukarıda oluşturulan dosyayı kullanın), `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` dosyasını kaydeder ve tekrar açarak her iki etkinleştirme türünü yeniden kontrol eder. Değişiklik öncesi kapsayıcıları toplar ve aynı kapsayıcıyı iki kez işlememek için referans eşitliğini kullanır. Sunum sorguları normal slaytları kapsar; paket‑geneli envanter için ayrıca ana‑slayt, yerleşim, not ve not‑el dağıtım ana‑slaytları açıkça sorgulanır.

Rapor, bir‑bazlı slayt indeksini ve mümkünse [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) değerini kaydeder. Desteklenen kapsayıcılar için [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) ilgili slaytı sağlar. Ana‑slayt, yerleşim ve notların normal slayt indeksi yoktur; kapsamlarıyla tanımlanırlar. Şekil kapsayıcıları ve metin‑bölümü biçimlendirme kapsayıcıları ayrı etiketlenir; diğer kapsayıcı türleri çalışma zamanı tip adını korur. Her kapsayıcı, iki eylemin ilişkilendirilebilmesi için rapor‑yerel bir kimlik alır. Rapor, eylem türlerini HyperlinkActionType enum'unda tanımlı tamsayı sabitleri olarak saklar.

Bu kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL'lerini ve geçerli dahili slayt hedeflerini izin verir. Makrolar, programlar, dosya eylemleri, diğer slayt‑gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güven sağlamaz: uygulamanıza uygun host beyaz listeleri ve diğer kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler kontrol edilir. Örnek, bağlantıları takip etmeden ya da eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, kapsayıcının [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) metodu [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) yöntemlerini destekler. Burada, yasak dış tıklama bağlantıları sabit bir HTTPS açılış sayfası ile değiştirilir; diğer yasak tıklama ve fare‑üzerinde eylemleri bağımsız olarak kaldırılır. `replaceExternalClicks` değerini `false` yaparak tüm politika ihlallerini kaldırabilirsiniz. Dağıtıma geçmeden önce uygulama‑sahibi bir yedekleme sayfası seçin.

Raporun dışa aktarım bayrağı, temkinli bir PDF inceleme politikası uygular: fare‑üzerinde eylemler ve harici bağlantı ya da belirli slayt atlaması dışındaki her şey potansiyel olarak desteklenmez olarak işaretlenir. Bu bir inceleme ipucu olup, yetenek testi ya da işaretlenmemiş bağlantıların dışa aktarımda hayatta kalacağı garantisi değildir. Desteklenen [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarım seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir. Raster [görüntüler](/slides/tr/nodejs-java/convert-powerpoint-to-png/) ve [videolar](/slides/tr/nodejs-java/convert-powerpoint-to-video/) etkileşimli köprüleri koruyamaz; bu çıktılar için denetim sırasında her eylem işaretlenmelidir.

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

Yukarıda oluşturulan giriş ile rapor beş eylem satırı içerir. Dosya fare‑üzerinde bağlantısı ve makro tıklaması kaldırılırken, HTTPS bağlantıları ve dahili slayt gezinmesi kalır. Doğrulama, yasak eylem olmadığını sıfır olarak gösterir. Yasak bir dış tıklama URL'si içeren bir giriş, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak fare‑üzerinde eylemi olan bir kapsayıcı, tıklama eylemini korur.

Bu seçici temizlik, [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) yönteminin aksine, politika gözetmeksizin seçili kapsam içinde her iki etkinleştirme türünü de kaldırmaz. Buradaki doğrulama yalnızca köprü eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içerikleri kaldırmaz ve dışa aktarılmış PDF ya da HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme ya da onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint'te bölümler slaytları gruplar, ancak dahili bir köprü yalnızca tek bir slaytı hedef alır. Bir bölüme gezinme oluşturmak için, o bölümün ilk slaytına bağlanın.

**Ana slayt öğelerine bir köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Ana slayt ve yerleşim öğeleri köprüleri destekler. Bu öğelere eklenen köprüler, ilgili ana‑slaytı veya yerleşimi kullanan slayt gösterisi sırasında kullanılabilir.

**Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarıldığında korunur mu?**

Desteklenen PDF ve HTML dışa aktarımları köprüleri koruyabilir; raster görüntüler ve videolar etkileşimli köprüleri koruyamaz. Ayrıntılar için [Köprüleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.