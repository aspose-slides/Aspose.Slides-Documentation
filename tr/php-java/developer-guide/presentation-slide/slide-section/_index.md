---
title: Sunumlarda PHP Kullanarak Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 90
url: /tr/php-java/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölümü düzenle
- bölümü değiştir
- bölüm adı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument'te slayt bölümlerini kolaylaştırın — bölümlere ayırın, yeniden adlandırın ve yeniden sıralayın, PPTX ve ODP iş akışlarını optimize edin."
---
## **Giriş**

Aspose.Slides for PHP via Java ile bir PowerPoint sunumunu bölümlere ayırabilirsiniz. Belirli slaytları içeren bölümler oluşturabilirsiniz.

Aşağıdaki durumlarda slaytları mantıksal parçalara ayırmak veya düzenlemek için bölümler oluşturmak isteyebilirsiniz:

- Büyük bir sunum üzerinde diğer insanlar veya bir ekip ile çalışırken ve belirli slaytları bir meslektaşınıza veya ekip üyelerine atamanız gerektiğinde. 
- Çok sayıda slayt içeren bir sunumla uğraşırken ve içeriğini tek seferde yönetmek veya düzenlemek için zorlanıyorsanız.

İdeal olarak, benzer slaytlara ev sahipliği yapan bir bölüm oluşturmalısınız—slaytların ortak bir özelliği vardır veya bir kurala göre bir grup içinde bulunabilir—ve bölüme içindeki slaytları tanımlayan bir ad vermelisiniz. 

## **Sunumlarda Bölüm Oluşturma**

Sunumda slaytları barındıracak bir bölüm eklemek için, Aspose.Slides for PHP via Java, oluşturmak istediğiniz bölümün adını ve bölümün başladığı slaytı belirlemenizi sağlayan [addSection()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sectioncollection/#addSection) metodunu sunar.

Bu örnek kod, bir sunumda bölüm oluşturmayı gösterir :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 yeniSlide2'de sonlandırılacak ve ardından section2 başlayacak

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bölüm Adlarını Değiştirme**

PowerPoint sunumunda bir bölüm oluşturduktan sonra adını değiştirmeye karar verebilirsiniz. 

Bu örnek kod, Aspose.Slides kullanarak bir sunumdaki bölümün adını nasıl değiştireceğinizi gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Bölümler PPT (PowerPoint 97–2003) formatına kaydedildiğinde korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez, bu yüzden .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Tam bir bölüm "gizli" olabilir mi?**

Hayır. Yalnızca tek tek slaytlar gizlenebilir. Bir bölüm bir varlık olarak "gizli" durumuna sahip değildir.

**Bir slayta göre bölüm hızlıca bulunabilir mi ve karşıt olarak bir bölümün ilk slaytı bulunabilir mi?**

Evet. Bir bölüm, başlangıç slaytı ile benzersiz olarak tanımlanır; bir slayt verildiğinde hangi bölüme ait olduğunu belirleyebilir ve bir bölüm için ilk slaytına erişebilirsiniz.