---
title: VSTO 및 Aspose.Slides에서 표의 행 또는 열 제거
type: docs
weight: 130
url: /ko/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
아래는 VSTO Presentation을 사용하여 표에서 행 또는 열을 제거하는 코드입니다:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //첫 번째 슬라이드를 가져옵니다

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides for .NET는 가장 쉬운 방법으로 표를 생성할 수 있는 가장 간단한 API를 제공합니다. 슬라이드에 표를 만들고 표에 대한 기본 작업을 수행하려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- 너비를 지정한 열 배열을 정의합니다.
- 높이를 지정한 행 배열을 정의합니다.
- IShapes 개체가 제공하는 AddTable 메서드를 사용하여 슬라이드에 표를 추가합니다.
- 표 행을 제거합니다.
- 표 열을 제거합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //첫 번째 슬라이드 가져오기

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)