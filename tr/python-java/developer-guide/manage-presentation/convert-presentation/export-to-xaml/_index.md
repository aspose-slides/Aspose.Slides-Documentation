---
title: Python üzerinden Java ile Sunumları XAML'e Dışa Aktarma
linktitle: Sunumu XAML'e
type: docs
weight: 30
url: /tr/python-java/export-to-xaml/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunumu dışa aktar
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- PowerPoint'ten XAML'e
- OpenDocument'ten XAML'e
- sunumdan XAML'e
- PPT'den XAML'e
- PPTX'den XAML'e
- ODP'den XAML'e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument sunumlarını XAML'e dışa aktarın. Varsayılan seçenekleri kullanın veya gizli slaytları dahil edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarını XAML'ye nasıl dışa aktaracağınızı açıklar. Kısa bir XAML girişini içerir, varsayılan ayarlarla bir sunumu XAML'ye kaydetmeyi gösterir ve [XamlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/) üzerinden dışa aktarmayı özelleştirmeyi, gizli slaytların dışa aktarımını da dahil ederek, gösterir. Makale ayrıca yedek fontlar, XAML yığını uyumluluğu ve gizli slayt dışa aktarım davranışıyla ilgili birkaç yaygın soruya yanıt verir.

Örnekler, Aspose.Slides for Python via Java ve uyumlu bir Java çalışma zamanını gerektirir. `pres.pptx` dosyasını geçerli çalışma dizinine yerleştirin. Her örnek, JVM zaten çalışıyorsa başlatmaz; yalnızca çalışmıyorsa başlatır.

## **XAML Hakkında**

XAML, WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin.Forms gibi çerçevelerde kullanıcı arayüzlerini tanımlamak için kullanılan XML tabanlı bir işaretleme dilidir.

XAML dosyalarıyla görsel bir tasarımcıda çalışabilir veya işaretlemeyi doğrudan yazıp düzenleyebilirsiniz.

## **Sunumları XAML'e Varsayılan Seçeneklerle Dışa Aktarma**

Aşağıdaki Python örneği, bir sunumu varsayılan ayarlarla XAML'e nasıl dışa aktaracağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Varsayılan olarak, dışa aktarılan slaytlar, işlemin geçerli çalışma dizininde bir `pres` alt klasörüne kaydedilir. Klasör otomatik olarak oluşturulur ve gerekli olan tüm görüntüler de oraya kaydedilir.

Çıktı klasörünün adı, kaynak dosyanın uzantısı olmadan alınır. `pres.pptx` için çıktı dosyaları `pres/Slide_1.xaml`, `pres/Slide_2.xaml` gibi adlandırılır. Girdi sunumuna mutlak bir yol alsanız bile, çıktı klasörü geçerli çalışma dizinine göre oluşturulur, girdi dosyasının yanına değil.

## **Sunumları XAML'e Özel Seçeneklerle Dışa Aktarma**

Aspose.Slides'in bir sunumu XAML'e nasıl dışa aktardığını kontrol etmek için [XamlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/) sınıfını kullanın.

Çıktıyı özel bir konuma kaydetmek için `IXamlOutputSaver` arayüzünü uygulayın ve bu uygulamanın bir örneğini [XamlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/) sınıfının [setOutputSaver](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/#setOutputSaver) metodine aktarın.

Gizli slaytları XAML çıktısına dahil etmek için, aşağıdaki Python örneğinde gösterildiği gibi `True` ile [setExportHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) metodunu çağırın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Oluşturulan Tüm XAML Ürünlerini Yakalama**

Bir XAML dışa aktarımı, dışa aktarılan her slayt için bir XAML belgesi ve ayrıca ayrı görüntüler ve destek kaynakları üretebilir. Bu ürünleri varsayılan dosya sistemi kaydedicisi yerine almak için özel bir `IXamlOutputSaver` nesnesini [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/#setOutputSaver) metoduna atayın. Dışa aktarımı, XAML‑özel [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) aşırı yüklemesiyle başlatın.

Python’da, Java `IXamlOutputSaver` arayüzünü uygulamak için `jpype.JProxy` kullanın. Geri çağırma yolunu `str` tipine dönüştürün ve döndürmeden önce Java bayt dizisini Python `bytes` tipine kopyalayın; aşağıda gösterildiği gibi.

### **Geri Çağırma Yaşam Döngüsünü Anlamak**

Dışa aktarıcı, oluşturulan her ürün için ayrı ayrı `IXamlOutputSaver.save` metodunu çağırır:

- `path` ürünü tanımlar ve göreceli dizinleri içerebilir. XAML, kaynaklara göreceli yollarla başvurabileceği için bu bilgiyi koruyun.
- `data` ürünün baytlarını içerir. Görüntüler ve diğer ikili kaynaklar metin olarak çözümlenmemelidir.
- Kaydedici, döndürmeden önce veriyi tutmak veya kalıcı hâle getirmekle sorumludur. Örneklerde her bayt dizisi uygulamaya ait belleğe kopyalanır.
- Dışa aktarımı, yalnızca sunum kaydetme işlemi döndüğünde ve her geri çağırma başarılı bir şekilde tamamlandığında başarılı olarak kabul edin. Depolama hatalarını gizlemeyin veya gözlenmeyen arka plan yazımlarını başlatmayın. Kalıcı kaydetme daha sonra gerçekleşiyorsa, bütün başarıyı o adım da başarılı olduğunda raporlayın.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) özel bir kaydediciye de uygulanır. Varsayılan ayar `False`, gizli slayt XAML belgelerini dışarıda tutar. `True` geçirilmesi, bu belgeleri ve dışa aktarım için gereken tüm kaynakları dahil eder. Kaynak sayısı sunuma bağlıdır; slayt başına bir geri çağırma veya sabit bir geri çağırma sırası olduğunu varsaymayın.

### **Belleğe Aktar ve Ürünleri İncele**

Bu tam örnek, `pres.pptx` dosyasını yükler, her ürünü isim ve değişmez `bytes` değerlerinden oluşan bir Python sözlüğünde toplar ve ismini, tipini ve bayt sayısını yazdırır. Sağlanan isimleri tam olarak korur. Aynı isimler, sessizce bir ürünü üzerine yazmak yerine koleksiyonu geçersiz olarak işaretler. Önek, sonuçları kullanmadan önce bunu denetler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Yalnızca XAML'i çöz, ve yalnızca metinsel inceleme gerektiğinde.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Uzantı kontrolleri inceleme için faydalıdır; tanıdık olmayan kaynak türleri dahil tüm ürünleri saklayın. Baytları saklarken veya aktarırken değiştirmeyin. Yalnızca metinsel işleme ihtiyacı olan XAML için `bytes.decode` ile UTF-8 kullanın.

### **Toplanan Ürünleri ZIP Arşivinde Paketle**

Bu bağımsız örnek, dışa aktarımı toplar, isimlerini doğrular ve orijinal baytları bir ZIP arşivine yazar. Benzersiz bir arşiv adı, eş zamanlı dışa aktarım işlerini ayırır. ZIP girişleri önde gelen eğik çizgileri (`/`) kullanır ve göreceli dizinleri korur. Normalleştirme sonrası çakışan güvensiz isimler, paket yazılmadan önce tüm paket, reddedilir.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Kapatma, başarı raporlanmadan önce ZIP dizinini sonlandırır.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

Örnek, bir yerel arşiv yazmak için Python'un `zipfile.ZipFile` sınıfını kullanır; dışa aktarıcı kendisi gevşek XAML ya da görüntü dosyaları yazmaz. Uzaktan depolama için, arşiv‑yazma aşamasını toplanan bayt dizilerinin yüklenmesiyle değiştirin. Bir dışa aktarım‑iş kimliği ile tam göreceli ürün adını blob anahtarı olarak kullanın veya iş kimliği, göreceli ad ve ikili veriyi bir veritabanı satırında saklayın. Tüm yüklemeler tamamlandıktan veya veritabanı işlemi onaylandıktan sonra işi yayınlayın. Kalıcı kaydetme başarısız olursa kısmi çıktıyı temizleyin.

Büyük sunumlar için, özel bir kaydedici her ürünü doğrudan uygulama depolamasına kalıcı hâle getirerek tüm dışa aktarımın ek bir kopyasını uygulama belleğinde tutmaktan kaçınabilir. Dışa aktarıcının bakış açısından her geri çağırmayı senkron tutun: hedef baytları kabul ettikten sonra yalnızca o zaman geri dönün ve hataların çağırıcıya ulaşmasına izin verin.

### **Kaynak İsimlerini Koru ve Referansları Doğrula**

- Hedef gerektirdiğinde yol ayırıcılarını normalleştirin, ancak göreceli dizinleri koruyun. Her oluşturulan ismin benzersiz olduğu ve kaynak referanslarının geçerli olduğu kesin değilse yalnızca `pathlib.Path.name` kullanmayın.
- Hedefe özgü isim doğrulaması uygulayın. Gevşek dosyalar yazarken, köklenmiş yolları ve geçiş bölümlerini reddedin, hedefi `pathlib.Path.resolve` ile çözün ve hedefin, dizin ayırıcılarını içeren içerik kontrolüyle istenen dışa aktarım dizininin altında kalıp kalmadığını doğrulayın. Yazma yönlendirebilecek sembolik bağlar olmadan uygulama kontrolündeki bir dizin kullanın.
- Her dışa aktarım işi için ayrı bir kaydedici ve depolama ad alanı kullanın. Ayırıcı normalleştirmesinden ve hedefin büyük/küçük harf duyarlılığı kurallarına göre çakışmaları tespit edin.
- Yayınlamadan önce, her XAML belgesini XML olarak ayrıştırın ve görüntü `Source` veya `ImageSource` gibi dosya tabanlı kaynak referanslarını inceleyin. Her göreceli URI'yı içeren XAML ürününün dizinine göre çözün, ortaya çıkan depolama adını normalleştirin ve karşılık gelen harita anahtarının, ZIP girişinin veya saklanan nesnenin mevcut olduğunu doğrulayın. Dış URI'ları ve XAML işaretleme ifadelerini göreceli dosya adlarından ayrı olarak ele alın.

Örneğin, `pres/Slide_1.xaml` dosyası `images/image1.png` dosyasına başvuruyorsa, saklanan kaynak `pres/images/image1.png` olarak mevcut olmalıdır. Sadece `image1.png` tutmak bu ilişkiyi bozar. Nesne depolama için, iş önekinin altında aynı dizin düzenini koruyun ve bu kaynak URL'lerini XAML tüketicisinin erişebileceği şekilde yapın. Tamamlanmış ZIP dosyasını yeniden açarak giriş adlarını ve kaynak baytlarını doğrulayın ve hedef XAML ortamında temsilci slaytları yükleyerek görüntülerin doğru çözüldüğünü teyit edin.

## **SSS**

**Orijinal font makinede mevcut değilse tahmin edilebilir fontları nasıl sağlayabilirim?**  
Export sırasında orijinal font eksik olduğunda yedek font olarak kullanılmak üzere [XamlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/) içinde [setDefaultRegularFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) yöntemini çağırın — bu, dışa aktarım sırasında yedek font olarak kullanılır. Bu, oluşturulan XAML'in yedek fontu başvurduğunu veya fontun hedef makinede bulunacağını garanti etmez. XAML'in başvurduğu fontların görüntülenecek ortamda mevcut olduğundan emin olun.

**Dışa aktarılan XAML sadece WPF için mi tasarlandı, yoksa diğer XAML yığınlarında da kullanılabilir mi?**  
Aspose.Slides, WPF XAML'yi kamu API'si aracılığıyla dışa aktarır. UWP ve Xamarin.Forms gibi diğer XAML yığınlarıyla uyumluluk garanti edilmez. Oluşturulan işaretlemeyi hedef ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl engelleyebilirim?**  
Varsayılan olarak, gizli slaytlar dahil edilmez. Bu davranışı, [XamlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/) içindeki [setExportHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) yöntemiyle kontrol edebilirsiniz — eğer dışa aktarmanıza gerek yoksa devre dışı bırakın.