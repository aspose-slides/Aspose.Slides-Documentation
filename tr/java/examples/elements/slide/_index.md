---
title: Slayt
type: docs
weight: 10
url: /tr/java/examples/elements/slide/
keywords:
- kod örneği
- slayt
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da slaytları kontrol edin: PPT, PPTX ve ODP sunumları için Java ile oluşturma, kopyalama, yeniden sıralama, yeniden boyutlandırma, arka plan ayarlama ve geçiş uygulama."
---
Bu makale, **Aspose.Slides for Java** kullanarak slaytlarla nasıl çalışılacağını gösteren bir dizi örnek sunar. `Presentation` sınıfını kullanarak slayt eklemeyi, erişmeyi, kopyalamayı, yeniden sıralamayı ve kaldırmayı öğreneceksiniz.

Aşağıdaki her örnek, kısa bir açıklama ve ardından Java kod snippet'i içerir.

## **Bir Slayt Ekle**

Yeni bir slayt eklemek için öncelikle bir yerleşim seçmelisiniz. Bu örnekte, `Blank` yerleşimini kullanıyor ve sunuma boş bir slayt ekliyoruz.

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

> 💡 **Not:** Her slayt yerleşimi bir ana slayttan türetilir; ana slayt genel tasarımı ve yer tutucu yapısını tanımlar. Aşağıdaki görüntü, PowerPoint'te ana slaytların ve bunlara bağlı yerleşimlerin nasıl düzenlendiğini gösterir.

![Master and Layout Relationship](master-layout-slide.png)

## **İndeks ile Slaytlara Erişim**

Slaytlara indekslerini kullanarak erişebilir veya bir referansa dayanarak bir slaydın indeksini bulabilirsiniz. Bu, belirli slaytlar arasında döngü yaparken veya onları değiştirirken faydalıdır.

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

## **Bir Slaytı Kopyala**

Bu örnek, mevcut bir slaytı nasıl kopyalayacağınızı gösterir. Kopyalanan slayt, slayt koleksiyonunun sonuna otomatik olarak eklenir.

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

## **Bir Slaytı Kaldır**

Bir slaytı kaldırmak için, ona referans verip `remove` metodunu çağırmanız yeterlidir. Bu örnek, ikinci bir slayt ekler ve ardından orijinali kaldırarak sadece yenisini bırakır.

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