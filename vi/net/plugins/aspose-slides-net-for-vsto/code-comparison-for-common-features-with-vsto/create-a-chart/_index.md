---
title: Tạo biểu đồ
type: docs
weight: 60
url: /vi/net/create-a-chart/
---
Các ví dụ mã dưới đây mô tả quy trình thêm một biểu đồ cột cụm 3D đơn giản bằng VSTO. Bạn tạo một thể hiện của bản trình bày, thêm một biểu đồ mặc định vào đó. Sau đó sử dụng sổ làm việc Microsoft Excel để truy cập và chỉnh sửa dữ liệu biểu đồ cùng với việc thiết lập các thuộc tính của biểu đồ. Cuối cùng, lưu bản trình bày.

## **VSTO**
Sử dụng VSTO, các bước sau được thực hiện:

1. Tạo một thể hiện của bản trình bày Microsoft PowerPoint.
1. Thêm một slide trống vào bản trình bày.
1. Thêm một biểu đồ cột cụm 3D và truy cập nó.
1. Tạo một thể hiện mới của Microsoft Excel Workbook và tải dữ liệu biểu đồ.
1. Truy cập worksheet dữ liệu biểu đồ bằng thể hiện Microsoft Excel Workbook từ sổ làm việc.
1. Đặt phạm vi biểu đồ trong worksheet và loại bỏ series 2 và 3 khỏi biểu đồ.
1. Sửa đổi dữ liệu danh mục của biểu đồ trong worksheet dữ liệu biểu đồ.
1. Sửa đổi dữ liệu của series 1 trong worksheet dữ liệu biểu đồ.
1. Bây giờ, truy cập tiêu đề biểu đồ và thiết lập các thuộc tính liên quan đến phông chữ.
1. Truy cập trục giá trị của biểu đồ và đặt đơn vị chính, đơn vị phụ, giá trị tối đa và giá trị tối thiểu.
1. Truy cập độ sâu biểu đồ hoặc trục series và loại bỏ nó vì trong ví dụ này chỉ sử dụng một series.
1. Bây giờ, đặt góc xoay của biểu đồ theo hướng X và Y.
1. Lưu bản trình bày.
1. Đóng các thể hiện của Microsoft Excel và PowerPoint.

``` csharp

 //Biến toàn cục

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Khởi tạo đối tượng slide

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Truy cập slide đầu tiên của bản trình bày

	objSlide = objPres.Slides[1];

	//Chọn slide đầu tiên và đặt bố cục của nó

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Thêm một biểu đồ mặc định vào slide

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Truy cập biểu đồ đã thêm

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Truy cập dữ liệu biểu đồ

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Tạo một thể hiện Workbook Excel để làm việc với dữ liệu biểu đồ

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Truy cập worksheet dữ liệu cho biểu đồ

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Đặt phạm vi cho biểu đồ

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Áp dụng phạm vi đã đặt vào bảng dữ liệu biểu đồ

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Đặt giá trị cho các danh mục và dữ liệu series tương ứng

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Đặt tiêu đề biểu đồ

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Truy cập trục giá trị của biểu đồ

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Đặt đơn vị cho trục giá trị

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Truy cập trục độ sâu của biểu đồ

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Đặt góc xoay của biểu đồ

	ppChart.Rotation = 20; //Giá trị Y

	ppChart.Elevation = 15; //Giá trị X

	ppChart.RightAngleAxes = false;

	// Lưu bản trình bày dưới dạng PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Đóng Workbook và bản trình bày

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//Các phương thức bổ sung

public static void StartPowerPoint()

{

	objPPT = new Microsoft.Office.Interop.PowerPoint.Application();

	objPPT.Visible = MsoTriState.msoTrue;

	//  objPPT.WindowState = PowerPoint.PpWindowState.ppWindowMaximized

}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation)

{

	EnsurePowerPointIsRunning(blnAddPresentation, false);

}

public static void EnsurePowerPointIsRunning()

{

	EnsurePowerPointIsRunning(false, false);

}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)

{

	string strName = null;

	//

	//Cố gắng truy cập thuộc tính name. Nếu gây ra ngoại lệ thì

	//khởi tạo một thể hiện mới của PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation được sử dụng để đảm bảo đã tải một bản trình bày

	if (blnAddPresentation == true)

	{

		try

		{

			strName = objPres.Name;

		}

		catch (Exception ex)

		{

			objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);

		}

	}

	//

	//BlnAddSlide được sử dụng để đảm bảo có ít nhất một slide trong

	//bản trình bày

	if (blnAddSlide)

	{

		try

		{

			strName = objPres.Slides[1].Name;

		}

		catch (Exception ex)

		{

			Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

			Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;

			objCustomLayout = objPres.SlideMaster.CustomLayouts[1];

			objSlide = objPres.Slides.AddSlide(1, objCustomLayout);

			objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;

			objCustomLayout = null;

			objSlide = null;

		}

	}

}
```
## **Aspose.Slides**
Sử dụng Aspose.Slides cho .NET, các bước sau được thực hiện:

1. Tạo một thể hiện của bản trình bày Microsoft PowerPoint.
1. Thêm một slide trống vào bản trình bày.
1. Thêm một biểu đồ cột cụm 3D và truy cập nó.
1. Truy cập worksheet dữ liệu biểu đồ bằng một thể hiện Microsoft Excel Workbook từ sổ làm việc.
1. Loại bỏ series 2 và 3 không sử dụng.
1. Truy cập các danh mục biểu đồ và sửa đổi nhãn.
1. Truy cập series 1 và sửa đổi giá trị series.
1. Bây giờ, truy cập tiêu đề biểu đồ và thiết lập các thuộc tính phông chữ.
1. Truy cập trục giá trị của biểu đồ và đặt đơn vị chính, đơn vị phụ, giá trị tối đa và giá trị tối thiểu.
1. Bây giờ, đặt góc xoay của biểu đồ theo hướng X và Y.
1. Lưu bản trình bày ở định dạng PPTX.

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//Tạo bài trình bày trống

	using (PresentationEx pres = new PresentationEx())

	{

		//Truy cập slide đầu tiên

		SlideEx slide = pres.Slides[0];

		//Thêm biểu đồ mặc định

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Lấy dữ liệu biểu đồ

		ChartDataEx chartData = ppChart.ChartData;

		//Xóa các series mặc định dư thừa

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Sửa đổi tên danh mục biểu đồ

		chartData.Categories[0].ChartDataCell.Value = "Bikes";

		chartData.Categories[1].ChartDataCell.Value = "Accessories";

		chartData.Categories[2].ChartDataCell.Value = "Repairs";

		chartData.Categories[3].ChartDataCell.Value = "Clothing";

		//Sửa đổi giá trị series biểu đồ cho danh mục đầu tiên

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Đặt tiêu đề biểu đồ

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 Sales";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Đặt giá trị trục

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Đặt góc xoay biểu đồ

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Lưu bài trình bày

		pres.Write("AsposeSampleChart.pptx");

	}

```
## **Tải xuống mã mẫu**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)