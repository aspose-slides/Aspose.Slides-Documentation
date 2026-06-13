---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /ko/cpp/presentationml-pptx-xml/
---
## **PresentationML 소개**
PresentationML은 프레젠테이션 문서용 XML 기반 형식군의 이름입니다. Office OpenXML(OOXML)은 Microsoft Office 2007 애플리케이션에서 도입된 XML 기반 형식입니다. Office OpenXML은 여러 특수화된 XML 기반 마크업 언어를 위한 컨테이너 형식입니다. PresentationML은 Microsoft Office PowerPoint 2007이 문서를 저장하는 데 사용하는 마크업 언어입니다. 

## **Aspose.Slides for C++의 PresentationML**
OOXML PresentationML 문서는 PPTX 파일 형태로 제공되며, 이는 [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 사양을 따르는 압축된 XML 패키지입니다. Aspose.Slides for C++는 PresentationML 문서를 만들기, 읽기, 조작하기 및 쓰기를 폭넓게 지원합니다. 또한 Aspose.Slides for C++는 PresentationML 문서를 PDF, TIFF, XPS와 같은 널리 사용되는 다양한 문서 형식으로 내보낼 수 있습니다. 이는 Aspose.Slides for C++가 프레젠테이션 문서를 포괄적으로 처리하도록 설계되었으며, PresentationML이 기본적으로 문서의 내부 프레젠테이션을 압축된 XML 패키지로 보관하기 때문입니다. 

## **PresentationML은 개방형이며, Aspose.Slides for C++를 사용해야 하는 이유**
PresentationML은 XML 기반이므로 Aspose.Slides for C++와 같은 서드파티 클래스 라이브러리에 의존하지 않고 XML 클래스를 사용하여 PresentationML 문서를 처리하고 생성하는 애플리케이션을 구축하는 것이 충분히 가능합니다. 그러나 PresentationML 문서를 작업할 때 XML 클래스보다 Aspose.Slides for C++를 사용하는 데에는 여러 가지 장점이 있습니다. 

OOXML 사양은 수천 페이지에 달할 정도로 방대합니다. 이는 PresentationML 문서를 적절히 처리하려면 해당 문서 형식을 이해하는 데 많은 시간과 노력이 필요함을 의미합니다. 반면 Aspose.Slides for C++를 사용하면 XML 클래스로 수행할 경우 상당히 복잡해 보이는 작업도 관련 클래스와 해당 메서드/속성을 사용해 간단히 수행할 수 있습니다. 

다음은 XML 클래스를 통해 PresentationML 문서를 다룰 때조차 제공되지 않는 몇 가지 기능입니다: 

- PPT 문서를 PDF, TIFF, XPS 형식으로 내보내기
- PPT 문서의 슬라이드를 SVG 형식으로 내보내기
- 슬라이드를 C++ Framework가 지원하는 모든 이미지 형식으로 렌더링
- 복제 기능을 사용하여 원본 프레젠테이션에서 마스터를 자동으로 복사
- 도형에 보호 적용

단일 슬라이드에 하나의 텍스트 상자가 포함되어 “Hello World” 텍스트가 들어 있는 PresentationML 문서 예제를 살펴보겠습니다. XML 클래스를 사용해 텍스트를 읽으려면 다음 조각에서 이 간단한 텍스트를 파싱할 수 있는 프로그램을 작성해야 합니다. 
## **예제**


``` cpp

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