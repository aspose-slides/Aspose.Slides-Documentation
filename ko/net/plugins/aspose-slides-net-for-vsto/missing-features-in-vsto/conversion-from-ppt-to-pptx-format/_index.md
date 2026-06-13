---
title: PPT에서 PPTX 형식으로 변환
type: docs
weight: 20
url: /ko/net/conversion-from-ppt-to-pptx-format/
---
Aspose.Slides 고유 기능은 작업에 영향을 주지 않고 버전 변환의 유연성을 제공합니다.
SaveFormat은 아래 표에 표시된 확장자로 문서를 변환할 수 있는 열거형입니다.

|**멤버 이름**|**값**|**설명**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |
아래는 PPT를 PPTX로 변환하는 코드 스니펫이며, 반대로도 수행할 수 있습니다.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//PPTX 파일을 나타내는 Presentation 객체를 인스턴스화합니다

Presentation pres = new Presentation(srcFileName);

//PPTX 프레젠테이션을 PPTX 형식으로 저장합니다

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)