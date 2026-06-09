---
title: Sunum Görünüm Özelliklerini JavaScript'te Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/nodejs-java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içerik
- taslak simgeler
- dikey ayırıcı çubuğu yakala
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayar
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java görünüm özelliklerini keşfedin ve PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırmasıyla ilgili özellikler. Bu bilgiler, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar; böylece yeniden açıldığında görünüm, sunumun en son kaydedildiği durumla aynı olur.

Metod [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) sunumun normal görünüm özelliklerine erişim sağlamak için eklendi.

[NormalViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewRestoredProperties) sınıfları ve bunların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType) enumı eklendi.

## **NormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

Metodlar [getShowOutlineIcons](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) normal görünüm modunda herhangi bir içerik bölgesinde taslak içeriği görüntülenirken uygulamanın simgeleri gösterip göstermeyeceğini belirler.

Metodlar [getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma sıçramasını belirler.

Özellik [getPreferSingleView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) kullanıcının standart üç içerik bölgesiyle gelen normal görünüme göre tam pencere tek içerik bölgesi görmeyi tercih edip etmeyeceğini belirler. Etkinleştirildiğinde uygulama, içerik bölgelerinden birini tüm pencerede gösterebilir.

Metodlar [getVerticalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) yatay ya da dikey ayırıcı çubuğun hangi durumda gösterileceğini belirtir. Yatay ayırıcı çubuk slaytı slayt altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metodlar [getRestoredLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) ve [getRestoredTop](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) normal görünümde üst ya da yan slayt bölgesinin boyutlandırmasını belirtir; bu, [getVerticalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) için [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Restored) değeri uygulandığında geçerlidir.

## **NormalViewProperties Geri Yükleme Hakkında**

Bölgenin değişken bir geri yüklenmiş boyutta (ne küçültülmüş ne büyütülmüş) olduğu durumlarda normal görünümde slayt bölgesinin (üst bölge çocuğu olduğunda genişlik, yan bölge çocuğu olduğunda yükseklik) boyutlandırmasını belirtir.

Metod [getDimensionSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) slayt bölgesinin (geri yüklenmiş üst bölge çocuğu olduğunda genişlik, geri yüklenmiş sol bölge çocuğu olduğunda yükseklik) boyutunu belirtir.

Metod [getAutoAdjust](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre telafi edip etmeyeceğini belirler.

Aşağıda verilen örnek, bir sunum için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) özelliklerine nasıl erişileceğini gösterir.

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Sunumun görünüm özelliklerini geri yükle
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Varsayılan Yakınlaştırma Değerini Ayarlama**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java artık sunum için varsayılan yakınlaştırma değerinin ayarlanmasını destekler; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) programlı olarak ayarlanabilir. Bu konuda, [Aspose.Slides](/slides/tr/) içinde bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation)ın [View Properties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties) nasıl ayarlanır örnekle göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation)ın [View Properties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties) ayarlarını belirleyin.
1. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.  
   Aşağıdaki örnekte slayt görünümü ve notlar görünümü için yakınlaştırma değerini ayarladık.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Sunumun görünüm özelliklerini ayarlama
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Notlar görünümü için yüzde cinsinden yakınlaştırma değeri
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getviewproperties/) sunum seviyesinde ([Normal View](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)) tanımlanır, bölüm bazında değil, bu yüzden tek bir parametre seti belge açıldığında tüm belgeye uygulanır.

**Farklı kullanıcılar için önceden tanımlı farklı görünüm durumları belirleyebilir miyim?**

Hayır. Ayarlar dosyada depolanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerini göz önünde bulundurabilir, ancak dosyanın kendisi tek bir görünüm özelliği seti içerir.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı View Properties içeren bir şablon hazırlayabilir miyim?**

Evet. Çünkü [view properties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getviewproperties/) sunum seviyesinde saklanır; bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.