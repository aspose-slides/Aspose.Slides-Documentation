---
title: Xử lý cảnh báo bản trình chiếu trong Java
type: docs
weight: 90
url: /vi/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback cảnh báo
- chính sách cảnh báo
- mất dữ liệu
- hỏng nguồn
- vấn đề tương thích
- thay thế phông chữ
- chữ ký kỹ thuật số
- tải bản trình chiếu
- render bản trình chiếu
- chuyển đổi bản trình chiếu
- lưu bản trình chiếu
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Tìm hiểu cách thu thập, phân loại và hành động đối với các cảnh báo khi tải, render, chuyển đổi và lưu bản trình chiếu bằng Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides có thể báo cáo các vấn đề có thể khôi phục được khi nó tải, render, chuyển đổi hoặc lưu một bản trình chiếu. Các ví dụ bao gồm bản ghi nguồn bị hỏng, nội dung không thể bảo toàn, thay thế phông chữ và các hạn chế của định dạng đích. Một callback cảnh báo cho phép ứng dụng ghi lại các điều kiện này và quyết định liệu hoạt động hiện tại có thể tiếp tục hay không.

Triển khai giao diện [IWarningCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarningcallback/) và kiểm tra các giá trị [getWarningType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getWarningType--) và [getDescription](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getDescription--) được cung cấp qua [IWarningInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/). Trả về [ReturnAction.Continue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/returnaction/#Continue) để chấp nhận cảnh báo hoặc [ReturnAction.Abort](https://reference.aspose.com/slides/vi/java/com.aspose.slides/returnaction/#Abort) để dừng thao tác.

Sử dụng [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) cho các cảnh báo phát sinh trong khi mở bản trình chiếu. Các lớp tùy chọn render và xuất kế thừa [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), nhận cảnh báo từ việc render slide, chuyển đổi và lưu. Vì cảnh báo tự nó không xác định thao tác của ứng dụng, hãy gắn mỗi instance callback với một giai đoạn thao tác khi bạn xây dựng báo cáo tổng hợp.

## **Cảnh báo và Ngoại lệ**

Một cảnh báo mô tả một điều kiện mà Aspose.Slides có thể khôi phục nếu callback trả về `ReturnAction.Continue`. Một ngoại lệ có nghĩa là thao tác yêu cầu không thể hoàn thành bình thường; ngoại lệ không được chuyển đổi thành cảnh báo và không thể được xử lý bằng chính sách cảnh báo.

Trả về `ReturnAction.Abort` yêu cầu bộ xử lý cảnh báo chấm dứt thao tác hiện tại bằng cách ném một ngoại lệ. Loại ngoại lệ công khai phụ thuộc vào thao tác và định dạng bản trình chiếu. Ví dụ, khi tải có thể phát sinh [PptxReadException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxreadexception/) hoặc [PptReadException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptreadexception/), trong khi lưu hoặc xuất có thể phát sinh [PptxException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxexception/). Xử lý ngoại lệ ở ranh giới của thao tác và dùng báo cáo cảnh báo để xác định liệu chính sách ứng dụng đã gây ra việc chấm dứt hay không thay vì dựa vào một subtype hoặc thông điệp ngoại lệ duy nhất. Callback ghi lại cảnh báo trước khi trả về `ReturnAction.Abort`, đảm bảo lý do vẫn có sẵn cho ứng dụng.

## **Các Loại Cảnh Báo**

Lớp [WarningType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/warningtype/) cung cấp các hằng số nguyên cho các danh mục sau:

| Loại cảnh báo | Ý nghĩa | Chính sách thường gặp |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/vi/java/com.aspose.slides/warningtype/#SourceFileCorruption) | Bản trình chiếu nguồn chứa dữ liệu hỏng có thể làm cho tài liệu lưu ở định dạng gốc trở nên không sử dụng được. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/vi/java/com.aspose.slides/warningtype/#DataLoss) | Văn bản, biểu đồ, hình ảnh hoặc dữ liệu khác có thể bị thiếu sau khi tải hoặc lưu. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/vi/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | Bản trình chiếu có thể mất định dạng quan trọng. | Abort trong chế độ xác thực nghiêm ngặt; nếu không thì ghi lại và tiếp tục. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/vi/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Một sự khác biệt định dạng hạn chế có thể xảy ra. | Ghi lại để chẩn đoán và tiếp tục. |
| [CompatibilityIssue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Kết quả có thể không mở được hoặc không hoạt động đúng trong một số ứng dụng hoặc phiên bản cũ. | Ghi log và tiếp tục trừ khi tính tương thích là bắt buộc. |
| [UnexpectedContent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/warningtype/#UnexpectedContent) | Nguồn chứa nội dung không hỗ trợ hoặc không nhận dạng được, ảnh hưởng có thể chưa được biết. | Ghi lại và tiếp tục, hoặc coi là lỗi trong chính sách nghiêm ngặt. |

Danh mục này nên quyết định chính sách. Lưu giá trị trả về bởi [getDescription](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getDescription--) để chẩn đoán, nhưng không dựa vào cách diễn đạt của nó cho logic ứng dụng vì văn bản thông điệp có thể thay đổi giữa các kịch bản cảnh báo và các phiên bản sản phẩm.

## **Thu Thập và Phân Loại Cảnh Báo**

Ví dụ dưới đây sử dụng một báo cáo cấp ứng dụng cho toàn bộ pipeline xử lý. Một instance callback riêng biệt gắn nhãn cảnh báo từ việc tải, render, chuyển đổi PDF và lưu PPTX. Chính sách sẽ abort khi gặp hỏng nguồn hoặc mất dữ liệu, tùy chọn abort khi mất định dạng lớn, và tiếp tục cho các cảnh báo khác.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

Truyền `false` cho `abortOnMajorFormattingLoss` khi khởi tạo `WarningPolicy` nếu chấp nhận được sự khác biệt định dạng lớn. Các vấn đề tương thích, mất định dạng nhỏ và nội dung không mong đợi vẫn được giữ trong báo cáo ngay cả khi thao tác tiếp tục. Mở rộng `WarningPolicy.getAction` nếu ứng dụng phải từ chối bất kỳ danh mục nào trong số này.

## **Các Kịch Bản Cảnh Báo Thông Thường**

Cảnh báo có thể xuất hiện ở các giai đoạn khác nhau của quy trình làm việc:

- **Chữ ký kỹ thuật số:** Một bản trình chiếu đã ký có thể tạo ra cảnh báo khi tải rằng chữ ký sẽ bị mất trong quá trình xử lý. Aspose.Slides báo cáo tình trạng `DataLoss` này qua [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback ở giai đoạn tải cho phép ứng dụng từ chối tệp hoặc chấp nhận rõ ràng việc mất dữ liệu đã báo cáo.
- **Thay thế phông chữ:** Một phông chữ không có sẵn có thể được thay thế khi slide được render hoặc xuất. Cảnh báo thay thế phông chữ được báo cáo là `DataLoss`, do đó chính sách nghiêm ngặt ở trên sẽ abort ngay cả khi ứng dụng cho rằng sự thay thế đó chấp nhận được về mặt thị giác. Để quan sát hành vi này, sử dụng bản trình chiếu đầu vào có văn bản bằng phông chữ không khả dụng cho runtime. Mô tả cảnh báo xác định việc thay thế; cấu hình các phông chữ cần thiết hoặc [font substitution rules](/slides/vi/java/font-substitution/) trước khi thử lại.
- **Nội dung không hỗ trợ hoặc không mong đợi:** Trình tải có thể gặp các bản ghi hoặc tính năng không nhận dạng được. Các cảnh báo này có thể dùng `UnexpectedContent`, hoặc một danh mục nghiêm trọng hơn khi dữ liệu hoặc định dạng bị ảnh hưởng.
- **Tương thích định dạng:** Lưu sang định dạng trình chiếu khác có thể bỏ qua một số tính năng hoặc tạo ra kết quả hoạt động khác trong một số ứng dụng. Ví dụ, lưu một bản trình chiếu có hơn tám hướng dẫn vẽ ngang hoặc dọc vào PPT legacy sẽ báo cáo `CompatibilityIssue`. Callback ở giai đoạn lưu có thể ghi lại mất mát và tiếp tục, hoặc từ chối nếu yêu cầu bảo toàn tất cả các hướng dẫn.
- **Hành vi tải:** Các tùy chọn tải và hành vi legacy cũng có thể tạo ra cảnh báo. Ví dụ, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) xác định việc sử dụng hành vi khóa bản trình chiếu đã lỗi thời như một `CompatibilityIssue`.

Cảnh báo phụ thuộc vào tài liệu nguồn, định dạng đích, thao tác và phiên bản Aspose.Slides. Đừng cho rằng mọi tệp đều sẽ tạo cảnh báo hoặc một kịch bản luôn chỉ thuộc một danh mục duy nhất.

## **Xử Lý An Toàn Khi Thao Tác Bị Hủy**

Khi một callback trả về `ReturnAction.Abort`, không sử dụng đối tượng đã không tải thành công và đừng cho rằng đầu ra render hoặc lưu đã hoàn thiện. Thao tác có thể dừng sau khi tạo tệp đầu ra nhưng trước khi hoàn tất.

Lưu kết quả đã được xác thực vào một đường dẫn riêng như `validated-output.pptx`. Thay thế bản trình chiếu hiện có chỉ sau khi thao tác kết thúc thành công, báo cáo cảnh báo đáp ứng chính sách ứng dụng, và đầu ra có thể mở và kiểm tra. Điều này tránh việc ghi đè tệp nguồn hợp lệ bằng kết quả một phần hoặc bị từ chối.

Báo cáo cảnh báo rỗng không đảm bảo mọi tính năng nguồn đã được bảo toàn. Thực hiện các kiểm tra nội dung và hình ảnh bổ sung mà ứng dụng yêu cầu. Xem thêm [Open Presentations](/slides/vi/java/open-presentation/) và [Save Presentations](/slides/vi/java/save-presentation/).

## **Câu Hỏi Thường Gặp**

**Callback cảnh báo có thể xử lý mọi lỗi của Aspose.Slides không?**

Không. Nó chỉ xử lý các điều kiện có thể khôi phục được và được báo cáo dưới dạng cảnh báo. Các ngoại lệ xảy ra độc lập với callback phải được ứng dụng xử lý xung quanh lời gọi tải, render, chuyển đổi hoặc lưu.

**Trả về `ReturnAction.Continue` có đảm bảo đầu ra giống hệt không?**

Không. Nó chỉ cho phép quá trình tiếp tục. Điều kiện đã báo cáo vẫn có thể gây ra sự khác biệt về dữ liệu, định dạng hoặc tính tương thích, vì vậy hãy xem xét các loại và mô tả cảnh báo đã thu thập.

**Ứng dụng có thể xác định thao tác nào đã tạo ra cảnh báo như thế nào?**

Tạo một instance callback cho mỗi thao tác và lưu giai đoạn do ứng dụng định nghĩa cùng với các giá trị trả về bởi [getWarningType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getWarningType--) và [getDescription](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getDescription--), như trong ví dụ.