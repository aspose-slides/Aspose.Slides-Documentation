---
title: 프레젠테이션 크기 및 레이아웃 작업
type: docs
weight: 90
url: /ko/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** 및 **SlideSize.Size**는 프레젠테이션 클래스의 속성으로, 아래 예시와 같이 설정하거나 가져올 수 있습니다.

## **예제**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//생성된 프레젠테이션의 슬라이드 크기를 원본과 동일하게 설정합니다

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//프레젠테이션을 디스크에 저장합니다

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 

## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)

## **실행 예제 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 

자세한 내용은 [.NET에서 프레젠테이션 슬라이드 크기 변경](/slides/ko/net/slide-size/)을(를) 참조하십시오.

{{% /alert %}}