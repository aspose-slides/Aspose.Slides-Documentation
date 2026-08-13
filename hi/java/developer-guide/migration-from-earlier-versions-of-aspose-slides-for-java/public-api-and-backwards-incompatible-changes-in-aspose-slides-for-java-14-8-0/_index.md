---
title: Aspose.Slides for Java 14.8.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for Java 14.8.0
type: docs
weight: 70
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- स्थानांतरण
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुचारू रूप से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 
यह पृष्ठ Aspose.Slides for Java 14.8.0 API के साथ प्रस्तुत किए गए सभी [added](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) वर्गों, विधियों, गुणों आदि, किसी भी नए प्रतिबंधों और अन्य [changes](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) की सूची देता है।
{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), और setOverlap(byte) मेथड्स जोड़े गए**
Aspose.Slides.Charts.IChartSeries.getOverlap() निर्धारित करता है कि 2D चार्ट्स पर बार और कॉलम कितनी ओवरलैप (एक -100 से 100 तक की सीमा में) करेंगे। यह मेथड केवल विशिष्ट श्रृंखला के लिए नहीं, बल्कि मूल श्रृंखला समूह की सभी श्रृंखलाओं के लिए है - यह उपयुक्त समूह गुण का प्रक्षेपण है।

- IChartSeries.getParentSeriesGroup() मेथड का उपयोग करके मूल श्रृंखला समूह तक पहुँचें।
- IChartSeriesGroup.getOverlap() और setOverlap(byte) मेथड्स का उपयोग करके मान को प्रबंधित करें।

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **ShapeThumbnailBounds.Appearance Enum मान जोड़ा गया**
शेप थंबनेल बनाते समय यह मेथड डेवलपर्स को उसके रूप की सीमाओं में शेप थंबनेल उत्पन्न करने की अनुमति देता है। यह सभी शेप प्रभावों को ध्यान में रखता है। उत्पन्न शेप थंबनेल स्लाइड की सीमाओं द्वारा प्रतिबंधित होता है।

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **VbaProject क्लास और IVbaProject इंटरफ़ेस जोड़े गए, Presentation.getVbaProject() और setVbaProject(VbaProject) मेथड्स में परिवर्तन किए गए**
एक नई सुविधा डेवलपर्स को प्रस्तुति में VBA प्रोजेक्ट बनाने और संपादित करने की अनुमति देती है।

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// नया VBA प्रोजेक्ट बनाएं

pres.setVbaProject(new VbaProject());

// VBA प्रोजेक्ट में खाली मॉड्यूल जोड़ें

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// मॉड्यूल स्रोत कोड सेट करें

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// <stdole> के लिए संदर्भ बनाएं

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office के लिए संदर्भ बनाएं

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA प्रोजेक्ट में संदर्भ जोड़ें

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);

```