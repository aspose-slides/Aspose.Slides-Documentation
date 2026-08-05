---
title: JavaScript'te PowerPoint Metin Paragraflarını Yönet
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
  - metin ekle
  - paragraf ekle
  - metni yönet
  - paragrafı yönet
  - madde işaretini yönet
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
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js'i Java üzerinden kullanarak paragraf biçimlendirmesini uzmanlıkla yönetin—JavaScript'te PPT, PPTX ve ODP sunumlarında hizalama, boşluk ve stil optimizasyonu sağlayın."
---
## **Giriş**

Aspose.Slides, Java'da PowerPoint metinleri, paragrafları ve bölümlerle çalışmak için ihtiyaç duyduğunuz tüm sınıfları sağlar.

* Aspose.Slides, bir paragrafı temsil eden nesneler eklemenizi sağlayan [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) sınıfını sunar. Bir `TextFame` nesnesi bir veya birden fazla paragraf içerebilir (her paragraf bir satır sonu ile oluşturulur).
* Aspose.Slides, bölümleri temsil eden nesneler eklemenizi sağlayan [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) sınıfını sunar. Bir `Paragraph` nesnesi bir veya birden fazla bölüm içerebilir (metin bölümü nesnelerinin koleksiyonu).
* Aspose.Slides, metinleri ve biçimlendirme özelliklerini temsil eden nesneler eklemenizi sağlayan [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) sınıfını sunar.

Bir `Paragraph` nesnesi, altında yatan `Portion` nesneleri aracılığıyla farklı biçimlendirme özelliklerine sahip metinleri işleyebilir.

## **Çoklu Bölüm İçeren Çoklu Paragraf Ekleme**

Bu adımlar, 3 paragraf ve her paragrafta 3 bölüm içeren bir metin çerçevesi eklemenizi gösterir:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına diziniyle erişin.
3. Slayta bir Dikdörtgen [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ile ilişkili `ITextFrame` nesnesini alın.
5. İki [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) nesnesi oluşturun ve bunları [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) `IParagraphs` koleksiyonuna ekleyin.
6. Her yeni `Paragraph` için üç [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) nesnesi oluşturun (varsayılan Paragraf için iki Portion nesnesi) ve her `Portion` nesnesini ilgili `Paragraph`ın IPortion koleksiyonuna ekleyin.
7. Her bölüm için bir metin belirleyin.
8. `Portion` nesnesinin sunduğu biçimlendirme özelliklerini kullanarak her bölüme istediğiniz biçimlendirmeyi uygulayın.
9. Değiştirilmiş sunumu kaydedin.

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişim
    var slide = pres.getSlides().get_Item(0);
    // Dikdörtgen tipinde bir AutoShape ekle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // AutoShape'in TextFrame'ine eriş
    var tf = ashp.getTextFrame();
    // Farklı metin biçimleriyle Paragraflar ve Bölümler oluştur
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // PPTX'i diske kaydet
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Paragraf Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Madde işaretli paragraflar her zaman daha kolay okunur ve anlaşılır.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına diziniyle erişin.
3. Seçilen slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. AutoShape'in [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
7. Paragrafın madde işareti `Type`ını `Symbol` olarak ayarlayın ve madde işareti karakterini belirleyin.
8. Paragrafın `Text` özelliğini ayarlayın.
9. Madde işareti için paragraf `Indent` değerini belirleyin.
10. Madde işareti için bir renk ayarlayın.
11. Madde işareti yüksekliğini ayarlayın.
12. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
13. İkinci paragrafı ekleyin ve 7‑13. adımları tekrarlayın.
14. Sunumu kaydedin.

```javascript
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var slide = pres.getSlides().get_Item(0);
    // AutoShape ekler ve ona erişir
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // AutoShape'in metin çerçevesine erişir
    var txtFrm = aShp.getTextFrame();
    // Varsayılan paragrafı kaldırır
    txtFrm.getParagraphs().removeAt(0);
    // Bir paragraf oluşturur
    var para = new aspose.slides.Paragraph();
    // Paragrafın madde işareti stilini ve sembolünü ayarlar
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Paragraf metnini ayarlar
    para.setText("Welcome to Aspose.Slides");
    // Madde işareti girintisini ayarlar
    para.getParagraphFormat().setIndent(25);
    // Madde işareti rengini ayarlar
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// IsBulletHardColor'ı true olarak ayarlar, kendi madde işareti rengini kullanmak için
    // Madde işareti yüksekliğini ayarlar
    para.getParagraphFormat().getBullet().setHeight(100);
    // Paragrafları metin çerçevesine ekler
    txtFrm.getParagraphs().add(para);
    // İkinci paragraf oluşturur
    var para2 = new aspose.slides.Paragraph();
    // Paragrafın madde işareti tipini ve stilini ayarlar
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Paragraf metnini ekler
    para2.setText("This is numbered bullet");
    // Madde işareti girintisini ayarlar
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// IsBulletHardColor'ı true olarak ayarlar, kendi madde işareti rengini kullanmak için
    // Madde işareti yüksekliğini ayarlar
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Paragrafları metin çerçevesine ekler
    txtFrm.getParagraphs().add(para2);
    // Değiştirilmiş sunumu kaydeder
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Resim Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Resimli paragraflar okunması ve anlaşılması kolaydır.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına diziniyle erişin.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. AutoShape'in [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
7. [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) ile resmi yükleyin.
8. Madde işareti tipini [Picture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) olarak ayarlayın ve resmi belirtin.
9. Paragrafın `Text` özelliğini ayarlayın.
10. Madde işareti için paragraf `Indent` değerini belirleyin.
11. Madde işareti için bir renk ayarlayın.
12. Madde işareti yüksekliğini ayarlayın.
13. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
14. İkinci paragrafı ekleyin ve önceki adımlara göre işlemi tekrarlayın.
15. Değiştirilmiş sunumu kaydedin.

```javascript
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
var presentation = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var slide = presentation.getSlides().get_Item(0);
    // Madde işaretleri için görüntüyü örnekler
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // AutoShape ekler ve ona erişir
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // AutoShape'in metin çerçevesine erişir
    var textFrame = autoShape.getTextFrame();
    // Varsayılan paragrafı kaldırır
    textFrame.getParagraphs().removeAt(0);
    // Yeni bir paragraf oluşturur
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Paragrafın madde işareti stilini ve görüntüsünü ayarlar
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Madde işareti yüksekliğini ayarlar
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Paragrafı metin çerçevesine ekler
    textFrame.getParagraphs().add(paragraph);
    // Sunumu PPTX dosyası olarak yazar
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Sunumu PPT dosyası olarak yazar
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Çok Seviyeli Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Çok seviyeli madde işaretleri okunması ve anlaşılması kolaydır.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına diziniyle erişin.
3. Yeni slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. AutoShape'in [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) sınıfını kullanarak ilk paragrafı oluşturun ve derinliği 0 olarak ayarlayın.
7. `Paragraph` sınıfıyla ikinci paragrafı oluşturun ve derinliği 1 olarak ayarlayın.
8. `Paragraph` sınıfıyla üçüncü paragrafı oluşturun ve derinliği 2 olarak ayarlayın.
9. `Paragraph` sınıfıyla dördüncü paragrafı oluşturun ve derinliği 3 olarak ayarlayın.
10. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
11. Değiştirilmiş sunumu kaydedin.

```javascript
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var slide = pres.getSlides().get_Item(0);
    // AutoShape ekler ve ona erişir
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Oluşturulan autoshape'in metin çerçevesine erişir
    var text = aShp.addTextFrame("");
    // Varsayılan paragrafı temizler
    text.getParagraphs().clear();
    // İlk paragrafı ekler
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Madde işareti seviyesini ayarlar
    para1.getParagraphFormat().setDepth(0);
    // İkinci paragrafı ekler
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Madde işareti seviyesini ayarlar
    para2.getParagraphFormat().setDepth(1);
    // Üçüncü paragrafı ekler
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Madde işareti seviyesini ayarlar
    para3.getParagraphFormat().setDepth(2);
    // Dördüncü paragrafı ekler
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Madde işareti seviyesini ayarlar
    para4.getParagraphFormat().setDepth(3);
    // Paragrafları koleksiyona ekler
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Sunumu PPTX dosyası olarak yazar
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Özel Numaralı Liste ile Paragraf Yönetimi**

[BulletFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bulletformat/) sınıfı, `NumberedBulletStartWith` özelliği ve benzeri ayarları sayesinde paragrafları özel numaralandırma veya biçimlendirme ile yönetmenizi sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Paragrafın bulunduğu slayta erişin.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. AutoShape'in [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) sınıfını kullanarak ilk paragrafı oluşturun ve `NumberedBulletStartWith` değerini 2 olarak ayarlayın.
7. `Paragraph` sınıfıyla ikinci paragrafı oluşturun ve `NumberedBulletStartWith` değerini 3 olarak ayarlayın.
8. `Paragraph` sınıfıyla üçüncü paragrafı oluşturun ve `NumberedBulletStartWith` değerini 7 olarak ayarlayın.
9. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
10. Değiştirilmiş sunumu kaydedin.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Oluşturulan autoshape'in metin çerçevesine erişir
    var textFrame = shape.getTextFrame();
    // Varsayılan mevcut paragrafı kaldırır
    textFrame.getParagraphs().removeAt(0);
    // İlk liste
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Bir Paragraf İçin İlk Satır Girintisi Ayarlama**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setindent/) metodunu kullanarak bir paragrafın ilk satır girintisini kontrol edebilirsiniz. Bu metod yalnızca paragrafın sol kenar boşluğuna göre ilk satırı kaydırır. Pozitif bir değer ilk satırı sağa, geri kalan satırlar ise paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak istediğinizde [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) kullanın. Yalnızca ilk satırı taşımak istediğinizde ise [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setindent/) kullanın.

Aşağıdaki örnek, çeşitli paragraflar oluşturur ve farklı girinti değerleri uygulayarak ilk satır girintisinin paragraf düzenine etkisini gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Çeşitli paragraflar oluşturun ve her biri için farklı [Indent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setindent/) değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Sonuç:

![Paragrafların birinci satır girintisi](first_line_indent.png)

## **Bir Paragraf İçin Asılı Girinti Ayarlama**

Asılı girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setindent/) metodu ile elde edersiniz. Girintiyi negatif bir değer olarak ayarlarsanız, ilk satır paragraf gövdesine göre sola kayar.

Uygulamada, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) paragraf gövdesinin sol konumunu, [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setindent/) ise ilk satırın bu kenar boşluğuna göre konumunu belirler. Asılı girinti oluşturmak için pozitif bir `MarginLeft` ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografyalar, referanslar, sözlük girdileri ve sarılmış satırların paragraf gövdesinin altına hizalanması gereken diğer paragraflar için faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her biri için pozitif bir [MarginLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) değeri ayarlayın.
6. Asılı girinti etkisini oluşturmak için negatif bir [Indent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setindent/) değeri ayarlayın.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Sonuç:

![Paragrafların asılı girintisi](hanging_indent.png)

## **Paragrafın Bitiş Çalıştırma Özelliklerini Yönetme**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Paragrafın bulunduğu slayta konumundan erişin.
1. Slayta bir dikdörtgen [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Dikdörtgene iki paragraf içeren bir [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) ekleyin.
1. Paragraflar için `FontHeight` ve Yazı tipi ayarlayın.
1. Paragraflar için Bitiş (End) özelliklerini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **HTML Metnini Paragraflara İçe Aktarma**

Aspose.Slides, HTML metnini paragraflara içe aktarmak için geliştirilmiş destek sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına diziniyle erişin.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. `AutoShape`'in [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine ekleyin ve erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. Kaynak HTML dosyasını bir TextReader ile okuyun.
7. [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
8. Okunan TextReader içeriğini TextFrame'in [ParagraphCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphcollection/) öğesine ekleyin.
9. Değiştirilmiş sunumu kaydedin.

```javascript
// Boş sunum örneği oluştur
var pres = new aspose.slides.Presentation();
try {
    // Sunumun varsayılan ilk slaytına eriş
    var slide = pres.getSlides().get_Item(0);
    // HTML içeriğini barındırmak için AutoShape ekle
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Şekle metin çerçevesi ekle
    ashape.addTextFrame("");
    // Eklenen metin çerçevesindeki tüm paragrafları temizle
    ashape.getTextFrame().getParagraphs().clear();
    // StreamReader kullanarak HTML dosyasını yükle
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // HTML stream okuyucusundan metni metin çerçevesine ekle
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Sunumu kaydet
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Paragrafların Metnini HTML'ye Dışa Aktarma**

Aspose.Slides, paragraflarda bulunan metinleri HTML'ye dışa aktarmak için geliştirilmiş destek sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve istediğiniz sunumu yükleyin.
2. İlgili slaytın referansına diziniyle erişin.
3. HTML'ye dışa aktarılacak metni içeren şekle erişin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.
5. Yeni bir HTML dosyası eklemek için bir `StreamWriter` örneği oluşturun.
6. StreamWriter'a bir başlangıç indeksi verin ve istediğiniz paragrafları dışa aktarın.

```javascript
// Sunum dosyasını yükle
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Sunumun varsayılan ilk slaytına eriş
    var slide = pres.getSlides().get_Item(0);
    // İstenen indeks
    var index = 0;
    // Eklenen şekle eriş
    var ashape = slide.getShapes().get_Item(index);
    // Çıktı HTML dosyası oluştur
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // İlk paragrafı HTML olarak çıkar
    // Paragraf başlangıç indeksi ve kopyalanacak toplam paragraf sayısını belirterek Paragrafların verisini HTML'ye yaz
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bir Paragrafı Görüntü Olarak Kaydetme**

Bu bölümde, [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) sınıfıyle temsil edilen bir metin paragrafını görüntü olarak kaydetmeyi gösteren iki örnek incelenecek. Her iki örnek de, paragrafı içeren şeklin görüntüsünü [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) sınıfının `getImage` yöntemleriyle almayı, paragrafın şekil içinde bulunan sınırlarını hesaplamayı ve bunu bitmap görüntüsü olarak dışa aktarmayı içerir. Bu yaklaşımlar, PowerPoint sunumlarından belirli metin bölümlerini ayırıp ayrı görüntüler olarak kaydetmenize olanak tanır; bu da farklı senaryolarda yeniden kullanım için faydalı olabilir.

Örnek dosyamızın adı **sample.pptx** ve içinde bir slayt bulunuyor; ilk şekil üç paragraf içeren bir metin kutusudur.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

**Örnek 1**

Bu örnekte ikinci paragraf bir görüntü olarak elde edilir. Bunun için sunumun ilk slaydındaki şeklin görüntüsü alınır, ardından şeklin metin çerçevesindeki ikinci paragrafın sınırları hesaplanır. Paragraf daha sonra yeni bir bitmap görüntüsüne çizilir ve PNG formatında kaydedilir. Bu yöntem, belirli bir paragrafı aynı boyut ve biçimlendirme ile ayrı bir görüntü olarak kaydetmek istediğinizde özellikle yararlıdır.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Şekli bellek içinde bitmap olarak kaydet.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Bellekten bir şekil bitmap'i oluştur.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // İkinci paragrafın sınırlarını hesapla.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Çıktı görüntüsü için koordinatları ve boyutu hesapla (minimum boyut - 1x1 piksel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Şekil bitmap'ini kırparak yalnızca paragraf bitmap'ini al.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Sonuç:

![Paragraf görüntüsü](paragraph_to_image_output.png)

**Örnek 2**

Bu örnekte önceki yaklaşıma ölçek faktörleri eklenir. Şekil, `2` ölçek faktörüyle görüntü olarak alınır, bu da paragrafı dışa aktarırken daha yüksek çözünürlük sağlar. Paragraf sınırları ölçek dikkate alınarak hesaplanır. Ölçekleme, özellikle yüksek kaliteli baskı materyalleri gibi daha detaylı bir görüntü gerektiğinde faydalıdır.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Ölçeklendirme ile şekli bellek içinde bitmap olarak kaydet.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Bellekten bir şekil bitmap'i oluştur.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // İkinci paragrafın sınırlarını hesapla.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Çıktı görüntüsü için koordinatları ve boyutu hesapla (minimum boyut - 1x1 piksel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Şekil bitmap'ini kırparak yalnızca paragraf bitmap'ini al.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **SSS**

**Bir metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Metin çerçevesinin kaydırma ayarını ([setWrapText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/setwraptext/)) kullanarak kaydırmayı kapatabilir, böylece satırlar çerçevenin kenarlarında kesilmez.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl alabilirim?**

Paragrafın (ve hatta tek bir bölümün) sınırlayıcı dikdörtgenini alarak slayt üzerindeki kesin konum ve boyutunu öğrenebilirsiniz.

**Paragraf hizalaması (sol/sağ/ortala/iki yana yasla) nerede kontrol edilir?**

[setAlignment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setalignment/) metodu, [ParagraphFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/) içinde paragraf seviyesinde bir ayardır; bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafa uygulanır.

**Paragrafın sadece bir kısmı (ör. tek bir kelime) için imla denetimi dili ayarlayabilir miyim?**

Evet. Dil, bölüm seviyesinde ayarlandığı için ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)) bir paragrafta birden fazla dil aynı anda bulunabilir.