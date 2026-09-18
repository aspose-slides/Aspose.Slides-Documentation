---
title: PHP'de Animasyonlarla PowerPoint Sunumlarını Geliştirin
linktitle: PowerPoint Animasyonu
type: docs
weight: 150
url: /tr/php-java/powerpoint-animation/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'in PowerPoint animasyonlarını yönetme yeteneklerini keşfedin. Sunumlarınızı geliştirmek için temel özellikler ve içgörüler."
---
## **Giriş**

Sunumların bir şeyi sunmak için tasarlandığı göz önüne alındığında, görsel görünümleri ve etkileşimli davranışları oluşturulurken her zaman dikkate alınır.

**PowerPoint animasyonu** bir sunumu izleyiciler için göz alıcı ve ilgi çekici hâle getirmede önemli bir rol oynar. Aspose.Slides for PHP via Java, PowerPoint sunumlarına animasyon eklemek için geniş bir seçenek yelpazesi sunar:

- Şekillere, grafiklere, tablolara, OLE nesnelerine ve diğer sunum öğelerine çeşitli PowerPoint animasyon efekti türlerini uygulayın.
- Tek bir şekil üzerinde birden çok PowerPoint animasyon efekti kullanın.
- Animasyon efektlerini kontrol etmek için animasyon zaman çizelgesini kullanın.
- Özel animasyonlar oluşturun.

Aspose.Slides for PHP via Java'da çeşitli animasyon efektleri şekillere uygulanabilir. Metin, resimler, OLE nesneleri ve tablolar dahil bir slayttaki her öğe şekil olarak kabul edildiğinden, animasyon efektleri slayttaki herhangi bir öğeye uygulanabilir.

## **Animasyon Efektleri**
Aspose.Slides **150+ animasyon efekti**'ni destekler; Bounce, PathFootball ve Zoom gibi temel efektlerin yanı sıra OLEObjectShow ve OLEObjectOpen gibi özel efektler de bulunur. Tam listeye [EffectType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effecttype/) sınıfında erişebilirsiniz.

Ek olarak, bu animasyon efektleri aşağıdaki davranışlarla birleştirilebilir:

- [RenkEfekti](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ColorEffect)
- [KomutEfekti](https://reference.aspose.com/slides/tr/php-java/aspose.slides/CommandEffect)
- [FiltreEfekti](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FilterEffect)
- [HareketEfekti](https://reference.aspose.com/slides/tr/php-java/aspose.slides/MotionEffect)
- [ÖzellikEfekti](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PropertyEffect)
- [DöndürmeEfekti](https://reference.aspose.com/slides/tr/php-java/aspose.slides/RotationEffect)
- [ÖlçekEfekti](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ScaleEffect)
- [AyarEfekti](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SetEffect)

## **Özel Animasyon**
Davranışları ve düzenlenebilir hareket yollarını oluşturma, inceleme ve değiştirme konularına yönelik eksiksiz PHP örnekleri için [Özel Animasyon](/slides/tr/php-java/custom-animation/) sayfasına bakın.

Aspose.Slides'te kendi **özel animasyonlarınızı** oluşturmak mümkündür. Bu, birden fazla davranışı yeni bir özel animasyona birleştirerek gerçekleştirilebilir.

[Behavior](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behavior/) PowerPoint animasyon efektinin bir yapı taşıdır. Efekti özelleştirmek için davranışları birleştirin veya önceden tanımlı bir efekti genişletmek için bir davranış ekleyin. Tekrar, ayrı bir tekrar davranışı yerine zamanlama ayarlarıyla yapılandırılır.

[Animation Point](https://reference.aspose.com/slides/tr/php-java/aspose.slides/point/) bir davranışın uygulanması gereken noktadır.

## **Animasyon Zaman Çizelgesi**
[Sequence](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/) farklı şekilleri hedefleyebilen animasyon efektlerinin bir koleksiyonudur.

[Timeline](https://reference.aspose.com/slides/tr/php-java/aspose.slides/animationtimeline/) belirli bir slaytta kullanılan bir dizi sekansın kümesidir. PowerPoint 2002'de tanıtılan bir animasyon motorudur. PowerPoint'in önceki sürümlerinde, sunumlara animasyon efektleri eklemek zordu ve çeşitli geçici çözümlerle ancak mümkün olabiliyordu. Zaman çizelgesi, PowerPoint animasyonları için daha net bir nesne modeli sunar. Bir slaytta yalnızca bir animasyon zaman çizelgesi bulunabilir.

## **Etkileşimli Animasyon**
[Trigger](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effecttriggertype/) belirli bir animasyonu başlatan bir düğme tıklaması gibi kullanıcı eylemlerini tanımlamanıza olanak verir.

## **Şekil Animasyonu**
Aspose.Slides, metin, dikdörtgen, çizgi, çerçeve, OLE nesneleri ve daha fazlasını içerebilen şekillere animasyon uygulamanıza olanak tanır.

{{% alert color="info" title="Note" %}}
Daha fazla okuyun [**Şekil Animasyonu Hakkında**](/slides/tr/php-java/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**
Animasyonlu grafikler oluşturmak için şekillerde kullanılan aynı sınıfları kullanmalısınız. Ancak, PowerPoint animasyonları yalnızca grafik kategorilerine veya grafik serilerine uygulanabilir. Bir kategori öğesine veya bir seri öğesine de animasyon efektleri uygulayabilirsiniz.

{{% alert color="info" title="Note" %}}
Daha fazla okuyun [**Animasyonlu Grafikler Hakkında**](/slides/tr/php-java/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**
Metni animasyonlamanın yanı sıra bir paragrafa da animasyon uygulayabilirsiniz.

{{% alert color="info" title="Note" %}}
Daha fazla okuyun [**Animasyonlu Metin Hakkında**](/slides/tr/php-java/animated-text/).
{{% /alert %}}

## **SSS**

**PDF'ye dışa aktarırken animasyonlar korunur mu?**

Hayır. PDF statik bir format olduğundan animasyonlar ve [slayt geçişleri](/slides/tr/php-java/slide-transition/) oynatılmaz. Hareket gerekiyorsa bunun yerine [HTML5](/slides/tr/php-java/export-to-html5/), [animasyonlu GIF](/slides/tr/php-java/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/php-java/convert-powerpoint-to-video/) formatına dışa aktarın.

**Animasyonlu bir sunumu videoya dönüştürüp kare hızı ve kare boyutunu kontrol edebilir miyim?**

Evet. Sunumu [çerçeveler olarak işleyebilir](/slides/tr/php-java/convert-powerpoint-to-video/) ve bunları bir videoya (örneğin ffmpeg ile) kodlayarak FPS ve çözünürlüğü seçebilirsiniz. İşleme sırasında animasyonlar ve slayt geçişleri oynatılır.

**ODP (sadece PPTX değil) ile çalışırken animasyonlar aynı kalır mı?**

PPT, PPTX ve ODP, [okuma](/slides/tr/php-java/open-presentation/) ve [yazma](/slides/tr/php-java/save-presentation/) için desteklenir, ancak bu animasyonların korunacağını garanti etmez. Özel animasyon verileri ODP'ye dönüştürülürken kaybolabilir. Biçim uyumluluğunu kontrol etmek için örnekler ve rehberlik amacıyla [Özel Animasyon](/slides/tr/php-java/custom-animation/) sayfasına bakın.