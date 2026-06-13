---
title: VSTO 및 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 표 만들기
type: docs
weight: 90
url: /ko/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
다음 단계는 VSTO를 사용하여 Microsoft PowerPoint 슬라이드에 표를 추가합니다:

- 프레젠테이션을 만들립니다.
- 프레젠테이션에 빈 슬라이드를 추가합니다.
- 슬라이드에 15 x 15 표를 추가합니다.
- 표의 각 셀에 글꼴 크기 10인 텍스트를 추가합니다.
- 프레젠테이션을 디스크에 저장합니다.
## **VSTO**
``` csharp

 //프레젠테이션 생성
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//빈 슬라이드 추가
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//15 x 15 표 추가
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//모든 행을 순회합니다
foreach (PowerPoint.Row row in tbl.Rows)
{
	i = i + 1;
	j = -1;
	//행의 모든 셀을 순회합니다
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
pres.SaveAs("tblVSTO.ppt",
	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	  Microsoft.Office.Core.MsoTriState.msoFalse);
``` 

다음 단계는 Aspose.Slides를 사용하여 Microsoft PowerPoint 슬라이드에 표를 추가합니다:

- 프레젠테이션을 만들립니다.
- 첫 번째 슬라이드에 15 x 15 표를 추가합니다.
- 표의 각 셀에 글꼴 크기 10인 텍스트를 추가합니다.
- 프레젠테이션을 디스크에 씁니다.
## **Aspose.Slides**
``` csharp

 //프레젠테이션 생성
Presentation pres = new Presentation();
//첫 번째 슬라이드에 접근
Slide sld = pres.GetSlideByPosition(1);
//표 추가
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);
//행을 순회
for (int i = 0; i < tbl.RowsNumber; i++)
	//셀을 순회
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//각 셀의 텍스트 프레임 가져오기
		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//텍스트 추가
		tf.Text = "T" + i.ToString() + j.ToString();
		//글꼴 크기를 10으로 설정
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}
//프레젠테이션을 디스크에 저장
pres.Write("tblSLD.ppt");
``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)