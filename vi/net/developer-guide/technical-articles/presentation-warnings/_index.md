---
title: Xử lý cảnh báo bản trình bày trong .NET
type: docs
weight: 120
url: /vi/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback cảnh báo
- chính sách cảnh báo
- mất dữ liệu
- hỏng nguồn
- vấn đề tương thích
- thay thế phông chữ
- chữ ký kỹ thuật số
- tải bản trình bày
- kết xuất bản trình bày
- chuyển đổi bản trình bày
- lưu bản trình bày
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thu thập, phân loại và xử lý các cảnh báo khi tải, kết xuất, chuyển đổi và lưu bản trình bày bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides có thể báo cáo các vấn đề có thể khôi phục được trong khi tải, render, chuyển đổi hoặc lưu một bản trình bày. Ví dụ bao gồm các bản ghi nguồn bị hỏng, nội dung không thể bảo toàn, việc thay thế phông chữ và các giới hạn của định dạng đích. Callback cảnh báo cho phép ứng dụng ghi lại các điều kiện này và quyết định liệu hoạt động hiện tại có thể tiếp tục hay không.

Triển khai giao diện [IWarningCallback](https://reference.aspose.com/slides/vi/net/aspose.slides.warnings/iwarningcallback/) và kiểm tra các thuộc tính [WarningType](https://reference.aspose.com/slides/vi/net/aspose.slides.warnings/iwarninginfo/warningtype/) và [Description](https://reference.aspose.com/slides/vi/net/aspose.slides.warnings/iwarninginfo/description/) được cung cấp qua [IWarningInfo](https://reference.aspose.com/slides/vi/net/aspose.slides.warnings/iwarninginfo/). Trả về [ReturnAction.Continue](https://reference.aspose.com/slides/vi/net/aspose.slides.warnings/returnaction/) để chấp nhận cảnh báo hoặc `ReturnAction.Abort` để dừng hoạt động.

Sử dụng [LoadOptions.WarningCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/warningcallback/) cho các cảnh báo được đưa ra khi mở một bản trình bày. Các lớp tùy chọn render và xuất kế thừa [SaveOptions.WarningCallback](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/warningcallback/), nhận các cảnh báo từ việc render slide, chuyển đổi và lưu. Vì cảnh báo tự nó không xác định hoạt động của ứng dụng, hãy gắn mỗi thể hiện callback với một giai đoạn hoạt động khi bạn xây dựng báo cáo tổng hợp.

## **Cảnh báo và Ngoại lệ**

Một cảnh báo mô tả một điều kiện mà Aspose.Slides có thể khôi phục nếu callback trả về `ReturnAction.Continue`. Một ngoại lệ có nghĩa là hoạt động yêu cầu không thể hoàn thành bình thường; ngoại lệ không được chuyển đổi thành cảnh báo và không thể được xử lý bằng chính sách cảnh báo.

Việc trả về `ReturnAction.Abort` yêu cầu bộ phân phối cảnh báo kết thúc hoạt động hiện tại bằng cách ném một ngoại lệ. Loại ngoại lệ công khai phụ thuộc vào hoạt động và định dạng bản trình bày. Ví dụ, quá trình tải có thể sinh ra [PptxReadException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxreadexception/) hoặc [PptReadException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptreadexception/), trong khi lưu hoặc xuất có thể sinh ra [PptxException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxexception/). Xử lý ngoại lệ tại ranh giới của hoạt động và sử dụng báo cáo cảnh báo để xác định liệu chính sách của ứng dụng đã gây ra việc kết thúc hay không, thay vì dựa vào một kiểu phụ ngoại lệ hoặc thông điệp duy nhất. Callback ghi lại cảnh báo trước khi trả về `ReturnAction.Abort`, đảm bảo lý do vẫn có sẵn cho ứng dụng.

## **Các danh mục cảnh báo**

Enumeration [WarningType](https://reference.aspose.com/slides/vi/net/aspose.slides.warnings/warningtype/) cung cấp các danh mục sau:

| Loại cảnh báo | Ý nghĩa | Chính sách điển hình |
| --- | --- | --- |
| `SourceFileCorruption` | Bản trình bày nguồn chứa lỗi gây khiến tài liệu được lưu ở định dạng gốc không sử dụng được. | Hủy. |
| `DataLoss` | Văn bản, biểu đồ, hình ảnh hoặc dữ liệu khác có thể thiếu sau khi tải hoặc lưu. | Hủy. |
| `MajorFormattingLoss` | Bản trình bày có thể mất định dạng quan trọng. | Hủy trong chế độ kiểm tra nghiêm ngặt; nếu không, ghi lại và tiếp tục. |
| `MinorFormattingLoss` | Có thể xảy ra một sự khác biệt định dạng hạn chế. | Ghi lại để chẩn đoán và tiếp tục. |
| `CompatibilityIssue` | Kết quả có thể không mở được hoặc hoạt động không đúng trong một số ứng dụng hoặc phiên bản cũ. | Ghi lại và tiếp tục trừ khi tính tương thích là bắt buộc. |
| `UnexpectedContent` | Nguồn chứa nội dung không được hỗ trợ hoặc không nhận dạng được và hiệu quả của nó có thể chưa được biết. | Ghi lại và tiếp tục, hoặc xem như lỗi trong chính sách nghiêm ngặt. |

Danh mục nên quyết định chính sách. Lưu `Description` để chẩn đoán, nhưng không dựa vào nội dung của nó cho logic ứng dụng vì văn bản thông báo có thể thay đổi giữa các kịch bản cảnh báo và các phiên bản sản phẩm.

## **Thu thập và phân loại cảnh báo**

Ví dụ sau sử dụng một báo cáo mức ứng dụng cho toàn bộ pipeline xử lý. Một thể hiện callback riêng ghi nhãn các cảnh báo từ việc tải, render, chuyển đổi PDF và lưu PPTX. Chính sách hủy khi gặp lỗi hỏng nguồn hoặc mất dữ liệu, tùy chọn hủy khi mất định dạng quan trọng, và tiếp tục cho các cảnh báo khác.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Đặt `abortOnMajorFormattingLoss` thành `false` khi các khác biệt định dạng quan trọng là chấp nhận được. Các vấn đề tương thích, mất định dạng nhỏ và nội dung không mong đợi vẫn được giữ trong báo cáo ngay cả khi hoạt động tiếp tục. Mở rộng `WarningPolicy.GetAction` nếu ứng dụng phải từ chối bất kỳ danh mục nào trong số này.

## **Các kịch bản cảnh báo phổ biến**

Cảnh báo có thể xuất hiện ở các giai đoạn khác nhau của quy trình làm việc:

- **Chữ ký kỹ thuật số:** Một bản trình bày đã ký có thể tạo ra cảnh báo trong quá trình tải rằng chữ ký sẽ bị mất trong quá trình xử lý. Aspose.Slides báo cáo điều kiện `DataLoss` này thông qua [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/vi/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Một callback ở giai đoạn tải cho phép ứng dụng từ chối tệp hoặc chấp nhận rõ ràng sự mất mát được báo cáo.
- **Thay thế phông chữ:** Một phông chữ không có sẵn có thể được thay thế khi slide được render hoặc xuất. Các cảnh báo thay thế phông chữ được báo cáo là `DataLoss`, vì vậy chính sách nghiêm ngặt ở trên sẽ hủy ngay cả khi ứng dụng coi một thay thế cụ thể là chấp nhận được về mặt hình ảnh. Để quan sát hành vi này, sử dụng bản trình bày đầu vào chứa văn bản bằng phông chữ không có sẵn cho runtime. Mô tả cảnh báo xác định việc thay thế; cấu hình các phông chữ cần thiết hoặc [font substitution rules](/slides/vi/net/font-substitution/) trước khi thử lại.
- **Nội dung không hỗ trợ hoặc không mong đợi:** Trình tải có thể gặp các bản ghi hoặc tính năng của bản trình bày mà nó không nhận ra. Các cảnh báo như vậy có thể sử dụng `UnexpectedContent`, hoặc một danh mục nghiêm trọng hơn khi dữ liệu hoặc định dạng biết là bị ảnh hưởng.
- **Tương thích định dạng:** Lưu sang định dạng bản trình bày khác có thể bỏ qua các tính năng hoặc tạo ra kết quả hoạt động khác nhau trong một số ứng dụng. Ví dụ, lưu một bản trình bày có hơn tám hướng dẫn vẽ ngang hoặc dọc sang PPT truyền thống sẽ báo cáo một `CompatibilityIssue`. Callback ở giai đoạn lưu có thể ghi lại sự mất mát và tiếp tục, hoặc từ chối nếu cần bảo toàn tất cả các hướng dẫn.
- **Hành vi tải:** Các tùy chọn tải và hành vi kế thừa cũng có thể tạo ra cảnh báo. Ví dụ, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/vi/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) xác định việc sử dụng hành vi khóa bản trình bày lỗi thời như một `CompatibilityIssue`.

Cảnh báo phụ thuộc vào tài liệu nguồn, định dạng đích, hoạt động và phiên bản Aspose.Slides. Đừng giả định rằng mọi tệp đều tạo ra cảnh báo hoặc rằng một kịch bản luôn chỉ thuộc một danh mục.

## **Xử lý an toàn các hoạt động bị hủy**

Khi một callback trả về `ReturnAction.Abort`, không sử dụng đối tượng không tải được và không giả định rằng output render hoặc lưu đã hoàn thành. Hoạt động có thể kết thúc sau khi tạo file output nhưng chưa hoàn thiện nó.

Lưu kết quả đã xác thực vào một đường dẫn riêng như `validated-output.pptx`. Thay thế bản trình bày hiện có chỉ sau khi hoạt động kết thúc thành công, báo cáo cảnh báo đáp ứng chính sách của ứng dụng, và output có thể được mở và kiểm tra. Điều này tránh ghi đè một tệp nguồn hợp lệ bằng một kết quả một phần hoặc bị từ chối.

Báo cáo cảnh báo rỗng không bảo đảm rằng mọi tính năng nguồn đã được bảo toàn. Áp dụng bất kỳ kiểm tra nội dung và hình ảnh bổ sung nào cần thiết cho ứng dụng. Xem thêm [Open Presentations](/slides/vi/net/open-presentation/) và [Save Presentations](/slides/vi/net/save-presentation/).

## **Câu hỏi thường gặp**

**Callback cảnh báo có thể xử lý mọi lỗi của Aspose.Slides không?**

Không. Nó chỉ xử lý các điều kiện có thể khôi phục được được báo cáo dưới dạng cảnh báo. Các ngoại lệ xảy ra độc lập với callback phải được ứng dụng xử lý xung quanh lời gọi tải, render, chuyển đổi hoặc lưu.

**Trả về `ReturnAction.Continue` có đảm bảo đầu ra giống hệt không?**

Không. Nó chỉ cho phép tiếp tục xử lý. Điều kiện được báo cáo vẫn có thể gây ra sự khác biệt về dữ liệu, định dạng hoặc tương thích, vì vậy hãy xem xét các loại cảnh báo và mô tả đã thu thập.

**Ứng dụng có thể xác định hoạt động nào đã tạo ra cảnh báo như thế nào?**

Tạo một thể hiện callback cho mỗi hoạt động và lưu trữ giai đoạn do ứng dụng định nghĩa cùng với `WarningType` và `Description`, như trong ví dụ.