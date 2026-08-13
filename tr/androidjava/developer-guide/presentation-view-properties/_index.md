---
title: Android'de Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/androidjava/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içerik
- taslak simgeleri
- dikey bölücüyü kilitle
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
description: "Aspose.Slides for Android via Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını düzenleyin."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasına ilişkin özellikler. Bu bilgi, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunum en son kaydedildiği andaki aynı durumda olur.

Yöntem [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) sunumun normal görünüm özelliklerine erişim sağlamak için eklendi.  

[INormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties) arabirimleri ve bunların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType) enumu eklendi.

## **INormalViewProperties hakkında**

Normal görünüm özelliklerini temsil eder.

Yöntemler [getShowOutlineIcons](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) normal görünüm modunda içerik bölgelerinden herhangi birinde taslak içeriği gösteriliyorsa uygulamanın simge gösterip göstermeyeceğini belirler.

Yöntemler [getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş duruma kilitlenip kilitlenmeyeceğini belirler.

Özellik [getPreferSingleView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) kullanıcının üç içerik bölgesine sahip standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirler. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencere içinde gösterebilir.

Yöntemler [getVerticalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) yatay veya düşey bölücü çubuğunun gösterileceği durumu belirtir. Yatay bölücü çubuk, slaytı slaytın altındaki içerik bölgesinden ayırırken, düşey bölücü çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Yöntemler [getRestoredLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) ve [getRestoredTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) normal görünümde üst veya yan slayt bölgesinin boyutlandırılmasını, [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Restored) değeri [getVerticalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) için uygulandığında belirtir.

## **INormalViewProperties'i Geri Yükleme Hakkında**

Normal görünümde bölgenin değişken geri yüklenmiş boyutta (küçültülmüş ya da büyütülmüş olmayan) olması durumunda, slayt bölgesinin ([getRestoredTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) çocuğu ise genişlik, [getRestoredLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) çocuğu ise yükseklik) boyutlandırılmasını belirler.

Yöntem [getDimensionSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) slayt bölgesinin (restoredTop çocuğu ise genişlik, restoredLeft çocuğu ise yükseklik) boyutunu belirtir.

Yöntem [getAutoAdjust](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) yan içerik bölgesinin, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yeni boyuta göre ayarlanıp ayarlanmayacağını belirtir.

Aşağıda verilen örnek, bir sunumun [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) özelliklerine nasıl erişileceğini gösterir.

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

Aspose.Slides for Android via Java artık sunum için varsayılan yakınlaştırma değerinin ayarlanmasını destekliyor; böylece sunum açıldığında yakınlaştırma önceden ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) programlı olarak ayarlanabilir. Bu konuda, bir örnekle [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesinin [View Properties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) özelliklerinin [Aspose.Slides](/slides/tr/) içinde nasıl ayarlanacağını göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesinin [View Properties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) ayarlarını belirleyin.
1. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın. Aşağıda verilen örnekte, slayt görünümü ve not görünümü için yakınlaştırma değerini ayarladık.

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
## **SSS**

### Sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?

[View settings](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) sunum seviyesinde ([Normal View](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)) tanımlanır, bölüm bazında değil; bu nedenle sunum açıldığında tüm belgeye tek bir parametre seti uygulanır.

### Farklı kullanıcılar için farklı görünüm durumlarını önceden tanımlayabilir miyim?

Hayır. Ayarlar dosyada depolanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerine saygı gösterebilir, ancak dosya kendisi yalnızca bir set görünüm özelliği içerir.

### Yeni sunumların aynı şekilde açılması için önceden tanımlanmış Görünüm Özellikleri içeren bir şablon hazırlayabilir miyim?

Evet. Çünkü [view properties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) sunum seviyesinde saklanır, bunları bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.