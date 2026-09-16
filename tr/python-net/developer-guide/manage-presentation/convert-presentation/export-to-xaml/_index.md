---
title: Python ile XAML’e Sunumları Dışa Aktarma
linktitle: Sunumdan XAML’e
type: docs
weight: 30
url: /tr/python-net/export-to-xaml/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunumu dışa aktar
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- PowerPoint'tan XAML’e
- OpenDocument'tan XAML’e
- sunumdan XAML’e
- PPT'den XAML’e
- PPTX'den XAML’e
- ODP'den XAML’e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python ile PowerPoint ve OpenDocument slaytlarını XAML’e dönüştürün—düzeninizi koruyan hızlı, Office gerektirmeyen bir çözüm."
---
## **Genel Bakış**

Bu makale, PowerPoint sunumlarını Aspose.Slides kullanarak XAML’e nasıl dışa aktarılacağını açıklar. XAML’e kısa bir giriş içerir, varsayılan ayarlarla bir sunumun XAML’e nasıl kaydedileceğini gösterir ve [XamlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/) aracılığıyla dışa aktarmayı özelleştirmeyi, gizli slaytların dışa aktarılması dahil, demonstrasyon eder. Makale ayrıca geri dönüş fontları, XAML yığını uyumluluğu ve gizli slayt dışa aktarma davranışıyla ilgili birkaç yaygın soruya yanıt verir.

## **XAML Hakkında**

XAML, WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin.Forms gibi çerçevelerde kullanıcı arabirimlerini tanımlamak için kullanılan XML tabanlı bir işaretleme dilidir.

XAML dosyalarıyla görsel bir tasarımcıda çalışabilir ya da işaretlemeyi doğrudan yazıp düzenleyebilirsiniz.

## **Varsayılan Seçeneklerle Sunumları XAML’e Dışa Aktarma**

Aşağıdaki Python örneği, bir sunumun varsayılan ayarlarla XAML’e dışa aktarılmasını gösterir:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Varsayılan olarak, dışa aktarılan slaytlar, sürecin geçerli çalışma dizininde bir `pres` alt klasörüne kaydedilir; bu dizin [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd) tarafından döndürülür. Klasör otomatik olarak oluşturulur ve gerekli tüm görüntüler de oraya kaydedilir.

Çıktı klasörü adı, kaynak dosya adının uzantısı olmadan alınır. `pres.pptx` için çıktı dosyaları `pres/Slide_1.xaml`, `pres/Slide_2.xaml` vb. olarak adlandırılır. Giriş sunumuna mutlak bir yol verseniz bile, çıktı klasörü geçerli çalışma dizinine göre oluşturulur, giriş dosyasının yanına değil.

## **Özel Seçeneklerle Sunumları XAML’e Dışa Aktarma**

Aspose.Slides’in bir sunumu XAML’e nasıl dışa aktaracağını kontrol etmek için [XamlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/) sınıfını kullanın.

Gizli slaytları XAML çıktısına eklemek için, aşağıdaki Python örneğinde gösterildiği gibi [export_hidden_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) özelliğini `True` olarak ayarlayın:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Oluşturulan Tüm XAML Artefaktlarını Yakalama**

Bir XAML dışa aktarımı, dışa aktarılan her slayt için bir XAML belgesi ve ayrıca ayrı görüntüler ve destekleyici kaynaklar üretebilir. Bir dışa aktarımı depolarken veya aktarırken bu dosyaların tamamını koruyun.

Aşağıdaki örnekler, geçici bir dizinde varsayılan dosya‑sistemi kaydedicisini kullanır, ardından oluşturulan dosyaları toplar.

### **Dışa Aktarım Yaşam Döngüsünü Anlamak**

- XAML seçeneklerini kabul eden XAML‑özgü [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) aşırı yüklemesiyle dışa aktarmayı başlatın. Oluşturulan dosyaları yalnızca işlem başarılı bir şekilde döndükten sonra okuyun.
- XAML, kaynakları göreceli yollarla başvurabileceği için her artefaktın göreceli yolunu koruyun.
- Artefaktları bayt olarak okuyun. Görüntüler ve diğer ikili kaynaklar metin olarak çözümlenmemelidir.
- Toplama ve sonrasında gerçekleşecek depo işlemleri tamamlandıktan sonra genel başarı raporu verin. Depolama hatalarının çağrıya ulaşmasına izin verin ve kalıcılık başarısız olursa kısmi çıktıyı temizleyin.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) varsayılan olarak `False` olduğundan gizli‑slayt XAML belgeleri dışarıda bırakılır. `True` olarak ayarlandığında bunlar ve dışa aktarımları için gereken kaynaklar da dahil edilir. Kaynak sayısı sunuma bağlıdır; slayt başına bir dosya varsaymayın.

{{% alert color="warning" title="Uyarı" %}}
Örnekler, sürecin geçerli çalışma dizinini geçici olarak değiştirir; bu da tüm iş parçacıklarını etkiler. Her dışa aktarmayı ayrı bir çalışan süreçte çalıştırın ya da dışa aktarım sırasında sürecin başka bir işinin geçerli dizine bağımlı olmadığından emin olun. Tek bir benzersiz geçici dizin, aynı süreç içinde eşzamanlı dışa aktarmaları güvenli hâle getirmez.
{{% /alert %}}

### **Belleğe Dışa Aktar ve Artefaktları İncele**

Bu tam örnek `pres.pptx` dosyasını yükler, geçici bir dizine dışa aktarır, her artefaktı göreceli ad ve bayt çiftleri içeren bir sözlükte toplar ve adını, tipini ve bayt sayısını yazdırır. Oluşturulan dizin yapısını korur ve toplama sonrasında geçici dosyaları siler. Giriş yolu, çalışma dizini değiştirilmeden önce çözülür.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Yalnızca XAML'i çöz, ve yalnızca metinsel inceleme gerektiğinde.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Uzantı kontrolleri inceleme için faydalıdır; tanımadığınız kaynak türleri dahil tüm artefaktları koruyun. Baytları saklarken veya aktarırken değiştirmeyin. Yalnızca metin işlemeye ihtiyaç duyan XAML’i çözümleyin. Bu yaklaşım, toplanan dışa aktarımı hem geçici disk hem de bellek içinde tutar.

### **Toplanan Artefaktları ZIP Arşivine Paketle**

Bu bağımsız örnek dışa aktarmayı toplar, adlarını doğrular ve orijinal baytları bir ZIP arşivine yazar. Benzersiz bir arşiv adı dışa aktarma işlerinizden ayırır. ZIP girdileri ileri eğik çizgi (`/`) kullanır ve göreceli dizinleri korur. Normalleştirme sonrası çakışan veya güvensiz adlar bütün paketi yazmadan önce reddeder.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # ZIP dizini, başarı raporlanmadan önce sonlandırılmıştır.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

Örnek, geçici dışa aktarmayı topladıktan sonra bir yerel arşiv oluşturmak için [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) kullanır. Uzaktan depolama için, arşiv‑yazma aşamasını toplanan baytların yüklenmesiyle değiştirin. Bir dışa aktarma‑iş kimliğiyle birlikte tam göreceli artefakt adı nesne anahtarı olarak kullanın veya iş kimliği, göreceli ad ve ikili veriyi bir veritabanı satırında saklayın. Tüm yüklemeler tamamlandığında ya da veritabanı işlemi onaylandığında işi yayınlayın. Kalıcılık başarısız olursa kısmi çıktıyı temizleyin.

Büyük sunumlar için, tüm baytları bir sözlükte toplamaktansa dışa aktarmadan sonra geçici dosyaları tek tek işleyin. Bu, dışa aktarımın tamamının ek bir bellek kopyasını önler, ancak aktarımcının kendi bellek gereksinimlerini ortadan kaldırmaz.

### **Kaynak Adlarını Koru ve Başvuruları Doğrula**

- Hedef gerektiriyorsa yol ayırıcılarını normalleştirin, ancak göreceli dizinleri koruyun. Tüm üretilen adların benzersiz olduğundan ve kaynak başvurularının geçerli olduğundan emin olmadığınız sürece yalnızca dosya adını tutmayın.
- Hedefe özgü ad doğrulaması uygulayın. Gevşek dosyalar yazılırken mutlak yolları ve dolaşım bölümlerini reddedin, hedefi çözün ve hedef dizinin altında kalıp kalmadığını doğrulayın. Yazma yönlendirmelerini engellemek için sembolik bağlantı içermeyen, uygulama‑kontrollü bir dizin kullanın.
- Her dışa aktarma işi için ayrı bir depolama ad alanı kullanın. Ayırıcı normalleştirmesinden sonra ve hedefin büyük/küçük harf duyarlılığı kurallarına göre çakışmaları tespit edin.
- Yayınlamadan önce her XAML belgesini XML olarak ayrıştırın ve `Source` ya da `ImageSource` gibi dosya temelli kaynak başvurularını inceleyin. Her göreceli URI’yı ilgili XAML artefaktının dizinine göre çözün, ortaya çıkan depolama adını normalleştirin ve sözlük anahtarı, ZIP girdisi veya saklanan nesnenin mevcut olduğunu doğrulayın. Harici URI’ları ve XAML işaretleme ifadelerini göreceli dosya adlarından ayrı tutun.

Örneğin, `pres/Slide_1.xaml` dosyası `images/image1.png`’ye başvuruyorsa, depolanan kaynak `pres/images/image1.png` olarak mevcut olmalıdır. Yalnızca `image1.png` tutmak bu ilişkiyi bozar. Nesne depolama için, iş önekinin altında aynı dizin yapısını koruyun ve bu kaynak URL’lerini XAML tüketicisinin erişebileceği hâle getirin. Tamamlanmış ZIP’i yeniden açarak giriş adlarını ve kaynak baytlarını doğrulayın ve hedef XAML ortamında temsilci slaytları yükleyerek görüntülerin doğru çözüldüğünü teyit edin.

## **SSS**

**Orijinal font makinede bulunmadığında öngörülebilir fontları nasıl sağlayabilirim?**

[XamlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/) içindeki [default_regular_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) ayarını yapın — dışa aktarma sırasında eksik olduğunda bir yedek font olarak kullanılır. Bu, oluşturulan XAML’in yedek fontu başvurduğu veya hedef makinede fontun bulunacağı anlamına gelmez. XAML’in başvurduğu fontların görüntüleneceği ortamda mevcut olduğundan emin olun.

**Dışa aktarılan XAML yalnızca WPF için mi tasarlandı, başka XAML yığınlarında da kullanılabilir mi?**

Aspose.Slides, halka açık API’si aracılığıyla WPF XAML’i dışa aktarır. UWP ve Xamarin.Forms gibi diğer XAML yığınlarıyla uyumluluk garanti edilmez. Üretilen işaretlemeyi hedef ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl engelleyebilirim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı [export_hidden_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) üzerinden kontrol edebilirsiniz — ihtiyacınız yoksa devre dışı bırakın.