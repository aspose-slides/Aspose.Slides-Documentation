---
title: Python'da Sunum Mürekkep Nesnelerini Yönet
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/python-net/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- mürekkep dışa aktarımı
- mürekkep oluşturma
- mürekkebi gizle
- InkOptions
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint mürekkep nesnelerini yönetin, izleri ve fırça özelliklerini düzenleyin ve PDF, HTML, SVG, TIFF ve görüntü dışa aktarımı sırasında mürekkep görünümünü kontrol edin."
---
## **Giriş**

PowerPoint, serbest biçimli darbeler çizebilmenizi sağlayan bir mürekkep özelliği sunar. Mürekkep, diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve bir slayttaki belirli öğelere dikkat çekmek için kullanılabilir.

[aspose.slides.ink](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/) ad alanı, mürekkep nesneleriyle çalışmak için gereken sınıfları içerir. Örneğin, [Ink](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/ink/) sınıfı bir slayttaki mürekkep nesnesini temsil eder.

## **Düzenli Nesneler ve Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaydındaki nesneler genellikle şekil nesneleri ile temsil edilir. En basit biçimde, bir şekil, nesnenin kendisinin (çerçevesinin) alanını tanımlayan ve kapsayıcı boyutu, şekil ve arka plan gibi özelliklere sahip bir kapsayıcıdır. Daha fazla bilgi için [Shape Layout Format](https://docs.aspose.com/slides/tr/python-net/shape-manipulations/#access-layout-formats-for-shape) sayfasına bakınız.

Ancak PowerPoint bir mürekkep nesnesini işlediğinde, nesne çerçevesinin (kapsayıcı) tüm özelliklerini boyutu dışında görmezden gelir. Kapsayıcı alanın boyutu, standart [Ink.width](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/ink/width/) ve [Ink.height](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/ink/height/) özellikleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep İzleri**

Mürekkep izi, bir kullanıcının dijital mürekkep yazarken kalemin yolunu kaydetmek için kullanılan temel bir öğedir. Bir iz, birbirine bağlı noktaların bir dizisini saklar.

Kodlamanın en basit biçimi, her örnek noktasının X ve Y koordinatlarını belirtir. Tüm bağlı noktalar oluşturulduğunda, şöyle bir görüntü ortaya çıkar:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Bir fırça, mürekkep izinin noktalarını birleştiren çizgileri çizmek için kullanılır. [InkBrush.color](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/inkbrush/color/) ve [InkBrush.size](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/inkbrush/size/) özellikleri, fırçanın rengini ve boyutunu kontrol eder.

### **Mürekkep Fırçasının Rengini Ayarlama**

Bu Python kodu, bir mürekkep fırçasının rengini nasıl ayarlayacağınızı gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Mürekkep Fırçasının Boyutunu Ayarlama**

Bu Python kodu, bir mürekkep fırçasının boyutunu nasıl ayarlayacağınızı gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Genellikle bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (ilgili veri bölümü gri tonludur). Fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutunu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık getirmek için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları gözden geçirelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu hesaba katmaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (önceki görsele bakınız).

Bu nedenle, tüm mürekkep nesnesinin görünür alanını belirlemek için izlerinin fırça boyutu dikkate alınmalıdır. Burada, hedef nesne (el yazısı metin izi) kapsayıcının (çerçevenin) boyutuna ölçeklendirilmiştir. Kapsayıcının boyutu değiştiğinde, fırça boyutu sabit kalır ve tersine de aynı durum geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metin nesneleri için benzer bir davranış kullanır:

![ink_powerpoint6](ink_powerpoint6.png)

## **Dışa Aktarma ve Oluşturma Sırasında Mürekkep Görünümünü Kontrol Etme**

Aspose.Slides, dışa aktarılan veya oluşturulan çıktıda mürekkep nesnelerinin nasıl görüneceğini kontrol etmek için [InkOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/inkoptions/) sınıfını sağlar. Bu sınıfın özelliklerini kullanarak mürekkebi tamamen gizleyebilir veya mürekkep fırçası maske işlemlerinin yorumlanma şeklini değiştirebilirsiniz.

Mürekkep seçenekleri, çeşitli çıktı türleri için dışa aktarım veya oluşturma seçenekleri aracılığıyla kullanılabilir:

| Çıktı | Mürekkep seçenekleri özelliği |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Bu özellikler aracılığıyla aynı iki ayar kullanılabilir:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/inkoptions/hide_ink/) ink nesnelerinin çıktıya dahil edilip edilmeyeceğini belirler. Varsayılan değeri `False` dır.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) bir mürekkep fırçası oluşturulurken maske işleminin opaklık olarak yorumlanıp yorumlanmayacağını belirler. Varsayılan değeri `True` tir; `False` olarak ayarlandığında ROP işlemi kullanılır.

### **PDF Çıktısında Mürekkep Nesnelerini Gizleme**

Varsayılan olarak, dışa aktarım sırasında mürekkep nesneleri görünür olur. El yazısı notlar veya diğer mürekkep içeriği olmadan temiz bir çıktı gerektiğinde [InkOptions.hide_ink](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/inkoptions/hide_ink/) değerini `True` olarak ayarlayın.

Aşağıdaki Python örneği, tüm mürekkep nesnelerini gizleyerek bir sunumu PDF olarak dışa aktarır:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Bir Slaytı Görüntü Olarak Oluştururken Mürekkep Nesnelerini Gizleme**

Kaydırmaları bitmap görüntüler olarak oluştururken mürekkep nesnelerini gizlemek için [RenderingOptions.ink_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/ink_options/) yapılandırın ve oluşturma seçeneklerini [Slide.get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/) yöntemine geçirin.

Aşağıdaki Python örneği, ilk slaytı mürekkep nesneleri olmadan bir PNG görüntüsü olarak oluşturur:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Mürekkep Maske Oluşturulmasını Kontrol Etme**

[InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) özelliği, mürekkep fırçaları oluşturulurken maske işlemlerinin nasıl yorumlanacağını kontrol eder. Varsayılan değer `True` tir ve opaklık kullanır. Özelliği `False` olarak ayarladığınızda ROP işlemi kullanılır.

Aşağıdaki Python örneği, bir slaytı SVG olarak dışa aktarır ve mürekkep maske işlemleri için ROP tabanlı oluşturma kullanır:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Aynı ayar, bir sunumu dışa aktarırken veya bir slaytı TIFF olarak oluştururken [TiffOptions.ink_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/ink_options/) aracılığıyla uygulanabilir.

### **Mürekkebi Gizleyip Gizlemeyeceğinizi Seçin**

Dışa aktarılan dosyanın, notlandırılmış bir sunumun temiz bir sürümü (örneğin, inceleme işaretleri olmadan dağıtım amaçlı son kopya) olması gerektiğinde [InkOptions.hide_ink](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/inkoptions/hide_ink/) değerini `True` olarak ayarlayın.

Mürekkep notları, inceleme yorumları, el yazısı notlar, vurgulamalar veya dışa aktarılan sonuçta görünür kalması gereken çizimler gibi amaçlanan içeriğin bir parçası olduğunda [InkOptions.hide_ink](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/inkoptions/hide_ink/) değerini varsayılan `False` olarak bırakın. Bu, uygulamaların aynı sunumdan kaynak mürekkep nesnelerini değiştirmeden ayrı inceleme ve son çıktılar üretmesini sağlar.

## **SSS**

**Mevcut bir mürekkep darbesinin rengini veya boyutunu değiştirebilir miyim?**

Evet. İzeyi [Ink.traces](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/ink/traces/) üzerinden alın, ardından onun [InkTrace.brush](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/inktrace/brush/) öğesini değiştirin. Fırçanın [InkBrush.color](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/inkbrush/color/) ve [InkBrush.size](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/inkbrush/size/) özelliklerini ayarlayabilirsiniz.

**Mürekkebi gizlemek kaynak sunumu değiştirir mi?**

Hayır. [InkOptions.hide_ink](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/inkoptions/hide_ink/) yalnızca oluşturulan veya dışa aktarılan sonucu etkiler; kaynak sunumdaki mürekkep nesnelerini kaldırmaz veya değiştirmez.

**Hangi dışa aktarma formatları mürekkep seçeneklerini destekler?**

Yukarıda gösterilen ilgili dışa aktarım veya oluşturma seçenekleri aracılığıyla PDF, HTML, SVG, TIFF ve bitmap slayt görüntüleri için mürekkep seçeneklerini yapılandırabilirsiniz.

**Daha fazla okuma**

* Şekiller hakkında genel bilgi için [PowerPoint Shapes](https://docs.aspose.com/slides/tr/python-net/powerpoint-shapes/) bölümüne bakın.
* Etkin değerler hakkında daha fazla bilgi için [Shape Effective Properties](https://docs.aspose.com/slides/tr/python-net/shape-effective-properties/#get-effective-font-height-value) sayfasına bakın.
* PDF dışa aktarımı detayları için [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/tr/python-net/convert-powerpoint-to-pdf/) sayfasına bakın.
* HTML dışa aktarımı detayları için [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/tr/python-net/convert-powerpoint-to-html/) sayfasına bakın.
* SVG dışa aktarımı detayları için [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/tr/python-net/render-a-slide-as-an-svg-image/) sayfasına bakın.
* TIFF dışa aktarımı detayları için [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/tr/python-net/convert-powerpoint-to-tiff/) sayfasına bakın.
* Slaytı görüntüye dönüştürme hakkında detaylar için [Convert Presentation Slides to Images](https://docs.aspose.com/slides/tr/python-net/convert-slide/) sayfasına bakın.