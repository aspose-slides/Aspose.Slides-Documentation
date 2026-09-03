---
title: Xử lý Cảnh báo Bản trình chiếu trong Node.js
type: docs
weight: 90
url: /vi/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Tìm hiểu cách thu thập, phân loại và xử lý các cảnh báo khi tải, render, chuyển đổi và lưu bản trình chiếu với Aspose.Slides cho Node.js thông qua Java."
---
## **Tổng quan**

Aspose.Slides có thể báo cáo các vấn đề có thể khôi phục được khi nó tải, render, chuyển đổi hoặc lưu một bản trình chiếu. Các ví dụ bao gồm các bản ghi nguồn bị hỏng, nội dung không thể bảo tồn, thay thế phông chữ và các hạn chế của định dạng đích. Một callback cảnh báo cho phép ứng dụng ghi lại những điều kiện này và quyết định liệu thao tác hiện tại có thể tiếp tục hay không.

Sử dụng `java.newProxy` để triển khai giao diện Java [IWarningCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarningcallback/) trong JavaScript và kiểm tra các giá trị [getWarningType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getWarningType--) và [getDescription](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getDescription--) được cung cấp thông qua [IWarningInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/). Trả về [ReturnAction.Continue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/returnaction/#Continue) để chấp nhận cảnh báo hoặc [ReturnAction.Abort](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/returnaction/#Abort) để dừng thao tác.

Sử dụng [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) cho các cảnh báo được đưa ra khi mở một bản trình chiếu. Các lớp tùy chọn render và xuất kế thừa [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), nhận các cảnh báo từ việc render slide, chuyển đổi và lưu. Vì cảnh báo không xác định thao tác của ứng dụng, hãy gắn mỗi đối tượng callback với một giai đoạn thao tác khi bạn xây dựng báo cáo tổng hợp.

## **Cảnh báo và Ngoại lệ**

Một cảnh báo mô tả một điều kiện mà Aspose.Slides có thể khôi phục nếu callback trả về `ReturnAction.Continue`. Một ngoại lệ có nghĩa là thao tác yêu cầu không thể hoàn thành bình thường; ngoại lệ không được chuyển thành cảnh báo và không thể được xử lý bằng chính sách cảnh báo.

Trả về `ReturnAction.Abort` yêu cầu bộ phân phối cảnh báo kết thúc thao tác hiện tại bằng cách ném một ngoại lệ. Loại ngoại lệ công khai phụ thuộc vào thao tác và định dạng bản trình chiếu. Ví dụ, quá trình tải có thể sinh ra [PptxReadException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxreadexception/) hoặc [PptReadException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptreadexception/), trong khi lưu hoặc xuất có thể sinh ra [PptxException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxexception/). Bắt lỗi từ cầu nối Java tại ranh giới của thao tác và sử dụng báo cáo cảnh báo để xác định liệu chính sách ứng dụng đã gây ra việc dừng hay không, thay vì chỉ dựa vào một loại ngoại lệ hoặc thông điệp. Callback ghi lại cảnh báo trước khi trả về `ReturnAction.Abort`, đảm bảo lý do vẫn còn sẵn cho ứng dụng.

## **Các danh mục cảnh báo**

Lớp [WarningType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/warningtype/) cung cấp các hằng số nguyên cho các danh mục sau:

| Loại cảnh báo | Ý nghĩa | Chính sách điển hình |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | Bản trình chiếu nguồn chứa dữ liệu bị hỏng có thể làm cho tài liệu được lưu ở định dạng gốc không sử dụng được. | Hủy. |
| [DataLoss](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/warningtype/#DataLoss) | Văn bản, biểu đồ, hình ảnh hoặc dữ liệu khác có thể thiếu sau khi tải hoặc lưu. | Hủy. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | Bản trình chiếu có thể mất định dạng quan trọng. | Hủy trong chế độ xác thực nghiêm ngặt; nếu không, ghi lại và tiếp tục. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Có thể xảy ra một sự khác biệt định dạng hạn chế. | Ghi lại để chẩn đoán và tiếp tục. |
| [CompatibilityIssue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Kết quả có thể không mở hoặc không hoạt động đúng trong một số ứng dụng hoặc phiên bản cũ. | Ghi log và tiếp tục trừ khi tính tương thích là bắt buộc. |
| [UnexpectedContent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | Nguồn chứa nội dung không được hỗ trợ hoặc không nhận dạng được, ảnh hưởng của nó có thể chưa được biết. | Ghi lại và tiếp tục, hoặc xem như lỗi trong chính sách nghiêm ngặt. |

Danh mục nên quyết định chính sách. Lưu giá trị trả về bởi [getDescription](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getDescription--) để chẩn đoán, nhưng không dựa vào nội dung văn bản này cho logic ứng dụng vì nội dung thông điệp có thể thay đổi giữa các kịch bản cảnh báo và các phiên bản sản phẩm.

## **Thu thập và Phân loại Cảnh báo**

Ví dụ JavaScript dưới đây sử dụng một báo cáo cấp ứng dụng cho toàn bộ pipeline xử lý. Một đối tượng callback riêng biệt gắn nhãn cho các cảnh báo từ tải, render, chuyển đổi PDF và lưu PPTX. Chính sách hủy khi gặp hỏng nguồn hoặc mất dữ liệu, tùy chọn hủy khi mất định dạng quan trọng, và tiếp tục với các cảnh báo còn lại.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Đặt `false` cho `abortOnMajorFormattingLoss` khi khởi tạo `WarningPolicy` nếu chấp nhận các khác biệt định dạng quan trọng. Các vấn đề về tính tương thích, mất định dạng nhẹ và nội dung không mong đợi vẫn được giữ trong báo cáo ngay cả khi thao tác tiếp tục. Mở rộng `WarningPolicy.getAction` nếu ứng dụng phải từ chối bất kỳ danh mục nào trong số này.

## **Kịch bản Cảnh báo Thông thường**

- **Chữ ký số:** Một bản trình chiếu đã ký có thể tạo ra cảnh báo khi tải rằng chữ ký sẽ bị mất trong quá trình xử lý. Aspose.Slides báo cáo điều kiện `DataLoss` này qua [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback ở giai đoạn tải cho phép ứng dụng từ chối tệp hoặc chấp nhận rõ ràng việc mất dữ liệu đã báo cáo.
- **Thay thế phông chữ:** Một phông chữ không có sẵn có thể được thay thế khi slide được render hoặc xuất. Cảnh báo thay thế phông chữ được báo cáo là `DataLoss`, vì vậy chính sách nghiêm ngặt ở trên sẽ hủy ngay cả khi ứng dụng cho rằng sự thay thế đó chấp nhận được về mặt hình ảnh. Để quan sát hành vi này, hãy dùng bản trình chiếu đầu vào chứa văn bản bằng phông chữ không có sẵn cho môi trường chạy. Mô tả cảnh báo chỉ ra sự thay thế; cấu hình các phông chữ cần thiết hoặc [quy tắc thay thế phông chữ](/slides/vi/nodejs-java/font-substitution/) trước khi thử lại.
- **Nội dung không hỗ trợ hoặc không mong đợi:** Trình tải có thể gặp các bản ghi hoặc tính năng mà nó không nhận ra. Các cảnh báo như vậy có thể sử dụng `UnexpectedContent`, hoặc một danh mục nghiêm trọng hơn khi dữ liệu hoặc định dạng được biết là bị ảnh hưởng.
- **Tương thích định dạng:** Lưu sang định dạng bản trình chiếu khác có thể bỏ qua tính năng hoặc tạo ra kết quả hoạt động khác nhau trong một số ứng dụng. Ví dụ, lưu một bản trình chiếu có hơn tám hướng dẫn vẽ ngang hoặc dọc sang PPT cổ điển sẽ báo cáo `CompatibilityIssue`. Callback ở giai đoạn lưu có thể ghi lại mất mát và tiếp tục, hoặc từ chối nếu việc bảo toàn mọi hướng dẫn là bắt buộc.
- **Hành vi tải:** Các tùy chọn tải và hành vi kế thừa cũng có thể tạo ra cảnh báo. Ví dụ, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) xác định việc sử dụng hành vi khóa bản trình chiếu lỗi thời như một `CompatibilityIssue`.

Cảnh báo phụ thuộc vào tài liệu nguồn, định dạng đích, thao tác và phiên bản Aspose.Slides. Đừng giả định rằng mọi tệp đều tạo ra cảnh báo hoặc một kịch bản luôn chỉ thuộc một danh mục duy nhất.

## **Xử lý an toàn các thao tác bị hủy**

Khi một callback trả về `ReturnAction.Abort`, không sử dụng đối tượng đã tải không thành công và không cho rằng đầu ra render hoặc lưu đã hoàn thiện. Thao tác có thể kết thúc sau khi tạo tệp đầu ra nhưng trước khi quá trình hoàn thành.

Lưu kết quả đã xác thực vào một đường dẫn riêng, chẳng hạn `validated-output.pptx`. Thay thế bản trình chiếu hiện có chỉ sau khi thao tác hoàn thành thành công, báo cáo cảnh báo đáp ứng chính sách ứng dụng và đầu ra có thể mở và kiểm tra. Cách này tránh ghi đè tệp nguồn hợp lệ bằng kết quả một phần hoặc bị từ chối.

Báo cáo cảnh báo rỗng không đảm bảo mọi tính năng nguồn đã được giữ lại. Áp dụng bất kỳ kiểm tra nội dung và hình ảnh bổ sung nào mà ứng dụng yêu cầu. Xem thêm [Mở Bản trình chiếu](/slides/vi/nodejs-java/open-presentation/) và [Lưu Bản trình chiếu](/slides/vi/nodejs-java/save-presentation/).

## **Câu hỏi thường gặp**

**Callback cảnh báo có thể xử lý mọi lỗi của Aspose.Slides không?**

Không. Nó chỉ xử lý các điều kiện có thể khôi phục được được báo cáo dưới dạng cảnh báo. Các ngoại lệ xảy ra độc lập với callback phải được ứng dụng xử lý xung quanh cuộc gọi tải, render, chuyển đổi hoặc lưu.

**Trả về `ReturnAction.Continue` có đảm bảo đầu ra giống hệt không?**

Không. Nó chỉ cho phép quá trình tiếp tục. Điều kiện đã báo cáo vẫn có thể gây ra sự khác biệt về dữ liệu, định dạng hoặc tính tương thích, vì vậy hãy xem xét các loại và mô tả cảnh báo đã thu thập.

**Làm thế nào ứng dụng có thể xác định thao tác đã tạo ra cảnh báo?**

Tạo một đối tượng callback cho mỗi thao tác và lưu trữ giai đoạn do ứng dụng định nghĩa cùng với các giá trị trả về bởi [getWarningType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getWarningType--) và [getDescription](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getDescription--), như trong ví dụ.