---
title: C++'ta Not Sayfası Boyutunu ve Yönünü Değiştirme
linktitle: Not Sayfası Boyutu
type: docs
weight: 10
url: /tr/cpp/notes-size/
keywords:
- not sayfası boyutu
- not yönelimi
- yatay notlar
- dikey notlar
- el ilanı boyutu
- PowerPoint
- sunum
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde not sayfası boyutlarını okuyun ve değiştirin, yönelimi değiştirin, kaydedilen boyutları doğrulayın ve notları ya da el ilanlarını PDF ve görüntülere dışa aktarın."
---
## **Genel Bakış**

Sunumun not sayfası ayarlarına erişmek için [Presentation::get_NotesSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_notessize/) yöntemini kullanın. Bu, boyutları ayarlayan [set_Size](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inotessize/set_size/) metoduna sahip bir [INotesSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inotessize/) nesnesi döndürür. Not ayarları nesnesi değiştirilemese de, boyutunu değiştirebilirsiniz.

Genişlik ve yükseklik **nokta** cinsinden belirtilir; inç başına 72 nokta vardır. Örneğin, 900 × 600 nokta 12,5 × 8⅓ inçtir. Bu ayarlar bireysel bir slaytın notlarından ziyade sunuma uygulanır.

| Ayar | Amaç |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_notessize/) | Not sayfası boyutlarını ve el ilanı dışa aktarma için kullanılan sayfa boyutlarını kontrol eder. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slidesize/) | Normal sunum slaytı boyutlarını [ISlideSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidesize/) aracılığıyla kontrol eder. |

Her iki ayarı da değiştirmek diğerini otomatik olarak değiştirmez. Not sayfası yönünü değiştirmek aynı zamanda normal slaytları döndürmez. Normal slaytları yeniden boyutlandırmak için [Slide Size](/slides/tr/cpp/slide-size/) sayfasına bakın.

Aşağıdaki örnekler mevcut bir `sample.pptx` dosyasını kullanır. Dışa aktarma örnekleri için en az bir slaytta konuşmacı notları bulunan bir sunum kullanın. Her örnek bağımsız olarak çalıştırılabilir.

## **Not Sayfası Boyutunu ve Yönünü Okuma**

Genişlik ve yüksekliği okuyun ve yönü belirlemek için karşılaştırın: daha geniş bir sayfa yatay, daha yüksek bir sayfa dikey ve eşit boyutlar kare bir sayfayı tanımlar. Bu örnek, standart bir kağıt boyutu varsaymadan gerçek boyutları nokta cinsinden yazdırır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Kağıt Boyutunu Değiştirmeden Yatay Olarak Değiştirme**

Sadece yönü değiştirmek için mevcut genişlik ve yüksekliği yer değiştirin. Bu, özel bir kağıt boyutunun uzunlukları da dahil olmak üzere her iki kenarın uzunluğunu korur. Aşağıdaki koşul, zaten yatay olan bir sayfanın yeniden dikey hale gelmesini engeller ve kare bir sayfayı aynı tutar.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Dikey yön için, `size.get_Width() > size.get_Height()` olduğunda aynı atamayı kullanın. Kağıt boyutunu da değiştirmek istemediğiniz sürece A4 veya Letter boyutlarını değiştirmeyin.

## **Özel Not Sayfası Boyutunu Ayarlama ve Doğrulama**

Her iki boyutu birlikte atayın, ardından sunumu yazmak için [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metodunu kullanın. Bu örnek 900 × 600 nokta boyutunda bir yatay sayfa ayarlar, PPTX olarak kaydeder ve kaydedilen dosyayı tekrar açarak kalıcı değerleri kontrol eder. Karşılaştırma, kayan nokta değerleri için 0,01 nokta toleransına izin verir; bu, her dosya formatı için kesinlik garantisi değildir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Beklenen sonuç `900 x 600 points` ve `Size preserved: True` şeklindedir. Yeni açılan bir sunumu kontrol etmek, yalnızca bellek içi ayarları değil, kaydedilen dosyayı da doğrular.

## **Notları ve El İlanlarını Dışa Aktarma**

Sayfa boyutları, notlar veya el ilanı düzenleri için kullanılabilir alanı tanımlar. Tek başına bu düzenleri etkinleştirmezler; dışa aktarma seçeneklerini de yapılandırmanız gerekir. Normal slayt dışa aktarma, slayt boyutlarını kullanmaya devam eder.

### **Notları PDF ve PNG Olarak Dışa Aktarma**

Notları PDF'e dahil etmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) öğesini [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) metoduna atayın. Bu örnek ayrıca [Slide::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/getimage/) ve [RenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/renderingoptions/) kullanarak notlu ilk slaytı PNG olarak işler.

[BottomTruncated](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notespositions/) modu notları tek bir sayfada tutar; sığmayan notlar kırpılabilir. PDF, 900 × 600 nokta sayfalar kullanır. Aşağıda kullanılan 1 × 1 görüntü ölçeğinde PNG 900 × 600 piksel olur. Noktalar sayfa geometrisini, pikseller ise raster çıktıyı tanımlar; boyutlar ayrıca işleme ölçeğine bağlıdır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Uzun notlarla PDF dışa aktarmada, [BottomFull](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notespositions/) gerektiğinde ek sayfalara izin verir. Yukarıdaki tek slayt görüntü çağrısı bu modu desteklemediği için kullanmayın. Yeniden boyutlandırdıktan sonra, kırpılmış notları ve mevcut notlar‑master nesnelerinin yerleşimini kontrol edin; yalnızca sayfa boyutlarını değiştirmek tüm içeriğin sığacağını garanti etmez. Not dışa aktarması hakkında daha fazla bilgi için [Convert PowerPoint to PDF with Notes](/slides/tr/cpp/convert-powerpoint-to-pdf-with-notes/) sayfasına bakın.

### **El İlanlarını PDF Olarak Dışa Aktarma**

Bir sayfada birden fazla slayt küçük resmi için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handoutlayoutingoptions/) kullanın. Aşağıdaki örnek 900 × 600 nokta sayfa ayarlar ve sayfa başına en fazla dört slayt düzenlemek için [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handouttype/) kullanır. Yatay ön ayar slayt sıralamasını kontrol eder; sayfa yönelimi genişlik ve yükseklikten elde edilir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Sayfa boyutunu değiştirmek, el ilanı ızgarası için kullanılabilir alanı değiştirir ancak kaynak slaytların boyutlarını etkilemez. El ilanı görüntüleri için, tek bir slaytın görüntü metodundan ziyade el ilanı düzeni ile [Presentation::GetImages](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/getimages/) kullanın. Aspose.Slides içinde, sunum düzeyindeki el ilanı işleme not sayfası boyutlarını kullanırken, tek slayt görüntü çağrısı el ilanı sayfası oluşturmaz. Düzen seçenekleri için [Handout Mode](/slides/tr/cpp/convert-powerpoint-in-handout-mode/) sayfasına bakın.

## **Görüntüleyiciler, Dışa Aktarma ve Yazdırmada Sayfa Boyutu**

- **Presentation viewers:** Bir görüntüleyici, notları kendi yerleşim kurallarını kullanarak görüntüleyebilir veya yazdırabilir. Başka bir uygulama dosyayı kaydederse, yeniden açın ve boyutları tekrar kontrol edin; o uygulamanın format dönüşümü onları normalleştirebilir.
- **Export formats:** Yukarıdaki not ve el ilanı PDF örnekleri yapılandırılmış sayfa boyutlarını kullanır. Raster görüntüler tam sayı piksel boyutları ve bir işleme ölçeği kullanır, bu yüzden kesirli nokta değerleri görüntü çıktısında yuvarlanabilir. Normal slaytların dışa aktarımı not sayfa boyutunu uygulamaz.
- **Printer drivers:** Kağıt seçimi, otomatik döndürme ve sayfaya sığdırma ayarları, sunumda veya PDF'de saklanan boyutları değiştirmeden fiziksel çıktıyı değiştirebilir. Belirli bir kağıt boyutu için, yazıcı ayarlarıyla eşleşin ve baskı ön izlemeyi kontrol edin.

## **SSS**

**Sadece bir slayt için not sayfası boyutunu ayarlayabilir miyim?**

Cevap: Not sayfası boyutu sunum düzeyinde bir ayardır. Bireysel slaytlar farklı not içeriğine sahip olabilir, ancak bu özellik her slayt için ayrı bir sayfa boyutu sağlamaz.

**Not yönünü değiştirmek slaytlarımı neden etkilemedi?**

Cevap: Not sayfaları ve normal slaytlar bağımsız boyutlara sahiptir. Slaytların kendisini yeniden boyutlandırmak istediğinizde normal slayt boyutu ayarlarını kullanın.

**Kaydedilmiş veya yazdırılmış sonucum farklı bir boyutta neden görünüyor?**

Cevap: Öncelikle kaydedilmiş sunumu yeniden açın ve not boyutlarını karşılaştırın. Eğer değişmişse, dosyayı başka bir uygulamada kaydetmenin veya dönüştürmenin sayfa ayarlarını değiştirip değiştirmediğini kontrol edin. Değişmemişse, dışa aktarma yerleşimini, görüntü ölçeğini, görüntüleyici ayarlarını ve yazıcı kağıt seçimini inceleyin.