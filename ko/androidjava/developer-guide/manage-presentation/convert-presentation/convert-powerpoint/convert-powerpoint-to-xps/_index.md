---
title: "Android에서 PowerPoint 프레젠테이션을 XPS로 변환"
linktitle: "PowerPoint를 XPS로"
type: docs
weight: 70
url: /ko/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 Java에서 PowerPoint PPT/PPTX를 고품질, 플랫폼 독립적인 XPS로 변환합니다. 단계별 가이드와 샘플 코드를 제공합니다."
---
## **개요**

Aspose.Slides는 PPT 또는 PPTX 파일을 XPS 형식으로 저장하여 PowerPoint 프레젠테이션을 XPS로 변환할 수 있게 해줍니다. 이 문서는 XPS 형식이 언제 유용할 수 있는지 설명하고 Aspose.Slides를 사용하여 기본 설정 또는 사용자 지정 [XpsOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/xpsoptions/) 설정으로 변환을 수행하는 방법을 보여줍니다.

## **XPS 소개**

Microsoft는 [XPS](https://docs.fileformat.com/page-description-language/xps/)를 [PDF](https://docs.fileformat.com/pdf/)의 대안으로 개발했습니다. XPS는 PDF와 매우 유사한 파일을 출력하여 콘텐츠를 인쇄할 수 있게 해줍니다. XPS 형식은 XML을 기반으로 하며, XPS 파일의 레이아웃이나 구조는 모든 운영 체제와 프린터에서 동일하게 유지됩니다.

## **Microsoft XPS 형식을 사용해야 할 때**

{{% alert color="info" %}} 
Aspose.Slides가 PPT 또는 PPTX 프레젠테이션을 XPS 형식으로 변환하는 방법을 보려면 [이 무료 온라인 변환기 앱](https://products.aspose.app/slides/ko/conversion)을 확인하십시오.
{{% /alert %}} 

스토리지 비용을 절감하려면 Microsoft PowerPoint 프레젠테이션을 XPS 형식으로 변환할 수 있습니다. 이렇게 하면 문서를 저장, 공유 및 인쇄하기가 더 쉬워집니다. 

Microsoft는 Windows(Windows 10에서도)에서 XPS에 대한 강력한 지원을 지속적으로 구현하고 있으므로 파일을 이 형식으로 저장하는 것을 고려할 수 있습니다. Windows 8.1, Windows 8, Windows 7 및 Windows Vista를 사용하는 경우, 특정 작업에 대해 XPS가 실제로 최선의 옵션이 될 수 있습니다. 

- **Windows 8**은 XPS 파일에 OXPS(Open XPS) 형식을 사용합니다. OXPS는 원본 XPS 형식의 표준화된 버전이며, Windows 8은 PDF 파일보다 XPS 파일에 대한 지원이 더 우수합니다. 
  - **XPS:** 내장 XPS 뷰어/리더와 XPS 인쇄 기능 제공. 
  - **PDF:** PDF 리더는 제공되지만 PDF 인쇄 기능은 없음. 

- **Windows 7 및 Windows Vista**는 원본 XPS 형식을 사용합니다. 이 운영 체제 역시 PDF보다 XPS 파일에 대한 지원이 더 좋습니다. 
  - **XPS:** 내장 XPS 뷰어와 XPS 인쇄 기능 제공. 
  - **PDF:** PDF 리더 없음. PDF 인쇄 기능 없음. 

|<p>**입력 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**출력 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft는 Windows 10의 Print to PDF 기능을 통해 PDF 인쇄를 지원하기 시작했습니다. 이전에는 사용자가 XPS 형식을 통해 문서를 인쇄해야 했습니다. 

## **Aspose.Slides를 사용한 XPS 변환**

Java용 [**Aspose.Slides**](https://products.aspose.com/slides/ko/androidjava/)에서 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스가 제공하는 [**Save**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 메서드를 사용하여 전체 프레젠테이션을 XPS 문서로 변환할 수 있습니다.

프레젠테이션을 XPS로 변환할 때는 다음 설정 중 하나를 사용하여 저장해야 합니다.

- 기본 설정([**XPSOptions**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/xpsoptions/) 없이)
- 사용자 지정 설정([**XPSOptions**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/xpsoptions/) 사용)

### **기본 설정을 사용하여 프레젠테이션을 XPS로 변환**

다음 Java 샘플 코드는 표준 설정을 사용하여 프레젠테이션을 XPS 문서로 변환하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // XpsOptions 클래스를 인스턴스화합니다
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

### 파일 대신 스트림에 XPS를 저장할 수 있나요?

예—Aspose.Slides는 스트림으로 직접 내보내는 기능을 제공하므로 웹 API, 서버‑사이드 파이프라인 또는 파일 시스템에 접근하지 않고 XPS를 전송해야 하는 모든 시나리오에 이상적입니다.

### 숨겨진 슬라이드가 XPS에 포함되며, 이를 제외할 수 있나요?

기본적으로 보이는 일반 슬라이드만 렌더링됩니다. 저장하기 전에 [숨겨진 슬라이드 포함 또는 제외](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-)를 [내보내기 설정](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/xpsoptions/)을 통해 지정할 수 있어 원하는 페이지만 출력에 포함될 수 있습니다.