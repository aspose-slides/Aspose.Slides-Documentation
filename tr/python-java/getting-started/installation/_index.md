---
title: Kurulum
type: docs
weight: 70
url: /tr/python-java/installation/
keywords:
  - Aspose.Slides indir
  - Aspose.Slides kur
  - Aspose.Slides kurulumu
  - Python
  - Java
  - JPype
  - Windows
  - macOS
  - Linux
description: "Aspose.Slides for Python via Java'ı Windows, Linux veya macOS'ta kurun, Java ve JPype'ı yapılandırın ve çalışan bir örnekle kurulumu doğrulayın."
---
Aspose.Slides for Python via Java Windows, Linux ve macOS'ta çalışır. Java kütüphanesine Python'dan erişmek için JPype kullanır. Microsoft PowerPoint gerekli değildir.

## **Önkoşullar**

Python paketlerini kurmadan önce, [System Requirements](/slides/tr/python-java/system-requirements/) sayfasında belirtilen gereksinimleri karşılayan Python ve bir JDK kurun. Bu sayfada uyumlu sürümler, mimari gereksinimleri ve JPype'i kaynak koddan derlemek için gereken bağımlılıklar listelenmiştir.

`JAVA_HOME` değişkenini JDK kurulum dizinine, `bin` alt dizinine değil, ayarlayın ve JDK'nin `bin` dizinini `PATH`'e ekleyin. Ortam değişkenlerini değiştirdikten sonra yeni bir terminal açın.

## **PyPI'dan Kurulum**

Aşağıdaki komutları bir terminalde çalıştırın, Python etkileşimli istemcisinde değil. Paketleri diğer projelerden izole tutmak için bir proje dizini ve sanal ortam oluşturun.

### **Windows**

Seçtiğiniz Python yorumlayıcısı `PATH` üzerinde `python` olarak mevcutsa, Komut İstemi'nde aşağıdaki komutları çalıştırın:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux ve macOS**

Seçtiğiniz Python sürümü `python3` olarak mevcutsa, Bash veya zsh'te aşağıdaki komutları çalıştırın:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Debian veya Ubuntu üzerinde, ortam oluşturma `ensurepip` bulunamadığı için başarısız olursa, `sudo apt-get install python3-venv` komutuyla `python3-venv` paketini kurun ve ardından ortam oluşturma komutunu tekrar çalıştırın. Ayrı olarak kurulmuş bir Python sürümü, onun sürümüne uygun `venv` paketine ihtiyaç duyabilir.

### **Paketleri Kurun**

Sanal ortam etkin olduğunda, JPype ve Aspose.Slides'i kurun:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

`python -m pip` kullanmak, paketlerin uygulamanızı çalıştıran yorumlayıcı için kurulmasını sağlar.

Mevcut bir Aspose.Slides kurulumunu güncellemek için aynı ortamda `python -m pip install --upgrade aspose-slides-java` komutunu çalıştırın.

## **ZIP Arşivinden Kurulum**

Kütüphaneyi ayrıca [Aspose.Slides indirme sayfasından](https://releases.aspose.com/slides/python-java/) da kullanabilirsiniz:

1. Python ve Java'yı [Önkoşullar](#prerequisites) bölümünde açıklandığı gibi kurun.
2. Yukarıdaki talimatları izleyerek bir sanal ortam oluşturun ve etkinleştirin.
3. JPype'i `python -m pip install JPype1` ile kurun.
4. Aspose.Slides for Python via Java ZIP arşivini indirin ve çıkarın.
5. Çıkarılan `asposeslides` paket dizinini bulun. İçeriğini, `lib` dizini ve JAR dosyası da dahil olmak üzere birlikte tutun.
6. `example.py` dosyasını bir sonraki bölümden `asposeslides` dizininin yanına yerleştirin, böylece Python paketi içe aktarabilir. Arşivde zaten `asposeslides` yanına bir `example.py` dosyası vardır; onu aşağıdaki dosyayla değiştirin.

## **Kurulumu Doğrulama**

Aşağıdaki kodu `example.py` olarak kaydedin. Bu kod bir metin kutulu sunum oluşturur ve geçerli çalışma dizininde `out.pptx` olarak kaydeder.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Sanal ortam etkin olduğunda, `example.py` dosyasının bulunduğu dizinden örnek kodu çalıştırın:

```sh
python example.py
```

`asposeslides` içe aktarması, JVM başlamadan önce paketlenmiş Java kütüphanesini kaydeder. JVM başlatıldıktan sonra `asposeslides.api` içe aktarın ve JVM'i kapatmadan önce sunum kaynaklarını serbest bırakın.

{{% alert color="info" title="Note" %}}
Lisans olmadan, çıktı bir değerlendirme filigranı içerir. Değerlendirme sınırlamaları ve geçici lisans bilgileri için [Evaluate Aspose.Slides](/slides/tr/python-java/evaluate-aspose-slides/) sayfasına bakın.
{{% /alert %}}

## **FAQ**

**Python, JVM'nin bulunamadığını ya da yüklenemediğini neden bildiriyor?**

`JAVA_HOME` değişkeninin Python ve JPype kurulumunuzla uyumlu bir JDK'yi işaret ettiğinden emin olun; bu, [System Requirements](/slides/tr/python-java/system-requirements/) sayfasında açıklanmıştır. Ek kontroller için [JPype kurulum sorun giderme rehberi](https://jpype.readthedocs.io/en/latest/install.html)'ne bakın.

**Kurulumdan sonra Python, `asposeslides` eksik olduğunu neden bildiriyor?**

Paket farklı bir Python yorumlayıcısı için kurulmuş olabilir. Kurulumda kullanılan sanal ortamı etkinleştirin ve `python -m pip show aspose-slides-java` komutunu çalıştırın. ZIP kurulumu için, `asposeslides` dizininin betiğinizin yanında olduğundan veya Python'un modül arama yolunda erişilebilir olduğundan emin olun.

**Örneği bir notebook'ta tekrarlı olarak çalıştırabilir miyim?**

Bu örnek bağımsız bir Python süreci için tasarlanmıştır. Tekrarlı notebook çalıştırması için uyarlamadan önce, JVM yaşam döngüsü ve notebook kullanımı hakkında bilgi için [Limitations and API Differences](/slides/tr/python-java/limitations-and-api-differences/#import-the-library) sayfasına bakın.

**pip `CERTIFICATE_VERIFY_FAILED` hatasıyla neden başarısız oluyor?**

Ağınız bir HTTPS denetim proxy'si kullanıyorsa, pip'in bu proxy'nin sertifika otoritesine güvenmesi gerekir. Pip'in `--cert` seçeneği ya da `PIP_CERT` ortam değişkeniyle güvenilen CA paketini yapılandırın; talimatlar için [pip HTTPS sertifika yönergeleri](https://pip.pypa.io/en/stable/topics/https-certificates/)'na bakın. Gerekli yapılandırma ağınıza ve pip sürümüne bağlıdır.