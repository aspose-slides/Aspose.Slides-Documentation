---
title: PresentationML (PPTX, XML) (Historical)
type: docs
weight: 20
url: /ko/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- 역사적
- Java
- Aspose.Slides
description: "역사적: Aspose.Slides for Java의 PresentationML (PPTX) 형식에 대한 이전 개요이며, 기존 링크를 위해 보관되었습니다. 현재 지원되는 형식 목록은 지원되는 파일 형식 페이지에 있습니다."
---
{{% alert color="info" title="Note" %}}

이 페이지는 기존 링크를 위해 보관된 과거 페이지입니다. 현재 버전의 Aspose.Slides for Java에 대한 설명은 포함되지 않습니다. Aspose.Slides for Java가 로드, 가져오기, 저장 및 렌더링하는 형식과 각 형식에 대한 API는 [지원되는 파일 형식](/slides/ko/java/supported-file-formats/)을 참조하십시오. PPTX와 PPT를 비교하려면 [차이점 이해: PPT와 PPTX](/slides/ko/java/ppt-vs-pptx/)를 확인하세요.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

PresentationML은 프레젠테이션 문서를 위한 XML 기반 형식군의 이름입니다. Office OpenXML(OOXML)은 Microsoft Office 2007 응용 프로그램에서 도입된 XML 기반 형식입니다. Office OpenXML은 여러 전문화된 XML 기반 마크업 언어를 위한 컨테이너 형식이며, PresentationML은 Microsoft Office PowerPoint 2007이 문서를 저장하는 데 사용하는 마크업 언어입니다.

{{% /alert %}}

## **Aspose.Slides for Java의 PresentationML**
OOXML PresentationML 문서는 PPTX 파일 형태로 제공되며, [OOXML ECMA-376](https://ecma-international.org/publications-and-standards/standards/ecma-376/) 사양을 따르는 압축된 XML 패키지입니다. Aspose.Slides for Java는 PresentationML 문서를 생성, 읽기, 조작 및 쓰기를 광범위하게 지원합니다. 또한 Aspose.Slides for Java는 PresentationML 문서를 PDF와 같은 널리 사용되는 문서 형식으로 내보낼 수 있습니다. 이는 Aspose.Slides for Java가 프레젠테이션 문서를 포괄적으로 처리하도록 설계되었으며, PresentationML이 기본적으로 문서의 내부 프레젠테이션을 압축된 XML 패키지 형태로 보관하기 때문에 가능합니다.

**Aspose.Slides for Java로 생성되고 Microsoft PowerPoint에서 열린 PPTX 문서**

![Aspose.Slides for Java로 생성되고 Microsoft PowerPoint에서 열린 PPTX 문서](presentationml-pptx-xml_1.png)


**같은 PPTX 문서를 ZIP 패키지로 본 모습**

![같은 PPTX 문서를 ZIP 패키지로 본 모습](presentationml-pptx-xml_2.jpg)


## **PresentationML은 오픈이며, Aspose.Slides for Java를 사용해야 하는 이유**
PresentationML이 XML 기반이기 때문에 XML 클래스를 사용해 제3자 라이브러리인 Aspose.Slides for Java 없이도 PresentationML 문서를 처리하고 생성하는 애플리케이션을 구축할 수 있습니다. 그러나 PresentationML 문서를 다룰 때 XML 클래스만 사용하는 것보다 Aspose.Slides for Java를 사용하는 데는 몇 가지 장점이 있습니다.

OOXML 사양은 수천 페이지에 달하므로 PresentationML 문서를 제대로 다루려면 형식을 이해하는 데 많은 시간과 노력이 필요합니다. 반면 Aspose.Slides for Java를 사용하면 복잡해 보이는 작업도 클래스와 해당 메서드 및 속성을 사용해 간단히 수행할 수 있습니다.

Aspose.Slides가 제공하는 기능 중 일부는 XML 클래스로 PresentationML 문서를 작업할 때는 전혀 사용할 수 없습니다.

- PPT 문서를 PDF 형식으로 내보내기.
- Java 프레임워크가 지원하는 모든 이미지 형식으로 슬라이드 렌더링.
- 복제 기능을 사용해 소스 프레젠테이션에서 마스터를 자동으로 복사.
- 도형에 보호 적용.

아래는 단일 슬라이드에 “Hello World” 텍스트 상자가 포함된 PresentationML 문서 예시입니다. XML 클래스로 텍스트를 읽으려면 다음 조각에서 이 간단한 텍스트를 파싱할 프로그램을 작성해야 합니다. Aspose.Slides가 이를 대신 수행합니다.

**XML**

``` xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">
  <p:cSld>
    <p:spTree>
      <p:nvGrpSpPr>
        <p:cNvPr id="1" name=""/>
        <p:cNvGrpSpPr/>
        <p:nvPr/>
      </p:nvGrpSpPr>
      <p:grpSpPr>
        <a:xfrm>
          <a:off x="0" y="0"/>
          <a:ext cx="0" cy="0"/>
          <a:chOff x="0" y="0"/>
          <a:chExt cx="0" cy="0"/>
        </a:xfrm></p:grpSpPr><p:sp>
          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>
          <p:cNvSpPr txBox="1"/>
            <p:nvPr/>
          </p:nvSpPr>
          <p:spPr>
            <a:xfrm>
              <a:off x="2819400" y="2590800"/>
              <a:ext cx="1297086" cy="369332"/>
            </a:xfrm>
            <a:prstGeom prst="rect">
              <a:avLst/>
            </a:prstGeom>
            <a:noFill/>
          </p:spPr>
          <p:txBody>
            <a:bodyPr wrap="none" rtlCol="0">
              <a:spAutoFit/>
            </a:bodyPr>
            <a:lstStyle/>
            <a:p>
              <a:r>
                <a:rPr lang="en-US"/>
                <a:t>Hello World
                </a:t>
              </a:r>
              <a:endParaRPr lang="en-US"/>
            </a:p>
          </p:txBody>
        </p:sp>
    </p:spTree>
  </p:cSld>
  <p:clrMapOvr>
    <a:masterClrMapping/>
  </p:clrMapOvr>
</p:sld>
```