---
title: C++ ile Sunumlar Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/cpp/create-presentation/
keywords:
- sunum oluştur
- yeni sunum
- PPT oluştur
- yeni PPT
- PPTX oluştur
- yeni PPTX
- ODP oluştur
- yeni ODP
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++ ile Aspose.Slides kullanarak sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programlı bir şekilde kaydedin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'ta bir sunum oluşturmanın, ilk slaytına bir metin kutusu eklemenin ve sonucu bir dosya olarak kaydetmenin nasıl yapılacağını gösterir. Sonundaki kısa SSS, formatlar, şablonlar, slayt boyutlandırma, birimler, bellek kullanımı, çoklu iş parçacığı, lisanslama, dijital imzalar ve VBA desteğiyle ilgili yaygın soruları kapsar.

Başlamadan önce, Aspose.Slides'ı projenize ekleyin: Windows'ta Visual Studio projesinde NuGet'ten veya Linux'ta CMake ile ZIP paketinden. Bkz. [Kurulum](/slides/tr/cpp/installation/).

## **PowerPoint Sunumu Oluşturma**

Bir sunum oluşturmak ve ilk slaytına bir metin kutusu eklemek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun. Yeni bir sunum zaten bir boş slayt içerir.  
2. Bu slaytı [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) metodu ve indeks 0 ile alın.  
3. [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) metodu ile bir dikdörtgen ekleyin ve metnini [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/) metodu ile ayarlayın.  
4. Sunumu PPTX dosyası olarak [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) metodu ile kaydedin.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Dikdörtgenin sol üst köşesi slaytın sol kenarından 50 puan, üst kenarından 50 puan uzakta ve dikdörtgen 400 puan genişliğinde ve 100 puan yüksekliğindedir. Program, çalıştığı dizinde *hello.pptx* dosyasını, içinde dikdörtgen ve metni tutan bir slayt ile kaydeder. Lisans olmadan Aspose.Slides, kaydettiği her slayta bir değerlendirme filigranı ekler; bkz. [Lisanslama](/slides/tr/cpp/licensing/).

## **SSS**

### Yeni bir sunumu hangi formatlarda kaydedebilirim?

[PPTX, PPT ve ODP](/slides/tr/cpp/save-presentation/) formatlarında kaydedebilir ve ayrıca [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/tr/cpp/convert-powerpoint-to-xps/), [HTML](/slides/tr/cpp/convert-powerpoint-to-html/), [SVG](/slides/tr/cpp/render-a-slide-as-an-svg-image/) ve [görseller](/slides/tr/cpp/convert-powerpoint-to-png/) gibi diğer formatlara dışa aktarabilirsiniz.

### Bir şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?

Evet. Şablonu yükleyin ve istediğiniz formatta kaydedin; POTX/POTM/PPTM ve benzeri formatlar [desteklenir](/slides/tr/cpp/supported-file-formats/).

### Sunum oluştururken slayt boyutunu/çözünürlüğünü nasıl kontrol edebilirim?

[Slayt boyutunu](/slides/tr/cpp/slide-size/) (4:3, 16:9 gibi ön ayarlar veya özel boyutlar) ayarlayın ve içeriğin nasıl ölçekleneceğini seçin.

### Büyüklükler ve koordinatlar hangi birimlerde ölçülür?

Puan cinsinden: 1 inç 72 birime eşittir.

### Çok sayıda medya dosyası içeren çok büyük bir sunumu bellek kullanımını azaltmak için nasıl yönetebilirim?

[BLOB yönetim stratejilerini](/slides/tr/cpp/manage-blob/) kullanın, geçici dosyalarla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

### Sunumları paralel olarak oluşturabilir/kaydedebilirim?

Aynı [Presentation]([https://reference.aspose.com/slides/cpp/aspose.slides/presentation/]) örneği üzerinde [birden çok iş parçacığından](/slides/tr/cpp/multithreading/) çalışamazsınız. Her iş parçacığı veya süreç için ayrı, izole edilmiş örnekler çalıştırın.

### Deneme filigranını ve sınırlamaları nasıl kaldırabilirim?

İşlem başına bir kez [bir lisans uygulayın](/slides/tr/cpp/licensing/). Lisans XML'i değiştirilmemeli ve birden çok iş parçacığı varsa lisans kurulumu senkronize edilmelidir.

### Oluşturduğum PPTX'i dijital olarak imzalayabilir miyim?

Evet. [Dijital imzalar](/slides/tr/cpp/digital-signature-in-powerpoint/) (ekleme ve doğrulama) sunumlar için desteklenir.

### Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?

Evet. [VBA projeleri oluşturabilir/düzenleyebilirsiniz](/slides/tr/cpp/presentation-via-vba/) ve PPTM/PPSM gibi makro‑etkin dosyaları kaydedebilirsiniz.