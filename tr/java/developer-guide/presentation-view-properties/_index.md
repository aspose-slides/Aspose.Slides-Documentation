---
title: Java'da Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- ana hat içeriği
- ana hat simgeleri
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
description: "Aspose.Slides for Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—yerleşim, yakınlaştırma seviyeleri ve görüntüleme ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasına ilişkin özellikler. Bu bilgiler uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar; böylece dosya yeniden açıldığında görünüm, sunum en son kaydedildiğinde olduğu durumla aynı olur.

Metot [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) sunumun normal görünüm özelliklerine erişim sağlamak için eklenmiştir.

[INormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties) arayüzleri ve bunların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType) enumu eklendi.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

Methodlar [getShowOutlineIcons](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) uygulamanın, normal görünüm modunda içerik bölgelerinden birinde anahat içeriği görüntüleniyorsa simgeleri gösterip göstermeyeceğini belirler.

Methodlar [getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş duruma yapışıp yapışmayacağını belirler.

Özellik [getPreferSingleView](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) kullanıcının, standart normal görünümdeki üç içerik bölgesi yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmeyeceğini belirler. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencerede görüntülemeyi seçebilir.

Methodlar [getVerticalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) yatay veya dikey bölücü çubuğunun hangi durumda gösterileceğini belirtir. Yatay bölücü çubuk slaytı slayt altındaki içerik bölgesinden, dikey bölücü çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Restored).

Methodlar [getRestoredLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) ve [getRestoredTop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) Normal görünümde üst veya yan slayt bölgesinin boyutlandırmasını belirtir; bu, [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Restored) değeri [getVerticalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) için uygulandığında geçerlidir.

## **INormalViewProperties Geri Yükleme Hakkında**

Normal görünümde, bölge değişken bir geri yüklenmiş boyutta (ne küçültülmüş ne de büyütülmüş) olduğunda, slayt bölgesinin (getRestoredTop'un çocuğu olduğunda genişlik, getRestoredLeft'in çocuğu olduğunda yükseklik) boyutlandırmasını belirtir.

Method [getDimensionSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) slayt bölgesinin boyutunu (restoredTop'un çocuğu olduğunda genişlik, restoredLeft'in çocuğu olduğunda yükseklik) belirtir.

Method [getAutoAdjust](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin boyutunun yeni boyuta göre ayarlanıp ayarlanmayacağını belirler.

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

## **Varsayılan Yakınlaştırma Değerini Ayarla**

{{% alert color="info" %}} 

Aspose.Slides for Java artık sunum için varsayılan yakınlaştırma değerini ayarlamayı destekliyor; böylece sunum açıldığında yakınlaştırma zaten ayarlı olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) programlı olarak ayarlanabilir. Bu konuda, bir örnekle [Aspose.Slides](/slides/tr/) içinde [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) öğesinin [View Properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties) nasıl ayarlanır göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties) ayarlayın.
1. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.
   Aşağıda verilen örnekte, slayt görünümü ve not görünümü için yakınlaştırma değeri ayarlanmıştır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Sunumun görünüm özelliklerini ayarlama
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Not görünümü için yüzde cinsinden yakınlaştırma değeri 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

### Bir sunumun farklı bölümleri için farklı görüntü ayarları belirleyebilir miyim?

[View settings](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) sunum seviyesinde ([Normal View](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)) tanımlanır, bölüm bazında değil; bu nedenle belge açıldığında tek bir parametre kümesi tüm belgeye uygulanır.

### Farklı kullanıcılar için farklı görüntü durumlarını önceden tanımlayabilir miyim?

Hayır. Ayarlar dosyada saklanır ve paylaşıldır. Görüntüleyici uygulamalar kullanıcı tercihlerine uyabilir, ancak dosya kendisi yalnız bir görüntü özelliği kümesi içerir.

### Önceden tanımlı View Properties ile bir şablon hazırlayıp yeni sunumların aynı şekilde açılmasını sağlayabilir miyim?

Evet. [view properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) sunum seviyesinde depolandığı için, bunları bir şablona ekleyebilir ve aynı başlangıç görüntü yapılandırmasıyla yeni belgeler oluşturabilirsiniz.