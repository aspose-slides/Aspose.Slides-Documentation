---
title: Android'de PowerPoint Metin Paragraflarını Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- metin ekle
- paragraf ekle
- metni yönet
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- askı girintisi
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntüleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) bir şeklin içinde metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf‑seviyesindeki biçimlendirmeye erişim sağlar.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) bir paragraftaki metin yürütmesini temsil eder. Her bölüm kendi metnine ve karakter‑seviyesindeki biçimlendirmeye sahip olabilir.

Bu nedenle bir paragraf, birden çok bölüm kullanılarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içerebilir.

## **Paragrafları Oluşturma ve Biçimlendirme**

### **Birden Çok Bölüm ile Paragraf Oluşturma**

Aşağıdaki adımlar, her biri üç bölüm içeren üç paragrafla bir metin çerçevesi oluşturur:

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksi aracılığıyla ilgili slayta erişin.
3. Slayta dikdörtgen bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) öğesine erişin.
5. Varsayılan paragrafı kullanın ve metin çerçevesine iki ek [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) nesnesi ekleyin.
6. Her paragrafın üç bölüm içermesi için yeterli sayıda [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) nesnesi ekleyin. Varsayılan paragraf zaten bir boş bölüm içerir.
7. Her bölümün metnini ayarlayın.
8. [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--) aracılığıyla karakter‑seviyesinde biçimlendirme uygulayın.
9. Değiştirilen sunumu kaydedin.

Bu Android via Java örneği adımları uygular:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Madde İşareti ve Numaralı Listeler Oluşturma**

### **Madde İşareti veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralandırma, ilgili öğeleri daha kolay taranabilir kılar. Aspose.Slides içinde liste ayarları, [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) aracılığıyla tanımlanır.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksi aracılığıyla ilgili slayta erişin.
3. Seçilen slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) öğesine erişin.
5. Metin çerçevesinden varsayılan paragrafı kaldırın.
6. Bir sembol madde işareti için bir [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) oluşturun.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-int-) değerini [BulletType.Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/) olarak ayarlayın ve madde işareti karakterini belirleyin.
8. Paragraf metnini, girintiyi, madde işareti rengini ve yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. İkinci bir paragraf oluşturun ve [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-int-) değerini [BulletType.Numbered](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/) olarak ayarlayın.
11. Numaralı madde işareti stilini yapılandırın ve paragrafı metin çerçevesine ekleyin.
12. Sunumu kaydedin.

Bu Android via Java örneği bir sembol madde işareti ve bir numaralı madde işareti oluşturur:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksi aracılığıyla ilgili slayta erişin.
3. Bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin ve onun [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) öğesine erişin.
4. Metin çerçevesinden varsayılan paragrafı kaldırın.
5. Madde işareti görüntüsünü yükleyin ve sunumun görsel koleksiyonuna bir [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) olarak ekleyin.
6. Bir [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) oluşturun ve metnini ayarlayın.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-int-) değerini [BulletType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/) olarak ayarlayın.
8. Görüntüyü [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--) aracılığıyla atayın ve madde işareti yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. Değiştirilen sunumu kaydedin.

Bu Android via Java örneği bir resim madde işareti oluşturur:

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

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) ayarlanarak paragraflar listenin farklı seviyelerinde konumlandırılır. En üst seviye derinliği `0` dır.

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) oluşturun ve bir slayta erişin.
2. Bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin ve varsayılan paragrafı metin çerçevesinden temizleyin.
3. Dört paragraf oluşturun ve madde işareti sembollerini yapılandırın.
4. [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) değerlerini sırasıyla `0`, `1`, `2` ve `3` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu Android via Java örneği dört seviyeli bir madde işaretli liste oluşturur:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) kullanılarak bir numaralı paragraf için ilk gösterilen sayı ayarlanır.

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) oluşturun ve bir slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.
2. Şeklin metin çerçevesinden varsayılan paragrafı temizleyin.
3. Üç numaralı paragraf oluşturun.
4. İlgili paragraflar için [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) değerlerini sırasıyla `2`, `3` ve `7` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu Android via Java örneği her paragraf için özel bir başlangıç numarası atar:

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

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) kullanılarak bir paragrafın ilk satır girintisi kontrol edilir. Bu yöntem yalnızca paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak istediğinizde [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) kullanılmalıdır. Yalnızca ilk satırı taşımak istediğinizde ise [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) kullanılmalıdır.

Aşağıdaki örnek, birkaç paragraf oluşturur ve farklı [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) değerlerini uygulayarak ilk satır girintisinin paragraf düzenini nasıl etkilediğini gösterir.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta bir dikdörtgen [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Birkaç paragraf oluşturun ve bunlar için farklı [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilen sunumu kaydedin.

Bu kod bir paragraf girintisinin nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Askı Girintisi Ayarlama**

Askı girintisi, ilk satırın kalan satırların solundan daha sola başlamasıyla ortaya çıkan bir paragraf düzenidir. Aspose.Slides içinde bu etki, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ile negatif bir değer verilerek elde edilir; bu, ilk satırı paragraf gövdesine göre sola hareket ettirir.

Uygulamada, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) paragraf gövdesinin sol konumunu, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ise ilk satırın bu kenar boşluğuna göre konumunu belirler. Askı girintisi oluşturmak için `setMarginLeft` pozitif, `setIndent` ise negatif bir değer almalıdır.

Bu biçimlendirme, bibliyografiler, kaynakça, sözlük girdileri ve sarılmış satırların paragraf gövdesinin altında hizalanması gereken diğer paragraflar için uygundur.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta bir dikdörtgen [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.
4. Şeklin [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her biri için [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) değerini pozitif olarak ayarlayın.
6. Askı etkisini yaratmak için [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) değerini negatif olarak geçirin.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilen sunumu kaydedin.

Bu kod bir paragraf için askı girintisinin nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Paragrafların askı girintisi](hanging_indent.png)

### **Paragraf Sonu Çalıştırma Özelliklerini Ayarlama**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek, ikinci paragrafın son işaretine bir yazı tipi boyutu ve Latin yazı tipi atar:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) yükleyin ve bir slayta erişin.
2. Bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin ve varsayılan paragrafını temizleyin.
3. İki paragraf oluşturun ve bunlara metin bölümleri ekleyin.
4. İkinci paragrafın son işareti için bir [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) oluşturun.
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) ve [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) ayarlayın.
6. Formatı [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ile atayın ve sunumu kaydedin.

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

Satır sonlarında otomatik kaydırma ve noktalama işaretlerini etkileyen paragraf kuralları için [Control Line Breaking](/slides/tr/androidjava/text-formatting/#control-line-breaking) ve [Control Hanging Punctuation](/slides/tr/androidjava/text-formatting/#control-hanging-punctuation) bölümlerine bakın.

Bir paragrafın metin düzenlemesi sonrası kapladığı satır sayısını saymak için [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) kullanılır; bu, otomatik kaydırma dahil olmak üzere render edilen satırları içerir. Bu, sunum şablonlarında metin uzunluğunu ve düzenini kontrol ederken kullanışlıdır.

Bir paragraf, [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--) içinde bir öğedir ve birden çok render edilen satır kaplayabilir. Paragraf içinde açık bir satır sonu, yeni bir paragraf oluşturmadan yeni bir satır başlatır. Otomatik kaydırma, metne açık satır sonları eklemeden mevcut genişliğe göre satır oluşturur. Bu yüzden paragraf sayısını veya satır‑sonu karakterlerini saymak render edilen satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şekli daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Kaydırma etkinleştirilmiş ve otomatik sığdırma devre dışı bırakılmıştır; böylece şekil genişliği, metni otomatik olarak küçültmeden kaydırmayı kontrol eder. Şekil boyutları puan cinsindendir. Son olarak örnek, metin çerçevesine bir paragraf daha ekler ve satır sayılarını toplar.

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

Bu metin ve boyutlarla, şekli daraltmak satır sayısını artırırken kısa dizeye geçmek azaltır. Kesin sayılar, kullanılan yazı tipine, boyutuna, kenar boşluklarına, girintilere, kaydırmaya ve otomatik sığdırma ayarlarına bağlı olarak değişebilir. Şablon kontrolü yaparken hedef ortam için planlanan yazı tiplerini ve düzen ayarlarını kullanın.

Satır sayısı yalnızca metnin kapsayıcısının dışına taşma durumunu belirlemez. Mevcut yükseklik, satır yüksekliği, paragraf ve satır aralığı ve otomatik sığdırma davranışı da önemlidir; kaydırma devre dışı bırakıldığında tek bir satır bile mevcut genişliği aşabilir.

## **Paragraf İçeriğini İçe ve Dışa Aktarma**

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) kullanılarak HTML işaretlemesi, bir metin çerçevesindeki paragraflara ve bölümlere dönüştürülür.

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Bir slayta erişin ve bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.
3. Şeklin [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) öğesine erişin ve varsayılan paragrafı temizleyin.
4. Kaynak HTML dosyasını okuyun.
5. HTML dizesini [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metoduna aktarın.
6. Değiştirilen sunumu kaydedin.

Bu Android via Java örneği HTML'i bir metin çerçevesine içe aktarır:

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

### **Paragraf Metnini HTML'ye Dışa Aktarma**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) kullanılarak seçilen paragraf aralığı HTML olarak dışa aktarılır.

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve istenen sunumu yükleyin.
2. Slayta erişin ve metni içeren [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) bulun.
3. Şeklin [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) öğesine erişin.
4. Başlangıç paragrafı indeksi ve dışa aktarılacak paragraf sayısı ile [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metodunu çağırın.
5. Dönen HTML dizesini bir dosyaya yazın.

Bu Android via Java örneği ilk metin şeklinin tüm paragraflarını dışa aktarır:

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

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) bireysel bir paragrafı doğrudan render eder ve bir [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) döndürür. Sonucu bir dosyaya veya akıma [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) ile kaydedebilirsiniz. İçeren şekli render etmenize veya bir bitmap'i elle kırpmanıza gerek yoktur.

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) paragraf bulunamazsa, geçerli bir render sınırı yoksa veya render edilemezse `null` döndürebilir. Kaydetmeden önce sonucu kontrol edin ve kullanımdan sonra döndürülen görüntüyü serbest bırakın.

#### **Paragrafı Varsayılan Ölçekte Render Etme**

sample.pptx adlı bir sunum dosyamızın bir slaytı olduğunu ve ilk şeklinin üç paragraf içeren bir metin kutusu olduğunu varsayalım.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek, ikinci paragrafı normal bir metin şekli içinde varsayılan ölçekte render eder ve PNG formatında kaydeder. `finally` bloğu, görüntünün doğru şekilde serbest bırakılmasını sağlar.

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

![Paragraf resmi](paragraph_to_image_output.png)

#### **Tablo Hücresinde Ölçeklendirme ile Paragraf Render Etme**

[ IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) aşırı yüklemesi, `float scaleX` ve `float scaleY` parametrelerini kabul eder; böylece yatay ve dikey ölçek faktörleri ayarlanabilir. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin ve yüksekliğinin iki katı olarak render eder ve sonucu PNG görüntüsü olarak kaydeder.

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

`1` ölçek faktörü, ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` ayarlandığında, genişliği ve yüksekliği yaklaşık iki katına çıkan bir görüntü elde edilir; bu da piksel sayısının dört katı demektir. Daha büyük faktörler, yakınlaştırma veya yüksek çözünürlüklü çıkışlar için metni daha keskin yapar, ancak bellek kullanımı ve dosya boyutunu da artırır. `1`’in altındaki faktörler, daha az detaylı daha küçük görüntüler üretir. Görüntünün en‑boy oranını korumak için aynı faktörler kullanılmalı; farklı yatay ve düşey faktörler çıkışı bağımsız olarak uzatır.

Bir bütün şekli [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) ile render etmek, çıktının şeklin dolgu, kenarlık veya diğer görsel bağlamını içermesi gerektiğinde faydalıdır. Sadece paragrafın görüntüsü için [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) kullanılmalıdır.

## **SSS**

**Bir metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Satır kaydırmayı devre dışı bırakmak için [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) ayarlayın; böylece satırlar metin çerçevesinin kenarlarında kırılmaz.

**Belirli bir paragrafın slayt üzerindeki kesin sınırlarını nasıl alabilirim?**

[IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) bir bölümün sınırlarını, [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) ise bir paragrafın sınırlarını döndürür.

**Paragraf hizalaması (sol, sağ, orta veya iki yana yaslama) nerede kontrol edilir?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) bir paragraf‑seviyesi ayarıdır ve bireysel bölüm biçimlendirmesinden bağımsız olarak bütün paragrafı etkiler.

Her satır içinde farklı yazı tipi boyutlarına sahip bölümleri dikey olarak hizalamak için **[Align Fonts Within a Line](/slides/tr/androidjava/text-formatting/#align-fonts-within-a-line)** konusuna bakın.

**Paragrafın bir kısmı için imla denetimi dili ayarlayabilir miyim?**

Evet. Bireysel bölümler için [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ayarlayarak bir paragraf içinde birden çok dilde metin bulunabilir.