---
title: Java'da PowerPoint Metin Paragraflarını Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- metin ekle
- paragraf ekle
- metni yönet
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- asmalı girinti
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metin HTML'e
- paragraf HTML'e
- paragraf görüntüye
- metin görüntüye
- paragrafı dışa aktar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntüleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Java, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) metin kapsayıcısını bir şekil içinde temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf‑düzeyi biçimlendirmesine erişim sağlar.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) bir paragraftaki bir metin çalıştırmasını temsil eder. Her bölüm kendi metnine ve karakter‑düzeyi biçimlendirmesine sahip olabilir.

Bir paragraf, bu nedenle birden çok bölüm kullanarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içeren metin barındırabilir.

## **Paragrafları Oluşturma ve Biçimlendirme**

### **Birden Çok Bölüm İçeren Paragraflar Oluşturma**

Aşağıdaki adımlar, her biri üç bölüm içeren üç paragrafla bir metin çerçevesi oluşturur:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks aracılığıyla erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) öğesine erişin.
5. Varsayılan paragrafı kullanın ve metin çerçevesine iki tane daha [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) nesnesi ekleyin.
6. Her paragrafın üç bölüm içerecek kadar [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) nesnesi ekleyin. Varsayılan paragraf zaten bir boş bölüm içerir.
7. Her bölümün metnini ayarlayın.
8. Karakter düzeyinde biçimlendirmeyi [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) üzerinden uygulayın.
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

Madde işaretleri ve numaralar, ilgili öğelerin daha kolay taranmasını sağlar. Aspose.Slides'te liste ayarları [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) üzerinden tanımlanır.

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks aracılığıyla erişin.
3. Seçili slayta bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) öğesine erişin.
5. Varsayılan paragrafı metin çerçevesinden kaldırın.
6. Sembol madde işareti için bir [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) oluşturun.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) metodunu [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) olarak ayarlayın ve madde işareti karakterini belirtin.
8. Paragraf metnini, girintiyi, madde işareti rengini ve madde işareti yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. İkinci bir paragraf oluşturun ve [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) metodunu [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) olarak ayarlayın.
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

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks aracılığıyla erişin.
3. Bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ekleyin ve onun [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) öğesine erişin.
4. Varsayılan paragrafı metin çerçevesinden kaldırın.
5. Madde işareti görüntüsünü yükleyin ve sunumun görüntü koleksiyonuna bir [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) olarak ekleyin.
6. Bir [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) oluşturun ve metnini ayarlayın.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) metodunu [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) olarak ayarlayın.
8. Görüntüyü [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) üzerinden atayın ve madde işareti yüksekliğini ayarlayın.
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

### **Çok Seviyeli Liste Oluşturma**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) metodunu kullanarak paragrafları bir listenin farklı seviyelerine yerleştirin. En üst seviyenin derinliği `0`'dır.

1. Bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) oluşturun ve bir slayta erişin.
2. Bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ekleyin ve varsayılan paragrafı metin çerçevesinden temizleyin.
3. Dört paragraf oluşturun ve madde işareti sembollerini yapılandırın.
4. [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) değerlerini sırasıyla `0`, `1`, `2` ve `3` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu Java örneği dört seviyeli bir madde işaretli liste oluşturur:

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

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metodunu kullanarak numaralı bir paragraf için gösterilecek başlangıç numarasını ayarlayın.

1. Bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) oluşturun ve bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) slayta ekleyin.
2. Şeklin metin çerçevesinden varsayılan paragrafı temizleyin.
3. Üç numaralı paragraf oluşturun.
4. İlgili paragraflar için [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metodunu sırasıyla `2`, `3` ve `7` olarak ayarlayın.
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

## **Paragraf Düzeni ve Bitiş Özelliklerini Kontrol Etme**

### **İlk Satır Girintisi Ayarlama**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metodunu kullanarak bir paragrafın ilk satır girintisini kontrol edin. Bu metod yalnızca ilk satırı paragrafın sol kenar boşluğuna göre hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak gerektiğinde [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metodunu kullanın. Yalnızca ilk satırı taşımak istediğinizde ise [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metodunu kullanın.

Aşağıdaki örnek birkaç paragraf oluşturur ve farklı [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) değerleri uygulayarak ilk satır girintisinin paragraf düzenini nasıl etkilediğini gösterir.

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Birkaç paragraf oluşturun ve bunlara farklı [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) değerleri atayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

Bu kod bir paragraf girintisinin nasıl ayarlanacağını gösterir:

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

### **Asma Girinti Ayarlama**

Asma girinti, ilk satırın kalan satırların solundan başlayarak yer aldığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ile oluşturursunuz. İlk satırı paragraf gövdesine göre sola kaydırmak için negatif bir değer geçirin.

Uygulamada, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) paragraf gövdesinin sol konumunu tanımlarken, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) bu kenar boşluğuna göre ilk satırın konumunu tanımlar. Asma girinti oluşturmak için `setMarginLeft`'a pozitif bir değer ve `setIndent`'e negatif bir değer geçirin.

Bu biçimlendirme, bibliyografiler, referanslar, sözlük girişleri ve satırların paragraf gövdesi altında hizalanması gereken diğer paragraflar için faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her biri için [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metoduna pozitif bir değer geçirin.
6. Asma girinti etkisini oluşturmak için [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metoduna negatif bir değer geçirin.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

Bu kod bir paragraf için asma girintinin nasıl ayarlanacağını gösterir:

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

![Paragrafların asma girintisi](hanging_indent.png)

### **Paragraf Sonu Çalıştırma Özelliklerini Ayarla**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) paragrafın son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek ikinci paragrafın son işaretine bir yazı tipi boyutu ve Latin yazı tipi atar:

1. Bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) yükleyin ve bir slayta erişin.
2. Bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ekleyin ve varsayılan paragrafını temizleyin.
3. İki paragraf oluşturun ve onlara metin bölümleri ekleyin.
4. İkinci paragrafın son işareti için bir [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) oluşturun.
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) ve [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) ayarlayın.
6. Formatı [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ile atayın ve sunumu kaydedin.

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

## **Render Edilen Satırları Sayma**

Satır kırma ve satır sonlarındaki noktalama işaretlerini etkileyen paragraf kuralları için **[Satır Kırmayı Kontrol Et](/slides/tr/java/text-formatting/#control-line-breaking)** ve **[Askıya Alınmış Noktalama İşaretlerini Kontrol Et](/slides/tr/java/text-formatting/#control-hanging-punctuation)** bölümlerine bakın.

[IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) metodunu kullanarak bir paragrafın metin yerleşiminden sonra kapladığı satır sayısını, otomatik kaydırma dahil olmak üzere, sayabilirsiniz. Bu, sunum şablonlarında metin uzunluğunu ve yerleşimini kontrol ederken yararlıdır.

Bir paragraf, [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) içindeki tek bir öğedir ve birden çok render edilmiş satır kaplayabilir. Paragraf içinde açık bir satır sonu, başka bir paragraf oluşturmadan yeni bir satır başlatır. Otomatik kaydırma, metni açık satır sonları eklemeden mevcut genişliğe göre satırlar oluşturur. Bu yüzden paragraf veya satır‑sonu karakterlerini saymak render edilmiş satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şekli daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Kaydırma etkin ve otomatik sığdırma devre dışı bırakılmıştır; böylece şekil genişliği kaydırmayı kontrol eder, metin otomatik olarak küçülmez veya şekil yeniden boyutlandırılmaz. Şekil boyutları puan cinsindendir. Son olarak örnek bir paragraf daha ekler ve metin çerçevesindeki satır sayılarını toplar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Bu metin ve bu boyutlarla, şekli daraltmak satır sayısını artırırken, metni kısa dizeyle değiştirmek sayıyı azaltır. Kesin sayılar, yazı tipi bulunabilirliği ve ikamesi, yazı tipi boyutu, kenar boşlukları, girintiler, kaydırma ve otomatik sığdırma ayarları gibi faktörlere bağlı olarak değişebilir. Şablon kontrolünde hedef ortam için tasarlanan yazı tiplerini ve yerleşim ayarlarını kullanın.

Satır sayısı tek başına metnin kapsayıcısının dışına taşma olup olmadığını belirlemez. Kullanılabilir yükseklik, satır yükseklikleri, paragraf ve satır aralığı ve otomatik sığdırma davranışı da önemlidir; kaydırma devre dışı ise tek bir satır bile mevcut genişliği aşabilir.

## **Paragraf İçeriğini İçe ve Dışa Aktarma**

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metodunu kullanarak HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Bir slayta erişin ve bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ekleyin.
3. Şeklin [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı temizleyin.
4. Kaynak HTML dosyasını okuyun.
5. HTML dizesini [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metoduna aktarın.
6. Değiştirilmiş sunumu kaydedin.

Bu Java örneği HTML'i bir metin çerçevesine içe aktarır:

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

### **Paragraf Metnini HTML'e Dışa Aktarma**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metodunu kullanarak seçili bir paragraf aralığını HTML olarak dışa aktarabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının örneğini oluşturun ve istediğiniz sunumu yükleyin.
2. Slayta erişin ve metni içeren [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) öğesini bulun.
3. Şeklin [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) öğesine erişin.
4. Başlangıç paragraf indeksi ve dışa aktarılacak paragraf sayısını belirterek [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metodunu çağırın.
5. Dönen HTML dizesini bir dosyaya yazın.

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

### **Paragrafı Görüntü Olarak Render Etme**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) yöntemi tek bir paragrafı doğrudan render eder ve bir [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) döndürür. Sonucu bir dosya ya da akışa [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ile kaydedebilirsiniz. İçeren şekli render etmenize veya bitmap'i elle kırpmanıza gerek yoktur.

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) paragraf bulunamazsa, geçerli bir render sınırı yoksa veya render edilemezse `null` dönebilir. Sonucu kaydetmeden önce kontrol edin ve kullanımdan sonra döndürülen görüntüyü serbest bırakın.

#### **Paragrafı Varsayılan Ölçekte Render Etme**

Bir sunum dosyası (sample.pptx) içinde bir slayt olduğunu ve ilk şeklin üç paragraf içeren bir metin kutusu olduğunu varsayalım.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek ikinci paragrafı normal bir metin şekli içinde varsayılan ölçekte render eder ve sonucu PNG formatında kaydeder. `finally` bloğu görüntünün doğru şekilde serbest bırakılmasını sağlar.

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

#### **Tablo Hücresinde Ölçekleme ile Paragrafı Render Etme**

Yatay ve düşey ölçek faktörlerini ayarlamak için `float scaleX` ve `float scaleY` parametrelerini kabul eden [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) aşırı yüklemesini kullanın. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin iki katı ve yüksekliğinin iki katı olacak şekilde render eder ve sonucu PNG görüntüsü olarak kaydeder.

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

`1` ölçek faktörü ilgili ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` verilirse, genişlik ve yükseklik yaklaşık olarak iki katına çıkar ve piksel sayısı dört katına yükselir. Daha büyük faktörler genellikle yakınlaştırma veya yüksek çözünürlüklü çıktı için metni keskinleştirir, fakat bellek kullanımını ve dosya boyutunu artırır. `1`'den düşük faktörler daha az detayla daha küçük görüntüler üretir. Oranları korumak için eşit faktörler kullanın; farklı yatay ve düşey faktörler çıktıyı bağımsız olarak uzatır.

[IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) yöntemi, şeklin dolgu, kenarlık veya diğer görsel bağlamının da dahil edilmesi gerektiğinde hâlâ kullanışlıdır. Yalnızca paragraf görüntüsü gerektiğinde [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) kullanın.

## **SSS**

**Metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**  
Evet. Satırların çerçevenin kenarlarında kırılmaması için kaydırmayı devre dışı bırakmak üzere [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) metodunu ayarlayın.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl alabilirim?**  
Paragrafın sınırlayıcı dikdörtgenini almak için [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) metodunu kullanın. Tek bir bölümün sınırlarını elde etmek için [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) metodunu kullanabilirsiniz.

**Paragraf hizalaması (sol, sağ, ortalanmış veya iki yana yaslanmış) nerede kontrol edilir?**  
[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) paragraf‑düzeyi bir ayardır ve bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafı etkiler.

Farklı yazı tipi boyutlarına sahip bölümleri her satırda dikey olarak hizalamak için **[Satır İçinde Yazı Tiplerini Hizala](/slides/tr/java/text-formatting/#align-fonts-within-a-line)** bölümüne bakın.

**Paragrafın bir kısmı için denetleme dilini ayarlayabilir miyim?**  
Evet. Bireysel bölümler için [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metodunu ayarlayarak bir paragraf içinde birden çok dilde metin bulundurabilirsiniz.