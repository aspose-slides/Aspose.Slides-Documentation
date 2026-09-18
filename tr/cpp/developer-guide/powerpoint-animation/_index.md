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
- animasyonlu görüntü
- animasyonlu tablo
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde gelişmiş animasyon efektlerini eklemeyi ve kontrol etmeyi öğrenerek dinamik PowerPoint ve OpenDocument sunumları oluşturun."
---
## **Giriş**

Sunumlar bir şey sunmak için tasarlandığından, görsel görünümleri ve etkileşimli davranışları her zaman oluşturulurken dikkate alınır.

**PowerPoint animasyonu** bir sunumu izleyiciler için göz alıcı ve ilgi çekici hale getirmede önemli bir rol oynar. Aspose.Slides, PowerPoint sunumlarına animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- Şekillere, çizelgelere, tablolara, OLE nesnelerine ve diğer sunum öğelerine çeşitli PowerPoint animasyon efektleri uygulayın.
- Tek bir şekil üzerinde birden çok PowerPoint animasyon efekti kullanın.
- Animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullanın.
- Özel animasyonlar oluşturun.

Aspose.Slides içinde çeşitli animasyon efektleri şekillere uygulanabilir. Metin, resim, OLE nesneleri ve tablolar dahil bir slayttaki her öğe bir şekil olarak kabul edildiğinden, animasyon efektleri slayttaki herhangi bir öğeye uygulanabilir.

[Aspose::Slides::Animation](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/) ad alanı, PowerPoint animasyonlarıyla çalışmak için sınıflar sağlar.

## **Animasyon Efektleri**
Aspose.Slides **150+ animasyon efekti** destekler; Bounce, PathFootball ve Zoom gibi temel efektler ile OLEObjectShow ve OLEObjectOpen gibi belirli efektler içerir. Tam listeyi [EffectType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effecttype/) enumarasyonunda bulabilirsiniz.

Ek olarak, bu animasyon efektleri aşağıdaki davranışlarla birleştirilebilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/seteffect/)

## **Özel Animasyon**
Davranışları ve düzenlenebilir hareket yollarını oluşturma, inceleme ve değiştirme üzerine tam C++ örnekleri için [Özel Animasyon](/slides/tr/cpp/custom-animation/) bölümüne bakın.

Aspose.Slides içinde kendi **özel animasyonlarınızı** oluşturabilirsiniz. Bu, birkaç davranışı birleştirerek yeni bir özel animasyon oluşturmakla mümkün olur.

[Behavior](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/behavior/) bir PowerPoint animasyon efektinin yapı taşıdır. Bir efekti özelleştirmek için davranışları birleştirin veya önceden tanımlı bir efekti genişletmek için bir davranış ekleyin. Tekrar, ayrı bir tekrar davranışı yerine zamanlama ayarlarıyla yapılandırılır.

[Animation Point](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/point/) bir davranışın uygulanması gereken noktadır.

## **Animasyon Zaman Çizelgesi**
[Sequence](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/sequence/) farklı şekilleri hedefleyebilen animasyon efektlerinin bir koleksiyonudur.

[IAnimationTimeLine](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ianimationtimeline/) belirli bir slaytta kullanılan bir dizi sekans setidir. PowerPoint 2002'de tanıtılan bir animasyon motorudur. PowerPoint'in önceki sürümlerinde, sunumlara animasyon efektleri eklemek zordu ve çeşitli geçici çözümlerle mümkün olabiliyordu. Zaman çizelgesi, PowerPoint animasyonları için daha net bir nesne modeli sunar. Bir slaytta yalnızca bir animasyon zaman çizelgesi bulunabilir.

## **Etkileşimli Animasyon**
[Trigger](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effecttriggertype/) bir düğme tıklaması gibi kullanıcı eylemlerini tanımlamanıza ve bu eylemlerin belirli bir animasyonu başlatmasına olanak tanır.

## **Şekil Animasyonu**
Aspose.Slides, metin, dikdörtgen, çizgi, çerçeve, OLE nesneleri ve daha fazlasını içerebilen şekillere animasyon uygulamanıza izin verir.

{{% alert color="info" title="Note" %}}
Daha fazla okuyun [**Şekil Animasyonu Hakkında**](/slides/tr/cpp/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**
Animasyonlu grafikler oluşturmak için şekillerde kullanılan aynı sınıfları kullanmalısınız. Ancak PowerPoint animasyonları yalnızca grafik kategorilerine veya grafik serilerine uygulanabilir. Bir kategori öğesine veya bir seri öğesine de animasyon efektleri uygulayabilirsiniz.

{{% alert color="info" title="Note" %}}
Daha fazla okuyun [**Animasyonlu Grafikler Hakkında**](/slides/tr/cpp/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**
Metni animasyonlamanın yanı sıra bir paragrafta da animasyon uygulayabilirsiniz.

{{% alert color="info" title="Note" %}}
Daha fazla okuyun [**Animasyonlu Metin Hakkında**](/slides/tr/cpp/animated-text/).
{{% /alert %}}

## **SSS**

**PDF'ye dışa aktarırken animasyonlar korunur mu?**

Hayır. PDF statik bir format olduğundan animasyonlar ve [slayt geçişleri](/slides/tr/cpp/slide-transition/) oynatılmaz. Hareket gerekiyorsa, bunun yerine [HTML5](/slides/tr/cpp/export-to-html5/), [animasyonlu GIF](/slides/tr/cpp/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/cpp/convert-powerpoint-to-video/) dışa aktarın.

**Animasyonlu bir sunumu video'ya dönüştürüp kare hızı ve kare boyutunu kontrol edebilir miyim?**

Evet. Sunumu [sunumu kareler olarak işleyebilir](/slides/tr/cpp/convert-powerpoint-to-video/) ve ardından bir video (ör. ffmpeg ile) olarak kodlayabilirsiniz; FPS ve çözünürlüğü seçebilirsiniz. Animasyonlar ve slayt geçişleri işleme sırasında oynatılır.

**ODP (sadece PPTX değil) ile çalışırken animasyonlar aynı kalır mı?**

PPT, PPTX ve ODP, [okuma](/slides/tr/cpp/open-presentation/) ve [yazma](/slides/tr/cpp/save-presentation/) için desteklenir, ancak bu animasyonların korunacağını garanti etmez. Özel animasyon verileri ODP'ye dönüştürülürken kaybolabilir. Uyumlu format denetimi için örnekler ve rehberlik için [Özel Animasyon](/slides/tr/cpp/custom-animation/) bölümüne bakın.