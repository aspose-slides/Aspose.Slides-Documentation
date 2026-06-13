---
title: 프레젠테이션 파일 형식 가져오기
type: docs
weight: 50
url: /ko/net/get-the-file-format-of-presentation/
---
파일 형식을 가져오려면 아래 단계를 따라 주세요:

- **IPresentationInfo** 클래스의 인스턴스 생성
- 프레젠테이션에 대한 정보 가져오기

아래 예제에서 파일 형식을 확인할 수 있습니다.
## **예제**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **실행 예제 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)