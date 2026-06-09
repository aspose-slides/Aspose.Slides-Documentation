---
title: Sunum Mürekkep Nesnelerini JavaScript ile Yönet
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/nodejs-java/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin—Aspose.Slides for Node.js ile dijital mürekkebi oluşturun, düzenleyin ve biçimlendirin. İzler, fırça rengi ve boyutu için JavaScript kod örnekleri alın."
---
## **Giriş**

PowerPoint, kaydırıcı üzerindeki diğer nesneleri vurgulamak, bağlamaları ve süreçleri göstermek ve slaytta belirli öğelere dikkat çekmek için standart olmayan şekiller çizebilmenizi sağlayan mürekkep işlevini sunar.  

Aspose.Slides, mürekkep nesneleri oluşturmak ve yönetmek için ihtiyaç duyduğunuz tüm Ink türlerini (ör. [Ink](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ink/) sınıfı) sağlar.

## **Normal Nesne ve Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler genellikle şekil nesneleriyle temsil edilir. Bir şekil nesnesi, en basit haliyle, nesnenin kendisinin (çerçevesinin) alanını ve özelliklerini tanımlayan bir kapsayıcıdır. Bu, kapsayıcı alanın boyutu, kapsayıcının şekli, kapsayıcının arka planı vb. içerir. Daha fazla bilgi için [Shape Layout Format](https://docs.aspose.com/slides/tr/nodejs-java/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.  

Ancak PowerPoint bir mürekkep nesnesiyle çalışırken, nesnenin çerçevesinin (kapsayıcının) boyut haricindeki tüm özelliklerini yok sayar. Kapsayıcı alanın boyutu standart `width` ve `height` değerleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep Şekil İzleri**

İz, bir kullanıcının dijital mürekkep yazarken kalemin izlediği yolu kaydetmek için kullanılan temel bir öğe veya standarttır. İzler, birbirine bağlı noktaların sırasını tanımlayan kayıtlardır.  

Kodlamanın en basit biçimi, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlanmış noktalar render edildiğinde, aşağıdaki gibi bir görüntü ortaya çıkar:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

İz öğelerinin noktalarını birleştiren çizgiler çizmek için bir fırça kullanabilirsiniz. Fırçanın kendi rengi ve boyutu vardır; bu, `Brush.setColor` ve `Brush.setSize` yöntemlerine karşılık gelir.  

### **Mürekkep Fırçası Rengini Ayarla**

Bu JavaScript kodu, bir fırçanın rengini nasıl ayarlayacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Mürekkep Fırçası Boyutunu Ayarla**

Bu JavaScript kodu, bir fırçanın boyutunu nasıl ayarlayacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Genel olarak, bir fırçanın genişliği ve yüksekliği eşleşmez, bu nedenle PowerPoint fırça boyutunu göstermez (veri bölümü gri tonludur). Ancak fırçanın genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutunu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık getirmek için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları gözden geçirelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu dikkate almaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (son resme bakın).  

Bu nedenle, tüm mürekkep nesnesinin görünür alanını belirlemek için iz nesnelerinin fırça boyutunu göz önünde bulundurmamız gerekir. Burada hedef nesne (el yazısı metin iz nesnesi), kapsayıcının (çerçevenin) boyutuna göre ölçeklenmiştir. Kapsayıcı (çerçeve) boyutu değiştiğinde fırça boyutu sabit kalır ve tersine de aynı durum geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metinlerle çalışırken aynı davranışı gösterir:

![ink_powerpoint6](ink_powerpoint6.png)

**Daha fazla okuma**

* Şekiller hakkında genel bilgi için [PowerPoint Shapes](https://docs.aspose.com/slides/tr/nodejs-java/powerpoint-shapes/) bölümüne bakın.  
* Etkili değerler hakkında daha fazla bilgi için [Shape Effective Properties](https://docs.aspose.com/slides/tr/nodejs-java/shape-effective-properties/#getting-effective-font-height-value) sayfasına bakın.