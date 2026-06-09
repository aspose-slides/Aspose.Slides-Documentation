---
title: Java'da Sunum Görünüm Özelliklerini Alıp Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/java/presentation-view-properties/
keywords: 
- görünüm özellikleri
- normal görünüm
- taslak içerik
- taslak ikonlar
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
description: "Aspose.Slides for Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntüleme ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgi uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunum son kaydedildiği zamandaki aynı durumda olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) metodu eklenmiştir.  

[INormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties) arayüzleri ve onların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType) enumu eklenmiştir.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

[**getShowOutlineIcons**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) ve [**setShowOutlineIcons**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) metodları, normal görünüm modunda herhangi bir içerik bölgesinde taslak içerik gösterilirken uygulamanın ikonları gösterip göstermeyeceğini belirtir.

[**getSnapVerticalSplitter**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) ve [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) metodları, yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirtir.

[**getPreferSingleView**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) ve [**setPreferSingleView**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) özellikleri, kullanıcının üç içerik bölgesiyle standart normal görünüm yerine tek bir içerik bölgesiyle tam pencere görünümünü tercih edip etmediğini belirtir. Etkinleştirildiğinde uygulama, içerik bölgelerinden birini tüm pencere içinde gösterebilir.

[**getVerticalBarState**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [**getHorizontalBarState**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metodları, yatay ya da dikey ayırıcı çubuğun hangi durumda gösterileceğini belirtir. Yatay ayırıcı çubuk slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Restored).

[**getRestoredLeft**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) ve [**getRestoredTop**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) metodları, [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SplitterBarStateType#Restored) değeri [**getVerticalBarState**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) ve [**getHorizontalBarState**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) için uygulandığında normal görünümün üst veya yan slayt bölgesinin boyutlandırılmasını tanımlar.

## **INormalViewProperties'in Geri Yüklenmesi Hakkında**

Normal görünümde bölgenin değişken bir geri yüklenmiş boyutta (küçültülmüş ya da büyütülmüş olmayan) olduğu durumlarda slayt bölgesinin (getRestoredTop çocuğu ise genişlik, getRestoredLeft çocuğu ise yükseklik) boyutlandırılmasını belirtir.

[getDimensionSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) yöntemi, geri yüklenmişTop çocuğu olduğunda genişlik, geri yüklenmişLeft çocuğu olduğunda yükseklik olmak üzere slayt bölgesi boyutunu belirtir.

[getAutoAdjust](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) yöntemi, pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre denge sağlanıp sağlanmayacağını belirtir.

Aşağıda verilen örnek, bir sunum için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) özelliklerine nasıl erişileceğini göstermektedir.

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

Aspose.Slides for Java artık sunumun varsayılan yakınlaştırma değerinin ayarlanmasını destekler; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) programatik olarak ayarlanabilir. Bu konuda, bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties)’i nasıl ayarlayacağımızı bir örnekle göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ViewProperties)’i ayarlayın.  
3. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.  
   Aşağıda verilen örnekte slayt görünümü ve not görünümü için yakınlaştırma değeri ayarlanmıştır.

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

**Sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) sunum seviyesinde ([Normal View](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)) tanımlanır, bölüm bazında değil, bu nedenle bir kez tanımlanan parametreler dosya açıldığında tüm belgeye uygulanır.

**Farklı kullanıcılar için farklı görünüm durumlarını önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerini dikkate alabilir, ancak dosya kendisi tek bir görünüm özelliği seti içerir.

**Yeni sunumların aynı şekilde açılmasını sağlamak için önceden tanımlı Görünüm Özelliklerine sahip bir şablon hazırlayabilir miyim?**

Evet. [View properties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getViewProperties--) sunum seviyesinde saklandığından, bunları bir şablona gömebilir ve yeni belgeleri aynı başlangıç görünüm yapılandırmasıyla oluşturabilirsiniz.