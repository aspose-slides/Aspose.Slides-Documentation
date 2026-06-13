---
title: .NET에서 PowerPoint 프레젠테이션을 XPS로 변환
linktitle: PowerPoint를 XPS로
type: docs
weight: 70
url: /ko/net/convert-powerpoint-to-xps/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 PowerPoint PPT/PPTX를 고품질, 플랫폼 독립적인 XPS로 변환합니다. 단계별 가이드와 샘플 C# 코드를 확인하세요."
---
## **개요**

Aspose.Slides를 사용하면 PPT 또는 PPTX 파일을 XPS 형식으로 저장하여 PowerPoint 프레젠테이션을 XPS로 변환할 수 있습니다. 이 문서에서는 XPS 형식이 유용할 수 있는 상황을 설명하고 Aspose.Slides를 사용해 기본 설정 또는 사용자 정의 [XpsOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/xpsoptions/) 설정으로 변환하는 방법을 보여줍니다.

## **XPS에 대하여**

Microsoft는 [XPS](https://docs.fileformat.com/page-description-language/xps/)를 [PDF](https://docs.fileformat.com/pdf/) 대안으로 개발했습니다. XPS는 PDF와 매우 유사한 파일을 출력하여 내용을 인쇄할 수 있게 해줍니다. XPS 형식은 XML을 기반으로 합니다. XPS 파일의 레이아웃이나 구조는 모든 운영 체제와 프린터에서 동일하게 유지됩니다.

## **Microsoft XPS 형식을 사용할 때**

{{% alert color="primary" %}} 

Aspose.Slides가 PPT 또는 PPTX 프레젠테이션을 XPS 형식으로 변환하는 방식을 보려면 [this free online converter app](https://products.aspose.app/slides/ko/conversion)를 확인하세요. 

{{% /alert %}} 

스토리지 비용을 절감하려면 Microsoft PowerPoint 프레젠테이션을 XPS 형식으로 변환할 수 있습니다. 이렇게 하면 문서를 저장·공유·인쇄하기가 더 쉬워집니다.

Microsoft는 Windows(Windows 10에서도)에서 XPS에 대한 강력한 지원을 지속하고 있으므로 파일을 이 형식으로 저장하는 것을 고려할 수 있습니다. Windows 8.1, Windows 8, Windows 7 및 Windows Vista를 사용 중이라면 특정 작업에 대해 XPS가 실제로 최선의 옵션이 될 수 있습니다.

- **Windows 8**는 XPS 파일에 OXPS(Open XPS) 형식을 사용합니다. OXPS는 원래 XPS 형식의 표준화된 버전입니다. Windows 8은 PDF 파일보다 XPS 파일에 대한 지원이 더 우수합니다.
  - **XPS:** 기본 제공 XPS 뷰어/리더 및 XPS 인쇄 기능이 제공됩니다.
  - **PDF:** PDF 리더는 제공되지만 PDF 인쇄 기능은 없습니다.

- **Windows 7** 및 **Windows Vista**는 원래 XPS 형식을 사용합니다. 이러한 운영 체제도 PDF보다 XPS 파일에 대한 지원이 더 좋습니다.
  - **XPS:** 기본 제공 XPS 뷰어 및 XPS 인쇄 기능이 제공됩니다.
  - **PDF:** PDF 리더가 없습니다. PDF 인쇄 기능도 없습니다.

|<p>**입력 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**출력 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft는 결국 Windows 10의 PDF 인쇄 기능을 통해 PDF 인쇄 작업에 대한 지원을 구현했습니다. 이전에는 사용자가 XPS 형식을 통해 문서를 인쇄해야 했습니다.

## **Aspose.Slides를 사용한 XPS 변환**

.NET용 [**Aspose.Slides**](https://products.aspose.com/slides/ko/net/)에서 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스가 제공하는 [**Save**](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/methods/save/index) 메서드를 사용하여 전체 프레젠테이션을 XPS 문서로 변환할 수 있습니다.

프레젠테이션을 XPS로 변환할 때는 다음 설정 중 하나를 사용하여 프레젠테이션을 저장해야 합니다.

- 기본 설정 ([**XPSOptions**](https://reference.aspose.com/slides/ko/net/aspose.slides.export/xpsoptions) 없이)
- 사용자 정의 설정 ([**XPSOptions**](https://reference.aspose.com/slides/ko/net/aspose.slides.export/xpsoptions) 포함)

### **기본 설정을 사용하여 프레젠테이션을 XPS로 변환**

다음 C# 샘플 코드는 표준 설정을 사용하여 프레젠테이션을 XPS 문서로 변환하는 방법을 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
 using (Presentation pres = new Presentation("Convert_XPS.pptx"))
 {
     // 프레젠테이션을 XPS 문서로 저장합니다
     pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
 }
```

### **사용자 정의 설정을 사용하여 프레젠테이션을 XPS로 변환**

다음 샘플 코드는 C#에서 사용자 정의 설정을 사용하여 프레젠테이션을 XPS 문서로 변환하는 방법을 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
 using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
 {
     // TiffOptions 클래스를 인스턴스화합니다
     XpsOptions options = new XpsOptions();

     // 메타파일을 PNG로 저장합니다
     options.SaveMetafilesAsPng = true;

     // 프레젠테이션을 XPS 문서로 저장합니다
     pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
 }
```

## **FAQ**

**파일 대신 스트림에 XPS를 저장할 수 있나요?**

예—Aspose.Slides를 사용하면 스트림으로 직접 내보낼 수 있어 웹 API, 서버 측 파이프라인 혹은 파일 시스템에 접근하지 않고 XPS를 전송하려는 모든 상황에 적합합니다.

**숨겨진 슬라이드가 XPS에 포함되며, 이를 제외할 수 있나요?**

기본적으로 일반(보이는) 슬라이드만 렌더링됩니다. XPS로 저장하기 전에 [export settings](https://reference.aspose.com/slides/ko/net/aspose.slides.export/xpsoptions/)를 통해 숨겨진 슬라이드를 [포함하거나 제외할 수 있습니다](https://reference.aspose.com/slides/ko/net/aspose.slides.export/xpsoptions/showhiddenslides/), 이렇게 하면 원하는 페이지만 출력에 포함됩니다.