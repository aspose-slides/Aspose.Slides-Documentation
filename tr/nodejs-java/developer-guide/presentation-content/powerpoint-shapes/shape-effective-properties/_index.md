---
title: Şekillerin Etkili Özelliklerini JavaScript ile Sunumlardan Almak
linktitle: Etkili Özellikler
type: docs
weight: 50
url: /tr/nodejs-java/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık donanımı
- köşe şekli
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu formatı
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'ı kullanarak PowerPoint sunumlarında yerel, kalıtılmış ve etkili şekil biçimlendirmesini nasıl ayırabileceğinizi öğrenin."
---
## **Yerel, Kalıtılmış ve Etkili Özellikleri Anlamak**

PowerPoint biçimlendirmesi birkaç kaynaktan gelebilir. Bir nesne üzerinde doğrudan depolanan değer **yerel değerdir**. Bu değer ayarlanmamışsa, PowerPoint bir paragraf varsayılanı, bir metin stili, bir düzen ya da ana slayt, bir tema veya sunum düzeyinde varsayılanlar gibi üst biçimlendirme kaynaklarına bakar. Bu değerler **kalıtılmış değerler**dir. Tüm hiyerarşi çözüldükten sonra kalan değer **etkili değer**dir—nesneyi renderlamak için kullanılan değer.

Örneğin, bir metin bölümü kendi yazı tipi yüksekliğini tanımlamıyor olabilir. Yerel [getFontHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/#getFontHeight) değeri `NaN` olur, bu da “burada ayarlı değil” anlamına gelir. Bölüm, paragrafından, sunumun varsayılan metin stilinden veya başka bir uygulanabilir kaynaktan yükseklik kalıtabilir. Bölüm formatı üzerinde [getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/#getEffective) çağrısı, son çözülen yüksekliği döndürür.

İki tür biçimlendirme verisini farklı amaçlar için kullanın:

- Bir değerin nerede tanımlandığını kontrol etmeniz gerektiğinde, [PortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/) gibi yerel bir format nesnesini okuyun veya değiştirin.
- Son, renderlanmış sonucu ihtiyaç duyduğunuzda, [effective data returned by PortionFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/#getEffective) verisini okuyun. Etkili veri yalnızca okunabilir.

Örnekleri çalıştırmadan önce, [install Aspose.Slides for Node.js via Java](/slides/tr/nodejs-java/installation/).

## **Yerel, Kalıtılmış ve Etkili Değerleri Karşılaştırma**

Aşağıdaki tam örnek bir şekil oluşturur ve sunum, paragraf ve bölüm seviyelerinde yazı tipi yükseklikleri uygular. Her adım, bu seviyelerde tanımlanan değerleri ve aynı metin bölümü için ortaya çıkan etkili değeri yazdırır. Ayrıca, biçimlendirme değişikliklerinden sonra etkili verinin yeniden okunması gerektiğini gösterir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Önceki değişikliklerden sonra etkili veriyi oku.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // İki farklı seviyede kalıtılmış değerleri tanımla.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Bölümdeki yerel değer, her iki kalıtılmış değerin üzerine yazar.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Kalıtılmış bir değeri değiştirmek, mevcut bir yerel değerin üzerine yazmaz.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Yerel değeri temizle. Bölüm şimdi tekrar paragraftan kalıtım alıyor.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Paragraf değerini temizle. Sunum varsayılanı şimdi sonucu sağlıyor.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu örnekte öncelik bölümün yerel biçimlendirmesi, ardından paragraf biçimlendirmesi ve son olarak sunum varsayılanıdır. Diğer nesneler farklı kalıtım zincirlerine sahip olabilir, ancak prensip aynıdır: daha spesifik açık değer kazanır ve [getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/#getEffective) son sonucu döndürür.

## **Etkili Metin Özelliklerini Almak**

Metin biçimlendirmesi birden fazla nesneye yayılmıştır:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#getEffective) kenar boşlukları, tutturma, otomatik sığdırma ve dikey metin yönü gibi metin çerçevesi özelliklerini çözer.
- [TextStyle.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textstyle/#getEffective) her metin stili seviyesinin paragraf biçimlendirmesini çözer.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#getEffective) hizalama, girinti ve madde işareti gibi paragraf özelliklerini çözer.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/#getEffective) yazı tipi yüksekliği, yazı tipi, renk, kalın ve italik gibi karakter özelliklerini çözer.

Sonraki örnek için `text-formatting.pptx` dosyasının en az bir slaytı ve içinde boş olmayan bir metin çerçevesi bulunan bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) içermesi gerekir. AutoShape, şekil koleksiyonundaki herhangi bir konumda olabilir; kod uygun bir nesneyi arar ve kullanmadan önce doğrular.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Etkili 3D Özelliklerini Almak**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getEffective) tüm çözülen 3D ayarlarını gruplandıran tek bir etkili veri nesnesi döndürür. Bu nesnenin [getCamera](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getBevelTop) ve [getBevelBottom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getBevelBottom) yöntemleri ilgili etkili verileri sunar. Bu ilgili ayarları birlikte okumak, bir şeklin son 3D görünümünü anlamayı kolaylaştırır.

Bu örnek için `shape-3d.pptx` dosyasının ilk slaytında en az bir şekil bulunmalıdır. Çıktının varsayılanların dışında değerler içermesini istiyorsanız, bu şekle 3D kamera, aydınlatma veya köşe ayarları uygulayın.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Etkili Tablo Biçimlendirmesini Almak**

Tablo biçimlendirmesi tablo stilinden ve tüm tablo, bir sütun, bir satır veya bireysel bir hücreye uygulanan biçimlendirmelerden gelebilir. Açıkça tanımlanmış doldurmalar arasında çakışma olduğunda öncelik hücre, satır, sütun ve ardından tüm tablo şeklindedir. Bir hücrenin etkili formatı, o hücreyi çizerken kullanılan son formattır.

Bu örnek için `table-formatting.pptx` dosyasının ilk slaytında en az bir tablo bulunmalıdır. Tablo en az bir satır ve bir sütun içermelidir. Kod, `getShapes().get_Item(0)`'ın bir tablo olduğunu varsaymak yerine bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/table/) arar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Renk ihtiyacınız varsa ve sadece doldurma türü yeterli değilse, önce etkili [getFillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/#getFillType) yöntemini kontrol edin ve ardından o türe uygulanabilen yöntemi okuyun—örneğin, katı doldurma için [getSolidFillColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/#getSolidFillColor).

## **Değişikliklerden Sonra Etkili Veriyi Yeniden Okuma**

Etkili veri, çözümleme anındaki biçimlendirme hiyerarşisini tanımlar. Hiyerarşiye katılabilecek herhangi bir şeyi değiştirdikten sonra `getEffective` yöntemini tekrar çağırın; örnekler:

- nesnenin yerel biçimlendirmesi;
- paragraf veya metin çerçevesi varsayılanları;
- bir tablo stili, tablo, sütun, satır veya hücre biçimi;
- düzen veya ana slayt biçimlendirmesi;
- tema verileri veya sunum düzeyinde varsayılanlar;
- bir slayta atanan düzen veya ana slayt.

Etkili veri nesnesini kalıcı bir anlık görüntü olarak saklamayın. Aspose.Slides bazı etkili verileri dahili olarak önbelleğe alabilir ve daha sonraki bir `getEffective` çağrısı bu verileri yenileyebilir. Değişiklik öncesi ve sonrası değerleri karşılaştırmanız gerekiyorsa, değişikliği yapmadan önce ihtiyacınız olan skaler değerleri (ör. yazı tipi yüksekliği, renk, hizalama veya köşe genişliği) kendi değişkenlerinize kopyalayın.

Bir değeri değiştirmek için ilgili yerel format nesnesini güncelleyin ve ardından sonucu doğrulamak için `getEffective` çağırın. Etkili veri nesneleri kendileri yalnızca okunabilir.

## **SSS**

**Etkili bir değerin hangi seviyeden geldiğini nasıl anlayabilirim?**  
Etkili veri, son değeri içerir, kaynağını değil. En spesifik seviyeden dışa doğru uygulanabilir yerel nesneleri inceleyin. Metin için bu, bölüm, paragraf, metin çerçevesi, düzen, ana slayt, tema ve sunum varsayılanlarını içerebilir. `NaN` veya `null` gibi tanımsız değerler, aramanın başka bir seviyeye devam ettiğini gösterir.

**Hiçbir seviye bir özelliği tanımlamazsa ne olur?**  
Aspose.Slides uygun PowerPoint veya kütüphane varsayılanını çözer. Bu çözülen değer, yerel bir nesne açıkça tanımlamasa bile etkili veride görünür.

**Neden bazen etkili değer yerel değerle aynı olur?**  
Yerel değer, kalıtım hesabını kazanmıştır. Bu, özelliğin nesne üzerinde açıkça ayarlandığı ve daha spesifik bir kuralın onu geçersiz kılmadığı durumlarda beklenir.

**Yerel veriyi ne zaman etkili veri yerine kullanmalıyım?**  
Yerel veriyi belirli bir biçimlendirme seviyesini incelemek veya düzenlemek için kullanın. Kalıtım, tema kuralları ve uygulanabilir stiller çözülüp son görünüm gerektiğinde etkili veriyi kullanın. [tam karşılaştırma örneği](#compare-local-inherited-and-effective-values) aynı iş akışında her ikisini de gösterir.