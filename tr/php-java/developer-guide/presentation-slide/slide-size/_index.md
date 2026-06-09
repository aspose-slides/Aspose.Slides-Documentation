---
title: PHP'de Sunum Slayt Boyutunu Değiştir
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
- özel slayt boyutu
- özel slayt boyutu
- benzersiz slayt boyutu
- tam boy slayt
- ekran tipi
- yeniden ölçekleme
- sığdır
- büyüt
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
descriptions: "PHP ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızlı bir şekilde yeniden boyutlandırmayı, kalite kaybı olmadan herhangi bir ekran için sunumları optimize etmeyi öğrenin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar; bu, hem yazdırma hem de ekranda görüntüleme için kritiktir. 

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En-Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En-Boy Oranı)**: Modern projeksiyon cihazları ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tüm slaytlara tek bir slayt boyutu ve en‑boy oranı uygulanır. En iyi sonuçlar için, slayt boyutlarını sunum oluşturma sürecinin başında ayarlayın; böylece sorunların önüne geçilmiş olur.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

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

## **Sunumlarda Özel Slayt Boyutlarını Belirleme**

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmayı tercih edebilirsiniz. Örneğin, sunumunuzdaki tam boy slaytları özel bir sayfa düzeninde yazdırmayı planlıyor ya da sunumunuzu belirli ekran tiplerinde görüntülemeyi düşünüyorsanız, özel bir boyut ayarı kullanmanız faydalı olacaktır. 

Bu örnek kod, Java üzerinden PHP için Aspose.Slides kullanarak bir sunum için özel bir slayt boyutu nasıl belirtilir gösterir:

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

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini İşleme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin resimler ya da nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya ne elde etmeyi amaçladığınıza bağlı olarak, bu ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını İSTEMİYORSANIZ bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek istiyor ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını (böylece içeriği kaybetmemeyi) sağlamasını istiyorsanız bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek istiyor ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız bu ayarı kullanın.

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `Maximize` ayarının nasıl kullanılacağını gösterir:

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

## **SSS**

**Slayt boyutunu inç dışındaki birimlerle (örneğin, point ya da milimetre) ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak point birimini kullanır; 1 point 1/72 inç'e eşittir. Milimetre veya santimetre gibi herhangi bir birimi point'e dönüştürerek slayt genişliği ve yüksekliğini bu değerlerle tanımlayabilirsiniz.

**Çok büyük bir özel slayt boyutu, işleme sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (point cinsinden) ve yüksek işleme ölçeği, bellek tüketimini artırır ve işlem süresini uzatır. Pratik bir slayt boyutu hedefleyin ve yalnızca gerektiğinde çıktı kalitesini sağlamak için işleme ölçeğini ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştiremezsiniz](/slides/tr/php-java/merge-presentation/) — önce bir sunumu diğerine uygun boyuta yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl işleneceğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutlar eşitlendikten sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Tek tek şekiller veya bir slaytın belirli bölgeleri için küçük resimler (thumbnail) oluşturabilir miyim ve bu yeni slayt boyutunu göz önünde bulundurur mu?**

Evet. Aspose.Slides, [tam slaytlar](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) ve [seçili şekiller](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) için küçük resimler oluşturabilir. Oluşan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.