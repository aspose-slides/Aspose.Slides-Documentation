---
title: ".NET'te Sunum Görünüm Özelliklerini Getirme ve Güncelleme"
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/net/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içerik
- taslak ikonlar
- dikey ayırıcıyı yakala
- tek görünüm
- çubuk durumu
- boyut
- otomatik ayarlama
- varsayılan yaklaştırma
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgiler uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunum son kaydedildiğinde olduğu durumla aynı olur.

Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/iviewproperties/properties/normalviewproperties) sunumun normal görünüm özelliklerine erişim sağlamak için eklenmiştir.  

[INormalViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/inormalviewrestoredproperties) arayüzleri ve bunların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/net/aspose.slides/splitterbarstatetype) enumu eklenmiştir.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

Property **ShowOutlineIcons**, normal görünüm modunda içerik bölgelerinden herhangi birinde taslak içeriği görüntülenirken uygulamanın ikon gösterip göstermeyeceğini belirtir.

Property **SnapVerticalSplitter**, yan bölge yeterince küçük olduğunda dikey ayırıcının küçültülmüş bir duruma geçip geçmeyeceğini belirtir.

Property **PreferSingleView**, kullanıcının üç içerik bölgesine sahip standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencere içinde gösterebilir.

Properties **VerticalBarState** ve **HorizontalBarState**, yatay ya da dikey ayırıcı çubuğunun gösterilmesi gereken durumu belirtir. Yatay ayırıcı çubuk, slaytı slayt altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** ve **SplitterBarStateType.Restored**.

Properties **RestoredLeft** ve **RestoredTop**, **VerticalBarState** ve **HorizontalBarState** için **SplitterBarStateType.Restored** değeri uygulandığında normal görünümde üst ya da yan slayt bölgesinin boyutlandırılmasını belirtir.

## **INormalViewProperties Kurtarılması Hakkında**

Bölge değişken bir kurtarılmış boyutta (ne küçültülmüş ne de büyütülmüş) olduğunda, normal görünümün slayt bölgesinin (RestoredTop çocuğu olduğunda genişlik, RestoredLeft çocuğu olduğunda yükseklik) boyutlandırılmasını belirtir.

Property **DimensionSize**, slayt bölgesinin (restoredTop çocuğu olduğunda genişlik, restoredLeft çocuğu olduğunda yükseklik) boyutunu belirtir.

Property **AutoAdjust**, yan içerik bölgesinin, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yeni boyuta göre telafi edip etmeyeceğini belirtir.

Aşağıdaki örnek, bir sunum için **ViewProperties.NormalViewProperties** özelliklerine nasıl erişileceğini gösterir.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Sunumun görüş özelliklerini geri yükle
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Varsayılan Yakınlaştırma Değerini Ayarla**

Aspose.Slides for .NET artık bir sunum açıldığında yakınlaştırmanın zaten ayarlanmış olmasını sağlayan varsayılan yakınlaştırma değerini ayarlamayı destekliyor. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties) ayarlanarak yapılabilir. Slide View Properties yanı sıra [NotesViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/properties/notesviewproperties) da programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde Sunumun Görünüm Özelliklerinin nasıl ayarlanacağını bir örnekle göreceğiz.

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun
2. Sunumun Görünüm [Properties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties) ayarlarını belirleyin
3. Sunumu PPTX dosyası olarak kaydedin

Aşağıdaki örnekte, slayt görünümü ve not görünümü için yakınlaştırma değerini ayarladık.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Sunumun görünüm özelliklerini ayarlama
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Not görünümü için yüzde cinsinden yakınlaştırma değeri 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/viewproperties/) sunum seviyesinde ([Normal View](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/slideviewproperties/)) tanımlanır, bölüm bazında değil, bu nedenle bir kez açıldığında tüm belgeye tek bir parametre seti uygulanır.

**Farklı kullanıcılar için önceden tanımlı farklı görünüm durumları oluşturabilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşılan bir şekilde bulunur. Görüntüleyici uygulamalar kullanıcı tercihlerini göz önünde bulundurabilir, ancak dosyanın kendisi tek bir görünüm özelliği seti içerir.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı Görünüm Özelliklerine sahip bir şablon hazırlayabilir miyim?**

Evet. [view properties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/viewproperties/) sunum seviyesinde saklandığı için bunları bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.