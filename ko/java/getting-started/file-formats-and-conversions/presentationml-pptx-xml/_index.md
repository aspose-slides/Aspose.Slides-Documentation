---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /ko/java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML은 프레젠테이션 문서를 위한 XML 기반 포맷 패밀리의 이름입니다. Office OpenXML(OOXML)은 Microsoft Office 2007 애플리케이션에서 도입된 XML 기반 포맷입니다. Office OpenXML은 여러 특화된 XML 기반 마크업 언어를 위한 컨테이너 포맷입니다. PresentationML은 Microsoft Office PowerPoint 2007이 문서를 저장하는 데 사용하는 마크업 언어입니다.

{{% /alert %}} 

## **Aspose.Slides for Java의 PresentationML**
OOXML PresentationML 문서는 PPTX 파일 형태로 제공되며, [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 사양을 따르는 압축된 XML 패키지입니다. Aspose.Slides for Java는 PresentationML 문서의 생성, 읽기, 조작 및 쓰기를 폭넓게 지원합니다. 또한 Aspose.Slides for Java는 PresentationML 문서를 PDF와 같은 널리 사용되는 문서 포맷으로 내보낼 수 있습니다. 이는 Aspose.Slides for Java가 프레젠테이션 문서를 포괄적으로 처리하도록 설계되었으며, PresentationML이 기본적으로 압축된 XML 패키지 형태로 내부 프레젠테이션을 보관하기 때문에 가능합니다.

**Aspose.Slides for Java로 생성하고 Microsoft PowerPoint에서 연 PPTX 문서** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Aspose.Slides for Java로 생성한 동일한 PPTX 문서를 ZIP으로 열어 본 모습** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML은 오픈 형식, Aspose.Slides for Java를 사용해야 하는 이유**
PresentationML이 XML 기반이기 때문에 XML 클래스를 사용해 서드파티 라이브러리인 Aspose.Slides for Java 없이도 문서를 처리하고 생성하는 애플리케이션을 구축할 수 있습니다. 그러나 PresentationML 문서를 다룰 때 XML 클래스만 사용하는 것보다 Aspose.Slides for Java를 사용하는 데는 여러 장점이 있습니다.

OOXML 사양은 수천 페이지에 달하므로 PresentationML 문서를 올바르게 처리하려면 형식에 대한 이해에 많은 시간과 노력이 필요합니다. 반면 Aspose.Slides for Java를 사용하면 복잡해 보이는 작업도 클래스와 해당 메서드 및 속성을 활용해 간단히 수행할 수 있습니다.

Aspose.Slides가 제공하는 기능 중 일부는 XML 클래스로 PresentationML 문서를 작업할 때는 전혀 사용할 수 없습니다:

- PPT 문서를 PDF 형식으로 내보내기.
- Java 프레임워크가 지원하는 모든 이미지 형식으로 슬라이드 렌더링.
- 복제 기능을 사용해 소스 프레젠테이션에서 마스터를 자동으로 복사.
- 도형에 보호 적용.

아래는 텍스트 상자에 “Hello World” 텍스트가 포함된 단일 슬라이드로 구성된 PresentationML 문서 예시입니다. XML 클래스를 사용해 텍스트를 읽으려면 다음 조각에서 이 단순 텍스트를 파싱하는 프로그램을 작성해야 합니다. Aspose.Slides가 이를 대신 처리합니다.

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