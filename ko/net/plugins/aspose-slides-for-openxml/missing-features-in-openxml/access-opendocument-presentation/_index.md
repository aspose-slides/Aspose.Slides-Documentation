---
title: OpenDocument 프레젠테이션에 액세스
type: docs
weight: 10
url: /ko/net/access-opendocument-presentation/
---
Aspose.Slides for .NET는 프레젠테이션 파일을 나타내는 **Presentation** 클래스를 제공합니다. **Presentation** 클래스는 이제 객체가 인스턴스화될 때 **Presentation** 생성자를 통해 **ODP**에 액세스할 수 있습니다.
## **예제**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다

using (Presentation pres = new Presentation(srcFileName))

{

    //PPTX 프레젠테이션을 PPTX 형식으로 저장합니다

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **실행 예제 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)