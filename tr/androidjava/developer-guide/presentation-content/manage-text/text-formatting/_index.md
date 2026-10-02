---
title: Android'de Sunum Metnini Biçimlendir
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/androidjava/text-formatting/
keywords:
- paragraf hizalama
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin döndürme
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi sabitleme
- metin sekleme
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'i Java üzerinden kullanarak PowerPoint ve OpenDocument sunumlarındaki metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Java üzerinden Aspose.Slides for Android kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, dönüş, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarlarını kapsar.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaytındaki ilk şekil bir metin kutusudur ve ilk paragraf aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılmış kalın biçimlendirme dahil olmak üzere etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Literal metin veya düzenli ifade eşleşmelerini bulmak ve vurgulamak için, [Metin Arama ve Değiştirme](/slides/tr/androidjava/search-and-replace-text/) adresine bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) kullanın veya bireysel metin bölümleri için [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerdeki açık vurgulama renkleri bu varsayılanın üzerine geçer:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın tamamı için vurgulama rengini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

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
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Metin bölümü için vurgulama rengini ayarla.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
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

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) kullanarak bir metin çerçevesindeki paragraf hizalamasını ayarlayın. Değer orta, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği, paragrafı **ortaya** hizalamanın yolunu gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın hizalamasını ortaya ayarla.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Satır İçinde Yazı Tipi Hizalama**

[IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) kullanarak bir satır içinde farklı yazı tipi boyutlarına sahip metin bölümlerini dikey olarak hizalayın. Bu ayar tüm paragrafı etkiler ve her satırın içindeki hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 punto olarak içerir ve farklı bir yazı tipi hizalaması vardır. Arial kullanır, otomatik sığdırma ve kaydırmayı devre dışı bırakır ve metin çerçevelerini tek satır için yeterli büyüklükte tutar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Karışık yazı tipi boyutlarıyla Alt Çizgi, Üst, Orta ve Alt hizalamanın karşılaştırması](font_alignment.png)

Yazı tipi hizalaması, yazı tipi ölçümlerini kullanır, bu nedenle tek tek harflerin görünür kenarları mutlaka tam olarak hizalanmayabilir. Örnek, alt çizgi ve alt hizalama arasındaki farkı göstermek için büyük bir harf ve bir alt karakter içerir. Yazı tipi bulunabilirliği ve ikamesi, kullanılan karakterler ve yazı tipi boyutlarındaki fark sonuçları etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da düzeni etkiler; modları karşılaştırırken aynı yazı tiplerini ve düzen ayarlarını kullanın.

Bu ayar, yatay paragraf hizalamasını kontrol eden [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve metin bloğunu şeklin içinde dikey konumlandıran [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) ayarlarından farklıdır. [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) aracılığıyla üst ve alt simge biçimlendirmesi, paragraf satırları için yazı tipi hizalaması ayarlamak yerine bireysel bölümleri temel çizgiye göre kaydırır.

## **Metin Şeffaflığını Ayarla**

Metin şeffaflığı, [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) aracılığıyla atanan rengin alfa bileşeni ile kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, %0‑255 ölçeğinde bir ARGB alfa kanalı değeridir, şeffaflık yüzdesi değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflık nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Metnin dolgu rengini şeffaf renk olarak ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümlerine** şeffaflık uygulamanın yolunu gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Boşluğunu Ayarla**

[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) kullanarak bir metin kutusundaki karakterler arasındaki boşluğu genişletebilir veya sıkıştırabilirsiniz. Örnekler 3 puan boşluk ekler; negatif değerler metni sıkıştırır.

Aşağıdaki Java kodu, **tüm paragrafta** karakter boşluğunu nasıl artıracağınızı gösterir:

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

![Paragraftaki karakter boşluğu](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümlerinde** karakter boşluğunu nasıl artıracağınızı gösterir:

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

![Metin bölümlerindeki karakter boşluğu](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırak**

Bazı durumlarda, Aspose.Slides tarafından render edilen metin, PowerPoint'te gösterilen aynı metinden biraz daha sık görünebilir. Bu, PowerPoint'in belirli yazı tipleri için kerning verisini görmezden gelmesi nedeniyle olabilir; hatta yazı tipi geçerli kerning bilgisine sahip olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda render edilen çıktıyı PowerPoint'e yakınlaştırmak için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) değerini gerçek yazı tipi boyutundan daha büyük bir değere ayarlayın. Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip "presentation.pptx" dosyasını gerektirir. Etkili yazı tipi adlarını (kalıtılan yazı tipleri dahil) kontrol eder ve Roboto kullanan bölümler için 100 puanlık bir eşik belirler. Bu, 100 puanın altında bir yazı tipi boyutuna sahip eşleşen bölümler için kerning'i devre dışı bırakır:

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

Eşiğin altındaki eşleşen metin için bu ayar kerning'i engeller ve bu PowerPoint’e özgü davranıştan etkilenen yazı tiplerinin Aspose.Slides render'ını PowerPoint'in görsel çıktısına yaklaştırmaya yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, paragraf seviyesinde [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) aracılığıyla veya bireysel bölümlerde [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 punto Times New Roman olarak, kalın, italik ve noktalı alt çizgi biçimlendirmesiyle ayarlar. Bireysel bölümlerdeki açık biçimlendirme bu varsayılanların üzerine geçer:

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

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 punto Times New Roman, italik biçimlendirme ve noktalı alt çizgi uygular:

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

## **Metin Döndürmesini Ayarla**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) kullanarak bir şekil içinde önceden tanımlı bir metin yönelimi ayarlayın.

Aşağıdaki kod örneği, şeklin içindeki metin yönelimini [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

## **Metin Çerçeveleri İçin Özel Döndürmeyi Ayarla**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) için özel bir döndürme açısı ayarlayın.

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

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) ve [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer, satır aralığını satır yüksekliğinin yüzdesi olarak belirtmek için kullanılır.
* Negatif bir değer, satır aralığını puan cinsinden belirtmek için kullanılır.

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

## **Satır Kesmesini Kontrol Et**

Paragraf satır kesme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metninin karıştığı sunumlarda faydalıdır. Aşağıdaki yöntemler [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/) içinde bulunur, bu yüzden tüm paragrafı etkiler:

* [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) Latin satır kesme kurallarını kontrol eder. Karışık metinde, değiştirilmesi komşu Doğu Asya metni ve noktalama işaretlerinin nerede kaydırılacağını da etkileyebilir.
* [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) Doğu Asya satır kesme kurallarını kontrol eder; bir satırın başındaki ve sonundaki karakterlere ait kısıtlamaları içerir.

Bu kurallar, bir metin çerçevesinde otomatik kaydırmayı etkinleştiren [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) işlevinin yerini almaz. Kaydırma gerçekleştiğinde düzeni etkiler; satır kesme karakteri eklemezler. Açık bir satır kesmesi, mevcut genişlikten bağımsız olarak paragrafta yeni bir satır oluşturur.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme seçeneğini de açıkça ayarlar ve "line_breaking.pptx" olarak kaydeder. Herhangi bir kuralı denemek için, diğer ayarları sabit tutarak ilgili değeri değiştirin. Örnek, 24 punto Arial ve SimSun kullanan, 160 punto çerçeve genişliği ve sıfır yatay metin çerçevesi kenar boşluğu olan bir yapı kullanır. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) ile çağrılır, böylece metin boyutu ve çerçeve boyutları sabit kalır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) uygun noktalama işaretlerinin sonraki satırı işgal etmesi yerine metin satırının sağ kenarının ötesine uzanmasına izin verir. Bu, tüm paragrafı etkiler ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 punto genişliğinde bir metin çerçevesinde asılı noktalama işaretlerini etkinleştirir ve "hanging_punctuation.pptx" olarak kaydeder. 24 punto Arial ve sıfır yatay metin çerçevesi kenar boşluğu ile, son nokta "sentence" kelimesinden sonra kalır ve sağ metin kenarının ötesine uzanır. Karşılaştırmak için özelliği [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) olarak ayarlayın; bu ayarlarla nokta ayrı bir satırda yer alır. Kaydırma etkin ve otomatik sığdırma devre dışı bırakılır, böylece mevcut genişlik sabit kalır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Her noktalama işareti asılı olamaz. Yukarıda açıklanan [yazı tipi ve düzen koşulları](#control-line-breaking) da bu karşılaştırmaya uygulanır: yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirmek görünür farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-), metin bir kapsayıcının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma durumunu veya şeklin otomatik olarak yeniden boyutlanıp boyutlanmayacağını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine sığacak şekilde yeniden boyutlandırır ve sonucu "autofit_type.pptx" olarak kaydeder.

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

Otomatik kaydırmadan sonra satırları saymak ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için, [Render Edilen Satırları Say](/slides/tr/androidjava/manage-paragraph/) adresine bakın. Sadece satır sayısı, metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), metnin bir şekil içinde dikey olarak nasıl konumlandırılacağını tanımlar; örneğin üst, orta veya alt. Aşağıdaki örnek, metni ilk şeklin alt kısmına sabitler ve sonucu "text_anchor.pptx" olarak kaydeder.

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

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) ve [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) kullanarak bir paragrafta sek duraklarını yapılandırın. Aşağıdaki örnek, varsayılan sek aralığını 100 puana ayarlar ve 30 puanda sola hizalı bir sek durak ekler. Bu ayarlar sek karakteri içeren metni etkiler.

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

Aspose.Slides, bir metin bölümü için denetleme dili ayarlamanıza olanak tanıyan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) sağlar. Denetleme dili, PowerPoint'te yazım ve dilbilgisi denetiminde kullanılan dili belirler.

Aşağıdaki örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip "presentation.pptx" dosyasını ve en az bir paragrafı gerektirir. İlk paragrafın içeriğini "1。" ile değiştirir, yazı tipini SimSun olarak ayarlar ve Basitleştirilmiş Çince denetleme dilini (`zh-CN`) atar. Sonucu "proofing_language.pptx" olarak kaydeder:

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

    // Denetleme dilinin Id'sini ayarla.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Varsayılan Dili Ayarla**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metin için varsayılan dili tanımlayın. Aşağıdaki örnek, varsayılan metin dili olarak Amerikan İngilizcesiyle bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümü için `en-US` değerini yazdırır.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Yeni bir dikdörtgen şekli ve metin ekle.
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

Sunum seviyesinde varsayılan metin biçimlendirmesini uygulamak için [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 punto kalın bir yazı tipi ayarlar ve "default_text_style.pptx" olarak kaydeder. Metin, daha spesifik bir biçimlendirme üzerine yazılmadığı sürece bu varsayılanları devralabilir.

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

## **Büyük Harf Efektiyle Metni Çıkar**

PowerPoint'te **All Caps** (Büyük Harf) yazı tipi etkisini uygulamak, metni slaytta büyük harf olarak gösterir, orijinal olarak küçük harf girilmiş olsa bile. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metinle eşleşmek için [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda dönen dizeyi büyük harfe dönüştürün.

Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusuna sahip "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü, aşağıda gösterildiği gibi All Caps etkisi uygulanmış "Hello, Aspose!" içerir.

![All Caps efekti](all_caps_effect.png)

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

**Bir slayttaki tablo içinde metni nasıl değiştiririm?**

Bir slayttaki tablo içinde metni değiştirmek için [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) kullanın. Hücreler üzerinde dolaşın ve her hücreyi [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) aracılığıyla güncelleyin; paragraf biçimlendirmesini ise [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) ile değiştirin.

**PowerPoint slaytındaki metne degrade (gradient) renk nasıl uygularım?**

Metne degrade renk uygulamak için [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) kullanın. [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) değerini [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.