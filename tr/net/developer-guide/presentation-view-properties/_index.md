---
title: .NET'te Sunum Görünüm Özelliklerini Alın ve Güncelleyin
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/net/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- anahat içeriği
- anahat simgeleri
- dikey ayırıcıyı yakala
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayar
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in görüntü özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgi, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm sunumun son kaydedildiği durumla aynı olur.

Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/iviewproperties/properties/normalviewproperties) presentation'ın normal görünüm özelliklerine erişim sağlamak için eklenmiştir.

[INormalViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/inormalviewrestoredproperties) arabirimleri ve türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/net/aspose.slides/splitterbarstatetype) enumu eklendi.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

Property **ShowOutlineIcons**, normal görünüm modundaki herhangi bir içerik bölgesinde anahat içeriği görüntüleniyorsa uygulamanın simge gösterip göstermeyeceğini belirtir.

Property **SnapVerticalSplitter**, yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma geçip geçmeyeceğini belirtir.

Property **PreferSingleView**, kullanıcının üç içerik bölgesine sahip standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencere içinde göstermeyi seçebilir.

Properties **VerticalBarState** ve **HorizontalBarState**, yatay veya dikey ayırıcı çubuğun gösterilmesi gereken durumu belirtir. Yatay ayırıcı çubuk slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler şunlardır: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** ve **SplitterBarStateType.Restored**.

Properties **RestoredLeft** ve **RestoredTop**, **VerticalBarState** ve **HorizontalBarState** için **SplitterBarStateType.Restored** değeri uygulandığında normal görünümde üst veya yan slayt bölgesinin boyutlandırılmasını belirtir.

## **INormalViewProperties Geri Yükleme Hakkında**

Normal görünümde bölge değişken bir geri yüklenmiş boyutta (küçültülmüş ya da büyütülmüş olmayan) olduğunda slayt bölgesinin (RestoredTop'un çocuğu ise genişlik, RestoredLeft'in çocuğu ise yükseklik) boyutlandırılmasını belirtir.

Property **DimensionSize**, slayt bölgesinin boyutunu (restoredTop'un çocuğu ise genişlik, restoredLeft'in çocuğu ise yükseklik) belirtir.

Property **AutoAdjust**, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre ayarlanıp ayarlanmayacağını belirtir.

Aşağıda verilen örnek, bir sunum için **ViewProperties.NormalViewProperties** özelliklerine nasıl erişileceğini gösterir.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Sunumun görünüm özelliklerini geri yükle
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Varsayılan Yakınlaştırma Değerini Ayarlama**

Aspose.Slides for .NET artık sunum için varsayılan yakınlaştırma değerinin ayarlanmasını destekliyor; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties) ayarlanarak yapılabilir. Slayt Görünüm Özellikleri ve [NotesViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/properties/notesviewproperties) programmatically olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde bir sunumun Görünüm Özelliklerini nasıl ayarlayacağınızı bir örnekle göreceğiz.

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun
1. Sunumun View [Properties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties) ayarını yapın
1. Sunumu PPTX dosyası olarak kaydedin

Aşağıda verilen örnekte, slayt görünümü ve not görünümü için yakınlaştırma değerini ayarladık.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Sunumun görünüm özelliklerini ayarlama
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Not görünümü için yüzde cinsinden yakınlaştırma değeri 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Izgara Aralığını Ayarlama**

[Presentation.ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/viewproperties/) kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties.GridSpacing](https://reference.aspose.com/slides/tr/net/aspose.slides/iviewproperties/gridspacing/) özelliği temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara aralığı puan cinsinden belirtilir; 72 puan bir inçe eşittir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Izgara, [drawing guides](/slides/tr/net/drawing-guides/) ile aynı değildir. Izgara aralığı düzenli bir aralığı kontrol eder, çizim kılavuzları ise yatay veya dikey hizalama çizgileri olarak ayrı ayrı konumlandırılır. Çizim kılavuzlarını eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Hem ızgara hem de çizim kılavuzları düzenleme yardımcılarındandır. PDF, resimler, SVG veya bir slayt gösterisinde slayt içeriği olarak işlenmezler. Izgara aralığının depolanması bir editörün ızgarayı göstermesini garanti etmez; görünürlük aynı zamanda görüntüleyicinin veya editörün tercihine bağlıdır.

## **Sunum Açılırken Yorumları Göster veya Gizle**

[Presentation.ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/viewproperties/) kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties.ShowComments](https://reference.aspose.com/slides/tr/net/aspose.slides/iviewproperties/showcomments/) okunarak veya değiştirilerek, PowerPoint veya uyumlu başka bir editörde sunum açıldığında yorumların gösterilip gösterilmeyeceği tercihi depolanır.

Bu ayar yalnızca depolanan görünüm tercihini kontrol eder. Yorum ekleme, kaldırma, düzenleme veya çözümleme yapmaz. Yorumları gizlemek içeriklerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumların kendisini değiştiren işlemler için [Presentation Comments](/slides/tr/net/presentation-comments/) sayfasına bakın.

Aşağıdaki örnek, yorum içeren mevcut bir `comments.pptx` dosyası gerektirir. Mevcut görünürlük ayarını yazdırır, yorumların gizlenmesini ister ve hiçbir yorumu kaldırmadan yeni bir PPTX kaydeder. Ayrıca yorum görünürlüğüyle birlikte başlangıç düzenleme görünümünü yapılandırmak için [IViewProperties.LastView](https://reference.aspose.com/slides/tr/net/aspose.slides/iviewproperties/lastview/) özelliğini [ViewType.SlideView](https://reference.aspose.com/slides/tr/net/aspose.slides/viewtype/) olarak ayarlar.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Bu ayar, yorumların PDF, HTML, resim, not veya el ilanı dışa aktarımlarına dahil edilip edilmeyeceğini belirlemez. İlgili dışa aktarım seçeneklerini ayrı ayrı yapılandırın.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden görünmüyor?**

Dosya ızgara aralığını depolar, ancak ızgaranın görüntülenip görüntülenmeyeceği editör tarafından kontrol edilir. Editörün ızgara görünürlüğü ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**

Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek depolanan ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/viewproperties/) sunum seviyesinde tanımlanır ([Normal View](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/slideviewproperties/)), bölüm bazında değil, bu yüzden bir belge açıldığında tek bir parametre seti tüm belgeye uygulanır.

**Farklı kullanıcılar için farklı görünüm durumlarını önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada depolanır ve ortak kullanılır. Görüntüleyici uygulamalar kullanıcı tercihlerini dikkate alabilir, ancak dosya kendisi tek bir görünüm özelliği seti içerir.

**Önceden tanımlı Görünüm Özelliklerine sahip bir şablon hazırlayabilir miyim, böylece yeni sunumlar aynı şekilde açılsın?**

Evet. [view properties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/viewproperties/) sunum seviyesinde depolandığı için, bunları bir şablona gömerek yeni belgeler oluşturduğunuzda aynı başlangıç görünüm yapılandırması kullanılır.