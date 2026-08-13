---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /ko/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

PresentationML은 프레젠테이션 문서를 위한 XML 기반 포맷군의 이름입니다. Office OpenXML(OOXML)은 Microsoft Office 2007 애플리케이션에 도입된 XML 기반 포맷입니다. Office OpenXML은 여러 전문화된 XML 기반 마크업 언어를 위한 컨테이너 포맷입니다. PresentationML은 Microsoft Office PowerPoint 2007이 문서를 저장하는 데 사용하는 마크업 언어입니다.

{{% /alert %}} 

## **Java용 Aspose.Slides의 PresentationML**
OOXML PresentationML 문서는 PPTX 파일 형태이며, [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 사양을 따르는 압축된 XML 패키지입니다. Aspose.Slides for Java는 PresentationML 문서를 생성, 읽기, 조작 및 쓰기를 폭넓게 지원합니다. 또한 Aspose.Slides for Java는 PresentationML 문서를 PDF와 같은 널리 사용되는 문서 형식으로 내보낼 수 있습니다. 이는 Aspose.Slides for Java가 프레젠테이션 문서를 포괄적으로 처리하도록 설계되었으며, PresentationML이 기본적으로 문서의 내부 프레젠테이션을 압축된 XML 패키지로 보관하기 때문입니다.

**Aspose.Slides for Java로 생성되고 Microsoft PowerPoint에서 열린 PPTX 문서** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Aspose.Slides for Java로 생성된 동일한 PPTX 문서를 ZIP에서 확인하기** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML은 오픈 형식이며, Aspose.Slides for Java를 사용해야 하는 이유**
PresentationML이 XML 기반이기 때문에 Aspose.Slides for Java와 같은 서드파티 클래스 라이브러리에 의존하지 않고 XML 클래스를 사용하여 PresentationML 문서를 처리하고 생성하는 애플리케이션을 구축하는 것이 충분히 가능합니다. 그러나 PresentationML 문서를 다룰 때 XML 클래스보다 Aspose.Slides for Java를 사용하는 데에는 여러 가지 장점이 있습니다.

OOXML 사양은 수천 페이지에 달하므로 PresentationML 문서를 올바르게 처리하려면 형식을 이해하는 데 많은 시간과 노력이 필요합니다. 반면 Aspose.Slides for Java를 사용하면 클래스와 해당 메서드 및 속성을 이용해 XML 클래스로 수행하면 복잡해 보이는 작업을 간단히 수행할 수 있습니다.

XML 클래스를 통해 PresentationML 문서를 작업할 때는 Aspose.Slides가 제공하는 몇몇 기능조차 사용할 수 없습니다:
- PPT 문서를 PDF 형식으로 내보내기.
- Java 프레임워크가 지원하는 모든 이미지 형식으로 슬라이드를 렌더링.
- 클론 기능을 사용하여 소스 프레젠테이션에서 마스터를 자동으로 복사.
- 도형에 보호 적용.

아래는 단일 슬라이드에 “Hello World” 텍스트가 포함된 텍스트 상자를 가진 PresentationML 문서 예시입니다. XML 클래스를 사용하여 텍스트를 읽으려면 다음 조각에서 이 간단한 텍스트를 파싱하는 프로그램을 작성해야 합니다. Aspose.Slides가 이를 대신 수행합니다.

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