---
title: Java'da Sunum Metnini Biçimlendirme
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/java/text-formatting/
keywords:
- paragraf hizalama
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin döndürmesi
- dönme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçeve sabitlemesi
- metin sekmesi
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, PowerPoint ve OpenDocument sunumlarında metni Aspose.Slides for Java kullanarak nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sekme durakları ve dil ayarları gibi konuları kapsar.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaydındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil dizinleri sıfır tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılmış kalın biçimlendirme dahil olmak üzere etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Metin arama ve değiştirme hakkında bilgi almak için [Metin Arama ve Değiştirme](/slides/tr/java/search-and-replace-text/).

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) kullanın veya ayrı metin bölümleri için [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerdeki açık vurgulama renkleri bu varsayına göre önceliklidir:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın tamamı için vurgulama rengini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümlerinin** arka plan rengini nasıl ayarlayacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Metin bölümünün vurgulama rengini ayarla.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) kullanarak bir metin çerçevesi içinde paragraf hizalamasını ayarlayın. Değerler ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamanın yolunu gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın hizalamasını ortala.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Satır İçinde Yazı Tiplerini Hizala**

[IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) kullanarak bir satır içinde farklı yazı tipi boyutlarına sahip metin bölümlerini dikey olarak hizalayın. Bu ayar tüm paragrafı etkiler ve her satırındaki hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 punto boyutlarında ve farklı bir yazı tipi hizalamasıyla içerir. Arial kullanır, otomatik sığdırma ve satır kaydırmayı devre dışı bırakır ve metin çerçevelerini tek satır için yeterli büyüklükte tutar:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Alt Çizgi, Üst, Merkez ve Alt yazı tipi hizalanmasının karışık yazı tipi boyutlarıyla karşılaştırması](font_alignment.png)

Yazı tipi hizalaması yazı tipi ölçümlerini kullanır, bu yüzden tek tek harflerin görünen kenarları mutlaka tam olarak hizalanmaz. Örnek, alt çizgi ve alt hizalama arasındaki farkı göstermek için hem büyük harf hem bir alt karakter içerir. Yazı tipi bulunabilirliği ve ikameleri, kullanılan karakterler ve yazı tipi boyutları farkı sonucu etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da yerleşimi etkiler; modları karşılaştırırken aynı yazı tiplerini ve yerleşim ayarlarını kullanın.

Bu ayar, yatay paragraf hizalamasını kontrol eden [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), ve metin bloğunu şeklin içinde dikey olarak konumlandıran [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) ayarından farklıdır. [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) aracılığıyla üst simge ve alt simge biçimlendirmesi, bölümü temel çizgiye göre kaydırır; paragraf satırları için yazı tipi hizalaması ayarlamaz.

## **Metin Saydamlığını Ayarla**

Metin saydamlığı, [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) ile atanan rengin alfa bileşeni aracılığıyla kontrol edilir. Aşağıdaki örneklerde `alpha = 50` 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde olarak bir saydamlık değeri değildir.

Aşağıdaki kod örneği, **tüm paragraf** için saydamlık uygulamanın yolunu gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Metnin doldurma rengini şeffaf renge ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Saydam paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümlerinin** saydamlığını nasıl uygulayacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Metin bölümünün şeffaflığını ayarla.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Saydam metin bölümleri](transparent_text_portions.png)

## **Metin Karakter Aralığını Ayarla**

[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) kullanarak bir metin kutusunda karakterler arasındaki aralığı genişletebilir veya sıkıştırabilirsiniz. Örnekler 3 puan aralık ekler; negatif değerler metni sıkıştırır.

Aşağıdaki Java kodu, **tüm paragraf** içinde karakter aralığını nasıl genişleteceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karakter aralığını genişlet.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümlerinin** karakter aralığını nasıl genişleteceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
            portion.getPortionFormat().setSpacing(3); // Karakter aralığını genişlet.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırak**

Bazı durumlarda, Aspose.Slides tarafından oluşturulan metin PowerPoint'te görüntülenen aynı metinden biraz daha sıkı görünebilir. Bu, PowerPoint'in belirli yazı tipleri için kerning verisini görmezden gelmesiyle olabilir; yazı tipinde geçerli kerning bilgileri bulunup PowerPoint ayarlarında kerning etkin olsa bile.

Bu gibi durumlarda oluşturulan çıktıyı PowerPoint'e daha yakın hale getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) değerini gerçek yazı tipi boyutundan büyük bir değere ayarlayın. Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusu içeren "presentation.pptx" dosyasını gerektirir. Etkili yazı tipi adlarını, kalıtılmış yazı tipleri de dahil olmak üzere kontrol eder ve Roboto kullanan bölümler için 100 puan eşik değeri ayarlar. Bu, 100 puanın altındaki yazı tipi boyutuna sahip eşleşen bölümlerde kerning'i devre dışı bırakır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eşiğin altında kalan eşleşen metinler için bu ayar kerning'i önler ve PowerPoint'in bu yazı tipleri için gösterdiği görsel çıktıya daha yakın bir render elde etmenize yardımcı olur.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) aracılığıyla paragraf seviyesinde ya da [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) ile ayrı bölümlerde ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini kalın, italik ve noktalı altı çizili 12 puan Times New Roman olarak ayarlar. Bireysel bölümlerdeki açık biçimlendirme bu varsayılanların üzerine yazılır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragraf için yazı tipi özelliklerini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragrafın yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik biçimlendirme ve noktalı alt çizgi uygular:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Metin bölümü için yazı tipi özelliklerini ayarla.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin bölümlerinin yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Yüksekliği Normalizasyonunu Kontrol Et**

Şablon tipografisini yeniden oluştururken ya da karakter yüksekliği farklarını incelerken [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) kullanın. PowerPoint'te normalizasyonu etkinleştirmek, bireysel karakterleri dikey olarak uzatarak ya da sıkıştırarak metin bölümünde görünür yüksekliğin aynı olmasını sağlar. Bu, farklı yazı tiplerinde eşit metin yüksekliği garantisi vermez.

Özelliği açıkça etkinleştirmek ya da devre dışı bırakmak için değeri [NullableBool.True or False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) olarak ayarlayın. `NullableBool.NotDefined` yerel ayarı bırakmaz; bölüm örneğin paragrafın [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) değerini miras alır. Bu, `False` anlamına gelmez. Çözülmüş Boolean değerini elde etmek için [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) ve [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) kullanın.

Aşağıdaki bağımsız örnek **Arial** kurulu olmasını gerektirir. 54 puanda aynı büyük harf, küçük harf, alt karakter ve aksanlı karakterler içeren iki metin bloğu oluşturur. Her iki paragraf da varsayılan olarak normalizasyonu etkinleştirir. Üst bölüm bunu açıkça devre dışı bırakır; alt bölüm devredilir. Çerçeve boyutları, kenar boşlukları ve paragraf aralığı aynı, kaydırma ve otomatik sığdırma devre dışı bırakılmıştır. Örnek `False: false` ve `NotDefined: true` çıktısını verir ve "text_height_normalization.pptx" dosyasını kaydeder:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma kaydedilen sunumdan dışa aktarılmıştır. Üst satırda normalizasyon devre dışı (`False`); alt satırda devredilmiş ayar (`NotDefined` → `True`) miras alınır. Bu görünümü yeniden oluşturmak için Arial kurulu tutun.

![Arial 54-punto metin, üstte normalizasyon devre dışı ve altta kalıtılmış normalizasyon etkin](text_height_normalization.png)

Normalizasyon, atanmış [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) değerini değiştirmeden karakter yüksekliğini değiştirir; bu değer punto cinsinden yazı tipi boyutunu belirtir. Paragraf [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) satır aralığını kontrol eder, metin çerçevesi [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) ise metnin ya da kapsayıcısının nasıl yeniden boyutlandırılacağını belirler. Bu ayarlar farklı amaçlara hizmet eder ve genel yerleşimi bağımsız olarak etkileyebilir. Paragraf biçimlendirme ve miras hakkında daha fazla bilgi için [Paragrafı Yönet](/slides/tr/java/manage-paragraph/) bölümüne bakın.

## **Üstü Çizgiyi Uygula ve Kaldır**

Bir metin bölümünde, orijinal metni silmeden düzeltmeler, iptal edilen terimler veya önceki fiyatları göstermek için [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) kullanın. Metin üzerinden bir veya iki çizgi eklemek için değeri [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) olarak ayarlayın.

Üstü çizgiyi kaldırmak için [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None) gönderin. Bu, çevreleyen biçimlendirme üstü çizgi tanımlamış olsa bile etkiyi açıkça devre dışı bırakır. Buna karşılık, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) yerel ayarı tanımsız bırakır; bölüm örneğin paragraftan biçimlendirmeyi miras alabilir. Bu, üstü çizginin kaldırılacağını garanti etmez. Sonuçta oluşan biçimlendirmeyi, miras alınan değerler dahil, okumak için [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) kullanın.

Aşağıdaki bağımsız örnek üç fiyat karşılaştırması oluşturur. Her paragraf etiket, önceki fiyat ve geçerli fiyat için ayrı bölümler içerir; yalnızca önceki fiyat etkilenir. İlk satır üstü çizgiyi uygular ve ardından kaldırır; diğer satırlar tek ve çift üstü çizgiyi korur. Bu ayarın değiştirilmesi, metni ve kalın önceki fiyat gibi diğer biçimlendirmeleri korur.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // Üstü çizgiyi uygula, ardından ilk önceki fiyatın üstü çizgisini açıkça kaldır.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç (üstten alta): üstü çizgi yok, tek çizgi, çift çizgi.

![Üstü çizgisi olmayan önceki fiyatlar, tek çizgili ve çift çizgili](strikethrough.png)

## **Metin Döndürmesini Ayarla**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) kullanarak bir şekil içinde önceden tanımlanmış bir metin yönelimi ayarlayın.

Aşağıdaki kod örneği, şekildeki metin yönelimini [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin döndürmesi](text_rotation.png)

## **Dikey Metin içinde Rakamları Yan Yana Göster**

Dikey bir Japon etikette iki basamaklı bir sayıyı birlikte tutmak için her iki rakamı da tek bir metin bölümünde birleştirin ve o bölüme [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) uygulayın. Örnek, hem etiketler için [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) hem de 40 puan MS Gothic kullanır. Sayısal bölüme gönderilen [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) değeri yalnızca farklıdır:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint'te sol etiket (`True`) rakamları dik ve 和 ile 年 arasında yan yana gösterir. Sağ etiket (`False`) ise rakam çiftini saat yönünde 90 derece döndürür. Çevredeki Japon karakterleri her iki etikette de dik kalır.

![PowerPoint'te dikey tarih etiketlerinin sol tarafta dik duran rakamları ve sağ tarafta döndürülmüş rakamları karşılaştırması](vertical_date.png)

## **Metin Çerçeveleri için Özel Döndürme Ayarla**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) için özel bir dönme açısı ayarlayın.

Aşağıdaki kod örneği, şeklin içinde metin çerçevesini saat yönünde 3 derece döndürür:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) ve [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer, satır aralığını satır yüksekliğinin bir yüzdesi olarak belirtir.
* Negatif bir değer, satır aralığını puan cinsinden belirtir.

Aşağıdaki örnek, ilk paragraftaki boşluğu satır yüksekliğinin %200’ü (çift satır aralığı) olarak ayarlar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Satır Kesilmeyi Kontrol Et**

Dar metin blokları ve Latin ile Doğu Asya metninin karıştığı sunumlarda paragraf satır kesme kuralları faydalıdır. Aşağıdaki yöntemler [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) içindedir; bu nedenle tüm paragrafı etkiler:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) Latin satır kesme kurallarını kontrol eder. Karışık metinde değiştirilmesi, yan yana gelen Doğu Asya metni ve noktalama işaretlerinin nerede kaydırılacağını da değiştirebilir.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) Doğu Asya satır kesme kurallarını kontrol eder; satırın başındaki ve sonundaki karakterlere getirilen kısıtlamalar da dahildir.

Bu kurallar, metin çerçevesi içinde otomatik kaydırmayı etkinleştiren [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) işlevini değiştirmez. Kaydırma gerçekleştiğinde yerleşimi etkiler; satır sonu karakteri eklemez. Açık bir satır sonu, mevcut genişlikten bağımsız olarak paragrafta yeni bir satır zorlar.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme seçeneğini de açıkça ayarlar ve "line_breaking.pptx" dosyasını kaydeder. İstenen kuralı denemek için diğer ayarları sabit tutarken ilgili değeri değiştirin. Örnek 24 puan Arial ve SimSun, 160 puan çerçeve genişliği ve sıfır yatay metin çerçevesi kenar boşlukları kullanır. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) ile çağrılır; böylece metin boyutu ve çerçeve ölçüleri sabit kalır.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Asılı Noktalama İşaretlerini Kontrol Et**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) uygun noktalama işaretlerinin metin satırının sağ kenarının ötesine uzanmasına izin verir; bir sonraki satırı doldurmaz. Bu, tüm paragrafı etkiler ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde asılı noktalama işaretlerini etkinleştirir ve "hanging_punctuation.pptx" dosyasını kaydeder. 24 puan Arial ve sıfır yatay metin çerçevesi kenar boşluklarıyla, son nokta "sentence" kelimesinin ardından kalır ve sağ metin kenarının ötesine uzanır. Karşılaştırma için özelliği [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) olarak ayarlayın: bu ayarlarla nokta ayrı bir satır oluşturur. Kaydırma etkin, otomatik sığdırma devre dışı bırakılmıştır; böylece kullanılabilir genişlik sabit tutulur.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Her noktalama işareti asılı olamaz. Yukarıda açıklanan [yazı tipi ve yerleşim koşulları](#control-line-breaking) da bu karşılaştırmaya uygulanır: yazı tipi, kullanılabilir genişlik, kenar boşlukları ya da otomatik sığdırma ayarları değiştirilirse görülebilir fark ortadan kalkar.

## **Metin Çerçeveleri için Otomatik Sığdırma Türünü Ayarla**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bir metin konteynerinin sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma yapıp yapmayacağını ya da şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanın. Aşağıdaki örnek şekli metnine sığacak şekilde yeniden boyutlandırır ve sonucu "autofit_type.pptx" dosyasına kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otomatik kaydırma sonrası satır sayısını saymak ve metnin ya da şeklin genişliğinin sonucu nasıl değiştirdiğini görmek için [Render Edilen Satırları Say](/slides/tr/java/manage-paragraph/) bölümüne bakın. Satır sayısı yalnızca metnin konteynerini aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) bir metnin bir şekil içinde nasıl dikey konumlandırılacağını tanımlar; örneğin üst, orta veya alt. Aşağıdaki örnek metni ilk şeklin altına sabitler ve sonucu "text_anchor.pptx" dosyasına kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Metin Sekmelerini Ayarla**

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) ve [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) kullanarak bir paragrafta sekme durakları yapılandırılabilir. Aşağıdaki örnek varsayılan sekme aralığını 100 puan olarak ayarlar ve 30 puanda sola hizalı bir sekme durakları ekler. Bu ayarlar sekme karakteri içeren metinleri etkiler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraf sekmeleri](paragraph_tabs.png)

## **Denetleme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için denetleme dilini ayarlamanıza olanak tanıyan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) sağlar. Denetleme dili, PowerPoint'te yazım ve dilbilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki örnek, ilk slaydın ilk şekli olarak bir metin kutusu içeren ve en az bir paragraf bulunan "presentation.pptx" dosyasını gerektirir. İlk paragrafın içeriğini "1。" ile değiştirir, yazı tipini SimSun olarak ayarlar ve Basitleştirilmiş Çince denetleme dilini (`zh-CN`) atar. Sonuç "proofing_language.pptx" dosyasına kaydedilir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Denetleme dilinin kimliğini ayarla.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dil Metaverisini Kopyala**

Bir şablondan çok dilli metin kopyalarken hem [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) hem de [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) korunmalıdır. Aşağıdaki bağımsız örnek, dil olarak US English ve alternatif dil olarak French ayarlanmış bir kaynak bölüm oluşturur ve metni ve tanımlayıcıları yeni bir sunumdaki bir bölüme kopyalar:

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Eğer kaynakta alternatif bir dil yoksa, null hedef değerini temizler.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alternatif dil olmadan bir kaynak denemek için `"fr-FR"` atamasını atlayın. Alternatif tanımlayıcı o zaman `null` olur ve aynı kopya ifadesi, hedefte önceden bir alternatif dil atanmış olsa bile, eksikliğini bir varsayılan değer eklemeden korur.

Bu tanımlayıcılar dil meta verisi olarak saklanır. Bunları korumak, PowerPoint'in hangi sözlüğü yazım ya da dilbilgisi denetimi için seçeceğini belirlemez.

## **Varsayılan Dili Ayarla**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) kullanarak bir sunum yüklenirken ya da oluşturulurken oluşturulan metin için varsayılan dili tanımlayın. Aşağıdaki örnek, varsayılan metin dili olarak US English ayarlanan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dilini `en-US` olarak yazdırır:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Yeni bir dikdörtgen şekil ekleyip metin ayarla.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // İlk bölümün dilini kontrol et.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Varsayılan Metin Stilini Ayarla**

Sunum seviyesinde varsayılan metin biçimlendirmesi uygulamak için [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir yazı tipi ayarlar ve "default_text_style.pptx" dosyasına kaydeder. Metin, daha belirgin biçimlendirme tarafından üzerine yazılmadıkça bu varsayılanları miras alabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Üst seviye paragraf biçimini al.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **BÜYÜK HARF Efektiyle Metni Çıkar**

PowerPoint'te **All Caps** (BÜYÜK HARF) yazı tipi efekti uygulandığında, metin slaytta büyük harf olarak görünür, ancak aslen küçük harfle yazılmıştır. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metin ile eşleşmesi için [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda dönen dizeyi büyük harfe dönüştürün.

Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusu içeren "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü, **All Caps** etkisi uygulanmış "Hello, Aspose!" içerir; aşağıda gösterildiği gibidir.

![BÜYÜK HARF etkisi](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

**Bir slayttaki tablo içindeki metni nasıl değiştiririm?**

Bir slayttaki tablo içinde metni değiştirmek için [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) kullanın. Hücreler üzerinde döngü kurarak her hücreyi [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) aracılığıyla güncelleyin ve paragraf biçimlendirmesini [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) ile ayarlayın.

**PowerPoint slaytındaki metne nasıl bir degrade renk uygularım?**

Metne bir degrade renk uygulamak için [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) kullanın. [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) değerini [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.

İlgili özellik: [Slayt içinde metni biçimlendirme](/slides/tr/features/text-formatting/).