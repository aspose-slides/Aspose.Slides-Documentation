---
title: Docker'da Aspose.Slides Nasıl Çalıştırılır
linktitle: Docker'da Aspose.Slides
type: docs
weight: 150
url: /tr/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker'da Aspose.Slides
- Docker konteyneri
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- yazı tipleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Docker'da .NET üzerinden Python için Aspose.Slides çalıştırma: çalışan bir Dockerfile, paketin ihtiyaç duyduğu yerel kütüphaneler, yazı tipi kurulumu ve konteyner içindeki lisanslama."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, Linux konteynerlerinde çalışır, ancak paket, bir .NET Core 3.1 çalışma zamanını içeren bir Python sarmalayıcısıdır. Bu çalışma zamanı, ince Python görüntülerinin içinde bulunmayan üç yerel kütüphane gerektirir ve sürümlerine karşı hassastır. Bu makale, çalışan bir Dockerfile sağlar, her bağımlılığın neden gerekli olduğunu açıklar ve yazı tipleri ile bir lisansın nasıl ekleneceğini gösterir.

## **Çalışan bir Dockerfile**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Derleyin ve çalıştırın:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Neden Temel Görüntü Debian 11**

`aspose.slides` tekerleği bir **.NET Core 3.1** çalışma zamanı içerir ve bu çalışma zamanı, mevcut Debian sürümlerinde gönderilen kütüphane sürümlerinden daha eskidir. Debian 12 ve 13'te konteyner başarıyla oluşturulur ancak ilk `Presentation()` çağrısında başarısız olur:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Mesaj yanıltıcıdır — ICU bu görüntülerde kurulu, ancak ICU 72 veya 76 sürümüdür ve .NET Core 3.1 yalnızca daha eski ana sürümleri tanır. Debian 12 ayrıca OpenSSL 3 gönderir, bu da ikinci bir hataya yol açar:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` Debian 11'dir ve paketlenmiş çalışma zamanının beklediği her iki sürümü de sağlar:

| Paket | Debian 11'de Sürüm | Neden Gereklidir |
|---|---|---|
| `libgdiplus` | 6.0.4 | Şekil, metin ve görüntülerin işlenmesi için kullanılan GDI+ uygulaması |
| `libicu67` | 67.1 | Küreselleşme verileri. Daha yeni ana sürümler .NET Core 3.1 tarafından tanınmaz |
| `libssl1.1` | 1.1.1w | Şifreleme. Debian 11'de önceden kurulu; Debian 12+’de yok |
| `libfontconfig1` | — | Yazı tipi keşfi |

`libssl1.1` zaten temel görüntüde bulunduğundan `apt-get install` içinde listelenmesine gerek yoktur.

Daha yeni bir temel görüntü kullanmanız gerekiyorsa, ICU gereksinimini atlamak için `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` ayarlayın. Bu, kültüre özgü biçimlendirmeyi devre dışı bırakır ve **OpenSSL** sorununu çözmez, bu nedenle Debian 11 hâlâ daha basit bir seçimdir.

## **Yazı Tipleri**

İnce görüntülerde hiç yazı tipi bulunmaz. En az bir yazı tipi kurulu olmadan, metin PDF, görüntü ve HTML çıktısında boş kutucuklar olarak gösterilir. `fonts-dejavu-core` küçük, genel amaçlı bir başlangıç noktasıdır.

Bir sunumun amaçlanan görünümünü yakalamak için, kullanılan yazı tiplerini görüntüye kopyalayın ve Aspose.Slides'ı onlara yönlendirin:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Konteyner içinde Lisanslama**

Lisans dosyasını görüntünün içine yerleştirmeyin — görüntüyü çeken herkes lisansı alır. Lisansı çalışma zamanında bağlayın:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Lisans olmadan kütüphane değerlendirme modunda çalışır; bu mod bir filigran ekler ve işlenen slayt sayısını sınırlar. Ayrıntılar için [Lisanslama](/slides/tr/python-net/licensing/) sayfasına bakın.

## **Bellek**

PDF ya da görüntülere işleme, dosya okuma işleminden daha fazla bellek tüketir. Sıkı bellek limitlerine sahip konteynerler, bir dönüşüm sırasında OOM killer tarafından sonlandırılabilir; bu genellikle sürecin Python izleme izi olmadan kaybolması şeklinde görülür. Böyle bir durum oluşursa, kodu incelemeden önce konteynerin bellek limitini artırın.