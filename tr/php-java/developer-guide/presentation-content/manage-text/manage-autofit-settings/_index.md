---
title: PHP'de AutoFit ile Sunumlarınızı Geliştirin
linktitle: Autofit Ayarları
type: docs
weight: 30
url: /tr/php-java/manage-autofit-settings/
keywords:
- metin kutusu
- otomatik sığdırma
- otomatik sığdırma kullanma
- metni sığdır
- metni küçült
- metni kaydır
- şekli yeniden boyutlandır
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PHP için Aspose.Slides'te AutoFit ayarlarını yöneterek PowerPoint ve OpenDocument sunumlarınızdaki metin görüntülenmesini optimize edin ve içerik okunabilirliğini artırın."
---
## **Giriş**

Varsayılan olarak, bir metin kutusu eklediğinizde Microsoft PowerPoint, metin kutusu için **Resize shape to fix text** ayarını kullanır—metnin her zaman kutuya sığmasını sağlamak için metin kutusunu otomatik olarak yeniden boyutlandırır. 

![PowerPoint'te metin kutusu](textbox-in-powerpoint.png)

* Metin kutusundaki metin daha uzun veya büyük olduğunda, PowerPoint metin kutusunu otomatik olarak büyütür—yüksekliğini artırır—daha fazla metin tutabilmesi için. 
* Metin kutusundaki metin daha kısa veya küçük olduğunda, PowerPoint metin kutusunu otomatik olarak küçültür—yüksekliğini azaltır—gereksiz boşluğu temizler. 

PowerPoint'te, bir metin kutusunun otomatik sığdırma davranışını kontrol eden 4 önemli parametre veya seçenek şunlardır: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![PowerPoint otomatik sığdırma seçenekleri](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java, [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TextFrameFormat) sınıfı altındaki bazı özellikler—sunumlarda metin kutularının otomatik sığdırma davranışını kontrol etmenizi sağlayan—benzer seçenekler sunar.

## **Bir Şekli Metne Uygun Olarak Yeniden Boyutlandırma**

Metnin her zaman kutuya sığmasını istiyorsanız **Resize shape to fix text** seçeneğini kullanmanız gerekir. Bu ayarı belirtmek için, [AutofitType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TextFrameFormat#getAutofitType--) özelliğini ( [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TextFrameFormat) sınıfından) `Shape` değerine ayarlayın.

![PowerPoint'te her zaman sığdırma ayarı](alwaysfit-setting-powerpoint.png)

Bu PHP kodu, bir metnin PowerPoint sunumunda her zaman kutusuna sığmasını nasıl belirteceğinizi gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Metin daha uzun veya büyük olursa, metin kutusu otomatik olarak yeniden boyutlandırılır (yüksekliği artar) ve tüm metnin sığması sağlanır. Metin daha kısa olursa, ters işlem gerçekleşir. 

## **Otomatik Sığdırma Kullanma**

Bir metin kutusunun veya şeklinin, içindeki metin değişse bile boyutlarını korumasını istiyorsanız **Do not Autofit** seçeneğini kullanmanız gerekir. Bu ayarı belirtmek için, [AutofitType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TextFrameFormat#getAutofitType--) özelliğini ( [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TextFrameFormat) sınıfından) `None` değerine ayarlayın.

![PowerPoint'te otomatik sığdırma kullanılmıyor ayarı](donotautofit-setting-powerpoint.png)

Bu PHP kodu, bir metin kutusunun PowerPoint sunumunda boyutlarını her zaman korumasını nasıl belirteceğinizi gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Metin kutusunun kutusuna sığamayacak kadar uzun olduğunda, metin dışarı taşar. 

## **Taşkınlıkta Metni Küçült**

Bir metin kutusunun, kutusuna sığamayacak kadar uzun olması durumunda, **Shrink text on overflow** seçeneği sayesinde metnin boyutu ve satır aralığının küçülmesini belirtebilirsiniz. Bu ayarı belirtmek için, [AutofitType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TextFrameFormat#getAutofitType--) özelliğini ( [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TextFrameFormat) sınıfından) `Normal` değerine ayarlayın.

![PowerPoint'te taşkınlıkta metni küçültme ayarı](shrinktextonoverflow-setting-powerpoint.png)

Bu PHP kodu, bir metnin PowerPoint sunumunda taşkınlıkta küçültülmesini nasıl belirteceğinizi gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
**Shrink text on overflow** seçeneği kullanıldığında, ayar yalnızca metin kutusuna sığamayacak kadar uzun olduğunda uygulanır. 
{{% /alert %}}

## **Metni Kaydır**

Bir şeklin içindeki metnin, metin şeklinin kenarını (yalnızca genişlik) aştığında şekil içinde satır sonu almasını istiyorsanız **Wrap text in shape** parametresini kullanmalısınız. Bu ayarı belirtmek için, [WrapText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TextFrameFormat#getWrapText--) özelliğini ( [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TextFrameFormat) sınıfından) `true` değerine ayarlamanız gerekir.

Bu PHP kodu, bir PowerPoint sunumunda Metni Kaydırma ayarını nasıl kullanacağınızı gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Bir şekil için `WrapText` özelliğini `False` olarak ayarlarsanız, şeklin içindeki metin şeklin genişliğinden daha uzun olduğunda, metin tek bir satırda şeklin sınırlarının dışına uzanır. 
{{% /alert %}}

## **SSS**

**Metin çerçevesinin iç kenar boşlukları AutoFit'i etkiler mi?**

Evet. Dolgu (iç kenar boşlukları) metin için kullanılabilir alanı azaltır, bu nedenle AutoFit daha erken devreye girer—yazı tipi küçülür veya şekil daha erken yeniden boyutlandırılır. AutoFit'i ayarlamadan önce kenar boşluklarını kontrol edin ve ayarlayın.

**AutoFit manuel ve yumuşak satır sonlarıyla nasıl etkileşir?**

Zorunlu satır sonları yerinde kalır ve AutoFit, bunların etrafında yazı tipi boyutunu ve aralığını ayarlar. Gereksiz satır sonlarını kaldırmak, AutoFit'in metni ne kadar agresif küçülteceğini genellikle azaltır.

**Tema yazı tipini değiştirmek veya yazı tipi ikamesi tetiklemek AutoFit sonuçlarını etkiler mi?**

Evet. Farklı glif ölçüleri olan bir yazı tipine ikame etmek, metnin genişliğini/yüksekliğini değiştirir, bu da nihai yazı tipi boyutunu ve satır kaydırmayı etkileyebilir. Herhangi bir yazı tipi değişikliğinden veya ikamesinden sonra slaytları yeniden kontrol edin.