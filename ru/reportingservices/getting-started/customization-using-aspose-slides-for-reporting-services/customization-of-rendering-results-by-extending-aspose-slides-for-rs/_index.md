---
title: Пользовательская настройка результатов рендеринга путем расширения Aspose.Slides для RS
type: docs
weight: 10
url: /ru/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---

{{% alert color="primary" %}} 

Эта страница описывает, как создать расширение для Aspose.Slides для RS.

- [Создание сборки расширения](/slides/ru/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Интеграция расширения](/slides/ru/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

Функция пользовательского расширения позволяет вам добавлять дополнительные элементы или обновлять существующие элементы во время экспорта отчета.
## **Как создать сборку расширения**
1. Создайте проект .NET и добавьте ссылку на Aspose.Slides.ReportingServices.dll.
1. Добавьте класс и наследуйте его от Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Переопределите виртуальные методы класса, чтобы добавить пользовательскую функциональность.
### **Пример**
Предположим, мы хотим добавить заметку с текстом, логотип и обновить название компании для каждого отчета, экспортированного с помощью Aspose.Slides для RS.

Для этого мы добавляем следующий класс:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Добавить заметку на первый слайд

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("Это демонстрация расширения рендеринга для Aspose.Slides для ReportingServices",

textFormat);

}

//Показать логотип на каждом слайде в правом нижнем углу

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Добавить (TM) к любому упоминанию названия компании в отчете

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

Соберите его, и вы получите сборку расширения. Мы готовы интегрировать расширение.

{{% /alert %}} 

[Проект Visual Studio RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Интеграция расширения**
Предположим, что ваша сборка называется **TestSlidesRenderingExtension.dll**:

- Скопируйте сборку в директорию **bin** ReportingService рядом с Aspose.Slides.ReportingServices.dll. (Например: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Предоставьте разрешение FullTrust для вашей сборки, добавив следующую CodeGroup в **rssrvpolicy.config**:

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" />

...

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Эта кодовая группа предоставляет разрешение на выполнение кода MyComputer. ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

...

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="Эта кодовая группа предоставляет полный доступ к расширению рендеринга Aspose.Slides для Reporting Services.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

Обновите разделы конфигурации расширения Aspose.Slides в **rsreportserver.config**, чтобы включить ваше расширение.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Если вы хотите использовать расширение для каждого типа вывода, поддерживаемого Aspose.Slides, добавьте ту же конфигурацию к расширениям с названиями ASPPTX, ASPPT, ASPPS, ASPPSX.
Содержимое тега Extension является полным именем типа с указанием сборки. (См. <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Теперь перезапустите Reporting Services и экспортируйте отчет. Вы получите что-то вроде [этой презентации](attachments/10289195/10452997.pptx) из отчета Company Sales SQL2008R2 примеров Adventureworks.