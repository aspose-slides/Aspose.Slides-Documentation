---
title: Android'de Sunum Görünüm Özelliklerini Alın ve Güncelleyin
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/androidjava/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- ana hat içeriği
- ana hat simgeleri
- dikey ayırıcı çubuğu yakala
- tek görünüm
- çubuk durumu
- boyut boyutu
- otomatik ayar
- varsayılan yaklaştırma
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slaytlarının biçimlerini özelleştirin—düzenleri, yaklaştırma seviyelerini ve görüntüleme ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırmasıyla ilgili özellikler. Bu bilgi, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar; böylece dosya yeniden açıldığında görünüm, sunum en son kaydedildiği zamandaki aynı durumda olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) yöntemi eklenmiştir.  

[INormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties) arabirimleri ve bunların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType) enum’u eklenmiştir.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

Yöntemler [getShowOutlineIcons](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) normal görünüm modunda içerik bölgelerinden birinde ana hat içeriği görüntülenirken uygulamanın simge gösterip göstermeyeceğini belirtir.

Yöntemler [getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma 'snap' yapıp yapmayacağını belirtir.

Özellikler [getPreferSingleView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) kullanıcının standart üç içerik bölgesine sahip normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencerede görüntülemeyi seçebilir.

Yöntemler [getVerticalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) yatay ya da dikey ayırıcı çubuğun hangi durumda gösterileceğini belirtir. Yatay ayırıcı çubuk slaytı slayt altındaki içerik bölgesinden, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Yöntemler [getRestoredLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) ve [getRestoredTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) [getVerticalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) için [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Restored) değeri uygulandığında normal görünümün üst ya da yan slayt bölgesinin boyutlandırmasını belirtir.

## **INormalViewProperties Yeniden Yükleme Hakkında**

Normal görünümde bölge değişken bir geri yükleme boyutunda (ne küçültülmüş ne de büyütülmüş) olduğunda, slayt bölgesinin (getRestoredTop’un çocuğu ise genişlik, getRestoredLeft’in çocuğu ise yükseklik) boyutlandırmasını belirtir.

[Yöntem] [getDimensionSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) slayt bölgesinin (restoredTop’un çocuğu ise genişlik, restoredLeft’in çocuğu ise yükseklik) boyutunu belirtir.

[Yöntem] [getAutoAdjust](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) pencere boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre telafi edip etmeyeceğini belirtir.

Aşağıda verilen bir örnek, bir sunum için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) özelliklerine nasıl erişileceğini gösterir.

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

Aspose.Slides for Android via Java artık sunumun varsayılan yaklaştırma değerini ayarlamayı destekliyor; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) programmatically olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesinin [Görünüm Özelliklerini](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) nasıl ayarlanır, bir örnekle göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. [Görünüm Özelliklerini](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) için ayarlayın.  
1. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.  
   Aşağıdaki örnekte, slayt görünümü ve notlar görünümü için yakınlaştırma değerini ayarladık.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Sunumun görünüm özelliklerini ayarlama
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Slayt görünümü için yüzde olarak yakınlaştırma değeri
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Notlar görünümü için yüzde olarak yakınlaştırma değeri

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Izgara Aralığını Ayarlama**

[Presentation.getViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) ve [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) yöntemleri temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara aralığı puan cinsinden belirtilir; 72 puan bir inçtir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

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

Izgara ve çizim kılavuzları düzenleme yardımcılarıdır. PDF, resim, SVG veya slayt gösterisi gibi çıktılarda slayt içeriği olarak render edilmezler. Izgara aralığını depolamak, bir düzenleyicinin ızgarayı gösterip göstermeyeceğini garanti etmez; görünürlük, izleyici veya düzenleyicinin tercihine de bağlıdır.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden görünmüyor?**  
Dosya ızgara aralığını saklar, ancak ızgaranın gösterilip gösterilmeyeceği düzenleyici tarafından kontrol edilir. Düzenleyicinin ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek depolanmış ızgara aralığını etkilemez.

**Sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**  
[Görünüm ayarları](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) sunum seviyesinde tanımlanır (Normal View / Slide View), bölüm bazında değil; bu yüzden bir belge açıldığında tek bir parametre seti tüm belgeye uygulanır.

**Farklı kullanıcılar için önceden tanımlı farklı görünüm durumları oluşturabilir miyim?**  
Hayır. Ayarlar dosyada saklanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerine saygı gösterebilir, ancak dosyada yalnızca tek bir görünüm özelliği seti bulunur.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı Görünüm Özellikleriyle bir şablon hazırlayabilir miyim?**  
Evet. [Görünüm özellikleri](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) sunum seviyesinde saklandığından, bir şablona gömülerek yeni belgeler aynı başlangıç görünüm yapılandırmasıyla oluşturulabilir.