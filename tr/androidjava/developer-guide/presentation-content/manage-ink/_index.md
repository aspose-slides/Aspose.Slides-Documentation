---
title: Android'de Sunum Mürekkep Nesnelerini Yönetme
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/androidjava/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- mürekkep dışa aktarım
- mürekkep işleme
- mürekkebi gizle
- IInkOptions
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint mürekkep nesnelerini yönetin, izleri ve fırça özelliklerini düzenleyin ve PDF, HTML, SVG, TIFF ve görüntü dışa aktarımı sırasında mürekkep görünümünü kontrol edin."
---
## **Giriş**

PowerPoint, serbest çizgiler çizmenizi sağlayan bir mürekkep özelliği sunar. Mürekkep, diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve bir slayttaki belirli öğelere dikkat çekmek için kullanılabilir.

Aspose.Slides, mürekkep nesneleriyle çalışmak için gereken türleri sunar. Örneğin, [IInk](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iink/) arayüzü bir slayttaki mürekkep nesnesini temsil eder.

## **Normal Nesneler ile Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler tipik olarak şekil nesneleriyle temsil edilir. En basit haliyle, bir şekil, nesnenin kendisinin (çerçevesinin) alanını tanımlayan, ayrıca kapsayıcı boyutu, şekli ve arka planı gibi özellikleri içeren bir konteynerdir. Daha fazla bilgi için [Shape Layout Format](https://docs.aspose.com/slides/tr/androidjava/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Ancak PowerPoint bir mürekkep nesnesiyle ilgilenirken, nesne çerçevesinin (kapsayıcının) boyutu dışındaki tüm özelliklerini yok sayar. Kapsayıcı alanının boyutu, standart [IShape.getWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getWidth--) ve [IShape.getHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getHeight--) metodlarıyla belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep İzleri**

Bir mürekkep izi, kullanıcının dijital mürekkep yazarken kalemin yolunu kaydetmek için kullanılan temel bir öğedir. Bir iz, birbirine bağlı noktaların bir dizisini saklar.

Kodlamanın en basit şekli, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlı noktalar çizildiğinde, aşağıdaki gibi bir görüntü oluştururlar:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Bir fırça, bir mürekkep izinin noktalarını birleştiren çizgileri çizmek için kullanılır. Fırçanın kendi renk ve boyutu vardır; bu, [IInkBrush.getColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkbrush/#getColor--) ve [IInkBrush.getSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkbrush/#getSize--) metodlarıyla temsil edilir.

### **Mürekkep Fırçası Rengini Ayarlama**

Bu Java kodu, bir mürekkep fırçasının rengini nasıl ayarlayacağınızı gösterir:

```java
import android.graphics.Color;
import com.aspose.slides.*;

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
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Genel olarak, bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (ilgili veri bölümü gri tonludur). Fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutunu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık getirmek için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları inceleyelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu hesaba katmaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (önceki görsele bakın).

Bu nedenle, tüm mürekkep nesnesinin görünen alanını belirlemek için izlerinin fırça boyutu dikkate alınmalıdır. Burada, hedef nesne (el yazısı metin izi) kapsayıcının (çerçevenin) boyutuna göre ölçeklendirilmiştir. Kapsayıcının boyutu değiştiğinde, fırça boyutu sabit kalır ve tersine de geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metin nesneleri için benzer bir davranış kullanır:

![ink_powerpoint6](ink_powerpoint6.png)

## **Dışa Aktarma ve İşleme Sırasında Mürekkep Görünümünü Kontrol Etme**

Aspose.Slides, mürekkep nesnelerinin dışa aktarılan veya işlenen çıktıda nasıl görüneceğini kontrol etmek için [IInkOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/) arayüzünü sunar. Özelliklerini, mürekkebi tamamen gizlemek veya mürekkep fırça maskesi işlemlerinin nasıl yorumlanacağını değiştirmek için kullanabilirsiniz.

Mürekkep seçenekleri, çeşitli çıktı türleri için dışa aktarım veya işleme seçenekleri aracılığıyla kullanılabilir:

| Çıktı | Mürekkep seçenekleri özelliği |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

Aşağıdaki [IInkOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/) metodları aynı iki ayarı ortaya koyar:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) çıktıda mürekkep nesnelerinin dahil edilip edilmeyeceğini belirler. Varsayılan değeri `false` tir.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) bir mürekkep fırçası işlenirken maske işleminin opaklık olarak yorumlanıp yorumlanmayacağını belirler. Varsayılan değeri `true`tır; bunun yerine ROP işlemi kullanmak için [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) metodunu `false` ile çağırın.

### **PDF Çıktısında Mürekkep Nesnelerini Gizleme**

Varsayılan olarak, dışa aktarım sırasında mürekkep nesneleri görünür kalır. El yazısı notları veya diğer mürekkep içeriği olmadan temiz bir çıktıyı oluşturmak için [IInkOptions.setHideInk](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) metodunu `true` ile çağırın.

Aşağıdaki Java örneği, tüm mürekkep nesnelerini gizlerken bir sunumu PDF'ye dışa aktarır:

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

Slaytları bitmap görüntüler olarak işlerken mürekkep nesnelerini gizlemek için [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) yapılandırın ve işleme seçeneklerini [ISlide.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) metoduna iletin.

Aşağıdaki Java örneği, ilk slaytı mürekkep nesneleri olmadan PNG görüntüsü olarak işler:

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

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) ayarı, mürekkep fırçaları işlenirken maske işlemlerinin nasıl yorumlandığını denetler. Varsayılan değer `true` olup, opaklık kullanır. Bunun yerine ROP işlemini kullanmak için [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) metodunu `false` ile çağırın.

Aşağıdaki Java örneği bir slaytı SVG'ye dışa aktarır ve mürekkep maske işlemleri için ROP tabanlı işleme kullanır:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

Aynı ayar, bir sunumu dışa aktarırken veya bir slaytı TIFF olarak işlerken [TiffOptions.getInkOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) aracılığıyla uygulanabilir.

### **Mürekkebi Gizleyip Gizlemeyeceğinizi veya Korumayı Seçin**

Dağıtım için revizyon işaretleri olmadan anotasyonlu bir sunumun temiz bir versiyonuna ihtiyacınız olduğunda, dışa aktarım sırasında [IInkOptions.setHideInk](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) metodunu `true` ile çağırın.

Mürekkep anotasyonları, inceleme yorumları, el yazısı notlar, vurgulamalar veya dışa aktarım sonucunda görünür kalması gereken çizimler gibi hedef içeriğin bir parçası olduğunda [IInkOptions.getHideInk](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) değerini varsayılan `false` olarak bırakın. Bu, uygulamaların aynı sunumdan kaynak mürekkep nesnelerini değiştirmeden ayrı inceleme ve son çıktılar üretmesine olanak tanır.

## **SSS**

**Mevcut bir mürekkep çizgisinin rengini veya boyutunu değiştirebilir miyim?**

Evet. İzleri [IInk.getTraces](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iink/#getTraces--) metodundan alın, ardından [IInkTrace.getBrush](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinktrace/#getBrush--) metodunu değiştirin. Fırçayı değiştirmek için [IInkBrush.setColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) veya [IInkBrush.setSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) metodlarını çağırın.

**Mürekkebi gizlemek kaynak sunumu değiştirir mi?**

Hayır. [IInkOptions.setHideInk](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) çağrısı sadece işlenen veya dışa aktarılan sonucu etkiler; kaynak sunumdaki mürekkep nesnelerini kaldırmaz veya değiştirmez.

**Hangi dışa aktarma formatları mürekkep seçeneklerini destekler?**

Yukarıda gösterilen ilgili dışa aktarım veya işleme seçenekleri aracılığıyla PDF, HTML, SVG, TIFF ve bitmap slayt görüntüleri için mürekkep seçeneklerini yapılandırabilirsiniz.

**İleri Okuma**

* Genel olarak şekiller hakkında bilgi almak için [PowerPoint Shapes](https://docs.aspose.com/slides/tr/androidjava/powerpoint-shapes/) bölümüne bakın.
* Etkili değerler hakkında daha fazla bilgi için [Shape Effective Properties](https://docs.aspose.com/slides/tr/androidjava/shape-effective-properties/#get-effective-font-height-value) sayfasına bakın.
* PDF dışa aktarımıyla ilgili ayrıntılar için [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/tr/androidjava/convert-powerpoint-to-pdf/) sayfasına bakın.
* HTML dışa aktarımıyla ilgili ayrıntılar için [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/tr/androidjava/convert-powerpoint-to-html/) sayfasına bakın.
* SVG dışa aktarımıyla ilgili ayrıntılar için [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/tr/androidjava/render-a-slide-as-an-svg-image/) sayfasına bakın.
* TIFF dışa aktarımıyla ilgili ayrıntılar için [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/tr/androidjava/convert-powerpoint-to-tiff/) sayfasına bakın.
* Slaytların görüntüye dönüştürülmesiyle ilgili ayrıntılar için [Convert Presentation Slides to Images](https://docs.aspose.com/slides/tr/androidjava/convert-slide/) sayfasına bakın.