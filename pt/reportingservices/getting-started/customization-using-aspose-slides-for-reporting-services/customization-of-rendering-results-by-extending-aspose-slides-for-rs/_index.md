---
title: Personalização dos Resultados de Renderização ao Estender Aspose.Slides para RS
type: docs
weight: 10
url: /pt/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 

Esta página descreve como criar uma extensão para Aspose.Slides for RS.

- [Create an Extension Assembly](/slides/pt/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Integrating the Extension](/slides/pt/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

O recurso Custom Extension permite adicionar elementos extras ou atualizar elementos existentes durante a exportação do relatório.
## **How to Create an Extension Assembly**
1. Crie um projeto .NET e adicione uma referência a Aspose.Slides.ReportingServices.dll.
1. Adicione uma classe e a derive de Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Substitua os métodos virtuais da classe para inserir funcionalidade personalizada.
### **Example**
Suponha que queiramos adicionar uma nota com algum texto, um logotipo e atualizar o nome da empresa em cada relatório exportado com Aspose.Slides for RS.

Para esse fim, adicionamos a seguinte classe:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Adicionar nota ao primeiro slide

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Mostrar logotipo em cada slide no canto inferior direito

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Adicionar (TM) a qualquer menção do nome da empresa no relatório

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

Compile-a e você obterá o assembly da extensão. Estamos prontos para integrar a extensão.

{{% /alert %}} 

[Visual studio project of RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Integrating the Extension**
Suponha que seu assembly se chama **TestSlidesRenderingExtension.dll**:

- Copie o assembly para o diretório **bin** do Reporting Service ao lado de Aspose.Slides.ReportingServices.dll. (Por exemplo: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Conceda permissão FullTrust ao seu assembly adicionando o seguinte CodeGroup ao **rssrvpolicy.config**:

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

Atualize as seções de configuração da extensão de renderização Aspose.Slides em **rsreportserver.config** para incluir sua extensão.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Se desejar usar a extensão para cada tipo de saída suportado pelo Aspose.Slides, adicione a mesma configuração às extensões com os nomes ASPPTX, ASPPT, ASPPS, ASPPSX.
O conteúdo da tag Extension é um nome qualificado de assembly do tipo. (Veja <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Agora reinicie o Reporting Services e exporte o relatório. Você obterá algo como [this presentation](attachments/10289195/10452997.pptx) do relatório Company Sales SQL2008R2 das amostras Adventureworks.