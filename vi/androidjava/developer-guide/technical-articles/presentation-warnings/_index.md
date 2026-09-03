---
title: Xử lý cảnh báo bản trình bày trên Android
type: docs
weight: 90
url: /vi/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback cảnh báo
- chính sách cảnh báo
- mất dữ liệu
- hỏng nguồn
- vấn đề tương thích
- thay thế phông chữ
- chữ ký số
- tải bản trình bày
- render bản trình bày
- chuyển đổi bản trình bày
- lưu bản trình bày
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách thu thập, phân loại và xử lý các cảnh báo khi tải, render, chuyển đổi và lưu bản trình bày với Aspose.Slides cho Android bằng Java."
---
## **Tổng quan**

Aspose.Slides có thể báo cáo các vấn đề có thể phục hồi được khi nó tải, render, chuyển đổi hoặc lưu một bản trình bày. Các ví dụ bao gồm bản ghi nguồn bị hỏng, nội dung không thể bảo tồn, thay thế phông chữ và các hạn chế của định dạng đích. Một callback cảnh báo cho phép ứng dụng ghi lại những tình huống này và quyết định liệu thao tác hiện tại có thể tiếp tục hay không.

Thực hiện giao diện [IWarningCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iwarningcallback/) và kiểm tra các giá trị [getWarningType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) và [getDescription](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) được cung cấp thông qua [IWarningInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iwarninginfo/). Trả về [ReturnAction.Continue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/returnaction/#Continue) để chấp nhận cảnh báo hoặc [ReturnAction.Abort](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/returnaction/#Abort) để dừng thao tác.

Sử dụng [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) cho các cảnh báo phát sinh khi mở bản trình bày. Các lớp tùy chọn render và xuất kế thừa [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), nhận cảnh báo từ việc render slide, chuyển đổi và lưu. Vì cảnh báo tự nó không xác định thao tác của ứng dụng, hãy gắn mỗi thể hiện callback với một giai đoạn thao tác khi bạn xây dựng báo cáo tổng hợp.

## **Cảnh báo và Ngoại lệ**

Cảnh báo mô tả một tình huống mà Aspose.Slides có thể phục hồi nếu callback trả về `ReturnAction.Continue`. Ngoại lệ có nghĩa là thao tác yêu cầu không thể hoàn thành bình thường; ngoại lệ không được chuyển thành cảnh báo và không thể được xử lý bằng chính sách cảnh báo.

Trả về `ReturnAction.Abort` yêu cầu bộ phân phối cảnh báo kết thúc thao tác hiện tại bằng cách ném một ngoại lệ. Loại ngoại lệ công khai phụ thuộc vào thao tác và định dạng bản trình bày. Ví dụ, quá trình tải có thể gây ra [PptxReadException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxreadexception/) hoặc [PptReadException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptreadexception/), trong khi lưu hoặc xuất có thể gây ra [PptxException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxexception/). Xử lý ngoại lệ ở ranh giới của thao tác và sử dụng báo cáo cảnh báo để xác định liệu chính sách của ứng dụng có gây ra việc dừng hay không, thay vì chỉ dựa vào một loại ngoại lệ hay thông điệp cụ thể. Callback ghi lại cảnh báo trước khi trả về `ReturnAction.Abort`, đảm bảo lý do vẫn có sẵn cho ứng dụng.

## **Danh mục Cảnh báo**

Lớp [WarningType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/warningtype/) cung cấp các hằng số số nguyên cho các danh mục sau:

| Loại cảnh báo | Ý nghĩa | Chính sách thường gặp |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | Bản trình bày nguồn chứa các lỗi có thể làm cho tài liệu lưu ở định dạng gốc không sử dụng được. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/warningtype/#DataLoss) | Văn bản, biểu đồ, hình ảnh hoặc dữ liệu khác có thể bị thiếu sau khi tải hoặc lưu. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | Bản trình bày có thể mất định dạng quan trọng. | Abort trong chế độ kiểm tra nghiêm ngặt; nếu không, ghi lại và tiếp tục. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Một sự khác biệt định dạng hạn chế có thể xảy ra. | Ghi lại để chuẩn đoán và tiếp tục. |
| [CompatibilityIssue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Kết quả có thể không mở hoặc hoạt động đúng trong một số ứng dụng hoặc phiên bản cũ. | Ghi log và tiếp tục trừ khi tính tương thích là bắt buộc. |
| [UnexpectedContent](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | Nguồn chứa nội dung không hỗ trợ hoặc không nhận diện được, hiệu ứng của nó chưa được biết. | Ghi lại và tiếp tục, hoặc coi là lỗi trong chính sách nghiêm ngặt. |

Danh mục nên quyết định chính sách. Lưu giá trị trả về bởi [getDescription](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) để chuẩn đoán, nhưng không dựa vào nội dung chuỗi này cho logic ứng dụng vì văn bản thông báo có thể thay đổi giữa các kịch bản cảnh báo và các phiên bản sản phẩm.

## **Thu thập và Phân loại Cảnh báo**

Ví dụ sau sử dụng một báo cáo ở mức ứng dụng cho toàn bộ quy trình xử lý. Một thể hiện callback riêng biệt gắn nhãn cho các cảnh báo phát sinh từ tải, render, chuyển đổi PDF và lưu PPTX. Chính sách sẽ abort khi gặp lỗi nguồn hoặc mất dữ liệu, tùy chọn abort khi mất định dạng quan trọng, và tiếp tục với các cảnh báo còn lại.

Đặt `input.pptx` trong một thư mục ứng dụng có quyền ghi và truyền thư mục đó cho `PresentationWarningExample.run`. Ví dụ sẽ lưu các đầu ra trong cùng thư mục. Thực thi xử lý bản trình bày trên một luồng nền để giữ giao diện Android phản hồi.

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

Truyền `false` cho `abortOnMajorFormattingLoss` khi khởi tạo `WarningPolicy` nếu chấp nhận các khác biệt định dạng quan trọng. Các vấn đề tương thích, mất định dạng nhẹ và nội dung không mong đợi vẫn được lưu trong báo cáo ngay cả khi thao tác tiếp tục. Mở rộng `WarningPolicy.getAction` nếu ứng dụng phải từ chối bất kỳ danh mục nào trong số đó.

## **Các Kịch bản Cảnh báo Thông thường**

Cảnh báo có thể xuất hiện ở các giai đoạn khác nhau của quy trình làm việc:

- **Chữ ký số:** Một bản trình bày đã ký có thể tạo ra cảnh báo khi tải rằng chữ ký sẽ bị mất trong quá trình xử lý. Aspose.Slides báo cáo tình huống `DataLoss` này qua [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Callback ở giai đoạn tải cho phép ứng dụng từ chối tệp hoặc chấp nhận mất mát được báo cáo.
- **Thay thế phông chữ:** Một phông chữ không có sẵn có thể được thay thế khi slide được render hoặc xuất. Cảnh báo thay thế phông chữ được báo cáo là `DataLoss`, vì vậy chính sách nghiêm ngặt ở trên sẽ abort ngay cả khi ứng dụng coi việc thay thế là chấp nhận được về mặt hình ảnh. Để quan sát hành vi này, hãy dùng một bản trình bày chứa văn bản bằng phông chữ không có trong runtime. Mô tả cảnh báo sẽ chỉ ra sự thay thế; cấu hình phông chữ cần thiết hoặc [font substitution rules](/slides/vi/androidjava/font-substitution/) trước khi thử lại.
- **Nội dung không hỗ trợ hoặc không mong đợi:** Trình tải có thể gặp các bản ghi hoặc tính năng không nhận diện được. Những cảnh báo này có thể dùng `UnexpectedContent`, hoặc một danh mục nghiêm trọng hơn khi dữ liệu hoặc định dạng bị ảnh hưởng.
- **Tương thích định dạng:** Lưu sang định dạng bản trình bày khác có thể bỏ qua một số tính năng hoặc tạo ra kết quả hoạt động khác nhau trong một số ứng dụng. Ví dụ, lưu một bản trình bày có hơn tám hướng dẫn vẽ ngang hoặc dọc vào PPT cổ sẽ báo cáo `CompatibilityIssue`. Callback ở giai đoạn lưu có thể ghi lại mất mát và tiếp tục, hoặc từ chối nếu cần bảo toàn mọi hướng dẫn.
- **Hành vi tải:** Các tùy chọn tải và hành vi legacy cũng có thể tạo ra cảnh báo. Ví dụ, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) xác định việc sử dụng hành vi khóa bản trình bày đã lỗi thời là một `CompatibilityIssue`.

Cảnh báo phụ thuộc vào tài liệu nguồn, định dạng đích, thao tác và phiên bản Aspose.Slides. Đừng giả định mỗi tệp đều tạo ra cảnh báo hoặc mỗi kịch bản luôn thuộc một danh mục duy nhất.

## **Xử lý An toàn Khi Thao tác Bị Dừng**

Khi một callback trả về `ReturnAction.Abort`, không sử dụng đối tượng đã không tải thành công và không giả định rằng đầu ra render hoặc lưu đã hoàn chỉnh. Thao tác có thể kết thúc sau khi tạo tệp đầu ra nhưng trước khi hoàn tất nó.

Lưu kết quả đã kiểm chứng vào một đường dẫn riêng, ví dụ `validated-output.pptx`. Thay thế bản trình bày hiện có chỉ sau khi thao tác hoàn thành thành công, báo cáo cảnh báo đáp ứng chính sách ứng dụng và đầu ra có thể mở và kiểm tra. Điều này tránh việc ghi đè lên tệp nguồn hợp lệ bằng kết quả chưa hoàn thiện hoặc bị từ chối.

Báo cáo cảnh báo rỗng không bảo đảm rằng mọi tính năng nguồn đã được bảo toàn. Áp dụng các kiểm tra nội dung và hình ảnh bổ sung theo yêu cầu của ứng dụng. Xem thêm [Open Presentations](/slides/vi/androidjava/open-presentation/) và [Save Presentations](/slides/vi/androidjava/save-presentation/).

## **Câu hỏi thường gặp**

**Callback cảnh báo có thể xử lý mọi lỗi của Aspose.Slides không?**

Không. Nó chỉ xử lý các tình huống có thể phục hồi được và được báo cáo dưới dạng cảnh báo. Các ngoại lệ xảy ra độc lập với callback phải được ứng dụng xử lý quanh các cuộc gọi tải, render, chuyển đổi hoặc lưu.

**Trả về `ReturnAction.Continue` có đảm bảo đầu ra giống hệt không?**

Không. Nó chỉ cho phép quá trình tiếp tục. Tình huống đã báo cáo vẫn có thể gây ra sự khác biệt về dữ liệu, định dạng hoặc tính tương thích, vì vậy hãy xem xét các loại và mô tả cảnh báo đã thu thập.

**Ứng dụng có thể xác định thao tác nào đã tạo ra cảnh báo như thế nào?**

Tạo một thể hiện callback cho mỗi thao tác và lưu một giai đoạn do ứng dụng định nghĩa cùng với các giá trị trả về bởi [getWarningType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) và [getDescription](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), như trong ví dụ.