---
title: Quản lý SmartArt trong Bài thuyết trình PowerPoint bằng .NET
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/net/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- kiểu bố cục
- thuộc tính ẩn
- biểu đồ tổ chức
- biểu đồ tổ chức dạng hình ảnh
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Học cách xây dựng và chỉnh sửa SmartArt PowerPoint với Aspose.Slides cho .NET bằng các mẫu mã C# rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một biểu đồ PowerPoint được tạo thành từ các nút, hình dạng nút và một bố cục. Với Aspose.Slides cho .NET, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức dạng hình ảnh.

## **Lấy văn bản từ đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản hiển thị, lặp qua [ISmartArt.AllNodes](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/ismartart/allnodes/), sau đó đọc [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) được trả về bởi [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Thay đổi kiểu bố cục của đối tượng SmartArt**

Bố cục SmartArt điều khiển cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, thay đổi nó thành giá trị `BasicProcess`, và lưu bản trình bày.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Kiểm tra xem nút SmartArt có bị ẩn hay không**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/ismartartnode/ishidden/) cho biết liệu nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các phần tử biểu đồ nhìn thấy được.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` và kiểm tra trạng thái ẩn của nút.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Lấy hoặc đặt bố cục biểu đồ tổ chức**

Đối với các biểu đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) định nghĩa cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo từ phía trái, phải hoặc cả hai bên, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/organizationchartlayouttype/) đã chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Tạo biểu đồ tổ chức dạng hình ảnh**

Biểu đồ tổ chức dạng hình ảnh là một bố cục SmartArt được thiết kế cho các biểu đồ cấp bậc có chứa các chỗ giữ hình ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào một slide.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho các ngôn ngữ RTL không?**

Có. Thuộc tính [IsReversed](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/smartart/isreversed/) chuyển hướng biểu đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ đảo ngược.

**Làm thế nào tôi có thể sao chép SmartArt vào cùng một slide hoặc sang bản trình bày khác mà vẫn giữ định dạng?**

Bạn có thể [sao chép hình dạng SmartArt](/slides/vi/net/shape-manipulations/) bằng [ShapeCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/shapecollection/addclone/) hoặc [sao chép toàn bộ slide](/slides/vi/net/clone-slides/) chứa SmartArt. Cả hai cách đều giữ kích thước, vị trí và định dạng.

**Làm thế nào tôi có thể render SmartArt thành hình ảnh raster để xem trước hoặc xuất ra web?**

Bạn có thể [render slide](/slides/vi/net/convert-powerpoint-to-png/) hoặc toàn bộ bản trình bày sang PNG hoặc JPEG. SmartArt được render như một phần của slide.

**Làm sao tôi có thể tìm một đối tượng SmartArt cụ thể trên một slide nếu có nhiều?**

Đặt giá trị [AlternativeText](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/alternativetext/) hoặc [Name](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/name/) trên hình dạng SmartArt, tìm giá trị đó trong [Slide.Shapes](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslide/shapes/), sau đó kiểm tra hình dạng khớp là một [ISmartArt](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/ismartart/).