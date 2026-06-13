---
title: ".NET में प्रभावी मेमोरी उपयोग के लिए प्रस्तुति BLOBs को प्रबंधित करें"
linktitle: "BLOB प्रबंधित करें"
type: docs
weight: 10
url: /hi/net/manage-blob/
keywords:
- बड़ा ऑब्जेक्ट
- बड़ी वस्तु
- बड़ी फ़ाइल
- BLOB जोड़ें
- BLOB निर्यात करें
- छवि को BLOB के रूप में जोड़ें
- मेमोरी कम करें
- मेमोरी उपभोग
- बड़ी प्रस्तुति
- टेम्पररी फ़ाइल
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में BLOB डेटा को प्रबंधित करें ताकि PowerPoint और OpenDocument फ़ाइल संचालन को सरल बनाया जा सके और कुशल प्रस्तुति हैंडलिंग हो सके."
---
## **सारांश**

Aspose.Slides प्रस्तुतियों में बड़े बाइनरी डेटा के लिए BLOB‑आधारित हैंडलिंग प्रदान करता है जिससे बड़े चित्रों, ऑडियो, वीडियो और प्रस्तुति फ़ाइलों के साथ काम करते समय मेमोरी उपयोग कम करने में सहायता मिलती है।

यह लेख दिखाता है कि BLOB‑आधारित प्रोसेसिंग का उपयोग करके प्रस्तुति में बड़े मीडिया को कैसे जोड़ा जाए, प्रस्तुति से बड़े मीडिया को कैसे एक्सपोर्ट किया जाए, और बड़े प्रस्तुतियों को अधिक कुशलता से कैसे लोड किया जाए। यह यह भी बताता है कि प्रोसेसिंग के दौरान टेम्पररी फ़ाइलों का उपयोग कैसे किया जा सकता है और उन्हें संग्रहीत करने वाले फ़ोल्डर को कैसे बदला जा सकता है।

## **BLOB के बारे में**

**BLOB** (**Binary Large Object**) आमतौर पर एक बड़ा आइटम (फ़ोटो, प्रस्तुति, दस्तावेज़, या मीडिया) होता है जिसे बाइनरी फ़ॉर्मेट में सहेजा जाता है।

Aspose.Slides for .NET आपको BLOB‑s का उपयोग ऐसे ऑब्जेक्ट्स के लिए करने की अनुमति देता है जिससे बड़े फ़ाइलों के साथ काम करते समय मेमोरी उपयोग कम हो जाता है।

## **BLOB का उपयोग करके मेमोरी उपयोग कम करें**

### **BLOB के माध्यम से प्रस्तुति में बड़ी फ़ाइल जोड़ें**

[Aspose.Slides](/slides/hi/net/) for .NET आपको बड़े फ़ाइलों (इस उदाहरण में एक बड़ी वीडियो फ़ाइल) को BLOB‑s से जुड़ी प्रक्रिया के माध्यम से जोड़ने की सुविधा देता है जिससे मेमोरी उपयोग कम हो जाता है।

यह C# दिखाता है कि कैसे BLOB प्रक्रिया के माध्यम से एक बड़ी वीडियो फ़ाइल को प्रस्तुति में जोड़ा जाए:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// एक नया प्रस्तुति बनाता है जिसमें वीडियो जोड़ा जाएगा
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // चलो वीडियो को प्रस्तुति में जोड़ते हैं - हमने KeepLocked व्यवहार चुना क्योंकि हम
        // व्यक्तिगत रूप से "veryLargeVideo.avi" फ़ाइल तक पहुंचने का इरादा नहीं रखते।
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // प्रस्तुति को सहेजता है। जबकि एक बड़ी प्रस्तुति आउटपुट होती है, मेमोरी उपभोग
        // pres ऑब्जेक्ट के जीवनचक्र के दौरान कम रहता है 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **प्रस्तुति से BLOB के माध्यम से बड़ी फ़ाइल एक्सपोर्ट करें**
Aspose.Slides for .NET आपको प्रस्तुतियों से BLOB‑s से जुड़ी प्रक्रिया के माध्यम से बड़ी फ़ाइलें (ऑडियो या वीडियो फ़ाइल) एक्सपोर्ट करने की अनुमति देता है। उदाहरण के लिए, आपको प्रस्तुति से एक बड़ी मीडिया फ़ाइल निकालनी हो लेकिन फ़ाइल को कंप्यूटर की मेमोरी में लोड नहीं करना चाहते। BLOB प्रक्रिया के माध्यम से फ़ाइल एक्सपोर्ट करने से मेमोरी उपयोग कम रहता है।

यह C# कोड वर्णित ऑपरेशन को दर्शाता है:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// सोर्स फ़ाइल को लॉक करता है और इसे मेमोरी में लोड नहीं करता
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// एक Presentation का इंस्टेंस बनाता है, "hugePresentationWithAudiosAndVideos.pptx" फ़ाइल को लॉक करता है।
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// आइए प्रत्येक वीडियो को एक फ़ाइल में सहेजते हैं। उच्च मेमोरी उपयोग को रोकने के लिए, हमें एक बफ़र की आवश्यकता है जिसका उपयोग प्रस्तुति के वीडियो स्ट्रीम से डेटा को नई बनाई गई वीडियो फ़ाइल के स्ट्रीम में स्थानांतरित करने के लिए किया जाएगा।
	// 
	byte[] buffer = new byte[8 * 1024];

	// वीडियो को इटरैट करता है
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// प्रेजेंटेशन वीडियो स्ट्रीम को खोलता है। कृपया नोट करें कि हमने जानबूझकर प्रॉपर्टी एक्सेस करने से बचाव किया है
		// जैसे video.BinaryData - क्योंकि यह प्रॉपर्टी एक बाइट एरे रिटर्न करती है जिसमें पूरा वीडियो होता है, जिससे
		// बाइट्स मेमोरी में लोड होते हैं। हम video.GetStream का उपयोग करते हैं, जो Stream रिटर्न करेगा - और नहीं
		// हमें पूरे वीडियो को मेमोरी में लोड करने की आवश्यकता पड़ती है।
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// वीडियो या प्रस्तुति के आकार की परवाह किए बिना मेमोरी उपभोग कम रहेगा,
	}

	// यदि आवश्यक हो, तो आप ऑडियो फ़ाइलों के लिए भी वही चरण लागू कर सकते हैं। 
}
```

### **प्रस्तुति में एक इमेज को BLOB के रूप में जोड़ें**
[IImageCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection) इंटरफ़ेस और [ImageCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imagecollection) क्लास की विधियों का उपयोग करके, आप बड़ी इमेज को स्ट्रीम के रूप में जोड़ सकते हैं ताकि इसे BLOB माना जाए।

यह C# कोड दिखाता है कि कैसे BLOB प्रक्रिया के माध्यम से बड़ी इमेज को जोड़ा जाए:

```c#
string pathToLargeImage = "large_image.jpg";

// एक नया प्रस्तुति बनाता है जिसमें छवि जोड़ी जाएगी।
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// चलो छवि को प्रस्तुति में जोड़ते हैं - हम KeepLocked व्यवहार चुनते हैं क्योंकि हम
		// "largeImage.png" फ़ाइल को एक्सेस करने का इरादा नहीं रखते।
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// प्रस्तुति को सहेजता है। जबकि बड़ी प्रस्तुति आउटपुट होती है, मेमोरी उपभोग 
		// pres ऑब्जेक्ट के जीवनचक्र के दौरान कम रहता है।
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **मेमोरी और बड़ी प्रस्तुतियाँ**

आमतौर पर, एक बड़ी प्रस्तुति लोड करने के लिए कंप्यूटर को बहुत अधिक टेम्पररी मेमोरी की आवश्यकता होती है। पूरी प्रस्तुति की सामग्री मेमोरी में लोड हो जाती है और वह फ़ाइल (जिससे प्रस्तुति लोड हुई थी) उपयोग में नहीं रहती।

एक बड़ी PowerPoint प्रस्तुति (large.pptx) पर विचार करें जिसमें 1.5 GB की वीडियो फ़ाइल हो। इस प्रस्तुति को लोड करने की मानक विधि नीचे दिए गए C# कोड में वर्णित है:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

लेकिन यह विधि लगभग 1.6 GB टेम्पररी मेमोरी का उपभोग करती है।

### **BLOB के रूप में बड़ी प्रस्तुति लोड करें**

BLOB‑संबंधी प्रक्रिया के माध्यम से, आप बड़ी प्रस्तुति को कम मेमोरी का उपयोग करके लोड कर सकते हैं। यह C# कोड दर्शाता है कि कैसे BLOB प्रक्रिया का उपयोग करके बड़ी प्रस्तुति फ़ाइल (large.pptx) लोड की जाती है:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **टेम्पररी फ़ाइलों के फ़ोल्डर को बदलें**

जब BLOB प्रक्रिया का उपयोग किया जाता है, आपका कंप्यूटर डिफ़ॉल्ट टेम्पररी फ़ाइल फ़ोल्डर में टेम्पररी फ़ाइलें बनाता है। यदि आप चाहते हैं कि टेम्पररी फ़ाइलें किसी अलग फ़ोल्डर में रखी जाएँ, तो आप `TempFilesRootPath` का उपयोग करके संग्रहण सेटिंग्स बदल सकते हैं:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
जब आप `TempFilesRootPath` का उपयोग करते हैं, Aspose.Slides स्वचालित रूप से टेम्पररी फ़ाइलों को संग्रहीत करने के लिए फ़ोल्डर नहीं बनाता। आपको फ़ोल्डर को मैन्युअल रूप से बनाना होगा।
{{% /alert %}}

### **मेमोरी मुक्त करने के लिए प्रस्तुति ऑब्जेक्ट को डिस्पोज़ करें**

बड़ी प्रस्तुतियों को प्रोसेस करते समय, सुनिश्चित करें कि [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को सही ढंग से डिस्पोज़ किया गया है ताकि वह मेमोरी मुक्त हो सके। अनुशंसित तरीका `using` स्टेटमेंट या डिक्लेरेशन का उपयोग करना है, जैसा कि ऊपर के उदाहरणों में दिखाया गया है; यह ब्लॉक के बाहर निकलते ही प्रस्तुति को स्वचालित रूप से डिस्पोज़ कर देता है और अनमैनेज्ड रिसोर्सेस को मुक्त करता है।

यदि आप `using` ब्लॉक के बिना प्रस्तुति बनाते हैं, तो समाप्त होने के बाद स्पष्ट रूप से `Dispose()` को कॉल करें।

```cs
Presentation presentation = new Presentation("large.pptx");

// ...प्रेजेंटेशन को प्रोसेस करें...
presentation.Save("large.pdf", SaveFormat.Pdf);

// स्पष्ट रूप से संसाधनों को रिलीज़ करें।
presentation.Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides प्रस्तुति में कौन सा डेटा BLOB माना जाता है और BLOB विकल्पों द्वारा नियंत्रित होता है?**  
इमेज, ऑडियो और वीडियो जैसे बड़े बाइनरी ऑब्जेक्ट्स BLOB के रूप में माने जाते हैं। पूरी प्रस्तुति फ़ाइल भी लोड या सेव करते समय BLOB हैंडलिंग में शामिल होती है। इन ऑब्जेक्ट्स पर BLOB नीतियों का प्रभाव होता है जो मेमोरी उपयोग को प्रबंधित करती हैं और आवश्यक होने पर टेम्पररी फ़ाइलों में स्वैप करती हैं।

**प्रेजेंटेशन लोड करते समय BLOB हैंडलिंग नियमों को कहाँ कॉन्फ़िगर कर सकता हूँ?**  
[LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) को [BlobManagementOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/blobmanagementoptions/) के साथ उपयोग करें। यहाँ आप BLOB के लिए इन‑मेमोरी सीमा सेट कर सकते हैं, टेम्पररी फ़ाइलों की अनुमति या निषेध कर सकते हैं, टेम्पररी फ़ाइलों के रूट पाथ को चुन सकते हैं, और सोर्स लॉकिंग व्यवहार को चयनित कर सकते हैं।

**क्या BLOB सेटिंग्स प्रदर्शन को प्रभावित करती हैं, और गति बनाम मेमोरी को कैसे संतुलित करें?**  
हां। BLOB को मेमोरी में रखने से गति अधिकतम होती है लेकिन RAM उपभोग बढ़ता है; मेमोरी सीमा को कम करने से अधिक काम टेम्पररी फ़ाइलों पर शिफ्ट हो जाता है, जिससे RAM कम उपयोग होती है लेकिन अतिरिक्त I/O लागत आती है। अपनी कार्यभार और वातावरण के अनुसार उचित संतुलन प्राप्त करने के लिए [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/hi/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) थ्रेशहोल्ड को ट्यून करें।

**क्या BLOB विकल्प बहुत बड़ी प्रस्तुतियों (जैसे गीगाबाइट्स) को खोलते समय मदद करते हैं?**  
हां। [BlobManagementOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/blobmanagementoptions/) विशेष रूप से ऐसे परिदृश्यों के लिए डिज़ाइन किए गए हैं: टेम्पररी फ़ाइलों को सक्षम करना और सोर्स लॉकिंग का उपयोग करना पीक RAM उपयोग को काफी हद तक कम कर सकता है और बहुत बड़ी डेक्स को स्थिर रूप से प्रोसेस करने में मदद करता है।

**क्या मैं डिस्क फ़ाइलों के बजाय स्ट्रीम से लोड करते समय BLOB नीतियों का उपयोग कर सकता हूँ?**  
हां। वही नियम स्ट्रीम पर भी लागू होते हैं: प्रस्तुति इंस्टेंस इनपुट स्ट्रीम को स्वामित्व ले सकता है और लॉक कर सकता है (चुने हुए लॉकिंग मोड के अनुसार), और अनुमति मिलने पर टेम्पररी फ़ाइलें उपयोग होती हैं, जिससे प्रोसेसिंग के दौरान मेमोरी उपयोग पूर्वानुमेय रहता है।