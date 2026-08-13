---
title: Java에서 프레젠테이션에 머리글 및 바닥글 추가 방법
linktitle: 머리글 및 바닥글 추가
type: docs
weight: 20
url: /ko/java/how-to-add-header-footer-in-a-presentation/
keywords:
- 마이그레이션
- 머리글 추가
- 바닥글 추가
- 레거시 코드
- 최신 코드
- 레거시 접근 방식
- 최신 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Java에서 레거시 및 최신 Aspose.Slides API를 사용하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션에 머리글과 바닥글을 추가하는 방법을 알아보세요."
---
{{% alert color="info" %}} 

새로운 [Aspose.Slides for Java API](https://docs.aspose.com/slides/ko/java/)가 출시되었으며 이제 이 단일 제품은 처음부터 PowerPoint 문서를 생성하고 기존 문서를 편집하는 기능을 지원합니다.

{{% /alert %}} 
## **Legacy Code 지원**
Aspose.Slides for Java 13.x 이전 버전으로 개발된 레거시 코드를 사용하려면 코드에 약간의 변경을 적용하면 이전과 동일하게 동작합니다. 이전 Aspose.Slides for Java에서 Aspose.Slide 및 Aspose.Slides.Pptx 네임스페이스에 있던 모든 클래스가 이제 단일 Aspose.Slides 네임스페이스로 병합되었습니다. 레거시 Aspose.Slides API에서 프레젠테이션에 머리글·바닥글을 추가하는 아래 간단한 코드 스니펫을 살펴보고 새로 병합된 API로 마이그레이션하는 단계를 확인하십시오.
## **레거시 Aspose.Slides for Java 접근 방식**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **새 Aspose.Slides for Java 13.x 접근 방식**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}