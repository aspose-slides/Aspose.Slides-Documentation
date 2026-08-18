---
title: Sao chép slide trong bản trình chiếu bằng C++
linktitle: Sao chép Slides
type: docs
weight: 40
url: /vi/cpp/clone-slides/
keywords:
- sao chép slide
- sao chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Nhanh chóng sao chép các slide PowerPoint bằng Aspose.Slides cho C++. Tham khảo các ví dụ mã rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Cloning là quá trình tạo một bản sao chính xác hoặc bản sao của một đối tượng. Aspose.Slides for C++ cũng cho phép tạo một bản sao hoặc clone của bất kỳ slide nào và sau đó chèn slide đã được clone vào bản trình chiếu hiện tại hoặc bất kỳ bản trình chiếu đã mở nào khác. Quá trình clone slide tạo ra một slide mới có thể được nhà phát triển chỉnh sửa mà không thay đổi slide gốc. Có một số cách để clone một slide:

- Clone tại cuối trong một Presentation.
- Clone tại vị trí khác trong Presentation.
- Clone tại cuối trong một Presentation khác.
- Clone tại vị trí khác trong một Presentation khác.
- Clone tại vị trí cụ thể trong một Presentation khác.

Trong Aspose.Slides for C++, (một collection của [ISlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/) objects) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) cung cấp các phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) và [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/) để thực hiện các loại clone slide ở trên.

## **Sao chép một slide ở cuối một Presentation**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp Presentation ở vị trí cuối của các slide hiện có, hãy sử dụng phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) bằng cách tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) và truyền slide cần clone làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) .
1. Ghi file Presentation đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (nằm ở vị trí đầu tiên – chỉ mục 0 – của Presentation) tới cuối Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Sao chép một slide tới vị trí khác trong một Presentation** in Presentation**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp Presentation nhưng ở vị trí khác, hãy sử dụng phương thức [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Khởi tạo lớp bằng cách tham chiếu tới bộ sưu tập **Slides** được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Gọi phương thức [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) và truyền slide cần clone cùng với chỉ mục cho vị trí mới làm tham số cho phương thức [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/) .
1. Ghi Presentation đã chỉnh sửa dưới dạng file PPTX.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (nằm ở chỉ mục 0 – vị trí 1 – của Presentation) tới chỉ mục 1 – Vị trí 2 – của Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Sao chép một slide ở cuối một Presentation khác**
Nếu bạn cần clone một slide từ một Presentation và sử dụng nó trong một Presentation khác, ở vị trí cuối của các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa Presentation mà slide sẽ được clone từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa Presentation đích mà slide sẽ được thêm vào.
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) bằng cách tham chiếu tới bộ sưu tập **Slides** được cung cấp bởi đối tượng Presentation của Presentation đích.
1. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) và truyền slide từ Presentation nguồn làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) .
1. Ghi file Presentation đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (từ chỉ mục đầu tiên của Presentation nguồn) tới cuối Presentation đích.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Sao chép một slide tới vị trí khác trong một Presentation khác**
Nếu bạn cần clone một slide từ một Presentation và sử dụng nó trong một Presentation khác, ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa Presentation nguồn mà slide sẽ được clone từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa Presentation mà slide sẽ được thêm vào.
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) bằng cách tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng Presentation của Presentation đích.
1. Gọi phương thức [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) và truyền slide từ Presentation nguồn cùng với vị trí mong muốn làm tham số cho phương thức [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/) .
1. Ghi file Presentation đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (từ chỉ mục 0 của Presentation nguồn) tới chỉ mục 1 (vị trí 2) của Presentation đích.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Sao chép một slide ở vị trí cụ thể trong một Presentation khác**
Nếu bạn cần clone một slide có master slide từ một Presentation và sử dụng nó trong một Presentation khác, trước tiên bạn phải clone master slide mong muốn từ Presentation nguồn sang Presentation đích. Sau đó bạn cần sử dụng master slide đó để clone slide có master slide. Phương thức **AddClone(ISlide, IMasterSlide)** yêu cầu master slide từ Presentation đích chứ không phải từ Presentation nguồn. Để clone slide có master, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa Presentation nguồn mà slide sẽ được clone từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa Presentation đích mà slide sẽ được clone tới.
1. Truy cập slide cần clone cùng với master slide.
1. Khởi tạo lớp [IMasterSlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslidecollection/) bằng cách tham chiếu tới bộ sưu tập Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) của Presentation đích.
1. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) được cung cấp bởi đối tượng [IMasterSlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslidecollection/) và truyền master từ PPTX nguồn cần clone làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) .
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) bằng cách thiết lập tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) của Presentation đích.
1. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) và truyền slide từ Presentation nguồn cần clone và master slide làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) .
1. Ghi file Presentation đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide có master (nằm ở chỉ mục 0 của Presentation nguồn) tới cuối Presentation đích bằng master từ slide nguồn.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Sao chép một slide ở cuối một Section được chỉ định**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một Presentation nhưng ở một Section khác, hãy sử dụng phương thức [**AddClone()**](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) được cung cấp bởi interface [**ISlideCollection**](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ cho phép clone một slide từ Section đầu tiên và sau đó chèn slide đã clone vào Section thứ hai của cùng một Presentation.

Đoạn mã dưới đây cho thấy cách clone một slide và chèn slide đã clone vào một Section được chỉ định.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Đảm bảo kích thước slide khớp nhau**

Khi clone slide vào một Presentation khác, hãy chắc chắn rằng Presentation đích có cùng kích thước slide với nguồn. Nếu kích thước slide khác nhau, Aspose.Slides sẽ không tự động thay đổi tỷ lệ các hình dạng đã clone — tọa độ và kích thước gốc của chúng sẽ được giữ nguyên, có thể gây ra nội dung bị lệch hoặc vượt ra ngoài biên giới slide.

Bạn có thể đặt kích thước slide của Presentation đích sao cho khớp với nguồn trước khi clone master và slide:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Thực hiện thao tác này trước khi clone master và slide.

## **CÂU HỎI THƯỜNG GẶP**

**Ghi chú người nói và bình luận của người xem có được sao chép không?**

Có. Trang ghi chú và các bình luận đánh giá được bao gồm trong bản sao chép. Nếu bạn không muốn chúng, [remove them](/slides/vi/cpp/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng được sao chép. Nếu biểu đồ được liên kết tới nguồn ngoài (ví dụ: một workbook OLE nhúng), liên kết đó được giữ lại dưới dạng một [OLE object](/slides/vi/cpp/manage-ole/). Sau khi di chuyển giữa các file, hãy kiểm tra tính khả dụng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và các section cho bản sao chép không?**

Có. Bạn có thể chèn bản sao chép tại một chỉ số slide cụ thể và đặt nó vào một [section](/slides/vi/cpp/slide-section/) đã chọn. Nếu section mục tiêu chưa tồn tại, tạo nó trước rồi di chuyển slide vào.