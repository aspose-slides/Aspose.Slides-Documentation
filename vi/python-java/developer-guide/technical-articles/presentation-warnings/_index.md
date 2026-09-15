---
title: Xử lý cảnh báo bản trình chiếu trong Python thông qua Java
type: docs
weight: 90
url: /vi/python-java/presentation-warnings/
aliases:
- /python-java/lay-cac-callback-canh-bao-cho-thay-the-phong-chu-trong-aspose-slides/
keywords:
- callback cảnh báo
- chính sách cảnh báo
- mất dữ liệu
- hỏng nguồn
- vấn đề tương thích
- thay thế phông chữ
- chữ ký số
- tải bản trình chiếu
- render bản trình chiếu
- chuyển đổi bản trình chiếu
- lưu bản trình chiếu
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách thu thập, phân loại và xử lý các cảnh báo khi tải, render, chuyển đổi và lưu bản trình chiếu bằng Aspose.Slides cho Python thông qua Java."
---
## **Tổng quan**

Aspose.Slides có thể báo cáo các vấn đề có thể khôi phục được khi nó tải, render, chuyển đổi hoặc lưu một bản trình chiếu. Các ví dụ bao gồm các bản ghi nguồn bị hỏng, nội dung không thể được bảo toàn, thay thế phông chữ và các hạn chế của định dạng đích. Callback cảnh báo cho phép ứng dụng ghi lại các điều kiện này và quyết định liệu thao tác hiện tại có thể tiếp tục hay không.

Triển khai giao diện `IWarningCallback` thông qua `jpype.JProxy` và kiểm tra các giá trị `getWarningType` và `getDescription` được cung cấp qua `IWarningInfo`. Trả về [ReturnAction.Continue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/returnaction/#Continue) để chấp nhận cảnh báo hoặc [ReturnAction.Abort](https://reference.aspose.com/slides/vi/python-java/aspose.slides/returnaction/#Abort) để dừng thao tác.

Sử dụng [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setWarningCallback) cho các cảnh báo phát sinh khi mở một bản trình chiếu. Các lớp tùy chọn render và xuất kế thừa [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveoptions/#setWarningCallback), nhận cảnh báo từ việc render slide, chuyển đổi và lưu. Vì cảnh báo tự nó không xác định được thao tác của ứng dụng, hãy gắn mỗi thể hiện callback với một giai đoạn thao tác khi bạn xây dựng báo cáo tổng hợp.

## **Cảnh báo và Ngoại lệ**

Một cảnh báo mô tả một điều kiện mà Aspose.Slides có thể khôi phục nếu callback trả về `ReturnAction.Continue`. Một ngoại lệ nghĩa là thao tác được yêu cầu không thể hoàn thành bình thường; ngoại lệ không được chuyển đổi thành cảnh báo và không thể được xử lý bằng chính sách cảnh báo.

Trả về `ReturnAction.Abort` yêu cầu bộ phân phối cảnh báo kết thúc thao tác hiện tại bằng cách ném một ngoại lệ. Loại ngoại lệ công khai phụ thuộc vào thao tác và định dạng bản trình chiếu. Ví dụ, khi tải có thể phát sinh [PptxReadException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxreadexception/) hoặc [PptReadException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptreadexception/), trong khi lưu hoặc xuất có thể phát sinh [PptxException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxexception/). Xử lý ngoại lệ tại ranh giới của thao tác và dùng báo cáo cảnh báo để xác định liệu chính sách ứng dụng đã gây ra việc kết thúc hay không, thay vì phụ thuộc vào một loại ngoại lệ hoặc thông điệp duy nhất. Callback ghi lại cảnh báo trước khi trả về `ReturnAction.Abort`, đảm bảo lý do vẫn còn sẵn cho ứng dụng.

## **Các loại Cảnh báo**

Lớp [WarningType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/warningtype/) cung cấp các hằng số nguyên cho các loại sau:

| Loại cảnh báo | Ý nghĩa | Chính sách thường gặp |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/vi/python-java/aspose.slides/warningtype/#SourceFileCorruption) | Bản trình chiếu nguồn chứa dữ liệu hỏng có thể làm cho tài liệu được lưu ở định dạng gốc không sử dụng được. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/vi/python-java/aspose.slides/warningtype/#DataLoss) | Văn bản, biểu đồ, hình ảnh hoặc dữ liệu khác có thể bị thiếu sau khi tải hoặc lưu. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/vi/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | Bản trình chiếu có thể mất định dạng quan trọng. | Abort trong chế độ kiểm tra nghiêm ngặt; nếu không, ghi lại và tiếp tục. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/vi/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Có thể xảy ra một sự khác biệt định dạng hạn chế. | Ghi lại để chẩn đoán và tiếp tục. |
| [CompatibilityIssue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Kết quả có thể không mở hoặc không hoạt động đúng trong một số ứng dụng hoặc phiên bản cũ. | Ghi nhật ký và tiếp tục trừ khi tính tương thích là bắt buộc. |
| [UnexpectedContent](https://reference.aspose.com/slides/vi/python-java/aspose.slides/warningtype/#UnexpectedContent) | Nguồn chứa nội dung không hỗ trợ hoặc không nhận diện được, ảnh hưởng có thể chưa rõ. | Ghi lại và tiếp tục, hoặc coi là lỗi trong chính sách nghiêm ngặt. |

Loại cảnh báo sẽ quyết định chính sách thực thi. Lưu giá trị trả về bởi `getDescription` để chẩn đoán, nhưng không dựa vào cách diễn đạt của nó cho logic ứng dụng vì văn bản thông điệp có thể thay đổi giữa các kịch bản cảnh báo và các phiên bản sản phẩm.

## **Thu thập và Phân loại Cảnh báo**

Ví dụ sau sử dụng một báo cáo cấp ứng dụng cho toàn bộ pipeline xử lý. Một thể hiện callback riêng biệt gắn nhãn cho các cảnh báo từ tải, render, chuyển đổi PDF và lưu PPTX. Chính sách sẽ abort khi gặp hỏng nguồn hoặc mất dữ liệu, tùy chọn abort khi mất định dạng lớn, và tiếp tục với các cảnh báo khác.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Truyền `False` cho `abort_on_major_formatting_loss` khi khởi tạo `WarningPolicy` nếu chấp nhận khác biệt định dạng lớn. Các vấn đề tương thích, mất định dạng nhỏ và nội dung bất ngờ vẫn được giữ trong báo cáo ngay cả khi thao tác tiếp tục. Mở rộng `WarningPolicy.get_action` nếu ứng dụng cần từ chối bất kỳ loại nào trong số này.

## **Các Kịch bản Cảnh báo Thông thường**

Cảnh báo có thể xuất hiện ở các giai đoạn khác nhau của quy trình làm việc:

- **Chữ ký kỹ thuật số:** Một bản trình chiếu đã ký có thể tạo ra cảnh báo khi tải rằng chữ ký sẽ bị mất trong quá trình xử lý. Aspose.Slides báo cáo trạng thái `DataLoss` này qua `IPresentationSignedWarningInfo`. Callback ở giai đoạn tải cho phép ứng dụng từ chối tệp hoặc chấp nhận mất mát được báo cáo một cách rõ ràng.
- **Thay thế phông chữ:** Một phông chữ không có sẵn có thể được thay thế khi slide được render hoặc xuất. Cảnh báo thay thế phông chữ được báo cáo là `DataLoss`, do đó chính sách nghiêm ngặt ở trên sẽ abort ngay cả khi ứng dụng cho rằng thay thế này chấp nhận được về mặt hình ảnh. Để quan sát hành vi này, sử dụng bản trình chiếu đầu vào chứa văn bản ở phông chữ không có trong môi trường runtime. Mô tả cảnh báo sẽ chỉ ra việc thay thế; hãy cấu hình phông chữ cần thiết hoặc [font substitution rules](/slides/vi/python-java/font-substitution/) trước khi thử lại.
- **Nội dung không hỗ trợ hoặc bất ngờ:** Trình tải có thể gặp các bản ghi hoặc tính năng không nhận dạng được. Những cảnh báo này có thể sử dụng `UnexpectedContent`, hoặc một loại nghiêm trọng hơn khi dữ liệu hoặc định dạng chắc chắn bị ảnh hưởng.
- **Tương thích định dạng:** Lưu sang định dạng bản trình chiếu khác có thể bỏ qua một số tính năng hoặc tạo ra kết quả hoạt động khác nhau trong một số ứng dụng. Ví dụ, lưu một bản trình chiếu có hơn tám hướng dẫn vẽ ngang hoặc dọc vào PPT cũ sẽ báo cáo một `CompatibilityIssue`. Callback ở giai đoạn lưu có thể ghi lại mất mát và tiếp tục, hoặc từ chối nếu cần giữ nguyên tất cả các hướng dẫn.
- **Hành vi tải:** Các tùy chọn tải và hành vi kế thừa cũng có thể tạo ra cảnh báo. Ví dụ, `IObsoletePresLockingBehaviorWarningInfo` xác định việc sử dụng hành vi khóa bản trình chiếu lỗi thời như một `CompatibilityIssue`.

Cảnh báo phụ thuộc vào tài liệu nguồn, định dạng đích, thao tác và phiên bản Aspose.Slides. Đừng giả định rằng mọi tệp đều tạo ra cảnh báo hoặc một kịch bản luôn thuộc về một loại duy nhất.

## **Xử lý An toàn Khi Thao tác Bị Abort**

Khi một callback trả về `ReturnAction.Abort`, không dùng đối tượng đã không tải được và không giả định rằng kết quả render hoặc lưu đã hoàn thiện. Thao tác có thể kết thúc sau khi tạo tệp đầu ra nhưng trước khi hoàn thiện nó.

Lưu kết quả đã được kiểm chứng vào một đường dẫn riêng, ví dụ `validated-output.pptx`. Thay thế bản trình chiếu hiện có chỉ sau khi thao tác hoàn thành thành công, báo cáo cảnh báo đáp ứng chính sách ứng dụng và đầu ra có thể mở và kiểm tra. Điều này tránh việc ghi đè lên tệp nguồn hợp lệ bằng kết quả không đầy đủ hoặc bị từ chối.

Báo cáo cảnh báo rỗng không đồng nghĩa với việc mọi tính năng nguồn đã được bảo tồn. Thực hiện bất kỳ kiểm tra nội dung và hình ảnh bổ sung nào mà ứng dụng yêu cầu. Xem thêm [Open Presentations](/slides/vi/python-java/open-presentation/) và [Save Presentations](/slides/vi/python-java/save-presentation/).

## **Câu hỏi thường gặp**

**Callback cảnh báo có thể xử lý mọi lỗi của Aspose.Slides không?**

Không. Nó chỉ xử lý các điều kiện có thể khôi phục được được báo cáo dưới dạng cảnh báo. Các ngoại lệ xảy ra độc lập với callback phải được ứng dụng xử lý xung quanh các lời gọi tải, render, chuyển đổi hoặc lưu.

**Trả về `ReturnAction.Continue` có đảm bảo đầu ra giống hệt không?**

Không. Nó chỉ cho phép quá trình tiếp tục. Điều kiện đã báo cáo vẫn có thể gây ra sự khác biệt về dữ liệu, định dạng hoặc tính tương thích, vì vậy hãy xem xét các loại và mô tả cảnh báo đã thu thập.

**Ứng dụng có thể xác định thao tác nào đã tạo ra cảnh báo như thế nào?**

Tạo một thể hiện callback cho mỗi thao tác và lưu trữ một giai đoạn được định nghĩa bởi ứng dụng cùng với các giá trị trả về bởi `getWarningType` và `getDescription`, như trong ví dụ.