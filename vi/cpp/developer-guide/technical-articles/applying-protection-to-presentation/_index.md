---
title: Hạn chế việc chỉnh sửa bản trình bày bằng khóa hình dạng trong C++
linktitle: Hạn chế việc chỉnh sửa bản trình bày
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

Một cách sử dụng phổ biến của Aspose.Slides for C++ là tạo, cập nhật và lưu các bản trình bày PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận được các bản trình bày này, việc hạn chế thay đổi các hình dạng có thể giúp bảo tồn bố cục và nội dung mong muốn.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng và gỡ bỏ khóa hình dạng trong một bản trình bày PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng.

## **Thành phần của một Slide**

Một slide trong bản trình bày được tạo thành từ các thành phần như autoshape, bảng, đối tượng OLE, nhóm hình dạng, khung ảnh, khung video, connector và các yếu tố khác được sử dụng để xây dựng bản trình bày. Trong Aspose.Slides for C++, mỗi yếu tố trên slide được biểu diễn bằng một đối tượng triển khai giao diện [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) hoặc kế thừa từ lớp thực hiện giao diện đó.

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) là giao diện cơ sở cho các khóa hình dạng. Aspose.Slides for C++ cung cấp các giao diện khóa sau:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) khóa các autoshape.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) khóa các connector shape.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) khóa các nhóm hình dạng.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) khóa các khung ảnh.

Để áp dụng các khóa trên toàn bộ một [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), hãy lặp qua các slide của nó và đặt các khóa tương ứng cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Gỡ bỏ Bảo vệ**

Các trình chỉnh sửa bản trình bày tương thích sử dụng khóa hình dạng để hạn chế các thao tác chỉnh sửa riêng lẻ. Mã hoá tệp và bảo vệ ghi ở mức tài liệu là các [cài đặt bảo vệ bản trình bày](/slides/vi/cpp/password-protected-presentation/) riêng biệt.

### **Áp dụng Bảo vệ cho Các Hình dạng PPTX**

Aspose.Slides for C++ cung cấp giao diện [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) để làm việc với các hình dạng trên một slide.

Ví dụ truyền `true` vào [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) và [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) cho các autoshape, với các khóa tương đương cho nhóm hình dạng, connector và khung ảnh. Các connector sử dụng [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) để di chuyển; các nhóm cũng sử dụng [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) để hạn chế việc nhóm.

Ví dụ tải một bản trình bày PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng ngoài bốn loại được xử lý sẽ được giữ nguyên. Vòng lặp không duyệt qua các hình dạng con bên trong một nhóm.

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

### **Gỡ bỏ Bảo vệ**

Để gỡ bỏ một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản trình bày có các khóa hình dạng và xóa các hạn chế về lựa chọn, di chuyển và thay đổi kích thước thông qua [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) và [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Nó cũng xóa [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) và lưu một bản sao của bản trình bày. Các cài đặt khóa khác được giữ nguyên.

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

### **Bảo tồn Cắt Ảnh**

Đặt một ảnh có tên `photo.jpg` trong thư mục làm việc. Ví dụ cắt 12% từ phía trái và 8% từ phía phải, sau đó gọi [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) trên khóa khung ảnh để bảo tồn việc cắt và hạn chế việc cắt thêm.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto photoBytes = File::ReadAllBytes(u"photo.jpg");
auto photo = presentation->get_Images()->AddImage(photoBytes);

auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, photo);
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_CropLeft(12);
pictureFormat->set_CropRight(8);

auto pictureFrameLock = pictureFrame->get_PictureFrameLock();
pictureFrameLock->set_AspectRatioLocked(false);
pictureFrameLock->set_CropLocked(true);

presentation->Save(u"PictureLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`PictureLocked.pptx` lưu khóa cắt dưới dạng `true`. Trong PowerPoint, lệnh **Crop** bị vô hiệu hoá khi ảnh được chọn.

### **Giữ Nhóm Sơ Đồ**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó gọi [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) trên khóa của nhóm để giữ các thành phần của sơ đồ lại với nhau. Các chỉnh sửa khác, như di chuyển nhóm hoặc thay đổi màu nền của thành phần, vẫn khả dụng.

```cpp
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto groupShape = shapes->AddGroupShape();
auto groupShapes = groupShape->get_Shapes();
groupShapes->AddAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
groupShapes->AddAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
groupShape->get_GroupShapeLock()->set_UngroupingLocked(true);

presentation->Save(u"DiagramLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`DiagramLocked.pptx` lưu khóa gỡ nhóm dưới dạng `true`. Trong PowerPoint, lệnh **Ungroup** bị vô hiệu hoá khi toàn bộ sơ đồ được chọn.

### **Báo cáo Các Khóa Hình dạng Hiện có**

Để xem lại một mẫu, mở nó và đọc đối tượng khóa của mỗi hình dạng. [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) trả về `true` khi tất cả các cờ trên đối tượng đó bị tắt và `false` khi ít nhất một cờ được bật. Một nhóm và các phần tử con của nó có các đối tượng khóa riêng, vì vậy hãy kiểm tra các phần tử con ngay cả khi nhóm không có khóa.

Ví dụ này kiểm tra việc di chuyển cho autoshape, khung ảnh và nhóm, việc cắt cho ảnh, và gỡ nhóm cho các nhóm. Nó báo cáo các cờ mà nó nhận diện và đánh dấu các loại hình dạng mà nó không kiểm tra.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/list.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <functional>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

std::function<void(SharedPtr<IShapeCollection>, int, String)> inspect;
inspect = [&inspect](SharedPtr<IShapeCollection> shapes, int slideNumber, String prefix)
{
    for (auto&& shape : IterateOver(shapes))
    {
        auto path = prefix + shape->get_Name();
        auto label = String::Format(u"Slide {0} | {1} | {2}", slideNumber, path, shape->GetType().get_Name());
        auto flags = MakeObject<List<String>>();
        auto group = AsCast<IGroupShape>(shape);

        if (group)
        {
            auto locks = group->get_GroupShapeLock();
            if (locks->get_UngroupingLocked()) flags->Add(u"UngroupingLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto picture = AsCast<IPictureFrame>(shape))
        {
            auto locks = picture->get_PictureFrameLock();
            if (locks->get_CropLocked()) flags->Add(u"CropLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto autoShape = AsCast<IAutoShape>(shape))
        {
            if (autoShape->get_AutoShapeLock()->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else
        {
            Console::WriteLine(label + u" | Uninspected");
            continue;
        }

        if (!shape->get_ShapeLock()->get_NoLocks())
        {
            auto restrictions = flags->get_Count() ? String::Join(u", ", flags->ToArray()) : String(u"Active flag not identified");
            Console::WriteLine(label + u" | " + restrictions);
        }

        if (group)
            inspect(group->get_Shapes(), slideNumber, path + u"/");
    }
};

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    inspect(slide->get_Shapes(), slide->get_SlideNumber(), u"");
}
presentation->Dispose();
```

Giả sử slide 1 của `Sample.pptx` chứa một nhóm có tên `Layout` với khóa gỡ nhóm, một ảnh có tên `Photo` bên trong với khóa cắt, và một hình chữ nhật không khóa có tên `Free`. Báo cáo bỏ qua `Free` và in ra hai dòng sau:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Báo cáo đọc các cờ chỉnh sửa ở mức hình dạng đã lưu mà không thay đổi chúng hoặc lưu bản trình bày. Bảo vệ ghi ở mức tài liệu là một cài đặt riêng, và việc thực thi mỗi cờ phụ thuộc vào trình chỉnh sửa.

### **Kết luận**

Aspose.Slides for C++ cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng hoặc áp dụng cùng một hạn chế trên nhiều slide. Chọn các khóa được hỗ trợ bởi từng loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần gỡ bỏ những hạn chế đó.

## **CÂU HỎI THƯỜNG GẶP**

**Can I combine shape locks and password protection in the same presentation?**

Có. Khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo mật bằng mật khẩu](/slides/vi/cpp/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình bày. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Can I restrict editing on specific slides without affecting others?**

Có. Áp dụng các khóa chỉ cho các hình dạng trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**How can I apply locks to individual shapes inside a group?**

Duyệt qua bộ sưu tập trả về bởi phương thức [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) của nhóm và áp dụng các khóa phù hợp cho mỗi hình dạng con. Lặp lại thao tác này cho bất kỳ nhóm lồng nhau nào, theo cách duyệt trong ví dụ báo cáo.