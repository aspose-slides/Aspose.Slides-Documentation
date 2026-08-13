---
title: C++'ta Sunumları Verimli Bir Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/cpp/merge-presentation/
keywords:
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını zahmetsizce birleştirerek iş akışınızı hızlandırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan diğerine slaytları kopyalayarak sunumları birleştirmenizi sağlar. Bu makale, tüm sunumları veya seçilmiş slaytları nasıl birleştireceğinizi, bir slayt masterı ya da belirli bir düzeni birleştirme sırasında nasıl kullanacağınızı, farklı slayt boyutlarına sahip sunumları nasıl ele alacağınızı ve birleştirilen slaytları bir sunum bölümüne nasıl ekleyeceğinizi açıklar. Ayrıca birleştirilen içeriğe ilişkin pratik notları, konuşmacı notları, yorumlar, parola korumalı kaynak dosyalar ve iş parçacığı kullanımını kapsar.

## **Sunum Birleştirme**

Bir sunumu diğerine birleştirdiğinizde, slaytlarını tek bir sunumda birleştirerek tek bir dosya elde etmiş olursunuz. 

{{% alert title="Bilgi" color="info" %}}

Çoğu sunum programı (PowerPoint veya OpenOffice) kullanıcıların sunumları bu şekilde birleştirmesine izin veren işlevler sunmaz. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/tr/cpp/), ancak, sunumları farklı şekillerde birleştirmenize olanak tanır. Tüm şekilleri, stilleri, metinleri, biçimlendirmeleri, yorumları, animasyonları vb. kayıpsız bir şekilde birleştirirsiniz. 

**Ayrıca bakınız**

[Clone Slides](https://docs.aspose.com/slides/tr/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Ne Birleştirilebilir**

Aspose.Slides ile şunları birleştirebilirsiniz:

* tüm sunumlar. Sunumlardaki tüm slaytlar tek bir sunumda toplanır
* belirli slaytlar. Seçilen slaytlar tek bir sunumda toplanır
* aynı formatta sunumlar (PPT‑den PPT‑ye, PPTX‑den PPTX‑e vb.) ve farklı formatlarda (PPT‑den PPTX‑e, PPTX‑den ODP‑ye vb.) birbirine.

{{% alert title="Uyarı" color="warning" %}} 

Sunumların yanı sıra Aspose.Slides diğer dosyaları da birleştirmenize izin verir:

* [Görseller](https://products.aspose.com/slides/tr/cpp/merger/image-to-image/), örneğin [JPG to JPG](https://products.aspose.com/slides/tr/cpp/merger/jpg-to-jpg/) veya [PNG to PNG](https://products.aspose.com/slides/tr/cpp/merger/png-to-png/)
* Belgeler, örneğin [PDF to PDF](https://products.aspose.com/slides/tr/cpp/merger/pdf-to-pdf/) veya [HTML to HTML](https://products.aspose.com/slides/tr/cpp/merger/html-to-html/)
* Ve iki farklı dosya, örneğin [image to PDF](https://products.aspose.com/slides/tr/cpp/merger/image-to-pdf/), [JPG to PDF](https://products.aspose.com/slides/tr/cpp/merger/jpg-to-pdf/) veya [TIFF to PDF](https://products.aspose.com/slides/tr/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Birleştirme Seçenekleri**

Aşağıdaki seçenekleri uygulayabilirsiniz:

* çıktı sunumundaki her slaytın benzersiz bir stile sahip olması
* tüm slaytların aynı stil kullanması.

Sunumları birleştirmek için Aspose.Slides, [AddClone](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) yöntemlerini ( [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide_collection) arayüzünden ) sunar. `AddClone` yöntemlerinin birkaç uygulaması, sunum birleştirme işlemi parametrelerini tanımlar. Her Presentation nesnesinin bir [Slides](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) koleksiyonu vardır; böylece slaytları birleştirmek istediğiniz sunumdan bir `AddClone` yöntemi çağırabilirsiniz. 

`AddClone` yöntemi, kaynak slaytın bir kopyası olan bir `ISlide` nesnesi döndürür. Çıktı sunumundaki slaytlar, kaynak slaytlardan basitçe kopyalanır. Bu nedenle, kaynak sunumlar etkilenmeden, sonuç slaytlar üzerinde stil, biçimlendirme seçenekleri veya düzenler uygulayabilirsiniz. 

## **Sunumları Birleştirme** 

Aspose.Slides, slaytların düzen ve stillerini koruyarak birleştirmenizi sağlayan [**AddClone (ISlide)**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) metodunu sunar (varsayılan parametreler). 

Aşağıdaki C++ kodu, sunumları nasıl birleştireceğinizi gösterir:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Slayt Masterı ile Sunumları Birleştirme**

Aspose.Slides, slayt master sunum şablonu uygulayarak slaytları birleştirmenizi sağlayan [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) metodunu sunar. Bu sayede, gerekirse çıktı sunumundaki slaytların stilini değiştirebilirsiniz. 

Aşağıdaki C++ kodu, açıklanan işlemi gösterir:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Uyarı" color="warning" %}} 

Slayt masterının düzeni otomatik olarak belirlenir. Uygun bir düzen belirlenemediğinde, `AddClone` metodunun `allowCloneMissingLayout` bool parametresi true olarak ayarlanmışsa kaynak slaytın düzeni kullanılır. Aksi takdirde [PptxEditException](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) fırlatılır. 

{{% /alert %}}

Çıktı sunumundaki slaytların farklı bir düzen almasını istiyorsanız, birleştirme sırasında [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) metodunu kullanın. 

## **Sunumlardan Belirli Slaytları Birleştirme**

Birden çok sunumdan belirli slaytları birleştirmek, özel sunum setleri oluşturmak için yararlıdır. Aspose.Slides C++ yalnızca ihtiyacınız olan slaytları seçip içe aktarmanıza izin verir. API, orijinal slaytların biçimlendirmesini, düzenini ve tasarımını korur.

Aşağıdaki C++ kodu, iki farklı sunumdan başlık slaytları ekleyerek yeni bir sunum oluşturur ve sonucu bir dosyaya kaydeder:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Yukarıdaki kodda tanımlanmıştır.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Slayt Düzeni ile Sunumları Birleştirme**

Bu C++ kodu, sunumlardan slaytları birleştirirken tercih ettiğiniz slayt düzenini uygulayarak tek bir çıktı sunumu elde etmenizi gösterir:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştirme**

{{% alert title="Uyarı" color="warning" %}} 

Farklı slayt boyutlarına sahip sunumları birleştiremezsiniz. 

{{% /alert %}}

Farklı slayt boyutlarına sahip iki sunumu birleştirmek için, boyutları aynı olacak şekilde bir sunumu yeniden boyutlandırmanız gerekir. 

Bu örnek kod, açıklanan işlemi göstermektedir:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Slaytları Bir Sunum Bölümüne Birleştirme**

Bu C++ kodu, belirli bir slaytı bir sunum bölümüne nasıl birleştireceğinizi gösterir:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Slayt, bölümün sonuna eklenir. 

{{% alert title="İpucu" color="info" %}}

Aspose, [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG to JPG](https://products.aspose.app/slides/tr/collage/jpg) veya PNG to PNG görselleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilirsiniz. 

{{% /alert %}}

## **SSS**

### Birleştirme sırasında konuşmacı notları korunur mu?

Evet. Slaytları klonlarken Aspose.Slides, notlar, biçimlendirme ve animasyonlar dahil olmak üzere tüm slayt öğelerini taşır.

### Yorumlar ve yazarları aktarılır mı?

Yorumlar, slayt içeriğinin bir parçası olduğundan slaytla birlikte kopyalanır. Yazar etiketleri, sonuç sunumdaki yorum nesneleri olarak korunur.

### Kaynak sunum parola korumalıysa ne olur?

Parola ile [açılmalıdır](/slides/tr/cpp/password-protected-presentation/) ve `LoadOptions::set_Password` ile (https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) kullanılmalıdır; yüklendikten sonra bu slaytlar, korunmasız bir hedef dosyaya (ya da korunmuş bir dosyaya da) güvenle klonlanabilir.

### Birleştirme işlemi ne kadar thread‑safe?

Aynı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini [birden çok iş parçacığından](/slides/tr/cpp/multithreading/) kullanmayın. Önerilen kural “bir belge — bir iş parçacığı”; farklı dosyalar ayrı iş parçacıklarında paralel olarak işlenebilir.