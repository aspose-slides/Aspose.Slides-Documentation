---
title: Đa luồng trong Aspose.Slides cho PHP qua Java
linktitle: Đa luồng
type: docs
weight: 310
url: /vi/php-java/multithreading/
keywords:
- đa luồng
- nhiều luồng
- công việc song song
- chuyển đổi slide
- slide sang hình ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Đa luồng Aspose.Slides cho PHP qua Java tăng tốc xử lý PowerPoint và OpenDocument. Khám phá các phương pháp tốt nhất cho quy trình làm việc bản trình bày hiệu quả."
---
## **Introduction**

Mặc dù có thể thực hiện công việc song song với các bản trình bày (ngoại trừ việc phân tích/tải/nhân bản) và hầu hết thời gian mọi thứ diễn ra tốt, nhưng vẫn có một khả năng nhỏ bạn có thể nhận được kết quả không chính xác khi sử dụng thư viện trong nhiều luồng.

Chúng tôi mạnh mẽ khuyến nghị bạn **không** sử dụng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) duy nhất trong môi trường đa luồng vì nó có thể gây ra các lỗi hoặc sự cố không thể dự đoán và khó phát hiện.

Việc tải, lưu và/hoặc nhân bản một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) trong nhiều luồng **không** an toàn. Các thao tác như vậy **không** được hỗ trợ. Nếu bạn cần thực hiện các nhiệm vụ này, bạn phải song song hoá các thao tác bằng cách sử dụng một số tiến trình đơn luồng—và mỗi tiến trình này nên sử dụng một thể hiện bản trình bày riêng.

Chúng tôi không đảm bảo khả năng đa luồng trong PHP khi sử dụng các tiện mở rộng. Nếu bạn sử dụng chúng, hãy tự chịu trách nhiệm.

## **FAQ**

**Tôi có cần gọi thiết lập giấy phép trong mỗi luồng không?**

Không. Chỉ cần thực hiện một lần cho mỗi tiến trình/một miền ứng dụng trước khi các luồng bắt đầu. Nếu [license setup](/slides/vi/php-java/licensing/) có thể được gọi đồng thời (ví dụ, trong quá trình khởi tạo lười), hãy đồng bộ hóa lời gọi đó vì phương thức thiết lập giấy phép tự nó không an toàn với đa luồng.

**Tôi có thể truyền các đối tượng `Presentation` hoặc `Slide` giữa các luồng không?**

Việc truyền các đối tượng bản trình bày "live" giữa các luồng không được khuyến cáo: hãy sử dụng các thể hiện độc lập cho mỗi luồng hoặc tạo trước các bản trình bày/containers slide riêng cho mỗi luồng. Cách tiếp cận này tuân theo khuyến nghị chung là không chia sẻ một thể hiện bản trình bày duy nhất giữa các luồng.

**Có an toàn khi song song hoá việc xuất sang các định dạng khác nhau (PDF, HTML, hình ảnh) với điều kiện mỗi luồng có một thể hiện `Presentation` riêng không?**

Có. Với các thể hiện độc lập và các đường dẫn đầu ra riêng biệt, các tác vụ này thường được song song hoá một cách đúng đắn; tránh bất kỳ đối tượng bản trình bày chung và các luồng I/O chung.

**Tôi nên làm gì với cài đặt phông chữ toàn cục (thư mục, thay thế) trong môi trường đa luồng?**

Khởi tạo tất cả các [font settings](/slides/vi/php-java/powerpoint-fonts/) toàn cục trước khi khởi động các luồng và không thay đổi chúng trong quá trình làm việc song song. Điều này loại bỏ các cuộc tranh chấp khi truy cập tài nguyên phông chữ chung.