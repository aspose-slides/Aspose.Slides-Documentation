---
title: Slaytı SVG Görüntüsü Olarak Render Et
type: docs
weight: 50
url: /tr/net/render-slide-as-svg-image/
---
SVG—Scalable Vector Graphics (ölçeklenebilir vektör grafikler) kısaltmasıdır ve iki boyutlu görüntüler oluşturmak için kullanılan standart bir grafik türü veya biçimidir. SVG, görüntüleri davranışlarını veya görünümünü tanımlayan detaylarla XML içinde vektör olarak depolar.  

SVG, ölçeklenebilirlik, etkileşim, performans, erişilebilirlik, programlanabilirlik ve benzeri konularda çok yüksek standartları karşılayan çok az görüntü biçiminden biridir. Bu nedenlerle web geliştirmede yaygın olarak kullanılır.  

Aşağıdaki senaryolarda SVG dosyalarını kullanmak isteyebilirsiniz:

- Sunumunuzu çok büyük bir formatta yazdırmayı planladığınızda. SVG görüntüler, herhangi bir çözünürlüğe ya da seviyeye kadar ölçeklenebilir. Kalite kaybı olmadan SVG görüntülerini ihtiyacınız kadar yeniden boyutlandırabilirsiniz.
- Slaytlarınızdan grafik ve çizelgeleri farklı medya veya platformlarda kullanmak istediğinizde. Çoğu okuyucu SVG dosyalarını yorumlayabilir.
- Görüntülerin mümkün olan en küçük boyutlarda olmasını istediğinizde. SVG dosyaları, özellikle bitmap (JPEG veya PNG) tabanlı diğer formatların yüksek çözünürlüklü eşdeğerlerinden genellikle daha küçüktür.

Aspose.Slides for .NET, sunumlarınızdaki slaytları **SVG** görüntüsü olarak dışa aktarmanıza olanak tanır. Herhangi bir slayttan SVG görüntüsü üretmek için şu adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun.
- Sunumdaki tüm slaytlar üzerinde yineleme yapın.
- Her slaytı bir FileStream aracılığıyla kendi SVG dosyasına yazın.

{{% alert color="info" %}} 
SVG dönüşüm işlevini Aspose.Slides for .NET'ten uyguladığımız [free web application](https://products.aspose.app/slides/tr/conversion/ppt-to-svg) deneyebilirsiniz.
{{% /alert %}} 

Bu C# örnek kodu, Aspose.Slides kullanarak PPT'yi SVG'ye nasıl dönüştüreceğinizi gösterir:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```