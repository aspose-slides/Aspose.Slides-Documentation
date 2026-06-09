---
title: C++'ta Animasyonlarla PowerPoint Sunumlarını Geliştirin
linktitle: PowerPoint Animasyonu
type: docs
weight: 150
url: /tr/cpp/powerpoint-animation/
keywords:
- animasyon ekle
- animasyonu güncelle
- animasyonu değiştir
- animasyonu kaldır
- animasyonu yönet
- animasyonu kontrol et
- animasyon efekti
- PowerPoint animasyonu
- animasyon zaman çizelgesi
- etkileşimli animasyon
- özel animasyon
- şekil animasyonu
- animasyonlu grafik
- animasyonlu metin
- animasyonlu şekil
- animasyonlu OLE nesnesi
- animasyonlu resim
- animasyonlu tablo
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta gelişmiş animasyon efektlerini eklemeyi ve kontrol etmeyi öğrenerek dinamik PowerPoint ve OpenDocument sunumları oluşturun."
---
## **Giriş**

Sunumların bir şeyi sunmak için tasarlandığını göz önünde bulundurarak, görsel görünümleri ve etkileşimli davranışları her zaman oluşturulurken dikkate alınır.

**PowerPoint animasyonu**, sunumu izleyiciler için göz alıcı ve çekici kılmak amacıyla önemli bir rol oynar. Aspose.Slides for C++ , PowerPoint sunumuna animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- Şekiller, grafikler, tablolar, OLE Nesneleri ve diğer sunum öğeleri üzerinde çeşitli PowerPoint animasyon efekti türlerini uygular.
- Bir şekil üzerinde birden fazla PowerPoint animasyon efekti kullanır.
- Animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullanır.
- Özel animasyon oluşturur.

Aspose.Slides for C++'ta, şekiller üzerinde çeşitli animasyon efektleri uygulanabilir. Metin, resimler, OLE Nesnesi, tablo vb. dahil slayttaki her öğe bir şekil olarak değerlendirildiği için, bir slaydın her öğesine animasyon efekti uygulayabiliriz.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation) **ad alanı**, PowerPoint animasyonlarıyla çalışmak için sınıflar sağlar.

## **Animasyon Efektleri**
Aspose.Slides, **150+ animasyon efekti** destekler; Bounce, PathFootball, Zoom etkisi gibi temel animasyon efektlerinin yanı sıra OLEObjectShow, OLEObjectOpen gibi özel animasyon efektleri de bulunur. Animasyon efektlerinin tam listesini [**EffectType**](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) adlı enum’da bulabilirsiniz.

Ayrıca, bu animasyon efektleri aşağıdaki öğelerle birleştirilerek kullanılabilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.set_effect)

## **Özel Animasyon**
Aspose.Slides içinde kendi **özel animasyonlarınızı** oluşturmak mümkündür. Bunu, birkaç davranışı bir araya getirerek yeni bir özel animasyon oluşturduğunuzda elde edebilirsiniz.

[**Behavior**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.behavior) herhangi bir PowerPoint animasyon efektinin yapı taşıdır. Tüm animasyon efektleri aslında tek bir strateji içinde birleştirilen bir dizi davranıştan oluşur. Davranışları bir kez birleştirerek özel bir animasyon oluşturabilir ve bunu diğer sunumlarda yeniden kullanabilirsiniz. Standart bir PowerPoint animasyon efektine yeni bir davranış eklediğinizde – bu başka bir özel animasyon olur. Örneğin, bir animasyona tekrarlama davranışı ekleyerek animasyonun birkaç kez tekrarlanmasını sağlayabilirsiniz.

[**Animation Point**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.point) davranışın uygulanması gereken bir noktadır.

## **Animasyon Zaman Çizelgesi**
[**Sequence**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.sequence) belirli bir şekle uygulanan animasyon efektlerinin bir koleksiyonudur.

[**AnimationTimeLine**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.animation_time_line) belirli bir slaytta kullanılan bir dizi Sequence’tir. PowerPoint 2002’den itibaren bir animasyon motoru olarak temsil edilmiştir. Önceki PowerPoint sürümlerinde, sunuma animasyon efekti eklemek zordu ve yalnızca çeşitli geçici çözümlerle mümkün oluyordu. Timeline, eski AnimationSettings sınıfının yerini alarak PowerPoint animasyonu için daha net bir nesne modeli sunar. Bir slayt yalnızca bir animasyon zaman çizelgesine sahip olabilir.

## **Etkileşimli Animasyon**
[**EffectTriggerType**](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) belirli bir animasyonun başlamasını sağlayacak kullanıcı eylemlerini (ör. düğme tıklaması) tanımlamaya olanak tanır. Tetikleyiciler yalnızca en yeni PowerPoint sürümüne eklenmiştir.

## **Şekil Animasyonu**
Aspose.Slides, gerçekte metin, dikdörtgen, çizgi, çerçeve, OLE Nesnesi vb. olabilen şekillere animasyon uygulamayı sağlar.

{{% alert color="primary" %}} 
Daha fazla oku [**Şekil Animasyonu Hakkında**](/slides/tr/cpp/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**
Animasyonlu grafikler oluşturmak için şekillerde kullanılan aynı sınıfları kullanmalısınız. Ancak, PowerPoint animasyonu yalnızca grafik kategorileri veya grafik serileri üzerinde kullanılabilir. Bir kategori öğesine veya seri öğesine de animasyon efekti uygulayabilirsiniz.

{{% alert color="primary" %}} 
Daha fazla oku [**Animasyonlu Grafikler Hakkında**](/slides/tr/cpp/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**
Animasyonlu metnin yanı sıra bir paragrafta da animasyon uygulamak mümkündür.

{{% alert color="primary" %}} 
Daha fazla oku [**Animasyonlu Metin Hakkında**](/slides/tr/cpp/animated-text/).
{{% /alert %}}

## **SSS**

**PDF'ye dışa aktarıldığında animasyonlar korunacak mı?**

Hayır. PDF statik bir formattır, bu yüzden animasyonlar ve [slayt geçişleri](/slides/tr/cpp/slide-transition/) oynatılmaz. Hareket gerektiğinde, bunun yerine [HTML5](/slides/tr/cpp/export-to-html5/), [animasyonlu GIF](/slides/tr/cpp/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/cpp/convert-powerpoint-to-video/) formatına dışa aktarabilirsiniz.

**Animasyonlu bir sunumu video haline getirip kare hızı ve kare boyutunu kontrol edebilir miyim?**

Evet. Sunumu [çerçeveler olarak işleyebilir](/slides/tr/cpp/convert-powerpoint-to-video/) ve bunları bir video dosyasına (ör. ffmpeg ile) kodlayabilirsiniz; FPS ve çözünürlüğü seçebilirsiniz. Animasyonlar ve slayt geçişleri işleme sırasında oynatılır.

**ODP (sadece PPTX değil) ile çalışırken animasyonlar aynı kalacak mı?**

PPT, PPTX ve ODP, [okuma](/slides/tr/cpp/open-presentation/) ve [yazma](/slides/tr/cpp/save-presentation/) için desteklenir, ancak format farklılıkları bazı efektlerin biraz farklı görünmesine veya davranmasına neden olabilir. Kritik durumları gerçek örneklerle doğrulayın.