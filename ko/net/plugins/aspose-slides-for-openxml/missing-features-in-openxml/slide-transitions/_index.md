---
title: 슬라이드 전환
type: docs
weight: 80
url: /ko/net/slide-transitions/
---
이해하기 쉽도록 Aspose.Slides for .NET을 사용하여 간단한 슬라이드 전환을 관리하는 방법을 시연했습니다. 개발자는 슬라이드에 다양한 전환 효과를 적용할 수 있을 뿐만 아니라 이러한 전환 효과의 동작을 맞춤 설정할 수도 있습니다. 간단한 슬라이드 전환 효과를 만들려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다
- Aspose.Slides for .NET에서 제공하는 전환 효과 중 하나를 **TransitionType** 열거형을 통해 슬라이드에 적용합니다
- 수정된 프레젠테이션 파일을 저장합니다.
## **예제**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다

using (Presentation pres = new Presentation(FileName))

{

    //슬라이드 1에 원형 전환 효과를 적용합니다

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //슬라이드 2에 콤 전환 효과를 적용합니다

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //슬라이드 3에 확대 전환 효과를 적용합니다

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //프레젠테이션을 디스크에 저장합니다

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **실행 예제 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
자세한 내용은 [슬라이드 전환 관리](/slides/ko/net/slide-transition/)를 확인하십시오.
{{% /alert %}}