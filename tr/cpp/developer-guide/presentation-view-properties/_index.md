---
title: C++'ta Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/cpp/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- anahat içeriği
- anahat simgeleri
- dikey ayırıcı çubuğunu yakala
- tek görünüm
- çubuk durumu
- boyut boyutu
- otomatik ayarlama
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm, slayt, yan içerik bölgesi ve alt içerik bölgesi olmak üzere üç içerik bölgesinden oluşur. Farklı içerik bölgelerinin konumlandırılmasına ilişkin özellikler. Bu bilgiler uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunum en son kaydedildiğinde olduğu durumla aynı olur.

Method [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) sunumun normal görünüm özelliklerine erişim sağlamak için eklendi.  

[INormalViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inormalviewrestoredproperties/) arabirimleri ve onların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/splitterbarstatetype/) enumu eklendi.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

Property **ShowOutlineIcons** uygulamanın normal görünüm modunda herhangi bir içerik bölgesinde anahat içeriği gösterildiğinde simgeleri göstermesi gerekip gerekmediğini belirtir.

Property **SnapVerticalSplitter** yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma yapışıp yapışmayacağını belirtir.

Property **PreferSingleView** kullanıcının standart üç içerik bölgesi olan normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde uygulama, içerik bölgelerinden birini tüm pencerede gösterebilir.

Property **VerticalBarState** ve **HorizontalBarState**, yatay veya dikey ayırıcı çubuğun hangi durumda gösterileceğini belirtir. Yatay ayırıcı çubuk slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** ve **SplitterBarStateType.Restored**.

Property **RestoredLeft** ve **RestoredTop**, **VerticalBarState** ve **HorizontalBarState** için **SplitterBarStateType.Restored** değeri uygulandığında normal görünümde üst veya yan slayt bölgesinin boyutlandırılmasını belirtir.

## **INormalViewProperties Geri Yükleme Hakkında**

Normal görünümde, bölge değişken bir geri yüklenmiş boyutta (küçültülmüş ya da büyütülmüş değil) olduğunda slayt bölgesinin boyutlandırılmasını (RestoredTop alt öğesi olduğunda genişlik, RestoredLeft alt öğesi olduğunda yüksekliği) belirtir.

Property **DimensionSize** slayt bölgesinin (RestoredTop alt öğesi olduğunda genişlik, RestoredLeft alt öğesi olduğunda yükseklik) boyutunu belirtir.

Property **AutoAdjust** görünümün içinde bulunduğu pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre telafi edip etmeyeceğini belirtir.

Aşağıdaki örnek, bir sunum için **ViewProperties.NormalViewProperties** özelliklerine nasıl erişileceğini gösterir.

```cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Sunumun görünüm özelliklerini geri yükle
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Varsayılan Yakınlaştırma Değerini Ayarlama**

Aspose.Slides for C++ artık sunumun varsayılan yakınlaştırma değerini ayarlamayı destekliyor; böylece sunum açıldığında yakınlaştırma önceden ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/) ayarlanarak yapılabilir. Slayt Görünüm Özellikleri ve [get_NotesViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/get_notesviewproperties/) programlı olarak ayarlanabilir. Bu konuda, bir örnekle Aspose.Slides içinde Sunumun Görünüm Özelliklerinin nasıl ayarlanacağını göreceğiz.

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun
2. Sunumun Görünüm [Properties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/) ayarını belirleyin
3. Sunumu PPTX dosyası olarak kaydedin

Aşağıdaki örnekte, slayt görünümü ve notlar görünümü için yakınlaştırma değerini ayarladık.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Sunumun görünüm özelliklerini ayarlama
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Slayt görünümü için yüzde olarak yakınlaştırma değeri
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Notlar görünümü için yüzde olarak yakınlaştırma değeri

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **SSS**

**Sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_viewproperties/) sunum seviyesinde ([Normal View](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/get_slideviewproperties/)) tanımlanır, bölüm bazında değil; bu nedenle tek bir parametre kümesi, belge açıldığında tüm belgeye uygulanır.

**Farklı kullanıcılar için farklı görünüm durumları önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerini dikkate alabilir, ancak dosya kendisi tek bir görünüm özelliği kümesi içerir.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı Görünüm Özelliklerine sahip bir şablon hazırlayabilir miyim?**

Evet. [view properties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_viewproperties/) sunum seviyesinde saklandığı için, bunları bir şablona yerleştirerek yeni belgeler oluşturduğunuzda aynı başlangıç görünüm yapılandırmasıyla açılır.