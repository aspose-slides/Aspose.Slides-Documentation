---
title: پیوند
type: docs
weight: 130
url: /fa/nodejs-java/examples/elements/hyperlink/
keywords:
- مثال کد
- پیوند
- پاورپوینت
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "افزودن و مدیریت پیوندها در Aspose.Slides برای Node.js: متن پیوند، اشکال و تصاویر، تعیین اهداف و اقدامات برای PPT، PPTX و ODP با مثال‌ها."
---
این مقاله افزودن، دسترسی، حذف و به‌روزرسانی پیوندهای ابرمتن در اشکال را با استفاده از **Aspose.Slides for Node.js via Java** نشان می‌دهد.

## **افزودن پیوند**
یک شکل مستطیلی با پیوندی که به یک وب‌سایت خارجی اشاره می‌کند ایجاد کنید.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به پیوند**
پیوند را از قسمت متن یک شکل بخوانید.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض می‌شود که اولین شکل حاوی متن با پیوند است.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **حذف پیوند**
پیوند را از متن یک شکل پاک کنید.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض می‌شود که اولین شکل حاوی متن با پیوند است.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **به‌روزرسانی پیوند**
هدف یک پیوند موجود را تغییر دهید. از `HyperlinkManager` برای اصلاح متنی که پیشاپیش شامل پیوند است استفاده کنید، که مشابه نحوه به‌روزرسانی ایمن پیوندها در PowerPoint می‌باشد.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض می‌شود که اولین شکل حاوی متن با پیوند است.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // تغییر یک پیوند درون متن موجود باید از طریق
        // HyperlinkManager انجام شود نه اینکه خاصیت را مستقیماً تنظیم کنیم.
        // این شبیه به نحوه به روزرسانی ایمن پیوندها در PowerPoint است.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```