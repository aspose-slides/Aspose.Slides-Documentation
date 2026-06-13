---
title: Aspose.Slides for RS를 확장하여 렌더링 결과 사용자 지정
type: docs
weight: 10
url: /ko/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 

이 페이지에서는 Aspose.Slides for RS용 확장을 만드는 방법을 설명합니다.

- [확장 어셈블리 만들기](/slides/ko/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [확장 통합](/slides/ko/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

Custom Extension 기능을 사용하면 보고서 내보내기 중에 추가 요소를 추가하거나 기존 요소를 업데이트할 수 있습니다.
## **확장 어셈블리 만드는 방법**
1. .NET 프로젝트를 생성하고 Aspose.Slides.ReportingServices.dll에 대한 참조를 추가합니다.
1. 클래스를 추가하고 Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase에서 상속합니다.
1. 클래스의 가상 메서드를 재정의하여 사용자 지정 기능을 추가합니다.
### **예시**
예를 들어, Aspose.Slides for RS로 내보낸 모든 보고서에 텍스트가 포함된 메모와 로고를 추가하고 회사 이름을 업데이트하고 싶다고 가정해 보겠습니다.

이를 위해 다음 클래스를 추가합니다:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//첫 번째 슬라이드에 메모 추가

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//모든 슬라이드 오른쪽 하단에 로고 표시

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//보고서에서 회사 이름이 언급될 때마다 (TM) 기호 추가

string companyName = "Adventure Works";

if (textBox.Text.Contains(companyName))

{

textBox.Text = textBox.Text.Replace(companyName, companyName + "™");

}

base.PostProcessTextBox(textBox);

}

}
```

{{% alert color="primary" %}} 

빌드하면 확장 어셈블리를 얻을 수 있습니다. 이제 확장을 통합할 준비가 되었습니다.

{{% /alert %}} 

[RenderingExtensionDemo.zip의 Visual Studio 프로젝트](attachments/10289195/10452998.zip)
### **확장 통합**
귀하의 어셈블리 이름이 **TestSlidesRenderingExtension.dll**이라고 가정합니다:

- 어셈블리를 Aspose.Slides.ReportingServices.dll 옆의 Reporting Service **bin** 디렉터리로 복사합니다. (예: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- 다음 CodeGroup을 **rssrvpolicy.config**에 추가하여 어셈블리에 FullTrust 권한을 부여합니다:

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" />

...

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

...

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="This code group grants full trust to the Aspose.Slides for Reporting Services Rendering extension.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

- **rsreportserver.config**의 Aspose.Slides 렌더링 확장 구성 섹션을 업데이트하여 확장을 포함시킵니다.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Aspose.Slides에서 지원하는 모든 출력 유형에 대해 확장을 사용하려면 ASPPTX, ASPPT, ASPPS, ASPPSX라는 이름의 확장에 동일한 구성을 추가합니다.  
Extension 태그의 내용은 형식의 어셈블리 전체 이름입니다. (See <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

이제 Reporting Services를 다시 시작하고 보고서를 내보냅니다. Adventureworks 샘플의 Company Sales SQL2008R2 보고서에서 [이 프레젠테이션](attachments/10289195/10452997.pptx)과 같은 결과를 얻을 수 있습니다.