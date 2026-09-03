---
title: Xử lý Cảnh báo Bản trình bày trong C++
type: docs
weight: 70
url: /vi/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback cảnh báo
- chính sách cảnh báo
- mất dữ liệu
- hư hỏng nguồn
- vấn đề tương thích
- thay thế phông chữ
- chữ ký số
- tải bản trình bày
- render bản trình bày
- chuyển đổi bản trình bày
- lưu bản trình bày
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Tìm hiểu cách thu thập, phân loại và xử lý các cảnh báo khi tải, render, chuyển đổi và lưu bản trình bày bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides có thể báo cáo các vấn đề có thể khôi phục được trong quá trình tải, hiển thị, chuyển đổi hoặc lưu một bản trình bày. Các ví dụ bao gồm các bản ghi nguồn bị hỏng, nội dung không thể được bảo tồn, việc thay thế phông chữ và các giới hạn của định dạng đích. Một callback cảnh báo cho phép ứng dụng ghi lại các điều kiện này và quyết định liệu hoạt động hiện tại có thể tiếp tục hay không.

Triển khai giao diện [IWarningCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides.warnings/iwarningcallback/) và xem xét các phương thức [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) và [IWarningInfo::get_Description](https://reference.aspose.com/slides/vi/cpp/aspose.slides.warnings/iwarninginfo/get_description/) được cung cấp qua [IWarningInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides.warnings/iwarninginfo/). Trả về [ReturnAction::Continue](https://reference.aspose.com/slides/vi/cpp/aspose.slides.warnings/returnaction/) để chấp nhận cảnh báo hoặc `ReturnAction::Abort` để dừng hoạt động.

Sử dụng [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_warningcallback/) cho các cảnh báo phát sinh khi mở bản trình bày. Các lớp tùy chọn render và xuất kế thừa [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveoptions/set_warningcallback/), nhận cảnh báo từ việc render slide, chuyển đổi và lưu. Vì cảnh báo không xác định trực tiếp hoạt động của ứng dụng, hãy gắn mỗi thể hiện callback với một giai đoạn hoạt động khi bạn xây dựng báo cáo tổng hợp.

## **Cảnh báo và Ngoại lệ**

Cảnh báo mô tả một tình huống mà Aspose.Slides có thể khôi phục nếu callback trả về `ReturnAction::Continue`. Ngoại lệ có nghĩa là thao tác được yêu cầu không thể hoàn thành bình thường; ngoại lệ không được chuyển thành cảnh báo và không thể được xử lý bởi chính sách cảnh báo.

Trả về `ReturnAction::Abort` yêu cầu trình phân phối cảnh báo dừng hoạt động hiện tại bằng cách ném một ngoại lệ. Kiểu ngoại lệ công khai phụ thuộc vào thao tác và định dạng bản trình bày. Ví dụ, quá trình tải có thể ném [PptxReadException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxreadexception/) hoặc [PptReadException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptreadexception/), trong khi lưu hoặc xuất có thể ném [PptxException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxexception/). Xử lý ngoại lệ ở ranh giới của thao tác và dùng báo cáo cảnh báo để xác định liệu chính sách ứng dụng đã gây ra việc dừng hay không thay vì dựa vào một kiểu ngoại lệ hay thông báo duy nhất. Callback ghi lại cảnh báo trước khi trả về `ReturnAction::Abort`, đảm bảo lý do vẫn có sẵn cho ứng dụng.

## **Các danh mục Cảnh báo**

Kiểu liệt kê [WarningType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.warnings/warningtype/) cung cấp các danh mục sau:

| Loại cảnh báo | Ý nghĩa | Chính sách điển hình |
| --- | --- | --- |
| `SourceFileCorruption` | Bản trình bày nguồn chứa lỗi có thể làm cho tài liệu được lưu ở định dạng gốc không sử dụng được. | Abort. |
| `DataLoss` | Văn bản, biểu đồ, hình ảnh hoặc dữ liệu khác có thể bị thiếu sau khi tải hoặc lưu. | Abort. |
| `MajorFormattingLoss` | Bản trình bày có thể mất định dạng quan trọng. | Abort trong chế độ kiểm tra nghiêm ngặt; nếu không ghi lại và tiếp tục. |
| `MinorFormattingLoss` | Một sự khác biệt định dạng hạn chế có thể xảy ra. | Ghi lại để chuẩn đoán và tiếp tục. |
| `CompatibilityIssue` | Kết quả có thể không mở hoặc không hoạt động đúng trong một số ứng dụng hoặc phiên bản cũ. | Ghi nhật ký và tiếp tục trừ khi tính tương thích là bắt buộc. |
| `UnexpectedContent` | Nguồn chứa nội dung không được hỗ trợ hoặc không nhận dạng, ảnh hưởng chưa biết. | Ghi lại và tiếp tục, hoặc coi là lỗi trong chính sách nghiêm ngặt. |

Danh mục này nên quyết định chính sách. Lưu mô tả cảnh báo để chuẩn đoán, nhưng không dựa vào nội dung văn bản cho logic ứng dụng vì thông điệp có thể thay đổi giữa các kịch bản và phiên bản sản phẩm.

## **Thu thập và Phân loại Cảnh báo**

Ví dụ sau sử dụng một báo cáo ở mức ứng dụng cho toàn bộ pipeline xử lý. Một thể hiện callback riêng biệt gắn nhãn cảnh báo từ tải, render, chuyển đổi PDF và lưu PPTX. Chính sách sẽ abort khi có lỗi nguồn hoặc mất dữ liệu, tùy chọn abort khi có mất định dạng lớn, và tiếp tục cho các cảnh báo còn lại.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

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
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Đặt `abortOnMajorFormattingLoss` thành `false` khi các khác biệt định dạng lớn là chấp nhận được. Các vấn đề tương thích, mất định dạng nhỏ và nội dung không mong đợi vẫn được giữ trong báo cáo ngay cả khi thao tác tiếp tục. Mở rộng `WarningPolicy::GetAction` nếu ứng dụng phải từ chối bất kỳ danh mục nào trong số này.

## **Các kịch bản Cảnh báo Thông thường**

Cảnh báo có thể xuất hiện ở các giai đoạn khác nhau của luồng công việc:

- **Chữ ký số:** Một bản trình bày đã ký có thể tạo cảnh báo trong quá trình tải rằng chữ ký sẽ bị mất trong quá trình xử lý. Aspose.Slides báo cáo tình huống `DataLoss` này qua [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Callback ở giai đoạn tải cho phép ứng dụng từ chối tệp hoặc chấp nhận mất mát đã báo cáo.
- **Thay thế phông chữ:** Khi một phông chữ không có sẵn được thay thế trong quá trình render hoặc xuất slide. Cảnh báo thay thế phông chữ được báo cáo là `DataLoss`, vì vậy chính sách nghiêm ngặt ở trên sẽ abort ngay cả khi ứng dụng coi một thay thế cụ thể là chấp nhận được về mặt hình ảnh. Để quan sát hành vi này, sử dụng bản trình bày đầu vào chứa văn bản bằng phông chữ không có trong runtime. Mô tả cảnh báo xác định việc thay thế; cấu hình các phông chữ cần thiết hoặc [font substitution rules](/slides/vi/cpp/font-substitution/) trước khi thử lại.
- **Nội dung không được hỗ trợ hoặc không mong đợi:** Bộ tải có thể gặp các bản ghi hoặc tính năng không nhận dạng. Các cảnh báo này có thể sử dụng `UnexpectedContent`, hoặc một danh mục nghiêm trọng hơn khi dữ liệu hoặc định dạng bị ảnh hưởng.
- **Tương thích định dạng:** Lưu sang một định dạng bản trình bày khác có thể bỏ qua tính năng hoặc tạo ra kết quả hoạt động khác trong một số ứng dụng. Ví dụ, lưu bản trình bày có hơn tám hướng dẫn vẽ ngang hoặc dọc vào PPT cổ điển sẽ báo cáo `CompatibilityIssue`. Callback ở giai đoạn lưu có thể ghi lại mất mát và tiếp tục, hoặc từ chối nếu yêu cầu bảo toàn toàn bộ các hướng dẫn.
- **Hành vi tải:** Các tùy chọn tải và hành vi kế thừa cũng có thể tạo cảnh báo. Ví dụ, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) xác định việc sử dụng hành vi khóa bản trình bày lỗi thời là một `CompatibilityIssue`.

Cảnh báo phụ thuộc vào tài liệu nguồn, định dạng đích, thao tác và phiên bản Aspose.Slides. Đừng giả định rằng mọi tệp đều tạo ra cảnh báo hoặc rằng một kịch bản luôn chỉ thuộc một danh mục duy nhất.

## **Xử lý An toàn Khi Thao tác Bị Hủy**

Khi một callback trả về `ReturnAction::Abort`, không sử dụng đối tượng đã không tải được và không giả định rằng kết quả render hoặc lưu đã hoàn thành. Thao tác có thể kết thúc sau khi tạo tệp đầu ra nhưng trước khi hoàn tất nó.

Lưu kết quả đã xác thực vào một đường dẫn riêng như `validated-output.pptx`. Thay thế bản trình bày hiện có chỉ sau khi thao tác kết thúc thành công, báo cáo cảnh báo đáp ứng chính sách ứng dụng, và tệp đầu ra có thể mở và kiểm tra. Điều này tránh ghi đè tệp nguồn hợp lệ bằng kết quả không đầy đủ hoặc bị từ chối.

Báo cáo cảnh báo rỗng không đảm bảo rằng mọi tính năng nguồn đã được bảo tồn. Thực hiện bất kỳ kiểm tra nội dung và hình ảnh bổ sung nào mà ứng dụng yêu cầu. Xem thêm [Open Presentations](/slides/vi/cpp/open-presentation/) và [Save Presentations](/slides/vi/cpp/save-presentation/).

## **Câu hỏi Thường gặp**

**Callback cảnh báo có thể xử lý mọi lỗi của Aspose.Slides không?**

Không. Nó chỉ xử lý các tình huống có thể khôi phục được và được báo cáo dưới dạng cảnh báo. Các ngoại lệ xảy ra độc lập với callback phải được ứng dụng xử lý quanh các lời gọi tải, render, chuyển đổi hoặc lưu.

**Việc trả về `ReturnAction::Continue` có đảm bảo đầu ra giống hệt không?**

Không. Nó chỉ cho phép quá trình tiếp tục. Tình huống đã báo cáo vẫn có thể gây ra sự khác biệt về dữ liệu, định dạng hoặc tính tương thích, vì vậy hãy xem xét các loại và mô tả cảnh báo đã thu thập.

**Ứng dụng có thể xác định được thao tác nào đã tạo ra cảnh báo như thế nào?**

Tạo một thể hiện callback cho mỗi thao tác và lưu trữ một giai đoạn do ứng dụng định nghĩa cùng với loại và mô tả cảnh báo, như trong ví dụ.