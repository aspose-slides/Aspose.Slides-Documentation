---
title: Android에서 ODP를 PPTX로 변환
linktitle: ODP를 PPTX로
type: docs
weight: 10
url: /ko/androidjava/convert-odp-to-pptx/
keywords:
- OpenDocument 변환
- 프레젠테이션 변환
- 슬라이드 변환
- ODP 변환
- OpenDocument를 PPTX로
- ODP를 PPTX로
- ODP를 PPTX로 저장
- ODP를 PPTX로 내보내기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 ODP를 PPTX로 변환합니다. 깔끔한 Java 코드 예제, 배치 팁, 고품질 결과—PowerPoint가 필요 없습니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 ODP 프레젠테이션을 PPTX 형식으로 변환하는 방법을 설명합니다.

## **ODP를 PPTX/PPT 프레젠테이션으로 변환**
Aspose.Slides for Android via Java은 프레젠테이션 파일을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스를 제공합니다. 이제 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스는 객체를 인스턴스화할 때 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) 생성자를 통해 ODP에 접근할 수 있습니다. 다음 예제는 ODP 프레젠테이션을 PPTX 프레젠테이션으로 변환하는 방법을 보여줍니다.

```java
// ODP 파일 열기
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// ODP 프레젠테이션을 PPTX 형식으로 저장
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **실시간 예제**
Aspose.Slides API로 구축된 [**Aspose.Slides 변환**](https://products.aspose.app/slides/ko/conversion/) 웹 앱을 방문할 수 있습니다. 이 앱은 Aspose.Slides API를 사용해 ODP를 PPTX로 변환하는 방법을 보여줍니다.

## **FAQ**

**ODP를 PPTX로 변환하려면 Microsoft PowerPoint 또는 LibreOffice를 설치해야 합니까?**

아니요. Aspose.Slides는 독립형으로 작동하며 ODP/PPTX를 읽거나 쓰기 위해 서드파티 애플리케이션이 필요하지 않습니다.

**변환 중에 마스터 슬라이드, 레이아웃 및 테마가 유지됩니까?**

예. 이 라이브러리는 전체 프레젠테이션 객체 모델을 사용하며 마스터 슬라이드와 레이아웃을 포함한 구조를 유지하므로 변환 후에도 디자인이 올바르게 유지됩니다.

**암호로 보호된 ODP 파일을 변환할 수 있나요?**

예. Aspose.Slides는 보호 여부를 감지하고, 비밀번호를 제공하면 [보호된 프레젠테이션](/slides/ko/androidjava/password-protected-presentation/) (ODP 포함)를 열어 작업할 수 있으며, 암호화 및 문서 속성 접근도 구성할 수 있습니다.

**Aspose.Slides는 클라우드 또는 REST 기반 변환 서비스에 적합합니까?**

예. 로컬 라이브러리를 자체 백엔드에서 사용하거나 [Aspose.Slides Cloud](https://products.aspose.cloud/slides/ko/family/) (REST API)를 사용할 수 있으며, 두 옵션 모두 ODP → PPTX 변환을 지원합니다.