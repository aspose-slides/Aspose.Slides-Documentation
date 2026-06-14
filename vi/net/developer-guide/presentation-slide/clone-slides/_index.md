---
title: Sao chép slide trong .NET
linktitle: Sao chép slide
type: docs
weight: 40
url: /vi/net/clone-slides/
keywords:
- sao chép slide
- sao chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Nhanh chóng sao chép các slide PowerPoint với Aspose.Slides cho .NET. Thực hiện các ví dụ mã rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Sao chép (Cloning) là quá trình tạo một bản sao chính xác hoặc bản sao của một thứ gì đó. Aspose.Slides cũng cho phép bạn sao chép (clone) bất kỳ slide nào và sau đó chèn slide đã sao chép vào bản trình diễn hiện tại hoặc bất kỳ bản trình diễn mở nào khác. Việc sao chép slide tạo ra một slide mới mà các nhà phát triển có thể chỉnh sửa mà không ảnh hưởng đến slide gốc. Có nhiều cách để sao chép một slide:

- Sao chép ở cuối một bản trình diễn.
- Sao chép ở vị trí khác trong cùng một bản trình diễn.
- Sao chép ở cuối một bản trình diễn khác.
- Sao chép ở vị trí khác trong một bản trình diễn khác.
- Sao chép ở vị trí cụ thể trong một bản trình diễn khác.

Trong Aspose.Slides for .NET, bộ sưu tập slide (một tập hợp các đối tượng [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/) ) được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) cung cấp các phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) và [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/insertclone/) để thực hiện các thao tác sao chép slide được mô tả ở trên.

## **Sao chép một Slide ở Cuối một Bản Trình Diễn**

Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng tệp bản trình diễn ở cuối các slide hiện có, hãy sử dụng phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) theo các bước được liệt kê dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) bằng cách tham chiếu đến bộ sưu tập Slides được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
3. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) được công bố bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) và truyền slide cần sao chép làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) .
4. Ghi tệp bản trình diễn đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở vị trí đầu tiên – chỉ mục 0 – của bản trình diễn) tới cuối bản trình diễn.

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình diễn
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Sao chép slide mong muốn tới cuối bộ sưu tập slide trong cùng bản trình diễn
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Ghi bản trình diễn đã sửa đổi ra đĩa
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Sao chép một Slide tới Vị trí Khác trong cùng một Bản Trình Diễn**

Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng tệp bản trình diễn nhưng ở vị trí khác, hãy sử dụng phương thức [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Khởi tạo lớp bằng cách tham chiếu đến bộ sưu tập **Slides** được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
3. Gọi phương thức [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/insertclone/methods/1) được công bố bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) và truyền slide cần sao chép cùng với chỉ mục cho vị trí mới làm tham số cho phương thức [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/insertclone/methods/1) .
4. Ghi bản trình diễn đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở chỉ mục 0 – vị trí 1 – của bản trình diễn) tới chỉ mục 1 – Vị trí 2 – của bản trình diễn.

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình diễn
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Sao chép slide mong muốn tới cuối bộ sưu tập slide trong cùng bản trình diễn
    ISlideCollection slds = pres.Slides;

    // Sao chép slide mong muốn tới chỉ mục đã chỉ định trong cùng bản trình diễn
    slds.InsertClone(2, pres.Slides[1]);

    // Ghi bản trình diễn đã sửa đổi ra đĩa
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Sao chép một Slide ở Cuối một Bản Trình Diễn Khác**

Nếu bạn cần sao chép một slide từ một bản trình diễn và sử dụng nó trong một tệp bản trình diễn khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình diễn mà slide sẽ được sao chép từ.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình diễn đích mà slide sẽ được thêm vào.
3. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) bằng cách tham chiếu đến bộ sưu tập **Slides** được công bố bởi đối tượng Presentation của bản trình diễn đích.
4. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) được công bố bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) và truyền slide từ bản trình diễn nguồn làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) .
5. Ghi tệp bản trình diễn đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ mục đầu tiên của bản trình diễn nguồn) tới cuối bản trình diễn đích.

```c#
// Khởi tạo lớp Presentation để tải tệp bản trình diễn nguồn
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    using (Presentation destPres = new Presentation())
    {
        // Sao chép slide mong muốn từ bản trình diễn nguồn tới cuối bộ sưu tập slide trong bản trình diễn đích
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Ghi bản trình diễn đích ra đĩa
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Sao chép một Slide tới Vị trí Khác trong một Bản Trình Diễn Khác**

Nếu bạn cần sao chép một slide từ một bản trình diễn và sử dụng nó trong một tệp bản trình diễn khác, ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình diễn nguồn mà slide sẽ được sao chép từ.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình diễn mà slide sẽ được thêm vào.
3. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) bằng cách tham chiếu đến bộ sưu tập Slides được công bố bởi đối tượng Presentation của bản trình diễn đích.
4. Gọi phương thức [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/insertclone/methods/1) được công bố bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) và truyền slide từ bản trình diễn nguồn cùng với vị trí mong muốn làm tham số cho phương thức [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/insertclone/methods/1) .
5. Ghi tệp bản trình diễn đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ mục 0 của bản trình diễn nguồn) tới chỉ mục 1 (vị trí 2) của bản trình diễn đích.

```c#
// Khởi tạo lớp Presentation để tải tệp bản trình diễn nguồn
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Ghi bản trình diễn đích ra đĩa
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Sao chép một Slide ở Vị trí Cụ thể trong một Bản Trình Diễn Khác**

Nếu bạn cần sao chép một slide cùng với master slide từ một bản trình diễn và sử dụng nó trong một bản trình diễn khác, bạn cần sao chép master slide mong muốn từ bản trình diễn nguồn sang bản trình diễn đích trước. Sau đó bạn cần sử dụng master slide đó để sao chép slide có master. Phương thức **AddClone(ISlide, IMasterSlide)** yêu cầu một master slide từ bản trình diễn đích thay vì từ bản trình diễn nguồn. Để sao chép slide có master, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình diễn nguồn mà slide sẽ được sao chép từ.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình diễn đích mà slide sẽ được sao chép tới.
3. Truy cập slide cần sao chép cùng với master slide.
4. Khởi tạo lớp [IMasterSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection) bằng cách tham chiếu đến bộ sưu tập Masters được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) của bản trình diễn đích.
5. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) được công bố bởi đối tượng [IMasterSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection) và truyền master từ PPTX nguồn cần sao chép làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) .
6. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) bằng cách đặt tham chiếu tới bộ sưu tập Slides được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) của bản trình diễn đích.
7. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) được công bố bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) và truyền slide từ bản trình diễn nguồn cần sao chép cùng với master slide làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) .
8. Ghi tệp bản trình diễn đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide có master (nằm ở chỉ mục 0 của bản trình diễn nguồn) tới cuối bản trình diễn đích bằng cách sử dụng master từ slide nguồn.

```c#
// Khởi tạo lớp Presentation để tải tệp bản trình diễn nguồn

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Khởi tạo lớp Presentation cho bản trình diễn đích (nơi slide sẽ được sao chép)
    using (Presentation destPres = new Presentation())
    {

        // Khởi tạo ISlide từ bộ sưu tập slide trong bản trình diễn nguồn cùng với
        // Slide master
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Sao chép master slide mong muốn từ bản trình diễn nguồn tới bộ sưu tập master trong
        // Bản trình diễn đích
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Sao chép master slide mong muốn từ bản trình diễn nguồn tới bộ sưu tập master trong
        // Bản trình diễn đích
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Sao chép slide mong muốn từ bản trình diễn nguồn với master mong muốn tới cuối
        // Bộ sưu tập slide trong bản trình diễn đích
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Sao chép master slide mong muốn từ bản trình diễn nguồn tới bộ sưu tập master trong // Bản trình diễn đích
        // Lưu bản trình diễn đích ra đĩa
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Sao chép một Slide ở Cuối một Phần Được Xác Định**

Với Aspose.Slides for .NET, bạn có thể sao chép một slide từ một phần của bản trình diễn và chèn slide đó vào một phần khác trong cùng một bản trình diễn. Trong trường hợp này, bạn phải sử dụng phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) từ giao diện [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) .

Mã C# dưới đây cho bạn thấy cách sao chép một slide và chèn slide đã sao chép vào một phần được chỉ định:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // để sao chép
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Ghi chú người nói và bình luận người xem có được sao chép không?**

Có. Trang ghi chú và các bình luận đánh giá đều được bao gồm trong bản sao. Nếu bạn không muốn chúng, hãy [xóa chúng](/slides/vi/net/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng đều được sao chép. Nếu biểu đồ được liên kết với nguồn bên ngoài (ví dụ, một sổ làm việc OLE nhúng), liên kết đó được giữ lại dưới dạng một [đối tượng OLE](/slides/vi/net/manage-ole/). Sau khi di chuyển giữa các tệp, hãy kiểm tra tính sẵn sàng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và các phần cho bản sao không?**

Có. Bạn có thể chèn bản sao vào một chỉ mục slide cụ thể và đặt nó vào một [phần](/slides/vi/net/slide-section/) đã chọn. Nếu phần đích không tồn tại, hãy tạo nó trước rồi chuyển slide vào đó.