---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 14.7.0
linktitle: Aspose.Slides cho Java 14.7.0
type: docs
weight: 60
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi không tương thích trong Aspose.Slides cho Java để di chuyển mượt mà các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác đã được thêm, bất kỳ hạn chế mới nào và các thay đổi khác được giới thiệu trong API Aspose.Slides for Java 14.7.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Các hàm khởi tạo của một số kiểu con TransitionValueBase đã bị loại bỏ và TransitionValueFactory đã bị loại bỏ**
Các hàm khởi tạo của một số kiểu con TransitionValueBase (cụ thể là CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) không có tác dụng trong API công khai và do đó đã bị loại bỏ. Lớp liên quan TransitionValueFactory và giao diện ITransitionValueFactory của nó đã bị loại bỏ vì cùng lý do.
### **Phần tử SoundAction đã bị loại bỏ khỏi kiểu liệt kê com.aspose.slides.TransitionType**
Phần tử SoundAction không chính xác và không được sử dụng. Cài đặt âm thanh được xác định bởi các thuộc tính SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Lớp FlyThroughTransition và giao diện IFlyThroughTransition đã được thêm**
Lớp com.aspose.slides.FlyThroughTransition (và giao diện com.aspose.slides.IFlyThroughTransition) liên quan tới kiểu chuyển tiếp Flythrough đã được hỗ trợ trong phiên bản này.
### **Lớp GlitterTransition, giao diện IGlitterTransition và kiểu liệt kê TransitionPattern đã được thêm**
Lớp com.aspose.slides.GlitterTransition (và giao diện com.aspose.slides.IGlitterTransition) liên quan tới kiểu chuyển tiếp Glitter đã được hỗ trợ trong phiên bản này. Kiểu liệt kê com.aspose.slides.TransitionPattern được sử dụng trong lớp này và xác định một mẫu hình học xếp chồng nhau để lấp đầy một khu vực lớn hơn.
### **Lớp LeftRightDirectionTransition, giao diện ILeftRightDirectionTransition và kiểu liệt kê TransitionLeftRightDirectionType đã được thêm**
Lớp com.aspose.slides.LeftRightDirectionTransition (và giao diện com.aspose.slides.ILeftRightDirectionTransition) liên quan tới các kiểu chuyển tiếp Switch, Flip, Ferris, Gallery, Conveyor đã được hỗ trợ trong phiên bản này. Kiểu liệt kê com.aspose.slides.TransitionLeftRightDirectionType được sử dụng trong lớp này và xác định một hướng giới hạn ở các giá trị left và right.
### **Các phần tử mới đã được thêm vào kiểu liệt kê com.aspose.slides.TransitionType**
Kiểu liệt kê com.aspose.slides.TransitionType đã được mở rộng với các phần tử mới. Các phần tử mới liên quan đến các chuyển tiếp PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Các phần tử mới liên quan đến các chuyển tiếp PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Lớp RevealTransition và giao diện IRevealTransition đã được thêm**
Lớp com.aspose.slides.RevealTransition (và giao diện com.aspose.slides.IRevealTransition) liên quan tới kiểu chuyển tiếp Reveal đã được hỗ trợ trong phiên bản này. Lớp RippleTransition, giao diện IRippleTransition và kiểu liệt kê TransitionCornerAndCenterDirectionType đã được thêm. Lớp com.aspose.slides.RippleTransition (và giao diện com.aspose.slides.IRippleTransition) liên quan tới kiểu chuyển tiếp Ripple đã được hỗ trợ trong phiên bản này. Kiểu liệt kê com.aspose.slides.TransitionCornerAndCenterDirectionType được sử dụng trong lớp này và xác định một hướng giới hạn ở các góc và trung tâm.
### **Lớp ShredTransition, giao diện IShredTransition và kiểu liệt kê TransitionShredPattern đã được thêm**
Lớp com.aspose.slides.ShredTransition (và giao diện com.aspose.slides.IShredTransition) liên quan tới kiểu chuyển tiếp Shred đã được hỗ trợ trong phiên bản này. Kiểu liệt kê com.aspose.slides.TransitionShredPattern được sử dụng trong lớp này và xác định một hình dạng hình học xếp chồng nhau để lấp đầy một khu vực lớn hơn.