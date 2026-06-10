---
title: A prezentáció fájlformátumának lekérése
type: docs
weight: 50
url: /hu/net/get-the-file-format-of-presentation/
---
A fájlformátum lekéréséhez kövesse az alábbi lépéseket:

- Hozzon létre egy **IPresentationInfo** példányt
- Szerezzen információkat a bemutatóról

Az alább megadott példában megkaptuk a fájlformátumot.
## **Példa**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

```
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Futtatható példa letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)