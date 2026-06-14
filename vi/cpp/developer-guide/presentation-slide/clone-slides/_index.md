---
title: Sao chép các slide bài thuyết trình trong C++
linktitle: Sao chép Slide
type: docs
weight: 40
url: /vi/cpp/clone-slides/
keywords:
- sao chép slide
- chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Nhanh chóng sao chép các slide PowerPoint bằng Aspose.Slides cho C++. Tham khảo các ví dụ mã rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Sao chép (cloning) là quá trình tạo ra một bản sao chính xác hoặc bản sao của một thứ gì đó. Aspose.Slides for C++ cũng cho phép tạo một bản sao hoặc clone của bất kỳ slide nào và sau đó chèn slide đã clone vào bản trình bày hiện tại hoặc bất kỳ bản trình bày nào khác đang mở. Quá trình clone slide tạo ra một slide mới có thể được nhà phát triển sửa đổi mà không làm thay đổi slide gốc. Có một số cách để clone một slide:

- Clone ở cuối trong cùng một Presentation.
- Clone ở vị trí khác trong Presentation.
- Clone ở cuối trong một Presentation khác.
- Clone ở vị trí khác trong một Presentation khác.
- Clone ở vị trí cụ thể trong một Presentation khác.

Trong Aspose.Slides for C++, (một tập hợp các [ISlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/) objects) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) cung cấp các phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) và [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/) để thực hiện các kiểu clone slide nêu trên.

## **Clone một Slide ở Cuối Presentation**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp presentation ở cuối các slide hiện có, hãy sử dụng phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) theo các bước dưới đây:

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) bằng cách tham chiếu đến tập hợp Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) và truyền slide cần clone làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/).
1. Ghi file presentation đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (nằm ở vị trí đầu tiên – chỉ mục 0 – của presentation) tới cuối presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Clone một Slide tới Vị trí Khác trong cùng một Presentation**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp presentation nhưng ở vị trí khác, hãy sử dụng phương thức [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/):

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Khởi tạo lớp bằng cách tham chiếu đến tập hợp **Slides** được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Gọi phương thức [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) và truyền slide cần clone cùng với chỉ mục cho vị trí mới làm tham số cho phương thức [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/).
1. Ghi presentation đã sửa đổi dưới dạng file PPTX.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (nằm ở chỉ mục 0 – vị trí 1 – của presentation) tới chỉ mục 1 – Vị trí 2 – của presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Clone một Slide ở Cuối một Presentation Khác**
Nếu bạn cần clone một slide từ một presentation và sử dụng nó trong một presentation khác, ở cuối các slide hiện có:

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa presentation mà slide sẽ được clone từ đó.
1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa presentation đích mà slide sẽ được thêm vào.
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) bằng cách tham chiếu đến tập hợp **Slides** được cung cấp bởi đối tượng Presentation của presentation đích.
1. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) và truyền slide từ presentation nguồn làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/).
1. Ghi file presentation đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (từ chỉ mục đầu tiên của presentation nguồn) tới cuối presentation đích.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clone một Slide tới Vị trí Khác trong một Presentation Khác**
Nếu bạn cần clone một slide từ một presentation và sử dụng nó trong một presentation khác, ở một vị trí cụ thể:

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa presentation nguồn mà slide sẽ được clone từ đó.
1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa presentation mà slide sẽ được thêm vào.
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) bằng cách tham chiếu đến tập hợp Slides của đối tượng Presentation của presentation đích.
1. Gọi phương thức [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) và truyền slide từ presentation nguồn cùng với vị trí mong muốn làm tham số cho phương thức [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/insertclone/).
1. Ghi file presentation đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (từ chỉ mục 0 của presentation nguồn) tới chỉ mục 1 (vị trí 2) của presentation đích.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clone một Slide ở Vị trí Cụ thể trong một Presentation Khác**
Nếu bạn cần clone một slide có master slide từ một presentation và sử dụng nó trong một presentation khác, trước tiên bạn phải clone master slide mong muốn từ presentation nguồn sang presentation đích. Sau đó bạn sẽ dùng master slide đó để clone slide có master. Phương thức **AddClone(ISlide, IMasterSlide)** yêu cầu master slide từ presentation đích chứ không phải từ nguồn. Để clone slide có master, vui lòng thực hiện các bước sau:

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa presentation nguồn mà slide sẽ được clone từ đó.
1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa presentation đích mà slide sẽ được clone tới.
1. Truy cập slide cần clone cùng với master slide.
1. Khởi tạo lớp [IMasterSlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslidecollection/) bằng cách tham chiếu đến tập hợp Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) của presentation đích.
1. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) được cung cấp bởi đối tượng [IMasterSlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslidecollection/) và truyền master từ PPTX nguồn cần clone làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/).
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) bằng cách đặt tham chiếu tới tập hợp Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) của presentation đích.
1. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) và truyền slide từ presentation nguồn cần clone và master slide làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/).
1. Ghi file presentation đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã clone một slide có master (nằm ở chỉ mục 0 của presentation nguồn) tới cuối presentation đích bằng master từ slide nguồn.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Clone một Slide ở Cuối một Section Được Xác Định**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp presentation nhưng ở một section khác, hãy sử dụng phương thức [**AddClone()**](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) được cung cấp bởi giao diện [**ISlideCollection**](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ cho phép clone một slide từ section đầu tiên và sau đó chèn slide đã clone vào section thứ hai của cùng một presentation.

Đoạn mã dưới đây cho bạn thấy cách clone một slide và chèn slide đã clone vào một section được chỉ định.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Câu hỏi thường gặp**

**Ghi chú người thuyết trình và bình luận của người xem có được clone không?**

Có. Trang ghi chú và các bình luận kiểm duyệt được bao gồm trong bản clone. Nếu bạn không muốn chúng, [remove them](/slides/vi/cpp/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng được sao chép. Nếu biểu đồ được liên kết tới nguồn bên ngoài (ví dụ: một workbook được nhúng OLE), liên kết đó được giữ nguyên dưới dạng một [OLE object](/slides/vi/cpp/manage-ole/). Sau khi di chuyển giữa các file, hãy xác minh tính khả dụng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và các section cho bản clone không?**

Có. Bạn có thể chèn bản clone tại một chỉ mục slide cụ thể và đặt nó vào một [section](/slides/vi/cpp/slide-section/) đã chọn. Nếu section mục tiêu không tồn tại, hãy tạo nó trước và sau đó di chuyển slide vào đó.