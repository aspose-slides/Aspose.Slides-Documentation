---
title: Personalización de los Resultados de Renderización al Extender Aspose.Slides para RS
type: docs
weight: 10
url: /es/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---

{{% alert color="primary" %}} 

Esta página describe cómo crear una extensión para Aspose.Slides para RS.

- [Crear un ensamblaje de extensión](/slides/es/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Integrar la extensión](/slides/es/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

La función de Extensión Personalizada te da la opción de agregar elementos adicionales o actualizar elementos existentes durante la exportación de informes.
## **Cómo crear un ensamblaje de extensión**
1. Crea un proyecto .NET y agrega una referencia a Aspose.Slides.ReportingServices.dll.
1. Agrega una clase y herédala de Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Sobrescribe los métodos virtuales de la clase para agregar funcionalidad personalizada.
### **Ejemplo**
Supongamos que queremos agregar una nota con algo de texto, un logo y actualizar el nombre de la empresa para cada informe exportado con Aspose.Slides para RS.

Para ese propósito, agregamos la siguiente clase:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Agregar nota a la primera diapositiva

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("Esta es la demostración de la Extensión de Renderizado para Aspose.Slides para Reporting Services",

textFormat);

}

//Mostrar logo en cada diapositiva en la esquina inferior derecha

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Agregar (TM) a cualquier mención del nombre de la empresa en el informe

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

Compílalo y obtendrás el ensamblaje de extensión. Estamos listos para integrar la extensión.

{{% /alert %}} 

[Proyecto de Visual Studio de RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Integrando la Extensión**
Supongamos que tu ensamblaje se llama **TestSlidesRenderingExtension.dll**:

- Copia el ensamblaje al directorio **bin** de ReportingService junto a Aspose.Slides.ReportingServices.dll. (Por ejemplo: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Concede permiso FullTrust a tu ensamblaje agregando el siguiente CodeGroup a **rssrvpolicy.config**:

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" />

...

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Este grupo de código concede permiso de ejecución de código a MiComputadora. ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

...

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="Este grupo de código concede confianza total a la extensión de renderizado de Aspose.Slides para Reporting Services.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

Actualiza las secciones de configuración de la extensión de Aspose.Slides en **rsreportserver.config** para incluir tu extensión.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Si deseas utilizar la extensión para cada tipo de salida compatible con Aspose.Slides, agrega la misma configuración a las extensiones con los nombres ASPPTX, ASPPT, ASPPS, ASPPSX.
El contenido de la etiqueta Extension es un nombre cualificado de ensamblaje del tipo. (Ver <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Ahora reinicia Reporting Services y exporta el informe. Obtendrás algo como [esta presentación](attachments/10289195/10452997.pptx) del informe de Ventas de la Empresa SQL2008R2 de los ejemplos de Adventureworks.