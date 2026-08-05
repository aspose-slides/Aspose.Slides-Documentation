---
title: Android'de PowerPoint Metin Paragraflarını Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
keywords:
- metin ekle
- paragraf ekle
- metin yönet
- paragraf yönet
- madde işareti yönet
- paragraf girintisi
- asılı girinti
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
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile paragraf biçimlendirmesinde uzmanlaşın—PPT, PPTX ve ODP sunumlarında hizalama, boşluk ve stili Java'da optimize edin."
---
## **Giriş**

Aspose.Slides, Java'da PowerPoint metinleri, paragrafları ve bölümleriyle çalışmak için ihtiyaç duyduğunuz tüm arabirimleri ve sınıfları sağlar.

* Aspose.Slides, bir paragrafı temsil eden nesneleri eklemenizi sağlayan [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) arabirimini sunar. Bir `ITextFame` nesnesi bir veya birden fazla paragraf içerebilir (her paragraf bir satır sonu ile oluşturulur).
* Aspose.Slides, bölümleri temsil eden nesneleri eklemenizi sağlayan [IParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/) arabirimini sunar. Bir `IParagraph` nesnesi bir veya birden fazla bölüm içerebilir (iPortions nesnelerinin koleksiyonu).
* Aspose.Slides, metinleri ve bunların biçimlendirme özelliklerini temsil eden nesneleri eklemenizi sağlayan [IPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/) arabirimini sunar.

Bir `IParagraph` nesnesi, altındaki `IPortion` nesneleri aracılığıyla farklı biçimlendirme özelliklerine sahip metinleri işleyebilir.

## **Birden Çok Metin Bölümü İçeren Birden Çok Paragraf Ekleme**

Bu adımlar, 3 paragraf ve her paragrafta 3 bölüm içeren bir metin çerçevesi eklemenizi gösterir:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına dizini aracılığıyla erişin.
3. Slayta bir Dikdörtgen [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
4. [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ile ilişkili ITextFrame'i alın.
5. İki [IParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/) nesnesi oluşturun ve bunları [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) üzerindeki `IParagraphs` koleksiyonuna ekleyin.
6. Her yeni `IParagraph` için üç [IPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/) nesnesi oluşturun (varsayılan Paragraf için iki Portion nesnesi) ve her `IPortion` nesnesini ilgili `IParagraph`'ın IPortion koleksiyonuna ekleyin.
7. Her bölüm için bazı metinler ayarlayın.
8. `IPortion` nesnesi tarafından sunulan biçimlendirme özelliklerini kullanarak her bölüme tercih ettiğiniz biçimlendirme özelliklerini uygulayın.
9. Değiştirilmiş sunumu kaydedin.

```java
// PPTX dosyasını temsil eden bir Presentation sınıfı örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slayta erişiliyor
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle tipinde bir AutoShape ekle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape'in TextFrame'ine eriş
    ITextFrame tf = ashp.getTextFrame();

    // Farklı metin biçimleriyle Paragraflar ve Bölümler oluştur
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    //PPTX'i diske yaz
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Paragraf Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Madde işaretli paragraflar her zaman daha kolay okunur ve anlaşılır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına dizini aracılığıyla erişin.
3. Seçili slayta bir [autoshape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) öğesine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
7. Paragrafın madde türünü `Symbol` olarak ayarlayın ve madde karakterini belirleyin.
8. Paragrafın `Text` özelliğini ayarlayın.
9. Madde için paragrafın `Indent` değerini ayarlayın.
10. Madde için bir renk belirleyin.
11. Madde için bir yükseklik ayarlayın.
12. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
13. İkinci paragrafı ekleyin ve 7‑13. adımları tekrarlayın.
14. Sunumu kaydedin.

```java
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshape ekler ve erişir
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshape'in metin çerçevesine erişir
    ITextFrame txtFrm = aShp.getTextFrame();

    // Varsayılan paragrafı kaldırır
    txtFrm.getParagraphs().removeAt(0);

    // Bir paragraf oluşturur
    Paragraph para = new Paragraph();

    // Paragraf madde işareti stilini ve sembolünü ayarlar
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Paragraf metnini ayarlar
    para.setText("Welcome to Aspose.Slides");

    // Madde işareti girintisini ayarlar
    para.getParagraphFormat().setIndent(25);

    // Madde işareti rengini ayarlar
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // kendi madde işareti rengini kullanmak için IsBulletHardColor'ı true olarak ayarla

    // Madde işareti yüksekliğini ayarlar
    para.getParagraphFormat().getBullet().setHeight(100);

    // Paragrafı metin çerçevesine ekler
    txtFrm.getParagraphs().add(para);

    // İkinci paragrafı oluşturur
    Paragraph para2 = new Paragraph();

    // Paragraf madde işareti tipini ve stilini ayarlar
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Paragraf metnini ekler
    para2.setText("This is numbered bullet");

    // Madde işareti girintisini ayarlar
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // kendi madde işareti rengini kullanmak için IsBulletHardColor'ı true olarak ayarla

    // Madde işareti yüksekliğini ayarlar
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Paragrafı metin çerçevesine ekler
    txtFrm.getParagraphs().add(para2);
    
    // Değiştirilmiş sunumu kaydeder
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Resim Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Resim paragrafları kolay okunur ve anlaşılır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına dizini aracılığıyla erişin.
3. Slayta bir [autoshape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) öğesine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
7. [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) içinde resmi yükleyin.
8. Madde türünü [Picture](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) olarak ayarlayın ve resmi belirleyin.
9. Paragrafın `Text` özelliğini ayarlayın.
10. Madde için paragrafın `Indent` değerini ayarlayın.
11. Madde için bir renk belirleyin.
12. Madde için bir yükseklik ayarlayın.
13. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
14. İkinci paragrafı ekleyin ve önceki adımlara göre işlemi tekrarlayın.
15. Değiştirilmiş sunumu kaydedin.

```java
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
Presentation presentation = new Presentation();
try {
    // İlk slayta erişir
    ISlide slide = presentation.getSlides().get_Item(0);

    // Madde işaretleri için resmi örnekler
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Autoshape ekler ve erişir
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshape'in metin çerçevesine erişir
    ITextFrame textFrame = autoShape.getTextFrame();

    // Varsayılan paragrafı kaldırır
    textFrame.getParagraphs().removeAt(0);

    // Yeni bir paragraf oluşturur
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Paragraf madde işareti stilini ve resmi ayarlar
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Madde işareti yüksekliğini ayarlar
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Paragrafı metin çerçevesine ekler
    textFrame.getParagraphs().add(paragraph);

    // Sunumu PPTX dosyası olarak yazar
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Sunumu PPT dosyası olarak yazar
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Çok Seviyeli Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Çok seviyeli maddeler okunması ve anlaşılması kolaydır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına dizini aracılığıyla erişin.
3. Yeni slayta bir [autoshape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) öğesine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraph/) sınıfı aracılığıyla ilk paragraf örneğini oluşturun ve derinliği 0 olarak ayarlayın.
7. `Paragraph` sınıfı aracılığıyla ikinci paragraf örneğini oluşturun ve derinliği 1 olarak ayarlayın.
8. `Paragraph` sınıfı aracılığıyla üçüncü paragraf örneğini oluşturun ve derinliği 2 olarak ayarlayın.
9. `Paragraph` sınıfı aracılığıyla dördüncü paragraf örneğini oluşturun ve derinliği 3 olarak ayarlayın.
10. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
11. Değiştirilmiş sunumu kaydedin.

```java
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshape ekler ve erişir
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Oluşturulan autoshape'in metin çerçevesine erişir
    ITextFrame text = aShp.addTextFrame("");

    // Varsayılan paragrafı temizler
    text.getParagraphs().clear();

    // İlk paragrafı ekler
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Madde işareti seviyesini ayarlar
    para1.getParagraphFormat().setDepth((short)0);

    // İkinci paragrafı ekler
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Madde işareti seviyesini ayarlar
    para2.getParagraphFormat().setDepth((short)1);

    // Üçüncü paragrafı ekler
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Madde işareti seviyesini ayarlar
    para3.getParagraphFormat().setDepth((short)2);

    // Dördüncü paragrafı ekler
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Madde işareti seviyesini ayarlar
    para4.getParagraphFormat().setDepth((short)3);

    // Paragrafları koleksiyona ekler
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Sunumu PPTX dosyası olarak yazar
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Özel Numaralı Liste İçeren Paragrafı Yönetme**

[IBulletFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/) arabirimi, `NumberedBulletStartWith` özelliği ve benzeri özellikler aracılığıyla özel numaralandırma veya biçimlendirme içeren paragrafları yönetmenizi sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Paragrafın bulunduğu slayta erişin.
3. Slayta bir [autoshape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) öğesine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraph/) sınıfı aracılığıyla ilk paragraf örneğini oluşturun ve [NumberedBulletStartWith](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) değerini 2 olarak ayarlayın.
7. `Paragraph` sınıfı aracılığıyla ikinci paragrafı oluşturun ve `NumberedBulletStartWith` değerini 3 olarak ayarlayın.
8. `Paragraph` sınıfı aracılığıyla üçüncü paragrafı oluşturun ve `NumberedBulletStartWith` değerini 7 olarak ayarlayın.
9. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
10. Değiştirilmiş sunumu kaydedin.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Oluşturulan autoshape'in metin çerçevesine erişir
    ITextFrame textFrame = shape.getTextFrame();

    // Varsayılan var olan paragrafı kaldırır
    textFrame.getParagraphs().removeAt(0);

    // İlk liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Paragraf İçin İlk Satır Girintisi Ayarlama**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) yöntemini kullanarak bir paragrafın ilk satır girintisini kontrol edebilirsiniz. Bu yöntem yalnızca paragrafın sol kenar boşluğuna göre ilk satırı kaydırır. Pozitif bir değer ilk satırı sağa, kalan satırlar ise paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak istediğinizde [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) kullanın. Yalnızca ilk satırı taşımak istediğinizde ise [IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) kullanın.

Aşağıdaki örnek, çeşitli paragraflar oluşturur ve farklı girinti değerleri uygulayarak ilk satır girintisinin paragraf düzenini nasıl etkilediğini gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Birkaç paragraf oluşturun ve her biri için farklı [Indent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Sonuç:

![Paragrafların ilk satır girintisi](first_line_indent.png)

## **Bir Paragraf İçin Asılı Girinti Ayarlama**

Asılı girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi [IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) yöntemiyle oluşturursunuz. Girintiyi negatif bir değer olarak ayarlarsanız, ilk satır paragraf gövdesine göre sola kayar.

Pratikte, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) paragraf gövdesinin sol konumunu belirlerken, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) bu marjın göre ilk satırın konumunu tanımlar. Asılı girinti oluşturmak için pozitif bir `MarginLeft` ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografyalar, referanslar, sözlük girişleri ve satırların paragraf gövdesi altında hizalanması gereken diğer paragraflar için faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Her paragraf için pozitif bir [MarginLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) değeri ayarlayın.
6. Asılı girinti etkisini oluşturmak için negatif bir [Indent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) değeri ayarlayın.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Sonuç:

![Paragrafların asılı girintisi](hanging_indent.png)

## **Paragraf Son Çalışma Özelliklerini Yönetme**

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Paragrafın bulunduğu slayta konumundan referans alın.
1. Slayta bir dikdörtgen [autoshape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Dikdörtgene iki paragraf içeren bir [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) ekleyin.
1. Paragrafların `FontHeight` ve font tipini ayarlayın.
1. Paragrafların End (son) özelliklerini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Paragraflara HTML Metni Aktarma**

Aspose.Slides, HTML metinlerini paragraflara aktarmak için gelişmiş destek sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına dizini aracılığıyla erişin.
3. Slayta bir [autoshape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
4. `autoshape` üzerine [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) ekleyin ve erişin.
5. `ITextFrame` içindeki varsayılan paragrafı kaldırın.
6. Kaynak HTML dosyasını bir TextReader ile okuyun.
7. [Paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraph/) sınıfı aracılığıyla ilk paragraf örneğini oluşturun.
8. Okunan TextReader içeriğini TextFrame'in [ParagraphCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraphcollection/) öğesine ekleyin.
9. Değiştirilmiş sunumu kaydedin.

```java
// Boş bir sunum örneği oluştur
Presentation pres = new Presentation();
try {
    // Sunumun varsayılan ilk slaytına eriş
    ISlide slide = pres.getSlides().get_Item(0);

    // HTML içeriğini barındırmak için AutoShape ekleniyor
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Şekle metin çerçevesi ekleniyor
    ashape.addTextFrame("");

    // Eklenen metin çerçevesindeki tüm paragrafları temizle
    ashape.getTextFrame().getParagraphs().clear();

    // StreamReader ile HTML dosyasını yüklüyor
    TextReader tr = new StreamReader("file.html");

    // HTML StreamReader'dan metni metin çerçevesine ekliyor
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Sunumu kaydediyor
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Paragraf Metnini HTML’ye Dışa Aktarma**

Aspose.Slides, paragraflarda bulunan metinleri HTML’ye aktarmak için geliştirilmiş destek sunar.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve istenen sunumu yükleyin.
2. İlgili slaytın referansına dizini aracılığıyla erişin.
3. HTML’ye dışa aktarılacak metni içeren şekle erişin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) öğesine erişin.
5. Bir `StreamWriter` örneği oluşturun ve yeni HTML dosyasını ekleyin.
6. StreamWriter’a bir başlangıç indeksi sağlayın ve tercih ettiğiniz paragrafları dışa aktarın.

```java
// Sunum dosyasını yükle
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Sunumun varsayılan ilk slaytına eriş
    ISlide slide = pres.getSlides().get_Item(0);

    // İstenen indeks
    int index = 0;

    // Eklenen şekle eriş
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Çıktı HTML dosyası oluşturuluyor
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //İlk paragrafı HTML olarak çıkarma
    // Paragraf başlangıç indeksini ve kopyalanacak toplam paragraf sayısını vererek Paragrafların verisini HTML'ye yazma
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Paragrafı Görüntü Olarak Kaydetme**

Bu bölümde, [IParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/) arabirimiyle temsil edilen bir metin paragrafını görüntü olarak kaydetmeyi gösteren iki örnek inceleyeceğiz. Her iki örnek de paragrafı içeren şeklin görüntüsünü [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) arabiriminin `getImage` yöntemleriyle almayı, paragrafın şekil içindeki sınırlarını hesaplamayı ve bitmap görüntüsü olarak dışa aktarmayı içerir. Bu yaklaşımlarla PowerPoint sunumlarından belirli metin bölümlerini ayırıp ayrı görüntüler olarak kaydedebilir ve çeşitli senaryolarda kullanabilirsiniz.

Örnek olarak, bir slide içeren ve ilk şekli üç paragraf içeren bir metin kutusu olan `sample.pptx` adlı bir sunum dosyamız olduğunu varsayalım.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

**Örnek 1**

Bu örnekte ikinci paragrafı bir görüntü olarak alıyoruz. Bunun için sunumun ilk slaydındaki şeklin görüntüsünü çıkarıp, şeklin metin çerçevesindeki ikinci paragrafın sınırlarını hesaplıyoruz. Paragraf daha sonra yeni bir bitmap görüntüsüne yeniden çizilir ve PNG formatında kaydedilir. Bu yöntem, belirli bir paragrafı tam boyut ve biçimlendirme koruyarak ayrı bir görüntü olarak kaydetmeniz gerektiğinde özellikle faydalıdır.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Şekli bellekte bir bitmap olarak kaydet.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Bellekten bir şekil bitmap'i oluştur.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // İkinci paragrafın sınırlarını hesapla.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Çıktı görüntüsü için koordinatları ve boyutu hesapla (minimum boyut - 1x1 piksel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Paragraf bitmap'ini yalnızca elde etmek için şekil bitmap'ini kırp.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Sonuç:

![Paragraf görüntüsü](paragraph_to_image_output.png)

**Örnek 2**

Bu örnekte önceki yöntemi, paragraf görüntüsüne ölçekleme faktörleri ekleyerek genişletiyoruz. Şekil sunumdan çıkarılıyor ve `2` ölçekleme faktörüyle görüntüleniyor. Bu, paragrafı dışa aktarırken daha yüksek çözünürlük sağlar. Paragraf sınırları ölçek dikkate alınarak hesaplanır. Ölçekleme, özellikle yüksek kaliteli baskı malzemelerinde kullanılacak daha detaylı bir görüntü gerektiğinde yararlıdır.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Şekli ölçeklendirme ile bellekte bir bitmap olarak kaydet.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Bellekten bir şekil bitmap'i oluştur.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // İkinci paragrafın sınırlarını hesapla.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Çıktı görüntüsü için koordinatları ve boyutu hesapla (minimum boyut - 1x1 piksel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Paragraf bitmap'ini yalnızca elde etmek için şekil bitmap'ini kırp.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **SSS**

**Bir metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Metin çerçevesinin kaydırma ayarını ([setWrapText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) kullanarak kaydırmayı kapatabilirsiniz; böylece satırlar çerçevenin kenarlarında bölünmez.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl elde edebilirim?**

Paragrafın (ve hatta tek bir bölümün) sınırlayıcı dikdörtgenini alarak slayt üzerindeki kesin konum ve boyutunu öğrenebilirsiniz.

**Paragraf hizalaması (sol/sağ/ortala/iki yana yasla) nerede kontrol edilir?**

[Alignment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) bir paragraf düzeyinde ayardır ve [ParagraphFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraphformat/) içinde bulunur; bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafı etkiler.

**Paragrafın sadece bir kısmı (ör. bir kelime) için yazım denetimi dili ayarlayabilir miyim?**

Evet. Dil, bölüm düzeyinde ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)) ayarlanır; bu sayede tek bir paragrafta birden çok dil bir arada bulunabilir.