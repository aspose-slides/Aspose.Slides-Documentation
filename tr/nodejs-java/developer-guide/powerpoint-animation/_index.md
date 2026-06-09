---
title: JavaScript'te Animasyonlarla PowerPoint Sunumlarını Geliştirin
linktitle: PowerPoint Animasyonu
type: docs
weight: 150
url: /tr/nodejs-java/powerpoint-animation/
keywords:
- animasyon ekle
- animasyonu güncelle
- animasyonu değiştir
- animasyonu kaldır
- animasyonu yönet
- animasyonu kontrol
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint animasyonlarını yönetmek için Node.js via Java için Aspose.Slides kullanın. Bu genel bakış, temel özellikleri vurgular ve sunumlarınızı geliştirmek için içgörüler sunar."
---
## **Giriş**

Sunumlar bir şeyi sunmak için tasarlandığından, görsel görünümleri ve etkileşimli davranışları her zaman oluşturulurken dikkate alınır.

**PowerPoint animasyonu**, sunumu izleyiciler için çekici ve ilgi çekici hâle getirmek için önemli bir rol oynar. Aspose.Slides for Node.js via Java, PowerPoint sunumuna animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- şekiller, grafikler, tablolar, OLE Nesneleri ve diğer sunum öğeleri üzerinde çeşitli PowerPoint animasyon efektleri uygulayın.
- bir şekil üzerinde birden fazla PowerPoint animasyon efekti kullanın.
- animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullanın.
- özel animasyon oluşturun.

Aspose.Slides for Node.js via Java'da, şekiller üzerinde çeşitli animasyon efektleri uygulanabilir. Slayttaki metin, resimler, OLE Nesnesi, tablo vb. dahil tüm öğeler şekil olarak kabul edildiğinden, bir slaydın her öğesine animasyon efekti uygulayabiliriz.

## **Animasyon Efektleri**
Aspose.Slides **150+ animasyon efekti** destekler; Bounce, PathFootball, Zoom efekti gibi temel animasyon efektlerinin yanı sıra OLEObjectShow, OLEObjectOpen gibi özel animasyon efektleri de bulunur. Tam animasyon efekti listesini **EffectType** enum'unda bulabilirsiniz.  
[**EffectType**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttype/)

Ek olarak, bu animasyon efektleri aşağıdaki efektlerle birleştirilebilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SetEffect)

## **Özel Animasyon**
Aspose.Slides'de kendi **özel animasyonlarınızı** oluşturabilirsiniz. Bu, birden fazla davranışı bir araya getirerek yeni bir özel animasyon oluşturmanızla mümkündür.

[**Behavior**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Behavior) herhangi bir PowerPoint animasyon efektinin yapı taşıdır. Tüm animasyon efektleri aslında bir strateji içinde birleştirilmiş davranışlar kümesidir. Davranışları bir kez birleştirip özel animasyon oluşturabilir ve diğer sunumlarda yeniden kullanabilirsiniz. Standart bir PowerPoint animasyon efektine yeni bir davranış eklerseniz – bu başka bir özel animasyon olur. Örneğin, bir animasyona tekrar davranışı ekleyerek birkaç kez tekrarlanmasını sağlayabilirsiniz.

[**Animation Point**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Point) davranışın uygulanması gereken bir noktadır.

## **Animasyon Zaman Çizelgesi**
[**Sequence**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Sequence) belirli bir şekle uygulanan animasyon efektlerinin bir koleksiyonudur.

[**Timeline**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AnimationTimeLine) belirli bir slaytta kullanılan bir dizi Sequence'ten oluşur. PowerPoint 2002'den beri bulunan bir animasyon motorudur. Önceki PowerPoint sürümlerinde animasyon efektlerini eklemek zordu ve yalnızca çeşitli geçici çözümlerle mümkün olabiliyordu. Timeline, eski AnimationSettings sınıfının yerini alarak PowerPoint animasyonu için daha net bir nesne modeli sunar. Bir slayt yalnızca bir animasyon zaman çizelgesine sahip olabilir.

## **Etkileşimli Animasyon**
[**Trigger**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/EffectTriggerType) belirli bir animasyonun başlamasını sağlayacak kullanıcı eylemlerini (ör. düğme tıklaması) tanımlamaya olanak verir. Tetikleyiciler yalnızca en son PowerPoint sürümüne eklenmiştir.

## **Şekil Animasyonu**
Aspose.Slides, şekillere animasyon uygulamaya olanak tanır; bu şekiller aslında metin, dikdörtgen, çizgi, çerçeve, OLE Nesnesi vb. olabilir.

{{% alert color="primary" %}} 
Read more [**Şekil Animasyonu Hakkında**](/slides/tr/nodejs-java/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**
Animasyonlu grafikler oluşturmak için şekillerde kullandığınız aynı sınıfları kullanmalısınız. Ancak PowerPoint animasyonunu yalnızca grafik kategorileri veya seri üzerine uygulamak mümkündür. Bir kategori öğesine veya seri öğesine de animasyon efekti uygulayabilirsiniz.

{{% alert color="primary" %}} 
Read more [**Animasyonlu Grafikler Hakkında**](/slides/tr/nodejs-java/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**
Animasyonlu metnin yanı sıra bir paragraf'a da animasyon uygulamak mümkündür.

{{% alert color="primary" %}} 
Read more [**Animasyonlu Metin Hakkında**](/slides/tr/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Animasyonlar PDF'ye dışa aktarılırken korunur mu?**

Hayır. PDF sabit bir formattır, bu yüzden animasyonlar ve [slide transitions](/slides/tr/nodejs-java/slide-transition/) oynatılmaz. Eğer hareket gerekiyorsa, bunun yerine [HTML5](/slides/tr/nodejs-java/export-to-html5/), [animated GIF](/slides/tr/nodejs-java/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) formatına dışa aktarın.

**Animasyonlu bir sunumu video haline getirip kare hızı ve kare boyutunu kontrol edebilir miyim?**

Evet. Sunumu [sunumu kareler olarak render et](/slides/tr/nodejs-java/convert-powerpoint-to-video/) yapabilir ve bunları bir video olarak kodlayabilirsiniz (ör. ffmpeg ile), FPS ve çözünürlüğü seçerek. Animasyonlar ve slayt geçişleri render sırasında oynatılır.

**Animasyonlar ODP (sadece PPTX değil) ile çalışırken aynı kalır mı?**

PPT, PPTX ve ODP, [okuma](/slides/tr/nodejs-java/open-presentation/) ve [kaydetme](/slides/tr/nodejs-java/save-presentation/) için desteklenir, ancak format farklılıkları bazı efektlerin biraz farklı görünmesine veya davranmasına neden olabilir. Kritik durumları gerçek örneklerle doğrulayın.