---
title: Conversione da PPT a formato PPTX
type: docs
weight: 20
url: /it/net/conversion-from-ppt-to-pptx-format/
---
Funzionalità unica di Aspose.Slides che fornisce flessibilità nella conversione delle versioni senza influire sul lavoro.
SaveFormat è un'enumerazione che può convertire il documento nelle estensioni indicate nella tabella sottostante.

|**Nome Membro**|**Valore**|**Descrizione**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |

Di seguito è riportato un frammento di codice che mostra la conversione da PPT a PPTX; è possibile farlo anche al contrario.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Instanzia un oggetto Presentation che rappresenta un file PPTX

Presentation pres = new Presentation(srcFileName);

//Salva la presentazione PPTX nel formato PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Scarica Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)