---
title: Python’da Sunum Görünüm Özelliklerini Getirme ve Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/python-net/presentation-view-properties/
keywords: 
- görüntü özellikleri
- normal görünüm
- anahat içeriği
- anahat ikonları
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
description: "Aspose.Slides for Python via .NET görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgiler uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar; böylece yeniden açıldığında görünüm, sunum en son kaydedildiğinde olduğu durumla aynı olur.

[ViewProperties.normal_view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/normal_view_properties/) özelliği, sunumun normal görünüm özelliklerine erişim sağlamak için eklendi. 

[NormalViewProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/normalviewrestoredproperties/) sınıfları ve onların türetilmişleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/splitterbarstatetype/) enumu eklendi.

## **INormalViewProperties Hakkında** 

Normal görünüm özelliklerini temsil eder.

**ShowOutlineIcons** özelliği, normal görünüm modundaki herhangi bir içerik bölgesinde anahat içeriği görüntülenirken uygulamanın simgeleri gösterip göstermeyeceğini belirtir.

**SnapVerticalSplitter** özelliği, yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş bir duruma sıkışıp sıkışmayacağını belirler.

**PreferSingleView** özelliği, kullanıcının üç içerik bölgesiyle standart normal görünüm yerine tek pencere tam içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencerede göstermeyi seçebilir.

**VerticalBarState** ve **HorizontalBarState** özellikleri, yatay veya dikey bölücü çubuğunun hangi durumda gösterileceğini belirler. Yatay bölücü çubuğu slaytı slayt altındaki içerik bölgesinden ayırırken, dikey bölücü çubuğu slaytı yan içerik bölgesinden ayırır. Olası değerler: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** ve **SplitterBarStateType.Restored**.

**RestoredLeft** ve **RestoredTop** özellikleri, **VerticalBarState** ve **HorizontalBarState** için **SplitterBarStateType.Restored** değeri uygulandığında normal görünümde üst veya yan slayt bölgesinin boyutlandırılmasını belirler.

## **INormalViewProperties'ı Geri Yükleme Hakkında**

Bölgenin değişken bir geri yüklenmiş boyutta (ne küçültülmüş ne de büyütülmüş) olduğu durumda normal görünümde slayt bölgesinin (RestoredTop’un çocuğu ise genişlik, RestoredLeft’in çocuğu ise yükseklik) boyutlandırılmasını belirtir. 

**DimensionSize** özelliği, slayt bölgesinin (restoredTop'un çocuğu ise genişlik, restoredLeft'in çocuğu ise yükseklik) boyutunu belirler.

**AutoAdjust** özelliği, pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta uyum sağlayıp sağlamayacağını belirler.

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

## **Varsayılan Yakınlaştırma Değerini Ayarla**

Aspose.Slides for Python via .NET artık sunum için varsayılan yakınlaştırma değerinin ayarlanmasını destekler; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) ayarlanarak yapılabilir. Slayt Görünüm Özellikleri ve [notes_view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/notes_view_properties/) programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde Sunumun Görünüm Özelliklerinin nasıl ayarlanacağını bir örnekle göreceğiz.

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun
1. Sunumun [view properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/) ayarlarını yapın
1. Sunumu PPTX dosyası olarak yazın

Aşağıdaki örnekte, slayt görünümü ve not görünümü için yakınlaştırma değeri ayarlanmıştır.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Sunumun görünüm özelliklerini ayarlama
    presentation.view_properties.slide_view_properties.scale = 100 # Slayt görünümü için yüzde olarak yakınlaştırma değeri
    presentation.view_properties.notes_view_properties.scale = 100 # Not görünümü için yüzde olarak yakınlaştırma değeri 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Izgara Aralığını Ayarla**

Sunum genelindeki görünüm ayarlarına erişmek için [Presentation.view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) kullanın. [ViewProperties.grid_spacing](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/grid_spacing/) özelliği, temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara aralığı puan cinsinden belirtilir; 72 puan bir inçe eşittir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Izgara, [çizim kılavuzlarından](/slides/tr/python-net/drawing-guides/) farklıdır. Izgara aralığı düzenli bir aralığı kontrol ederken, çizim kılavuzları yatay veya dikey hizalama çizgileri olarak bireysel konumlandırılır. Çizim kılavuzlarını eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Izgara ve çizim kılavuzları düzenleme yardımcılarıdır. PDF, görüntüler, SVG veya bir slayt gösterisi içinde slayt içeriği olarak render edilmezler. Izgara aralığının depolanması, bir düzenleyicinin ızgarayı gösterip göstermeyeceğini garanti etmez; görünürlük aynı zamanda izleyici veya düzenleyicinin tercihine bağlıdır.

## **Sunum Açılırken Yorumları Göster veya Gizle**

Sunum genelindeki görünüm ayarlarına erişmek için [Presentation.view_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) kullanın. [ViewProperties.show_comments](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/show_comments/) öğesini okuyarak veya değiştirerek, PowerPoint veya uyumlu bir editörde sunum açıldığında yorumların gösterilip gösterilmeyeceği tercihinin saklanmasını sağlarsınız.

Bu ayar yalnızca saklanan görünüm tercihini kontrol eder. Yorumları eklemez, kaldırmaz, düzenlemez veya çözmez. Yorumları gizlemek, içeriklerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları değiştiren işlemler için [Presentation Comments](/slides/tr/python-net/presentation-comments/) bölümüne bakın.

Aşağıdaki örnek, yorumlar içeren mevcut bir `comments.pptx` dosyası gerektirir. Mevcut görünürlük ayarını yazdırır, yorumların gizlenmesini talep eder ve yorumları kaldırmadan yeni bir PPTX kaydeder. Ayrıca, yorum görünürlüğünün yanı sıra başlangıç düzenleme görünümünü yapılandırmak için [ViewProperties.last_view](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/last_view/) özelliğini [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewtype/) olarak ayarlar.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Bu ayar, yorumların PDF, HTML, görüntü, not veya el ilanı dışa aktarımlarına dahil edilip edilmeyeceğini belirlemez. İlgili dışa aktarma seçeneklerini ayrı ayrı yapılandırın.

## **SSS**

**Izgara, sunumu yeniden açtıktan sonra neden görünmüyor?**  
Dosya ızgara aralığını depolar, ancak ızgaranın gösterilip gösterilmeyeceği editör tarafından kontrol edilir. Editörün ızgara görünürlüğü ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek depolanan ızgara aralığını etkilemez.

**Farklı bölümler için farklı görünüm ayarları belirleyebilir miyim?**  
[View settings](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) sunum düzeyinde ([Normal View](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/slide_view_properties/)) tanımlanır; bölüm bazında değil. Bu nedenle, bir belge açıldığında tüm belgeye aynı parametreler uygulanır.

**Farklı kullanıcılar için önceden tanımlı farklı görünüm durumları belirleyebilir miyim?**  
Hayır. Ayarlar dosyada depolanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerine uyabilir, ancak dosya tek bir görünüm özelliği seti içerir.

**Yeni sunumların aynı şekilde açılmasını sağlayacak önceden tanımlı Görünüm Özellikleri içeren bir şablon hazırlayabilir miyim?**  
Evet. [view properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/view_properties/) sunum düzeyinde depolandığından, bunları bir şablona gömebilir ve yeni belgeler oluştururken aynı başlangıç görünüm yapılandırmasını kullanabilirsiniz.