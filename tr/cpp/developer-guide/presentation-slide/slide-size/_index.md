---
title: C++'ta Sunum Slayt Boyutunu Değiştir
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/cpp/slide-size/
keywords:
- slayt boyutu
- en-boy oranı
- standart
- geniş ekran
- 4:3
- 16:9
- slayt boyutunu ayarla
- slayt boyutunu değiştir
- özel slayt boyutu
- özel slayt boyutu
- benzersiz slayt boyutu
- tam boyutlu slayt
- ekran tipi
- yeniden ölçeklendirme
- sığmasını sağla
- azami boyut
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++ ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızlı bir şekilde yeniden boyutlandırmayı öğrenin, kalite kaybı olmadan herhangi bir ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem baskı hem de ekran görüntüsü için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En‑Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En‑Boy Oranı)**: Modern projektörler ve görüntü birimleri için önerilir.

Tüm slaytlara aynı slayt boyutu ve en‑boy oranının uygulanmasıyla sunumunuzda tutarlılığı koruyun. En iyi sonucu elde etmek için, karmaşıklıkları önlemek amacıyla sunum oluşturma sürecinin başında slayt boyutlarınızı ayarlayın.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides kullanarak C++ içinde bir sunumda slayt boyutunu nasıl değiştireceğinizi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Sunumlarda Özel Slayt Boyutlarını Belirleme**

Ortak slayt boyutlarını (4:3 ve 16:9) çalışmanız için uygun bulmazsanız, belirli veya benzersiz bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzu özel bir sayfa düzeninde tam boyutta baskı almayı planlıyorsanız ya da sunumunuzu belirli ekran tiplerinde göstermek istiyorsanız, sunumunuz için özel bir boyut ayarı kullanmanız faydalı olacaktır.

Bu örnek kod, C++ için Aspose.Slides kullanarak bir sunum için özel bir slayt boyutu belirlemenin nasıl yapılacağını gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 kağıt boyutu
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini İşleme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin görüntüler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya başarmayı amaçladığınıza bağlı olarak bu ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını **istemiyorsanız**, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek istiyorsanız ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını sağlamasını (bu şekilde içerik kaybını önlersiniz) istiyorsanız, bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek istiyorsanız ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın.

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `Maximize` ayarının nasıl kullanılacağını gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **SSS**

**İnç dışında birimler (örneğin, puan veya milimetre) kullanarak özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak puanları kullanır; 1 puan bir inçin 1/72'sine eşittir. Milimetre veya santimetre gibi herhangi bir birimi puanlara dönüştürüp, dönüşmüş değerleri slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, renderleme sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği birleştirildiğinde, bellek tüketimi artar ve işleme süreleri uzar. Pratik bir slayt boyutuna odaklanın ve istenen çıktı kalitesine ulaşmak için render ölçeğini yalnızca gerektiği kadar ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştirme](/slides/tr/cpp/merge-presentation/) yapamazsınız — önce bir sunumu diğerine uyacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl işleneceğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Tek tek şekiller için ya da bir slaytın belirli bölgeleri için önizleme resimleri (thumbnail) oluşturabilir miyim ve bunlar yeni slayt boyutuna uyumlu olur mu?**

Evet. Aspose.Slides, [tam slaytlar](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/getimage/) için olduğu gibi [seçili şekiller](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getimage/) için de önizleme resimleri oluşturabilir. Ortaya çıkan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometriyi sağlar.