---
title: JavaScript'te Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/nodejs-java/presentation-view-properties/
keywords:
- görünüm özellikleri
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
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java view properties'ı keşfedin ve PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgi, uygulamanın görünüm durumunu dosyaya kaydetmesine olanak tanır, böylece yeniden açıldığında görünüm, sunum en son kaydedildiğinde olduğu durumla aynı olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) yöntemi eklenmiştir.

[NormalViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewRestoredProperties) sınıfları ve onların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType) enumu eklendi.

## **NormalViewProperties hakkında**

Normal görünüm özelliklerini temsil eder.

[getShowOutlineIcons](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) yöntemleri, normal görünüm modunda herhangi bir içerik bölgesinde anahat içeriği görüntüleniyorsa uygulamanın simge gösterip göstermeyeceğini belirler.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) yöntemleri, yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirler.

[getPreferSingleView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) özelliği, kullanıcının üç içerik bölgesine sahip standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirler. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencerede göstermeyi seçebilir.

[getVerticalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) yöntemleri, yatay veya dikey ayırıcı çubuğun hangi durumda gösterileceğini belirtir. Yatay ayırıcı çubuk slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

[getRestoredLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) ve [getRestoredTop](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) yöntemleri, [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Restored) değeri, [getVerticalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) için uygulandığında normal görünümde üst veya yan slayt bölgesinin boyutlandırılmasını belirtir.

## **NormalViewProperties'i Geri Yükleme Hakkında**

Normal görünümde slayt bölgesinin (üst bölge çocuğu olduğunda genişlik, yan bölge çocuğu olduğunda yükseklik) boyutlandırılmasını, bölge değişken bir geri yüklenmiş boyutta (hem küçültülmemiş hem de büyütülmemiş) olduğunda belirtir.

[getDimensionSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) yöntemi, slayt bölgesinin (restoredTop çocuğu olduğunda genişlik, restoredLeft çocuğu olduğunda yükseklik) boyutunu belirtir.

[getAutoAdjust](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) yöntemi, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin boyutunun yeni boyuta göre otomatik ayarlanıp ayarlanmayacağını belirtir.

Aşağıda verilen örnek, bir sunum için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) özelliklerine nasıl erişileceğini gösterir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Varsayılan Yakınlaştırma Değerini Ayarla**

{{% alert color="info" %}} 
Aspose.Slides for Node.js via Java artık sunumun varsayılan yakınlaştırma değerini ayarlamayı destekliyor; böylece sunum açıldığında yakınlaştırma önceden ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation)un [View Properties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties) nasıl ayarlanır örnekle göreceğiz.
{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation)un [View Properties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties) ayarlayın.
1. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın. Aşağıda verilen örnekte, slayt görünümü ve not görünümü için yakınlaştırma değeri ayarlanmıştır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Sunumun görünüm özelliklerini ayarlama
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Slayt görünümü için yüzde olarak yakınlaştırma değeri
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Not görünümü için yüzde olarak yakınlaştırma değeri
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Izgara Aralığını Ayarla**

[Presentation.getViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getViewProperties--) kullanarak sunum genelindeki görünüm ayarlarına erişin. [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) ve [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) yöntemleri, alttaki düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar, tek bir slayt yerine tüm sunuma uygulanır. Izgara aralığı nokta cinsinden belirtilir; 72 nokta bir inçe eşittir. API belgelendirmesinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Izgara, [drawing guides](/slides/tr/nodejs-java/drawing-guides/) öğesinden farklıdır. Izgara aralığı düzenli bir aralığı kontrol eder, çizim kılavuzları ise ayrı ayrı konumlandırılmış yatay veya düşey hizalama çizgileridir. Çizim kılavuzlarını eklemek, taşımak veya silmek ızgara aralığını değiştirmez.

Izgara ve çizim kılavuzları her ikisi de düzenleme yardımcılarıdır. PDF, görüntüler, SVG veya slayt gösterisi içinde slayt içeriği olarak render edilmezler. Izgara aralığını depolamak, bir düzenleyicinin ızgarayı göstereceğini garanti etmez; görünürlüğü ayrıca görüntüleyicinin veya düzenleyicinin tercihine bağlıdır.

## **Sunum Açılırken Yorumları Göster ya da Gizle**

[Presentation.getViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getViewProperties--) kullanarak sunum genelindeki görünüm ayarlarına erişin. [ViewProperties.getShowComments](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/#getShowComments--) ve [ViewProperties.setShowComments](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte--) kullanarak, PowerPoint veya başka bir uyumlu düzenleyicide sunum açıldığında yorumların gösterilip gösterilmeyeceğine dair kayıtlı tercihi okuyabilir veya değiştirebilirsiniz.

Bu ayar yalnızca kayıtlı görünüm tercihini kontrol eder. Yorumları eklemez, kaldırmaz, düzenlemez veya çözüme kavuşturmaz. Yorumları gizlemek, içeriklerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları değiştiren işlemler için [Presentation Comments](/slides/tr/nodejs-java/presentation-comments/) bölümüne bakın.

Aşağıdaki örnek, yorum içeren mevcut bir `comments.pptx` dosyasına ihtiyaç duyar. Mevcut görünürlük ayarını yazdırır, yorumların gizlenmesini ister ve yorumları kaldırmadan yeni bir PPTX dosyası kaydeder. Ayrıca yorum görünürlüğüyle birlikte başlangıç düzenleme görünümünü yapılandırmak için [ViewProperties.setLastView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) ve [ViewType.SlideView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewtype/#SlideView) kullanır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu ayar, yorumların PDF, HTML, resim, not veya el kitabı dışa aktarımlarına dahil edilip edilmediğini belirlemez. İlgili dışa aktarım seçeneklerini ayrı ayrı yapılandırın.

## **SSS**

**Sunumu yeniden açtıktan sonra ızgara neden görünmüyor?**  
Dosya ızgara aralığını depolar, ancak ızgaranın gösterilip gösterilmeyeceği düzenleyici tarafından kontrol edilir. Düzenleyicinin ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını silmek ızgara aralığını değiştirir mi?**  
Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek, depolanan ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**  
[View settings](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getviewproperties/) sunum düzeyinde ([Normal View](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)) tanımlanır, bölüm bazında değil, bu nedenle belgenin tamamına tek bir parametre seti uygulanır.

**Farklı kullanıcılar için farklı görünüm durumları önceden tanımlanabilir mi?**  
Hayır. Ayarlar dosyada depolanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerini dikkate alabilir, ancak dosya kendisi yalnızca bir set görünüm özelliği içerir.

**Yeni sunumların aynı şekilde açılmasını sağlamak için önceden tanımlanmış View Properties içeren bir şablon hazırlayabilir miyim?**  
Evet. [view properties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getviewproperties/) sunum düzeyinde depolandığından, bunları bir şablona gömebilir ve yeni belgeleri aynı başlangıç görünüm yapılandırmasıyla oluşturabilirsiniz.