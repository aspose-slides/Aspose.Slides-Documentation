---
title: PHP'de Sunum Slayt Boyutunu Değiştirin
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/php-java/slide-size/
keywords:
- slayt boyutu
- en-boy oranı
- standart
- geniş ekran
- 4:3
- 16:9
- slayt boyutunu ayarla
- slayt boyutunu değiştir
- özelleştirilmiş slayt boyutu
- özel slayt boyutu
- benzersiz slayt boyutu
- tam boyutlu slayt
- ekran tipi
- yeniden ölçeklendirme
- uyumu sağla
- en çok büyüt
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PHP ve Aspose.Slides ile PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırmayı öğrenin, herhangi bir ekranda kalite kaybı olmadan sunumları optimize edin."
---
## **Introduction**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem baskı hem de ekran görüntüsü için kritiktir. 

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En-Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 En-Boy Oranı)**: Modern projektörler ve gösterimler için önerilir.

Tüm slaytlara tek bir slayt boyutu ve en‑boy oranı uygulanacağından sunumunuz boyunca tutarlılık sağlayın. En iyi sonuçlar için, karmaşıklıkları önlemek amacıyla sunum oluşturma sürecinin başında slayt boyutlarınızı ayarlayın.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Change the Slide Size in Presentations**

Bu örnek kod, Aspose.Slides kullanarak bir sunumda slayt boyutunu nasıl değiştireceğinizi gösterir:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Specify Custom Slide Sizes in Presentations**

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzdan tam boy slaytlar yazdırmayı özel bir sayfa düzeninde planlıyorsanız veya sunumunuzu belirli ekran tiplerinde görüntülemeyi amaçlıyorsanız, özel bir boyut ayarı kullanmak size fayda sağlayabilir. 

Bu örnek kod, Java üzerinden PHP için Aspose.Slides kullanarak bir sunum için özel bir slayt boyutu nasıl belirtileceğini gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4 kağıt boyutu

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Handle Slide Content After Resizing**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin görüntüler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna sığacak şekilde otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya neyi başarmayı hedeflediğinize bağlı olarak aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını **İSTEMİYORSANIZ**, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını sağlamak (böylece içeriği kaybetmezsiniz) istiyorsanız, bu ayarı kullanın. 

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın. 

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `Maximize` ayarını nasıl kullanacağınızı gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Ölçü birimi olarak inç dışındaki birimleri (örneğin, nokta veya milimetre) kullanarak özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak nokta (point) birimini kullanır; 1 nokta bir inçin 1/72'sine eşittir. Herhangi bir birimi (örneğin milimetre veya santimetre) noktalara dönüştürüp bu değerleri slayt genişliği ve yüksekliği tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, renderlama sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (nokta cinsinden) ve daha yüksek renderleme ölçeği, bellek tüketimini artırır ve işlem sürelerini uzatır. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesine ulaşmak için renderleme ölçeğini yalnızca gerektiğinde ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [merge presentations](/slides/tr/php-java/merge-presentation/) yapamazsınız — önce bir sunumu diğerine uygun boyuta yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl işleneceğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bir slaydın tek tek şekilleri veya belirli bölgeleri için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutunu dikkate alacak mı?**

Evet. Aspose.Slides, [entire slides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) ve [selected shapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) için küçük resimler oluşturabilir. Oluşturulan görüntüler, mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometriyi sağlar.