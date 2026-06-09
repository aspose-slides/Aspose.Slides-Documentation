---
title: PHP Kullanarak Sunumlarda Üst Simge ve Alt Simge Yönetimi
linktitle: Üst Simge ve Alt Simge
type: docs
weight: 80
url: /tr/php-java/superscript-and-subscript/
keywords:
- üst simge
- alt simge
- üst simge ekle
- alt simge ekle
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Java üzerinden PHP için Aspose.Slides'ta üst simge ve alt simgeyi ustalaşın ve sunumlarınızı maksimum etki için profesyonel metin biçimlendirmesiyle yükseltin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarınıza üst simge ve alt simge metinlerini entegre etme özellikleri sunar. Kimyasal formülleri, matematiksel denklemleri vurgulamanız ya da içeriği dipnotlarla açıklamanız gerektiğinde, bu özel biçimlendirme seçenekleri netlik ve kesinliği korur. Bu makalede, üst simge ve alt simge stillerini sorunsuz şekilde nasıl uygulayacağınızı ve her slaytta profesyonel sonuçlar elde edeceğinizi öğreneceksiniz.

## **Üst Simge ve Alt Simge Metnini Yönetme**
Herhangi bir paragraf bölümüne üst simge ve alt simge metni ekleyebilirsiniz. Aspose.Slides metin çerçevesinde Üst Simge veya Alt Simge metni eklemek için [**setEscapement**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setEscapement) metodunu [PortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PortionFormat) sınıfının kullanmanız gerekir.

Bu özellik, üst simge veya alt simge metnini döndürür veya ayarlar (değer -%100 (alt simge) ile %100 (üst simge) arasında). Örneğin:

- [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- İndeksini kullanarak bir slaytın referansını alın.
- [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) içinde [Rectangle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ShapeType#Rectangle) türünde bir şekil ekleyin.
- [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ile ilişkili [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) e erişin.
- Mevcut Paragrafları temizleyin
- Üst simge metnini tutacak yeni bir paragraf nesnesi oluşturun ve bunu [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) öğesinin [IParagraphs collection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParagraphs)ine ekleyin.
- Yeni bir bölüm nesnesi oluşturun
- Üst simge eklemek için bölümün Escapement özelliğini 0 ile 100 arasında ayarlayın. (0 üst simge yok demektir)
- [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Portion) için bir metin belirleyin ve ardından bunu paragrafın bölüm koleksiyonuna ekleyin.
- Alt simge metnini tutacak yeni bir paragraf nesnesi oluşturun ve bunu IParagraphs koleksiyonuna ITextFrame içinde ekleyin.
- Yeni bir bölüm nesnesi oluşturun
- Alt simge eklemek için bölümün Escapement özelliğini 0 ile -100 arasında ayarlayın. (0 alt simge yok demektir)
- [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Portion) için bir metin belirleyin ve ardından bunu paragrafın bölüm koleksiyonuna ekleyin.
- Sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir.

```php
  # PPTX'yi temsil eden bir Presentation sınıfı örnekleyin
  $pres = new Presentation();
  try {
    # Slaytı al
    $slide = $pres->getSlides()->get_Item(0);
    # Metin kutusu oluştur
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Üst simge metni için paragraf oluştur
    $superPar = new Paragraph();
    # Normal metinli bölüm oluştur
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Üst simge metniyle bölüm oluştur
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Alt simge metni için paragraf oluştur
    $paragraph2 = new Paragraph();
    # Normal metinli bölüm oluştur
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Alt simge metniyle bölüm oluştur
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Paragrafları metin kutusuna ekle
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Üst simge ve alt simge, PDF veya diğer formatlara dışa aktarılırken korunur mu?**  
Evet, Aspose.Slides, sunumları PDF, PPT/PPTX, görüntüler ve diğer desteklenen formatlara dışa aktarırken üst simge ve alt simge biçimlendirmesini doğru bir şekilde korur. Özel biçimlendirme tüm çıktı dosyalarında aynen kalır.

**Üst simge ve alt simge, kalın veya italik gibi diğer biçimlendirme stilleriyle birleştirilebilir mi?**  
Evet, Aspose.Slides tek bir metin bölümünde çeşitli metin stillerini karıştırmanıza izin verir. Kalın, italik, alt çizgi gibi stilleri etkinleştirebilir ve aynı anda [PortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/) sınıfındaki ilgili özellikleri yapılandırarak üst simge veya alt simge uygulayabilirsiniz.

**Üst simge ve alt simge biçimlendirmesi, tablolar, grafikler veya SmartArt içindeki metinlerde çalışır mı?**  
Evet, Aspose.Slides, tablolar ve grafik öğeleri dahil olmak üzere çoğu nesnede biçimlendirmeyi destekler. SmartArt ile çalışırken, uygun öğelere (örneğin [SmartArtNode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnode/)) ve bunların metin kapsayıcılarına erişmeniz ve ardından [PortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/) özelliklerini benzer şekilde yapılandırmanız gerekir.