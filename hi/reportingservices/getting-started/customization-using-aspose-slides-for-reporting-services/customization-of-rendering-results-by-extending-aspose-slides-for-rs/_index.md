---
title: Aspose.Slides for RS को विस्तारित करके रेंडरिंग परिणामों का अनुकूलन
type: docs
weight: 10
url: /hi/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 
यह पृष्ठ Aspose.Slides for RS के लिए एक्सटेंशन बनाने की प्रक्रिया का वर्णन करता है।

- [एक्सटेंशन असेंबली बनाएँ](/slides/hi/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [एक्सटेंशन को एकीकृत करना](/slides/hi/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

कस्टम एक्सटेंशन सुविधा आपको रिपोर्ट निर्यात के दौरान अतिरिक्त तत्व जोड़ने या मौजूदा तत्वों को अपडेट करने का विकल्प देती है।
## **एक्सटेंशन असेंबली कैसे बनायें**
1. .NET प्रोजेक्ट बनाएं और Aspose.Slides.ReportingServices.dll का संदर्भ जोड़ें।
1. एक क्लास जोड़ें और उसे Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase से इनहेरिट करें।
1. कस्टम कार्यक्षमता जोड़ने के लिए क्लास के वर्चुअल मेथड्स को ओवरराइड करें।
### **उदाहरण**
मान लीजिए हम Aspose.Slides for RS से निर्यात किए गए प्रत्येक रिपोर्ट में कुछ टेक्स्ट के साथ एक नोट, एक लोगो जोड़ना और कंपनी का नाम अपडेट करना चाहते हैं।

इस उद्देश्य के लिए हम निम्नलिखित क्लास जोड़ते हैं:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//पहली स्लाइड में नोट जोड़ें

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//हर स्लाइड के नीचे दाएं कोने में लोगो दिखाएँ

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//रिपोर्ट में कंपनी नाम के किसी भी उल्लेख में (TM) जोड़ें

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
इसे बनाें और आपको एक्सटेंशन असेंबली मिलेगी। हम एक्सटेंशन को एकीकृत करने के लिए तैयार हैं।

{{% /alert %}} 

[RenderingExtensionDemo.zip का Visual Studio प्रोजेक्ट](attachments/10289195/10452998.zip)
### **एक्सटेंशन को एकीकृत करना**
मान लीजिए आपकी असेंबली का नाम **TestSlidesRenderingExtension.dll** है:

- असेंबली को ReportingService के **bin** डायरेक्टरी में Aspose.Slides.ReportingServices.dll के बगल में कॉपी करें। (उदाहरण: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- नीचे दिया गया CodeGroup **rssrvpolicy.config** में जोड़कर अपनी असेंबली को FullTrust अनुमति दें:

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

**rsreportserver.config** के Aspose.Slides रेंडरिंग एक्सटेंशन कॉन्फ़िग सेक्शन्स को अपडेट करें ताकि आपका एक्सटेंशन शामिल हो सके।

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

यदि आप Aspose.Slides द्वारा समर्थित प्रत्येक आउटपुट प्रकार के लिए एक्सटेंशन उपयोग करना चाहते हैं, तो ASPPTX, ASPPT, ASPPS, ASPPSX नाम वाले एक्सटेंशन्स में वही कॉन्फ़िग जोड़ें।  
Extension टैग की सामग्री प्रकार का assembly-qualified नाम होती है। (देखें <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

अब Reporting Services को पुनरारंभ करें और रिपोर्ट निर्यात करें। आपको Adventureworks सैंपल के Company Sales SQL2008R2 रिपोर्ट से इस प्रकार की प्रस्तुति मिलेगी [यह प्रस्तुति](attachments/10289195/10452997.pptx)।