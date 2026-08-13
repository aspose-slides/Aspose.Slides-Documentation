---
title: Java'da Sunum Slayt Boyutunu Değiştir
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
- ölçeklendirme yok
- uygunluğu sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızlı bir şekilde yeniden boyutlandırmayı, herhangi bir ekranda kalite kaybı olmadan sunumları optimize etmeyi öğrenin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar; bu, hem yazdırma hem de ekranda görüntüleme için kritiktir. 

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En‑Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En‑Boy Oranı)**: Modern projektörler ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılık sağlayın; tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, slayt boyutlarınızı sunum oluşturma sürecinin başında ayarlayın, böylece sorunlardan kaçınırsınız.

{{% alert color="info" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

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

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzdan tam boyutta slaytları özel bir sayfa düzeninde yazdırmayı planlıyorsanız veya sunumunuzu belirli ekran tiplerinde göstermek istiyorsanız, özel bir boyut ayarı kullanmanız faydalı olacaktır. 

Bu örnek kod, Java'da Aspose.Slides for Java kullanarak bir sunum için özel bir slayt boyutu belirtmenin nasıl yapılacağını gösterir:

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

## **Yeniden Boyutlandırma Sonrası Slayt İçeriğini Yönetme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin resimler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna sığacak şekilde otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya neyi başarmayı istediğinize bağlı olarak, aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını İSTEMİYORSANIZ, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek istiyorsanız ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını (böylece içeriğin kaybolmasını önlemek) sağlamasını istiyorsanız, bu ayarı kullanın. 

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek istiyorsanız ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın. 

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

### Özel bir slayt boyutunu inç dışında bir birim (örneğin, puan veya milimetre) kullanarak ayarlayabilir miyim?

Evet. Aspose.Slides dahili olarak puan birimini kullanır; 1 puan 1/72 inçtir. Herhangi bir birimi (örneğin milimetre veya santimetre) puana dönüştürerek slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

### Çok büyük bir özel slayt boyutu, oluşturma sırasında performans ve bellek kullanımını etkiler mi?

Evet. Daha büyük slayt boyutları (puan olarak) ve yüksek oluşturma ölçeği birlikte bellek tüketimini artırır ve işleme sürelerini uzatır. Kullanışlı bir slayt boyutu hedefleyin ve istenen çıktı kalitesine ulaşmak için yalnızca gerektiğinde oluşturma ölçeğini ayarlayın.

### Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştiremezsiniz](/slides/tr/java/merge-presentation/) — önce bir sunumu diğerine eşit olacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutlar eşitlendiğinde, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

### Tek tek şekiller veya bir slaydın belirli bölgeleri için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutuna saygı gösterecek mi?

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ve [seçili şekiller](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage-int-float-float-) için küçük resimler oluşturabilir. Oluşturulan görseller mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.