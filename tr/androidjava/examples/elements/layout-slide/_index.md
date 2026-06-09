---
title: Düzen Slaytı
type: docs
weight: 20
url: /tr/androidjava/examples/elements/layout-slide/
keywords:
- kod örneği
- düzen slaytı
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'da ana düzen slaytları: PPT, PPTX ve ODP sunumları için Java örnekleriyle slayt düzenlerini, yer tutucuları ve ana düzenleri seçin, uygulayın ve özelleştirin."
---
Bu makale, Aspose.Slides for Android via Java'da **Layout Slides** ile nasıl çalışılacağını gösterir. Bir düzen slaytı, normal slaytların devraldığı tasarımı ve biçimlendirmeyi tanımlar. Düzen slaytlarını ekleyebilir, erişebilir, çoğaltabilir ve kaldırabilir, ayrıca sunum boyutunu azaltmak için kullanılmayanları temizleyebilirsiniz.

## **Düzen Slaytı Ekle**

Tekrar kullanılabilir biçimlendirme tanımlamak için özel bir düzen slaytı oluşturabilirsiniz. Örneğin, bu düzeni kullanan tüm slaytlarda görünen bir metin kutusu ekleyebilirsiniz.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Boş bir düzen türü ve özel bir ad ile bir düzen slaytı oluştur.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Düzen slaytına bir metin kutusu ekle.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Bu düzeni kullanarak iki slayt ekle; her ikisi de düzenten metni devralacak.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Not 1:** Düzen slaytları, tek tek slaytlar için şablon görevi görür. Ortak öğeleri bir kez tanımlayabilir ve birçok slaytta yeniden kullanabilirsiniz.

> 💡 **Not 2:** Bir düzen slaytına şekil veya metin eklediğinizde, bu düzene dayalı tüm slaytlar paylaşılan içeriği otomatik olarak gösterir.  
> Aşağıdaki ekran görüntüsü, aynı düzen slaytından bir metin kutusu miras alan iki slaytı gösterir.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Düzen Slaytına Erişme**

Düzen slaytlarına indeksle ya da düzen tipine göre (ör. `Blank`, `Title`, `SectionHeader`, vb.) erişilebilir.

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Dizinle bir düzen slaytına eriş.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Türle bir düzen slaytına eriş.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Düzen Slaytını Kaldırma**

Artık ihtiyaç duyulmadığında belirli bir düzen slaytını kaldırabilirsiniz.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Türle bir düzen slaytı al ve kaldır.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

Sunum boyutunu azaltmak için hiçbir normal slayt tarafından kullanılmayan düzen slaytlarını kaldırmak isteyebilirsiniz.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Otomatik olarak hiçbir slayt tarafından başvurulmayan tüm düzen slaytlarını kaldırır.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Düzen Slaytını Kopyalama**

`addClone` yöntemiyle bir düzen slaytını çoğaltabilirsiniz.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Türle mevcut bir düzen slaytı al.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Düzen slaytını düzen slaytları koleksiyonunun sonuna kopyala.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Özet:** Düzen slaytları, slaytlar arasında tutarlı biçimlendirmeyi yönetmek için güçlü araçlardır. Aspose.Slides, düzen slaytlarını oluşturma, yönetme ve optimize etme konusunda tam kontrol sağlar.