---
title: उपयोगकर्ता द्वारा परिभाषित आयाम द्वारा टिफ़ के रूप में रेंडर किया गया
type: docs
weight: 40
url: /hi/net/rendered-as-tiff-by-user-defined-dimension/
---
निम्नलिखित उदाहरण दिखाता है कि कैसे एक प्रस्तुति को कस्टमाइज़्ड इमेज साइज का उपयोग करके **TiffOptions** क्लास के साथ TIFF दस्तावेज़ में परिवर्तित किया जा सकता है।

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//एक Presentation ऑब्जेक्ट बनाता है जो एक Presentation फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation(srcFileName);

//TiffOptions क्लास को instantiate करता है
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//कम्प्रेशन प्रकार सेट करना
opts.CompressionType = TiffCompressionTypes.Default;

//कम्प्रेशन प्रकार
//Default - डिफ़ॉल्ट कम्प्रेशन स्कीम (LZW) निर्दिष्ट करता है।
//None - कोई कम्प्रेशन नहीं निर्दिष्ट करता है.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - कम्प्रेशन प्रकार पर निर्भर करता है और मैन्युअल रूप से सेट नहीं किया जा सकता।
//Resolution unit - हमेशा "2" के बराबर होता है (डॉट्स प्रति इंच)
//इमेज DPI सेट करना
opts.DpiX = 200;

opts.DpiY = 100;

//इमेज साइज सेट करें
opts.ImageSize = new Size(1728, 1078);

//निर्दिष्ट इमेज साइज के साथ प्रस्तुति को TIFF में सहेजें
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **नमूना कोड डाउनलोड करें**
- [गिटहब](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [बिटबकेट](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)