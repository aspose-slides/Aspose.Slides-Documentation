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
description: "Java üzerinden PHP için Aspose.Slides ile sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak verimliliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, bu özelliği tanıtacağız; notları nasıl kaldıracağınızı ve bir sunumdaki not slaytlarına nasıl stil uygulanacağını açıklayacağız. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki şekillerde kaldırabilir:

- Sunumdaki belirli bir slayttan notları kaldırın.
- Sunumdaki tüm slaytlardan notları kaldırın.

## **Slayttan Notları Kaldırma**
Belirli bir slayttaki notlar, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

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

## **Sunumdan Notları Kaldırma**
Sunumdaki tüm slaytlardaki notlar, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

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

## **Not Stili Ekleme**
[getNotesStyle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) yöntemi, [MasterNotesSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/MasterNotesSlide) sınıfına eklenmiştir. Bu özellik, bir not metninin stilini belirler. Uygulama aşağıdaki örnekte gösterilmiştir.

```php
  # Sunum dosyasını temsil eden bir Presentation nesnesi oluştur
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

**Belirli bir slaytın notlarına erişim sağlayan API varlığı hangisidir?**

Notlar, slaydın not yöneticisi aracılığıyla erişilir: slayt bir [NotesSlideManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [method](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notesslidemanager/getnotesslide/) içerir; not yoksa `null` döndürülür.

**Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteği açısından farklar var mı?**

Kütüphane, geniş bir Microsoft PowerPoint formatları (97‑yeni) ve ODP yelpazesini hedefler; notlar, bu formatlarda, PowerPoint'in yüklü bir kopyasına bağımlı olmaksızın desteklenir.