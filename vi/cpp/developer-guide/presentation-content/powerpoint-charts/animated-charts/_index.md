---
title: Tạo hoạt hình biểu đồ PowerPoint trong C++
linktitle: Biểu đồ động
type: docs
weight: 80
url: /vi/cpp/animated-charts/
keywords:
- biểu đồ
- biểu đồ động
- hoạt hình biểu đồ
- chuỗi biểu đồ
- danh mục biểu đồ
- phần tử chuỗi
- phần tử danh mục
- thêm hiệu ứng
- loại hiệu ứng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tạo biểu đồ động ấn tượng trong C++ với Aspose.Slides. Nâng cao bản trình chiếu với hình ảnh động trong các tệp PPT và PPTX—bắt đầu ngay."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hoạt hình các thành phần biểu đồ. **Series**, **Categories**, **Series Elements**, **Categories Elements** có thể được hoạt hình bằng phương thức [ISequence::AddEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/addeffect/) và hai enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) và [EffectChartMinorGroupingType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effectchartminorgroupingtype/).

## **Hoạt hình chuỗi biểu đồ**
Nếu bạn muốn hoạt hình một chuỗi biểu đồ, viết mã theo các bước sau:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Hoạt hình chuỗi.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã hoạt hình chuỗi biểu đồ.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Hoạt hình trong một phần tử chuỗi**
Nếu bạn muốn hoạt hình các phần tử chuỗi, viết mã theo các bước sau:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Hoạt hình các phần tử chuỗi.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã hoạt hình các phần tử của chuỗi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Hoạt hình danh mục biểu đồ**
Nếu bạn muốn hoạt hình một danh mục biểu đồ, viết mã theo các bước sau:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Hoạt hình danh mục.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã hoạt hình danh mục biểu đồ.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Hoạt hình trong một phần tử danh mục**
Nếu bạn muốn hoạt hình các phần tử danh mục, viết mã theo các bước sau:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Hoạt hình các phần tử danh mục.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã hoạt hình các phần tử danh mục.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**Các loại hiệu ứng khác nhau (ví dụ: vào, nhấn mạnh, ra) có được hỗ trợ cho biểu đồ như các hình dạng thông thường không?**

Có. Biểu đồ được xem như một hình dạng, vì vậy nó hỗ trợ các loại hiệu ứng hoạt hình tiêu chuẩn, bao gồm vào, nhấn mạnh và ra, với khả năng kiểm soát đầy đủ qua thời gian biểu slide và các chuỗi hoạt hình.

**Tôi có thể kết hợp hoạt hình biểu đồ với chuyển tiếp slide không?**

Có. [Transitions](/slides/vi/cpp/slide-transition/) áp dụng cho slide, trong khi các hiệu ứng hoạt hình áp dụng cho các đối tượng trên slide. Bạn có thể sử dụng cả hai cùng trong cùng một bản trình chiếu và kiểm soát chúng một cách độc lập.

**Các hoạt hình biểu đồ có được giữ nguyên khi lưu dưới dạng PPTX không?**

Có. Khi bạn [save to PPTX](/slides/vi/cpp/save-presentation/), tất cả các hiệu ứng hoạt hình và thứ tự của chúng được giữ nguyên vì chúng là một phần của mô hình hoạt hình gốc của bản trình chiếu.

**Tôi có thể đọc các hoạt hình biểu đồ hiện có từ một bản trình chiếu và chỉnh sửa chúng không?**

Có. [API](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/) cung cấp quyền truy cập vào thời gian biểu slide, các chuỗi và hiệu ứng, cho phép bạn kiểm tra các hoạt hình biểu đồ hiện có và điều chỉnh chúng mà không cần tạo lại mọi thứ từ đầu.

**Tôi có thể tạo video bao gồm các hoạt hình biểu đồ bằng Aspose.Slides không?**

Có. Bạn có thể [export a presentation to video](/slides/vi/cpp/convert-powerpoint-to-video/) trong khi giữ nguyên các hoạt hình, cấu hình thời gian và các cài đặt xuất khác để đoạn clip kết quả phản ánh đúng việc phát lại có hoạt hình.