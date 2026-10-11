---
title: PHP'de Sunum Notlarını Yönet
linktitle: Sunum Notları
type: docs
weight: 110
url: /tr/php-java/presentation-notes/
keywords:
- notlar
- not slaytı
- not ekle
- not kaldır
- not stili
- ana notlar
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides ile sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak verimliliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, bu özelliği tanıtacağız; notların nasıl kaldırılacağını ve bir sunumdaki not slaytlarına nasıl stil uygulanacağını göstereceğiz. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki yollarla kaldırabilir:

- Bir sunumdaki belirli bir slayttan notları kaldır.
- Bir sunumdaki tüm slaytlardan notları kaldır.

Not sayfası boyutlarını okumak veya değiştirmek, yönlendirmeyi değiştirmek ve dışa aktarma davranışını kontrol etmek için [Not Sayfası Boyutu](/slides/tr/php-java/notes-size/) bölümüne bakın.

## **Bir Slayttan Notları Kaldır**
Belirli bir slayttan notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesini oluştur
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # İlk slaydın notlarını kaldırma
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Sunumu diske kaydetme
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Sunumdan Notları Kaldır**
Bir sunumdaki tüm slaytlardan notlar aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesini oluştur
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Tüm slaytların notlarını kaldırma
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Sunumu diske kaydetme
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Not Stili Ekle**
[getNotesStyle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) metodu, [MasterNotesSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/MasterNotesSlide) sınıfının not metni stiline erişim sağlar. Uygulama aşağıdaki örnekte gösterilmiştir.

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesini oluştur
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # MasterNotesSlide metin stilini al
      $notesStyle = $notesMaster->getNotesStyle();
      # İlk seviye paragraflar için sembol madde işareti ayarla
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Belirli bir slaytın notlarına erişim sağlayan API nesnesi hangisidir?**

Notlar, slaytın not yöneticisi aracılığıyla erişilir: slayt bir [NotesSlideManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [metot](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notesslidemanager/getnotesslide/) vardır; not yoksa `null` döner.

**Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteği açısından farklılıklar var mı?**

Kütüphane, geniş bir Microsoft PowerPoint formatı (97‑yenileri) ve ODP yelpazesini hedefler; notlar bu formatlarda, yüklü bir PowerPoint kopyasına bağlı olmaksızın desteklenir.