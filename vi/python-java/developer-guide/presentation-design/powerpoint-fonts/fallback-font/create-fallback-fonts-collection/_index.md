---
title: Cấu hình Bộ sưu tập Phông chữ Dự phòng trong Python qua Java
linktitle: Bộ sưu tập Phông chữ Dự phòng
type: docs
weight: 20
url: /vi/python-java/create-fallback-fonts-collection/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- bộ sưu tập phông chữ
- cấu hình phông chữ
- cài đặt phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Thiết lập một bộ sưu tập phông chữ dự phòng trong Aspose.Slides cho Python qua Java để giữ cho văn bản nhất quán và sắc nét trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn cấu hình một bộ quy tắc phông chữ dự phòng cho một bản trình chiếu. Mỗi quy tắc dự phòng được biểu diễn bằng lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrule/) và có thể được thêm vào một [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrulescollection/).

Sau khi tạo bộ sưu tập, bạn có thể gán nó bằng phương thức [setFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) của [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/) của bản trình chiếu. [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/) kiểm soát phông chữ trên toàn bộ bản trình chiếu, và mỗi đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) có riêng mình một [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/).

Khi [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/) được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng được chỉ định sẽ được áp dụng trong quá trình render bản trình chiếu.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrule/) có thể được tổ chức thành một [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrulescollection/). Bạn có thể thêm hoặc xóa các quy tắc khỏi bộ sưu tập.

Bộ sưu tập này sau đó có thể được gán bằng phương thức [setFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) của lớp [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/), lớp kiểm soát phông chữ trên toàn bộ bản trình chiếu.

Mỗi [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) có một phương thức [getFontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getFontsManager) trả về thể hiện riêng của nó đối với lớp [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/).

Ví dụ sau cho thấy cách tạo một bộ quy tắc phông chữ dự phòng và gán nó cho [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/) của một bản trình chiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Sau khi [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/) được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng sẽ được áp dụng trong quá trình render bản trình chiếu.

{{% alert color="info" title="Note" %}}
Tìm hiểu thêm về cách [render một bản trình chiếu với phông chữ dự phòng](/slides/vi/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Các quy tắc dự phòng của tôi có được nhúng vào tệp PPTX và hiển thị trong PowerPoint sau khi lưu không?**

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy; chúng không được ghi vào PPTX và sẽ không xuất hiện trong giao diện PowerPoint.

**Quy tắc dự phòng có áp dụng cho văn bản trong SmartArt, WordArt, biểu đồ và bảng không?**

Có. Cùng một cơ chế thay thế glyph được sử dụng cho bất kỳ văn bản nào trong các đối tượng này.

**Aspose có phân phối bất kỳ phông chữ nào cùng với thư viện không?**

Không. Bạn tự thêm và sử dụng phông chữ và chịu trách nhiệm hoàn toàn.

**Có thể sử dụng đồng thời việc thay thế/đối thế cho các phông chữ thiếu và dự phòng cho các glyph thiếu không?**

Có. Chúng là các giai đoạn độc lập của cùng một quy trình giải quyết phông chữ: đầu tiên engine giải quyết tính khả dụng của phông chữ ([replacement](/slides/vi/python-java/font-replacement/)/[substitution](/slides/vi/python-java/font-substitution/)), sau đó dự phòng lấp đầy các khoảng trống cho các glyph thiếu trong các phông chữ có sẵn.