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
- özel slayt boyutu
- eşsiz slayt boyutu
- tam boyutlu slayt
- ekran tipi
- ölçekleme yok
- uygunluğu sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
descriptions: "Java ve Aspose.Slides for Android ile PPT, PPTX ve ODP dosyalarındaki slaytları hızla yeniden boyutlandırarak, kalite kaybı olmadan herhangi bir ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar; bu, hem baskı hem de ekran görüntüsü için kritiktir. 

Popüler Slayt Boyutları ve Oranları:

- **Standart (4:3 En-Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En-Boy Oranı)**: Modern projektörler ve ekranlar için tavsiye edilir.

Sunumunuz boyunca tutarlılığı sağlayın; tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için slayt ölçülerinizi sunum oluşturma sürecinin başında ayarlayın, böylece komplikasyonlardan kaçınılır.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides kullanarak Java'da bir sunumun slayt boyutunu nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sunumlarda Özel Slayt Boyutları Belirleme**

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli ya da özgün bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzdan tam boyutlu slaytları özel bir sayfa düzeninde yazdırmayı planlıyorsanız ya da sunumunuzu belirli ekran tiplerinde göstermeyi amaçlıyorsanız, özel bir boyut ayarı kullanmanız faydalı olacaktır. 

Bu örnek kod, Java üzerinden Aspose.Slides for Android kullanarak bir sunum için özel bir slayt boyutu nasıl belirtileceğini gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 kağıt boyutu
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini Yönetme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin resimler veya nesneler) bozulabilir. Varsayılan olarak nesneler otomatik olarak yeni slayt boyutuna sığacak şekilde yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl ilgileneceğini belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı ya da ulaşmayı amaçladığınıza bağlı olarak, aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Eğer slaytlardaki nesnelerin yeniden boyutlandırılmasını istemiyorsanız, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklemek istiyorsanız ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını sağlamasını (böylece içeriği kaybetmezsiniz) istiyorsanız, bu ayarı kullanın. 

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklemek istiyorsanız ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna göre orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın. 

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `Maximize` ayarının nasıl kullanılacağını gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**İnç dışında birimlerle (örneğin puan veya milimetre) özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak puan (point) kullanır; 1 puan 1/72 inçtir. Herhangi bir birimi (örneğin milimetre ya da santimetre) puana dönüştürüp, bu dönüştürülmüş değerleri slayt genişliği ve yüksekliği olarak tanımlayabilirsiniz.

**Çok büyük bir özel slayt boyutu, render sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği, bellek tüketimini artırır ve işleme sürelerini uzatır. Pratik bir slayt boyutu hedefleyin ve yalnızca istenen çıktı kalitesine ulaşmak için render ölçeğini gerektiği gibi ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştiremezsiniz](/slides/tr/androidjava/merge-presentation/) — önce bir sunumun boyutunu diğerine eşitleyin. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları eşitledikten sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bir slayttaki tek tek şekiller veya belirli bölgeler için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutuna uyumlu olur mu?**

Evet. Aspose.Slides, [tam slaytlar](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ve [seçili şekiller](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) için küçük resimler oluşturabilir. Oluşan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtır, bu da tutarlı çerçeveleme ve geometri sağlar.