---
title: Android'de Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/androidjava/manage-textbox/
keywords:
- metin kutusu
- metin çerçevesi
- metin ekle
- metin güncelle
- metin kutusu oluştur
- metin kutusunu denetle
- metin sütunu ekle
- bağlantı ekle
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında Aspose.Slides for Android via Java kullanarak metin kutularını oluşturun, tanımlayın, biçimlendirin ve güncelleyin."
---
## **Giriş**

Aspose.Slides for Android via Java'da slayt metni, şekillere ait metin çerçevelerinde depolanır. [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) arayüzü, en yaygın metin içeren şekli temsil eder ve metnini [IAutoShape.getTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) yöntemi aracılığıyla ortaya çıkarır.

{{% alert color="info" title="Note" %}}
Her otomatik şekil [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) uygular, ancak her şekil bir otomatik şekil değildir veya bir metin çerçevesini desteklemez. Mevcut bir sunumu işlerken, bir şeklin metnine erişmeden önce [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) uyguladığını kontrol edin.
{{% /alert %}}

## **Bir Slaytta Metin Kutusu Oluşturma**

Bir metin kutusu oluşturmak için, slayta bir otomatik şekil ekleyin, metnini metin çerçevesine ekleyin ve sunumu kaydedin. Aşağıdaki örnek dikdörtgen bir metin kutusu oluşturur:

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

[IShapeCollection.addAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-)‘a geçirilen koordinatlar ve boyutlar puan cinsindendir. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) sağlanan metinle metin çerçevesini başlatır.

## **Metin Kutusu Şekli Kontrolü**

[IAutoShape.isTextBox](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#isTextBox--) yöntemini kullanarak bir otomatik şeklin metin kutusu olarak kabul edilip edilmediğini belirleyin. Bu, bir sunumda hem metin içeren hem de yalnızca grafiksel otomatik şekiller bulunduğunda faydalıdır.

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

Yeni eklenen bir otomatik şekil, içinde boş olmayan metin bulunana kadar metin kutusu olarak kabul edilmez. Bu metni [IAutoShape.addTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) veya [ITextFrame.setText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) aracılığıyla sağlayabilirsiniz. Boş bir dize eklemek veya atamak, [IAutoShape.isTextBox](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#isTextBox--) `false` döndürmesine neden olur:

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

İlk iki çağrı `true` yazdırır; son iki çağrı `false` yazdırır.

## **Bir Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodu, hangi sunum nesnesinin içerdiğini bilmeden bir [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) alabilir. Sahip olduğu [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/)‘e geri dönmek için yalnızca okunabilir [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentShape--) yöntemini kullanın.

Otomatik şekil veya başka bir metin içeren şekle ait bir metin çerçevesi için, [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentShape--) sahibi döndürür ve [ITextFrame.getParentCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null` döndürür. Erişmeden önce döndürülen değeri kontrol edin. Şekil ve tablo hücresi sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de içerecek şekilde tanımlamak için [Search and Replace Text](/slides/tr/androidjava/search-and-replace-text/) sayfasına bakın.

## **Metin Kutusuna Sütunlar Ekleme**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) yöntemi metin çerçevesini sütunlara böler, [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) ise sütunlar arasındaki boşluğu puan cinsinden ayarlar. Her iki ayar da [ITextFrameFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/)‘a aittir ve mevcut bir metin kutusunun metin çerçevesi aracılığıyla değiştirilebilir. Metin aynı şekil içinde sütunlar arasında yeniden akar; başka bir şekle geçmez.

Aşağıdaki örnek, sütunlar arasında 10 puan boşluk olan üç sütunlu bir metin kutusu oluşturur, sunumu kaydeder ve çıkış dosyasından kaydedilen ayarları okur:

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

## **Bireysel Sütunlardan Metin Çıkarma**

Mevcut bir metin çerçevesinde her görsel sütuna atanan metni elde etmek için [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) kullanın. Metod, sütun tabanlı okuma sırasına göre her sütun için bir dize döndürür. Tek sütunlu bir metin çerçevesi tek elemanlı bir dizi üretir ve boş bir sütun boş bir dizeyle temsil edilir. Dizi yalnızca düz metin içerir; bölüm seviyesi biçimlendirme korunmaz.

Bu, aşağıdakilere ihtiyaç duyduğunuzda faydalıdır:
- Metni, sütun tabanlı okuma sırasını koruyarak çıkarın.
- Çok sütunlu slaytların içeriğini indeksleyin veya karşılaştırın.
- Her sütunu ayrı bir dosyaya, veritabanı alanına veya başka bir hedefe dışa aktarın.
- Sütun sayısını [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), boşluğu [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), yazı tipini veya metin çerçevesi boyutunu değiştirince metnin nasıl yeniden dağıtıldığını inceleyin.

Metod, geçerli [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) içinde dağıtılan metni rapor eder; ayrı şekiller veya metin kutuları arasında otomatik olarak akış yapmaz. Sütun dağılımı mevcut yazı tiplerine ve diğer metin düzeni ayarlarına bağlı olabilir, bu yüzden tutarlı sonuçların önemli olduğu durumlarda gereken yazı tiplerinin mevcut olduğundan emin olun.

Aşağıdaki örnek bir sunumu yükler, metin çerçevesi olan ilk çok sütunlu otomatik şekli bulur, yapılandırılmış sütun sayısını okur ve her sütundan metni ayrı bir dosyaya yazar. Metin çerçevesi sağlamayan şekiller atlanır.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

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
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
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

Bir sunum boyunca metni güncellemek için slaytlar ve şekiller üzerinden döngü yapın, otomatik şekilleri seçin ve ardından metin bölümlerini düzenleyin. Bölüm seviyesinde çalışmak, hem metni hem de karakter biçimlendirmesini değiştirmenizi sağlar.

Aşağıdaki örnek, otomatik şekil metnindeki her `years` geçişini `months` ile değiştirir ve etkilenen her bölümü kalın yapar:

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

Bu dolaşım yalnızca otomatik şekillerdeki metni günceller. Tablolar, çizelgeler, SmartArt veya gruplanmış şekillerde depolanan metin, o nesnelerin kendi koleksiyonları üzerinden dolaşım gerektirir.

## **Köprülü Metin Kutusu Ekleme**

Bir köprü, belirli bir metin bölümüne atanabilir; böylece yalnızca o metin tıklanabilir bağlantı olur. Bölümü harici bir URL ile ilişkilendirmek için [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) kullanın.

Aşağıdaki örnek bağlanmış metin oluşturur ve bir sunuma kaydeder:

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

**Bir ana slayt veya yerleşim slaydındaki metin kutusu ile metin tutucu arasındaki fark nedir?**

Bir [yer tutucu](/slides/tr/androidjava/manage-placeholder/), konum ve biçimlendirmesini bir [ana slayt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/masterslide/) veya [yerleşim slaytı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/layoutslide/) üzerinden devralabilir. Normal bir metin kutusu, oluşturulduğu slaytta bağımsız bir şekildir ve düzen değiştiğinde placeholder davranışı kazanmaz.

**Grafiklerde, tablolarda veya SmartArt'ta metni değiştirmeden metni nasıl değiştirebilirim?**

Dolaşımı, [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) uygulayan şekillerle sınırlayın; bu, Metni Güncelleme örneğinde gösterilmiştir. Çizelgeler, tablolar ve SmartArt metni kendi nesne modellerinde saklar, bu yüzden o döngü tarafından değiştirilmezler.