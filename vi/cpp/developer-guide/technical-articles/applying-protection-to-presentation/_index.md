---
title: Hạn chế chỉnh sửa bản trình bày bằng khóa hình dạng trong C++
linktitle: Hạn chế chỉnh sửa bản trình bày
type: docs
weight: 10
url: /vi/cpp/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa hình dạng
- khóa vị trí
- khóa lựa chọn
- khóa thay đổi kích thước
- khóa nhóm
- PowerPoint
- PPTX
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản trình bày PPTX bằng Aspose.Slides cho C++ để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides for C++ là tạo, cập nhật và lưu các bản trình bày PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận được các bản trình bày này, việc hạn chế thay đổi các hình dạng có thể giúp bảo tồn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng và loại bỏ khóa hình dạng trong bản trình bày PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng.

## **Thành phần của một Slide**

Một slide trong bản trình bày được tạo thành từ các thành phần như hình tự động, bảng, đối tượng OLE, các hình dạng nhóm, khung ảnh, khung video, connector, và các yếu tố khác được sử dụng để xây dựng một bản trình bày. Trong Aspose.Slides for C++, mỗi yếu tố trên slide được đại diện bởi một đối tượng triển khai giao diện [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện này.

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) là giao diện cơ sở cho các khóa hình dạng. Aspose.Slides for C++ cung cấp các giao diện khóa sau:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) khóa các hình tự động.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) khóa các hình connector.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) khóa các hình nhóm.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) khóa các khung ảnh.

Để áp dụng khóa cho toàn bộ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), hãy lặp qua các slide của nó và đặt các khóa phù hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Xóa Bảo vệ**

Các khóa hình dạng hạn chế các thao tác như chọn, di chuyển và thay đổi kích thước các hình dạng. Chúng không làm cho toàn bộ bản trình bày không thể chỉnh sửa.

### **Áp dụng Bảo vệ cho Các Hình dạng PPTX**

Aspose.Slides for C++ cung cấp giao diện [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) để làm việc với các hình dạng trên một slide.

Ví dụ này truyền `true` vào [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) và [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) cho các hình tự động, cùng với các khóa tương đương cho hình nhóm, connector và khung ảnh. Connectors sử dụng [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) cho việc di chuyển; các nhóm cũng sử dụng [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) để hạn chế việc nhóm.

Ví dụ tải một bản trình bày PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide, và lưu một bản sao với các hạn chế này đã được áp dụng. Các hình dạng không thuộc bốn loại được xử lý sẽ được để nguyên. Vòng lặp không duyệt qua các hình dạng con bên trong một nhóm.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Xóa Bảo vệ**

Để xóa một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ dưới đây tải một bản trình bày có các khóa hình dạng và xóa các hạn chế về lựa chọn, di chuyển và thay đổi kích thước thông qua [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) và [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Nó cũng xóa [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) và lưu một bản sao của bản trình bày. Các cài đặt khóa khác được để nguyên.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Kết luận**

Aspose.Slides for C++ cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ hoặc áp dụng cùng một hạn chế trên nhiều slide. Chọn các khóa được hỗ trợ bởi mỗi loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần xóa các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình bày không?**

Có. Các khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/cpp/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình bày. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các hình dạng trên các slide được chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào tôi có thể áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Lặp qua bộ sưu tập trả về bởi phương thức [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) của nhóm và áp dụng các khóa phù hợp cho mỗi hình dạng con. Lặp lại cho bất kỳ nhóm lồng nhau nào. Các ví dụ trên chỉ xử lý bộ sưu tập hình dạng của slide, vì vậy chúng không đặt khóa cho các thành viên nhóm riêng lẻ.