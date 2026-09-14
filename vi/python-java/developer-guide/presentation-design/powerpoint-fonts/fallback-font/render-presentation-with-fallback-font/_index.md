---
title: Hiển thị bản trình chiếu với phông chữ dự phòng trong Python qua Java
linktitle: Hiển thị bản trình chiếu
type: docs
weight: 30
url: /vi/python-java/render-presentation-with-fallback-font/
keywords:
- phông chữ dự phòng
- hiển thị PowerPoint
- hiển thị bản trình chiếu
- hiển thị slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Render bản trình chiếu với phông chữ dự phòng trong Aspose.Slides cho Python qua Java – giữ văn bản nhất quán trên PPT, PPTX và ODP với các mẫu mã Python từng bước."
---
## **Tổng quan**

Aspose.Slides cho phép bạn render các bản trình bày bằng cách sử dụng các quy tắc phông chữ dự phòng. Bài viết này mô tả cách tạo một bộ sưu tập quy tắc phông chữ dự phòng, chỉnh sửa các quy tắc bằng cách xóa hoặc thêm phông chữ dự phòng, và gán bộ sưu tập này bằng phương thức [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

Khi bộ sưu tập quy tắc phông chữ dự phòng đã được gán cho [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/), các quy tắc sẽ được áp dụng trong các thao tác như lưu, render và chuyển đổi bản trình bày. Ví dụ minh họa cách sử dụng các quy tắc đã cấu hình khi render ảnh thu nhỏ của một slide và lưu nó dưới dạng ảnh JPEG.

## **Render một Slide bằng Quy tắc Phông chữ Dự phòng**

Các bước trong ví dụ sau bao gồm:

1. [Tạo một bộ sưu tập quy tắc phông chữ dự phòng](/slides/vi/python-java/create-fallback-fonts-collection/).
1. [Xóa](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrule/#remove) một phông chữ dự phòng khỏi một quy tắc và [thêm phông chữ dự phòng](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) vào một quy tắc khác.
1. Gán bộ sưu tập quy tắc bằng [setFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) trên font manager được trả về bởi [getFontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getFontsManager).
1. Sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để lưu bản trình bày ở cùng định dạng hoặc định dạng khác. Sau khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/), các quy tắc này sẽ được áp dụng trong các thao tác trên bản trình bày: lưu, render, chuyển đổi, v.v.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Tạo một bộ sưu tập quy tắc mới.
fallback_rules = FontFallBackRulesCollection()

# Tạo một số quy tắc.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Cố gắng xóa phông chữ dự phòng "Tahoma" khỏi các quy tắc.
    fallback_rule.remove("Tahoma")

    # Cập nhật các quy tắc cho phạm vi được chỉ định.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Xóa một quy tắc hiện có, giữ lại ít nhất một quy tắc để render.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Gán bộ sưu tập quy tắc đã chuẩn bị.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Render ảnh thu nhỏ sử dụng bộ sưu tập quy tắc đã cấu hình.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Lưu ảnh vào đĩa ở định dạng JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Đọc thêm về cách [chuyển đổi PPT và PPTX sang JPG bằng Python qua Java](/slides/vi/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}