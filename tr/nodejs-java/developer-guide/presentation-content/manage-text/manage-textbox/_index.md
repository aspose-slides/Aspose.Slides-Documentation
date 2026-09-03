---
title: Sunumlarda JavaScript Kullanarak Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/nodejs-java/manage-textbox/
keywords:
- metin kutusu
- metin çerçevesi
- metin ekle
- metni güncelle
- metin kutusu oluştur
- metin kutusunu kontrol et
- metin sütunu ekle
- köprü ekle
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument sunumlarında metin kutularını oluşturma, tanımlama, biçimlendirme ve güncelleme."
---
## **Giriş**

Aspose.Slides for Node.js via Java'da slayt metni, şekillere ait metin çerçevelerinde depolanır. [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) sınıfı en yaygın metin taşıyan şekli temsil eder ve metnini [AutoShape.getTextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/#getTextFrame) yöntemi aracılığıyla açığa çıkar.

{{% alert color="info" title="Not" %}}

Her otomatik şekil [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) sınıfından türetilir, ancak her şekil bir otomatik şekil değildir ve bir metin çerçevesi desteklemez. Mevcut bir sunumu işlerken, metnine erişmeden önce şeklin [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) örneği olup olmadığını kontrol edin.

{{% /alert %}}

## **Bir Slayta Metin Kutusu Oluşturma**

Bir metin kutusu oluşturmak için bir slayta otomatik şekil ekleyin, metin çerçevesine metin ekleyin ve sunumu kaydedin. Aşağıdaki örnek dikdörtgen bir metin kutusu oluşturur:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ShapeCollection.addAutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addAutoShape) yöntemine geçirilen koordinat ve boyutlar nokta biriminde ölçülür. [AutoShape.addTextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/#addTextFrame) verilen metinle metin çerçevesini başlatır.

## **Metin Kutusu Şekli Kontrolü**

Bir otomatik şeklin metin kutusu olarak ele alınıp alınmadığını belirlemek için [AutoShape.isTextBox](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/#isTextBox) yöntemini kullanın. Bu, bir sunum hem metin taşıyan hem de yalnızca grafiksel otomatik şekiller içerdiğinde yararlıdır.

![Bir metin kutusu ve bir şekil](istextbox.png)

Aşağıdaki örnek bir sunumdaki her otomatik şekli inceler:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Yeni eklenen bir otomatik şekil, içinde boş olmayan metin olduğu sürece metin kutusu olarak kabul edilmez. Bu metni [AutoShape.addTextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/#addTextFrame) veya [TextFrame.setText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#setText) yöntemiyle sağlayabilirsiniz. Boş bir dize eklemek veya atamak, [AutoShape.isTextBox](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/#isTextBox) yönteminin `false` döndürmesine neden olur:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

İlk iki çağrı `true`; son iki çağrı `false` yazdırır.

## **Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodu, hangi sunum nesnesinin içinde bulunduğunu bilmeden bir [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) alabilir. Sahibi olan [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) nesnesine geri dönmek için yalnızca okuma izni olan [TextFrame.getParentShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentShape) yöntemini kullanın.

Bir otomatik şekil veya başka bir metin taşıyan şekil tarafından sahip olunan bir metin çerçevesi için [TextFrame.getParentShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentShape) sahibi döndürür ve [TextFrame.getParentCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentCell) `null` döndürür. Erişmeden önce dönen değeri kontrol edin. Şekil ve tablo hücresi sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de içerecek şekilde tanımlamak için [Metin Ara ve Değiştir](/slides/tr/nodejs-java/search-and-replace-text/) konusuna bakın.

## **Metin Kutusuna Sütunlar Ekleme**

[TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setColumnCount) yöntemi metin çerçevesini sütunlara böler, [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) ise sütunlar arasındaki boşluğu nokta biriminde ayarlar. Her iki ayar da [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/) sınıfına aittir ve mevcut bir metin kutusunun metin çerçevesi üzerinden değiştirilebilir. Metin aynı şekil içinde sütunlar arasında akışır; başka bir şekle geçmez.

Aşağıdaki örnek, sütun başına 10 nokta boşlukla üç sütunlu bir metin kutusu oluşturur, sunumu kaydeder ve çıkış dosyasından kaydedilen ayarları geri okur:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Tekil Sütunlardan Metni Çıkarma**

Mevcut bir metin çerçevesindeki her görsel sütuna atanmış metni almak için [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#splitTextByColumns) yöntemini kullanın. Yöntem, sütun tabanlı okuma sırasına göre her sütun için bir dize döndürür. Tek sütunlu bir metin çerçevesi bir elemanlı bir dizi üretir ve boş bir sütun boş bir dize ile temsil edilir. Dize yalnızca düz metin içerir; bölüm‑düzeyi biçimlendirme korunmaz.

Bu yöntem aşağıdaki durumlarda faydalıdır:

- Metni sütun‑tabanlı okuma sırasını koruyarak çıkarmak.
- Çok‑sütunlu slaytların içeriğini indekslemek veya karşılaştırmak.
- Her sütunu ayrı bir dosya, veritabanı alanı veya başka bir hedefe aktarmak.
- [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setColumnCount), [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), yazı tipi veya metin‑çerçevesi boyutu gibi ayarları değiştirdikten sonra metnin nasıl yeniden dağıtıldığını incelemek.

Yöntem, mevcut [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) içinde dağıtılmış metni rapor eder; ayrı şekiller veya metin kutuları arasında otomatik akış sağlamaz. Sütun dağılımı mevcut yazı tiplerine ve diğer metin‑dizilim ayarlarına bağlıdır; tutarlı sonuçların önemli olduğu durumlarda gerekli yazı tiplerinin mevcut olduğundan emin olun.

Aşağıdaki örnek bir sunum yükler, metin çerçevesi olan ilk çok‑sütunlu otomatik şekli bulur, yapılandırılmış sütun sayısını okur ve her sütunun metnini ayrı bir dosyaya yazar. Metin çerçevesi sağlamayan şekiller atlanır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Metni Güncelleme**

Bir sunumda metni güncellemek için slaytları ve şekilleri döngüye alın, otomatik şekilleri seçin ve ardından metin bölümlerini düzenleyin. Bölüm seviyesinde çalışmak, metni ve karakter biçimlendirmesini değiştirmenize olanak tanır.

Aşağıdaki örnek, otomatik‑şekil metnindeki tüm `years` ifadelerini `months` ile değiştirir ve etkilenen her bölümü kalın yapar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu gezinti yalnızca otomatik şekillerdeki metni günceller. Tablolar, grafikler, SmartArt veya gruplandırılmış şekillerde saklanan metin, ilgili nesnelerin kendi koleksiyonlarının gezilmesini gerektirir.

## **Köprülü Bir Metin Kutusu Ekleme**

Bir köprü belirli bir metin bölümüne atanabilir; böylece yalnızca o metin tıklanabilir bağlantı olur. Bölümü harici bir URL ile ilişkilendirmek için [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) yöntemini kullanın.

Aşağıdaki örnek bağlantılı metin oluşturur ve bir sunuma kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir ana slayt veya düzen slaytındaki metin kutusu ile metin yer tutucusu arasındaki fark nedir?**

Bir [placeholder](/slides/tr/nodejs-java/manage-placeholder/) konum ve biçimini bir [master slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) veya [layout slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) üzerinden devralabilir. Normal bir metin kutusu, oluşturulduğu slaytta bağımsız bir şekildir ve düzen değiştiğinde yer tutucu davranışı kazanmaz.

**Grafik, tablo veya SmartArt'taki metni değiştirmeden metni nasıl değiştirebilirim?**

Gezintiyi, [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) örnekleriyle sınırlayın; bu, Metni Güncelleme örneğinde gösterildiği gibidir. Grafikler, tablolar ve SmartArt kendi nesne modellerinde metni depolar, bu yüzden bu döngü tarafından değiştirilmezler.