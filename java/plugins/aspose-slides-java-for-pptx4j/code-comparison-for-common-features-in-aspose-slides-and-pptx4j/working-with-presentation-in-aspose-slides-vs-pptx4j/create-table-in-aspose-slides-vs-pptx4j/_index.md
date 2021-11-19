---
title: Create Table in Aspose.Slides vs pptx4j
type: docs
weight: 30
url: /java/create-table-in-aspose-slides-vs-pptx4j/
---

## **Aspose.Slides - Create Table**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Define Array of Columns with Width
- Define Array of Rows with Height
- Add a Table to the slide using addTable method exposed by IShapes object
- Iterate through each Cell to apply formatting to the Top, Bottom, Right, Left Borders
- Merge first two cells of the first row of the table
- Access the Text Frame of a Cell
- Add some text to the Text Frame
- Save the modified presentation

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents PPTX file

Presentation pres = new Presentation();

//Access first slide

ISlide sld = pres.getSlides().get_Item(0);

//Define columns with widths and rows with heights

double[] dblCols = { 50, 50, 50 };

double[] dblRows = { 50, 30, 30, 30, 30 };

//Add table shape to slide

ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

//Set border format for each cell

for(int row = 0; row < tbl.getRows().size(); row++)

{

    for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)

    {

		tbl.getRows().get_Item(row).get_Item(cell).getBorderTop().getFillFormat().setFillType(FillType.Solid);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderTop().setWidth(5);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderBottom().getFillFormat().setFillType(FillType.Solid);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderBottom().setWidth(5);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderLeft().getFillFormat().setFillType(FillType.Solid);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderLeft().setWidth(5);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderRight().getFillFormat().setFillType(FillType.Solid);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);

		tbl.getRows().get_Item(row).get_Item(cell).getBorderRight().setWidth(5);

    }

}

//Merge cells 1 & 2 of row 1

tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(0), false);

//Add text to the merged cell

tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

//Save PPTX to Disk

pres.save(dataDir + "Tables-Aspose.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **pptx4j - Create Table**
Below example shows 2 different methods of adding a table to presentation using pptx4j.

**Java**

{{< highlight java >}}

 public static void main(String[] args) throws Exception {

	// Where will we save our new .ppxt?

	String outputfilepath = dataDir + "Tables-Pptx4j.pptx";

	// Create skeletal package, including a MainPresentationPart and a SlideLayoutPart

	PresentationMLPackage presentationMLPackage = PresentationMLPackage.createPackage();

	// Need references to these parts to create a slide

	// Please note that these parts *already exist* - they are

	// created by createPackage() above.  See that method

	// for instruction on how to create and add a part.

	MainPresentationPart pp = (MainPresentationPart)presentationMLPackage.getParts().getParts().get(

			new PartName("/ppt/presentation.xml"));

	SlideLayoutPart layoutPart = (SlideLayoutPart)presentationMLPackage.getParts().getParts().get(

			new PartName("/ppt/slideLayouts/slideLayout1.xml"));

	// OK, now we can create a slide

	SlidePart slidePart = presentationMLPackage.createSlidePart(pp, layoutPart,

			new PartName("/ppt/slides/slide1.xml"));

	// Method 1 - programmatic

	slidePart.getJaxbElement().getCSld().getSpTree().getSpOrGrpSpOrGraphicFrame().add( getTable() );

	// Method 2 - from string - on slide 2

	SlidePart slide2 = presentationMLPackage.createSlidePart(pp, layoutPart,

			new PartName("/ppt/slides/slide2.xml"));

	slide2.getJaxbElement().getCSld().getSpTree().getSpOrGrpSpOrGraphicFrame().add( createGraphicFrameFromString() );

	// All done: save it

	presentationMLPackage.save(new java.io.File(outputfilepath));

	System.out.println("\n\n done .. saved " + outputfilepath);

}

public static CTGraphicalObjectFrame getTable() throws JAXBException {

	// instatiation the factory for later object creation.

	org.docx4j.dml.ObjectFactory dmlFactory = new org.docx4j.dml.ObjectFactory();

	org.pptx4j.pml.ObjectFactory pmlFactory = new org.pptx4j.pml.ObjectFactory();

	// Node Creation

	CTGraphicalObjectFrame graphicFrame = pmlFactory

			.createCTGraphicalObjectFrame();

	org.pptx4j.pml.CTGraphicalObjectFrameNonVisual nvGraphicFramePr = pmlFactory

			.createCTGraphicalObjectFrameNonVisual();

	org.docx4j.dml.CTNonVisualDrawingProps cNvPr = dmlFactory

			.createCTNonVisualDrawingProps();

	org.docx4j.dml.CTNonVisualGraphicFrameProperties cNvGraphicFramePr = dmlFactory

			.createCTNonVisualGraphicFrameProperties();

	org.docx4j.dml.CTGraphicalObjectFrameLocking graphicFrameLocks = new org.docx4j.dml.CTGraphicalObjectFrameLocking();

	org.docx4j.dml.CTTransform2D xfrm = dmlFactory.createCTTransform2D();

	Graphic graphic = dmlFactory.createGraphic();

	GraphicData graphicData = dmlFactory.createGraphicData();

	// Build the parent-child relationship of this slides.xml

	graphicFrame.setNvGraphicFramePr(nvGraphicFramePr);

	nvGraphicFramePr.setCNvPr(cNvPr);

	cNvPr.setName("1");

	nvGraphicFramePr.setCNvGraphicFramePr(cNvGraphicFramePr);

	cNvGraphicFramePr.setGraphicFrameLocks(graphicFrameLocks);

	graphicFrameLocks.setNoGrp(true);

	nvGraphicFramePr.setNvPr(pmlFactory.createNvPr());

//        <p:xfrm>

//        <a:off x="1524000" y="1397000"/>

//        <a:ext cx="6096000" cy="741680"/>

//      </p:xfrm>

	graphicFrame.setXfrm(xfrm);

	CTPositiveSize2D ext = dmlFactory.createCTPositiveSize2D();

	ext.setCx(6096000);

	ext.setCy(741680);

	xfrm.setExt(ext);

	CTPoint2D off = dmlFactory.createCTPoint2D();

	xfrm.setOff(off);

	off.setX(1524000);

	off.setY(1397000);

	graphicFrame.setGraphic(graphic);

	graphic.setGraphicData(graphicData);

	graphicData

			.setUri("http://schemas.openxmlformats.org/drawingml/2006/table");

	CTTable ctTable = dmlFactory.createCTTable();

	JAXBElement<CTTable> tbl = dmlFactory.createTbl(ctTable);

	graphicData.getAny().add(tbl);

	CTTableGrid ctTableGrid = dmlFactory.createCTTableGrid();

	CTTableCol gridCol = dmlFactory.createCTTableCol();

	ctTable.setTblGrid(ctTableGrid);

	ctTableGrid.getGridCol().add(gridCol);

	ctTableGrid.getGridCol().add(gridCol);

	gridCol.setW(300000);

	CTTableRow ctTableRow = dmlFactory.createCTTableRow();

	ctTableRow.setH(370840);


	ctTableRow.getTc().add(createTableCell());

	ctTableRow.getTc().add(createTableCell());

	for (int i = 0; i < 4; i++) {

		ctTable.getTr().add(ctTableRow);

	}

	return graphicFrame;

}

public static CTTableCell createTableCell() throws JAXBException {

   String contents =

	"<a:tc  xmlns:a=\"http://schemas.openxmlformats.org/drawingml/2006/main\">" +

	"<a:txBody>"

        +"<a:bodyPr/>"

        +"<a:lstStyle/>"

        +"<a:p>"

          +"<a:r>"

            +"<a:rPr lang=\"en-AU\" dirty=\"0\" smtClean=\"0\"/>"

            +"<a:t>11</a:t>"

          +"</a:r>"

          +"<a:endParaRPr lang=\"en-AU\" dirty=\"0\"/>"

          +"</a:p>"

      +"</a:txBody>" +

      "</a:tc>";

      //+"<a:tcPr/>

   return ((CTTableCell)XmlUtils.unmarshalString(contents,org.docx4j.jaxb.Context.jc, CTTableCell.class));

}

public static CTGraphicalObjectFrame createGraphicFrameFromString() throws JAXBException {

        String tableau =

        	     "<p:graphicFrame xmlns:a=\"http://schemas.openxmlformats.org/drawingml/2006/main\" xmlns:p=\"http://schemas.openxmlformats.org/presentationml/2006/main\">" +

        	     "        <p:nvGraphicFramePr>" +

        	     "          <p:cNvPr id=\"4\" name=\"Table 3\"/>" +

        	     "          <p:cNvGraphicFramePr>" +

        	     "            <a:graphicFrameLocks noGrp=\"1\"/>" +

        	     "          </p:cNvGraphicFramePr>" +

        	     "          <p:nvPr/>" +

        	     "        </p:nvGraphicFramePr>" +

        	     "        <p:xfrm>" +

        	     "          <a:off x=\"1524000\" y=\"1397000\"/>" +

        	     "          <a:ext cx=\"6096000\" cy=\"741680\"/>" +

        	     "        </p:xfrm>" +

        	     "        <a:graphic>" +

        	     "          <a:graphicData uri=\"http://schemas.openxmlformats.org/drawingml/2006/table\">" +

        	     "            <a:tbl>" +

        	     "              <a:tblPr firstRow=\"1\" bandRow=\"1\">" +

        	     "                <a:tableStyleId>{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}</a:tableStyleId>" +

        	     "              </a:tblPr>" +

        	     "              <a:tblGrid>" +

        	     "                <a:gridCol w=\"3048000\"/>" +

        	     "                <a:gridCol w=\"3048000\"/>" +

        	     "              </a:tblGrid>" +

        	     "              <a:tr h=\"370840\">" +

        	     "                <a:tc>" +

        	     "                  <a:txBody>" +

        	     "                    <a:bodyPr/>" +

        	     "                    <a:lstStyle/>" +

        	     "                    <a:p>" +

        	     "                      <a:r>" +

        	     "                        <a:rPr lang=\"en-AU\" dirty=\"0\" smtClean=\"0\"/>" +

        	     "                        <a:t>11</a:t>" +

        	     "                      </a:r>" +

        	     "                      <a:endParaRPr lang=\"en-AU\" dirty=\"0\"/>" +

        	     "                    </a:p>" +

        	     "                  </a:txBody>" +

        	     "                  <a:tcPr/>" +

        	     "                </a:tc>" +

        	     "                <a:tc>" +

        	     "                  <a:txBody>" +

        	     "                    <a:bodyPr/>" +

        	     "                    <a:lstStyle/>" +

        	     "                    <a:p>" +

        	     "                      <a:r>" +

        	     "                        <a:rPr lang=\"en-AU\" dirty=\"0\" smtClean=\"0\"/>" +

        	     "                        <a:t>12</a:t>" +

        	     "                      </a:r>" +

        	     "                      <a:endParaRPr lang=\"en-AU\" dirty=\"0\"/>" +

        	     "                    </a:p>" +

        	     "                  </a:txBody>" +

        	     "                  <a:tcPr/>" +

        	     "                </a:tc>" +

        	     "              </a:tr>" +

        	     "              <a:tr h=\"370840\">" +

        	     "                <a:tc>" +

        	     "                  <a:txBody>" +

        	     "                    <a:bodyPr/>" +

        	     "                    <a:lstStyle/>" +

        	     "                    <a:p>" +

        	     "                      <a:r>" +

        	     "                        <a:rPr lang=\"en-AU\" dirty=\"0\" smtClean=\"0\"/>" +

        	     "                        <a:t>21</a:t>" +

        	     "                      </a:r>" +

        	     "                      <a:endParaRPr lang=\"en-AU\" dirty=\"0\"/>" +

        	     "                    </a:p>" +

        	     "                  </a:txBody>" +

        	     "                  <a:tcPr/>" +

        	     "                </a:tc>" +

        	     "                <a:tc>" +

        	     "                  <a:txBody>" +

        	     "                    <a:bodyPr/>" +

        	     "                    <a:lstStyle/>" +

        	     "                    <a:p>" +

        	     "                      <a:r>" +

        	     "                        <a:rPr lang=\"en-AU\" dirty=\"0\" smtClean=\"0\"/>" +

        	     "                        <a:t>22</a:t>" +

        	     "                      </a:r>" +

        	     "                      <a:endParaRPr lang=\"en-AU\" dirty=\"0\"/>" +

        	     "                    </a:p>" +

        	     "                  </a:txBody>" +

        	     "                  <a:tcPr/>" +

        	     "                </a:tc>" +

        	     "              </a:tr>" +

        	     "            </a:tbl>" +

        	     "          </a:graphicData>" +

        	     "        </a:graphic>" +

        	     "      </p:graphicFrame>";


        return (CTGraphicalObjectFrame) XmlUtils.unmarshalString(tableau, Context.jcPML,

        		CTGraphicalObjectFrame.class);

}

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Creating a Table from Scratch in Slide](/slides/java/manage-table/).

{{% /alert %}}
