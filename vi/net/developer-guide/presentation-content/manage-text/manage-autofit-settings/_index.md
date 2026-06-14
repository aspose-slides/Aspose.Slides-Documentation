---
title: Nâng cao các bài thuyết trình của bạn với AutoFit trong .NET
linktitle: Cài đặt AutoFit
type: docs
weight: 30
url: /vi/net/manage-autofit-settings/
keywords:
- hộp văn bản
- tự động phù hợp
- không tự động phù hợp
- phù hợp văn bản
- thu nhỏ văn bản
- ngắt dòng văn bản
- thay đổi kích thước hình
- PowerPoint
- bài thuyết trình
- C#
- .NET
- Aspose.Slides
description: "Tìm hiểu cách quản lý các cài đặt AutoFit trong Aspose.Slides cho .NET để tối ưu hiển thị văn bản trong các bài thuyết trình PowerPoint và OpenDocument và cải thiện khả năng đọc nội dung."
---
## **Giới thiệu**

Mặc định, khi bạn thêm một hộp văn bản, Microsoft PowerPoint sử dụng cài đặt **Resize shape to fit text** cho hộp văn bản—nó tự động thay đổi kích thước hộp văn bản để đảm bảo văn bản luôn vừa trong đó.

![Hộp văn bản trong PowerPoint](textbox-in-powerpoint.png)

* Khi văn bản trong hộp văn bản dài hơn hoặc lớn hơn, PowerPoint tự động mở rộng hộp văn bản—tăng chiều cao—để cho phép chứa nhiều văn bản hơn.
* Khi văn bản trong hộp văn bản ngắn hơn hoặc nhỏ hơn, PowerPoint tự động thu nhỏ hộp văn bản—giảm chiều cao—để loại bỏ không gian dư thừa.

Trong PowerPoint, có bốn tham số hoặc tùy chọn quan trọng điều khiển hành vi tự động khớp (autofit) cho hộp văn bản:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Các tùy chọn Autofit trong PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET cung cấp các tùy chọn tương tự—các thuộc tính trong lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat)—cho phép bạn kiểm soát hành vi autofit cho các hộp văn bản trong bản trình chiếu.

## **Thay đổi kích thước hình để vừa văn bản**

Nếu bạn muốn văn bản trong một hộp luôn vừa trong hộp sau khi thay đổi nội dung, bạn phải sử dụng tùy chọn **Resize shape to fit text**. Để chỉ định cài đặt này, đặt thuộc tính `AutofitType` từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat) thành `Shape`.

![Thay đổi kích thước hình để vừa văn bản](alwaysfit-setting-powerpoint.png)

Đoạn mã C# này cho thấy cách chỉ định rằng văn bản luôn phải vừa trong hộp của nó trong một bản trình chiếu PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Nếu văn bản trở nên dài hơn hoặc lớn hơn, hộp văn bản sẽ tự động được thay đổi kích thước (tăng chiều cao) để đảm bảo toàn bộ văn bản vừa trong đó. Nếu văn bản ngắn lại, ngược lại sẽ xảy ra.

## **Không tự động khớp**

Nếu bạn muốn một hộp văn bản hoặc hình giữ nguyên kích thước bất kể các thay đổi trong văn bản chứa, bạn phải sử dụng tùy chọn **Do not Autofit**. Để chỉ định cài đặt này, đặt thuộc tính `AutofitType` từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat) thành `None`.

![Cài đặt “Do not Autofit” trong PowerPoint](donotautofit-setting-powerpoint.png)

Đoạn mã C# này cho thấy cách chỉ định rằng một hộp văn bản luôn giữ nguyên kích thước của nó trong một bản trình chiếu PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Khi văn bản trở nên quá dài đối với hộp của nó, nó sẽ tràn ra ngoài.

## **Thu nhỏ văn bản khi tràn**

Nếu văn bản trở nên quá dài đối với hộp, thông qua tùy chọn **Shrink text on overflow**, bạn có thể chỉ định rằng kích thước và khoảng cách của văn bản phải được giảm để vừa trong hộp. Để chỉ định cài đặt này, đặt thuộc tính `AutofitType` từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat) thành `Normal`.

![Cài đặt “Shrink text on overflow” trong PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Đoạn mã C# này cho thấy cách chỉ định rằng văn bản phải được thu nhỏ khi tràn trong một bản trình chiếu PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
Khi sử dụng tùy chọn **Shrink text on overflow**, cài đặt chỉ được áp dụng khi văn bản trở nên quá dài đối với hộp của nó.
{{% /alert %}}

## **Ngắt dòng văn bản**

Nếu bạn muốn văn bản trong một hình được ngắt dòng bên trong hình khi văn bản vượt quá đường viền (chỉ chiều rộng) của hình, bạn phải sử dụng tham số **Wrap text in shape**. Để chỉ định cài đặt này, bạn phải đặt thuộc tính `WrapText` từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat) thành `NullableBool.True`.

Đoạn mã C# này cho thấy cách sử dụng cài đặt Wrap Text trong một bản trình chiếu PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 
Nếu bạn đặt thuộc tính `WrapText` thành `NullableBool.False` cho một hình, khi văn bản bên trong hình dài hơn chiều rộng của hình, văn bản sẽ mở rộng ra ngoài đường viền của hình trên một dòng duy nhất.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các lề nội bộ của khung văn bản có ảnh hưởng đến AutoFit không?**

Có. Padding (lề nội bộ) giảm diện tích sử dụng cho văn bản, vì vậy AutoFit sẽ được kích hoạt sớm hơn—giảm kích thước phông chữ hoặc thay đổi kích thước hình nhanh hơn. Kiểm tra và điều chỉnh lề trước khi tinh chỉnh AutoFit.

**AutoFit tương tác như thế nào với các ngắt dòng thủ công và ngắt dòng mềm?**

Các ngắt dòng bắt buộc vẫn giữ nguyên, và AutoFit sẽ điều chỉnh kích thước phông chữ và khoảng cách xung quanh chúng. Loại bỏ các ngắt dòng không cần thiết thường giảm mức độ AutoFit phải thu nhỏ văn bản.

**Thay đổi phông chữ chủ đề hoặc kích hoạt thay thế phông chữ có ảnh hưởng đến kết quả AutoFit không?**

Có. Thay thế bằng một phông chữ có các chỉ số glyph khác nhau thay đổi độ rộng/chiều cao của văn bản, điều này có thể thay đổi kích thước phông chữ cuối cùng và cách ngắt dòng. Sau bất kỳ thay đổi hoặc thay thế phông chữ nào, hãy kiểm tra lại các slide.