---
title: Android'de Sunum Slayt Boyutunu Değiştir
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/androidjava/slide-size/
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
- spesifik slayt boyutu
- eşsiz slayt boyutu
- tam boyutlu slayt
- ekran türü
- ölçekleme yapma
- uyumu sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Java ve Aspose.Slides for Android ile PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırın, kaliteden ödün vermeden her ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar; bu, hem baskı hem de ekran gösterimi için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 Aspect Ratio)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 Aspect Ratio)**: Modern projeksiyon cihazları ve ekranlar için önerilir.

Tüm slaytlarda tek bir slayt boyutu ve en‑boy oranı kullanarak tutarlılığı sağlayın. En iyi sonuçlar için slayt boyutlarını sunum oluşturma sürecinin başında ayarlayın; böylece komplikasyonların önüne geçilir.

{{% alert color="info" title="Note" %}}
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

Not ve el yazısı sayfaları, normal slaytlardan farklı boyutlara sahiptir. Boyut ve yönelimlerini değiştirmek için [Not Sayfa Boyutu](/slides/tr/androidjava/notes-size/) sayfasına bakın.

## **Sunumlarda Slayt Boyutunu Değiştir**

Bu örnek kod, Java’da Aspose.Slides kullanarak bir sunumda slayt boyutunu nasıl değiştireceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sunumlarda Özel Slayt Boyutlarını Belirle**

Yaygın slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmayı tercih edebilirsiniz. Örneğin, sunumunuzdan tam boyutta slaytları özel bir sayfa düzeninde yazdırmayı planlıyorsanız veya sunumunuzu belirli ekran tiplerinde göstermek istiyorsanız, özel bir boyut ayarıyla fayda sağlayabilirsiniz.

Bu örnek kod, Java üzerinden Aspose.Slides for Android kullanarak bir sunum için özel slayt boyutu nasıl belirlenir gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 kağıt boyutu
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kaydırma Sonrası Slayt İçeriklerini İşleme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin resimler veya nesneler) bozulabilir. Varsayılan olarak nesneler yeni slayt boyutuna sığacak şekilde otomatik yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides’in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar seçebilirsiniz.

Ne yapmayı planladığınıza bağlı olarak aşağıdaki ayarlardan birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını **istemiyorsanız** bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek ve tüm nesnelerin slaytlara sığmasını sağlamak (içeriğin kaybolmasını önlemek) istiyorsanız bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek ve nesneleri yeni slayt boyutuna orantılı olarak büyütmek istiyorsanız bu ayarı kullanın.

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `Maximize` ayarının nasıl kullanılacağını gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Özel bir slayt boyutunu inç dışındaki birimlerle (örneğin puan veya milimetre) ayarlayabilir miyim?**

Evet. Aspose.Slides içsel olarak puan kullanır; 1 puan 1/72 inçe eşittir. Milimetre veya santimetre gibi birimleri puana dönüştürüp slayt genişliği ve yüksekliğini bu değerlerle tanımlayabilirsiniz.

**Çok büyük bir özel slayt boyutu, render sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği, bellek tüketimini artırır ve işlem süresini uzatır. İstenen çıktı kalitesine ulaşmak için pratik bir slayt boyutu seçin ve render ölçeğini yalnızca gerektiğinde ayarlayın.

**Standart dışı bir slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip olduğunda [sunumları birleştir](/slides/tr/androidjava/merge-presentation/) **yapamazsınız**; önce bir sunumu diğerine eşit boyuta yeniden boyutlandırın. Slayt boyutunu değiştirirken mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra formatı koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekillerin veya slaytın belirli bölgelerinin küçük resimlerini oluşturabilir miyim ve bu yeni slayt boyutunu dikkate alır mı?**

Evet. Aspose.Slides, [tam slaytların](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) yanı sıra [seçili şekillerin](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) küçük resimlerini oluşturabilir. Oluşan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeve ve geometri sağlar.