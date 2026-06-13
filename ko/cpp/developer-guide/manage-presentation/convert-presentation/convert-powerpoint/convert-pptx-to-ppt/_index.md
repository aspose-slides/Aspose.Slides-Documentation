---
title: C++에서 PPTX를 PPT로 변환
linktitle: PPTX를 PPT로
type: docs
weight: 21
url: /ko/cpp/convert-pptx-to-ppt/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPTX 변환
- PPTX를 PPT로
- PPTX를 PPT로 저장
- PPTX를 PPT로 내보내기
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PPTX를 PPT로 쉽게 변환—PowerPoint 형식과 원활한 호환성을 보장하고 프레젠테이션 레이아웃과 품질을 유지합니다."
---
## **개요**

이 문서에서는 C++을 사용하여 PPTX 형식의 PowerPoint 프레젠테이션을 PPT 형식으로 변환하는 방법을 설명합니다. 다음 주제를 다룹니다.

- C++에서 PPTX를 PPT로 변환

## **C++에서 PPTX를 PPT로 변환**

C++ 샘플 코드에서 PPTX를 PPT로 변환하는 방법은 아래 섹션, 즉 [Convert PPTX to PPT](#convert-pptx-to-ppt) 을 참고하십시오. 이 코드는 PPTX 파일을 로드하고 PPT 형식으로 저장합니다. 저장 형식을 다르게 지정하면 PDF, XPS, ODP, HTML 등 다양한 형식으로도 저장할 수 있습니다. 자세한 내용은 해당 기사들을 참고하세요.

- [C++에서 PPTX를 PDF로 변환](/slides/ko/cpp/convert-powerpoint-to-pdf/)
- [C++에서 PPTX를 XPS로 변환](/slides/ko/cpp/convert-powerpoint-to-xps/)
- [C++에서 PPTX를 HTML로 변환](/slides/ko/cpp/convert-powerpoint-to-html/)
- [C++에서 PPTX를 ODP로 저장](/slides/ko/cpp/save-presentation/)
- [C++에서 PPTX를 PNG로 변환](/slides/ko/cpp/convert-powerpoint-to-png/)

## **PPTX를 PPT로 변환**
PPTX를 PPT로 변환하려면 파일 이름과 저장 형식을 **Save** 메서드에 전달하면 됩니다. 대상은 [**Presentation**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation/) 클래스입니다. 아래 C++ 코드 샘플은 기본 옵션을 사용해 PPTX에서 PPT로 변환하는 예시입니다.

```cpp
// PPTX를 로드합니다.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// PPT 형식으로 저장합니다.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **FAQ**

**PPT(97–2003) 형식으로 저장할 때 모든 PPTX 효과와 기능이 유지되나요?**

항상 그렇지는 않습니다. PPT 형식은 최신 기능(예: 특정 효과, 개체 및 동작)을 지원하지 않기 때문에 변환 과정에서 일부 기능이 단순화되거나 래스터화될 수 있습니다.

**전체 프레젠테이션이 아닌 선택한 슬라이드만 PPT로 변환할 수 있나요?**

직접 저장은 전체 프레젠테이션을 대상으로 합니다. 특정 슬라이드만 변환하려면 해당 슬라이드만 포함하는 새로운 프레젠테이션을 만든 후 PPT로 저장하거나, 슬라이드 별 변환 매개변수를 지원하는 서비스/API를 사용하십시오.

**암호로 보호된 프레젠테이션을 지원하나요?**

예. 파일이 보호되어 있는지 감지하고, 비밀번호를 사용해 열 수 있으며, 저장된 PPT에 대해 [보호/암호화 설정을 구성](/slides/ko/cpp/password-protected-presentation/) 할 수도 있습니다.