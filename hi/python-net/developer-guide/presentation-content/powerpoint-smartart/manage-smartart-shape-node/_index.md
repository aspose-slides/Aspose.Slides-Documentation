---
title: Python का उपयोग करके प्रस्तुतियों में SmartArt आकार नोड्स प्रबंधित करें
linktitle: SmartArt आकार नोड
type: docs
weight: 30
url: /hi/python-net/manage-smartart-shape-node/
keywords:
- SmartArt नोड
- चाइल्ड नोड
- नोड जोड़ें
- नोड स्थिति
- नोड तक पहुँचें
- नोड हटाएँ
- कस्टम स्थिति
- असिस्टेंट नोड
- फ़िल फ़ॉर्मेट
- नोड रेंडर करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PPT, PPTX और ODP में SmartArt आकार नोड्स प्रबंधित करें। साफ़ कोड नमूने और टिप्स प्राप्त करें ताकि आप अपनी प्रस्तुतियों को सुगम बना सकें।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों में SmartArt ग्राफिक्स नोड्स के माध्यम से व्यवस्थित होते हैं जो पाठ रखते हैं और आरेख की संरचना को परिभाषित करते हैं। Aspose.Slides आपको इन SmartArt नोड्स के साथ प्रोग्रामेटिक रूप से काम करने की सुविधा देता है: नए नोड्स और चाइल्ड नोड्स जोड़ना, किसी विशेष स्थिति पर चाइल्ड नोड्स सम्मिलित करना, मौजूदा नोड्स तक पहुँचना, और उनका पाठ, स्तर तथा स्थिति पढ़ना।

यह लेख SmartArt शेप नोड्स को प्रबंधित करने के तरीके बताता है। यह दिखाता है कि नोड्स को कैसे हटाएँ, इंडेक्स या स्थिति के आधार पर चाइल्ड नोड्स के साथ कैसे काम करें, असिस्टेंट नोड को सामान्य नोड में बदलें, SmartArt नोड शेप की स्थिति, आकार और घूर्णन समायोजित करें, नोड फ़िल फ़ॉर्मेट सेट करें, और SmartArt चाइल्ड नोड की थंबनेल छवि जेनरेट करें।

## **SmartArt नोड जोड़ें**
Aspose.Slides for Python via .NET ने SmartArt शेप्स को सबसे आसान तरीके से प्रबंधित करने के लिए सबसे सरल API प्रदान किया है। नीचे दिया गया नमूना कोड SmartArt शेप के अंदर नोड और चाइल्ड नोड जोड़ने में मदद करेगा।

- `Presentation` क्लास का एक उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।
- उसके Index का उपयोग करके पहले स्लाइड का रेफ़रेंस प्राप्त करें।
- पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जाँचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArt में टाइपकैस्ट करें।
- SmartArt के NodeCollection में एक नया नोड जोड़ें और TextFrame में पाठ सेट करें।
- अब, नवीनतम जोड़े गए SmartArt नोड में एक चाइल्ड नोड जोड़ें और TextFrame में पाठ सेट करें।
- प्रस्तुति को सहेजें।

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# वांछित प्रस्तुति लोड करें
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    for shape in pres.slides[0].shapes:

        # जांचें कि शेप SmartArt प्रकार का है
        if type(shape) is art.SmartArt:
            # नया SmartArt नोड जोड़ें
            node1 = shape.all_nodes.add_node()
            # टेक्स्ट जोड़ें
            node1.text_frame.text = "Test"

            # पैरेंट नोड में नया चाइल्ड नोड जोड़ें। यह संग्रह के अंत में जोड़ा जाएगा
            new_node = node1.child_nodes.add_node()

            # टेक्स्ट जोड़ें
            new_node.text_frame.text = "New Node Added"

    # प्रस्तुति सहेजें
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **विशिष्ट स्थिति पर SmartArt नोड जोड़ें**
नीचे दिए गए नमूना कोड में बताया गया है कि कैसे SmartArt शेप के संबंधित नोड्स के अंतर्गत चाइल्ड नोड्स को विशिष्ट स्थिति पर जोड़ा जाए।

- `Presentation` क्लास का एक उदाहरण बनाएं।
- उसके Index का उपयोग करके पहले स्लाइड का रेफ़रेंस प्राप्त करें।
- एक्सेस किए गए स्लाइड में StackedList प्रकार का SmartArt शेप जोड़ें।
- जोड़े गए SmartArt शेप में पहला नोड एक्सेस करें।
- अब, चयनित नोड के लिए स्थिति 2 पर चाइल्ड नोड जोड़ें और उसका पाठ सेट करें।
- प्रस्तुति को सहेजें।

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# प्रस्तुति इंस्टेंस बनाना
with slides.Presentation() as pres:
    # प्रस्तुति स्लाइड तक पहुँचें
    slide = pres.slides[0]

    # Smart Art IShape जोड़ें
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # इंडेक्स 0 पर SmartArt नोड तक पहुँच रहे हैं
    node = smart.all_nodes[0]

    # पैरेंट नोड में स्थिति 2 पर नया चाइल्ड नोड जोड़ें
    chNode = node.child_nodes.add_node_by_position(2)

    # टेक्स्ट जोड़ें
    chNode.text_frame.text = "Sample text Added"

    # प्रस्तुति सहेजें
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **SmartArt नोड तक पहुँचें**
निम्नलिखित नमूना कोड SmartArt शेप के भीतर नोड्स तक पहुँचने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt के LayoutType को नहीं बदल सकते क्योंकि यह केवल पढ़ने योग्य है और SmartArt शेप जोड़ते समय ही सेट होता है।

- `Presentation` क्लास का एक उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।
- उसके Index का उपयोग करके पहले स्लाइड का रेफ़रेंस प्राप्त करें।
- पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जाँचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArt में टाइपकैस्ट करें।
- SmartArt शेप के सभी नोड्स को ट्रैवर्स करें।
- SmartArt नोड की स्थिति, स्तर और पाठ जैसी जानकारी प्रदर्शित करें।

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# वांछित प्रस्तुति लोड करें
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    for shape in pres.slides[0].shapes:
        # जांचें कि शेप SmartArt प्रकार का है
        if type(shape) is art.SmartArt:
            # SmartArt के भीतर सभी नोड्स को ट्रैवर्स करें
            for i in range(len(shape.all_nodes)):
                # इंडेक्स i पर SmartArt नोड तक पहुँच रहे हैं
                node = shape.all_nodes[i]

                # SmartArt नोड पैरामीटर प्रिंट कर रहे हैं
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```



## **SmartArt चाइल्ड नोड तक पहुँचें**
निम्नलिखित नमूना कोड SmartArt शेप के संबंधित नोड्स के अंतर्गत चाइल्ड नोड्स तक पहुँचने में मदद करेगा।

- `PresentationEx` क्लास का एक उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।
- उसके Index का उपयोग करके पहले स्लाइड का रेफ़रेंस प्राप्त करें।
- पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जाँचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArtEx में टाइपकैस्ट करें।
- SmartArt शेप के सभी नोड्स को ट्रैवर्स करें।
- प्रत्येक चयनित SmartArt शेप नोड के लिए, संबंधित नोड के भीतर सभी चाइल्ड नोड्स को ट्रैवर्स करें।
- चाइल्ड नोड की स्थिति, स्तर और पाठ जैसी जानकारी प्रदर्शित करें।

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# वांछित प्रस्तुति लोड करें
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    for shape in pres.slides[0].shapes:
        # जांचें कि शेप SmartArt प्रकार का है
        if type(shape) is art.SmartArt:
            # SmartArt के भीतर सभी नोड्स को ट्रैवर्स करें
            for node0 in shape.all_nodes:
                # चाइल्ड नोड्स को ट्रैवर्स कर रहे हैं
                for j in range(len(node0.child_nodes)):
                    # SmartArt नोड में चाइल्ड नोड तक पहुँच रहे हैं
                    node = node0.child_nodes[j]

                    # SmartArt चाइल्ड नोड पैरामीटर प्रिंट कर रहे हैं
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **विशिष्ट स्थिति पर SmartArt चाइल्ड नोड तक पहुँचें**
इस उदाहरण में हम सीखेंगे कि कैसे विशिष्ट स्थिति पर स्थित चाइल्ड नोड्स को संबंधित नोड्स के अंतर्गत एक्सेस किया जाए।

- `Presentation` क्लास का एक उदाहरण बनाएं।
- उसके Index का उपयोग करके पहले स्लाइड का रेफ़रेंस प्राप्त करें।
- StackedList प्रकार का SmartArt शेप जोड़ें।
- जोड़ा गया SmartArt शेप एक्सेस करें।
- एक्सेस किए गए SmartArt शेप में इंडेक्स 0 पर नोड एक्सेस करें।
- अब, GetNodeByPosition() मेथड का उपयोग करके एक्सेस किए गए SmartArt नोड के लिए स्थिति 1 पर चाइल्ड नोड एक्सेस करें।
- चाइल्ड नोड की स्थिति, स्तर और पाठ जैसी जानकारी प्रदर्शित करें।

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# प्रस्तुति को इंस्टैंशिएट करें
with slides.Presentation() as pres:
    # पहले स्लाइड तक पहुँच रहे हैं
    slide = pres.slides[0]
    # पहले स्लाइड में SmartArt शेप जोड़ें
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # इंडेक्स 0 पर SmartArt नोड तक पहुँच रहे हैं
    node = smart.all_nodes[0]
    # पैरेंट नोड में स्थिति 1 पर चाइल्ड नोड तक पहुँच रहे हैं
    position = 1
    chNode = node.child_nodes[position] 
    # SmartArt चाइल्ड नोड पैरामीटर प्रिंट कर रहे हैं
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```



## **SmartArt नोड हटाएँ**
इस उदाहरण में हम सीखेंगे कि SmartArt शेप के भीतर नोड्स को कैसे हटाया जाए।

- `Presentation` क्लास का एक उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।
- उसके Index का उपयोग करके पहले स्लाइड का रेफ़रेंस प्राप्त करें।
- पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जाँचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArt में टाइपकैस्ट करें।
- जाँचें कि SmartArt में 0 से अधिक नोड्स हैं।
- हटाए जाने वाले SmartArt नोड का चयन करें।
- अब, RemoveNode() मेथड का उपयोग करके चयनित नोड को हटाएँ और प्रस्तुति सहेजें।

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# वांछित प्रस्तुति लोड करें
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    for shape in pres.slides[0].shapes:
        # जांचें कि शेप SmartArt प्रकार का है
        if type(shape) is art.SmartArt:
            # शेप को SmartArtEx में टाइपकैस्ट करें
            if len(shape.all_nodes) > 0:
                # इंडेक्स 0 पर SmartArt नोड तक पहुँच रहे हैं
                node = shape.all_nodes[0]

                # चयनित नोड को हटाया जा रहा है
                shape.all_nodes.remove_node(node)

    # प्रस्तुति सहेजें
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **विशिष्ट स्थिति पर SmartArt नोड हटाएँ**
इस उदाहरण में हम सीखेंगे कि SmartArt शेप के भीतर नोड्स को विशिष्ट स्थिति पर कैसे हटाया जाए।

- `Presentation` क्लास का एक उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।
- उसके Index का उपयोग करके पहले स्लाइड का रेफ़रेंस प्राप्त करें।
- पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जाँचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArt में टाइपकैस्ट करें।
- इंडेक्स 0 पर SmartArt शेप नोड का चयन करें।
- अब, जाँचें कि चयनित SmartArt नोड में 2 से अधिक चाइल्ड नोड्स हैं।
- अब, RemoveNodeByPosition() मेथड का उपयोग करके स्थिति 1 पर नोड हटाएँ।
- प्रस्तुति को सहेजें।

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# वांछित प्रस्तुति लोड करें
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    for shape in pres.slides[0].shapes:
        # जांचें कि शेप SmartArt प्रकार का है
        if type(shape) is art.SmartArt:
            # शेप को SmartArt में टाइपकैस्ट करें
            if len(shape.all_nodes) > 0:
                # इंडेक्स 0 पर SmartArt नोड तक पहुँच रहे हैं
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # स्थिति 1 पर चाइल्ड नोड को हटाया जा रहा है
                    node.child_nodes.remove_node(1)

    # प्रस्तुति सहेजें
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```



## **SmartArt में चाइल्ड नोड के लिए कस्टम स्थिति सेट करें**
अब Aspose.Slides for Python via .NET SmartArtShape के X और Y प्रॉपर्टीज़ सेट करने के लिए समर्थन प्रदान करता है। नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे कस्टम SmartArtShape की स्थिति, आकार और घूर्णन सेट किया जाए; कृपया ध्यान दें कि नए नोड्स जोड़ने से सभी नोड्स की स्थितियों और आकारों की पुनर्गणना होती है।

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# वांछित प्रस्तुति लोड करें
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# SmartArt शेप को नई स्थिति में ले जाएँ
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# SmartArt शेप की चौड़ाइयाँ बदलें
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# SmartArt शेप की ऊँचाई बदलें
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# SmartArt शेप का घूर्णन बदलें
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```



## **असिस्टेंट नोड जाँचें**
निम्नलिखित नमूना कोड में हम यह जांचेंगे कि SmartArt नोड कलेक्शन में असिस्टेंट नोड्स कैसे पहचानें और उनका परिवर्तन कैसे करें।

- `PresentationEx` क्लास का एक उदाहरण बनाएँ और SmartArt शेप के साथ प्रस्तुति लोड करें।
- उसके Index का उपयोग करके दूसरा स्लाइड रेफ़रेंस प्राप्त करें।
- पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जाँचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArtEx में टाइपकैस्ट करें।
- SmartArt शेप के सभी नोड्स को ट्रैवर्स करें और देखें कि क्या वे असिस्टेंट नोड्स हैं।
- असिस्टेंट नोड की स्थिति को सामान्य नोड में बदलें।
- प्रस्तुति को सहेजें।

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# प्रस्तुति इंस्टेंस बनाना
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # पहले स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    for shape in pres.slides[0].shapes:
        # जांचें कि शेप SmartArt प्रकार का है
        if type(shape) is art.SmartArt:
            # SmartArt शेप के सभी नोड्स को ट्रैवर्स कर रहे हैं
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # जांचें कि नोड असिस्टेंट नोड है
                if node.is_assistant:
                    # असिस्टेंट नोड को false सेट करके सामान्य नोड बनाएं
                    node.is_assistant = False
    # प्रस्तुति सहेजें
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **नोड का Fill फ़ॉर्मेट सेट करें**
Aspose.Slides for Python via .NET कस्टम SmartArt शेप्स जोड़ने और उनके Fill फ़ॉर्मेट सेट करने की सुविधा देता है। यह लेख बताता है कि कैसे SmartArt शेप्स बनाएँ, एक्सेस करें और उनके Fill फ़ॉर्मेट को Aspose.Slides for Python via .NET की सहायता से सेट करें।

कृपया नीचे दिए चरणों का पालन करें:

- `Presentation` क्लास का एक उदाहरण बनाएँ।
- स्लाइड का इंडेक्स उपयोग करके उसका रेफ़रेंस प्राप्त करें।
- LayoutType सेट करके SmartArt शेप जोड़ें।
- SmartArt शेप नोड्स के लिए FillFormat सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # स्लाइड तक पहुँच रहे हैं
    slide = presentation.slides[0]

    # SmartArt शेप और नोड्स जोड़ रहे हैं
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # नोड के fill रंग को सेट कर रहे हैं
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # प्रस्तुति सहेज रहे हैं
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **SmartArt चाइल्ड नोड का थंबनेल उत्पन्न करें**
डिवेलपर्स नीचे दिए गए चरणों का पालन करके SmartArt चाइल्ड नोड का थंबनेल बना सकते हैं:

1. `Presentation` क्लास को इन्स्टैंशिएट करें जो PPTX फ़ाइल का प्रतिनिधित्व करता है।
2. SmartArt जोड़ें।
3. उसके Index का उपयोग करके नोड का रेफ़रेंस प्राप्त करें।
4. थंबनेल इमेज प्राप्त करें।
5. थंबनेल इमेज को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

नीचे दिया गया उदाहरण SmartArt चाइल्ड नोड का थंबनेल जेनरेट करता है

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# PPTX फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंशिएट करें 
with slides.Presentation() as presentation: 
    # SmartArt जोड़ें 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # इंडेक्स का उपयोग करके नोड का रेफ़रेंस प्राप्त करें  
    node = smart.nodes[1]

    # थंबनेल प्राप्त करें
    with node.shapes[0].get_image() as bmp:
        # थंबनेल सहेजें
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**क्या SmartArt एनीमेशन समर्थित है?**

हाँ। SmartArt को सामान्य शेप के रूप में माना जाता है, इसलिए आप [standard animations](/slides/hi/python-net/shape-animation/) (entrance, exit, emphasis, motion paths) लागू कर सकते हैं और टाइमिंग समायोजित कर सकते हैं। आवश्यक होने पर आप SmartArt नोड्स के भीतर शेप्स को भी एनीमेट कर सकते हैं।

**यदि किसी स्लाइड पर SmartArt का आंतरिक ID अज्ञात हो तो उसे कैसे विश्वसनीय रूप से ढूँढें?**

[alternative text](/slides/hi/python-net/smartart-alternative-text/) का उपयोग करके असाइन करें और खोजें। SmartArt पर एक विशिष्ट AltText सेट करने से आप इसे प्रोग्रामेटिक रूप से आंतरिक पहचानकर्ताओं पर निर्भर हुए बिना खोज सकते हैं।

**क्या प्रस्तुति को PDF में कनवर्ट करने पर SmartArt का रूप बना रहेगा?**

हाँ। Aspose.Slides PDF निर्यात के दौरान [PDF export](/slides/hi/python-net/convert-powerpoint-to-pdf/) के दौरान उच्च दृश्य सटीकता के साथ SmartArt को रेंडर करता है, जिससे लेआउट, रंग और इफ़ेक्ट्स संरक्षित रहते हैं।

**क्या मैं पूरे SmartArt की छवि (प्रिव्यू या रिपोर्ट के लिए) निकाल सकता हूँ?**

हाँ। आप SmartArt शेप को [raster formats](/slides/hi/python-net/smartart-get-image/) या [SVG](/slides/hi/python-net/smartart-write-as-svg/) में रेंडर कर सकते हैं, जिससे थंबनेल, रिपोर्ट या वेब उपयोग के लिए उपयुक्त स्केलेबल आउटपुट प्राप्त होता है।