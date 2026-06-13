---
title: प्रस्तुतियों में Python के साथ BLOBs को प्रबंधित करें प्रभावी मेमोरी उपयोग के लिए
linktitle: BLOB प्रबंधन
type: docs
weight: 10
url: /hi/python-net/manage-blob/
keywords:
- बड़ा ऑब्जेक्ट
- बड़ा आइटम
- बड़ी फ़ाइल
- BLOB जोड़ें
- BLOB निर्यात करें
- छवि को BLOB के रूप में जोड़ें
- मेमोरी कम करें
- मेमोरी खपत
- बड़ी प्रस्तुति
- अस्थायी फ़ाइल
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के लिए Python via .NET में BLOB डेटा को प्रबंधित करें जिससे PowerPoint और OpenDocument फ़ाइल संचालन को सरल बनाया जा सके और प्रभावी प्रस्तुति हैंडलिंग हो।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुतियों में बड़े बाइनरी डेटा के लिए BLOB-आधारित हैंडलिंग प्रदान करता है ताकि बड़े चित्रों, ऑडियो, वीडियो और प्रस्तुति फ़ाइलों के साथ काम करते समय मेमोरी खपत को कम किया जा सके।

यह लेख दिखाता है कि बड़े मीडिया को प्रस्तुति में जोड़ने, प्रस्तुति से बड़े मीडिया को निर्यात करने और बड़ी प्रस्तुतियों को अधिक कुशलता से लोड करने के लिए BLOB-आधारित प्रोसेसिंग का कैसे उपयोग किया जाए। यह यह भी समझाता है कि प्रोसेसिंग के दौरान अस्थायी फ़ाइलें कैसे उपयोग की जा सकती हैं और उन्हें संग्रहीत करने वाले फ़ोल्डर को कैसे बदला जाए।

## **BLOB के बारे में**

**BLOB** (**Binary Large Object**) आमतौर पर एक बड़ा आइटम (फ़ोटो, प्रस्तुति, दस्तावेज़, या मीडिया) होता है जो बाइनरी फ़ॉर्मेट में संग्रहीत किया जाता है।

Aspose.Slides for Python via .NET आपको बड़े फ़ाइलों के शामिल होने पर मेमोरी खपत को कम करने के तरीके से ऑब्जेक्ट्स के लिए BLOB का उपयोग करने की अनुमति देता है।

## **Memory Consumption घटाने के लिए BLOB का उपयोग करें**

### **BLOB के माध्यम से बड़े फ़ाइल को प्रस्तुति में जोड़ें**

[Aspose.Slides](/slides/hi/python-net/) for .NET आपको मेमोरी खपत को कम करने के लिए BLOB शामिल प्रक्रिया के माध्यम से बड़े फ़ाइलों (इस मामले में एक बड़ा वीडियो फ़ाइल) को जोड़ने की अनुमति देती है।

यह Python दिखाता है कि BLOB प्रक्रिया के माध्यम से बड़े वीडियो फ़ाइल को प्रस्तुति में कैसे जोड़ें:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# एक नई प्रस्तुति बनाता है जिसमें वीडियो जोड़ा जाएगा
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # आइए वीडियो को प्रस्तुति में जोड़ते हैं - हमने KeepLocked व्यवहार चुना क्योंकि हम
        # उद्देश्य नहीं है कि "veryLargeVideo.avi" फ़ाइल तक पहुंचें।
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # प्रस्तुति को सहेजता है। जबकि एक बड़ी प्रस्तुति आउटपुट की जाती है, मेमोरी खपत
        # pres ऑब्जेक्ट के जीवनचक्र के दौरान कम रहती है
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **BLOB के माध्यम से प्रस्तुतिकरण से बड़े फ़ाइल को निर्यात करें**
Aspose.Slides for Python via .NET आपको प्रस्तुतियों से BLOB शामिल प्रक्रिया के माध्यम से बड़े फ़ाइलों (जैसे ऑडियो या वीडियो फ़ाइल) को निर्यात करने की अनुमति देती है। उदाहरण के लिए, आपको प्रस्तुति से एक बड़ी मीडिया फ़ाइल निकालनी पड़ सकती है लेकिन आप नहीं चाहते कि फ़ाइल आपके कंप्यूटर की मेमोरी में लोड हो। BLOB प्रक्रिया के माध्यम से फ़ाइल निर्यात करके आप मेमोरी खपत को कम रख सकते हैं।

यह Python कोड वर्णित ऑपरेशन को दर्शाता है:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# प्रत्येक वीडियो को फ़ाइल में सहेजते हैं। उच्च मेमोरी उपयोग से बचने के लिए, हमें एक बफ़र चाहिए जिसका उपयोग किया जाएगा
	# प्रस्तुति के वीडियो स्ट्रीम से डेटा को नई बनाई गई वीडियो फ़ाइल के स्ट्रीम में स्थानांतरित करने के लिए।
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# वीडियो पर इटरशन करता है
    index = 0
    # यदि आवश्यक हो, आप ऑडियो फ़ाइलों के लिए भी वही चरण लागू कर सकते हैं। 
    for video in pres.videos:
		# प्रस्तुति वीडियो स्ट्रीम खोलता है। कृपया ध्यान दें कि हमने जानबूझकर प्रॉपर्टीज़ तक पहुँचने से बचा
		# जैसे video.BinaryData - क्योंकि यह प्रॉपर्टी पूरी वीडियो वाला बाइट ऐरे लौटाता है, जो फिर
		# मेमोरी में बाइट्स लोड होने का कारण बनता है। हम video.GetStream का उपयोग करते हैं, जो Stream लौटाता है - और यह
		#  मेमोरी में पूरी वीडियो लोड करने की आवश्यकता नहीं रखता।
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **प्रस्तुति में BLOB के रूप में छवि जोड़ें**
[**ImageCollection**](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/) क्लास की विधियों का उपयोग करके आप एक बड़ी छवि को स्ट्रीम के रूप में जोड़ सकते हैं जिससे वह BLOB के रूप में माना जाता है।

यह Python कोड दिखाता है कि BLOB प्रक्रिया के माध्यम से बड़ी छवि को कैसे जोड़ें:

```py
import aspose.slides as slides

# नई प्रस्तुति बनाता है जिसमें छवि जोड़ी जाएगी।
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Memory और बड़े प्रस्तुतिकरण**

आमतौर पर, बड़ी प्रस्तुति को लोड करने के लिए कंप्यूटरों को बहुत अधिक अस्थायी मेमोरी की आवश्यकता होती है। प्रस्तुति की सभी सामग्री मेमोरी में लोड हो जाती है और वह फ़ाइल (जिससे प्रस्तुति लोड हुई थी) उपयोग में नहीं रहती।

एक बड़ी PowerPoint प्रस्तुति (large.pptx) पर विचार करें जिसमें 1.5 GB वीडियो फ़ाइल है। प्रस्तुति को लोड करने की मानक विधि इस Python कोड में वर्णित है:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

लेकिन यह विधि लगभग 1.6 GB अस्थायी मेमोरी उपभोग करती है।

### **BLOB के रूप में बड़े प्रस्तुतिकरण को लोड करें**
BLOB शामिल प्रक्रिया के माध्यम से आप कम मेमोरी का उपयोग करके बड़ी प्रस्तुति को लोड कर सकते हैं। यह Python कोड उस कार्यान्वयन को दर्शाता है जहाँ BLOB प्रक्रिया का उपयोग करके बड़ी प्रस्तुति फ़ाइल (large.pptx) को लोड किया जाता है:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **अस्थायी फ़ाइलों के फ़ोल्डर को बदलें**
जब BLOB प्रक्रिया का उपयोग किया जाता है, आपका कंप्यूटर डिफ़ॉल्ट अस्थायी फ़ाइल फ़ोल्डर में अस्थायी फ़ाइलें बनाता है। यदि आप चाहते हैं कि अस्थायी फ़ाइलें किसी अलग फ़ोल्डर में रखी जाएँ, तो आप `temp_files_root_path` का उपयोग करके स्टोरेज सेटिंग्स बदल सकते हैं:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
जब आप `temp_files_root_path` का उपयोग करते हैं, तो Aspose.Slides स्वचालित रूप से अस्थायी फ़ाइलों को संग्रहीत करने के लिए फ़ोल्डर नहीं बनाता। आपको फ़ोल्डर मैन्युअल रूप से बनाना होगा। 
{{% /alert %}}

### **मेमोरी मुक्त करने के लिए प्रस्तुति ऑब्जेक्ट्स को डिस्पोज़ करें**
बड़ी प्रस्तुतियों को प्रोसेस करते समय सुनिश्चित करें कि [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस को सही ढंग से डिस्पोज़ किया गया है ताकि वह उपयोग की हुई मेमोरी मुक्त हो सके। अनुशंसित तरीका है कि ऊपर दिखाए गए उदाहरणों की तरह कॉन्टेक्स्ट मैनेजर (`with slides.Presentation(...) as presentation:`) का उपयोग करें; यह ब्लॉक समाप्त होने पर स्वचालित रूप से प्रस्तुति को बंद कर देता है और अनमैनेज्ड रिसोर्सेज़ को मुक्त कर देता है।

यदि आप `with` ब्लॉक के बिना प्रस्तुति बनाते हैं, तो उपयोग समाप्त होने के बाद स्पष्ट रूप से `presentation.dispose()` कॉल करें, और किसी भी शेष रेफ़रेंस को हटा दें ताकि Python का गार्बेज कलेक्टर मेमोरी को पुनः प्राप्त कर सके।

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...प्रस्तुति को प्रोसेस करें...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# स्पष्ट रूप से संसाधनों को रिलीज़ करें।
presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides प्रस्तुति में कौन सा डेटा BLOB के रूप में माना जाता है और BLOB विकल्पों द्वारा नियंत्रित होता है?**  
छवियों, ऑडियो और वीडियो जैसे बड़े बाइनरी ऑब्जेक्ट्स BLOB के रूप में माने जाते हैं। पूरी प्रस्तुति फ़ाइल भी लोड या सेव करते समय BLOB हैंडलिंग में शामिल होती है। इन ऑब्जेक्ट्स को BLOB नीतियों द्वारा नियंत्रित किया जाता है जो मेमोरी उपयोग और आवश्यकतानुसार अस्थायी फ़ाइलों में स्पिल को प्रबंधित करती हैं।

**प्रस्तुति लोड करते समय BLOB हैंडलिंग नियम कहाँ कॉन्फ़िगर करूँ?**  
[LoadOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/) को [BlobManagementOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/blobmanagementoptions/) के साथ उपयोग करें। यहाँ आप BLOB के लिए इन‑मेमोरी सीमा सेट कर सकते हैं, अस्थायी फ़ाइलों को अनुमति या प्रतिबंधित कर सकते हैं, अस्थायी फ़ाइलों के रूट पाथ को चुन सकते हैं, और स्रोत लॉकिंग व्यवहार को निर्दिष्ट कर सकते हैं।

**क्या BLOB सेटिंग्स प्रदर्शन को प्रभावित करती हैं, और गति बनाम मेमोरी को कैसे संतुलित करूँ?**  
हां। मेमोरी में BLOB रखना गति को अधिकतम करता है लेकिन RAM उपयोग बढ़ाता है; मेमोरी सीमा को घटाने से अधिक कार्य अस्थायी फ़ाइलों पर शिफ्ट हो जाता है, जिससे RAM कम होती है लेकिन अतिरिक्त I/O लागत आती है। सही संतुलन पाने के लिए [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/hi/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) थ्रेशहोल्ड को समायोजित करें।

**क्या अत्यधिक बड़ी प्रस्तुतियों (उदाहरण के लिए गीगाबाइट‑साइज़) को खोलते समय BLOB विकल्प मदद करते हैं?**  
हां। [BlobManagementOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/blobmanagementoptions/) ऐसे परिदृश्यों के लिए बनाई गई हैं: अस्थायी फ़ाइलें सक्षम करना और स्रोत लॉकिंग का उपयोग करने से पीक RAM उपयोग को काफी हद तक घटाया जा सकता है और बहुत बड़ी डेक की प्रोसेसिंग स्थिर हो जाती है।

**क्या मैं डिस्क फ़ाइलों के बजाय स्ट्रीम से लोड करते समय BLOB नीतियों का उपयोग कर सकता हूँ?**  
हां। वही नियम स्ट्रीम पर भी लागू होते हैं: प्रस्तुति इंस्टेंस इनपुट स्ट्रीम को (चुनी गई लॉकिंग मोड के आधार पर) स्वामित्व में ले सकता है और लॉक कर सकता है, और जब अनुमति हो तो अस्थायी फ़ाइलें उपयोग की जाती हैं, जिससे प्रोसेसिंग के दौरान मेमोरी उपयोग पूर्वानुमानित रहता है।