---
title: Android'de Sunum Slayt Boyutunu Değiştir
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/androidjava/slide-size/
keywords:
- slayt boyutu
- en boy oranı
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
- yeniden ölçekleme yapma
- uygunluğu sağla
- en büyük yap
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Java ve Aspose.Slides for Android ile PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırın, kalite kaybı olmadan herhangi bir ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarındaki slayt boyutunu ve en boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem baskı hem de ekran görüntüsü için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standart (4:3 En Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En Boy Oranı)**: Modern projeksiyon cihazları ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tek bir slayt boyutu ve en boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, karmaşayı önlemek amacıyla sunum oluşturma sürecinin başında slayt boyutlarınızı ayarlayın.

{{% alert color="info" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides kullanarak Java’da bir sunumda slayt boyutunu nasıl değiştireceğinizi gösterir:

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

## **Sunumlarda Özel Slayt Boyutlarını Belirleme**

Yaygın slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmayı seçebilirsiniz. Örneğin, sunumunuzdaki slaytları özel bir sayfa düzeninde tam boyutta yazdırmayı planlıyorsanız veya sunumunuzu belirli ekran tiplerinde görüntülemeyi amaçlıyorsanız, sunumunuz için özel bir boyut ayarı kullanmak size fayda sağlayabilir.

Bu örnek kod, Aspose.Slides for Android’i Java aracılığıyla kullanarak Java’da bir sunum için özel bir slayt boyutu nasıl belirleyeceğinizi gösterir:

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

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini Yönetme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içerikleri (örneğin görüntüler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna sığacak şekilde otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides’in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı amaçladığınıza bağlı olarak aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını **istemiyorsanız**, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklemek ve bütün nesnelerin slaytlara sığmasını sağlamak (içeriğin kaybolmasını önlemek) istiyorsanız, bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklemek ve nesnelerin yeni slayt boyutuna oranlayarak büyütülmesini istiyorsanız, bu ayarı kullanın.

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

### Özel bir slayt boyutunu inç dışındaki birimlerle (örneğin, nokta veya milimetre) ayarlayabilir miyim?

Evet. Aspose.Slides dahili olarak nokta birimini kullanır; 1 nokta bir inçin 1/72’sine eşittir. Herhangi bir birimi (milimetre veya santimetre gibi) noktalara dönüştürüp, dönüştürülmüş değerleri slayt genişliği ve yüksekliği olarak tanımlayabilirsiniz.

### Çok büyük bir özel slayt boyutu, render sırasında performans ve bellek kullanımını etkiler mi?

Evet. Daha büyük slayt boyutları (nokta cinsinden) ve yüksek render ölçeği, daha fazla bellek tüketimine ve daha uzun işleme sürelerine yol açar. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesini elde etmek için render ölçeğini yalnızca gerektiği kadar artırın.

### Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?

Farklı slayt boyutlarına sahip oldukları sürece [merge presentations](/slides/tr/androidjava/merge-presentation/) yapılamaz — önce bir sunumu diğerine göre yeniden boyutlandırmanız gerekir. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları eşitledikten sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

### Tek tek şekiller veya slaytın belirli bölgeleri için küçük resimler oluşturabilir miyim ve bu küçük resimler yeni slayt boyutunu göz önünde bulundurur mu?

Evet. Aspose.Slides, [entire slides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) için olduğu kadar [selected shapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) için de küçük resimler oluşturabilir. Oluşturulan görüntüler mevcut slayt boyutu ve en boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.