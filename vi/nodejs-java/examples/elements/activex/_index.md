---
title: ActiveX
type: docs
weight: 200
url: /vi/nodejs-java/examples/elements/activex/
keywords:
- ví dụ mã
- ActiveX
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Xem các ví dụ ActiveX của Aspose.Slides for Node.js: chèn, cấu hình và điều khiển các đối tượng ActiveX trong bản trình chiếu PPT và PPTX bằng mã JavaScript rõ ràng."
---
Bài viết này trình bày cách thêm, truy cập, xóa và cấu hình các điều khiển ActiveX trong một bản trình chiếu bằng cách sử dụng **Aspose.Slides for Node.js via Java**.

## **Thêm một điều khiển ActiveX**

Thêm một điều khiển ActiveX mới vào slide.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Thêm một điều khiển ActiveX mới.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập một điều khiển ActiveX**

Đọc thông tin từ điều khiển ActiveX đầu tiên trên slide.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Truy cập điều khiển ActiveX đầu tiên.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một điều khiển ActiveX**

Xóa một điều khiển ActiveX hiện có khỏi slide.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Xóa điều khiển ActiveX đầu tiên.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Đặt thuộc tính ActiveX**

Cấu hình một số thuộc tính ActiveX.

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            let control = slide.getControls().get_Item(0);

            control.getProperties().set_Item("Caption", "Click Me");
            control.getProperties().set_Item("Enabled", "true");
        }

        presentation.save("activex_properties.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```