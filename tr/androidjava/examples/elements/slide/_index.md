---
title: Slayt
type: docs
weight: 10
url: /tr/androidjava/examples/elements/slide/
keywords:
- kod örneği
- slayt
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de slaytları kontrol edin: Java ile PPT, PPTX ve ODP sunumları için slayt oluşturma, kopyalama, yeniden sıralama, yeniden boyutlandırma, arka plan ayarlama ve geçiş uygulama."
---
Bu makale, **Aspose.Slides for Android via Java** kullanarak slaytlarla nasıl çalışılacağını gösteren bir dizi örnek sunar. `Presentation` sınıfını kullanarak slayt ekleme, erişme, kopyalama, yeniden sıralama ve kaldırma konularını öğreneceksiniz.

Aşağıdaki her örnek, kısa bir açıklama ve ardından Java kod parçacığı içerir.

## **Slayt Ekle**

Yeni bir slayt eklemek için önce bir düzen seçmelisiniz. Bu örnekte, `Blank` düzenini kullanıyor ve sunuma boş bir slayt ekliyoruz.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

💡 **Not:** Her slayt düzeni, genel tasarımı ve yer tutucu yapısını tanımlayan bir ana slayttan türetilir. Aşağıdaki resim, ana slaytların ve ilgili düzenlerin PowerPoint'te nasıl organize edildiğini gösterir.

![Master and Layout Relationship](master-layout-slide.png)

## **İndeks ile Slaytlara Erişme**

Slaytlara indekslerini kullanarak erişebilir veya bir referansa dayanarak bir slaytın indeksini bulabilirsiniz. Bu, belirli slaytlar üzerinde döngü yapmak veya değişiklik yapmak için faydalıdır.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Başka bir boş slayt ekle.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Slaytlara indeks ile eriş.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Bir referanstan slayt indeksini al, ardından indeks ile eriş.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Slaytı Kopyala**

Bu örnek, mevcut bir slaytı nasıl kopyalayacağınızı gösterir. Kopyalanan slayt otomatik olarak slayt koleksiyonunun sonuna eklenir.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Slaytları Yeniden Sırala**

Bir slaytı yeni bir indekse taşıyarak slaytların sırasını değiştirebilirsiniz. Bu örnekte, kopyalanan bir slaytı ilk konuma taşıyoruz.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Slaytı Kaldır**

Bir slaytı kaldırmak için sadece ona referans verip `remove` metodunu çağırmanız yeterlidir. Bu örnek, ikinci bir slayt ekler ve ardından orijinali kaldırarak sadece yeni slaytı bırakır.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```