---
title: प्रेज़ेंटेशन में खोज और प्रतिस्थापन
type: docs
weight: 20
url: /hi/net/find-and-replace-in-presentation/
---
निम्नलिखित चरणों का पालन करें:

1. एक प्रस्तुति खोलें।
1. पाठ खोजें।
1. पाठ को बदलें।
1. प्रस्तुति लिखें।

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//प्रस्तुति खोलें

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//प्रस्तुति में सभी टेक्स्ट बॉक्स प्राप्त करें

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //बदलने के लिए टेक्स्ट खोजें

        if (port.Text.Contains(strToFind))

        //मौजूदा टेक्स्ट को नए टेक्स्ट से प्रतिस्थापित करें

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)