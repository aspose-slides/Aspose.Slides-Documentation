---
title: Quản lý dự án VBA trong bản trình chiếu bằng Java
linktitle: Bản trình chiếu qua VBA
type: docs
weight: 250
url: /vi/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Khám phá cách tạo và thao tác các bản trình chiếu PowerPoint và OpenDocument thông qua VBA với Aspose.Slides cho Java để tối ưu hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Aspose.Slides cung cấp các lớp và giao diện để làm việc với macro và mã VBA.

{{% alert title="Note" color="warning" %}} 

Khi bạn chuyển đổi một bản trình chiếu chứa macro sang định dạng file khác (PDF, HTML, v.v.), Aspose.Slides sẽ bỏ qua tất cả các macro (macro không được chuyển sang file kết quả).

Khi bạn thêm macro vào bản trình chiếu hoặc lưu lại bản trình chiếu chứa macro, Aspose.Slides chỉ ghi lại các byte của macro.

Aspose.Slides **không bao giờ** chạy các macro trong bản trình chiếu.

{{% /alert %}}

## **Thêm Macro VBA**

Aspose.Slides cung cấp lớp [VbaProject](https://reference.aspose.com/slides/vi/java/com.aspose.slides/vbaproject/) để cho phép bạn tạo dự án VBA (và các tham chiếu dự án) và chỉnh sửa các mô-đun hiện có. Bạn có thể sử dụng giao diện [IVbaProject](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivbaproject/) để quản lý VBA nhúng trong bản trình chiếu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) .
2. Sử dụng hàm khởi tạo [VbaProject](https://reference.aspose.com/slides/vi/java/com.aspose.slides/vbaproject/#VbaProject--) để thêm một dự án VBA mới.
3. Thêm một mô-đun vào VbaProject.
4. Đặt mã nguồn cho mô-đun.
5. Thêm các tham chiếu tới <stdole>.
6. Thêm các tham chiếu tới **Microsoft Office**.
7. Liên kết các tham chiếu với dự án VBA.
8. Lưu bản trình chiếu.

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Tạo một dự án VBA mới
    pres.setVbaProject(new VbaProject());
    
    // Thêm một mô-đun trống vào dự án VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Đặt mã nguồn cho mô-đun
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

{{% alert color="info" %}} 

Bạn có thể muốn xem **Aspose** [Macro Remover](https://products.aspose.app/slides/vi/remove-macros), một ứng dụng web miễn phí dùng để xóa macro khỏi tài liệu PowerPoint, Excel và Word. 

{{% /alert %}} 

## **Xóa Macro VBA**

Bằng cách sử dụng thuộc tính [VbaProject](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getVbaProject--) trong lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation), bạn có thể xóa một macro VBA.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tải bản trình chiếu chứa macro.
2. Truy cập mô-đun Macro và xóa nó.
3. Lưu bản trình chiếu đã chỉnh sửa.

```java
import com.aspose.slides.*;

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

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tải bản trình chiếu chứa macro.
2. Kiểm tra xem bản trình chiếu có chứa một Dự án VBA hay không.
3. Duyệt qua tất cả các mô-đun trong Dự án VBA để xem các macro.

```java
import com.aspose.slides.*;

// Tải bản trình chiếu chứa macro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Kiểm tra xem bản trình chiếu có chứa một Dự án VBA hay không
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

## **Kiểm tra dự án VBA có được bảo vệ bằng mật khẩu hay không**

Bằng cách sử dụng phương thức [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) , bạn có thể xác định liệu các thuộc tính của dự án có được bảo vệ bằng mật khẩu hay không.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và tải một bản trình chiếu có chứa macro.
2. Kiểm tra xem bản trình chiếu có chứa một [VBA project](https://reference.aspose.com/slides/vi/java/com.aspose.slides/vbaproject/) hay không.
3. Kiểm tra xem dự án VBA có được bảo vệ bằng mật khẩu không để xem các thuộc tính của nó.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Kiểm tra xem bản trình chiếu có chứa một dự án VBA hay không.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

### Điều gì xảy ra với macro nếu tôi lưu bản trình chiếu dưới dạng PPTX?

Macro sẽ bị xóa vì PPTX không hỗ trợ VBA. Để giữ macro, chọn PPTM, PPSM hoặc POTM.

### Aspose.Slides có thể chạy macro trong bản trình chiếu để, ví dụ, làm mới dữ liệu không?

Không. Thư viện không bao giờ thực thi mã VBA; việc thực thi chỉ có thể thực hiện được trong PowerPoint với các cài đặt bảo mật phù hợp.

### Có hỗ trợ làm việc với các điều khiển ActiveX liên kết với mã VBA không?

Có, bạn có thể truy cập các [điều khiển ActiveX](/slides/vi/java/activex/), sửa đổi thuộc tính của chúng và xóa chúng. Điều này hữu ích khi macro tương tác với ActiveX.