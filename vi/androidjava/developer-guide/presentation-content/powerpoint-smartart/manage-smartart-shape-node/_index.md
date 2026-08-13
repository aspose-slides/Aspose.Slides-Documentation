---
title: Quản lý các nút hình dạng SmartArt trong bản trình chiếu trên Android
linktitle: Nút Hình Dạng SmartArt
type: docs
weight: 30
url: /vi/androidjava/manage-smartart-shape-node/
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
- kết xuất nút
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý các nút hình dạng SmartArt trong PPT và PPTX bằng Aspose.Slides cho Android. Nhận các mẫu mã Java rõ ràng và mẹo để tối ưu hóa bản trình chiếu của bạn."
---
## **Tổng quan**

Đồ họa SmartArt trong các bản trình chiếu PowerPoint được tổ chức thông qua các nút chứa văn bản và định nghĩa cấu trúc của sơ đồ. Aspose.Slides cho phép bạn làm việc với các nút SmartArt này một cách lập trình: thêm nút mới và nút con, chèn nút con vào vị trí cụ thể, truy cập các nút hiện có và đọc văn bản, cấp độ và vị trí của chúng.

Bài viết này giải thích cách quản lý các nút hình dạng SmartArt. Nó chỉ ra cách xóa nút, làm việc với nút con theo chỉ mục hoặc vị trí, chuyển nút trợ lý thành nút thường, điều chỉnh vị trí, kích thước và góc quay của các hình dạng nút SmartArt, đặt định dạng tô đầy cho nút và tạo hình ảnh thu nhỏ cho một nút SmartArt.

## **Thêm một nút SmartArt**
Aspose.Slides for Android via Java đã cung cấp API đơn giản nhất để quản lý các hình dạng SmartArt một cách dễ dàng. Đoạn mã mẫu sau sẽ giúp thêm nút và nút con vào trong hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Bài trình bày](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) nếu đó là SmartArt.
1. [Thêm một nút mới](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) vào **NodeCollection** của hình dạng SmartArt và đặt văn bản trong TextFrame.
1. Bây giờ, [Thêm](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) một **Child Node** vào nút SmartArt vừa thêm và đặt văn bản trong TextFrame.
1. Lưu bản trình chiếu.

```java
import com.aspose.slides.*;

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
Trong đoạn mã mẫu sau chúng tôi đã giải thích cách thêm các nút con thuộc về các nút tương ứng của hình dạng SmartArt tại vị trí nhất định.

1. Tạo một thể hiện của lớp [Bài trình bày](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Thêm một hình dạng [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArt) loại [StackedList](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) vào slide đã truy cập.
1. Truy cập nút đầu tiên trong hình dạng SmartArt vừa thêm.
1. Bây giờ, thêm **Child Node** cho **Node** đã chọn tại vị trí 2 và đặt văn bản cho nó.
1. Lưu bản trình chiếu.

```java
import com.aspose.slides.*;

// Tạo một thể hiện bản trình chiếu
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
Đoạn mã mẫu sau sẽ giúp truy cập các nút bên trong hình dạng SmartArt. Lưu ý rằng LayoutType của SmartArt được chọn khi hình dạng được thêm; việc thay đổi nó sau này bằng **setLayout** sẽ tái tạo lại toàn bộ sơ đồ, vì vậy các vị trí và kích thước nút bạn đã đặt sẽ được tính lại.

1. Tạo một thể hiện của lớp [Bài trình bày](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) nếu đó là SmartArt.
1. Duyệt qua tất cả **Nodes** trong hình dạng SmartArt.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của nút SmartArt.

```java
import com.aspose.slides.*;

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
    
            // Duyệt qua tất cả các nút trong SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Truy cập nút SmartArt tại chỉ mục i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // In ra các tham số của nút SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập một nút con SmartArt**
Đoạn mã mẫu sau sẽ giúp truy cập các nút con thuộc về các nút tương ứng của hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Bài trình bày](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) nếu đó là SmartArt.
1. Duyệt qua tất cả **Nodes** trong hình dạng SmartArt.
1. Đối với mỗi **Node** của hình dạng SmartArt được chọn, duyệt qua tất cả **Child Nodes** trong nút cụ thể.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của **Child Node**.

```java
import com.aspose.slides.*;

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
    
            // Duyệt qua tất cả các nút trong SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Truy cập nút SmartArt tại chỉ mục i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Duyệt qua các nút con trong nút SmartArt tại chỉ mục i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Truy cập nút con trong nút SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // In ra các tham số của nút con SmartArt
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
Trong ví dụ này, chúng ta sẽ học cách truy cập các nút con tại một số vị trí nhất định thuộc về các nút tương ứng của hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Bài trình bày](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Thêm một hình dạng SmartArt loại [StackedList](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).
1. Truy cập hình dạng SmartArt vừa thêm.
1. Truy cập nút có chỉ mục 0 cho hình dạng SmartArt đã truy cập.
1. Bây giờ, truy cập **Child Node** tại vị trí 1 cho nút SmartArt đã truy cập bằng phương thức **get_Item()**.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của **Child Node**.

```java
import com.aspose.slides.*;

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
    
    // In ra các tham số của nút con SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa một nút SmartArt**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Bài trình bày](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) nếu đó là SmartArt.
1. Kiểm tra xem SmartArt có nhiều hơn 0 nút không.
1. Chọn nút SmartArt cần xóa.
1. Bây giờ, xóa nút đã chọn bằng phương thức [RemoveNode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
1. Lưu bản trình chiếu.

```java
import com.aspose.slides.*;

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

## **Xóa một nút SmartArt từ vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong hình dạng SmartArt tại một vị trí nhất định.

1. Tạo một thể hiện của lớp [Bài trình bày](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) nếu đó là SmartArt.
1. Chọn nút hình dạng SmartArt có chỉ mục 0.
1. Bây giờ, kiểm tra xem nút SmartArt đã chọn có nhiều hơn 2 nút con không.
1. Bây giờ, xóa nút tại **Position 1** bằng phương thức [RemoveNode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
1. Lưu bản trình chiếu.

```java
import com.aspose.slides.*;

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
Bây giờ Aspose.Slides for Android via Java hỗ trợ việc đặt thuộc tính [SmartArtShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArtShape) **X** và **Y**. Đoạn mã dưới đây cho thấy cách đặt vị trí, kích thước và góc quay tùy chỉnh cho SmartArtShape; cũng lưu ý rằng việc thêm nút mới sẽ làm tính toán lại vị trí và kích thước của tất cả các nút. Với cài đặt vị trí tùy chỉnh, người dùng có thể đặt các nút theo yêu cầu.

```java
import com.aspose.slides.*;

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
{{% alert color="info" %}} 

Trong bài viết này chúng ta sẽ tiếp tục nghiên cứu các tính năng của các hình dạng SmartArt được thêm vào các slide trình chiếu bằng cách lập trình sử dụng Aspose.Slides for Android via Java.

{{% /alert %}} 

Chúng ta sẽ sử dụng hình dạng SmartArt nguồn sau để thực hiện các thí nghiệm trong các phần khác nhau của bài viết.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Hình: Hình dạng SmartArt nguồn trong slide**|

Trong đoạn mã mẫu sau chúng tôi sẽ nghiên cứu cách xác định **Assistant Nodes** trong bộ sưu tập nút SmartArt và thay đổi chúng.

1. Tạo một thể hiện của lớp [Bài trình bày](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) nếu đó là SmartArt.
1. Duyệt qua tất cả các nút trong hình dạng SmartArt và kiểm tra xem chúng có phải là **Assistant Nodes** không.
1. Thay đổi trạng thái của Assistant Node thành nút thường.
1. Lưu bản trình chiếu.

```java
import com.aspose.slides.*;

// Tạo một thể hiện bản trình chiếu
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
                    // Đặt nút trợ lý thành false và biến nó thành nút thường
                    node.setAssistant(false);
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
|**Hình: Assistant Nodes đã được thay đổi trong hình dạng SmartArt trong slide**|

## **Đặt định dạng tô đầy cho một nút**
Aspose.Slides for Android via Java cho phép thêm các hình dạng SmartArt tùy chỉnh và đặt định dạng tô đầy cho chúng. Bài viết này giải thích cách tạo và truy cập các hình dạng SmartArt và đặt định dạng tô đầy cho các nút của chúng bằng Aspose.Slides for Android via Java.

Vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Bài trình bày](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng chỉ mục của nó.
1. Thêm một hình dạng [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArt) bằng cách đặt **LayoutType** của nó.
1. Đặt **FillFormat** cho các nút hình dạng SmartArt.
1. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Tạo hình thu nhỏ của một nút SmartArt**
Các nhà phát triển có thể tạo hình thu nhỏ của một nút SmartArt bằng cách thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Bài trình bày](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. [Thêm SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Lấy tham chiếu của một nút bằng cách sử dụng chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ.
1. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```java
import com.aspose.slides.*;

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

## **FAQ**

### SmartArt animation có được hỗ trợ không?

Có. SmartArt được coi là một hình dạng thông thường, vì vậy bạn có thể [áp dụng các hoạt hình tiêu chuẩn](/slides/vi/androidjava/shape-animation/) (nhập, thoát, nhấn mạnh, đường chuyển động) và điều chỉnh thời gian. Bạn cũng có thể tạo hoạt hình cho các hình dạng bên trong các nút SmartArt khi cần.

### Làm sao tôi có thể xác định một SmartArt cụ thể trên slide nếu không biết ID nội bộ của nó?

Gán và tìm kiếm bằng [văn bản thay thế](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getAlternativeText--). Đặt AltText đặc biệt cho SmartArt cho phép bạn tìm nó bằng lập trình mà không phụ thuộc vào các định danh nội bộ.

### Khi chuyển đổi bản trình chiếu sang PDF, hình dạng SmartArt có được giữ nguyên không?

Có. Aspose.Slides render SmartArt với độ trung thực cao khi [xuất PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/), bảo tồn bố cục, màu sắc và hiệu ứng.

### Tôi có thể trích xuất hình ảnh của toàn bộ SmartArt (để xem trước hoặc báo cáo) không?

Có. Bạn có thể render một hình dạng SmartArt sang [định dạng raster](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) hoặc sang [SVG](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) để xuất ra vector có thể mở rộng, phù hợp cho hình thu nhỏ, báo cáo hoặc sử dụng trên web.