---
title: Android'de Sunum Mürekkep Nesnelerini Yönet
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
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin - Aspose.Slides for Android ile dijital mürekkebi oluşturun, düzenleyin ve biçimlendirin. İzler, fırça rengi ve boyutu için Java kod örnekleri alın."
---
## **Giriş**

PowerPoint, slayt üzerindeki diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve belirli öğelere dikkat çekmek için kullanılabilen standart dışı şekiller çizebilmenizi sağlayan bir mürekkep işlevi sunar.  

Aspose.Slides, mürekkep nesnelerini oluşturmak ve yönetmek için ihtiyacınız olan tüm Ink türlerini (ör. [Ink](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ink/) sınıfı) sağlar.

## **Düzenli Nesneler ile Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler genellikle şekil nesneleriyle temsil edilir. En basit biçimde bir şekil nesnesi, nesnenin alanını (çerçevesini) ve özelliklerini tanımlayan bir kapsayıcıdır. İkincisi, kapsayıcı alan boyutu, kapsayıcının şekli, arka planı vb. içerir. Daha fazla bilgi için [Shape Layout Format](https://docs.aspose.com/slides/tr/androidjava/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Bununla birlikte, PowerPoint bir mürekkep nesnesiyle çalışırken, kapsayıcının (çerçevenin) tüm özelliklerini, yalnızca boyutunu hariç tutarak yok sayar. Kapsayıcı alanın boyutu, standart `width` ve `height` değerleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep Şekli İzleri**

İz, bir kullanıcının dijital mürekkep yazarken kalemin izini kaydetmek için kullanılan temel bir öğe veya standarttır. İzler, bağlanmış noktaların sıralarını tanımlayan kayıtlardır.  

Kodlamanın en basit biçimi, her örnek noktasının X ve Y koordinatlarını belirtir. Tüm bağlantılı noktalar oluşturulduğunda, aşağıdaki gibi bir görüntü ortaya çıkar:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

İz öğelerinin noktalarını birleştiren çizgiler çizmek için bir fırça kullanabilirsiniz. Fırçanın kendine özgü bir rengi ve boyutu vardır; bu, `Brush.Color` ve `Brush.Size` özelliklerine karşılık gelir.  

### **Mürekkep Fırçası Rengini Ayarlama**

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

### **Mürekkep Fırçası Boyutunu Ayarlama**

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

Genel olarak, bir fırçanın genişliği ve yüksekliği eşleşmez, bu nedenle PowerPoint fırça boyutunu göstermez (veri bölümü gri tonludur). Ancak fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutunu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık getirmek için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları gözden geçirelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu dikkate almaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (son görüntüye bakın).  

Bu nedenle, tüm mürekkep nesnesinin görünen alanını belirlemek için iz nesnelerinin fırça boyutunu göz önünde bulundurmalıyız. Burada hedef nesne (el yazısı metin iz nesnesi), kapsayıcı (çerçeve) boyutuna göre ölçeklendirilmiştir. Kapsayıcının (çerçevenin) boyutu değiştiğinde, fırça boyutu sabit kalır ve tersine de aynı şey geçerlidir:

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metinlerle çalışırken aynı davranışı gösterir:

![ink_powerpoint6](ink_powerpoint6.png)

**Daha fazla okuma**

* Şekiller hakkında genel bilgi için, [PowerPoint Shapes](https://docs.aspose.com/slides/tr/androidjava/powerpoint-shapes/) bölümüne bakın.
* Etkin değerler hakkında daha fazla bilgi için, [Shape Effective Properties](https://docs.aspose.com/slides/tr/androidjava/shape-effective-properties/#getting-effective-font-height-value) bölümüne bakın.