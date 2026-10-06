---
title: PHP'de Sunum Slayt Boyutunu Değiştir
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/php-java/slide-size/
keywords:
- slayt boyutu
- en/boy oranı
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
- ekran türü
- ölçeklendirme yapma
- uygunluğu sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PHP ve Aspose.Slides ile PPT, PPTX ve ODP dosyalarındaki slaytları hızlı bir şekilde yeniden boyutlandırmayı öğrenin, kalite kaybı olmadan tüm ekranlar için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en/boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem baskı hem de ekranda görüntüleme için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standart (4:3 En/Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En/Boy Oranı)**: Modern projektör ve ekranlar için önerilir.

Tüm slaytlar aynı slayt boyutu ve en/boy oranını kullandığından sunumunuzda tutarlılık sağlayın. En iyi sonuçlar için slayt boyutlarını sunum oluşturma sürecinin başında ayarlayın, böylece komplikasyonlardan kaçınmış olursunuz.

{{% alert color="info" title="Note" %}}
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en/boy oranını kullanır.
{{% /alert %}}

Not ve el ilanı sayfaları, normal slaytlardan ayrı boyutlara sahiptir. Boyut ve yönlerini değiştirmek için [Not Sayfası Boyutu](/slides/tr/php-java/notes-size/) sayfasına bakın.

## **Sunumlarda Slayt Boyutunu Değiştirin**

Bu örnek kod, Aspose.Slides kullanarak bir sunumda slayt boyutunun nasıl değiştirileceğini gösterir:

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

## **Sunumlarda Özel Slayt Boyutları Belirleyin**

Yaygın slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzdaki slaytları özel bir sayfa düzeninde tam boyutta yazdırmayı planlıyorsanız veya sunumunuzu belirli ekran tiplerinde görüntülemeyi düşünüyorsanız, özel bir boyut ayarı kullanmanız faydalı olacaktır.

Bu örnek kod, PHP üzerinden Java ile Aspose.Slides kullanarak bir sunum için özel slayt boyutu nasıl belirtilir gösterir:

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

## **Yeniden Boyutlandırma Sonrası Slayt İçeriğini Yönetme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin resimler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmak istediğinize bağlı olarak aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını istemiyorsanız bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek ve tüm nesnelerin slaytlara sığmasını sağlamak için Aspose.Slides'in nesneleri küçültmesini istiyorsanız (böylece içerik kaybını önlersiniz) bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek ve nesnelerin yeni slayt boyutuna orantılı olarak büyütülmesini istiyorsanız bu ayarı kullanın.

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

**Özel bir slayt boyutunu inç dışında birimlerle (örneğin puan veya milimetre) ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak puan kullanır; 1 puan 1/72 inçe eşittir. Herhangi bir birimi (milimetre veya santimetre gibi) puana dönüştürüp slayt genişliği ve yüksekliği olarak kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, oluşturma sırasında performansı ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği, bellek tüketimini artırır ve işleme süresini uzatır. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesini elde etmek için render ölçeğini yalnızca gerektiği kadar ayarlayın.

**Standart olmayan bir slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip sunumları [sunumları birleştirme](/slides/tr/php-java/merge-presentation/) sırasında birleştiremezsiniz; önce bir sunumu diğerine uyacak şekilde yeniden boyutlandırmanız gerekir. Slayt boyutunu değiştirirken mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Tek tek şekiller veya slaytın belirli bölgeleri için önizleme resimleri oluşturabilir miyim ve bunlar yeni slayt boyutunu dikkate alır mı?**

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) ve [seçili şekiller](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) için önizleme resimleri oluşturabilir. Oluşturulan görüntüler mevcut slayt boyutu ve en/boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.