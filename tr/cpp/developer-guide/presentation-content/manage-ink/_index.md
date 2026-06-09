---
title: C++'ta Sunum Mürekkep Nesnelerini Yönet
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/cpp/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin—Aspose.Slides for C++ ile dijital mürekkebi oluşturun, düzenleyin ve biçimlendirin. İzler, fırça rengi ve boyutu için kod örnekleri alın."
---
## **Giriş**

PowerPoint, kaydırma üzerinde standart olmayan şekiller çizebilmenizi sağlayan mürekkep işlevini sunar; bu işlev, diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve slayttaki belirli öğelere dikkat çekmek için kullanılabilir.

Aspose.Slides, mürekkep nesnelerini oluşturmak ve yönetmek için gereken türleri içeren [Aspose.Slides.Ink](https://reference.aspose.com/slides/tr/cpp/aspose.slides.ink/) arayüzünü sağlar.

## **Düzenli Nesneler ve Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler genellikle şekil nesneleriyle temsil edilir. Bir şekil nesnesi, en basit haliyle, nesnenin kendisinin (çerçevesinin) alanını ve özelliklerini tanımlayan bir kapsayıcıdır. Bu özellikler, kapsayıcı alanın boyutu, kapsayıcının şekli, kapsayıcının arka planı vb. içerir. Daha fazla bilgi için [Shape Layout Format](https://docs.aspose.com/slides/tr/cpp/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Ancak PowerPoint bir mürekkep nesnesiyle uğraşırken, çerçeve (kapsayıcı) özelliklerinin tümünü, yalnızca boyutunu hariç tutarak görmez. Kapsayıcı alanın boyutu standart `width` ve `height` değerleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape İzleri**

İz, bir kullanıcının dijital mürekkep yazarak kalem hareketini kaydetmek için kullanılan temel bir öğe veya standarttır. İzler, birbirine bağlı noktaların sırasını tanımlayan kayıtlardır.

Kodlamanın en basit biçimi, her örnek noktasının X ve Y koordinatlarını belirtir. Tüm bağlanmış noktalar işlendiğinde, aşağıdaki gibi bir görüntü ortaya çıkar:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Bir fırça kullanarak iz öğelerinin noktalarını birbirine bağlayan çizgiler çizebilirsiniz. Fırçanın `Brush.Color` ve `Brush.Size` özelliklerine karşılık gelen kendi rengi ve boyutu vardır.

### **Mürekkep Fırça Rengini Ayarlama**

Bu C++ kodu, bir fırçanın rengini nasıl ayarlayacağınızı gösterir:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Mürekkep Fırça Boyutunu Ayarlama**

Bu C++ kodu, bir fırçanın boyutunu nasıl ayarlayacağınızı gösterir:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

Genel olarak, bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (veri bölümü gri tonludur). Ancak fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutunu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık olması için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları inceleyelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu dikkate almaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (son görsele bakın).

Bu nedenle, tüm mürekkep nesnesinin görünür alanını belirlemek için iz nesnelerinin fırça boyutunu dikkate almalıyız. Burada hedef nesne (el yazısı metin iz nesnesi), kapsayıcı (çerçeve) boyutuna ölçeklenmiştir. Kapsayıcının (çerçevenin) boyutu değiştiğinde, fırça boyutu sabit kalır ve tersine de aynı durum geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metinlerle çalışırken aynı davranışı gösterir:

![ink_powerpoint6](ink_powerpoint6.png)

**Daha fazla okuma**

* Şekiller hakkında genel bilgi için, [PowerPoint Shapes](https://docs.aspose.com/slides/tr/cpp/powerpoint-shapes/) bölümüne bakın.
* Etkin değerler hakkında daha fazla bilgi için, [Shape Effective Properties](https://docs.aspose.com/slides/tr/cpp/shape-effective-properties/#get-effective-font-height-value) bölümüne bakın.