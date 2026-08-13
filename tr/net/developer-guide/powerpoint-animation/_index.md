---
title: PowerPoint Sunumlarını .NET'te Animasyonlarla Geliştirin
linktitle: PowerPoint Animasyonu
type: docs
weight: 150
url: /tr/net/powerpoint-animation/
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
- animasyonlu görüntü
- animasyonlu tablo
- PowerPoint sunumu
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in PowerPoint animasyonlarını yönetme yeteneklerini keşfedin. Bu genel bakış, temel özellikleri vurgular ve sunumlarınızı geliştirmeniz için içgörüler sunar."
---
## **Giriş**

Sunumların bir şeyi sunmak amacıyla hazırlanması nedeniyle, görsel görünümleri ve etkileşimli davranışları oluşturulurken her zaman dikkate alınır.

**PowerPoint animasyonu**, bir sunumu izleyiciler için ilgi çekici ve etkileyici kılmada önemli bir rol oynar. Aspose.Slides for .NET, PowerPoint sunumlarına animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- Şekiller, çizelgeler, tablolar, OLE nesneleri ve diğer sunum öğelerine çeşitli PowerPoint animasyon efektleri uygulayın.
- Tek bir şekle birden çok PowerPoint animasyon efekti uygulayın.
- Animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullanın.
- Özelleştirilmiş animasyonlar oluşturun.

Aspose.Slides for .NET’te, çeşitli animasyon efektleri şekillere uygulanabilir. Metin, resimler, OLE nesneleri ve tablolar dahil bir slayttaki her öğe bir şekil olarak kabul edildiğinden, animasyon efektleri slayttaki herhangi bir öğeye uygulanabilir.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/) namespace PowerPoint animasyonlarıyla çalışmak için sınıflar sağlar.

## **Animasyon Efektleri**

Aspose.Slides **150+ animasyon efekti** destekler; Bounce, PathFootball ve Zoom gibi temel efektlerin yanı sıra OLEObjectShow ve OLEObjectOpen gibi özel efektler de bulunur. Tüm animasyon efektlerinin tam listesini [EffectType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttype) enumarasyonunda bulabilirsiniz.

Ek olarak, bu animasyon efektleri aşağıdaki ile birleştirilebilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/seteffect)

## **Özel Animasyon**

Aspose.Slides’te kendi **özel animasyonlarınızı** oluşturabilirsiniz. Bu, birkaç davranışı bir araya getirerek yeni bir özel animasyon oluşturmayı gerektirir.

[Behaviour](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/behavior), herhangi bir PowerPoint animasyon efektinin temel yapı taşıdır. Tüm animasyon efektleri, bir strateji içinde birleştirilen davranış kümesidir. Davranışları bir kez birleştirip özel bir animasyon oluşturabilir ve bunu diğer sunumlarda yeniden kullanabilirsiniz. Standart bir PowerPoint animasyon efektine yeni bir davranış eklerseniz, bu başka bir özel animasyon haline gelir. Örneğin, bir animasyona yineleme davranışı ekleyerek birkaç kez tekrarlanmasını sağlayabilirsiniz.

[Animation Point](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/point), bir davranışın uygulanması gereken noktadır.

## **Animasyon Zaman Çizelgesi**

[Sequence](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/sequence), belirli bir şekle uygulanan animasyon efektlerinin koleksiyonudur.

[Timeline](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/animationtimeline), belirli bir slaytta kullanılan sıralamaların bir kümesidir. PowerPoint 2002’de tanıtılan bir animasyon motorudur. PowerPoint’in eski sürümlerinde sunumlara animasyon eklemek zordu ve çeşitli geçici çözümlerle ancak mümkün olabiliyordu. Zaman çizelgesi, eski AnimationSettings sınıfının yerini alır ve PowerPoint animasyonları için daha net bir nesne modeli sağlar. Bir slaytta yalnızca bir animasyon zaman çizelgesi bulunabilir.

## **Etkileşimli Animasyon**

[Trigger](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttriggertype), belirli bir animasyonu başlatacak kullanıcı eylemlerini (ör. bir düğmeye tıklama) tanımlamanıza olanak verir. Tetikleyiciler, PowerPoint’in en son sürümünde tanıtıldı.

## **Şekil Animasyonu**

Aspose.Slides, şekillere animasyon uygulamanıza izin verir; bu şekiller metin, dikdörtgen, çizgi, çerçeve, OLE nesneleri ve daha fazlasını içerebilir.

{{% alert color="info" %}} 
Daha fazla bilgi [**Şekil Animasyonu Hakkında**](/slides/tr/net/shape-animation/).
{{% /alert %}}

## **Animasyonlu Çizelgeler**

Animasyonlu çizelgeler oluşturmak için şekillerde olduğu gibi aynı sınıfları kullanmalısınız. Ancak PowerPoint animasyonları yalnızca çizelge kategorilerine veya çizelge serilerine uygulanabilir. Bir kategori öğesine veya bir seri öğesine de animasyon efekti uygulayabilirsiniz.

{{% alert color="info" %}} 
Daha fazla bilgi [**Animasyonlu Çizelgeler Hakkında**](/slides/tr/net/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**

Animasyonlu metnin yanı sıra bir paragraf üzerine de animasyon uygulamak mümkündür.

{{% alert color="info" %}} 
Daha fazla bilgi [**Animasyonlu Metin Hakkında**](/slides/tr/net/animated-text/).
{{% /alert %}}

## **SSS**

### Animasyonlar PDF’ye dışa aktarıldığında korunur mu?

Hayır. PDF statik bir formattır, bu yüzden animasyonlar ve [slayt geçişleri](/slides/tr/net/slide-transition/) çalışmaz. Hareket gerekiyorsa, bunun yerine [HTML5](/slides/tr/net/export-to-html5/), [animasyonlu GIF](/slides/tr/net/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/net/convert-powerpoint-to-video/) formatına dışa aktarın.

### Animasyonlu bir sunumu videoya dönüştürüp kare hızı ve kare boyutunu kontrol edebilir miyim?

Evet. Sunumu [kareler olarak render](/slides/tr/net/convert-powerpoint-to-video/) edip bir video dosyasına (ör. ffmpeg ile) kodlayabilirsiniz; FPS ve çözünürlüğü seçebilirsiniz. Render sırasında animasyonlar ve slayt geçişleri oynatılır.

### ODP ile çalışırken (sadece PPTX değil) animasyonlar aynı kalır mı?

PPT, PPTX ve ODP, [okuma](/slides/tr/net/open-presentation/) ve [yazma](/slides/tr/net/save-presentation/) için desteklenir, ancak format farklılıkları bazı efektlerin biraz farklı görünmesine veya davranmasına neden olabilir. Kritik durumları gerçek örneklerle doğrulayın.