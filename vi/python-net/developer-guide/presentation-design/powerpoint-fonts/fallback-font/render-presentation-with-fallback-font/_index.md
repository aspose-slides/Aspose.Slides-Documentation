---
title: Hiển thị bản trình chiếu với phông chữ dự phòng trong Python
linktitle: Hiển thị bản trình chiếu
type: docs
weight: 30
url: /vi/python-net/render-presentation-with-fallback-font/
keywords:
- phông chữ dự phòng
- hiển thị PowerPoint
- hiển thị bản trình chiếu
- hiển thị slide
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Hiển thị bản trình chiếu với phông chữ dự phòng trong Aspose.Slides cho Python qua .NET – giữ nguyên định dạng văn bản trên PPT, PPTX và ODP với các mẫu mã từng bước."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hiển thị các bản trình chiếu bằng cách sử dụng các quy tắc phông chữ dự phòng. Bài viết này hướng dẫn cách tạo bộ sưu tập quy tắc phông chữ dự phòng, sửa đổi các quy tắc bằng cách xóa hoặc thêm phông chữ dự phòng, và gán bộ sưu tập này cho thuộc tính `FontsManager.font_fall_back_rules_collection`.

Sau khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho `fonts_manager` của bản trình chiếu, các quy tắc sẽ được áp dụng trong các thao tác như lưu, hiển thị và chuyển đổi bản trình chiếu. Ví dụ minh họa cách sử dụng các quy tắc đã cấu hình khi hiển thị ảnh thu nhỏ của slide và lưu nó dưới dạng ảnh PNG.

## **Hiển thị một Slide bằng Quy tắc Phông chữ Dự phòng**

Các bước trong ví dụ sau bao gồm:

1. Chúng tôi [tạo bộ sưu tập quy tắc phông chữ dự phòng](/slides/vi/python-net/create-fallback-fonts-collection/).
1. [Xóa](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontfallbackrule/remove/) một quy tắc phông chữ dự phòng và [add_fall_back_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) vào một quy tắc khác.
1. Đặt bộ sưu tập quy tắc vào thuộc tính [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/).
1. Bằng phương thức [Presentation.save()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) chúng ta có thể lưu bản trình chiếu ở cùng định dạng, hoặc lưu ở định dạng khác. Khi bộ sưu tập quy tắc phông chữ dự phòng được đặt cho FontsManager, các quy tắc này sẽ được áp dụng trong bất kỳ thao tác nào trên bản trình chiếu: lưu, hiển thị, chuyển đổi, v.v.

```py
import aspose.slides as slides

# Tạo một thể hiện mới của bộ sưu tập quy tắc
rulesList = slides.FontFallBackRulesCollection()

# tạo một số quy tắc
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	#Cố gắng xóa phông chữ Dự phòng "Tahoma" khỏi các quy tắc đã tải
	fallBackRule.remove("Tahoma")

	#Và cập nhật các quy tắc cho phạm vi chỉ định
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

#Ngoài ra chúng ta có thể xóa bất kỳ quy tắc nào hiện có khỏi danh sách
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	#Gán danh sách quy tắc đã chuẩn bị để sử dụng
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Kết xuất ảnh thu nhỏ bằng cách sử dụng bộ sưu tập quy tắc đã khởi tạo và lưu dưới dạng PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
Đọc thêm về cách [Convert PowerPoint Slides to PNG in Python](/slides/vi/python-net/convert-powerpoint-to-png/).
{{% /alert %}}