---
title: Python ile Sunumlarda Mürekkep Nesnelerini Yönetin
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
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin—Aspose.Slides for Python via .NET ile dijital mürekkebi oluşturun, düzenleyin ve biçimlendirin. İzler, fırça rengi ve boyutu için kod örneklerini alın."
---
## **Giriş**

PowerPoint, standart dışı şekiller çizebilmenizi sağlayan mürekkep işlevi sunar; bu işlev diğer nesneleri vurgulamak, bağlantı ve süreçleri göstermek ve bir slayttaki belirli öğelere dikkat çekmek için kullanılabilir. 

Aspose.Slides, mürekkep nesnelerini oluşturmak ve yönetmek için gerekli türleri içeren [aspose.slides.ink](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ink/) ad alanını sağlar. 

## **Düzenli Nesne ve Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaydındaki nesneler tipik olarak şekil nesneleriyle temsil edilir. En basit biçimde bir şekil nesnesi, nesnenin kendisinin (çerçevesinin) alanını ve özelliklerini tanımlayan bir kapsayıcıdır. İkincisi, kapsayıcı alanının boyutu, kapsayıcının şekli, arka planı vb. içerir. Bilgi için [Şekil Düzeni Biçimi](https://docs.aspose.com/slides/tr/python-net/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Bununla birlikte, PowerPoint bir mürekkep nesnesiyle çalışırken, çerçeve (kapsayıcı) özelliklerinin tümünü, yalnızca boyutunu hariç tutarak görmezden gelir. Kapsayıcı alanının boyutu standart `width` ve `height` değerleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep Şekli İzleri**

İz, bir kullanıcının dijital mürekkep ile yazarken kalemin izlediği yolu kaydetmek için kullanılan temel bir öğe veya standarttır. İzler, birbirine bağlı noktaların sıralarını tanımlayan kayıtlardır. 

Kodlamanın en basit biçimi, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlanan noktalar render edildiğinde aşağıdaki gibi bir görüntü oluşur:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Bir fırça kullanarak iz öğelerinin noktalarını birleştiren çizgiler çizebilirsiniz. Fırçanın kendi rengi ve boyutu vardır; bunlar `Brush.color` ve `Brush.size` özelliklerine karşılık gelir. 

### **Mürekkep Fırça Rengini Ayarla**

Bu Python kodu, bir fırçanın rengini nasıl ayarlayacağınızı gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Mürekkep Fırça Boyutunu Ayarla** 

Bu Python kodu, bir fırçanın boyutunu nasıl ayarlayacağınızı gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

Genel olarak, bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (veri bölümü gri olur). Ancak, fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık getirmek için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları gözden geçirelim: 

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve) fırçaların boyutunu dikkate almaz—çizgi kalınlığının sıfır olduğunu her zaman varsayar (son resme bakın). 

Bu nedenle, tüm mürekkep nesnesinin görünen alanını belirlemek için iz nesnelerinin fırça boyutunu göz önünde bulundurmalıyız. Burada, hedef nesne (el yazısı iz nesnesi) kapsayıcı (çerçeve) boyutuna ölçeklendirilmiştir. Kapsayıcının (çerçevenin) boyutu değiştiğinde, fırça boyutu sabit kalır ve tersine de geçerlidir. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metinlerle çalışırken aynı davranışı sergiler:

![ink_powerpoint6](ink_powerpoint6.png)

**İlave Okuma**

* Şekiller hakkında genel bilgi için, [PowerPoint Shapes](https://docs.aspose.com/slides/tr/python-net/powerpoint-shapes/) bölümüne bakın. 
* Etkin değerler hakkında daha fazla bilgi için, [Shape Effective Properties](https://docs.aspose.com/slides/tr/python-net/shape-effective-properties/#get-effective-font-height-value) bölümünü inceleyin.