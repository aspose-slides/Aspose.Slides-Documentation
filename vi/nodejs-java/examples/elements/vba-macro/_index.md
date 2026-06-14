---
title: Macro VBA
type: docs
weight: 150
url: /vi/nodejs-java/examples/elements/vba-macro/
keywords:
- ví dụ mã
- VBA
- macro
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tự động hóa các bản trình chiếu với Aspose.Slides cho Node.js qua Java: tạo, nhập và bảo mật macro VBA trong PPT, PPTX và ODP bằng các ví dụ JavaScript rõ ràng."
---
Bài viết này trình bày cách thêm, truy cập và xóa macro VBA bằng **Aspose.Slides for Node.js via Java**.

## **Thêm macro VBA**

Tạo một bản trình chiếu có dự án VBA và một mô-đun macro đơn giản.

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập macro VBA**

Lấy mô-đun đầu tiên từ dự án VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Giả sử bản trình chiếu có ít nhất một mô-đun VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa macro VBA**

Xóa một mô-đun khỏi dự án VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Giả sử bản trình chiếu có ít nhất một mô-đun VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```