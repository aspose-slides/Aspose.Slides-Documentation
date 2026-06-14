---
title: "Đa luồng trong Aspose.Slides cho C++"
linktitle: "Đa luồng"
type: docs
weight: 200
url: /vi/cpp/multithreading/
keywords:
- đa luồng
- nhiều luồng
- công việc song song
- chuyển đổi slide
- slide sang hình ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Đa luồng trong Aspose.Slides cho C++ tăng tốc quá trình xử lý PowerPoint và OpenDocument. Khám phá các thực tiễn tốt nhất để quy trình làm việc với bản trình bày hiệu quả."
---
## **Giới thiệu**

Mặc dù có thể thực hiện công việc song song với các bản trình bày (ngoại trừ việc phân tích/tải/nhân bản) và mọi thứ thường diễn ra tốt (hầu hết thời gian), vẫn có một khả năng nhỏ bạn có thể nhận được kết quả không chính xác khi sử dụng thư viện trong nhiều luồng.

Chúng tôi mạnh mẽ khuyến nghị bạn **không** sử dụng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) duy nhất trong môi trường đa luồng vì có thể gây ra các lỗi hoặc thất bại không thể dự đoán và khó phát hiện.

Việc tải, lưu và/hoặc nhân bản một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) trong nhiều luồng là **không** an toàn. Các thao tác như vậy **không** được hỗ trợ. Nếu bạn cần thực hiện các nhiệm vụ này, hãy thực hiện song song bằng cách sử dụng nhiều tiến trình đơn luồng—và mỗi tiến trình này nên sử dụng một thể hiện bản trình bày riêng.

## **Chuyển đổi các slide của bản trình bày sang hình ảnh một cách song song**

Giả sử chúng ta muốn chuyển đổi tất cả các slide trong một bản trình bày PowerPoint sang hình ảnh PNG một cách song song. Vì không an toàn khi sử dụng một thể hiện `Presentation` duy nhất trong nhiều luồng, chúng ta sẽ chia các slide thành các bản trình bày riêng và chuyển đổi chúng sang hình ảnh một cách song song, mỗi bản trình bày chạy trong một luồng riêng. Đoạn mã mẫu sau cho thấy cách thực hiện.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Trích xuất slide i vào một bản trình bày riêng.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Chuyển đổi slide thành hình ảnh trong một tác vụ riêng.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Đợi cho tất cả các tác vụ hoàn thành.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Tôi có cần gọi thiết lập giấy phép trong mỗi luồng không?**

Không. Chỉ cần thực hiện một lần cho mỗi tiến trình/miền ứng dụng trước khi các luồng khởi động. Nếu [license setup](/slides/vi/cpp/licensing/) có thể được gọi đồng thời (ví dụ, trong quá trình khởi tạo lười), hãy đồng bộ cuộc gọi đó vì phương thức thiết lập giấy phép không an toàn với luồng.

**Tôi có thể truyền các đối tượng `Presentation` hoặc `Slide` qua lại giữa các luồng không?**

Không khuyến khích truyền các đối tượng bản trình bày “sống” giữa các luồng: hãy sử dụng các thể hiện độc lập cho mỗi luồng hoặc tạo trước các bản trình bày/bộ chứa slide riêng cho mỗi luồng. Cách tiếp cận này tuân theo khuyến nghị chung là không chia sẻ một thể hiện bản trình bày duy nhất giữa các luồng.

**Việc xuất ra các định dạng khác nhau (PDF, HTML, hình ảnh) một cách song song có an toàn không, với điều kiện mỗi luồng có một thể hiện `Presentation` riêng?**

Có. Với các thể hiện độc lập và các đường dẫn đầu ra riêng, các nhiệm vụ này thường được thực hiện song song một cách đúng đắn; tránh bất kỳ đối tượng bản trình bày hoặc luồng I/O nào được chia sẻ.

**Tôi nên xử lý các cài đặt phông chữ toàn cục (thư mục, thay thế) như thế nào khi làm việc đa luồng?**

Khởi tạo tất cả các cài đặt phông chữ toàn cục trước khi khởi động các luồng và không thay đổi chúng trong quá trình làm việc song song. Điều này loại bỏ các cuộc đua khi truy cập tài nguyên phông chữ chung.