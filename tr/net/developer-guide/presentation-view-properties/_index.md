---
title: .NET'te Sunum Görünüm Özelliklerini Getirme ve Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/net/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içerik
- taslak simgeler
- dikey bölücüyü yakala
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
description: "Aspose.Slides for .NET görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve gösterim ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırmasıyla ilgili özellikler. Bu bilgi uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunum en son kaydedildiği zamanki aynı durumda olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/iviewproperties/properties/normalviewproperties) özelliği eklenmiştir.  

[INormalViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/inormalviewrestoredproperties) arayüzleri ve onların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/net/aspose.slides/splitterbarstatetype) enumu eklenmiştir.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

**ShowOutlineIcons** özelliği, normal görünüm modunda içeriğin taslak gösterildiği herhangi bir içerik bölgesinde uygulamanın simgeleri gösterip göstermeyeceğini belirtir.

**SnapVerticalSplitter** özelliği, yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirtir.

**PreferSingleView** özelliği, kullanıcının standart üç içerik bölgesiyle normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencere içinde gösterebilir.

**VerticalBarState** ve **HorizontalBarState** özellikleri, yatay veya dikey ayırıcı çubuğun hangi durumda gösterileceğini belirler. Yatay ayırıcı çubuk slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** ve **SplitterBarStateType.Restored**.

**RestoredLeft** ve **RestoredTop** özellikleri, **VerticalBarState** ve **HorizontalBarState** için **SplitterBarStateType.Restored** değeri uygulandığında normal görünümün üst veya yan slayt bölgesinin boyutlandırılmasını belirtir.

## **INormalViewProperties Yeniden Yüklenmesi Hakkında**

Normal görünümde bölgenin değişken bir yeniden yüklenmiş boyutta (ne küçültülmüş ne de büyütülmüş) olduğu durumda slayt bölgesinin (RestoredTop çocuğu ise genişlik, RestoredLeft çocuğu ise yükseklik) boyutlandırılmasını belirtir.

**DimensionSize** özelliği, slayt bölgesinin (restoredTop çocuğu ise genişlik, restoredLeft çocuğu ise yükseklik) boyutunu belirtir.

**AutoAdjust** özelliği, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre ayarlanıp ayarlanmayacağını belirtir.

Aşağıda verilen bir örnek, bir sunum için **ViewProperties.NormalViewProperties** özelliklerine nasıl erişileceğini gösterir.

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

Aspose.Slides for .NET artık bir sunumun varsayılan yakınlaştırma değerinin ayarlanmasını destekliyor; böylece sunum açıldığında yakınlaştırma zaten ayarlı olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties) ayarlanarak yapılabilir. Slayt Görünüm Özellikleri ve [NotesViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/properties/notesviewproperties) programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde bir sunumun Görünüm Özelliklerinin nasıl ayarlanacağını bir örnekle göreceğiz.

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun
1. Sunumun Görünüm [Properties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties) ayarlarını belirleyin
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

[Presentation.ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/viewproperties/) kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties.GridSpacing](https://reference.aspose.com/slides/tr/net/aspose.slides/iviewproperties/gridspacing/) özelliği, temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tek bir slayt için değil, tüm sunum için geçerlidir. Izgara aralığı, 72 puan bir inç olacak şekilde puan cinsinden belirtilir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek, mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

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

Izgara, [çizim kılavuzlarından](/slides/tr/net/drawing-guides/) farklıdır. Izgara aralığı düzenli bir aralığı kontrol ederken, çizim kılavuzları ayrı ayrı konumlandırılmış yatay veya dikey hizalama çizgileridir. Çizim kılavuzlarını eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Izgara ve çizim kılavuzları her ikisi de düzenleme yardımcılarıdır. PDF, görüntüler, SVG veya bir slayt gösterisinde slayt içeriği olarak işlenmezler. Izgara aralığının depolanması, bir düzenleyicinin ızgarayı göstereceğinin garantisi değildir; görünürlüğü aynı zamanda izleyici veya düzenleyicinin tercihine bağlıdır.

## **SSS**

**Sunumu tekrar açtıktan sonra ızgara neden görünmüyor?**  
Dosya ızgara aralığını saklar, ancak düzenleyici ızgaranın görüntülenip görüntülenmeyeceğini kontrol eder. Düzenleyicinin ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek saklanan ızgara aralığını aynı bırakır.

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**  
[View settings](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/viewproperties/) sunum seviyesinde ([Normal View](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/slideviewproperties/)) tanımlanır, bölüm bazında değil; bu nedenle bir parametre seti belge açıldığında tüm belgeye uygulanır.

**Farklı kullanıcılar için farklı görünüm durumlarını önceden tanımlayabilir miyim?**  
Hayır. Ayarlar dosyada saklanır ve paylaşımlıdır. Görüntüleyici uygulamalar kullanıcı tercihlerini göz önünde bulundurabilir, ancak dosya kendisi yalnızca tek bir görünüm özelliği seti içerir.

**Önceden tanımlanmış Görünüm Özellikleriyle bir şablon hazırlayabilir ve yeni sunumların aynı şekilde açılmasını sağlayabilir miyim?**  
Evet. [view properties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/viewproperties/) sunum seviyesinde depolandığı için, bunları bir şablona yerleştirip aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.