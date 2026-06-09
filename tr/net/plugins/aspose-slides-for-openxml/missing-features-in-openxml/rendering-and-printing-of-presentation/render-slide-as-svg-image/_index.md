---
title: Slaytı SVG Görüntüsü Olarak Oluştur
type: docs
weight: 50
url: /tr/net/render-slide-as-svg-image/
---
SVG—Scalable Vector Graphics'in kısaltmasıdır— iki boyutlu görüntüler oluşturmak için kullanılan standart bir grafik türü veya formatıdır. SVG, görüntüleri davranışlarını veya görünümünü tanımlayan ayrıntılarla XML içinde vektör olarak depolar. 

SVG, ölçeklenebilirlik, etkileşim, performans, erişilebilirlik, programlanabilirlik ve benzeri konularda çok yüksek standartları karşılayan birkaç görüntü formatından biridir. Bu nedenlerle, web geliştirmede yaygın olarak kullanılır. 

Aşağıdaki senaryolarda SVG dosyalarını kullanmak isteyebilirsiniz:

- sunumunuzu çok büyük bir formatta yazdırmayı planladığınızda. SVG görüntüler, herhangi bir çözünürlük veya seviyeye ölçeklenebilir. Kaliteden ödün vermeden SVG görüntülerini gerektiği kadar yeniden boyutlandırabilirsiniz.
- slaytlarınızdaki grafik ve çizelgeleri farklı ortamlar veya platformlarda kullanmayı düşündüğünüzde. Çoğu okuyucu SVG dosyalarını yorumlayabilir. 
- mümkün olan en küçük görüntü boyutlarını kullanmanız gerektiğinde. SVG dosyaları, genellikle diğer formatlardaki yüksek çözünürlüklü eşdeğerlerinden daha küçüktür, özellikle bitmap tabanlı (JPEG veya PNG) formatlardan.

Aspose.Slides for .NET, sunumlarınızdaki slaytları **SVG** görüntüleri olarak dışa aktarmanıza olanak tanır. Herhangi bir slayttan SVG görüntüsü oluşturmak için şunları yapın:

- Presentation sınıfının bir örneğini oluşturun.
- sunumdaki tüm slaytlar arasında döngü yapın.
- her slaytı FileStream aracılığıyla kendi SVG dosyasına yazın.

{{% alert color="primary" %}} 

Aspose.Slides for .NET'ten PPT'den SVG'ye dönüşüm işlevini uyguladığımız [ücretsiz web uygulaması](https://products.aspose.app/slides/tr/conversion/ppt-to-svg) denemek isteyebilirsiniz.

{{% /alert %}} 

Bu C# örnek kod, Aspose.Slides kullanarak PPT'yi SVG'ye nasıl dönüştüreceğinizi gösterir:

``` csharp
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