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
description: "Aspose.Slides for Python via Java'ı Windows, Linux veya macOS üzerinde kurun, Java ve JPype'ı yapılandırın ve çalışan bir örnekle kurulumu doğrulayın."
---
Aspose.Slides for Python via Java Windows, Linux ve macOS üzerinde çalışır. Java kütüphanesine Python'dan erişmek için JPype kullanır. Microsoft PowerPoint gerekli değildir.

## **Önkoşullar**

Python paketlerini kurmadan önce, [Sistem Gereksinimleri](/slides/tr/python-java/system-requirements/) karşılayan Python ve bir JDK kurun. Bu sayfa uyumlu sürümleri, mimari gereksinimleri ve JPype'ı kaynaktan derlemek için gerekli bağımlılıkları listeler.

`JAVA_HOME` değişkenini JDK kurulum dizinine, `bin` alt dizinine değil, ayarlayın ve JDK'nın `bin` dizinini `PATH`'e ekleyin. Ortam değişkenlerini değiştirdikten sonra yeni bir terminal açın.

## **PyPI'dan Kurulum**

Bu komutları bir terminalde çalıştırın, Python etkileşimli isteminde değil. Paketleri diğer projelerden izole tutmak için bir proje dizini ve sanal ortam oluşturun.

### **Windows**

`PATH`'e `python` olarak eklenmiş seçtiğiniz Python yorumlayıcısıyla, Komut İstemi'nde aşağıdaki komutları çalıştırın:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux ve macOS**

`python3` olarak bulunabilen seçtiğiniz Python sürümüyle, Bash veya zsh'de aşağıdaki komutları çalıştırın:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Debian veya Ubuntu'da, ortam oluşturma `ensurepip` nedeniyle başarısız olursa `sudo apt-get install python3-venv` komutuyla `python3-venv` paketini kurun ve ortam oluşturma komutunu tekrar edin. Ayrı bir Python sürümü kullanıyorsanız, sürümüne uygun `venv` paketini yüklemeniz gerekebilir.

### **Paketleri Kurun**

Sanal ortam etkin durumdayken JPype ve Aspose.Slides'i kurun:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

`python -m pip` kullanmak, paketlerin uygulamanızı çalıştıran yorumlayıcı için kurulduğundan emin olur.

Mevcut bir Aspose.Slides kurulumunu güncellemek için aynı ortamda `python -m pip install --upgrade aspose-slides-java` komutunu çalıştırın.

## **ZIP Arşivinden Kurulum**

Kütüphaneyi ayrıca [Aspose.Slides indirme sayfası](https://releases.aspose.com/slides/tr/python-java/) üzerinden de kullanabilirsiniz:

1. [Önkoşullar](#önkoşullar) bölümünde açıklandığı gibi Python ve Java'yı kurun.  
2. Yukarıdaki talimatları izleyerek bir sanal ortam oluşturup etkinleştirin.  
3. `python -m pip install JPype1` komutuyla JPype'i kurun.  
4. Aspose.Slides for Python via Java ZIP arşivini indirin ve çıkarın.  
5. Çıkarılan `asposeslides` paket dizinini bulun. `lib` dizini ve JAR dosyası dahil içeriklerin tamamını bir arada tutun.  
6. `example.py` dosyasını bir sonraki bölümden `asposeslides` dizini yanına koyun, böylece Python paketi içe aktarabilir.

## **Kurulumu Doğrulama**

Aşağıdaki kodu `example.py` olarak kaydedin. Bir metin kutulu sunum oluşturur ve mevcut çalışma dizinine `out.pptx` olarak kaydeder.

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

Sanal ortam etkin durumdayken `example.py` dosyasının bulunduğu dizinden örneği çalıştırın:

```sh
python example.py
```

`asposeslides` içe aktarımı, JVM başlatılmadan önce paketlenmiş Java kütüphanesini kaydeder. JVM başlatıldıktan sonra `asposeslides.api` içe aktarın ve kapatmadan önce sunum kaynaklarını serbest bırakın.

{{% alert color="info" title="Note" %}}
Lisans olmadan çıktı bir değerlendirme filigranı içerir. Değerlendirme sınırlamaları ve geçici lisans bilgileri için [Aspose.Slides Değerlendirme](/slides/tr/python-java/evaluate-aspose-slides/) sayfasına bakın.
{{% /alert %}}

## **SSS**

**Python, JVM'nin bulunamadığını veya yüklenemediğini neden bildiriyor?**  
`JAVA_HOME`'un Python ve JPype kurulumunuzla uyumlu bir JDK'ya işaret ettiğini kontrol edin; ayrıntılar [Sistem Gereksinimleri](/slides/tr/python-java/system-requirements/) sayfasındadır. Ek kontroller için [JPype kurulum sorun giderme kılavuzu](https://jpype.readthedocs.io/en/latest/install.html) adresine bakın.

**Kurulum sonrası Python, `asposeslides` eksik diyor, neden?**  
Paket farklı bir Python yorumlayıcısı için kurulmuş olabilir. Kurulumda kullanılan sanal ortamı etkinleştirin ve `python -m pip show aspose-slides-java` komutunu çalıştırın. ZIP kurulumunda, `asposeslides` dizininin betiğinizin yanına yerleştirildiğinden veya Python'un modül arama yolunda olduğundan emin olun.

**Örneği bir defterde (notebook) tekrar tekrar çalıştırabilir miyim?**  
Örnek bağımsız bir Python süreci için tasarlanmıştır. Defterde tekrar tekrar çalıştırmadan önce JVM yaşam döngüsü ve defter yönergeleri için [Sınırlamalar ve API Farklılıkları](/slides/tr/python-java/limitations-and-api-differences/#import-the-library) sayfasına bakın.

**pip, `CERTIFICATE_VERIFY_FAILED` hatasıyla neden başarısız oluyor?**  
Ağınız bir HTTPS denetim proxy'si kullanıyorsa, pip'in bu proxy'nin sertifika otoritesine güvenmesi gerekir. pip'in `--cert` seçeneği veya `PIP_CERT` ortam değişkeniyle güvenilir CA paketini yapılandırın; ayrıntılar için [pip HTTPS sertifika talimatları](https://pip.pypa.io/en/stable/topics/https-certificates/) sayfasına bakın.