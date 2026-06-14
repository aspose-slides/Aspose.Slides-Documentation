---
title: Quản lý các nút hình dạng SmartArt trong bản trình bày bằng .NET
linktitle: Nút hình dạng SmartArt
type: docs
weight: 30
url: /vi/net/manage-smartart-shape-node/
keywords:
- nút SmartArt
- nút con
- thêm nút
- vị trí nút
- truy cập nút
- xóa nút
- vị trí tùy chỉnh
- nút trợ lý
- định dạng tô màu
- kết xuất nút
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Quản lý các nút hình dạng SmartArt trong PPT và PPTX bằng Aspose.Slides cho .NET. Nhận các mẫu mã rõ ràng và mẹo để tối ưu hoá bản trình bày của bạn."
---
## **Tổng quan**

Đồ họa SmartArt trong các bản trình bày PowerPoint được tổ chức thông qua các nút chứa văn bản và xác định cấu trúc của sơ đồ. Aspose.Slides cho phép bạn làm việc với các nút SmartArt này bằng lập trình: thêm nút mới và nút con, chèn nút con vào vị trí cụ thể, truy cập các nút hiện có và đọc văn bản, cấp độ và vị trí của chúng.

Bài viết này giải thích cách quản lý các nút hình dạng SmartArt. Nó chỉ cách xóa nút, làm việc với các nút con theo chỉ mục hoặc vị trí, chuyển một nút trợ lý thành nút thường, điều chỉnh vị trí, kích thước và góc quay của các hình dạng nút SmartArt, đặt định dạng tô màu cho nút và tạo hình thu nhỏ cho một nút con SmartArt.

## **Thêm một nút SmartArt**
Aspose.Slides cho .NET đã cung cấp API đơn giản nhất để quản lý các hình dạng SmartArt một cách dễ dàng. Mã mẫu dưới đây sẽ giúp thêm nút và nút con vào trong hình dạng SmartArt.

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và tải bản trình bày có chứa hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra xem hình dạng có phải là loại SmartArt không và chuyển kiểu hình dạng đã chọn sang SmartArt nếu nó là SmartArt.
- Thêm một nút mới vào NodeCollection của hình dạng SmartArt và đặt văn bản trong TextFrame.
- Bây giờ, thêm một nút con vào nút SmartArt vừa thêm và đặt văn bản trong TextFrame.
- Lưu bản trình bày.

```c#
// Tải bản trình bày mong muốn
Presentation pres = new Presentation("AddNodes.pptx");

// Traverse through every shape inside first slide
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Kiểm tra xem hình dạng có phải là loại SmartArt không
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Ép kiểu hình dạng sang SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Thêm một nút SmartArt mới
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Thêm văn bản
        TemNode.TextFrame.Text = "Test";

        // Thêm nút con mới vào nút cha. Nó sẽ được thêm vào cuối bộ sưu tập
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Thêm văn bản
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Lưu bản trình bày
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Thêm một nút SmartArt tại một vị trí cụ thể**
Trong mã mẫu dưới đây, chúng tôi giải thích cách thêm các nút con thuộc về các nút tương ứng của hình dạng SmartArt tại vị trí cụ thể.

- Tạo một thể hiện của lớp `Presentation`.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
- Thêm một hình dạng SmartArt kiểu StackedList vào slide đã truy cập.
- Truy cập nút đầu tiên trong hình dạng SmartArt đã thêm.
- Bây giờ, thêm nút con cho nút đã chọn tại vị trí 2 và đặt văn bản cho nó.
- Lưu bản trình bày.

```c#
// Tạo một thể hiện của bản trình bày
Presentation pres = new Presentation();

// Truy cập slide của bản trình bày
ISlide slide = pres.Slides[0];

// Thêm Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Truy cập nút SmartArt tại chỉ mục 0
ISmartArtNode node = smart.AllNodes[0];

// Thêm nút con mới tại vị trí 2 trong nút cha
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Thêm văn bản
chNode.TextFrame.Text = "Sample Text Added";

// Lưu bản trình bày
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Truy cập một nút SmartArt**
Mã mẫu dưới đây sẽ giúp truy cập các nút bên trong hình dạng SmartArt. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc và chỉ được đặt khi hình dạng SmartArt được thêm.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình bày có chứa hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra xem hình dạng có phải là loại SmartArt không và chuyển kiểu hình dạng đã chọn sang SmartArt nếu nó là SmartArt.
- Duyệt qua tất cả các nút trong hình dạng SmartArt.
- Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của nút SmartArt.

```c#
  // Tải bản trình bày mong muốn
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Duyệt qua mọi hình dạng trong slide đầu tiên
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Kiểm tra xem hình dạng có phải là loại SmartArt không
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Ép kiểu hình dạng sang SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Duyệt qua tất cả các nút trong SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Truy cập nút SmartArt tại chỉ mục i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // In ra các tham số của nút SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

## **Truy cập một nút con SmartArt**
Mã mẫu dưới đây sẽ giúp truy cập các nút con thuộc về các nút tương ứng của hình dạng SmartArt.

- Tạo một thể hiện của lớp PresentationEx và tải bản trình bày có chứa hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra xem hình dạng có phải là loại SmartArt không và chuyển kiểu hình dạng đã chọn sang SmartArtEx nếu nó là SmartArt.
- Duyệt qua tất cả các nút trong hình dạng SmartArt.
- Đối với mỗi nút hình dạng SmartArt đã chọn, duyệt qua tất cả các nút con trong nút cụ thể đó.
- Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của nút con.

```c#
 // Tải bản trình bày mong muốn
 Presentation pres = new Presentation("AccessChildNodes.pptx");

 // Duyệt qua mọi hình dạng trong slide đầu tiên
 foreach (IShape shape in pres.Slides[0].Shapes)
 {
 
     // Kiểm tra xem hình dạng có phải là loại SmartArt không
     if (shape is Aspose.Slides.SmartArt.SmartArt)
     {
 
         // Ép kiểu hình dạng sang SmartArt
         Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
 
         // Duyệt qua tất cả các nút trong SmartArt
         for (int i = 0; i < smart.AllNodes.Count; i++)
         {
             // Truy cập nút SmartArt tại chỉ mục i
             Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
 
             // Duyệt qua các nút con trong nút SmartArt tại chỉ mục i
             for (int j = 0; j < node0.ChildNodes.Count; j++)
             {
                 // Truy cập nút con trong nút SmartArt
                 Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];
 
                 // In ra các tham số của nút con SmartArt
                 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                 Console.WriteLine(outString);
             }
         }
     }
 }
```

## **Truy cập một nút con SmartArt tại một vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách truy cập các nút con ở một vị trí cụ thể thuộc về các nút tương ứng của hình dạng SmartArt.

- Tạo một thể hiện của lớp `Presentation`.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
- Thêm một hình dạng SmartArt kiểu StackedList.
- Truy cập hình dạng SmartArt đã thêm.
- Truy cập nút có chỉ mục 0 của hình dạng SmartArt đã truy cập.
- Bây giờ, truy cập nút con tại vị trí 1 của nút SmartArt đã truy cập bằng phương thức GetNodeByPosition().
- Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của nút con.

```c#
// Tạo một thể hiện của bản trình bày
Presentation pres = new Presentation();

// Truy cập slide đầu tiên
ISlide slide = pres.Slides[0];

// Thêm hình dạng SmartArt vào slide đầu tiên
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Truy cập nút SmartArt tại chỉ mục 0
ISmartArtNode node = smart.AllNodes[0];

// Truy cập nút con tại vị trí 1 trong nút cha
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// In ra các tham số của nút con SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```

## **Xóa một nút SmartArt**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong hình dạng SmartArt.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình bày có chứa hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra xem hình dạng có phải là loại SmartArt không và chuyển kiểu hình dạng đã chọn sang SmartArt nếu nó là SmartArt.
- Kiểm tra xem SmartArt có nhiều hơn 0 nút không.
- Chọn nút SmartArt cần xóa.
- Bây giờ, xóa nút đã chọn bằng phương thức RemoveNode() và Lưu bản trình bày.

```c#
// Tải bản trình bày mong muốn
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Duyệt qua mọi hình dạng trong slide đầu tiên
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (shape is ISmartArt)
        {
            // Ép kiểu hình dạng sang SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Truy cập nút SmartArt tại chỉ mục 0
                ISmartArtNode node = smart.AllNodes[0];

                // Xóa nút đã chọn
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Lưu bản trình bày
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Xóa một nút SmartArt tại một vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong hình dạng SmartArt ở vị trí cụ thể.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình bày có chứa hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra xem hình dạng có phải là loại SmartArt không và chuyển kiểu hình dạng đã chọn sang SmartArt nếu nó là SmartArt.
- Chọn nút hình dạng SmartArt có chỉ mục 0.
- Bây giờ, kiểm tra xem nút SmartArt đã chọn có nhiều hơn 2 nút con không.
- Bây giờ, xóa nút tại Vị trí 1 bằng phương thức RemoveNodeByPosition().
- Lưu bản trình bày.

```c#
// Tải bản trình bày mong muốn             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Duyệt qua mọi hình dạng trong slide đầu tiên
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Kiểm tra xem hình dạng có phải là loại SmartArt không
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Ép kiểu hình dạng sang SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Truy cập nút SmartArt tại chỉ mục 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Xóa nút con tại vị trí 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Lưu bản trình bày
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Đặt vị trí tùy chỉnh cho một nút con trong đối tượng SmartArt**
Hiện tại Aspose.Slides cho .NET hỗ trợ thiết lập các thuộc tính X và Y của SmartArtShape. Đoạn mã bên dưới cho thấy cách đặt vị trí, kích thước và góc quay tùy chỉnh cho SmartArtShape; cũng lưu ý rằng việc thêm nút mới sẽ gây tính toán lại vị trí và kích thước của tất cả các nút.

```c#
 // Tải bản trình bày mong muốn
 Presentation pres = new Presentation("AccessChildNodes.pptx");

 {
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Di chuyển hình dạng SmartArt đến vị trí mới
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Thay đổi chiều rộng của hình dạng SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Thay đổi chiều cao của hình dạng SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Thay đổi góc quay của hình dạng SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **Kiểm tra một nút trợ lý**
Trong mã mẫu dưới đây, chúng tôi sẽ tìm hiểu cách xác định các nút trợ lý trong bộ sưu tập nút SmartArt và thay đổi chúng.

- Tạo một thể hiện của lớp PresentationEx và tải bản trình bày có chứa hình dạng SmartArt.
- Lấy tham chiếu của slide thứ hai bằng cách sử dụng chỉ mục của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra xem hình dạng có phải là loại SmartArt không và chuyển kiểu hình dạng đã chọn sang SmartArtEx nếu nó là SmartArt.
- Duyệt qua tất cả các nút trong hình dạng SmartArt và kiểm tra xem chúng có phải là nút trợ lý không.
- Thay đổi trạng thái của nút trợ lý thành nút bình thường.
- Lưu bản trình bày.

```c#
// Tạo một thể hiện của bản trình bày
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Ép kiểu hình dạng sang SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Duyệt qua tất cả các nút của hình dạng SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Kiểm tra xem nút có phải là nút trợ lý không
                if (node.IsAssistant)
                {
                    // Đặt nút trợ lý thành false và chuyển nó thành nút bình thường
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Lưu bản trình bày
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Đặt định dạng tô màu cho nút**
Aspose.Slides cho .NET cho phép thêm các hình dạng SmartArt tùy chỉnh và đặt định dạng tô màu cho chúng. Bài viết này giải thích cách tạo và truy cập các hình dạng SmartArt và đặt định dạng tô màu bằng Aspose.Slides cho .NET.

Vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp `Presentation`.
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một hình dạng SmartArt bằng cách thiết lập LayoutType.
- Đặt FillFormat cho các nút của hình dạng SmartArt.
- Ghi bản trình bày đã sửa đổi thành file PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // Truy cập slide
    ISlide slide = presentation.Slides[0];

    // Thêm hình dạng SmartArt và các nút
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Đặt màu nền cho nút
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Lưu bản trình bày
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **Tạo hình thu nhỏ của một nút con SmartArt**
Các nhà phát triển có thể tạo hình thu nhỏ của nút con SmartArt bằng cách thực hiện các bước sau:

1. Tạo một thể hiện của lớp `Presentation` đại diện cho file PPTX.
1. Thêm SmartArt.
1. Lấy tham chiếu của một nút bằng cách sử dụng chỉ mục của nó
1. Lấy hình ảnh thu nhỏ.
1. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

Ví dụ dưới đây tạo hình thu nhỏ của nút con SmartArt

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ hoạt ảnh không?**

Có. SmartArt được xem như một hình dạng thông thường, vì vậy bạn có thể [áp dụng các hoạt ảnh tiêu chuẩn](/slides/vi/net/shape-animation/) (đi vào, rời khỏi, nhấn mạnh, đường di chuyển) và điều chỉnh thời gian. Bạn cũng có thể tạo hoạt ảnh cho các hình dạng bên trong các nút SmartArt khi cần.

**Làm sao tôi có thể xác định một SmartArt cụ thể trên slide nếu ID nội bộ của nó không biết?**

Gán và tìm kiếm bằng [văn bản thay thế](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/alternativetext/). Đặt AltText đặc trưng cho SmartArt cho phép bạn tìm nó bằng lập trình mà không phụ thuộc vào các định danh nội bộ.

**Giao diện SmartArt có được bảo tồn khi chuyển đổi bản trình bày sang PDF không?**

Có. Aspose.Slides render SmartArt với độ trung thực hình ảnh cao trong quá trình [xuất PDF](/slides/vi/net/convert-powerpoint-to-pdf/), bảo tồn bố cục, màu sắc và hiệu ứng.

**Tôi có thể trích xuất hình ảnh của toàn bộ SmartArt (để xem trước hoặc báo cáo) không?**

Có. Bạn có thể render một hình dạng SmartArt thành [định dạng raster](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage/) hoặc thành [SVG](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/writeassvg/) để xuất ra vector có thể mở rộng, phù hợp cho hình thu nhỏ, báo cáo hoặc sử dụng trên web.