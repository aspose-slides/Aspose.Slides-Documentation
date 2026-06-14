---
title: Tạo hiệu ứng động cho văn bản PowerPoint trong .NET
linktitle: Văn bản động
type: docs
weight: 60
url: /vi/net/animated-text/
keywords:
- văn bản động
- hoạt hình văn bản
- đoạn văn động
- hoạt hình đoạn văn
- hiệu ứng hoạt hình
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tạo văn bản động đa dạng trong các bản trình bày PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho .NET, kèm theo các ví dụ mã C# dễ hiểu và được tối ưu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với văn bản động trong Aspose.Slides bằng cách áp dụng hiệu ứng hoạt hình cho các đoạn văn riêng lẻ và lấy lại các hiệu ứng đã được gán cho các đoạn văn trong một khung văn bản. Nó tập trung vào các phương pháp API được sử dụng để thêm hoạt hình cấp đoạn và kiểm tra các hiệu ứng hoạt hình đoạn hiện có trong một bản trình bày.

## **Thêm Hiệu Ứng Hoạt Hình vào Đoạn Văn**

Chúng tôi đã thêm phương thức [**AddEffect()**](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/sequence/methods/addeffect/index) vào các lớp [**Sequence**](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/sequence) và [**ISequence**](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence). Phương thức này cho phép bạn thêm hiệu ứng hoạt hình vào một đoạn văn duy nhất. Đoạn mã mẫu dưới đây cho thấy cách thêm hiệu ứng hoạt hình vào một đoạn văn:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // chọn đoạn văn để thêm hiệu ứng
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // thêm hiệu ứng hoạt hình Fly vào đoạn văn đã chọn
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Lấy Các Hiệu Ứng Hoạt Hình cho Đoạn Văn**

Bạn có thể muốn tìm hiểu các hiệu ứng hoạt hình đã được thêm vào một đoạn văn — ví dụ, trong một trường hợp, bạn muốn lấy các hiệu ứng hoạt hình trong một đoạn văn vì bạn dự định áp dụng các hiệu ứng đó cho một đoạn văn hoặc hình dạng khác.

Aspose.Slides cho .NET cho phép bạn lấy tất cả các hiệu ứng hoạt hình được áp dụng cho các đoạn văn chứa trong một khung văn bản (hình). Đoạn mã mẫu dưới đây cho thấy cách lấy các hiệu ứng hoạt hình trong một đoạn văn:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **FAQ**

**Các hoạt hình văn bản khác gì so với chuyển tiếp slide, và chúng có thể được kết hợp không?**

Các hoạt hình văn bản điều khiển hành vi của đối tượng theo thời gian trên một slide, trong khi [transitions](/slides/vi/net/slide-transition/) điều khiển cách các slide chuyển đổi. Chúng độc lập và có thể được sử dụng cùng nhau; thứ tự phát lại được quyết định bởi dòng thời gian hoạt hình và cài đặt chuyển tiếp.

**Các hoạt hình văn bản có được giữ nguyên khi xuất sang PDF hoặc hình ảnh không?**

Không. PDF và hình ảnh raster là tĩnh, vì vậy bạn sẽ thấy trạng thái duy nhất của slide mà không có chuyển động. Để giữ chuyển động, hãy xuất dưới dạng [video](/slides/vi/net/convert-powerpoint-to-video/) hoặc [HTML](/slides/vi/net/export-to-html5/).

**Các hoạt hình văn bản có hoạt động trong bố cục và slide master không?**

Các hiệu ứng được áp dụng cho các đối tượng bố cục/master sẽ được kế thừa bởi các slide, nhưng thời gian và tương tác của chúng với các hoạt hình cấp slide phụ thuộc vào chuỗi cuối cùng trên slide.