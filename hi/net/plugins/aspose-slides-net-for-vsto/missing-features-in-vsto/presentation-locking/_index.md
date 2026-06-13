---
title: प्रेज़ेंटेशन लॉकिंग
type: docs
weight: 110
url: /hi/net/presentation-locking/
---
## **प्रेज़ेंटेशन लॉकिंग**
एक सामान्य उपयोग **Aspose.Slides** का यह है कि स्वचालित कार्यप्रवाह के हिस्से के रूप में Microsoft PowerPoint 2007 (PPTX) प्रेज़ेंटेशन बनाना, अद्यतन करना और सहेजना। ऐसे एप्लिकेशन के उपयोगकर्ता जिन्हें Aspose.Slides इस तरह से उपयोग किया जाता है, आउटपुट प्रेज़ेंटेशन तक पहुँच प्राप्त करते हैं। उन्हें संपादन से बचाना एक सामान्य चिंता है। यह महत्वपूर्ण है कि स्वचालित रूप से जनित प्रेज़ेंटेशन अपने मूल स्वरूप और सामग्री को बनाए रखें।

यह बताता है कि प्रेज़ेंटेशन और स्लाइड्स कैसे निर्मित होते हैं और Aspose.Slides for .NET कैसे एक प्रेज़ेंटेशन पर सुरक्षा लागू कर सकता है और फिर उसे हटा सकता है। यह विशेषता Aspose.Slides के लिए विशिष्ट है और लेखन के समय माइक्रोसॉफ्ट PowerPoint में उपलब्ध नहीं है। यह डेवलपर्स को इस बात का नियंत्रण करने का तरीका देता है कि उनके एप्लिकेशन द्वारा निर्मित प्रेज़ेंटेशन का उपयोग कैसे किया जाता है।

## **स्लाइड का संघटन**
एक PPTX स्लाइड कई घटकों से बनी होती है जैसे ऑटो शेप्स, टेबल्स, OLE ऑब्जेक्ट्स, ग्रुप्ड शेप्स, पिक्चर फ्रेम्स, वीडियो फ्रेम्स, कनेक्टर्स और विभिन्न अन्य तत्व जो प्रेज़ेंटेशन बनाने के लिए उपलब्ध हैं।

Aspose.Slides for .NET में, स्लाइड पर प्रत्येक तत्व को एक Shape ऑब्जेक्ट में बदला जाता है। दूसरे शब्दों में, स्लाइड पर प्रत्येक तत्व या तो एक Shape ऑब्जेक्ट है या Shape ऑब्जेक्ट से व्युत्पन्न कोई ऑब्जेक्ट है।

PPTX की संरचना जटिल है, इसलिए PPT के विपरीत, जहाँ सभी प्रकार के शेप्स के लिए एक सामान्य लॉक प्रयोग किया जा सकता है, विभिन्न शेप टाइप के लिए विभिन्न प्रकार के लॉक होते हैं। BaseShapeLock क्लास सामान्य PPTX लॉकिंग क्लास है। PPTX के लिए Aspose.Slides for .NET में निम्नलिखित प्रकार के लॉक समर्थित हैं।

- AutoShapeLock ऑटो शेप्स को लॉक करता है।
- ConnectorLock कनेक्टर शेप्स को लॉक करता है।
- GraphicalObjectLock ग्राफिकल ऑब्जेक्ट्स को लॉक करता है।
- GroupshapeLock ग्रुप शेप्स को लॉक करता है।
- PictureFrameLock पिक्चर फ्रेम्स को लॉक करता है।

Presentation ऑब्जेक्ट में सभी Shape ऑब्जेक्ट्स पर किया गया कोई भी कार्य पूरे प्रेज़ेंटेशन पर लागू होता है।

## **सुरक्षा लागू करना और हटाना**
सुरक्षा लागू करने से यह सुनिश्चित होता है कि प्रेज़ेंटेशन को संपादित नहीं किया जा सकता। यह प्रेज़ेंटेशन की सामग्री को सुरक्षित रखने की एक उपयोगी तकनीक है।

**PPTX शेप्स पर सुरक्षा लागू करना**

Aspose.Slides for .NET स्लाइड पर एक शेप को संभालने के लिए Shape क्लास प्रदान करता है।

जैसा कि पहले बताया गया, प्रत्येक शेप क्लास के साथ सुरक्षा के लिए एक संबंधित shape lock क्लास जुड़ी होती है। यह लेख NoSelect, NoMove और NoResize लॉक पर केंद्रित है। ये लॉक सुनिश्चित करते हैं कि शेप्स को चयन (माउस क्लिक या अन्य चयन विधियों से) नहीं किया जा सकता, और इन्हें नहीं हटाया या आकार बदला जा सकता।

नीचे दिया गया कोड नमूना प्रेज़ेंटेशन में सभी शेप प्रकारों पर सुरक्षा लागू करता है।

``` csharp

 //PPTX फ़ाइल को दर्शाने वाली Presentation क्लास को instantiate करें

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//PPTX फ़ाइल को दर्शाने वाली Presentation क्लास को instantiate करें


//प्रेज़ेंटेशन में स्लाइड्स तक पहुँचने के लिए ISlide ऑब्जेक्ट

SlideEx slide = pTemplate.Slides[0];

//अस्थायी शेप्स को रखने के लिए IShape ऑब्जेक्ट

ShapeEx shape;

//प्रेज़ेंटेशन की सभी स्लाइड्स पर इटररेट कर रहे हैं

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//स्लाइड्स में सभी शेप्स पर इटररेट कर रहे हैं

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//यदि शेप ऑटोशेप है

		if (shape is AutoShapeEx)

		{

			//ऑटो शेप में टाइप कास्टिंग और ऑटो शेप लॉक प्राप्त करना

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//शेप्स के लॉक लागू करना

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//यदि शेप ग्रुप शेप है

		else if (shape is GroupShapeEx)

		{

			//ग्रुप शेप में टाइप कास्टिंग और ग्रुप शेप लॉक प्राप्त करना

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//शेप्स के लॉक लागू करना

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//यदि शेप कनेक्टर है

		else if (shape is ConnectorEx)

		{

			//कनेक्टर शेप में टाइप कास्टिंग और कनेक्टर शेप लॉक प्राप्त करना

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//शेप्स के लॉक लागू करना

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//यदि शेप पिक्चर फ्रेम है

		else if (shape is PictureFrameEx)

		{

			//पिक्चर फ्रेम शेप में टाइप कास्टिंग और पिक्चर फ्रेम लॉक प्राप्त करना

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//शेप्स के लॉक लागू करना

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//प्रेज़ेंटेशन फ़ाइल को सहेज रहे हैं

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**सुरक्षा हटाना**

Aspose.Slides for .NET द्वारा लागू सुरक्षा को केवल Aspose.Slides for .NET के साथ ही हटाया जा सकता है। एक शेप को अनलॉक करने के लिए, लागू लॉक का मान false सेट करें। नीचे दिया गया कोड नमूना दिखाता है कि लॉक किए गए प्रेज़ेंटेशन में शेप्स को कैसे अनलॉक किया जाता है।

``` csharp

 //वांछित प्रेज़ेंटेशन खोलें
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//प्रेज़ेंटेशन में स्लाइड्स तक पहुँचने के लिए ISlide ऑब्जेक्ट
SlideEx slide = pTemplate.Slides[0];

//अस्थायी शेप्स को रखने के लिए IShape ऑब्जेक्ट
ShapeEx shape;

//प्रेज़ेंटेशन की सभी स्लाइड्स पर इटररेट कर रहे हैं
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	 //स्लाइड्स में सभी शेप्स पर इटररेट कर रहे हैं
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//यदि शेप ऑटोशेप है
		if (shape is AutoShapeEx)
		{
			//ऑटो शेप में टाइप कास्टिंग और ऑटो शेप लॉक प्राप्त करना
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//शेप्स के लॉक लागू कर रहे हैं
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//यदि शेप ग्रुप शेप है
		else if (shape is GroupShapeEx)
		{
			//ग्रुप शेप में टाइप कास्टिंग और ग्रुप शेप लॉक प्राप्त करना
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//शेप्स के लॉक लागू कर रहे हैं
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//यदि शेप कनेक्टर शेप है
		else if (shape is ConnectorEx)
		{
			//कनेक्टर शेप में टाइप कास्टिंग और कनेक्टर शेप लॉक प्राप्त करना
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//शेप्स के लॉक लागू कर रहे हैं
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//यदि शेप पिक्चर फ्रेम है
		else if (shape is PictureFrameEx)
		{
			//पिक्चर फ्रेम शेप में टाइप कास्टिंग और पिक्चर फ्रेम लॉक प्राप्त करना
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//शेप्स के लॉक लागू कर रहे हैं
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//प्रेज़ेंटेशन फ़ाइल सहेज रहे हैं
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **नमूना कोड डाउनलोड करें**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)