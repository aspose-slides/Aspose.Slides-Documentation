---
title: Quản lý các nút hình dạng SmartArt trong bản trình chiếu bằng Java
linktitle: Nút hình dạng SmartArt
type: docs
weight: 30
url: /vi/java/manage-smartart-shape-node/
keywords:
- nút SmartArt
- nút con
- thêm nút
- vị trí nút
- truy cập nút
- xóa nút
- vị trí tùy chỉnh
- nút trợ lý
- định dạng tô đầy
- render nút
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý các nút hình dạng SmartArt trong PPT và PPTX với Aspose.Slides cho Java. Nhận mẫu mã rõ ràng và mẹo để tinh giản các bản trình chiếu của bạn."
---
## **Tổng quan**

Đồ họa SmartArt trong các bản trình chiếu PowerPoint được tổ chức thông qua các nút chứa văn bản và xác định cấu trúc của sơ đồ. Aspose.Slides cho phép bạn làm việc với các nút SmartArt này bằng cách lập trình: thêm nút mới và nút con, chèn nút con ở vị trí cụ thể, truy cập các nút hiện có và đọc văn bản, cấp độ và vị trí của chúng.

Bài viết này giải thích cách quản lý các nút hình dạng SmartArt. Nó cho thấy cách xóa nút, làm việc với nút con theo chỉ mục hoặc vị trí, chuyển đổi nút trợ lý thành nút bình thường, điều chỉnh vị trí, kích thước và góc quay của các nút SmartArt, đặt định dạng tô đầy cho nút, và tạo hình thu nhỏ cho nút con SmartArt.

## **Thêm một nút SmartArt**
Aspose.Slides for Java đã cung cấp API đơn giản nhất để quản lý các hình dạng SmartArt một cách dễ dàng. Mã mẫu dưới đây sẽ giúp thêm nút và nút con vào trong hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) và tải bản trình chiếu có Đối tượng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra nếu hình dạng là loại [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) nếu nó là SmartArt.
1. [Add a new Node](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) trong SmartArt shape [**NodeCollection**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt#getAllNodes--) và đặt văn bản trong TextFrame.
1. Bây giờ, [Add](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) một [**Child Node**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) trong nút [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) vừa được thêm và đặt văn bản trong TextFrame.
1. Lưu bản trình chiếu.

```java
// Tải bản trình chiếu mong muốn
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (shape instanceof SmartArt) 
        {
            // Ép kiểu hình dạng sang SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Thêm một nút SmartArt mới
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Thêm văn bản
            TemNode.getTextFrame().setText("Test");
    
            // Thêm nút con mới vào nút cha. Nó sẽ được thêm vào cuối bộ sưu tập
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Thêm văn bản
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Lưu bản trình chiếu
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm một nút SmartArt ở vị trí cụ thể**
Trong mã mẫu dưới đây chúng tôi giải thích cách thêm các nút con thuộc các nút tương ứng của hình dạng SmartArt tại vị trí nhất định.

1. Tạo một thể hiện của lớp Presentation.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Thêm một hình dạng [**StackedList**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtLayoutType#StackedList) kiểu [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArt) trong slide đã truy cập.
1. Truy cập nút đầu tiên trong hình dạng SmartArt vừa thêm.
1. Bây giờ, thêm [**Child Node**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) cho [**Node**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtNode) đã chọn ở vị trí 2 và đặt văn bản cho nó.
1. Lưu bản trình chiếu.

```java
// Tạo một thể hiện của bản trình chiếu
Presentation pres = new Presentation();
try {
    // Truy cập slide của bản trình chiếu
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm IShape Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Truy cập nút SmartArt tại chỉ mục 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Thêm nút con mới tại vị trí 2 trong nút cha
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Thêm Văn bản
    chNode.getTextFrame().setText("Sample Text Added");

    // Lưu bản trình chiếu
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập một nút SmartArt**
Mã mẫu sau sẽ giúp truy cập các nút bên trong hình dạng SmartArt. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc và chỉ được đặt khi hình dạng SmartArt được thêm vào.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tải bản trình chiếu có Đối tượng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra nếu hình dạng là loại [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) nếu nó là SmartArt.
1. Duyệt qua tất cả các [**Nodes**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArt#getAllNodes--) trong SmartArt Shape.
1. Truy cập và hiển thị thông tin như vị trí nút SmartArt, cấp độ và Văn bản.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (IShape shape : slide.getShapes()) 
    {
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (shape instanceof ISmartArt) 
        {
            // Ép kiểu hình dạng sang SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Duyệt qua tất cả các nút bên trong SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Truy cập nút SmartArt tại chỉ mục i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // In các tham số của nút SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập một nút con SmartArt**
Mã mẫu sau sẽ giúp truy cập các nút con thuộc các nút tương ứng của hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tải bản trình chiếu có Đối tượng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra nếu hình dạng là loại [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) nếu nó là SmartArt.
1. Duyệt qua tất cả các [**Nodes**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArt#getAllNodes--) trong SmartArt Shape.
1. Đối với mỗi [**Node**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtNode) đã chọn, duyệt qua tất cả các [**Child Nodes**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtNode#getChildNodes--) trong nút cụ thể.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của [**Child Node**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (IShape shape : slide.getShapes()) 
    {
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (shape instanceof ISmartArt) 
        {
            // Ép kiểu hình dạng sang SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Duyệt qua tất cả các nút bên trong SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Truy cập nút SmartArt tại chỉ mục i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Duyệt qua các nút con trong nút SmartArt tại chỉ mục i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Truy cập nút con trong nút SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // In các tham số của nút con SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập một nút con SmartArt ở vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách truy cập các nút con ở một vị trí nhất định thuộc các nút tương ứng của hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) .
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Thêm một hình dạng [**StackedList**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtLayoutType#StackedList) kiểu SmartArt.
1. Truy cập hình dạng SmartArt vừa thêm.
1. Truy cập nút có chỉ mục 0 cho hình dạng SmartArt đã truy cập.
1. Bây giờ, truy cập [**Child Node**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ở vị trí 1 cho nút SmartArt đã truy cập bằng phương thức **get_Item()**.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của [**Child Node**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Khởi tạo bản trình chiếu
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Thêm hình dạng SmartArt vào slide đầu tiên
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Truy cập nút SmartArt tại chỉ mục 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Truy cập nút con tại vị trí 1 trong nút cha
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // In các tham số của nút con SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa một nút SmartArt**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tải bản trình chiếu có Đối tượng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra nếu hình dạng là loại [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) nếu nó là SmartArt.
1. Kiểm tra nếu [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) có nhiều hơn 0 nút.
1. Chọn nút SmartArt cần xóa.
1. Bây giờ, xóa nút đã chọn bằng phương thức [**RemoveNode**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
1. Lưu bản trình chiếu.

```java
// Tải bản trình chiếu mong muốn
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (shape instanceof ISmartArt) 
        {
            // Ép kiểu hình dạng sang SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Truy cập nút SmartArt tại chỉ mục 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Xóa nút đã chọn
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Lưu bản trình chiếu
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa một nút SmartArt ở vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong hình dạng SmartArt tại một vị trí nhất định.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tải bản trình chiếu có Đối tượng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra nếu hình dạng là loại [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISSmartArt) nếu nó là SmartArt.
1. Chọn nút hình dạng SmartArt ở chỉ mục 0.
1. Bây giờ, kiểm tra nếu nút SmartArt đã chọn có nhiều hơn 2 nút con.
1. Bây giờ, xóa nút ở **Position 1** bằng phương thức [**RemoveNode**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
1. Lưu bản trình chiếu.

```java
// Tải bản trình chiếu mong muốn
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (shape instanceof SmartArt) 
        {
            // Ép kiểu hình dạng sang SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Truy cập nút SmartArt tại chỉ mục 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Xóa nút con tại vị trí 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Lưu bản trình chiếu
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt vị trí tùy chỉnh cho một nút con trong đối tượng SmartArt**
Bây giờ Aspose.Slides for Java hỗ trợ việc đặt thuộc tính [SmartArtShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#setX-float-) và [Y](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#setY-float-). Đoạn mã dưới đây cho thấy cách đặt vị trí, kích thước và góc quay tùy chỉnh cho SmartArtShape, cũng lưu ý rằng việc thêm nút mới sẽ làm tính lại vị trí và kích thước của tất cả các nút. Với cài đặt vị trí tùy chỉnh, người dùng có thể đặt các nút theo yêu cầu.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Di chuyển hình dạng SmartArt tới vị trí mới
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Thay đổi độ rộng của hình dạng SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Thay đổi chiều cao của hình dạng SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Thay đổi góc quay của hình dạng SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Kiểm tra một nút trợ lý**
{{% alert color="primary" %}} 

Trong bài viết này chúng tôi sẽ tiếp tục khảo sát các tính năng của các hình dạng SmartArt được thêm vào các slide trình chiếu một cách lập trình bằng Aspose.Slides for Java.

{{% /alert %}} 

Chúng tôi sẽ sử dụng hình dạng SmartArt nguồn sau cho việc khảo sát trong các phần khác nhau của bài viết.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Hình: Hình SmartArt nguồn trong slide**|

Trong mã mẫu dưới đây chúng tôi sẽ khảo sát cách xác định **Assistant Nodes** trong bộ sưu tập nút SmartArt và thay đổi chúng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tải bản trình chiếu có Đối tượng SmartArt.
1. Lấy tham chiếu của slide thứ hai bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra nếu hình dạng là loại [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) nếu nó là SmartArt.
1. Duyệt qua tất cả các nút trong hình dạng SmartArt và kiểm tra nếu chúng là [**Assistant Nodes**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtNode#isAssistant--) .
1. Thay đổi trạng thái của Assistant Node thành nút bình thường.
1. Lưu bản trình chiếu.

```java
// Tạo một thể hiện của bản trình chiếu
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (shape instanceof ISmartArt) 
        {
            // Ép kiểu hình dạng sang SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Duyệt qua tất cả các nút của hình dạng SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Kiểm tra xem nút có phải là nút trợ lý không
                if (node.isAssistant()) 
                {
                    // Đặt nút trợ lý thành false và chuyển nó thành nút bình thường
                    node.isAssistant();
                }
            }
        }
    }
    
    // Lưu bản trình chiếu
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Hình: Assistant Nodes đã được thay đổi trong SmartArt shape trong slide**|

## **Đặt định dạng tô đầy cho nút**
Aspose.Slides for Java cho phép thêm các hình dạng SmartArt tùy chỉnh và đặt định dạng tô đầy cho chúng. Bài viết này giải thích cách tạo và truy cập các hình dạng SmartArt và đặt định dạng tô đầy cho các nút của chúng bằng Aspose.Slides for Java.

Vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) .
1. Lấy tham chiếu của một slide bằng chỉ mục của nó.
1. Thêm một hình dạng [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArt) bằng cách đặt [**LayoutType**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) cho nó.
1. Đặt [**FillFormat**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#getFillFormat--) cho các nút hình dạng SmartArt.
1. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```java
// Khởi tạo bản trình chiếu
Presentation pres = new Presentation();
try {
    // Truy cập slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Thêm hình dạng SmartArt và các nút
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Đặt màu tô đầy cho nút
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Lưu bản trình chiếu
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tạo hình thu nhỏ cho một nút con SmartArt**
Các nhà phát triển có thể tạo hình thu nhỏ cho nút con của SmartArt bằng cách thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) .
1. [Add SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) .
1. Lấy tham chiếu của một nút bằng cách sử dụng chỉ mục của nó
1. Lấy hình ảnh thu nhỏ.
1. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX 
Presentation pres = new Presentation();
try {
    // Thêm SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Lấy tham chiếu của một nút bằng cách sử dụng chỉ mục của nó  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Lấy hình thu nhỏ
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Lưu hình thu nhỏ
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ hoạt ảnh không?**

Có. SmartArt được coi như một hình dạng thông thường, vì vậy bạn có thể [apply standard animations](/slides/vi/java/shape-animation/) (entrance, exit, emphasis, motion paths) và điều chỉnh thời gian. Bạn cũng có thể tạo hoạt ảnh cho các hình dạng bên trong nút SmartArt khi cần.

**Làm thế nào để xác định chính xác một SmartArt cụ thể trên slide nếu không biết ID nội bộ của nó?**

Gán và tìm kiếm bằng [alternative text](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getAlternativeText--) . Đặt AltText đặc trưng cho SmartArt giúp bạn tìm nó bằng lập trình mà không cần dựa vào các định danh nội bộ.

**Hình ảnh SmartArt có được giữ nguyên khi chuyển đổi bản trình chiếu sang PDF không?**

Có. Aspose.Slides render SmartArt với độ trung thực hình ảnh cao trong quá trình [PDF export](/slides/vi/java/convert-powerpoint-to-pdf/), bảo tồn bố cục, màu sắc và hiệu ứng.

**Tôi có thể trích xuất hình ảnh toàn bộ SmartArt (cho bản xem trước hoặc báo cáo) không?**

Có. Bạn có thể render một hình dạng SmartArt sang [raster formats](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage-int-float-float-) hoặc sang [SVG](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) để có đầu ra vector có thể mở rộng, phù hợp cho hình thu nhỏ, báo cáo hoặc sử dụng trên web.