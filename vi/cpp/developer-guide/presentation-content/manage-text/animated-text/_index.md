---
title: Tạo hoạt ảnh văn bản PowerPoint trong C++
linktitle: Văn bản hoạt ảnh
type: docs
weight: 60
url: /vi/cpp/animated-text/
keywords:
- văn bản hoạt ảnh
- hoạt ảnh văn bản
- đoạn văn hoạt ảnh
- hoạt ảnh đoạn văn
- hiệu ứng hoạt ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tạo văn bản hoạt ảnh động trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho C++, với các ví dụ mã C++ tối ưu, dễ theo dõi."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với văn bản hoạt hình trong Aspose.Slides bằng cách áp dụng hiệu ứng hoạt hình cho từng đoạn và truy xuất các hiệu ứng đã được gán cho các đoạn trong một khung văn bản. Nó tập trung vào các phương thức API được sử dụng để thêm hoạt hình ở mức đoạn và kiểm tra các hiệu ứng hoạt hình đoạn hiện có trong một bản trình chiếu.

## **Thêm hiệu ứng hoạt hình vào đoạn văn**

Chúng tôi đã thêm phương thức [**AddEffect()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) vào các lớp [**Sequence**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.sequence) và [**ISequence**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.i_sequence). Phương thức này cho phép bạn thêm hiệu ứng hoạt hình vào một đoạn duy nhất. Mã mẫu này cho bạn thấy cách thêm hiệu ứng hoạt hình vào một đoạn duy nhất:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// chọn đoạn văn để thêm hiệu ứng
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// thêm hiệu ứng hoạt ảnh Fly vào đoạn văn đã chọn
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## **Lấy hiệu ứng hoạt hình cho đoạn văn**

Bạn có thể muốn tìm hiểu các hiệu ứng hoạt hình đã được thêm vào một đoạn; ví dụ, trong một trường hợp, bạn muốn lấy các hiệu ứng hoạt hình trong một đoạn vì dự định áp dụng những hiệu ứng đó vào một đoạn hoặc hình dạng khác.

Aspose.Slides cho C++ cho phép bạn lấy tất cả các hiệu ứng hoạt hình được áp dụng cho các đoạn nằm trong một khung văn bản (hình). Mã mẫu này cho bạn thấy cách lấy các hiệu ứng hoạt hình trong một đoạn:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **FAQ**

**Hoạt hình văn bản khác với chuyển đổi slide như thế nào, và chúng có thể được kết hợp không?**

Hoạt hình văn bản kiểm soát hành vi của đối tượng theo thời gian trên một slide, trong khi [transitions](/slides/vi/cpp/slide-transition/) kiểm soát cách slide chuyển đổi. Chúng độc lập và có thể được sử dụng cùng nhau; thứ tự phát được điều khiển bởi thời gian hoạt hình và cài đặt chuyển đổi.

**Hoạt hình văn bản có được giữ lại khi xuất sang PDF hoặc hình ảnh không?**

Không. PDF và hình ảnh raster là tĩnh, vì vậy bạn sẽ chỉ thấy một trạng thái duy nhất của slide mà không có chuyển động. Để giữ chuyển động, hãy xuất dưới dạng [video](/slides/vi/cpp/convert-powerpoint-to-video/) hoặc [HTML](/slides/vi/cpp/export-to-html5/) .

**Hoạt hình văn bản có hoạt động trong bố cục và mẫu slide không?**

Các hiệu ứng được áp dụng cho các đối tượng bố cục/mẫu sẽ được kế thừa bởi các slide, nhưng thời gian và tương tác của chúng với các hoạt hình ở mức slide phụ thuộc vào trình tự cuối cùng trên slide.