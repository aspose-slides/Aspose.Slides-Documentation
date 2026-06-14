---
title: Hiển thị bản trình chiếu với phông chữ dự phòng trong JavaScript
linktitle: Hiển thị bản trình chiếu
type: docs
weight: 30
url: /vi/nodejs-java/render-presentation-with-fallback-font/
keywords:
- phông chữ dự phòng
- hiển thị PowerPoint
- hiển thị bản trình chiếu
- hiển thị slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Hiển thị bản trình chiếu với phông chữ dự phòng trong Aspose.Slides cho Node.js – giữ nguyên nội dung văn bản trên các định dạng PPT, PPTX và ODP với các mẫu mã JavaScript từng bước."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hiển thị bản trình bày bằng cách sử dụng các quy tắc phông chữ dự phòng. Bài viết này chỉ ra cách tạo bộ sưu tập quy tắc phông chữ dự phòng, chỉnh sửa các quy tắc bằng cách xóa hoặc thêm phông chữ dự phòng, và gán bộ sưu tập bằng phương thức `FontsManager.setFontFallBackRulesCollection`.

Khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho `FontsManager` của bản trình bày, các quy tắc sẽ được áp dụng trong các thao tác như lưu, hiển thị và chuyển đổi bản trình bày. Ví dụ minh họa cách sử dụng các quy tắc đã cấu hình khi hiển thị ảnh thu nhỏ của một slide và lưu dưới dạng ảnh PNG.

## **Hiển thị một Slide bằng Các Quy tắc Phông chữ Dự phòng**

Ví dụ sau đây bao gồm các bước sau:

1. Chúng tôi [tạo bộ sưu tập quy tắc phông chữ dự phòng](/slides/vi/nodejs-java/create-fallback-fonts-collection/).
1. [Xóa](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) một quy tắc phông chữ dự phòng và [addFallBackFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) vào một quy tắc khác.
1. Gán bộ sưu tập quy tắc cho [getFontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) phương thức.
1. Với phương thức [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) chúng ta có thể lưu bản trình bày ở cùng định dạng, hoặc lưu ở định dạng khác. Sau khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho [FontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontsManager), các quy tắc này sẽ được áp dụng trong mọi thao tác trên bản trình bày: lưu, hiển thị, chuyển đổi, v.v.

```javascript
// Tạo một thể hiện mới của bộ sưu tập quy tắc
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// tạo một số quy tắc
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Cố gắng xóa phông chữ FallBack "Tahoma" khỏi các quy tắc đã tải
    fallBackRule.remove("Tahoma");
    // Và cập nhật các quy tắc cho phạm vi đã chỉ định
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Chúng ta cũng có thể xóa bất kỳ quy tắc nào hiện có khỏi danh sách
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Gán danh sách quy tắc đã chuẩn bị để sử dụng
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Kết xuất ảnh thu nhỏ bằng cách sử dụng bộ sưu tập quy tắc đã khởi tạo và lưu dưới dạng JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Lưu ảnh vào đĩa ở định dạng JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Đọc thêm về cách [Chuyển đổi PPT và PPTX sang JPG trong JavaScript](/slides/vi/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}