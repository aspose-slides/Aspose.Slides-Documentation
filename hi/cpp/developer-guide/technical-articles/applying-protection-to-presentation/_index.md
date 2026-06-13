---
title: आकार लॉक के साथ प्रस्तुति संपादन को रोकें
linktitle: प्रस्तुति संपादन रोकें
type: docs
weight: 10
url: /hi/cpp/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षा
- आकार लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार को लॉक करें
- समूह को लॉक करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "जानेँ कैसे Aspose.Slides for C++ PPT, PPTX और ODP फ़ाइलों में आकृतियों को लॉक या अनलॉक करता है, प्रस्तुतियों को सुरक्षित करता है जबकि नियंत्रित संपादनों की अनुमति देता है और तेज़ डिलीवरी प्रदान करता है।"
---
## **पृष्ठभूमि**

Aspose.Slides का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में Microsoft PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। इस प्रकार Aspose.Slides का उपयोग करने वाले अनुप्रयोगों के उपयोगकर्ताओं को उत्पन्न प्रस्तुतियों तक पहुंच मिलती है, इसलिए उन्हें संपादन से बचाना एक आम चिंता है। यह महत्वपूर्ण है कि स्वचालित रूप से उत्पन्न प्रस्तुतियों में उनका मूल स्वरूप और सामग्री बनी रहे।

यह लेख समझाता है कि प्रस्तुतियों और स्लाइड्स की संरचना कैसे होती है और Aspose.Slides for C++ प्रस्तुति पर सुरक्षा कैसे लागू कर सकता है और बाद में उसे हटाया जा सकता है। यह डेवलपर्स को यह नियंत्रित करने का तरीका प्रदान करता है कि उनके अनुप्रयोगों द्वारा उत्पन्न प्रस्तुतियों का उपयोग कैसे किया जाए।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में स्वचालित आकृतियों, तालिकाओं, OLE ऑब्जेक्ट्स, समूहित आकृतियों, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर्स और अन्य तत्वों जैसी घटक होते हैं जिनका उपयोग प्रस्तुति बनाने के लिए किया जाता है। Aspose.Slides for C++ में, स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा प्रतिनिधित्व किया जाता है जो [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या उस वर्ग से विरासत में लेता है।

PPTX की संरचना जटिल है, इसलिए PPT के विपरीत, जहाँ सभी प्रकार की आकृतियों के लिए एक सामान्य लॉक उपयोग किया जा सकता है, विभिन्न आकृति प्रकारों को अलग-अलग लॉक की आवश्यकता होती है। [IBaseShapeLock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseshapelock/) इंटरफ़ेस PPTX के लिए सामान्य लॉकिंग क्लास है। Aspose.Slides for C++ में PPTX के लिए निम्नलिखित प्रकार के लॉक समर्थित हैं:

- [IAutoShapeLock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshapelock/) ऑटोशेप्स को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iconnectorlock/) कनेक्टर आकृतियों को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igraphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट्स को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igroupshapelock/) समूह आकृतियों को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframelock/) चित्र फ्रेम को लॉक करता है।   

एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट में सभी shape ऑब्जेक्ट्स पर किया गया कोई भी कार्य सम्पूर्ण प्रस्तुति पर लागू होता है।

## **सुरक्षा लागू करना और हटाना**

सुरक्षा लागू करने से यह सुनिश्चित होता है कि प्रस्तुति को संपादित नहीं किया जा सकता। यह प्रस्तुति की सामग्री की सुरक्षा के लिए एक उपयोगी तकनीक है।

### **PPTX आकृतियों पर सुरक्षा लागू करें**

Aspose.Slides for C++ स्लाइड पर आकृतियों के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

जैसा कि पहले उल्लेख किया गया है, प्रत्येक shape वर्ग का एक संबंधित shape-lock वर्ग सुरक्षा के लिए होता है। यह लेख NoSelect, NoMove और NoResize लॉक पर केंद्रित है। ये लॉक सुनिश्चित करते हैं कि आकृतियों को चयन नहीं किया जा सकता (माउस क्लिक या अन्य चयन विधियों से) और उन्हें नहीं हिला या आकार बदला जा सकता।

निम्नलिखित कोड नमूना प्रस्तुति में सभी shape प्रकारों पर सुरक्षा लागू करता है।

```cpp
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// प्रस्तुति में सभी स्लाइड्स को पार करना।
for (auto&& slide : presentation->get_Slides())	{

	// स्लाइड में सभी आकृतियों को पार करना।
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// आकृति को ऑटोशेप में टाइप-कास्ट करना और उसका शैप लॉक प्राप्त करना।
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// आकृति को ग्रुप शैप में टाइप-कास्ट करना और उसका शैप लॉक प्राप्त करना।
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// आकृति को कनेक्टर शैप में टाइप-कास्ट करना और उसका शैप लॉक प्राप्त करना।
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// आकृति को पिक्चर फ्रेम में टाइप-कास्ट करना और उसका शैप लॉक प्राप्त करना।
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// प्रस्तुति फ़ाइल को सहेजना।
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **सुरक्षा हटाएँ**

एक shape को अनलॉक करने के लिए, लागू किए गए लॉक के मान को `false` सेट करें। निम्नलिखित कोड नमूना दिखाता है कि लॉक्ड प्रस्तुति में आकृतियों को कैसे अनलॉक किया जाए।

```cpp
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// प्रस्तुति में सभी स्लाइड्स को पार करना।
for (auto&& slide : presentation->get_Slides())	{

	// स्लाइड में सभी आकृतियों को पार करना।
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// आकृति को ऑटोशेप में टाइप-कास्ट करना और उसका शैप लॉक प्राप्त करना।
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// आकृति को ग्रुप शैप में टाइप-कास्ट करना और उसका शैप लॉक प्राप्त करना।
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// आकृति को कनेक्टर शैप में टाइप-कास्ट करना और उसका शैप लॉक प्राप्त करना।
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// आकृति को पिक्चर फ्रेम में टाइप-कास्ट करना और उसका शैप लॉक प्राप्त करना।
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// प्रस्तुति फ़ाइल को सहेजना।
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **निष्कर्ष**

Aspose.Slides प्रस्तुति में आकृतियों की सुरक्षा के लिए कई विकल्प प्रदान करता है। आप एक व्यक्तिगत आकृति को लॉक कर सकते हैं या प्रस्तुति में सभी आकृतियों के माध्यम से इटरेट करके प्रत्येक को लॉक कर पूरी फ़ाइल को प्रभावी रूप से सुरक्षित कर सकते हैं। आप लॉक मान को `false` सेट करके सुरक्षा हटा सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में shape लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हाँ। लॉक फ़ाइल के भीतर ऑब्जेक्ट्स के संपादन को सीमित करता है, जबकि [password protection](/slides/hi/cpp/password-protected-presentation/) खोलने और/या परिवर्तन सहेजने तक पहुंच को नियंत्रित करता है। ये तंत्र एक-दूसरे को पूरक हैं और साथ मिलकर काम करते हैं।

**क्या मैं अन्य स्लाइड्स को प्रभावित किए बिना विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ?**

हाँ। चयनित स्लाइड्स पर आकृतियों पर लॉक लागू करें; शेष स्लाइड्स संपादन योग्य रहेंगी।

**क्या shape लॉक समूहित ऑब्जेक्ट्स और कनेक्टर्स पर लागू होते हैं?**

हाँ। समूह, कनेक्टर्स, ग्राफ़िक ऑब्जेक्ट्स और अन्य shape प्रकारों के लिए विशिष्ट लॉक प्रकार समर्थित हैं।