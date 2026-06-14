---
title: Khóa Bài Trình
type: docs
weight: 110
url: /vi/net/presentation-locking/
---
## **Khóa Bài Trình**
Một cách sử dụng phổ biến cho **Aspose.Slides** là tạo, cập nhật và lưu các bài thuyết trình Microsoft PowerPoint 2007 (PPTX) như một phần của quy trình tự động. Người dùng của ứng dụng sử dụng Aspose.Slides theo cách này sẽ nhận được các bài thuyết trình đầu ra. Bảo vệ chúng khỏi việc chỉnh sửa là một mối quan tâm phổ biến. Điều quan trọng là các bài thuyết trình được tạo tự động phải giữ nguyên định dạng và nội dung gốc.

Điều này giải thích cách các bài thuyết trình và slide được xây dựng và cách Aspose.Slides for .NET có thể áp dụng bảo vệ và sau đó gỡ bỏ bảo vệ khỏi một bài thuyết trình. Tính năng này là duy nhất đối với Aspose.Slides và, tại thời điểm viết bài, không có sẵn trong Microsoft PowerPoint. Nó cung cấp cho các nhà phát triển một cách kiểm soát cách các bài thuyết trình do ứng dụng của họ tạo ra được sử dụng.

## **Cấu Trúc Của Một Slide**
Một slide PPTX được cấu thành từ nhiều thành phần như các hình tự động, bảng, đối tượng OLE, các hình nhóm, khung hình ảnh, khung video, kết nối và các yếu tố khác có sẵn để xây dựng một bài thuyết trình.

Trong Aspose.Slides for .NET, mỗi thành phần trên slide được chuyển thành một đối tượng Shape. Nói cách khác, mỗi thành phần trên slide là một đối tượng Shape hoặc một đối tượng kế thừa từ Shape.

Cấu trúc của PPTX khá phức tạp, vì vậy không giống như PPT, nơi một khóa chung có thể được sử dụng cho mọi loại hình, PPTX có các loại khóa khác nhau cho từng loại hình. Lớp BaseShapeLock là lớp khóa chung cho PPTX. Các loại khóa sau được hỗ trợ trong Aspose.Slides for .NET cho PPTX.

- AutoShapeLock khóa các hình tự động.
- ConnectorLock khóa các hình kết nối.
- GraphicalObjectLock khóa các đối tượng đồ họa.
- GroupshapeLock khóa các hình nhóm.
- PictureFrameLock khóa các khung hình ảnh.

Mọi hành động thực hiện trên tất cả các đối tượng Shape trong một đối tượng Presentation sẽ được áp dụng cho toàn bộ bài thuyết trình.

## **Áp Dụng và Gỡ Bảo Vệ**
Áp dụng bảo vệ đảm bảo rằng một bài thuyết trình không thể bị chỉnh sửa. Đây là một kỹ thuật hữu ích để bảo vệ nội dung của bài thuyết trình.

**Áp Dụng Bảo Vệ cho Các Shape PPTX**
Aspose.Slides for .NET cung cấp lớp Shape để xử lý một shape trên slide.

Như đã đề cập trước đó, mỗi lớp shape có một lớp khóa shape tương ứng để bảo vệ. Bài viết này tập trung vào các khóa NoSelect, NoMove và NoResize. Những khóa này đảm bảo rằng các shape không thể được chọn (bằng cách nhấp chuột hoặc các phương pháp chọn khác), và chúng không thể di chuyển hoặc thay đổi kích thước.

Các mẫu mã sau đây áp dụng bảo vệ cho tất cả các loại shape trong một bài thuyết trình.

``` csharp

 //Khởi tạo lớp Presentation đại diện cho tệp PPTX file

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Khởi tạo lớp Presentation đại diện cho tệp PPTX file


//Đối tượng ISlide để truy cập các slide trong bài thuyết trình

SlideEx slide = pTemplate.Slides[0];

//Đối tượng IShape để giữ các shape tạm thời

ShapeEx shape;

//Duyệt qua tất cả các slide trong bài thuyết trình

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

		//Duyệt qua tất cả các shape trong các slide

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//nếu shape là autoshape

		if (shape is AutoShapeEx)

		{

			//Ép kiểu sang Auto shape và lấy khóa auto shape

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Áp dụng khóa cho shape

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//nếu shape là group shape

		else if (shape is GroupShapeEx)

		{

			//Ép kiểu sang group shape và lấy khóa group shape

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Áp dụng khóa cho shape

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//nếu shape là connector

		else if (shape is ConnectorEx)

		{

			//Ép kiểu sang connector shape và lấy khóa connector shape

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Áp dụng khóa cho shape

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//nếu shape là picture frame

		else if (shape is PictureFrameEx)

		{

			//Ép kiểu sang picture frame shape và lấy khóa picture frame shape

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Áp dụng khóa cho shape

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Lưu tệp bài thuyết trình

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 

**Gỡ Bảo Vệ**
Bảo vệ được áp dụng bằng Aspose.Slides for .NET chỉ có thể được gỡ bỏ bằng Aspose.Slides for .NET. Để mở khóa một shape, đặt giá trị của khóa đã áp dụng thành false. Mẫu mã sau đây cho thấy cách mở khóa các shape trong một bài thuyết trình đã bị khóa.

``` csharp

 //Mở bài thuyết trình mong muốn

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//Đối tượng ISlide để truy cập các slide trong bài thuyết trình

SlideEx slide = pTemplate.Slides[0];

//Đối tượng IShape để giữ các shape tạm thời

ShapeEx shape;

//Duyệt qua tất cả các slide trong bài thuyết trình

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Duyệt qua tất cả các shape trong các slide

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//nếu shape là autoshape

		if (shape is AutoShapeEx)

		{

			//Ép kiểu sang Auto shape và lấy khóa auto shape

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Áp dụng khóa cho shape

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//nếu shape là group shape

		else if (shape is GroupShapeEx)

		{

			//Ép kiểu sang group shape và lấy khóa group shape

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Áp dụng khóa cho shape

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//nếu shape là Connector shape

		else if (shape is ConnectorEx)

		{

			//Ép kiểu sang connector shape và lấy khóa connector shape

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Áp dụng khóa cho shape

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//nếu shape là picture frame

		else if (shape is PictureFrameEx)

		{

			//Ép kiểu sang picture frame shape và lấy khóa picture frame shape

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Áp dụng khóa cho shape

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Lưu tệp bài thuyết trình

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 

## **Tải Mã Mẫu**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)