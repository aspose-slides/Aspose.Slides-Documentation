---
title: Java'da Sunum Görünüm Özelliklerini Getirme ve Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içerik
- taslak simgeler
- dikey ayırıcıyı yakala
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayar
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slaytlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slaytın kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgi uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm sunum en son kaydedildiği zamanki aynı durumda olur.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) sunumun normal görünüm özelliklerine erişim sağlamak için eklenmiştir.  

[INormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties) arayüzleri ve bunların alt tipleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType) enumu eklendi.

## **INormalViewProperties hakkında**

Normal görünüm özelliklerini temsil eder.

Methodlar [getShowOutlineIcons](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) normal görünüm modunda içerik bölgelerinden birinde taslak içeriği gösteriliyorsa uygulamanın simgeleri gösterip göstermeyeceğini belirler.

Methodlar [getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirler.

Özellik [getPreferSingleView](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) kullanıcının üç içerik bölgesiyle standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirler. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencerede göstermeyi seçebilir.

Methodlar [getVerticalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) yatay veya dikey ayırıcı çubuğun gösterilmesi gereken durumu belirtir. Yatay ayırıcı çubuk slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler şunlardır: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Restored).

Methodlar [getRestoredLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) ve [getRestoredTop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) [getVerticalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) için [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Restored) değeri uygulandığında normal görünümün üst veya yan slayt bölgesinin boyutlandırmasını belirtir.

## **INormalViewProperties geri yükleme hakkında**

Normal görünümde, bölge değişken bir geri yüklenmiş boyutta (ne küçültülmüş ne genişletilmiş) olduğunda slayt bölgesinin (restoredTop çocuğu olduğunda genişlik, restoredLeft çocuğu olduğunda yükseklik) boyutlandırmasını belirtir.

Method [getDimensionSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) slide bölgesi (restoredTop çocuğu olduğunda genişlik, restoredLeft çocuğu olduğunda yükseklik) boyutunu belirtir.

Method [getAutoAdjust](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre telafi edilip edilmemesi gerektiğini belirtir.

Aşağıda verilen örnek, bir sunumun [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) özelliklerine nasıl erişileceğini gösterir.

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
Aspose.Slides for Java artık sunumun varsayılan yakınlaştırma değerini ayarlamayı destekliyor; böylece sunum açıldığında yakınlaştırma önceden ayarlanmış oluyor. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) nesnesinin [View Properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties) nasıl ayarlanır bir örnekle göreceğiz.
{{% /alert %}} 

Sunum özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) nesnesinin [View Properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties) özelliğini ayarlayın.  
1. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.  
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

[Presentation.getViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) metodunu kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iviewproperties/#getGridSpacing--) ve [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) metodları temel düzenleme ızolasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara aralığı nokta cinsindendir; 72 nokta bir inçe eşittir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

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

Izgara, [çizim kılavuzlarından](/slides/tr/java/drawing-guides/) farklıdır. Izgara aralığı düzenli bir mesafeyi kontrol eder, çizim kılavuzları ise ayrı ayrı yerleştirilen yatay veya dikey hizalama çizgileridir. Çizim kılavuzları eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Izgara ve çizim kılavuzları düzenleme yardımcılarıdır. PDF, görüntü, SVG veya slayt gösterisi gibi çıktılarda slayt içeriği olarak işlenmezler. Izgara aralığını depolamak, bir editörün ızgarayı gösterip göstermeyeceğini garanti etmez; görünürlük ayrıca izleyicinin veya editörün tercihine bağlıdır.

## **Sunum Açılırken Yorumları Göster veya Gizle**

[Presentation.getViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) metodunu kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties.getShowComments](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iviewproperties/#getShowComments--) ve [IViewProperties.setShowComments](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) metodları, yorumların PowerPoint veya başka bir uyumlu editörde sunum açıldığında gösterilip gösterilmeyeceğine ilişkin saklanan tercihi okur veya değiştirir.

Bu ayar yalnızca saklanan görünüm tercihini kontrol eder. Yorumları eklemez, kaldırmaz, düzenlemez veya çözmez. Yorumları gizlemek içeriklerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları değiştiren işlemler için [Sunum Yorumları](/slides/tr/java/presentation-comments/) bölümüne bakın.

Aşağıdaki örnek, yorumları içeren mevcut bir `comments.pptx` dosyası gerektirir. Mevcut görünürlük ayarını yazdırır, yorumların gizlenmesini ister ve yorumları kaldırmadan yeni bir PPTX kaydeder. Ayrıca [IViewProperties.setLastView](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iviewproperties/#setLastView-int-) metodunu [ViewType.SlideView](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewtype/#SlideView) ile birlikte kullanarak yorum görünürlüğüyle birlikte başlangıç düzenleme görünümünü yapılandırır.

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

Bu ayar, yorumların PDF, HTML, görüntü, notlar veya el ilanı dışa aktarımlarına dahil edilip edilmediğini belirlemez. İlgili dışa aktarma seçeneklerini ayrı ayrı yapılandırın.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden görünmüyor?**  
Dosya ızgara aralığını saklar, ancak editör ızgaranın gösterilip gösterilmeyeceğini kontrol eder. Editörün ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek saklanan ızgara aralığını değiştirmez.

**Sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**  
[View settings](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) sunum seviyesinde tanımlanır ([Normal View](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), bölüm bazında değil; bu nedenle belge açıldığında tüm belgeye tek bir parametre seti uygulanır.

**Farklı kullanıcılar için önceden tanımlı farklı görünüm durumları belirleyebilir miyim?**  
Hayır. Ayarlar dosyada saklanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerine saygı gösterebilir, ancak dosya tek bir görünüm özelliği seti içerir.

**Yeni sunumların aynı şekilde açılmasını sağlayacak önceden tanımlı Görünüm Özellikleriyle bir şablon hazırlayabilir miyim?**  
Evet. [View properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) sunum seviyesinde saklandığı için bunları bir şablona gömebilir ve yeni belgeleri aynı başlangıç görünüm yapılandırmasıyla oluşturabilirsiniz.