---
title: Hiển thị bản trình chiếu với phông chữ dự phòng trong Java
linktitle: Hiển thị bản trình chiếu
type: docs
weight: 30
url: /vi/java/render-presentation-with-fallback-font/
keywords:
- phông chữ dự phòng
- hiển thị PowerPoint
- hiển thị bản trình chiếu
- hiển thị slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Hiển thị bản trình chiếu với phông chữ dự phòng trong Aspose.Slides cho Java – giữ nguyên định dạng văn bản trên PPT, PPTX và ODP với các mẫu mã Java từng bước."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hiển thị các bản trình bày bằng cách sử dụng quy tắc phông chữ dự phòng. Bài viết này mô tả cách tạo một bộ sưu tập quy tắc phông chữ dự phòng, chỉnh sửa các quy tắc bằng cách loại bỏ hoặc thêm phông chữ dự phòng, và gán bộ sưu tập bằng phương thức `FontsManager.setFontFallBackRulesCollection`.

Khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho `FontsManager` của bài thuyết trình, các quy tắc sẽ được áp dụng trong các thao tác như lưu, hiển thị và chuyển đổi bài thuyết trình. Ví dụ minh họa cách sử dụng các quy tắc đã cấu hình khi hiển thị ảnh thu nhỏ của slide và lưu nó dưới dạng ảnh PNG.

## **Hiển thị Slide bằng Quy tắc Phông chữ Dự phòng**

Ví dụ sau bao gồm các bước sau:

1. Chúng tôi [tạo bộ sưu tập quy tắc phông chữ dự phòng](/slides/vi/java/create-fallback-fonts-collection/).
2. [Xóa](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) một quy tắc phông chữ dự phòng và [addFallBackFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) cho một quy tắc khác.
3. Đặt bộ sưu tập quy tắc cho [getFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) phương thức.
4. Bằng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#save-java.lang.String-int-) chúng ta có thể lưu bản trình bày ở cùng định dạng, hoặc lưu nó ở định dạng khác. Sau khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho [FontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsManager), các quy tắc này sẽ được áp dụng trong mọi thao tác với bản trình bày: lưu, hiển thị, chuyển đổi, v.v.

```java
// Tạo một thể hiện mới của bộ sưu tập quy tắc
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Cố gắng xóa phông chữ FallBack "Tahoma" khỏi các quy tắc đã tải
    fallBackRule.remove("Tahoma");

    // Và cập nhật các quy tắc cho phạm vi được chỉ định
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Also we can remove any existing rules from list
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Gán danh sách quy tắc đã chuẩn bị để sử dụng
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Lưu ảnh vào đĩa ở định dạng JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Đọc thêm về cách [Chuyển đổi PPT và PPTX sang JPG trong Java](/slides/vi/java/convert-powerpoint-to-jpg/).
{{% /alert %}}