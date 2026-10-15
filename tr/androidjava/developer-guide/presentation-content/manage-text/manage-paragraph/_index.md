---
title: Android'da PowerPoint Metin Paragraflarını Yönet
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
- madde işareti yönet
- paragraf girintisi
- askı girintisi
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML'e
- paragrafı HTML'e
- paragrafı görsele
- metni görsele
- paragraf dışa aktar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görselleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) metin şekli içindeki metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf düzeyinde biçimlendirmesine erişim sağlar.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) bir paragraftaki metin yürütmesini temsil eder. Her bölüm kendi metnine ve karakter düzeyinde biçimlendirmesine sahip olabilir.

Bu nedenle bir paragraf, birden çok bölüm kullanarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içeren metin içerebilir.

## **Paragraflar Oluşturma ve Biçimlendirme**

Bir şeklin metin çerçevesinde paragraflar oluşturun ve bölümleri kullanarak bireysel metin yürütmelerini biçimlendirin. Bu bölüm, her paragrafta birden çok bölümü birleştirerek farklı renkler, yazı boyutları ve stiller uygulamayı gösterir.

### **Birden Çok Bölüm İçeren Paragraflar Oluşturma**

Aşağıdaki Android via Java örneği, [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--) tarafından döndürülen koleksiyonda üç metin yürütmesi içeren üç paragraf oluşturur. Varsayılan paragrafı ve boş bölümünü yeniden kullanır, ardından kalan paragrafları ve bölümleri ekler. Biçimlendirme, [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--) aracılığıyla uygulanır: her paragraftaki ilk bölüm kırmızı, kalın ve 15 puan; ikinci bölüm mavi, italik ve 18 puan. Üçüncü bölüm varsayılan biçimini korur:

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

## **Madde İşaretli ve Numaralı Listeler Oluşturma**

Paragraf metnini semboller, sayılar veya özel görsellerle listelere düzenleyin. Bu bölümdeki örnekler madde işareti biçimlendirmesini, çok seviyeli listeleri ve özel başlangıç sayılarını kapsar.

### **Madde İşaretli veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralar ilgili öğeleri taramayı kolaylaştırır. Aspose.Slides'te liste ayarları, [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) üzerinden tanımlanır.

Bu Android via Java örneği aynı metin çerçevesine bir sembol madde işareti ve bir numaralı öğe ekler. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) madde işareti tipini seçerken, [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) sembolü sağlar ve [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) numaralandırma stilini seçer. Her iki öğe de %100 yükseklikte siyah madde işareti ve 25 puan paragraf girintisi kullanır:

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

Resim madde işaretleri, bir sembol veya sayı yerine özel bir görsel kullanmanıza olanak tanır.

Bu Android via Java örneği, bir [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) olarak sunumun görsel koleksiyonuna bir resim ekler ve bunu paragraf madde işareti olarak kullanır. Madde işareti olarak bir resim kullanmak için [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) çağrılır ve resim [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--) aracılığıyla atanır. [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) %100 olarak ayarlanır, böylece madde işareti paragraf metnine göre boyutlandırılır:

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

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) ayarlanarak paragraflar bir listenin farklı seviyelerinde konumlandırılır. En üst seviyenin derinliği `0` dır.

Bu Android via Java örneği, dört paragraf için [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) değerlerini 0‑3 arasında atayarak tek bir metin çerçevesinde hiyerarşi oluşturur. Her paragraf bir sembol madde işareti kullanır; [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) yuvarlak madde işareti ve tire arasında geçiş yaparak yan yana seviyeleri ayırt eder:

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

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) kullanarak bir numaralı paragraf için başlangıç numarasını ayarlayabilirsiniz.

Bu Android via Java örneği üç paragraf için numaralandırma kullanmak üzere [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) ayarlar ve [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) değerlerini 2, 3 ve 7 olarak atar. Başlangıç değeri her paragraf için ayrı ayrı yapılandırılır, böylece görüntülenen sayılar atlanabilir:

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

Paragraf kenar boşluklarını ve girintilerini ayarlayarak ilk satır ve kaydırılmış satırların konumunu kontrol edin. Paragraf son işaretini, görünür metin bölümlerinden ayrı olarak da biçimlendirebilirsiniz.

### **İlk Satır Girintisi Ayarlama**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) yöntemiyle bir paragrafın ilk satır girintisini kontrol edebilirsiniz. Bu ayar yalnızca paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalanmış kalır.

Tüm paragrafı taşımak gerektiğinde [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) kullanın. Yalnızca ilk satırı taşımak istediğinizde ise [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) kullanın.

Aşağıdaki örnek üç paragrafın aynı [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) değerini 20 puan ve [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) değerlerini 0, 20 ve 40 puan olarak ayarlar. İlk satırlar giderek daha büyük ofsetlerde başlarken, kaydırılmış satırlar aynı sol kenar boşluğunu korur:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Askı Girintisi Ayarlama**

Askı girintisi, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) özelliğiyle oluşturursunuz. `Indent` değerini negatif yaparak ilk satırı paragraf gövdesine göre sola kaydırın.

Uygulamada, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) paragraf gövdesinin sol konumunu, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ise ilk satırın bu kenar boşluğuna göre konumunu belirler. Askı girintisi oluşturmak için pozitif bir `MarginLeft` ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografiler, referanslar, sözlük girişleri ve kaydırılmış satırların paragraf gövdesinin altına hizalanması gereken diğer paragraflar için faydalıdır.

Aşağıdaki Android via Java örneği, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) değerlerini 40 ve 60 puan, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) değerlerini -20 ve -30 puan olarak eşleştirir. Her paragrafta ilk satır kaydırılmış satırların solunda başlar; ikinci paragrafta daha derin bir askı girintisi vardır:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Paragraf Sonu Çalıştırma Özelliklerini Ayarlama**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) yöntemi paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek, [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 48 puan ve [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) Times New Roman olarak ayarlayan bir [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) oluşturur. Bu biçimi ikinci paragrafın son işaretine atar, görünür metin bölümlerini değiştirmez:

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

Otomatik kaydırma ve satır sonlarında noktalama işaretlerini etkileyen paragraf kuralları için [Control Line Breaking](/slides/tr/androidjava/text-formatting/#control-line-breaking) ve [Control Hanging Punctuation](/slides/tr/androidjava/text-formatting/#control-hanging-punctuation) bölümlerine bakın.

Paragrafın metin yerleşiminden sonra kaç satır kapladığını saymak için [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) kullanılabilir; bu, otomatik kaydırmayı da içerir. Sunum şablonlarında metin uzunluğunu ve yerleşimini kontrol ederken faydalıdır.

Bir paragraf, [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--) içinde tek bir öğedir ve birkaç render edilmiş satır kaplayabilir. Paragraf içinde açık bir satır sonu, başka bir paragraf oluşturmadan yeni bir satır zorlar. Otomatik kaydırma ise mevcut genişliğe göre satır oluşturur ve metne açık satır sonu eklemez. Bu nedenle paragrafları ya da satır sonu karakterlerini saymak, render edilmiş satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şekli daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Örnek, [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) ile kaydırmayı etkinleştirir ve [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) ile otomatik sığdırmayı devre dışı bırakır; böylece şekil genişliği kaydırmayı kontrol eder, metni otomatik küçültmez veya şekli yeniden boyutlandırmaz. Her ölçüm [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) kullanır. Şekil boyutları puan cinsindendir. Son olarak örnek bir paragraf daha ekleyerek metin çerçevesindeki satır sayılarını toplar.

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

Bu metin ve bu boyutlarla, şekli daraltmak satır sayısını artırırken, kısa dizeyle değiştirmek azaltır. Kesin sayılar font bulunabilirliği, ikame, yazı tipi boyutu, kenar boşlukları, girinti, kaydırma ve otomatik sığdırma ayarlarına bağlı olarak değişebilir. Bir şablonu kontrol ederken hedef ortam için planlanan font ve yerleşim ayarlarını kullanın.

Satır sayısı yalnız başına metnin kapsayıcısının dışına taşmasını belirlemez. Kullanılabilir yükseklik, satır yüksekliği, paragraf ve satır aralığı ve otomatik sığdırma davranışı da önemlidir; kaydırma devre dışı bırakıldığında tek bir satır bile mevcut genişliği aşabilir.

## **Paragraf İçeriğini İçe ve Dışa Aktarma**

HTML kullanarak metni bir sunuma getirebilir veya mevcut paragrafları dışa aktararak sunum dışı kullanım için elde edebilirsiniz. Bu bölüm ayrıca tablo hücrelerindeki paragraflar dahil, bireysel paragrafları görsel olarak render etmeyi de gösterir.

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) kullanarak HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürebilirsiniz.

Bu Android via Java örneği bir dosyadan HTML okur ve işaretlemeyi [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metoduna geçirir. Metin çerçevesinin varsayılan paragrafını temizler, böylece çerçeve yalnızca içe aktarılan içeriği içerir. Dikdörtgen şekil, slaytın her iki yanında 10 puanlık bir kenar boşluğu bırakır:

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

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) kullanarak seçili paragraf aralığını HTML olarak dışa aktarabilirsiniz. Sunum metnini bir web sitesinde yeniden kullanırken, sunumun font, boyut veya metin kutusu stillerini taşımadan yerel vurguyu korumak isteyebilirsiniz. [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) ayarı, dışa aktarımın biçimlendirme kalıtımını ne kadar takip edeceğini kontrol eder.

[Örnek sunumu](text-inheritance.pptx) indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slaytı, "Inherited text; explicit red 18pt" metnini içeren bir metin şekli barındırır. Girdi kasıtlı olarak birkaç biçimlendirme seviyesini kullanır:

- Sunumun varsayılan metin stili Calibri ve 28 pt boyutu sağlar.
- Metin çerçevesinin birinci seviyesindeki metin stili mavi metin ve italik sağlar.
- Paragraf açıkça kalın metin ayarlar.
- İkinci bölüm, "explicit red 18pt", kırmızı metin ve 18 pt boyutunu açıkça ayarlar.

Aşağıdaki tam örnek aynı paragrafları üç kez dışa aktarır. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) dışa aktarma metoduna geçirilir ve her sonuç ayrı bir UTF‑8 HTML dosyası olarak yazılır:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

Oluşturulan HTML, ilk bölüm için aşağıdaki CSS'i içerir, "Inherited text; ". Tablo ilgili bildirimleri listeler; diğer oluşturulan özellikler açıklık için çıkarılmıştır.

| Çıktı | İlk Bölüm İçin İlgili CSS | Görünüm |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri mevcutsa 28 pt boyutunda mavi, kalın, italik metin. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Mavi, kalın, italik metin; sayfa veya tarayıcı font ailesi ve boyutunu sağlar. |
| `ParagraphOnly.html` | `font-weight:bold` | Kalın metin; sayfa veya tarayıcı font ailesi, boyut, renk ve italik stili sağlar. |

İkinci bölüm, üç çıktının tamamında `color:#ff0000`, `font-size:18pt` ve `font-weight:bold` değerlerini korur. `All` ve `TextBox` içinde italik de korunur, `ParagraphOnly` içinde korunmaz. Kalıtımın kısıtlanması, bir paragraf veya bölüme açıkça atanmış biçimlendirmeyi kaldırmaz.

Dosyaları aynı tarayıcıda açarak karşılaştırın. Kısıtlı iki modda, atlanan CSS özellikleri hedef sayfanın stilleri veya tarayıcı varsayılanları tarafından çözülür; sonuçta görünüm HTML'nin nerede kullanıldığına bağlıdır.

### **Bir Paragrafı Görüntü Olarak Render Etme**

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) bireysel bir paragrafı doğrudan render eder ve bir [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) döndürür. Sonucu bir dosyaya veya akışa [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) ile kaydedebilirsiniz. İçeren şekli render etmenize veya bir bitmap’i manuel olarak kırpmanıza gerek yoktur.

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) paragraf ana koleksiyonunda bulunamazsa, geçerli bir render sınırı yoksa veya render edilemezse `null` döndürebilir. Kaydetmeden önce sonucu kontrol edin ve kullanım sonrası döndürülen görseli serbest bırakın.

#### **Paragrafı Varsayılan Ölçekte Render Etme**

Örnek, bir slaytta ilk şekli üç paragraf içeren bir metin kutusu olan bir sunum kullanır.

![Üç paragraf içeren Metin Kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek, indeks 1’deki ikinci paragrafı seçer ve [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) metodunu ölçek parametresiz olarak çağırır. Şeklin gerekli paragrafı içerdiğini ve render’in bir görsel döndürdüğünü kontrol eder, ardından PNG formatında kaydetmek için [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metodunu kullanır. `finally` bloğu görüntüyü kullanım sonrası serbest bırakır.

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

![Paragraf Görseli](paragraph_to_image_output.png)

#### **Bir Paragrafı Tablo Hücresinde Ölçeklendirme ile Render Etme**

`float scaleX` ve `float scaleY` parametrelerini kabul eden [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) aşırı yüklemesini kullanarak yatay ve dikey ölçek faktörlerini ayarlayabilirsiniz. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin iki katı ve yüksekliğinin iki katı olarak render eder ve sonucu PNG görseli olarak kaydeder.

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

`1` faktörü ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` genişlik ve yükseklik yaklaşık olarak varsayılan boyutların iki katı olur ve dört kat piksel üretir. Daha büyük faktörler yakınlaştırma veya yüksek çözünürlük çıktısı için daha keskin metin üretir, ancak bellek kullanımını ve dosya boyutunu artırır. `1` altındaki faktörler daha az ayrıntı içeren daha küçük görseller üretir. En boy oranını korumak için eşit faktörler kullanın; farklı yatay ve dikey faktörler çıktıyı bağımsız olarak uzatır.

[IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) ile bütün bir şekli render etmek, çıktının şeklin doldurmasını, kenarlığını veya diğer görsel bağlamını içermesi gerektiğinde hâlâ faydalıdır. Sadece paragraf görseli için [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) kullanın.

## **SSS**

**Metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Satırların metin çerçevesinin kenarlarında kırılmaması için kaydırmayı devre dışı bırakmak üzere [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) ayarlayın.

**Belirli bir paragrafın slayt üzerindeki tam sınırlamalarını nasıl alabilirim?**

Paragrafın sınırlayıcı dikdörtgenini elde etmek için [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) kullanın. Bireysel bir bölüme ait sınırlamaları almak için [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) kullanılabilir.

**Paragraf hizalaması (sol, sağ, ortalanmış veya iki yana yaslanmış) nerede kontrol edilir?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) bir paragraf‑düzeyi ayardır ve bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafı etkiler.

Farklı yazı tipi boyutlarındaki bölümleri aynı satır içinde dikey olarak hizalamak için [Align Fonts Within a Line](/slides/tr/androidjava/text-formatting/#align-fonts-within-a-line) bölümüne bakın.

**Paragrafın bir kısmı için denetim dilini ayarlayabilir miyim?**

Evet. Bireysel bölümler için [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ayarlayarak bir paragrafın birden çok dilde metin içermesini sağlayabilirsiniz.