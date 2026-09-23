---
title: Android'de Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/androidjava/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içeriği
- taslak simgeleri
- dikey ayırıcı yakalama
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayarlama
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgi, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunumun son kaydedildiği andaki durumla aynı olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) yöntemi eklenmiştir.  

[INormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties) arayüzleri ve alt sınıfları, [SplitterBarStateType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType) enumu eklenmiştir.

## **INormalViewProperties hakkında**

Normal görünüm özelliklerini temsil eder.

[getShowOutlineIcons](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) yöntemleri, normal görünüm modunda içerik bölgelerinden birinde taslak içeriği gösterilirken uygulamanın simgeleri gösterip göstermeyeceğini belirtir.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) yöntemleri, yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirtir.

[getPreferSingleView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) kullanıcıların, üç içerik bölgesine sahip standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencere içinde göstermeyi seçebilir.

[getVerticalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) yatay veya dikey ayırıcı çubuğun hangi durumda gösterileceğini belirtir. Bir yatay ayırıcı çubuk slaytı slaytın altındaki içerik bölgesinden ayırırken, bir dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

[getRestoredLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) ve [getRestoredTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) normal görünümde, bölge [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Restored) değeri [getVerticalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) için uygulandığında üst veya yan slayt bölgesinin boyutlandırılmasını belirtir.

## **INormalViewProperties Restorasyonu Hakkında**

Normal görünümde, bölgeler değişken bir restore boyutunda (ne küçültülmüş ne de büyütülmüş) olduğunda slayt bölgesinin (getRestoredTop'un çocuğu olduğunda genişlik, getRestoredLeft'in çocuğu olduğunda yükseklik) boyutunu belirtir.

[getDimensionSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) slayt bölgesinin (restoredTop'un çocuğu olduğunda genişlik, restoredLeft'in çocuğu olduğunda yükseklik) boyutunu belirtir.

[getAutoAdjust](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) yan içerik bölgesinin boyutunun, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yeni boyuta uyum sağlayıp sağlamayacağını belirtir.

Aşağıda verilen örnek, bir sunum için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) özelliklerine nasıl erişileceğini gösterir.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Sunumun görünüm özelliklerini geri yükle
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Varsayılan Yakınlaştırma Değerini Ayarlama**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java artık bir sunumun varsayılan yakınlaştırma değerini ayarlamayı destekliyor; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) programatik olarak ayarlanabilir. Bu konuda, Aspose.Slides'te bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesinin [View Properties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) nasıl ayarlanır, bir örnekle göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) ayarlayın.  
3. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.  
   Aşağıdaki örnekte, slayt görünümü ve notlar görünümü için yakınlaştırma değerini ayarladık.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Sunumun görünüm özelliklerini ayarlama
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Notlar görünümü için yüzde cinsinden yakınlaştırma değeri 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Izgara Aralığını Ayarlama**

[Presentation.getViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) ve [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) yöntemleri temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara aralığı, 72 noktanın bir inçe eşit olduğu puan cinsinden belirtilir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Izgara, [çizim kılavuzlarından](/slides/tr/androidjava/drawing-guides/) farklıdır. Izgara aralığı düzenli bir aralığı kontrol eder, çizim kılavuzları ise yatay veya dikey hizalama çizgileri olarak bireysel konumlandırılır. Çizim kılavuzlarını eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Izgara ve çizim kılavuzları her ikisi de düzenleme yardımcılarındandır. PDF, görüntüler, SVG veya slayt gösterisinde slayt içeriği olarak işlenmezler. Izgara aralığını depolamak, bir düzenleyicinin ızgarayı göstereceğini garanti etmez; görünürlüğü ayrıca görüntüleyici veya düzenleyicinin tercihine bağlıdır.

## **Sunum Açılırken Yorumları Gösterme veya Gizleme**

[Presentation.getViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) kullanarak sunum genelindeki görünüm ayarlarına erişin. Yorumların PowerPoint veya başka bir uyumlu düzenleyicide açıldığında gösterilip gösterilmeyeceğiyle ilgili depolanan tercihi okumak veya değiştirmek için [IViewProperties.getShowComments](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) ve [IViewProperties.setShowComments](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) yöntemlerini kullanın.

Bu ayar yalnızca depolanan görünüm tercihini kontrol eder. Yorum ekleme, silme, düzenleme veya çözümleme işlemlerini gerçekleştirmez. Yorumları gizlemek, içeriklerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları değiştiren işlemler için [Presentation Comments](/slides/tr/androidjava/presentation-comments/) sayfasına bakın.

Aşağıdaki örnek, yorum içeren mevcut bir `comments.pptx` dosyasını gerektirir. Mevcut görünürlük ayarını yazdırır, yorumların gizlenmesini talep eder ve yorumları kaldırmadan yeni bir PPTX kaydeder. Ayrıca, yorum görünürlüğüyle birlikte ilk düzenleme görünümünü yapılandırmak için [IViewProperties.setLastView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) ve [ViewType.SlideView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewtype/#SlideView) kullanır.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu ayar, yorumların PDF, HTML, görüntü, not veya el ilanı dışa aktarımlarına dahil edilip edilmediğini belirlemez. İlgili dışa aktarım seçeneklerini ayrı olarak yapılandırın.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden görünmüyor?**  
Dosya ızgara aralığını depolar, ancak ızgaranın gösterilip gösterilmediğini düzenleyici kontrol eder. Düzenleyicinin ızgara görünürlüğü ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek, depolanan ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**  
[Görünüm ayarları](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) sunum düzeyinde tanımlanır ([Normal View](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), bölüme göre değil; bu nedenle belge açıldığında tüm belgeye tek bir parametre kümesi uygulanır.

**Farklı kullanıcılar için farklı görünüm durumları önceden tanımlayabilir miyim?**  
Hayır. Ayarlar dosyada depolanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerini göz önünde bulundurabilir, ancak dosya kendisi tek bir görünüm özelliği kümesi içerir.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı Görünüm Özellikleriyle bir şablon hazırlayabilir miyim?**  
Evet. [Görünüm özellikleri](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) sunum düzeyinde depolandığı için, bunları bir şablona yerleştirerek yeni belgeler oluşturduğunuzda aynı başlangıç görünüm yapılandırması kullanılabilir.