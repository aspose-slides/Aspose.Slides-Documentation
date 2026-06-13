---
title: VSTO 및 Aspose.Slides for .NET을 사용한 애니메이션 그림 프레임 추가
linktitle: 애니메이션 그림 프레임
type: docs
weight: 60
url: /ko/net/adding-picture-frame-with-animation/
keywords:
- 그림 프레임
- 이미지 추가
- 그림 추가
- 애니메이션이 있는 이미지
- 애니메이션이 있는 그림
- 마이그레이션
- VSTO
- Office 자동화
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office 자동화에서 Aspose.Slides for .NET으로 마이그레이션하고, 깔끔한 C# 코드를 사용하여 PowerPoint (PPT, PPTX) 슬라이드에서 그림 프레임에 애니메이션을 적용합니다."
---
{{% alert color="primary" %}} 
그림 프레임은 Microsoft PowerPoint에서 도형이나 이미지에 적용되어 프레젠테이션의 이미지를 테두리로 감쌉니다. 이 문서에서는 먼저 [VSTO 2008](/slides/ko/net/adding-picture-frame-with-animation/)와 그 다음 [Aspose.Slides for .NET](/slides/ko/net/adding-picture-frame-with-animation/)을 사용하여 프로그래밍 방식으로 그림 프레임을 만들고 애니메이션을 적용하는 방법을 보여줍니다. 먼저 VSTO 2008을 사용하여 프레임과 애니메이션을 적용하는 방법을 보여드리고, 이어서 Aspose.Slides for .NET을 사용하여 동일한 단계를 수행하는 방법을 보여드립니다.
{{% /alert %}} 
## **그림 프레임에 애니메이션 추가**
아래 코드 샘플은 슬라이드가 포함된 프레젠테이션을 만들고, 그림 프레임이 적용된 이미지를 추가한 다음 해당 이미지에 애니메이션을 적용합니다.
### **VSTO 2008 예제**
VSTO 2008을 사용하여 다음 단계를 수행합니다:
1. 프레젠테이션을 생성합니다.
1. 빈 슬라이드를 추가합니다.
1. 슬라이드에 그림 도형을 추가합니다.
1. 그림에 애니메이션을 적용합니다.
1. 프레젠테이션을 디스크에 저장합니다.
**VSTO로 생성된 출력 프레젠테이션** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//빈 프레젠테이션 생성
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//빈 슬라이드 추가
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//그림 프레임 추가
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//그림 프레임에 애니메이션 적용
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//프레젠테이션 저장
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET 예제**
Aspose.Slides for .NET을 사용하여 다음 단계를 수행합니다:
1. 프레젠테이션을 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 그림 컬렉션에 이미지를 추가합니다.
1. 슬라이드에 그림 도형을 추가합니다.
1. 그림에 애니메이션을 적용합니다.
1. 프레젠테이션을 디스크에 저장합니다.
**Aspose.Slides로 생성된 출력 프레젠테이션** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
 // 빈 프레젠테이션 생성
 using (Presentation pres = new Presentation())
 {
     // 첫 번째 슬라이드에 접근
     ISlide slide = pres.Slides[0];

     // 프레젠테이션의 이미지 컬렉션에 이미지 추가
     IImage image = Images.FromFile("aspose.jpg");
     IPPImage ppImage = pres.Images.AddImage(image);
     image.Dispose();

     // 이미지의 높이와 너비와 일치하는 그림 프레임 추가
     IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

     // 슬라이드의 메인 애니메이션 시퀀스 가져오기
     ISequence sequence = pres.Slides[0].Timeline.MainSequence;

     // 그림 프레임에 왼쪽에서 날아오는 애니메이션 효과 추가
     IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

     // 프레젠테이션 저장
     pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
 }
```