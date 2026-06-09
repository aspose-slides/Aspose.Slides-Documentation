---
title: C++'ta Sunum Notlarını Yönetin
linktitle: Sunum Notları
type: docs
weight: 110
url: /tr/cpp/presentation-notes/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunum notlarını özelleştirin. PowerPoint ve OpenDocument notlarıyla sorunsuz çalışarak verimliliğinizi artırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, notların nasıl kaldırılacağını ve bir sunumdaki not slaytlarına nasıl stil uygulanacağını tanıtacağız. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki şekillerde kaldırabilir:

- Bir sunumdaki belirli bir slayttan notları kaldır.
- Bir sunumdaki tüm slaytlardan notları kaldır.

## **Belirli Bir Slayttan Notları Kaldır**
Bazı belirli bir slaydın notları, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Tüm Slaytlardan Notları Kaldır**
Bir sunumdaki tüm slaytların notları, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Not Stilini Ekle**
NotesStyle özelliği sırasıyla IMasterNotesSlide arabirimi ve MasterNotesSlide sınıfına eklenmiştir. Bu özellik, bir not metninin stilini belirtir. Uygulama aşağıdaki örnekte gösterilmiştir.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **SSS**

**Belirli bir slaydın notlarına erişimi sağlayan API varlığı hangisidir?**

Notlara, slaydın not yöneticisi aracılığıyla erişilir: slayt bir [NotesSlideManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [method](https://reference.aspose.com/slides/tr/cpp/aspose.slides/notesslidemanager/get_notesslide/) (notlar yoksa `null` döner) içerir.

**Kütüphanenin çalıştığı PowerPoint sürümleri arasında not desteği açısından farklılıklar var mı?**

Kütüphane, Microsoft PowerPoint formatlarının (97‑yenisi) ve ODP’nin geniş bir yelpazesini hedefler; notlar bu formatlarda, PowerPoint’in yüklü bir kopyasına bağlı olmaksızın desteklenir.