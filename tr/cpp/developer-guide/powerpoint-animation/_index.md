---
title: "C++'da Animasyonlarla PowerPoint Sunumlarını Geliştirin"
linktitle: "PowerPoint Animasyonu"
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
description: "Aspose.Slides for C++'da gelişmiş animasyon efektlerini eklemeyi ve kontrol etmeyi öğrenerek dinamik PowerPoint ve OpenDocument sunumları oluşturun."
---
## **Giriş**

Sunumlar bir şeyi sunmak amacıyla yapıldığından, oluşturulurken görsel görünümleri ve etkileşimli davranışları her zaman göz önünde bulundurulur.

**PowerPoint animasyonu** izleyiciler için sunumu göz alıcı ve çekici kılmak amacıyla önemli bir rol oynar. Aspose.Slides for C++ PowerPoint sunumuna animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- şekiller, grafikler, tablolar, OLE Nesneleri ve diğer sunum öğeleri üzerinde çeşitli PowerPoint animasyon efekti türlerini uygulayın.
- bir şekil üzerinde birden fazla PowerPoint animasyon efekti kullanın.
- animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullanın.
- özel animasyon oluşturun.

Aspose.Slides for C++'de çeşitli animasyon efektleri şekillere uygulanabilir. Metin, resimler, OLE Nesnesi, tablo vb. dahil slayttaki her öğe bir şekil olarak kabul edildiğinden, bir slaydın her öğesine animasyon efekti uygulanabilir.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation) **ad alanı**, PowerPoint animasyonlarıyla çalışmak için sınıflar sağlar.
## **Animasyon Efektleri**
Aspose.Slides **150+ animasyon efekti** destekler; Bounce, PathFootball, Zoom etkisi gibi temel animasyon efektleri ve OLEObjectShow, OLEObjectOpen gibi belirli animasyon efektlerini içerir. Tüm animasyon efektlerinin tam listesini [**EffectType**](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31)enumeration içinde bulabilirsiniz.

Ayrıca, bu animasyon efektleri onlarla birlikte kullanılabilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.set_effect)

## **Özel Animasyon**
Aspose.Slides içinde kendi **özel animasyonlarınızı** oluşturmak mümkündür. Bu, birkaç davranışı bir araya getirerek yeni bir özel animasyon oluşturduğunuzda elde edilebilir.

[**Behavior**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.behavior) herhangi bir PowerPoint animasyon efektinin yapı birimidir. Tüm animasyon efektleri aslında bir strateji içinde birleştirilen bir dizi davranıştır. Davranışları bir kez özel bir animasyona birleştirip diğer sunumlarda yeniden kullanabilirsiniz. Standart bir PowerPoint animasyon efektine yeni bir davranış eklediğinizde – bu başka bir özel animasyon olur. Örneğin, bir animasyona tekrarlama davranışı ekleyerek birkaç kez tekrarlanmasını sağlayabilirsiniz.

[**Animation Point**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.point) davranışın uygulanması gereken bir noktadır.

## **Animasyon Zaman Çizelgesi**
[**Sequence**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.sequence) belirli bir şekle uygulanan animasyon efektlerinin bir koleksiyonudur.

[**AnimationTimeLine**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.animation_time_line) belirli bir slaytta kullanılan bir dizi Sequence'ten oluşur. PowerPoint 2002'den beri bir animasyon motoru olarak temsil edilmektedir. Önceki PowerPoint sürümlerinde, sunuma animasyon efekti eklemek zordu ve yalnızca çeşitli geçici çözümlerle mümkün oluyordu. Zaman çizelgesi, eski AnimationSettings sınıfının yerini alır ve PowerPoint animasyonu için daha net bir nesne modeli sağlar. Bir slaytta yalnızca bir animasyon zaman çizelgesi bulunabilir.

## **Etkileşimli Animasyon**
[**EffectTriggerType**](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) belirli bir animasyonun başlamasını sağlayacak kullanıcı eylemlerini (ör. düğme tıklaması) tanımlamaya izin verir. Tetikleyiciler yalnızca en son PowerPoint sürümüne eklenmiştir.

## **Şekil Animasyonu**
Aspose.Slides, metin, dikdörtgen, çizgi, çerçeve, OLE Nesnesi vb. gibi şekillere animasyon uygulamaya olanak tanır.

{{% alert color="info" %}} 
Daha fazla bilgi [**Şekil Animasyonu Hakkında**](/slides/tr/cpp/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**
Animasyonlu grafikler oluşturmak için şekillerde kullanılan aynı sınıfları kullanmalısınız. Ancak PowerPoint animasyonu yalnızca grafik kategorileri veya grafik serileri üzerinde kullanılabilir. Ayrıca bir kategori öğesine veya seri öğesine de animasyon efekti uygulayabilirsiniz.

{{% alert color="info" %}} 
Daha fazla bilgi [**Animasyonlu Grafikler Hakkında**](/slides/tr/cpp/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**
Animasyonlu metin dışında, bir paragraf üzerine de animasyon uygulamak mümkündür.

{{% alert color="info" %}} 
Daha fazla bilgi [**Animasyonlu Metin Hakkında**](/slides/tr/cpp/animated-text/).
{{% /alert %}}

## **SSS**

### PDF'ye dışa aktarırken animasyonlar korunur mu?

Hayır. PDF statik bir formattır, bu nedenle animasyonlar ve [slayt geçişleri](/slides/tr/cpp/slide-transition/) oynatılmaz. Hareket gerekiyorsa, bunun yerine [HTML5](/slides/tr/cpp/export-to-html5/), [animasyonlu GIF](/slides/tr/cpp/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/cpp/convert-powerpoint-to-video/) formatına dışa aktarın.

### Animasyonlu bir sunumu video haline getirip kare hızı ve kare boyutunu kontrol edebilir miyim?

Evet. Sunumu [kareler olarak render edebilir](/slides/tr/cpp/convert-powerpoint-to-video/) ve bunları bir video olarak kodlayabilirsiniz (ör. ffmpeg ile), FPS ve çözünürlüğü seçerek. Animasyonlar ve slayt geçişleri render sırasında oynatılır.

### ODP (sadece PPTX değil) ile çalışırken animasyonlar aynı kalır mı?

PPT, PPTX ve ODP, [okuma](/slides/tr/cpp/open-presentation/) ve [yazma](/slides/tr/cpp/save-presentation/) için desteklenir, ancak format farklılıkları bazı efektlerin biraz farklı görünmesine veya davranmasına neden olabilir. Kritik durumları gerçek örneklerle doğrulayın.