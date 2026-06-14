---
title: Quản lý Dự án VBA trong Bài thuyết trình trên Android
linktitle: Bài thuyết trình qua VBA
type: docs
weight: 250
url: /vi/androidjava/presentation-via-vba/
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
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Khám phá cách tạo và thao tác các bài thuyết trình PowerPoint và OpenDocument qua VBA với Aspose.Slides cho Android bằng Java để tối ưu quy trình làm việc của bạn."
---
## **Giới thiệu**

Aspose.Slides cung cấp các lớp và giao diện để làm việc với macro và mã VBA.

{{% alert title="Note" color="warning" %}} 

Khi bạn chuyển đổi một bài thuyết trình chứa macro sang định dạng tệp khác (PDF, HTML, v.v.), Aspose.Slides bỏ qua tất cả các macro (macro sẽ không được chuyển sang tệp kết quả).

Khi bạn thêm macro vào một bài thuyết trình hoặc lưu lại một bài thuyết trình chứa macro, Aspose.Slides chỉ ghi lại các byte của macro.

Aspose.Slides **không bao giờ** chạy các macro trong một bài thuyết trình.

{{% /alert %}}

## **Thêm Macro VBA**

Aspose.Slides cung cấp lớp [VbaProject](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/vbaproject/) cho phép bạn tạo dự án VBA (và các tham chiếu dự án) và chỉnh sửa các mô-đun hiện có. Bạn có thể sử dụng giao diện [IVbaProject](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivbaproject/) để quản lý VBA nhúng trong một bài thuyết trình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Sử dụng constructor của [VbaProject](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/vbaproject/#VbaProject--) để thêm một dự án VBA mới.
1. Thêm một mô-đun vào VbaProject.
1. Đặt mã nguồn của mô-đun.
1. Thêm tham chiếu tới <stdole>.
1. Thêm tham chiếu tới **Microsoft Office**.
1. Liên kết các tham chiếu với dự án VBA.
1. Lưu bài thuyết trình.

Mã Java này cho bạn thấy cách thêm một macro VBA từ đầu vào một bài thuyết trình:

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Tạo một dự án VBA mới
    pres.setVbaProject(new VbaProject());
    
    // Thêm một mô-đun trống vào dự án VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Đặt mã nguồn của mô-đun
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Tạo một tham chiếu tới <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Tạo một tham chiếu tới Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Thêm các tham chiếu vào dự án VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Lưu bản trình chiếu
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Bạn có thể muốn thử **Aspose** [Macro Remover](https://products.aspose.app/slides/vi/remove-macros), một ứng dụng web miễn phí dùng để xóa macro khỏi các tài liệu PowerPoint, Excel và Word. 

{{% /alert %}} 

## **Xóa Macro VBA**

Sử dụng thuộc tính [VbaProject](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getVbaProject--) dưới lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation), bạn có thể xóa một macro VBA.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) và tải bài thuyết trình chứa macro.
1. Truy cập mô-đun Macro và xóa nó.
1. Lưu bài thuyết trình đã chỉnh sửa.

Mã Java này cho bạn thấy cách xóa một macro VBA:

```java
// Tải bản trình chiếu chứa macro
Presentation pres = new Presentation("VBA.pptm");
try {
    // Truy cập mô-đun Vba và xóa nó 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Lưu bản trình chiếu
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Trích xuất Macro VBA**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) và tải bài thuyết trình chứa macro.
2. Kiểm tra xem bài thuyết trình có chứa một Dự án VBA không.
3. Duyệt qua tất cả các mô-đun trong Dự án VBA để xem các macro.

Mã Java này cho bạn thấy cách trích xuất các macro VBA từ một bài thuyết trình chứa macro:

```java
// Tải bản trình chiếu chứa macro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Kiểm tra xem Bản trình chiếu có chứa dự án VBA hay không
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kiểm tra Dự án VBA có được bảo vệ bằng mật khẩu hay không**

Sử dụng phương pháp [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--), bạn có thể xác định liệu các thuộc tính của dự án có được bảo vệ bằng mật khẩu hay không.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và tải một bài thuyết trình chứa macro.
2. Kiểm tra xem bài thuyết trình có chứa một [VBA project](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/vbaproject/) không.
3. Kiểm tra xem dự án VBA có được bảo vệ bằng mật khẩu để xem các thuộc tính của nó không.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Kiểm tra xem bản trình chiếu có chứa dự án VBA hay không.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Điều gì xảy ra với macro nếu tôi lưu bài thuyết trình dưới dạng PPTX?**

Macro sẽ bị xóa vì PPTX không hỗ trợ VBA. Để giữ macro, hãy chọn PPTM, PPSM hoặc POTM.

**Aspose.Slides có thể chạy macro trong bài thuyết trình để, ví dụ, làm mới dữ liệu không?**

Không. Thư viện không bao giờ thực thi mã VBA; việc thực thi chỉ có thể thực hiện trong PowerPoint với các cài đặt bảo mật thích hợp.

**Có hỗ trợ làm việc với các điều khiển ActiveX liên kết với mã VBA không?**

Có, bạn có thể truy cập các [ActiveX controls](/slides/vi/androidjava/activex/), chỉnh sửa thuộc tính của chúng và xóa chúng. Điều này hữu ích khi macro tương tác với ActiveX.