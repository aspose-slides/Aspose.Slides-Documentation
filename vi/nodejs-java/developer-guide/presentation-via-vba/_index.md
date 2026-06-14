---
title: Quản lý dự án VBA trong bản trình chiếu bằng JavaScript
linktitle: Trình chiếu qua VBA
type: docs
weight: 250
url: /vi/nodejs-java/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- thêm macro
- xóa macro
- trích xuất macro
- thêm VBA
- xóa VBA
- trích xuất VBA
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo và thao tác các bản trình chiếu PowerPoint và OpenDocument qua VBA trong JavaScript với Aspose.Slides cho Node.js qua Java để tối ưu hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Aspose.Slides cung cấp các lớp để làm việc với macro và mã VBA.

{{% alert title="Lưu ý" color="warning" %}} 
Khi bạn chuyển đổi một bản trình chiếu chứa macro sang định dạng tệp khác (PDF, HTML, v.v.), Aspose.Slides bỏ qua tất cả các macro (macro không được chuyển sang tệp kết quả).

Khi bạn thêm macro vào bản trình chiếu hoặc lưu lại một bản trình chiếu chứa macro, Aspose.Slides chỉ ghi các byte của macro.

Aspose.Slides **không bao giờ** chạy các macro trong một bản trình chiếu.
{{% /alert %}}

## **Thêm Macro VBA**

Aspose.Slides cung cấp lớp [VbaProject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/vbaproject/) để cho phép bạn tạo các dự án VBA (và các tham chiếu dự án) và chỉnh sửa các mô-đun hiện có. Bạn có thể sử dụng lớp [VbaProject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/vbaproject/) để quản lý VBA được nhúng trong một bản trình chiếu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Sử dụng hàm khởi tạo [VbaProject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/vbaproject/#VbaProject--) để thêm một dự án VBA mới.
1. Thêm một mô-đun vào VbaProject.
1. Đặt mã nguồn cho mô-đun.
1. Thêm tham chiếu tới <stdole>.
1. Thêm tham chiếu tới **Microsoft Office**.
1. Liên kết các tham chiếu với dự án VBA.
1. Lưu bản trình chiếu.

Đoạn mã JavaScript này cho bạn thấy cách thêm một macro VBA từ đầu vào bản trình chiếu:

```javascript
// Tạo một thể hiện của lớp Presentation
let pres = new aspose.slides.Presentation();
try {
    // Tạo một dự án VBA mới
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Thêm một mô-đun trống vào dự án VBA
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Đặt mã nguồn cho mô-đun
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Tạo một tham chiếu tới <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Tạo một tham chiếu tới Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Thêm các tham chiếu vào dự án VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Lưu bản trình chiếu
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Bạn có thể muốn khám phá **Aspose** [Macro Remover](https://products.aspose.app/slides/vi/remove-macros), một ứng dụng web miễn phí dùng để xóa macro khỏi các tài liệu PowerPoint, Excel và Word. 
{{% /alert %}} 

## **Xóa Macro VBA**

Sử dụng thuộc tính [VbaProject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getVbaProject--) dưới lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation), bạn có thể xóa một macro VBA.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) và tải bản trình chiếu chứa macro.
1. Truy cập mô-đun Macro và xóa nó.
1. Lưu bản trình chiếu đã được chỉnh sửa.

Đoạn mã JavaScript này cho bạn thấy cách xóa một macro VBA:

```javascript
// Tải bản trình chiếu chứa macro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Truy cập mô-đun Vba và xóa nó
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Lưu bản trình chiếu
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Trích xuất Macro VBA**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) và tải bản trình chiếu chứa macro.
2. Kiểm tra xem bản trình chiếu có chứa một Dự án VBA hay không.
3. Duyệt qua tất cả các mô-đun trong Dự án VBA để xem các macro.

Đoạn mã JavaScript này cho bạn thấy cách trích xuất macro VBA từ một bản trình chiếu chứa macro:

```javascript
// Tải bản trình chiếu chứa macro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Kiểm tra xem bản trình chiếu có chứa dự án VBA hay không
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kiểm tra xem Dự án VBA có được bảo vệ bằng mật khẩu hay không**

Sử dụng phương thức [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected), bạn có thể xác định xem các thuộc tính của dự án có được bảo vệ bằng mật khẩu hay không.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và tải một bản trình chiếu chứa macro.
2. Kiểm tra xem bản trình chiếu có chứa một [VBA project](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/vbaproject/) hay không.
3. Kiểm tra xem dự án VBA có được bảo vệ bằng mật khẩu để xem các thuộc tính của nó hay không.

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Kiểm tra xem bản trình chiếu có chứa dự án VBA hay không.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Điều gì xảy ra với macro nếu tôi lưu bản trình chiếu dưới dạng PPTX?**

Các macro sẽ bị xóa vì PPTX không hỗ trợ VBA. Để giữ lại các macro, chọn PPTM, PPSM hoặc POTM.

**Aspose.Slides có thể chạy macro trong một bản trình chiếu để, ví dụ, làm mới dữ liệu không?**

Không. Thư viện không bao giờ thực thi mã VBA; việc thực thi chỉ có thể được thực hiện trong PowerPoint với các cài đặt bảo mật thích hợp.

**Có hỗ trợ làm việc với các điều khiển ActiveX liên kết với mã VBA không?**

Có, bạn có thể truy cập các [ActiveX controls](/slides/vi/nodejs-java/activex/), sửa đổi thuộc tính của chúng và xóa chúng. Điều này hữu ích khi các macro tương tác với ActiveX.