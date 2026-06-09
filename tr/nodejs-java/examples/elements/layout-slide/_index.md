---
title: Layout Slaytı
type: docs
weight: 20
url: /tr/nodejs-java/examples/elements/layout-slide/
keywords:
- kod örneği
- layout slaytı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'ta ana düzen slaytları: PPT, PPTX ve ODP sunumları için örneklerle slayt düzenlerini, yer tutucuları ve masterları seçin, uygulayın ve özelleştirin."
---
Bu makale, Aspose.Slides for Node.js via Java'da **Layout Slides** ile nasıl çalışılacağını gösterir. Bir layout slaytı, normal slaytlar tarafından devralınan tasarım ve biçimlendirmeyi tanımlar. Layout slaytlarını ekleyebilir, erişebilir, klonlayabilir ve kaldırabilir, ayrıca kullanılmayanları temizleyerek sunum boyutunu azaltabilirsiniz.

## **Layout Slaytı Ekle**

Yeniden kullanılabilir biçimlendirmeyi tanımlamak için özel bir layout slaytı oluşturabilirsiniz.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Boş bir düzen türü ve özel bir ad ile bir layout slaytı oluşturun.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Not 1:** Layout slaytları, tek tek slaytlar için şablon görevi görür. Ortak öğeleri bir kez tanımlayabilir ve birçok slayt boyunca tekrar kullanabilirsiniz.

> 💡 **Not 2:** Bir layout slaytına şekil veya metin eklediğinizde, bu layout üzerine kurulan tüm slaytlar bu ortak içeriği otomatik olarak gösterir.  
> Aşağıdaki ekran görüntüsü, aynı layout slaytından bir metin kutusu miras alan iki slaytı göstermektedir.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Layout Slaytına Erişim**

Layout slaytlarına, indeks veya layout türüne göre (ör. `Blank`, `Title`, `SectionHeader`, vb.) erişilebilir.

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Bir layout slaytına indeks ile erişin.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Bir layout slaytına tür ile erişin.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Layout Slaytını Kaldır**

Artık ihtiyaç duyulmadığında belirli bir layout slaytını kaldırabilirsiniz.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Tür göre bir layout slaytı al ve kaldır.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Kullanılmayan Layout Slaytlarını Kaldır**

Sunum boyutunu azaltmak için, normal slaytlar tarafından kullanılmayan layout slaytlarını kaldırmak isteyebilirsiniz.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Otomatik olarak hiçbir slayt tarafından referans edilmeyen tüm layout slaytlarını kaldırır.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Layout Slaytını Kopyala**

`addClone` metodunu kullanarak bir layout slaytını çoğaltabilirsiniz.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Tür ile mevcut bir layout slaytı al.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Layout slaytını layout slayt koleksiyonunun sonuna klonla.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Özet:** Layout slaytları, slaytlar arasında tutarlı biçimlendirmeyi yönetmek için güçlü araçlardır. Aspose.Slides, layout slaytlarının oluşturulması, yönetilmesi ve optimize edilmesi konusunda tam kontrol sağlar.