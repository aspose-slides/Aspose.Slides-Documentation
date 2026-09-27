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
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Aspose.Slides for Python via .NET'i PyPI'dan pip ile Windows, Linux ve macOS üzerinde kurun ve Linux ile macOS'un ihtiyaç duyduğu yerel kütüphaneleri yükleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET'in Windows, Linux ve macOS üzerinde nasıl kurulacağını açıklar. Paket, [PyPI](https://pypi.org/project/aspose.slides/) üzerinden yayınlanır ve pip ile kurulur. Kullanılan .NET çalışma zamanını içerdiği için .NET kurmanıza gerek yoktur. Linux ve macOS üzerinde bu çalışma zamanı, işletim sisteminin içermediği yerel kütüphanelere ihtiyaç duyar; aşağıdaki bölümler bu kütüphaneleri listeler.

Aspose.Slides for Python via .NET, Python 3.5‑den 3.14‑e kadar destekler. PyPI, Windows (32‑bit ve 64‑bit), Linux (x86_64 ve ARM64) ve macOS (Intel ve Apple silicon) için paketler sunar.

## **Windows**

Windows üzerinde paketi pip ile kurun. Başka bir kütüphane gerekmez.

```bash
pip install aspose.slides
```

## **Linux**

Linux'ta, paket içinde bulunan .NET çalışma zamanı iki kütüphane gerektirir:

- **libgdiplus**, Windows GDI+ grafik API'sinin bir uygulamasıdır. Bu olmadan bir sunumu kaydetme işlemi `The type initializer for 'Gdip' threw an exception` hatasıyla başarısız olur.
- **ICU** (International Components for Unicode). Bu olmadan Python süreci, ilk Aspose.Slides çağrısında `Couldn't find a valid ICU package installed on the system` mesajıyla sonlanır.

Debian ve Ubuntu'da her ikisini de apt ile kurun:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

ICU paketinin adı sürümünü içerir: Debian 13 için `libicu76` paketidir. Debian 12'de `libicu72`, Ubuntu 24.04'te ise `libicu74` kurun. Sisteminizdeki adı öğrenmek için şu komutu çalıştırın:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Ardından paketi sanal ortama kurun. Mevcut Debian ve Ubuntu sürümlerinde, sistem Python'u sanal ortam dışı `pip install` yapılmasına izin vermez ve `externally-managed-environment` hatası verir.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Aynı sanal ortamı etkinleştirerek betiklerinizi çalıştırın. Dağıtımınızın yönetmediği bir Python kullanıyorsanız (örn. resmi `python` Docker görüntülerindeki Python), sanal ortam olmadan da `pip install aspose.slides` komutunu çalıştırabilirsiniz.

Sunumlarınızda kullanılan yazı tipleri veya uygun alternatifler, slaytları PDF ya da görüntüye dönüştürürken metnin doğru render edilmesi için sistemde kurulu olmalıdır.

## **macOS**

macOS üzerindeki kurulumu henüz doğrulamıyoruz. macOS'ta Aspose.Slides aşağıdaki önkoşullara ihtiyaç duyar:

- **Shared library'li Python**, yani `--enable-shared` yapılandırma seçeneğiyle derlenmiş Python. Python'u [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos) ile kuruyorsanız, bir Python sürümü kurarken `PYTHON_CONFIGURE_OPTS` ortam değişkenini `--enable-shared` olarak ayarlayın.
- **Sistem kütüphane dizininde libpython kütüphanesi**. pyenv ile kurulan Python, libpython kütüphanesini (ör. *libpython3.9.dylib*) *~/.pyenv/versions* altında tutar; bu dosyaya */usr/local/lib* içinde bir sembolik bağ oluşturun.
- **libgdiplus**, Windows GDI+ grafik API'sinin bir uygulamasıdır. Homebrew, bunu `mono-libgdiplus` paketi olarak sunar.

Ardından paketi pip ile kurun.

## **Kurulumu Kontrol Et**

Kurulumu kontrol etmek için, [Sunum Oluşturma](/slides/tr/python-net/create-presentation/) sayfasındaki ilk örneği *hello.py* olarak kaydedin ve `python hello.py` komutunu çalıştırın. *new_presentation.pptx* dosyası geçerli klasöre kaydedilir.

## **Güncelleme**

Mevcut bir kurulumu en son sürüme yükseltmek için, paketin kurulu olduğu ortamda aşağıdaki komutu çalıştırın:

```bash
pip install --upgrade aspose.slides
```

## **SSS**

**Aspose.Slides'ı bir sanal ortamda kurabilir miyim?**

Evet. Pip ile herhangi bir Python sanal ortamına kurabilirsiniz. Linux ve macOS için gereken yerel kütüphaneler sistemde kurulur, sanal ortam içinde değildir.

**Aspose.Slides'ı Docker konteynerlerinde kullanabilir miyim?**

Evet. Görüntü, bir Linux sistemindeki aynı yerel kütüphaneleri – libgdiplus ve ICU – ve sunumlarınızın kullandığı yazı tiplerini içermelidir.

**Ücretsiz bir sürüm veya deneme sınırlaması var mı?**

Evet. Lisans olmadan Aspose.Slides değerlendirme modunda çalışır: kaydedilen her slayta bir değerlendirme filigranı ekler ve sunumlardan okunan metni kısaltır. Bu sınırlamaları kaldırmak için geçerli bir [lisans](/slides/tr/python-net/licensing/) uygulayın.