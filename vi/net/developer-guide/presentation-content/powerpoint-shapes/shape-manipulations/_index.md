---
title: Quản lý các hình trong bản trình chiếu bằng .NET
linktitle: Thao tác hình
type: docs
weight: 40
url: /vi/net/shape-manipulations/
keywords:
- hình PowerPoint
- hình trong bản trình chiếu
- hình trên slide
- tìm hình
- sao chép hình
- xóa hình
- ẩn hình
- thay đổi thứ tự hình
- lấy Interop Shape ID
- văn bản thay thế cho hình
- định dạng bố cục cho hình
- hình dưới dạng SVG
- chuyển hình sang SVG
- căn hình
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Học cách tạo, chỉnh sửa và tối ưu hóa các hình trong Aspose.Slides cho .NET và cung cấp các bản trình chiếu PowerPoint hiệu năng cao."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các hình trong bản trình chiếu bằng Aspose.Slides. Nó chỉ ra cách tìm một hình trên slide, sao chép, xóa, ẩn, thay đổi thứ tự, lấy ID hình Interop và đặt văn bản thay thế để nhận dạng và xử lý tiếp theo.

Bài viết cũng đề cập cách truy cập định dạng bố cục cho hình, kết xuất hình dưới dạng SVG, căn chỉnh hình trên slide và sử dụng các thuộc tính lật để phản chiếu ngang và dọc. Ngoài ra, còn có một phần FAQ ngắn về việc kết hợp hình, thứ tự chồng (z‑order) và khóa hình.

## **Tìm một hình trên slide**
Chủ đề này sẽ mô tả một kỹ thuật đơn giản giúp các nhà phát triển dễ dàng tìm một hình cụ thể trên slide mà không cần sử dụng Id nội bộ của nó. Điều quan trọng là các tệp PowerPoint không có cách nào để xác định hình trên slide ngoại trừ Id duy nhất nội bộ. Việc sử dụng Id nội bộ để tìm hình thường gặp khó khăn. Tất cả các hình được thêm vào slide đều có một số Văn bản Alt. Chúng tôi đề nghị các nhà phát triển sử dụng văn bản thay thế để tìm một hình cụ thể. Bạn có thể dùng MS PowerPoint để xác định văn bản thay thế cho các đối tượng mà bạn dự định sẽ thay đổi sau này.

Sau khi đặt văn bản thay thế cho bất kỳ hình nào mong muốn, bạn có thể mở bản trình chiếu đó bằng Aspose.Slides for .NET và duyệt qua tất cả các hình được thêm vào một slide. Trong mỗi vòng lặp, bạn kiểm tra văn bản thay thế của hình và hình có văn bản thay thế khớp sẽ là hình bạn cần. Để minh họa kỹ thuật này một cách rõ ràng hơn, chúng tôi đã tạo một phương thức, [FindShape](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/findshape/#findshape_1) thực hiện việc tìm một hình cụ thể trên slide và trả về hình đó.

```c#
public static void Run()
{
    // Tạo một lớp Presentation đại diện cho tệp bản trình chiếu
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Văn bản thay thế của hình cần tìm
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Triển khai phương thức để tìm một hình trong slide bằng văn bản thay thế của nó
public static IShape FindShape(ISlide slide, string alttext)
{
    // Duyệt qua tất cả các hình trong slide
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Nếu văn bản thay thế của slide khớp với yêu cầu thì
        // Trả về hình
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **Sao chép một hình**
Để sao chép một hình vào slide bằng Aspose.Slides for .NET:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Truy cập bộ sưu tập hình của slide nguồn.
1. Thêm một slide mới vào bản trình chiếu.
1. Sao chép các hình từ bộ sưu tập hình của slide nguồn sang slide mới.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Ví dụ dưới đây thêm một hình nhóm vào slide.

```c#
// Khởi tạo lớp Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Ghi tệp PPTX ra đĩa
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **Xóa một hình**
Aspose.Slides for .NET cho phép các nhà phát triển xóa bất kỳ hình nào. Để xóa hình khỏi bất kỳ slide nào, vui lòng thực hiện các bước dưới đây:

1. Tạo một thể hiện của lớp `Presentation`.
1. Truy cập slide đầu tiên.
1. Tìm hình có AlternativeText cụ thể.
1. Xóa hình.
1. Lưu tệp vào đĩa.

```c#
// Tạo đối tượng Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = pres.Slides[0];

// Thêm autoshape loại hình chữ nhật
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Lưu bản trình chiếu ra đĩa
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **Ẩn một hình**
Aspose.Slides for .NET cho phép các nhà phát triển ẩn bất kỳ hình nào. Để ẩn hình khỏi bất kỳ slide nào, vui lòng thực hiện các bước dưới đây:

1. Tạo một thể hiện của lớp `Presentation`.
1. Truy cập slide đầu tiên.
1. Tìm hình có AlternativeText cụ thể.
1. Ẩn hình.
1. Lưu tệp vào đĩa.

```c#
// Tạo đối tượng Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();

// Lấy slide đầu tiên
ISlide sld = pres.Slides[0];

// Thêm autoshape loại hình chữ nhật
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Lưu bản trình chiếu ra đĩa
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **Thay đổi thứ tự hình**
Aspose.Slides for .NET cho phép các nhà phát triển thay đổi thứ tự các hình. Thay đổi thứ tự xác định hình nào ở phía trước và hình nào ở phía sau. Để thay đổi thứ tự hình trên bất kỳ slide nào, vui lòng thực hiện các bước dưới đây:

1. Tạo một thể hiện của lớp `Presentation`.
1. Truy cập slide đầu tiên.
1. Thêm một hình.
1. Thêm một số văn bản vào khung văn bản của hình.
1. Thêm một hình khác với cùng tọa độ.
1. Thay đổi thứ tự các hình.
1. Lưu tệp vào đĩa.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```

## **Lấy Interop Shape ID**
Aspose.Slides for .NET cho phép các nhà phát triển lấy một định danh hình duy nhất trong phạm vi slide, đối lập với thuộc tính UniqueId chỉ cho phép lấy định danh duy nhất trong phạm vi bản trình chiếu. Thuộc tính OfficeInteropShapeId đã được thêm vào giao diện IShape và lớp Shape. Giá trị trả về bởi thuộc tính OfficeInteropShapeId tương ứng với giá trị Id của đối tượng Microsoft.Office.Interop.PowerPoint.Shape. Dưới đây là một đoạn mã mẫu.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Lấy định danh hình duy nhất trong phạm vi slide
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **Đặt Văn bản Thay thế cho một Hình**
Aspose.Slides for .NET cho phép các nhà phát triển đặt AlternateText cho bất kỳ hình nào. 
Các hình trong bản trình chiếu có thể được phân biệt bằng thuộc tính AlternativeText hoặc Shape Name. 
Thuộc tính AlternativeText có thể được đọc hoặc đặt thông qua Aspose.Slides cũng như Microsoft PowerPoint. 
Bằng cách sử dụng thuộc tính này, bạn có thể gắn thẻ một hình và thực hiện các thao tác khác nhau như Xóa hình, 
Ẩn hình hoặc Thay đổi thứ tự các hình trên slide.
Để đặt AlternateText cho một hình, vui lòng thực hiện các bước dưới đây:

1. Tạo một thể hiện của lớp `Presentation`.
1. Truy cập slide đầu tiên.
1. Thêm bất kỳ hình nào vào slide.
1. Thực hiện một số thao tác với hình vừa thêm.
1. Duyệt qua các hình để tìm một hình.
1. Đặt AlternativeText.
1. Lưu tệp vào đĩa.

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();

// Lấy slide đầu tiên
ISlide sld = pres.Slides[0];

// Thêm autoshape loại hình chữ nhật
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Lưu bản trình chiếu ra đĩa
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **Truy cập Định dạng Bố cục cho một Hình**
Aspose.Slides for .NET cung cấp API đơn giản để truy cập định dạng bố cục cho một hình. Bài viết này trình bày cách bạn có thể truy cập các định dạng bố cục.

Dưới đây là đoạn mã mẫu.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **Kết xuất Hình dưới dạng SVG**
Bây giờ Aspose.Slides for .NET hỗ trợ kết xuất một hình dưới dạng svg. Phương thức WriteAsSvg (và các overload của nó) đã được thêm vào lớp Shape và giao diện IShape. Phương thức này cho phép lưu nội dung của hình dưới dạng tệp SVG. Đoạn mã dưới đây cho thấy cách xuất hình trên slide ra tệp SVG.

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **Căn một Hình**

Thông qua phương thức [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/methods/alignshapes/index) có overload, bạn có thể 

* căn các hình so với lề của slide. Xem **Ví dụ 1**. 
* căn các hình so với nhau. Xem **Ví dụ 2**. 

Kiểu liệt kê [ShapesAlignmentType](https://reference.aspose.com/slides/vi/net/aspose.slides/shapesalignmenttype) định nghĩa các tùy chọn căn có sẵn.

**Ví dụ 1**

Đoạn mã C# này cho thấy cách căn các hình có chỉ mục 1,2 và 4 dọc theo viền trên cùng của slide:
Mã nguồn dưới đây căn các hình có chỉ mục 1,2 và 4 dọc theo viền trên cùng của slide.

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**Ví dụ 2**

Đoạn mã C# này cho thấy cách căn toàn bộ bộ sưu tập hình so với hình dưới cùng trong bộ sưu tập:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Thuộc tính Lật**

Trong Aspose.Slides, lớp [ShapeFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/shapeframe/) cung cấp khả năng kiểm soát việc phản chiếu ngang và dọc của hình thông qua các thuộc tính `FlipH` và `FlipV`. Cả hai thuộc tính đều có kiểu [NullableBool](https://reference.aspose.com/slides/vi/net/aspose.slides/nullablebool/), cho phép giá trị `True` để lật, `False` để không lật, hoặc `NotDefined` để sử dụng hành vi mặc định. Các giá trị này có thể truy cập từ [Frame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/frame/) của một hình.

Để sửa đổi cài đặt lật, một thể hiện mới của [ShapeFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/shapeframe/) được tạo dựa trên vị trí và kích thước hiện tại của hình, các giá trị mong muốn cho `FlipH` và `FlipV`, và góc quay. Gán thể hiện này cho [Frame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/frame/) của hình và lưu bản trình chiếu sẽ áp dụng các phép biến đổi phản chiếu và ghi chúng vào tệp đầu ra.

Giả sử chúng ta có tệp sample.pptx trong đó slide đầu tiên chứa một hình duy nhất với cài đặt lật mặc định, như hình dưới.

![Hình cần lật](shape_to_be_flipped.png)

Đoạn mã sau lấy các thuộc tính lật hiện tại của hình và lật nó cả ngang và dọc.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Lấy thuộc tính lật ngang của hình.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Lấy thuộc tính lật dọc của hình.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Lật ngang.
    NullableBool flipV = NullableBool.True; // Lật dọc.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình đã lật](flipped_shape.png)

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp các hình (union/intersect/subtract) trên slide giống như trong trình chỉnh sửa desktop không?**

Hiện không có API thao tác Boolean tích hợp. Bạn có thể gần đúng bằng cách tự xây dựng đường viền mong muốn—ví dụ, tính toán hình học kết quả (qua [GeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath/)) và tạo một hình mới với đường viền đó, tùy chọn xóa các hình gốc.

**Làm sao tôi kiểm soát thứ tự chồng (z‑order) để một hình luôn ở phía “trên cùng”?**

Thay đổi thứ tự chèn/di chuyển trong bộ sưu tập [shapes](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslide/shapes/) của slide. Để có kết quả dự đoán được, hãy hoàn thiện z‑order sau khi thực hiện mọi thay đổi khác trên slide.

**Tôi có thể “khóa” một hình để ngăn người dùng chỉnh sửa nó trong PowerPoint không?**

Có. Đặt các cờ bảo vệ ở mức hình ([shape‑level protection flags](/slides/vi/net/applying-protection-to-presentation/)) (ví dụ: khóa chọn, di chuyển, thay đổi kích thước, chỉnh sửa văn bản). Nếu cần, áp dụng các hạn chế tương tự trên master hoặc layout. Lưu ý đây là bảo vệ ở mức giao diện người dùng, không phải tính năng bảo mật; để bảo vệ mạnh hơn, kết hợp với các hạn chế ở mức tệp như đề xuất chỉ đọc hoặc mật khẩu ([read‑only recommendations or passwords](/slides/vi/net/password-protected-presentation/)).