---
title: स्लाइड को SVG छवि के रूप में बनाएं
type: docs
weight: 70
url: /hi/net/create-slide-as-svg-image/
---
Aspose.Slides.Pptx for .NET का उपयोग करके किसी भी इच्छित स्लाइड से SVG छवि उत्पन्न करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक इंस्टेंस बनाएं।
- इच्छित स्लाइड का संदर्भ उसके ID या इंडेक्स का उपयोग करके प्राप्त करें।
- SVG छवि को मेमोरी स्ट्रीम में प्राप्त करें।
- मेमोरी स्ट्रीम को फ़ाइल में सहेजें।
## **उदाहरण**

```

 //एक Presentation क्लास को इंस्टैंशिएट करें जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //दूसरी स्लाइड तक पहुँचें

   ISlide sld = pres.Slides[1];

   //एक मेमोरी स्ट्रीम ऑब्जेक्ट बनाएं

   MemoryStream SvgStream = new MemoryStream();

   //स्लाइड की SVG छवि जनरेट करें और मेमोरी स्ट्रीम में सहेजें

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //मेमोरी स्ट्रीम को फ़ाइल में सहेजें

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

}

SvgStream.Close();

``` 
## **चल रहे उदाहरण को डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

अधिक विवरण के लिए, देखें [Render Presentation Slides as SVG Images in .NET](/slides/hi/net/render-a-slide-as-an-svg-image/).

{{% /alert %}}