---
title: Python Kullanarak Sunumlarda SmartArt Grafiklerini Yönetme
linktitle: SmartArt Grafikler
type: docs
weight: 20
url: /tr/python-java/manage-smartart-shape/
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
- SmartArt düzen tipi
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python'da Aspose.Slides kullanarak PowerPoint SmartArt oluşturma, düzenleme ve stil verme işlemlerini otomatikleştirin; kısa kod örnekleri ve performansa odaklı rehberlik içerir."
---
## **Genel Bakış**

Aspose.Slides, programlı olarak PowerPoint sunumlarında SmartArt grafiklerini oluşturmanıza ve yönetmenize olanak tanır. Bu makale, bir slayta SmartArt şekli eklemeyi, mevcut SmartArt şekillerine erişmeyi, belirli bir düzen tipine göre SmartArt bulmayı ve SmartArt stilini veya renk stilini değiştirerek görsel görünümünü güncellemeyi açıklar.

Örnekler, sunum slaydının şekil koleksiyonu aracılığıyla SmartArt şekilleriyle nasıl çalışılacağını, bir şeklin SmartArt olup olmadığını nasıl kontrol edileceğini ve ardından özelliklerini nasıl değiştirebileceğinizi veya inceleyebileceğinizi gösterir.

## **SmartArt Şekli Oluşturma**
Aspose.Slides for Python via Java, SmartArt şekilleri oluşturmak için bir API sağlar. Bir slaytta SmartArt şekli oluşturmak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayt alın.
1. Bir [SmartArtLayoutType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartlayouttype/) belirterek [SmartArt şekli ekleyin](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addSmartArt).
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Bir SmartArt şekli ekle.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Sunumu kaydet.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Şekil: Slayta eklenen SmartArt şekli**|

## **Bir Slaytta SmartArt Şekline Erişme**
Aşağıdaki örnek, bir sunum slaydındaki SmartArt şekillerine erişir. Slayttaki her şekli döngüye alır ve şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) örneği olup olmadığını kontrol eder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # İlk slayttaki her şekli döngüye al.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Belirli Bir Düzen Tipine Sahip SmartArt Şekline Erişme**
Aşağıdaki örnek, [SmartArt.getLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/#getLayout) tarafından döndürülen belirli bir düzen tipine sahip bir [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) şekline erişir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. İlk slaytı indeksine göre alın.
1. İlk slayttaki her şekli döngüye al.
1. Şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) örneği olup olmadığını kontrol edin.
1. SmartArt şeklinin belirtilen düzen tipine sahip olup olmadığını kontrol edin ve gerekli işlemi gerçekleştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # İlk slayttaki her şekli döngüye al.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt düzenini kontrol et.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **SmartArt Şekli Stilini Değiştirme**
Bu örnek, bir SmartArt şeklinin hızlı stilini nasıl değiştireceğinizi gösterir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. İlk slaytı indeksine göre alın.
1. İlk slayttaki her şekli döngüye al.
1. Şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) örneği olup olmadığını kontrol edin.
1. Belirtilen stile sahip SmartArt şekli bulun.
1. SmartArt şekli için yeni stili ayarlayın.
1. Sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # İlk slayttaki her şekli döngüye al.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt stilini kontrol et ve değiştir.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Şekil: Stili değiştirilen SmartArt şekli**|

## **SmartArt Şekli Renk Stilini Değiştirme**
Bu örnek, belirli bir renk stiline sahip bir SmartArt şekline erişir ve o stili değiştirir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. İlk slaytı indeksine göre alın.
1. İlk slayttaki her şekli döngüye al.
1. Şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) örneği olup olmadığını kontrol edin.
1. Belirtilen renk stiline sahip SmartArt şekli bulun.
1. SmartArt şekli için yeni renk stilini ayarlayın.
1. Sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # İlk slayttaki her şekli döngüye al.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt stilini kontrol et ve değiştir.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Şekil: Renk stili değiştirilen SmartArt şekli**|

## **FAQ**

**SmartArt'ı tek bir nesne olarak canlandırabilir miyim?**

Evet. SmartArt bir şekildir, bu nedenle diğer şekillerde olduğu gibi animasyon API'si aracılığıyla [standart animasyonlar](/slides/tr/python-java/powerpoint-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilirsiniz.

**Bir slayttaki belirli bir SmartArt'ı dahili kimliğini bilmiyorsam nasıl bulabilirim?**

Şeklin [alternatif metnini](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setAlternativeText) ayarlayın ve bu değere göre şekli arayın—bu, hedef şekli bulmanın önerilen yoludur.

**SmartArt'ı diğer şekillerle gruplandırabilir miyim?**

Evet. SmartArt'ı diğer şekillerle (resimler, tablolar vb.) gruplandırabilir ve ardından [grubu manipüle edebilirsiniz](/slides/tr/python-java/group/).

**Belirli bir SmartArt'ın (örneğin önizleme veya rapor için) görüntüsünü nasıl alabilirim?**

Şeklin bir küçük resim/görüntüsünü dışa aktarın; kütüphane [bireysel şekilleri](/slides/tr/python-java/create-shape-thumbnails/) raster dosyalara (PNG/JPG/TIFF) render edebilir.

**Tüm sunumu PDF'ye dönüştürürken SmartArt görünümü korunacak mı?**

Evet. Render motoru, [PDF dışa aktarımı](/slides/tr/python-java/convert-powerpoint-to-pdf/) için yüksek doğruluk hedefler; çeşitli kalite ve uyumluluk seçenekleri sunar.