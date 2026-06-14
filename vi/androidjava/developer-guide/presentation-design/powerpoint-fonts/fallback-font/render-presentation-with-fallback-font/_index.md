---
title: Kết xuất bản thuyết trình với phông chữ dự phòng trên Android
linktitle: Kết xuất bản thuyết trình
type: docs
weight: 30
url: /vi/androidjava/render-presentation-with-fallback-font/
keywords:
- phông chữ dự phòng
- kết xuất PowerPoint
- kết xuất bản thuyết trình
- kết xuất slide
- PowerPoint
- OpenDocument
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Kết xuất bản thuyết trình với phông chữ dự phòng trong Aspose.Slides cho Android – giữ nguyên định dạng văn bản trên PPT, PPTX và ODP với các mẫu mã Java từng bước."
---
## **Tổng quan**

Aspose.Slides cho phép bạn kết xuất các bản thuyết trình bằng cách sử dụng các quy tắc phông chữ dự phòng. Bài viết này chỉ cách tạo bộ sưu tập quy tắc phông chữ dự phòng, chỉnh sửa các quy tắc bằng cách xóa hoặc thêm phông chữ dự phòng, và gán bộ sưu tập bằng phương thức `FontsManager.setFontFallBackRulesCollection`.

Khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho `FontsManager` của bản thuyết trình, các quy tắc sẽ được áp dụng trong các thao tác như lưu, kết xuất và chuyển đổi bản thuyết trình. Ví dụ minh họa cách sử dụng các quy tắc đã cấu hình khi kết xuất ảnh thu nhỏ của một slide và lưu dưới dạng ảnh PNG.

## **Kết xuất một Slide bằng Quy tắc Phông chữ Dự phòng**

Các bước trong ví dụ dưới đây bao gồm:

1. Chúng tôi [tạo bộ sưu tập quy tắc phông chữ dự phòng](/slides/vi/androidjava/create-fallback-fonts-collection/).
2. [Xóa] một quy tắc phông chữ dự phòng và [addFallBackFonts] vào một quy tắc khác.
3. Đặt bộ sưu tập quy tắc cho [getFontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) phương thức.
4. Với [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) phương thức chúng ta có thể lưu bản thuyết trình ở cùng định dạng, hoặc lưu nó ở định dạng khác. Sau khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho [FontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontsManager), các quy tắc này sẽ được áp dụng trong bất kỳ thao tác nào trên bản thuyết trình: lưu, kết xuất, chuyển đổi, v.v.

```java
// Tạo một thể hiện mới của bộ sưu tập quy tắc
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// tạo một số quy tắc
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Cố gắng xóa phông chữ FallBack "Tahoma" khỏi các quy tắc đã tải
    fallBackRule.remove("Tahoma");

    // Và cập nhật các quy tắc cho phạm vi chỉ định
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Ngoài ra chúng ta có thể xóa bất kỳ quy tắc nào hiện có trong danh sách
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Gán danh sách quy tắc đã chuẩn bị để sử dụng
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Kết xuất ảnh thu nhỏ bằng cách sử dụng bộ sưu tập quy tắc đã khởi tạo và lưu dưới dạng JPEG
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
Đọc thêm về [Chuyển đổi PPT và PPTX sang JPG trên Android](/slides/vi/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}