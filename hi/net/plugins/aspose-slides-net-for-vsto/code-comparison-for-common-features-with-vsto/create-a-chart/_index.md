---
title: चार्ट बनाएं
type: docs
weight: 60
url: /hi/net/create-a-chart/
---
नीचे दी गई कोड उदाहरण VSTO का उपयोग करके एक साधारण 3D क्लस्टर्ड कॉलम चार्ट जोड़ने की प्रक्रिया का वर्णन करती हैं। आप एक प्रेजेंटेशन उदाहरण बनाते हैं, उसमें एक डिफ़ॉल्ट चार्ट जोड़ते हैं। फिर चार्ट डेटा तक पहुँचने और उसे संशोधित करने के साथ साथ चार्ट गुण सेट करने के लिए Microsoft Excel वर्कबुक का उपयोग करते हैं। अंत में, प्रेजेंटेशन को सहेजते हैं।

## **VSTO**
VSTO का उपयोग करके, निम्नलिखित चरणों को किया जाता है:

1. Microsoft PowerPoint प्रस्तुति का एक उदाहरण बनाएँ।
1. प्रेजेंटेशन में एक खाली स्लाइड जोड़ें।
1. एक 3D क्लस्टर्ड कॉलम चार्ट जोड़ें और उसे एक्सेस करें।
1. एक नया Microsoft Excel Workbook उदाहरण बनाएँ और चार्ट डेटा लोड करें।
1. वर्कबुक से Microsoft Excel Workbook उदाहरण का उपयोग करके चार्ट डेटा कार्यपत्रक तक पहुँचें।
1. कार्यपत्रक में चार्ट रेंज सेट करें और चार्ट से सीरीज़ 2 और 3 हटाएँ।
1. चार्ट डेटा कार्यपत्रक में चार्ट श्रेणी डेटा संशोधित करें।
1. चार्ट डेटा कार्यपत्रक में चार्ट सीरीज़ 1 डेटा संशोधित करें।
1. अब, चार्ट शीर्षक तक पहुँचें और फ़ॉन्ट से संबंधित गुण सेट करें।
1. चार्ट वैल्यू एक्सिस तक पहुँचें और प्रमुख इकाई, छोटे इकाइयाँ, अधिकतम मान और न्यूनतम मान सेट करें।
1. चार्ट गहराई या सीरीज़ एक्सिस तक पहुँचें और इसे हटाएँ क्योंकि इस उदाहरण में केवल एक सीरीज़ उपयोग हुई है।
1. अब, X और Y दिशा में चार्ट रोटेशन एंगल सेट करें।
1. प्रेजेंटेशन सहेजें।
1. Microsoft Excel और PowerPoint के उदाहरण बंद करें।

``` csharp

 //वैश्विक चर

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//स्लाइड ऑब्जेक्ट बनाएं

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//प्रस्तुति की पहली स्लाइड तक पहुंचें

	objSlide = objPres.Slides[1];

	//पहली स्लाइड चुनें और उसका लेआउट सेट करें

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//स्लाइड में एक डिफ़ॉल्ट चार्ट जोड़ें

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//जोड़े गए चार्ट तक पहुंचें

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//चार्ट डेटा तक पहुंचें

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//चार्ट डेटा के साथ काम करने के लिए Excel वर्कबुक का उदाहरण बनाएं

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//चार्ट के लिए डेटा कार्यपत्रक तक पहुंचना

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//चार्ट की रेंज सेट करना

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//चार्ट डेटा तालिका पर सेट रेंज लागू करना

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//श्रेणियों और संबंधित श्रृंखला डेटा के लिए मान सेट करना

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//चार्ट शीर्षक सेट करना

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//चार्ट मान अक्ष तक पहुंचना

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//मान अक्ष इकाइयों को सेट करना

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//चार्ट गहराई अक्ष तक पहुंचना

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//चार्ट घूर्णन सेट करना

	ppChart.Rotation = 20; //Y-मान

	ppChart.Elevation = 15; //X-मान

	ppChart.RightAngleAxes = false;

	//प्रेजेंटेशन को PPTX के रूप में सहेजें

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//वर्कबुक और प्रेजेंटेशन बंद करें

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//Supplementary methods

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

	//नाम प्रॉपर्टी तक पहुंचने की कोशिश करें। यदि यह अपवाद उत्पन्न करता है तो

	//एक नया PowerPoint इंस्टेंस शुरू करें

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation का उपयोग यह सुनिश्चित करने के लिए किया जाता है कि एक प्रस्तुति लोड हो

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

	//BlnAddSlide का उपयोग यह सुनिश्चित करने के लिए किया जाता है कि कम से कम एक स्लाइड ...

	//प्रस्तुति

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
Aspose.Slides for .NET का उपयोग करके, निम्नलिखित चरणों को किया जाता है:

1. Microsoft PowerPoint प्रस्तुति का एक उदाहरण बनाएँ।
1. प्रेजेंटेशन में एक खाली स्लाइड जोड़ें।
1. एक 3D क्लस्टर्ड कॉलम चार्ट जोड़ें और उसे एक्सेस करें।
1. वर्कबुक से Microsoft Excel Workbook उदाहरण का उपयोग करके चार्ट डेटा कार्यपत्रक तक पहुँचें।
1. अनुपयोगी सीरीज़ 2 और 3 हटाएँ।
1. चार्ट श्रेणियों तक पहुँचें और लेबल संशोधित करें।
1. सीरीज़ 1 तक पहुँचें और सीरीज़ मान संशोधित करें।
1. अब, चार्ट शीर्षक तक पहुँचें और फ़ॉन्ट गुण सेट करें।
1. चार्ट वैल्यू एक्सिस तक पहुँचें और प्रमुख इकाई, छोटे इकाइयाँ, अधिकतम मान और न्यूनतम मान सेट करें।
1. अब, X और Y दिशा में चार्ट रोटेशन एंगल सेट करें।
1. प्रेजेंटेशन को PPTX प्रारूप में सहेजें।

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//खाली प्रस्तुति बनाएं

	using (PresentationEx pres = new PresentationEx())

	{

		//पहली स्लाइड तक पहुंचना

		SlideEx slide = pres.Slides[0];

		//डिफ़ॉल्ट चार्ट जोड़ना

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//चार्ट डेटा प्राप्त करना

		ChartDataEx chartData = ppChart.ChartData;

		//अतिरिक्त डिफ़ॉल्ट श्रृंखलाएँ हटाना

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//चार्ट श्रेणी नाम संशोधित करना

		chartData.Categories[0].ChartDataCell.Value = "Bikes";

		chartData.Categories[1].ChartDataCell.Value = "Accessories";

		chartData.Categories[2].ChartDataCell.Value = "Repairs";

		chartData.Categories[3].ChartDataCell.Value = "Clothing";

		//पहली श्रेणी के लिए चार्ट श्रृंखला मान संशोधित करना

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//चार्ट शीर्षक सेट करना

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 Sales";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//अक्ष मान सेट करना

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//चार्ट घूर्णन सेट करना

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//प्रस्तुति सहेजना

		pres.Write("AsposeSampleChart.pptx");

	}

```
 
## **Download Sample Code**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)