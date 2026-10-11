---
title: Java'da Sunum Slayt Boyutunu Değiştirme
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/java/slide-size/
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
- eşsiz slayt boyutu
- tam boyutlu slayt
- ekran türü
- ölçeklendirme yapma
- uyumu sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızla yeniden boyutlandırmayı, kalite kaybı olmadan herhangi bir ekran için sunumları optimize etmeyi öğrenin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem yazdırma hem de ekranda görüntüleme için kritiktir. 

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En‑Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 En‑Boy Oranı)**: Modern projektör ve ekranlar için tavsiye edilir.

Sunumunuz boyunca tutarlılığı sağlamak için tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, slayt boyutlarınızı sunumu oluşturma sürecinin başında ayarlayın; bu, komplikasyonları önler.

{{% alert color="info" title="Note" %}}
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

Notlar ve el ilanı sayfaları, normal slaytlardan farklı boyutlara sahiptir. Boyut ve yönlerini değiştirmek için [Notes Page Size](/slides/tr/java/notes-size/) sayfasına bakın.

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Java'da Aspose.Slides kullanarak bir sunumda slayt boyutunu nasıl değiştireceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sunumlarda Özel Slayt Boyutlarını Belirleme**

Ortak slayt boyutlarını (4:3 ve 16:9) işiniz için uygun bulmazsanız, belirli ya da benzersiz bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzdan tam boyutlu slaytları özel bir sayfa düzeninde yazdırmayı planlıyorsanız ya da sunumunuzu belirli ekran tiplerinde görüntülemeyi düşünüyorsanız, sunumunuz için özel bir boyut ayarı kullanmak size fayda sağlayabilir.

Bu örnek kod, Java'da Aspose.Slides for Java kullanarak bir sunum için özel bir slayt boyutu nasıl belirleyeceğinizi gösterir:

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

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini İşleme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin görüntüler veya nesneler) bozulmuş olabilir. Varsayılan olarak, nesneler yeni slayt boyutuna sığacak şekilde otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya başarmayı amaçladığınıza bağlı olarak, aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını İSTEMEYİN, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek istiyorsanız ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını sağlamasını (böylece içerik kaybını önlersiniz) istiyorsanız, bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek istiyorsanız ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı hale getirecek şekilde büyütmesini istiyorsanız, bu ayarı kullanın.

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

**Özel bir slayt boyutunu inç dışında birimlerle (örneğin puan veya milimetre) ayarlayabilir miyim?**

Evet. Aspose.Slides, dahili olarak puan (point) birimini kullanır; 1 puan 1/72 inç eder. Herhangi bir birimi (örneğin milimetre veya santimetre) puana dönüştürüp, dönüştürülmüş değerleri slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, oluşturma sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek oluşturma ölçeği birleştiğinde, bellek tüketimi artar ve işleme süresi uzar. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesine ulaşmak için oluşturma ölçeğini yalnızca gerektiğinde ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştiremezsiniz](/slides/tr/java/merge-presentation/) — önce bir sunumun boyutunu diğerine eşitlemek için yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekiller veya bir slaydın belirli bölgeleri için küçük görseller oluşturabilir miyim ve bunlar yeni slayt boyutuna uyumlu olur mu?**

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ve [seçili şekiller](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage-int-float-float-) için küçük görseller oluşturabilir. Oluşturulan resimler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.