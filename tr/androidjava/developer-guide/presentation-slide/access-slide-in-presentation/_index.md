---
title: Android'de Sunum Slaytlarına Erişim
linktitle: Slayta Erişim
type: docs
weight: 20
url: /tr/androidjava/access-slide-in-presentation/
keywords:
- slayta erişim
- slayt indeksi
- slayt kimliği
- slayt konumu
- konumu değiştir
- slayt özellikleri
- slayt numarası
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint ve OpenDocument sunumlarındaki slaytlara nasıl erişileceğini ve yönetileceğini öğrenin. Java kod örnekleriyle verimliliği artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir sunumdaki slaytlara nasıl erişileceğini ve yönetileceğini açıklar. Slayt koleksiyonundan sıfır tabanlı indeksle slaytları nasıl alacağınızı ve `getSlideById` yöntemiyle bir slaytı benzersiz kimliğiyle nasıl erişeceğinizi gösterir.

Ayrıca, `setSlideNumber` yöntemiyle bir slaytın konumunu nasıl değiştireceğinizi ve `setFirstSlideNumber` yöntemiyle bir sunumun başlangıç slayt numarasını nasıl tanımlayacağınızı öğreneceksiniz. Örnekler, bir sunumu yüklemeyi, slayt referansları almayı, slayt sırasını veya numaralandırmasını güncellemeyi ve değiştirilmiş sunumu kaydetmeyi gösterir.

## **Indeks ile Slayta Erişim**

Bir sunumdaki tüm slaytlar, slayt konumuna göre 0’dan başlayarak sayısal olarak sıralanır. İlk slayt 0 indeksinden erişilebilir; ikinci slayt 1 indeksinden erişilir; vb.

Sunum dosyasını temsil eden Presentation sınıfı, tüm slaytları bir [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) ( [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) nesnelerinin koleksiyonu) olarak sunar. Bu Java kodu, bir slayta indeksine göre nasıl erişileceğini gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
Presentation pres = new Presentation("demo.pptx");
try {
    // Slaytı slayt indeksiyle erişir
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **ID ile Slayta Erişim**

Bir sunumdaki her slayt, ona özgü benzersiz bir kimliğe sahiptir. Bu kimliği hedeflemek için [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı tarafından sunulan [getSlideById](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlideById-long-) yöntemini kullanabilirsiniz. Bu Java kodu, geçerli bir slayt kimliği nasıl sağlanır ve [getSlideById](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlideById-long-) yöntemiyle o slayta nasıl erişilir gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
Presentation pres = new Presentation("demo.pptx");
try {
    // Bir slayt kimliği alır
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Slaytı kimliğiyle erişir
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Slayt Konumunu Değiştirme**

Aspose.Slides, bir slayt konumunu değiştirmenize izin verir. Örneğin, ilk slaytın ikinci slayt olması gerektiğini belirtebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Konumunu değiştirmek istediğiniz slaytın referansını indeks yoluyla alın
1. Slayt için yeni bir konum belirlemek üzere [setSlideNumber](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#setSlideNumber-int-) özelliğini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Bu Java kodu, konum 1'deki slaytın konum 2'ye taşındığı bir işlemi gösterir: 

```java
// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Konumu değiştirilecek slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Slayt için yeni konumu ayarlar
    sld.setSlideNumber(2);
    
    // Değiştirilmiş sunumu kaydeder
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

İlk slayt ikinci oldu; ikinci slayt birinci oldu. Bir slaytın konumunu değiştirdiğinizde, diğer slaytlar otomatik olarak ayarlanır.

## **Slayt Numarasını Ayarlama**

[setFirstSlideNumber](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) özelliğini ([Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı tarafından sunulan) kullanarak, bir sunumdaki ilk slayt için yeni bir numara belirleyebilirsiniz. Bu işlem diğer slayt numaralarının yeniden hesaplanmasına sebep olur.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayt numarasını alın.
1. Slayt numarasını ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Bu Java kodu, ilk slayt numarasının 10 olarak ayarlandığı bir işlemi gösterir: 

```java
// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Slayt numarasını alır
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Slayt numarasını ayarlar
    pres.setFirstSlideNumber(10);
	
    // Değiştirilmiş sunumu kaydeder
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

İlk slaytı atlamak istiyorsanız, numaralandırmaya ikinci slayttan başlayabilir (ve ilk slayt için numaralandırmayı gizleyebilirsiniz) şu şekilde:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Sunumun ilk slaytı için numarayı ayarlar
    presentation.setFirstSlideNumber(0);

    // Tüm slaytlar için slayt numaralarını gösterir
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // İlk slayt için slayt numarasını gizler
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Değiştirilmiş sunumu kaydeder
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **SSS**

**Kullanıcının gördüğü slayt numarası, koleksiyonun sıfır tabanlı indeksine eşleşir mi?**

Bir slaytta gösterilen numara keyfi bir değerden (ör. 10) başlayabilir ve indeksle eşleşmek zorunda değildir; ilişki, sunumun [first slide number](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ayarıyla kontrol edilir.

**Gizli slaytlar indekslemeyi etkiler mi?**

Evet. Gizli bir slayt koleksiyonda kalır ve indekslemeye dahil edilir; "gizli" ifadesi görüntülenmeye ilişkin olup, koleksiyondaki konumunu etkilemez.

**Bir slaytın indeksi, diğer slaytlar eklendiğinde veya kaldırıldığında değişir mi?**

Evet. İndeksler her zaman slaytlardaki mevcut sıralamayı yansıtır ve ekleme, silme ve taşıma işlemleri sırasında yeniden hesaplanır.