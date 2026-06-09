---
title: C++ ile Sunum Slayt Boyutunu Değiştir
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/cpp/slide-size/
keywords:
- slayt boyutu
- en‑boy oranı
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
- ölçeklendirme yapma
- sığdırmayı sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
descriptions: "C++ ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızlı bir şekilde yeniden boyutlandırmayı öğrenin, kalite kaybetmeden herhangi bir ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında baskı ve ekranda görüntüleme için kritik olan slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar. 

Popüler Slayt Boyutları ve Oranları:

- **Standart (4:3 En Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En Boy Oranı)**: Modern projektörler ve ekranlar için önerilir.

Tüm slaytlarda aynı slayt boyutu ve en‑boy oranının uygulanmasıyla tutarlılığı sağlayın. En iyi sonuçlar için slayt boyutlarını sunum oluşturma sürecinin başında belirleyin; aksi takdirde sorunlarla karşılaşabilirsiniz.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides for C++ kullanarak bir sunumda slayt boyutunun nasıl değiştirileceğini gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Sunumlarda Özel Slayt Boyutlarını Belirleme**

Ortak slayt boyutları (4:3 ve 16:9) işinize uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmayı tercih edebilirsiniz. Örneğin, sunumunuzdan tam boyutlu slaytları özelleştirilmiş bir sayfa düzeninde yazdırmayı planlıyorsanız veya sunumunuzu belirli ekran tiplerinde görüntülemeyi amaçlıyorsanız, özel bir boyut ayarı kullanmak sizin için faydalı olacaktır. 

Bu örnek kod, Aspose.Slides for C++ kullanarak C++ içinde bir sunum için özel bir slayt boyutu nasıl belirtileceğini gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 kağıt boyutu
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini İşleme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin resimler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken Aspose.Slides'in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar seçebilirsiniz.

Ne yapmak istediğinize bağlı olarak şu ayarlardan birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını **İSTEMİYORSANIZ**, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklemek ve tüm nesnelerin slaytlara sığmasını sağlamak (içeriğin kaybolmasını önlemek) için Aspose.Slides'in nesneleri küçültmesini istiyorsanız, bu ayarı kullanın. 

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklemek ve nesnelerin yeni slayt boyutuna orantılı olarak büyütülmesini istiyorsanız, bu ayarı kullanın. 

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `Maximize` ayarının nasıl kullanılacağını gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **SSS**

**Ölçü birimi olarak inç dışında birimler (örneğin nokta veya milimetre) kullanarak özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak nokta birimini kullanır; 1 nokta 1/72 inçe eşittir. Herhangi bir birimi (milimetre veya santimetre gibi) noktalara dönüştürüp slayt genişliği ve yüksekliğini bu değerlerle tanımlayabilirsiniz.

**Çok büyük bir özel slayt boyutu, oluşturma sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (nokta cinsinden) ve yüksek oluşturma ölçeği, bellek tüketimini artırır ve işleme süresini uzatır. Pratik bir slayt boyutu hedefleyin ve yalnızca ihtiyaç duyduğunuz kalitede render ölçeğini ayarlayın.

**Standart olmayan bir slayt boyutu tanımlayıp ardından farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştirme](/slides/tr/cpp/merge-presentation/) yapamazsınız — önce bir sunumu diğerine eşit boyuta getirin. Slayt boyutunu değiştirirken mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra formatlamayı koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekiller veya bir slaydın belirli bölgeleri için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutunu dikkate alır mı?**

Evet. Aspose.Slides, [tam slaytlar](/slides/tr/cpp/merge-presentation/) için ve ayrıca [seçili şekiller](/slides/tr/cpp/merge-presentation/) için küçük resimler oluşturabilir. Oluşturulan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.