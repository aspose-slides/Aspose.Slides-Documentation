---
title: API Công cộng và Các Thay đổi Không Tương thích Ngược trong Aspose.Slides cho .NET 14.7.0
linktitle: Aspose.Slides cho .NET 14.7.0
type: docs
weight: 90
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- phương pháp cũ
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công cộng và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển một cách suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các [added](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) hoặc [removed](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) lớp, phương thức, thuộc tính và các mục khác, cũng như các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 14.7.0.

{{% /alert %}} 
## **Thay đổi API Công cộng**
### **Các hàm khởi tạo và thành phần đã bị xóa**
#### **Đã xóa một số hàm khởi tạo kiểu con của TransitionValueBase và TransitionValueFactory**
Các hàm khởi tạo của một số kiểu con TransitionValueBase (cụ thể là CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) không có tác dụng trong API công cộng nên đã bị xóa. 

Lớp liên quan TransitionValueFactory và giao diện ITransitionValueFactory của nó cũng đã bị xóa vì cùng lý do.
#### **Đã xóa phần tử SoundAction khỏi enumeration Aspose.Slides.SlideShow.TransitionType**
Phần tử SoundAction không chính xác và không được sử dụng. Cài đặt âm thanh được định nghĩa bằng các thuộc tính SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Các lớp và giao diện được thêm**
#### **Đã thêm lớp FlyThroughTransition và giao diện IFlyThroughTransition**
Lớp Aspose.Slides.SlideShow.FlyThroughTransition (và giao diện Aspose.Slides.SlideShow.IFlyThroughTransition) liên quan đến kiểu chuyển tiếp Flythrough được hỗ trợ kể từ phiên bản này.
#### **Đã thêm lớp GlitterTransition, giao diện IGlitterTransition và enumeration TransitionPattern**
Lớp Aspose.Slides.SlideShow.GlitterTransition (và giao diện Aspose.Slides.SlideShow.IGlitterTransition) liên quan đến kiểu chuyển tiếp Glitter được hỗ trợ kể từ phiên bản này.

Enumeration Aspose.Slides.SlideShow.TransitionPattern được sử dụng trong lớp này và chỉ định một mẫu hình học được lắp ráp lại để lấp đầy một khu vực lớn hơn.
#### **Đã thêm lớp LeftRightDirectionTransition, giao diện ILeftRightDirectionTransition và enumeration TransitionLeftRightDirectionType**
Lớp Aspose.Slides.SlideShow.LeftRightDirectionTransition (và giao diện Aspose.Slides.SlideShow.ILeftRightDirectionTransition) liên quan đến các kiểu chuyển tiếp Conveyor, Ferris, Flip, Gallery và Switch. Tất cả đều được hỗ trợ kể từ phiên bản này.

Enumeration Aspose.Slides.SlideShow.TransitionLeftRightDirectionType được sử dụng trong lớp này và chỉ định một hướng, chỉ bao gồm các giá trị left và right.
#### **Đã thêm các phần tử mới vào enumeration Aspose.Slides.SlideShow.TransitionType**
Enumeration Aspose.Slides.SlideShow.TransitionType đã được mở rộng với các phần tử mới.

- Các phần tử mới liên quan đến các chuyển tiếp PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Các phần tử mới liên quan đến các chuyển tiếp PowerPoint 2013 mới: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Đã thêm lớp RevealTransition và giao diện IRevealTransition**
Lớp Aspose.Slides.SlideShow.RevealTransition (và giao diện Aspose.Slides.SlideShow.IRevealTransition) liên quan đến kiểu chuyển tiếp Reveal được hỗ trợ kể từ phiên bản này.
#### **Đã thêm lớp RippleTransition, giao diện IRippleTransition và enumeration TransitionCornerAndCenterDirectionType**
Lớp Aspose.Slides.SlideShow.RippleTransition (và giao diện Aspose.Slides.SlideShow.IRippleTransition) liên quan đến kiểu chuyển tiếp Ripple được hỗ trợ kể từ phiên bản này.

Enumeration Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType được sử dụng trong lớp này và chỉ định một hướng, chỉ bao gồm các góc và trung tâm.