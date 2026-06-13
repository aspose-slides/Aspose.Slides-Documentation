---
title: PowerPoint 렌더링 확장 캡션 사용자 지정
type: docs
weight: 60
url: /ko/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 
이 문서에서는 Aspose.Slides for Reporting Services의 렌더링 옵션 캡션을 사용자 지정하는 방법을 보여줍니다.
{{% /alert %}} 
## **예제**
Aspose.Slides for Reporting Services를 설치하면 내보내기 옵션 드롭다운 메뉴에 4개의 추가 내보내기 옵션이 추가됩니다.

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **캡션 텍스트를 수정하는 방법**
이 확장 기능의 기본 캡션은 기본 이름을 재정의하여 변경할 수 있습니다. 이 단계에서는 캡션을 “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ”에서 “ **PowerPoint 97 – 2003 format(PPT)** ”으로 변경하는 방법을 보여줍니다.

**단계 1:** 일반적으로 다음 디렉터리에 있는 **rsreportserver.config** 파일을 찾으십시오:

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer**

**단계** **2:** rsreportserver.config 파일에서 다음 줄을 찾으십시오:

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**단계** **3:** 이와 같이 확장 파라미터를 교체하십시오:

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

이제 내보내기 옵션이 다음과 같이 표시됩니다:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)