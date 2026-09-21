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

Aspose.Slides, bir sunumdan not slaytlarını kaldırmayı destekler. Bu konuda, bu özelliği tanıtacağız; notların nasıl kaldırılacağını ve bir sunumdaki not slaytlarına nasıl stil uygulanacağını açıklayacağız. Aspose.Slides, herhangi bir slayttan notları kaldırmanıza ve mevcut notlara stil uygulamanıza olanak tanır. Geliştiriciler notları aşağıdaki şekillerde kaldırabilirler:

- Bir sunumdaki belirli bir slayttan notları kaldırın.
- Bir sunumdaki tüm slaytlardan notları kaldırın.

Not sayfası boyutlarını okumak veya değiştirmek, yönlendirmeyi değiştirmek ve dışa aktarma davranışını kontrol etmek için [Not Sayfası Boyutu](/slides/tr/cpp/notes-size/) adresine bakın.

## **Belirli Bir Slayttan Notları Kaldır**

Belirli bir slayttaki notlar, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Tüm Slaytlardan Notları Kaldır**

Bir sunumdaki tüm slaytlardaki notlar, aşağıdaki örnekte gösterildiği gibi kaldırılabilir:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Not Stili Ekle**

NotesStyle özelliği, IMasterNotesSlide arabirimine ve MasterNotesSlide sınıfına eklenmiştir. Bu özellik, not metninin stilini belirtir. Uygulama aşağıdaki örnekte gösterilmiştir.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **SSS**

### Belirli bir slaytın notlarına erişim sağlayan API varlığı hangisidir?

Notlar, slaytın not yöneticisi aracılığıyla erişilir: slaytın bir [NotesSlideManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/notesslidemanager/) ve not nesnesini döndüren bir [method](https://reference.aspose.com/slides/tr/cpp/aspose.slides/notesslidemanager/get_notesslide/) vardır; not yoksa `null` döndürülür.

### Kütüphanenin çalıştığı PowerPoint sürümlerinde not desteği açısından farklılıklar var mı?

Kütüphane, geniş bir Microsoft PowerPoint formatı (97‑yenisi) ve ODP yelpazesini hedefler; notlar, PowerPoint'in kurulu bir kopyasına bağımlı olmadan bu formatlar içinde desteklenir.