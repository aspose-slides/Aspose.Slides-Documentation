---
title: VSTO와 Aspose.Slides에서 애니메이션이 포함된 그림 프레임 추가
type: docs
weight: 20
url: /ko/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
아래 코드 샘플은 슬라이드가 포함된 프레젠테이션을 만들고, 그림 프레임이 있는 이미지를 추가한 뒤 애니메이션을 적용합니다.

## **VSTO**
VSTO를 사용하여 다음 단계를 수행합니다:

1. 프레젠테이션을 생성합니다.
1. 빈 슬라이드를 추가합니다.
1. 슬라이드에 그림 형태를 추가합니다.
1. 그림에 애니메이션을 적용합니다.
1. 프레젠테이션을 디스크에 저장합니다.

``` csharp

 //빈 프레젠테이션 생성

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//빈 슬라이드 추가

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//그림 프레임 추가

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//그림 프레임에 애니메이션 적용

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//프레젠테이션 저장

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
Aspose.Slides for .NET을 사용하여 다음 단계를 수행합니다:

1. 프레젠테이션을 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 그림 컬렉션에 이미지를 추가합니다.
1. 슬라이드에 그림 형태를 추가합니다.
1. 그림에 애니메이션을 적용합니다.
1. 프레젠테이션을 디스크에 저장합니다.

``` csharp

 //빈 프레젠테이션 생성

Presentation pres = new Presentation();

//첫 번째 슬라이드에 접근

Slide slide = pres.GetSlideByPosition(1);

//프레젠테이션의 그림 컬렉션에 그림 객체 추가

Picture pic = new Picture(pres, "pic.jpeg");

//그림 객체가 추가된 후, 그림에 고유한 그림 ID가 할당됩니다

int picId = pres.Pictures.Add(pic);

//그림 프레임 추가

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//그림 프레임에 애니메이션 적용

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//프레젠테이션 저장

pres.Write("AsposeAnim.ppt");

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)