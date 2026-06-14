---
title: Hiển thị bản trình chiếu với phông chữ dự phòng trong C++
linktitle: Hiển thị bản trình chiếu
type: docs
weight: 30
url: /vi/cpp/render-presentation-with-fallback-font/
keywords:
- phông chữ dự phòng
- hiển thị PowerPoint
- hiển thị bản trình chiếu
- hiển thị slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Hiển thị bản trình chiếu với phông chữ dự phòng trong Aspose.Slides cho C++ – giữ nguyên nội dung văn bản trên PPT, PPTX và ODP với các mẫu mã C++ từng bước."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hiển thị bản trình chiếu bằng cách sử dụng các quy tắc phông chữ dự phòng. Bài viết này trình bày cách tạo bộ sưu tập quy tắc phông chữ dự phòng, chỉnh sửa các quy tắc bằng cách xóa hoặc thêm phông chữ dự phòng, và gán bộ sưu tập này bằng phương thức `FontsManager::set_FontFallBackRulesCollection`.

Khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho `FontsManager` của bản trình chiếu, các quy tắc sẽ được áp dụng trong các thao tác như lưu, hiển thị và chuyển đổi bản trình chiếu. Ví dụ minh họa cách sử dụng các quy tắc đã cấu hình khi hiển thị ảnh thu nhỏ của slide và lưu nó dưới dạng ảnh PNG.

## **Hiển thị Slide bằng Quy tắc Phông chữ Dự phòng**

Ví dụ dưới đây bao gồm các bước sau:

1. Chúng tôi [tạo bộ sưu tập quy tắc phông chữ dự phản](/slides/vi/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/remove/) một quy tắc phông chữ dự phòng và [AddFallBackFonts()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) vào một quy tắc khác.
3. Gửi bộ sưu tập quy tắc tới phương thức [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. Với phương thức [Presentation::Save()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) chúng ta có thể lưu bản trình chiếu ở cùng định dạng, hoặc lưu ở định dạng khác. Sau khi bộ sưu tập quy tắc phông chữ dự phòng được đặt cho FontsManager, các quy tắc này sẽ được áp dụng trong mọi thao tác trên bản trình chiếu: lưu, hiển thị, chuyển đổi, v.v.

``` cpp
// Tạo một thể hiện mới của bộ sưu tập quy tắc
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Tạo một số quy tắc
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Đang cố gắng xóa phông chữ FallBack "Tahoma" khỏi các quy tắc đã tải
	fallBackRule->Remove(u"Tahoma");

	// Và cập nhật các quy tắc cho phạm vi được chỉ định
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Ngoài ra chúng ta có thể xóa bất kỳ quy tắc nào hiện có trong danh sách
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Gán danh sách quy tắc đã chuẩn bị để sử dụng
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Kết xuất ảnh thu nhỏ bằng cách sử dụng bộ sưu tập quy tắc đã khởi tạo và lưu dưới dạng PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
Đọc thêm về cách [Chuyển đổi các slide PowerPoint sang PNG trong C++](/slides/vi/cpp/convert-powerpoint-to-png/).
{{% /alert %}}