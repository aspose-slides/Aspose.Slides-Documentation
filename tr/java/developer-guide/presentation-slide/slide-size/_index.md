---
title: Sunum Slayt Boyutunu Java'da Değiştir
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
  - benzersiz slayt boyutu
  - tam boyutlu slayt
  - ekran tipi
  - ölçekleme yok
  - uygunluğu sağla
  - büyüt
  - PowerPoint
  - OpenDocument
  - sunum
  - Java
  - Aspose.Slides
descriptions: "Java ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırmayı öğrenin, kalite kaybı olmadan herhangi bir ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem yazdırma hem de ekranda görüntüleme için kritiktir.  

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En‑Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 En‑Boy Oranı)**: Modern projektörler ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, sunumu oluşturma sürecinin başında slayt boyutlarınızı ayarlayın; böylece komplikasyonlardan kaçınırsınız.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Java'da Aspose.Slides kullanarak bir sunumda slayt boyutunu nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sunumlarda Özel Slayt Boyutlarını Belirleme**

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzdan tam boyutlu slaytları özel bir sayfa düzeninde yazdırmayı planlıyorsanız ya da sunumunuzu belirli ekran tiplerinde görüntülemeyi amaçlıyorsanız, özel bir boyut ayarı kullanmanız muhtemelen faydalı olacaktır.  

Bu örnek kod, Java'da Aspose.Slides for Java kullanarak bir sunum için özel bir slayt boyutu nasıl belirleyeceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 kağıt boyutu
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yeniden Boyutlandırma Sonrası Slayt İçeriğini Yönetme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin görüntüler veya nesneler) bozulmuş olabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutu değiştirilirken, Aspose.Slides'in slaytlardaki içeriği nasıl ele alacağını belirleyen bir ayar belirtebilirsiniz.  

Ne yapmayı veya neyi başarmayı amaçladığınıza bağlı olarak, aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını **ISTEMİYORSANIZ**, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek istiyor ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını sağlamasını istiyorsanız (bu şekilde içerik kaybını önlersiniz), bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek istiyor ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın.

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

**İnç dışında birimler (örneğin puan veya milimetre) kullanarak özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides, dahili olarak puan birimini kullanır; 1 point bir inçin 1/72'sine eşittir. Herhangi bir birimi (milimetre veya santimetre gibi) puana dönüştürerek slayt genişliği ve yüksekliği olarak tanımlayabilirsiniz.

**Çok büyük bir özel slayt boyutu render (çizim) sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve daha yüksek render ölçeği, artan bellek tüketimi ve daha uzun işlem süresi ile sonuçlanır. Uygun bir slayt boyutu hedefleyin ve yalnızca istenen çıktı kalitesini elde etmek için render ölçeğini gerektiği gibi ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlarda sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştiremezsiniz](/slides/tr/java/merge-presentation/) — önce bir sunumun boyutunu diğerine eşitlemek gerekir. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl işlendiğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesizescaletype/) seçeneği ile belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekiller veya slaytın belirli bölgeleri için küçük resimler (thumbnail) oluşturabilir miyim ve bu yeni slayt boyutunu dikkate alacak mı?**

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) için olduğu gibi [seçili şekiller](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage-int-float-float-) için de küçük resimler oluşturabilir. Oluşan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometrinin sağlanmasını garantiler.