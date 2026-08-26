---
title: Lấy và Cập nhật Thông tin Bản trình bày bằng C++
linktitle: Thông tin Bản trình bày
type: docs
weight: 30
url: /vi/cpp/examine-presentation/
keywords:
- định dạng bản trình bày
- thuộc tính bản trình bày
- thuộc tính tài liệu
- lấy thuộc tính
- đọc thuộc tính
- thay đổi thuộc tính
- sửa đổi thuộc tính
- cập nhật thuộc tính
- kiểm tra PPTX
- kiểm tra PPT
- kiểm tra ODP
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình bày PowerPoint và OpenDocument bằng C++ để có cái nhìn nhanh hơn và đánh giá nội dung thông minh hơn."
---
## **Tổng quan**

Bài viết này hướng dẫn cách kiểm tra thông tin bản trình bày trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của bản trình bày mà không cần tải toàn bộ tệp, đọc các thuộc tính tài liệu của nó và cập nhật các thuộc tính đó khi cần.

Các ví dụ dựa trên các API [PresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/documentproperties/) và minh họa các thao tác điển hình khi làm việc với siêu dữ liệu bản trình bày.

## **Kiểm tra định dạng bản trình bày**

Trước khi làm việc với một bản trình bày, bạn có thể muốn biết định dạng (PPT, PPTX, ODP và các định dạng khác) hiện tại của bản trình bày là gì.

Bạn có thể kiểm tra định dạng của bản trình bày mà không cần tải nó. Xem đoạn mã C++ sau:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Lấy thuộc tính bản trình bày**

Đoạn mã C++ này cho bạn biết cách lấy các thuộc tính của bản trình bày (thông tin về bản trình bày):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ...
```

## **Cập nhật thuộc tính bản trình bày**

Aspose.Slides cung cấp phương thức [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) cho phép bạn thực hiện các thay đổi đối với thuộc tính của bản trình bày.

Giả sử chúng ta có một bản trình bày PowerPoint với các thuộc tính tài liệu như dưới đây.

![Thuộc tính tài liệu gốc của bản trình bày PowerPoint](input_properties.png)

Ví dụ mã này cho bạn thấy cách chỉnh sửa một số thuộc tính của bản trình bày:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị dưới đây.

![Thuộc tính tài liệu đã thay đổi của bản trình bày PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Để biết thêm thông tin về một bản trình bày và các thuộc tính bảo mật của nó, bạn có thể thấy các liên kết sau hữu ích:

- [Bảo vệ bản trình bày bằng mật khẩu](/slides/vi/cpp/password-protected-presentation/)
- [Bảo vệ bản trình bày bằng ghi](/slides/vi/cpp/write-protected-presentation/)

## **FAQ**

**Làm thế nào tôi có thể kiểm tra xem các phông chữ có được nhúng hay không và chúng là những phông chữ nào?**

Tìm thông tin [embedded-font information](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/getembeddedfonts/) ở cấp độ bản trình bày, sau đó so sánh các mục đó với tập hợp [fonts actually used across content](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/getfonts/) để xác định phông chữ nào là quan trọng cho việc hiển thị.

**Làm thế nào tôi có thể nhanh chóng xác định xem tệp có slide ẩn không và có bao nhiêu?**

Duyệt qua [slide collection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidecollection/) và kiểm tra [visibility flag](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/get_hidden/) của mỗi slide.

**Tôi có thể phát hiện liệu kích thước và định hướng slide tùy chỉnh có được sử dụng hay không, và chúng có khác so với mặc định không?**

Có. So sánh [slide size and orientation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_slidesize/) hiện tại với các preset tiêu chuẩn; điều này giúp dự đoán hành vi khi in và xuất.

**Có cách nhanh để xem biểu đồ có tham chiếu đến nguồn dữ liệu bên ngoài không?**

Có. Duyệt qua tất cả các [charts](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chart/), kiểm tra [data source](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), và ghi chú liệu dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị hỏng.

**Làm thế nào tôi có thể đánh giá các slide 'nặng' có thể làm chậm quá trình render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng đổ, hoạt ảnh và đa phương tiện; gán một điểm phức tạp sơ bộ để đánh dấu các điểm nóng tiềm năng về hiệu suất.