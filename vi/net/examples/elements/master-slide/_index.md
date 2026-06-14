---
title: Slide Master
type: docs
weight: 30
url: /vi/net/examples/elements/master-slide/
keywords:
- slide master
- thêm slide master
- truy cập slide master
- xóa slide master
- slide master không sử dụng
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá các ví dụ về slide master của Aspose.Slides cho .NET: tạo, chỉnh sửa và tạo kiểu cho master, placeholder và theme trong PPT, PPTX và ODP bằng mã C# rõ ràng."
---
Master slides tạo thành cấp cao nhất của hệ thống kế thừa slide trong PowerPoint. Một **master slide** định nghĩa các yếu tố thiết kế chung như nền, logo và định dạng văn bản. **Layout slides** kế thừa từ master slides, và **normal slides** kế thừa từ layout slides.

Bài viết này trình bày cách tạo, chỉnh sửa và quản lý master slides bằng Aspose.Slides for .NET.

## **Thêm một Master Slide**

Ví dụ này cho thấy cách tạo một master slide mới bằng cách sao chép master slide mặc định. Sau đó nó thêm một banner tên công ty vào tất cả các slide thông qua kế thừa layout.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Sao chép slide master mặc định.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Thêm banner với tên công ty lên phần trên của slide master.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Gán slide master mới cho một layout slide.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Gán layout slide cho slide đầu tiên trong bản thuyết trình.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Note 1:** Master slides cung cấp cách áp dụng thương hiệu nhất quán hoặc các yếu tố thiết kế chung trên tất cả các slide. Bất kỳ thay đổi nào được thực hiện trên master sẽ tự động phản ánh trên các layout và normal slide phụ thuộc.

> 💡 **Note 2:** Bất kỳ hình dạng hoặc định dạng nào được thêm vào master slide sẽ được kế thừa bởi layout slides và, tiếp theo, tất cả các normal slide sử dụng các layout đó.  
> Hình ảnh bên dưới minh họa cách một hộp văn bản được thêm vào master slide sẽ tự động được hiển thị trên slide cuối cùng.

![Ví dụ Kế thừa Master](master-slide-banner.png)

## **Truy cập một Master Slide**

Bạn có thể truy cập master slides thông qua bộ sưu tập `Presentation.Masters`. Dưới đây là cách lấy và làm việc với chúng:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Truy cập slide master đầu tiên.
    var firstMasterSlide = presentation.Masters[0];

    // Thay đổi loại nền.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Xóa một Master Slide**

Master slides có thể được xóa bằng chỉ số hoặc bằng tham chiếu.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Xóa một slide master theo chỉ số.
    presentation.Masters.RemoveAt(0);

    // Xóa một slide master theo tham chiếu.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Xóa các Master Slide không sử dụng**

Một số bản trình bày chứa các master slide không được sử dụng. Việc xóa những slide này có thể giúp giảm kích thước tệp.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Xóa tất cả các slide master không sử dụng (ngay cả những slide được đánh dấu Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```