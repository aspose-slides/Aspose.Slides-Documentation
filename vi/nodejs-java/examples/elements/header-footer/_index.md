---
title: Đầu trang và Chân trang
type: docs
weight: 220
url: /vi/nodejs-java/examples/elements/header-footer/
keywords:
- ví dụ mã
- đầu trang
- chân trang
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Kiểm soát đầu trang và chân trang của slide bằng Aspose.Slides cho Node.js: thêm ngày tháng, số slide và văn bản tùy chỉnh trong PPT, PPTX và ODP với các ví dụ JavaScript."
---
Bài viết này trình bày cách thêm chân trang và cập nhật các trình giữ chỗ ngày giờ bằng **Aspose.Slides for Node.js via Java**.

## **Thêm Chân Trang**
Thêm văn bản vào vùng chân trang của một slide và hiển thị nó.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Cập Nhật Ngày và Giờ**
Sửa đổi trình giữ chỗ ngày và giờ trên một slide.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```