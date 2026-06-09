---
title: Java'da Sunumlarda Madde İşaretli ve Numaralı Listeleri Yönetme
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
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listeleri nasıl oluşturacağınızı ve biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Java, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde işareti ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftır.

Paragraf düzeyinde liste ayarlarına erişmek için [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/#getParagraphFormat--) metodunu kullanın. Ana giriş noktası, bir [IBulletFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/) nesnesi döndüren [IParagraphFormat.getBullet](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#getBullet--) metodudur. Bu nesneyle madde işareti türünü, sembolünü, resmini, rengini, boyutunu, numaralama stilini ve başlangıç sayısını ayarlayabilirsiniz.

Bu makale şunları gösterir:

- özel bir sembolle madde işaretli bir liste oluşturma
- resimli madde işareti oluşturma
- paragraf derinliğini ayarlayarak çok seviyeli bir liste oluşturma
- numaralı bir liste oluşturma
- var olan bir sunumda liste biçimlendirmesini inceleme ve değiştirme

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için bir [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) nesnesine [IParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/) nesneleri ekleyin ve [IBulletFormat.setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setType-byte-) metodunu [BulletType.Symbol](https://reference.aspose.com/slides/tr/java/com.aspose.slides/bullettype/#Symbol) olarak ayarlayın. Ardından [IBulletFormat.setChar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#getColor--) ve [IBulletFormat.setHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setHeight-float-) metodlarını kullanarak madde işareti görünümünü kontrol edebilirsiniz.

Aşağıdaki Java kodu bir slaytta madde işaretli bir liste oluşturmayı gösterir:

```java
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

Öğelerin sırası önemli olduğunda numaralı listeler kullanın. [IBulletFormat.setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setType-byte-) metodunu [BulletType.Numbered](https://reference.aspose.com/slides/tr/java/com.aspose.slides/bullettype/#Numbered) olarak ayarlayın. Ayrıca bir numaralandırma biçimi seçmek için [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) metodunu veya listenin 1 dışındaki bir değerden başlamasını istiyorsanız [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metodunu kullanabilirsiniz.

Aşağıdaki Java kodu bir slaytta numaralı bir liste oluşturmayı gösterir:

```java
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

Aspose.Slides, normal bir madde işareti sembolünü bir görüntüyle değiştirmenize olanak tanır. Resimli madde işaretleri, küçük boyutta okunabilirliği koruyan basit görüntüler, örneğin simgeler veya küçük şeffaf PNG dosyaları ile en iyi şekilde çalışır.

{{% alert color="primary" %}}
İdeal olarak, normal madde işareti sembolünü bir görüntüyle değiştirmeyi planlıyorsanız, şeffaf bir arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görüntüler, özel madde işareti sembolleri olarak iyi çalışır.

Resmin çok küçük bir boyuta ölçeklendirileceğini unutmayın. Bu nedenle, madde işaretinde kullanılacak bir görselin net ve görsel olarak etkili kalmasını öneririz.
{{% /alert %}}

Resimli bir madde işareti oluşturmak için bir görüntüyü [Presentation.getImages](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getImages--) metoduyla ekleyin ve döndürülen görüntü nesnesini [IBulletFormat.getPicture](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#getPicture--) metoduna atayın. Görüntüyü atamadan önce [IBulletFormat.setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setType-byte-) metodunu [BulletType.Picture](https://reference.aspose.com/slides/tr/java/com.aspose.slides/bullettype/#Picture) olarak ayarlayın.

Diyelim ki elimizde bir "image.png" var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki Java kodu bir slaytta resimli madde işaretleri oluşturmayı gösterir:

```java
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

Liste öğelerini farklı seviyelerde yerleştirmek için [IParagraphFormat.setDepth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setDepth-short-) metodunu kullanın. Seviye 0 en üst seviyedir, seviye 1 onun altında gömülüdür ve bu şekilde devam eder.

Aşağıdaki Java kodu çok seviyeli bir madde işaretli liste oluşturmayı gösterir:

```java
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

## **Mevcut Bir Listeyi Değiştirme**

Mevcut bir sunumda liste biçimlendirmesini değiştirmek için hedef paragrafı erişin ve [IParagraphFormat.getBullet](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#getBullet--) ayarlarını güncelleyin. Liste oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

Aşağıdaki Java kodu bir metin çerçevesindeki ilk paragrafı numaralı liste stiline dönüştürür:

```java
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

## **SSS**

**Madde işaretli ve numaralı listeler PDF ya da görüntülere dışa aktarılabilir mi?**

Evet. Aspose.Slides, hedef format ilgili metin yerleşimini ve madde işareti özelliklerini destekliyorsa liste biçimlendirmesini korur.

**Mevcut sunumlarda listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı erişin, [IParagraphFormat.getBullet](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#getBullet--) ayarlarını inceleyin veya güncelleyin ve sunumu kaydedin.

**Listeler Latin dışı metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir, bu sayede çok dilli sunumlarda listeler oluşturabilirsiniz. Kullanılan yazı tiplerinin ihtiyaç duyduğunuz karakterleri desteklediğinden emin olun.