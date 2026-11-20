---
title: "JavaScript'te Sunum Metnini Biçimlendir"
linktitle: "Metin Biçimlendirme"
type: docs
weight: 50
url: /tr/nodejs-java/text-formatting/
keywords:
- "paragraf hizala"
- "metin stili"
- "metin arka planı"
- "metin şeffaflığı"
- "karakter aralığı"
- "yazı tipi özellikleri"
- "yazı tipi ailesi"
- "metin döndürmesi"
- "döndürme açısı"
- "metin çerçevesi"
- "satır aralığı"
- "otomatik sığdırma özelliği"
- "metin çerçevesi ankrajı"
- "metin sekmesi"
- "varsayılan dil"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil uygulayın. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, saydamlık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarlarını kapsar.

Aksi belirtilmedikçe örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaytındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır tabanlıdır. Kalın bölümleri seçen örnekler, kalıtsal kalın biçimlendirme dahil olmak üzere etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Gerçek metni ya da düzenli ifade eşleşmelerini bulmak ve vurgulamak için [Metin Arama ve Değiştirme](/slides/tr/nodejs-java/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak üzere [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) kullanın veya bireysel metin bölümleri için [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerde belirtilen vurgulama renkleri bu varsayılanı geçersiz kılar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Tüm paragraf için vurgulama rengini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği **kalın yazı tipi** kullanan **metin bölümleri** için arka plan renginin nasıl ayarlanacağını gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Metin bölümü için vurgulama rengini ayarla.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

Bir metin çerçevesi içinde paragraf hizalamasını ayarlamak için [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) kullanın. Değerler ortalanmış, sola hizalı, sağa hizalı, iki yana yaslı vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın hizalamasını ortaya ayarla.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Satır İçinde Yazı Tipi Hizalamasını Ayarla**

Farklı yazı tipi boyutlarına sahip metin bölümlerini bir satır içinde dikey olarak hizalamak için [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) kullanın. Bu ayar tüm paragraf için geçerlidir ve her satırın içinde hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, tek bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 puan boyutlarında içerir ve farklı bir yazı tipi hizalamasına sahiptir. Arial kullanır, otomatik sığdırma ve satır kaydırma devre dışı bırakılır, metin çerçeveleri tek satır için yeterli büyüklükte tutulur.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Baseline, Üst, Ortası ve Alt hizalaması karışık yazı tipi boyutlarıyla karşılaştırması](font_alignment.png)

Yazı tipi hizalaması, yazı tipi metriklerine dayanır; bu nedenle bireysel harflerin görünen kenarları tam olarak hizalanmayabilir. Örnek, büyük harf ve bir alçak karakter içererek baseline ile alt hizalama arasındaki farkı göstermeye çalışır. Yazı tipi bulunabilirliği, karakter seçimi ve yazı tipi boyutlarındaki fark sonuçları etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da yerleşimi etkiler; karşılaştırma yaparken aynı yazı tipleri ve düzen ayarları kullanılmalıdır.

Bu ayar, yatay paragraf hizalamasını kontrol eden [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) ve şekil içinde metin bloğunu dikey konumlandıran [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) ayarlarından farklıdır. [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) ile yapılan üst ve alt indeksleme, baseline’a göre bireysel bölümleri kaydırır; paragraf satırları için yazı tipi hizalamasını ayarlamaz.

## **Metin Şeffaflığını Ayarla**

Metin şeffaflığı, [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) aracılığıyla atanmış rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde olarak şeffaflık değildir.

Aşağıdaki kod örneği **tüm paragraf** için şeffaflık nasıl uygulanacağını gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Metnin doldurma rengini şeffaf renk olarak ayarla.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın yazı tipi** kullanan metin bölümleri için şeffaflığın nasıl uygulanacağını gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Metin bölümünün şeffaflığını ayarla.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Aralığını Ayarla**

Bir metin kutusunda karakterler arasındaki boşluğu genişletmek veya daraltmak için [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) kullanın. Örnekler 3 puanlık boşluk ekler; negatif değerler metni sıkıştırır.

Aşağıdaki JavaScript kodu, **tüm paragraf** içinde karakter aralığını nasıl genişleteceğinizi gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karakter aralığını genişlet.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği **kalın yazı tipi** kullanan metin bölümleri için karakter aralığını nasıl genişleteceğinizi gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
            portion.getPortionFormat().setSpacing(3); // Karakter aralığını genişlet.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning’i Devre Dışı Bırak**

Bazı durumlarda Aspose.Slides tarafından oluşturulan metin, PowerPoint’teki aynı metinden biraz daha sık görünebilir. Bu, PowerPoint’in belirli yazı tipleri için kerning verisini görmezden gelmesinden kaynaklanabilir; yazı tipi geçerli kerning bilgisine sahip olsa bile PowerPoint ayarlarında kerning açıksa.

Bu durumlarda, etkilenen yazı tipini kullanan metin bölümleri için kerning’i devre dışı bırakabilirsiniz. [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) değerini gerçek yazı tipi boyutundan büyük bir değere ayarlayın. Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren “presentation.pptx” dosyasını gerektirir. Etkili yazı tiplerini (kalıtsal yazı tipleri dahil) denetler ve Roboto kullanan bölümler için 100 puanlık eşik belirler. Bu, 100 puandan düşük boyutta kullanılan eşleşen bölümler için kerning’i devre dışı bırakır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eşiğin altındaki eşleşen metinler için bu ayar kerning’i engeller ve PowerPoint’in bu yazı tipleri için gösterdiği görsel çıktıya daha yakın bir render elde edilmesine yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) aracılığıyla paragraf seviyesinde veya [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) aracılığıyla tekil bölümlerde ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman, kalın, italik ve noktalı altı çizili olarak ayarlar. Tekil bölümler üzerindeki açık biçimlendirme bu varsayılanları geçersiz kılar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Paragraf için yazı tipi özelliklerini ayarla.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik ve noktalı altı çizili uygular:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Metin bölümü için yazı tipi özelliklerini ayarla.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Yüksekliği Normalizasyonunu Kontrol Et**

Şablon tipografisini yeniden üretirken veya karakter yüksekliği farklarını incelerken [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) kullanın. PowerPoint’te normalizasyonu etkinleştirmek, bireysel karakterleri dikey olarak gererek metin bölümünde görünür yüksekliği eşitlemeye çalışır. Farklı yazı tipleri arasında eşit metin yüksekliği garantilenmez.

Özelliği **True** veya **False** olarak ayarlamak için [NullableBool.True or False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) kullanın. `NullableBool.NotDefined` yerel ayarı ayarlamaz ve bölümün değerini, örneğin paragrafın [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) gibi bir kaynaktan devralmasına izin verir. Bu, `False` anlamına gelmez. Çözülmüş Boolean değeri elde etmek için [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) ve [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) kullanın.

Aşağıdaki bağımsız örnek **Arial** yüklü olmasını gerektirir. 54 puan boyutunda aynı büyük harfler, küçük harfler, alçak karakterler ve aksanlı karakterler içeren iki metin bloğu oluşturur. Her iki paragraf da varsayılan olarak normalizasyonu etkinleştirir. Üst bölüm bunu açıkça devre dışı bırakırken, alt bölüm devralır. Çerçeve boyutları, kenar boşlukları ve paragraf aralığı aynıdır; karşılaştırmanın tutarlı olması için kaydırma ve otomatik sığdırma devre dışı bırakılmıştır. Örnek `False: false` ve `NotDefined: true` çıktısını verir, ardından “text_height_normalization.pptx” dosyasını kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma kaydedilen sunumdan dışa aktarılmıştır. Üst satırda normalizasyon devre dışı (`False`); alt satırda devralınmış ayar (`NotDefined` → `True`). Bu görünümü yeniden üretmek için Arial kurulu olmalıdır.

![Arial 54 puan metin, üstte normalizasyon devre dışı, altta devralınmış](text_height_normalization.png)

Normalizasyon, atanan [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight) değerini değiştirmeden karakter yüksekliğini değiştirir; bu değer puan cinsinden font boyutunu belirtir. Paragraf [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) satır aralığını kontrol eder, metin çerçevesi [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) ise metin ya da kapsayıcının nasıl ayarlanacağını belirler. Bu ayarlar farklı amaçlara hizmet eder ve düzeni bağımsız olarak etkileyebilir. Paragraf biçimlendirme ve kalıtım hakkında daha fazla bilgi için [Paragrafı Yönet](/slides/tr/nodejs-java/manage-paragraph/) bölümüne bakın.

## **Üstü Çizili (Strikethrough) Uygula ve Kaldır**

Bir metin bölümünde hataları, iptal edilen ifadeleri veya önceki fiyatları göstermek için [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) kullanın. Metin üzerindeki bir ya da iki çizgi için [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) değerini ayarlayın.

Üstü çiziliyi kaldırmak için [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None) kullanın. Bu, çevreleyen biçimlendirme üstü çiziliyi belirtse bile efekti açıkça devre dışı bırakır. Bunun aksine, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) yerel ayarı tanımsız bırakır ve bölümün, örneğin paragraftan, biçimlendirmeyi devralmasına izin verir; bu, üstü çiziliyi kaldırdığı garantisi vermez. Sonuçlandırılan biçimlendirmeyi, kalıtsal değerler de dahil olmak üzere okumak için [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) kullanın.

Aşağıdaki bağımsız örnek üç fiyat karşılaştırması oluşturur. Her paragraf, etiket, önceki fiyat ve mevcut fiyat için ayrı bölümler içerir; böylece yalnızca önceki fiyat etkilenir. İlk satır üstü çiziliyi uygular ve ardından kaldırır; diğer satırlar tek ve çift üstü çiziliyi korur. Bu ayarın değiştirilmesi, metni ve diğer biçimlendirmelerini, örneğin kalın önceki fiyatı, korur.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Üstü çizgiyi uygula, ardından ilk önceki fiyatın üzerindeki çizgiyi açıkça kaldır.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç, yukarıdan aşağıya: üstü çizili yok, tek üstü çizili, çift üstü çizili.

![Üstü çizili olmayan, tek üstü çizili ve çift üstü çizili önceki fiyatlar](strikethrough.png)

## **Metin Döndürmeyi Ayarla**

Bir şekil içinde önceden tanımlı bir metin yönlendirmesi ayarlamak için [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) kullanın.

Aşağıdaki kod örneği, şekildeki metin yönlendirmesini **90 derece saat yönünün tersine** döndüren [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/) olarak ayarlar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarla**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) kullanarak bir [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) için özel bir döndürme açısı ayarlayın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif değer satır aralığını satır yüksekliğinin yüzde olarak belirtir.
* Negatif değer satır aralığını puan cinsinden belirtir.

Aşağıdaki örnek, ilk paragraftaki satır aralığını satır yüksekliğinin %200’ü (çift satır aralığı) olarak ayarlar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Satır Kesintisini Kontrol Et**

Paragraf satır kesintisi kuralları, dar metin bloklarında ve Latin ile Doğu Asya metinlerinin karıştığı sunumlarda yararlıdır. Aşağıdaki yöntemler [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/)’a aittir ve bir bütün paragrafta geçerlidir:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) Latin satır kesintisi kurallarını kontrol eder. Karışık metinlerde değiştirildiğinde, bitişik Doğu Asya metni ve noktalama işaretlerinin kaydırılma noktaları da etkilenebilir.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) Doğu Asya satır kesintisi kurallarını, satır başı ve sonundaki karakter sınırlamalarını içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik kaydırmayı etkinleştiren [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText) işlevinin yerine geçmez; kaydırma gerçekleştiğinde yerleşimi etkiler, satır sonu karakteri eklemezler. Açık bir satır sonu, paragraf içinde mevcut genişliğe bakılmaksızın yeni bir satır başlatır.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesintisi seçeneğini de açıkça ayarlar ve “line_breaking.pptx” dosyasına kaydeder. Her kuralı denemek için, diğer ayarları sabit tutarken ilgili değeri değiştirin. Örnek 24 puan Arial ve SimSun, 160 puan çerçeve genişliği ve sıfır yatay metin çerçevesi kenar boşluğu kullanır. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) ile çağrılır; böylece metin boyutu ve çerçeve boyutları sabit kalır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Asılı Noktalama İşaretlerini Kontrol Et**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation), uygun noktalama işaretlerinin metin satırının sağ kenarının ötesine uzanmasına izin verir; bir sonraki satırı doldurmaz. Bu, tüm paragraf için geçerlidir ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğindeki bir metin çerçevesinde asılı noktalama işaretini etkinleştirir ve “hanging_punctuation.pptx” dosyasına kaydeder. 24 puan Arial ve sıfır yatay metin çerçevesi kenar boşluğu ile, son nokta “sentence” kelimesinden sonra kalır ve sağ metin kenarının ötesine uzanır. Karşılaştırmak için özelliği [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) olarak ayarlayın; bu ayarlarda nokta ayrı bir satırda yer alır. Kaydırma etkin, otomatik sığdırma devre dışı bırakılmıştır; böylece kullanılabilir genişlik sabittir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Her noktalama işareti asılı olamaz. Yukarıda açıklanan [yazı tipi ve yerleşim koşulları](#control-line-breaking) bu karşılaştırmaya da uygulanır; yazı tipi, kullanılabilir genişlik, kenar boşlukları veya otomatik sığdırma ayarları değiştirildiğinde görünür fark ortadan kalkabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType), metnin kapsayıcısının sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülmesi, taşması veya şeklin otomatik olarak yeniden boyutlandırılması gibi davranışları kontrol etmek için kullanın. Aşağıdaki örnek, şeklin metnine sığacak şekilde yeniden boyutlandırılmasını yapılandırır ve sonucu “autofit_type.pptx” olarak kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otomatik kaydırma sonrası satır sayısını saymak ve metnin ya da şeklin genişliğinin sonucu nasıl etkilediğini görmek için [Render Edilen Satırları Say](/slides/tr/nodejs-java/manage-paragraph/) bölümüne bakın. Satır sayısı yalnızca metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Bağlantı Noktasını Ayarla**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), bir şekil içinde metnin dikey konumlandırılmasını tanımlar; örneğin üst, orta veya alt gibi. Aşağıdaki örnek, metni ilk şeklin altına sabitler ve sonucu “text_anchor.pptx” olarak kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Metin Sekmelerini Ayarla**

Bir paragrafta sek duraklarını yapılandırmak için [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) ve [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) kullanın. Aşağıdaki örnek, varsayılan sek aralığını 100 puan olarak ayarlar ve 30 puanda sola hizalı bir sek durak ekler. Bu ayarlar sek karakteri içeren metni etkiler.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraf sekleri](paragraph_tabs.png)

## **Düzeltme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için düzeltme dilini ayarlamanızı sağlayan [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) sunar. Düzeltme dili, PowerPoint’teki imla ve dil bilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki örnek, ilk slayttaki ilk şekil olarak bir metin kutusu ve en az bir paragraf içeren “presentation.pptx” dosyasını gerektirir. İlk paragrafın içeriği “1”。 ile değiştirilir, SimSun yazı tipi atanır ve Basitleştirilmiş Çince düzeltme dili (`zh-CN`) belirlenir. Sonuç “proofing_language.pptx” olarak kaydedilir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Düzeltme dilinin kimliğini ayarla.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dil Üst Verilerini Kopyala**

Çok dilli bir şablondan metin kopyalarken, hem [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) hem de [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) üst verilerini koruyun. Aşağıdaki bağımsız örnek, bir kaynak bölümünde ABD İngilizcesi ana dil ve Fransızca alternatif dil oluşturur ve metni ve tanımlayıcıları yeni bir sunumdaki bir bölüme kopyalar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Eğer kaynakta alternatif dil yoksa, null hedef değerini temizler.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alternatif dil olmadan bir kaynak denemek için `"fr-FR"` atamasını atlayın. Alternatif tanımlayıcı o zaman `null` olur ve aynı kopya ifadesi, hedefte daha önce bir alternatif dil atanmış olsa bile, eksikliği varsayılan bir değer eklemeden korur.

Bu tanımlayıcılar dil üst verisi olarak saklanır. Bunları korumak, PowerPoint’in hangi sözlüğü imla veya dil bilgisi denetimi için seçeceğini belirlemez.

## **Varsayılan Dili Ayarla**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) kullanarak, bir sunum yüklenirken veya oluşturulurken oluşturulan metin için varsayılan dili tanımlayın. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi ayarlayan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dilini `en-US` olarak yazdırır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Metin içeren yeni bir dikdörtgen şekil ekle.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // İlk bölümün dilini kontrol et.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Varsayılan Metin Stilini Ayarla**

Sunum düzeyinde varsayılan metin biçimlendirmesi uygulamak için [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için 14 puan kalın bir yazı tipini varsayılan olarak ayarlar ve “default_text_style.pptx” olarak kaydeder. Metin, daha spesifik biçimlendirme geçerli olmadıkça bu varsayılanları devralabilir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Üst seviyedeki paragraf formatını al.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Büyük Harf Etkisiyle Metin Çıkar**

PowerPoint’te **All Caps** yazı tipi etkisi uygulandığında, metin slaytta büyük harf olarak görünür; ancak orijinal metin küçük harf olarak girilmiş olabilir. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni girildiği gibi döndürür. Görünen metni eşleştirmek için [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda döndürülen dizgeyi büyük harfe çevirin.

Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren “sample2.pptx” dosyasını gerektirir. İlk paragrafın ilk bölümü “Hello, Aspose!” metnini **All Caps** efektiyle içerir; aşağıda gösterildiği gibidir.

![All Caps etkisi](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Çıktı:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki tablo içinde metni nasıl değiştiririm?**

Tablo içindeki metni değiştirmek için [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) kullanın. Hücreleri dolaşın ve her hücreyi [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) ve paragraf biçimlendirmesini [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat) aracılığıyla güncelleyin.

**PowerPoint slaytındaki metne nasıl bir degrade (gradient) renk uygularım?**

Metne degrade renk uygulamak için [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) kullanın. [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) değerini [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönü ve saydamlığı yapılandırın.