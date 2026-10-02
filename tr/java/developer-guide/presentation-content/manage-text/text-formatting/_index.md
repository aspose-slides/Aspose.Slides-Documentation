---
title: Java'da Sunum Metnini Biçimlendir
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
- metin döndürme
- dönüş açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi sabitlemesi
- metin sekleme
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stillendirin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, dönüşüm, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarlarını kapsar.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaytındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır temellidir. Kalın bölümleri seçen örnekler, kalıtılan kalın biçimlendirme dahil olmak üzere etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Metin ara ve değiştir [Search and Replace Text](/slides/tr/java/search-and-replace-text/).

## **Metin Arka Plan Rengini Ayarla**

Bir paragrafın varsayılan vurgulama rengini ayarlamak için [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) kullanın veya bireysel metin bölümleri için [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerdeki açık vurgulama renkleri bu varsayılanın üzerine yazılır:

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağınızı gösterir:

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

Bir metin çerçevesi içinde paragraf hizalamasını ayarlamak için [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) kullanın. Değer merkezlenmiş, sola hizalı, sağa hizalı, iki yana yaslı vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamanın yolunu gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın hizalamasını merkeze ayarla.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Satır İçindeki Yazı Tiplerini Hizala**

Bir satır içinde farklı yazı tipi boyutlarına sahip metin bölümlerini düşey olarak hizalamak için [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) kullanın. Bu ayar tüm paragraf için geçerlidir ve satırlarının içinde hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, tek bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 punto olarak, farklı yazı tipi hizalamasıyla içerir. Arial kullanır, otomatik sığdırma ve kaydırmayı devre dışı bırakır ve metin çerçevelerini tek satır için yeterli büyüklükte tutar.

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

![Alt Çizgi, Üst, Orta ve Alt yazı tipi hizalama karşılaştırması](font_alignment.png)

Yazı tipi hizalaması yazı tipi metriklerini kullanır, bu nedenle bireysel harflerin görünen kenarları mutlaka tam olarak hizalanmaz. Örnek, bir büyük harf ve bir alt çizgi karakteri içerir ve temel çizgi ile alt hizalama arasındaki farkı göstermeye yardımcı olur. Yazı tipi bulunurluğu ve ikame edilmesi, kullanılan karakterler ve yazı tipi boyutları arasındaki fark sonucu etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da düzeni etkiler; modları karşılaştırırken aynı yazı tiplerini ve düzen ayarlarını kullanın.

Bu ayar, yatay paragraf hizalamasını kontrol eden [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), ve şekil içinde metin bloğunu düşey olarak konumlandıran [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) ayarlarından farklıdır. [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) aracılığıyla üst simge ve alt simge biçimlendirmesi, paragraf satırlarının yazı tipi hizalamasını ayarlamak yerine bireysel bölümleri temel çizgiye göre kaydırır.

## **Metin Şeffaflığını Ayarla**

Metin şeffaflığı, [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) aracılığıyla atanan rengin alfa bileşeniyle kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, yüzde 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, şeffaflık yüzdesi değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflığın nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Metnin doldurma rengini şeffaf renk olarak ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için şeffaflığın nasıl uygulanacağını gösterir:

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

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin Karakter Aralığını Ayarla**

Metin kutusundaki karakterler arasındaki boşluğu genişletmek veya sıkıştırmak için [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) kullanın. Örnekler 3 puan ekler; negatif değerler metni sıkıştırır.

Aşağıdaki Java kodu, **tüm paragrafta** karakter aralığını nasıl artıracağınızı gösterir:

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümlerinde** karakter aralığını nasıl artıracağınızı gösterir:

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

Bazı durumlarda, Aspose.Slides tarafından işlenen metin, aynı metnin PowerPoint'te gösterilmesinden biraz daha sıkı görünebilir. Bu, PowerPoint'in bazı yazı tipleri için kerning verilerini göz ardı etmesi nedeniyle olabilir; hatta yazı tipi geçerli kerning bilgisine sahip ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda, çıktıyı PowerPoint'e daha yakın hâle getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) değerini gerçek yazı tipi boyutundan büyük bir değere ayarlayın. Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip "presentation.pptx" dosyasını gerektirir. Etkili yazı tipi adlarını, kalıtılan yazı tipleri dahil, kontrol eder ve Roboto kullanan bölümler için 100 puan eşik değerini ayarlar. Bu, 100 puandan küçük yazı tipi boyutuna sahip eşleşen bölümler için kerning'i devre dışı bırakır:

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

Eşiğin altındaki eşleşen metin için bu ayar kerning'i önler ve Aspose.Slides'in, bu PowerPoint'e özgü davranıştan etkilenen yazı tipleri için görsel çıktısını PowerPoint ile hizalamaya yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, paragraf düzeyinde [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ile veya bireysel bölümlerde [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman olarak kalın, italik ve noktalı alt çizgi biçimlendirmesiyle ayarlar. Bireysel bölümlerdeki açık biçimlendirme bu varsayılanların üzerine yazar.

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

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

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

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Dönüşünü Ayarla**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) kullanarak bir şekil içinde önceden tanımlı bir metin yönü ayarlayın.

Aşağıdaki kod örneği, şekildeki metin yönünü [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

![Metin dönmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Dönüşüm Ayarla**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) için özel bir dönüş açısı ayarlayın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

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

![Özel metin dönüşümü](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) ve [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) sağlar. Bu özellikler aşağıdaki gibi kullanılır:

* Pozitif bir değer kullanarak satır aralığını satır yüksekliğinin yüzdesi olarak belirtin.
* Negatif bir değer kullanarak satır aralığını puan cinsinden belirtin.

Aşağıdaki örnek, ilk paragraftaki aralığı satır yüksekliğinin %200'üne (çift satır aralığı) ayarlar:

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

## **Satır Kesilmesini Kontrol Et**

Paragraf satır kesme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metnini karıştıran sunumlarda yararlıdır. Aşağıdaki yöntemler [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) aittir, bu nedenle tüm paragraf için geçerlidir:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) Latin satır kesme kurallarını kontrol eder. Karışık metinde, değiştirmek komşu Doğu Asya metni ve noktalama işaretlerinin nerede kaydırılacağını da etkileyebilir.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) Doğu Asya satır kesme kurallarını kontrol eder; bir satırın başındaki ve sonundaki karakterlere ilişkin kısıtlamaları içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik kaydırmayı etkinleştiren [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) yerine geçmez. Kaydırma gerçekleştiğinde yerleşimi etkiler; satır sonu karakteri eklemezler. Açık bir satır sonu, mevcut genişlikten bağımsız olarak paragrafta yeni bir satır oluşturur.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme seçeneğini açıkça ayarlar ve "line_breaking.pptx" olarak kaydeder. Herhangi bir kuralı denemek için, diğer ayarları sabit tutarak ilgili değeri değiştirin. Örnek, 24 puan Arial ve SimSun kullanır, çerçeve genişliği 160 puan ve yatay metin çerçevesi kenar boşlukları sıfırdır. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) metin boyutu ve çerçeve boyutları sabit kalması için [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) ile çağrılır.

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

## **Askı Noktalama İşaretlerini Kontrol Et**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) uygun noktalama işaretlerinin bir sonraki satırı işgal etmesi yerine metin satırının sağ kenarının ötesine uzanmasına izin verir. Tüm paragraf için geçerlidir ve askı girintisinden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde askı noktalama işaretlerini etkinleştirir ve "hanging_punctuation.pptx" olarak kaydeder. 24 puan Arial ve yatay metin çerçevesi kenar boşlukları sıfır iken, son nokta "sentence" kelimesinden sonra kalır ve sağ metin kenarının ötesine uzanır. Karşılaştırmak için özelliği [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) olarak ayarlayın: bu ayarlarla nokta ayrı bir satır alır. Kaydırma etkinleştirilir ve otomatik sığdırma devre dışı bırakılır, böylece kullanılabilir genişlik sabit kalır.

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

Her noktalama işareti askı yapamaz. Yukarıda açıklanan [yazı tipi ve yerleşim koşulları](#control-line-breaking) da bu karşılaştırmaya uygulanır: yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirmek görünür farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) metin kapsayıcının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceği, taşma yapıp yapmayacağı veya şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine uyması için yeniden boyutlandırır ve sonucu "autofit_type.pptx" olarak kaydeder.

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

Otomatik kaydırma sonrası satırları saymak ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için [Count Rendered Lines](/slides/tr/java/manage-paragraph/) bölümüne bakın. Satır sayısı yalnızca metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) metnin bir şekil içinde dikey olarak nasıl konumlandırılacağını tanımlar; örneğin üst, orta veya alt. Aşağıdaki örnek, metni ilk şeklin altına sabitler ve sonucu "text_anchor.pptx" olarak kaydeder.

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

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) ve [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) kullanarak bir paragraftaki sek duraklarını yapılandırın. Aşağıdaki örnek, varsayılan sek aralığını 100 puana ayarlar ve 30 puanda sola hizalı bir sek durak ekler. Bu ayarlar sek karakteri içeren metni etkiler.

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

## **Denetim Dilini Ayarla**

Aspose.Slides, bir metin bölümü için denetim dilini ayarlamanızı sağlayan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) sunar. Denetim dili, PowerPoint'te imla ve dilbilgisi denetiminde kullanılan dili belirler.

Aşağıdaki örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip "presentation.pptx" dosyasını ve en az bir paragrafı gerektirir. İlk paragrafın içeriğini "1。" ile değiştirir, yazı tipini SimSun olarak ayarlar ve Basitleştirilmiş Çince denetim dilini (`zh-CN`) atar. Sonucu "proofing_language.pptx" olarak kaydeder:

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

    // Denetim dilinin Id'sini ayarla.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Varsayılan Dili Ayarla**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metin için varsayılan dili tanımlayın. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi kullanan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dilini `en-US` olarak yazdırır.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Yeni bir dikdörtgen şekil ekle ve metin ekle.
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

Sunum seviyesinde varsayılan metin biçimlendirmesini uygulamak için [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir yazı tipi ayarlar ve "default_text_style.pptx" olarak kaydeder. Metin, daha spesifik bir biçimlendirme üzerine yazılmadıkça bu varsayılanları miras alabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Üst düzey paragraf formatını al.
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

## **All-Caps Efektiyle Metni Çıkar**

PowerPoint’te **All Caps** yazı tipi efekti uygulandığında, metin küçük harfle girilmiş olsa bile slaytta büyük harf olarak görünür. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metinle eşleşmek için [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda dönen dizeyi büyük harfe çevirin.

Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü, aşağıda gösterildiği gibi All Caps etkisi uygulanmış "Hello, Aspose!" içerir.

![All Caps etkisi](all_caps_effect.png)

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

**Bir slayttaki tabloda metni nasıl değiştiririm?**

Bir slayttaki tablodaki metni değiştirmek için [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) kullanın. Hücreler üzerinde döngü yapın ve her hücreyi [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) aracılığıyla güncelleyin; paragraf biçimlendirmesini ise [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) ile yapın.

**PowerPoint slaytındaki metne degrade (gradient) renk nasıl uygulanır?**

Metne degrade renk uygulamak için [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) kullanın. [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) değerini [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.