---
title: Android'de Sunum Görünüm Özelliklerini Getirme ve Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/androidjava/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içerik
- taslak simgeleri
- dikey ayırıcıyı yakala
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
description: "Aspose.Slides for Android via Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntüleme ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırmasıyla ilgili özellikler. Bu bilgiler, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunumun son kaydedildiği anki durumla aynı olur.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) sunumun normal görünüm özelliklerine erişim sağlamak için eklendi.  

[INormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties) arayüzleri ve bunların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType) enumu eklendi.

## **INormalViewProperties hakkında**

Normal görünüm özelliklerini temsil eder.

Metodlar [getShowOutlineIcons](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) normal görünüm modunda içerik bölgelerinden birinde taslak içeriği gösteriliyorsa uygulamanın simgeleri gösterip göstermeyeceğini belirtir.

Metodlar [getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirtir.

Özellik [getPreferSingleView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) kullanıcının üç içerik bölgesiyle standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde uygulama, içerik bölgelerinden birini tüm pencerede gösterebilir.

Metodlar [getVerticalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) yatay veya dikey ayırıcı çubuğun gösterilmesi gereken durumu belirtir. Yatay ayırıcı çubuk slaytı slayt altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler şunlardır: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metodlar [getRestoredLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) ve [getRestoredTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) normal görünümde üst veya yan slayt bölgesinin boyutlandırılmasını, [getVerticalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) için [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SplitterBarStateType#Restored) değeri uygulandığında belirtir.

## **INormalViewProperties'i Geri Yükleme Hakkında**

Normal görünümde bölge değişken bir geri yüklenmiş boyutta (ne küçültülmüş ne de büyütülmüş) olduğunda slayt bölgesinin (restoredTop çocuğu ise genişlik, restoredLeft çocuğu ise yükseklik) boyutlandırmasını belirtir.

Method [getDimensionSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) slayt bölgesinin (restoredTop çocuğu ise genişlik, restoredLeft çocuğu ise yükseklik) boyutunu belirtir.

Method [getAutoAdjust](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) yan içerik bölgesinin, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yeni boyuta göre telafi edip etmeyeceğini belirtir.

Aşağıda verilen örnek, bir sunum için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) özelliklerine nasıl erişileceğini gösterir.

```java
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

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java artık sunumu açtığınızda yakınlaştırmanın zaten ayarlı olmasını sağlayan varsayılan yakınlaştırma değerini ayarlamayı destekliyor. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) programlı olarak ayarlanabilir. Bu konuda, [Aspose.Slides](/slides/tr/) içinde bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) nasıl ayarlanır, bir örnekle göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ViewProperties) ayarlayın.
1. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin. Aşağıdaki örnekte, slayt görünümü ve not görünümü için yakınlaştırma değerini ayarladık.

```java
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

**Farklı bölümler için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) sunum düzeyinde ([Normal View](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)) tanımlanır, bölüme göre değil; bu nedenle tek bir parametre seti belge açıldığında tüm belgeye uygulanır.

**Farklı kullanıcılar için farklı görünüm durumlarını önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerini dikkate alabilir, ancak dosya kendisi tek bir görünüm özelliği seti içerir.

**Önceden tanımlı Görünüm Özelliklerine sahip bir şablon hazırlayarak yeni sunumların aynı şekilde açılmasını sağlayabilir miyim?**

Evet. [view properties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getViewProperties--) sunum düzeyinde saklandığından, bunları bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.