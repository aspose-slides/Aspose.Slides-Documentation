---
title: Quản lý các connector trong bản trình chiếu bằng C++
linktitle: Kết nối
type: docs
weight: 10
url: /vi/cpp/connector/
keywords:
- kết nối
- loại kết nối
- điểm kết nối
- đường kết nối
- góc kết nối
- kết nối các hình dạng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Cho phép các ứng dụng C++ vẽ, nối và tự động định tuyến các đường trong các slide PowerPoint—đạt được kiểm soát đầy đủ đối với các connector thẳng, góc và cong."
---
## **Giới thiệu**

Một PowerPoint connector là một đường đặc biệt kết nối hoặc liên kết hai hình dạng với nhau và vẫn gắn vào các hình dạng ngay cả khi chúng bị di chuyển hoặc thay đổi vị trí trên một slide nhất định. 

Các connector thường được kết nối tới *điểm kết nối* (điểm xanh lá), vốn tồn tại trên mọi hình dạng theo mặc định. Các điểm kết nối xuất hiện khi con trỏ tiếp cận gần chúng.

*Điểm điều chỉnh* (điểm màu cam), chỉ tồn tại trên một số connector nhất định, được dùng để thay đổi vị trí và hình dạng của connector.

## **Các loại Connector**

Trong PowerPoint, bạn có thể sử dụng connector thẳng, góc (elbow), và cong. 

Aspose.Slides cung cấp các connector này:

| Connector                      | Image                                                        | Số điểm điều chỉnh |
| ------------------------------ | ------------------------------------------------------------ | ------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                   |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                   |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                   |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                   |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                   |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                   |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                   |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                   |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                   |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                   |

## **Kết nối các hình dạng bằng Connector**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.auto_shape) vào slide bằng phương thức `AddAutoShape` được cung cấp bởi đối tượng `Shapes` .
4. Thêm một connector bằng phương thức `AddConnector` được cung cấp bởi đối tượng `Shapes` bằng cách xác định loại connector .
5. Kết nối các hình dạng bằng connector .
6. Gọi phương thức `Reroute` để áp dụng đường kết nối ngắn nhất .
7. Lưu bản thuyết trình. 

```c++
// Đường dẫn tới thư mục tài liệu.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Tải bản trình chiếu mong muốn
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Truy cập slide đầu tiên
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Truy cập bộ sưu tập các hình dạng cho một slide cụ thể
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Thêm hình tự động Ellipse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Thêm hình tự động Rectangle
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Thêm một shape connector vào bộ sưu tập shape của slide
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Kết nối các hình dạng bằng connector
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Gọi reroute để đặt đường ngắn nhất tự động giữa các hình dạng
	connector->Reroute();
	
	// Lưu bản trình chiếu
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="LƯU Ý"  color="warning"   %}} 

`Phương thức` `connector->Reroute` `làm lại đường dẫn cho một connector và buộc nó di chuyển theo đường ngắn nhất có thể giữa các hình dạng. Để đạt được mục tiêu này, phương thức có thể thay đổi các điểm `StartShapeConnectionSiteIndex` và `EndShapeConnectionSiteIndex`.`

{{% /alert %}} 

## **Chỉ định Điểm Kết Nối**

Nếu bạn muốn một connector liên kết hai hình dạng bằng cách sử dụng các điểm cụ thể trên các hình dạng, bạn phải chỉ định các điểm kết nối ưa thích của mình theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.auto_shape) vào slide bằng phương thức `AddAutoShape` được cung cấp bởi đối tượng `Shapes` .
4. Thêm một connector bằng phương thức `AddConnector` được cung cấp bởi đối tượng `Shapes` bằng cách xác định loại connector .
5. Kết nối các hình dạng bằng connector . 
6. Đặt các điểm kết nối ưa thích trên các hình dạng. 
7. Lưu bản thuyết trình.

```c++
	// Đường dẫn tới thư mục tài liệu.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Tải bản trình chiếu mong muốn
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Truy cập slide đầu tiên
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Truy cập bộ sưu tập các hình dạng cho một slide cụ thể
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Thêm hình tự động Ellipse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Thêm hình tự động Rectangle
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Thêm một shape connector vào bộ sưu tập shape của slide
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Kết nối các hình dạng bằng connector
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Đặt chỉ số điểm kết nối ưa thích trên hình Ellipse
	int wantedIndex = 6;

	// Kiểm tra xem chỉ số ưa thích có nhỏ hơn số lượng site tối đa hay không
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Đặt điểm kết nối ưa thích trên hình tự động Ellipse
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Lưu bản trình chiếu
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Điều chỉnh một Điểm Connector**

Bạn có thể điều chỉnh một connector hiện có thông qua các điểm điều chỉnh của nó. Chỉ những connector có điểm điều chỉnh mới có thể được thay đổi theo cách này. Xem bảng dưới **[Các loại connector.](/slides/vi/cpp/connector/#types-of-connectors)** 

### **Trường hợp Đơn giản**

Xem xét một trường hợp mà một connector giữa hai hình dạng (A và B) đi qua một hình dạng thứ ba (C):

![connector-obstruction](connector-obstruction.png)

Code:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

Để tránh hoặc vượt qua hình dạng thứ ba, chúng ta có thể điều chỉnh connector bằng cách di chuyển đường thẳng đứng sang trái như sau:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Trường hợp Phức tạp** 

Để thực hiện các điều chỉnh phức tạp hơn, bạn phải lưu ý những điều sau:

* Điểm điều chỉnh của một connector gắn chặt với công thức tính toán và xác định vị trí của nó. Vì vậy, việc thay đổi vị trí của điểm có thể làm thay đổi hình dạng của connector.
* Các điểm điều chỉnh của một connector được định nghĩa theo một thứ tự chặt chẽ trong một mảng. Các điểm điều chỉnh được đánh số từ điểm bắt đầu của connector tới điểm cuối.
* Giá trị của điểm điều chỉnh phản ánh phần trăm của chiều rộng/chiều cao của hình dạng connector.
  * Hình dạng được giới hạn bởi các điểm bắt đầu và kết thúc của connector nhân với 1000. 
  * Điểm thứ nhất, điểm thứ hai và điểm thứ ba lần lượt định nghĩa phần trăm từ chiều rộng, phần trăm từ chiều cao và phần trăm từ chiều rộng (lại một lần) respectively.
* Đối với các phép tính xác định tọa độ của các điểm điều chỉnh của connector, bạn phải tính đến góc quay và phản chiếu của connector. **Lưu ý** rằng góc quay của tất cả các connector được hiển thị dưới **[Các loại connector](/slides/vi/cpp/connector/#types-of-connectors)** là 0.

#### **Trường hợp 1**

Xem xét một trường hợp mà hai đối tượng khung văn bản được liên kết với nhau thông qua một connector:

![connector-shape-complex](connector-shape-complex.png)

Code:

```c++
// Khởi tạo lớp trình chiếu đại diện cho tệp PPTX
auto pres = System::MakeObject<Presentation>();
// Lấy slide đầu tiên trong bản trình chiếu
auto slide = pres->get_Slides()->idx_get(0);
// Lấy các hình dạng từ slide đầu tiên
auto shapes = slide->get_Shapes();
// Thêm các hình dạng sẽ được nối lại với nhau bằng một connector
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Thêm một connector
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Xác định hướng của connector
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Xác định độ dày của đường connector
lineFormat->set_Width(3);
// Xác định màu sắc của connector
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Liên kết các hình dạng với nhau bằng connector
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Lấy các điểm điều chỉnh cho connector
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Điều chỉnh**

Chúng ta có thể thay đổi giá trị điểm điều chỉnh của connector bằng cách tăng phần trăm chiều rộng và chiều cao tương ứng lên 20% và 200% tương ứng:

```c++
// Thay đổi giá trị của các điểm điều chỉnh
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Kết quả:

![connector-adjusted-1](connector-adjusted-1.png)

Để định nghĩa một mô hình cho phép chúng ta xác định tọa độ và hình dạng của các phần riêng lẻ của connector, hãy tạo một hình dạng tương ứng với thành phần ngang của connector tại điểm connector.Adjustments[0]:

```c++
// Vẽ thành phần dọc của connector
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Kết quả:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Trường hợp 2**

Trong **Trường hợp 1**, chúng ta đã minh họa một thao tác điều chỉnh connector đơn giản bằng các nguyên tắc cơ bản. Trong các tình huống bình thường, bạn phải tính đến góc quay và cách hiển thị của connector (được thiết lập bởi `connector.Rotation`, `connector.Frame.FlipH`, và `connector.Frame.FlipV`). Bây giờ chúng ta sẽ trình bày quy trình.

Đầu tiên, hãy thêm một đối tượng khung văn bản mới (**To 1**) vào slide (để kết nối) và tạo một connector (màu xanh lá) mới nối nó với các đối tượng đã tạo trước đó.

```c++
// Tạo một đối tượng binding mới
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Tạo một connector mới
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Kết nối các đối tượng bằng connector mới tạo
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Lấy các điểm điều chỉnh của connector
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Thay đổi giá trị của các điểm điều chỉnh
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Kết quả:

![connector-adjusted-3](connector-adjusted-3.png)

Thứ hai, hãy tạo một hình dạng sẽ tương ứng với thành phần ngang của connector đi qua điểm điều chỉnh mới của connector `connector.Adjustments[0]`. Chúng ta sẽ sử dụng các giá trị từ dữ liệu connector cho `connector.Rotation`, `connector.Frame.FlipH`, và `connector.Frame.FlipV` và áp dụng công thức chuyển đổi tọa độ phổ biến cho việc quay quanh một điểm x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Trong trường hợp của chúng ta, góc quay của đối tượng là 90 độ và connector hiển thị theo chiều dọc, vì vậy đây là mã tương ứng:

```c++

```

Kết quả:

![connector-adjusted-4](connector-adjusted-4.png)

Chúng tôi đã minh họa các phép tính liên quan đến việc điều chỉnh đơn giản và các điểm điều chỉnh phức tạp (điểm điều chỉnh có góc quay). Sử dụng kiến thức đã học, bạn có thể phát triển mô hình riêng của mình (hoặc viết mã) để lấy đối tượng `GraphicsPath` hoặc thậm chí đặt giá trị điểm điều chỉnh của connector dựa trên tọa độ slide cụ thể.

## **Tìm Góc của Các Đường Connector**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Truy cập hình dạng đường connector.
4. Sử dụng độ rộng, chiều cao của đường, chiều cao khung hình dạng và độ rộng khung hình dạng để tính góc.

```c++
void ConnectorLineAngle()
{

	// Đường dẫn tới thư mục tài liệu.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Tải bản trình chiếu mong muốn
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Truy cập slide đầu tiên
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Truy cập bộ sưu tập các hình dạng của slide
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
//	float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **Câu hỏi thường gặp**

**Làm thế nào để tôi biết một connector có thể "dán" vào một hình dạng cụ thể không?**

Kiểm tra xem hình dạng có cung cấp [connection sites](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/get_connectionsitecount/) hay không. Nếu không có hoặc số lượng bằng 0, việc dán không khả dụng; trong trường hợp đó, hãy sử dụng các đầu điểm tự do và định vị chúng một cách thủ công. Thông thường nên kiểm tra số lượng site trước khi gắn.

**Điều gì xảy ra với một connector nếu tôi xóa một trong các hình dạng đã kết nối?**

Các đầu của nó sẽ bị tách rời; connector vẫn còn trên slide như một đường thông thường với đầu/start và end tự do. Bạn có thể xóa nó hoặc gán lại các kết nối và, nếu cần, [reroute](https://reference.aspose.com/slides/vi/cpp/aspose.slides/connector/reroute/).

**Các liên kết connector có được giữ lại khi sao chép một slide sang bản thuyết trình khác không?**

Nói chung là có, với điều kiện các hình dạng mục tiêu cũng được sao chép. Nếu slide được chèn vào một tệp khác mà không có các hình dạng đã kết nối, các đầu sẽ trở thành tự do và bạn sẽ cần gắn lại chúng.