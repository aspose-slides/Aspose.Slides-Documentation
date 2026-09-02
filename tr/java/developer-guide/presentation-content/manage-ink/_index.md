---
title: Java'da Sunum Mürekkep Nesnelerini Yönet
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/java/manage-ink/
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
- IInkOptions
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin, izleri ve fırça özelliklerini düzenleyin ve Aspose.Slides for Java ile PDF, HTML, SVG, TIFF ve görüntü dışa aktarımı sırasında mürekkep görünümünü kontrol edin."
---
## **Giriş**

PowerPoint, serbest çizim darbeleri çizmenizi sağlayan bir mürekkep özelliği sunar. Mürekkep, diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve bir slayttaki belirli öğelere dikkat çekmek için kullanılabilir.

Aspose.Slides, mürekkep nesneleriyle çalışmak için gereken tipleri sağlar. Örneğin, [IInk](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iink/) arayüzü bir slayttaki mürekkep nesnesini temsil eder.

## **Normal Nesneler ve Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler tipik olarak şekil nesneleriyle temsil edilir. En basit biçiminde, bir şekil, nesnenin alanını (çerçevesini) tanımlayan, boyut, şekil ve arka plan gibi özellikleri içeren bir kapsayıcıdır. Daha fazla bilgi için, [Shape Layout Format](https://docs.aspose.com/slides/tr/java/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Ancak PowerPoint bir mürekkep nesnesini işlediğinde, çerçeve (kapsayıcı) özelliklerinin tamamını, sadece boyutunu hariç tutarak yok sayar. Kapsayıcı alanın boyutu, standart [IShape.getWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getWidth--) ve [IShape.getHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getHeight--) yöntemleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep İzleri**

Mürekkep izi, bir kullanıcının dijital mürekkep yazarken kalemin yolunu kaydetmek için kullanılan temel bir öğedir. Bir iz, bağlanmış noktaların bir dizisini depolar.

Kodlamanın en basit biçimi, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlanmış noktalar çizildiğinde aşağıdaki gibi bir görüntü oluşur:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Fırça, bir mürekkep izinin noktalarını birleştiren çizgileri çizmek için kullanılır. Fırçanın kendine özgü bir rengi ve boyutu vardır; bu, [IInkBrush.getColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkbrush/#getColor--) ve [IInkBrush.getSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkbrush/#getSize--) yöntemleriyle temsil edilir.

### **Mürekkep Fırçası Rengini Ayarlama**

Bu Java kodu, bir mürekkep fırçasının rengini nasıl ayarlayacağınızı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Mürekkep Fırçası Boyutunu Ayarlama**

Bu Java kodu, bir mürekkep fırçasının boyutunu nasıl ayarlayacağınızı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Genellikle bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (ilgili veri bölümü gri tonludur). Genişlik ve yükseklik eşleştiğinde PowerPoint boyutu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık getirmek için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları inceleyelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve) fırçaların boyutunu hesaba katmaz — her zaman çizgi kalınlığının sıfır olduğunu varsayar (önceki görsele bakın).

Bu nedenle, tüm mürekkep nesnesinin görünen alanını belirlemek için izlerin fırça boyutu dikkate alınmalıdır. Burada hedef nesne (el yazısı metin izi), kapsayıcının (çerçevenin) boyutuna ölçeklendirilmiştir. Kapsayıcının boyutu değiştiğinde fırça boyutu sabit kalır ve tersine de geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metin nesneleri için benzer bir davranış sergiler:

![ink_powerpoint6](ink_powerpoint6.png)

## **Dışa Aktarım ve İşleme Sırasında Mürekkep Görünümünü Kontrol Etme**

Aspose.Slides, dışa aktarılmış veya işlenmiş çıktıda mürekkep nesnelerinin nasıl görüneceğini kontrol etmek için [IInkOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/) arayüzünü sağlar. Özelliklerini, mürekkebi tamamen gizlemek veya mürekkep fırça maske işlemlerinin nasıl yorumlandığını değiştirmek için kullanabilirsiniz.

Mürekkep seçenekleri, çeşitli çıktı türleri için dışa aktarma veya işleme seçenekleri aracılığıyla kullanılabilir:

| Çıktı | Mürekkep seçenekleri özelliği |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

Aşağıdaki [IInkOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/) yöntemleri aynı iki ayarı ortaya çıkarır:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/#getHideInk--) mürekkep nesnelerinin çıktıya dahil edilip edilmediğini belirler. Varsayılan değeri `false` tir.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) bir mürekkep fırçası işlenirken maske işleminin opaklık olarak yorumlanıp yorumlanmayacağını belirler. Varsayılan değeri `true` dır; bunun yerine ROP işlemini kullanmak için [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) yöntemini `false` ile çağırın.

### **PDF Çıktısında Mürekkep Nesnelerini Gizleme**

Varsayılan olarak, dışa aktarım sırasında mürekkep nesneleri görünür kalır. El yazısı notları veya diğer mürekkep içerikleri olmadan temiz bir çıktı oluşturmak için [IInkOptions.setHideInk](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) yöntemini `true` ile çağırın.

Aşağıdaki Java örneği, tüm mürekkep nesnelerini gizleyerek bir sunumu PDF olarak dışa aktarır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Bir Slaytı Görüntü Olarak İşlerken Mürekkep Nesnelerini Gizleme**

Slaytları bitmap görüntüler olarak işlerken mürekkep nesnelerini gizlemek için [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/renderingoptions/#getInkOptions--) ayarlayın ve işleme seçeneklerini [ISlide.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) yöntemine aktarın.

Aşağıdaki Java örneği, ilk slaytı mürekkep nesneleri olmadan bir PNG görüntüsü olarak işler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Mürekkep Maske İşlemesini Kontrol Etme**

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) ayarı, mürekkep fırçaları işlenirken maske işlemlerinin nasıl yorumlandığını kontrol eder. Varsayılan değer `true` olup opaklık kullanır. Bunun yerine ROP işlemini kullanmak için [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) yöntemini `false` ile çağırın.

Aşağıdaki Java örneği, bir slaytı SVG olarak dışa aktarır ve mürekkep maske işlemleri için ROP tabanlı işleme kullanır:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

Aynı ayar, bir sunumu dışa aktarırken veya bir slaytı TIFF olarak işlerken [TiffOptions.getInkOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#getInkOptions--) aracılığıyla da uygulanabilir.

### **Mürekkebi Gizleyip Gizlemeyeceğinizi veya Korumayı Seçin**

İnceleme işaretleri olmadan dağıtım için temiz bir notlu sunum sürümüne ihtiyacınız olduğunda, dışa aktarım sırasında [IInkOptions.setHideInk](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) yöntemini `true` ile çağırın.

Mürekkep notları, el yazısı notlar, vurgulamalar veya çizimler gibi istenen içeriğin bir parçası olduğunda, [IInkOptions.getHideInk](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/#getHideInk--) değerini varsayılan `false` olarak bırakın. Bu, uygulamaların aynı sunumdan kaynak mürekkep nesnelerini değiştirmeden ayrı inceleme ve nihai çıktılar üretmesini sağlar.

## **SSS**

**Mevcut bir mürekkep darbesinin rengini veya boyutunu değiştirebilir miyim?**

Evet. [IInk.getTraces](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iink/#getTraces--) yöntemini kullanarak izi alın, ardından [IInkTrace.getBrush](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinktrace/#getBrush--) yöntemini değiştirin. Rengi değiştirmek için [IInkBrush.setColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-), boyutu değiştirmek için ise [IInkBrush.setSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) yöntemini çağırın.

**Mürekkebi gizlemek kaynak sunumu değiştirir mi?**

Hayır. [IInkOptions.setHideInk](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) çağrısı yalnızca işlenmiş veya dışa aktarılmış sonucu etkiler; kaynak sunumdaki mürekkep nesnelerini kaldırmaz veya değiştirmez.

**Hangi dışa aktarma formatları mürekkep seçeneklerini destekler?**

PDF, HTML, SVG, TIFF ve bitmap slayt görüntüleri için yukarıda gösterilen ilgili dışa aktarma veya işleme seçenekleri aracılığıyla mürekkep seçeneklerini yapılandırabilirsiniz.

**Daha fazla okuma**

* Şekiller hakkında genel bilgi için, [PowerPoint Shapes](https://docs.aspose.com/slides/tr/java/powerpoint-shapes/) bölümüne bakın.
* Etkili değerler hakkında daha fazla bilgi için, [Shape Effective Properties](https://docs.aspose.com/slides/tr/java/shape-effective-properties/#get-effective-font-height-value) bölümüne bakın.
* PDF dışa aktarımı hakkında ayrıntılar için, [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/tr/java/convert-powerpoint-to-pdf/) bölümüne bakın.
* HTML dışa aktarımı hakkında ayrıntılar için, [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/tr/java/convert-powerpoint-to-html/) bölümüne bakın.
* SVG dışa aktarımı hakkında ayrıntılar için, [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/tr/java/render-a-slide-as-an-svg-image/) bölümüne bakın.
* TIFF dışa aktarımı hakkında ayrıntılar için, [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/tr/java/convert-powerpoint-to-tiff/) bölümüne bakın.
* Slaytı görüntü olarak işleme hakkında ayrıntılar için, [Convert Presentation Slides to Images](https://docs.aspose.com/slides/tr/java/convert-slide/) bölümüne bakın.