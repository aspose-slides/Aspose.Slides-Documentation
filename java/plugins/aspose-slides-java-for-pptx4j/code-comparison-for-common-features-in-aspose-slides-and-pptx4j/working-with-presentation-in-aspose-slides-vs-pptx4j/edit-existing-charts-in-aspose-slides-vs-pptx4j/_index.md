---
title: Edit Existing Charts in Aspose.Slides vs pptx4j
type: docs
weight: 40
url: /java/edit-existing-charts-in-aspose-slides-vs-pptx4j/
---

## **Aspose.Slides - Edit Existing Charts**
Aspose.Slides for Java also facilitates developers to update PowerPoint charts generated through Aspose.Slides or PowerPoint.

Aspose.Slides for Java has provided the simplest API to update charts in an easiest way. To update a chart in a slide:

- Open an instance of Presentation class containing chart
- Obtain the reference of a slide by using its Index
- Traverse through all shapes to find desired chart
- Access the chart data worksheet
- Modify the chart data series data by changing series values
- Adding a new series and populating data inside it
- Write the modified presentation as a PPTX file

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents PPTX file

Presentation pres = new Presentation(dataDir + "AsposeChart.pptx");

//Access first slide

ISlide sld = pres.getSlides().get_Item(0);

// Add chart with default data

IChart chart = (IChart)sld.getShapes().get_Item(0);

//Setting the index of chart data sheet

int defaultWorksheetIndex = 0;

//Getting the chart data worksheet

IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

//Changing chart Category Name

fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");

fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");


//Take first chart series

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

//Now updating series data

fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");//modifying series name

series.getDataPoints().get_Item(0).getValue().setData (90);

series.getDataPoints().get_Item(1).getValue().setData ( 123);

series.getDataPoints().get_Item(2).getValue().setData ( 44);

//Take Second chart series

series = chart.getChartData().getSeries().get_Item(1);

//Now updating series data

fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");//modifying series name

series.getDataPoints().get_Item(0).getValue().setData (23);

series.getDataPoints().get_Item(1).getValue().setData ( 67);

series.getDataPoints().get_Item(2).getValue().setData ( 99);


//Now, Adding a new series

chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

//Take 3rd chart series

series = chart.getChartData().getSeries().get_Item(2);

//Now populating series data

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

chart.setType(ChartType.ClusteredCylinder);

// Save presentation with chart

pres.save(dataDir + "ChartModified-Aspose.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **pptx4j - Edit Existing Charts**
It possible to edit the existing charts in presentation. Below is the method to edit charts using pptx4j.

**Java**

{{< highlight java >}}

 // Input file

String inputfilepath = dataDir + "pptx-chart.pptx";

// The names of the parts which will be edited

// Alter these to match what is in your input pptx

// .. the chart

String chartPartName = "/ppt/charts/chart1.xml";

// .. the xlsx

String xlsPartName = "/ppt/embeddings/Microsoft_Excel_Sheet1.xlsx";

// Output file

String outputfilepath = dataDir + "ChartModified-Pptx4j.pptx";

// Values to change

Random rand = new Random();

String firstValue  = String.valueOf(rand.nextInt(99));

String secondValue = String.valueOf(rand.nextInt(99));

// Open the PPT template file

PresentationMLPackage ppt = (PresentationMLPackage) OpcPackage

	.load(new java.io.File(inputfilepath));

/*

 * Get the Chart object and update the values. Afterwards, we'll update

 * the associated spreadsheet so that the data is synchronized.

 */

Chart chart = (Chart) ppt.getParts().get(new PartName(chartPartName));

List<Object> objects = chart.getJaxbElement().getChart().getPlotArea()

		.getAreaChartOrArea3DChartOrLineChart();

for (Object object : objects) {

	if (object instanceof CTBarChart) {

		List<CTBarSer> ctBarSers = ((CTBarChart) object).getSer();

		for (CTBarSer ctBarSer : ctBarSers)

		{

			List<CTNumVal> ctNumVals = ctBarSer.getVal().getNumRef().getNumCache().getPt();

			for (CTNumVal ctNumVal : ctNumVals)

			{

				System.out.println("ctNumVal Val BEFORE: " + ctNumVal.getV());

				if (ctNumVal.getIdx() == 0) {

					ctNumVal.setV(firstValue);

				}

				else if (ctNumVal.getIdx() == 1) {

					ctNumVal.setV(secondValue);

				}

				System.out.println("ctNumVal Val AFTER: " + ctNumVal.getV());

			}

		}

	}

}

/*

 * Get the spreadsheet and find the cell values that need to be updated

 */

EmbeddedPackagePart epp  = (EmbeddedPackagePart) ppt

	.getParts().get(new PartName(xlsPartName));

if (epp==null) {

	throw new Docx4JException("Could find EmbeddedPackagePart: " + xlsPartName);

}

InputStream is = BufferUtil.newInputStream(epp.getBuffer());

SpreadsheetMLPackage spreadSheet = (SpreadsheetMLPackage) SpreadsheetMLPackage.load(is);

Map<PartName,Part> partsMap = spreadSheet.getParts().getParts();

Iterator<Entry<PartName, Part>> it = partsMap.entrySet().iterator();

while(it.hasNext()) {

	Map.Entry<PartName, Part> pairs = it.next();

	if (partsMap.get(pairs.getKey()) instanceof WorksheetPart) {

		WorksheetPart wsp = (WorksheetPart) partsMap.get(pairs.getKey()) ;

		List<Row> rows = wsp.getJaxbElement().getSheetData().getRow();

		for (Row row : rows) {

			List<Cell> cells = row.getC();

			for (Cell cell : cells)

			{

				if (cell.getR().equals("B2") && cell.getV() != null) {

					System.out.println("B2 CELL VAL: " + cell.getV());

					// change the B2 cell value

					cell.setT(STCellType.STR);

					cell.setV(firstValue);

				}

				else if (cell.getR().equals("B3") && cell.getV() != null) {

					System.out.println("B3 CELL VAL: " + cell.getV());

					// Change the B3 cell value

					cell.setT(STCellType.STR);

					cell.setV(secondValue);

				}

			}

		}

	}

}

/*

 * Convert the Spreadsheet to a binary format, set it on the

 * EmbeddedPackagePart, add it back onto the deck and save to a file.

 *

 */

ByteArrayOutputStream baos = new ByteArrayOutputStream();

SaveToZipFile saver = new SaveToZipFile(spreadSheet);

saver.save(baos);

epp.setBinaryData(baos.toByteArray());

// Write the new file to disks

ppt.save(new java.io.File(outputfilepath));

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://archive.codeplex.com/?p=asposeslidesjavapptx4j)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://archive.codeplex.com/?p=asposeslidesjavapptx4j)

{{% alert color="primary" %}} 

For more details, visit [Updating an Existing Chart ](http://docs.aspose.com:8082/docs/display/slidesjava/Updating+an+Existing+Chart).

{{% /alert %}}
