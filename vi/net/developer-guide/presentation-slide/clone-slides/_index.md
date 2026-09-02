---
title: Sao chép slide bản trình chiếu trong .NET
linktitle: Sao chép Slides
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
description: "Nhanh chóng nhân bản các slide PowerPoint với Aspose.Slides cho .NET. Thực hiện các ví dụ mã rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Sao chép (cloning) là quá trình tạo một bản sao chính xác hoặc bản sao của một thứ gì đó. Aspose.Slides cũng cho phép bạn sao chép (clone) bất kỳ slide nào và sau đó chèn slide đã sao chép vào bản trình chiếu hiện tại hoặc bất kỳ bản trình chiếu mở nào khác. Việc sao chép slide tạo ra một slide mới mà các nhà phát triển có thể chỉnh sửa mà không ảnh hưởng đến slide gốc. Có một số cách để sao chép một slide:

- Sao chép tại cuối một bản trình chiếu.
- Sao chép tại vị trí khác trong một bản trình chiếu.
- Sao chép tại cuối một bản trình chiếu khác.
- Sao chép tại vị trí khác trong một bản trình chiếu khác.
- Sao chép cùng với slide master của nó vào một bản trình chiếu khác.

Trong Aspose.Slides cho .NET, bộ sưu tập slide (một tập hợp các đối tượng [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/) ) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) cung cấp các phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) và [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/insertclone/) để thực hiện các thao tác sao chép slide đã mô tả ở trên.

## **Sao chép một Slide tại Cuối một Bản Trình Chiếu**

Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu ở cuối các slide hiện có, hãy sử dụng phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) theo các bước được liệt kê dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) bằng cách tham chiếu đến bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
3. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) và truyền slide cần sao chép làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) .
4. Ghi tệp bản trình chiếu đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở vị trí đầu tiên – chỉ số 0 – của bản trình chiếu) đến cuối bản trình chiếu.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Sao chép slide mong muốn tới cuối bộ sưu tập các slide trong cùng một bản trình chiếu
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Ghi bản trình chiếu đã chỉnh sửa ra đĩa
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Sao chép một Slide tới Vị Trí Khác trong Một Bản Trình Chiếu**

Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở vị trí khác, hãy sử dụng phương thức [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Khởi tạo lớp bằng cách tham chiếu đến bộ sưu tập **Slides** được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
3. Gọi phương thức [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/insertclone/methods/1) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) và truyền slide cần sao chép cùng với chỉ mục cho vị trí mới làm tham số cho phương thức [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/insertclone/methods/1) .
4. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở chỉ mục 1 – vị trí 2 – của bản trình chiếu) đến chỉ mục 2 – vị trí 3 – của bản trình chiếu.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Sao chép slide mong muốn tới cuối bộ sưu tập các slide trong cùng một bản trình chiếu
    ISlideCollection slds = pres.Slides;

    // Sao chép slide mong muốn tới chỉ mục được chỉ định trong cùng một bản trình chiếu
    slds.InsertClone(2, pres.Slides[1]);

    // Ghi bản trình chiếu đã chỉnh sửa ra đĩa
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Sao chép một Slide tại Cuối một Bản Trình Chiếu Khác**

Nếu bạn cần sao chép một slide từ một bản trình chiếu và sử dụng nó trong một tệp bản trình chiếu khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình chiếu mà slide sẽ được sao chép từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình chiếu đích mà slide sẽ được thêm vào.
3. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) bằng cách tham chiếu đến bộ sưu tập **Slides** được cung cấp bởi đối tượng Presentation của bản trình chiếu đích.
4. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) và truyền slide từ bản trình chiếu nguồn làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) .
5. Ghi tệp bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ mục đầu tiên của bản trình chiếu nguồn) đến cuối bản trình chiếu đích.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    using (Presentation destPres = new Presentation())
    {
        // Sao chép slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập các slide trong bản trình chiếu đích
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Ghi bản trình chiếu đích ra đĩa
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Sao chép một Slide tới Vị Trí Khác trong Một Bản Trình Chiếu Khác**

Nếu bạn cần sao chép một slide từ một bản trình chiếu và sử dụng nó trong một tệp bản trình chiếu khác, ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình chiếu nguồn mà slide sẽ được sao chép từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình chiếu mà slide sẽ được thêm vào.
3. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) bằng cách tham chiếu đến bộ sưu tập Slides được cung cấp bởi đối tượng Presentation của bản trình chiếu đích.
4. Gọi phương thức [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/insertclone/methods/1) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) và truyền slide từ bản trình chiếu nguồn cùng với vị trí mong muốn làm tham số cho phương thức [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/insertclone/methods/1) .
5. Ghi tệp bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ mục 0 của bản trình chiếu nguồn) đến chỉ mục 1 (vị trí 2) của bản trình chiếu đích.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Ghi bản trình chiếu đích ra đĩa
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Sao chép một Slide cùng với Slide Master của nó tới Bản Trình Chiếu Khác**

Nếu bạn cần sao chép một slide cùng với slide master từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, trước tiên bạn phải sao chép slide master mong muốn từ bản trình chiếu nguồn sang bản trình chiếu đích. Sau đó bạn cần sử dụng slide master đó để sao chép slide có master. Phương thức **AddClone(ISlide, IMasterSlide)** yêu cầu một slide master từ bản trình chiếu đích chứ không phải từ bản trình chiếu nguồn. Để sao chép slide có master, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình chiếu nguồn mà slide sẽ được sao chép từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa bản trình chiếu đích mà slide sẽ được sao chép tới.
3. Truy cập slide cần sao chép cùng với slide master.
4. Khởi tạo lớp [IMasterSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection) bằng cách tham chiếu đến bộ sưu tập Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) của bản trình chiếu đích.
5. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) được cung cấp bởi đối tượng [IMasterSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection) và truyền master từ PPTX nguồn cần sao chép làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) .
6. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) bằng cách đặt tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) của bản trình chiếu đích.
7. Gọi phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) và truyền slide từ bản trình chiếu nguồn cần sao chép và slide master làm tham số cho phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) .
8. Ghi tệp bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide có master (nằm ở chỉ mục 0 của bản trình chiếu nguồn) đến cuối bản trình chiếu đích bằng cách sử dụng master từ slide nguồn.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Khởi tạo lớp Presentation cho bản trình chiếu đích (nơi slide sẽ được sao chép)
    using (Presentation destPres = new Presentation())
    {

        // Khởi tạo ISlide từ bộ sưu tập các slide trong bản trình chiếu nguồn cùng với
        // slide Master
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Sao chép slide master mong muốn từ bản trình chiếu nguồn đến bộ sưu tập master trong
        // bản trình chiếu đích
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Sao chép slide master mong muốn từ bản trình chiếu nguồn đến bộ sưu tập master trong
        // bản trình chiếu đích
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Sao chép slide mong muốn từ bản trình chiếu nguồn với master mong muốn tới cuối
        // bộ sưu tập các slide trong bản trình chiếu đích
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Sao chép slide master mong muốn từ bản trình chiếu nguồn đến bộ sưu tập master trong // bản trình chiếu đích
        // Lưu bản trình chiếu đích ra đĩa
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Sao chép một Slide tại Cuối một Phần Được Chỉ Định**

Với Aspose.Slides cho .NET, bạn có thể sao chép một slide từ một phần của bản trình chiếu và chèn slide đó vào một phần khác trong cùng một bản trình chiếu. Trong trường hợp này, bạn phải sử dụng phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/methods/addclone/index) từ giao diện [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) .

Đoạn mã C# này cho bạn thấy cách sao chép một slide và chèn slide đã sao chép vào một phần được chỉ định:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Đảm Bảo Kích Thước Slide Khớp Nhau**

Khi sao chép slide sang một bản trình chiếu khác, hãy chắc chắn rằng bản trình chiếu đích có cùng kích thước slide với bản trình chiếu nguồn. Nếu kích thước slide khác nhau, Aspose.Slides sẽ không tự động thay đổi kích thước các hình đã sao chép — tọa độ và kích thước gốc của chúng được giữ nguyên, điều này có thể khiến nội dung hiển thị lệch hoặc vượt ra ngoài ranh giới slide.

Bạn có thể đặt kích thước slide của bản trình chiếu đích sao cho khớp với bản trình chiếu nguồn trước khi sao chép master và slide:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Thực hiện việc này trước khi sao chép master và slide.

## **Câu hỏi thường gặp**

**Lưu ý người nói và bình luận của người xem có được sao chép không?**

Có. Trang ghi chú và bình luận đánh giá được bao gồm trong bản sao. Nếu bạn không muốn chúng, [loại bỏ chúng](/slides/vi/net/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng đều được sao chép. Nếu biểu đồ được liên kết với nguồn bên ngoài (ví dụ, một sổ làm việc được nhúng OLE), liên kết đó được giữ lại dưới dạng một [OLE object](/slides/vi/net/manage-ole/). Sau khi di chuyển giữa các tệp, hãy kiểm tra tính khả dụng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và các phần cho bản sao không?**

Có. Bạn có thể chèn bản sao vào một chỉ mục slide cụ thể và đặt nó vào một [section](/slides/vi/net/slide-section/) đã chọn. Nếu phần đích không tồn tại, hãy tạo nó trước và sau đó di chuyển slide vào đó.