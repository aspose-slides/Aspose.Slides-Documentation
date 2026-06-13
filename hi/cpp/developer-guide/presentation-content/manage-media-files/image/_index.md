---
title: C++ का उपयोग करके प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें
linktitle: छवियों का प्रबंधन करें
type: docs
weight: 10
url: /hi/cpp/image/
keywords:
- छवि जोड़ें
- चित्र जोड़ें
- बिटमैप जोड़ें
- छवि बदलें
- चित्र बदलें
- वेब से
- पृष्ठभूमि
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- EMF जोड़ें
- WMF जोड़ें
- TIFF जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- EMF
- SVG
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument में छवि प्रबंधन को सरल बनाएं, प्रदर्शन को अनुकूलित करें और कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को अधिक आकर्षक और रोचक बनाती हैं। Microsoft PowerPoint में आप फ़ाइल, इंटरनेट या अन्य स्थानों से चित्रों को स्लाइडों पर डाल सकते हैं। इसी प्रकार, Aspose.Slides आपको अपने प्रस्तुतियों में विभिन्न प्रक्रियाओं के माध्यम से स्लाइडों में छवियां जोड़ने की सुविधा देता है।

{{% alert title="Tip" color="primary" %}} 

Aspose मुफ्त कन्वर्टर—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—प्रदान करता है, जो लोगों को छवियों से जल्दी प्रस्तुतियां बनाने में मदद करता है। 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

यदि आप किसी छवि को फ्रेम ऑब्जेक्ट के रूप में जोड़ना चाहते हैं—विशेष रूप से जब आप उस पर मानक फ़ॉर्मेटिंग विकल्पों का उपयोग करके उसकी आकार बदलना, प्रभाव जोड़ना आदि चाहते हैं—तो देखें [Picture Frame](/slides/hi/cpp/picture-frame/)। 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

आप छवियों और PowerPoint प्रस्तुतियों से संबंधित इनपुट/आउटपुट ऑपरेशनों को नियंत्रित करके एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में छवि को परिवर्तित कर सकते हैं। इन पृष्ठों को देखें: convert [image to JPG](https://products.aspose.com/slides/hi/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides इन लोकप्रिय फ़ॉर्मेट्स—JPEG, PNG, GIF और अन्य—में छवियों के साथ ऑपरेशनों को समर्थन देता है। 

## **स्थानीय रूप से संग्रहीत छवियों को स्लाइड्स में जोड़ें**

आप अपने कंप्यूटर की एक या कई छवियों को प्रस्तुतिकरण की स्लाइड पर जोड़ सकते हैं। यह C++ कोड नमूना आपको दिखाता है कि स्लाइड में छवि कैसे जोड़ें:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **वेब से छवियों को स्लाइड्स में जोड़ें**

यदि वह छवि जो आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर पर उपलब्ध नहीं है, तो आप सीधे वेब से छवि जोड़ सकते हैं। 

यह C++ कोड नमूना आपको दिखाता है कि वेब से छवि को स्लाइड में कैसे जोड़ें:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **स्लाइड मास्टर में छवियों को जोड़ें**

स्लाइड मास्टर वह शीर्ष स्लाइड है जो उसके नीचे सभी स्लाइडों की थीम, लेआउट आदि की जानकारी संग्रहीत और नियंत्रित करता है। इसलिए जब आप स्लाइड मास्टर में छवि जोड़ते हैं, तो वह छवि उस स्लाइड मास्टर के तहत सभी स्लाइडों पर दिखाई देती है। 

यह C++ कोड नमूना आपको दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ें:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **स्लाइड बैकग्राउंड के रूप में छवियों को जोड़ें**

आप किसी विशिष्ट स्लाइड या कई स्लाइडों के लिए पृष्ठभूमि के रूप में एक तस्वीर का उपयोग कर सकते हैं। ऐसे मामलों में, आपको देखना चाहिए *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/hi/cpp/presentation-background/#setting-images-as-background-for-slides)*।

## **प्रेज़ेंटेशन में SVG जोड़ें**
आप किसी भी छवि को प्रेज़ेंटेशन में जोड़ या सम्मिलित कर सकते हैं, यदि आप [AddPictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) मेथड का उपयोग करते हैं, जो [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape_collection) इंटरफ़ेस से संबंधित है।

SVG छवि के आधार पर एक इमेज ऑब्जेक्ट बनाने के लिए, आप इसे इस प्रकार कर सकते हैं:

1. ImageShapeCollection में सम्मिलित करने के लिए SvgImage ऑब्जेक्ट बनाएं
2. ISvgImage से PPImage ऑब्जेक्ट बनाएं
3. IPPImage इंटरफ़ेस का उपयोग करके PictureFrame ऑब्जेक्ट बनाएं

यह कोड नमूना आपको दिखाता है कि ऊपर बताए गये चरणों को लागू करके SVG छवि को प्रेज़ेंटेशन में कैसे जोड़ें:
``` cpp 
// दस्तावेज़ निर्देशिका का पथ
System::String dataDir = u"D:\\Documents\\";

// स्रोत SVG फ़ाइल का नाम
System::String svgFileName = dataDir + u"sample.svg";

// आउटपुट प्रस्तुति फ़ाइल का नाम
System::String outPptxPath = dataDir + u"presentation.pptx";

// नई प्रस्तुति बनाएं
auto p = System::MakeObject<Presentation>();

// SVG फ़ाइल की सामग्री पढ़ें
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage ऑब्जेक्ट बनाएं
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// PPImage ऑब्जेक्ट बनाएं
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// एक नया PictureFrame बनाता है 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// PPTX फ़ॉर्मेट में प्रस्तुति सहेजें
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **SVG को शैप्स के सेट में परिवर्तित करें**
Aspose.Slides का SVG को शैप्स के सेट में परिवर्तन PowerPoint की उस विशेषता के समान है जो SVG छवियों के साथ काम करने के लिए प्रयोग की जाती है:

![PowerPoint Popup Menu](img_01_01.png)

यह सुविधा [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape_collection) इंटरफ़ेस के [AddGroupShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) मेथड के एक ओवरलोड द्वारा प्रदान की जाती है, जो पहला आर्ग्युमेंट के रूप में एक [ISvgImage](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_svg_image) ऑब्जेक्ट लेती है।

यह कोड नमूना आपको दिखाता है कि वर्णित मेथड का उपयोग करके SVG फ़ाइल को शैप्स के सेट में कैसे परिवर्तित करें:

``` cpp 
// दस्तावेज़ निर्देशिका का पथ
System::String dataDir = u"D:\\Documents\\";

// स्रोत SVG फ़ाइल का नाम
System::String svgFileName = dataDir + u"sample.svg";

// आउटपुट प्रस्तुति फ़ाइल का नाम
System::String outPptxPath = dataDir + u"presentation.pptx";

// नई प्रस्तुति बनाएँ
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// SVG फ़ाइल की सामग्री पढ़ें
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage ऑब्जेक्ट बनाएं
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// स्लाइड आकार प्राप्त करें
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// SVG छवि को आकार बदलकर स्लाइड आकार के अनुसार शैप्स के समूह में बदलें
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// PPTX फॉर्मेट में प्रस्तुति सहेजें
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **स्लाइड्स में EMF के रूप में छवियों को जोड़ें**
Aspose.Slides for C++ आपको एक्सेल शीट्स से EMF छवियां जनरेट करने और Aspose.Cells के साथ इन छवियों को स्लाइड्स में EMF के रूप में जोड़ने की अनुमति देता है। 

यह कोड नमूना आपको दिखाता है कि वर्णित कार्य कैसे करें:

``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

## **इमेज कलेक्शन में छवियों को बदलें**

Aspose.Slides आपको प्रस्तुति के इमेज कलेक्शन (जिसमें स्लाइड शैप्स द्वारा उपयोग की गई छवियां भी शामिल हैं) में संग्रहीत छवियों को बदलने की सुविधा देता है। यह अनुभाग कलेक्शन में छवियों को अपडेट करने के कई तरीके दर्शाता है। API सीधी विधियां प्रदान करती है जिससे आप रॉ बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद किसी अन्य छवि का उपयोग करके छवि बदल सकते हैं।

नीचे दिए गए चरणों का पालन करें:

1. उस प्रस्तुति फ़ाइल को लोड करें जिसमें छवियां हैं, इसके लिए [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उपयोग करें।
2. फ़ाइल से नई छवि को बाइट एरे में लोड करें।
3. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
4. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।
5. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति के इमेज कलेक्शन में पहले से मौजूद किसी छवि से बदलें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```cpp
// ऐसी प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// पहला तरीका।
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// दूसरा तरीका।
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// तीसरा तरीका।
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// प्रस्तुति को फ़ाइल में सहेजें।
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Aspose FREE [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कन्वर्टर का उपयोग करके आप आसानी से टेक्स्ट को एनिमेट कर सकते हैं, टेक्स्ट से GIF बना सकते हैं आदि। 

{{% /alert %}}

## **FAQ**

**क्या मूल छवि का रिज़ॉल्यूशन सम्मिलन के बाद भी बना रहता है?**

हाँ। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम स्वरूप इस बात पर निर्भर करता है कि स्लाइड पर [चित्र](/slides/hi/cpp/picture-frame/) को कैसे स्केल किया गया है और सहेजते समय कौन सा संपीड़न लागू किया गया है।

**कई स्लाइडों में एक ही लोगो को एक साथ बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और उसे प्रस्तुति के इमेज कलेक्शन में बदलें—परिवर्तन सभी उन तत्वों में प्रसारित हो जाएंगे जो उस संसाधन का उपयोग करते हैं।

**क्या सम्मिलित SVG को संपादन योग्य शैप्स में परिवर्तित किया जा सकता है?**

हाँ। आप एक SVG को शैप्स के समूह में बदल सकते हैं, जिसके बाद व्यक्तिगत भाग मानक शैप गुणों के साथ संपादन योग्य हो जाते हैं।

**मैं कई स्लाइडों के लिए एक साथ पृष्ठभूमि के रूप में चित्र कैसे सेट कर सकता हूं?**

[चित्र को पृष्ठभूमि के रूप में असाइन करें](/slides/hi/cpp/presentation-background/) मास्टर स्लाइड या संबंधित लेआउट पर—जो भी स्लाइडें उस मास्टर/लेआउट का उपयोग करती हैं, वे पृष्ठभूमि को विरासत में प्राप्त करेंगी।

**मैं प्रस्तुति के आकार के अत्यधिक बढ़ने से कैसे बच सकता हूं जब कई चित्र हों?**

एक ही छवि संसाधन को पुन: उपयोग करें, अनावश्यक प्रतियों से बचें, उचित रिज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उपयुक्त हो, दोहराव वाले ग्राफिक्स को मास्टर पर रखें।