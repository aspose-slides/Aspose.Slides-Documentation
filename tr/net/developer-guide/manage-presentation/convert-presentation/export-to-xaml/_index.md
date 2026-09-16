---
title: Sunumları .NET'te XAML'ye Dışa Aktarma
linktitle: Sunumu XAML'ye
type: docs
weight: 30
url: /tr/net/export-to-xaml/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunumu dışa aktar
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- PowerPoint'ten XAML'ye
- OpenDocument'ten XAML'ye
- sunumdan XAML'ye
- PPT'den XAML'ye
- PPTX'den XAML'ye
- ODP'den XAML'ye
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'ye dışa aktar
- PPTX'i XAML'ye dışa aktar
- ODP'yi XAML'ye dışa aktar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te PowerPoint ve OpenDocument slaytlarını XAML'ye dönüştürün—düzeninizi bozmayan hızlı, Office gerektirmeyen bir çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML'ye nasıl dışa aktaracağınızı açıklar. XAML'e kısa bir giriş içerir, bir sunumun varsayılan ayarlarla XAML'ye nasıl kaydedileceğini gösterir ve gizli slaytların dışa aktarılması dahil olmak üzere dışa aktarmayı [XamlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/xamloptions/) aracılığıyla nasıl özelleştireceğinizi gösterir. Makale ayrıca geri dönüş fontları, XAML yığını uyumluluğu ve gizli slayt dışa aktarma davranışıyla ilgili birkaç yaygın soruya yanıt verir.

## **XAML Hakkında**

XAML, WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin.Forms gibi çerçevelerde kullanıcı arabirimlerini tanımlamak için kullanılan bir XML tabanlı işaretleme dilidir.

XAML dosyalarıyla görsel bir tasarımcıda çalışabilir veya işaretlemeyi doğrudan yazıp düzenleyebilirsiniz.

## **Varsayılan Seçeneklerle Sunumları XAML'ye Dışa Aktarma**

Aşağıdaki C# örneği, bir sunumu varsayılan ayarlarla XAML'ye nasıl dışa aktaracağınızı gösterir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Varsayılan olarak, dışa aktarılan slaytlar, [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory) tarafından döndürülen süreç çalışma dizininin bir `pres` alt klasörüne kaydedilir. Klasör otomatik olarak oluşturulur ve gerekli olan tüm görüntüler de oraya kaydedilir.

Çıktı klasörü adı, uzantısı olmadan kaynak dosya adından alınır. `pres.pptx` için çıktı dosyaları `pres/Slide_1.xaml`, `pres/Slide_2.xaml` vb. olarak adlandırılır. Giriş sunumuna mutlak bir yol verdiğinizde bile, çıktı klasörü giriş dosyasının yanına değil, mevcut çalışma dizinine göre oluşturulur.

## **Özel Seçeneklerle Sunumları XAML'ye Dışa Aktarma**

Aspose.Slides'in bir sunumu XAML'ye nasıl dışa aktardığını kontrol etmek için [IXamlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/ixamloptions/) arayüzünü kullanın.

Çıktıyı özel bir konuma kaydetmek için [IXamlOutputSaver](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/ixamloutputsaver/) uygulayın ve örnek bir uygulamayı [XamlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/xamloptions/) içindeki [OutputSaver](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/xamloptions/outputsaver/) özelliğine atayın.

Gizli slaytları XAML çıktısına dahil etmek için, aşağıdaki C# örneğinde gösterildiği gibi [ExportHiddenSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) özelliğini `true` olarak ayarlayın:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Oluşturulan Tüm XAML Ürünlerini Yakalama**

Bir XAML dışa aktarımı, dışa aktarılan her slayt için bir XAML belgesi ile ayrıca görüntüler ve destekleyici kaynaklar üretebilir. Bu ürünleri varsayılan dosya sistemi kaydedicisini kullanmak yerine almak için özelleştirilmiş bir [IXamlOutputSaver](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/ixamloutputsaver/) atayın. XAML seçeneklerini kabul eden [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) aşırı yüklemesiyle dışa aktarmayı başlatın.

### **Geri Arama Yaşam Döngüsünü Anlama**

Dışa aktarım, üretilen her ürün için [IXamlOutputSaver.Save](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/ixamloutputsaver/save/) metodunu ayrı ayrı çağırır:

- `path` ürünü tanımlar ve göreli dizinler içerebilir. XAML, kaynakları göreli yollarla referans gösterebileceği için bu bilgiyi koruyun.
- `data` ürünün baytlarını içerir. Görüntüler ve diğer ikili kaynaklar metin olarak çözülecek şekilde işlenmemelidir.
- Kaydedici, veriyi geri dönmeden önce saklamaktan veya kalıcı hale getirmekten sorumludur. Örneklerde her bayt dizisi uygulamaya ait belleğe kopyalanır.
- Sunum kaydetme işlemi döndüğünde ve her geri arama başarılı bir şekilde tamamlandığında dışa aktarımı başarılı kabul edin. Depolama hatalarını yutmayın veya gözden kaçan arka plan yazmalarını başlatmayın. Kalıcı hale getirme daha sonra gerçekleşiyorsa, bütün adım da başarılı olduğunda genel başarıyı raporlayın.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) özelliği özelleştirilmiş bir kaydediciye de uygulanır. Varsayılan değeri `false` olduğundan gizli slayt XAML belgeleri dışarıda bırakılır. `true` olarak ayarlandığında bunlar ve dışa aktarımları için gerekli tüm kaynaklar dahil edilir. Kaynak sayısı sunuma bağlıdır; slayt başına bir geri arama ya da sabit bir geri arama sırası varsaymayın.

### **Belleğe Dışa Aktar ve Ürünleri İncele**

Bu tam örnek, `pres.pptx` dosyasını yükler, her ürünü bir [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) içinde toplar ve adını, türünü ve bayt sayısını yazar. Sağlanan adları tam olarak korur. Aynı ada sahip birden fazla ürün koleksiyonu hataya yol açar, sessizce üzerine yazmaz.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Yalnızca XAML'i çöz, ve yalnızca metin incelemesi gerektiğinde.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Uygulamanızdan `InMemoryXamlExample.Run` metodunu çağırın. Uzantı kontrolleri inceleme için yararlıdır; tanıdık olmayan kaynak türleri dahil tüm ürünleri tutun. Baytları depolarken veya iletirken değiştirmeyin. Yalnızca metin işleme gerektiren XAML için [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) kullanın.

### **Toplanan Ürünleri ZIP Arşivine Paketleme**

Bu bağımsız örnek dışa aktarmayı toplar, adlarını doğrular ve özgün baytları bir ZIP arşivine yazar. Eş zamanlı dışa aktarma işlerini ayırmak için benzersiz bir arşiv adı kullanılır. ZIP girdileri ileri eğik çizgi (`/`) içerir ve göreli dizinleri korur. Normalizasyon sonrası çakışan veya güvensiz adlar paket tümü yazılmadan önce reddedilir.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // ZIP dizini, başarı raporlanmadan önce disposal ile sonlandırıldı.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Uygulamanızdan `ZipXamlExample.Run` metodunu çağırın. Örnek, bir yerel arşiv yazmak için [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) kullanır; dışa aktarıcı gevşek XAML veya görüntü dosyaları yazmaz. Uzaktan depolama için, arşiv‑yazma aşamasını toplanan bayt dizilerinin yüklenmesiyle değiştirin. Bir dışa aktarma işi kimliği ile tam göreli ürün adını bir blob anahtarı olarak kullanın veya iş kimliği, göreli ad ve ikili veriyi bir veri tabanı satırında saklayın. Tüm yüklemeler tamamlandığında veya veritabanı işlemi onaylandığında işi yayınlayın. Kalıcı hâle getirme başarısız olursa kısmi çıktıyı temizleyin.

Büyük sunumlar için, özelleştirilmiş bir kaydedici her ürünü doğrudan uygulama depolamasına kalıcı hâle getirebilir; bu, tüm dışa aktarmanın uygulama belleğinde ek bir kopyasını tutmayı önler. Dışa aktarıcı hâlâ tüm ürünleri bellekte toplar, ardından kaydediciye çağırır. Kaydedicinin bakış açısından her geri aramayı eşzamanlı tutun: baytlar hedefe kabul edilene kadar döndürmeyin ve hataların çağırıcıya ulaşmasına izin verin.

### **Kaynak İsimlerini Koru ve Referansları Doğrula**

- Hedef gerektiriyorsa yol ayırıcılarını normalize edin, ancak göreli dizinleri koruyun. Her üretim adının benzersiz olduğu ve kaynak referanslarının geçerli kalacağı kesin değilse yalnızca [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) kullanmayın.
- Hedefe özgü ad doğrulaması uygulayın. Gevşek dosyalar yazılırken köklenmiş yolları ve geçiş segmentlerini reddedin, hedefi [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) ile çözün ve hedefin amaçlanan dışa aktarma dizini altında kaldığını, dizin ayırıcıyı içererek doğrulayın. Sembolik bağlar yönlendirme yapmayacak, uygulama kontrolündeki bir dizin kullanın.
- Her dışa aktarma işi için ayrı bir kaydedici ve depolama ad alanı kullanın. Ayırıcı normalizasyonundan ve hedefin büyük/küçük harf duyarlılığı kurallarından kaynaklanan çakışmaları tespit edin.
- Yayınlamadan önce her XAML belgesini XML olarak ayrıştırın ve `Source` veya `ImageSource` gibi dosya tabanlı kaynak referanslarını inceleyin. Her göreli URI'yi ilgili XAML ürününün diziniyle çözün, ortaya çıkan depolama adını normalize edin ve sözlüğün anahtarı, ZIP girdisi ya da depolanan nesnenin var olduğunu doğrulayın. Harici URI'leri ve XAML işaretleme ifadelerini göreli dosya adlarından ayrı değerlendirin.

Örneğin, `pres/Slide_1.xaml` dosyası `images/image1.png` referans veriyorsa, depolanan kaynak `pres/images/image1.png` olarak bulunmalıdır. Yalnızca `image1.png` saklamak bu ilişkiyi bozar. Nesne depolama için iş ön ekinin altında aynı dizin yapısını koruyun ve bu kaynak URL'lerini XAML tüketicisinin erişebileceği şekilde sağlayın. ZIP'i tekrar açarak giriş adlarını ve kaynak baytlarını doğrulayın, ardından hedef XAML ortamında örnek slaytları yükleyerek görsellerin doğru çözüldüğünden emin olun.

## **SSS**

**Orijinal font makinede bulunmuyorsa, öngörülebilir fontları nasıl sağlarız?**

[XamlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/xamloptions/) içindeki [DefaultRegularFont](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/defaultregularfont/) ayarını yapın — dışa aktarım sırasında eksik olduğunda yedek font olarak kullanılır. Bu, oluşturulan XAML'in yedek fontu referans alacağı veya hedef makinede fontun mevcut olacağı anlamına gelmez. XAML'in referans verdiği fontların görüntülenecek ortamda mevcut olduğundan emin olun.

**Dışa aktarılan XAML sadece WPF için mi amaçlanmıştır yoksa diğer XAML yığınlarında da kullanılabilir mi?**

Aspose.Slides, kamu API'si aracılığıyla WPF XAML'i dışa aktarır. UWP ve Xamarin.Forms gibi diğer XAML yığınlarıyla uyumluluk garanti edilmez. Oluşturulan işaretlemeyi hedef ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl engelleyebilirim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı [XamlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/xamloptions/) içindeki [ExportHiddenSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) ile kontrol edebilirsiniz — ihtiyacınız yoksa devre dışı bırakın.