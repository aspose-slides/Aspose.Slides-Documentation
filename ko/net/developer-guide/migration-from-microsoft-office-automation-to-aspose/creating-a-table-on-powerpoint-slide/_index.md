---
title: VSTO 및 Aspose.Slides for .NET을 사용한 테이블 만들기
linktitle: 테이블 만들기
type: docs
weight: 50
url: /ko/net/creating-a-table-on-powerpoint-slide/
keywords:
- 테이블 만들기
- 마이그레이션
- VSTO
- Office 자동화
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office 자동화를 Aspose.Slides for .NET으로 마이그레이션하고 C#에서 유연한 서식으로 PowerPoint(PPT, PPTX) 슬라이드에 테이블을 생성합니다."
---
{{% alert color="info" %}} 
표는 프레젠테이션 슬라이드에서 데이터를 표시하는 데 널리 사용됩니다. 이 문서에서는 먼저 [VSTO 2008](/slides/ko/net/creating-a-table-on-powerpoint-slide/)를, 그 다음 [Aspose.Slides for .NET](/slides/ko/net/creating-a-table-on-powerpoint-slide/)를 사용하여 글꼴 크기 10인 15 × 15 표를 프로그래밍 방식으로 만드는 방법을 보여줍니다.
{{% /alert %}} 
## **표 만들기**
#### **VSTO 2008 예제**
The following steps add a table to a Microsoft PowerPoint slide using VSTO:

1. 프레젠테이션을 생성합니다.
1. 빈 슬라이드를 프레젠테이션에 추가합니다.
1. 슬라이드에 15 × 15 표를 추가합니다.
1. 표의 각 셀에 글꼴 크기 10으로 텍스트를 추가합니다.
1. 프레젠테이션을 디스크에 저장합니다.

```c#
//프레젠테이션 생성
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//빈 슬라이드 추가
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add a 15 x 15 table
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//모든 행을 순회
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //행의 모든 셀을 순회
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //각 셀의 텍스트 프레임 가져오기
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //텍스트 추가
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //텍스트의 글꼴 크기를 10으로 설정
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//프레젠테이션을 디스크에 저장
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET 예제**
The following steps add a table to a Microsoft PowerPoint slide using Aspose.Slides:

1. 프레젠테이션을 생성합니다.
1. 첫 번째 슬라이드에 15 × 15 표를 추가합니다.
1. 표의 각 셀에 글꼴 크기 10으로 텍스트를 추가합니다.
1. 프레젠테이션을 디스크에 기록합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

//첫 번째 슬라이드에 접근
ISlide sld = pres.Slides[0];

//열 너비와 행 높이를 정의
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//테이블 추가
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//각 셀에 대한 테두리 형식 설정
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//각 셀의 텍스트 프레임 가져오기
		ITextFrame tf = cell.TextFrame;
		//텍스트 추가
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//글꼴 크기를 10으로 설정
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//프레젠테이션을 디스크에 저장
pres.Save("tblSLD.ppt", SaveFormat.Ppt);
```