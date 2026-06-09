---
title: Kurulum
type: docs
weight: 70
url: /tr/python-net/installation/
keywords:
- Aspose.Slides indir
- Aspose.Slides kur
- Aspose.Slides kullan
- Aspose.Slides kurulumu
- Windows
- macOS
- Python
description: "Aspose.Slides for Python via .NET'i hızlı bir şekilde nasıl kuracağınızı öğrenin. Adım adım kılavuz, sistem gereksinimleri ve kod örnekleri — bugün PowerPoint sunumlarıyla çalışmaya başlayın!"
---
## **Genel Bakış**

Aspose.Slides for Python via .NET paketi, tüm gerekli .NET kütüphanelerini içinde barındırır; bu da .NET'i ayrı olarak kurmanıza gerek olmadığı anlamına gelir. Bu, kurulum sürecini basitleştirir ve geliştiricilerin sunumlarla hemen çalışmaya başlamasını sağlar. Ancak, işletim sisteminize veya ortamınıza bağlı olarak .NET'in ihtiyaç duyduğu bazı platform‑spesifik bağımlılıkları hâlâ kurmanız gerekebilir. Ayrıca, paketinin tam uyumluluğu ve düzgün çalışması için belirli sistem gereksinimlerinin karşılanması gerekir.

## **Windows**

**Sistem Gereksinimleri**

Makinenizin özelliklerinin [sistem gereksinimlerini](/slides/tr/python-net/system-requirements/) karşılayıp karşılamadığını kontrol edin ve doğrulayın.

### **Aspose.Slides'ı Yükleyin**

`pip`, Windows üzerinde [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) paketini indirmek ve kurmak için en kolay yoldur.

Aspose.Slides'ı yüklemek için aşağıdaki komutu çalıştırın:

```sh
pip install aspose-slides
```

**Aspose.Slides Kullanımı**

Aşağıdaki kodu çalıştırarak Aspose.Slides kurulumunuzu test edin ve bir PowerPoint sunumu oluşturun:

```python
# Aspose.Slides for Python via .NET modülünü içe aktar.
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekle.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Sistem Gereksinimleri**

Makinenizin özelliklerinin [sistem gereksinimlerini](/slides/tr/python-net/system-requirements/) karşılayıp karşılamadığını kontrol edin ve doğrulayın.

### **Önkoşullar**

**Paylaşımlı Kütüphanelerle Python**

macOS'ta Python kurulumu için birkaç yöntem vardır, ancak [pyenv aracı](https://github.com/pyenv/pyenv#homebrew-in-macos)'nı kullanmanızı şiddetle öneririz.

**pyenv**'i kurup yapılandırdıktan sonra, Terminal uygulamasında aşağıdaki komutları çalıştırarak paylaşımlı kütüphaneleri olan Python'u yükleyin:

1. Python'u kurun:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. Global Python sürümü olarak ayarlayın:

```sh
pyenv global 3.9.13
```

3. Kabuk‑özgü Python sürümü olarak ayarlayın:

```sh
pyenv shell 3.9.13
```

4. libpython kütüphanesi için bir sembolik bağlantı oluşturun:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

Not: Python 3.5 veya üzeri gereklidir. Burada yalnızca örnek olarak 3.9.13 sürümü kullanılmıştır.

**libgdiplus Kütüphanesini Yükleyin**

**libgdiplus** kütüphanesi, macOS ve Linux için .NET'in grafik işlevselliği için güvendiği Windows GDI+ uygulamasıdır.
Bu kütüphaneyi macOS'ta kurmak için aşağıdaki komutu çalıştırın:

```sh
brew install mono-libgdiplus
```

### **Aspose.Slides'ı Yükleyin**

`pip`, macOS üzerinde [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) paketini indirmek ve kurmak için en kolay yoldur.

Aspose.Slides'ı yüklemek için aşağıdaki komutu çalıştırın:

```sh
pip install aspose-slides
```

**Aspose.Slides Kullanımı**

Aşağıdaki kodu çalıştırarak Aspose.Slides kurulumunuzu test edin ve bir PowerPoint sunumu oluşturun:

```python
# Aspose.Slides for Python via .NET modülünü içe aktar.
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekle.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Aspose.Slides'ı sanal bir ortamda kurabilir miyim?**

Evet, `pip` kullanarak herhangi bir Python sanal ortamına kurabilirsiniz. Ortamın, işletim sisteminize bağlı olarak gerekli yerel bağımlılıklara erişimi olduğundan emin olun.

**Aspose.Slides'ı Docker konteynerlerinde kullanabilir miyim?**

Evet, ancak Docker imajınızın gerekli yerel kütüphaneleri (**libgdiplus**, font paketleri vb.) ve doğru Python sürümünü içerdiğinden emin olmanız gerekir.

**Ücretsiz bir sürüm veya deneme sınırlaması var mı?**

Evet, varsayılan olarak Aspose.Slides değerlendirme modunda çalışır; bu modda filigran eklenir ve başka sınırlamalar olabilir. Kısıtlamaları kaldırmak için geçerli bir [lisans](/slides/tr/python-net/licensing/) uygulamanız gerekir.