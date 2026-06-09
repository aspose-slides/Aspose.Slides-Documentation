---
title: PowerPoint Sunumlarını .NET'te Animasyonlarla Geliştirin
linktitle: PowerPoint Animasyonu
type: docs
weight: 150
url: /tr/net/powerpoint-animation/
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
- animasyonlu görüntü
- animasyonlu tablo
- PowerPoint sunumu
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in PowerPoint animasyonlarını yönetme yeteneklerini keşfedin. Bu genel bakış, temel özellikleri vurgular ve sunumlarınızı geliştirmek için içgörüler sunar."
---
## **Giriş**

Sunumların bir şeyi sunmak amacı taşıdığından, görsel görünümü ve etkileşimli davranışı her zaman oluşturulurken göz önünde bulundurulur.

**PowerPoint animasyonu** sunumu izleyiciler için göz alıcı ve ilgi çekici hâle getirmede önemli bir rol oynar. Aspose.Slides for .NET, PowerPoint sunumlarına animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- Şekillere, grafiklere, tablolara, OLE nesnelerine ve diğer sunum öğelerine çeşitli PowerPoint animasyon efektleri uygulayın.
- Tek bir şekil üzerinde birden çok PowerPoint animasyon efekti kullanın.
- Animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullanın.
- Özel animasyonlar oluşturun.

Aspose.Slides for .NET'te, çeşitli animasyon efektleri şekillere uygulanabilir. Metin, resim, OLE nesneleri ve tablolar dahil olmak üzere bir slayd üzerindeki her öğe bir şekil olarak kabul edildiğinden, animasyon efektleri slayttaki herhangi bir öğeye uygulanabilir.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/) ad alanı, PowerPoint animasyonlarıyla çalışmak için sınıflar sağlar.

## **Animasyon Efektleri**

Aspose.Slides, **150+ animasyon efekti**'ni destekler; Bounce, PathFootball ve Zoom gibi temel efektlerin yanı sıra OLEObjectShow ve OLEObjectOpen gibi belirli efektler de bulunur. Animasyon efektlerinin tam listesini [EffectType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttype) enumarasyonunda bulabilirsiniz.

Ayrıca, bu animasyon efektleri aşağıdakilerle birleştirilebilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/seteffect)

## **Özel Animasyon**

Aspose.Slides'te kendi **özel animasyonlarınızı** oluşturmak mümkündür. Bu, birden fazla davranışı birleştirerek yeni bir özel animasyon elde edilmesiyle sağlanabilir.

[Behaviour](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/behavior) herhangi bir PowerPoint animasyon efektinin temel yapı taşıdır. Tüm animasyon efektleri esasen bir strateji içinde birleştirilen bir dizi davranıştan oluşur. Davranışları bir kez birleştirip özel bir animasyon oluşturabilir ve bunu diğer sunumlarda yeniden kullanabilirsiniz. Standart bir PowerPoint animasyon efektine yeni bir davranış eklerseniz, bu başka bir özel animasyon haline gelir. Örneğin, bir animasyona tekrarlama davranışı ekleyerek animasyonun birkaç kez tekrar etmesini sağlayabilirsiniz.

[Animation Point](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/point) davranışın uygulanması gereken noktadır.

## **Animasyon Zaman Çizelgesi**

[Sequence](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/sequence) belirli bir şekle uygulanan animasyon efektlerinin bir koleksiyonudur.

[Timeline](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/animationtimeline) belirli bir slaytta kullanılan bir dizi sekansdır. PowerPoint 2002'de tanıtılan bir animasyon motorudur. PowerPoint'in önceki sürümlerinde, sunumlara animasyon efekti eklemek zordu ve yalnızca çeşitli geçici çözümlerle gerçekleştirilebiliyordu. Zaman çizelgesi, eski AnimationSettings sınıfının yerini alır ve PowerPoint animasyonları için daha net bir nesne modeli sunar. Bir slaytta yalnızca bir animasyon zaman çizelgesi bulunabilir.

## **Etkileşimli Animasyon**

[Trigger](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttriggertype) belirli bir animasyonu başlatacak kullanıcı eylemlerini (ör. bir düğmeye tıklama) tanımlamanıza olanak tanır. Tetikleyiciler, PowerPoint'in en son sürümünde tanıtıldı.

## **Şekil Animasyonu**

Aspose.Slides, metin, dikdörtgen, çizgi, çerçeve, OLE nesnesi ve daha fazlasını içerebilen şekillere animasyon uygulamanıza olanak tanır.

{{% alert color="primary" %}} 
Daha fazla okuyun [**Şekil Animasyonu Hakkında**](/slides/tr/net/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**

Animasyonlu grafikler oluşturmak için şekillerde kullanılan aynı sınıfları kullanmalısınız. Ancak, PowerPoint animasyonları yalnızca grafik kategorilerine veya grafik serilerine uygulanabilir. Ayrıca, bir kategori öğesine veya bir seri öğesine animasyon efektleri uygulayabilirsiniz.

{{% alert color="primary" %}} 
Daha fazla okuyun [**Animasyonlu Grafikler Hakkında**](/slides/tr/net/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**

Animasyonlu metin dışında, bir paragraf'a da animasyon uygulamak mümkündür.

{{% alert color="primary" %}} 
Daha fazla okuyun [**Animasyonlu Metin Hakkında**](/slides/tr/net/animated-text/).
{{% /alert %}}

## **SSS**

**PDF'ye dışa aktarırken animasyonlar korunacak mı?**

Hayır. PDF statik bir formattır, bu yüzden animasyonlar ve [slayt geçişleri](/slides/tr/net/slide-transition/) oynatılmaz. Hareket gerekiyorsa, bunun yerine [HTML5](/slides/tr/net/export-to-html5/), [animasyonlu GIF](/slides/tr/net/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/net/convert-powerpoint-to-video/) formatına dışa aktarın.

**Animasyonlu bir sunumu video haline getirip kare hızı ve kare boyutunu kontrol edebilir miyim?**

Evet. Sunumu [kareler olarak işleyerek](/slides/tr/net/convert-powerpoint-to-video/) video haline getirebilir ve (ör. ffmpeg ile) FPS ve çözünürlüğü seçerek kodlayabilirsiniz. İşleme sırasında animasyonlar ve slayt geçişleri oynatılır.

**ODP (sadece PPTX değil) ile çalışırken animasyonlar aynı kalacak mı?**

PPT, PPTX ve ODP, [okuma](/slides/tr/net/open-presentation/) ve [yazma](/slides/tr/net/save-presentation/) için desteklenir, ancak format farkları bazı efektlerin biraz farklı görünmesine veya davranmasına neden olabilir. Kritik durumları gerçek örneklerle doğrulayın.