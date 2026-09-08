---
title: Python üzerinden Java ile Sunum Mürekkep Nesnelerini Yönet
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/python-java/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- mürekkep dışa aktarımı
- mürekkep işleme
- mürekkebi gizle
- InkOptions
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint mürekkep nesnelerini yönetin, izleri ve fırça özelliklerini düzenleyin ve PDF, HTML, SVG, TIFF ve görüntü dışa aktarımı sırasında mürekkebin görünümünü kontrol edin."
---
## **Giriş**

PowerPoint, serbest çizim darbeleri çizebilmenizi sağlayan bir mürekkep özelliği sunar. Mürekkep, diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve bir slaytta belirli öğelere dikkat çekmek için kullanılabilir.

Aspose.Slides, mürekkep nesneleriyle çalışmak için gerekli türleri sağlar. Örneğin, [Ink](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ink/) sınıfı bir slayttaki mürekkep nesnesini temsil eder.

## **Düzenli Nesneler ve Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler tipik olarak şekil nesneleriyle temsil edilir. En basit biçimde, bir şekil, nesnenin (çerçevesinin) alanını tanımlayan ve konteyner boyutu, şekil ve arka plan gibi özellikleri içeren bir kapsayıcıdır. Daha fazla bilgi için [Shape Layout Format](/slides/tr/python-java/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Ancak, PowerPoint bir mürekkep nesnesiyle ilgilenirken, çerçeve (kapsayıcı) özelliklerinin tümünü, yalnızca boyutunu hariç tutarak yok sayar. Kapsayıcı alanın boyutu standart [Shape.getWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getWidth) ve [Shape.getHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getHeight) yöntemleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep İzleri**

Mürekkep izi, bir kullanıcının dijital mürekkep yazarken kalemin izini kaydetmek için kullanılan temel bir öğedir. Bir iz, birbirine bağlı noktaların bir dizisini saklar.

Kodlamanın en basit biçimi, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlı noktalar render edildiğinde aşağıdaki gibi bir görüntü oluştururlar:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Fırça, bir mürekkep izinin noktalarını birbirine bağlayan çizgileri çizmeye yarar. Fırçanın kendi rengi ve boyutu vardır; bu, [InkBrush.getColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkbrush/#getColor) ve [InkBrush.getSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkbrush/#getSize) yöntemleriyle temsil edilir.

### **Mürekkep Fırçası Rengini Ayarlama**

Bu Python kodu, bir mürekkep fırçasının rengini nasıl ayarlayacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Mürekkep Fırçası Boyutunu Ayarlama**

Bu Python kodu, bir mürekkep fırçasının boyutunu nasıl ayarlayacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

Genel olarak, bir fırçanın genişliği ve yüksekliği eşleşmez, bu nedenle PowerPoint fırça boyutunu göstermez (ilgili veri bölümü gri tonludur). Fırça genişliği ve yüksekliği eşleştiğinde PowerPoint boyutu şu şekilde görüntüler:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık kazandırmak için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları gözden geçirelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu hesaba katmaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (önceki görsele bakın).

Bu nedenle, tüm mürekkep nesnesinin görünür alanını belirlemek için izlerinin fırça boyutu dikkate alınmalıdır. Burada hedef nesne (el yazısı izleri), kapsayıcının (çerçevenin) boyutuna ölçeklendirilmiştir. Kapsayıcının boyutu değiştiğinde fırça boyutu sabit kalır ve tersine de geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metin nesneleri için benzer bir davranış sergiler:

![ink_powerpoint6](ink_powerpoint6.png)

## **Dışa Aktarım ve İşleme Sırasında Mürekkep Görünümünü Kontrol Etme**

Aspose.Slides, dışa aktarılan veya render edilen çıktıda mürekkep nesnelerinin nasıl görüneceğini kontrol etmek için [InkOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/) sınıfını sağlar. Özelliklerini kullanarak mürekkebi tamamen gizleyebilir veya mürekkep fırça maske işlemlerinin yorumlanma şeklini değiştirebilirsiniz.

Mürekkep seçenekleri, çeşitli çıktı tipleri için dışa aktarma veya işleme seçenekleri aracılığıyla kullanılabilir:

| Çıktı | Mürekkep seçenekleri özelliği |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Aşağıdaki [InkOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/) yöntemleri aynı iki ayarı ortaya koyar:

- [getHideInk](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/#getHideInk) mürekkep nesnelerinin çıktıya dahil edilip edilmeyeceğini belirler. Varsayılan değeri `False`tır.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) bir maske işleminin, bir mürekkep fırçası render edilirken opaklık olarak yorumlanıp yorumlanmayacağını belirler. Varsayılan değeri `True`dır; bunun yerine ROP işlemini kullanmak için `False` ile [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) çağırın.

### **PDF Çıktısında Mürekkep Nesnelerini Gizleme**

Varsayılan olarak, mürekkep nesneleri dışa aktarma sırasında görünür kalır. El yazısı notları veya diğer mürekkep içerikleri olmadan temiz bir çıktı elde etmek için [InkOptions.setHideInk](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/#setHideInk) yöntemini `True` ile çağırın.

Aşağıdaki Python örneği, tüm mürekkep nesnelerini gizleyerek bir sunumu PDF olarak dışa aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Bir Slaytı Görüntü Olarak İşlerken Mürekkep Nesnelerini Gizleme**

Slaytları bitmap görüntü olarak render ederken mürekkep nesnelerini gizlemek için [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/#getInkOptions) yapılandırın ve render seçeneklerini [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) metoduna iletin.

Aşağıdaki Python örneği, ilk slaytı mürekkep nesneleri olmadan PNG görüntüsü olarak render eder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Mürekkep Maskesi İşlemesini Kontrol Etme**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) ayarı, mürekkep fırçaları render edilirken maske işlemlerinin nasıl yorumlanacağını kontrol eder. Varsayılan değer `True` olup opaklık kullanır. Bunun yerine ROP işlemini kullanmak için `False` ile [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) çağırın.

Aşağıdaki Python örneği, bir slaytı SVG olarak dışa aktarır ve mürekkep maske işlemleri için ROP tabanlı render kullanır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

Aynı ayar, bir sunumu dışa aktarırken veya bir slaytı TIFF olarak render ederken [TiffOptions.getInkOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/#getInkOptions) aracılığıyla da uygulanabilir.

### **Mürekkebi Gizlemeyi mi Saklamayı mı Seçin**

Dağıtım için inceleme işaretleri olmayan temiz bir sunum sürümüne ihtiyacınız varsa, dışa aktarma sırasında [InkOptions.setHideInk](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/#setHideInk) yöntemini `True` ile çağırın.

Mürekkep notları, el yazısı açıklamalar, vurgulamalar veya çizimler gibi içeriklerin dışa aktarılan sonuçta görünür kalması istendiğinde, [InkOptions.getHideInk](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/#getHideInk) varsayılan `False` değerinde bırakın. Bu, aynı sunumdan kaynak mürekkep nesnelerini değiştirmeden ayrı inceleme ve son çıktılar üretebilmenizi sağlar.

## **SSS**

**Mevcut bir mürekkep darbesinin rengini veya boyutunu değiştirebilir miyim?**

Evet. [Ink.getTraces](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ink/#getTraces) ile izi alın, ardından [InkTrace.getBrush](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inktrace/#getBrush) metodunu değiştirin. Rengi değiştirmek için [InkBrush.setColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkbrush/#setColor), boyutu değiştirmek için [InkBrush.setSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkbrush/#setSize) metodunu çağırın.

**Mürekkebi gizlemek kaynak sunumu değiştirir mi?**

Hayır. [InkOptions.setHideInk](https://reference.aspose.com/slides/tr/python-java/aspose.slides/inkoptions/#setHideInk) yalnızca render edilen veya dışa aktarılan sonucu etkiler; kaynak sunumdaki mürekkep nesnelerini kaldırmaz veya değiştirmez.

**Hangi dışa aktarma formatları mürekkep seçeneklerini destekler?**

PDF, HTML, SVG, TIFF ve bitmap slayt görüntüleri için yukarıda gösterilen ilgili dışa aktarma veya işleme seçenekleri aracılığıyla mürekkep seçeneklerini yapılandırabilirsiniz.

**İlgili Okumalar**

* Şekiller hakkında genel bilgi için, [PowerPoint Shapes](/slides/tr/python-java/powerpoint-shapes/) bölümüne bakın.
* Etkili değerler hakkında daha fazla bilgi için, [Shape Effective Properties](/slides/tr/python-java/shape-effective-properties/#get-effective-font-height-value) bölümünü inceleyin.
* PDF dışa aktarımıyla ilgili ayrıntılar için, [Convert PPT and PPTX to PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) bölümüne bakın.
* HTML dışa aktarımıyla ilgili ayrıntılar için, [Convert PowerPoint Presentations to HTML](/slides/tr/python-java/convert-powerpoint-to-html/) bölümüne bakın.
* SVG dışa aktarımıyla ilgili ayrıntılar için, [Render Presentation Slides as SVG Images](/slides/tr/python-java/render-a-slide-as-an-svg-image/) bölümüne bakın.
* TIFF dışa aktarımıyla ilgili ayrıntılar için, [Convert PowerPoint Presentations to TIFF](/slides/tr/python-java/convert-powerpoint-to-tiff/) bölümüne bakın.
* Slaytı görüntüye dönüştürme işlemleriyle ilgili ayrıntılar için, [Convert Presentation Slides to Images](/slides/tr/python-java/convert-slide/) bölümüne bakın.