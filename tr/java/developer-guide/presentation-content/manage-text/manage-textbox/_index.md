---
title: Java Kullanarak Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/java/manage-textbox/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarındaki metin kutularını oluşturun, tanımlayın, biçimlendirin ve güncelleyin."
---
## **Giriş**

Aspose.Slides for Java'da slayt metni, şekillere ait metin çerçevelerinde saklanır. [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) arabirimi, en yaygın metin taşıyan şekli temsil eder ve metnini [IAutoShape.getTextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#getTextFrame--) yöntemiyle ortaya çıkar.

{{% alert color="info" title="Not" %}}

Her otomatik şekil [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) arabirimini uygular, ancak her şekil bir otomatik şekil değildir ve bir metin çerçevesi desteklemez. Mevcut bir sunumu işlerken, metne erişmeden önce şeklin [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) uyguladığını kontrol edin.

{{% /alert %}}

## **Bir Slaytta Metin Kutusu Oluşturma**

Bir metin kutusu oluşturmak için bir slayta otomatik şekil ekleyin, metni metin çerçevesine ekleyin ve sunumu kaydedin. Aşağıdaki örnek dikdörtgen bir metin kutusu oluşturur:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[IShapeCollection.addAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) yöntemine geçirilen koordinatlar ve boyutlar puan cinsindendir. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metin çerçevesini verilen metinle başlatır.

## **Metin Kutusu Şekli Kontrolü**

[IAutoShape.isTextBox](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#isTextBox--) yöntemini kullanarak bir otomatik şeklin metin kutusu olarak kabul edilip edilmediğini belirleyin. Bu, bir sunumda hem metin taşıyan hem de yalnızca grafiksel otomatik şekiller bulunduğunda faydalıdır.

![Bir metin kutusu ve bir şekil](istextbox.png)

Aşağıdaki örnek bir sunumdaki her otomatik şekli inceler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Yeni eklenen bir otomatik şekil, içinde boş olmayan bir metin olduğunda metin kutusu olarak kabul edilir. Bu metni [IAutoShape.addTextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) veya [ITextFrame.setText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#setText-java.lang.String-) aracılığıyla sağlayabilirsiniz. Boş bir dize eklemek veya atamak, [IAutoShape.isTextBox](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#isTextBox--) yönteminin `false` döndürmesine neden olur:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

İlk iki çağrı `true`; sonraki iki çağrı `false` yazdırır.

## **Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodu, hangi sunum nesnesinin içerdiğini bilmeden bir [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) alabilir. Sahibi olan [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) nesnesine geri gitmek için yalnızca‑okunur [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getParentShape--) yöntemini kullanın.

Bir otomatik şekil veya başka bir metin‑taşıyan şekil tarafından sahip olunan bir metin çerçevesi için, [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getParentShape--) sahibi döndürür ve [ITextFrame.getParentCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getParentCell--) `null` döndürür. Erişmeden önce döndürülen değeri kontrol edin. Şekil ve tablo‑hücre sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de içerecek şekilde tanımlamak için [Metin Arama ve Değiştirme](/slides/tr/java/search-and-replace-text/) bölümüne bakın.

## **Metin Kutusuna Sütun Ekleme**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) yöntemi, metin çerçevesini sütunlara böler, [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) ise sütunlar arasındaki boşluğu puan cinsinden ayarlar. Her iki ayar da [ITextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/) kapsamında bulunur ve mevcut bir metin kutusunun metin çerçevesi üzerinden değiştirilebilir. Metin aynı şekil içinde sütunlar arasında akışır; başka bir şekle devam etmez.

Aşağıdaki örnek, sütunlar arasında 10 puan boşluk bulunan üç sütunlu bir metin kutusu oluşturur, sunumu kaydeder ve kaydedilen ayarları çıkış dosyasından geri okur:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Tek Tek Sütunlardan Metin Çıkarma**

Mevcut bir metin çerçevesinde her görsel sütuna atanan metni almak için [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#splitTextByColumns--) yöntemini kullanın. Yöntem, sütun‑bazlı okuma sırasına göre her sütun için bir dize döndürür. Tek sütunlu bir metin çerçevesi bir elemanlı bir dizi üretir; boş bir sütun boş dizeyle temsil edilir. Dize sadece düz metin içerir; bölüm‑seviyesi biçimlendirme korunmaz.

Bu yöntem aşağıdaki durumlarda yararlıdır:

- Metni sütun‑bazlı okuma sırasını koruyarak çıkarmak.
- Çok‑sütunlu slaytların içeriğini indekslemek veya karşılaştırmak.
- Her sütunu ayrı bir dosyaya, veri tabanı alanına veya başka bir hedefe aktarmak.
- [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), yazı tipi veya metin‑çerçevesi boyutu değiştirildiğinde metnin nasıl yeniden dağıtıldığını incelemek.

Yöntem, mevcut [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) içinde dağıtılan metni raporlar; ayrı şekiller veya metin kutuları arasında otomatik akış sağlamaz. Sütun dağılımı mevcut yazı tiplerine ve diğer metin‑düzeni ayarlarına bağlıdır; tutarlı sonuçların önemli olduğu durumlarda gerekli yazı tiplerinin mevcut olduğundan emin olun.

Aşağıdaki örnek bir sunumu yükler, metin çerçevesi olan ilk çok‑sütunlu otomatik şekli bulur, yapılandırılmış sütun sayısını okur ve her sütunun metnini ayrı bir dosyaya yazar. Metin çerçevesi sağlamayan şekiller atlanır.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Metni Güncelleme**

Bir sunumda metni güncellemek için slaytları ve şekilleri döngüyle gezerek otomatik şekilleri seçin ve ardından metin bölümlerini düzenleyin. Bölüm seviyesinde çalışmak, hem metni hem de karakter biçimlendirmesini değiştirmenizi sağlar.

Aşağıdaki örnek, otomatik‑şekil metnindeki her `years` ifadesini `months` ile değiştirir ve etkilenen her bölümü kalın yapar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu gezinme yalnızca otomatik şekillerdeki metni günceller. Tablolarda, grafiklerde, SmartArt'ta veya gruplanmış şekillerde saklanan metin, bu nesnelerin kendi koleksiyonları üzerinden gezilerek güncellenmelidir.

## **Hipermetinli Metin Kutusu Ekleme**

Bir hipermetin belirli bir metin bölümüne atanabilir; böylece yalnızca o metin tıklanabilir bağlantı olur. Bölümü harici bir URL ile ilişkilendirmek için [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) yöntemini kullanın.

Aşağıdaki örnek bağlantılı metin oluşturur ve bir sunuma kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir ana slayt veya düzen slaytında bir metin kutusu ile bir metin yer tutucu arasındaki fark nedir?**

Bir [placeholder](/slides/tr/java/manage-placeholder/) konumunu ve biçimini bir [master slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/masterslide/) veya [layout slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/layoutslide/) üzerinden devralabilir. Normal bir metin kutusu, oluşturulduğu slaytta bağımsız bir şekildir ve düzen değiştiğinde yer tutucu davranışı kazanmaz.

**Grafik, tablo veya SmartArt'taki metni değiştirmeden metni nasıl değiştirebilirim?**

Metni yalnızca [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) uygulayan şekilleri gezerek güncelleyin; bu, Metni Güncelleme örneğinde gösterildiği gibi yapılır. Grafikler, tablolar ve SmartArt, metni kendi nesne modellerinde sakladığından bu döngüyle değiştirilmezler.