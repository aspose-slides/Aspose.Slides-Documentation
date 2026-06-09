---
title: C++'ta Sunumları Verimli Bir Şekilde Birleştirin
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/cpp/merge-presentation/
keywords:
- PowerPoint'ı birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- PowerPoint'ı birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını zahmetsizce birleştirerek iş akışınızı hızlandırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan diğerine slayt klonlayarak sunumları birleştirmenizi sağlar. Bu makale, tüm sunumları veya seçili slaytları nasıl birleştirileceğini, birleştirme sırasında slayt ana sayfası veya belirli bir düzenin nasıl kullanılacağını, farklı slayt boyutlarına sahip sunumların nasıl ele alınacağını ve birleştirilen slaytların bir sunum bölümüne nasıl ekleneceğini açıklar. Ayrıca birleştirilen içerikle ilgili pratik notları, konuşmacı notaları, yorumlar, şifre korumalı kaynak dosyalar ve iş parçacığı kullanımını kapsar.

## **Sunum Birleştirme**

Bir sunumu diğerine birleştirdiğinizde, slaytlarını tek bir sunumda birleştirerek bir dosya elde etmiş olursunuz.

{{% alert title="Bilgi" color="info" %}}
Çoğu sunum programı (PowerPoint veya OpenOffice) kullanıcıların sunumları bu şekilde birleştirmesine izin veren işlevlere sahip değildir.

[**Aspose.Slides for C++**](https://products.aspose.com/slides/tr/cpp/) ise sunumları farklı şekillerde birleştirmenizi sağlar. Tüm şekilleri, stilleri, metinleri, biçimlendirmeleri, yorumları, animasyonları vb. içeriklerini kayıp yaşamadan birleştirebilirsiniz.

**Ayrıca Bakınız**

[Slaytları Kopyala](https://docs.aspose.com/slides/tr/cpp/clone-slides/)*.*
{{% /alert %}}

### **Ne Birleştirilebilir**

Aspose.Slides ile şunları birleştirebilirsiniz

* tüm sunumları. Sunumlardan tüm slaytlar tek bir sunumda birleştirilir
* belirli slaytları. Seçilen slaytlar tek bir sunumda birleştirilir
* aynı formatta (PPT'den PPT'ye, PPTX'ten PPTX'e vb.) ve farklı formatlarda (PPT'den PPTX'e, PPTX'ten ODP'ye vb.) sunumları birbirine birleştirebilirsiniz.

{{% alert title="Not" color="warning" %}} 
Sunumların yanı sıra, Aspose.Slides başka dosyaları da birleştirmenize izin verir:

* [Görseller](https://products.aspose.com/slides/tr/cpp/merger/image-to-image/), örneğin [JPG'den JPG'ye](https://products.aspose.com/slides/tr/cpp/merger/jpg-to-jpg/) veya [PNG'den PNG'ye](https://products.aspose.com/slides/tr/cpp/merger/png-to-png/) 
* Belgeler, örneğin [PDF'den PDF'ye](https://products.aspose.com/slides/tr/cpp/merger/pdf-to-pdf/) veya [HTML'den HTML'ye](https://products.aspose.com/slides/tr/cpp/merger/html-to-html/)
* Ve görüntü ile PDF gibi iki farklı dosya, örneğin [görüntüden PDF'ye](https://products.aspose.com/slides/tr/cpp/merger/image-to-pdf/) veya [JPG'den PDF'ye](https://products.aspose.com/slides/tr/cpp/merger/jpg-to-pdf/) veya [TIFF'den PDF'ye](https://products.aspose.com/slides/tr/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Birleştirme Seçenekleri**

Aşağıdaki seçenekleri uygulayabilirsiniz

* çıktı sunumundaki her slayt benzersiz bir stile sahip olur
* çıktı sunumundaki tüm slaytlar aynı stil kullanır. 

Sunumları birleştirmek için Aspose.Slides, [AddClone](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) yöntemlerini ([ISlideCollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide_collection) arayüzünden) sağlar. `AddClone` yöntemlerinin birden fazla uygulaması, sunum birleştirme sürecinin parametrelerini belirler. Her Presentation nesnesinin bir [Slides](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) koleksiyonu vardır; bu nedenle slaytları birleştirmek istediğiniz sunum üzerinden `AddClone` metodunu çağırabilirsiniz. 

`AddClone` yöntemi, kaynak slaydın bir kopyası olan bir `ISlide` nesnesi döndürür. Çıktı sunumundaki slaytlar, kaynak slaytlardan basitçe kopyalanmıştır. Bu nedenle, sonuç slaytlarda (örneğin stiller, biçimlendirme seçenekleri veya düzenler uygulayarak) değişiklik yapabilirsiniz; kaynak sunumların etkilenmesi konusunda endişelenmenize gerek yoktur. 

## **Sunumları Birleştir** 

Aspose.Slides, slaytların düzenlerini ve stillerini koruyarak (varsayılan parametreler) slaytları birleştirmenizi sağlayan [**AddClone (ISlide)**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) metodunu sunar. 

Bu C++ kodu, sunumları nasıl birleştireceğinizi gösterir:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Sunumları Slayt Ana Sayfası ile Birleştir**

Aspose.Slides, slayt ana sayfası sunum şablonunu uygulayarak slaytları birleştirmenizi sağlayan [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) metodunu sunar. Bu sayede, gerektiğinde çıktı sunumundaki slaytların stilini değiştirebilirsiniz. 

Bu C++ kodu, açıklanan işlemi gösterir:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Not" color="warning" %}} 
Slayt ana sayfasının slayt düzeni otomatik olarak belirlenir. Uygun bir düzen belirlenemediğinde, `AddClone` metodunun `allowCloneMissingLayout` Boolean parametresi true olarak ayarlanmışsa, kaynak slaydın düzeni kullanılır. Aksi takdirde, [PptxEditException](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) istisnası fırlatılır. 
{{% /alert %}}

Çıktı sunumundaki slaytların farklı bir slayt düzenine sahip olmasını istiyorsanız, birleştirirken [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) metodunu kullanın. 

## **Belirli Slaytları Sunumlardan Birleştir**

Birden fazla sunumdan belirli slaytları birleştirmek, özel slayt paketleri oluşturmak için faydalıdır. Aspose.Slides C++ yalnızca ihtiyacınız olan slaytları seçip içe aktarmanızı sağlar. API, orijinal slaytların biçimlendirmesini, düzenini ve tasarımını korur.

Şu C++ kodu yeni bir sunum oluşturur, iki diğer sunumdan başlık slaytlarını ekler ve sonucu bir dosyaya kaydeder:

```cpp
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

## **Sunumları Slayt Düzeni ile Birleştir**

Bu C++ kodu, slaytları birleştirirken tercih ettiğiniz slayt düzenini uygulayarak tek bir çıktı sunumu elde etmenizi gösterir:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

{{% alert title="Not" color="warning" %}} 
Farklı slayt boyutlarına sahip sunumları birleştiremezsiniz. 
{{% /alert %}}

Farklı slayt boyutlarına sahip 2 sunumu birleştirmek için, sunumlardan birinin boyutunu diğerinin boyutuna eşitleyecek şekilde yeniden boyutlandırmanız gerekir. 

Bu örnek kod, açıklanan işlemi gösterir:

```cpp
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

## **Slaytları Sunum Bölümüne Birleştir**

Bu C++ kodu, belirli bir slaytı sunumdaki bir bölüme nasıl birleştireceğinizi gösterir:

```cpp
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

{{% alert title="İpucu" color="primary" %}}

Aspose, bir [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye görüntüleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve benzeri işlemler yapabilirsiniz. 

{{% /alert %}}

## **SSS**

**Birleştirme sırasında konuşmacı notları korunur mu?**

Evet. Slaytları klonlarken, Aspose.Slides notlar, biçimlendirme ve animasyonlar dahil tüm slayt öğelerini taşıyarak kopyalar.

**Yorumlar ve yorum yazarları aktarılır mı?**

Yorumlar, slayt içeriğinin bir parçası olarak slaytla birlikte kopyalanır. Yorum yazar etiketleri, sonuç sunumdaki yorum nesneleri olarak korunur.

**Kaynak sunum şifre korumalıysa ne olur?**

[LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) ile şifreyle [açılmalıdır](/slides/tr/cpp/password-protected-presentation/); yüklendikten sonra bu slaytlar, korumasız bir hedef dosyaya (veya korumalı bir dosyaya da) güvenle klonlanabilir.

**Birleştirme işlemi ne kadar thread‑safe?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini [birden çok iş parçacığından](/slides/tr/cpp/multithreading/) kullanmayın. Önerilen kural “bir belge — bir iş parçacığı”; farklı dosyalar ayrı iş parçacıklarında paralel olarak işlenebilir.