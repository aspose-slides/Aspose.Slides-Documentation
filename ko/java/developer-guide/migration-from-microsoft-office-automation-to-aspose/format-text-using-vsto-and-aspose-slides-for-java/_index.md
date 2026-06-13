---
title: VSTO 및 Aspose.Slides for Java를 사용한 텍스트 서식 지정
linktitle: 텍스트 서식 지정
type: docs
weight: 30
url: /ko/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- 텍스트 서식 지정
- 마이그레이션
- VSTO
- Office 자동화
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Microsoft Office 자동화에서 Aspose.Slides for Java로 마이그레이션하고, PowerPoint(PPT, PPTX) 프레젠테이션에서 텍스트를 정확하게 제어하며 서식 지정합니다."
---
{{% alert color="primary" %}} 

때때로 슬라이드의 텍스트를 프로그래밍 방식으로 서식 지정해야 할 때가 있습니다. 이 문서에서는 첫 번째 슬라이드에 일부 텍스트가 있는 샘플 프레젠테이션을 [VSTO](/slides/ko/java/format-text-using-vsto-and-aspose-slides-for-java/) 또는 [Aspose.Slides for Java](/slides/ko/java/format-text-using-vsto-and-aspose-slides-for-java/)를 사용하여 읽는 방법을 보여줍니다. 코드는 슬라이드의 세 번째 텍스트 상자에 있는 텍스트를 마지막 텍스트 상자의 텍스트와 같이 보이도록 서식 지정합니다.

{{% /alert %}} 
## **Formatting Text**
VSTO와 Aspose.Slides 메서드는 다음 단계들을 수행합니다:

1. 소스 프레젠테이션을 엽니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 세 번째 텍스트 상자에 접근합니다.
1. 세 번째 텍스트 상자 내 텍스트의 서식을 변경합니다.
1. 프레젠테이션을 디스크에 저장합니다.

아래 스크린샷은 VSTO와 Aspose.Slides for Java 코드 실행 전후의 샘플 슬라이드를 보여줍니다.

**입력 프레젠테이션** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO 코드 예제**
아래 코드는 VSTO를 사용하여 슬라이드의 텍스트를 다시 서식 지정하는 방법을 보여줍니다.

**VSTO로 다시 서식 지정된 텍스트** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Java 예제**
Aspose.Slides를 사용하여 텍스트를 서식 지정하려면, 텍스트를 서식 지정하기 전에 글꼴을 추가합니다.

**Aspose.Slides로 만든 출력 프레젠테이션** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}