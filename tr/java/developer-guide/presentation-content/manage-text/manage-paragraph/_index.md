---
title: Java'da PowerPoint Metin Paragraflarını Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/java/manage-paragraph/
aliases:
  - /java/paragraf/
  - /java/bölüm/
keywords:
- metin ekle
- paragraf ekle
- metni yönet
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- sarkıtılmış girinti
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML'ye
- paragrafı HTML'ye
- paragrafı görüntüye
- metni görüntüye
- paragrafı dışa aktar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntüleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Java, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) şekil içindeki metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [IParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf‑seviyesindeki biçimlendirmeye erişim sağlar.
* [IPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/) bir paragraftaki metin akışını temsil eder. Her bölüm kendi metnine ve karakter‑seviyesindeki biçimlendirmeye sahip olabilir.

Bu nedenle bir paragraf, birden çok bölüm kullanarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içeren metin içerebilir.

## **Paragraflar Oluşturma ve Biçimlendirme**

### **Birden Çok Bölüm İçeren Paragraflar Oluşturma**

Aşağıdaki adımlar, her biri üç bölüm içeren üç paragrafla bir metin çerçevesi oluşturur:

1. Presentation sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks üzerinden erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) öğesine erişin.
5. Varsayılan paragrafı kullanın ve metin çerçevesine iki tane daha [IParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/) nesnesi ekleyin.
6. Her paragrafın üç bölüm içermesi için yeterli sayıda [IPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/) nesnesi ekleyin. Varsayılan paragraf zaten bir boş bölüm içerir.
7. Her bölümün metnini ayarlayın.
8. Karakter seviyesindeki biçimlendirmeyi [IPortion.getPortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#getPortionFormat--) aracılığıyla uygulayın.
9. Değiştirilmiş sunumu kaydedin.

Bu Java örneği adımları uygular:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Madde İşaretli ve Numaralı Listeler Oluşturma**

### **Madde İşaretli veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralar, ilgili öğelerin taranmasını kolaylaştırır. Aspose.Slides’te liste ayarları [IBulletFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/) aracılığıyla tanımlanır.

1. Presentation sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks üzerinden erişin.
3. Seçili slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) öğesine erişin.
5. Varsayılan paragrafı metin çerçevesinden kaldırın.
6. Sembol madde işareti için bir [Paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraph/) oluşturun.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setType-int-) metodunu [BulletType.Symbol](https://reference.aspose.com/slides/tr/java/com.aspose.slides/bullettype/) olarak ayarlayın ve madde işareti karakterini belirtin.
8. Paragraf metnini, girintiyi, madde işareti rengini ve yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. İkinci paragrafı oluşturun ve [IBulletFormat.setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setType-int-) metodunu [BulletType.Numbered](https://reference.aspose.com/slides/tr/java/com.aspose.slides/bullettype/) olarak ayarlayın.
11. Numaralı madde işareti stilini yapılandırın ve paragrafı metin çerçevesine ekleyin.
12. Sunumu kaydedin.

Bu Java örneği bir sembol madde işareti ve bir numaralı madde işareti oluşturur:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Resim Madde İşaretleri Kullanma**

Resim madde işaretleri, bir sembol veya sayı yerine özel bir görüntü kullanmanıza olanak tanır.

1. Presentation sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks üzerinden erişin.
3. Bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin ve onun [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) öğesine erişin.
4. Varsayılan paragrafı metin çerçevesinden kaldırın.
5. Madde işareti görüntüsünü yükleyin ve sunumun görüntü koleksiyonuna bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) olarak ekleyin.
6. Bir [Paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraph/) oluşturun ve metnini ayarlayın.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setType-int-) metodunu [BulletType.Picture](https://reference.aspose.com/slides/tr/java/com.aspose.slides/bullettype/) olarak ayarlayın.
8. Görüntüyü [IBulletFormat.getPicture](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#getPicture--) aracılığıyla atayın ve madde işareti yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. Değiştirilmiş sunumu kaydedin.

Bu Java örneği bir resim madde işareti oluşturur:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Çok Düzeyli Liste Oluşturma**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setDepth-short-) metodunu ayarlayarak paragrafları bir listenin farklı seviyelerine yerleştirebilirsiniz. Üst seviye `0` derinliğe sahiptir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) oluşturun ve bir slayta erişin.
2. Bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin ve metin çerçevesindeki varsayılan paragrafı temizleyin.
3. Dört paragraf oluşturup madde işareti sembollerini yapılandırın.
4. Onların [IParagraphFormat.setDepth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setDepth-short-) değerlerini `0`, `1`, `2` ve `3` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu Java örneği dört seviyeli madde işaretli bir liste oluşturur:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Numaralı Liste Öğelerini Özel Değerlerle Başlatma**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metodunu kullanarak numaralı bir paragrafın başlangıç sayısını ayarlayabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) oluşturun ve bir slayta [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
2. Şeklin metin çerçevesindeki varsayılan paragrafı temizleyin.
3. Üç numaralı paragraf oluşturun.
4. İlgili paragraflar için [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metodunu sırasıyla `2`, `3` ve `7` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu Java örneği her paragraf için özel bir başlangıç numarası atar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Paragraf Düzeni ve Son Özelliklerini Kontrol Etme**

### **İlk Satır Girintisi Ayarlama**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metodunu kullanarak bir paragrafın ilk satır girintisini kontrol edebilirsiniz. Bu metod yalnızca paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak gerektiğinde [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) kullanın. Sadece ilk satırı taşımak istediğinizde ise [IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) kullanın.

Aşağıdaki örnek birkaç paragraf oluşturur ve farklı [IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) değerleri uygulayarak ilk satır girintisinin paragraf düzenini nasıl etkilediğini gösterir.

1. Presentation sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Çeşitli paragraflar oluşturun ve her biri için farklı [IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

Bu kod bir paragraf girintisi nasıl ayarlanır gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragrafların ilk satır girintisi](first_line_indent.png)

### **Sarkıtılmış Girinti Ayarlama**

Sarkıtılmış girinti, ilk satırın kalan satırların solundan daha sola başlamasıyla elde edilen bir paragraf düzenidir. Aspose.Slides’te bu etkiyi [IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ile oluşturursunuz; negatif bir değer ilk satırı paragraf gövdesine göre sola kaydırır.

Uygulamada, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) paragraf gövdesinin sol konumunu belirler, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ise ilk satırın bu kenar boşluğuna göre konumunu tanımlar. Sarkıtılmış bir girinti oluşturmak için `setMarginLeft` metoduna pozitif bir değer, `setIndent` metoduna negatif bir değer veririz.

Bu biçimlendirme, bibliyografyalar, referanslar, sözlük girdileri ve satırların paragraf gövdesinin altında hizalanması gereken diğer paragraflar için faydalıdır.

1. Presentation sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her biri için [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metoduna pozitif bir değer verin.
6. Sarkıtılmış etkiyi oluşturmak için [IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metoduna negatif bir değer verin.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

Bu kod bir paragraf için sarkıtılmış girinti nasıl ayarlanır gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragrafların sarkıtılmış girintisi](hanging_indent.png)

### **Paragraf Sonu Çalıştırma Özelliklerini Ayarlama**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek, ikinci paragrafın son işaretine bir yazı tipi boyutu ve Latin yazı tipi atar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) yükleyin ve bir slayta erişin.
2. Bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin ve varsayılan paragrafını temizleyin.
3. İki paragraf oluşturun ve bunlara metin bölümleri ekleyin.
4. İkinci paragrafın son işareti için bir [PortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portionformat/) oluşturun.
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) ve [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) ayarlayın.
6. Biçimi [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ile atayın ve sunumu kaydedin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Paragraf İçeriğini İçe ve Dışa Aktarma**

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metodunu kullanarak HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürebilirsiniz.

1. Presentation sınıfının bir örneğini oluşturun.
2. Bir slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
3. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı temizleyin.
4. Kaynak HTML dosyasını okuyun.
5. HTML dizisini [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metoduna geçirin.
6. Değiştirilmiş sunumu kaydedin.

Bu Java örneği HTML’i bir metin çerçevesine içe aktarır:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Paragraf Metnini HTML Olarak Dışa Aktarma**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metodunu kullanarak seçili paragraf aralığını HTML olarak dışa aktarabilirsiniz.

1. Presentation sınıfının bir örneğini oluşturun ve istenen sunumu yükleyin.
2. Slayta erişin ve metni içeren [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) bulun.
3. Şeklin [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) öğesine erişin.
4. Başlangıç paragraf indeksi ve dışa aktarılacak paragraf sayısı ile [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metodunu çağırın.
5. Döndürülen HTML dizgisini bir dosyaya yazın.

Bu Java örneği ilk metin şeklinin tüm paragraflarını dışa aktarır:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Bir Paragrafı Görüntü Olarak Oluşturma**

[IParagraph.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/#getImage--) bir paragrafı doğrudan render eder ve bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) döndürür. Sonucu [IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ile dosyaya veya akışa kaydedebilirsiniz. İçeren şekli render etmenize veya bitmap’i elle kırpmanıza gerek yoktur.

[IParagraph.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/#getImage--) paragraf bulunamazsa, geçerli bir render alanı yoksa veya render edilemezse `null` dönebilir. Kaydetmeden önce sonucu kontrol edin ve kullanım sonrası döndürülen görüntüyü serbest bırakın.

#### **Paragrafı Varsayılan Ölçekte Oluşturma**

sample.pptx adlı bir sunum dosyamızın bir slaydı olduğunu ve ilk şeklinin üç paragraf içeren bir metin kutusu olduğunu varsayalım.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek, normal bir metin şeklinin ikinci paragrafını varsayılan ölçekte render eder ve döndürülen görüntüyü PNG formatında kaydeder. `finally` bloğu, görüntünün doğru şekilde serbest bırakılmasını sağlar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraf görüntüsü](paragraph_to_image_output.png)

#### **Tablo Hücresinde Paragrafı Ölçeklendirme ile Oluşturma**

`float scaleX` ve `float scaleY` parametrelerini kabul eden [IParagraph.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/#getImage-float-float-) aşırı yüklemesini kullanarak yatay ve dikey ölçek faktörlerini ayarlayabilirsiniz. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin iki katı ve yüksekliğinin iki katı olarak render eder ve sonucu PNG görüntüsü olarak kaydeder.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

`1` ölçek faktörü, ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` kullanmak, genişlik ve yüksekliği yaklaşık olarak iki katına çıkaran bir görüntü üretir; bu da piksel sayısını dört katına yükseltir. Daha büyük faktörler, yakınlaştırma veya yüksek çözünürlüklü çıktı için daha keskin metin sağlar, ancak bellek kullanımı ve dosya boyutunu da artırır. `1`’in altındaki faktörler daha küçük ve daha az detaylı görüntüler üretir. En boy oranını korumak için eşit faktörler kullanın; farklı yatay ve dikey faktörler çıktıyı bağımsız olarak uzatır.

Bir şeklin tamamını [IShape.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getImage--) ile render etmek, çıktının şeklin doldurması, kenarlığı veya diğer görsel bağlamını içermesi gerektiğinde yararlıdır. Sadece paragraf görüntüsü için [IParagraph.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/#getImage--) kullanın.

## **SSS**

**Metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Kaydırmayı devre dışı bırakmak ve satırların metin çerçevesinin kenarlarında kırılmasını önlemek için [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) metodunu ayarlayın.

**Belirli bir paragrafın slayt üzerindeki tam sınırlamalarını nasıl alabilirim?**

Paragrafın sınırlayan dikdörtgenini almak için [IParagraph.getRect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/#getRect--) metodunu kullanın. Tek bir bölümün sınırlamalarını elde etmek için [IPortion.getRect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#getRect--) metodunu kullanabilirsiniz.

**Paragraf hizalaması (sol, sağ, merkez veya iki kenara yaslama) nerede kontrol edilir?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) bir paragraf‑seviyesi ayarıdır ve bireysel bölümlerin biçimlendirmesinden bağımsız olarak tüm paragrafı etkiler.

**Paragrafın bir kısmı için dil denetimi ayarlayabilir miyim?**

Evet. Bireysel bölümler için [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metodunu ayarlayarak bir paragrafın içinde birden fazla dilde metin bulunmasını sağlayabilirsiniz.