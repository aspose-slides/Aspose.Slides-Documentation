---
title: Python'da Sunum Görünüm Özelliklerini Alın ve Güncelleyin
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/python-net/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içerik
- taslak simgeler
- dikey bölücüyü yakala
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayarlama
- varsayılan yakınlaştırma
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET görünüm özelliklerini keşfedin ve PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntüleme ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: kaydır kendisi, yan bir içerik bölgesi ve alt bir içerik bölgesi. Farklı içerik bölgelerinin konumlandırmasıyla ilgili özellikler. Bu bilgiler, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunum en son kaydedildiği zamanki durumda olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/normal_view_properties/) özelliği eklenmiştir. 

[NormalViewProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/normalviewrestoredproperties/) sınıfları ve bunların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/splitterbarstatetype/) enumu eklenmiştir.

## **INormalViewProperties Hakkında** 

Normal görünüm özelliklerini temsil eder.

**ShowOutlineIcons** özelliği, normal görünüm modunda herhangi bir içerik bölgesinde taslak içeriği gösteriliyorsa uygulamanın simgeleri gösterip göstermeyeceğini belirler.

**SnapVerticalSplitter** özelliği, yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş bir duruma sıkışıp tutunup tutmayacağını belirler.

**PreferSingleView** özelliği, kullanıcının standart üç içerik bölgesi içeren normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirler. Etkinleştirildiğinde uygulama, içerik bölgelerinden birini tüm pencerede gösterebilir.

**VerticalBarState** ve **HorizontalBarState** özellikleri, yatay veya dikey bölücü çubuğunun gösterileceği durumu belirler. Yatay bölücü çubuğu slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey bölücü çubuğu slaytı yan içerik bölgesinden ayırır. Olası değerler: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** ve **SplitterBarStateType.Restored**.

**RestoredLeft** ve **RestoredTop** özellikleri, **VerticalBarState** ve **HorizontalBarState** için **SplitterBarStateType.Restored** değeri uygulandığında normal görünümde üst veya yan slayt bölgesinin boyutlandırmasını belirler.

## **INormalViewProperties Geri Yükleme Hakkında**

Normal görünümde bölgenin değişken geri yüklenmiş bir boyuta (küçültülmemiş ve büyütülmemiş) sahip olduğu zaman (RestoredTop’un çocuğu ise genişlik, RestoredLeft’ın çocuğu ise yükseklik) slayt bölgesinin boyutlandırmasını belirtir.

**DimensionSize** özelliği, slayt bölgesinin (restoredTop’un çocuğu ise genişlik, restoredLeft’ın çocuğu ise yükseklik) boyutunu belirtir.

**AutoAdjust** özelliği, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta uyum sağlayıp sağlamayacağını belirler.

Aşağıda verilen örnek, bir sunum için **ViewProperties.NormalViewProperties** özelliklerine nasıl erişileceğini gösterir.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Sunumun görünüm özelliklerini geri yükle
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Varsayılan Yakınlaştırma Değerini Ayarla**

Aspose.Slides for Python via .NET artık bir sunum için varsayılan yakınlaştırma değerini ayarlamayı destekler; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) ayarlanarak yapılabilir. Slayt Görünüm Özellikleri ve [notes_view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/notes_view_properties/) programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde bir sunumun Görünüm Özelliklerini nasıl ayarlayacağınızı bir örnekle göreceğiz.

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun
1. Sunumun [view properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/) ayarlayın
1. Sunumu bir PPTX dosyası olarak yazın

Aşağıdaki örnekte, slayt görünümü ve not görünümü için yakınlaştırma değerini ayarladık.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Sunumun görünüm özelliklerini ayarlama
    presentation.view_properties.slide_view_properties.scale = 100 # Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
    presentation.view_properties.notes_view_properties.scale = 100 # Not görünümü için yüzde cinsinden yakınlaştırma değeri 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**  
[Görünüm ayarları](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) sunum seviyesinde ([Normal Görünüm](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slayt Görünümü](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/slide_view_properties/)) tanımlanır, bölüm bazında değil, bu nedenle bir set parametre belge açıldığında tüm belgeye uygulanır.

**Farklı kullanıcılar için farklı görünüm durumları önceden tanımlayabilir miyim?**  
Hayır. Ayarlar dosyada depolanır ve paylaşılandır. Görüntüleyici uygulamalar kullanıcı tercihlerini göz önünde bulundurabilir, ancak dosya kendisi yalnızca bir set görünüm özelliği içerir.

**Yeni sunumlar aynı şekilde açılsın diye önceden tanımlanmış Görünüm Özellikleriyle bir şablon hazırlayabilir miyim?**  
Evet. Çünkü [görünüm özellikleri](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) sunum seviyesinde depolandığından, bunları bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.