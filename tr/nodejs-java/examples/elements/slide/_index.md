---
title: Slayt
type: docs
weight: 10
url: /tr/nodejs-java/examples/elements/slide/
keywords:
- kod örneği
- slayt
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde slaytları kontrol edin: PPT, PPTX ve ODP sunumları için oluşturma, kopyalama, yeniden sıralama, yeniden boyutlandırma, arka plan ayarlama ve geçiş uygulama."
---
Bu makale, **Aspose.Slides for Node.js via Java** kullanarak slaytlarla çalışmayı gösteren bir dizi örnek sunar. `Presentation` sınıfını kullanarak slayt ekleme, erişme, kopyalama, yeniden sıralama ve kaldırma konularını öğreneceksiniz.

Her örnek aşağıda kısa bir açıklama ve ardından bir JavaScript kod parçacığı içerir.

## **Slayt Ekle**

Yeni bir slayt eklemek için önce bir düzen seçmelisiniz. Bu örnekte, `Blank` düzenini kullanıyor ve sunuma boş bir slayt ekliyoruz.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Not:** Her slayt düzeni bir ana slayttan türetilir; ana slayt genel tasarımı ve yer tutucu yapısını tanımlar. Aşağıdaki resim, PowerPoint'te ana slaytların ve bunlara bağlı düzenlerin nasıl düzenlendiğini gösterir.

![Ana Slayt ve Düzen İlişkisi](master-layout-slide.png)

## **İndeks ile Slaytlara Erişme**

Slaytlara indekslerini kullanarak erişebilirsiniz. Bu, slaytlar arasında döngü kurmak veya belirli slaytları değiştirmek için işe yarar.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // İndeks ile bir slayta eriş.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Slaytı Kopyala**

Bu örnek, mevcut bir slaytı nasıl kopyalayacağınızı gösterir. Kopyalanan slayt otomatik olarak slayt koleksiyonunun sonuna eklenir.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Slaytları Yeniden Sırala**

Bir slaytı yeni bir indekse taşıyarak slaytların sırasını değiştirebilirsiniz. Bu örnekte, bir slaytı ilk konuma taşıyoruz.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // İkinci slaytı ilk konuma taşıyarak slaytları yeniden sırala.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Slaytı Kaldır**

Bir slaytı kaldırmak için, sadece ona referans verip `remove` metodunu çağırın. Bu örnek ikinci bir slayt ekler ve ardından orijinali kaldırarak yalnızca yenisini bırakır.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```