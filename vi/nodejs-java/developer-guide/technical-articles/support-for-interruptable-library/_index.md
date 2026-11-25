---
title: Gián đoạn các hoạt động trình chiếu kéo dài trong Node.js
linktitle: Gián đoạn các hoạt động trình chiếu
type: docs
weight: 120
url: /vi/nodejs-java/support-for-interruptable-library/
keywords:
- các hoạt động có thể gián đoạn
- token gián đoạn
- token hủy
- thời gian chờ chuyển đổi
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Hủy các hoạt động trình chiếu kéo dài trong Aspose.Slides cho Node.js thông qua Java, đặt thời gian chờ chuyển đổi và theo dõi các slide đã được xuất trước khi hủy."
---
## **Tổng quan**

Aspose.Slides cho Node.js thông qua Java hỗ trợ hủy khi tải, lưu hoặc render một bản trình chiếu. Bạn cũng có thể kiểm tra token giống nhau trong vòng lặp xuất của mình để dừng lại trước slide tiếp theo và trả về số lượng các slide đã được lưu.

## **Ngắt một hoạt động trình chiếu**

Tạo một [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), lấy token của nó bằng [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken), và truyền nó cho [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Sử dụng các tùy chọn này khi khởi tạo [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Gọi [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) trên nguồn sẽ yêu cầu hủy thao tác hiện tại. Aspose.Slides sẽ dừng lại khi lần tiếp theo nó kiểm tra token.

### **Đặt thời gian chờ chuyển đổi**

Ví dụ sau cho phép 20 giây để mở `sample.pptx` và lưu nó dưới dạng `sample.pdf`. Cả hàm khởi tạo và việc lưu đều chạy bất đồng bộ qua cầu Java nên bộ hẹn giờ Node.js có thể kích hoạt trong bất kỳ thao tác nào. Ví dụ kiểm tra token sau khi tải và lại sau khi lưu, vì một lời gọi thư viện có thể trả về sau khi yêu cầu hủy. Nó giải phóng bản trình chiếu khi thao tác hoàn thành và xóa bộ hẹn giờ nếu việc chuyển đổi kết thúc sớm. Nếu việc hủy xảy ra trong quá trình lưu, tệp đầu ra có thể đã tồn tại và có thể không đầy đủ.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

Để chuyển đổi sang định dạng PowerPoint cũ hơn với giới hạn 10 giây, truyền `"sample.ppt"`, `slides.SaveFormat.Ppt`, và `10000` làm ba đối số cuối cùng.

## **Dừng trước khi xử lý Slide tiếp theo**

Sử dụng [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) trước mỗi lần xuất khi người gọi có thể sử dụng kết quả một phần. Phiên bản tải chồng [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) cho các slide được chọn nhận một mảng Java `int[]` chứa số slide bắt đầu từ 1. Ghi lại mỗi số chỉ sau khi PDF của nó đã được lưu thành công.

Chạy ví dụ với một bản trình chiếu có tên `sample.pptx` chứa ít nhất hai slide. Để minh họa việc hủy giữa các lần xuất, ví dụ yêu cầu hủy ngay sau khi lưu slide đầu tiên.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

Ví dụ ghi `slide-1.pdf` và in `Starting slide 1` tiếp theo là `Completed: [1]`. Vòng lặp quan sát việc hủy trước khi bắt đầu slide 2. Nếu một lần lưu tự nó bị gián đoạn, danh sách trả về chỉ chứa các lần xuất thành công trước đó.

Để cho phép người gọi xử lý việc hủy như một lỗi, thay thế kiểm tra và `break` ở đầu vòng lặp bằng [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), gọi dưới dạng `token.throwIfInterruptionRequested()`. Sử dụng cùng kiểm tra ném lỗi sau khi lưu và loại bỏ `try`/`catch` quanh nó. Với cùng đầu vào, PDF đầu tiên vẫn được ghi, và vòng lặp thứ hai ném lỗi trước khi hàm có thể trả về danh sách.

## **Câu hỏi thường gặp**

**Khi nào tôi nên yêu cầu hủy?**

Yêu cầu hủy khi thời hạn hết hạn hoặc ứng dụng không còn cần kết quả nữa. Việc tải, lưu và render đều có thể sử dụng token được truyền cho bản trình chiếu khi khởi tạo.

**Nguồn và token khác nhau như thế nào?**

Nguồn cho phép ứng dụng yêu cầu hủy. Token cho phép Aspose.Slides và mã của bạn kiểm tra yêu cầu đó.

**Bộ hẹn giờ Node.js có thể ngắt một việc lưu đồng bộ không?**

Một việc lưu đồng bộ sẽ chặn JavaScript trên luồng gọi. Sử dụng các cuộc gọi cầu Java bất đồng bộ được trình bày trong ví dụ thời gian chờ để bộ hẹn giờ có thể yêu cầu hủy khi việc lưu đang diễn ra.

**Hủy có có hiệu lực ngay lập tức không?**

Hủy là hợp tác. Một thao tác đang chạy sẽ dừng lại khi nó nhận thấy yêu cầu. Một thao tác đã hoàn thành sẽ giữ kết quả của nó.

**Nhiều thao tác có thể chia sẻ một nguồn không?**

Có. Gọi `interrupt()` yêu cầu hủy cho mọi thao tác sử dụng token từ nguồn đó. Sử dụng một nguồn riêng cho mỗi thao tác mà bạn muốn hủy độc lập.