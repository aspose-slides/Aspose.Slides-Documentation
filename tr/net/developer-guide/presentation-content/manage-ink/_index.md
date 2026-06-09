---
title: .NET'te Sunum Mürekkep Nesnelerini Yönet
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/net/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin—Aspose.Slides for .NET ile dijital mürekkebi oluşturun, düzenleyin ve stillendirin. İzler, fırça rengi ve boyutu için kod örnekleri alın."
---
## **Giriş**

PowerPoint, standart dışı şekiller çizebilmenizi sağlayan mürekkep işlevi sunar; bu işlev, diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve bir slayttaki belirli öğelere dikkat çekmek için kullanılabilir. 

Aspose.Slides, mürekkep nesnelerini oluşturmak ve yönetmek için ihtiyaç duyduğunuz türleri içeren [Aspose.Slides.Ink](https://reference.aspose.com/slides/tr/net/aspose.slides.ink/) arabirimini sağlar. 

## **Düzenli Nesneler ve Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler genellikle şekil nesneleriyle temsil edilir. En basit formda bir şekil nesnesi, nesnenin kendisinin alanını (çerçevesini) ve özelliklerini tanımlayan bir kapsayıcıdır. Bu özellikler arasında kapsayıcı alanın boyutu, kapsayıcının şekli, kapsayıcının arka planı vb. bulunur. Daha fazla bilgi için [Şekil Düzeni Biçimi](https://docs.aspose.com/slides/tr/net/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Ancak PowerPoint bir mürekkep nesnesiyle çalışırken, nesne çerçevesinin (kapsayıcının) tüm özelliklerini, yalnızca boyutunu hariç tutar. Kapsayıcı alanın boyutu standart `width` ve `height` değerleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep Şekil İzleri**

İz, bir kullanıcının dijital mürekkep yazması sırasında kalemin izini kaydetmek için kullanılan temel bir öğe veya standarttır. İzler, birbirine bağlanan nokta dizilerini tanımlayan kayıtlardır. 

Kodlamanın en basit biçimi, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlanan noktalar çizildiğinde aşağıdaki gibi bir görüntü oluşur:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Bir fırça, iz öğelerinin noktalarını birleştiren çizgileri çizmek için kullanılabilir. Fırçanın kendi rengi ve boyutu vardır; bunlar `Brush.Color` ve `Brush.Size` özelliklerine karşılık gelir. 

### **Mürekkep Fırçası Rengini Ayarla**

Bu C# kodu, bir fırçanın renginin nasıl ayarlanacağını gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **Mürekkep Fırçası Boyutunu Ayarla** 

Bu C# kodu, bir fırçanın boyutunun nasıl ayarlanacağını gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

Genel olarak, bir fırçanın genişliği ve yüksekliği aynı olmayabilir; bu nedenle PowerPoint fırça boyutunu göstermez (veri bölümü gri tonludur). Ancak fırça genişliği ve yüksekliği aynı olduğunda, PowerPoint boyutu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık kazandırmak için mürekkep nesnesinin yüksekliğini artırıp önemli boyutları inceleyelim: 

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırça boyutlarını dikkate almaz—çizgi kalınlığını her zaman sıfır olarak varsayar (son resme bakın). 

Bu nedenle, tüm mürekkep nesnesinin görünen alanını belirlemek için iz nesnelerinin fırça boyutunu göz önünde bulundurmalıyız. Burada hedef nesne (el yazısı iz nesnesi), kapsayıcı (çerçeve) boyutuna göre ölçeklendirilmiştir. Kapsayıcı (çerçeve) boyutu değiştiğinde fırça boyutu sabit kalır ve tersine de geçerlidir. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metinlerle çalışırken aynı davranışı gösterir:

![ink_powerpoint6](ink_powerpoint6.png)

**Daha Fazla Okuma**

* Şekiller hakkında genel bilgi için [PowerPoint Şekilleri](https://docs.aspose.com/slides/tr/net/powerpoint-shapes/) bölümüne bakın. 
* Etkin değerler hakkında daha fazla bilgi için [Şekil Etkin Özellikleri](https://docs.aspose.com/slides/tr/net/shape-effective-properties/#get-effective-font-height-value) bölümünü inceleyin.