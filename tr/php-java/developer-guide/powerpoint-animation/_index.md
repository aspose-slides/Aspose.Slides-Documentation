---
title: PowerPoint Sunumlarını PHP'de Animasyonlarla Geliştirin
linktitle: PowerPoint Animasyonu
type: docs
weight: 150
url: /tr/php-java/powerpoint-animation/
keywords:
- animasyon ekle
- animasyon güncelle
- animasyon değiştir
- animasyon kaldır
- animasyon yönet
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'in PowerPoint animasyonlarını yönetmedeki yeteneklerini keşfedin. Sunumlarınızı geliştirmek için temel özellikler ve içgörüler."
---
## **Giriş**

Sunumlar bir şeyi sunmak amacıyla hazırlandığından, oluşturulurken görsel görünümü ve etkileşimli davranışı her zaman göz önünde bulundurulur.

**PowerPoint animasyonu** sunumu izleyiciler için göz alıcı ve çekici kılmak amacıyla önemli bir rol oynar. Aspose.Slides for PHP via Java, PowerPoint sunumuna animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- çeşitli türde PowerPoint animasyon efektlerini şekiller, grafikler, tablolar, OLE Nesneleri ve diğer sunum öğeleri üzerine uygulayın.
- bir şekil üzerinde birden çok PowerPoint animasyon efekti kullanın.
- animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullanın.
- özel animasyon oluşturun.

Aspose.Slides for PHP via Java'da, çeşitli animasyon efektleri şekillere uygulanabilir. Metin, resim, OLE Nesnesi, tablo vb. dahil slayttaki her öğe bir şekil olarak kabul edildiğinden, bir slaydın her öğesine animasyon efekti uygulayabiliriz.

## **Animasyon Efektleri**
Aspose.Slides **150+ animasyon efekti** destekler, Bounce, PathFootball, Yakınlaştırma efekti gibi temel animasyon efektleri ve OLEObjectShow, OLEObjectOpen gibi belirli animasyon efektlerini içerir. Animasyon efektlerinin tam listesini [**EffectType**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effecttype/) enum'unda bulabilirsiniz.

Ayrıca, bu animasyon efektleri onlarla birlikte kullanılabilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SetEffect)

## **Özel Animasyon**
Aspose.Slides'de kendi **özel animasyonlarınızı** oluşturabilirsiniz. 
Bunu, birden fazla davranışı bir araya getirerek yeni bir özel animasyon oluşturursanız elde edebilirsiniz.

[**Behavior**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Behavior) herhangi bir PowerPoint animasyon efektinin yapı birimidir. Tüm animasyon efektleri aslında bir strateji içinde birleştirilmiş bir dizi davranıştan oluşur. Davranışları bir kez birleştirerek özel bir animasyon oluşturabilir ve bunu diğer sunumlarda yeniden kullanabilirsiniz. Standart bir PowerPoint animasyon efektine yeni bir davranış eklerseniz, bu başka bir özel animasyon olur. Örneğin, bir animasyona yineleme davranışı ekleyerek animasyonun birkaç kez tekrarlanmasını sağlayabilirsiniz.

[**Animation Point**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Point) davranışın uygulanması gereken noktadır.

## **Animasyon Zaman Çizelgesi**
[**Sequence**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Sequence) belirli bir şekle uygulanan animasyon efektlerinin bir koleksiyonudur.

[**Timeline**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/AnimationTimeLine) belirli bir slaytta kullanılan bir dizi Sequence'ten oluşur. PowerPoint 2002'den beri temsil edilen bir animasyon motorudur. Önceki PowerPoint sürümlerinde, sunuma animasyon efektleri eklemek zordu ve yalnızca çeşitli geçici çözümlerle mümkün oluyordu. Timeline, eski AnimationSettings sınıfının yerini alarak PowerPoint animasyonu için daha net bir nesne modeli sağlar. Bir slayt yalnızca bir animasyon zaman çizelgesine sahip olabilir.

## **Etkileşimli Animasyon**
[**Trigger**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/EffectTriggerType) belirli bir animasyonu başlatacak kullanıcı eylemlerini (ör. düğme tıklaması) tanımlamayı sağlar. Tetikleyiciler yalnızca en son PowerPoint sürümüne eklenmiştir.

## **Şekil Animasyonu**
Aspose.Slides, şekillere (metin, dikdörtgen, çizgi, çerçeve, OLE Nesnesi vb.) animasyon uygulamayı sağlar.

{{% alert color="primary" %}} 
Daha fazla bilgi edinin [**Şekil Animasyonu Hakkında**](/slides/tr/php-java/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**
Animasyonlu grafikler oluşturmak için şekillerde kullanılan aynı sınıfları kullanmalısınız. Bununla birlikte, PowerPoint animasyonunu yalnızca grafik kategorileri veya grafik serileri üzerinde kullanmak mümkündür. Ayrıca bir kategori öğesine veya seri öğesine animasyon efekti uygulayabilirsiniz.

{{% alert color="primary" %}} 
Daha fazla bilgi edinin [**Animasyonlu Grafikler Hakkında**](/slides/tr/php-java/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**
Animasyonlu metin dışında, bir paragrafa da animasyon uygulamak mümkündür.

{{% alert color="primary" %}} 
Daha fazla bilgi edinin [**Animasyonlu Metin Hakkında**](/slides/tr/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF'ye dışa aktarırken animasyonlar korunacak mı?**

Hayır. PDF sabit bir format olduğundan, animasyonlar ve [slayt geçişleri](/slides/tr/php-java/slide-transition/) oynatılmaz. Hareket gerekiyorsa, bunun yerine [HTML5](/slides/tr/php-java/export-to-html5/), [animasyonlu GIF](/slides/tr/php-java/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/php-java/convert-powerpoint-to-video/) formatına dışa aktarın.

**Animasyonlu bir sunumu videoya dönüştürebilir ve kare oranı ile kare boyutunu kontrol edebilir miyim?**

Evet. Sunumu [çerçeveler olarak renderleyebilirsiniz](/slides/tr/php-java/convert-powerpoint-to-video/) ve bunları bir video (ör. ffmpeg ile) olarak kodlayabilir, FPS ve çözünürlüğü seçebilirsiniz. Renderleme sırasında animasyonlar ve slayt geçişleri oynatılır.

**ODP ile (sadece PPTX değil) çalışırken animasyonlar aynı kalacak mı?**

PPT, PPTX ve ODP, [okuma](/slides/tr/php-java/open-presentation/) ve [yazma](/slides/tr/php-java/save-presentation/) için desteklenir, ancak format farkları bazı efektlerin biraz farklı görünmesine veya davranmasına neden olabilir. Kritik durumları gerçek örneklerle doğrulayın.