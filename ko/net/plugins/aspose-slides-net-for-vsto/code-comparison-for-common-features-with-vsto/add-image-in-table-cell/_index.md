---
title: 표 셀에 이미지 추가
type: docs
weight: 10
url: /ko/net/add-image-in-table-cell/
---
## **VSTO**
아래는 표 셀에 이미지를 추가하는 코드입니다:

``` csharp

    //표를 포함하는 Presentation 클래스를 엽니다
   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //첫 번째 슬라이드를 가져옵니다
   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Aspose.Slides for .NET는 표를 가장 쉽게 만들 수 있는 가장 간단한 API를 제공합니다. 새 표를 만들면서 표 셀에 이미지를 추가하려면 아래 단계를 따라 주세요:

- Presentation 클래스의 인스턴스를 생성합니다
- 인덱스를 사용하여 슬라이드 참조를 가져옵니다
- 열의 너비를 지정한 배열을 정의합니다
- 행의 높이를 지정한 배열을 정의합니다
- IShapes 객체가 제공하는 AddTable 메서드를 사용하여 슬라이드에 표를 추가합니다
- 이미지 파일을 보관할 Bitmap 객체를 생성합니다
- Bitmap 이미지를 IPPImage 객체에 추가합니다
- 표 셀의 채우기 형식을 그림으로 설정합니다
- 이미지를 표의 첫 번째 셀에 추가합니다
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //첫 번째 슬라이드 가져오기

  ISlide sld = MyPresentation.Slides[0];

  //이미지 파일을 보관할 Bitmap 이미지 객체 생성

  using IImage image = Images.FromFile(ImageFile);

  //Bitmap 객체를 사용하여 IPPImage 객체 생성

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //첫 번째 테이블 셀에 이미지 추가

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //PPTX를 디스크에 저장

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)