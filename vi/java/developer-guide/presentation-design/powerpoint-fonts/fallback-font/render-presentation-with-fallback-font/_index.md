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
description: "Hiển thị bản trình chiếu với phông chữ dự phòng trong Aspose.Slides cho Java – giữ nguyên định dạng văn bản trên PPT, PPTX và ODP với các mẫu code Java từng bước."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hiển thị bản trình chiếu bằng cách sử dụng các quy tắc phông chữ dự phòng. Bài viết này hướng dẫn cách tạo bộ sưu tập quy tắc phông chữ dự phòng, sửa đổi các quy tắc bằng cách xóa hoặc thêm phông chữ dự phòng, và gán bộ sưu tập bằng phương thức `FontsManager.setFontFallBackRulesCollection`.

Khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho `FontsManager` của bản trình chiếu, các quy tắc sẽ được áp dụng trong các thao tác như lưu, hiển thị và chuyển đổi bản trình chiếu. Ví dụ minh họa cách sử dụng các quy tắc đã cấu hình khi hiển thị ảnh thu nhỏ của slide và lưu nó dưới dạng ảnh JPEG.

## **Hiển thị Slide bằng Quy tắc Phông chữ Dự phòng**

Ví dụ sau bao gồm các bước sau:

1. Chúng tôi [tạo bộ sưu tập quy tắc phông chữ dự phòng](/slides/vi/java/create-fallback-fonts-collection/).
1. [Xóa](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) một quy tắc phông chữ dự phòng và [addFallBackFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) vào một quy tắc khác.
1. Đặt bộ sưu tập quy tắc vào phương thức [getFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) phương thức.
1. Với phương thức [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#save-java.lang.String-int-) chúng ta có thể lưu bản trình chiếu ở định dạng hiện tại, hoặc lưu nó ở định dạng khác. Sau khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho [FontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsManager), các quy tắc này sẽ được áp dụng trong mọi thao tác trên bản trình chiếu: lưu, hiển thị, chuyển đổi, v.v.

```java
import com.aspose.slides.*;

// Tạo một thể hiện mới của bộ sưu tập quy tắc
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// tạo một số quy tắc
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Cố gắng xóa phông chữ FallBack "Tahoma" khỏi các quy tắc đã tải
    fallBackRule.remove("Tahoma");

    // Và cập nhật các quy tắc cho phạm vi đã chỉ định
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Ngoài ra chúng ta có thể xóa bất kỳ quy tắc nào hiện có khỏi danh sách, giữ lại ít nhất một quy tắc để hiển thị với
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Gán danh sách quy tắc đã chuẩn bị để sử dụng
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Render ảnh thu nhỏ bằng cách sử dụng bộ sưu tập quy tắc đã khởi tạo và lưu dưới dạng JPEG
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

{{% alert color="info" %}} 
Đọc thêm về cách [Chuyển đổi PPT và PPTX sang JPG trong Java](/slides/vi/java/convert-powerpoint-to-jpg/).
{{% /alert %}}