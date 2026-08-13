---
title: Android'de Animasyonlarla PowerPoint Sunumlarını Geliştirin
linktitle: PowerPoint Animasyonu
type: docs
weight: 150
url: /tr/androidjava/powerpoint-animation/
keywords:
- animasyon ekle
- animasyon güncelle
- animasyon değiştir
- animasyon kaldır
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'in PowerPoint animasyonlarını yönetmedeki yeteneklerini keşfedin. Bu genel bakış temel özellikleri vurgular."
---
## **Giriş**

Sunumların bir şeyi sunmak için tasarlandığını göz önünde bulundurarak, oluşturulurken görsel tasarımları ve etkileşimli davranışları her zaman dikkate alınır.

**PowerPoint animasyonu** izleyiciler için sunumu göz alıcı ve çekici kılmak adına önemli bir rol oynar. Aspose.Slides for Android via Java, PowerPoint sunumuna animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- şekiller, grafikler, tablolar, OLE Nesneleri ve diğer sunum öğeleri üzerine çeşitli PowerPoint animasyon efekti türlerini uygula.
- bir şekil üzerinde birden fazla PowerPoint animasyon efekti kullan.
- animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullan.
- özel animasyon oluştur.

Aspose.Slides for Android via Java'da, çeşitli animasyon efektleri şekillere uygulanabilir. Metin, resim, OLE Nesnesi, tablo vb. dahil slayttaki her öğe bir şekil olarak kabul edildiğinden, bir slaydın her öğesine animasyon efekti uygulanabilir.


## **Animasyon Efektleri**
Aspose.Slides, **150+ animasyon efekti** destekler; Bounce, PathFootball, Zoom efekti gibi temel animasyon efektleri ve OLEObjectShow, OLEObjectOpen gibi özel animasyon efektlerini içerir. Animasyon efektlerinin tam listesini [**EffectType**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effecttype/) dizininde bulabilirsiniz.

Ayrıca bu animasyon efektleri şu sınıflarla birleştirilebilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SetEffect)

## **Özel Animasyon**
Aspose.Slides içinde kendi **özel animasyonlarınızı** oluşturabilirsiniz.  
Bu, birkaç davranışı birleştirerek yeni bir özel animasyon oluşturduğunuzda elde edilebilir.

[**Behavior**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Behavior) herhangi bir PowerPoint animasyon efektinin yapı birimidir. Tüm animasyon efektleri aslında bir strateji içinde birleştirilmiş davranışlar kümesidir. Davranışları bir kez birleştirerek özel bir animasyon oluşturabilir ve bunu diğer sunumlarda tekrar kullanabilirsiniz. Standart bir PowerPoint animasyon efektine yeni bir davranış eklerseniz, bu başka bir özel animasyon olur. Örneğin, bir animasyona tekrarlama davranışı ekleyerek animasyonun birkaç kez tekrarlanmasını sağlayabilirsiniz.

[**Animation Point**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Point) davranışın uygulanması gereken bir noktadır.

## **Animasyon Zaman Çizelgesi**
[**Sequence**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Sequence) belirli bir şekle uygulanan animasyon efektlerinin bir koleksiyonudur.

[**Timeline**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AnimationTimeLine) bir slaytta kullanılan Sequence kümesidir. PowerPoint 2002'den beri temsil edilen bir animasyon motorudur. Önceki PowerPoint sürümlerinde animasyon efektlerini eklemek zordu ve yalnızca çeşitli geçici çözümlerle mümkün olabiliyordu. Timeline, eski AnimationSettings sınıfının yerini alarak PowerPoint animasyonu için daha net bir nesne modeli sağlar. Bir slaytta yalnızca bir animasyon zaman çizelgesi bulunabilir.

## **Etkileşimli Animasyon**
[**Trigger**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/EffectTriggerType) belirli bir animasyonun başlamasını sağlayan kullanıcı eylemlerini (ör. buton tıklaması) tanımlamaya imkan verir. Trigger'lar yalnızca en son PowerPoint sürümünde eklenmiştir.

## **Şekil Animasyonu**
Aspose.Slides, metin, dikdörtgen, çizgi, çerçeve, OLE Nesnesi vb. olabilen şekillere animasyon uygulamayı mümkün kılar.

{{% alert color="info" %}} 
Daha fazla bilgi için [**Şekil Animasyonu Hakkında**](/slides/tr/androidjava/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**
Animasyonlu grafikler oluşturmak için şekillerde kullanılan aynı sınıfları kullanmalısınız. Ancak PowerPoint animasyonu yalnızca grafik kategorileri veya grafik serileri üzerinde uygulanabilir. Bir kategori öğesine veya seri öğesine de animasyon efekti ekleyebilirsiniz.

{{% alert color="info" %}} 
Daha fazla bilgi için [**Animasyonlu Grafikler Hakkında**](/slides/tr/androidjava/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**
Animasyonlu metnin yanı sıra bir paragraf üzerinde de animasyon uygulamak mümkündür.

{{% alert color="info" %}} 
Daha fazla bilgi için [**Animasyonlu Metin Hakkında**](/slides/tr/androidjava/animated-text/).
{{% /alert %}}

## **SSS**

### Animasyonlar PDF'ye dışa aktarılırken korunur mu?

Hayır. PDF statik bir formattır, bu yüzden animasyonlar ve [slide transitions](/slides/tr/androidjava/slide-transition/) oynatılmaz. Hareket gerekiyorsa, bunun yerine [HTML5](/slides/tr/androidjava/export-to-html5/), [animated GIF](/slides/tr/androidjava/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/androidjava/convert-powerpoint-to-video/) dışa aktarın.

### Animasyonlu bir sunumu video haline getirip kare hızı ve çözünürlüğünü kontrol edebilir miyim?

Evet. Sunumu kareler halinde [render](/slides/tr/androidjava/convert-powerpoint-to-video/) edebilir ve bir video olarak kodlayabilirsiniz (ör. ffmpeg ile), FPS ve çözünürlüğü seçerek. Animasyonlar ve slayt geçişleri render sırasında oynatılır.

### Animasyonlar ODP (yalnızca PPTX değil) ile çalışırken aynı kalır mı?

PPT, PPTX ve ODP, [okuma](/slides/tr/androidjava/open-presentation/) ve [yazma](/slides/tr/androidjava/save-presentation/) desteklenir, ancak format farkları bazı efektlerin biraz farklı görünmesine veya davranmasına neden olabilir. Kritik durumları gerçek örneklerle doğrulayın.