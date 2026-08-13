---
title: Android Sunumlarında Madde İşaretli ve Numaralı Listeleri Yönetme
linktitle: Listeleri Yönet
type: docs
weight: 60
url: /tr/androidjava/manage-lists/
keywords:
- madde işareti
- madde işaretli liste
- numaralı liste
- sembol madde işareti
- resim madde işareti
- özel madde işareti
- çok seviyeli liste
- madde işareti oluştur
- madde işareti ekle
- liste ekle
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listeleri nasıl oluşturup biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde işareti ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftır.

Paragraf düzeyindeki liste ayarlarına erişmek için [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) yöntemini kullanın. Ana giriş noktası [IParagraphFormat.getBullet](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), bu yöntem bir [IBulletFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/) nesnesi döndürür. Bu nesne ile madde işareti türünü, sembolü, resmi, rengi, boyutu, numaralandırma stilini ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale şunların nasıl yapılacağını gösterir:

- özel bir sembolle madde işaretli liste oluşturma
- resim madde işareti oluşturma
- paragraf derinliği ayarlanarak çok düzeyli liste oluşturma
- numaralı liste oluşturma
- mevcut bir sunumda liste biçimlendirmesini inceleme ve değiştirme

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için bir [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) içine paragraflar ekleyin ve [IBulletFormat.setType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) özelliğini [BulletType.Symbol](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/bullettype/) olarak ayarlayın. Ardından madde işaretinin görünümünü kontrol etmek için [IBulletFormat.setChar](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/#getColor--) ve [IBulletFormat.setHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) özelliklerini ayarlayabilirsiniz.

Aşağıdaki Java kodu bir slaytta madde işaretli liste nasıl oluşturulacağını gösterir:

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

Öğelerin sırası önemli olduğunda numaralı listeler kullanın. [IBulletFormat.setType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) özelliğini [BulletType.Numbered](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/bullettype/) olarak ayarlayın. Ayrıca [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) ile bir numaralandırma biçimi seçebilir veya listenin 1 dışındaki bir değerle başlamasını istiyorsanız [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) özelliğini kullanın.

Aşağıdaki Java kodu bir slaytta numaralı liste nasıl oluşturulacağını gösterir:

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

## **Resim Madde İşareti Oluşturma**

Aspose.Slides, normal bir madde işareti sembolünü bir görüntüyle değiştirmenize olanak tanır. Resim madde işaretleri, küçük boyutta okunabilirliğini koruyan basit görüntüler, örneğin simgeler veya küçük şeffaf PNG dosyaları ile en iyi şekilde çalışır.

{{% alert color="info" %}}
İdeal olarak, normal madde işareti sembolünü bir görüntüyle değiştirmeyi planlıyorsanız, şeffaf bir arka plana sahip basit bir grafik seçmeniz en iyisidir. Bu tür görüntüler, özel madde işareti sembolleri olarak iyi çalışır.

Görüntünün çok küçük bir boyuta ölçekleneceğini unutmayın. Bu nedenle, bir listede madde işareti olarak kullanıldığında net ve görsel olarak etkili kalacak bir görüntü seçmenizi şiddetle öneririz.
{{% /alert %}}

Resim madde işareti oluşturmak için bir görüntüyü [Presentation.getImages](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getImages--) ile ekleyin ve döndürülen [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesini [IBulletFormat.getPicture](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/#getPicture--) özelliğine atayın. Görüntüyü atamadan önce [IBulletFormat.setType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) özelliğini [BulletType.Picture](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/bullettype/) olarak ayarlayın.

Diyelim ki elimizde "image.png" adlı bir dosya var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki Java kodu bir slaytta resim madde işaretleri nasıl oluşturulacağını gösterir:

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

![Resim madde işaretleri](picture_bullets.png)

## **Çok Düzeyli Liste Oluşturma**

Liste öğelerini farklı seviyelere yerleştirmek için [IParagraphFormat.setDepth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) özelliğini kullanın. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe geçer ve bu şekilde devam eder.

Aşağıdaki Java kodu çok düzeyli bir liste nasıl oluşturulacağını gösterir:

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

![Çok düzeyli liste](multilevel_list.png)

## **Mevcut Bir Listeyi Değiştirme**

Mevcut bir sunumda liste biçimlendirmesini değiştirmek için hedef paragrafı alın ve [IParagraphFormat.getBullet](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) ayarlarını güncelleyin. PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için listeler oluştururken kullanılan aynı yöntemler kullanılabilir.

Aşağıdaki Java kodu bir metin çerçevesindeki ilk paragrafı numaralı liste stiline dönüştürür:

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

## **SSS**

### Madde işaretli ve numaralı listeler PDF veya görüntülere dışa aktarılabilir mi?

Evet. Aspose.Slides, hedef format ilgili metin düzeni ve madde işareti özelliklerini desteklediğinde liste biçimlendirmesini korur.

### Mevcut sunumlarda listeleri düzenleyebilir miyim?

Evet. Sunumu yükleyin, hedef paragrafı alın, [IParagraphFormat.getBullet](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) ayarlarını inceleyin veya güncelleyin ve ardından sunumu kaydedin.

### Listeler Latin olmayan metin içerebilir mi?

Evet. Liste öğesi metni Unicode karakterler içerebilir, bu sayede çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan yazı tiplerinin ihtiyacınız olan karakterleri desteklediğinden emin olun.