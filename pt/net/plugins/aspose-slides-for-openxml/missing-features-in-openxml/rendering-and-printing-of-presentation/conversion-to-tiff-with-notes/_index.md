---
title: Conversão para Tiff com Notas
type: docs
weight: 10
url: /pt/net/conversion-to-tiff-with-notes/
---
TIFF é um dos vários formatos de imagem amplamente usados que o Aspose.Slides para .NET oferece suporte para converter uma apresentação com notas em imagens. Você também pode gerar miniaturas de slides na visualização de Slide de Notas. Abaixo estão dois trechos de código que mostram como gerar imagens TIFF de uma apresentação na visualização de Slide de Notas.

O método **Save** exposto pela classe **Presentation** pode ser usado para converter toda a apresentação na visualização de Slide de Notas para TIFF. Você também pode gerar uma miniatura de slide na visualização de Slide de Notas para slides individuais.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instancie um objeto Presentation que representa um arquivo de apresentação

Presentation pres = new Presentation(srcFileName);

//Salvando a apresentação em notas TIFF

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)