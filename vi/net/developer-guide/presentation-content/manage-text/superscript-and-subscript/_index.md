---
title: Quản lý Chỉ số trên và Chỉ số dưới trong Bản trình chiếu bằng .NET
linktitle: Chỉ số trên và Chỉ số dưới
type: docs
weight: 80
url: /vi/net/superscript-and-subscript/
keywords:
- chỉ số trên
- chỉ số dưới
- thêm chỉ số trên
- thêm chỉ số dưới
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Nắm vững chỉ số trên và chỉ số dưới trong Aspose.Slides cho .NET và nâng tầm bản trình chiếu của bạn với định dạng văn bản chuyên nghiệp để đạt hiệu quả tối đa."
---
## **Tổng quan**

Aspose.Slides for .NET cung cấp các tính năng để tích hợp văn bản chỉ số trên và chỉ số dưới vào các bản trình chiếu PowerPoint (PPT, PPTX) và OpenDocument (ODP). Cho dù bạn cần làm nổi bật công thức hoá học, phương trình toán học, hay chú thích nội dung bằng chú thích cuối trang, các tùy chọn định dạng chuyên biệt này giúp duy trì độ rõ ràng và chính xác. Trong bài viết này, bạn sẽ học cách áp dụng phong cách chỉ số trên và chỉ số dưới một cách liền mạch và đảm bảo kết quả chuyên nghiệp cho mỗi slide.

## **Thêm văn bản chỉ số trên và chỉ số dưới**

Bạn có thể thêm văn bản chỉ số trên và chỉ số dưới vào bất kỳ đoạn văn nào trong bản trình chiếu. Để thực hiện điều này với Aspose.Slides, bạn phải sử dụng thuộc tính `Escapement` của lớp [PortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/portionformat/).

Thuộc tính này cho phép bạn đặt văn bản ở chế độ chỉ số trên hoặc chỉ số dưới, với giá trị từ -100% (chỉ số dưới) đến 100% (chỉ số trên).

Các bước thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Lấy một tham chiếu đến một slide bằng chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) có loại `Rectangle` vào slide.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) liên kết với [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) .
5. Xóa các đoạn văn hiện có.
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) mới cho văn bản chỉ số trên và thêm nó vào bộ sưu tập đoạn văn của [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) .
7. Tạo một đối tượng phần văn bản mới.
8. Đặt thuộc tính `Escapement` cho phần văn bản trong khoảng từ 0 đến 100 để áp dụng chỉ số trên (0 có nghĩa là không có chỉ số trên).
9. Đặt một đoạn văn bản cho [Portion](https://reference.aspose.com/slides/vi/net/aspose.slides/portion/) và thêm nó vào bộ sưu tập phần của đoạn văn.
10. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) khác cho văn bản chỉ số dưới và thêm nó vào bộ sưu tập đoạn văn.
11. Tạo một đối tượng phần văn bản mới.
12. Đặt thuộc tính `Escapement` cho phần văn bản trong khoảng từ 0 đến -100 để áp dụng chỉ số dưới (0 có nghĩa là không có chỉ số dưới).
13. Đặt một đoạn văn bản cho [Portion](https://reference.aspose.com/slides/vi/net/aspose.slides/portion/) và thêm nó vào bộ sưu tập phần của đoạn văn.
14. Lưu bản trình chiếu dưới dạng tệp PPTX.

Mã C# sau thực hiện các bước trên:

```c#
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Tạo một hộp văn bản.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Tạo một đoạn văn cho văn bản chỉ số trên.
    IParagraph superPar = new Paragraph();

    // Tạo một phần văn bản với văn bản thường.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Tạo một phần văn bản với văn bản chỉ số trên.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Tạo một đoạn văn cho văn bản chỉ số dưới.
    IParagraph paragraph2 = new Paragraph();

    // Tạo một phần văn bản với văn bản thường.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Tạo một phần văn bản với văn bản chỉ số dưới.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Thêm các đoạn văn vào hộp văn bản.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Chỉ số trên và chỉ số dưới](superscript_and_subscript.png)

## **Câu hỏi thường gặp**

**Liệu chỉ số trên và chỉ số dưới có được giữ nguyên khi xuất ra PDF hoặc các định dạng khác không?**

Có, Aspose.Slides for .NET giữ nguyên đúng định dạng chỉ số trên và chỉ số dưới khi xuất bản trình chiếu sang PDF, PPT/PPTX, hình ảnh và các định dạng hỗ trợ khác. Định dạng chuyên biệt này vẫn nguyên vẹn trong tất cả các tệp đầu ra.

**Chỉ số trên và chỉ số dưới có thể kết hợp với các kiểu định dạng khác như in đậm hoặc in nghiêng không?**

Có, Aspose.Slides cho phép bạn kết hợp các kiểu văn bản khác nhau trong cùng một phần văn bản. Bạn có thể bật in đậm, in nghiêng, gạch chân và đồng thời áp dụng chỉ số trên hoặc chỉ số dưới bằng cách cấu hình các thuộc tính tương ứng trong [PortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/portionformat/) .

**Định dạng chỉ số trên và chỉ số dưới có hoạt động cho văn bản trong bảng, biểu đồ hoặc SmartArt không?**

Có, Aspose.Slides for .NET hỗ trợ định dạng trong hầu hết các đối tượng, bao gồm các thành phần bảng và biểu đồ. Khi làm việc với SmartArt, bạn cần truy cập các phần tử thích hợp (chẳng hạn như [SmartArtNode](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/smartartnode/)) và các vùng chứa văn bản của chúng, sau đó cấu hình các thuộc tính [PortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/portionformat/) theo cách tương tự.