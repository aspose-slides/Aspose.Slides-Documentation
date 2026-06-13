---
title: Java에서 PowerPoint 프레젠테이션을 XPS로 변환
linktitle: PowerPoint를 XPS로
type: docs
weight: 70
url: /ko/java/convert-powerpoint-to-xps/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 XPS로
- 프레젠테이션을 XPS로
- 슬라이드를 XPS로
- PPT를 XPS로
- PPTX를 XPS로
- PPT를 XPS로 저장
- PPTX를 XPS로 저장
- PPT를 XPS로 내보내기
- PPTX를 XPS로 내보내기
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint PPT/PPTX를 고품질의 플랫폼 독립적인 XPS로 변환합니다. 단계별 가이드와 샘플 코드를 확인하세요."
---
## **개요**

Aspose.Slides는 PPT 또는 PPTX 파일을 XPS 형식으로 저장하여 PowerPoint 프레젠테이션을 XPS로 변환할 수 있게 해줍니다. 이 문서에서는 XPS 형식이 유용할 수 있는 경우를 설명하고, 기본 설정 또는 사용자 지정 [XpsOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xpsoptions/) 설정을 사용하여 Aspose.Slides로 변환하는 방법을 보여줍니다.

## **XPS에 대한 정보**

Microsoft는 [PDF](https://docs.fileformat.com/pdf/)의 대안으로 [XPS](https://docs.fileformat.com/page-description-language/xps/)를 개발했습니다. XPS는 PDF와 매우 유사한 파일을 출력하여 콘텐츠를 인쇄할 수 있게 합니다. XPS 형식은 XML 기반이며, XPS 파일의 레이아웃 또는 구조는 모든 운영 체제와 프린터에서 동일하게 유지됩니다.

## **Microsoft XPS 형식을 사용해야 할 때**

{{% alert color="primary" %}} 

Aspose.Slides가 PPT 또는 PPTX 프레젠테이션을 XPS 형식으로 변환하는 방식을 확인하려면 [이 무료 온라인 변환기 앱](https://products.aspose.app/slides/ko/conversion)을 확인하십시오.

{{% /alert %}} 

스토리지 비용을 절감하려면 Microsoft PowerPoint 프레젠테이션을 XPS 형식으로 변환할 수 있습니다. 이렇게 하면 문서를 저장, 공유 및 인쇄하기가 더 쉬워집니다.

Microsoft는 Windows(Windows 10에서도)에서 XPS에 대한 강력한 지원을 계속 구현하고 있으므로 파일을 이 형식으로 저장하는 것을 고려할 수 있습니다. Windows 8.1, Windows 8, Windows 7 및 Windows Vista를 사용하고 있다면 특정 작업에 대해 XPS가 실제로 최선의 옵션일 수 있습니다.

- **Windows 8** 은 XPS 파일에 OXPS(Open XPS) 형식을 사용합니다. OXPS는 원래 XPS 형식의 표준화된 버전입니다. Windows 8은 PDF 파일보다 XPS 파일에 대한 지원이 더 우수합니다.
  - **XPS:** 기본 제공 XPS 뷰어/리더 및 XPS 인쇄 기능 사용 가능.
  - **PDF:** PDF 리더는 제공되지만 PDF 인쇄 기능은 없습니다.
- **Windows 7 및 Windows Vista** 는 원래 XPS 형식을 사용합니다. 이 운영 체제들도 PDF보다 XPS 파일에 대한 지원이 더 좋습니다.
  - **XPS:** 기본 제공 XPS 뷰어 및 XPS 인쇄 기능 사용 가능.
  - **PDF:** PDF 리더가 없습니다. PDF 인쇄 기능도 없습니다.

|<p>**입력 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**출력 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft는 결국 Windows 10의 Print to PDF 기능을 통해 PDF 인쇄 작업에 대한 지원을 구현했습니다. 이전에는 사용자가 XPS 형식을 통해 문서를 인쇄해야 했습니다.

## **Aspose.Slides를 사용한 XPS 변환**

Java용 [**Aspose.Slides**](https://products.aspose.com/slides/ko/java/)에서는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스가 제공하는 [**Save**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 메서드를 사용하여 전체 프레젠테이션을 XPS 문서로 변환할 수 있습니다.

프레젠테이션을 XPS로 변환할 때는 다음 설정 중 하나를 사용하여 프레젠테이션을 저장해야 합니다.

- 기본 설정 ([**XPSOptions**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xpsoptions/) 없이)
- 사용자 지정 설정 ([**XPSOptions**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xpsoptions/) 사용)

### **기본 설정을 사용하여 프레젠테이션을 XPS로 변환**

다음 Java 샘플 코드는 표준 설정을 사용하여 프레젠테이션을 XPS 문서로 변환하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // 프레젠테이션을 XPS 문서로 저장합니다
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **사용자 지정 설정을 사용하여 프레젠테이션을 XPS로 변환**

다음 샘플 코드는 Java에서 사용자 지정 설정을 사용하여 프레젠테이션을 XPS 문서로 변환하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions 클래스를 인스턴스화합니다
    XpsOptions options = new XpsOptions();

    // 메타파일을 PNG로 저장합니다
    options.setSaveMetafilesAsPng(true);

    // 프레젠테이션을 XPS 문서로 저장합니다
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**스트림에 XPS를 저장하고 파일 대신 사용할 수 있나요?**

예—Aspose.Slides를 사용하면 스트림으로 직접 내보낼 수 있어 웹 API, 서버 측 파이프라인 또는 파일 시스템에 접근하지 않고 XPS를 전송해야 하는 모든 상황에 이상적입니다.

**숨겨진 슬라이드가 XPS에 포함되며, 이를 제외할 수 있나요?**

기본적으로 일반(보이는) 슬라이드만 렌더링됩니다. XPS로 저장하기 전에 [내보내기 설정](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xpsoptions/)을 통해 [숨겨진 슬라이드를 포함하거나 제외할 수](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) 있습니다. 이를 통해 출력에 원하는 페이지만 정확히 포함되도록 할 수 있습니다.