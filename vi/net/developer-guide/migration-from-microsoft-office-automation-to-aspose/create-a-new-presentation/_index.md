---
title: Tạo Bản Trình Bày Mới Sử Dụng VSTO và Aspose.Slides cho .NET
linktitle: Tạo Bản Trình Bày Mới
type: docs
weight: 10
url: /vi/net/create-a-new-presentation/
keywords:
- tạo bản trình bày
- bản trình bày mới
- di chuyển
- VSTO
- tự động hoá Office
- PowerPoint
- trình bày
- .NET
- C#
- Aspose.Slides
description: "Di chuyển từ tự động hoá Microsoft Office sang Aspose.Slides cho .NET và tạo các bản trình bày PowerPoint (PPT, PPTX) mới trong C# với mã sạch, đáng tin cậy."
---
{{% alert color="primary" %}} 

VSTO được phát triển để cho phép các nhà phát triển tạo các ứng dụng có thể chạy bên trong Microsoft Office. VSTO dựa trên COM nhưng được bao bọc trong một đối tượng .NET để có thể được sử dụng trong các ứng dụng .NET. VSTO cần hỗ trợ .NET framework cũng như môi trường runtime dựa trên CLR của Microsoft Office. Mặc dù nó có thể được sử dụng để tạo các add-in cho Microsoft Office, nhưng gần như không thể dùng làm thành phần phía máy chủ. Nó cũng gặp các vấn đề nghiêm trọng về triển khai.

Aspose.Slides for .NET là một thành phần có thể được sử dụng để thao tác với các bản trình bày Microsoft PowerPoint, giống như VSTO, nhưng nó có một số ưu điểm:

- Aspose.Slides chỉ chứa mã được quản lý và không yêu cầu cài đặt runtime của Microsoft Office.
- Nó có thể được sử dụng như một thành phần phía máy khách hoặc phía máy chủ.
- Việc triển khai rất dễ dàng vì Aspose.Slides được đóng gói trong một DLL duy nhất.

{{% /alert %}} 
## **Tạo một bản trình bày**
Dưới đây là hai ví dụ mã minh họa cách VSTO và Aspose.Slides for .NET có thể được sử dụng để đạt được mục tiêu tương tự. Ví dụ đầu tiên là [VSTO](/slides/vi/net/create-a-new-presentation/); [ví dụ thứ hai](/slides/vi/net/create-a-new-presentation/) sử dụng Aspose.Slides.
### **Ví dụ VSTO**
**Kết quả VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Note: PowerPoint là một không gian tên đã được định nghĩa ở trên như thế này
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Tạo một bản trình bày
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Lấy bố cục slide tiêu đề
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Thêm một slide tiêu đề.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Đặt văn bản tiêu đề
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Đặt văn bản phụ đề
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Ghi kết quả ra đĩa
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Ví dụ Aspose.Slides for .NET**
**Kết quả từ Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//Tạo một bản trình bày
Presentation pres = new Presentation();

//Thêm slide tiêu đề
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Đặt văn bản tiêu đề
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Đặt văn bản phụ đề
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Ghi kết quả ra đĩa
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```