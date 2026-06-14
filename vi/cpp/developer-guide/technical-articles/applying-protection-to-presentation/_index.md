---
title: Ngăn Chặn Việc Chỉnh Sửa Bản Trình Bày Bằng Khóa Hình Dạng
linktitle: Ngăn Chặn Việc Chỉnh Sửa Bản Trình Bày
type: docs
weight: 10
url: /vi/cpp/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa hình dạng
- khóa vị trí
- khóa chọn
- khóa kích thước
- khóa nhóm
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho C++ khóa hoặc mở khóa các hình dạng trong tập tin PPT, PPTX và ODP, bảo vệ bản trình bày đồng thời cho phép chỉnh sửa có kiểm soát và giao hàng nhanh hơn."
---
## **Bối cảnh**

Một mục đích phổ biến của Aspose.Slides là tạo, cập nhật và lưu các bản trình bày Microsoft PowerPoint (PPTX) như một phần của quy trình tự động. Người dùng các ứng dụng sử dụng Aspose.Slides theo cách này có quyền truy cập vào các bản trình bày đã tạo, do đó bảo vệ chúng khỏi việc chỉnh sửa là một mối quan tâm chung. Điều quan trọng là các bản trình bày được tạo tự động phải giữ nguyên định dạng và nội dung ban đầu.

Bài viết này giải thích cách cấu trúc của bản trình bày và slide, cũng như cách Aspose.Slides for C++ có thể áp dụng bảo vệ cho một bản trình bày và sau đó gỡ bỏ nó. Nó cung cấp cho nhà phát triển một cách để kiểm soát cách các bản trình bày do ứng dụng của họ tạo ra được sử dụng.

## **Thành phần của một slide**

Một slide trong bản trình bày được tạo thành từ các thành phần như hình tự động, bảng, đối tượng OLE, các hình dạng nhóm, khung ảnh, khung video, kết nối và các yếu tố khác được sử dụng để xây dựng một bản trình bày. Trong Aspose.Slides for C++, mỗi thành phần trên slide được biểu diễn bằng một đối tượng thực thi giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện này.

Cấu trúc của PPTX rất phức tạp, vì vậy không giống như PPT, nơi một khóa chung có thể được sử dụng cho mọi loại hình dạng, các loại hình dạng khác nhau yêu cầu các khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseshapelock/) là lớp khóa chung cho PPTX. Các loại khóa sau được hỗ trợ trong Aspose.Slides for C++ cho PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshapelock/) khóa các hình tự động.  
- [IConnectorLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iconnectorlock/) khóa các hình kết nối.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.  
- [IGroupShapeLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igroupshapelock/) khóa các hình nhóm.  
- [IPictureFrameLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframelock/) khóa các khung ảnh.   

Bất kỳ hành động nào được thực hiện trên tất cả các đối tượng hình dạng trong một đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) sẽ được áp dụng cho toàn bộ bản trình bày.

## **Áp dụng và gỡ bảo vệ**

Áp dụng bảo vệ đảm bảo rằng bản trình bày không thể bị chỉnh sửa. Đây là một kỹ thuật hữu ích để bảo vệ nội dung của bản trình bày.

### **Áp dụng bảo vệ cho các hình dạng PPTX**

Aspose.Slides for C++ cung cấp giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) để làm việc với các hình dạng trên một slide.

Như đã đề cập ở trên, mỗi lớp hình dạng có một lớp khóa hình dạng tương ứng để thực hiện bảo vệ. Bài viết này tập trung vào các khóa NoSelect, NoMove và NoResize. Các khóa này đảm bảo rằng các hình dạng không thể được chọn (bằng cách nhấp chuột hoặc các phương pháp chọn khác) và không thể di chuyển hoặc thay đổi kích thước.

Mẫu mã sau áp dụng bảo vệ cho tất cả các loại hình dạng trong một bản trình bày.

```cpp
// Tạo một đối tượng Presentation đại diện cho tệp PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Duyệt qua tất cả các slide trong bản trình bày.
for (auto&& slide : presentation->get_Slides())	{

	// Duyệt qua tất cả các hình dạng trong slide.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Ép kiểu hình dạng thành autoshape và lấy khóa hình dạng của nó.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Ép kiểu hình dạng thành group shape và lấy khóa hình dạng của nó.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Ép kiểu hình dạng thành connector shape và lấy khóa hình dạng của nó.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Ép kiểu hình dạng thành picture frame và lấy khóa hình dạng của nó.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Lưu tệp bản trình bày.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Gỡ bảo vệ**

Để mở khóa một hình dạng, đặt giá trị của khóa đã áp dụng thành `false`. Mẫu mã dưới đây cho thấy cách mở khóa các hình dạng trong một bản trình bày đã khóa.

```cpp
// Khởi tạo lớp Presentation đại diện cho tệp PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Duyệt qua tất cả các slide trong bản trình bày.
for (auto&& slide : presentation->get_Slides())	{

	// Duyệt qua tất cả các hình dạng trong slide.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Ép kiểu hình dạng thành autoshape và lấy khóa hình dạng của nó.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Ép kiểu hình dạng thành group shape và lấy khóa hình dạng của nó.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Ép kiểu hình dạng thành connector shape và lấy khóa hình dạng của nó.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Ép kiểu hình dạng thành picture frame và lấy khóa hình dạng của nó.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Lưu tệp bản trình bày.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kết luận**

Aspose.Slides cung cấp một số tùy chọn để bảo vệ các hình dạng trong một bản trình bày. Bạn có thể khóa một hình dạng riêng lẻ hoặc duyệt qua tất cả các hình dạng trong bản trình bày và khóa từng cái để bảo vệ hiệu quả toàn bộ tệp. Bạn có thể gỡ bảo vệ bằng cách đặt giá trị khóa thành `false`.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình bày không?**

Có. Các khóa hạn chế việc chỉnh sửa các đối tượng trong tệp, trong khi [password protection](/slides/vi/cpp/password-protected-presentation/) kiểm soát quyền truy cập để mở và/hoặc lưu các thay đổi. Hai cơ chế này bổ trợ lẫn nhau và hoạt động đồng thời.

**Tôi có thể hạn chế việc chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng các khóa cho các hình dạng trên các slide đã chọn; các slide còn lại sẽ vẫn có thể chỉnh sửa.

**Các khóa hình dạng có áp dụng cho các đối tượng nhóm và kết nối không?**

Có. Các loại khóa riêng được hỗ trợ cho các nhóm, kết nối, đối tượng đồ họa và các loại hình dạng khác.