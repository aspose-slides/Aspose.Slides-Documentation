---
title: Python'da Sunum Görünüm Özelliklerini Al ve Güncelle
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
- otomatik ayar
- varsayılan yakınlaştırma
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET görünüm özelliklerini keşfedin ve PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgiler uygulamanın görüş durumunu dosyaya kaydetmesini sağlar; böylece yeniden açıldığında görünüm, sunum en son kaydedildiğinde olduğu durumda olur.

Property [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/normal_view_properties/) normal görünüm özelliklerine erişim sağlamak için eklenmiştir.  

[NormalViewProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/normalviewrestoredproperties/) sınıfları ve alt sınıfları, [SplitterBarStateType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/splitterbarstatetype/) enum’u eklenmiştir.

## **INormalViewProperties Hakkında** 

Normal görünüm özelliklerini temsil eder.

Property **ShowOutlineIcons**, normal görünüm modunda herhangi bir içerik bölgesinde taslak içeriği gösterilirken uygulamanın simge göstermesi gerektiğini belirtir.

Property **SnapVerticalSplitter**, yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirtir.

Property **PreferSingleView**, kullanıcının üç içerik bölgesiyle standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde uygulama, içerik bölgelerinden birini tüm pencerede gösterebilir.

Properties **VerticalBarState** ve **HorizontalBarState**, yatay veya dikey bölücü çubuğunun hangi durumda gösterileceğini belirtir. Yatay bölücü çubuk slaytı altındaki içerik bölgesinden ayırırken, dikey bölücü çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** ve **SplitterBarStateType.Restored**.

Properties **RestoredLeft** ve **RestoredTop**, **VerticalBarState** ve **HorizontalBarState** için **SplitterBarStateType.Restored** değeri uygulandığında normal görünümün üst veya yan slayt bölgesinin boyutlandırılmasını belirtir.

## **INormalViewProperties Geri Yükleme Hakkında**

Bölge değişken bir geri yüklenmiş boyutta (ne küçültülmüş ne de büyütülmüş) olduğunda normal görünümde slayt bölgesinin (RestoredTop’un çocuğu olduğunda genişlik, RestoredLeft’in çocuğu olduğunda yükseklik) boyutlandırılmasını belirtir.

Property **DimensionSize**, slayt bölgesinin (restoredTop’un çocuğu olduğunda genişlik, restoredLeft’in çocuğu olduğunda yükseklik) boyutunu belirtir.

Property **AutoAdjust**, pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre telafi edilip edilmeyeceğini belirtir.

Aşağıdaki örnek, bir sunum için **ViewProperties.NormalViewProperties** özelliklerine nasıl erişileceğini gösterir.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Sunumun görünüm özelliklerini geri yükle
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Varsayılan Yakınlaştırma Değerini Ayarlama**

Aspose.Slides for Python via .NET, bir sunum açıldığında yakınlaştırmanın zaten ayarlı olduğu varsayılan yakınlaştırma değerini ayarlamayı destekler. Bu, bir sunumun [view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) ayarlanarak yapılabilir. Slayt Görünüm Özellikleri ve [notes_view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/notes_view_properties/) programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde Sunumun Görünüm Özelliklerini bir örnekle nasıl ayarlayacağımızı inceleyeceğiz.

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun
2. Sunumun [view properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/) öğesini ayarlayın
3. Sunumu bir PPTX dosyası olarak yazın

Aşağıdaki örnekte, slayt görünümü ve not görünümü için yakınlaştırma değeri ayarlanmıştır.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Sunumun görünüm özelliklerini ayarlama
    presentation.view_properties.slide_view_properties.scale = 100 # Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
    presentation.view_properties.notes_view_properties.scale = 100 # Not görünümü için yüzde cinsinden yakınlaştırma değeri 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Izgara Aralığını Ayarlama**

Sunum genelindeki görünüm ayarlarına erişmek için [Presentation.view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) kullanın. [ViewProperties.grid_spacing](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/grid_spacing/) özelliği, alt düzey düzenleme ızolasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara aralığı puan cinsinden belirtilir; 72 puan bir inçtir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek mevcut bir `demo.pptx` dosyasını açar, geçerli ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Izgara, [çizim kılavuzlarından](/slides/tr/python-net/drawing-guides/) farklıdır. Izgara aralığı düzenli bir aralığı kontrol ederken, çizim kılavuzları yatay veya dikey hizalama çizgileri olarak bireysel konumlandırılır. Çizim kılavuzlarını eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Hem ızgara hem de çizim kılavuzları düzenleme yardımlarıdır. PDF, görseller, SVG veya slayt gösterisi içinde slayt içeriği olarak render edilmezler. Izgara aralığının depolanması, bir düzenleyicinin ızgarayı göstermesini garanti etmez; görünürlüğü izleyici ya da düzenleyicinin tercihine de bağlıdır.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden görünmüyor?**

Dosya ızgara aralığını depolar, ancak düzenleyici ızgaranın gösterilip gösterilmeyeceğini kontrol eder. Düzenleyicinin ızgara görünürlüğü ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**

Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek depolanan ızgara aralığını değiştirmez.

**Sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) sunum seviyesinde ([Normal View](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/slide_view_properties/)) tanımlanır, bölüm bazında değil; bu yüzden belge açıldığında tek bir parametre seti tüm belgeye uygulanır.

**Farklı kullanıcılar için önceden tanımlı farklı görünüm durumları ayarlayabilir miyim?**

Hayır. Ayarlar dosyada depolanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerini uygulayabilir, ancak dosya kendisi tek bir görünüm özelliği seti içerir.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı Görünüm Özellikleri içeren bir şablon hazırlayabilir miyim?**

Evet. [View properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) sunum seviyesinde depolandığı için, bunları bir şablona gömebilir ve yeni belgeler oluşturduğunuzda aynı başlangıç görünüm yapılandırmasını elde edebilirsiniz.