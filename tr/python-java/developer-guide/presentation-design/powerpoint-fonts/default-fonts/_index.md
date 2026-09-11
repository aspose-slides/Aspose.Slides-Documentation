---
title: Python üzerinden Java ile Varsayılan Sunum Yazı Tiplerini Belirleme
linktitle: Varsayılan Yazı Tipi
type: docs
weight: 30
url: /tr/python-java/default-font/
keywords:
- varsayılan yazı tipi
- normal yazı tipi
- normal yazı tipi
- Asya yazı tipi
- PDF dışa aktarımı
- XPS dışa aktarımı
- görüntü dışa aktarımı
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java içerisinde varsayılan yazı tiplerini ayarlayarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) dosyalarının PDF, XPS ve görüntülere doğru dönüştürülmesini sağlayın."
---
## **Overview**

Aspose.Slides, bir sunum render edildiğinde kullanılan varsayılan yazı tiplerini belirlemenizi sağlar. Bu, slayt küçük resimleri oluştururken veya bir sunumu PDF ve XPS gibi formatlara dışa aktarırken kullanışlıdır. Varsayılan yazı tipleri, sunum yüklenmeden önce [LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) aracılığıyla yapılandırılır.

[setDefaultRegularFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) yöntemi normal metin için varsayılan yazı tipini tanımlar, [setDefaultAsianFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) ise Asya metni için varsayılan yazı tipini tanımlar. Bu seçenekler ayarlandıktan sonra sunum, belirtilen yazı tipleri kullanılarak yüklenebilir ve render edilebilir.

## **Use Default Fonts for Rendering a Presentation**

Aspose.Slides, bir sunumu PDF, XPS veya küçük resim olarak render etmek için varsayılan yazı tiplerini ayarlamanıza olanak tanır. Bu bölüm, Aspose.Slides for Python via Java kullanarak normal ve Asya metni için varsayılan yazı tiplerinin nasıl tanımlanacağını gösterir:

1. Bir [LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) örneği oluşturun.  
2. [setDefaultRegularFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) yöntemini kullanarak istediğiniz yazı tipini belirtin. Aşağıdaki örnek Wingdings'i kullanır.  
3. [setDefaultAsianFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) yöntemini kullanarak istediğiniz yazı tipini belirtin. Aşağıdaki örnek de Wingdings'i kullanır.  
4. Sunumu, yükleme seçenekleriyle birlikte [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) kullanarak yükleyin.  
5. Sonuçları doğrulamak için slayt küçük resmini, PDF ve XPS'yi oluşturun.

Aşağıdaki örnek bu adımları uygular:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Varsayılan normal ve Asya yazı tiplerini tanımlamak için yükleme seçeneklerini kullanın.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Sunumu yükleyin.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Bir slayt küçük resmi oluşturun.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Görüntüyü diske kaydedin.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # PDF oluşturun.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # XPS belgesi oluşturun.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**Varsayılan normal ve Asya yazı tipleri tam olarak neyi etkiler—sadece dışa aktarımı mı, yoksa küçük resimler, PDF, XPS, HTML ve SVG'yi de mi?**  
Tüm desteklenen çıktılar için renderleme işlem hattına katılırlar. Bu, slayt küçük resimleri, [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/python-java/convert-powerpoint-to-xps/), [raster görüntüler](/slides/tr/python-java/convert-powerpoint-to-png/), [HTML](/slides/tr/python-java/convert-powerpoint-to-html/), ve [SVG](/slides/tr/python-java/render-a-slide-as-an-svg-image/) içerir, çünkü Aspose.Slides bu hedeflerde aynı yerleşim ve glif çözümleme mantığını kullanır.

**Sadece bir PPTX dosyasını okuyup kaydederken, renderleme yapılmadan varsayılan yazı tipleri uygulanır mı?**  
Hayır. Varsayılan yazı tipleri, metnin ölçülmesi ve çizilmesi gerektiğinde önemlidir. Bir sunumun doğrudan açılıp kaydedilmesi, depolanan yazı tipi dizilerini veya dosyanın yapısını değiştirmez. Varsayılan yazı tipleri, metni renderleyen veya yeniden akışa sokan işlemler sırasında devreye girer.

**Kendi yazı tipi klasörlerimi eklersem ya da bellekteki yazı tiplerini sağlarsam, varsayılan yazı tipleri seçilirken bunlar dikkate alınır mı?**  
Evet. [Custom font sources](/slides/tr/python-java/custom-font/) motorun kullanabileceği mevcut aile ve glif kataloğunu genişletir. Varsayılan yazı tipleri ve herhangi bir [fallback rules](/slides/tr/python-java/fallback-font/) önce bu kaynaklara başvurur, bu da sunucularda ve konteynerlerde daha güvenilir kapsama sağlar.

**Varsayılan yazı tipleri metin ölçümlerini (kerning, ilerlemeler) ve dolayısıyla satır sonlarını ve kaydırmayı etkiler mi?**  
Evet. Yazı tipini değiştirmek, glif ölçümlerini değiştirir ve renderleme sırasında satır sonlarını, kaydırmayı ve sayfalamayı etkileyebilir. Yerleşim stabilitesi için [embed the original fonts](/slides/tr/python-java/embedded-font/) veya ölçüsel olarak uyumlu varsayılan ve fallback ailelerini seçin.

**Sunumda kullanılan tüm yazı tipleri gömülü ise, varsayılan yazı tiplerini ayarlamanın bir anlamı var mı?**  
Genellikle gerekli değildir, çünkü [embedded fonts](/slides/tr/python-java/embedded-font/) zaten tutarlı bir görünüm sağlar. Varsayılan yazı tipleri, gömülü alt küme tarafından kapsanmayan karakterler veya bir dosyanın gömülü ve gömülmemiş metin karışımı durumunda güvenlik ağı olarak hâlâ yardımcı olur.