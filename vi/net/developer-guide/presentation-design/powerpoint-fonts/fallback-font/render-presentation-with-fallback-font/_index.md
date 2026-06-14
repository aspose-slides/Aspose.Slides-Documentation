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

Aspose.Slides cho phép bạn hiển thị bản trình chiếu bằng cách sử dụng các quy tắc phông chữ dự phòng. Bài viết này trình bày cách tạo bộ sưu tập các quy tắc phông chữ dự phòng, sửa đổi các quy tắc bằng cách xóa hoặc thêm phông chữ dự phòng, và gán bộ sưu tập này cho thuộc tính `FontsManager.FontFallBackRulesCollection`.

Khi bộ sưu tập các quy tắc phông chữ dự phòng được gán cho `FontsManager` của bản trình chiếu, các quy tắc sẽ được áp dụng trong các thao tác như lưu, render và chuyển đổi bản trình chiếu. Ví dụ minh họa cách sử dụng các quy tắc đã cấu hình khi render hình thu nhỏ của một slide và lưu nó dưới dạng hình PNG.

## **Render một slide bằng các quy tắc phông chữ dự phòng**

Ví dụ sau bao gồm các bước sau:

1. Chúng tôi [tạo bộ sưu tập các quy tắc phông chữ dự phòng](/slides/vi/net/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrule/methods/remove) một quy tắc phông chữ dự phòng và [AddFallBackFonts()](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) vào một quy tắc khác.
3. Đặt bộ sưu tập quy tắc vào thuộc tính [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
4. Với phương thức [Presentation.Save()](https://reference.aspose.com/slides/vi/net/aspose.slides.presentation/save/methods/4) chúng ta có thể lưu bản trình chiếu ở cùng định dạng, hoặc lưu nó ở định dạng khác. Sau khi bộ sưu tập các quy tắc phông chữ dự phòng được gán cho FontsManager, các quy tắc này sẽ được áp dụng trong mọi thao tác trên bản trình chiếu: lưu, render, chuyển đổi, v.v.

```c#
// Tạo một thể hiện mới của bộ sưu tập các quy tắc
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// tạo một số quy tắc
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Cố gắng xóa phông chữ FallBack "Tahoma" khỏi các quy tắc đã tải
	fallBackRule.Remove("Tahoma");

	// Và cập nhật các quy tắc cho phạm vi đã chỉ định
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Ngoài ra chúng ta có thể xóa bất kỳ quy tắc nào hiện có khỏi danh sách
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Gán danh sách các quy tắc đã chuẩn bị để sử dụng
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Render hình thu nhỏ bằng cách sử dụng bộ sưu tập các quy tắc đã khởi tạo và lưu dưới dạng PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
Đọc thêm về [Lưu và Chuyển đổi trong Presentation](/slides/vi/net/convert-powerpoint-to-png/).
{{% /alert %}}