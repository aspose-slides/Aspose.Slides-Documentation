---
title: Java’da Sunumlarda Madde İşaretli ve Numaralı Listeleri Yönetme
linktitle: Listeleri Yönet
type: docs
weight: 60
url: /tr/java/manage-lists/
keywords:
- madde işareti
- madde işaretli liste
- numaralı liste
- sembol madde işareti
- resimli madde işareti
- özel madde işareti
- çok seviyeli liste
- madde işareti oluştur
- madde işareti ekle
- liste ekle
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listeleri nasıl oluşturup biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Java, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde işareti ayarları paragraf formatı aracılığıyla kontrol edilen bir paragraftır.

Paragraf seviyesindeki liste ayarlarına erişmek için [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) yöntemini kullanın. Ana giriş noktası, bir [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) nesnesi döndüren [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) yöntemidir. Bu nesneyle madde işareti türünü, sembolünü, resmini, rengini, boyutunu, numaralandırma stilini ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale şunları gösterir:

- özel bir sembolle madde işaretli bir liste oluşturma
- resimli bir madde işareti oluşturma
- paragraf derinliğini ayarlayarak çok seviyeli bir liste oluşturma
- numaralı bir liste oluşturma
- varolan bir sunumdaki liste biçimini inceleme ve değiştirme
- paragraf metniyle birlikte gerçek liste işaretlerini ve numaralarını okuma

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için, bir [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) içine [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) nesneleri ekleyin ve [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) yöntemini [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Symbol) olarak ayarlayın. Ardından madde işaretinin görünümünü kontrol etmek için [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getColor--) ve [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) yöntemlerini kullanabilirsiniz.

Aşağıdaki Java kodu, bir slaytta madde işaretli bir liste oluşturmayı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Sembol madde işaretleri](symbol_bullets.png)

## **Numaralı Liste Oluşturma**

Ögelerin sırası önemli olduğunda numaralı listeler kullanın. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) yöntemini [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Numbered) olarak ayarlayın. Ayrıca bir numaralandırma biçimini [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) ile seçebilir veya listenin 1 dışında bir değerden başlaması gerektiğinde [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) ayarlayabilirsiniz.

Aşağıdaki Java kodu, bir slaytta numaralı bir liste oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Numaralı madde işaretleri](numbered_bullets.png)

## **Resimli Madde İşareti Oluşturma**

Aspose.Slides, normal bir madde işareti simgesini bir görüntüyle değiştirmenize olanak tanır. Resimli madde işaretleri, küçük boyutta okunaklı kalan basit görüntülerle, örneğin simgeler veya küçük şeffaf PNG dosyalarıyla en iyi şekilde çalışır.

{{% alert color="info" title="Note" %}}
İdeal olarak, normal madde işareti simgesini bir görüntüyle değiştirmeyi planlıyorsanız, şeffaf arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görüntüler, özel madde işareti sembolleri olarak iyi çalışır.
{{% /alert %}}

Resimli bir madde işareti oluşturmak için, bir görüntüyü [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) metoduna ekleyin ve dönen görüntü nesnesini [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) metoduna atayın. Görüntüyü atamadan önce [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) yöntemini [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Picture) olarak ayarlayın.

Diyelim ki elimizde bir "image.png" var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki Java kodu, bir slaytta resimli madde işaretleri oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Resimli madde işaretleri](picture_bullets.png)

## **Çok Seviyeli Liste Oluşturma**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) yöntemini kullanarak liste öğelerini farklı seviyelere yerleştirin. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe bir seviyedir ve bu şekilde devam eder.

Aşağıdaki Java kodu, çok seviyeli bir madde işaretli liste oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Çok seviyeli liste](multilevel_list.png)

## **Varolan Bir Listeyi Değiştirme**

Varolan bir sunumda liste biçimini değiştirmek için, hedef paragrafı erişin ve [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) ayarlarını güncelleyin. Listeleri oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gerçek Madde İşareti Değerlerini Okuma**

Sunum içeriğini çıkartırken, liste işaretlerini paragraf metniyle birlikte tutun. Etkili madde işareti biçimini elde etmek için [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--) metodunu çağırın ve [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) metoduna erişin. [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) metodunu okurmadan önce [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) metodunu kontrol edin.

Numaralı listeler için bu üç değeri ayırın:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) formatı belirler; örneğin bir nokta ile biten Arap rakamları veya bir nokta ile biten küçük harfli harfler.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) numaralı paragraflar grubunun başlangıç numarasını belirtir.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) belirli bir paragraf için biçimlendirilmiş işareti döndürür. Örneğin, 5'ten başlayan bir listede ikinci öğe `6.` döndürür.

Her paragrafta [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDepth--) değerini koruyarak iç içeleme seviyesini tutun. Gerçek işaret tam hiyerarşiyi kodlamaz: iç içe bir öğe `c.` döndürebilir, `6.c.` gibi birleşik bir etiket yerine.

Aşağıdaki bağımsız örnek, listeler oluşturur, bir sunuma kaydeder ve sunuyu yeniden yükleyerek her paragrafın metnini, derinliğini, madde işareti türünü ve gerçek değerini rapor eder. Küçük mavi resim işareti, satır içi SVG'den oluşturulur.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Harici bir görüntü dosyası olmadan bir resim işareti oluştur.
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

Kaynak listeler aşağıda gösterilmiştir.

![5'ten başlayan listeler, iç içe harf ve Roma rakamı öğeleri, bir sembol işareti, madde işareti olmayan bir paragraf ve mavi resim işareti](actual_bullet_values.png)

Rapor, PowerPoint'te gösterilen işaretlerle eşleşir:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

[BulletType.None ve BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) durumunda, [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) `null` döndürür, boş bir dize değil. Bu türleri ayrı ayrı ele alın: ilki işaret içermez, ikincisi madde işareti resmini ayrı olarak çıkartmayı gerektirir. Bir resimli madde işareti yalnızca bir metin işareti çıkartılarak yeniden oluşturulamaz.

## **SSS**

**Madde işaretli ve numaralı listeler PDF veya görüntülere dışa aktarılabilir mi?**

Evet. Aspose.Slides, hedef format ilgili metin düzeni ve madde işareti özelliklerini desteklediğinde liste biçimlendirmesini korur.

**Varolan sunumlarda listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı erişin, [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) ayarlarını inceleyin veya güncelleyin ve sunumu kaydedin.

**Listeler, Latin olmayan metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir, bu sayede çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan fontların ihtiyacınız olan karakterleri desteklediğinden emin olun.