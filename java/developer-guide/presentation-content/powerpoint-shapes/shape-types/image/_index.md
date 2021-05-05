---
title: Image
type: docs
weight: 10
url: /java/image/
---

## **Add EMZ Image to Images collection**

Aspose.Slides for Java provides a facility to embed EMZ file inside a presentation images collection. An example is given below that shows how to add EMZ image to images collection.

```java
// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream imageFile = new FileInputStream("image.emz");

    IPPImage image = pres.getImages().addImage(imageFile);
        
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
            (float) pres.getSlideSize().getSize().getWidth(), (float) pres.getSlideSize().getSize().getHeight(), image);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create an Image From SVG Object**

Aspose.Slides for Java added new [**addImage**](https://apireference.aspose.com/slides/java/com.aspose.slides/IImageCollection#addImage-com.aspose.slides.ISvgImage-) method to [**IImageCollection**](https://apireference.aspose.com/slides/java/com.aspose.slides/IImageCollection) interface and [**ImageCollection**](https://apireference.aspose.com/slides/java/com.aspose.slides/ImageCollection) class. These methods provide the ability to insert SVG fragments to the presentation image collection.

The code sample below shows how to insert SVG fragments to the presentation image collection.

```java
// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

The following code shows how to insert SVG fragments to the presentation image collection from an external resource.

```java
// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get(dataDir + "/image1.svg")));
    ISvgImage svgImage = new SvgImage(svgContent, new ExternalResourceResolver(), dataDir);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert SVG Images Into Group Shape**

Method [**addGroupShape**](https://apireference.aspose.com/java/slides/com.aspose.slides/IShapeCollection#addGroupShape--) has been added to [**IShapeCollection**](https://apireference.aspose.com/java/slides/com.aspose.slides/IShapeCollection) interface and [**ShapeCollection**](https://apireference.aspose.com/java/slides/com.aspose.slides/ShapeCollection) class in Aspose.Slides for Java. This method allows to convert [**SvgImage**](https://apireference.aspose.com/java/slides/com.aspose.slides/SvgImage) object that represents [SVG](https://wiki.fileformat.com/page-description-language/svg/) data into a group of shapes.

The code sample below shows how to convert SVG images into a group of shapes.

```java
// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation("image.pptx");
try {
    PictureFrame pFrame = (PictureFrame) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ISvgImage svgImage = pFrame.getPictureFormat().getPicture().getImage().getSvgImage();
    if (svgImage != null)
    {
        // Convert svg image into group of shapes
        IGroupShape groupShape = pres.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 
                pFrame.getFrame().getX(), pFrame.getFrame().getY(),
                pFrame.getFrame().getWidth(), pFrame.getFrame().getHeight());

        // remove source svg image from presentation
        pres.getSlides().get_Item(0).getShapes().remove(pFrame);
    }
    pres.save("image_group.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Images as EMF in Slides**

Aspose.Slides for Java provides a facility that generates EMF image of excel sheet and add the image as EMF in slides with the help of Aspose.Cells. The sample code is implemented in the example given below.

```java
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Save the workbook to stream
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);
    
        byte[] bytes = Files.readAllBytes(Paths.get(EmfSheetName));
        IPPImage emfImage = pres.getImages().addImage(bytes);
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, (float) pres.getSlideSize().getSize().getWidth(), (float) pres.getSlideSize().getSize().getHeight(), emfImage);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```