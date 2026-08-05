---
title: PowerPoint Metin Paragraflarını PHP'de Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
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
- paragraf dışa aktar
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile paragraf biçimlendirmesini ustalaştırın — PPT, PPTX ve ODP sunumlarında hizalama, boşluk ve stili optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint metinleri, paragrafları ve bölümleriyle çalışmak için ihtiyacınız olan tüm sınıfları sağlar.

* Aspose.Slides, bir paragrafı temsil eden nesneler eklemenizi sağlayan [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) sınıfını sunar. Bir `TextFame` nesnesi bir veya birden fazla paragraf içerebilir (her paragraf bir satır sonu ile oluşturulur).
* Aspose.Slides, bölümleri temsil eden nesneler eklemenizi sağlayan [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) sınıfını sunar. Bir `Paragraph` nesnesi bir veya birden fazla bölüm içerebilir (bölüm nesnelerinin koleksiyonu).
* Aspose.Slides, metinleri ve bunların biçimlendirme özelliklerini temsil eden nesneler eklemenizi sağlayan [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) sınıfını sunar.

`Paragraph` nesnesi, altında yatan `Portion` nesneleri aracılığıyla farklı biçimlendirme özelliklerine sahip metinleri işleyebilir.

## **Birden Çok Bölüm İçeren Birden Çok Paragraf Ekleme**

Bu adımlar, 3 paragraf içeren ve her paragrafın 3 bölüm içeren bir metin çerçevesi eklemeyi gösterir:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına indeks üzerinden erişin.
3. Slayta bir Dikdörtgen [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ile ilişkili ITextFrame'i alın.
5. İki [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) nesnesi oluşturun ve bunları [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)'in paragraf koleksiyonuna ekleyin.
6. Her yeni `Paragraph` için üç [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) nesnesi oluşturun (varsayılan Paragraf için iki Portion nesnesi) ve her `Portion` nesnesini ilgili `Paragraph`'ın bölüm koleksiyonuna ekleyin.
7. Her bölüm için bazı metinler ayarlayın.
8. `Portion` nesnesinin sunduğu biçimlendirme özelliklerini kullanarak her bölüme tercih ettiğiniz biçimlendirme özelliklerini uygulayın.
9. Değiştirilmiş sunumu kaydedin.

Bu PHP kodu, bölümler içeren paragrafları eklemek için adımların bir uygulamasıdır:

```php
# Bir PPTX dosyasını temsil eden Presentation sınıfını örnekleyin
$pres = new Presentation();
try {
    # İlk slayta erişiliyor
    $slide = $pres->getSlides()->get_Item(0);
    # Dikdörtgen tipinde bir AutoShape ekleyin
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # AutoShape'in TextFrame'ine erişin
    $tf = $ashp->getTextFrame();
    # Farklı metin biçimleriyle Paragraflar ve Bölümler oluşturun
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # PPTX'i diske kaydedin
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Paragraf Madde İşaretlerini Yönetme**

Madde işareti listeleri, bilgileri hızlı ve etkili bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Madde işaretli paragraflar her zaman daha kolay okunur ve anlaşılır.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına indeks üzerinden erişin.
3. Seçilen slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. AutoShape'in [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)’ine erişin.
5. `TextFrame`'deki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
7. Paragrafın madde işareti `Type`'ını `Symbol` olarak ayarlayın ve madde işareti karakterini belirleyin.
8. Paragrafın `Text`'ini ayarlayın.
9. Madde işareti için paragraf `Indent`'ini ayarlayın.
10. Madde işareti için bir renk ayarlayın.
11. Madde işaretinin yüksekliğini ayarlayın.
12. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
13. İkinci paragrafı ekleyin ve adım 7'den 13'e verilen süreci tekrarlayın.
14. Sunumu kaydedin.

Bu PHP kodu, bir paragraf madde işareti eklemeyi gösterir:

```php
# PPTX dosyasını temsil eden Presentation sınıfını örnekler
$pres = new Presentation();
try {
    # İlk slayta erişir
    $slide = $pres->getSlides()->get_Item(0);
    # Autoshape ekler ve ona erişir
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Autoshape'in metin çerçevesine erişir
    $txtFrm = $aShp->getTextFrame();
    # Varsayılan paragrafı kaldırır
    $txtFrm->getParagraphs()->removeAt(0);
    # Bir paragraf oluşturur
    $para = new Paragraph();
    # Paragraf mermi stilini ve simgesini ayarlar
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Paragraf metnini ayarlar
    $para->setText("Welcome to Aspose.Slides");
    # Mermi girintisini ayarlar
    $para->getParagraphFormat()->setIndent(25);
    # Mermi rengini ayarlar
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// Kendi mermi rengini kullanmak için IsBulletHardColor'ı true olarak ayarla

    # Mermi yüksekliğini ayarlar
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Paragrafı metin çerçevesine ekler
    $txtFrm->getParagraphs()->add($para);
    # İkinci paragrafı oluşturur
    $para2 = new Paragraph();
    # Paragraf mermi tipini ve stilini ayarlar
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Paragraf metnini ekler
    $para2->setText("This is numbered bullet");
    # Mermi girintisini ayarlar
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// Kendi mermi rengini kullanmak için IsBulletHardColor'ı true olarak ayarla

    # Mermi yüksekliğini ayarlar
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Paragrafı metin çerçevesine ekler
    $txtFrm->getParagraphs()->add($para2);
    # Değiştirilmiş sunumu kaydeder
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Resim Madde İşaretlerini Yönetme**

Madde işareti listeleri, bilgileri hızlı ve etkili bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Resim paragrafları okunması ve anlaşılması kolaydır.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına indeks üzerinden erişin.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. AutoShape'in [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)’ine erişin.
5. `TextFrame`'deki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
7. [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) içinde resmi yükleyin.
8. Madde işareti türünü [Picture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bullettype/#Picture) olarak ayarlayın ve resmi belirleyin.
9. Paragrafın `Text`'ini ayarlayın.
10. Madde işareti için paragraf `Indent`'ini ayarlayın.
11. Madde işareti için bir renk ayarlayın.
12. Madde işaretinin yüksekliğini ayarlayın.
13. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
14. İkinci paragrafı ekleyin ve önceki adımlara göre süreci tekrarlayın.
15. Değiştirilmiş sunumu kaydedin.

```php
# PPTX dosyasını temsil eden Presentation sınıfını örnekler
$presentation = new Presentation();
try {
    # İlk slayta erişir
    $slide = $presentation->getSlides()->get_Item(0);
    # Madde imleçleri için resmi oluşturur
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Autoshape ekler ve ona erişir
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Autoshape'in metin çerçevesine erişir
    $textFrame = $autoShape->getTextFrame();
    # Varsayılan paragrafı kaldırır
    $textFrame->getParagraphs()->removeAt(0);
    # Yeni bir paragraf oluşturur
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Paragrafın madde imleç stili ve resmini ayarlar
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Madde imleç yüksekliğini ayarlar
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Paragrafı metin çerçevesine ekler
    $textFrame->getParagraphs()->add($paragraph);
    # Sunumu PPTX dosyası olarak yazar
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Sunumu PPT dosyası olarak yazar
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Çok Düzeyli Madde İşaretlerini Yönetme**

Madde işareti listeleri, bilgileri hızlı ve etkili bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Çok düzeyli madde işaretleri okunması ve anlaşılması kolaydır.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına indeks üzerinden erişin.
3. Yeni slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. AutoShape'in [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)’ine erişin.
5. `TextFrame`'deki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) sınıfı aracılığıyla ilk paragraf örneğini oluşturun ve derinliği 0 olarak ayarlayın.
7. `Paragraph` sınıfı aracılığıyla ikinci paragrafı oluşturun ve derinliği 1 olarak ayarlayın.
8. `Paragraph` sınıfı aracılığıyla üçüncü paragrafı oluşturun ve derinliği 2 olarak ayarlayın.
9. `Paragraph` sınıfı aracılığıyla dördüncü paragrafı oluşturun ve derinliği 3 olarak ayarlayın.
10. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
11. Değiştirilmiş sunumu kaydedin.

```php
# PPTX dosyasını temsil eden Presentation sınıfını örnekler
$pres = new Presentation();
try {
    # İlk slayta erişir
    $slide = $pres->getSlides()->get_Item(0);
    # Autoshape ekler ve ona erişir
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Oluşturulan autoshape'in metin çerçevesine erişir
    $text = $aShp->addTextFrame("");
    # Varsayılan paragrafı temizler
    $text->getParagraphs()->clear();
    # İlk paragrafı ekler
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Mermi seviyesini ayarlar
    $para1->getParagraphFormat()->setDepth(0);
    # İkinci paragrafı ekler
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Mermi seviyesini ayarlar
    $para2->getParagraphFormat()->setDepth(1);
    # Üçüncü paragrafı ekler
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Mermi seviyesini ayarlar
    $para3->getParagraphFormat()->setDepth(2);
    # Dördüncü paragrafı ekler
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Mermi seviyesini ayarlar
    $para4->getParagraphFormat()->setDepth(3);
    # Paragrafları koleksiyona ekler
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Sunumu PPTX dosyası olarak yazar
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Özel Numaralı Liste İçeren Paragrafı Yönetme**

[BulletFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/) sınıfı, özelleştirilmiş numaralandırma veya biçimlendirme içeren paragrafları yönetmenizi sağlayan [setNumberedBulletStartWith](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) yöntemi ve diğerlerini sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Paragrafı içeren slayta erişin.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. AutoShape'in [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)’ine erişin.
5. `TextFrame`'deki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) sınıfı aracılığıyla ilk paragrafı oluşturun ve [NumberedBulletStartWith](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) değerini 2 olarak ayarlayın.
7. `Paragraph` sınıfı aracılığıyla ikinci paragrafı oluşturun ve `NumberedBulletStartWith` değerini 3 olarak ayarlayın.
8. `Paragraph` sınıfı aracılığıyla üçüncü paragrafı oluşturun ve `NumberedBulletStartWith` değerini 7 olarak ayarlayın.
9. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
10. Değiştirilmiş sunumu kaydedin.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Oluşturulan autoshape'in metin çerçevesine erişir
    $textFrame = $shape->getTextFrame();
    # Varsayılan mevcut paragrafı kaldırır
    $textFrame->getParagraphs()->removeAt(0);
    # İlk liste
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Paragraf İçin İlk Satır Girintisi Ayarlama**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setindent/) yöntemini kullanarak bir paragrafın ilk satır girintisini kontrol edin. Bu yöntem sadece paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırır, geri kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı hareket ettirmeniz gerektiğinde [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setmarginleft/) kullanın. Sadece ilk satırı hareket ettirmeniz gerektiğinde [ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setindent/) kullanın.

Aşağıdaki örnek, birden fazla paragraf oluşturur ve ilk satır girintisinin paragraf düzenine nasıl etki ettiğini göstermek için farklı girinti değerleri uygular.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Birkaç paragraf oluşturun ve onlara farklı [Indent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setindent/) değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

Bu kod, bir paragraf girintisinin nasıl ayarlanacağını gösterir:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Paragraf İçin Asılı Girintiyi Ayarlama**

Asılı girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi [ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setindent/) yöntemiyle oluşturursunuz. Girintiyi negatif bir değere ayarlayarak ilk satırı paragraf gövdesine göre sola kaydırabilirsiniz.

Uygulamada, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setmarginleft/) paragraf gövdesinin sol konumunu tanımlar ve [ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setindent/) bu kenar boşluğuna göre ilk satırın konumunu belirler. Asılı bir girinti oluşturmak için pozitif bir `MarginLeft` değeri ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografyalar, referanslar, sözlük girişleri ve satır sonlarının paragraf gövdesi altında, ilk satırın ilk karakteri altında değil, hizalanması gereken diğer paragraflar için faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her birine pozitif bir [MarginLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setmarginleft/) değeri ayarlayın.
6. Asılı girinti etkisini oluşturmak için negatif bir [Indent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setindent/) değeri ayarlayın.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

Bu kod, bir paragraf için asılı girintinin nasıl ayarlanacağını gösterir:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Paragraf Sonu Çalışma Özelliklerini Yönetme**

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Paragrafı içeren slaydın referansını konumuna göre alın.
3. Slayta bir dikdörtgen [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. Dikdörtgene iki paragraf içeren bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) ekleyin.
5. Paragraflar için yazı tipi yüksekliğini ve Yazı tipi türünü ayarlayın.
6. Paragraflar için End özelliklerini ayarlayın.
7. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu PHP kodu, PowerPoint'te paragraflar için End özelliklerini nasıl ayarlayacağınızı gösterir:

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **HTML Metnini Paragraflara İçe Aktarma**

Aspose.Slides, HTML metnini paragraflara içe aktarmak için geliştirilmiş destek sunar.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansına indeks üzerinden erişin.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. `AutoShape`'in [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)’ini ekleyin ve ona erişin.
5. `TextFrame`'deki varsayılan paragrafı kaldırın.
6. Kaynak HTML dosyasını bir TextReader ile okuyun.
7. [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) sınıfı aracılığıyla ilk paragraf örneğini oluşturun.
8. Okunan TextReader'dan HTML dosyası içeriğini TextFrame'in [ParagraphCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphcollection/)’ine ekleyin.
9. Değiştirilmiş sunumu kaydedin.

Bu PHP kodu, HTML metinlerini paragraflara içe aktarma adımlarının bir uygulamasıdır:

```php
# Boş sunum örneği oluştur
$pres = new Presentation();
try {
    # Sunumun varsayılan ilk slaytına eriş
    $slide = $pres->getSlides()->get_Item(0);
    # HTML içeriğini barındırmak için AutoShape ekle
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Şekle metin çerçevesi ekle
    $ashape->addTextFrame("");
    # Eklenen metin çerçevesindeki tüm paragrafları temizle
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Stream reader kullanarak HTML dosyasını yükle
    $tr = new StreamReader("file.html");
    # HTML stream reader'dan metni metin çerçevesine ekle
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Sunumu kaydet
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Paragraf Metnini HTML'ye Dışa Aktarma**

Aspose.Slides, metinleri (paragraflarda bulunan) HTML'ye dışa aktarmak için geliştirilmiş destek sunar.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve istediğiniz sunumu yükleyin.
2. İlgili slaytın referansına indeks üzerinden erişin.
3. HTML'ye dışa aktarılacak metni içeren şekle erişin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)’ine erişin.
5. `StreamWriter` örneği oluşturun ve yeni HTML dosyasını ekleyin.
6. StreamWriter'a bir başlangıç indeksi sağlayın ve tercih ettiğiniz paragrafları dışa aktarın.

Bu PHP kodu, PowerPoint paragraf metinlerini HTML'ye dışa aktarmayı gösterir:

```php
# Sunum dosyasını yükle
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Sunumun varsayılan ilk slaytına eriş
    $slide = $pres->getSlides()->get_Item(0);
    # İstenen indeks
    $index = 0;
    # Eklenen şekle erişiliyor
    $ashape = $slide->getShapes()->get_Item($index);
    # Çıktı HTML dosyası oluşturuluyor
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # İlk paragrafı HTML olarak çıkarma
    # Paragrafların verisini, başlangıç indeksi ve kopyalanacak toplam paragraf sayısı sağlanarak HTML'ye yazma
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Paragrafı Görüntü Olarak Kaydetme**

Bu bölümde, [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) sınıfı tarafından temsil edilen bir metin paragrafını görüntü olarak kaydetmeyi gösteren iki örneği inceleyeceğiz. Her iki örnek de paragrafı içeren şeklin görüntüsünü [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfının `getImage` yöntemleriyle elde etmeyi, paragrafın şekil içindeki sınırlarını hesaplamayı ve bunu bitmap görüntüsü olarak dışa aktarmayı içerir. Bu yaklaşımlar, PowerPoint sunumlarından metnin belirli bölümlerini çıkartıp ayrı görüntüler olarak kaydetmenizi sağlar; bu, çeşitli senaryolarda daha sonraki kullanım için faydalı olabilir.

sample.pptx adlı bir sunum dosyamızın bir slaytı olduğunu ve ilk şeklin üç paragraf içeren bir metin kutusu olduğunu varsayalım.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

Bu örnekte, ikinci paragrafı bir görüntü olarak elde ediyoruz. Bunu yapmak için, sunumun ilk slaydındaki şeklin görüntüsünü çıkarıyor ve ardından şeklin metin çerçevesindeki ikinci paragrafın sınırlarını hesaplıyoruz. Paragraf daha sonra yeni bir bitmap görüntüsü üzerine yeniden çizilir ve PNG formatında kaydedilir. Bu yöntem, metnin tam boyutlarını ve biçimlendirmesini koruyarak belirli bir paragrafı ayrı bir görüntü olarak kaydetmeniz gerektiğinde özellikle yararlıdır.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Şekli bellekte bitmap olarak kaydet.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Bellekten bir şekil bitmap'i oluştur.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // İkinci paragrafın sınırlarını hesapla.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Çıktı görüntüsü için koordinatları ve boyutu hesapla (minimum boyut - 1x1 piksel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Şekil bitmap'ini kırparak sadece paragraf bitmap'ini al.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sonuç:

![The paragraph image](paragraph_to_image_output.png)

**Example 2**

Bu örnekte, paragraf görüntüsüne ölçek faktörleri ekleyerek önceki yaklaşımı genişletiyoruz. Şekil sunumdan çıkarılır ve `2` ölçek faktörüyle bir görüntü olarak kaydedilir. Bu, paragrafı dışa aktarırken daha yüksek çözünürlüklü bir çıktı sağlar. Paragraf sınırları, ölçek dikkate alınarak hesaplanır. Ölçeklendirme, özellikle yüksek kaliteli basılı materyallerde kullanılmak üzere daha ayrıntılı bir görüntü gerektiğinde faydalı olur.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Şekli bellekte ölçekle bitmap olarak kaydet.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Bellekten bir şekil bitmap'i oluştur.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // İkinci paragrafın sınırlarını hesapla.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Çıktı görüntüsü için koordinatları ve boyutu hesapla (minimum boyut - 1x1 piksel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Şekil bitmap'ini kırparak sadece paragraf bitmap'ini al.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Satır kaydırmayı kapatmak için metin çerçevesinin kaydırma ayarını ([setWrapText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/setwraptext/)) kullanın; böylece satırlar çerçevenin kenarlarında bölünmez.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl alabilirim?**

Paragrafın (ve hatta tek bir bölümün) sınırlayıcı dikdörtgenini alarak, slayt üzerindeki kesin konum ve boyutunu öğrenebilirsiniz.

**Paragraf hizalaması (sol/sağ/ortala/iki yana yasla) nerede kontrol edilir?**

[Alignment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/setalignment/) [ParagraphFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/) içinde bir paragraf düzeyinde ayardır; bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafa uygulanır.

**Paragrafın sadece bir kısmı (örneğin bir kelime) için imla dili ayarlayabilir miyim?**

Evet. Dil, bölüm düzeyinde ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId)) ayarlandığından, tek bir paragrafta birden fazla dil bir arada bulunabilir.