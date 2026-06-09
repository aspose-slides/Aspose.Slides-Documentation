---
title: Bölüm
type: docs
weight: 90
url: /tr/nodejs-java/examples/elements/section/
keywords:
- kod örneği
- bölüm
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'da slayt bölümlerini yönetin: JavaScript örnekleriyle PPT, PPTX ve ODP için oluşturma, yeniden adlandırma, yeniden sıralama ve slaytları gruplama."
---
Sunum bölümlerini yönetmek için örnekler—bölümleri programlı olarak ekleme, erişme, silme ve yeniden adlandırma, **Aspose.Slides for Node.js via Java** kullanarak.

## **Bir Bölüm Ekle**

Belirli bir slaytta başlayan bir bölüm oluşturun.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Bölümün başlangıcını işaret eden slaytı belirtin.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Bir Bölüme Eriş**

Bir sunumdan bölüm bilgilerini okuyun.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Dizine göre bir bölüme eriş.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Bir Bölüm Kaldır**

Daha önce eklenmiş bir bölümü silin.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk bölümü kaldır.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Bir Bölümün Adını Değiştir**

Mevcut bir bölümün adını değiştirin.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```