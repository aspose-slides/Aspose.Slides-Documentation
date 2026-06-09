---
title: Android'de Animasyonlarla PowerPoint Sunumlarını Geliştirin
linktitle: PowerPoint Animasyonu
type: docs
weight: 150
url: /tr/androidjava/powerpoint-animation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'in PowerPoint animasyonlarını yönetmedeki yeteneklerini keşfedin. Bu genel bakış temel özellikleri vurgular."
---
## **Giriş**

Sunumlar bir şey sunmak için tasarlandığından, oluşturulurken görsel görünümleri ve etkileşimli davranışları her zaman göz önünde bulundurulur.

**PowerPoint animation** izleyiciler için sunumu göz alıcı ve çekici hâle getirmek amacıyla önemli bir rol oynar. Aspose.Slides for Android via Java, PowerPoint sunumuna animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- şekiller, grafikler, tablolar, OLE Nesneleri ve diğer sunum öğeleri üzerinde çeşitli PowerPoint animasyon efekti türlerini uygula.
- bir şekil üzerinde birden fazla PowerPoint animasyon efekti kullan.
- animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullan.
- özel animasyon oluştur.

Aspose.Slides for Android via Java’da, şekiller üzerinde çeşitli animasyon efektleri uygulanabilir. Metin, resim, OLE Nesnesi, tablo vb. dahil slayttaki her öğe bir şekil olarak kabul edildiğinden, bir slaydın tüm öğelerine animasyon efekti uygulayabiliriz.

## **Animasyon Efektleri**
Aspose.Slides **150+ animasyon efekti**'ni destekler; Bounce, PathFootball, Zoom efekti gibi temel animasyon efektlerinin yanı sıra OLEObjectShow, OLEObjectOpen gibi belirli animasyon efektlerini de içerir. Animasyon efektlerinin tam listesini [**EffectType**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effecttype/) enumerasyonunda bulabilirsiniz.

Ayrıca, bu animasyon efektleri aşağıdaki öğelerle birleştirilebilir:
- [ColorEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SetEffect)

## **Özel Animasyon**
Aspose.Slides içinde kendi **özel animasyonlarınızı** oluşturabilirsiniz. Bunun için birkaç davranışı bir araya getirerek yeni bir özel animasyon oluşturabilirsiniz.

[**Behavior**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Behavior) herhangi bir PowerPoint animasyon efektinin yapı taşıdır. Tüm animasyon efektleri aslında bir strateji içinde birleştirilen bir dizi davranıştan oluşur. Davranışları bir kez birleştirerek özel bir animasyon oluşturabilir ve bunu diğer sunumlarda tekrar kullanabilirsiniz. Standart bir PowerPoint animasyon efektine yeni bir davranış eklediğinizde – bu başka bir özel animasyon olur. Örneğin, bir animasyona tekrarlama davranışı ekleyerek animasyonun birkaç kez tekrarlanmasını sağlayabilirsiniz.

[**Animation Point**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Point) davranışın uygulanması gereken noktadır.

## **Animasyon Zaman Çizelgesi**
[**Sequence**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Sequence) belirli bir şekle uygulanan animasyon efektlerinin bir koleksiyonudur.

[**Timeline**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AnimationTimeLine) belirli bir slaytta kullanılan bir dizi Sequence'tir. PowerPoint 2002'den beri temsil edilen bir animasyon motorudur. Önceki PowerPoint sürümlerinde, sunuma animasyon efekti eklemek zordu ve yalnızca çeşitli geçici çözümlerle mümkün oluyordu. Timeline, eski AnimationSettings sınıfının yerini alır ve PowerPoint animasyonu için daha açık bir nesne modeli sağlar. Bir slayt yalnızca bir animasyon zaman çizelgesine sahip olabilir.

## **Etkileşimli Animasyon**
[**Trigger**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/EffectTriggerType) belirli bir animasyonun başlamasını sağlayacak kullanıcı eylemlerini (ör. düğme tıklaması) tanımlamaya olanak verir. Trigger'lar yalnızca en son PowerPoint sürümüne eklenmiştir.

## **Şekil Animasyonu**
Aspose.Slides, aslında metin, dikdörtgen, çizgi, çerçeve, OLE Nesnesi vb. olabilen şekillere animasyon uygulamaya izin verir.

{{% alert color="primary" %}} 
Daha fazla okuyun [**Şekil Animasyonu Hakkında**](/slides/tr/androidjava/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**
Animasyonlu grafikler oluşturmak için şekillerde kullanılan aynı sınıfları kullanmalısınız. Ancak, PowerPoint animasyonunu yalnızca grafik kategorileri veya seri'lerine uygulamak mümkündür. Ayrıca bir kategori öğesine veya seri öğesine animasyon efekti uygulayabilirsiniz.

{{% alert color="primary" %}} 
Daha fazla okuyun [**Animasyonlu Grafikler Hakkında**](/slides/tr/androidjava/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**
Animasyonlu metin dışında, bir paragrafa da animasyon uygulamak mümkündür.

{{% alert color="primary" %}} 
Daha fazla okuyun [**Animasyonlu Metin Hakkında**](/slides/tr/androidjava/animated-text/).
{{% /alert %}}

## **SSS**

**PDF'ye dışa aktarırken animasyonlar korunacak mı?**

Hayır. PDF statik bir formattır, bu yüzden animasyonlar ve [slide transitions](/slides/tr/androidjava/slide-transition/) oynatılmaz. Hareket gerekiyorsa, bunun yerine [HTML5](/slides/tr/androidjava/export-to-html5/), [animated GIF](/slides/tr/androidjava/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/androidjava/convert-powerpoint-to-video/) formatına dışa aktarın.

**Animasyonlu bir sunumu video haline getirip kare hızı ve kare boyutunu kontrol edebilir miyim?**

Evet. Sunumu [kareler olarak işleyin](/slides/tr/androidjava/convert-powerpoint-to-video/) ve bunları bir video (ör. ffmpeg) olarak kodlayabilirsiniz; FPS ve çözünürlüğü seçebilirsiniz. Render sırasında animasyonlar ve slide geçişleri oynatılır.

**ODP (sadece PPTX değil) ile çalışırken animasyonlar aynı kalacak mı?**

PPT, PPTX ve ODP, [reading](/slides/tr/androidjava/open-presentation/) ve [writing](/slides/tr/androidjava/save-presentation/) işlemleri için desteklenir, ancak format farklılıkları bazı efektlerin biraz farklı görünmesine veya davranmasına neden olabilir. Kritik durumları gerçek örneklerle doğrulayın.