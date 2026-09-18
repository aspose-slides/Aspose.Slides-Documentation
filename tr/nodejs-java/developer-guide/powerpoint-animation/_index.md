---
title: JavaScript ile Animasyonlar Kullanarak PowerPoint Sunumlarını Geliştirin
linktitle: PowerPoint Animasyonu
type: docs
weight: 150
url: /tr/nodejs-java/powerpoint-animation/
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
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint animasyonlarını yönetin. Bu genel bakış, temel özellikleri vurgular ve sunumlarınızı geliştirmek için içgörüler sunar."
---
## **Giriş**

Sunumlar bir şeyi sunmak için tasarlandığından, görsel görünümleri ve etkileşimli davranışları her zaman oluşturulurken dikkate alınır.

**PowerPoint animasyonu** sunumu izleyiciler için dikkat çekici ve ilgi çekici hâle getirmede önemli bir rol oynar. Aspose.Slides for Node.js via Java, PowerPoint sunumlarına animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- Şekillere, grafiklere, tablolara, OLE nesnelerine ve diğer sunum öğelerine çeşitli PowerPoint animasyon efektleri uygulayın.
- Tek bir şekil üzerinde birden fazla PowerPoint animasyon efekti kullanın.
- Animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullanın.
- Özel animasyonlar oluşturun.

Aspose.Slides for Node.js via Java'da, şekillere çeşitli animasyon efektleri uygulanabilir. Metin, resimler, OLE nesneleri ve tablolar dahil bir slayttaki her öğe bir şekil olarak kabul edildiğinden, animasyon efektleri slayttaki herhangi bir öğeye uygulanabilir.

## **Animasyon Efektleri**
Aspose.Slides **150+ animasyon efekti** destekler; Bounce, PathFootball ve Zoom gibi temel efektlerin yanı sıra OLEObjectShow ve OLEObjectOpen gibi özel efektler de bulunur. Tam listeyi [EffectType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttype/) enumarasyonunda bulabilirsiniz.

Ayrıca bu animasyon efektleri aşağıdaki davranışlarla birleştirilebilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SetEffect)

## **Özel Animasyon**

Davranışları ve düzenlenebilir hareket yollarını oluşturma, inceleme ve değiştirme için tam JavaScript örneklerine [Custom Animation](/slides/tr/nodejs-java/custom-animation/) adresinden bakabilirsiniz.

Aspose.Slides içinde kendi **özel animasyonlarınızı** oluşturmak mümkündür. Bu, birkaç davranışı yeni bir özel animasyona birleştirerek sağlanabilir.

[Behavior](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behavior/) bir PowerPoint animasyon efektinin yapı taşıdır. Bir efekti özelleştirmek için davranışları birleştirin veya önceden tanımlı bir efekti genişletmek için bir davranış ekleyin. Tekrar, ayrı bir tekrar davranışı yerine zamanlama ayarlarıyla yapılandırılır.

[Animation Point](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/point/) bir davranışın uygulanması gereken noktadır.

## **Animasyon Zaman Çizelgesi**
[Sequence](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/) farklı şekillere hedeflenebilen animasyon efektlerinin bir koleksiyonudur.

[Timeline](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/animationtimeline/) belirli bir slaytta kullanılan bir dizi sekanstır. PowerPoint 2002'de tanıtılan bir animasyon motorudur. PowerPoint'in önceki sürümlerinde, sunumlara animasyon efekti eklemek zordu ve yalnızca çeşitli geçici çözümlerle mümkün olabiliyordu. Zaman çizelgesi, PowerPoint animasyonları için daha net bir nesne modeli sunar. Bir slaytta yalnızca bir animasyon zaman çizelgesi bulunabilir.

## **Etkileşimli Animasyon**
[Trigger](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttriggertype/) belirli bir animasyonu başlatan bir düğme tıklaması gibi kullanıcı eylemlerini tanımlamanıza olanak sağlar.

## **Şekil Animasyonu**
Aspose.Slides, metin, dikdörtgen, çizgi, çerçeve, OLE nesnesi ve daha fazlasını içerebilen şekillere animasyon uygulamanıza izin verir.

{{% alert color="info" title="Note" %}}
Daha fazla okuyun [**Şekil Animasyonu Hakkında**](/slides/tr/nodejs-java/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**
Animasyonlu grafikler oluşturmak için şekillerde kullanılan aynı sınıfları kullanmalısınız. Ancak, PowerPoint animasyonları yalnızca grafik kategorilerine veya grafik serilerine uygulanabilir. Bir kategori öğesine veya bir seri öğesine de animasyon efektleri uygulayabilirsiniz.

{{% alert color="info" title="Note" %}}
Daha fazla okuyun [**Animasyonlu Grafikler Hakkında**](/slides/tr/nodejs-java/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**
Metni animasyonlamanın yanı sıra bir paragrafa da animasyon uygulayabilirsiniz.

{{% alert color="info" title="Note" %}}
Daha fazla okuyun [**Animasyonlu Metin Hakkında**](/slides/tr/nodejs-java/animated-text/).
{{% /alert %}}

## **SSS**

**PDF'ye dışa aktarırken animasyonlar korunacak mı?**

Hayır. PDF statik bir format olduğundan animasyonlar ve [slide transitions](/slides/tr/nodejs-java/slide-transition/) oynatılmaz. Hareket gerektiriyorsa, bunun yerine [HTML5](/slides/tr/nodejs-java/export-to-html5/), [animated GIF](/slides/tr/nodejs-java/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) olarak dışa aktarın.

**Animasyonlu bir sunumu video haline getirip kare hızı ve kare boyutunu kontrol edebilir miyim?**

Evet. Sunumu [render the presentation as frames](/slides/tr/nodejs-java/convert-powerpoint-to-video/) olarak karelere dönüştürebilir ve bunları bir videoya (ör. ffmpeg ile) kodlayabilirsiniz; FPS ve çözünürlüğü seçebilirsiniz. Animasyonlar ve slayt geçişleri render sırasında oynatılır.

**ODP (sadece PPTX değil) ile çalışırken animasyonlar aynı kalır mı?**

PPT, PPTX ve ODP, [reading](/slides/tr/nodejs-java/open-presentation/) ve [writing](/slides/tr/nodejs-java/save-presentation/) için desteklenir, ancak bu animasyonların korunacağını garanti etmez. ODP'ye dönüştürülürken özel animasyon verileri kaybolabilir. Format uyumluluğunu kontrol etme konusunda örnekler ve rehberlik için [Custom Animation](/slides/tr/nodejs-java/custom-animation/) sayfasına bakın.