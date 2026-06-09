---
title: Localizar e Substituir em Apresentação
type: docs
weight: 20
url: /pt/net/find-and-replace-in-presentation/
---
A seguir estão os passos a serem seguidos:

1. Abrir uma apresentação.
1. Pesquisar o texto.
1. Substituir o texto.
1. Salvar a apresentação.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Abrir a apresentação

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Obter todas as caixas de texto na apresentação

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Encontrar o texto a ser substituído

        if (port.Text.Contains(strToFind))

        //Substituir o texto existente pelo novo texto

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Baixar código de exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)