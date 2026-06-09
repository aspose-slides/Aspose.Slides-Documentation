---
title: Sunumlarda PHP Kullanarak Yazı Tiplerini Yönet
linktitle: Yazı Tiplerini Yönet
type: docs
weight: 10
url: /tr/php-java/manage-fonts/
keywords:
- yazı tiplerini yönet
- yazı tipi özellikleri
- paragraf
- metin biçimlendirme
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de yazı tiplerini kontrol edin: özel yazı tiplerini gömerek, değiştirerek ve yükleyerek PPT, PPTX ve ODP sunumlarının net, marka güvenli ve tutarlı olmasını sağlayın."
---
## **Yazı Tipi İle İlgili Özellikleri Yönet**
{{% alert color="primary" %}} 

Sunumlar genellikle hem metin hem de görsel içerir. Metin, belirli bölümleri ve kelimeleri vurgulamak ya da kurumsal stillere uymak için çeşitli şekillerde biçimlendirilebilir. Metin biçimlendirme, kullanıcıların sunum içeriğinin görünüm ve hisini değiştirmesine yardımcı olur. Bu makale, Aspose.Slides for PHP via Java kullanarak slaytlardaki paragraf metinlerinin yazı tipi özelliklerini nasıl yapılandıracağını gösterir.

{{% /alert %}} 

Bir paragrafın yazı tipi özelliklerini Aspose.Slides for PHP via Java kullanarak yönetmek için:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksini kullanarak elde edin.
1. [Placeholder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholder/) şekillerine erişin ve bunları [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) olarak tip dönüştürün.
1. [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) tarafından sunulan [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) içinden [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) alın.
1. Paragrafı iki yana yaslayın.
1. Bir [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/)'ın metin [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/)'ına erişin.
1. [FontData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontdata/) kullanarak yazı tipini tanımlayın ve metin [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/)'ının **Font**unu buna göre ayarlayın.
   1. Yazı tipini kalın yapın.
   1. Yazı tipini italik yapın.
1. [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) nesnesi tarafından sunulan [FillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) kullanarak yazı tipi rengini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir. Basit bir sunumu alır ve bir slayttaki yazı tiplerini biçimlendirir. Aşağıdaki ekran görüntüleri giriş dosyasını ve kod parçacıklarının nasıl değiştirdiğini gösterir. Kod, yazı tipini, rengi ve yazı tipi stilini değiştirir.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Şekil: Girdi dosyasındaki metin**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Şekil: Aynı metin güncellenmiş biçimlendirme ile**|

```php
  # Bir PPTX dosyasını temsil eden Presentation nesnesini oluştur
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Slayt konumunu kullanarak bir slayta erişiliyor
    $slide = $pres->getSlides()->get_Item(0);
    # Slayttaki birinci ve ikinci yer tutucuya erişiliyor ve AutoShape olarak tip dönüştürülüyor
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # İlk Paragrafa erişiliyor
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Paragrafı iki yana yasla
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # İlk bölüme (portion) erişiliyor
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Yeni yazı tiplerini tanımla
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Yeni yazı tiplerini bölüme ata
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Yazı tipini kalın yap
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Yazı tipini italik yap
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Yazı tipi rengini ayarla
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # PPTX'i diske kaydet
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Metin Yazı Tipi Özelliklerini Ayarlama**
{{% alert color="primary" %}} 

**Yazı Tipi İle İlgili Özellikleri Yönet** bölümünde belirtildiği gibi, bir paragrafta benzer biçimlendirme stiline sahip metni tutmak için bir [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) kullanılır. Bu makale, Aspose.Slides for PHP via Java kullanarak içinde metin olan bir metin kutusu oluşturmayı ve ardından belirli bir yazı tipi ve yazı tipi ailesi kategorisinin çeşitli diğer özelliklerini tanımlamayı gösterir.

{{% /alert %}} 

Bir metin kutusu oluşturmak ve içindeki metnin yazı tipi özelliklerini ayarlamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksini kullanarak elde edin.
1. Slayta **Rectangle** tipinde bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ile ilişkili dolgu stilini kaldırın.
1. [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/)'ın [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)'ine erişin.
1. [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)'e bir metin ekleyin.
1. [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)' ile ilişkili [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) nesnesine erişin.
1. [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) için kullanılacak yazı tipini tanımlayın.
1. [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) nesnesi tarafından sunulan ilgili özellikleri kullanarak kalın, italik, altı çizili, renk ve yükseklik gibi diğer yazı tipi özelliklerini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Yukarıdaki adımların uygulanması aşağıda verilmiştir.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Şekil: Aspose.Slides for PHP via Java tarafından ayarlanan bazı yazı tipi özelliklerine sahip metin**|

```php
  # PPTX dosyasını temsil eden bir Presentation nesnesi oluştur
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $sld = $pres->getSlides()->get_Item(0);
    # Rectangle tipinde bir AutoShape ekle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # AutoShape ile ilişkili herhangi bir dolgu stilini kaldır
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # AutoShape ile ilişkili TextFrame'e eriş
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # TextFrame ile ilişkili Portion'a eriş
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Portion için yazı tipini ayarla
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Yazı tipinin Kalın özelliğini ayarla
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Yazı tipinin İtalik özelliğini ayarla
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Yazı tipinin Altı Çizili özelliğini ayarla
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Yazı tipinin Yüksekliğini ayarla
    $port->getPortionFormat()->setFontHeight(25);
    # Yazı tipinin rengini ayarla
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Sunumu diske kaydet
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```