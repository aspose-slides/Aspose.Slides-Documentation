---
title: Hiển thị bản trình chiếu với phông chữ dự phòng trong .NET
linktitle: Hiển thị bản trình chiếu
type: docs
weight: 30
url: /vi/net/render-presentation-with-fallback-font/
keywords:
- phông chữ dự phòng
- hiển thị PowerPoint
- hiển thị bản trình chiếu
- hiển thị slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Hiển thị bản trình chiếu với phông chữ dự phòng trong Aspose.Slides cho .NET – giữ nguyên định dạng văn bản trên PPT, PPTX và ODP với các mẫu mã C# từng bước."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hiển thị bản trình chiếu bằng cách sử dụng các quy tắc phông chữ dự phòng. Bài viết này mô tả cách tạo bộ sưu tập quy tắc phông chữ dự phòng, chỉnh sửa các quy tắc bằng cách xóa hoặc thêm phông chữ dự phòng, và gán bộ sưu tập này cho thuộc tính `FontsManager.FontFallBackRulesCollection`.

Khi bộ sưu tập quy tắc phông chữ dự phòng đã được gán cho `FontsManager` của bản trình chiếu, các quy tắc sẽ được áp dụng trong các thao tác như lưu, hiển thị và chuyển đổi bản trình chiếu. Ví dụ minh họa cách sử dụng các quy tắc đã cấu hình khi hiển thị thumbnail của slide và lưu nó dưới dạng ảnh PNG.

## **Hiển thị Slide bằng Quy tắc Phông chữ Dự phòng**

Các bước trong ví dụ sau:

1. Chúng tôi [tạo bộ sưu tập quy tắc phông chữ dự phòng](/slides/vi/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrule/methods/remove) một quy tắc phông chữ dự phòng và [AddFallBackFonts()](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) vào một quy tắc khác.
1. Đặt bộ sưu tập quy tắc vào thuộc tính [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Với phương thức [Presentation.Save()](https://reference.aspose.com/slides/vi/net/aspose.slides.presentation/save/methods/4) chúng ta có thể lưu bản trình chiếu ở cùng định dạng, hoặc lưu ở định dạng khác. Khi bộ sưu tập quy tắc phông chữ dự phòng được đặt cho FontsManager, các quy tắc này sẽ được áp dụng trong bất kỳ thao tác nào trên bản trình chiếu: lưu, hiển thị, chuyển đổi, v.v.

```c#
using Aspose.Slides;

// Tạo một thể hiện mới của bộ sưu tập quy tắc
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Cố gắng xóa phông chữ FallBack "Tahoma" khỏi các quy tắc đã tải
	fallBackRule.Remove("Tahoma");

	// Và cập nhật các quy tắc cho phạm vi được chỉ định
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Ngoài ra chúng ta có thể xóa bất kỳ quy tắc nào hiện có trong danh sách, giữ lại ít nhất một quy tắc để hiển thị
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Gán danh sách quy tắc đã chuẩn bị để sử dụng
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Hiển thị thumbnail bằng cách sử dụng bộ sưu tập quy tắc đã khởi tạo và lưu dưới dạng PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
Đọc thêm về [Lưu và Chuyển Đổi trong Bản Trình Chiếu](/slides/vi/net/convert-powerpoint-to-png/).
{{% /alert %}}