---
title: Python Kullanarak Sunumlarda SmartArt Grafiklerini Yönetme
linktitle: SmartArt Grafikler
type: docs
weight: 20
url: /tr/python-net/manage-smartart-shape/
keywords:
- SmartArt nesnesi
- SmartArt grafiği
- SmartArt stili
- SmartArt rengi
- SmartArt oluşturma
- SmartArt ekleme
- SmartArt düzenleme
- SmartArt değiştirme
- SmartArt erişimi
- SmartArt düzen türü
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET üzerinden Python'da PowerPoint SmartArt oluşturma, düzenleme ve stil oluşturmayı otomatikleştirin; net kod örnekleri ve performansa odaklı rehberlik sunar."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında SmartArt grafiklerini programlı olarak oluşturmanıza ve yönetmenize olanak tanır. Bu makale, bir slayta SmartArt şekli eklemeyi, mevcut SmartArt şekillerine erişmeyi, belirli bir düzen türüne göre SmartArt bulmayı ve SmartArt stilini veya renk stilini değiştirerek görsel görünümünü güncellemeyi açıklar.

Örnekler, sunum slaytının şekil koleksiyonu üzerinden SmartArt şekilleriyle nasıl çalışılacağını, bir şeklin SmartArt olup olmadığını kontrol etmeyi ve ardından özelliklerini değiştirmeyi ya da incelemeyi gösterir.

## **SmartArt Şekilleri Oluşturma**

Aspose.Slides for Python via .NET, slaytlara sıfırdan özel SmartArt şekilleri eklemenizi sağlar. API bunu kolaylaştırır. Bir slayta SmartArt şekli eklemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Hedef slaytı indeksine göre alın.
3. Düzen türünü belirterek bir SmartArt şekli ekleyin.
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # Sunum slaydına erişin.
    slide = presentation.slides[0]
    # Bir SmartArt şekli ekleyin.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Sunumu diske kaydedin.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Slaytlardaki SmartArt Şekillerine Erişim**

Aşağıdaki kod, bir slayttaki SmartArt şekillerine nasıl erişileceğini gösterir. Örnek, slayttaki her şekli döndürür ve bunun bir [SmartArt](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/) nesnesi olup olmadığını kontrol eder.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Bir sunum dosyasını yükleyin.
with slides.Presentation("SmartArt.pptx") as presentation:
    # İlk slayd üzerindeki her şekli döndürün.
    for shape in presentation.slides[0].shapes:
        # Şeklin bir SmartArt şekli olup olmadığını kontrol edin.
        if isinstance(shape, smartart.SmartArt):
            # Şekil adını yazdırın.
            print("Shape name:", shape.name)
```

## **Belirli Bir Düzen Türüne Sahip SmartArt Şekillerine Erişim**

Aşağıdaki örnek, belirli bir düzen türüne sahip bir SmartArt şekline nasıl erişileceğini gösterir. Bir SmartArt’ın düzen türünün değiştirilemeyeceğini unutmayın; bu sadece okunabilir ve şekil oluşturulduğunda ayarlanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun ve SmartArt şekli içeren sunumu yükleyin.
2. İndeksine göre ilk slayta bir referans alın.
3. İlk slayttaki her şekli döndürün.
4. Şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/) nesnesi olup olmadığını kontrol edin.
5. SmartArt şeklinin düzen türü ihtiyacınıza eşleşiyorsa, gerekli işlemleri gerçekleştirin.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # İlk slayd üzerindeki her şekli döndürün.
    for shape in presentation.slides[0].shapes:
        # Şeklin bir SmartArt şekli olup olmadığını kontrol edin.
        if isinstance(shape, smartart.SmartArt):
            # SmartArt düzen türünü kontrol edin.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **SmartArt Şekil Stilini Değiştirme**

Aşağıdaki örnek, SmartArt şekillerini bulmayı ve stillerini değiştirmeyi gösterir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) oluşturun ve SmartArt şekil(ler)ini içeren dosyayı yükleyin.
2. İndeksine göre ilk slayta bir referans alın.
3. İlk slayttaki her şekli döndürün.
4. Belirtilen stile sahip SmartArt şekli bulun.
5. Yeni stili SmartArt şekline atayın.
6. Sunumu kaydedin.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # İlk slayd üzerindeki her şekli döndürün.
    for shape in presentation.slides[0].shapes:
        # Şeklin bir SmartArt şekli olup olmadığını kontrol edin.
        if isinstance(shape, smartart.SmartArt):
            # SmartArt stilini kontrol edin.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # SmartArt stilini değiştirin.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Sunumu kaydedin.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt Şekillerinin Renk Stilini Değiştirme**

Bu örnek, bir SmartArt şeklinin renk stilini nasıl değiştireceğinizi gösterir. Örnek kod, belirtilen renk stiline sahip bir SmartArt şekli bulur ve günceller.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun ve SmartArt şekli(ler)ini içeren sunumu yükleyin.
2. İndeksine göre ilk slayta bir referans alın.
3. İlk slayttaki her şekli döndürün.
4. Şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/) nesnesi olup olmadığını kontrol edin.
5. Belirtilen renk stiline sahip SmartArt şekli bulun.
6. Bu SmartArt şekli için yeni renk stilini ayarlayın.
7. Sunumu kaydedin.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # İlk slayd üzerindeki her şekli döndürün.
    for shape in presentation.slides[0].shapes:
        # Şeklin bir SmartArt şekli olup olmadığını kontrol edin.
        if isinstance(shape, smartart.SmartArt):
            # Renk tipini kontrol edin.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Renk tipini değiştirin.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Sunumu kaydedin.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**SmartArt'ı tek bir nesne olarak canlandırabilir miyim?**

Evet. SmartArt bir şekildir, bu yüzden diğer şekillerde olduğu gibi animasyon API'si aracılığıyla [standart animasyonları](/slides/tr/python-net/powerpoint-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilirsiniz.

**Bir slayttaki belirli bir SmartArt’ı iç kimliğini bilmiyorsam nasıl bulabilirim?**

Alternatif Metni (AltText) ayarlayın ve bu değerle şekli arayın—bu, hedef şekli bulmanın önerilen bir yoludur.

**SmartArt'ı diğer şekillerle gruplayabilir miyim?**

Evet. SmartArt'ı diğer şekillerle (resimler, tablolar vb.) gruplayabilir ve ardından [grubu manipüle edebilirsiniz](/slides/tr/python-net/group/).

**Belirli bir SmartArt'ın görüntüsünü (ör. önizleme veya rapor için) nasıl alabilirim?**

Şeklin küçük önizlemesini/görüntüsünü dışa aktarın; kütüphane [bireysel şekilleri](/slides/tr/python-net/create-shape-thumbnails/) PNG/JPG/TIFF gibi raster dosyalarına render edebilir.

**Tüm sunumu PDF'ye dönüştürdüğümde SmartArt görünümü korunacak mı?**

Evet. Renderleme motoru, [PDF dışa aktarımı](/slides/tr/python-net/convert-powerpoint-to-pdf/) için yüksek doğruluk hedefler ve çeşitli kalite ve uyumluluk seçenekleri sunar.