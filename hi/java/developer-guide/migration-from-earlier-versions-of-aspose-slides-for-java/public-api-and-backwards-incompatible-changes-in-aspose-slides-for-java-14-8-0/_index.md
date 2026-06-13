---
title: Aspose.Slides for Java 14.8.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for Java 14.8.0
type: docs
weight: 70
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- स्थांतरण
- पुराना कोड
- आधुनिक कोड
- पुराना दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को आसानी से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) क्लास, मेथड, प्रॉपर्टी आदि, नई प्रतिबंधों और अन्य [बदलाव](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) को दर्शाता है जो Aspose.Slides for Java 14.8.0 API के साथ प्रस्तुत किए गए हैं।

{{% /alert %}} 
## **पब्लिक API परिवर्तन**
### **Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() और setOverlap(byte) मेथड्स जोड़े गए**
Aspose.Slides.Charts.IChartSeries.getOverlap() 2D चार्ट्स पर बार और कॉलम कितनी ओवरलैप होंगी, इसे -100 से 100 तक की रेंज में प्राप्त करता है। यह मेथड केवल विशिष्ट सीरीज़ के लिए नहीं बल्कि पैरेंट सीरीज़ ग्रुप की सभी सीरीज़ के लिए लागू होता है – यह उपयुक्त ग्रुप प्रॉपर्टी का प्रोजेक्शन है।

- पैरेंट सीरीज़ ग्रुप तक पहुँचने के लिए IChartSeries.getParentSeriesGroup() मेथड का उपयोग करें।
- मान को प्रबंधित करने के लिए IChartSeriesGroup.getOverlap() और setOverlap(byte) मेथड्स का उपयोग करें।

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **ShapeThumbnailBounds.Appearance एनम वैल्यू जोड़ी गई**
यह मेथड शैप थंबनेल बनाने का तरीका डेवलपर्स को शैप की अपीयरेंस की सीमा में थंबनेल जनरेट करने की अनुमति देता है। यह सभी शैप इफ़ेक्ट्स को ध्यान में रखता है। उत्पन्न शैप थंबनेल स्लाइड की सीमाओं द्वारा सीमित रहता है।

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **VbaProject क्लास और IVbaProject इंटरफ़ेस जोड़े गए, Presentation.getVbaProject() और setVbaProject(VbaProject) मेथड्स बदले गए**
एक नई सुविधा डेवलपर्स को प्रस्तुति में VBA प्रोजेक्ट बनाने और संपादित करने की अनुमति देती है।

``` java

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

pres.save("data\\test.pptm", SaveFormat.Pptm);

```