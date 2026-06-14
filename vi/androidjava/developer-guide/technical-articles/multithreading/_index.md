---
title: Đa luồng trong Aspose.Slides cho Android qua Java
linktitle: Đa luồng
type: docs
weight: 310
url: /vi/androidjava/multithreading/
keywords:
- đa luồng
- nhiều luồng
- công việc song song
- chuyển đổi slide
- slide sang hình ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Đa luồng trong Aspose.Slides cho Android qua Java tăng cường việc xử lý PowerPoint và OpenDocument. Khám phá các thực tiễn tốt nhất cho quy trình làm việc bài thuyết trình hiệu quả."
---
## **Giới thiệu**

Mặc dù việc làm việc song song với các bài thuyết trình là khả thi (ngoại trừ việc phân tích/tải/chép) và hầu hết thời gian mọi thứ hoạt động tốt, nhưng vẫn có một khả năng nhỏ mà bạn có thể nhận được kết quả không chính xác khi sử dụng thư viện trong nhiều luồng.

Chúng tôi khuyến cáo mạnh mẽ rằng bạn **không** nên sử dụng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) duy nhất trong môi trường đa luồng vì nó có thể dẫn đến các lỗi hoặc thất bại không thể dự đoán và khó phát hiện.

Việc tải, lưu và/hoặc sao chép một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) trong nhiều luồng là **không** an toàn. Các thao tác như vậy **không** được hỗ trợ. Nếu bạn cần thực hiện các nhiệm vụ này, bạn phải thực hiện song song các thao tác bằng cách sử dụng nhiều tiến trình đơn luồng—và mỗi tiến trình này nên sử dụng một thể hiện bài thuyết trình riêng.

## **Chuyển đổi các slide của bài thuyết trình sang hình ảnh một cách song song**

Giả sử chúng ta muốn chuyển đổi tất cả các slide từ một bài thuyết trình PowerPoint sang các ảnh PNG một cách song song. Vì không an toàn khi sử dụng một thể hiện `Presentation` duy nhất trong nhiều luồng, chúng ta sẽ chia các slide thành các bài thuyết trình riêng và chuyển đổi chúng sang ảnh một cách song song, sử dụng mỗi bài thuyết trình trong một luồng riêng. Ví dụ mã sau minh họa cách thực hiện.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Trích xuất slide i vào một bài thuyết trình riêng.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Chuyển đổi slide thành hình ảnh trong một nhiệm vụ riêng.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// Chờ tất cả các nhiệm vụ hoàn thành.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **Câu hỏi thường gặp**

**Tôi có cần gọi cài đặt giấy phép trong mỗi luồng không?**

Không. Chỉ cần thực hiện một lần cho mỗi tiến trình/một miền ứng dụng trước khi các luồng bắt đầu. Nếu [cài đặt giấy phép](/slides/vi/androidjava/licensing/) có thể được gọi đồng thời (ví dụ, trong quá trình khởi tạo lười), hãy đồng bộ hóa cuộc gọi đó vì phương thức cài đặt giấy phép tự nó không an toàn với đa luồng.

**Tôi có thể chuyển các đối tượng `Presentation` hoặc `Slide` giữa các luồng không?**

Việc chuyển các đối tượng bài thuyết trình "đang hoạt động" giữa các luồng không được khuyến nghị: hãy sử dụng các thể hiện độc lập cho mỗi luồng hoặc tạo sẵn các bài thuyết trình/bộ chứa slide riêng cho mỗi luồng. Cách tiếp cận này tuân theo khuyến cáo chung không chia sẻ một thể hiện bài thuyết trình duy nhất giữa các luồng.

**Có an toàn khi thực hiện xuất song song ra các định dạng khác nhau (PDF, HTML, hình ảnh) nếu mỗi luồng có một thể hiện `Presentation` riêng không?**

Có. Với các thể hiện độc lập và các đường xuất riêng biệt, các nhiệm vụ này thường được thực hiện song song một cách đúng đắn; tránh bất kỳ đối tượng bài thuyết trình chung nào và tránh chia sẻ luồng I/O.

**Tôi nên làm gì với cài đặt phông chữ toàn cục (thư mục, thay thế) trong môi trường đa luồng?**

Khởi tạo tất cả các [cài đặt phông chữ](/slides/vi/androidjava/powerpoint-fonts/) toàn cục trước khi khởi động các luồng và không thay đổi chúng trong quá trình làm việc song song. Điều này loại bỏ các cuộc đua khi truy cập tài nguyên phông chữ chung.