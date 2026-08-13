---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides for Java 14.7.0
linktitle: Aspose.Slides cho Java 14.7.0
type: docs
weight: 60
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- phương pháp kế thừa
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi phá vỡ trong Aspose.Slides cho Java để di chuyển mượt mà các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục tương tự đã [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/), bất kỳ hạn chế mới và các thay đổi khác được giới thiệu trong API Aspose.Slides for Java 14.7.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Các hàm khởi tạo của một số kiểu con TransitionValueBase đã bị loại bỏ và TransitionValueFactory đã bị loại bỏ**
Các hàm khởi tạo của một số kiểu con TransitionValueBase (và cụ thể là CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) không còn hữu ích trong API công khai nên đã bị loại bỏ. Lớp liên quan TransitionValueFactory và giao diện ITransitionValueFactory của nó cũng đã bị loại bỏ vì cùng lý do.
### **Phần tử SoundAction đã bị loại bỏ khỏi enum com.aspose.slides.TransitionType**
Phần tử SoundAction không đúng và không được sử dụng. Cài đặt âm thanh được định nghĩa bởi các thuộc tính SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Lớp FlyThroughTransition và giao diện IFlyThroughTransition đã được thêm**
Lớp com.aspose.slides.FlyThroughTransition (và giao diện com.aspose.slides.IFlyThroughTransition) liên quan đến kiểu chuyển tiếp Flythrough đã được hỗ trợ trong phiên bản này.
### **Lớp GlitterTransition, giao diện IGlitterTransition và enum TransitionPattern đã được thêm**
Lớp com.aspose.slides.GlitterTransition (và giao diện com.aspose.slides.IGlitterTransition) liên quan đến kiểu chuyển tiếp Glitter đã được hỗ trợ trong phiên bản này. Enum com.aspose.slides.TransitionPattern được sử dụng trong lớp này và chỉ định một mẫu hình học được lắp ghép lại để lấp đầy một khu vực lớn hơn.
### **Lớp LeftRightDirectionTransition, giao diện ILeftRightDirectionTransition và enum TransitionLeftRightDirectionType đã được thêm**
Lớp com.aspose.slides.LeftRightDirectionTransition (và giao diện com.aspose.slides.ILeftRightDirectionTransition) liên quan đến các kiểu chuyển tiếp Switch, Flip, Ferris, Gallery, Conveyor đã được hỗ trợ trong phiên bản này. Enum com.aspose.slides.TransitionLeftRightDirectionType được sử dụng trong lớp này và chỉ định một hướng giới hạn ở các giá trị left và right.
### **Các phần tử mới đã được thêm vào enum com.aspose.slides.TransitionType**
Enum com.aspose.slides.TransitionType đã được mở rộng với các phần tử mới.
Các phần tử mới liên quan đến các chuyển tiếp PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
Các phần tử mới liên quan đến các chuyển tiếp PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Lớp RevealTransition và giao diện IRevealTransition đã được thêm**
Lớp com.aspose.slides.RevealTransition (và giao diện com.aspose.slides.IRevealTransition) liên quan đến kiểu chuyển tiếp Reveal đã được hỗ trợ trong phiên bản này.
Lớp RippleTransition, giao diện IRippleTransition và enum TransitionCornerAndCenterDirectionType đã được thêm.
Lớp com.aspose.slides.RippleTransition (và giao diện com.aspose.slides.IRippleTransition) liên quan đến kiểu chuyển tiếp Ripple đã được hỗ trợ trong phiên bản này.
Enum com.aspose.slides.TransitionCornerAndCenterDirectionType được sử dụng trong lớp này và chỉ định một hướng giới hạn ở các góc và trung tâm.
### **Lớp ShredTransition, giao diện IShredTransition và enum TransitionShredPattern đã được thêm**
Lớp com.aspose.slides.ShredTransition (và giao diện com.aspose.slides.IShredTransition) liên quan đến kiểu chuyển tiếp Shred đã được hỗ trợ trong phiên bản này.
Enum com.aspose.slides.TransitionShredPattern được sử dụng trong lớp này và chỉ định một hình dạng hình học được lắp ghép lại để lấp đầy một khu vực lớn hơn.