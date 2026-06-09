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
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin—Aspose.Slides for Java ile dijital mürekkebi oluşturun, düzenleyin ve stil verin. İzler, fırça rengi ve boyutu için kod örnekleri alın."
---
## **Giriş**

PowerPoint, standart dışı şekiller çizebilmenizi sağlayan mürekkep işlevi sunar; bu işlev diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve slayttaki belirli öğelere dikkat çekmek için kullanılabilir. 

Aspose.Slides, mürekkep nesneleri oluşturmak ve yönetmek için ihtiyaç duyduğunuz tüm Ink türlerini (ör. [Ink](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ink/) sınıfı) sağlar. 

## **Düzenli Nesneler ve Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler genellikle şekil nesneleriyle temsil edilir. Bir şekil nesnesi, en basit haliyle, nesnenin kendisinin (çerçevesinin) alanını ve özelliklerini tanımlayan bir kapsayıcıdır. İkinci kısım, kapsayıcı alanının boyutu, kapsayıcının şekli, arka planı vb. özellikleri içerir. Bilgi için, [Shape Layout Format](https://docs.aspose.com/slides/tr/java/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Ancak PowerPoint bir mürekkep nesnesiyle çalışırken, nesne çerçevesinin (kapsayıcının) tüm özelliklerini, yalnızca boyutunu hariç tutar. Kapsayıcı alanının boyutu standart `width` ve `height` değerleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape İzleri**

İz, bir kalemin dijital mürekkep üzerinde yazma sırasında izlediği yolu kaydetmek için kullanılan temel bir öğe veya standarttır. İzler, birbirine bağlı noktaların dizilerini tanımlayan kayıtlardır. 

Kodlamanın en basit biçimi, her örnek noktasının X ve Y koordinatlarını belirtir. Tüm bağlı noktalar render edildiğinde şu şekilde bir görüntü oluşur:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim için Fırça Özellikleri**

İz öğelerinin noktalarını birleştiren çizgiler çizmek için bir fırça kullanabilirsiniz. Fırçanın kendi rengi ve boyutu vardır; bu `Brush.Color` ve `Brush.Size` özelliklerine karşılık gelir. 

### **Mürekkep Fırçası Rengini Ayarla**

Bu Java kodu, bir fırçanın rengini nasıl ayarlayacağınızı gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Mürekkep Fırçası Boyutunu Ayarla** 

Bu Java kodu, bir fırçanın boyutunu nasıl ayarlayacağınızı gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

Genel olarak, bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (veri bölümü gri renktedir). Ancak fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutunu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık getirmek için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları inceleyelim: 

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu dikkate almaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (son görüntüye bakın). 

Bu nedenle, bütün mürekkep nesnesinin görünür alanını belirlemek için iz nesnelerinin fırça boyutunu göz önünde bulundurmalıyız. Burada hedef nesne (el yazısı metin iz nesnesi), kapsayıcı (çerçeve) boyutuna ölçeklendirilmiştir. Kapsayıcı (çerçeve) boyutu değiştiğinde, fırça boyutu sabit kalır ve tersine de aynı şey geçerlidir. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metinlerle çalışırken de aynı davranışı gösterir:

![ink_powerpoint6](ink_powerpoint6.png)

**Daha fazla okuma**

* Genel olarak şekiller hakkında bilgi edinmek için [PowerPoint Shapes](https://docs.aspose.com/slides/tr/java/powerpoint-shapes/) bölümüne bakın. 
* Etkili değerler hakkında daha fazla bilgi için [Shape Effective Properties](https://docs.aspose.com/slides/tr/java/shape-effective-properties/#getting-effective-font-height-value) bölümüne bakın.