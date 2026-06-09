---
title: PHP'de Sunum Mürekkep Nesnelerini Yönet
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/php-java/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin — Aspose.Slides for PHP via Java ile dijital mürekkebi oluşturun, düzenleyin ve biçimlendirin. İzler, fırça rengi ve boyutu için kod örnekleri alın."
---
## **Giriş**

PowerPoint, standart olmayan şekilleri çizebilmenizi sağlayan bir kalem işlevi sunar; bu işlev, diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve bir slayttaki belirli öğelere dikkat çekmek için kullanılabilir.  

Aspose.Slides, mürekkep nesnelerini oluşturmak ve yönetmek için ihtiyacınız olan tüm Ink türlerini (ör. [Ink](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ink/) sınıfı) sağlar.

## **Normal Nesneler ile Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler tipik olarak şekil (shape) nesneleriyle temsil edilir. En basit haliyle bir şekil nesnesi, nesnenin kendisinin alanını (çerçevesini) ve özelliklerini tanımlayan bir kapsayıcıdır. Bu özellikler, kapsayıcı alanın boyutu, kapsayıcının şekli, arka planı vb. içerir. Ayrıntılı bilgi için [Shape Layout Format](https://docs.aspose.com/slides/tr/php-java/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Bununla birlikte, PowerPoint bir mürekkep nesnesiyle çalışırken, çerçeve (kapsayıcı) özelliklerinin tümünü, yalnızca boyutunu hariç tutarak yok sayar. Kapsayıcı alanın boyutu, standart `width` ve `height` değerleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape İzleri**

İz, bir kullanıcının dijital mürekkep yazarken kalemin izlediği yolu kaydetmek için kullanılan temel bir öğe veya standarttır. İzler, birbirine bağlanmış noktaların dizilerini tanımlayan kayıtlardır.  

Kodlamanın en basit şekli, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlanmış noktalar çizildiğinde aşağıdaki gibi bir görüntü ortaya çıkar:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

İz öğelerinin noktalarını birleştiren çizgileri çizmek için bir fırça kullanabilirsiniz. Fırçanın kendi rengi ve boyutu vardır; bu, `Brush.Color` ve `Brush.Size` özelliklerine karşılık gelir.  

### **Ink Fırça Rengini Ayarlama**

Bu PHP kodu, bir fırçanın rengini nasıl ayarlayacağınızı gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ink Fırça Boyutunu Ayarlama**

Bu PHP kodu, bir fırçanın boyutunu nasıl ayarlayacağınızı gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Genel olarak, bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (veri bölümü gri tonludur). Ancak, fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık getirmek için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları inceleyelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu dikkate almaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (son görsele bakın).  

Bu nedenle, tüm mürekkep nesnesinin görünen alanını belirlemek için iz nesnelerinin fırça boyutunu göz önünde bulundurmamız gerekir. Burada hedef nesne (el yazısı iz nesnesi), kapsayıcı (çerçeve) boyutuna göre ölçeklendirilmiştir. Kapsayıcı (çerçeve) boyutu değiştiğinde fırça boyutu sabit kalır ve tersine de aynı durum geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metinlerle çalışırken aynı davranışı sergiler:

![ink_powerpoint6](ink_powerpoint6.png)

**İlave Okuma**

* Şekiller hakkında genel bilgi için [PowerPoint Shapes](https://docs.aspose.com/slides/tr/php-java/powerpoint-shapes/) bölümüne bakın.  
* Etkin değerler hakkında daha fazla bilgi için [Shape Effective Properties](https://docs.aspose.com/slides/tr/php-java/shape-effective-properties/#getting-effective-font-height-value) bölümünü inceleyin.