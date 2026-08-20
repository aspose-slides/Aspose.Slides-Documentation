---
title: PPT'yi .NET'te PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/net/convert-ppt-to-pptx/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e aktar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides ile .NET'te eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notaları için C# örneklerini içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for .NET, bir PPT dosyasını Microsoft PowerPoint olmadan yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, tek bir dosyayı veya bir dosya dizinini nasıl dönüştüreceğinizi gösterir ve dönüşüm sonrasında neyin doğrulanması gerektiğini açıklar.

## **Bir PPT Dosyasını PPTX'e Dönüştürme**

Kaynak dosyayı [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı ile yükleyin, ardından [IPresentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/save/) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) ile çağırın. `using` bildirimi, kapsam sona erdiğinde sunumu temizler ve kaynaklarını serbest bırakır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Eski PPT sunumunu yükle.
using var presentation = new Presentation("presentation.ppt");

// Sunumu PPTX formatında kaydet.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Dosya uzantısı tek başına çıktı formatını seçmez; bu işlevi [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) argümanı yapar. Orijinal PPT dosyasını korumanız gerekiyorsa, giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştürme**

Aşağıdaki örnek, bir dizindeki her `.ppt` dosyasını dönüştürür. Her dosya bağımsız olarak işlenir, bu nedenle bir dönüştürme hatası diğer batch işlemlerini durdurmaz.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

Üretim işleri için, tam istisna kaydını tutun, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağını belirleyin ve başarısız dosya adlarını yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gereken şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerik, dönüşümün başarısız olmasına yol açabilir. Şifreli dosyaları yüklemek için [Şifre Koruması Olan Sunumlar](/slides/tr/net/password-protected-presentation/) bölümüne bakın.

## **Doğruluk ve Eski Özellikler**

Dönüştürme genellikle slaytları, ana slaytları, düzenleri, metni, şekilleri, resimleri, tabloları ve grafikleri korur. Ancak, PPT ve PPTX her özelliği tam olarak aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX karşılığı olmayan bir eski özellik, normalleştirilebilir, çıkarılabilir veya farklı şekilde görüntülenebilir.

Dönüştürülen dosyayı, animasyonlar, geçişler, gömülü veya bağlanmış OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir kullanılan yazı tipleri veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro etkin bir format değildir; bu nedenle VBA’nın kullanılabilir olması gerektiğinde uygun bir makro‑etkin iş akışı kullanın. Ayrıca, dönüştürülmüş sunumun açılacağı veya işleneceği ortamda gerekli yazı tipleri ve dış kaynakların mevcut olduğunu doğrulayın.

Önemli belgeler için, oluşturulan PPTX’i programlı olarak yeniden açın ve temel slayt sayısını ve içeriğini inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedef görüntüleyicide karşılaştırın. Başarılı bir [IPresentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/save/) çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunu kanıt olarak görmeyin.

## **Ne Zaman PPTX Kullanmalı**

Sunum mevcut PowerPoint sürümlerinde düzenlenecekse, Open XML paketleri ile çalışan sistemlerle değiş tokuş yapılacaksa veya eski ikili PPT’ye göre incelemesi ve kurtarılması daha kolay bir formatta saklanacaksa PPTX kullanın. Dönüştürülmüş sunum doğruluk kontrollerinizi geçene kadar orijinal PPT’yi arşiv veya geri dönüş kopyası olarak saklayın.

PDF, HTML, görüntüler, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruyacağını varsaymak yerine [Sunumları Çoklu Formata Dönüştürme](/slides/tr/net/convert-presentation/) bölümündeki format‑spesifik rehberi kullanın.

## **Çevrimiçi Dönüştürücü**

Aralıklı bir dosya veya hızlı bir karşılaştırma için [çevrimiçi PPT to PPTX dönüştürücüyü](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) kullanabilirsiniz. Tekrarlayan dönüşümler, toplu işleme veya uygulama düzeyinde hata yönetimi için .NET API’yı kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/slides/tr/net/ppt-vs-pptx/)
- [.NET’te Sunumları Kaydet](/slides/tr/net/save-presentation/)
- [Desteklenen Dosya Formatları](/slides/tr/net/supported-file-formats/)
- [.NET’te Sunumları Aç](/slides/tr/net/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for .NET, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski veya desteklenmeyen özellik için tam doğruluk garanti edilmez. Oluşturulan dosyayı, makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir kullanılan yazı tipleri içerdiğinde gözden geçirin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Eksik ya da yanlış şifre, yükleme işleminin başarısız olmasına neden olur.

**Dönüşümden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyiciler ve iş akışlarında doğrulayana kadar tutun. Bu, bir eski özelliğin farklı dönüştürülmesi durumunda geri dönüş kopyası sağlar.