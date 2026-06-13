---
title: C++ में कुशल मेमोरी उपयोग के लिए प्रस्तुति BLOB प्रबंधित करें
linktitle: BLOB प्रबंधित करें
type: docs
weight: 10
url: /hi/cpp/manage-blob/
keywords:
  - बड़ा ऑब्जेक्ट
  - बड़ा आइटम
  - बड़ी फ़ाइल
  - BLOB जोड़ें
  - BLOB निर्यात करें
  - छवि को BLOB के रूप में जोड़ें
  - मेमोरी कम करें
  - मेमोरी उपभोग
  - बड़ी प्रस्तुति
  - अस्थायी फ़ाइल
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - C++
  - Aspose.Slides
description: "C++ के लिए Aspose.Slides में BLOB डेटा का प्रबंधन करके PowerPoint और OpenDocument फ़ाइल संचालन को सुव्यवस्थित करें और कुशल प्रस्तुति हैंडलिंग सुनिश्चित करें."
---
## **अवलोकन**

Aspose.Slides बड़े बाइनरी डेटा को प्रस्तुतियों में संभालने के लिए BLOB-आधारित प्रोसेस प्रदान करता है जिससे बड़ी छवियों, ऑडियो, वीडियो और प्रस्तुति फ़ाइलों के साथ काम करते समय मेमोरी उपभोग कम करने में मदद मिलती है।

यह लेख दिखाता है कि BLOB-आधारित प्रोसेसिंग का उपयोग करके प्रस्तुति में बड़े मीडिया को कैसे जोड़ा जाए, प्रस्तुति से बड़े मीडिया को कैसे निर्यात किया जाए, और बड़े प्रस्तुतियों को अधिक कुशलता से कैसे लोड किया जाए। यह यह भी बताता है कि प्रोसेसिंग के दौरान अस्थायी फ़ाइलों का उपयोग कैसे किया जा सकता है और उन्हें संग्रहीत करने के लिए फ़ोल्डर को कैसे बदलें।

## **BLOB के बारे में**

**BLOB** (**Binary Large Object**) आमतौर पर एक बड़ा आइटम (फ़ोटो, प्रस्तुति, दस्तावेज़, या मीडिया) होता है जिसे बाइनरी फॉर्मेट में सहेजा जाता है।

Aspose.Slides for C++ आपको बड़े फ़ाइलों के साथ काम करते समय मेमोरी उपभोग कम करने के लिए ऑब्जेक्ट्स के लिए BLOB का उपयोग करने की सुविधा देता है।

## **मेमोरी उपभोग कम करने के लिए BLOB का उपयोग करें**

### **BLOB के माध्यम से प्रस्तुति में बड़ी फ़ाइल जोड़ें**

[Aspose.Slides](/slides/hi/cpp/) for C++ आपको BLOB प्रक्रिया के माध्यम से बड़ी फ़ाइलें (इस मामले में, एक बड़ी वीडियो फ़ाइल) जोड़ने की अनुमति देता है जिससे मेमोरी उपभोग कम हो जाता है।

यह C++ कोड दिखाता है कि BLOB प्रक्रिया के माध्यम से प्रस्तुति में बड़ी वीडियो फ़ाइल कैसे जोड़ी जाए:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// नई प्रस्तुति बनाता है जिसमें वीडियो जोड़ा जाएगा
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// आइए वीडियो को प्रस्तुति में जोड़ते हैं - हमने KeepLocked व्यवहार चुना है क्योंकि हम
// "veryLargeVideo.avi" फ़ाइल तक पहुँचने का इरादा नहीं रखते।
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// प्रस्तुति को सहेजता है। जबकि बड़ी प्रस्तुति आउटपुट होती है, मेमोरी उपभोग
// pres ऑब्जेक्ट के जीवनकाल में कम बना रहता है
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **BLOB के माध्यम से प्रस्तुति से बड़ी फ़ाइल निर्यात करें**
Aspose.Slides for C++ आपको प्रस्तुति से BLOB प्रक्रिया के माध्यम से बड़ी फ़ाइलें (जैसे ऑडियो या वीडियो फ़ाइल) निर्यात करने की सुविधा देता है। उदाहरण के तौर पर, आपको प्रस्तुति से एक बड़ी मीडिया फ़ाइल निकालनी हो सकती है लेकिन आप नहीं चाहते कि फ़ाइल आपके कंप्यूटर की मेमोरी में लोड हो। BLOB प्रक्रिया के माध्यम से फ़ाइल निर्यात करने से मेमोरी उपभोग कम रहता है।

यह C++ कोड दर्शाता है कि उपरोक्त कार्य कैसे किया जाता है:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// एक Presentation इंस्टेंस बनाता है, "hugePresentationWithAudiosAndVideos.pptx" फ़ाइल को लॉक करता है।

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// चलिए प्रत्येक वीडियो को एक फ़ाइल में सहेजते हैं। उच्च मेमोरी उपयोग को रोकने के लिए हमें एक बफ़र चाहिए जो उपयोग किया जाएगा
// प्रस्तुति के वीडियो स्ट्रीम से डेटा को नई बनाई गई वीडियो फ़ाइल के स्ट्रीम में स्थानांतरित करने के लिए।
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// वीडियो के माध्यम से इटरेट करता है
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// प्रस्तुति के वीडियो स्ट्रीम को खोलता है। कृपया ध्यान दें कि हमने जानबूझकर मेथड्स तक पहुँचने से बचा है
	// जैसे video->get_BinaryData - क्योंकि यह मेथड पूरी वीडियो युक्त बाइट ऐरे लौटाता है, जो फिर
	// बाइट्स को मेमोरी में लोड करता है। हम video->GetStream का उपयोग करते हैं, जो Stream लौटाएगा - और यह नहीं
	// पूरे वीडियो को मेमोरी में लोड करने की आवश्यकता रखता है।
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// मेमोरी उपभोग वीडियो या प्रस्तुति के आकार की परवाह किए बिना कम रहेगा,
}

// यदि आवश्यक हो, तो आप ऑडियो फ़ाइलों के लिए भी वही कदम लागू कर सकते हैं।
```

### **एक छवि को BLOB के रूप में प्रस्तुति में जोड़ें**
[IImageCollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_image_collection) इंटरफ़ेस और [ImageCollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.image_collection) क्लास की विधियों का उपयोग करके आप बड़ी छवि को एक स्ट्रीम के रूप में जोड़ सकते हैं ताकि उसे BLOB माना जाए।

यह C++ कोड दिखाता है कि BLOB प्रक्रिया के माध्यम से बड़ी छवि कैसे जोड़ी जाए:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// नई प्रस्तुति बनाता है जिसमें छवि जोड़ी जाएगी।
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// चलिए छवि को प्रस्तुति में जोड़ते हैं - हम KeepLocked व्यवहार चुनते हैं क्योंकि हम
// "largeImage.png" फ़ाइल तक पहुँचने का इरादा नहीं रखते।
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// प्रस्तुति को सहेजता है। जबकि एक बड़ी प्रस्तुति आउटपुट होती है, मेमोरी उपभोग 
// pres ऑब्जेक्ट के जीवनचक्र में कम रहता है
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **मेमोरी और बड़ी प्रस्तुतियां**

आमतौर पर, बड़ी प्रस्तुति लोड करने के लिए कंप्यूटर को बहुत सारी अस्थायी मेमोरी की आवश्यकता होती है। प्रस्तुति की पूरी सामग्री मेमोरी में लोड हो जाती है और वह फ़ाइल (जिससे प्रस्तुति लोड की गई थी) उपयोग में नहीं रहती।

एक बड़ी PowerPoint प्रस्तुति (large.pptx) पर विचार करें जिसमें 1.5 GB वीडियो फ़ाइल शामिल है। प्रस्तुति लोड करने की मानक विधि इस C++ कोड में वर्णित है:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

लेकिन यह विधि लगभग 1.6 GB अस्थायी मेमोरी का उपयोग करती है।

### **BLOB के रूप में बड़ी प्रस्तुति लोड करें**

BLOB प्रक्रिया के माध्यम से आप बड़ी प्रस्तुति को कम मेमोरी का उपयोग करके लोड कर सकते हैं। यह C++ कोड इस कार्यान्वयन को वर्णित करता है जहाँ BLOB प्रक्रिया का उपयोग करके बड़ी प्रस्तुति फ़ाइल (large.pptx) लोड की जाती है:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **अस्थायी फ़ाइलों के फ़ोल्डर को बदलें**

जब BLOB प्रक्रिया का उपयोग किया जाता है, आपका कंप्यूटर डिफ़ॉल्ट अस्थायी फ़ाइल फ़ोल्डर में अस्थायी फ़ाइलें बनाता है। यदि आप चाहते हैं कि अस्थायी फ़ाइलें किसी अन्य फ़ोल्डर में रखी जाएँ, तो आप `TempFilesRootPath` का उपयोग करके संग्रहण सेटिंग्स बदल सकते हैं:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
जब आप `TempFilesRootPath` का उपयोग करते हैं, तो Aspose.Slides स्वचालित रूप से अस्थायी फ़ाइलों को संग्रहीत करने के लिए कोई फ़ोल्डर नहीं बनाता। आपको फ़ोल्डर को स्वयं मैन्युअल रूप से बनाना होगा।
{{% /alert %}}

### **मेमोरी मुक्त करने के लिए प्रस्तुति ऑब्जेक्ट्स को डिस्पोज करें**

बड़ी प्रस्तुतियों को प्रोसेस करते समय सुनिश्चित करें कि [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को सही ढंग से डिस्पोज किया गया है जिससे वह उपयोग की गई मेमोरी मुक्त हो सके। प्रस्तुति के उपयोग को समाप्त करने के बाद `Dispose()` को कॉल करके अनमैनेज्ड संसाधनों को मुक्त करें।

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...process the presentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Explicitly release resources.
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides प्रस्तुति में कौन सा डेटा BLOB के रूप में माना जाता है और BLOB विकल्पों द्वारा नियंत्रित होता है?**  
छवियों, ऑडियो और वीडियो जैसी बड़ी बाइनरी ऑब्जेक्ट्स को BLOB माना जाता है। पूरी प्रस्तुति फ़ाइल भी लोड या सहेजते समय BLOB हैंडलिंग में शामिल होती है। इन ऑब्जेक्ट्स को BLOB नीतियों द्वारा नियंत्रित किया जाता है जो मेमोरी उपयोग और आवश्यक होने पर अस्थायी फ़ाइलों में स्पिल को प्रबंधित करती हैं।

**प्रस्तुति लोड करते समय BLOB हैंडलिंग नियमों को कहाँ कॉन्फ़िगर किया जाता है?**  
[LoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/) के साथ [BlobManagementOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/blobmanagementoptions/) का प्रयोग करें। यहाँ आप BLOB के लिए इन‑मेमोरी सीमा सेट कर सकते हैं, अस्थायी फ़ाइलों को सक्षम या अक्षम कर सकते हैं, अस्थायी फ़ाइलों के रूट पाथ को चुन सकते हैं, तथा स्रोत लॉकिंग व्यवहार को निर्धारित कर सकते हैं।

**क्या BLOB सेटिंग्स प्रदर्शन को प्रभावित करती हैं, और गति बनाम मेमोरी को कैसे संतुलित करें?**  
हां। मेमोरी में BLOB रखने से गति अधिकतम रहती है लेकिन RAM उपयोग बढ़ता है; मेमोरी सीमा को कम करने से अधिक काम अस्थायी फ़ाइलों पर जाता है, जिससे RAM कम उपयोग होती है लेकिन अतिरिक्त I/O का खर्च बढ़ता है। सही संतुलन पाने के लिए आप [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/hi/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) विधि का उपयोग कर सकते हैं।

**क्या अत्यधिक बड़ी प्रस्तुतियों (जैसे कई गीगाबाइट) को खोलते समय BLOB विकल्प मदद करते हैं?**  
हां। [BlobManagementOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/blobmanagementoptions/) ऐसे परिदृश्यों के लिए डिज़ाइन किए गए हैं: अस्थायी फ़ाइलों को सक्षम करना और स्रोत लॉकिंग का उपयोग करने से अधिकतम RAM उपयोग में काफी कमी आती है और बहुत बड़ी डेक्स को प्रोसेस करना स्थिर हो जाता है।

**क्या डिस्क फ़ाइलों के बजाय स्ट्रीम से लोड करते समय भी BLOB नीतियों का उपयोग कर सकता हूँ?**  
हां। वही नियम स्ट्रीम पर भी लागू होते हैं: प्रस्तुति इंस्टेंस इनपुट स्ट्रीम को (चयनित लॉकिंग मोड के आधार पर) स्वामित्व और लॉक कर सकता है, और जब अनुमति हो तो अस्थायी फ़ाइलों का उपयोग किया जाता है, जिससे प्रोसेसिंग के दौरान मेमोरी उपयोग पूर्वानुमानित रहता है।