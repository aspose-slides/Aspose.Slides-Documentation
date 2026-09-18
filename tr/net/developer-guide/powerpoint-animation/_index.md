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
- animasyonlu resim
- animasyonlu tablo
- PowerPoint sunumu
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in PowerPoint animasyonlarını yönetme yeteneklerini keşfedin. Bu genel bakış, temel özellikleri vurgular ve sunumlarınızı geliştirmeniz için bilgiler sunar."
---
## **Giriş**

Sunumlar bir şey sunmak için tasarlandığından, görsel görünümleri ve etkileşimli davranışları her zaman oluşturulurken dikkate alınır.

**PowerPoint animasyonu**, bir sunumu izleyiciler için göz alıcı ve ilgi çekici hâle getirmede önemli bir rol oynar. Aspose.Slides for .NET, PowerPoint sunumlarına animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- Şekillere, grafiklere, tablolara, OLE nesnelerine ve diğer sunum öğelerine çeşitli PowerPoint animasyon efektleri uygulayın.
- Tek bir şekil üzerinde birden fazla PowerPoint animasyon efekti kullanın.
- Animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullanın.
- Özel animasyonlar oluşturun.

Aspose.Slides for .NET'te, şekillere çeşitli animasyon efektleri uygulanabilir. Metin, resim, OLE nesneleri ve tablolara dahil bir slayttaki her öğe şekil olarak kabul edildiğinden, animasyon efektleri slayttaki herhangi bir öğeye uygulanabilir.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/) namespace PowerPoint animasyonlarıyla çalışmak için sınıflar sağlar.

## **Animasyon Efektleri**

Aspose.Slides, **150+ animasyon efekti** destekler; Bounce, PathFootball ve Zoom gibi temel efektlerin yanı sıra OLEObjectShow ve OLEObjectOpen gibi belirli efektler de vardır. Animasyon efektlerinin tam listesini [EffectType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttype) enum'unda bulabilirsiniz.

Ayrıca, bu animasyon efektleri aşağıdakilerle birlikte kullanılabilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/seteffect)

## **Özel Animasyon**

Davranışları ve düzenlenebilir hareket yollarını oluşturup inceleyen ve değiştiren tam C# örnekleri için [Custom Animation](/slides/tr/net/custom-animation/) sayfasına bakın.

Aspose.Slides'te kendi **özel animasyonlarınızı** oluşturmak mümkündür. Bu, birden fazla davranışı birleştirerek yeni bir özel animasyon oluşturmakla sağlanabilir.

[Behavior](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/behavior) bir PowerPoint animasyon efektinin temel yapı taşıdır. Bir efekti özelleştirmek için davranışları birleştirin veya önceden tanımlı bir efekti genişletmek için bir davranış ekleyin. Tekrar, ayrı bir tekrar davranışı yerine zamanlama ayarlarıyla yapılandırılır.

[Animation Point](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/point) bir davranışın uygulanması gereken noktadır.

## **Animasyon Zaman Çizelgesi**

[Sequence](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/sequence) farklı şekilleri hedefleyebilen animasyon efektlerinin bir koleksiyonudur.

[Timeline](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/animationtimeline) belirli bir slaytta kullanılan bir dizi sekansdır. PowerPoint 2002'de tanıtılan bir animasyon motorudur. PowerPoint'in önceki sürümlerinde, sunumlara animasyon efekti eklemek zordu ve çeşitli geçici çözümlerle yapılabiliyordu. Zaman çizelgesi, eski AnimationSettings sınıfının yerini alır ve PowerPoint animasyonları için daha net bir nesne modeli sunar. Bir slaytta yalnızca bir animasyon zaman çizelgesi bulunabilir.

## **Etkileşimli Animasyon**

[Trigger](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttriggertype) belirli bir animasyonu başlatacak kullanıcı eylemlerini (ör. bir düğmeye tıklama) tanımlamanıza olanak sağlar. Tetikleyiciler PowerPoint'in en son sürümünde tanıtıldı.

## **Şekil Animasyonu**

Aspose.Slides, metin, dikdörtgen, çizgi, çerçeve, OLE nesneleri ve daha fazlasını içerebilen şekillere animasyon uygulamanıza izin verir.

{{% alert color="info" title="Note" %}}
Daha fazla bilgi için [**Şekil Animasyonu Hakkında**](/slides/tr/net/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**

Animasyonlu grafikler oluşturmak için şekillerde kullanılan aynı sınıfları kullanmalısınız. Ancak, PowerPoint animasyonları yalnızca grafik kategorilerine veya grafik serilerine uygulanabilir. Bir kategori öğesine veya bir seri öğesine de animasyon efekti uygulayabilirsiniz.

{{% alert color="info" title="Note" %}}
Daha fazla bilgi için [**Animasyonlu Grafikler Hakkında**](/slides/tr/net/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**

Metni animasyonlamanın yanı sıra bir paragraf üzerine de animasyon uygulayabilirsiniz.

{{% alert color="info" title="Note" %}}
Daha fazla bilgi için [**Animasyonlu Metin Hakkında**](/slides/tr/net/animated-text/).
{{% /alert %}}

## **SSS**

**PDF'ye dışa aktarırken animasyonlar korunur mu?**

Hayır. PDF statik bir formattır, bu yüzden animasyonlar ve [slayt geçişleri](/slides/tr/net/slide-transition/) oynatılmaz. Hareket gerekliyse, bunun yerine [HTML5](/slides/tr/net/export-to-html5/), [animasyonlu GIF](/slides/tr/net/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/net/convert-powerpoint-to-video/) olarak dışa aktarın.

**Animasyonlu bir sunumu videoya dönüştürüp kare hızı ve kare boyutunu kontrol edebilir miyim?**

Evet. Sunumu [kareler olarak renderlayarak](/slides/tr/net/convert-powerpoint-to-video/) videoya (ör. ffmpeg ile) kodlayabilir, FPS ve çözünürlüğü seçebilirsiniz. Animasyonlar ve slayt geçişleri renderleme sırasında oynatılır.

**ODP (sadece PPTX değil) ile çalışırken animasyonlar aynı kalır mı?**

PPT, PPTX ve ODP, [okuma](/slides/tr/net/open-presentation/) ve [yazma](/slides/tr/net/save-presentation/) işlemleri için desteklenir, ancak bu animasyonların korunacağını garanti etmez. ODP'ye dönüştürürken özel animasyon verileri kaybolabilir. Test edilmiş bir örnek ve format sınırlamaları için [Custom Animation](/slides/tr/net/custom-animation/) sayfasına bakın.