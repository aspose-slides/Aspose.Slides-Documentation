---
title: Layout Slaytı
type: docs
weight: 20
url: /tr/java/examples/elements/layout-slide/
keywords:
- kod örneği
- yerleşim slaytı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da ana yerleşim slaytları: PPT, PPTX ve ODP sunumları için Java örnekleriyle slayt yerleşimlerini, yer tutucuları ve masterları seçin, uygulayın ve özelleştirin."
---
Bu makale, Aspose.Slides for Java'da **Layout Slides** ile nasıl çalışılacağını gösterir. Bir yerleşim slaytı, normal slaytlar tarafından miras alınan tasarımı ve biçimlendirmeyi tanımlar. Yerleşim slaytlarını ekleyebilir, erişebilir, kopyalayabilir ve kaldırabilir, ayrıca kullanılmayanları temizleyerek sunum boyutunu azaltabilirsiniz.

## **Yerleşim Slaytı Ekle**

Tekrar kullanılabilir biçimlendirmeyi tanımlamak için özel bir yerleşim slaytı oluşturabilirsiniz. Örneğin, bu yerleşimi kullanan tüm slaytlarda görünecek bir metin kutusu ekleyebilirsiniz.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Boş bir yerleşim türü ve özel bir ad ile bir yerleşim slaytı oluştur.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Yerleşim slaytına bir metin kutusu ekle.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Bu yerleşimi kullanarak iki slayt ekle; her ikisi de yerleşimden metni miras alır.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Yerleşim slaytları, tek tek slaytlar için şablon görevi görür. Ortak öğeleri bir kez tanımlayabilir ve birçok slayt arasında tekrar kullanabilirsiniz.

> 💡 **Note 2:** Bir yerleşim slaytına şekil veya metin eklediğinizde, o yerleşime dayanan tüm slaytlar bu ortak içeriği otomatik olarak gösterir.  
> Aşağıdaki ekran görüntüsü, aynı yerleşim slaytından bir metin kutusu miras alan iki slaytı gösterir.

![Yerleşim İçeriği Miras Alan Slaytlar](layout-slide-result.png)

## **Yerleşim Slaytına Erişim**

Yerleşim slaytlarına indeks veya yerleşim türüne göre (örneğin `Blank`, `Title`, `SectionHeader` vb.) erişilebilir.

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Bir yerleşim slaytına indeksle eriş.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Bir yerleşim slaytına tipe göre eriş.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Yerleşim Slaytını Kaldır**

Artık ihtiyaç duyulmuyorsa belirli bir yerleşim slaytını kaldırabilirsiniz.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Tipine göre bir yerleşim slaytı al ve kaldır.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Kullanılmayan Yerleşim Slaytlarını Kaldır**

Sunum boyutunu küçültmek için, normal slaytlar tarafından kullanılmayan yerleşim slaytlarını kaldırmak isteyebilirsiniz.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Otomatik olarak herhangi bir slayt tarafından referans alınmayan tüm yerleşim slaytlarını kaldırır.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Yerleşim Slaytını Kopyala**

`addClone` metodunu kullanarak bir yerleşim slaytını çoğaltabilirsiniz.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Türüne göre mevcut bir yerleşim slaytı al.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Yerleşim slaytını yerleşim slaytı koleksiyonunun sonuna kopyala.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** Yerleşim slaytları, slaytlar arasında tutarlı biçimlendirme yönetmek için güçlü araçlardır. Aspose.Slides, yerleşim slaytlarını oluşturma, yönetme ve optimize etme konusunda tam kontrol sağlar.