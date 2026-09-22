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
- dikey bölücüyü yakala
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
description: "Aspose.Slides for Java görünüm özelliklerini keşfedin, PPT, PPTX ve ODP slaytlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntüleme ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgi, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar; böylece yeniden açıldığında görünüm, sunum en son kaydedildiği zamanki aynı durumda olur.

Yöntem [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) sunumun normal görünüm özelliklerine erişim sağlamak için eklenmiştir.

[INormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties) arayüzleri ve onların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType) enum'i eklenmiştir.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

Metodlar [getShowOutlineIcons](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean--) normal görünüm modundaki içerik bölgelerinden birinde taslak içeriği görüntüleniyorsa uygulamanın simgeleri gösterip göstermeyeceğini belirler.

Metodlar [getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş bir duruma sıçramasını belirler.

Özellik [getPreferSingleView](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) kullanıcının üç içerik bölgesine sahip standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirler. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencereye gösterebilir.

Metodlar [getVerticalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) yatay veya dikey bölücü çubuğunun gösterileceği durumu belirtir. Yatay bölücü çubuğu slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey bölücü çubuğu slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Restored).

Metodlar [getRestoredLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) ve [getRestoredTop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Restored) değeri [getVerticalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) için uygulandığında normal görünümde üst veya yan slayt bölgesinin boyutlandırmasını belirtir.

## **INormalViewProperties Geri Yükleme Hakkında**

Normal görünümde bölge değişken bir geri yüklenmiş boyutta (ne küçültülmüş ne de büyütülmüş) olduğunda, slayt bölgesinin (üst bölgenin çocuğu olduğunda genişliği, yan bölgenin çocuğu olduğunda yüksekliği) boyutlandırılmasını belirtir.

Metod [getDimensionSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) slayt bölgesinin (restoredTop çocuğu olduğunda genişlik, restoredLeft çocuğu olduğunda yükseklik) boyutunu belirtir.

Metod [getAutoAdjust](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin boyutunun yeni boyuta göre ayarlanıp ayarlanmayacağını belirler.

Aşağıda verilen bir örnek, bir sunum için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) özelliklerine nasıl erişileceğini göstermektedir.

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

Aspose.Slides for Java artık sunumun açıldığında yakınlaştırmanın zaten ayarlı olduğu şekilde varsayılan yakınlaştırma değerini ayarlamayı destekliyor. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) programmatically olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties) nasıl ayarlanacağını bir örnekle göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties) ayarlayın.
3. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.
   Aşağıdaki örnekte, slayt görünümü ve notlar görünümü için yakınlaştırma değerini ayarladık.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Sunumun görünüm özelliklerini ayarlama
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Slayt görünümü için yüzde olarak yakınlaştırma değeri
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Not görünümü için yüzde olarak yakınlaştırma değeri 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Izgara Aralığını Ayarlama**

[Presentation.getViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iviewproperties/#getGridSpacing--) ve [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) metodları temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara aralığı puan cinsinden belirtilir; 72 puan bir inçtir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek, mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

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

Izgara, [çizim kılavuzlarından](/slides/tr/java/drawing-guides/) farklıdır. Izgara aralığı düzenli bir aralığı kontrol eder, çizim kılavuzları ise ayrı ayrı konumlandırılmış yatay veya dikey hizalama çizgileridir. Çizim kılavuzları eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Izgara ve çizim kılavuzları her ikisi de düzenleme yardımcılarıdır. PDF, görüntüler, SVG veya slayt gösterisinde slayt içeriği olarak işlenmezler. Izgara aralığını depolamak, bir düzenleyicinin ızgarayı göstereceğini garanti etmez; görünürlüğü yine görüntüleyici veya düzenleyicinin tercihine bağlıdır.

## **SSS**

**Sunumu yeniden açtıktan sonra ızgara neden görünmüyor?**

Dosya ızgara aralığını saklar, ancak düzenleyici ızgaranın gösterilip gösterilmeyeceğini kontrol eder. Düzenleyicinin ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**

Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek, depolanan ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) sunum düzeyinde ([Normal View](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)) tanımlanır, bölüm bazında değil; bu nedenle açıldığında tüm belgeye tek bir parametre seti uygulanır.

**Farklı kullanıcılar için farklı görünüm durumlarını önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerini dikkate alabilir, ancak dosya kendisi tek bir görünüm özelliği seti içerir.

**Yeni sunumların aynı şekilde açılmasını sağlayacak önceden tanımlı View Properties içeren bir şablon hazırlayabilir miyim?**

Evet. [View properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) sunum düzeyinde saklandığı için, bunları bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.